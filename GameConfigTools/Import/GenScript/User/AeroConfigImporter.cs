using GameConfigTools.Constant;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Config;
using Config.Table;
using Thrift.Protocol;

namespace GameConfigTools.Import
{
    public partial class AeroConfigImporter : AbstractExcelImporter
    {
        private XElement root;
        private AeroConfigTable config;

        private Dictionary<int, HashSet<int>> evolutionLevelDic;

        protected override void GenerateConfig(List<string[][]> sheetValues, ref string errMsg, out XElement root, out TBase tbase)
        {
            root = this.root;
            tbase = this.config;
        }

        protected override string GetConfigName()
        {
            return SysConstant.AERO_CONFIG;
        }

        protected override void OnAutoParasLine(string sheetName, int row,string[] line, ref string errMsg)
        {
            if (!evolutionLevelDic.ContainsKey(groupId))
            {
                evolutionLevelDic.Add(groupId, new HashSet<int>());
            }
            HashSet<int> evolutionLevelSet = evolutionLevelDic[groupId];
            if (!evolutionLevelSet.Add(evolutionLevel))
            {
                errMsg = string.Format("{0}.xlsx 同一个组下进化等级不能重复", this.GetConfigName());
                return;
            }

            XElement aeroE = new XElement("aero");
            root.Add(aeroE);
            aeroE.Add(new XAttribute("id", id));
            aeroE.Add(new XAttribute("name", name));
            aeroE.Add(new XAttribute("groupId", groupId));
            aeroE.Add(new XAttribute("quality", quality));
            aeroE.Add(new XAttribute("evolutionLevel", evolutionLevel));
            aeroE.Add(new XAttribute("evolutionConsumeId", evolutionConsumeId));
            aeroE.Add(new XAttribute("decomposeId", decomposeId));
            

            AeroConfig c = new AeroConfig();
            c.Id = id;
            c.GroupId = groupId;
            c.EvolutionLevel = evolutionLevel;
            c.EvolutionConusmeId = evolutionConsumeId;
            c.NameMessageId = nameeMessageId;
            c.DescMessageId = descMessageId;
            c.Model = model;
            c.Prefab = prefab;
            c.Quality = quality;
            c.Icon = icon;
            c.MoveAdd = moveAdd;
            c.FlyAdd = flyAdd;
            c.MoveMax = moveMax;
            c.FlyMax = flyMax;
            c.DropAdd = dropAdd;
            c.DropMax = dropMax;
            c.Friction = friction;
            c.ResistanceAdd = resistance;
            c.RecoverHp = recoverHp;
            c.RecoverId = recoverId;
            c.AttachPoint = attachPoint;
            config.AeroConfigMap.Add(c.Id, c);
        }

        protected override void OnAutoParasBegin()
        {
            evolutionLevelDic = new Dictionary<int, HashSet<int>>();
            root = new XElement("root");
            config = new AeroConfigTable();
            config.AeroConfigMap = new Dictionary<int, AeroConfig>();
        }
    }
}
