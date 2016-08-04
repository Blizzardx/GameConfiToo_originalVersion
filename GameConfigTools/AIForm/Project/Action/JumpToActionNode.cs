using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConfigTools.AIForm.Action
{
    class JumpToActionNode : ActionNode
    {
        public int m_iSpeed;
        public int m_iGrivity;

        public JumpToActionNode(int speed, int g)
        {
            m_iSpeed = speed;
            m_iGrivity = g;
        }
        public override string GetNodeDesc()
        {
            return "跳跃节点";
        }
    }
}
