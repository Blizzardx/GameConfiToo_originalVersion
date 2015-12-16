using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GameConfigTools.Constant;
using GameConfigTools.Import;
using Thrift.Protocol;

class DefaultUserTalentImporter : AbstractXmlImporter
{
    protected override string GetConfigName()
    {
        return SysConstant.DEFAULT_TALENT_CONFIG;
    }
}
class DifficultyControlImporter : AbstractXmlImporter
{
    protected override string GetConfigName()
    {
        return SysConstant.DIFFICULTY_CONFIG;
    }
}
class TalentControlImpoort : AbstractXmlImporter
{
    protected override string GetConfigName()
    {
        return SysConstant.TALENT_CONFIG;
    }
}