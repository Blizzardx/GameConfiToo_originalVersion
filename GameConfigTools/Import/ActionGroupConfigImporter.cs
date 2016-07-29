using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Xml.Linq;
using Config;
using Config.Table;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class ActionGroupConfigImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            ActionGroupConfigTable config = new ActionGroupConfigTable();
            tbase = config;
            config.ActionGroupMap = new Dictionary<int, ActionGroupConfig>();

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
                    Dictionary<int, List<string>> targetList = new Dictionary<int, List<string>>();
                    for (;;)
                    {
                        List<string> group = new List<string>();
                        if (index >=values[i].Length || string.IsNullOrEmpty(values[i][index]))
                        {
                            break;
                        }
                        if (!DecodeList(values[i], ref index, group))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误", this.GetConfigName(), sheetName, row, index);
                            return;
                        }
                        else
                        {
                            int groupId = 0;
                            if (!int.TryParse(group[0], out groupId))
                            {
                                errMsg = "id必须为整形";
                                return;
                            }
                            group.RemoveAt(0);

                            if (targetList.ContainsKey(groupId))
                            {
                                errMsg = "id不能重复";
                                return;
                            }
                            //if (group.Count != 6)
                            //{
                            //    errMsg = "长度不合法";
                            //    return;
                            //}
                            targetList.Add(groupId, group);
                        }
                    }
                    ActionGroupConfig line = new ActionGroupConfig();
                    line.Id = id;
                    line.ActionGroupMap = targetList;
                    config.ActionGroupMap.Add(id, line);
                }
            }

        }

        protected override string GetConfigName()
        {
            return SysConstant.ACTION_GROUP_CONFIG;
        }
        private bool DecodeList(string[] content, ref int index, List<string> targetList)
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
                    targetList.Add(s);
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
