using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Import;
using GameConfigTools.Util;
using Thrift.Protocol;
public class RunnerGameSettingImporter : AbstractExcelImporter
{
    protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
    {
        root = null;
        tbase = null;
        if (sheetValues == null || sheetValues.Count == 0)
        {
            return;
        }
        root = new XElement("root");

        RunnerGameSettingTable config = new RunnerGameSettingTable();
        tbase = config;

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

                float initSpeed;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out initSpeed))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 InitSpeed", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float gravity;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out gravity))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 gravity", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float jumpSpeed;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out jumpSpeed))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 jumpSpeed", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float jumpStartRiseTime;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out jumpStartRiseTime))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 jumpStartRiseTime", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float jumpGlideTime;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out jumpGlideTime))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 jumpGlideTime", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float superJumpSpeed;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out superJumpSpeed))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 superJumpSpeed", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float superJumpStartRiseTime;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out superJumpStartRiseTime))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 superJumpStartRiseTime", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float superJumpGlideTime;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out superJumpGlideTime))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 superJumpGlideTime", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                float jumpEndDelayTime;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out jumpEndDelayTime))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 jumpEndDelayTime", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                int trunkLoopCount;
                if (!VaildUtil.TryConvertInt(values[i][index++], out trunkLoopCount))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 trunkLoopCount", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                List<double> stepFloatList = new List<double>();

                if (values[i][index++] == "(")
                {
                    string value = values[i][index++];
                    while (value != ")")
                    {
                        float stepFloat;
                        if (!VaildUtil.TryConvertFloat(value, out stepFloat))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 step float", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        stepFloatList.Add(stepFloat);
                        value = values[i][index++];
                    }
                }

                config.InitSpeed = initSpeed;
                config.Gravity = gravity;
                config.JumpSpeed = jumpSpeed;
                config.JumpStartRiseTime = jumpStartRiseTime;
                config.JumpGlideTime = jumpGlideTime;
                config.SuperJumpSpeed = superJumpSpeed;
                config.SuperJumpStartRiseTime = superJumpStartRiseTime;
                config.SuperJumpGlideTime = superJumpGlideTime;
                config.JumpEndDelayTime = jumpEndDelayTime;
                config.TrunkLoopCount = trunkLoopCount;
                config.HitWaitTimeList = stepFloatList;
            }
        }
    }
    protected override string GetConfigName()
    {
        return SysConstant.RUNNERGAME_SETTING_CONFIG;
    }
}

