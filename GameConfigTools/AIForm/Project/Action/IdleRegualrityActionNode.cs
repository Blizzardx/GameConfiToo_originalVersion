using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    class IdleRegualrityActionNode:ActionNode
    {
        public int m_iSpeed;
        public int m_iPathId;

        public IdleRegualrityActionNode(int speed,int pathId)
        {
            m_iSpeed = speed;
            m_iPathId = pathId;
        }

        public override string GetNodeDesc()
        {
            return "待机规律节点";
        }
    }
}
