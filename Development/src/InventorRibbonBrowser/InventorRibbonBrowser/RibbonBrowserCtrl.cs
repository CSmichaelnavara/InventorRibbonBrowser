using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Inventor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace InventorRibbonBrowser
{
    public partial class RibbonBrowserCtrl : UserControl
    {
        private Ribbons _ribbons;

        public RibbonBrowserCtrl()
        {
            InitializeComponent();
            treeView1.HideSelection = false;
        }


        public Ribbons Ribbons
        {
            get => _ribbons;
            set
            {
                _ribbons = value;
                PopulateTreeView();
            }
        }

        private void cCodeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string code = CodeBuilder.BuildCSharpCode(treeView1.SelectedNode as RibbonTreeNode);
            if (MessageBox.Show(code, "Copy code to clipboard?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Clipboard.SetText(code);
            }
        }

        private void interalNamePathToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string code = CodeBuilder.InternalNamePath(treeView1.SelectedNode as RibbonTreeNode);
            if (MessageBox.Show(code, "Copy code to clipboard?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Clipboard.SetText(code);
            }
        }


        private void PopulateTreeView()
        {
            treeView1.Nodes.Clear();
            if (Ribbons == null)
                return;

            var topNode = new RibbonTreeNode(Ribbons);

            treeView1.Nodes.Add(topNode);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var ribbonTreeNode = e.Node as RibbonTreeNode;
            if (ribbonTreeNode == null)
            {
                propertyGrid1.SelectedObject = null;
                toolStripStatusLabel1.Text = "";
                return;
            }

            propertyGrid1.SelectedObject = ribbonTreeNode.DisplayObject;
            toolStripStatusLabel1.Text =
                ribbonTreeNode.FullPath.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var treeNode = e.Node as RibbonTreeNode;
            treeNode?.LoadChildren();
        }

        private void vbNetCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = CodeBuilder.BuildVbNetCode(treeView1.SelectedNode as RibbonTreeNode);
            if (MessageBox.Show(code, "Copy code to clipboard?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Clipboard.SetText(code);
            }
        }
    }

    class CodeBuilder
    {
        static string BuildCode(RibbonTreeNode ribbonTreeNode, string indexerOpen, string indexerClose)
        {
            string result = "";
            var node = ribbonTreeNode;
            string internalName = node.InternalName;
            string childCollection = "";
            while (node.Parent is RibbonTreeNode parentNode)
            {
                switch (parentNode.RibbonNodeType)
                {
                    case RibbonNodeType.Unknown:
                        break;
                    case RibbonNodeType.Root:
                        childCollection = nameof(parentNode.Ribbons);
                        break;
                    case RibbonNodeType.Ribbon:
                        childCollection = nameof(parentNode.Ribbon.RibbonTabs);
                        break;
                    case RibbonNodeType.RibbonTab:
                        childCollection = nameof(parentNode.RibbonTab.RibbonPanels);
                        break;
                    case RibbonNodeType.RibbonPanel:
                        childCollection = nameof(parentNode.RibbonPanel.CommandControls);
                        break;
                    case RibbonNodeType.Command:
                        childCollection = nameof(parentNode.CommandControl.ChildControls);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                result = $".{childCollection}{indexerOpen}\"{internalName}\"{indexerClose}{result}";
                internalName = parentNode.InternalName;
                node = parentNode;
            }

            return result;
        }


        public static string InternalNamePath(RibbonTreeNode ribbonTreeNode)
        {
            string result = "";
            var node = ribbonTreeNode;
            result = node.InternalName;
            while (node.Parent is RibbonTreeNode parentNode)
            {
                result = parentNode.InternalName + "\\" + result;
                node = parentNode;
            }

            return result;
        }


        public static string BuildCSharpCode(RibbonTreeNode ribbonTreeNode) => BuildCode(ribbonTreeNode, "[", "]");


        public static string BuildVbNetCode(RibbonTreeNode ribbonTreeNode) => BuildCode(ribbonTreeNode, "(", ")");
    }
}