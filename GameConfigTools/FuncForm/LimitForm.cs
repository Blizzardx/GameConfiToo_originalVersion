using Config;
using Config.Table;
using GameConfigTools.Constant;
using GameConfigTools.Import;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameConfigTools.FuncForm
{
    public partial class LimitForm : Form
    {
        private LimitConfigTable config;
        public LimitForm()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ImporterManager.instance.RemoveCacheConfig(SysConstant.LIMIT_CONFIG);

            string errMsg = "";
            config = ImporterManager.instance.GetCacheConfig(SysConstant.LIMIT_CONFIG, ref errMsg) as LimitConfigTable;
            if(errMsg != "")
            {
                MessageBox.Show(this, errMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<LimitGroup> list = new List<LimitGroup>();
            foreach (KeyValuePair<int, LimitGroup> kv in config.LimitMap)
            {
                list.Add(kv.Value);
            }
            FillLimit(list);
        }

        public void FillLimit(List<LimitGroup> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                LimitGroup group = list[i];

                LimitPanel lp = new LimitPanel(group);
                lp.Location = new Point(0, i * 60);
                lp.DoUpdate();

                panel1.Controls.Add(lp);
            }
        }
    }
}
