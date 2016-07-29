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
    public partial class RunActionPanel : UserControl, BTParam
    {
        private int m_iRunSpeed;

        public RunActionPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(runSpeedTextBox.Text, out m_iRunSpeed))
            {
                return "逃跑速度必须为整型";
            }
            return null;        
        }

        public TreeNode GenNode()
        {
            return new RunActionNode(m_iRunSpeed);
        }

        public void UpdateUI(TreeNode node)
        {
            RunActionNode runNode = node as RunActionNode;
            runSpeedTextBox.Text = runNode.m_iRunSpeed.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            RunActionNode runNode = node as RunActionNode;
            runNode.m_iRunSpeed = int.Parse(runSpeedTextBox.Text);
        }
    }
}
