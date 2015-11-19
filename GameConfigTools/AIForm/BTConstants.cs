using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm
{
    public class BTConstants
    {
        public static string[][] NODE_NAMES = new string[][]{
            new string[]{ "选择节点", "顺序节点", "并行节点", "优先选择节点" },               //复合节点
            new string[]{ "间隔装饰节点" },               //装饰节点
            new string[]{ "条件节点" },               //条件节点
            new string[]{ "巡逻行为", "寻敌行为", "站位行为", "逃跑行为", "休闲行为", "攻击行为", "被攻击行为" },               //行为节点
        };


        public const string NODE_TYPE_SELECTOR = "selector";
        public const string NODE_TYPE_SEQUENCE = "sequence";
        public const string NODE_TYPE_PARALLEL = "parallel";
        public const string NODE_TYPE_PRIORITY_SELECTOR = "prioritySelector";

        public const string NODE_TYPE_DECORATOR = "decorator";
        public const string NODE_NAME_INVERTER = "inverter";


        public const string NODE_TYPE_CONDITION = "condition";

        public const string NODE_TYPE_ACTION = "action";
        public const string NODE_NAME_PATROL = "patrol";
        public const string NODE_NAME_POSITION = "position";
        public const string NODE_NAME_SEEK = "seek";
        public const string NODE_NAME_CHASE = "chase";
        public const string NODE_NAME_RETREAT = "retreat";
        public const string NODE_NAME_IDLE = "idle";
        public const string NODE_NAME_ATTACK = "attack";
        public const string NODE_NAME_ATTACKED = "attacked";
    }
}
