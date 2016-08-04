using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameConfigTools.AIForm.Action
{
    public partial class JumptoActionPanel : UserControl, BTParam
    {
        public int m_iSpeed;
        public int m_iGrivity;

        public JumptoActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(MoveSpeedTextBox.Text,out m_iSpeed))
            {
                return "速度必须为整行";
            }
            if (!int.TryParse(GrivityTextBox.Text, out m_iGrivity))
            {
                return "重力加速度必须为整形";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new JumpToActionNode(m_iSpeed,m_iGrivity);
        }

        public void UpdateUI(TreeNode node)
        {
            JumpToActionNode action = node as JumpToActionNode;
            m_iSpeed = action.m_iSpeed;
            m_iGrivity = action.m_iGrivity;
            GrivityTextBox.Text = m_iGrivity.ToString();
            MoveSpeedTextBox.Text = m_iSpeed.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            JumpToActionNode action = node as JumpToActionNode;
            m_iSpeed = int.Parse(MoveSpeedTextBox.Text);
            m_iGrivity = int.Parse(GrivityTextBox.Text);
            action.m_iSpeed = m_iSpeed;
            action.m_iGrivity = m_iGrivity;
        }
    }
}
