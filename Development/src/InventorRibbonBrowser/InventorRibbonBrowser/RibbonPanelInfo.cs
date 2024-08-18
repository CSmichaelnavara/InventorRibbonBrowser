using Inventor;

namespace InventorRibbonBrowser;

class RibbonPanelInfo : RibbonPanel
{
    private readonly RibbonPanel _ribbonPanel;

    public RibbonPanelInfo(RibbonPanel ribbonPanel)
    {
        _ribbonPanel = ribbonPanel;
    }

    public void Delete()
    {
        _ribbonPanel.Delete();
    }

    public void Reposition(string targetPanelInternalName, bool insertBeforeTargetPanel)
    {
        _ribbonPanel.Reposition(targetPanelInternalName, insertBeforeTargetPanel);
    }

    public void Move(int top, int left)
    {
        _ribbonPanel.Move(top, left);
    }

    public ObjectTypeEnum Type => _ribbonPanel.Type;

    public RibbonTab Parent => _ribbonPanel.Parent;

    public Application Application => _ribbonPanel.Application;

    public string DisplayName => _ribbonPanel.DisplayName;

    public string InternalName => _ribbonPanel.InternalName;

    public CommandControls CommandControls => _ribbonPanel.CommandControls;

    public string ClientId => _ribbonPanel.ClientId;

    public bool Visible
    {
        get => _ribbonPanel.Visible;
        set => _ribbonPanel.Visible = value;
    }

    public bool Docked
    {
        get => _ribbonPanel.Docked;
        set => _ribbonPanel.Docked = value;
    }

    public CommandControls SlideoutControls => _ribbonPanel.SlideoutControls;

    public string SlideOutKeyTip
    {
        get => _ribbonPanel.SlideOutKeyTip;
        set => _ribbonPanel.SlideOutKeyTip = value;
    }
}