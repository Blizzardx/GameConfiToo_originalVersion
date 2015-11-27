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

        /// <summary>
        /// messageConfig配置
        /// </summary>
        public static readonly string MESSAGE_CONFIG = "messageConfig";

        public static readonly string LIMIT_CONFIG = "limitConfig";

        public static readonly string FUNC_CONFIG = "funcConfig";

        public static readonly string TARGET_CONFIG = "targetConfig";

        public static readonly string SYSTEM_CONFIG = "systemConfig";

        public static readonly string TERRAIN_EDITOR_CONFIG = "terrainEditorConfig";

        public static readonly string AI_MOVE_CONFIG = "aiMoveConfig";

        public static readonly string ANIEDITOR_CONFIG = "aniEditorConfig";

        public static readonly string AI_CONFIG = "aiConfig";

        public static readonly string CHARACTOR_CONFIG = "charactorConfig";

        public static readonly string NPC_CONFIG = "npcConfig";

        public static readonly string TERRAIN_CONFIG = "terrainConfig";

        public static readonly string ACTION_CONFIG = "actionConfig";

        public static readonly string DIALOG_CONFIG = "dialogConfig";

        public static readonly string MAIN_MISSION_CONFIG = "mainMissionConfig";

        public static readonly string MISSION_STEP_CONFIG = "missionStepConfig";

        public static readonly string STAGE_CONFIG = "stageConfig";

        public static readonly string SKILL_CONFIG = "skillConfig";


        public static readonly string RATIOGAME_CONFIG = "ratioGameConfig";        
public static readonly string CHAT_DIRTY_WORD_CONFIG = "chatDirtywordConfig";

        public static readonly string NAME_DIRTY_WORD_CONFIG = "nameDirtywordConfig";    }
}


