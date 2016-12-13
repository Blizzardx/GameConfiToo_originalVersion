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
    public partial class FashionConfigImporter : AbstractExcelImporter
    {
        private XElement xmlRoot;
        private FashionConfigTable config;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = null;
            tbase = config;
        }
        protected override string GetConfigName()
        {
            return SysConstant.FASHION_CONFIG;
        }
        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            if (null == dyeingIdList)
            {
                dyeingIdList = new List<int>();
            }
            if (null == CustomizedIdList)
            {
                CustomizedIdList = new List<int>();
            }

            XElement tmpXmlroot = new XElement("fashion");
            xmlRoot.Add(tmpXmlroot);
            tmpXmlroot.Add(new XAttribute("id", id));
            tmpXmlroot.Add(new XAttribute("name", name));
            tmpXmlroot.Add(new XAttribute("decomposeId", decomposeId));
            tmpXmlroot.Add(new XAttribute("firstType", firstType));
            tmpXmlroot.Add(new XAttribute("activeCostId", activeCostId));
            tmpXmlroot.Add(new XAttribute("activeLimit", activeLimitId));
            tmpXmlroot.Add(new XAttribute("dyeingCostId", dyeingCostId));

            XElement colorsE = new XElement("availableDyeingIds");
            tmpXmlroot.Add(colorsE);
            foreach (var elem in dyeingIdList)
            {
                colorsE.Add(new XElement("availableDyeingId", elem));
            }
            XElement texturesE = new XElement("availableCustomizedIds");
            tmpXmlroot.Add(texturesE);
            foreach (var elem in CustomizedIdList)
            {
                texturesE.Add(new XElement("availableCustomizedId", elem));
            }

            FashionConfig c = new FashionConfig();
            c.Id = id;
            c.NameId = nameMessageId;
            c.DescId = descMessageId;
            c.Icon = icon;
            c.FirstType = firstType;
            c.Resource = resource;
            c.ActiveCostId = activeCostId;
            c.ActiveLimitId = activeLimitId;
            c.DyeingList = dyeingIdList;
            c.CustomizedList = CustomizedIdList;
            c.Animation = animation;
            c.DyeingCostId = dyeingCostId;

            if (config.FashionConfigMap.ContainsKey(id))
            {
                errMsg = string.Format("{0}.xlsx id{1}£¨÷ÿ∏¥", this.GetConfigName(), id);
                return;
            }
            config.FashionConfigMap.Add(c.Id, c);
        }
        protected override void OnAutoParasBegin()
        {
            xmlRoot = new XElement("root");
            config = new FashionConfigTable();
            config.FashionConfigMap = new Dictionary<int, FashionConfig>();
        }
    }
}
