using Config.Table;
using GameConfigTools.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public class AIConfigImporter : AbstractXmlImporter
    {
        protected override bool Valid(XElement root, out TBase tbase, ref string errMsg)
        {
            AiConfigTable config = new AiConfigTable();
            tbase = config;
            config.BtTreeXml = root.ToString();
            return true;
        }

        protected override string GetConfigName()
        {
            return SysConstant.AI_CONFIG;
        }
    }
}
