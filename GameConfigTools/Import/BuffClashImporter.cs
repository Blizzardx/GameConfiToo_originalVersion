using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class BuffClashImporter : AbstractExcelImporter
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

            BuffClashConfigTable config = new BuffClashConfigTable();
            tbase = config;
            config.BuffClashConfigMap = new Dictionary<sbyte, Dictionary<sbyte, sbyte>>();

            string sheetName = this.GetSheetNames()[0];
            string[][] values = sheetValues[0];
            int columnSize = values[0].Length;

            for (int i = 0; i < values.Length; i++)
            {
                if (!this.IsLineNotNull(values[i]))
                {
                    continue;
                }
                int row = i + 1;
                int column = 0;
                XElement typeE = null;
                Dictionary<sbyte, sbyte> clashDic = null;
                for (int j = 0; j < columnSize; j++)
                {
                    column = j + 1;   
                    if (j == 0)
                    {
                        int type;
                        if (!VaildUtil.TryConvertInt(values[i][j], out type))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，buff类型必须为0 - {4}整型", this.GetConfigName(), sheetName, row, column, sbyte.MaxValue);
                            return;
                        }

                        typeE = new XElement("buffClash");
                        root.Add(typeE);
                        typeE.Add(new XAttribute("type", type));
                        clashDic = new Dictionary<sbyte, sbyte>();
                        config.BuffClashConfigMap.Add((sbyte)type, clashDic);
                    }
                    else
                    {
                        int clash;
                        if (!VaildUtil.TryConvertInt(values[i][j], out clash))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，碰撞结果必须为0 - {4}整型", this.GetConfigName(), sheetName, row, column, sbyte.MaxValue);
                            return;
                        }

                        XElement typeClashTypeE = new XElement("clash");
                        typeClashTypeE.Add(new XAttribute("clashType", j));
                        typeE.Add(typeClashTypeE);
                        typeClashTypeE.Add(clash);

                        clashDic.Add((sbyte)j, (sbyte)clash);
                    }
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.BUFF_CLASH_CONFIG;
        }
    }
}
