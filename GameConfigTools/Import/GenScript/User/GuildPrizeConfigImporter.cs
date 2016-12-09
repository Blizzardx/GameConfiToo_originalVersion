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
    public partial class GuildPrizeConfigImporter : AbstractExcelImporter
    {
        private GuildPrizeConfigTable config;

        private XElement e;
        private HashSet<int> m_CheckMap;
         
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.GUILD_PRIZE_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            XElement endlessStageE = new XElement("guildPrize");
            e.Add(endlessStageE);
            endlessStageE.Add(new XAttribute("id", id));
            endlessStageE.Add(new XAttribute("itemId", itemId));
            endlessStageE.Add(new XAttribute("itemCount", itemCount));
            endlessStageE.Add(new XAttribute("weight", weight));
            endlessStageE.Add(new XAttribute("hitCount", hitCount));

            if (m_CheckMap.Contains(id))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，Id重复", this.GetConfigName(), sheetName, row);
                return;
            }
            m_CheckMap.Add(id);

            GuildPrizeConfig c = new GuildPrizeConfig();
            c.Id = id;
            c.ItemId = itemId;
            c.Count = itemCount;
            config.GuildPriceConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            e = new XElement("root");
            m_CheckMap = new HashSet<int>();

            config = new GuildPrizeConfigTable();
            config.GuildPriceConfigMap = new Dictionary<int, GuildPrizeConfig>();
        }
    }
}
