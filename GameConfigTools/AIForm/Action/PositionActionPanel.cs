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
    public partial class PositionActionPanel : UserControl, BTParam
    {
        private int range;
        public PositionActionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            if (!int.TryParse(rangeTextBox.Text.Trim(), out range))
            {
                return "站位间隔必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new PositionActionNode(range);
        }

        public void UpdateUI(TreeNode node)
        {
            PositionActionNode n = node as PositionActionNode;
            rangeTextBox.Text = n.Range.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            PositionActionNode n = node as PositionActionNode;
            n.Range = range;
        }
    }
}
