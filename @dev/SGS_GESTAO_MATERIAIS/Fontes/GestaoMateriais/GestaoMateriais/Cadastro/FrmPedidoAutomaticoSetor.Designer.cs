namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmPedidoAutomaticoSetor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoAutomaticoSetor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.tsCancelarGeracaoPedidos = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.btnPesquisaPac = new System.Windows.Forms.PictureBox();
            this.txtNomePac = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroInternacao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.dtgPedidosGerar = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colSelecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataGerar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MnPopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnAlterarHora = new System.Windows.Forms.ToolStripMenuItem();
            this.colDataDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdGerar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodoDose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodPresc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPedidoOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPedidoNovo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbEdicao = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel10 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtd = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.cbGerados = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnStatus = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.tsHac.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidosGerar)).BeginInit();
            this.MnPopUp.SuspendLayout();
            this.grbEdicao.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCancelarGeracaoPedidos});
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(704, 28);
            this.tsHac.TabIndex = 100;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Pedido Automático Setor";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // tsCancelarGeracaoPedidos
            // 
            this.tsCancelarGeracaoPedidos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCancelarGeracaoPedidos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsCancelarGeracaoPedidos.Image = ((System.Drawing.Image)(resources.GetObject("tsCancelarGeracaoPedidos.Image")));
            this.tsCancelarGeracaoPedidos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCancelarGeracaoPedidos.Name = "tsCancelarGeracaoPedidos";
            this.tsCancelarGeracaoPedidos.Size = new System.Drawing.Size(133, 25);
            this.tsCancelarGeracaoPedidos.Text = "Cancelar Geração Sel.";
            this.tsCancelarGeracaoPedidos.Click += new System.EventHandler(this.tsCancelarGeracaoPedidos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbUnidade);
            this.groupBox2.Controls.Add(this.hacLabel1);
            this.groupBox2.Controls.Add(this.hacLabel2);
            this.groupBox2.Controls.Add(this.cmbSetor);
            this.groupBox2.Controls.Add(this.hacLabel3);
            this.groupBox2.Controls.Add(this.cmbLocal);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 102);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrar Setor";
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
            this.cmbUnidade.Location = new System.Drawing.Point(62, 20);
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
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 24);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 133;
            this.hacLabel1.Text = "Unidade";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(23, 51);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 135;
            this.hacLabel2.Text = "Local";
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
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(61, 74);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = "cmbLocal";
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(178, 21);
            this.cmbSetor.TabIndex = 138;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(21, 78);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 137;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(62, 47);
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
            // btnPesquisaPac
            // 
            this.btnPesquisaPac.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.btnPesquisaPac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaPac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaPac.Location = new System.Drawing.Point(429, 48);
            this.btnPesquisaPac.Name = "btnPesquisaPac";
            this.btnPesquisaPac.Size = new System.Drawing.Size(34, 21);
            this.btnPesquisaPac.TabIndex = 106;
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
            this.txtNomePac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNomePac.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomePac.Limpar = true;
            this.txtNomePac.Location = new System.Drawing.Point(342, 75);
            this.txtNomePac.Name = "txtNomePac";
            this.txtNomePac.NaoAjustarEdicao = true;
            this.txtNomePac.Obrigatorio = false;
            this.txtNomePac.ObrigatorioMensagem = null;
            this.txtNomePac.PreValidacaoMensagem = null;
            this.txtNomePac.PreValidado = false;
            this.txtNomePac.SelectAllOnFocus = false;
            this.txtNomePac.Size = new System.Drawing.Size(243, 18);
            this.txtNomePac.TabIndex = 105;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 104;
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
            this.txtNroInternacao.Location = new System.Drawing.Point(342, 48);
            this.txtNroInternacao.MaxLength = 10;
            this.txtNroInternacao.Name = "txtNroInternacao";
            this.txtNroInternacao.NaoAjustarEdicao = true;
            this.txtNroInternacao.Obrigatorio = false;
            this.txtNroInternacao.ObrigatorioMensagem = null;
            this.txtNroInternacao.PreValidacaoMensagem = null;
            this.txtNroInternacao.PreValidado = false;
            this.txtNroInternacao.SelectAllOnFocus = false;
            this.txtNroInternacao.Size = new System.Drawing.Size(85, 21);
            this.txtNroInternacao.TabIndex = 103;
            this.txtNroInternacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroInternacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroInternacao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Atendimento";
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
            this.btnLimparProduto.Location = new System.Drawing.Point(591, 100);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 160;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Visible = false;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(287, 105);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(51, 13);
            this.hacLabel6.TabIndex = 158;
            this.hacLabel6.Text = "Produto";
            // 
            // txtProduto
            // 
            this.txtProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtProduto.Enabled = false;
            this.txtProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtProduto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtProduto.Limpar = true;
            this.txtProduto.Location = new System.Drawing.Point(342, 102);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.NaoAjustarEdicao = true;
            this.txtProduto.Obrigatorio = false;
            this.txtProduto.ObrigatorioMensagem = null;
            this.txtProduto.PreValidacaoMensagem = null;
            this.txtProduto.PreValidado = false;
            this.txtProduto.SelectAllOnFocus = false;
            this.txtProduto.Size = new System.Drawing.Size(243, 18);
            this.txtProduto.TabIndex = 161;
            // 
            // dtgPedidosGerar
            // 
            this.dtgPedidosGerar.AllowUserToAddRows = false;
            this.dtgPedidosGerar.AllowUserToDeleteRows = false;
            this.dtgPedidosGerar.AllowUserToResizeColumns = false;
            this.dtgPedidosGerar.AllowUserToResizeRows = false;
            this.dtgPedidosGerar.AlterarStatus = false;
            this.dtgPedidosGerar.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidosGerar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPedidosGerar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedidosGerar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelecionar,
            this.colSetor,
            this.colDataGerar,
            this.colDataDose,
            this.colDsProd,
            this.colQtdGerar,
            this.colPeriodoDose,
            this.colAtendimento,
            this.colCodPresc,
            this.colPedidoOrigem,
            this.colPedidoNovo,
            this.colIdProduto});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPedidosGerar.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgPedidosGerar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgPedidosGerar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgPedidosGerar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgPedidosGerar.GridPesquisa = false;
            this.dtgPedidosGerar.Limpar = true;
            this.dtgPedidosGerar.Location = new System.Drawing.Point(5, 139);
            this.dtgPedidosGerar.Name = "dtgPedidosGerar";
            this.dtgPedidosGerar.NaoAjustarEdicao = true;
            this.dtgPedidosGerar.Obrigatorio = false;
            this.dtgPedidosGerar.ObrigatorioMensagem = null;
            this.dtgPedidosGerar.PreValidacaoMensagem = null;
            this.dtgPedidosGerar.PreValidado = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidosGerar.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgPedidosGerar.RowHeadersVisible = false;
            this.dtgPedidosGerar.RowHeadersWidth = 25;
            this.dtgPedidosGerar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgPedidosGerar.Size = new System.Drawing.Size(687, 316);
            this.dtgPedidosGerar.TabIndex = 162;
            this.dtgPedidosGerar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPedidosGerar_CellClick);
            this.dtgPedidosGerar.SelectionChanged += new System.EventHandler(this.dtgPedidosGerar_SelectionChanged);
            this.dtgPedidosGerar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtgPedidosGerar_MouseDown);
            // 
            // colSelecionar
            // 
            this.colSelecionar.HeaderText = "";
            this.colSelecionar.Name = "colSelecionar";
            this.colSelecionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelecionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelecionar.Width = 25;
            // 
            // colSetor
            // 
            this.colSetor.HeaderText = "Setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.ReadOnly = true;
            this.colSetor.Width = 155;
            // 
            // colDataGerar
            // 
            this.colDataGerar.ContextMenuStrip = this.MnPopUp;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDataGerar.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataGerar.HeaderText = "Data Gerar Pedido";
            this.colDataGerar.Name = "colDataGerar";
            this.colDataGerar.ReadOnly = true;
            this.colDataGerar.Width = 118;
            // 
            // MnPopUp
            // 
            this.MnPopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnAlterarHora});
            this.MnPopUp.Name = "MnPopUp";
            this.MnPopUp.ShowImageMargin = false;
            this.MnPopUp.ShowItemToolTips = false;
            this.MnPopUp.Size = new System.Drawing.Size(160, 26);
            // 
            // MnAlterarHora
            // 
            this.MnAlterarHora.Name = "MnAlterarHora";
            this.MnAlterarHora.Size = new System.Drawing.Size(159, 22);
            this.MnAlterarHora.Text = "Alterar Hora Geração";
            this.MnAlterarHora.Click += new System.EventHandler(this.MnAlterarHora_Click);
            // 
            // colDataDose
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            this.colDataDose.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDataDose.HeaderText = "Data Dose";
            this.colDataDose.Name = "colDataDose";
            this.colDataDose.ReadOnly = true;
            this.colDataDose.Width = 118;
            // 
            // colDsProd
            // 
            this.colDsProd.HeaderText = "Item";
            this.colDsProd.Name = "colDsProd";
            this.colDsProd.ReadOnly = true;
            this.colDsProd.Width = 250;
            // 
            // colQtdGerar
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colQtdGerar.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQtdGerar.HeaderText = "Qtde.";
            this.colQtdGerar.Name = "colQtdGerar";
            this.colQtdGerar.ReadOnly = true;
            this.colQtdGerar.Width = 50;
            // 
            // colPeriodoDose
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPeriodoDose.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPeriodoDose.HeaderText = "Per. Dose";
            this.colPeriodoDose.Name = "colPeriodoDose";
            this.colPeriodoDose.ReadOnly = true;
            this.colPeriodoDose.Width = 77;
            // 
            // colAtendimento
            // 
            this.colAtendimento.HeaderText = "Atendimento";
            this.colAtendimento.Name = "colAtendimento";
            this.colAtendimento.ReadOnly = true;
            this.colAtendimento.Width = 73;
            // 
            // colCodPresc
            // 
            this.colCodPresc.HeaderText = "Cód. Presc.";
            this.colCodPresc.Name = "colCodPresc";
            this.colCodPresc.ReadOnly = true;
            this.colCodPresc.Width = 85;
            // 
            // colPedidoOrigem
            // 
            this.colPedidoOrigem.HeaderText = "Pedido Origem";
            this.colPedidoOrigem.Name = "colPedidoOrigem";
            this.colPedidoOrigem.ReadOnly = true;
            // 
            // colPedidoNovo
            // 
            this.colPedidoNovo.HeaderText = "Pedido Gerado";
            this.colPedidoNovo.Name = "colPedidoNovo";
            this.colPedidoNovo.ReadOnly = true;
            this.colPedidoNovo.Width = 110;
            // 
            // colIdProduto
            // 
            this.colIdProduto.HeaderText = "colIdProduto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.ReadOnly = true;
            this.colIdProduto.Visible = false;
            // 
            // grbEdicao
            // 
            this.grbEdicao.Controls.Add(this.btnSalvar);
            this.grbEdicao.Controls.Add(this.hacLabel10);
            this.grbEdicao.Controls.Add(this.txtQtd);
            this.grbEdicao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEdicao.Location = new System.Drawing.Point(514, 464);
            this.grbEdicao.Name = "grbEdicao";
            this.grbEdicao.Size = new System.Drawing.Size(181, 53);
            this.grbEdicao.TabIndex = 163;
            this.grbEdicao.TabStop = false;
            this.grbEdicao.Text = "Editar Registro Selecionado";
            // 
            // btnSalvar
            // 
            this.btnSalvar.AlterarStatus = true;
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.disk;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(142, 25);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(18, 18);
            this.btnSalvar.TabIndex = 157;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // hacLabel10
            // 
            this.hacLabel10.AutoSize = true;
            this.hacLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hacLabel10.Location = new System.Drawing.Point(14, 29);
            this.hacLabel10.Name = "hacLabel10";
            this.hacLabel10.Size = new System.Drawing.Size(81, 13);
            this.hacLabel10.TabIndex = 152;
            this.hacLabel10.Text = "QTDE. GERAR";
            // 
            // txtQtd
            // 
            this.txtQtd.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtd.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtd.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtd.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtd.Limpar = true;
            this.txtQtd.Location = new System.Drawing.Point(98, 24);
            this.txtQtd.MaxLength = 2;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.NaoAjustarEdicao = false;
            this.txtQtd.Obrigatorio = false;
            this.txtQtd.ObrigatorioMensagem = "";
            this.txtQtd.PreValidacaoMensagem = "";
            this.txtQtd.PreValidado = false;
            this.txtQtd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQtd.SelectAllOnFocus = false;
            this.txtQtd.Size = new System.Drawing.Size(35, 21);
            this.txtQtd.TabIndex = 151;
            // 
            // cbGerados
            // 
            this.cbGerados.AutoSize = true;
            this.cbGerados.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cbGerados.Enabled = false;
            this.cbGerados.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbGerados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGerados.Limpar = true;
            this.cbGerados.Location = new System.Drawing.Point(524, 50);
            this.cbGerados.Name = "cbGerados";
            this.cbGerados.Obrigatorio = false;
            this.cbGerados.ObrigatorioMensagem = null;
            this.cbGerados.PreValidacaoMensagem = null;
            this.cbGerados.PreValidado = false;
            this.cbGerados.Size = new System.Drawing.Size(178, 17);
            this.cbGerados.TabIndex = 164;
            this.cbGerados.Text = "COM PEDIDOS GERADOS";
            this.cbGerados.UseVisualStyleBackColor = true;
            this.cbGerados.Click += new System.EventHandler(this.cbGerados_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.AlterarStatus = true;
            this.btnStatus.BackColor = System.Drawing.Color.White;
            this.btnStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStatus.BackgroundImage")));
            this.btnStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnStatus.Location = new System.Drawing.Point(13, 470);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(80, 40);
            this.btnStatus.TabIndex = 165;
            this.btnStatus.Text = "Status Geração";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Visible = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // FrmPedidoAutomaticoSetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 522);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.cbGerados);
            this.Controls.Add(this.grbEdicao);
            this.Controls.Add(this.dtgPedidosGerar);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.btnLimparProduto);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.btnPesquisaPac);
            this.Controls.Add(this.txtNomePac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNroInternacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmPedidoAutomaticoSetor";
            this.Text = "FrmPedidoAutomaticoSetor";
            this.Load += new System.EventHandler(this.FrmPedidoAutomaticoSetor_Load);
            this.tsHac.ResumeLayout(false);
            this.tsHac.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidosGerar)).EndInit();
            this.MnPopUp.ResumeLayout(false);
            this.grbEdicao.ResumeLayout(false);
            this.grbEdicao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private System.Windows.Forms.PictureBox btnPesquisaPac;
        private SGS.Componentes.HacTextBox txtNomePac;
        private System.Windows.Forms.Label label2;
        private SGS.Componentes.HacTextBox txtNroInternacao;
        private System.Windows.Forms.Label label1;
        private SGS.Componentes.HacButton btnLimparProduto;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacTextBox txtProduto;
        private SGS.Componentes.HacDataGridView dtgPedidosGerar;
        private System.Windows.Forms.GroupBox grbEdicao;
        private System.Windows.Forms.ToolStripButton tsCancelarGeracaoPedidos;
        private SGS.Componentes.HacLabel hacLabel10;
        private SGS.Componentes.HacTextBox txtQtd;
        private SGS.Componentes.HacButton btnSalvar;
        private SGS.Componentes.HacCheckBox cbGerados;
        private SGS.Componentes.HacButton btnStatus;
        private System.Windows.Forms.ContextMenuStrip MnPopUp;
        private System.Windows.Forms.ToolStripMenuItem MnAlterarHora;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataGerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdGerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodoDose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodPresc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoNovo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
    }
}