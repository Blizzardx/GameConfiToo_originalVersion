using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm.Action
{
    public partial class IdleRandomActionPanel : UserControl, BTParam
    {
        public int m_iMinX;
        public int m_iMaxX;
        public int m_iMinY;
        public int m_iMaxY;
        public int m_iMinDuringTime;
        public int m_iMaxDuringTime;

        public IdleRandomActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(xMinBox.Text, out m_iMinX))
            {
                return "最小x轴速度必须为整型";
            }
            if (!int.TryParse(xMaxBox.Text, out m_iMaxX))
            {
                return "最大x轴速度必须为整型";
            }
            if (!int.TryParse(yMinBox.Text, out m_iMinY))
            {
                return "最小y轴速度必须为整型";
            }
            if (!int.TryParse(yMaxBox.Text, out m_iMaxY))
            {
                return "最大y轴速度必须为整型";
            }
            if (!int.TryParse(duringtimeMinBox.Text, out m_iMinDuringTime))
            {
                return "最小持续时间必须为整型";
            }
            if (!int.TryParse(duringtimeMaxBox.Text, out m_iMaxDuringTime))
            {
                return "最大持续时间必须为整型";
            }
            if (m_iMinX > m_iMaxX)
            {
                return "max 必须大于等于 min";
            }
            if (m_iMinY > m_iMaxY)
            {
                return "max 必须大于等于 min";
            }
            if (m_iMinDuringTime > m_iMaxDuringTime)
            {
                return "max 必须大于等于 min";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new IdleRandomActionNode(m_iMinX,m_iMaxX,m_iMinY,m_iMaxY,m_iMinDuringTime,m_iMaxDuringTime);
        }

        public void UpdateUI(TreeNode node)
        {
            IdleRandomActionNode idleNode = node as IdleRandomActionNode;
            m_iMinX = idleNode.m_iMinX;
            m_iMaxX = idleNode.m_iMaxX;
            m_iMinY = idleNode.m_iMinY;
            m_iMaxY = idleNode.m_iMaxY;
            m_iMinDuringTime = idleNode.m_iMinDuringTime;
            m_iMaxDuringTime = idleNode.m_iMaxDuringTime;

            xMinBox.Text = m_iMinX.ToString();
            xMaxBox.Text = m_iMaxX.ToString();
            yMinBox.Text = m_iMinY.ToString();
            yMaxBox.Text = m_iMaxY.ToString();
            duringtimeMinBox.Text = m_iMinDuringTime.ToString();
            duringtimeMaxBox.Text = m_iMaxDuringTime.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            IdleRandomActionNode idleNode = node as IdleRandomActionNode;
            m_iMinX = int.Parse(xMinBox.Text);
            m_iMaxX = int.Parse(xMaxBox.Text);
            m_iMinY = int.Parse(yMinBox.Text);
            m_iMaxY = int.Parse(yMaxBox.Text);
            m_iMinDuringTime = int.Parse(duringtimeMinBox.Text);
            m_iMaxDuringTime = int.Parse(duringtimeMaxBox.Text);

            idleNode.m_iMinX = m_iMinX;
            idleNode.m_iMaxX = m_iMaxX;
            idleNode.m_iMinY = m_iMinY;
            idleNode.m_iMaxY = m_iMaxY;
            idleNode.m_iMinDuringTime = m_iMinDuringTime;
            idleNode.m_iMaxDuringTime = m_iMaxDuringTime;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
