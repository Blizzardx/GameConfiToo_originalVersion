using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    class IdleStaticActionNode:ActionNode
    {
        public int m_iRange;
        public int m_iRate;
        public int m_iPositionId;

        public IdleStaticActionNode(int range, int rate, int positionId)
        {
            m_iRange = range;
            m_iRate = rate;
            m_iPositionId = positionId;
        }
        public override string GetNodeDesc()
        {
            return "待机静态节点";
        }
    }
}
