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
    public partial class PatrolActionPanel : UserControl, BTParam
    {
        private int range;
        public PatrolActionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            if (!int.TryParse(rangeTextBox.Text.Trim(), out range))
            {
                return "巡逻范围必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new PatrolActionNode(range);
        }

        public void UpdateUI(TreeNode node)
        {
            PatrolActionNode n = node as PatrolActionNode;
            rangeTextBox.Text = n.Range.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            PatrolActionNode n = node as PatrolActionNode;
            n.Range = range;
        }
    }
}
