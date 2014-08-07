namespace XTemplate.Templating
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    internal static class TemplateParser
    {
        private static Regex allNewlineRegex = new Regex(@"^\s*$", RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex directiveEscapeFindingRegex = new Regex("\\\\+(?=\")|\\\\+(?=$)", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private static Regex directiveParsingRegex = new Regex("(?<pname>\\S+?)\\s*=\\s*\"(?<pvalue>.*?)(?<=[^\\\\](\\\\\\\\)*)\"|(?<name>\\S+)", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private const string endTag = @"(?<=[^\\](\\\\)*)#>";
        private static Regex eolEscapeFindingRegex = new Regex(@"\\+(?=$)", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private static Regex escapeFindingRegex = new Regex(@"\\+(?=<\\#)|\\+(?=\\#>)", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private static MatchEvaluator escapeReplacingEvaluator;
        private const string ma = @"(?<=([^\\]|^)(\\\\)*)";
        private static Regex nameValidatingRegex = new Regex(@"^\s*[\w\.]+\s+", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private static Regex newlineAtLineEndRegex = new Regex(@"(?=(\r\n)|\n)[ \t]*$", RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex newlineAtLineStartRegex = new Regex(@"^[ \t]*((\r\n)|\n)", RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex newlineFindingRegex = new Regex(Environment.NewLine, RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex paramValueValidatingRegex = new Regex("[\\w\\.]+\\s*=\\s*\"(.*?)(?<=[^\\\\](\\\\\\\\)*)\"\\s*", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        private const string startTag = @"(?<=([^\\]|^)(\\\\)*)<#";
        private static Regex templateParsingRegex;
        private static Regex unescapedTagFindingRegex = new Regex(@"(^|[^\\])(\\\\)*(<\#|\#>)", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        static TemplateParser()
        {
            escapeReplacingEvaluator = delegate (Match match) {
                if (match.Success && (match.Value != null))
                {
                    int length = (int) Math.Floor((double) (((double) match.Value.Length) / 2.0));
                    return match.Value.Substring(0, length);
                }
                return string.Empty;
            };
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(@"(?<text>^(\\\\)+)(?=<#)|", new object[0]);
            builder.AppendFormat("{0}@(?<directive>.*?){1}|", @"(?<=([^\\]|^)(\\\\)*)<#", @"(?<=[^\\](\\\\)*)#>");
            builder.AppendFormat(@"{0}\!(?<member>.*?){1}|", @"(?<=([^\\]|^)(\\\\)*)<#", @"(?<=[^\\](\\\\)*)#>");
            builder.AppendFormat("{0}=(?<expression>.*?){1}|", @"(?<=([^\\]|^)(\\\\)*)<#", @"(?<=[^\\](\\\\)*)#>");
            builder.AppendFormat("{0}(?<statement>.*?){1}|", @"(?<=([^\\]|^)(\\\\)*)<#", @"(?<=[^\\](\\\\)*)#>");
            builder.AppendFormat(@"(?<text>.+?)(?=((?<=[^\\](\\\\)*)<#))|", new object[0]);
            builder.AppendFormat("(?<text>.+)(?=$)", new object[0]);
            templateParsingRegex = new Regex(builder.ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
        }

        private static void InsertPosition(List<Block> blocks)
        {
            int num = 1;
            int num2 = 1;
            foreach (Block block in blocks)
            {
                if (((block.Type == BlockType.Member) || (block.Type == BlockType.Directive)) || (block.Type == BlockType.Expression))
                {
                    num2 += 3;
                }
                else if (block.Type == BlockType.Statement)
                {
                    num2 += 2;
                }
                block.StartLine = num;
                block.StartColumn = num2;
                MatchCollection matchs = newlineFindingRegex.Matches(block.Text);
                num += matchs.Count;
                if (matchs.Count > 0)
                {
                    num2 = ((block.Text.Length - matchs[matchs.Count - 1].Index) - Environment.NewLine.Length) + 1;
                }
                else
                {
                    num2 += block.Text.Length;
                }
                block.EndLine = num;
                block.EndColumn = num2;
                if (block.Type != BlockType.Text)
                {
                    num2 += 2;
                }
            }
        }

        public static List<Block> Parse(string name, string content)
        {
            List<Block> blocks = new List<Block>();
            if (!string.IsNullOrEmpty(content))
            {
                foreach (Match match in templateParsingRegex.Matches(content))
                {
                    Block item = new Block();
                    Group group = null;
                    if ((group = match.Groups["text"]).Success)
                    {
                        item.Type = BlockType.Text;
                    }
                    else if ((group = match.Groups["directive"]).Success)
                    {
                        item.Type = BlockType.Directive;
                    }
                    else if ((group = match.Groups["member"]).Success)
                    {
                        item.Type = BlockType.Member;
                    }
                    else if ((group = match.Groups["expression"]).Success)
                    {
                        item.Type = BlockType.Expression;
                    }
                    else if ((group = match.Groups["statement"]).Success)
                    {
                        item.Type = BlockType.Statement;
                    }
                    if ((group != null) && group.Success)
                    {
                        item.Text = group.Value;
                        item.Name = name;
                        blocks.Add(item);
                    }
                }
                InsertPosition(blocks);
                foreach (Block block2 in blocks)
                {
                    if (unescapedTagFindingRegex.Match(block2.Text).Success)
                    {
                        throw new TemplateException(block2, @"不可识别的标记！可能有未编码的字符，比如\<#。");
                    }
                }
                StripEscapeCharacters(blocks);
            }
            return blocks;
        }

        public static Directive ParseDirectiveBlock(Block block)
        {
            if (block == null)
            {
                throw new ArgumentNullException("block");
            }
            if (!ValidateDirectiveString(block))
            {
                throw new TemplateException(block, "指令格式错误！");
            }
            MatchCollection matchs = directiveParsingRegex.Matches(block.Text);
            string name = null;
            Dictionary<string, string> parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (Match match in matchs)
            {
                Group group;
                if ((group = match.Groups["name"]).Success)
                {
                    name = group.Value;
                }
                else
                {
                    string key = null;
                    string input = null;
                    if ((group = match.Groups["pname"]).Success)
                    {
                        key = group.Value;
                    }
                    if ((group = match.Groups["pvalue"]).Success)
                    {
                        input = group.Value;
                    }
                    if ((key != null) && (input != null))
                    {
                        if (parameters.ContainsKey(key))
                        {
                            throw new TemplateException(block, string.Format("指令中已存在名为[{0}]的参数！", key));
                        }
                        input = directiveEscapeFindingRegex.Replace(input, escapeReplacingEvaluator);
                        parameters.Add(key, input);
                    }
                }
            }
            if (name != null)
            {
                return new Directive(name, parameters, block);
            }
            return null;
        }

        private static void StripEscapeCharacters(List<Block> blocks)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                Block block = blocks[i];
                block.Text = escapeFindingRegex.Replace(block.Text, escapeReplacingEvaluator);
                if (i != (blocks.Count - 1))
                {
                    block.Text = eolEscapeFindingRegex.Replace(block.Text, escapeReplacingEvaluator);
                }
            }
        }

        internal static void StripExtraNewlines(List<Block> blocks)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                Block block = blocks[i];
                if (block.Type == BlockType.Text)
                {
                    if (i > 0)
                    {
                        Block block2 = blocks[i - 1];
                        if ((block2.Type != BlockType.Expression) && (block2.Type != BlockType.Text))
                        {
                            block.Text = newlineAtLineStartRegex.Replace(block.Text, string.Empty);
                        }
                        if ((block2.Type == BlockType.Member) && ((i == (blocks.Count - 1)) || (blocks[i + 1].Type == BlockType.Member)))
                        {
                            block.Text = allNewlineRegex.Replace(block.Text, string.Empty);
                        }
                    }
                    if (i < (blocks.Count - 1))
                    {
                        Block block3 = blocks[i + 1];
                        if ((block3.Type != BlockType.Expression) && (block3.Type != BlockType.Text))
                        {
                            block.Text = newlineAtLineEndRegex.Replace(block.Text, string.Empty);
                        }
                    }
                }
            }
            Predicate<Block> match = delegate (Block b) {
                if (b.Type == BlockType.Member)
                {
                    return false;
                }
                return string.IsNullOrEmpty(b.Text);
            };
            blocks.RemoveAll(match);
        }

        private static bool ValidateDirectiveString(Block block)
        {
            Match match = nameValidatingRegex.Match(block.Text);
            if (!match.Success)
            {
                return false;
            }
            int length = match.Length;
            MatchCollection matchs = paramValueValidatingRegex.Matches(block.Text);
            if (matchs.Count == 0)
            {
                return false;
            }
            foreach (Match match2 in matchs)
            {
                if (match2.Index != length)
                {
                    return false;
                }
                length += match2.Length;
            }
            if (length != block.Text.Length)
            {
                return false;
            }
            return true;
        }
    }
}

