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

                float jumpEndDelayTime;
                if (!VaildUtil.TryConvertFloat(values[i][index++], out jumpEndDelayTime))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，没有获取正确的 jumpEndDelayTime", this.GetConfigName(), sheetName, row, index);
                    return;
                }

                config.InitSpeed = initSpeed;
                config.Gravity = gravity;
                config.JumpSpeed = jumpSpeed;
                config.JumpStartRiseTime = jumpStartRiseTime;
                config.JumpEndDelayTime = jumpEndDelayTime;
            }
        }
    }
    protected override string GetConfigName()
    {
        return SysConstant.RUNNERGAME_SETTING_CONFIG;
    }
}

