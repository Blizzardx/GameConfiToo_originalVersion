using GameConfigTools.Constant;
using System.Collections.Generic;
using System.Xml.Linq;
using Config;
using Config.Table;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public partial class NecklaceConfigImporter : AbstractExcelImporter
    {
        private NecklaceConfigTable m_Config;
        private XElement m_serverConfig;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = m_serverConfig;
            tbase = m_Config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.NECKLACE_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName,int row,string[] line, ref string errMsg)
        {
            NecklaceConfig c = new NecklaceConfig();
            c.Id = id;
            c.ActiveLoverExp = activeLoverExp;
            c.AttachPosition = attachPos;
            c.DescMessageId = descMessageId;
            c.Icon = icon;
            c.NameMessageId = nameMessageId;
            c.PutonFuncId = putonfuncid;
            c.Quality = quality;
            c.Resource = resource;
            c.TakeoffFuncId = takeofffuncid;
            c.FuncDescMessageId = funcMessageId;

            // check id 
            if (m_Config.NecklaceConfigMap.ContainsKey(c.Id))
            {
                errMsg = string.Format("{0}.xlsx {1}–– id ÷ÿ∏¥", this.GetConfigName(),row);
                return;
            }
            m_Config.NecklaceConfigMap.Add(c.Id, c);

            XElement xmlE = new XElement("necklace");
            m_serverConfig.Add(xmlE);
            xmlE.Add(new XAttribute("id", id));
            xmlE.Add(new XAttribute("name", name));
            xmlE.Add(new XAttribute("quality", quality));
            xmlE.Add(new XAttribute("activeLoverExp", activeLoverExp));
            xmlE.Add(new XAttribute("takeoffFuncId", takeofffuncid));
            xmlE.Add(new XAttribute("putonFuncId", putonfuncid));
        }

        protected override void OnAutoParasBegin()
        {
            m_Config = new NecklaceConfigTable();
            m_Config.NecklaceConfigMap = new Dictionary<int, NecklaceConfig>();


            m_serverConfig = new XElement("root");
        }
    }
}
