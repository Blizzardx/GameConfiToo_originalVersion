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
    public partial class AmapConfigImporter : AbstractExcelImporter
    {
        private AmapConfigTable config;
        private XElement e;

        Dictionary<int, XElement> provinceDic = new Dictionary<int, XElement>();

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = e;
            tbase = config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.AMAP_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName, int row, string[] line, ref string errMsg)
        {
            string adcodeStr = adcode.ToString();
            int provinceCode = int.Parse(adcodeStr.Substring(0, 2));
            int cityCode = int.Parse(adcodeStr.Substring(2, 2));
            int suffix = int.Parse(adcodeStr.Substring(4));

            if (!config.MapConfig.ContainsKey(provinceCode))
            {
                ProvinceConfig c = new ProvinceConfig();
                c.Code = provinceCode;
                c.Name = name;
                c.CityConfigMap = new Dictionary<int, CityConfig>();
                config.MapConfig.Add(provinceCode, c);

                XElement provinceE = new XElement("province");
                e.Add(provinceE);
                provinceDic.Add(provinceCode, provinceE);

                provinceE.Add(new XAttribute("code", provinceCode));
                provinceE.Add(new XAttribute("name", name));
            }
            if (cityCode != 0 && suffix == 0)
            {
                ProvinceConfig pc = config.MapConfig[provinceCode];
                if (!pc.CityConfigMap.ContainsKey(cityCode))
                {
                    CityConfig c = new CityConfig();
                    c.Code = cityCode;
                    c.Name = name;
                    pc.CityConfigMap.Add(cityCode, c);

                    XElement provinceE = provinceDic[provinceCode];
                    XElement cityE = new XElement("city");
                    provinceE.Add(cityE);

                    cityE.Add(new XAttribute("code", cityCode));
                    cityE.Add(new XAttribute("name", name));
                }
            }
        }

        protected override void OnAutoParasBegin()
        {
            e = new XElement("root");

            config = new AmapConfigTable();
            config.MapConfig = new Dictionary<int, ProvinceConfig>();
        }
    }
}
