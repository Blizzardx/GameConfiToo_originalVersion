using GameConfigTools.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.Import.mmAdvImport
{
    class PuzzleGameLevelImporter: AbstractXmlImporter
    {
        protected override string GetConfigName()
        {
            return SysConstant.PUZZLEGAME_LEVEL_CONFIG;
        }
    }
}
