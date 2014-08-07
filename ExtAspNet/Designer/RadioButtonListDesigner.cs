
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RadioButtonListDesigner.cs
 * CreatedOn:   2008-06-20
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;

namespace ExtAspNet
{
   
    public class RadioButtonListDesigner : ControlBaseDesigner
    {
       
        public override string GetDesignTimeHtml()
        {

            RadioButtonList control = CurrentControl as RadioButtonList;


            string content = String.Empty;

            content += "<span style=\"border:solid 1px #999; padding:2px; background-color:#eee;\">RadioButtonList</span>";


            return control.GetDesignTimeHtml(content);
        }


    }
}
