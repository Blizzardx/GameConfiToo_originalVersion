using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class ResultConfigImporter:AbstractExcelImporter
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

            ResultConfigTable config = new ResultConfigTable();
            tbase = config;
            config.ResultConfigMap = new Dictionary<int, ResultConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int type;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out type))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int expBase;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out expBase))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int expModeRatio;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out expModeRatio))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int expOtherRatio;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out expOtherRatio))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    ResultConfig c = new ResultConfig();
                    c.Id = id;
                    c.ExpBase = expBase;
                    c.ExpModeRatio = expModeRatio;
                    c.ExpOtherRatio = expOtherRatio;
                    c.Type = type;
                    config.ResultConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.RESULT_CONFIG;
        }
    }
}
