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
    public partial class DiyCharConfigImporter : AbstractExcelImporter
    {
        private DiyCharConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.DIY_CHAR_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName, int row,string[] line, ref string errMsg)
        {
            DiyVertexInfo c = new DiyVertexInfo();
            c.VertexId = vertexid;
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
                        if (elem.PositionId == positionId)
                        {
                            elem.VertexList.Add(c);
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        DiyPositionInfo newInfo = new DiyPositionInfo();
                        newInfo.PositionId = positionId;
                        newInfo.VertexList = new List<DiyVertexInfo>() { c };
                        positionList.Add(newInfo);
                    }
                }
                else
                {
                    config.DiyCharConfigMap[id].PositionInfoList = new List<DiyPositionInfo>();

                    DiyPositionInfo newInfo = new DiyPositionInfo();
                    newInfo.PositionId = positionId;
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
                newInfo.PositionId = positionId;
                newInfo.VertexList = new List<DiyVertexInfo>() { c };
                newConfig.PositionInfoList.Add(newInfo);
                config.DiyCharConfigMap.Add(id, newConfig);
            }
        }

        protected override void OnAutoParasBegin()
        {
            config = new DiyCharConfigTable();
            config.DiyCharConfigMap = new Dictionary<int, DiyCharConfig>();
        }
    }
}
