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
    class RatioGameImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            root = new XElement("RatioGame");

            RatioGameConfigTable config = new RatioGameConfigTable();
            tbase = config;

            config.BallCount = new List<MiniGameHardConfig>();
            config.BallColor = new List<MiniGameHardConfig>();
            config.BallMaterial = new List<MiniGameHardConfig>();
            config.BallSpeed = new List<MiniGameHardConfig>();
            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];

                if (sheetName == "BallCount")
                {
                    string[][] values = sheetValues[sheetIndex];
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (!this.IsLineNotNull(values[i]))
                        {
                            continue;
                        }
                        int row = i + 1;
                        int index = 0;

                        float hard;
                        int count;

                        if (!VaildUtil.TryConvertFloat(values[i][index++], out hard))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        if (!VaildUtil.TryConvertInt(values[i][index++], out count))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                            return;
                        }
                        XElement levelXE = new XElement("BallCount", new XAttribute("hard", hard));
                        root.Add(levelXE);

                        MiniGameHardConfig hardConfig = new MiniGameHardConfig();
                        hardConfig.Hard = hard;
                        hardConfig.Count = count;

                        XElement countXE = new XElement("count", count);
                        levelXE.Add(countXE);

                        config.BallCount.Add(hardConfig);
                    }
                }
                else if (sheetName == "BallColor")
                {
                    string[][] values = sheetValues[sheetIndex];
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (!this.IsLineNotNull(values[i]))
                        {
                            continue;
                        }
                        int row = i + 1;
                        int index = 0;

                        float hard;
                        int count;

                        if (!VaildUtil.TryConvertFloat(values[i][index++], out hard))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        if (!VaildUtil.TryConvertInt(values[i][index++], out count))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                            return;
                        }
                        XElement levelXE = new XElement("BallCount", new XAttribute("hard", hard));
                        root.Add(levelXE);

                        MiniGameHardConfig hardConfig = new MiniGameHardConfig();
                        hardConfig.Hard = hard;
                        hardConfig.Count = count;

                        XElement countXE = new XElement("count", count);
                        levelXE.Add(countXE);

                        config.BallColor.Add(hardConfig);
                    }
                }
                else if (sheetName == "BallMaterial")
                {
                    string[][] values = sheetValues[sheetIndex];
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (!this.IsLineNotNull(values[i]))
                        {
                            continue;
                        }
                        int row = i + 1;
                        int index = 0;

                        float hard;
                        int count;

                        if (!VaildUtil.TryConvertFloat(values[i][index++], out hard))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        if (!VaildUtil.TryConvertInt(values[i][index++], out count))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                            return;
                        }
                        XElement levelXE = new XElement("BallCount", new XAttribute("hard", hard));
                        root.Add(levelXE);

                        MiniGameHardConfig hardConfig = new MiniGameHardConfig();
                        hardConfig.Hard = hard;
                        hardConfig.Count = count;

                        XElement countXE = new XElement("count", count);
                        levelXE.Add(countXE);

                        config.BallMaterial.Add(hardConfig);
                    }
                }
                else if(sheetName == "BallSpeed")
                {
                    string[][] values = sheetValues[sheetIndex];
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (!this.IsLineNotNull(values[i]))
                        {
                            continue;
                        }
                        int row = i + 1;
                        int index = 0;

                        float hard;
                        int count;

                        if (!VaildUtil.TryConvertFloat(values[i][index++], out hard))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为float浮点型", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        if (!VaildUtil.TryConvertInt(values[i][index++], out count))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                            return;
                        }
                        XElement levelXE = new XElement("BallCount", new XAttribute("hard", hard));
                        root.Add(levelXE);

                        MiniGameHardConfig hardConfig = new MiniGameHardConfig();
                        hardConfig.Hard = hard;
                        hardConfig.Count = count;

                        XElement countXE = new XElement("count", count);
                        levelXE.Add(countXE);

                        config.BallSpeed.Add(hardConfig);
                    }
                }
            }
            /*
            config.RatioGameConfigMap = new Dictionary<int, RatioGameConfig>();

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

                    int level,speed;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out level))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    if (!VaildUtil.TryConvertInt(values[i][index++], out speed))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    index++;
                    XElement levelXE = new XElement("LevelConfig", new XAttribute("level", level));
                    root.Add(levelXE);

                    RatioGameConfig ratioGame = new RatioGameConfig();
                    ratioGame.Level = level;
                    ratioGame.Speed = speed;

                    XElement speedXE = new XElement("speed");
                    levelXE.Add(speed);
                    XElement ballsXE = new XElement("Balls");
                    levelXE.Add(ballsXE);

                    List<BallData> ballDataList = new List<BallData>();
                    ratioGame.BallDataList = ballDataList;

                    //int j = i;
                    while (this.IsLineNotNull(values[i]))
                    {
                        int offset = index;
                        int material, color;
                        if (!VaildUtil.TryConvertInt(values[i][offset++], out material))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                            return;
                        }
                        if (!VaildUtil.TryConvertInt(values[i][offset++], out color))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                            return;
                        }
                        BallData data = new BallData();
                        ballDataList.Add(data);

                        XElement materialXE = new XElement("material", material);
                        ballsXE.Add(materialXE);
                        XElement colorXE = new XElement("color",color);
                        ballsXE.Add(colorXE);

                        i++;
                    }

                    config.RatioGameConfigMap.Add(level, ratioGame);
                }
            }
            */
        }
        protected override string GetConfigName()
        {
            return SysConstant.RATIOGAME_CONFIG;
        }
    }
}
