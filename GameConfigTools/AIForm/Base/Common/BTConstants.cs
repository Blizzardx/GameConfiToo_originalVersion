using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm
{
    public class BTConstants
    {
        public static string[][] NODE_NAMES = new string[][]{
            new string[]{ "选择节点", "顺序节点", "并行选择节点", "并行顺序节点"},               //复合节点
            new string[]{ "间隔时间装饰节点","间隔帧数装饰节点" },               //装饰节点
            new string[]{ "条件节点" },               //条件节点
            new string[]{
                "死亡节点",
                "技能攻击节点",
                "逃跑节点",
                "普攻节点",
                "待机静态节点",
                "待机规律节点",
                "待机随机节点",
                "移动节点",
                "跳跃节点",
            },               //行为节点
        };

        //复合节点
        public const string NODE_TYPE_SELECTOR = "selector";
        public const string NODE_TYPE_SEQUENCE = "sequence";
        public const string NODE_TYPE_PARALLEL = "parallel";
        public const string NODE_TYPE_PRIORITY_SELECTOR = "prioritySelector";
        public const string NODE_TYPE_PARALLEL_SELECTOR = "parallelSelector";
        public const string NODE_TYPE_PARALLEL_SEQUENCE = "parallelSequence";

        //装饰节点
        public const string NODE_TYPE_DECORATOR = "decorator";
        public const string NODE_NAME_INVERTER = "inverter";
        public const string Node_NAME_INVERTER_FRAME = "inverterbyframe";

        //条件节点
        public const string NODE_TYPE_CONDITION = "condition";

        //行为节点
        public const string NODE_TYPE_ACTION = "action";
        public const string NODE_NAME_DEAD = "dead";
        public const string NODE_NAME_RESUME = "resume";
        public const string NODE_NAME_SKILLATTACK = "skillattack";
        public const string NODE_NAME_ATTACK = "attack";
        public const string NODE_NAME_RUN = "run";
        public const string NODE_NAME_IDLE_STATIC = "idlestatic";
        public const string NODE_NAME_IDLE_RANDOM = "idlerandom";
        public const string NODE_NAME_IDLE_REGULARITY = "idleregularity";
        public const string Node_Name_MOVE = "move";
        public const string NODE_NAME_JUMPTO = "jumpto";
    }
}
