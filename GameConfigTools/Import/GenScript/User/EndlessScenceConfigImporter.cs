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
    public partial class EndlessScenceConfigImporter : AbstractExcelImporter
    {
        private EndlessScenceConfigTable config;
        private HashSet<string> resourceSet = new HashSet<string>();
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.ENDLESS_SCENE_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            
            if (!resourceSet.Add(resource))
            {
                errMsg = string.Format("{0}.xlsx sheet:{1} [{2}]行读取出现错误，场景资源名重复", this.GetConfigName(), sheetName, row);
                return;
            }
            string key = styleId + "_" + difficulty;
            EndlessScenceConfig c = new EndlessScenceConfig();
            c.Resource = resource;
            c.StyleId = styleId;
            c.Difficulty = difficulty;
            c.Direction = direction;

            if (!config.EndlessScenceConfigMap.ContainsKey(key))
            {
                config.EndlessScenceConfigMap.Add(key, new List<EndlessScenceConfig>());
            }
            List<EndlessScenceConfig> list = config.EndlessScenceConfigMap[key];
            list.Add(c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new EndlessScenceConfigTable();
            config.EndlessScenceConfigMap = new Dictionary<string, List<EndlessScenceConfig>>();
        }
    }
}
