using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class PatrolActionNode : ActionNode
    {
        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public PatrolActionNode(int range)
        {
            this.range = range;
        }

        public override string GetNodeDesc()
        {
            return "巡逻行为";
        }
    }
}
