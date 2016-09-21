using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public partial class BattleResultConfigImporter : AbstractExcelImporter
    {
        private XElement rootE;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = rootE;
            tbase = null;
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_RESULT_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName, int row, string[] line, ref string errMsg)
        {
            XElement resultE = new XElement("result");
            rootE.Add(resultE);

            resultE.Add(new XAttribute("id", id));
            resultE.Add(new XAttribute("baseExp", baseExp));
            resultE.Add(new XAttribute("baseGold", baseGold));
            if (itemId1 != 0 && baseCount1 != 0)
            {
                XElement itemE = new XElement("item");
                resultE.Add(itemE);
                itemE.Add(new XAttribute("itemId", itemId1));
                itemE.Add(new XAttribute("count", baseCount1));
            }
            if (itemId2 != 0 && baseCount2 != 0)
            {
                XElement itemE = new XElement("item");
                resultE.Add(itemE);
                itemE.Add(new XAttribute("itemId", itemId2));
                itemE.Add(new XAttribute("count", baseCount2));
            }
            if (itemId3 != 0 && baseCount3 != 0)
            {
                XElement itemE = new XElement("item");
                resultE.Add(itemE);
                itemE.Add(new XAttribute("itemId", itemId3));
                itemE.Add(new XAttribute("count", baseCount3));
            }
        }

        protected override void OnAutoParasBegin()
        {
            rootE = new XElement("root");
        }
    }
}
