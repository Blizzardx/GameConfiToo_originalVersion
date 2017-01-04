using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameConfigTools.Constant;
using Thrift.Protocol;
using System.Xml.Linq;

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
            importerDic.Add(SysConstant.CHAT_DIRTY_WORD_CONFIG, new ChatDirtyWordImporter());
            importerDic.Add(SysConstant.NAME_DIRTY_WORD_CONFIG, new NameDirtyWordImporter());
            importerDic.Add(SysConstant.MESSAGE_CONFIG, new MessageImporter());
            importerDic.Add(SysConstant.LIMIT_FUNC_SCENE_CONFIG, new LimitFuncSceneImporter());
            importerDic.Add(SysConstant.LIMIT_CONFIG, new LimitImporter());
            importerDic.Add(SysConstant.FUNC_CONFIG, new FuncImporter());
            importerDic.Add(SysConstant.TARGET_CONFIG, new TargetImporter());
            importerDic.Add(SysConstant.CHARACTER_BASE_CONFIG, new CharacterBaseConfigImporter());
            importerDic.Add(SysConstant.BATTLE_ACTION_CONFIG, new BattleActionConfigImporter());
            importerDic.Add(SysConstant.BATTLE_ACTION_EVENT_CONFIG, new BattleActionEventConfigImporter());
            importerDic.Add(SysConstant.BATTLE_SKILL_CONFIG, new BattleSkillConfigImporter());
            importerDic.Add(SysConstant.BATTLE_EFFECT_CONFIG, new BattleEffectConfigImporter());
            importerDic.Add(SysConstant.BATTLE_EFFECT_EVENT_CONFIG, new BattleEffectEventConfigImporter());
            importerDic.Add(SysConstant.BATTLE_ITEM_CONFIG, new BattleItemConfigImporter());
            importerDic.Add(SysConstant.AERO_ATTRIBUTE_CONFIG, new AeroAttributeConfigImporter());
            importerDic.Add(SysConstant.STORY_CONFIG, new StoryImporter());
            importerDic.Add(SysConstant.DIALOG_CONFIG, new DialogImporter());
            importerDic.Add(SysConstant.EFFECT_ITEM_CONFIG, new EffectItemCollideImporter());

            importerDic.Add(SysConstant.COUNTER_CONFIG, new CounterImporter());
            importerDic.Add(SysConstant.SYSTEM_CONFIG, new SystemImporter());
            importerDic.Add(SysConstant.RANDOM_NAME_CONFIG, new RandomNameImporter());
            importerDic.Add(SysConstant.GM_LANGUAGE_CONFIG, new GMLanguageImporter());
            importerDic.Add(SysConstant.BATTLE_BUFF_CONFIG, new BattleBuffImporter());
            importerDic.Add(SysConstant.BUFF_CLASH_CONFIG, new BuffClashImporter());
            importerDic.Add(SysConstant.AI_CONFIG, new AIConfigImporter());
            importerDic.Add(SysConstant.MONSTER_CONFIG, new MonsterImporter());
            importerDic.Add(SysConstant.DROP_CONFIG, new DropImporter());
            importerDic.Add(SysConstant.MONSTER_SKILL_GROUP_CONFIG, new MonsterSkillGroupConfigImporter());
            importerDic.Add(SysConstant.ACTION_GROUP_CONFIG, new ActionGroupConfigImporter());
            importerDic.Add(SysConstant.CHAPTER_CONFIG, new ChapterImporter());
            importerDic.Add(SysConstant.STAGE_CONFIG, new StageImporter());
            importerDic.Add(SysConstant.AERO_CONFIG, new AeroConfigImporter());
            importerDic.Add(SysConstant.DARK_CLOUD_CONFIG, new DarkCloudConfigImporter());
            importerDic.Add(SysConstant.CLOUD_CONFIG, new CloudConfigImporter());
            importerDic.Add(SysConstant.RAIN_CONFIG, new RainConfigImporter());
            importerDic.Add(SysConstant.SHOCK_CONFIG, new ShockConfigImporter());
            importerDic.Add(SysConstant.WEATHER_PLAN_CONFIG, new WeatherPlanConfigImporter());
            importerDic.Add(SysConstant.STAGE_WEATHER_PLAN_CONFIG, new StageWeatherPlanConfigImporter());
            importerDic.Add(SysConstant.ITEM_GENERATOR_CONFIG, new ItemGeneratorConfigImporter());
            importerDic.Add(SysConstant.STAGE_LOGIC_POINT_DESC_CONFIG, new StageLogicPointDescConfigImporter());
            importerDic.Add(SysConstant.PVP_STAGE_CONFIG, new PvpStageConfigImporter());
            importerDic.Add(SysConstant.MODE_CONFIG, new ModeConfigImporter());
            importerDic.Add(SysConstant.BATTLE_RESULT_CONFIG, new BattleResultConfigImporter());
            importerDic.Add(SysConstant.ROOM_CHANNEL_CONFIG, new RoomChannelImporter());
            importerDic.Add(SysConstant.PROPS_CONFIG, new PropsImporter());
            importerDic.Add(SysConstant.DIY_MALL_CONFIG, new DiyMallImporter());
            importerDic.Add(SysConstant.DIY_PRESET_CONFIG, new DiyPresetImporter());
            importerDic.Add(SysConstant.DECORATE_CONFIG, new DecorateConfigImporter());
            importerDic.Add(SysConstant.ROOM_ACTION_MALL_CONFIG, new RoomActionMallImport());
            importerDic.Add(SysConstant.ROOM_ACTION_CONFIG, new RoomActionImporter());
            importerDic.Add(SysConstant.FASHION_CONFIG, new FashionConfigImporter());
            importerDic.Add(SysConstant.FASHION_GROUP_CONFIG, new FashionGroupConfigImporter());
            importerDic.Add(SysConstant.SPELLCARD_CONFIG, new SpellCardConfigImporter());
            importerDic.Add(SysConstant.SPELLCARD_LEVELUP_CONFIG, new SpellCardLevelupConfigImporter());
            importerDic.Add(SysConstant.BASE_MALL_CONFIG, new BaseMallImporter());
            importerDic.Add(SysConstant.ACTIVITY_MALL_CONFIG, new ActivityMallConfigImporter());
            importerDic.Add(SysConstant.MALL_CONFIG, new MallConfigImporter());
            importerDic.Add(SysConstant.DIY_CHAR_CONFIG, new DiyCharConfigImporter());
            importerDic.Add(SysConstant.AERO_LEVEL_UP_CONFIG, new AeroLevelUpConfigImporter());
            importerDic.Add(SysConstant.AERO_GROUP_CONFIG, new AeroGroupConfigImporter());
            importerDic.Add(SysConstant.CONSUME_CONFIG, new ConsumeImporter());
            importerDic.Add(SysConstant.EXCHANGE_CONFIG, new ExchangeImporter());
            importerDic.Add(SysConstant.CAD_PLAYER_CONFIG, new CadPlayerConfigImporter());
            importerDic.Add(SysConstant.CAD_PLAYER_ATTR_CONFIG, new CadPlayerAttrConfigImporter());
            importerDic.Add(SysConstant.CAD_BOX_CONFIG, new CadBoxConfigImporter());
            importerDic.Add(SysConstant.DECOMPOSE_CONFIG, new DecomposeImporter());
            importerDic.Add(SysConstant.BATTLE_MACHINE_CONFIG, new BattleMachineConfigImporter());
            importerDic.Add(SysConstant.STORY_PLAY_CONFIG, new StoryPlayImporter());
            importerDic.Add(SysConstant.MONSTER_BORN_CONFIG, new MonsterBornImporter());
            importerDic.Add(SysConstant.PENTAKILL_CONFIG, new PentakillConfigImporter());
            importerDic.Add(SysConstant.EMOTICON_CONFIG, new EmoticonConfigImporter());
            importerDic.Add(SysConstant.CHARACTER_EXP_CONFIG, new CharacterExpConfigImporter());
            importerDic.Add(SysConstant.NECKLACE_CONFIG, new NecklaceConfigImporter());
            importerDic.Add(SysConstant.DIFFICULTY_CURVE_CONFIG, new DifficultyCurveConfigImporter());
            importerDic.Add(SysConstant.ENDLESS_STAGE_CONFIG, new EndlessStageConfigImporter());
            importerDic.Add(SysConstant.ENDLESS_SCENE_CONFIG, new EndlessScenceConfigImporter());
            importerDic.Add(SysConstant.GUILD_PRIZE_CONFIG, new GuildPrizeConfigImporter());
            importerDic.Add(SysConstant.AMAP_CONFIG, new AmapConfigImporter());
            importerDic.Add(SysConstant.HORN_ATTR_CONFIG, new HornAttrConfigImporter());
            importerDic.Add(SysConstant.GUILD_EXP_CONFIG, new GuildExpConfigImporter());
            importerDic.Add(SysConstant.WEAPON_CONFIG, new WeaponConfigImporter());
            importerDic.Add(SysConstant.WEAPON_ATTRIBUTE_CONFIG, new WeaponAttributeConfigImporter());
            importerDic.Add(SysConstant.FASHION_CUSTOMIZED_CONFIG, new FashionCustomizedConfigImporter());
            importerDic.Add(SysConstant.FASHION_DYEING_CONFIG, new FashionDyeingConfigImporter());
            importerDic.Add(SysConstant.BATTLE_COLOR_CONFIG, new BattleColorConfigImporter());
            importerDic.Add(SysConstant.GUILD_FLAG_CONFIG, new GuildFlagConfigImporter());
            importerDic.Add(SysConstant.TERRAIN_CONFIG, new TerrainConfigImporter());
        }
        /// <summary>
        /// 加载关联导入
        /// </summary>
        private void LoadLinkImporter()
        {
            linkDic.Add(SysConstant.LIMIT_FUNC_SCENE_CONFIG, new string[] { SysConstant.LIMIT_CONFIG, SysConstant.FUNC_CONFIG });
            linkDic.Add(SysConstant.LIMIT_CONFIG, new string[] { SysConstant.MESSAGE_CONFIG });
            linkDic.Add(SysConstant.FASHION_GROUP_CONFIG, new string[] { SysConstant.FASHION_CONFIG });
            linkDic.Add(SysConstant.SPELLCARD_LEVELUP_CONFIG, new string[] { SysConstant.SPELLCARD_CONFIG });
        }

        private void LoadExternalConfigName()
        {
            //externalConfigDic.Add(SysConstant.TERRAIN_EDITOR_CONFIG, "terrain_txtpkg.bytes");
            //externalConfigDic.Add(SysConstant.FORMATION_EDITOR_CONFIG, "formation_txtpkg.bytes");
            externalConfigDic.Add(SysConstant.STORY_PLAY_CONFIG, "storyPlayConfig_txtpkg.bytes");
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

