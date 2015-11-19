using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class LimitImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            MessageConfigTable messageConfig = ImporterManager.instance.GetCacheConfig(SysConstant.MESSAGE_CONFIG, ref errMsg) as MessageConfigTable;
            if (messageConfig == null)
            {
                return;
            }
            Dictionary<int, string> messageDic = null;
            foreach (string key in messageConfig.MessageMap.Keys)
            {
                messageDic = messageConfig.MessageMap[key];
                break;
            }

            root = new XElement("limitGroups");
            LimitConfgTable limitConfig = new LimitConfgTable();
            limitConfig.LimitMap = new Dictionary<int, LimitGroup>();
            tbase = limitConfig;
            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    int row = i + 1;
                    int index = 0;
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }

                    int limitGroupId;
                    if (!int.TryParse(values[i][index++], out limitGroupId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，条件函数组ID必须为整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    //跳过函数说明
                    index++;
                    int logic;
                    if (!int.TryParse(values[i][index++], out logic))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符必须为整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    if (logic < 0 || logic > 1)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，逻辑符数值必须在[0 - 1]之间", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    List<string> tempList = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        tempList.Add(values[i][j]);
                    }
                    //解析出条件配置
                    List<List<string>> resultList = this.ParseBracket(tempList);
                    if (resultList == null)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，条件函数配置不合法，括号没有匹配上", this.GetConfigName(), sheetName, row);
                        return;
                    }

                    if (resultList.Count == 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，条件组内条件不能为空", this.GetConfigName(), sheetName, row);
                        return;
                    }

                    XElement limitGroupElement = new XElement("limitGroup", new XAttribute("id", limitGroupId), new XAttribute("logic", logic));
                    root.Add(limitGroupElement);

                    LimitGroup group = new LimitGroup();
                    group.Id = limitGroupId;
                    group.Logic = (sbyte)logic;
                    group.LimitDataList = new List<LimitData>();
                    limitConfig.LimitMap.Add(group.Id, group);

                    //开始解析每一个条件
                    for (int n = 0; n < resultList.Count; n++)
                    {
                        int no = n + 1;

                        List<string> list = resultList[n];

                        int limitIndex = 0;

                        int limitId;
                        if (!int.TryParse(list[limitIndex++], out limitId))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个条件函数读取出现错误，条件函数ID:[{4}]必须为整型", this.GetConfigName(), sheetName, row, no, list[limitIndex - 1]);
                            return;
                        }

                        int messageId;
                        if (!int.TryParse(list[limitIndex++], out messageId))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个条件函数读取出现错误，messageId:[{4}]必须为整型", this.GetConfigName(), sheetName, row, no, list[limitIndex - 1]);
                            return;
                        }
                        if (messageId != 0)
                        {
                            if (!messageDic.ContainsKey(messageId))
                            {
                                errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个条件函数读取出现错误，messageId:[{4}]在{5}中不存在", this.GetConfigName(), sheetName, row, no, list[limitIndex - 1], SysConstant.MESSAGE_CONFIG);
                                return;
                            }

                        }

                        int operate;
                        if (!int.TryParse(list[limitIndex++], out operate))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个条件函数读取出现错误，操作符:[{4}]必须为整型", this.GetConfigName(), sheetName, row, no, list[limitIndex - 1]);
                            return;
                        }
                        if (operate < 0 || operate > 5)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个条件函数读取出现错误，操作符:[{4}]数值必须在[0 - 5]之间", this.GetConfigName(), sheetName, row, no, list[limitIndex - 1]);
                            return;
                        }

                        int target;
                        if (!int.TryParse(list[limitIndex++], out target))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个条件函数读取出现错误，目标:[{4}]必须为整型", this.GetConfigName(), sheetName, row, no, list[limitIndex - 1]);
                            return;
                        }

                        XElement limitDataElement = new XElement("limitData", new XAttribute("id", limitId), new XAttribute("operator", operate), new XAttribute("messageId", messageId),
                                    new XAttribute("target", target));
                        limitGroupElement.Add(limitDataElement);

                        LimitData data = new LimitData();
                        data.Id = limitId;
                        data.Oper = (sbyte)operate;
                        data.MessageId = messageId;
                        data.Target = (sbyte)target;
                        data.ParamStringList = new List<string>();
                        data.ParamIntList = new List<int>();
                        group.LimitDataList.Add(data);

                        //解析参数
                        if (limitIndex < list.Count)
                        {
                            
                            for (; limitIndex < list.Count; limitIndex++)
                            {
                                string param = list[limitIndex];
                                if (param == null || param.Trim() == "")
                                {
                                    continue;
                                }
                                if (this.IsExistSpecial(param))
                                {
                                    limitDataElement.Add(new XElement("param", new XCData(param)));
                                }
                                else
                                {
                                    limitDataElement.Add(new XElement("param", param));
                                }
                                data.ParamStringList.Add(param);
                                int intParam;
                                if (int.TryParse(param, out intParam))
                                {
                                    data.ParamIntList.Add(intParam);
                                }
                                else
                                {
                                    data.ParamIntList.Add(0);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.LIMIT_CONFIG;
        }
    }
}
