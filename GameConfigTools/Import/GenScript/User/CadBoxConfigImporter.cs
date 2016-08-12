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
    public partial class CadBoxConfigImporter : AbstractExcelImporter
    {
        private CadBoxConfigTable config;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.CAD_BOX_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            CadBoxConfig c = new CadBoxConfig();
            c.Id = id;
            c.Model = model;
            c.DataPrefab = dataPrefab;
            c.Durable = durable;
            c.Angle = angle;
            c.CollisionLimitId = collisionLimitId;
            c.CollisionFuncId = collisionFuncId;
            c.DeadLimitId = deadLimitId;
            c.DeadFunId = deadFunId;
            c.DieEffect = dieEffect;
            config.CadBoxConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new CadBoxConfigTable();
            config.CadBoxConfigMap = new Dictionary<int, CadBoxConfig>();
        }
    }
}
