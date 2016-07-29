using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using GameConfigTools.Constant;

namespace GameConfigTools.Export
{
    /// <summary>
    /// nameDirtyWordExporter配置的导出实现
    /// </summary>
    public class NameDirtyWordExporter : AbstractExcelExporter
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(NameDirtyWordExporter));

        protected override string[] GetColumns()
        {
            return null;
        }
        protected override string GetConfigName()
        {
            return SysConstant.NAME_DIRTY_WORD_CONFIG;
        }
        protected override string GetSheetName()
        {
            return "名字屏蔽字";
        }
        protected override string[][] GetValues(string xml)
        {
            if (xml == null || xml.Trim() == "")
            {
                return null;
            }
            try
            {
                XElement root = XElement.Parse(xml);
                var words = root.Elements("word");
                string[][] values = new string[words.Count()][];
                int index = 0;
                foreach (var word in words)
                {
                    string[] ss = values[index] = new string[1];
                    ss[0] = word.Value;
                    index++;
                }
                return values;
            }
            catch (Exception e)
            {
                logger.Error("export " + this.GetConfigName() + " error. xml:" + xml, e);
            }
            return null;
        }
    }
}
