namespace Hac.Windows.Forms.Controls
{
    partial class HacProfissionalSolicitante
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
            this.btnPesquisarProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.cboUfConselhoProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.txtNomeProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.cboTipoConselhoProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.txtCodigoProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnPesquisarProfissionalSolicitante
            // 
            this.btnPesquisarProfissionalSolicitante.AlterarStatus = true;
            this.btnPesquisarProfissionalSolicitante.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalSolicitante.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarProfissionalSolicitante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarProfissionalSolicitante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.BorderSize = 0;
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalSolicitante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarProfissionalSolicitante.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarProfissionalSolicitante.Location = new System.Drawing.Point(471, 1);
            this.btnPesquisarProfissionalSolicitante.Name = "btnPesquisarProfissionalSolicitante";
            this.btnPesquisarProfissionalSolicitante.Size = new System.Drawing.Size(23, 20);
            this.btnPesquisarProfissionalSolicitante.TabIndex = 1;
            this.btnPesquisarProfissionalSolicitante.UseVisualStyleBackColor = false;
            this.btnPesquisarProfissionalSolicitante.Click += new System.EventHandler(this.btnPesquisarProfissionalSolicitante_Click);
            // 
            // cboUfConselhoProfissionalSolicitante
            // 
            this.cboUfConselhoProfissionalSolicitante.BackColor = System.Drawing.Color.Honeydew;
            this.cboUfConselhoProfissionalSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUfConselhoProfissionalSolicitante.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboUfConselhoProfissionalSolicitante.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboUfConselhoProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUfConselhoProfissionalSolicitante.FormattingEnabled = true;
            this.cboUfConselhoProfissionalSolicitante.Limpar = true;
            this.cboUfConselhoProfissionalSolicitante.Location = new System.Drawing.Point(82, 2);
            this.cboUfConselhoProfissionalSolicitante.Name = "cboUfConselhoProfissionalSolicitante";
            this.cboUfConselhoProfissionalSolicitante.Obrigatorio = true;
            this.cboUfConselhoProfissionalSolicitante.ObrigatorioMensagem = "UF Profissional Solicitante Obrigatório.";
            this.cboUfConselhoProfissionalSolicitante.PreValidacaoMensagem = null;
            this.cboUfConselhoProfissionalSolicitante.PreValidado = false;
            this.cboUfConselhoProfissionalSolicitante.Size = new System.Drawing.Size(45, 20);
            this.cboUfConselhoProfissionalSolicitante.TabIndex = 3;
            // 
            // txtNomeProfissionalSolicitante
            // 
            this.txtNomeProfissionalSolicitante.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeProfissionalSolicitante.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeProfissionalSolicitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProfissionalSolicitante.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtNomeProfissionalSolicitante.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProfissionalSolicitante.Limpar = true;
            this.txtNomeProfissionalSolicitante.Location = new System.Drawing.Point(205, 3);
            this.txtNomeProfissionalSolicitante.Name = "txtNomeProfissionalSolicitante";
            this.txtNomeProfissionalSolicitante.NaoAjustarEdicao = false;
            this.txtNomeProfissionalSolicitante.Obrigatorio = false;
            this.txtNomeProfissionalSolicitante.ObrigatorioMensagem = null;
            this.txtNomeProfissionalSolicitante.PreValidacaoMensagem = null;
            this.txtNomeProfissionalSolicitante.PreValidado = false;
            this.txtNomeProfissionalSolicitante.SelectAllOnFocus = false;
            this.txtNomeProfissionalSolicitante.Size = new System.Drawing.Size(260, 18);
            this.txtNomeProfissionalSolicitante.TabIndex = 4;
            // 
            // cboTipoConselhoProfissionalSolicitante
            // 
            this.cboTipoConselhoProfissionalSolicitante.BackColor = System.Drawing.Color.Honeydew;
            this.cboTipoConselhoProfissionalSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoConselhoProfissionalSolicitante.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboTipoConselhoProfissionalSolicitante.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboTipoConselhoProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoConselhoProfissionalSolicitante.FormattingEnabled = true;
            this.cboTipoConselhoProfissionalSolicitante.Limpar = true;
            this.cboTipoConselhoProfissionalSolicitante.Location = new System.Drawing.Point(1, 2);
            this.cboTipoConselhoProfissionalSolicitante.Name = "cboTipoConselhoProfissionalSolicitante";
            this.cboTipoConselhoProfissionalSolicitante.Obrigatorio = true;
            this.cboTipoConselhoProfissionalSolicitante.ObrigatorioMensagem = "CRM Profissional Solicitante Obrigatório.";
            this.cboTipoConselhoProfissionalSolicitante.PreValidacaoMensagem = null;
            this.cboTipoConselhoProfissionalSolicitante.PreValidado = false;
            this.cboTipoConselhoProfissionalSolicitante.Size = new System.Drawing.Size(75, 20);
            this.cboTipoConselhoProfissionalSolicitante.TabIndex = 2;
            // 
            // txtCodigoProfissionalSolicitante
            // 
            this.txtCodigoProfissionalSolicitante.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCodigoProfissionalSolicitante.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoProfissionalSolicitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoProfissionalSolicitante.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoProfissionalSolicitante.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProfissionalSolicitante.Limpar = true;
            this.txtCodigoProfissionalSolicitante.Location = new System.Drawing.Point(133, 3);
            this.txtCodigoProfissionalSolicitante.MaxLength = 15;
            this.txtCodigoProfissionalSolicitante.Name = "txtCodigoProfissionalSolicitante";
            this.txtCodigoProfissionalSolicitante.NaoAjustarEdicao = false;
            this.txtCodigoProfissionalSolicitante.Obrigatorio = true;
            this.txtCodigoProfissionalSolicitante.ObrigatorioMensagem = "Código Profissional Solicitante Obrigatório.";
            this.txtCodigoProfissionalSolicitante.PreValidacaoMensagem = null;
            this.txtCodigoProfissionalSolicitante.PreValidado = false;
            this.txtCodigoProfissionalSolicitante.SelectAllOnFocus = true;
            this.txtCodigoProfissionalSolicitante.Size = new System.Drawing.Size(66, 18);
            this.txtCodigoProfissionalSolicitante.TabIndex = 0;
            this.txtCodigoProfissionalSolicitante.Leave += new System.EventHandler(this.txtCodigoProfissionalSolicitante_Leave);
            // 
            // HacProfissionalSolicitante
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarProfissionalSolicitante);
            this.Controls.Add(this.cboUfConselhoProfissionalSolicitante);
            this.Controls.Add(this.txtNomeProfissionalSolicitante);
            this.Controls.Add(this.cboTipoConselhoProfissionalSolicitante);
            this.Controls.Add(this.txtCodigoProfissionalSolicitante);
            this.Name = "HacProfissionalSolicitante";
            this.Size = new System.Drawing.Size(497, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarProfissionalSolicitante;
        private Hac.Windows.Forms.Controls.HacComboBox cboUfConselhoProfissionalSolicitante;
        public Hac.Windows.Forms.Controls.HacTextBox txtNomeProfissionalSolicitante;
        private Hac.Windows.Forms.Controls.HacComboBox cboTipoConselhoProfissionalSolicitante;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoProfissionalSolicitante;


    }
}
