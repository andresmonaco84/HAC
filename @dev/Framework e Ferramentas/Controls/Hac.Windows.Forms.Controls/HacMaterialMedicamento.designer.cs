namespace Hac.Windows.Forms.Controls
{
    partial class HacMaterialMedicamento
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
            this.btnPesquisarProduto = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoProduto = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoProduto = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.AlterarStatus = true;
            this.btnPesquisarProduto.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProduto.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarProduto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarProduto.FlatAppearance.BorderSize = 0;
            this.btnPesquisarProduto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProduto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarProduto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarProduto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarProduto.Location = new System.Drawing.Point(361, 1);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarProduto.TabIndex = 27;
            this.btnPesquisarProduto.UseVisualStyleBackColor = false;
            this.btnPesquisarProduto.Click += new System.EventHandler(this.btnPesquisarProduto_Click);
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoProduto.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtDescricaoProduto.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Desabilitado;
            this.txtDescricaoProduto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoProduto.Limpar = false;
            this.txtDescricaoProduto.Location = new System.Drawing.Point(77, 3);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.NaoAjustarEdicao = false;
            this.txtDescricaoProduto.Obrigatorio = false;
            this.txtDescricaoProduto.ObrigatorioMensagem = null;
            this.txtDescricaoProduto.PreValidacaoMensagem = null;
            this.txtDescricaoProduto.PreValidado = false;
            this.txtDescricaoProduto.SelectAllOnFocus = false;
            this.txtDescricaoProduto.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoProduto.TabIndex = 26;
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoProduto.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtCodigoProduto.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Desabilitado;
            this.txtCodigoProduto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProduto.Limpar = false;
            this.txtCodigoProduto.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.NaoAjustarEdicao = false;
            this.txtCodigoProduto.Obrigatorio = false;
            this.txtCodigoProduto.ObrigatorioMensagem = null;
            this.txtCodigoProduto.PreValidacaoMensagem = null;
            this.txtCodigoProduto.PreValidado = false;
            this.txtCodigoProduto.SelectAllOnFocus = false;
            this.txtCodigoProduto.Size = new System.Drawing.Size(71, 18);
            this.txtCodigoProduto.TabIndex = 25;
            this.txtCodigoProduto.Leave += new System.EventHandler(this.txtCodigoProduto_Leave);
            // 
            // HacProdutoMaterialMedicamento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarProduto);
            this.Controls.Add(this.txtDescricaoProduto);
            this.Controls.Add(this.txtCodigoProduto);
            this.Name = "HacProdutoMaterialMedicamento";
            this.Size = new System.Drawing.Size(385, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarProduto;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoProduto;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoProduto;
    }
}
