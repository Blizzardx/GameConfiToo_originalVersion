//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.42000
// FileName : LineGameLevelImporter
//
// Created by : Baoxue at 2016/4/18 13:14:34
//
//
//========================================================================

using GameConfigTools.Constant;
using System;
using System.Collections.Generic;

namespace GameConfigTools.Import.mmAdvImport
{
    class LineGameLevelImporter : AbstractXmlImporter
    {        
        protected override string GetConfigName()
        {
            return SysConstant.LINEGAME_LEVEL_CONFIG;
        }
    }
}
