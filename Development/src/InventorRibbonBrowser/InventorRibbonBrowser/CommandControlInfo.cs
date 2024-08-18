using Inventor;

namespace InventorRibbonBrowser;

class CommandControlInfo : CommandControl
{
    private readonly CommandControl _commandControl;

    public CommandControlInfo(CommandControl commandControl)
    {
        _commandControl = commandControl;
    }

    public void Delete()
    {
        _commandControl.Delete();
    }

    public ObjectTypeEnum Type => _commandControl.Type;

    public Application Application => _commandControl.Application;

    public object Parent => _commandControl.Parent;

    public string DisplayName => _commandControl.DisplayName;

    public string InternalName => _commandControl.InternalName;

    public CommandControls ChildControls => _commandControl.ChildControls;

    public ControlDefinition ControlDefinition => _commandControl.ControlDefinition;

    public ControlTypeEnum ControlType => _commandControl.ControlType;

    public ControlDefinition DisplayedControl
    {
        get => _commandControl.DisplayedControl;
        set => _commandControl.DisplayedControl = value;
    }

    public bool ShowText
    {
        get => _commandControl.ShowText;
        set => _commandControl.ShowText = value;
    }

    public bool UseLargeIcon
    {
        get => _commandControl.UseLargeIcon;
        set => _commandControl.UseLargeIcon = value;
    }

    public bool Visible
    {
        get => _commandControl.Visible;
        set => _commandControl.Visible = value;
    }

    public string KeyTip
    {
        get => _commandControl.KeyTip;
        set => _commandControl.KeyTip = value;
    }
}