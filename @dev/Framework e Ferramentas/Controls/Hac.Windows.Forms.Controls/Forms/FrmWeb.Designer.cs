namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeb));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panelHideMenu = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(984, 702);
            this.webBrowser.TabIndex = 0;
            // 
            // panelHideMenu
            // 
            this.panelHideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHideMenu.AutoSize = true;
            this.panelHideMenu.BackColor = System.Drawing.Color.White;
            this.panelHideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelHideMenu.Name = "panelHideMenu";
            this.panelHideMenu.Size = new System.Drawing.Size(984, 102);
            this.panelHideMenu.TabIndex = 1;
            this.panelHideMenu.Visible = false;
            // 
            // FrmWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 702);
            this.Controls.Add(this.panelHideMenu);
            this.Controls.Add(this.webBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmWeb";
            this.ShowIcon = false;
            this.Text = "SGS - Sistema de Gestão de Saúde";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        public System.Windows.Forms.Panel panelHideMenu;
    
    }
}