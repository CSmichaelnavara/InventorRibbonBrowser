using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Inventor;

namespace InventorRibbonBrowser;

class RibbonTreeNode : TreeNode
{
    public RibbonTreeNode(object nativeObject)
    {
        if (nativeObject == null)
            return;
        Nodes.Add("---");

        NativeObject = nativeObject;
        switch (nativeObject)
        {
            case Ribbons ribbons:
                RibbonNodeType = RibbonNodeType.Root;
                Text = "Ribbons";
                InternalName = "Ribbons";
                break;
            case Ribbon ribbon:
                RibbonNodeType = RibbonNodeType.Ribbon;
                Text = ribbon.InternalName;
                InternalName = ribbon.InternalName;
                break;
            case RibbonTab ribbonTab:
                RibbonNodeType = RibbonNodeType.RibbonTab;
                Text = ribbonTab.DisplayName;
                InternalName = ribbonTab.InternalName;
                break;
            case RibbonPanel ribbonPanel:
                RibbonNodeType = RibbonNodeType.RibbonPanel;
                Text = ribbonPanel.DisplayName;
                InternalName = ribbonPanel.InternalName;
                break;
            case CommandControl commandControl:
                RibbonNodeType = RibbonNodeType.Command;
                string displayName = commandControl.DisplayName;
                Text = string.IsNullOrEmpty(displayName) ? "??" : displayName;
                InternalName = commandControl.InternalName;
                break;
        }
    }

    public string InternalName { get; private set; }
    public CommandControl CommandControl => NativeObject as CommandControl;

    public object DisplayObject
    {
        get
        {
            switch (RibbonNodeType)
            {
                case RibbonNodeType.Unknown:
                    break;
                case RibbonNodeType.Root:
                    return new RibbonsInfo(Ribbons);
                case RibbonNodeType.Ribbon:
                    return new RibbonInfo(Ribbon);
                case RibbonNodeType.RibbonTab:
                    return new RibbonTabInfo(RibbonTab);
                case RibbonNodeType.RibbonPanel:
                    return new RibbonPanelInfo(RibbonPanel);
                case RibbonNodeType.Command:
                    return new CommandControlInfo(CommandControl);
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return NativeObject;
        }
    }

    public object NativeObject { get; set; }
    public Ribbon Ribbon => NativeObject as Ribbon;
    public RibbonNodeType RibbonNodeType { get; set; }
    public RibbonPanel RibbonPanel => NativeObject as RibbonPanel;
    public Ribbons Ribbons => NativeObject as Ribbons;
    public RibbonTab RibbonTab => NativeObject as RibbonTab;

    public void LoadChildren()
    {
        Nodes.Clear();
        IEnumerable children = null;
        switch (RibbonNodeType)
        {
            case RibbonNodeType.Unknown:
                break;
            case RibbonNodeType.Root:
                children = Ribbons;
                break;
            case RibbonNodeType.Ribbon:
                children = Ribbon.RibbonTabs;
                break;
            case RibbonNodeType.RibbonTab:
                children = RibbonTab.RibbonPanels;
                break;
            case RibbonNodeType.RibbonPanel:
                var controls = new List<object>();
                controls.AddRange(RibbonPanel.CommandControls.Cast<object>());
                controls.AddRange(RibbonPanel.SlideoutControls.Cast<object>());
                children = controls;
                break;
            case RibbonNodeType.Command:
                children = CommandControl.ChildControls;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (children == null) return;
        foreach (object child in children)
        {
            Nodes.Add(new RibbonTreeNode(child));
        }
    }
}