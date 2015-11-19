using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameConfigTools.AIForm
{
    public class RootNode : BTNode
    {
        private int id;
        private string desc;

        public string Desc
        {
            get { return desc; }
        }
        public int Id
        {
            get { return id; }
        }
        public RootNode(int id, string desc)
        {
            this.id = id;
            this.desc = desc;
            Text = GetNodeDesc();
        }

        public override string GetNodeDesc()
        {
            return id + ": " + desc;
        }
    }
}
