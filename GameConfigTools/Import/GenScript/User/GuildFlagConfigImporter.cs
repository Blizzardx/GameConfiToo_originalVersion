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
    public partial class GuildFlagConfigImporter : AbstractExcelImporter
    {
        private GuildFlagConfigTable m_Config;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = m_Config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.GUILD_FLAG_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            GuildFlagConfig config = new GuildFlagConfig();
            config.FlagType = flagType;
            config.Id = id;
            config.OptionColorList = colorList;
            config.Texture = texture;

            for (int i = 0; i < colorList.Count; ++i)
            {
                if (!VaildUtil.IsColor(colorList[i]))
                {
                    errMsg = string.Format("{0}.xlsx color formate error{1}£¬ÖØ¸´", this.GetConfigName(), colorList[i]);
                    return;
                }
                colorList[i] = "#" + colorList[i];
            }
            
            if (flagType == 1)
            {
                if (m_Config.IconConfigMap.ContainsKey(id))
                {
                    errMsg = string.Format("{0}.xlsx id{1}£¬ÖØ¸´", this.GetConfigName(), id);
                    return;
                }
                // icon
                m_Config.IconConfigMap.Add(id, config);
                
            }
            else
            {
                if (m_Config.BgConfigMap.ContainsKey(id))
                {
                    errMsg = string.Format("{0}.xlsx id{1}£¬ÖØ¸´", this.GetConfigName(), id);
                    return;
                }
                // bg
                m_Config.BgConfigMap.Add(id, config);
            }
        }

        protected override void OnAutoParasBegin()
        {
            m_Config = new GuildFlagConfigTable();
            m_Config.BgConfigMap = new Dictionary<int, GuildFlagConfig>();
            m_Config.IconConfigMap = new Dictionary<int, GuildFlagConfig>();
        }
    }
}
