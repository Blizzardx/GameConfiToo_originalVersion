using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.Constant
{
    public class SysConstant
    {
        public static readonly string SYS_PATH = Application.StartupPath;

        public static readonly string SYS_CONFIG_PATH = SYS_PATH + "/conf";

        public static readonly string SYS_CONFIG_FILE = SYS_CONFIG_PATH + "/config.xml";

        public static readonly string CLIENT_EDIT_DATA = "clientEditData";

        public static readonly string CLIENT_RESOURCE_UPLOAD = "/upload.do";

        //获取游戏列表
        public static readonly string LIST_GAME_TYPE = "/config/list_game_type.do";
        //获取游戏版本列表
        public static readonly string LIST_VERSION = "/config/list_version.do?game_type={0}";
        //获取游戏的配置列表
        public static readonly string LIST_CONFIG = "/config/list_config.do?game_type={0}&server_version={1}";
        //获取最新的配置信息
        public static readonly string GET_NEW_CONFIG_INFO = "/config/get_new_config_info.do?game_type={0}&server_version={1}&name={2}";
        //上传配置
        public static readonly string UPDATE_CONFIG = "/config/updateConfig.do";

        //客户端一帧多长时间，毫秒
        public static readonly int CLIENT_FRAME_TIME = 33;

        /// <summary>
        /// messageConfig配置
        /// </summary>
        public static readonly string MESSAGE_CONFIG = "messageConfig";

        public static readonly string CHAT_DIRTY_WORD_CONFIG = "chatDirtywordConfig";

        public static readonly string NAME_DIRTY_WORD_CONFIG = "nameDirtywordConfig";

        public static readonly string COUNTER_CONFIG = "counterConfig";

        public static readonly string LIMIT_FUNC_SCENE_CONFIG = "limitFuncSceneConfig";

        public static readonly string LIMIT_CONFIG = "limitConfig";

        public static readonly string FUNC_CONFIG = "funcConfig";

        public static readonly string SYSTEM_CONFIG = "systemConfig";

        public static readonly string RANDOM_NAME_CONFIG = "randomNameConfig";

        public static readonly string DROP_LIST_CONFIG = "dropListConfig";

        public static readonly string GM_LANGUAGE_CONFIG = "gmLanguageConfig";

        public static readonly string TARGET_CONFIG = "targetConfig";

        public static readonly string BATTLE_BUFF_CONFIG = "battleBuffConfig";

        public static readonly string BUFF_CLASH_CONFIG = "buffClashConfig";

        public static readonly string AI_CONFIG = "aiConfig";

        public static readonly string CHARACTER_BASE_CONFIG = "characterBaseConfig";

        public static readonly string BATTLE_ACTION_CONFIG = "battleActionConfig";

        public static readonly string BATTLE_ACTION_EVENT_CONFIG = "battleActionEventConfig";

        public static readonly string BATTLE_SKILL_CONFIG = "battleSkillConfig";

        public static readonly string BATTLE_EFFECT_CONFIG = "battleEffectConfig";

        public static readonly string BATTLE_EFFECT_EVENT_CONFIG = "battleEffectEventConfig";

        public static readonly string BATTLE_ITEM_CONFIG = "battleItemConfig";

        public static readonly string MONSTER_CONFIG = "monsterConfig";

        public static readonly string DROP_CONFIG = "dropConfig";

        public static readonly string MONSTER_SKILL_GROUP_CONFIG = "monsterSkillGroupConfig";

		public static readonly string AERO_ATTRIBUTE_CONFIG = "aeroAttributeConfig";

        public static readonly string STORY_CONFIG = "storyConfig";

        public static readonly string DIALOG_CONFIG = "dialogConfig";

        public static readonly string EFFECT_ITEM_CONFIG = "effectItemCollide";

        public static readonly string ACTION_GROUP_CONFIG = "actionGroupConfig";

        public static readonly string CHAPTER_CONFIG = "chapterConfig";

        public static readonly string STAGE_CONFIG = "stageConfig";

        public static readonly string AERO_CONFIG = "aeroConfig";

        public static readonly string DARK_CLOUD_CONFIG = "darkCloudConfig";

        public static readonly string SHOCK_CONFIG = "shockConfig";

        public static readonly string CLOUD_CONFIG = "cloudConfig";

        public static readonly string RAIN_CONFIG = "rainConfig";

        public static readonly string WEATHER_PLAN_CONFIG = "weatherPlanConfig";

        public static readonly string STAGE_WEATHER_PLAN_CONFIG = "stageWeatherPlanConfig";

        public static readonly string ITEM_GENERATOR_CONFIG = "itemGeneratorConfig";

        public static readonly string STAGE_LOGIC_POINT_DESC_CONFIG = "stageLogicPointDescConfig";

        public static readonly string MODE_CONFIG = "modeConfig";

        public static readonly string PVP_STAGE_CONFIG = "pvpStageConfig";

        public static readonly string BATTLE_RESULT_CONFIG = "battleResultConfig";

        public static readonly string ROOM_CHANNEL_CONFIG = "roomChannelConfig";

        public static readonly string PROPS_CONFIG = "propsConfig";

        public static readonly string DIY_MALL_CONFIG = "diyMallConfig";

        public static readonly string DIY_PRESET_CONFIG = "diyPresetConfig";

        public static readonly string DECORATE_CONFIG = "decorateConfig";

        public static readonly string ROOM_ACTION_MALL_CONFIG = "roomActionMallConfig";

        public static readonly string ROOM_ACTION_CONFIG = "roomActionConfig";

        public static readonly string FASHION_CONFIG = "fashionConfig";

        public static readonly string FASHION_GROUP_CONFIG = "fashionGroupConfig";

        public static readonly string SPELLCARD_CONFIG = "spellCardConfig";

        public static readonly string SPELLCARD_LEVELUP_CONFIG = "spellCardLevelupConfig";

        public static readonly string BASE_MALL_CONFIG = "baseMallConfig";

        public static readonly string ACTIVITY_MALL_CONFIG = "activiyMallConfig";

        public static readonly string MALL_CONFIG = "mallConfig";

        public static readonly string DIY_CHAR_CONFIG = "diyCharConfig";

        public static readonly string AERO_LEVEL_UP_CONFIG = "aeroLevelUpConfig";

        public static readonly string AERO_GROUP_CONFIG = "aeroGroupConfig";

        public static readonly string CONSUME_CONFIG = "consumeConfig";

        public static readonly string EXCHANGE_CONFIG = "exchangeConfig";

        public static readonly string CAD_PLAYER_CONFIG = "cadPlayerConfig";

        public static readonly string CAD_PLAYER_ATTR_CONFIG = "cadPlayerAttrConfig";

        public static readonly string CAD_BOX_CONFIG = "cadBoxConfig";

        public static readonly string DECOMPOSE_CONFIG = "decomposeConfig";


        public static readonly string STORY_PLAY_CONFIG = "storyPlayConfig";

        public static readonly string BATTLE_MACHINE_CONFIG = "battleMachineConfig";

        public static readonly string MONSTER_BORN_CONFIG = "monsterBornConfig";

        public static readonly string PENTAKILL_CONFIG = "pentaKillConfig";

        public static readonly string EMOTICON_CONFIG = "emoticonConfig";

        public static readonly string CHARACTER_EXP_CONFIG = "characterExpConfig";

        public static readonly string NECKLACE_CONFIG = "necklaceConfig";

        public static readonly string DIFFICULTY_CURVE_CONFIG = "difficultyCurveConfig";

        public static readonly string ENDLESS_STAGE_CONFIG = "endlessStageConfig";

        public static readonly string ENDLESS_SCENE_CONFIG = "endlessScenceConfig";

        public static readonly string GUILD_PRIZE_CONFIG = "guildPrizeConfig";

        public static readonly string AMAP_CONFIG = "amapConfig";

        public static readonly string HORN_ATTR_CONFIG = "hornAttrConfig";

        public static readonly string GUILD_EXP_CONFIG = "guildExpConfig";

        public static readonly string WEAPON_CONFIG = "weaponConfig";

        public static readonly string WEAPON_ATTRIBUTE_CONFIG = "weaponAttributeConfig";

        public static readonly string FASHION_DYEING_CONFIG = "fashionDyeingConfig";

        public static readonly string FASHION_CUSTOMIZED_CONFIG = "fashionCustomizedConfig";

        public static readonly string BATTLE_COLOR_CONFIG = "battleColorConfig";

        public static readonly string GUILD_FLAG_CONFIG = "guildFlagConfig";
    }
}
