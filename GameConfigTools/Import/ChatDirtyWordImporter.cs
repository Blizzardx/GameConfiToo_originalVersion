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
    public class ChatDirtyWordImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            ISet<string> set = new HashSet<string>();
            root = new XElement("root");

            DirtywordConfigTable config = new DirtywordConfigTable();
            config.WordSet = new Thrift.Collections.THashSet<string>();
            tbase = config;
            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    string value = values[i][0];
                    if (value == null || value == "")
                    {
                        continue;
                    }
                    if (!set.Add(value))
                    {
                        continue;
                    }
                    if (this.IsExistSpecial(value))
                    {
                        root.Add(new XElement("word", new XCData(value)));
                    }
                    else
                    {
                        root.Add(new XElement("word", value));
                    }

                    config.WordSet.Add(value);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.CHAT_DIRTY_WORD_CONFIG;
        }

        protected override bool UseAnnotation()
        {
            return false;
        }
    }
}
