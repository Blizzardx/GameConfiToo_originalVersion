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
    public partial class ChaseActionPanel : UserControl, BTParam
    {
        private bool canChase;
        private bool hasBeenChase;
        private int chaseTime;

        public ChaseActionPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {
            canChase = canChaseCheckBox.Checked;
            hasBeenChase = hasBeenChaseCheckBox.Checked;
            if (!hasBeenChase)
            {
                if (!int.TryParse(chaseTimeTextBox.Text.Trim(), out chaseTime))
                {
                    return "追击时间必须为整型";
                }
            }
            return null;
        }

        public TreeNode GenNode()
        {
            return new ChaseActionNode(canChase, hasBeenChase, chaseTime);
        }

        public void UpdateUI(TreeNode node)
        {
            ChaseActionNode n = node as ChaseActionNode;
            canChaseCheckBox.Checked = n.CanChase;
            hasBeenChaseCheckBox.Checked = n.HasBeenChase;
            chaseTimeTextBox.Text = n.ChaseTime.ToString();
        }

        public void UpdateNode(TreeNode node)
        {
            ChaseActionNode n = node as ChaseActionNode;
            n.CanChase = canChase;
            n.HasBeenChase = hasBeenChase;
            n.ChaseTime = chaseTime;
        }
    }
}
