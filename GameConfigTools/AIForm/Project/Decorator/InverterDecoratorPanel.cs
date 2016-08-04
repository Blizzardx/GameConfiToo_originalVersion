using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameConfigTools.AIForm.Action;

namespace GameConfigTools.AIForm.Decorator
{
    public partial class InverterDecoratorPanel : UserControl, BTParam
    {

        private int interval;

        public InverterDecoratorPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            if (!int.TryParse(intervalTextBox.Text.Trim(), out interval))
            {
                return "间隔时间必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new InverterDecoratorNode(interval);
        }

        public void UpdateUI(TreeNode node)
        {
            InverterDecoratorNode n = node as InverterDecoratorNode;
            intervalTextBox.Text = n.Interval.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            InverterDecoratorNode n = node as InverterDecoratorNode;
            n.Interval = interval;
        }
    }
}
