using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Util;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    class DiyCharConfigImporter1 : AbstractExcelImporter
    {
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            if (sheetValues == null || sheetValues.Count == 0)
            {
                return;
            }

            DiyCharConfigTable config = new DiyCharConfigTable();
            tbase = config;
            config.DiyCharConfigMap = new Dictionary<int, DiyCharConfig>();

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
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    string name = values[i][index++];
                    int posId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out posId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，怪物名字ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    int vertexId;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out vertexId))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，标签ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int radius;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out radius))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，类型必须为1 - 3的整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int min;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out min))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，类型必须为整数", this.GetConfigName(), sheetName, row, index);
                        return;
                    }
                    int max;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out max))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，普通攻击必须为0 - {4}整数", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int dirx;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out dirx))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int diry;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out diry))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }
                    int dirz;
                    if (!VaildUtil.TryConvertInt(values[i][index++], out dirz))
                    {
                        errMsg = string.Format("{0}.xlsx sheet:[{1}] [{2},{3}]读取出现错误，出生条件ID必须为0 - {4}整型", this.GetConfigName(), sheetName, row, index, int.MaxValue);
                        return;
                    }

                    DiyVertexInfo c = new DiyVertexInfo();
                    c.VertexId = vertexId;
                    c.Radius = radius;
                    c.Min = min;
                    c.Max = max;
                    c.Dir = new ThriftVector3();
                    c.Dir.X = dirx;
                    c.Dir.Y = diry;
                    c.Dir.Z = dirz;

                    if (config.DiyCharConfigMap.ContainsKey(id))
                    {
                        if (null != config.DiyCharConfigMap[id].PositionInfoList)
                        {
                            var positionList = config.DiyCharConfigMap[id].PositionInfoList;
                            bool exist = false;
                            foreach (var elem in positionList)
                            {
                                if (elem.PositionId == posId)
                                {
                                    elem.VertexList.Add(c);
                                    exist = true;
                                    break;
                                }
                            }
                            if (!exist)
                            {
                                DiyPositionInfo newInfo = new DiyPositionInfo();
                                newInfo.PositionId = posId;
                                newInfo.VertexList = new List<DiyVertexInfo>() {c};
                                positionList.Add(newInfo);
                            }
                        }
                        else
                        {
                            config.DiyCharConfigMap[id].PositionInfoList = new List<DiyPositionInfo>();

                            DiyPositionInfo newInfo = new DiyPositionInfo();
                            newInfo.PositionId = posId;
                            newInfo.VertexList = new List<DiyVertexInfo>() { c };
                            config.DiyCharConfigMap[id].PositionInfoList.Add(newInfo);
                        }
                    }
                    else
                    {
                        DiyCharConfig newConfig = new DiyCharConfig();
                        newConfig.CharId = id;
                        newConfig.PositionInfoList = new List<DiyPositionInfo>();
                        DiyPositionInfo newInfo = new DiyPositionInfo();
                        newInfo.PositionId = posId;
                        newInfo.VertexList = new List<DiyVertexInfo>() { c };
                        newConfig.PositionInfoList.Add(newInfo);
                        config.DiyCharConfigMap.Add(id, newConfig);
                    }
                }
            }
        }

        protected override string GetConfigName()
        {
            return SysConstant.DIY_CHAR_CONFIG;
        }
    }
}
