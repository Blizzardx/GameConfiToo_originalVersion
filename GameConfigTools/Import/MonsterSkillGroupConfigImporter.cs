using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class MonsterSkillGroupConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            MonsterSkillGroupConfigTable config = new MonsterSkillGroupConfigTable();
            tbase = config;
            config.SkillGroupConfigMap = new Dictionary<int, MonsterSkillGroupConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物ID必须为0 - {4}整型",
                            this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<List<int>> targetList = new List<List<int>>();
                    for (;;)
                    {
                        List<int> group = new List<int>();
                        if (index >= values[i].Length || string.IsNullOrEmpty(values[i][index]))
                        {
                            break;
                        }
                        if (!DecodeList(values[i], ref index, group))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误",this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        else
                        {
                            targetList.Add(group);
                        }
                    }
                    MonsterSkillGroupConfig line = new MonsterSkillGroupConfig();
                    line.Id = id;
                    line.SkillList = targetList;
                    config.SkillGroupConfigMap.Add(id, line);
                }
            }

        }

        protected override string GetConfigName()
        {
            return SysConstant.MONSTER_SKILL_GROUP_CONFIG;
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
