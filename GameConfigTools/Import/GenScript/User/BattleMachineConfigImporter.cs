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
    public partial class BattleMachineConfigImporter : AbstractExcelImporter
    {
        private BattleMachineConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_MACHINE_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            BattleMachineConfig c = new BattleMachineConfig();
            c.Id = id;
            c.EnterLimitId = enterLimitId;
            c.EnterFuncId = enterFuncId;
            c.StayLimitId = stayLimitId;
            c.StayFuncId = stayFuncId;
            c.ExitLimitId = exitLimitId;
            c.ExitFuncId = exitFuncId;
            c.DelayTime = delayTime;

            config.BattleMachineConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new BattleMachineConfigTable();
            config.BattleMachineConfigMap = new Dictionary<int, BattleMachineConfig>();
        }
    }
}
