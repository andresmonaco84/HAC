namespace Hac.Windows.Forms.Controls
{
    partial class FrmPesquisaBeneficiario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaBeneficiario));
            this.gbxConsultaBeneficiario = new System.Windows.Forms.GroupBox();
            this.txtDataNascimento = new Hac.Windows.Forms.Controls.HacMaskedTextBox(this.components);
            this.cboSexo = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.radServicoPrestado = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.radAcsFuncionarios = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.lblSexo = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.txtNome = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblDataNascimento = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblNome = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblPesquisa = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.grdBeneficiario = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.Convenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prontuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radTitular = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.radDependente = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.gbxConsultaBeneficiario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBeneficiario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxConsultaBeneficiario
            // 
            this.gbxConsultaBeneficiario.Controls.Add(this.txtDataNascimento);
            this.gbxConsultaBeneficiario.Controls.Add(this.cboSexo);
            this.gbxConsultaBeneficiario.Controls.Add(this.radServicoPrestado);
            this.gbxConsultaBeneficiario.Controls.Add(this.radAcsFuncionarios);
            this.gbxConsultaBeneficiario.Controls.Add(this.lblSexo);
            this.gbxConsultaBeneficiario.Controls.Add(this.txtNome);
            this.gbxConsultaBeneficiario.Controls.Add(this.lblDataNascimento);
            this.gbxConsultaBeneficiario.Controls.Add(this.lblNome);
            this.gbxConsultaBeneficiario.Controls.Add(this.lblPesquisa);
            this.gbxConsultaBeneficiario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxConsultaBeneficiario.Location = new System.Drawing.Point(9, 36);
            this.gbxConsultaBeneficiario.Name = "gbxConsultaBeneficiario";
            this.gbxConsultaBeneficiario.Size = new System.Drawing.Size(754, 109);
            this.gbxConsultaBeneficiario.TabIndex = 0;
            this.gbxConsultaBeneficiario.TabStop = false;
            this.gbxConsultaBeneficiario.Text = "PESQUISA DE BENEFICIÁRIOS";
            // 
            // txtDataNascimento
            // 
            this.txtDataNascimento.AcceptedFormatMasked = Hac.Windows.Forms.Controls.AcceptedFormatMasked.Data;
            this.txtDataNascimento.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataNascimento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtDataNascimento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDataNascimento.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtDataNascimento.Limpar = true;
            this.txtDataNascimento.Location = new System.Drawing.Point(133, 77);
            this.txtDataNascimento.Mask = "00/00/0000";
            this.txtDataNascimento.Name = "txtDataNascimento";
            this.txtDataNascimento.NaoAjustarEdicao = true;
            this.txtDataNascimento.Obrigatorio = false;
            this.txtDataNascimento.ObrigatorioMensagem = "";
            this.txtDataNascimento.PreValidacaoMensagem = "";
            this.txtDataNascimento.PreValidado = false;
            this.txtDataNascimento.SelectAllOnFocus = false;
            this.txtDataNascimento.Size = new System.Drawing.Size(72, 18);
            this.txtDataNascimento.TabIndex = 6;
            this.txtDataNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // cboSexo
            // 
            this.cboSexo.BackColor = System.Drawing.Color.Honeydew;
            this.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexo.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.cboSexo.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboSexo.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Limpar = true;
            this.cboSexo.Location = new System.Drawing.Point(315, 76);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Obrigatorio = false;
            this.cboSexo.ObrigatorioMensagem = "";
            this.cboSexo.PreValidacaoMensagem = null;
            this.cboSexo.PreValidado = false;
            this.cboSexo.Size = new System.Drawing.Size(121, 20);
            this.cboSexo.TabIndex = 8;
            // 
            // radServicoPrestado
            // 
            this.radServicoPrestado.AutoSize = true;
            this.radServicoPrestado.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.radServicoPrestado.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.radServicoPrestado.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radServicoPrestado.Limpar = false;
            this.radServicoPrestado.Location = new System.Drawing.Point(347, 22);
            this.radServicoPrestado.Name = "radServicoPrestado";
            this.radServicoPrestado.Obrigatorio = false;
            this.radServicoPrestado.ObrigatorioMensagem = null;
            this.radServicoPrestado.PreValidacaoMensagem = null;
            this.radServicoPrestado.PreValidado = false;
            this.radServicoPrestado.Size = new System.Drawing.Size(152, 18);
            this.radServicoPrestado.TabIndex = 2;
            this.radServicoPrestado.Text = "Serviço Prestado/PA";
            this.radServicoPrestado.UseVisualStyleBackColor = true;
            this.radServicoPrestado.CheckedChanged += new System.EventHandler(this.radServicoPrestado_CheckedChanged);
            // 
            // radAcsFuncionarios
            // 
            this.radAcsFuncionarios.AutoSize = true;
            this.radAcsFuncionarios.Checked = true;
            this.radAcsFuncionarios.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.radAcsFuncionarios.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.radAcsFuncionarios.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAcsFuncionarios.Limpar = false;
            this.radAcsFuncionarios.Location = new System.Drawing.Point(134, 22);
            this.radAcsFuncionarios.Name = "radAcsFuncionarios";
            this.radAcsFuncionarios.Obrigatorio = false;
            this.radAcsFuncionarios.ObrigatorioMensagem = null;
            this.radAcsFuncionarios.PreValidacaoMensagem = null;
            this.radAcsFuncionarios.PreValidado = false;
            this.radAcsFuncionarios.Size = new System.Drawing.Size(134, 18);
            this.radAcsFuncionarios.TabIndex = 1;
            this.radAcsFuncionarios.TabStop = true;
            this.radAcsFuncionarios.Text = "ACS/Funcionários";
            this.radAcsFuncionarios.UseVisualStyleBackColor = true;
            this.radAcsFuncionarios.CheckedChanged += new System.EventHandler(this.radAcsFuncionarios_CheckedChanged);
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSexo.Location = new System.Drawing.Point(264, 81);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(43, 14);
            this.lblSexo.TabIndex = 7;
            this.lblSexo.Text = "Sexo:";
            // 
            // txtNome
            // 
            this.txtNome.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNome.BackColor = System.Drawing.Color.Honeydew;
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNome.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNome.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Limpar = true;
            this.txtNome.Location = new System.Drawing.Point(133, 50);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.NaoAjustarEdicao = true;
            this.txtNome.Obrigatorio = false;
            this.txtNome.ObrigatorioMensagem = "";
            this.txtNome.PreValidacaoMensagem = null;
            this.txtNome.PreValidado = false;
            this.txtNome.SelectAllOnFocus = false;
            this.txtNome.Size = new System.Drawing.Size(364, 18);
            this.txtNome.TabIndex = 4;
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataNascimento.Location = new System.Drawing.Point(7, 81);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(119, 14);
            this.lblDataNascimento.TabIndex = 5;
            this.lblDataNascimento.Text = "Data Nascimento:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(7, 53);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(48, 14);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome:";
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisa.Location = new System.Drawing.Point(7, 24);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(94, 14);
            this.lblPesquisa.TabIndex = 0;
            this.lblPesquisa.Text = "Pesquisa por:";
            // 
            // grdBeneficiario
            // 
            this.grdBeneficiario.AllowUserToAddRows = false;
            this.grdBeneficiario.AllowUserToDeleteRows = false;
            this.grdBeneficiario.AllowUserToOrderColumns = true;
            this.grdBeneficiario.AllowUserToResizeColumns = false;
            this.grdBeneficiario.AllowUserToResizeRows = false;
            this.grdBeneficiario.AlterarStatus = false;
            this.grdBeneficiario.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBeneficiario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBeneficiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBeneficiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Convenio,
            this.Plano,
            this.Credencial,
            this.Prontuario,
            this.CPF,
            this.RG,
            this.Nome,
            this.EstadoCivil});
            this.grdBeneficiario.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.grdBeneficiario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdBeneficiario.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdBeneficiario.GridPesquisa = true;
            this.grdBeneficiario.Limpar = true;
            this.grdBeneficiario.Location = new System.Drawing.Point(9, 158);
            this.grdBeneficiario.MultiSelect = false;
            this.grdBeneficiario.Name = "grdBeneficiario";
            this.grdBeneficiario.NaoAjustarEdicao = true;
            this.grdBeneficiario.Obrigatorio = false;
            this.grdBeneficiario.ObrigatorioMensagem = null;
            this.grdBeneficiario.PreValidacaoMensagem = null;
            this.grdBeneficiario.PreValidado = false;
            this.grdBeneficiario.ReadOnly = true;
            this.grdBeneficiario.RowHeadersVisible = false;
            this.grdBeneficiario.RowHeadersWidth = 25;
            this.grdBeneficiario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBeneficiario.Size = new System.Drawing.Size(903, 295);
            this.grdBeneficiario.TabIndex = 12;
            this.grdBeneficiario.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdBeneficiario_CellMouseDoubleClick);
            // 
            // Convenio
            // 
            this.Convenio.DataPropertyName = "CODCON";
            this.Convenio.HeaderText = "Convênio";
            this.Convenio.Name = "Convenio";
            this.Convenio.ReadOnly = true;
            this.Convenio.Width = 75;
            // 
            // Plano
            // 
            this.Plano.DataPropertyName = "CODPLA";
            this.Plano.HeaderText = "Plano";
            this.Plano.Name = "Plano";
            this.Plano.ReadOnly = true;
            this.Plano.Width = 75;
            // 
            // Credencial
            // 
            this.Credencial.DataPropertyName = "CREDENCIAL";
            this.Credencial.HeaderText = "Credencial";
            this.Credencial.Name = "Credencial";
            this.Credencial.ReadOnly = true;
            this.Credencial.Width = 150;
            // 
            // Prontuario
            // 
            this.Prontuario.DataPropertyName = "CODPAC";
            this.Prontuario.HeaderText = "Prontuário";
            this.Prontuario.Name = "Prontuario";
            this.Prontuario.ReadOnly = true;
            this.Prontuario.Width = 90;
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "CPFBEN";
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            this.CPF.Width = 90;
            // 
            // RG
            // 
            this.RG.DataPropertyName = "RGBEN";
            this.RG.HeaderText = "RG";
            this.RG.Name = "RG";
            this.RG.ReadOnly = true;
            this.RG.Width = 90;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "NOMBEN";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 230;
            // 
            // EstadoCivil
            // 
            this.EstadoCivil.DataPropertyName = "ESTCIVBEN";
            this.EstadoCivil.HeaderText = "Estado Civil";
            this.EstadoCivil.Name = "EstadoCivil";
            this.EstadoCivil.ReadOnly = true;
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(922, 28);
            this.tspCommand.TabIndex = 13;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.BeforePesquisar += new Hac.Windows.Forms.Controls.AfterBeforeHacEventHandler(this.tspCommand_BeforePesquisar);
            this.tspCommand.PesquisarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_PesquisarClick);
            this.tspCommand.AfterLimpar += new Hac.Windows.Forms.Controls.AfterBeforeHacEventHandler(this.tspCommand_AfterLimpar);
            this.tspCommand.CancelarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_CancelarClick);
            this.tspCommand.LimparClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_LimparClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radTitular);
            this.groupBox1.Controls.Add(this.radDependente);
            this.groupBox1.Location = new System.Drawing.Point(774, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 109);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // radTitular
            // 
            this.radTitular.AutoSize = true;
            this.radTitular.Checked = true;
            this.radTitular.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.radTitular.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.radTitular.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitular.Limpar = false;
            this.radTitular.Location = new System.Drawing.Point(16, 30);
            this.radTitular.Name = "radTitular";
            this.radTitular.Obrigatorio = false;
            this.radTitular.ObrigatorioMensagem = null;
            this.radTitular.PreValidacaoMensagem = null;
            this.radTitular.PreValidado = false;
            this.radTitular.Size = new System.Drawing.Size(64, 18);
            this.radTitular.TabIndex = 12;
            this.radTitular.TabStop = true;
            this.radTitular.Text = "Titular";
            this.radTitular.UseVisualStyleBackColor = true;
            // 
            // radDependente
            // 
            this.radDependente.AutoSize = true;
            this.radDependente.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.radDependente.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.radDependente.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDependente.Limpar = false;
            this.radDependente.Location = new System.Drawing.Point(16, 63);
            this.radDependente.Name = "radDependente";
            this.radDependente.Obrigatorio = false;
            this.radDependente.ObrigatorioMensagem = null;
            this.radDependente.PreValidacaoMensagem = null;
            this.radDependente.PreValidado = false;
            this.radDependente.Size = new System.Drawing.Size(103, 18);
            this.radDependente.TabIndex = 11;
            this.radDependente.Text = "Dependente";
            this.radDependente.UseVisualStyleBackColor = true;
            // 
            // FrmPesquisaBeneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 463);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.grdBeneficiario);
            this.Controls.Add(this.gbxConsultaBeneficiario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaBeneficiario";
            this.ShowInTaskbar = false;
            this.Text = "Pesquisa de Beneficiários";
            this.Load += new System.EventHandler(this.FrmPesquisaBeneficiario_Load);
            this.gbxConsultaBeneficiario.ResumeLayout(false);
            this.gbxConsultaBeneficiario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBeneficiario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConsultaBeneficiario;
        //private System.Windows.Forms.DataGridView grdBeneficiario;
        private Hac.Windows.Forms.Controls.HacDataGridView grdBeneficiario;
        private Hac.Windows.Forms.Controls.HacLabel lblDataNascimento;
        private Hac.Windows.Forms.Controls.HacLabel lblNome;
        private Hac.Windows.Forms.Controls.HacLabel lblPesquisa;
        private Hac.Windows.Forms.Controls.HacLabel lblSexo;
        private Hac.Windows.Forms.Controls.HacTextBox txtNome;
        private Hac.Windows.Forms.Controls.HacRadioButton radAcsFuncionarios;
        private Hac.Windows.Forms.Controls.HacRadioButton radServicoPrestado;
        private Hac.Windows.Forms.Controls.HacComboBox cboSexo;
        private Hac.Windows.Forms.Controls.HacMaskedTextBox txtDataNascimento;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Convenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prontuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn RG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoCivil;
        private System.Windows.Forms.GroupBox groupBox1;
        private Hac.Windows.Forms.Controls.HacRadioButton radTitular;
        private Hac.Windows.Forms.Controls.HacRadioButton radDependente;
    }
}