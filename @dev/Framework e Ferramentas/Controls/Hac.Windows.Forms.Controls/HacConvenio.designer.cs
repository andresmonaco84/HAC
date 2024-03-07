namespace Hac.Windows.Forms.Controls
{
    partial class HacConvenio
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPesquisarConvenio = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnPesquisarConvenio
            // 
            this.btnPesquisarConvenio.AlterarStatus = true;
            this.btnPesquisarConvenio.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarConvenio.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarConvenio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarConvenio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarConvenio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarConvenio.FlatAppearance.BorderSize = 0;
            this.btnPesquisarConvenio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarConvenio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarConvenio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarConvenio.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarConvenio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarConvenio.Location = new System.Drawing.Point(336, 1);
            this.btnPesquisarConvenio.Name = "btnPesquisarConvenio";
            this.btnPesquisarConvenio.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarConvenio.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnPesquisarConvenio, "Pesquisar Convênio");
            this.btnPesquisarConvenio.UseVisualStyleBackColor = false;
            this.btnPesquisarConvenio.Click += new System.EventHandler(this.btnPesquisarConvenio_Click);
            // 
            // txtDescricaoConvenio
            // 
            this.txtDescricaoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtDescricaoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoConvenio.Limpar = true;
            this.txtDescricaoConvenio.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoConvenio.Name = "txtDescricaoConvenio";
            this.txtDescricaoConvenio.NaoAjustarEdicao = true;
            this.txtDescricaoConvenio.Obrigatorio = false;
            this.txtDescricaoConvenio.ObrigatorioMensagem = null;
            this.txtDescricaoConvenio.PreValidacaoMensagem = null;
            this.txtDescricaoConvenio.PreValidado = false;
            this.txtDescricaoConvenio.SelectAllOnFocus = false;
            this.txtDescricaoConvenio.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoConvenio.TabIndex = 1;
            // 
            // txtCodigoConvenio
            // 
            this.txtCodigoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoConvenio.Limpar = true;
            this.txtCodigoConvenio.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoConvenio.MaxLength = 5;
            this.txtCodigoConvenio.Name = "txtCodigoConvenio";
            this.txtCodigoConvenio.NaoAjustarEdicao = true;
            this.txtCodigoConvenio.Obrigatorio = false;
            this.txtCodigoConvenio.ObrigatorioMensagem = null;
            this.txtCodigoConvenio.PreValidacaoMensagem = null;
            this.txtCodigoConvenio.PreValidado = false;
            this.txtCodigoConvenio.SelectAllOnFocus = false;
            this.txtCodigoConvenio.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoConvenio.TabIndex = 0;
            this.txtCodigoConvenio.TextChanged += new System.EventHandler(this.txtCodigoConvenio_TextChanged);
            this.txtCodigoConvenio.Leave += new System.EventHandler(this.txtCodigoConvenio_Leave);
            // 
            // HacConvenio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarConvenio);
            this.Controls.Add(this.txtDescricaoConvenio);
            this.Controls.Add(this.txtCodigoConvenio);
            this.Name = "HacConvenio";
            this.Size = new System.Drawing.Size(360, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarConvenio;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoConvenio;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoConvenio;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
