namespace Hac.Windows.Forms.Controls
{
    partial class HacProfissionalCorpoClinico
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
            this.cboTipoConselhoProfissionalCorpoClinico = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.txtNomeProfissionalCorpoClinico = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoProfissionalCorpoClinico = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.cboUfConselhoProfissionalCorpoClinico = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.btnPesquisarProfissionalResponsavelAlta = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.SuspendLayout();
            // 
            // cboTipoConselhoProfissionalCorpoClinico
            // 
            this.cboTipoConselhoProfissionalCorpoClinico.BackColor = System.Drawing.Color.Honeydew;
            this.cboTipoConselhoProfissionalCorpoClinico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoConselhoProfissionalCorpoClinico.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboTipoConselhoProfissionalCorpoClinico.Enabled = false;
            this.cboTipoConselhoProfissionalCorpoClinico.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboTipoConselhoProfissionalCorpoClinico.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoConselhoProfissionalCorpoClinico.FormattingEnabled = true;
            this.cboTipoConselhoProfissionalCorpoClinico.Limpar = false;
            this.cboTipoConselhoProfissionalCorpoClinico.Location = new System.Drawing.Point(1, 2);
            this.cboTipoConselhoProfissionalCorpoClinico.Name = "cboTipoConselhoProfissionalCorpoClinico";
            this.cboTipoConselhoProfissionalCorpoClinico.Obrigatorio = false;
            this.cboTipoConselhoProfissionalCorpoClinico.ObrigatorioMensagem = null;
            this.cboTipoConselhoProfissionalCorpoClinico.PreValidacaoMensagem = null;
            this.cboTipoConselhoProfissionalCorpoClinico.PreValidado = false;
            this.cboTipoConselhoProfissionalCorpoClinico.Size = new System.Drawing.Size(75, 20);
            this.cboTipoConselhoProfissionalCorpoClinico.TabIndex = 2;
            // 
            // txtNomeProfissionalCorpoClinico
            // 
            this.txtNomeProfissionalCorpoClinico.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeProfissionalCorpoClinico.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeProfissionalCorpoClinico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProfissionalCorpoClinico.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNomeProfissionalCorpoClinico.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeProfissionalCorpoClinico.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProfissionalCorpoClinico.Limpar = true;
            this.txtNomeProfissionalCorpoClinico.Location = new System.Drawing.Point(205, 3);
            this.txtNomeProfissionalCorpoClinico.Name = "txtNomeProfissionalCorpoClinico";
            this.txtNomeProfissionalCorpoClinico.NaoAjustarEdicao = false;
            this.txtNomeProfissionalCorpoClinico.Obrigatorio = false;
            this.txtNomeProfissionalCorpoClinico.ObrigatorioMensagem = null;
            this.txtNomeProfissionalCorpoClinico.PreValidacaoMensagem = null;
            this.txtNomeProfissionalCorpoClinico.PreValidado = false;
            this.txtNomeProfissionalCorpoClinico.SelectAllOnFocus = false;
            this.txtNomeProfissionalCorpoClinico.Size = new System.Drawing.Size(260, 18);
            this.txtNomeProfissionalCorpoClinico.TabIndex = 4;
            // 
            // txtCodigoProfissionalCorpoClinico
            // 
            this.txtCodigoProfissionalCorpoClinico.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoProfissionalCorpoClinico.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoProfissionalCorpoClinico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoProfissionalCorpoClinico.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoProfissionalCorpoClinico.Enabled = false;
            this.txtCodigoProfissionalCorpoClinico.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoProfissionalCorpoClinico.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProfissionalCorpoClinico.Limpar = true;
            this.txtCodigoProfissionalCorpoClinico.Location = new System.Drawing.Point(133, 3);
            this.txtCodigoProfissionalCorpoClinico.MaxLength = 15;
            this.txtCodigoProfissionalCorpoClinico.Name = "txtCodigoProfissionalCorpoClinico";
            this.txtCodigoProfissionalCorpoClinico.NaoAjustarEdicao = false;
            this.txtCodigoProfissionalCorpoClinico.Obrigatorio = false;
            this.txtCodigoProfissionalCorpoClinico.ObrigatorioMensagem = null;
            this.txtCodigoProfissionalCorpoClinico.PreValidacaoMensagem = null;
            this.txtCodigoProfissionalCorpoClinico.PreValidado = false;
            this.txtCodigoProfissionalCorpoClinico.SelectAllOnFocus = false;
            this.txtCodigoProfissionalCorpoClinico.Size = new System.Drawing.Size(66, 18);
            this.txtCodigoProfissionalCorpoClinico.TabIndex = 0;
            this.txtCodigoProfissionalCorpoClinico.Leave += new System.EventHandler(this.txtCodigoProfissionalCorpoClinico_Leave);
            // 
            // cboUfConselhoProfissionalCorpoClinico
            // 
            this.cboUfConselhoProfissionalCorpoClinico.BackColor = System.Drawing.Color.Honeydew;
            this.cboUfConselhoProfissionalCorpoClinico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUfConselhoProfissionalCorpoClinico.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboUfConselhoProfissionalCorpoClinico.Enabled = false;
            this.cboUfConselhoProfissionalCorpoClinico.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboUfConselhoProfissionalCorpoClinico.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUfConselhoProfissionalCorpoClinico.FormattingEnabled = true;
            this.cboUfConselhoProfissionalCorpoClinico.Limpar = false;
            this.cboUfConselhoProfissionalCorpoClinico.Location = new System.Drawing.Point(82, 2);
            this.cboUfConselhoProfissionalCorpoClinico.Name = "cboUfConselhoProfissionalCorpoClinico";
            this.cboUfConselhoProfissionalCorpoClinico.Obrigatorio = false;
            this.cboUfConselhoProfissionalCorpoClinico.ObrigatorioMensagem = null;
            this.cboUfConselhoProfissionalCorpoClinico.PreValidacaoMensagem = null;
            this.cboUfConselhoProfissionalCorpoClinico.PreValidado = false;
            this.cboUfConselhoProfissionalCorpoClinico.Size = new System.Drawing.Size(45, 20);
            this.cboUfConselhoProfissionalCorpoClinico.TabIndex = 3;
            // 
            // btnPesquisarProfissionalResponsavelAlta
            // 
            this.btnPesquisarProfissionalResponsavelAlta.AlterarStatus = true;
            this.btnPesquisarProfissionalResponsavelAlta.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalResponsavelAlta.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarProfissionalResponsavelAlta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarProfissionalResponsavelAlta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarProfissionalResponsavelAlta.Enabled = false;
            this.btnPesquisarProfissionalResponsavelAlta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarProfissionalResponsavelAlta.FlatAppearance.BorderSize = 0;
            this.btnPesquisarProfissionalResponsavelAlta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalResponsavelAlta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalResponsavelAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarProfissionalResponsavelAlta.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarProfissionalResponsavelAlta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarProfissionalResponsavelAlta.Location = new System.Drawing.Point(471, 1);
            this.btnPesquisarProfissionalResponsavelAlta.Name = "btnPesquisarProfissionalResponsavelAlta";
            this.btnPesquisarProfissionalResponsavelAlta.Size = new System.Drawing.Size(23, 20);
            this.btnPesquisarProfissionalResponsavelAlta.TabIndex = 1;
            this.btnPesquisarProfissionalResponsavelAlta.UseVisualStyleBackColor = false;
            this.btnPesquisarProfissionalResponsavelAlta.Click += new System.EventHandler(this.btnPesquisarProfissionalCorpoClinico_Click);
            // 
            // HacProfissionalCorpoClinico
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.cboTipoConselhoProfissionalCorpoClinico);
            this.Controls.Add(this.btnPesquisarProfissionalResponsavelAlta);
            this.Controls.Add(this.txtNomeProfissionalCorpoClinico);
            this.Controls.Add(this.txtCodigoProfissionalCorpoClinico);
            this.Controls.Add(this.cboUfConselhoProfissionalCorpoClinico);
            this.Name = "HacProfissionalCorpoClinico";
            this.Size = new System.Drawing.Size(497, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacComboBox cboTipoConselhoProfissionalCorpoClinico;
        private Hac.Windows.Forms.Controls.HacButton btnPesquisarProfissionalResponsavelAlta;
        public Hac.Windows.Forms.Controls.HacTextBox txtNomeProfissionalCorpoClinico;
        private Hac.Windows.Forms.Controls.HacComboBox cboUfConselhoProfissionalCorpoClinico;
        public HacTextBox txtCodigoProfissionalCorpoClinico;
    }
}
