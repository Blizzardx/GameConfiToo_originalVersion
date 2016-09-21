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
    public partial class CadPlayerAttrConfigImporter : AbstractExcelImporter
    {
        private CadPlayerAttrConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.CAD_PLAYER_ATTR_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            CadPlayerAttrConfig c = new CadPlayerAttrConfig();
            c.Pid = pid;
            c.Level = level;
            c.Exp = exp;
            c.NormalSkill = normalSkill;
            c.Skill1 = skill1;
            c.MaxHp = maxHp;
            c.MoveSpeed = moveSpeed;
            c.JumpSpeed = jumpSpeed;
            c.JumpHight = jumpHight;
            c.JumpCount = jumpCount;
            c.BoxSpeed = boxSpeed;
            c.Model = model;
            c.DataPrefab = dataPrefab;
            
            if (!config.CadPlayerAttrConfigMap.ContainsKey(pid))
            {
                config.CadPlayerAttrConfigMap.Add(pid, new Dictionary<int, CadPlayerAttrConfig>());
            }
            Dictionary<int, CadPlayerAttrConfig> dic = config.CadPlayerAttrConfigMap[pid];
            dic.Add(level, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new CadPlayerAttrConfigTable();
            config.CadPlayerAttrConfigMap = new Dictionary<int, Dictionary<int, CadPlayerAttrConfig>>();
        }
    }
}
