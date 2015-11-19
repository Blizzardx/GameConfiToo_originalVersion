using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class RetreatActionNode : ActionNode
    {
        private int maxCount;

        public int MaxCount
        {
            get { return maxCount; }
            set { maxCount = value; }
        }
        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public RetreatActionNode(int maxCount, int range)
        {
            this.maxCount = maxCount;
            this.range = range;
        }

        public override string GetNodeDesc()
        {
            return "逃跑行为";
        }
    }
}
