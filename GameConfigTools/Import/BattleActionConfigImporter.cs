using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class BattleActionConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            BattleActionConfigTable config = new BattleActionConfigTable();
            tbase = config;
            config.BattleActionConfigMap = new Dictionary<int, List<BattleActionConfig>>();


            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int row = i + 1;
                    int index = 0;
                    int id;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    //描述
                    index++;
                    int skillId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out skillId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，技能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];

                    int canMove;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canMove, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否可以移动必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    int canJump;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canJump, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否可以跳必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int totalTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out totalTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int isLoop;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isLoop))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否循环必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    BattleActionConfig c = new BattleActionConfig();
                    c.Id = id;
                    c.SkillId = skillId;
                    c.Name = name;
                    c.CanMove = canMove != 0;
                    c.CanJump = canJump != 0;
                    c.TotalTime = totalTime / SysConstant.CLIENT_FRAME_TIME;
                    c.IsLoop = isLoop != 0;

                    List<BattleActionConfig> list = null;
                    if (!config.BattleActionConfigMap.ContainsKey(c.SkillId))
                    {
                        config.BattleActionConfigMap.Add(c.SkillId, new List<BattleActionConfig>());
                    }
                    list = config.BattleActionConfigMap[c.SkillId];
                    list.Add(c);

                }
            }

        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_ACTION_CONFIG;
        }
    }
}
