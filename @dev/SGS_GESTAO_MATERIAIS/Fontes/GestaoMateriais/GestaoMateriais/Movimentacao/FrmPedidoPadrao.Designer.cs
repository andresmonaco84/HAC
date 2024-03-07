namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmPedidoPadrao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel1.Controls.Add(this.hacLabel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 24);
            this.panel1.TabIndex = 66;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.ForeColor = System.Drawing.Color.ForestGreen;
            this.hacLabel7.Location = new System.Drawing.Point(6, 4);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(101, 13);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Pedido Padrão";
            // 
            // FrmPedidoPadrao
            // 
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPedidoPadrao";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel7;
    }
}
