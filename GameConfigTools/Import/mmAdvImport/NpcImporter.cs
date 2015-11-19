//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.18444
// FileName : NpcImporter
//
// Created by : Baoxue at 2015/11/4 14:32:10
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
    public class NpcImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            root = new XElement("NpcConfigTable");
            NpcConfigTable npcConfigTable = new NpcConfigTable();
            npcConfigTable.NpcCofigMap = new Dictionary<int, NpcConfig>();

            tbase = npcConfigTable;

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
                int id;
                string name;
                int nameMsgId;
                int sex;
                string modelResource;
                int age;
                int ai;
                int clickFuncId;

                if (!int.TryParse(line[index++], out id))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                name = line[index++];
                if (!int.TryParse(line[index++], out nameMsgId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                if (!int.TryParse(line[index++], out sex))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                modelResource = line[index++];
                if (!int.TryParse(line[index++], out age))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                if (!int.TryParse(line[index++], out ai))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }
                if (!int.TryParse(line[index++], out clickFuncId))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), "default", i, index);
                    return;
                }

                //out put xml
                XElement npcDataGroup = new XElement("NpcConfig", new XAttribute("id", id));
                root.Add(npcDataGroup);

                XElement npcDataElement = new XElement("CharactorData",
                    new XAttribute("id", id),
                    new XAttribute("NameMsgId", nameMsgId),
                    new XAttribute("Sex", sex),
                    new XAttribute("ModelResource", modelResource),
                    new XAttribute("Age", age),
                    new XAttribute("AiId", ai),
                    new XAttribute("ClickFuncId", clickFuncId));

                npcDataGroup.Add(npcDataElement);

                //out put thrift
                NpcConfig charElem = new NpcConfig();
                charElem.Id = id;
                charElem.NameMsgId = nameMsgId;
                charElem.Sex = sex;
                charElem.ModelResource = modelResource;
                charElem.Age = age;
                charElem.AiId = ai;
                charElem.ClickFuncId = clickFuncId;

                if (npcConfigTable.NpcCofigMap.ContainsKey(charElem.Id))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] id重复", this.GetConfigName(), i);
                }
                else
                {
                    npcConfigTable.NpcCofigMap.Add(charElem.Id, charElem);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.NPC_CONFIG;
        }
    }
}


