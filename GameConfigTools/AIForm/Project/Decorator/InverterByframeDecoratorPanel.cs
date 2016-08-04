using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameConfigTools.AIForm.Decorator
{
    public partial class InverterByframeDecoratorPanel : UserControl, BTParam
    {
        private int interval;
        public InverterByframeDecoratorPanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            if (!int.TryParse(intervalTextBox.Text, out interval))
            {
                return "间隔帧数必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new InverterByframeDecoratorNode(interval);
        }

        public void UpdateUI(TreeNode node)
        {
            InverterByframeDecoratorNode action = node as InverterByframeDecoratorNode;
            intervalTextBox.Text = action.Interval.ToString();
            interval = action.Interval;
        }

        public void UpdateNode(TreeNode node)
        {
            InverterByframeDecoratorNode action = node as InverterByframeDecoratorNode;
            interval = int.Parse(intervalTextBox.Text);
            action.Interval = interval;
        }
    }
}
