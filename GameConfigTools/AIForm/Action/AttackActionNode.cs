using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class AttackActionNode : ActionNode
    {
        public int m_iSpeed;

        public AttackActionNode(int moveSpeed)
        {
            m_iSpeed = moveSpeed;
        }
        public override string GetNodeDesc()
        {
            return "普攻节点";
        }
    }
}
