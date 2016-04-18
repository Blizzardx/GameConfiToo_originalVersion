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
using Config.Table;

public class FlipCardLevelImporter : AbstractXmlImporter
{
    protected override bool Valid(System.Xml.Linq.XElement root, out Thrift.Protocol.TBase tbase, ref string errMsg)
    {
        FlipCardLevelConfigTable table = new FlipCardLevelConfigTable();
        table.LevelConfigXml = root.ToString();
        tbase = table;
        return true;
    }
    protected override string GetConfigName()
    {
        return SysConstant.FLIPCARD_LEVEL_CONFIG;
    }
}

