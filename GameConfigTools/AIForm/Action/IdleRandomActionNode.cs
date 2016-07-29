using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.AIForm.Action
{
    public class IdleRandomActionNode:ActionNode
    {
        public int m_iMinX;
        public int m_iMaxX;
        public int m_iMinY;
        public int m_iMaxY;
        public int m_iMinDuringTime;
        public int m_iMaxDuringTime;

        public IdleRandomActionNode(int xMin,
                                    int xMax,
                                    int yMin,
                                    int yMax,
                                    int timeMin,
                                    int timeMax)
        {
            m_iMinX = xMin;
            m_iMaxX = xMax;
            m_iMinY = yMin;
            m_iMaxY = yMax;
            m_iMinDuringTime = timeMin;
            m_iMaxDuringTime = timeMax;
        }
        public override string GetNodeDesc()
        {
            return "待机随机节点";
        }
    }
}
