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

namespace GameConfigTools.Import
{
    public class StoryImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            StoryConfigTable config = new StoryConfigTable();
            tbase = config;
            config.StoryConfigMap = new Dictionary<int,StoryConfig>();


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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，StoryID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    List<string> list = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        list.Add(values[i][j]);
                    }
                    List<StoryParamEntry> storyParamEntryList = new List<StoryParamEntry>();
                    List<List<string>> resultList = this.ParseBracket(list);
                    if (null == resultList)
                    {
                        errMsg = "括号匹配错误";
                        return;
                    }
                    if (resultList != null && resultList.Count == 1)
                    {
                        for (int k = 0; k < resultList.Count; k++)
                        {
                            List<string> property = resultList[k];
                            if (property.Count % 2 != 0)
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，Story参数的第{3}个配置不合法", this.GetConfigName(), sheetName, row, (k + 1));
                                return;
                            }

                            for (int n = 0; n < property.Count; n++ )
                            {
                                if (n % 2 == 0)
                                {
                                    int key;
                                    if (!VaildUtil.TryConvertInt(property[n], out key))
                                    {
                                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，对话ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                                        return;
                                    }

                                    int value;
                                    if (!VaildUtil.TryConvertInt(property[n + 1], out value))
                                    {
                                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，方案ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                                        return;
                                    }

                                    StoryParamEntry ep = new StoryParamEntry();
                                    ep.Key = key;
                                    ep.Value = value;
                                    storyParamEntryList.Add(ep);
                                }
                            }
                        }
                    }
                    StoryConfig c = new StoryConfig();
                    c.Id = id;               
                    c.StoryParam = storyParamEntryList;
                    config.StoryConfigMap.Add(c.Id, c);
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.STORY_CONFIG;
        }
    }
}
