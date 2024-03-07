namespace Hac.Windows.Forms.Controls
{
    partial class HacProcedimentoProposto
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPesquisarProcedimentoProposto = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoProcedimentoProposto = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoProcedimentoProposto = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnPesquisarProcedimentoProposto
            // 
            this.btnPesquisarProcedimentoProposto.AlterarStatus = true;
            this.btnPesquisarProcedimentoProposto.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProcedimentoProposto.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarProcedimentoProposto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarProcedimentoProposto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarProcedimentoProposto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarProcedimentoProposto.FlatAppearance.BorderSize = 0;
            this.btnPesquisarProcedimentoProposto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProcedimentoProposto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProcedimentoProposto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarProcedimentoProposto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarProcedimentoProposto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarProcedimentoProposto.Location = new System.Drawing.Point(361, 1);
            this.btnPesquisarProcedimentoProposto.Name = "btnPesquisarProcedimentoProposto";
            this.btnPesquisarProcedimentoProposto.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarProcedimentoProposto.TabIndex = 2;
            this.btnPesquisarProcedimentoProposto.UseVisualStyleBackColor = false;
            this.btnPesquisarProcedimentoProposto.Click += new System.EventHandler(this.btnPesquisarProcedimentoProposto_Click);
            // 
            // txtDescricaoProcedimentoProposto
            // 
            this.txtDescricaoProcedimentoProposto.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoProcedimentoProposto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoProcedimentoProposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoProcedimentoProposto.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoProcedimentoProposto.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoProcedimentoProposto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoProcedimentoProposto.Limpar = true;
            this.txtDescricaoProcedimentoProposto.Location = new System.Drawing.Point(77, 3);
            this.txtDescricaoProcedimentoProposto.Name = "txtDescricaoProcedimentoProposto";
            this.txtDescricaoProcedimentoProposto.NaoAjustarEdicao = false;
            this.txtDescricaoProcedimentoProposto.Obrigatorio = false;
            this.txtDescricaoProcedimentoProposto.ObrigatorioMensagem = null;
            this.txtDescricaoProcedimentoProposto.PreValidacaoMensagem = null;
            this.txtDescricaoProcedimentoProposto.PreValidado = false;
            this.txtDescricaoProcedimentoProposto.SelectAllOnFocus = false;
            this.txtDescricaoProcedimentoProposto.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoProcedimentoProposto.TabIndex = 1;
            // 
            // txtCodigoProcedimentoProposto
            // 
            this.txtCodigoProcedimentoProposto.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoProcedimentoProposto.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoProcedimentoProposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoProcedimentoProposto.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoProcedimentoProposto.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoProcedimentoProposto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProcedimentoProposto.Limpar = true;
            this.txtCodigoProcedimentoProposto.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoProcedimentoProposto.MaxLength = 8;
            this.txtCodigoProcedimentoProposto.Name = "txtCodigoProcedimentoProposto";
            this.txtCodigoProcedimentoProposto.NaoAjustarEdicao = false;
            this.txtCodigoProcedimentoProposto.Obrigatorio = false;
            this.txtCodigoProcedimentoProposto.ObrigatorioMensagem = null;
            this.txtCodigoProcedimentoProposto.PreValidacaoMensagem = null;
            this.txtCodigoProcedimentoProposto.PreValidado = false;
            this.txtCodigoProcedimentoProposto.SelectAllOnFocus = false;
            this.txtCodigoProcedimentoProposto.Size = new System.Drawing.Size(71, 18);
            this.txtCodigoProcedimentoProposto.TabIndex = 0;
            this.txtCodigoProcedimentoProposto.Leave += new System.EventHandler(this.txtCodigoProcedimentoProposto_Leave);
            // 
            // HacProcedimentoProposto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarProcedimentoProposto);
            this.Controls.Add(this.txtDescricaoProcedimentoProposto);
            this.Controls.Add(this.txtCodigoProcedimentoProposto);
            this.Name = "HacProcedimentoProposto";
            this.Size = new System.Drawing.Size(385, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarProcedimentoProposto;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoProcedimentoProposto;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoProcedimentoProposto;
    }
}
