using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmLancamentoOutraUnidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLancamentoOutraUnidade));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkAjudaAtualizarGrid = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocalEstoque = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPesqMov = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtDtMov = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgHistoricoCCusto = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.ColDelHist = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMovId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoteFab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQtdeHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.lblEstoqueUnificado = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtCodProd = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblCodProd = new System.Windows.Forms.Label();
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAVMov = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistoricoCCusto)).BeginInit();
            this.grbFilial.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAjudaAtualizarGrid
            // 
            this.chkAjudaAtualizarGrid.AutoSize = true;
            this.chkAjudaAtualizarGrid.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkAjudaAtualizarGrid.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkAjudaAtualizarGrid.Limpar = false;
            this.chkAjudaAtualizarGrid.Location = new System.Drawing.Point(15, 573);
            this.chkAjudaAtualizarGrid.Name = "chkAjudaAtualizarGrid";
            this.chkAjudaAtualizarGrid.Obrigatorio = false;
            this.chkAjudaAtualizarGrid.ObrigatorioMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidacaoMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidado = false;
            this.chkAjudaAtualizarGrid.Size = new System.Drawing.Size(15, 14);
            this.chkAjudaAtualizarGrid.TabIndex = 133;
            this.chkAjudaAtualizarGrid.UseVisualStyleBackColor = true;
            this.chkAjudaAtualizarGrid.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "Excluir";
            this.dataGridViewImageColumn1.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.ToolTipText = "Excluir Linha";
            this.dataGridViewImageColumn1.Width = 40;
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
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 132;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Consumo de Itens Diversos";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(8, 43);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(59, 13);
            this.hacLabel6.TabIndex = 135;
            this.hacLabel6.Text = "Estoque";
            // 
            // cmbLocalEstoque
            // 
            this.cmbLocalEstoque.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocalEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocalEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbLocalEstoque.FormattingEnabled = true;
            this.cmbLocalEstoque.Limpar = false;
            this.cmbLocalEstoque.Location = new System.Drawing.Point(81, 39);
            this.cmbLocalEstoque.Name = "cmbLocalEstoque";
            this.cmbLocalEstoque.Obrigatorio = true;
            this.cmbLocalEstoque.ObrigatorioMensagem = "Selecione a Origem";
            this.cmbLocalEstoque.PreValidacaoMensagem = null;
            this.cmbLocalEstoque.PreValidado = false;
            this.cmbLocalEstoque.Size = new System.Drawing.Size(491, 21);
            this.cmbLocalEstoque.TabIndex = 134;
            this.cmbLocalEstoque.Text = "<Selecione>";
            this.cmbLocalEstoque.SelectionChangeCommitted += new System.EventHandler(this.cmbTiposCCusto_SelectionChangeCommitted);
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = true;
            this.cmbSetor.Location = new System.Drawing.Point(615, 73);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Selecione um Setor";
            this.cmbSetor.PreValidacaoMensagem = "";
            this.cmbSetor.PreValidado = false;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(170, 21);
            this.cmbSetor.TabIndex = 141;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(370, 74);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Selecione um Local";
            this.cmbLocal.PreValidacaoMensagem = "";
            this.cmbLocal.PreValidado = false;
            this.cmbLocal.Size = new System.Drawing.Size(170, 21);
            this.cmbLocal.TabIndex = 140;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbUnidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = true;
            this.cmbUnidade.Location = new System.Drawing.Point(137, 73);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Selecione uma Unidade";
            this.cmbUnidade.PreValidacaoMensagem = "";
            this.cmbUnidade.PreValidado = false;
            this.cmbUnidade.Size = new System.Drawing.Size(170, 21);
            this.cmbUnidade.SomenteAtiva = true;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 139;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.UnidadeUsuario = true;
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(570, 77);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 138;
            this.hacLabel3.Text = "Setor";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(328, 77);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 137;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(78, 77);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 136;
            this.hacLabel1.Text = "Unidade";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(8, 77);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(57, 13);
            this.hacLabel4.TabIndex = 142;
            this.hacLabel4.Text = "C. Custo";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 372);
            this.tabControl1.TabIndex = 158;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgMatMed);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(784, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Movimentação";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeColumns = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.AlterarStatus = true;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeletar,
            this.colMatMedIdt,
            this.colDsProduto,
            this.colMAVMov,
            this.colQtde});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMatMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(3, 3);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.RowTemplate.Height = 18;
            this.dtgMatMed.Size = new System.Drawing.Size(778, 340);
            this.dtgMatMed.TabIndex = 123;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPesqMov);
            this.tabPage2.Controls.Add(this.txtDtMov);
            this.tabPage2.Controls.Add(this.hacLabel11);
            this.tabPage2.Controls.Add(this.dtgHistoricoCCusto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(784, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Histórico C. Custo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPesqMov
            // 
            this.btnPesqMov.AlterarStatus = true;
            this.btnPesqMov.BackColor = System.Drawing.Color.White;
            this.btnPesqMov.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesqMov.BackgroundImage")));
            this.btnPesqMov.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesqMov.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesqMov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesqMov.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesqMov.Location = new System.Drawing.Point(220, 7);
            this.btnPesqMov.Name = "btnPesqMov";
            this.btnPesqMov.Size = new System.Drawing.Size(105, 22);
            this.btnPesqMov.TabIndex = 3;
            this.btnPesqMov.Text = "Pesquisar";
            this.btnPesqMov.UseVisualStyleBackColor = true;
            this.btnPesqMov.Click += new System.EventHandler(this.btnPesqMov_Click);
            // 
            // txtDtMov
            // 
            this.txtDtMov.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtMov.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtMov.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDtMov.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtMov.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtMov.Limpar = true;
            this.txtDtMov.Location = new System.Drawing.Point(114, 8);
            this.txtDtMov.MaxLength = 10;
            this.txtDtMov.Name = "txtDtMov";
            this.txtDtMov.NaoAjustarEdicao = false;
            this.txtDtMov.Obrigatorio = false;
            this.txtDtMov.ObrigatorioMensagem = "";
            this.txtDtMov.PreValidacaoMensagem = "";
            this.txtDtMov.PreValidado = false;
            this.txtDtMov.SelectAllOnFocus = false;
            this.txtDtMov.Size = new System.Drawing.Size(100, 21);
            this.txtDtMov.TabIndex = 2;
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(8, 11);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(100, 13);
            this.hacLabel11.TabIndex = 1;
            this.hacLabel11.Text = "Data Movimento";
            // 
            // dtgHistoricoCCusto
            // 
            this.dtgHistoricoCCusto.AllowUserToAddRows = false;
            this.dtgHistoricoCCusto.AllowUserToDeleteRows = false;
            this.dtgHistoricoCCusto.AllowUserToResizeColumns = false;
            this.dtgHistoricoCCusto.AllowUserToResizeRows = false;
            this.dtgHistoricoCCusto.AlterarStatus = true;
            this.dtgHistoricoCCusto.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistoricoCCusto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgHistoricoCCusto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistoricoCCusto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDelHist,
            this.colMovId,
            this.colDtMov,
            this.colDsProdutoHist,
            this.colLoteFab,
            this.colMAV,
            this.colQtdeHist});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHistoricoCCusto.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgHistoricoCCusto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgHistoricoCCusto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgHistoricoCCusto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgHistoricoCCusto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgHistoricoCCusto.GridPesquisa = false;
            this.dtgHistoricoCCusto.Limpar = true;
            this.dtgHistoricoCCusto.Location = new System.Drawing.Point(3, 71);
            this.dtgHistoricoCCusto.Name = "dtgHistoricoCCusto";
            this.dtgHistoricoCCusto.NaoAjustarEdicao = false;
            this.dtgHistoricoCCusto.Obrigatorio = false;
            this.dtgHistoricoCCusto.ObrigatorioMensagem = null;
            this.dtgHistoricoCCusto.PreValidacaoMensagem = null;
            this.dtgHistoricoCCusto.PreValidado = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistoricoCCusto.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgHistoricoCCusto.RowHeadersWidth = 25;
            this.dtgHistoricoCCusto.Size = new System.Drawing.Size(778, 272);
            this.dtgHistoricoCCusto.TabIndex = 0;
            this.dtgHistoricoCCusto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHistoricoCCusto_CellDoubleClick);
            // 
            // ColDelHist
            // 
            this.ColDelHist.HeaderText = "DEL";
            this.ColDelHist.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.ColDelHist.Name = "ColDelHist";
            this.ColDelHist.ReadOnly = true;
            this.ColDelHist.Width = 30;
            // 
            // colMovId
            // 
            this.colMovId.HeaderText = "ID";
            this.colMovId.Name = "colMovId";
            this.colMovId.ReadOnly = true;
            this.colMovId.Visible = false;
            // 
            // colDtMov
            // 
            this.colDtMov.HeaderText = "Data";
            this.colDtMov.Name = "colDtMov";
            this.colDtMov.ReadOnly = true;
            // 
            // colDsProdutoHist
            // 
            this.colDsProdutoHist.HeaderText = "Descrição";
            this.colDsProdutoHist.Name = "colDsProdutoHist";
            this.colDsProdutoHist.ReadOnly = true;
            this.colDsProdutoHist.Width = 410;
            // 
            // colLoteFab
            // 
            this.colLoteFab.HeaderText = "Lote";
            this.colLoteFab.Name = "colLoteFab";
            this.colLoteFab.ReadOnly = true;
            this.colLoteFab.Width = 70;
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
            // colQtdeHist
            // 
            this.colQtdeHist.HeaderText = "Qtde";
            this.colQtdeHist.Name = "colQtdeHist";
            this.colQtdeHist.ReadOnly = true;
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtIdProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtIdProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdProduto.Limpar = true;
            this.txtIdProduto.Location = new System.Drawing.Point(82, 105);
            this.txtIdProduto.MaxLength = 50;
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = false;
            this.txtIdProduto.ObrigatorioMensagem = null;
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(144, 21);
            this.txtIdProduto.TabIndex = 144;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdProduto_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Cód. Barra";
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbCE);
            this.grbFilial.Controls.Add(this.rbAcs);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(624, 26);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(161, 36);
            this.grbFilial.TabIndex = 159;
            this.grbFilial.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbCE.Limpar = false;
            this.rbCE.Location = new System.Drawing.Point(111, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 119;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.CheckedChanged += new System.EventHandler(this.rbCE_CheckedChanged);
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbAcs.Limpar = false;
            this.rbAcs.Location = new System.Drawing.Point(59, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 1;
            this.rbAcs.TabStop = true;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.CheckedChanged += new System.EventHandler(this.rbAcs_CheckedChanged);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(6, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 0;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.CheckedChanged += new System.EventHandler(this.rbHac_CheckedChanged);
            // 
            // lblEstoqueUnificado
            // 
            this.lblEstoqueUnificado.AutoSize = true;
            this.lblEstoqueUnificado.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEstoqueUnificado.ForeColor = System.Drawing.Color.Green;
            this.lblEstoqueUnificado.Location = new System.Drawing.Point(619, 103);
            this.lblEstoqueUnificado.Name = "lblEstoqueUnificado";
            this.lblEstoqueUnificado.Size = new System.Drawing.Size(0, 12);
            this.lblEstoqueUnificado.TabIndex = 160;
            // 
            // txtCodProd
            // 
            this.txtCodProd.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodProd.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodProd.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtCodProd.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtCodProd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodProd.Limpar = true;
            this.txtCodProd.Location = new System.Drawing.Point(325, 105);
            this.txtCodProd.MaxLength = 50;
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.NaoAjustarEdicao = false;
            this.txtCodProd.Obrigatorio = false;
            this.txtCodProd.ObrigatorioMensagem = null;
            this.txtCodProd.PreValidacaoMensagem = null;
            this.txtCodProd.PreValidado = false;
            this.txtCodProd.SelectAllOnFocus = false;
            this.txtCodProd.Size = new System.Drawing.Size(66, 21);
            this.txtCodProd.TabIndex = 145;
            this.txtCodProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProd.Visible = false;
            this.txtCodProd.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProd_Validating);
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCodProd.Location = new System.Drawing.Point(237, 108);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(82, 13);
            this.lblCodProd.TabIndex = 161;
            this.lblCodProd.Text = "Cód. Produto";
            this.lblCodProd.Visible = false;
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
            this.colDeletar.Visible = false;
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
            this.colDsProduto.Width = 600;
            // 
            // colMAVMov
            // 
            this.colMAVMov.FalseValue = "N";
            this.colMAVMov.HeaderText = "MAR";
            this.colMAVMov.Name = "colMAVMov";
            this.colMAVMov.ReadOnly = true;
            this.colMAVMov.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMAVMov.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMAVMov.TrueValue = "S";
            this.colMAVMov.Width = 35;
            // 
            // colQtde
            // 
            this.colQtde.HeaderText = "Quantidade";
            this.colQtde.MaxInputLength = 5;
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            // 
            // FrmLancamentoOutraUnidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 503);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.lblCodProd);
            this.Controls.Add(this.lblEstoqueUnificado);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.cmbLocalEstoque);
            this.Controls.Add(this.chkAjudaAtualizarGrid);
            this.Controls.Add(this.tsHac);
            this.ModoTela = HospitalAnaCosta.SGS.Componentes.ModoEdicao.Edicao;
            this.Name = "FrmLancamentoOutraUnidade";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.LancamentoOutraUnidade_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistoricoCCusto)).EndInit();
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacCheckBox chkAjudaAtualizarGrid;
        private HacToolStrip tsHac;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private HacLabel hacLabel6;
        private HacComboBox cmbLocalEstoque;
        private HacCmbSetor cmbSetor;
        private HacCmbLocal cmbLocal;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel3;
        private HacLabel hacLabel2;
        private HacLabel hacLabel1;
        private HacLabel hacLabel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private HacDataGridView dtgMatMed;
        private System.Windows.Forms.TabPage tabPage2;
        private HacDataGridView dtgHistoricoCCusto;
        private HacButton btnPesqMov;
        private HacTextBox txtDtMov;
        private HacLabel hacLabel11;
        private HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbFilial;
        private HacRadioButton rbCE;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacLabel lblEstoqueUnificado;
        private HacTextBox txtCodProd;
        private System.Windows.Forms.Label lblCodProd;
        private System.Windows.Forms.DataGridViewImageColumn ColDelHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProdutoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoteFab;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeHist;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAVMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
    }
}