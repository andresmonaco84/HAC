using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmVersao
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
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblVersao = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblIp = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblEndereco = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.SuspendLayout();
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(25, 9);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(47, 13);
            this.hacLabel1.TabIndex = 0;
            this.hacLabel1.Text = "Versão";
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblVersao.Location = new System.Drawing.Point(78, 8);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(52, 14);
            this.lblVersao.TabIndex = 1;
            this.lblVersao.Text = "versão";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblIp.Location = new System.Drawing.Point(12, 28);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(60, 13);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "Endereço";
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndereco.ForeColor = System.Drawing.Color.Red;
            this.lblEndereco.Location = new System.Drawing.Point(78, 27);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(74, 16);
            this.lblEndereco.TabIndex = 3;
            this.lblEndereco.Text = "hacLabel2";
            // 
            // FrmVersao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(292, 74);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.hacLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVersao";
            this.ShowInTaskbar = false;
            this.Text = "GestaoSuprimentos";
            this.Load += new System.EventHandler(this.FrmVersao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacLabel hacLabel1;
        private HacLabel lblVersao;
        private HacLabel lblIp;
        private HacLabel lblEndereco;
    }
}