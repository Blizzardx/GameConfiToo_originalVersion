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
using Common.Config;
using Common.Config.Table;

namespace GameConfigTools.Import.mmAdvImport
{
    class ArithmeticImporter : AbstractExcelImporter
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

            ArithmeticConfigTable config = new ArithmeticConfigTable();
            tbase = config;
            config.ArithmeticConfigMap = new Dictionary<int, ArithmeticConfig>();

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

                    int difficultyid;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out difficultyid))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，难度级别(ID)必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int platecount;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out platecount))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，盘子数量必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int timer;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out timer))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时间单位必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int maximum;
                    if(!VaildUtil.TryConvertInt(values[i][index++], out maximum))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，计算最大值必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int rule;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out rule))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，规则说明值必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    XElement propsE = new XElement("item");
                    root.Add(propsE);
                    propsE.Add(new XAttribute("difficultyid", difficultyid));
                    propsE.Add(new XAttribute("platecount", platecount));
                    propsE.Add(new XAttribute("timer", timer));
                    propsE.Add(new XAttribute("maximum", maximum));
                    propsE.Add(new XAttribute("rule", rule));

                    ArithmeticConfig c = new ArithmeticConfig();
                    c.Difficultyid = difficultyid;
                    c.Platecount = platecount;
                    c.Timer = timer;
                    c.Maximum = maximum;
                    c.Rule = rule;
                    config.ArithmeticConfigMap.Add(c.Difficultyid, c);
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.ARITHMETIC_CONFIG;
        }
    }
}
