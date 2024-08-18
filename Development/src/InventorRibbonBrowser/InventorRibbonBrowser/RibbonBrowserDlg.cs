using System.Windows.Forms;
using Application = Inventor.Application;

namespace InventorRibbonBrowser
{
    public partial class RibbonBrowserDlg : Form
    {
        private Application _inventor;

        public Application ThisApplication
        {
            get => _inventor;
            set
            {
                _inventor = value;
                ribbonBrowserCtrl1.Ribbons = ThisApplication.UserInterfaceManager.Ribbons;
            }
        }

        public RibbonBrowserDlg()
        {
            InitializeComponent();
        }
    }
}
