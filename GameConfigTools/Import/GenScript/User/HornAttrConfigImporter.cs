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
    public partial class HornAttrConfigImporter : AbstractExcelImporter
    {
        private XElement e;
        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = null;
        }

        protected override string GetConfigName()
        {
            return SysConstant.HORN_ATTR_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            XElement attrE = new XElement("attr");
            e.Add(attrE);
            attrE.Add(new XAttribute("itemId", id));
            attrE.Add(new XAttribute("background", background));
        }

        protected override void OnAutoParasBegin()
        {
            e = new XElement("root");
        }
    }
}
