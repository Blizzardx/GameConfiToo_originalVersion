using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConfigTools.Constant;

namespace GameConfigTools.Import
{
    class TerrainConfigImporter : AbstractXmlImporter
    {
        protected override string GetConfigName()
        {
            return SysConstant.TERRAIN_CONFIG;
        }

    }
}
