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

                    int isMoveBreak;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isMoveBreak, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否移动打断必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    int isFlyBreak;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isFlyBreak, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否飞行打断必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int isSkillBreak;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isSkillBreak, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否技能打断必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int isDemageBreak;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isDemageBreak, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否受击打断必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int isCollisionBreak;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isCollisionBreak, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否碰撞打断必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int isFloat;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out isFloat, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，是否受悬浮必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int canUseOnDrop;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out canUseOnDrop, 0, 1))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，降落伞状态能否使用必须为0 - 1整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int totalFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out totalFrame))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    BattleActionConfig c = new BattleActionConfig();
                    c.Id = id;
                    c.SkillId = skillId;
                    c.Name = name;
                    c.IsMoveBreak = isMoveBreak != 0;
                    c.IsFlyBreak = isFlyBreak != 0;
                    c.IsSkillBreak = isSkillBreak != 0;
                    c.IsDemageBreak = isDemageBreak != 0;
                    c.IsCollisionBreak = isCollisionBreak != 0;
                    c.IsFloat = isFloat != 0;
                    c.CanUseOnDrop = canUseOnDrop != 0;
                    c.TotalFrame = totalFrame;

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
