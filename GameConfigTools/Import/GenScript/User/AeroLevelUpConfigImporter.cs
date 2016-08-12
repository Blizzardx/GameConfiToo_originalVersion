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
    public partial class AeroLevelUpConfigImporter : AbstractExcelImporter
    {
        private AeroLevelUpConfigTable config;
        private XElement root;
        
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;

            root = this.root;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.AERO_LEVEL_UP_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName, int row, string[] line, ref string errMsg)
        {
            if(level <= 1)
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，等级必须大于1级", this.GetConfigName(), sheetName, row);
                return;
            }

            AeroLevelUpConfig c = new AeroLevelUpConfig();
            c.AeroId = aeroId;
            c.Level = level;
            c.ConsumeId = consumeId;
            c.LimitId = limitId;
            c.FuncId = funcId;
            if (!config.AeroLevelUpConfigMap.ContainsKey(aeroId))
            {
                config.AeroLevelUpConfigMap.Add(aeroId, new Dictionary<int, AeroLevelUpConfig>());
            }
            Dictionary<int, AeroLevelUpConfig> dic = config.AeroLevelUpConfigMap[aeroId];

            if(level > 2)
            {
                if(!dic.ContainsKey(level - 1))
                {
                    errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，等级配置必须要连续", this.GetConfigName(), sheetName, row);
                    return;
                }
            }

            dic.Add(level, c);

            XElement levelUpE = new XElement("levelUp");
            root.Add(levelUpE);

            levelUpE.Add(new XAttribute("aeroId", aeroId));
            levelUpE.Add(new XAttribute("level", level));
            levelUpE.Add(new XAttribute("consumeId", consumeId));
            levelUpE.Add(new XAttribute("limitId", limitId));
            levelUpE.Add(new XAttribute("funcId", funcId));
        }

        protected override void OnAutoParasBegin()
        {
            root = new XElement("root");
            config = new AeroLevelUpConfigTable();
            config.AeroLevelUpConfigMap = new Dictionary<int, Dictionary<int, AeroLevelUpConfig>>();
        }
    }
}
