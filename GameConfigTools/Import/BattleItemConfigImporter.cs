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
    public class BattleItemConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            BattleItemConfigTable config = new BattleItemConfigTable();
            tbase = config;
            config.BattleItemConfigMap = new Dictionary<int, BattleItemConfig>();

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
                    if (config.BattleItemConfigMap.ContainsKey(id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，ID重复", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    index++;
                    string resource = values[i][index++];
                    string dataPrefab = values[i][index++];
                    int totalFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out totalFrame))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，总帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maxFrame;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxFrame))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大帧数必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    if (totalFrame == 0 && maxFrame == 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，当总帧数不限制时，最大帧数不能为0", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int minSpeedX;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out minSpeedX, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最小速度X必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    int maxSpeedX;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxSpeedX, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大速度X必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    int minSpeedY;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out minSpeedY, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最小速度Y必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    int maxSpeedY;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxSpeedY, int.MinValue, int.MaxValue))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大速度Y必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MinValue, int.MaxValue);
                        return;
                    }
                    int minInterval;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out minInterval))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最小间隔必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maxInterval;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out maxInterval))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，最大间隔必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int collisionLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out collisionLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，碰撞到物体时的条件id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int collisionFuncId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out collisionFuncId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，碰撞到物体时的功能id必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string dieEffect = values[i][index++];
                    string flyEffect = values[i][index++];

                    BattleItemConfig c = new BattleItemConfig();
                    c.Id = id;
                    c.Resource = resource;
                    c.TotalFrame = totalFrame;
                    c.MaxFrame = maxFrame;
                    c.MinSpeedX = minSpeedX;
                    c.MaxSpeedX = maxSpeedX;
                    c.MinSpeedY = minSpeedY;
                    c.MaxSpeedY = maxSpeedY;
                    c.MinInterval = minInterval;
                    c.MaxInterval = maxInterval;
                    c.CollisionLimitId = collisionLimitId;
                    c.CollisionFuncId = collisionFuncId;
                    c.DataPrefab = dataPrefab;
                    c.DieEffect = dieEffect;
                    c.FlyEffect = flyEffect;
                    config.BattleItemConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BATTLE_ITEM_CONFIG;
        }
    }
}
