using Inventor;

namespace InventorRibbonBrowser;

class RibbonInfo : Ribbon
{
    private readonly Ribbon _ribbon;

    public RibbonInfo(Ribbon ribbon)
    {
        _ribbon = ribbon;
    }

    public ObjectTypeEnum Type => _ribbon.Type;
    public UserInterfaceManager Parent => _ribbon.Parent;
    public Application Application => _ribbon.Application;
    public string InternalName => _ribbon.InternalName;
    public RibbonTabs RibbonTabs => _ribbon.RibbonTabs;
    public bool Active => _ribbon.Active;
    public CommandControls QuickAccessControls => _ribbon.QuickAccessControls;
}