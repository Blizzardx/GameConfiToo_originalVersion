//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// FileName : GrenadeImporter
//
// Created by : Baoxue at 2016/2/24 12:07:41
//
//
//========================================================================

using System.Collections.Generic;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class GrenadeImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            root = new XElement("GrenadeTable");
            GrenadeConfigTable table = new GrenadeConfigTable();
            table.GrenadeConfig = new List<GrenadeConfig>();

            tbase = table;

            string[][] content = sheetValues[0];
            for (int i = 0; i < content.Length; ++i)
            {
                if (null == content[i][0])
                {
                    continue;
                }
                if ("" == content[i][0])
                {
                    break;
                }
                string[] line = content[i];
                int index = 0;

                float diff;
                float range;
                int time;

                if (!float.TryParse(line[index++], out diff))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                if (!float.TryParse(line[index++], out range))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                if (!int.TryParse(line[index++], out time))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }

                //out put xml
                XElement npcDataGroup = new XElement("NpcConfig", new XAttribute("id", diff));
                root.Add(npcDataGroup);

                XElement npcDataElement = new XElement("CharactorData",
                    new XAttribute("diff", diff),
                    new XAttribute("range", range),
                    new XAttribute("time", time));

                npcDataGroup.Add(npcDataElement);

                //out put thrift
                GrenadeConfig elem = new GrenadeConfig();
                elem.Diff = (int)(diff * 10000);
                elem.WaitTime = time;
                elem.RespRange = (int)(range * 10000);

                table.GrenadeConfig.Add(elem);
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.GRENADE_CONFIG;
        }
    }
}