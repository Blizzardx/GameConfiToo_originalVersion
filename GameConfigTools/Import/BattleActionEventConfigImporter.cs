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
    public class BattleActionEventConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            BattleActionEventConfigTable config = new BattleActionEventConfigTable();
            tbase = config;
            config.BattleActionEventConfigMap = new Dictionary<int, List<BattleActionEventConfig>>();

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

                    //备注
                    index++;
                    int actionId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out actionId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对应动作id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int loopTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out loopTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对应动作id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int eventTime;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eventTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，触发事件的帧必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int frameLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out frameLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关键帧条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int frameFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out frameFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关键帧功能ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    BattleActionEventConfig c = new BattleActionEventConfig();
                    c.ActionId = actionId;
                    c.LoopTime = loopTime;
                    c.EventFrame = eventTime;
                    c.FrameLimitId = frameLimitId;
                    c.FrameFuncId = frameFuncId;

                    List<BattleActionEventConfig> list = null;
                    if (!config.BattleActionEventConfigMap.ContainsKey(c.ActionId))
                    {
                        config.BattleActionEventConfigMap.Add(c.ActionId, new List<BattleActionEventConfig>());
                    }
                    list = config.BattleActionEventConfigMap[c.ActionId];
                    list.Add(c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_ACTION_EVENT_CONFIG;
        }
    }
}
