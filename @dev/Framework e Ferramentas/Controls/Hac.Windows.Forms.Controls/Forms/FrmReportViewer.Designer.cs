namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmReportViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportViewer));
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnSair = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.PesquisarVisivel = false;
            this.tspCommand.SalvarHabilitado = false;
            this.tspCommand.SalvarText = "Salvar";
            this.tspCommand.SalvarTextTamanho = 70;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(970, 28);
            this.tspCommand.TabIndex = 48;
            this.tspCommand.Text = "Geração Automática da Interface de Ambulatório e PS por período";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 604);
            this.panel1.TabIndex = 49;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.Size = new System.Drawing.Size(970, 604);
            this.reportViewer1.TabIndex = 2;
            // 
            // btnSair
            // 
            this.btnSair.AlterarStatus = true;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSair.BackgroundImage")));
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(862, 6);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(105, 22);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Visible = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FrmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(970, 632);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tspCommand);
            this.Name = "FrmReportViewer";
            this.Text = "FrmReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportViewer_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tspCommand;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private HacButton btnSair;


    }
}