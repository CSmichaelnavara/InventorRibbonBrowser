namespace InventorRibbonBrowser
{
    partial class RibbonBrowserDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbonBrowserCtrl1 = new InventorRibbonBrowser.RibbonBrowserCtrl();
            this.SuspendLayout();
            // 
            // ribbonBrowserCtrl1
            // 
            this.ribbonBrowserCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBrowserCtrl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBrowserCtrl1.Name = "ribbonBrowserCtrl1";
            this.ribbonBrowserCtrl1.Ribbons = null;
            this.ribbonBrowserCtrl1.Size = new System.Drawing.Size(453, 429);
            this.ribbonBrowserCtrl1.TabIndex = 0;
            // 
            // RibbonBrowserDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 429);
            this.Controls.Add(this.ribbonBrowserCtrl1);
            this.Name = "RibbonBrowserDlg";
            this.Text = "RibbonBrowserDlg";
            this.ResumeLayout(false);

        }

        #endregion

        private RibbonBrowserCtrl ribbonBrowserCtrl1;
    }
}