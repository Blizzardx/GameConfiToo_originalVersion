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
    public partial class DifficultyCurveConfigImporter : AbstractExcelImporter
    {
        private DifficultyCurveConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.DIFFICULTY_CURVE_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if(difficultyMin > difficultyMax)
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，难度下限不能高于难度上限!", this.GetConfigName(), sheetName, row);
                return;
            }
            if(id > 1)
            {
                if (!config.DifficultyCurveConfigMap.ContainsKey(id - 1))
                {
                    errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，ID不连续", this.GetConfigName(), sheetName, row);
                    return;
                }
            }
            DifficultyCurveConfig c = new DifficultyCurveConfig();
            c.Id = id;
            c.DifficultyMin = difficultyMin;
            c.DifficultyMax = difficultyMax;
            config.DifficultyCurveConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new DifficultyCurveConfigTable();
            config.DifficultyCurveConfigMap = new Dictionary<int, DifficultyCurveConfig>();
        }
    }
}
