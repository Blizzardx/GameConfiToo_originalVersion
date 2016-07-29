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
    public class BattleEffectEventConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            BattleEffectEventConfigTable config = new BattleEffectEventConfigTable();
            tbase = config;
            config.BattleEffectEventConfigMap = new Dictionary<int, List<BattleEffectEventConfig>>();

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

                    index++;
                    int effectId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out effectId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，特效ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int eventFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out eventFrame))
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

                    
                    BattleEffectEventConfig c = new BattleEffectEventConfig();
                    c.EffectId = effectId;
                    c.EventFrame = eventFrame;
                    c.FrameLimitId = frameLimitId;
                    c.FrameFuncId = frameFuncId;

                    List<BattleEffectEventConfig> list = null;
                    if (!config.BattleEffectEventConfigMap.ContainsKey(c.EffectId))
                    {
                        config.BattleEffectEventConfigMap.Add(c.EffectId, new List<BattleEffectEventConfig>());
                    }
                    list = config.BattleEffectEventConfigMap[c.EffectId];
                    list.Add(c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_EFFECT_EVENT_CONFIG;
        }
    }
}
