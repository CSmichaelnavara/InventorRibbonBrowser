using System;
using System.Runtime.InteropServices;
using Inventor;

namespace InventorRibbonBrowser
{
    [Guid("4c566814-74c9-4805-97fa-49e305991251")]
    public class StandardAddInServer : ApplicationAddInServer
    {
        public const string ClientId = "{4c566814-74c9-4805-97fa-49e305991251}";
        private Application _inventor;

        private ButtonDefinition _showRibbonTreeBtn;

        private RibbonPanel zeroDocPanel;
        private RibbonPanel partPanel;
        private RibbonPanel assemblyPanel;
        private RibbonPanel drawingPanel;

        public void Activate(ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            _inventor = addInSiteObject.Application;

            _showRibbonTreeBtn = _inventor.CommandManager.ControlDefinitions.AddButtonDefinition(
                "Ribbon tree",
                "InventorRibbonBrowser.ShowRibbonTreeBtn",
                CommandTypesEnum.kQueryOnlyCmdType,
                ClientId
            );
            _showRibbonTreeBtn.OnExecute += ShowRibbonTreeBtn_OnExecute;
            //_showRibbonTreeBtn.AutoAddToGUI();

            string zeroDocPanelInternalName = "CsMichaelNavara.InventorRibbonBrowser.ZeroDocPanel";
            string partPanelInternalName = "CsMichaelNavara.InventorRibbonBrowser.PartPanel";
            string assemblyPanelInternalName = "CsMichaelNavara.InventorRibbonBrowser.AssemblyPanel";
            string drawingPanelInternalName = "CsMichaelNavara.InventorRibbonBrowser.DrawingPanel";

            zeroDocPanel = _inventor.UserInterfaceManager.Ribbons["ZeroDoc"].RibbonTabs["id_TabTools"].RibbonPanels.Add("Ribbon", zeroDocPanelInternalName, ClientId);
            partPanel = _inventor.UserInterfaceManager.Ribbons["Part"].RibbonTabs["id_AddInsTab"].RibbonPanels.Add("Ribbon", zeroDocPanelInternalName, ClientId);
            assemblyPanel = _inventor.UserInterfaceManager.Ribbons["Assembly"].RibbonTabs["id_AddInsTab"].RibbonPanels.Add("Ribbon", zeroDocPanelInternalName, ClientId);
            drawingPanel = _inventor.UserInterfaceManager.Ribbons["Drawing"].RibbonTabs["id_AddInsTab"].RibbonPanels.Add("Ribbon", zeroDocPanelInternalName, ClientId);

            zeroDocPanel.CommandControls.AddButton(_showRibbonTreeBtn);
            partPanel.CommandControls.AddButton(_showRibbonTreeBtn);
            assemblyPanel.CommandControls.AddButton(_showRibbonTreeBtn);
            drawingPanel.CommandControls.AddButton(_showRibbonTreeBtn);

        }

        public void Deactivate()
        {
            _showRibbonTreeBtn.Delete();

            zeroDocPanel.Delete();
            partPanel.Delete();
            assemblyPanel.Delete();
            drawingPanel.Delete();

            _inventor = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ExecuteCommand(int commandId)
        {
        }

        public object Automation => null;

        private void ShowRibbonTreeBtn_OnExecute(NameValueMap context)
        {
            var ribbonBrowserDlg = new RibbonBrowserDlg() { ThisApplication = _inventor };
            ribbonBrowserDlg.Show();
        }
    }
}