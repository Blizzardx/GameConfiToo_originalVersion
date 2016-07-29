using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using GameConfigTools.Constant;

namespace GameConfigTools.Import
{
    public class RandomNameImporter : AbstractExcelImporter
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
            XElement familysElement = new XElement("familyNames");
            XElement namesElement = new XElement("names");
            root.Add(familysElement);
            root.Add(namesElement);

            ISet<string> set = new HashSet<string>();
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
                    string familyName = values[i][0];
                    string name = values[i][1];
                    if (familyName != null && familyName.Trim() != "")
                    {
                        if (set.Add(familyName))
                        {
                            if (this.IsExistSpecial(familyName))
                            {
                                familysElement.Add(new XElement("familyName", new XCData(familyName)));
                            }
                            else
                            {
                                familysElement.Add(new XElement("familyName", familyName));
                            }
                        }
                    }
                    if (name != null && name.Trim() != "")
                    {
                        if (set.Add(name))
                        {
                            if (this.IsExistSpecial(name))
                            {
                                namesElement.Add(new XElement("name", new XCData(name)));
                            }
                            else
                            {
                                namesElement.Add(new XElement("name", name));
                            }
                        }
                    }
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.RANDOM_NAME_CONFIG;
        }
    }
}
