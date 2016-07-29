using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    class MoveActionNode : ActionNode
    {
        public int m_iPathId;
        public int m_iMoveSpeed;

        public MoveActionNode(int movespeed,int pathId)
        {
            m_iMoveSpeed = movespeed;
            m_iPathId = pathId;
        }
        public override string GetNodeDesc()
        {
            return "移动节点";
        }
    }
}