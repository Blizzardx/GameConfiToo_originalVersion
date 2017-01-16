using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Config;

namespace GameConfigTools.FuncForm
{
    public partial class LimitPanel : UserControl
    {
        private LimitGroup group;
        public LimitPanel(LimitGroup group)
        {
            InitializeComponent();
            this.Dock = DockStyle.None;
            this.group = group;
        }
      
        public void DoUpdate()
        {
            idTextBox.Text = group.Id.ToString();
        }
    }
}
