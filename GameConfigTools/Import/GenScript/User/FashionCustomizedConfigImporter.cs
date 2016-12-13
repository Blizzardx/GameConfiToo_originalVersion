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
    public partial class FashionCustomizedConfigImporter : AbstractExcelImporter
    {
        private XElement xmlRoot;
        private FashionCustomizedConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.FASHION_CUSTOMIZED_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            XElement tmpXmlroot = new XElement("fashionCustomized");
            xmlRoot.Add(tmpXmlroot);
            tmpXmlroot.Add(new XAttribute("id", id));
            tmpXmlroot.Add(new XAttribute("costId", costId));

            FashionCustomizedConfig c = new FashionCustomizedConfig();
            c.Id = id;
            c.CostId = costId;
            c.Texture = texture;

            if (config.CustomizedConfigMap.ContainsKey(id))
            {
                errMsg = string.Format("{0}.xlsx id{1}£¨÷ÿ∏¥", this.GetConfigName(), id);
                return;
            }
            config.CustomizedConfigMap.Add(id, c);
        }

        protected override void OnAutoParasBegin()
        {
            xmlRoot = new XElement("root");
            config = new FashionCustomizedConfigTable();
            config.CustomizedConfigMap = new Dictionary<int, FashionCustomizedConfig>();
        }
    }
}
