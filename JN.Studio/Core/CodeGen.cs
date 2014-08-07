using System;
using System.Collections.Generic;
using System.Text;
using XCode.DataAccessLayer;
using XTemplate.Templating;
using NewLife.Threading;
using NewLife.Log;
using System.Threading;

namespace JN.Studio.Core
{
    public static class CodeGen
    {
        static CodeGen()
        {
            Template.BaseClassName = "JN.Studio.Core.XCoderBase";
            Template.Debug = true;
        }

        private static Dictionary<String, String> _Templates;
        /// <summary>模版</summary>
        public static Dictionary<String, String> Templates
        {
            get
            {
                if (_Templates == null) _Templates = FileSource.GetTemplates();
                return _Templates;
            }
        }

        /// <summary>
        /// 编译后的模板可以直接使用
        /// </summary>
        private static Dictionary<String, Template> _CompileTemplates = new Dictionary<string,Template>();

        /// <summary>
        /// 自动重置事件，用于标识模板的初始化尚未完成
        /// </summary>
        private static AutoResetEvent[] _AutoResetEvents = new AutoResetEvent[2];
        /// <summary>
        /// 异步编译模板数量
        /// </summary>
        private static Int16 _AsyncCompileNum = 0;

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tables"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static String[] Render(String tableName, List<IDataTable> tables, XConfig config)
        {
            if (tables == null || tables.Count < 1) return null;

            var table = tables.Find(e => e.Name.EqualIgnoreCase(tableName));
            if (tableName == null) return null;

            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            data["Config"] = config;
            data["Tables"] = tables;
            data["Table"] = table;

            String tempName = config.GetTemplateName();
            if(!_CompileTemplates.ContainsKey(tempName) || _CompileTemplates[tempName] == null)
            {
                //--等待系统异步编译的结果
                WaitForAsyncCompile();
                CompileTemplate(config);
            }
            Template tt = _CompileTemplates[tempName];

            List<String> rs = new List<string>();
            foreach (var item in tt.Templates)
            {
                if (item.Included) continue;
                String content = tt.Render(item.Name, data);
                rs.Add(content);
            }

            return rs.ToArray();
        }

        /// <summary>
        /// 异步编译模板
        /// </summary>
        public static void AsyncCompileTemplate()
        {
            if (_AsyncCompileNum < 2)
            {
                for (int i = 0; i < _AutoResetEvents.Length; i++)
                {
                    _AutoResetEvents[i] = new AutoResetEvent(false);
                }

                ThreadPoolX.QueueUserWorkItem(x =>
                {
                    XTrace.WriteLine(String.Format("实体数据[{0}]开始编译。", "PMS"));
                    try
                    {
                        XConfig config = new XConfig(XConfig.TEMPLATE_ENTITY_DATA, "JN.PMS.Entity", "PMS");
                        CompileTemplate(config);
                        XTrace.WriteLine(String.Format("实体数据[{0}]结束编译。", "PMS"));
                    }
                    catch (Exception ex)
                    {
                        XTrace.WriteLine(String.Format("实体数据[{0}]编译报错：{1}", "PMS", ex.Message));
                    }
                    finally
                    {
                        _AsyncCompileNum++;
                        AutoResetEvent autoEvent = x as AutoResetEvent;
                        autoEvent.Set();
                    }


                }, _AutoResetEvents[0]);

                ThreadPoolX.QueueUserWorkItem(x =>
                {
                    XTrace.WriteLine(String.Format("实体业务[{0}]开始编译。", "PMS"));
                    try
                    {
                        XConfig config = new XConfig(XConfig.TEMPLATE_ENTITY_BIZ, "JN.PMS.Entity", "PMS");
                        CompileTemplate(config);
                        XTrace.WriteLine(String.Format("实体业务[{0}]结束编译。", "PMS"));
                    }
                    catch (Exception ex)
                    {
                        XTrace.WriteLine(String.Format("实体业务[{0}]编译报错：{1}", "PMS", ex.Message));
                    }
                    finally
                    {
                        _AsyncCompileNum++;
                        AutoResetEvent autoEvent = x as AutoResetEvent;
                        autoEvent.Set();
                    }

                }, _AutoResetEvents[1]);
            }
        }

        /// <summary>
        /// 等待异步编译
        /// </summary>
        public static void WaitForAsyncCompile()
        {
            while (_AsyncCompileNum < 2)
            {
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 编译模版
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Template CompileTemplate(XConfig config)
        {
            Dictionary<string, string> templates = new Dictionary<string, string>();
            String tempName = config.TemplateName;

            // 系统模版
            foreach (var item in Templates)
            {
                var key = item.Key;
                String name = key.Substring(0, key.IndexOf("."));
                if (name != tempName) continue;

                String content = item.Value;

                // 添加文件头
                if (config.UseHeadTemplate && !String.IsNullOrEmpty(config.HeadTemplate) && key.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                    content = config.HeadTemplate + content;

                templates.Add(key.Substring(name.Length + 1), content);
            }

            Template tt = Template.Create(templates);
            if (tempName.StartsWith("*")) tempName = tempName.Substring(1);
            tt.AssemblyName = tempName;

            // 编译模版。这里至少要处理，只有经过了处理，才知道模版项是不是被包含的
            tt.Compile();

            lock (_CompileTemplates)
            {
                _CompileTemplates[config.GetTemplateName()] = tt;
            }

            return tt;
        }
    }
}
