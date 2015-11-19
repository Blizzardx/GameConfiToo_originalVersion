//========================================================================
// Copyright(C): ***********************
//
// CLR Version : 4.0.30319.18444
// FileName : TerrainImporter
//
// Created by : Baoxue at 2015/11/16 14:50:58
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GameConfigTools.Constant;
using GameConfigTools.Import;
using Thrift.Protocol;

public class TerrainImporter : AbstractXmlImporter
{
    protected override string GetConfigName()
    {
        return SysConstant.TERRAIN_CONFIG;
    }
}

