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
    public partial class CadPlayerConfigImporter : AbstractExcelImporter
    {
        private CadPlayerConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.CAD_PLAYER_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            CadPlayerConfig c = new CadPlayerConfig();
            c.Id = id;
            c.Type = type;
            config.CadPlayerConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new CadPlayerConfigTable();
            config.CadPlayerConfigMap = new Dictionary<int, CadPlayerConfig>();
        }
    }
}
