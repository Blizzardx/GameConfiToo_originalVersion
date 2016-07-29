using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using System.Xml.Linq;
using System.Collections;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class GMLanguageImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            root = new XElement("root");

            HashSet<string> set = new HashSet<string>();

            List<XElement> languageList = new List<XElement>();

            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string[][] values = sheetValues[sheetIndex];
                for (int i = 1; i < values[0].Length; i++)
                {
                    if (values.Length < 2)
                    {
                        continue;
                    }
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    string title = values[0][i];
                    if (title == null)
                    {
                        continue;
                    }
                    if (set.Add(title))
                    {
                        XElement language = new XElement("language");
                        language.Add(new XAttribute("id", title));
                        root.Add(language);

                        languageList.Add(language);
                    }
                }
                List<int> messageIdList = new List<int>();
                for (int i = 1; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int messageId;
                    if (!int.TryParse(values[i][0], out messageId))
                    {
                        errMsg = string.Format("[{0},{1}]错误，messageId:{2}必须为整型", i, 1, values[i][0]);
                        return;
                    }
                    messageIdList.Add(messageId);
                }

                for (int i = 1; i < values.Length; i++)
                {
                    for (int j = 1; j < values[i].Length; j++)
                    {
                        string value = values[i][j];
                        if (value == null)
                        {
                            value = "";
                        }
                        if (messageIdList.Count < i)
                        {
                            continue;
                        }

                        XElement language = languageList[j - 1];

                        XElement message = new XElement("message");
                        language.Add(message);
                        int messageId = messageIdList[i - 1];
                        message.Add(new XAttribute("id", messageId));
                        if (this.IsExistSpecial(value))
                        {
                            message.Add(new XCData(value));
                        }
                        else
                        {
                            message.Add(value);
                        }
                    }
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.GM_LANGUAGE_CONFIG;
        }
        protected override bool UseAnnotation()
        {
            return false;
        }
    }
}
