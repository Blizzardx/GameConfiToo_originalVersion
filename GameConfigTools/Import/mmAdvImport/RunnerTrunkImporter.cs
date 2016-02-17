using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using GameConfigTools.Import;

class RunnerTrunkImporter : AbstractXmlImporter
{
    protected override string GetConfigName()
    {
        return SysConstant.RUNNER_TRUNK_CONFIG;
    }
}