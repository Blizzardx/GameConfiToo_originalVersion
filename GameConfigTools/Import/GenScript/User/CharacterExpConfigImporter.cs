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
    public partial class CharacterExpConfigImporter : AbstractExcelImporter
    {
        private XElement rootE;
        private CharacterExpConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = rootE;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.CHARACTER_EXP_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if(level != 1)
            {
                if (config.CharacterExpConfigMap.ContainsKey(level))
                {
                    errMsg = string.Format("{0}.xlsx 等级{1}，重复", this.GetConfigName(), level);
                    return;
                }
                if(!config.CharacterExpConfigMap.ContainsKey(level - 1))
                {
                    errMsg = string.Format("{0}.xlsx 等级配置必须要连续", this.GetConfigName());
                    return;
                }
                CharacterExpConfig beforeConfig = config.CharacterExpConfigMap[level - 1];
                if(totalExp <= beforeConfig.TotalExp)
                {
                    errMsg = string.Format("{0}.xlsx 当前等级{1}，经验值不能小于上一个等级的经验值", this.GetConfigName(), level);
                    return;
                }
            }
            CharacterExpConfig c = new CharacterExpConfig();
            c.Level = level;
            c.TotalExp = totalExp;
            c.LevelUpLimitId = levelUpLimitId;
            c.LevelUpFuncId = levelUpFuncId;
            config.CharacterExpConfigMap.Add(level, c);

            XElement levelConfigE = new XElement("level");
            rootE.Add(levelConfigE);

            levelConfigE.Add(new XAttribute("level", level));
            levelConfigE.Add(new XAttribute("totalExp", totalExp));
            levelConfigE.Add(new XAttribute("levelUpLimitId", levelUpLimitId));
            levelConfigE.Add(new XAttribute("levelUpFuncId", levelUpFuncId));
        }

        protected override void OnAutoParasBegin()
        {
            config = new CharacterExpConfigTable();
            config.CharacterExpConfigMap = new Dictionary<int, CharacterExpConfig>();

            rootE = new XElement("root");
        }
    }
}
