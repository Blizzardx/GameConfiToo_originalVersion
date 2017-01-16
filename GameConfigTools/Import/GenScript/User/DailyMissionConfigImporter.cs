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
    public partial class DailyMissionConfigImporter : AbstractExcelImporter
    {
        private XElement e;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = null;
        }

        protected override string GetConfigName()
        {
            return SysConstant.DAILY_MISSION_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            XElement missionE = new XElement("mission");
            e.Add(missionE);
            missionE.Add(new XAttribute("id", id));
            missionE.Add(new XAttribute("name", name));
            missionE.Add(new XAttribute("nameMessageId", nameMessageId));
            missionE.Add(new XAttribute("descMessageId", descMessageId));
            missionE.Add(new XAttribute("type", type));
            missionE.Add(new XAttribute("sceneId", sceneId));
            missionE.Add(new XAttribute("sceneLimitId", sceneLimitId));
            missionE.Add(new XAttribute("sceneFuncId", sceneFuncId));
            missionE.Add(new XAttribute("completeLimitId", completeLimitId));
            missionE.Add(new XAttribute("awardLimitId", awardLimitId));
            missionE.Add(new XAttribute("awardFuncId", awardFuncId));
            missionE.Add(new XAttribute("activeValue", activeValue));
            missionE.Add(new XAttribute("weight", weight));
            missionE.Add(new XAttribute("order", order));
        }

        protected override void OnAutoParasBegin()
        {
            e = new XElement("root");
        }
    }
}
