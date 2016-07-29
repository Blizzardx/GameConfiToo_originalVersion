using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class FuncImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            FuncConfigTable funcConfig = new FuncConfigTable();
            funcConfig.FuncMap = new Dictionary<int, FuncGroup>();

            tbase = funcConfig;
            root = new XElement("funcGroups");
            string[] sheetNames = this.GetSheetNames();
            for (int sheetIndex = 0; sheetIndex < sheetValues.Count; sheetIndex++)
            {
                string sheetName = sheetNames[sheetIndex];
                string[][] values = sheetValues[sheetIndex];
                for (int i = 0; i < values.Length; i++)
                {
                    int row = i + 1;
                    if (!this.IsLineNotNull(values[i]))
                    {
                        continue;
                    }
                    int index = 0;
                    int funcGroupId;
                    if (!int.TryParse(values[i][index++], out funcGroupId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，功能函数组ID必须为整型", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    //跳过函数说明
                    index++;
                    List<string> tempList = new List<string>();
                    for (int j = index; j < values[i].Length; j++)
                    {
                        tempList.Add(values[i][j]);
                    }
                    //解析出功能配置
                    List<List<string>> resultList = this.ParseBracket(tempList);
                    if (resultList == null)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，功能函数配置不合法，括号没有匹配上", this.GetConfigName(), sheetName, row);
                        return;
                    }

                    if (resultList.Count == 0)
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2}行]读取出现错误，功能组内条件不能为空", this.GetConfigName(), sheetName, row);
                        return;
                    }

                    XElement funcGroupElement = new XElement("funcGroup", new XAttribute("id", funcGroupId));
                    root.Add(funcGroupElement);

                    FuncGroup group = new FuncGroup();
                    group.Id = funcGroupId;
                    group.FuncDataList = new List<FuncData>();

                    funcConfig.FuncMap.Add(group.Id, group);

                    //开始解析每一个条件
                    for (int n = 0; n < resultList.Count; n++)
                    {
                        int no = n + 1;
                        List<string> list = resultList[n];
                        int funcIndex = 0;
                        int funcId;
                        if (!int.TryParse(list[funcIndex++], out funcId))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个功能函数读取出现错误，功能函数ID:[{4}]必须为整型", this.GetConfigName(), sheetName, row, no, list[funcIndex - 1]);
                            return;
                        }
                        int operate;
                        if (!int.TryParse(list[funcIndex++], out operate))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个功能函数读取出现错误，操作符:[{4}]必须为整型", this.GetConfigName(), sheetName, row, no, list[funcIndex - 1]);
                            return;
                        }
                        if (operate < 0 || operate > 2)
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个功能函数读取出现错误，操作符:[{4}]数值必须在[0 - 2]之间", this.GetConfigName(), sheetName, row, no, list[funcIndex - 1]);
                            return;
                        }
                        int target;
                        if (!int.TryParse(list[funcIndex++], out target))
                        {
                            errMsg = string.Format("{0}.xlsx sheet:[{1}] 第[{2}]行，第[{3}]个功能函数读取出现错误，目标:[{4}]必须为整型", this.GetConfigName(), sheetName, row, no, list[funcIndex - 1]);
                            return;
                        }
                        XElement funcDataElement = new XElement("funcData", new XAttribute("id", funcId), new XAttribute("operator", operate), new XAttribute("target", target));
                        funcGroupElement.Add(funcDataElement);

                        FuncData data = new FuncData();
                        data.Id = funcId;
                        data.Oper = (sbyte)operate;
                        data.Target = (sbyte)target;
                        data.ParamStringList = new List<string>();
                        data.ParamIntList = new List<int>();

                        group.FuncDataList.Add(data);
                        //解析参数
                        if (funcIndex < list.Count)
                        {

                            for (; funcIndex < list.Count; funcIndex++)
                            {
                                string param = list[funcIndex];
                                if (param == null || param.Trim() == "")
                                {
                                    continue;
                                }
                                if (this.IsExistSpecial(param))
                                {
                                    funcDataElement.Add(new XElement("param", new XCData(param)));
                                }
                                else
                                {
                                    funcDataElement.Add(new XElement("param", param));
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
            return SysConstant.FUNC_CONFIG;
        }
    }
}
