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
    /// messageConfig配置的导出实现
    /// </summary>
    public class MessageExporter : AbstractExcelExporter
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MessageExporter));

        protected override string[] GetColumns()
        {
            return null;
        }
        protected override string GetConfigName()
        {
            return SysConstant.MESSAGE_CONFIG;
        }

        protected override string GetSheetName()
        {
            return "message";
        }

        protected override string[][] GetValues(string xml)
        {
            if (xml == null || xml.Trim() == "")
            {
                return null;
            }
            XElement root = XElement.Parse(xml);
            var languages = root.Elements("language");
            int rowSize = 0;
            int columnSize = 0;
            foreach (var language in languages)
            {
                if (languages.Count() > columnSize)
                {
                    columnSize = languages.Count();
                }
                //找出最长的row
                var messages = language.Elements("message");
                if (messages.Count() > rowSize)
                {
                    rowSize = messages.Count();
                }
            }
            
            string[][] values = new string[rowSize + 1][];
            values[0] = new string[columnSize + 1];
            values[0][0] = "MessageId";

            int row = 1;
            int column = 1;

            foreach (var language in languages)
            {
                var messages = language.Elements("message");
                values[0][column++] = language.Attribute("id").Value;
            }

            for (int i = 1; i < rowSize + 1; i++)
            {
                values[i] = new string[columnSize + 1];
            }

            column = 0;
            foreach (var language in languages)
            {
                if (language.Attribute("id").Value == "zh_CN")
                {
                    var messages = language.Elements("message");
                    foreach (var messgae in messages)
                    {
                        values[row][column] = messgae.Attribute("id").Value;
                        row++;
                    }
                }
            }
            
            column = 1;
            foreach (var language in languages)
            {
                row = 1;
                var messages = language.Elements("message");
                foreach (var messgae in messages)
                {
                    values[row][column] = messgae.Value;
                    row++;
                }
                column++;
            }

            return values;
        }
    }
}
