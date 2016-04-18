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

using Config.Table;
using GameConfigTools.Constant;
using System;
using System.Collections.Generic;

namespace GameConfigTools.Import.mmAdvImport
{
    class LineGameLevelImporter : AbstractXmlImporter
    {
        protected override bool Valid(System.Xml.Linq.XElement root, out Thrift.Protocol.TBase tbase, ref string errMsg)
        {
            LineGameLevelConfigTable table = new LineGameLevelConfigTable();
            table.LevelConfigXml = root.ToString();
            tbase = table;
            return true;
        }
        protected override string GetConfigName()
        {
            return SysConstant.LINEGAME_LEVEL_CONFIG;
        }
    }
}
