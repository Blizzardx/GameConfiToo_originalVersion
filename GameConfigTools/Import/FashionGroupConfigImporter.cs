using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class FashionGroupConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            FashionConfigTable messageConfig = ImporterManager.instance.GetCacheConfig(SysConstant.FASHION_CONFIG, ref errMsg) as FashionConfigTable;
            if (messageConfig == null)
            {
                return;
            }

            root = new XElement("root");

            FashionGroupConfigTable config = new FashionGroupConfigTable();
            tbase = config;
            config.FashionGroupMap = new Dictionary<int, FashionGroupConfig>();

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
                    string name = values[i][index++];
                    int nameMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out nameMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string desc = values[i][index++];
                    int descMessageId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out descMessageId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int displayLimitId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out displayLimitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int sortId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out sortId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，时装名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    string icon = values[i][index++];

                    // skill list
                    List<int> fashionList = new List<int>();
                    if (!DecodeList(values[i], ref index, fashionList))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误， 解析时装列表出错", this.GetConfigName(), sheetName, row, index);
                        return;
                    }

                    XElement monsterE = new XElement("fashionGroup");
                    root.Add(monsterE);
                    monsterE.Add(new XAttribute("id", id));
                    monsterE.Add(new XAttribute("name", name));
                    XElement skillIdsE = new XElement("fashions");
                    monsterE.Add(new XAttribute("displayLimitId", displayLimitId));
                    monsterE.Add(skillIdsE);
                    foreach (var elem in fashionList)
                    {
                        skillIdsE.Add(new XElement("fashionId", elem));
                    }

                    FashionGroupConfig c = new FashionGroupConfig();
                    c.Id = id;
                    c.NameId = nameMessageId;
                    c.DescId = descMessageId;
                    c.Icon = icon;
                    c.SortId = sortId;
                    c.FashionList = fashionList;
                    c.DisplayLimitId = displayLimitId;

                    for (int k = 0; k < c.FashionList.Count; ++k)
                    {
                        if (!messageConfig.FashionConfigMap.ContainsKey(fashionList[k]))
                        {
                            errMsg = " id 在fashionconfig表中不存在  " + id + " 错误的fashion id " + fashionList[k];
                            return;
                        }
                    }
                    if (config.FashionGroupMap.ContainsKey(id))
                    {
                        errMsg = " id 重复 " + id;
                        return;
                    }
                    config.FashionGroupMap.Add(c.Id, c);
                }
            }
        }
        protected override string GetConfigName()
        {
            return SysConstant.FASHION_GROUP_CONFIG;
        }
        private bool DecodeList(string[] content, ref int index, List<int> targetList)
        {
            if (content[index++] != "(")
            {
                return false;
            }
            bool isDone = false;
            for (; index < content.Length; ++index)
            {
                string s = content[index];

                if (s == ")")
                {
                    ++index;
                    isDone = true;
                    break;
                }
                else
                {
                    int tmp = 0;
                    if (!int.TryParse(s, out tmp))
                    {
                        break;
                    }
                    targetList.Add(tmp);
                }
            }
            if (!isDone)
            {
                return false;
            }
            return true;
        }
    }
}
