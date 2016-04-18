using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using Thrift.Protocol;
using System.Xml.Linq;
using GameConfigTools.Import.mmAdvImport;

namespace GameConfigTools.Import
{
    public class ImporterManager
    {
        public static readonly ImporterManager instance = new ImporterManager();

        private Dictionary<string, Importer> importerDic = new Dictionary<string, Importer>();

        private Dictionary<string, string[]> linkDic = new Dictionary<string, string[]>();

        //存放导入配置的缓存，方便做关联时的验证
        private Dictionary<string, TBase> configCacheDic = new Dictionary<string, TBase>();

        private Dictionary<string, string> externalConfigDic = new Dictionary<string, string>();

        public ImporterManager()
        {
            this.LoadImporter();
            this.LoadLinkImporter();
            this.LoadExternalConfigName();
        }
        /// <summary>
        /// 加载导入的实现
        /// </summary>
        private void LoadImporter()
        {
            importerDic.Add(SysConstant.MESSAGE_CONFIG, new MessageImporter());
            importerDic.Add(SysConstant.LIMIT_CONFIG, new LimitImporter());
            importerDic.Add(SysConstant.TARGET_CONFIG, new TargetImporter());
            importerDic.Add(SysConstant.FUNC_CONFIG, new FuncImporter());
            importerDic.Add(SysConstant.CHARACTOR_CONFIG, new CharactorImporter());
            importerDic.Add(SysConstant.NPC_CONFIG, new NpcImporter());
            importerDic.Add(SysConstant.TERRAIN_CONFIG, new TerrainImporter());
            importerDic.Add(SysConstant.ACTION_CONFIG, new ActionImporter());
            importerDic.Add(SysConstant.DIALOG_CONFIG, new DialogImporter());
            importerDic.Add(SysConstant.MISSION_STEP_CONFIG, new MissionStepImporter());
            importerDic.Add(SysConstant.MAIN_MISSION_CONFIG, new MainMissionImporter());
            importerDic.Add(SysConstant.STAGE_CONFIG, new StageImporter());
            importerDic.Add(SysConstant.SKILL_CONFIG, new SkillImporter());
            importerDic.Add(SysConstant.CHAT_DIRTY_WORD_CONFIG, new ChatDirtyWordImporter());
            importerDic.Add(SysConstant.NAME_DIRTY_WORD_CONFIG, new NameDirtyWordImporter());
            importerDic.Add(SysConstant.RATIOGAME_CONFIG, new RatioGameImporter());
            importerDic.Add(SysConstant.ITEMS_CONFIG, new ItemsImporter());
            importerDic.Add(SysConstant.AI_CONFIG, new AIConfigImporter());
            importerDic.Add(SysConstant.ARITHMETIC_CONFIG, new ArithmeticImporter());
            importerDic.Add(SysConstant.DEFAULT_TALENT_CONFIG, new DefaultUserTalentImporter());
            importerDic.Add(SysConstant.DIFFICULTY_CONFIG, new DifficultyControlImporter());
            importerDic.Add(SysConstant.TALENT_CONFIG, new TalentControlImpoort());
            importerDic.Add(SysConstant.REGULARITY_CONFIG, new RegularityImporter());
            importerDic.Add(SysConstant.REGULARITY_SETTING_CONFIG, new RegularitySettingImporter());
            importerDic.Add(SysConstant.FLIGHT_CONFIG, new FlightImporter());
            importerDic.Add(SysConstant.MUSICGAME_SETTING_CONFIG, new MusicGameSettingImporter());
            importerDic.Add(SysConstant.MUSICGAME_CONFIG, new MusicGameImporter());
            importerDic.Add(SysConstant.RUNNERGAME_SETTING_CONFIG, new RunnerGameSettingImporter());
            importerDic.Add(SysConstant.LIMIT_FUNC_SCENE_CONFIG, new LimitFuncSceneImporter());
            importerDic.Add(SysConstant.RUNNER_TRUNK_CONFIG, new RunnerTrunkImporter());
            importerDic.Add(SysConstant.STORY_CONFIG, new StoryImporter());
            importerDic.Add(SysConstant.GRENADE_CONFIG, new GrenadeImporter());
            importerDic.Add(SysConstant.FLIPCARD_LEVEL_CONFIG, new FlipCardLevelImporter());
            importerDic.Add(SysConstant.PUZZLEGAME_LEVEL_CONFIG, new PuzzleGameLevelImporter());
            importerDic.Add(SysConstant.LINEGAME_LEVEL_CONFIG, new LineGameLevelImporter());
        }
        /// <summary>
        /// 加载关联导入
        /// </summary>
        private void LoadLinkImporter()
        {
            //linkDic.Add(SysConstant.LIMIT_FUNC_SCENE_CONFIG, new string[] { SysConstant.LIMIT_CONFIG, SysConstant.FUNC_CONFIG });
            linkDic.Add(SysConstant.LIMIT_CONFIG, new string[] { SysConstant.MESSAGE_CONFIG });
        }

