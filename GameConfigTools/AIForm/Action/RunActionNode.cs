using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{

    public class RunActionNode : ActionNode
    {
        public int m_iRunSpeed;

        public RunActionNode(int speed)
        {
            m_iRunSpeed = speed;
        }
        public override string GetNodeDesc()
        {
            return "逃跑节点";
        }
    }
}
