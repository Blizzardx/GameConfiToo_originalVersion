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
    public partial class IdleStaticActionPanel : UserControl, BTParam
    {
        public int m_iRange;
        public int m_iRate;
        public int m_iPositionId;

        public IdleStaticActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(rangeBox.Text, out m_iRange))
            {
                return "浮动范围必须为整型";
            }
            if (!int.TryParse(rateBox.Text, out m_iRate))
            {
                return "浮动频率必须为整型";
            }
            if (!int.TryParse(positionIdBox.Text, out m_iPositionId))
            {
                return "位置id必须为整形";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new IdleStaticActionNode(m_iRange,m_iRate,m_iPositionId);
        }

        public void UpdateUI(TreeNode node)
        {
            IdleStaticActionNode idle = node as IdleStaticActionNode;
            m_iRange = idle.m_iRange;
            m_iRate = idle.m_iRate;
            m_iPositionId = idle.m_iPositionId;

            rangeBox.Text = m_iRange.ToString();
            rateBox.Text = m_iRate.ToString();
            positionIdBox.Text = m_iPositionId.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            IdleStaticActionNode idle = node as IdleStaticActionNode;
            m_iRange = int.Parse(rangeBox.Text);
            m_iRate = int.Parse(rateBox.Text);
            m_iPositionId = int.Parse(positionIdBox.Text);

            idle.m_iRange = m_iRange;
            idle.m_iRate = m_iRate;
            idle.m_iPositionId = m_iPositionId;
        }
    }
}
