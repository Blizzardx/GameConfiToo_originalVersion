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
    public partial class FashionDyeingConfigImporter : AbstractExcelImporter
    {
        private FashionDyeingConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.FASHION_DYEING_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            FashionDyeingConfig c = new FashionDyeingConfig();
            c.Id = id;
            c.Color = RgbaValue;
            if (config.DyeingConfigMap.ContainsKey(id))
            {
                errMsg = string.Format("{0}.xlsx id{1}£¨÷ÿ∏¥", this.GetConfigName(), id);
                return;
            }
            config.DyeingConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            config = new FashionDyeingConfigTable();
            config.DyeingConfigMap = new Dictionary<int, FashionDyeingConfig>();
        }
    }
}
