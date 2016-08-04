using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameConfigTools.AIForm.Project.Composite
{
    public partial class ParallelSequencePanel : UserControl, BTParam
    {
        public ParallelSequencePanel()
        {
            InitializeComponent();
        }

        public string ValidateParam()
        {
            return null;
        }

        public TreeNode GenNode()
        {
            return new ParallelSequenceNode();
        }

        public void UpdateUI(TreeNode node)
        {

        }

        public void UpdateNode(TreeNode node)
        {

        }
    }
}
