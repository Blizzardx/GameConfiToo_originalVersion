//========================================================================
// FileName : MoleAttackLevelImporter
// 
// Created by : LeoLi at 2016/4/21 11:06:45
//
// Purpose : 
//========================================================================
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using GameConfigTools.Import;
using Config.Table;

public class MoleAttackLevelImporter : AbstractXmlImporter
{
    protected override bool Valid(System.Xml.Linq.XElement root, out Thrift.Protocol.TBase tbase, ref string errMsg)
    {
        MoleAttackLevelConfigTable table = new MoleAttackLevelConfigTable();
        table.LevelConfigXml = root.ToString();
        tbase = table;
        return true;
    }
    protected override string GetConfigName()
    {
        return SysConstant.MOLEATTACK_LEVEL_CONFIG;
    }

}

