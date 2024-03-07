namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmPedidoEstoqueLocal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoEstoqueLocal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cbStatus = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtReqIdt = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtData = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.grbAddMatMed = new System.Windows.Forms.GroupBox();
            this.btnAdd = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtQtdReq = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbMatMed = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colReqItemIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDsUnidadeVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatMedPrincAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbTipo = new System.Windows.Forms.GroupBox();
            this.rbMed = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbMat = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cbUrgente = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnSugerir = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.chkAjudaAtualizarGrid = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbKit = new System.Windows.Forms.GroupBox();
            this.cmbKit = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.grbFilial.SuspendLayout();
            this.grbAddMatMed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.grbTipo.SuspendLayout();
            this.grbKit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(777, 28);
            this.tsHac.TabIndex = 83;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Pedido ao Estoque Local de Mat/Med";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = true;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(569, 35);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(194, 21);
            this.cmbSetor.TabIndex = 89;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(314, 35);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(195, 21);
            this.cmbLocal.TabIndex = 88;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 38);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 84;
            this.hacLabel1.Text = "Unidade";
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
            this.cmbUnidade.Location = new System.Drawing.Point(68, 35);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(189, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 87;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(272, 38);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 85;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(527, 38);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 86;
            this.hacLabel3.Text = "Setor";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cbStatus.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.Limpar = true;
            this.cbStatus.Location = new System.Drawing.Point(446, 105);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Obrigatorio = false;
            this.cbStatus.ObrigatorioMensagem = null;
            this.cbStatus.PreValidacaoMensagem = null;
            this.cbStatus.PreValidado = false;
            this.cbStatus.Size = new System.Drawing.Size(143, 17);
            this.cbStatus.TabIndex = 95;
            this.cbStatus.Text = "Enviar Solicitação";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Enabled = false;
            this.grbFilial.Location = new System.Drawing.Point(704, 58);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(59, 36);
            this.grbFilial.TabIndex = 94;
            this.grbFilial.TabStop = false;
            this.grbFilial.Visible = false;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbHac.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(6, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(50, 17);
            this.rbHac.TabIndex = 0;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "Data do Pedido";
            // 
            // txtReqIdt
            // 
            this.txtReqIdt.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtReqIdt.BackColor = System.Drawing.Color.Honeydew;
            this.txtReqIdt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReqIdt.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtReqIdt.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtReqIdt.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtReqIdt.Limpar = true;
            this.txtReqIdt.Location = new System.Drawing.Point(108, 101);
            this.txtReqIdt.Name = "txtReqIdt";
            this.txtReqIdt.NaoAjustarEdicao = false;
            this.txtReqIdt.Obrigatorio = false;
            this.txtReqIdt.ObrigatorioMensagem = null;
            this.txtReqIdt.PreValidacaoMensagem = null;
            this.txtReqIdt.PreValidado = false;
            this.txtReqIdt.ReadOnly = true;
            this.txtReqIdt.SelectAllOnFocus = false;
            this.txtReqIdt.Size = new System.Drawing.Size(100, 21);
            this.txtReqIdt.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 92;
            this.label5.Text = "Número Pedido";
            // 
            // txtData
            // 
            this.txtData.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtData.BackColor = System.Drawing.Color.Honeydew;
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtData.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtData.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtData.Limpar = true;
            this.txtData.Location = new System.Drawing.Point(323, 101);
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = true;
            this.txtData.Obrigatorio = false;
            this.txtData.ObrigatorioMensagem = null;
            this.txtData.PreValidacaoMensagem = null;
            this.txtData.PreValidado = false;
            this.txtData.ReadOnly = true;
            this.txtData.SelectAllOnFocus = false;
            this.txtData.Size = new System.Drawing.Size(108, 21);
            this.txtData.TabIndex = 91;
            // 
            // grbAddMatMed
            // 
            this.grbAddMatMed.Controls.Add(this.btnAdd);
            this.grbAddMatMed.Controls.Add(this.txtQtdReq);
            this.grbAddMatMed.Controls.Add(this.hacLabel9);
            this.grbAddMatMed.Controls.Add(this.hacLabel7);
            this.grbAddMatMed.Controls.Add(this.cmbMatMed);
            this.grbAddMatMed.Enabled = false;
            this.grbAddMatMed.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAddMatMed.Location = new System.Drawing.Point(5, 131);
            this.grbAddMatMed.Name = "grbAddMatMed";
            this.grbAddMatMed.Size = new System.Drawing.Size(758, 48);
            this.grbAddMatMed.TabIndex = 127;
            this.grbAddMatMed.TabStop = false;
            this.grbAddMatMed.Text = "Adicionar Mat/Med";
            // 
            // btnAdd
            // 
            this.btnAdd.AlterarStatus = true;
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(663, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 22);
            this.btnAdd.TabIndex = 127;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQtdReq
            // 
            this.txtQtdReq.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdReq.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdReq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdReq.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtQtdReq.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdReq.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdReq.Limpar = true;
            this.txtQtdReq.Location = new System.Drawing.Point(611, 20);
            this.txtQtdReq.MaxLength = 3;
            this.txtQtdReq.Name = "txtQtdReq";
            this.txtQtdReq.NaoAjustarEdicao = false;
            this.txtQtdReq.Obrigatorio = false;
            this.txtQtdReq.ObrigatorioMensagem = "";
            this.txtQtdReq.PreValidacaoMensagem = null;
            this.txtQtdReq.PreValidado = false;
            this.txtQtdReq.SelectAllOnFocus = false;
            this.txtQtdReq.Size = new System.Drawing.Size(35, 21);
            this.txtQtdReq.TabIndex = 126;
            this.txtQtdReq.TabStop = false;
            this.txtQtdReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(569, 24);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(38, 13);
            this.hacLabel9.TabIndex = 127;
            this.hacLabel9.Text = "Qtde.";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(6, 24);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(55, 13);
            this.hacLabel7.TabIndex = 126;
            this.hacLabel7.Text = "Mat/Med";
            // 
            // cmbMatMed
            // 
            this.cmbMatMed.BackColor = System.Drawing.Color.Honeydew;
            this.cmbMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbMatMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMatMed.FormattingEnabled = true;
            this.cmbMatMed.Limpar = true;
            this.cmbMatMed.Location = new System.Drawing.Point(63, 20);
            this.cmbMatMed.Name = "cmbMatMed";
            this.cmbMatMed.Obrigatorio = false;
            this.cmbMatMed.ObrigatorioMensagem = null;
            this.cmbMatMed.PreValidacaoMensagem = null;
            this.cmbMatMed.PreValidado = false;
            this.cmbMatMed.Size = new System.Drawing.Size(497, 21);
            this.cmbMatMed.TabIndex = 125;
            this.cmbMatMed.Text = "<Selecione>";
            this.cmbMatMed.DropDown += new System.EventHandler(this.cmbMatMed_DropDown);
            this.cmbMatMed.SelectionChangeCommitted += new System.EventHandler(this.cmbMatMed_SelectionChangeCommitted);
            this.cmbMatMed.Enter += new System.EventHandler(this.cmbMatMed_Enter);
            this.cmbMatMed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbMatMed_KeyUp);
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeColumns = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.AlterarStatus = false;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReqItemIdt,
            this.colDeletar,
            this.colDsProd,
            this.colMAV,
            this.colDsUnidadeVenda,
            this.colQtde,
            this.colMatMedIdt,
            this.colMatMedPrincAt});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle23;
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(5, 188);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(758, 356);
            this.dtgMatMed.TabIndex = 128;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            this.dtgMatMed.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgMatMed_CellValidating);
            this.dtgMatMed.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellValueChanged);
            // 
            // colReqItemIdt
            // 
            this.colReqItemIdt.HeaderText = "ReqItemIdt";
            this.colReqItemIdt.Name = "colReqItemIdt";
            this.colReqItemIdt.ReadOnly = true;
            this.colReqItemIdt.Visible = false;
            // 
            // colDeletar
            // 
            this.colDeletar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDeletar.HeaderText = "Excluir";
            this.colDeletar.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDeletar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeletar.ToolTipText = "Excluir Linha";
            this.colDeletar.Width = 45;
            // 
            // colDsProd
            // 
            this.colDsProd.HeaderText = "Descrição do Mat/Med";
            this.colDsProd.Name = "colDsProd";
            this.colDsProd.ReadOnly = true;
            this.colDsProd.Width = 400;
            // 
            // colMAV
            // 
            this.colMAV.FalseValue = "N";
            this.colMAV.HeaderText = "MAR";
            this.colMAV.Name = "colMAV";
            this.colMAV.ReadOnly = true;
            this.colMAV.TrueValue = "S";
            this.colMAV.Width = 35;
            // 
            // colDsUnidadeVenda
            // 
            this.colDsUnidadeVenda.HeaderText = "Unidade";
            this.colDsUnidadeVenda.Name = "colDsUnidadeVenda";
            this.colDsUnidadeVenda.ReadOnly = true;
            // 
            // colQtde
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N0";
            dataGridViewCellStyle22.NullValue = null;
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle22;
            this.colQtde.HeaderText = "Qtd. Pedido";
            this.colQtde.MaxInputLength = 3;
            this.colQtde.Name = "colQtde";
            // 
            // colMatMedIdt
            // 
            this.colMatMedIdt.HeaderText = "colMatMedIdt";
            this.colMatMedIdt.Name = "colMatMedIdt";
            this.colMatMedIdt.Visible = false;
            // 
            // colMatMedPrincAt
            // 
            this.colMatMedPrincAt.HeaderText = "colMatMedPrincAt";
            this.colMatMedPrincAt.Name = "colMatMedPrincAt";
            this.colMatMedPrincAt.Visible = false;
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(7, 547);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(355, 12);
            this.hacLabel8.TabIndex = 133;
            this.hacLabel8.Text = "* Para adicionar item fracionado, busque pelo botão superior Mat/Med";
            this.hacLabel8.Visible = false;
            // 
            // grbTipo
            // 
            this.grbTipo.Controls.Add(this.rbMed);
            this.grbTipo.Controls.Add(this.rbMat);
            this.grbTipo.Location = new System.Drawing.Point(11, 58);
            this.grbTipo.Name = "grbTipo";
            this.grbTipo.Size = new System.Drawing.Size(116, 36);
            this.grbTipo.TabIndex = 134;
            this.grbTipo.TabStop = false;
            // 
            // rbMed
            // 
            this.rbMed.AutoSize = true;
            this.rbMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbMed.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMed.Limpar = false;
            this.rbMed.Location = new System.Drawing.Point(60, 13);
            this.rbMed.Name = "rbMed";
            this.rbMed.Obrigatorio = false;
            this.rbMed.ObrigatorioMensagem = null;
            this.rbMed.PreValidacaoMensagem = null;
            this.rbMed.PreValidado = false;
            this.rbMed.Size = new System.Drawing.Size(52, 17);
            this.rbMed.TabIndex = 1;
            this.rbMed.Text = "MED";
            this.rbMed.UseVisualStyleBackColor = true;
            this.rbMed.Click += new System.EventHandler(this.rbMed_Click);
            // 
            // rbMat
            // 
            this.rbMat.AutoSize = true;
            this.rbMat.Checked = true;
            this.rbMat.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbMat.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbMat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMat.Limpar = false;
            this.rbMat.Location = new System.Drawing.Point(6, 13);
            this.rbMat.Name = "rbMat";
            this.rbMat.Obrigatorio = false;
            this.rbMat.ObrigatorioMensagem = null;
            this.rbMat.PreValidacaoMensagem = null;
            this.rbMat.PreValidado = false;
            this.rbMat.Size = new System.Drawing.Size(52, 17);
            this.rbMat.TabIndex = 0;
            this.rbMat.TabStop = true;
            this.rbMat.Text = "MAT";
            this.rbMat.UseVisualStyleBackColor = true;
            this.rbMat.Click += new System.EventHandler(this.rbMat_Click);
            // 
            // cbUrgente
            // 
            this.cbUrgente.AutoSize = true;
            this.cbUrgente.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cbUrgente.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbUrgente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUrgente.ForeColor = System.Drawing.Color.Red;
            this.cbUrgente.Limpar = true;
            this.cbUrgente.Location = new System.Drawing.Point(139, 72);
            this.cbUrgente.Name = "cbUrgente";
            this.cbUrgente.Obrigatorio = false;
            this.cbUrgente.ObrigatorioMensagem = null;
            this.cbUrgente.PreValidacaoMensagem = null;
            this.cbUrgente.PreValidado = false;
            this.cbUrgente.Size = new System.Drawing.Size(85, 17);
            this.cbUrgente.TabIndex = 96;
            this.cbUrgente.Text = "URGENTE";
            this.cbUrgente.UseVisualStyleBackColor = true;
            // 
            // btnSugerir
            // 
            this.btnSugerir.AlterarStatus = true;
            this.btnSugerir.BackColor = System.Drawing.Color.White;
            this.btnSugerir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSugerir.BackgroundImage")));
            this.btnSugerir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSugerir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSugerir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSugerir.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSugerir.Location = new System.Drawing.Point(230, 68);
            this.btnSugerir.Name = "btnSugerir";
            this.btnSugerir.Size = new System.Drawing.Size(137, 22);
            this.btnSugerir.TabIndex = 135;
            this.btnSugerir.Text = "SUGERIR PEDIDO";
            this.btnSugerir.UseVisualStyleBackColor = true;
            this.btnSugerir.Visible = false;
            this.btnSugerir.Click += new System.EventHandler(this.btnSugerir_Click);
            // 
            // chkAjudaAtualizarGrid
            // 
            this.chkAjudaAtualizarGrid.AutoSize = true;
            this.chkAjudaAtualizarGrid.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkAjudaAtualizarGrid.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkAjudaAtualizarGrid.Limpar = false;
            this.chkAjudaAtualizarGrid.Location = new System.Drawing.Point(762, 572);
            this.chkAjudaAtualizarGrid.Name = "chkAjudaAtualizarGrid";
            this.chkAjudaAtualizarGrid.Obrigatorio = false;
            this.chkAjudaAtualizarGrid.ObrigatorioMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidacaoMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidado = false;
            this.chkAjudaAtualizarGrid.Size = new System.Drawing.Size(15, 14);
            this.chkAjudaAtualizarGrid.TabIndex = 136;
            this.chkAjudaAtualizarGrid.UseVisualStyleBackColor = true;
            this.chkAjudaAtualizarGrid.Visible = false;
            // 
            // grbKit
            // 
            this.grbKit.Controls.Add(this.cmbKit);
            this.grbKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbKit.Location = new System.Drawing.Point(446, 58);
            this.grbKit.Name = "grbKit";
            this.grbKit.Size = new System.Drawing.Size(252, 36);
            this.grbKit.TabIndex = 137;
            this.grbKit.TabStop = false;
            this.grbKit.Text = "kit";
            this.grbKit.Visible = false;
            // 
            // cmbKit
            // 
            this.cmbKit.BackColor = System.Drawing.Color.Honeydew;
            this.cmbKit.DisplayMember = "CAD_MTMD_KIT_DSC";
            this.cmbKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKit.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbKit.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbKit.FormattingEnabled = true;
            this.cmbKit.Limpar = true;
            this.cmbKit.Location = new System.Drawing.Point(4, 13);
            this.cmbKit.MaxDropDownItems = 10;
            this.cmbKit.Name = "cmbKit";
            this.cmbKit.Obrigatorio = false;
            this.cmbKit.ObrigatorioMensagem = null;
            this.cmbKit.PreValidacaoMensagem = null;
            this.cmbKit.PreValidado = false;
            this.cmbKit.Size = new System.Drawing.Size(243, 21);
            this.cmbKit.TabIndex = 130;
            this.cmbKit.ValueMember = "CAD_MTMD_KIT_ID";
            this.cmbKit.SelectionChangeCommitted += new System.EventHandler(this.cmbKit_SelectionChangeCommitted);
            // 
            // FrmPedidoEstoqueLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 579);
            this.Controls.Add(this.grbKit);
            this.Controls.Add(this.chkAjudaAtualizarGrid);
            this.Controls.Add(this.btnSugerir);
            this.Controls.Add(this.cbUrgente);
            this.Controls.Add(this.grbTipo);
            this.Controls.Add(this.hacLabel8);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.grbAddMatMed);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReqIdt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmPedidoEstoqueLocal";
            this.Text = "FrmPedidoEstoqueLocal";
            this.Load += new System.EventHandler(this.FrmPedidoEstoqueLocal_Load);
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.grbAddMatMed.ResumeLayout(false);
            this.grbAddMatMed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.grbTipo.ResumeLayout(false);
            this.grbTipo.PerformLayout();
            this.grbKit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacCheckBox cbStatus;
        private System.Windows.Forms.GroupBox grbFilial;
        private SGS.Componentes.HacRadioButton rbHac;
        private System.Windows.Forms.Label label1;
        private SGS.Componentes.HacTextBox txtReqIdt;
        private System.Windows.Forms.Label label5;
        private SGS.Componentes.HacTextBox txtData;
        private System.Windows.Forms.GroupBox grbAddMatMed;
        private SGS.Componentes.HacButton btnAdd;
        private SGS.Componentes.HacTextBox txtQtdReq;
        private SGS.Componentes.HacLabel hacLabel9;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacComboBox cmbMatMed;
        private SGS.Componentes.HacDataGridView dtgMatMed;
        private SGS.Componentes.HacLabel hacLabel8;
        private System.Windows.Forms.GroupBox grbTipo;
        private SGS.Componentes.HacRadioButton rbMed;
        private SGS.Componentes.HacRadioButton rbMat;
        private SGS.Componentes.HacCheckBox cbUrgente;
        private SGS.Componentes.HacButton btnSugerir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqItemIdt;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidadeVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedPrincAt;
        private SGS.Componentes.HacCheckBox chkAjudaAtualizarGrid;
        private System.Windows.Forms.GroupBox grbKit;
        private SGS.Componentes.HacComboBox cmbKit;
    }
}