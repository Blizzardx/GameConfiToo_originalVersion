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
            AeroLevelUpConfig c = new AeroLevelUpConfig();
            c.AeroId = aeroId;
            c.Level = level;
            c.LimitId = limitId;
            c.FuncId = funcId;
            config.AeroLevelUpConfigMap.Add(aeroId, c);

            root = new XElement("root");
            XElement levelUpE = new XElement("levelUp");
            root.Add(levelUpE);

            levelUpE.Add(new XAttribute("aeroId", aeroId));
            levelUpE.Add(new XAttribute("level", level));
            levelUpE.Add(new XAttribute("limitId", limitId));
            levelUpE.Add(new XAttribute("funcId", funcId));
        }

        protected override void OnAutoParasBegin()
        {
            config = new AeroLevelUpConfigTable();
            config.AeroLevelUpConfigMap = new Dictionary<int, AeroLevelUpConfig>();
        }
    }
}
