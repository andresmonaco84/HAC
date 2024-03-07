namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmPrescricaoPesquisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrescricaoPesquisa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbPesquisa = new System.Windows.Forms.GroupBox();
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grmAutorizado = new System.Windows.Forms.GroupBox();
            this.rbAutoPend = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbTodas = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAutorizadoNao = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAutorizado = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.grbStatus = new System.Windows.Forms.GroupBox();
            this.rbInativas = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAtiva = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtDataIniConsumo = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDataLimite = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cbPendenteAVencer = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnPesquisaPac = new System.Windows.Forms.PictureBox();
            this.txtNomePac = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroInternacao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.dtgItem = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdPrescInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutorizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataLimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdPedidaHoje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdPendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeAuto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbUnidadeLocal = new System.Windows.Forms.GroupBox();
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.grbPesquisa.SuspendLayout();
            this.grmAutorizado.SuspendLayout();
            this.grbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).BeginInit();
            this.grbUnidadeLocal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(755, 28);
            this.tsHac.TabIndex = 84;
            this.tsHac.TituloTela = "Pesquisa Prescrição";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // grbPesquisa
            // 
            this.grbPesquisa.BackColor = System.Drawing.SystemColors.Control;
            this.grbPesquisa.Controls.Add(this.cmbSetor);
            this.grbPesquisa.Controls.Add(this.hacLabel3);
            this.grbPesquisa.Controls.Add(this.grmAutorizado);
            this.grbPesquisa.Controls.Add(this.grbStatus);
            this.grbPesquisa.Controls.Add(this.btnLimparProduto);
            this.grbPesquisa.Controls.Add(this.txtDataIniConsumo);
            this.grbPesquisa.Controls.Add(this.hacLabel2);
            this.grbPesquisa.Controls.Add(this.txtDataLimite);
            this.grbPesquisa.Controls.Add(this.hacLabel4);
            this.grbPesquisa.Controls.Add(this.cbPendenteAVencer);
            this.grbPesquisa.Controls.Add(this.lblProduto);
            this.grbPesquisa.Controls.Add(this.hacLabel1);
            this.grbPesquisa.Controls.Add(this.btnPesquisaPac);
            this.grbPesquisa.Controls.Add(this.txtNomePac);
            this.grbPesquisa.Controls.Add(this.label1);
            this.grbPesquisa.Controls.Add(this.label2);
            this.grbPesquisa.Controls.Add(this.txtNroInternacao);
            this.grbPesquisa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPesquisa.Location = new System.Drawing.Point(14, 28);
            this.grbPesquisa.Name = "grbPesquisa";
            this.grbPesquisa.Size = new System.Drawing.Size(731, 145);
            this.grbPesquisa.TabIndex = 156;
            this.grbPesquisa.TabStop = false;
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = false;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = true;
            this.cmbSetor.Location = new System.Drawing.Point(90, 73);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = "cmbLocal";
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(232, 21);
            this.cmbSetor.TabIndex = 199;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(42, 77);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 198;
            this.hacLabel3.Text = "Setor";
            // 
            // grmAutorizado
            // 
            this.grmAutorizado.Controls.Add(this.rbAutoPend);
            this.grmAutorizado.Controls.Add(this.rbTodas);
            this.grmAutorizado.Controls.Add(this.rbAutorizadoNao);
            this.grmAutorizado.Controls.Add(this.rbAutorizado);
            this.grmAutorizado.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grmAutorizado.Location = new System.Drawing.Point(520, 74);
            this.grmAutorizado.Name = "grmAutorizado";
            this.grmAutorizado.Size = new System.Drawing.Size(205, 65);
            this.grmAutorizado.TabIndex = 197;
            this.grmAutorizado.TabStop = false;
            this.grmAutorizado.Text = "AUTORIZAÇÃO";
            // 
            // rbAutoPend
            // 
            this.rbAutoPend.AutoSize = true;
            this.rbAutoPend.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAutoPend.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAutoPend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAutoPend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbAutoPend.Limpar = true;
            this.rbAutoPend.Location = new System.Drawing.Point(95, 18);
            this.rbAutoPend.Name = "rbAutoPend";
            this.rbAutoPend.Obrigatorio = false;
            this.rbAutoPend.ObrigatorioMensagem = null;
            this.rbAutoPend.PreValidacaoMensagem = null;
            this.rbAutoPend.PreValidado = false;
            this.rbAutoPend.Size = new System.Drawing.Size(91, 17);
            this.rbAutoPend.TabIndex = 160;
            this.rbAutoPend.Text = "PENDENTES";
            this.rbAutoPend.UseVisualStyleBackColor = true;
            this.rbAutoPend.Click += new System.EventHandler(this.rbAutoPend_Click);
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Checked = true;
            this.rbTodas.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbTodas.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodas.Limpar = true;
            this.rbTodas.Location = new System.Drawing.Point(17, 18);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Obrigatorio = false;
            this.rbTodas.ObrigatorioMensagem = "";
            this.rbTodas.PreValidacaoMensagem = null;
            this.rbTodas.PreValidado = true;
            this.rbTodas.Size = new System.Drawing.Size(63, 17);
            this.rbTodas.TabIndex = 121;
            this.rbTodas.TabStop = true;
            this.rbTodas.Text = "TODOS";
            this.rbTodas.UseVisualStyleBackColor = true;
            this.rbTodas.Click += new System.EventHandler(this.rbTodas_Click);
            // 
            // rbAutorizadoNao
            // 
            this.rbAutorizadoNao.AutoSize = true;
            this.rbAutorizadoNao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAutorizadoNao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAutorizadoNao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAutorizadoNao.Limpar = true;
            this.rbAutorizadoNao.Location = new System.Drawing.Point(95, 43);
            this.rbAutorizadoNao.Name = "rbAutorizadoNao";
            this.rbAutorizadoNao.Obrigatorio = false;
            this.rbAutorizadoNao.ObrigatorioMensagem = "";
            this.rbAutorizadoNao.PreValidacaoMensagem = null;
            this.rbAutorizadoNao.PreValidado = true;
            this.rbAutorizadoNao.Size = new System.Drawing.Size(48, 17);
            this.rbAutorizadoNao.TabIndex = 120;
            this.rbAutorizadoNao.Text = "NÃO";
            this.rbAutorizadoNao.UseVisualStyleBackColor = true;
            // 
            // rbAutorizado
            // 
            this.rbAutorizado.AutoSize = true;
            this.rbAutorizado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAutorizado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAutorizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAutorizado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbAutorizado.Limpar = true;
            this.rbAutorizado.Location = new System.Drawing.Point(17, 43);
            this.rbAutorizado.Name = "rbAutorizado";
            this.rbAutorizado.Obrigatorio = false;
            this.rbAutorizado.ObrigatorioMensagem = null;
            this.rbAutorizado.PreValidacaoMensagem = null;
            this.rbAutorizado.PreValidado = false;
            this.rbAutorizado.Size = new System.Drawing.Size(44, 17);
            this.rbAutorizado.TabIndex = 119;
            this.rbAutorizado.Text = "SIM";
            this.rbAutorizado.UseVisualStyleBackColor = true;
            // 
            // grbStatus
            // 
            this.grbStatus.Controls.Add(this.rbInativas);
            this.grbStatus.Controls.Add(this.rbAtiva);
            this.grbStatus.Location = new System.Drawing.Point(588, 38);
            this.grbStatus.Name = "grbStatus";
            this.grbStatus.Size = new System.Drawing.Size(137, 30);
            this.grbStatus.TabIndex = 156;
            this.grbStatus.TabStop = false;
            // 
            // rbInativas
            // 
            this.rbInativas.AutoSize = true;
            this.rbInativas.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbInativas.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbInativas.Limpar = false;
            this.rbInativas.Location = new System.Drawing.Point(65, 10);
            this.rbInativas.Name = "rbInativas";
            this.rbInativas.Obrigatorio = false;
            this.rbInativas.ObrigatorioMensagem = null;
            this.rbInativas.PreValidacaoMensagem = null;
            this.rbInativas.PreValidado = false;
            this.rbInativas.Size = new System.Drawing.Size(71, 17);
            this.rbInativas.TabIndex = 2;
            this.rbInativas.Text = "Inativas";
            this.rbInativas.UseVisualStyleBackColor = true;
            // 
            // rbAtiva
            // 
            this.rbAtiva.AutoSize = true;
            this.rbAtiva.Checked = true;
            this.rbAtiva.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAtiva.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAtiva.Limpar = false;
            this.rbAtiva.Location = new System.Drawing.Point(5, 10);
            this.rbAtiva.Name = "rbAtiva";
            this.rbAtiva.Obrigatorio = false;
            this.rbAtiva.ObrigatorioMensagem = null;
            this.rbAtiva.PreValidacaoMensagem = null;
            this.rbAtiva.PreValidado = false;
            this.rbAtiva.Size = new System.Drawing.Size(60, 17);
            this.rbAtiva.TabIndex = 1;
            this.rbAtiva.TabStop = true;
            this.rbAtiva.Text = "Ativas";
            this.rbAtiva.UseVisualStyleBackColor = true;
            // 
            // btnLimparProduto
            // 
            this.btnLimparProduto.AlterarStatus = true;
            this.btnLimparProduto.BackColor = System.Drawing.Color.White;
            this.btnLimparProduto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimparProduto.BackgroundImage")));
            this.btnLimparProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimparProduto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnLimparProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparProduto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnLimparProduto.Location = new System.Drawing.Point(478, 45);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 158;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Visible = false;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // txtDataIniConsumo
            // 
            this.txtDataIniConsumo.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataIniConsumo.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataIniConsumo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataIniConsumo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDataIniConsumo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDataIniConsumo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDataIniConsumo.Limpar = true;
            this.txtDataIniConsumo.Location = new System.Drawing.Point(157, 104);
            this.txtDataIniConsumo.MaxLength = 10;
            this.txtDataIniConsumo.Name = "txtDataIniConsumo";
            this.txtDataIniConsumo.NaoAjustarEdicao = true;
            this.txtDataIniConsumo.Obrigatorio = false;
            this.txtDataIniConsumo.ObrigatorioMensagem = "";
            this.txtDataIniConsumo.PreValidacaoMensagem = null;
            this.txtDataIniConsumo.PreValidado = false;
            this.txtDataIniConsumo.SelectAllOnFocus = false;
            this.txtDataIniConsumo.Size = new System.Drawing.Size(98, 21);
            this.txtDataIniConsumo.TabIndex = 157;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(6, 109);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(149, 13);
            this.hacLabel2.TabIndex = 156;
            this.hacLabel2.Text = "Data Início Consumo >=";
            // 
            // txtDataLimite
            // 
            this.txtDataLimite.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataLimite.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataLimite.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataLimite.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDataLimite.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDataLimite.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDataLimite.Limpar = true;
            this.txtDataLimite.Location = new System.Drawing.Point(410, 104);
            this.txtDataLimite.MaxLength = 10;
            this.txtDataLimite.Name = "txtDataLimite";
            this.txtDataLimite.NaoAjustarEdicao = true;
            this.txtDataLimite.Obrigatorio = false;
            this.txtDataLimite.ObrigatorioMensagem = "";
            this.txtDataLimite.PreValidacaoMensagem = null;
            this.txtDataLimite.PreValidado = false;
            this.txtDataLimite.SelectAllOnFocus = false;
            this.txtDataLimite.Size = new System.Drawing.Size(98, 21);
            this.txtDataLimite.TabIndex = 158;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(258, 109);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(152, 13);
            this.hacLabel4.TabIndex = 154;
            this.hacLabel4.Text = "Data Limite Consumo <=";
            // 
            // cbPendenteAVencer
            // 
            this.cbPendenteAVencer.AutoSize = true;
            this.cbPendenteAVencer.Checked = true;
            this.cbPendenteAVencer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPendenteAVencer.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbPendenteAVencer.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbPendenteAVencer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPendenteAVencer.Limpar = true;
            this.cbPendenteAVencer.Location = new System.Drawing.Point(338, 76);
            this.cbPendenteAVencer.Name = "cbPendenteAVencer";
            this.cbPendenteAVencer.Obrigatorio = false;
            this.cbPendenteAVencer.ObrigatorioMensagem = null;
            this.cbPendenteAVencer.PreValidacaoMensagem = null;
            this.cbPendenteAVencer.PreValidado = false;
            this.cbPendenteAVencer.Size = new System.Drawing.Size(165, 17);
            this.cbPendenteAVencer.TabIndex = 159;
            this.cbPendenteAVencer.Text = "PENDÊNCIAS A VENCER";
            this.cbPendenteAVencer.UseVisualStyleBackColor = true;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(92, 48);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 14);
            this.lblProduto.TabIndex = 141;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(36, 49);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(51, 13);
            this.hacLabel1.TabIndex = 140;
            this.hacLabel1.Text = "Produto";
            // 
            // btnPesquisaPac
            // 
            this.btnPesquisaPac.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.btnPesquisaPac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaPac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaPac.Location = new System.Drawing.Point(658, 16);
            this.btnPesquisaPac.Name = "btnPesquisaPac";
            this.btnPesquisaPac.Size = new System.Drawing.Size(40, 21);
            this.btnPesquisaPac.TabIndex = 90;
            this.btnPesquisaPac.TabStop = false;
            this.btnPesquisaPac.Click += new System.EventHandler(this.btnPesquisaPac_Click);
            // 
            // txtNomePac
            // 
            this.txtNomePac.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomePac.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomePac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomePac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNomePac.Enabled = false;
            this.txtNomePac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNomePac.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomePac.Limpar = true;
            this.txtNomePac.Location = new System.Drawing.Point(265, 17);
            this.txtNomePac.Name = "txtNomePac";
            this.txtNomePac.NaoAjustarEdicao = true;
            this.txtNomePac.Obrigatorio = false;
            this.txtNomePac.ObrigatorioMensagem = null;
            this.txtNomePac.PreValidacaoMensagem = null;
            this.txtNomePac.PreValidado = false;
            this.txtNomePac.SelectAllOnFocus = false;
            this.txtNomePac.Size = new System.Drawing.Size(387, 21);
            this.txtNomePac.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Atendimento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Paciente";
            // 
            // txtNroInternacao
            // 
            this.txtNroInternacao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtNroInternacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtNroInternacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroInternacao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNroInternacao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNroInternacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNroInternacao.Limpar = true;
            this.txtNroInternacao.Location = new System.Drawing.Point(92, 17);
            this.txtNroInternacao.MaxLength = 10;
            this.txtNroInternacao.Name = "txtNroInternacao";
            this.txtNroInternacao.NaoAjustarEdicao = true;
            this.txtNroInternacao.Obrigatorio = false;
            this.txtNroInternacao.ObrigatorioMensagem = null;
            this.txtNroInternacao.PreValidacaoMensagem = null;
            this.txtNroInternacao.PreValidado = false;
            this.txtNroInternacao.SelectAllOnFocus = false;
            this.txtNroInternacao.Size = new System.Drawing.Size(100, 21);
            this.txtNroInternacao.TabIndex = 87;
            this.txtNroInternacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroInternacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroInternacao_Validating);
            // 
            // dtgItem
            // 
            this.dtgItem.AllowUserToAddRows = false;
            this.dtgItem.AllowUserToDeleteRows = false;
            this.dtgItem.AllowUserToResizeColumns = false;
            this.dtgItem.AllowUserToResizeRows = false;
            this.dtgItem.AlterarStatus = false;
            this.dtgItem.BackgroundColor = System.Drawing.Color.White;
            this.dtgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSetor,
            this.colIdAtendimento,
            this.colPaciente,
            this.colIdPrescInt,
            this.colIdProduto,
            this.colProduto,
            this.colAutorizado,
            this.colDataLimite,
            this.colQtdeDia,
            this.colQtdPedidaHoje,
            this.colQtdPendente,
            this.colQtdDisp,
            this.colQtdeAuto,
            this.colDataInicio,
            this.colId,
            this.colCompleto});
            this.dtgItem.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItem.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItem.GridPesquisa = false;
            this.dtgItem.Limpar = true;
            this.dtgItem.Location = new System.Drawing.Point(14, 180);
            this.dtgItem.Name = "dtgItem";
            this.dtgItem.NaoAjustarEdicao = true;
            this.dtgItem.Obrigatorio = false;
            this.dtgItem.ObrigatorioMensagem = null;
            this.dtgItem.PreValidacaoMensagem = null;
            this.dtgItem.PreValidado = false;
            this.dtgItem.RowHeadersVisible = false;
            this.dtgItem.RowHeadersWidth = 25;
            this.dtgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItem.Size = new System.Drawing.Size(731, 420);
            this.dtgItem.TabIndex = 157;
            this.dtgItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItem_CellDoubleClick);
            // 
            // colSetor
            // 
            this.colSetor.HeaderText = "Setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.ReadOnly = true;
            this.colSetor.Width = 150;
            // 
            // colIdAtendimento
            // 
            this.colIdAtendimento.HeaderText = "Atendimento";
            this.colIdAtendimento.Name = "colIdAtendimento";
            this.colIdAtendimento.ReadOnly = true;
            this.colIdAtendimento.Width = 90;
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.ReadOnly = true;
            this.colPaciente.Width = 200;
            // 
            // colIdPrescInt
            // 
            this.colIdPrescInt.HeaderText = "Prescr. Int.";
            this.colIdPrescInt.Name = "colIdPrescInt";
            this.colIdPrescInt.ReadOnly = true;
            this.colIdPrescInt.Width = 75;
            // 
            // colIdProduto
            // 
            this.colIdProduto.HeaderText = "colIdProduto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.Visible = false;
            // 
            // colProduto
            // 
            this.colProduto.HeaderText = "Produto";
            this.colProduto.Name = "colProduto";
            this.colProduto.ReadOnly = true;
            this.colProduto.Width = 220;
            // 
            // colAutorizado
            // 
            this.colAutorizado.HeaderText = "Autorizado";
            this.colAutorizado.Name = "colAutorizado";
            this.colAutorizado.ReadOnly = true;
            this.colAutorizado.Width = 70;
            // 
            // colDataLimite
            // 
            this.colDataLimite.HeaderText = "Dta. Limite";
            this.colDataLimite.Name = "colDataLimite";
            this.colDataLimite.ReadOnly = true;
            this.colDataLimite.Width = 90;
            // 
            // colQtdeDia
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.colQtdeDia.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtdeDia.HeaderText = "Qtd. Diária Autor.";
            this.colQtdeDia.Name = "colQtdeDia";
            this.colQtdeDia.ReadOnly = true;
            this.colQtdeDia.Width = 80;
            // 
            // colQtdPedidaHoje
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.colQtdPedidaHoje.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQtdPedidaHoje.HeaderText = "Qtd. Solicitada Hoje";
            this.colQtdPedidaHoje.Name = "colQtdPedidaHoje";
            this.colQtdPedidaHoje.ReadOnly = true;
            this.colQtdPedidaHoje.Visible = false;
            this.colQtdPedidaHoje.Width = 80;
            // 
            // colQtdPendente
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.Format = "N0";
            this.colQtdPendente.DefaultCellStyle = dataGridViewCellStyle8;
            this.colQtdPendente.HeaderText = "Qtd. Pendente Envio";
            this.colQtdPendente.Name = "colQtdPendente";
            this.colQtdPendente.ReadOnly = true;
            this.colQtdPendente.Width = 80;
            // 
            // colQtdDisp
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.colQtdDisp.DefaultCellStyle = dataGridViewCellStyle9;
            this.colQtdDisp.HeaderText = "Qtd. Dispensada";
            this.colQtdDisp.Name = "colQtdDisp";
            this.colQtdDisp.ReadOnly = true;
            this.colQtdDisp.Width = 80;
            // 
            // colQtdeAuto
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.colQtdeAuto.DefaultCellStyle = dataGridViewCellStyle10;
            this.colQtdeAuto.HeaderText = "Qtd. Total Autor.";
            this.colQtdeAuto.Name = "colQtdeAuto";
            this.colQtdeAuto.ReadOnly = true;
            this.colQtdeAuto.Width = 80;
            // 
            // colDataInicio
            // 
            this.colDataInicio.HeaderText = "Dta. Início Consumo";
            this.colDataInicio.Name = "colDataInicio";
            this.colDataInicio.ReadOnly = true;
            this.colDataInicio.Width = 90;
            // 
            // colId
            // 
            this.colId.HeaderText = "Cd. Controle";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 75;
            // 
            // colCompleto
            // 
            this.colCompleto.DataPropertyName = "COMPLETO";
            this.colCompleto.HeaderText = "COMPLETO";
            this.colCompleto.Name = "colCompleto";
            this.colCompleto.ReadOnly = true;
            this.colCompleto.Visible = false;
            // 
            // grbUnidadeLocal
            // 
            this.grbUnidadeLocal.Controls.Add(this.cmbUnidade);
            this.grbUnidadeLocal.Controls.Add(this.hacLabel5);
            this.grbUnidadeLocal.Controls.Add(this.hacLabel6);
            this.grbUnidadeLocal.Controls.Add(this.cmbLocal);
            this.grbUnidadeLocal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbUnidadeLocal.Location = new System.Drawing.Point(352, 608);
            this.grbUnidadeLocal.Name = "grbUnidadeLocal";
            this.grbUnidadeLocal.Size = new System.Drawing.Size(254, 65);
            this.grbUnidadeLocal.TabIndex = 159;
            this.grbUnidadeLocal.TabStop = false;
            this.grbUnidadeLocal.Text = "Unidade/Local";
            this.grbUnidadeLocal.Visible = false;
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(62, 14);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = "cmbLocal";
            this.cmbUnidade.NomeComboSetor = "cmbSetor";
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(177, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 134;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(6, 18);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(53, 13);
            this.hacLabel5.TabIndex = 133;
            this.hacLabel5.Text = "Unidade";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(23, 45);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(36, 13);
            this.hacLabel6.TabIndex = 135;
            this.hacLabel6.Text = "Local";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(62, 41);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = "cmbSetor";
            this.cmbLocal.NomeComboUnidade = "cmbUnidade";
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(177, 21);
            this.cmbLocal.TabIndex = 136;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // FrmPrescricaoPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 607);
            this.Controls.Add(this.grbUnidadeLocal);
            this.Controls.Add(this.dtgItem);
            this.Controls.Add(this.grbPesquisa);
            this.Controls.Add(this.tsHac);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPrescricaoPesquisa";
            this.Text = "Pesquisa Prescrição";
            this.Load += new System.EventHandler(this.FrmPrescricaoPesquisa_Load);
            this.grbPesquisa.ResumeLayout(false);
            this.grbPesquisa.PerformLayout();
            this.grmAutorizado.ResumeLayout(false);
            this.grmAutorizado.PerformLayout();
            this.grbStatus.ResumeLayout(false);
            this.grbStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).EndInit();
            this.grbUnidadeLocal.ResumeLayout(false);
            this.grbUnidadeLocal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox grbPesquisa;
        private SGS.Componentes.HacLabel lblProduto;
        private SGS.Componentes.HacLabel hacLabel1;
        private System.Windows.Forms.PictureBox btnPesquisaPac;
        private SGS.Componentes.HacTextBox txtNomePac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SGS.Componentes.HacTextBox txtNroInternacao;
        private SGS.Componentes.HacDataGridView dtgItem;
        private SGS.Componentes.HacTextBox txtDataLimite;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacCheckBox cbPendenteAVencer;
        private SGS.Componentes.HacTextBox txtDataIniConsumo;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacButton btnLimparProduto;
        private SGS.Componentes.HacRadioButton rbAtiva;
        private System.Windows.Forms.GroupBox grbStatus;
        private SGS.Componentes.HacRadioButton rbInativas;
        private System.Windows.Forms.GroupBox grmAutorizado;
        private SGS.Componentes.HacRadioButton rbTodas;
        private SGS.Componentes.HacRadioButton rbAutorizadoNao;
        private SGS.Componentes.HacRadioButton rbAutorizado;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacLabel hacLabel3;
        private System.Windows.Forms.GroupBox grbUnidadeLocal;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacRadioButton rbAutoPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPrescInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutorizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdPedidaHoje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdPendente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompleto;
    }
}