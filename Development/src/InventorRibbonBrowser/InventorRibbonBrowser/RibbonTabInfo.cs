using Inventor;

namespace InventorRibbonBrowser;

class RibbonTabInfo : RibbonTab
{
    private readonly RibbonTab _ribbonTab;

    public RibbonTabInfo(RibbonTab ribbonTab)
    {
        _ribbonTab = ribbonTab;
    }

    public void Delete()
    {
        _ribbonTab.Delete();
    }

    public ObjectTypeEnum Type => _ribbonTab.Type;

    public Ribbon Parent => _ribbonTab.Parent;

    public Application Application => _ribbonTab.Application;

    public string DisplayName => _ribbonTab.DisplayName;

    public string InternalName => _ribbonTab.InternalName;

    public RibbonPanels RibbonPanels => _ribbonTab.RibbonPanels;

    public bool Active
    {
        get => _ribbonTab.Active;
        set => _ribbonTab.Active = value;
    }

    public string ClientId => _ribbonTab.ClientId;

    public bool Visible
    {
        get => _ribbonTab.Visible;
        set => _ribbonTab.Visible = value;
    }

    public bool Contextual
    {
        get => _ribbonTab.Contextual;
        set => _ribbonTab.Contextual = value;
    }

    public string KeyTip
    {
        get => _ribbonTab.KeyTip;
        set => _ribbonTab.KeyTip = value;
    }
}