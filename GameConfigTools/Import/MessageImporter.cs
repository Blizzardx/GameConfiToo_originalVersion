using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class MessageImporter : AbstractExcelImporter
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

            MessageConfigTable config = new MessageConfigTable();
            config.MessageMap = new Dictionary<string, Dictionary<int, string>>();
            tbase = config;

            HashSet<string> set = new HashSet<string>();
            
            List<XElement> languageList = new List<XElement>();
            List<Dictionary<int, string>> clientLanguageList = new List<Dictionary<int, string>>();
            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string[][] values = sheetValues[sheetIndex];
                string sheetName = sheetNames[sheetIndex];
                
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
                        Dictionary<int, string> dic = new Dictionary<int, string>();
                        clientLanguageList.Add(dic);
                        config.MessageMap.Add(title, dic);
                    }
                }
                List<int> messageIdList = new List<int>();
                for (int i = 1; i < values.Length; i++)
                {
                    int row = i + 1;
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int messageId;
                    if (!int.TryParse(values[i][0], out messageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]错误，messageId:[{4}]必须为整型", this.GetConfigName(), sheetName, row, 1, values[i][0]);
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
                        Dictionary<int, string> dic = clientLanguageList[j - 1];
                        dic.Add(messageId, value);
                    }
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.MESSAGE_CONFIG;
        }
    }
}
