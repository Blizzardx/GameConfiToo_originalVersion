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
    public partial class MoveActionPanel : UserControl, BTParam
    {
        public int m_iPathId;
        public int m_iMoveSpeed;

        public MoveActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(PathIdTextBox.Text, out m_iPathId))
            {
                return "路径方案id必须为整型";
            }
            if (!int.TryParse(movespeedBox.Text, out m_iMoveSpeed))
            {
                return "移动速度必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new MoveActionNode(m_iMoveSpeed,m_iPathId);
        }

        public void UpdateUI(TreeNode node)
        {
            MoveActionNode action = node as MoveActionNode;
            PathIdTextBox.Text = action.m_iPathId.ToString();
            movespeedBox.Text = action.m_iMoveSpeed.ToString();
            m_iPathId = action.m_iPathId;
            m_iMoveSpeed = action.m_iMoveSpeed;
        }

        public void UpdateNode(TreeNode node)
        {
            MoveActionNode action = node as MoveActionNode;
            m_iPathId = int.Parse(PathIdTextBox.Text);
            m_iMoveSpeed = int.Parse(movespeedBox.Text);
            action.m_iPathId = m_iPathId;
            action.m_iMoveSpeed = m_iMoveSpeed;
        }
    }
}
