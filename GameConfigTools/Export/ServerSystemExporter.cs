using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;

namespace GameConfigTools.Export
{
    public class ServerSystemExporter : AbstractXmlExporter
    {
        protected override string GetConfigName()
        {
            return SysConstant.SYSTEM_CONFIG;
        }
    }
}
