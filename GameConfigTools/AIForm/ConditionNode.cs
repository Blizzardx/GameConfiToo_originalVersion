using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm
{
    public class ConditionNode : BTNode
    {
        private int targetId;

        public int TargetId
        {
            get { return targetId; }
            set { targetId = value; }
        }
        private int limitId;

        public int LimitId
        {
            get { return limitId; }
            set { limitId = value; }
        }

        public ConditionNode(int targetId, int limitId)
        {
            this.targetId = targetId;
            this.limitId = limitId;
        }

        public override string GetNodeDesc()
        {
            return "条件节点";
        }
    }
}
