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
    public partial class TierConfigImporter : AbstractExcelImporter
    {
        private XElement e;
        private TierConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.TIER_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            XElement tierE = new XElement("tier");
            e.Add(tierE);
            tierE.Add(new XAttribute("type", type));
            tierE.Add(new XAttribute("name", name));
            tierE.Add(new XAttribute("star", star));
            tierE.Add(new XAttribute("nextSeasonTierType", nextSeasonTierType));
            tierE.Add(new XAttribute("nextSeasonStar", nextSeasonStar));

            TierConfig c = new TierConfig();
            c.Type = type;
            c.NameResource = nameResource;
            c.BedgeResource = bedgeResource;
            c.Star = star;
            c.NextSeasonTierType = nextSeasonTierType;
            c.NextSeasonStar = nextSeasonStar;
            c.NextMessageId = nextMessageId;
            if (config.TierConfigMap.ContainsKey(type))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，id 重复", this.GetConfigName(), sheetName, row);
                return;
            }
            config.TierConfigMap.Add(type, c);
        }

        protected override void OnAutoParasBegin()
        {
            e = new XElement("root");
            config = new TierConfigTable();
            config.TierConfigMap = new Dictionary<int, TierConfig>();
        }
    }
}
