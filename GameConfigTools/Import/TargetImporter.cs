using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;
using Config;
using Config.Table;

namespace GameConfigTools.Import
{
    public class TargetImporter : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }
            root = new XElement("targetGroups");

            TargetConfigTable config = new TargetConfigTable();
            tbase = config;
            config.TargetMap = new Dictionary<int, TargetGroup>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数组ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    index++;
                    int targetId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out targetId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，目标函数ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    List<string> paramList = new List<string>();
                    for(; index < values[i].Length; index++)
                    {
                        string param = values[i][index];
                        paramList.Add(param);
                    }

                    XElement targetGroupE = new XElement("targetGroup");
                    root.Add(targetGroupE);
                    targetGroupE.Add(new XAttribute("id", id));

                    XElement targetDataE = new XElement("targetData");
                    targetGroupE.Add(targetDataE);
                    targetDataE.Add(new XAttribute("targetId", targetId));
                    XElement paramE = new XElement("param");
                    targetDataE.Add(paramE);
                    foreach(string param in paramList)
                    {
                        paramE.Add(param);
                    }

                    TargetGroup targetGroup = new TargetGroup();
                    config.TargetMap.Add(id, targetGroup);
                    targetGroup.Id = id;

                    List<TargetData> targetDataList = new List<TargetData>();
                    targetGroup.TargetDataList = targetDataList;

                    TargetData data = new TargetData();
                    targetDataList.Add(data);
                    data.TargetId = targetId;
                    data.ParamStringList = paramList;
                    data.ParamIntList = new List<int>();
                    foreach(string param in paramList)
                    {
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

        protected override string GetConfigName()
        {
            return SysConstant.TARGET_CONFIG;
        }
    }
}
