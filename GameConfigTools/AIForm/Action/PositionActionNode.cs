using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class PositionActionNode : ActionNode
    {
        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public PositionActionNode(int range)
        {
            this.range = range;
        }

        public override string GetNodeDesc()
        {
            return "站位行为";
        }
    }
}
