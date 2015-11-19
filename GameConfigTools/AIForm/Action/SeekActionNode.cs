using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class SeekActionNode : ActionNode
    {
        private int range;

        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public SeekActionNode(int range, int type)
        {
            this.range = range;
            this.type = type;
        }

        public override string GetNodeDesc()
        {
            return "寻敌行为";
        }
    }
}
