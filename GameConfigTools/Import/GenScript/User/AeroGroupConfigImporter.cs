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
    public partial class AeroGroupConfigImporter : AbstractExcelImporter
    {
        private XElement root;
        private AeroGroupConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = this.root;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.AERO_GROUP_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName, int row, string[] line, ref string errMsg)
        {
            XElement groupE = new XElement("group");
            root.Add(groupE);
            groupE.Add(new XAttribute("groupId", groupId));
            groupE.Add(new XAttribute("activeLimitId", activeLimitId));
            groupE.Add(new XAttribute("activeConsumeId", activeConsumeId));

            AeroGroupConfig c = new AeroGroupConfig();
            c.GroupId = groupId;
            c.ShowLimitId = showLimitId;
            c.ActiveMessageId = activeMessageId;
            c.ActiveLimitId = activeLimitId;
            c.ActiveConsumeId = activeConsumeId;
            c.Order = order;
            config.AeroGroupConfigMap.Add(groupId, c);
        }

        protected override void OnAutoParasBegin()
        {
            root = new XElement("root");
            config = new AeroGroupConfigTable();
            config.AeroGroupConfigMap = new Dictionary<int, AeroGroupConfig>();
        }
    }
}
