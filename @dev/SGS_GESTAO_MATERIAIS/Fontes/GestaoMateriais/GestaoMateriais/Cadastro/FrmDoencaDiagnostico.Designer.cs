namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmDoencaDiagnostico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoencaDiagnostico));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblDoDi = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbDoDi = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.btnExcluir = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtDoDi = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.cbSelecionar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(531, 28);
            this.tsHac.TabIndex = 124;
            this.tsHac.TituloTela = "";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // lblDoDi
            // 
            this.lblDoDi.AutoSize = true;
            this.lblDoDi.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDoDi.Location = new System.Drawing.Point(28, 40);
            this.lblDoDi.Name = "lblDoDi";
            this.lblDoDi.Size = new System.Drawing.Size(19, 13);
            this.lblDoDi.TabIndex = 125;
            this.lblDoDi.Text = "--";
            // 
            // cmbDoDi
            // 
            this.cmbDoDi.BackColor = System.Drawing.Color.Honeydew;
            this.cmbDoDi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoDi.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbDoDi.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbDoDi.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoDi.FormattingEnabled = true;
            this.cmbDoDi.Limpar = true;
            this.cmbDoDi.Location = new System.Drawing.Point(28, 57);
            this.cmbDoDi.Name = "cmbDoDi";
            this.cmbDoDi.Obrigatorio = false;
            this.cmbDoDi.ObrigatorioMensagem = null;
            this.cmbDoDi.PreValidacaoMensagem = null;
            this.cmbDoDi.PreValidado = false;
            this.cmbDoDi.Size = new System.Drawing.Size(449, 20);
            this.cmbDoDi.TabIndex = 187;
            this.cmbDoDi.SelectionChangeCommitted += new System.EventHandler(this.cmbDoDi_SelectionChangeCommitted);
            // 
            // btnExcluir
            // 
            this.btnExcluir.AlterarStatus = false;
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.BackgroundImage")));
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(407, 86);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(69, 22);
            this.btnExcluir.TabIndex = 194;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtDoDi
            // 
            this.txtDoDi.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDoDi.BackColor = System.Drawing.Color.Honeydew;
            this.txtDoDi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDoDi.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDoDi.Enabled = false;
            this.txtDoDi.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDoDi.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDoDi.Limpar = true;
            this.txtDoDi.Location = new System.Drawing.Point(28, 87);
            this.txtDoDi.MaxLength = 150;
            this.txtDoDi.Name = "txtDoDi";
            this.txtDoDi.NaoAjustarEdicao = false;
            this.txtDoDi.Obrigatorio = false;
            this.txtDoDi.ObrigatorioMensagem = null;
            this.txtDoDi.PreValidacaoMensagem = null;
            this.txtDoDi.PreValidado = false;
            this.txtDoDi.SelectAllOnFocus = false;
            this.txtDoDi.Size = new System.Drawing.Size(374, 21);
            this.txtDoDi.TabIndex = 193;
            // 
            // cbSelecionar
            // 
            this.cbSelecionar.AutoSize = true;
            this.cbSelecionar.Checked = true;
            this.cbSelecionar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSelecionar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbSelecionar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbSelecionar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelecionar.Limpar = false;
            this.cbSelecionar.Location = new System.Drawing.Point(30, 116);
            this.cbSelecionar.Name = "cbSelecionar";
            this.cbSelecionar.Obrigatorio = false;
            this.cbSelecionar.ObrigatorioMensagem = null;
            this.cbSelecionar.PreValidacaoMensagem = null;
            this.cbSelecionar.PreValidado = false;
            this.cbSelecionar.Size = new System.Drawing.Size(206, 17);
            this.cbSelecionar.TabIndex = 195;
            this.cbSelecionar.Text = "Selecionar novo item ao Salvar";
            this.cbSelecionar.UseVisualStyleBackColor = true;
            // 
            // FrmDoencaDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 149);
            this.Controls.Add(this.cbSelecionar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.txtDoDi);
            this.Controls.Add(this.cmbDoDi);
            this.Controls.Add(this.lblDoDi);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmDoencaDiagnostico";
            this.Text = "SGS  ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDoencaDiagnostico_FormClosing);
            this.Load += new System.EventHandler(this.FrmDoencaDiagnostico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel lblDoDi;
        private SGS.Componentes.HacComboBox cmbDoDi;
        private SGS.Componentes.HacButton btnExcluir;
        private SGS.Componentes.HacTextBox txtDoDi;
        private SGS.Componentes.HacCheckBox cbSelecionar;
    }
}