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
    public partial class RetreatActionPanel : UserControl, BTParam
    {
        private int maxCount;
        private int range;
        public RetreatActionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            if (!int.TryParse(maxCountTextBox.Text.Trim(), out maxCount)) 
            {
                return "最多逃跑次数必须为整型";
            }
            if (!int.TryParse(rangeTextBox.Text.Trim(), out range))
            {
                return "逃跑距离必须为整型";
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new RetreatActionNode(maxCount, range);
        }

        public void UpdateUI(TreeNode node)
        {
            RetreatActionNode n = node as RetreatActionNode;
            maxCountTextBox.Text = n.MaxCount.ToString();
            rangeTextBox.Text = n.Range.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            RetreatActionNode n = node as RetreatActionNode;
            n.MaxCount = maxCount;
            n.Range = range;
        }
    }
}
