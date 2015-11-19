using GameConfigTools.AIForm.Action;
using GameConfigTools.AIForm.Decorator;
using GameConfigTools.Model;
using GameConfigTools.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace GameConfigTools.AIForm
{
    public partial class EditAIConfigForm : Form
    {
        private TreeNode copyTreeNode;

        public EditAIConfigForm()
        {
            InitializeComponent();
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem == expandAllStripMenuItem)
            {
                treeView1.SelectedNode.ExpandAll();
                return;
            }
            
            //添加节点
            if(e.ClickedItem == addRootToolStripMenuItem1)
            {
                AddBTRootForm addBTForm = new AddBTRootForm(treeView1);
                addBTForm.ShowDialog(this);
                if (addBTForm.RootNode != null)
                {
                    treeView1.Nodes.Add(addBTForm.RootNode);
                }
                return;
            }

            if(e.ClickedItem == addToolStripMenuItem1)
            {
                AddNodeForm addNodeForm = new AddNodeForm(treeView1.SelectedNode, OperType.Add);
                addNodeForm.ShowDialog(this);
                
                return;
            }
            if(e.ClickedItem == updateToolStripMenuItem1)
            {
                AddNodeForm addNodeForm = new AddNodeForm(treeView1.SelectedNode, OperType.Update);
                addNodeForm.ShowDialog(this);
                return;
            }
            if(e.ClickedItem == delToolStripMenuItem1)
            {
                treeView1.SelectedNode.Remove();
                return;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                addToolStripMenuItem1.Enabled = false;
                updateToolStripMenuItem1.Enabled = false;
                delToolStripMenuItem1.Enabled = false;
            }
            else
            {
                addToolStripMenuItem1.Enabled = true;
                updateToolStripMenuItem1.Enabled = true;
                delToolStripMenuItem1.Enabled = true;
            }

            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode != null)
            {
                if (selectNode.Parent == null && selectNode.Nodes.Count > 0)
                {
                    addToolStripMenuItem1.Enabled = false;
                    return;
                }
                else
                {
                    addToolStripMenuItem1.Enabled = true;
                }
                if(selectNode is DecoratorNode)
                {
                    if (selectNode.Nodes.Count > 0)
                    {
                        addToolStripMenuItem1.Enabled = false;
                        return;
                    }
                    else
                    {
                        addToolStripMenuItem1.Enabled = true;
                    }
                }
                
                if (selectNode is ConditionNode)
                {
                    addToolStripMenuItem1.Enabled = false;
                    return;
                }
                else
                {
                    addToolStripMenuItem1.Enabled = true;
                }
                if (selectNode is ActionNode)
                {
                    addToolStripMenuItem1.Enabled = false;
                    return;
                }
                else
                {
                    addToolStripMenuItem1.Enabled = true;
                }
            }
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(treeView1, e.Location);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button != System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }
            treeView1.SelectedNode = e.Node;
            e.Node.Expand();
        }

        private void EditAIConfigForm_Load(object sender, EventArgs e)
        {
            this.SaveAIConfig(new XElement("root"), false);

            XElement root = this.LoadAIConfig();
            this.GenTreeViewDataByXml(root);
        }

        /// <summary>
        /// 根据xml生成行为树显示
        /// </summary>
        /// <param name="root"></param>
        public void GenTreeViewDataByXml(XElement root)
        {
            var behaviorTreeEList = root.Elements("behaviorTree");
            if(behaviorTreeEList == null || behaviorTreeEList.Count() == 0)
            {
                return;
            }
            foreach(XElement behaviorTreeE in behaviorTreeEList)
            {
                int id = int.Parse(behaviorTreeE.Attribute("id").Value);
                string desc = behaviorTreeE.Attribute("desc").Value;
                RootNode rootNode = new RootNode(id, desc);
                treeView1.Nodes.Add(rootNode);

                this.GenNode(rootNode, behaviorTreeE);
            }
        }

        private void GenNode(TreeNode parent, XElement btNode)
        {
            var btNodeEList = btNode.Elements("btNode");
            if (btNodeEList == null || btNodeEList.Count() == 0)
            {
                return;
            }
            foreach (XElement btNodeE in btNodeEList)
            {
                TreeNode node = this.GetTreeNode(btNodeE);
                if(node != null)
                {
                    parent.Nodes.Add(node);
                }

                this.GenNode(node, btNodeE);
            }
        }

        private TreeNode GetTreeNode(XElement btNodeE)
        {
            string nodeType = btNodeE.Attribute("nodeType").Value;

            if(nodeType == BTConstants.NODE_TYPE_SELECTOR)
            {
                
                return new SelectorNode();

            }
            else if(nodeType == BTConstants.NODE_TYPE_SEQUENCE)
            {
                return new SequenceNode();
            }
            else if(nodeType == BTConstants.NODE_TYPE_PARALLEL)
            {
                return new ParallelNode();
            }
            else if(nodeType == BTConstants.NODE_TYPE_PRIORITY_SELECTOR)
            {
                return new PrioritySelectorNode();
            }
            else if (nodeType == BTConstants.NODE_TYPE_DECORATOR)           //装饰节点
            {
                string nodeName = btNodeE.Attribute("name").Value;
                //间隔装饰节点
                if(nodeName == BTConstants.NODE_NAME_INVERTER)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);

                    return new InverterDecoratorNode(int.Parse(dic["interval"]));
                }
            }
            else if(nodeType == BTConstants.NODE_TYPE_CONDITION)
            {
                Dictionary<string, string> dic = this.GetProperty(btNodeE);
                return new ConditionNode(int.Parse(dic["targetId"]), int.Parse(dic["limitId"]));
            }
            else if(nodeType == BTConstants.NODE_TYPE_ACTION)
            {
                string nodeName = btNodeE.Attribute("name").Value;

                if(nodeName == BTConstants.NODE_NAME_PATROL)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    return new PatrolActionNode(int.Parse(dic["range"]));
                }
                else if(nodeName == BTConstants.NODE_NAME_SEEK)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    return new SeekActionNode(int.Parse(dic["range"]), (dic.ContainsKey("type") ? int.Parse(dic["type"]) : 0));
                }
                else if(nodeName == BTConstants.NODE_NAME_POSITION)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    return new PositionActionNode(int.Parse(dic["range"]));
                }
                else if (nodeName == BTConstants.NODE_NAME_RETREAT)
                {
                    Dictionary<string, string> dic = this.GetProperty(btNodeE);
                    return new RetreatActionNode(int.Parse(dic["maxCount"]), int.Parse(dic["range"]));
                }
                else if(nodeName == BTConstants.NODE_NAME_IDLE)
                {
                    return new IdleActionNode();
                }
                else if(nodeName == BTConstants.NODE_NAME_ATTACK)
                {
                    return new AttackActionNode();
                }
                else if(nodeName == BTConstants.NODE_NAME_ATTACKED)
                {
                    return new AttackedActionNode();
                }
            }
            return null;
        }

        private Dictionary<string, string> GetProperty(XElement btNodeE)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var propertyEList = btNodeE.Elements("property");
            if (propertyEList == null || propertyEList.Count() == 0)
            {
                return dic;
            }
            foreach(XElement propertyE in propertyEList)
            {
                dic.Add(propertyE.Attribute("key").Value, propertyE.Attribute("value").Value);
            }
            return dic;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            XElement root = new XElement("root");
            if(treeView1.Nodes.Count > 0)
            {
                foreach(TreeNode node in treeView1.Nodes)
                {
                    RootNode rootNode = node as RootNode;
                    XElement behaviorTreeE = new XElement("behaviorTree");
                    root.Add(behaviorTreeE);
                    behaviorTreeE.Add(new XAttribute("id", rootNode.Id));
                    behaviorTreeE.Add(new XAttribute("desc", rootNode.Desc));

                    if(rootNode.Nodes.Count > 0)
                    {
                        this.GenXml(rootNode, behaviorTreeE);
                    }
                }
            }
            this.SaveAIConfig(root, true);
            MessageBox.Show("保存AI配置到本地成功");
        }

        private void GenXml(TreeNode parent, XElement btNodeE)
        {
            if (parent.Nodes.Count == 0)
            {
                return;
            }
            foreach(TreeNode node in parent.Nodes)
            {
                XElement xe = new XElement("btNode");
                btNodeE.Add(xe);

                if(node is SelectorNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_SELECTOR));
                }
                else if(node is SequenceNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_SEQUENCE));
                }
                else if (node is ParallelNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_PARALLEL));
                }
                else if(node is PrioritySelectorNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_PRIORITY_SELECTOR));
                }
                else if(node is DecoratorNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_DECORATOR));
                    if(node is InverterDecoratorNode)
                    {
                        InverterDecoratorNode n = node as InverterDecoratorNode;
                        
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_INVERTER));
                        xe.Add(this.GetPropertyElement("interval", n.Interval));
                    }
                }
                else if(node is ConditionNode)
                {
                    ConditionNode n = node as ConditionNode;
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_CONDITION));
                    xe.Add(this.GetPropertyElement("targetId", n.TargetId));
                    xe.Add(this.GetPropertyElement("limitId", n.LimitId));
                }
                else if(node is ActionNode)
                {
                    xe.Add(new XAttribute("nodeType", BTConstants.NODE_TYPE_ACTION));
                    if(node is PatrolActionNode)
                    {
                        PatrolActionNode n = node as PatrolActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_PATROL));
                        xe.Add(this.GetPropertyElement("range", n.Range));
                    }
                    else if (node is SeekActionNode)
                    {
                        SeekActionNode n = node as SeekActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_SEEK));
                        xe.Add(this.GetPropertyElement("range", n.Range));
                        xe.Add(this.GetPropertyElement("type", n.Type));
                    }
                    else if (node is PositionActionNode)
                    {
                        PositionActionNode n = node as PositionActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_POSITION));
                        xe.Add(this.GetPropertyElement("range", n.Range));
                    }
                    else if (node is RetreatActionNode)
                    {
                        RetreatActionNode n = node as RetreatActionNode;
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_RETREAT));
                        xe.Add(this.GetPropertyElement("maxCount", n.MaxCount));
                        xe.Add(this.GetPropertyElement("range", n.Range));
                    }
                    else if(node is IdleActionNode)
                    {
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_IDLE));
                    }
                    else if(node is AttackActionNode)
                    {
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_ATTACK));
                    }
                    else if (node is AttackedActionNode)
                    {
                        xe.Add(new XAttribute("name", BTConstants.NODE_NAME_ATTACKED));
                    }
                }

                if(node.Nodes.Count > 0)
                {
                    this.GenXml(node, xe);
                }
            }
        }

        private XElement GetPropertyElement(string key, object value)
        {
            XElement e = new XElement("property");
            e.Add(new XAttribute("key", key));
            e.Add(new XAttribute("value", value));
            return e;
        }

        private void SaveAIConfig(XElement root, bool force)
        {
            SysConfig config = Context.instance.GetSysConfig();

            string filePath = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\aiConfig.xml";
            if (!File.Exists(filePath) || force)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    XmlWriterSettings setting = new XmlWriterSettings();
                    setting.Indent = true;
                    setting.IndentChars = "\t";
                    setting.NewLineChars = "\n";
                    setting.Encoding = Encoding.UTF8;
                    using (XmlWriter xw = XmlWriter.Create(fs, setting))
                    {
                        root.WriteTo(xw);
                    }
                }
            }
        }

        private XElement LoadAIConfig()
        {
            SysConfig config = Context.instance.GetSysConfig();

            string filePath = config.ExcelPath + @"\" + Context.instance.GetGame() + @"\" + Context.instance.GetVersion() + @"\aiConfig.xml";

            return XElement.Load(filePath);
        }

        private bool CanAddNode(TreeNode source, TreeNode target)
        {

            return true;
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if(selectNode == null)
            {
                MessageBox.Show(this, "请先选择要移动的节点", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNode parent = selectNode.Parent;
            int currIndex = selectNode.Index;
            if (currIndex == 0)
            {
                treeView1.Focus();
                return;
            }
            selectNode.Remove();
            parent.Nodes.Insert(currIndex - 1, selectNode);
            treeView1.SelectedNode = selectNode;
            treeView1.Focus();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode == null)
            {
                MessageBox.Show(this, "请先选择要移动的节点", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TreeNode parent = selectNode.Parent;
            if(selectNode.NextNode == null)
            {
                treeView1.Focus();
                return;
            }
            int currIndex = selectNode.Index;
            selectNode.Remove();
            parent.Nodes.Insert(currIndex + 1, selectNode);
            treeView1.SelectedNode = selectNode;
            treeView1.Focus();
        }
    }
}
