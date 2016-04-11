//========================================================================
// Copyright(C): CYTX
//
// FileName : FlipCardLevelImporter
// 
// Created by : LeoLi at 2016/3/31 15:02:04
//
// Purpose : 
//========================================================================
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using GameConfigTools.Import;

public class FlipCardLevelImporter : AbstractXmlImporter
{
    protected override string GetConfigName()
    {
        return SysConstant.FLIPCARD_LEVEL_CONFIG;
    }
}

