using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmPedidoPadrao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoPadrao));
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.txtPeriodo = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercRessuprimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeFornecer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtRess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtAtu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsumido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercentual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatMedPrincAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnDispensar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDataDispensacao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.cbStatus = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.chkAjudaAtualizarGrid = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.txtDataUltReq = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblTotalLst = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblEstoqueUnificado = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbFilial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.SuspendLayout();
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(122, 109);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(31, 13);
            this.hacLabel5.TabIndex = 107;
            this.hacLabel5.Text = "Dias";
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbCE);
            this.grbFilial.Controls.Add(this.rbAcs);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(636, 63);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(144, 36);
            this.grbFilial.TabIndex = 100;
            this.grbFilial.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbCE.Limpar = false;
            this.rbCE.Location = new System.Drawing.Point(103, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = true;
            this.rbCE.ObrigatorioMensagem = "Escolha Um estoque HAC/ACS/CE";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 117;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.Click += new System.EventHandler(this.rbCE_Click);
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(55, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = true;
            this.rbAcs.ObrigatorioMensagem = "Escolha Um estoque HAC/ACS/CE";
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 3;
            this.rbAcs.TabStop = true;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Click += new System.EventHandler(this.rbAcs_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(6, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = true;
            this.rbHac.ObrigatorioMensagem = "Escolha Um estoque HAC/ACS/CE";
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 2;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtPeriodo.BackColor = System.Drawing.Color.Honeydew;
            this.txtPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeriodo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtPeriodo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtPeriodo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtPeriodo.Limpar = true;
            this.txtPeriodo.Location = new System.Drawing.Point(65, 105);
            this.txtPeriodo.MaxLength = 5;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.NaoAjustarEdicao = false;
            this.txtPeriodo.Obrigatorio = true;
            this.txtPeriodo.ObrigatorioMensagem = "Período de Dias deve estar Preenchido";
            this.txtPeriodo.PreValidacaoMensagem = null;
            this.txtPeriodo.PreValidado = false;
            this.txtPeriodo.SelectAllOnFocus = false;
            this.txtPeriodo.Size = new System.Drawing.Size(56, 21);
            this.txtPeriodo.TabIndex = 99;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(7, 109);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(50, 13);
            this.hacLabel4.TabIndex = 98;
            this.hacLabel4.Text = "Período";
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
            this.cmbSetor.Location = new System.Drawing.Point(561, 39);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 97;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.AlterarStatus = true;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeletar,
            this.colMatMedIdt,
            this.colDsProduto,
            this.colPercRessuprimento,
            this.colQtdePadrao,
            this.colQtdeEstoque,
            this.colQtdeFornecer,
            this.colDtRess,
            this.colDtAtu,
            this.colConsumido,
            this.colPercentual,
            this.colMatMedPrincAt});
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(6, 137);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.RowTemplate.Height = 18;
            this.dtgMatMed.Size = new System.Drawing.Size(780, 350);
            this.dtgMatMed.TabIndex = 91;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            this.dtgMatMed.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellEndEdit);
            this.dtgMatMed.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgMatMed_CellValidating);
            this.dtgMatMed.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellValueChanged);
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
            this.colDeletar.Width = 40;
            // 
            // colMatMedIdt
            // 
            this.colMatMedIdt.HeaderText = "colMatMedIdt";
            this.colMatMedIdt.Name = "colMatMedIdt";
            this.colMatMedIdt.Visible = false;
            // 
            // colDsProduto
            // 
            this.colDsProduto.HeaderText = "Descrição";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 300;
            // 
            // colPercRessuprimento
            // 
            this.colPercRessuprimento.HeaderText = "Ressup. %";
            this.colPercRessuprimento.MaxInputLength = 3;
            this.colPercRessuprimento.Name = "colPercRessuprimento";
            this.colPercRessuprimento.Width = 83;
            // 
            // colQtdePadrao
            // 
            this.colQtdePadrao.HeaderText = "Qtde Padrão";
            this.colQtdePadrao.MaxInputLength = 5;
            this.colQtdePadrao.Name = "colQtdePadrao";
            this.colQtdePadrao.Width = 90;
            // 
            // colQtdeEstoque
            // 
            this.colQtdeEstoque.HeaderText = "Est. Local";
            this.colQtdeEstoque.Name = "colQtdeEstoque";
            this.colQtdeEstoque.ReadOnly = true;
            this.colQtdeEstoque.Width = 78;
            // 
            // colQtdeFornecer
            // 
            this.colQtdeFornecer.HeaderText = "Qtd. Fornecer";
            this.colQtdeFornecer.Name = "colQtdeFornecer";
            this.colQtdeFornecer.ReadOnly = true;
            this.colQtdeFornecer.Visible = false;
            this.colQtdeFornecer.Width = 95;
            // 
            // colDtRess
            // 
            this.colDtRess.HeaderText = "Dt. Forn.";
            this.colDtRess.Name = "colDtRess";
            this.colDtRess.ReadOnly = true;
            this.colDtRess.Width = 75;
            // 
            // colDtAtu
            // 
            this.colDtAtu.HeaderText = "Atualizado";
            this.colDtAtu.Name = "colDtAtu";
            this.colDtAtu.ReadOnly = true;
            this.colDtAtu.Width = 70;
            // 
            // colConsumido
            // 
            this.colConsumido.HeaderText = "Consumido";
            this.colConsumido.Name = "colConsumido";
            this.colConsumido.ReadOnly = true;
            this.colConsumido.Visible = false;
            this.colConsumido.Width = 80;
            // 
            // colPercentual
            // 
            this.colPercentual.HeaderText = "Cons. %";
            this.colPercentual.Name = "colPercentual";
            this.colPercentual.ReadOnly = true;
            this.colPercentual.Visible = false;
            this.colPercentual.Width = 70;
            // 
            // colMatMedPrincAt
            // 
            this.colMatMedPrincAt.HeaderText = "colMatMedPrincAt";
            this.colMatMedPrincAt.Name = "colMatMedPrincAt";
            this.colMatMedPrincAt.ReadOnly = true;
            this.colMatMedPrincAt.Visible = false;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(517, 44);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 90;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(309, 40);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(190, 21);
            this.cmbLocal.TabIndex = 89;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(267, 44);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 88;
            this.hacLabel2.Text = "Local";
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
            this.cmbUnidade.Location = new System.Drawing.Point(65, 41);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(190, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 87;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 44);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 86;
            this.hacLabel1.Text = "Unidade";
            // 
            // btnDispensar
            // 
            this.btnDispensar.AlterarStatus = true;
            this.btnDispensar.BackColor = System.Drawing.Color.White;
            this.btnDispensar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDispensar.BackgroundImage")));
            this.btnDispensar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispensar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnDispensar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispensar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnDispensar.Location = new System.Drawing.Point(161, 104);
            this.btnDispensar.Name = "btnDispensar";
            this.btnDispensar.Size = new System.Drawing.Size(105, 22);
            this.btnDispensar.TabIndex = 109;
            this.btnDispensar.Text = "Dispensar";
            this.btnDispensar.UseVisualStyleBackColor = true;
            this.btnDispensar.Visible = false;
            this.btnDispensar.Click += new System.EventHandler(this.btnDispensar_Click);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(7, 78);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(116, 13);
            this.hacLabel6.TabIndex = 110;
            this.hacLabel6.Text = "Data Último Pedido";
            // 
            // txtDataDispensacao
            // 
            this.txtDataDispensacao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataDispensacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataDispensacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataDispensacao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDataDispensacao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDataDispensacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDataDispensacao.Limpar = true;
            this.txtDataDispensacao.Location = new System.Drawing.Point(448, 74);
            this.txtDataDispensacao.MaxLength = 10;
            this.txtDataDispensacao.Name = "txtDataDispensacao";
            this.txtDataDispensacao.NaoAjustarEdicao = true;
            this.txtDataDispensacao.Obrigatorio = false;
            this.txtDataDispensacao.ObrigatorioMensagem = null;
            this.txtDataDispensacao.PreValidacaoMensagem = null;
            this.txtDataDispensacao.PreValidado = false;
            this.txtDataDispensacao.ReadOnly = true;
            this.txtDataDispensacao.SelectAllOnFocus = false;
            this.txtDataDispensacao.Size = new System.Drawing.Size(165, 21);
            this.txtDataDispensacao.TabIndex = 111;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Checked = true;
            this.cbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStatus.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbStatus.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.Limpar = false;
            this.cbStatus.Location = new System.Drawing.Point(542, 108);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Obrigatorio = false;
            this.cbStatus.ObrigatorioMensagem = null;
            this.cbStatus.PreValidacaoMensagem = null;
            this.cbStatus.PreValidado = false;
            this.cbStatus.Size = new System.Drawing.Size(84, 17);
            this.cbStatus.TabIndex = 112;
            this.cbStatus.Text = "Confirmar";
            this.cbStatus.UseVisualStyleBackColor = true;
            this.cbStatus.Visible = false;
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
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 113;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Pedido Padrão";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // chkAjudaAtualizarGrid
            // 
            this.chkAjudaAtualizarGrid.AutoSize = true;
            this.chkAjudaAtualizarGrid.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkAjudaAtualizarGrid.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkAjudaAtualizarGrid.Limpar = false;
            this.chkAjudaAtualizarGrid.Location = new System.Drawing.Point(12, 575);
            this.chkAjudaAtualizarGrid.Name = "chkAjudaAtualizarGrid";
            this.chkAjudaAtualizarGrid.Obrigatorio = false;
            this.chkAjudaAtualizarGrid.ObrigatorioMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidacaoMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidado = false;
            this.chkAjudaAtualizarGrid.Size = new System.Drawing.Size(15, 14);
            this.chkAjudaAtualizarGrid.TabIndex = 114;
            this.chkAjudaAtualizarGrid.UseVisualStyleBackColor = true;
            this.chkAjudaAtualizarGrid.Visible = false;
            // 
            // txtDataUltReq
            // 
            this.txtDataUltReq.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataUltReq.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataUltReq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataUltReq.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDataUltReq.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDataUltReq.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDataUltReq.Limpar = true;
            this.txtDataUltReq.Location = new System.Drawing.Point(124, 74);
            this.txtDataUltReq.MaxLength = 10;
            this.txtDataUltReq.Name = "txtDataUltReq";
            this.txtDataUltReq.NaoAjustarEdicao = true;
            this.txtDataUltReq.Obrigatorio = false;
            this.txtDataUltReq.ObrigatorioMensagem = null;
            this.txtDataUltReq.PreValidacaoMensagem = null;
            this.txtDataUltReq.PreValidado = false;
            this.txtDataUltReq.ReadOnly = true;
            this.txtDataUltReq.SelectAllOnFocus = false;
            this.txtDataUltReq.Size = new System.Drawing.Size(165, 21);
            this.txtDataUltReq.TabIndex = 116;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(297, 77);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(150, 13);
            this.hacLabel7.TabIndex = 115;
            this.hacLabel7.Text = "Data Última Dispensação";
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(12, 503);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(123, 13);
            this.hacLabel8.TabIndex = 117;
            this.hacLabel8.Text = "Total Itens Listados:";
            // 
            // lblTotalLst
            // 
            this.lblTotalLst.AutoSize = true;
            this.lblTotalLst.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTotalLst.Location = new System.Drawing.Point(141, 503);
            this.lblTotalLst.Name = "lblTotalLst";
            this.lblTotalLst.Size = new System.Drawing.Size(0, 13);
            this.lblTotalLst.TabIndex = 118;
            // 
            // lblEstoqueUnificado
            // 
            this.lblEstoqueUnificado.AutoSize = true;
            this.lblEstoqueUnificado.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEstoqueUnificado.ForeColor = System.Drawing.Color.Green;
            this.lblEstoqueUnificado.Location = new System.Drawing.Point(640, 111);
            this.lblEstoqueUnificado.Name = "lblEstoqueUnificado";
            this.lblEstoqueUnificado.Size = new System.Drawing.Size(0, 12);
            this.lblEstoqueUnificado.TabIndex = 162;
            this.lblEstoqueUnificado.Visible = false;
            // 
            // FrmPedidoPadrao
            // 
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.Controls.Add(this.lblEstoqueUnificado);
            this.Controls.Add(this.lblTotalLst);
            this.Controls.Add(this.hacLabel8);
            this.Controls.Add(this.txtDataUltReq);
            this.Controls.Add(this.hacLabel7);
            this.Controls.Add(this.chkAjudaAtualizarGrid);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.txtDataDispensacao);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.btnDispensar);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.cbStatus);
            this.Name = "FrmPedidoPadrao";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPedidoPadrao_FormClosing);
            this.Load += new System.EventHandler(this.FrmPedidoPadrao_Load);
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacCmbSetor cmbSetor;
        private HacDataGridView dtgMatMed;
        private HacLabel hacLabel3;
        private HacCmbLocal cmbLocal;
        private HacLabel hacLabel2;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel1;
        private HacLabel hacLabel4;
        private HacTextBox txtPeriodo;
        private System.Windows.Forms.GroupBox grbFilial;
        private HacLabel hacLabel5;
        private HacRadioButton rbHac;
        private HacRadioButton rbAcs;
        private HacButton btnDispensar;
        private HacLabel hacLabel6;
        private HacTextBox txtDataDispensacao;
        private HacCheckBox cbStatus;
        private HacToolStrip tsHac;
        private HacCheckBox chkAjudaAtualizarGrid;
        private HacTextBox txtDataUltReq;
        private HacLabel hacLabel7;
        private HacRadioButton rbCE;
        private HacLabel hacLabel8;
        private HacLabel lblTotalLst;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercRessuprimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdePadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeFornecer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtRess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtAtu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsumido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercentual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedPrincAt;
        private HacLabel lblEstoqueUnificado;
    }
}
