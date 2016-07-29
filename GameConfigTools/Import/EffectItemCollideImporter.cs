using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class EffectItemCollideImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            EffectItemCollideTable config = new EffectItemCollideTable();
            tbase = config;
            config.EffectItemCollideMap = new Dictionary<string, int>();

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

                    int effectType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out effectType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，子弹碰撞类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int itemType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out itemType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，关卡物体类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int collideType;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out collideType))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，碰撞策略必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string key = effectType + "_" + itemType;
                    if (config.EffectItemCollideMap.ContainsKey(key))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，重复的子弹碰撞类型{4}, 关卡物体类型{5}", this.GetConfigName(), sheetName, row, index, effectType, itemType);
                        return;
                    }
                    config.EffectItemCollideMap.Add(key, collideType);

                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.EFFECT_ITEM_CONFIG;
        }
    }
}
