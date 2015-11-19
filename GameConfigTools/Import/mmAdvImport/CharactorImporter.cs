//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.18444
// FileName : CharactorImporter
//
// Created by : Baoxue at 2015/11/4 14:31:28
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using Microsoft.Office.Interop.Excel;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class CharactorImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root,out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            root = new XElement("charactorConfigTable");
            CharactorConfigTable charactorConfig = new CharactorConfigTable();
            charactorConfig.CharactorCofigMap = new Dictionary<int, CharactorConfig>();

            tbase = charactorConfig;

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

                //out put xml
                XElement charactorDataElement = new XElement("charactorConfig", new XAttribute("id", id));
                root.Add(charactorDataElement);

                XElement funcDataElement = new XElement("CharactorData", 
                    new XAttribute("id", id),
                    new XAttribute("NameMsgId", nameMsgId),
                    new XAttribute("Sex", sex),
                    new XAttribute("ModelResource", modelResource),
                    new XAttribute("Age", age));

                //charactorDataElement.Add(funcDataElement);

                //out put thrift
                CharactorConfig charElem = new CharactorConfig();
                charElem.Id = id;
                charElem.NameMsgId = nameMsgId;
                charElem.Sex = sex;
                charElem.ModelResource = modelResource;
                charElem.Age = age;

                if (charactorConfig.CharactorCofigMap.ContainsKey(charElem.Id))
                {
                    errMsg = string.Format("{0}.xlsx sheet:[{1}] id重复", this.GetConfigName(), i);
                }
                else
                {
                    charactorConfig.CharactorCofigMap.Add(charElem.Id, charElem);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.CHARACTOR_CONFIG;
        }
    }
}