        private void LoadExternalConfigName()
        {
            externalConfigDic.Add(SysConstant.TERRAIN_CONFIG, SysConstant.TERRAIN_CONFIG+"_txtpkg.bytes");
            //externalConfigDic.Add(SysConstant.FORMATION_EDITOR_CONFIG, "formation_txtpkg.bytes");
            externalConfigDic.Add(SysConstant.ACTION_CONFIG, SysConstant.ACTION_CONFIG + "_txtpkg.bytes");

            externalConfigDic.Add(SysConstant.DEFAULT_TALENT_CONFIG, SysConstant.DEFAULT_TALENT_CONFIG + "_txtpkg.bytes");
            externalConfigDic.Add(SysConstant.DIFFICULTY_CONFIG, SysConstant.DIFFICULTY_CONFIG + "_txtpkg.bytes");
            externalConfigDic.Add(SysConstant.TALENT_CONFIG, SysConstant.TALENT_CONFIG + "_txtpkg.bytes");
            externalConfigDic.Add(SysConstant.RUNNER_TRUNK_CONFIG, SysConstant.RUNNER_TRUNK_CONFIG + "_txtpkg.bytes");

            externalConfigDic.Add(SysConstant.FLIPCARD_LEVEL_CONFIG, SysConstant.FLIPCARD_LEVEL_CONFIG + "_txtpkg.bytes");

            externalConfigDic.Add(SysConstant.PUZZLEGAME_LEVEL_CONFIG, SysConstant.PUZZLEGAME_LEVEL_CONFIG + "_txtpkg.bytes");
            externalConfigDic.Add(SysConstant.LINEGAME_LEVEL_CONFIG, SysConstant.LINEGAME_LEVEL_CONFIG + "_txtpkg.bytes");
        }

        public Importer GetImporter(string configName)
        {
            if (!importerDic.ContainsKey(configName))
            {
                return null;
            }
            return importerDic[configName];
        }

        /// <summary>
        /// 获取关联导入的对象
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public string[] GetLinkImporters(string configName)
        {
            if (!linkDic.ContainsKey(configName))
            {
                return null;
            }
            return linkDic[configName];
        }

        public TBase GetCacheConfig(string configName, ref string errMsg)
        {
            if (!configCacheDic.ContainsKey(configName))
            {
                //缓存未命中，尝试从excel中加载
                Importer impoter = this.GetImporter(configName);
                if (impoter is AbstractExcelImporter)
                {
                    XElement root;
                    TBase tbase;
                    AbstractExcelImporter excelImport = impoter as AbstractExcelImporter;
                    excelImport.ReadExcel(ref errMsg, out root, out tbase);
                }
            }
            if (!configCacheDic.ContainsKey(configName))
            {
                return null;
            }

            return configCacheDic[configName];
        }

        public void AddCacheConfig(string configName, TBase config)
        {
            this.RemoveCacheConfig(configName);
            configCacheDic.Add(configName, config);
        }

        public void RemoveCacheConfig(string configName)
        {
            if (configCacheDic.ContainsKey(configName))
            {
                configCacheDic.Remove(configName);
            }
        }

        public string GetExternalBytesName(string configName)
        {
            if (!externalConfigDic.ContainsKey(configName))
            {
                return null;
            }
            return externalConfigDic[configName];
        }
    }
}

