using Config;
using Config.Table;
using GameConfigTools.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class MonsterBornImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            MonsterBornConfigTable config = new MonsterBornConfigTable();
            tbase = config;
            config.MonsterBornConfigMap = new Dictionary<int, MonsterBornConfig>();

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
                    if (!int.TryParse(values[i][index++], out id))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，id:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    int limitId;
                    if (!int.TryParse(values[i][index++], out limitId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，limitId:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    int waitForBegin;
                    if (!int.TryParse(values[i][index++], out waitForBegin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，waitForBegin:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    int waitTime;
                    if (!int.TryParse(values[i][index++], out waitTime))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，waitTime:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    int duringTimeMin;
                    if (!int.TryParse(values[i][index++], out duringTimeMin))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，duringTimeMin:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    int duringTimeMax;
                    if (!int.TryParse(values[i][index++], out duringTimeMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，duringTimeMax:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    int countMax;
                    if (!int.TryParse(values[i][index++], out countMax))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，countMax:[{4}]必须为整型", this.GetConfigName(), sheetName, row, index, values[i][index - 1]);
                        return;
                    }
                    List<string> list = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        if(values[i][j].Trim() == "")
                        {
                            continue;
                        }
                        list.Add(values[i][j].Trim());
                    }
                    List<List<string>> resultList = this.ParseBracket(list);
                    if (resultList == null || resultList.Count < 1)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，权重配置不合法", this.GetConfigName(), sheetName, row);
                        return;
                    }
                    List<string> weightList = resultList[0];
                    if(weightList.Count % 2 != 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，权重配置不合法", this.GetConfigName(), sheetName, row);
                        return;
                    }
                    MonsterBornConfig c = new MonsterBornConfig();
                    c.MonsterWeightConfigList = new List<MonsterWeightConfig>();
                    for (int k = 0; k < weightList.Count; k++)
                    {
                        if(k % 2 != 0)
                        {
                            continue;
                        }

                        int monsterId;
                        if (!int.TryParse(weightList[k], out monsterId))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，monsterId:{4}必须为整型", this.GetConfigName(), sheetName, row, index, weightList[k]);
                            return;
                        }
                        int weight;
                        if (!int.TryParse(weightList[k + 1], out weight))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，monsterId:{4}必须为整型", this.GetConfigName(), sheetName, row, index, weightList[k + 1]);
                            return;
                        }
                        MonsterWeightConfig wc = new MonsterWeightConfig();
                        wc.MonsterId = monsterId;
                        wc.Weight = weight;
                        c.MonsterWeightConfigList.Add(wc);
                    }
                    c.Id = id;
                    c.LimitId = limitId;
                    c.WaitForBegin = waitForBegin;
                    c.WaitTime = waitTime;
                    c.DuringTimeMin = duringTimeMin;
                    c.DuringTimeMax = duringTimeMax;
                    c.CountMax = countMax;
                    config.MonsterBornConfigMap.Add(c.Id , c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.MONSTER_BORN_CONFIG;
        }
    }
}
