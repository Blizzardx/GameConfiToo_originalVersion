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
    public partial class CharacterActionConfigImporter : AbstractExcelImporter
    {
        private CharacterActionConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.CHARACTER_ACTION_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            CharacterActionConfig c = new CharacterActionConfig();
            c.Id = id;
            c.Born = born;
            c.BornTime = bornTime;
            c.Idle = idle;
            c.IdleTime = idleTime;
            c.Walk = walk;
            c.WalkTime = walkTime;
            c.Jump = jump;
            c.JumpTime = jumpTime;
            c.Drop = drop;
            c.DropTime = dropTime;
            c.Landing = landing;
            c.LandingTime = landingTime;
            c.Death = death;
            c.DeathTime = deathTime;
            c.Back = back;
            c.BackTime = backTime;
            c.Left = left;
            c.LeftTime = leftTime;
            c.Right = right;
            c.RightTime = rightTime;
            c.RelaxIdle = relaxIdle;
            c.RelaxIdleTime = relaxIdleTime;
            c.RelaxWalk = relaxWalk;
            c.RelaxWalkTime = relaxWalkTime;
            c.IdleFire = idleFire;
            c.IdleFireTime = idleFireTime;
            config.CharacterActionConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new CharacterActionConfigTable();
            config.CharacterActionConfigMap = new Dictionary<int, CharacterActionConfig>();
        }
    }
}
