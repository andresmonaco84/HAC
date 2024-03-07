namespace Hac.Windows.Forms.Controls
{
    partial class HacConvenioProdutoEquivale
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
            this.btnPesquisarProcedimento = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoProcedimento = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoProcedimento = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnPesquisarProcedimento
            // 
            this.btnPesquisarProcedimento.AlterarStatus = true;
            this.btnPesquisarProcedimento.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProcedimento.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarProcedimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarProcedimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarProcedimento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarProcedimento.FlatAppearance.BorderSize = 0;
            this.btnPesquisarProcedimento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProcedimento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProcedimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarProcedimento.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarProcedimento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarProcedimento.Location = new System.Drawing.Point(361, 1);
            this.btnPesquisarProcedimento.Name = "btnPesquisarProcedimento";
            this.btnPesquisarProcedimento.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarProcedimento.TabIndex = 27;
            this.btnPesquisarProcedimento.UseVisualStyleBackColor = false;
            this.btnPesquisarProcedimento.Click += new System.EventHandler(this.btnPesquisarProcedimento_Click);
            // 
            // txtDescricaoProcedimento
            // 
            this.txtDescricaoProcedimento.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoProcedimento.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoProcedimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoProcedimento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoProcedimento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoProcedimento.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoProcedimento.Limpar = true;
            this.txtDescricaoProcedimento.Location = new System.Drawing.Point(77, 3);
            this.txtDescricaoProcedimento.Name = "txtDescricaoProcedimento";
            this.txtDescricaoProcedimento.NaoAjustarEdicao = false;
            this.txtDescricaoProcedimento.Obrigatorio = false;
            this.txtDescricaoProcedimento.ObrigatorioMensagem = null;
            this.txtDescricaoProcedimento.PreValidacaoMensagem = null;
            this.txtDescricaoProcedimento.PreValidado = false;
            this.txtDescricaoProcedimento.SelectAllOnFocus = false;
            this.txtDescricaoProcedimento.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoProcedimento.TabIndex = 26;
            // 
            // txtCodigoProcedimento
            // 
            this.txtCodigoProcedimento.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoProcedimento.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoProcedimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoProcedimento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoProcedimento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoProcedimento.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProcedimento.Limpar = true;
            this.txtCodigoProcedimento.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoProcedimento.MaxLength = 8;
            this.txtCodigoProcedimento.Name = "txtCodigoProcedimento";
            this.txtCodigoProcedimento.NaoAjustarEdicao = false;
            this.txtCodigoProcedimento.Obrigatorio = false;
            this.txtCodigoProcedimento.ObrigatorioMensagem = null;
            this.txtCodigoProcedimento.PreValidacaoMensagem = null;
            this.txtCodigoProcedimento.PreValidado = false;
            this.txtCodigoProcedimento.SelectAllOnFocus = false;
            this.txtCodigoProcedimento.Size = new System.Drawing.Size(71, 18);
            this.txtCodigoProcedimento.TabIndex = 25;
            this.txtCodigoProcedimento.Leave += new System.EventHandler(this.txtCodigoProcedimento_Leave);
            // 
            // HacProcedimento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarProcedimento);
            this.Controls.Add(this.txtDescricaoProcedimento);
            this.Controls.Add(this.txtCodigoProcedimento);
            this.Name = "HacProcedimento";
            this.Size = new System.Drawing.Size(385, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarProcedimento;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoProcedimento;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoProcedimento;
    }
}
