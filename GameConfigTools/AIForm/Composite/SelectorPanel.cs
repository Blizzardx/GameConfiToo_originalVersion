﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm.Composite
{
    public partial class SelectorPanel : UserControl, BTParam
    {

        public SelectorPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public string ValidateParam()
        {

            return null;
        }

        public TreeNode GenNode()
        {
            return new SelectorNode();
        }

        public void UpdateUI(TreeNode node)
        {

        }

        public void UpdateNode(TreeNode node)
        {

        }
    }
}
