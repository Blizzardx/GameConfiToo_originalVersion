using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameConfigTools.AIForm.Action;

namespace GameConfigTools.AIForm.Action
{
    public partial class AttackActionPanel : UserControl, BTParam
    {
        private int moveSpeed;

        public AttackActionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            if (!int.TryParse(moveSpeedTextBox.Text.Trim(), out moveSpeed))
            {
                return "移动速度必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new AttackActionNode(moveSpeed);
        }

        public void UpdateUI(TreeNode node)
        {
            AttackActionNode actionNode = node as AttackActionNode;
            moveSpeedTextBox.Text = actionNode.m_iSpeed.ToString();
            moveSpeed = actionNode.m_iSpeed;
        }

        public void UpdateNode(TreeNode node)
        {
            AttackActionNode actionNode = node as AttackActionNode;
            
            if (int.TryParse(moveSpeedTextBox.Text,out actionNode.m_iSpeed))
            {
                //log error
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void moveSpeedTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
