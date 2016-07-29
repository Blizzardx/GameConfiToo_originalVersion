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
    public partial class IdleRegularityActionPanel : UserControl, BTParam
    {
        public int m_iSpeed;
        public int m_iPathId;

        public IdleRegularityActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(moveSpeedBox.Text, out m_iSpeed))
            {
                return "移动速度必须为整型";
            }
            if (!int.TryParse(pathIdBox.Text, out m_iPathId))
            {
                return "路径id必须为整形";
            }
            return null;
        }
        public TreeNode GenNode()
        {
            return new IdleRegualrityActionNode(m_iSpeed,m_iPathId);
        }
        public void UpdateUI(TreeNode node)
        {
            IdleRegualrityActionNode idle = node as IdleRegualrityActionNode;
            m_iSpeed = idle.m_iSpeed;
            m_iPathId = idle.m_iPathId;
            moveSpeedBox.Text = m_iSpeed.ToString();
            pathIdBox.Text = m_iPathId.ToString();
        }
        public void UpdateNode(TreeNode node)
        {
            IdleRegualrityActionNode idle = node as IdleRegualrityActionNode;
            m_iPathId = int.Parse(pathIdBox.Text);
            m_iSpeed = int.Parse(moveSpeedBox.Text);

            idle.m_iPathId = m_iPathId;
            idle.m_iSpeed = m_iSpeed;
        }
    }
}
