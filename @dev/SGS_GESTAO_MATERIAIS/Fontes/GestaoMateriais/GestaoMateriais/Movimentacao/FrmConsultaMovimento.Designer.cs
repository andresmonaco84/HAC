using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmConsultaMovimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaMovimento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbTipoMov = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtData = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgMovimento = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSubTipoMov = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblPedido = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtNumPedido = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtAtdId = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.chkVerTodos = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.colDtMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQtdE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReqId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioEstorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtFat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHrFat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlEstorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimento)).BeginInit();
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
            this.tsHac.Size = new System.Drawing.Size(892, 28);
            this.tsHac.TabIndex = 12;
            this.tsHac.TituloTela = "Pesquisa de Movimentos";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(440, 41);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 140;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(268, 38);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(170, 21);
            this.cmbLocal.TabIndex = 1;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.Leave += new System.EventHandler(this.cmbLocal_Leave);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(229, 41);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 138;
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
            this.cmbUnidade.Location = new System.Drawing.Point(88, 38);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(138, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 0;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.Leave += new System.EventHandler(this.cmbUnidade_Leave);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(2, 41);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 136;
            this.hacLabel1.Text = "Unidade";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbAcs);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(778, 30);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(102, 36);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(52, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 5;
            this.rbAcs.TabStop = true;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(5, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 4;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
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
            this.cmbSetor.Location = new System.Drawing.Point(480, 38);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 2;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.Leave += new System.EventHandler(this.cmbSetor_Leave);
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.BackColor = System.Drawing.Color.Honeydew;
            this.cmbTipoMov.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbTipoMov.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbTipoMov.FormattingEnabled = true;
            this.cmbTipoMov.Limpar = true;
            this.cmbTipoMov.Location = new System.Drawing.Point(58, 507);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Obrigatorio = false;
            this.cmbTipoMov.ObrigatorioMensagem = null;
            this.cmbTipoMov.PreValidacaoMensagem = null;
            this.cmbTipoMov.PreValidado = false;
            this.cmbTipoMov.Size = new System.Drawing.Size(138, 21);
            this.cmbTipoMov.TabIndex = 9;
            this.cmbTipoMov.Text = "<Selecione>";
            this.cmbTipoMov.Leave += new System.EventHandler(this.cmbTipoMov_Leave);
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(3, 510);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(31, 13);
            this.hacLabel4.TabIndex = 144;
            this.hacLabel4.Text = "Tipo";
            // 
            // txtData
            // 
            this.txtData.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtData.BackColor = System.Drawing.Color.Honeydew;
            this.txtData.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtData.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtData.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtData.Limpar = false;
            this.txtData.Location = new System.Drawing.Point(619, 63);
            this.txtData.MaxLength = 10;
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = true;
            this.txtData.Obrigatorio = false;
            this.txtData.ObrigatorioMensagem = "";
            this.txtData.PreValidacaoMensagem = "";
            this.txtData.PreValidado = false;
            this.txtData.SelectAllOnFocus = false;
            this.txtData.Size = new System.Drawing.Size(100, 21);
            this.txtData.TabIndex = 7;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(579, 67);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(34, 13);
            this.hacLabel6.TabIndex = 145;
            this.hacLabel6.Text = "Data";
            // 
            // dtgMovimento
            // 
            this.dtgMovimento.AllowUserToAddRows = false;
            this.dtgMovimento.AllowUserToDeleteRows = false;
            this.dtgMovimento.AllowUserToResizeRows = false;
            this.dtgMovimento.AlterarStatus = false;
            this.dtgMovimento.BackgroundColor = System.Drawing.Color.White;
            this.dtgMovimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMovimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDtMov,
            this.colUnidade,
            this.colSetor,
            this.colProduto,
            this.colMAV,
            this.colQtdE,
            this.colQtdS,
            this.colSaldo,
            this.colTipo,
            this.colSubTipo,
            this.colReqId,
            this.colUsuario,
            this.colUsuarioEstorno,
            this.colSubTp,
            this.colDtFat,
            this.colHrFat,
            this.colFlEstorno,
            this.colIdRef});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMovimento.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgMovimento.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.dtgMovimento.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMovimento.GridPesquisa = false;
            this.dtgMovimento.Limpar = false;
            this.dtgMovimento.Location = new System.Drawing.Point(6, 192);
            this.dtgMovimento.Name = "dtgMovimento";
            this.dtgMovimento.NaoAjustarEdicao = true;
            this.dtgMovimento.Obrigatorio = false;
            this.dtgMovimento.ObrigatorioMensagem = null;
            this.dtgMovimento.PreValidacaoMensagem = null;
            this.dtgMovimento.PreValidado = false;
            this.dtgMovimento.RowHeadersVisible = false;
            this.dtgMovimento.RowHeadersWidth = 25;
            this.dtgMovimento.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgMovimento.RowTemplate.Height = 18;
            this.dtgMovimento.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMovimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMovimento.Size = new System.Drawing.Size(874, 309);
            this.dtgMovimento.TabIndex = 11;
            this.dtgMovimento.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgMovimento_RowPostPaint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 150;
            this.label2.Text = "Produto";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(201, 510);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(50, 13);
            this.hacLabel7.TabIndex = 153;
            this.hacLabel7.Text = "Subtipo";
            // 
            // cmbSubTipoMov
            // 
            this.cmbSubTipoMov.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSubTipoMov.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSubTipoMov.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSubTipoMov.FormattingEnabled = true;
            this.cmbSubTipoMov.Limpar = true;
            this.cmbSubTipoMov.Location = new System.Drawing.Point(255, 507);
            this.cmbSubTipoMov.Name = "cmbSubTipoMov";
            this.cmbSubTipoMov.Obrigatorio = false;
            this.cmbSubTipoMov.ObrigatorioMensagem = null;
            this.cmbSubTipoMov.PreValidacaoMensagem = null;
            this.cmbSubTipoMov.PreValidado = false;
            this.cmbSubTipoMov.Size = new System.Drawing.Size(396, 21);
            this.cmbSubTipoMov.TabIndex = 10;
            this.cmbSubTipoMov.Text = "<Selecione>";
            this.cmbSubTipoMov.Leave += new System.EventHandler(this.cmbSubTipoMov_Leave);
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
            this.btnLimparProduto.Location = new System.Drawing.Point(465, 63);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 154;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPedido.Location = new System.Drawing.Point(3, 115);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(45, 13);
            this.lblPedido.TabIndex = 155;
            this.lblPedido.Text = "Pedido";
            // 
            // txtNumPedido
            // 
            this.txtNumPedido.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtNumPedido.BackColor = System.Drawing.Color.Honeydew;
            this.txtNumPedido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtNumPedido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNumPedido.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNumPedido.Limpar = false;
            this.txtNumPedido.Location = new System.Drawing.Point(88, 112);
            this.txtNumPedido.MaxLength = 10;
            this.txtNumPedido.Name = "txtNumPedido";
            this.txtNumPedido.NaoAjustarEdicao = true;
            this.txtNumPedido.Obrigatorio = false;
            this.txtNumPedido.ObrigatorioMensagem = "";
            this.txtNumPedido.PreValidacaoMensagem = "";
            this.txtNumPedido.PreValidado = false;
            this.txtNumPedido.SelectAllOnFocus = false;
            this.txtNumPedido.Size = new System.Drawing.Size(100, 21);
            this.txtNumPedido.TabIndex = 156;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(3, 91);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(79, 13);
            this.hacLabel5.TabIndex = 157;
            this.hacLabel5.Text = "Atendimento";
            this.hacLabel5.DoubleClick += new System.EventHandler(this.hacLabel5_DoubleClick);
            // 
            // txtAtdId
            // 
            this.txtAtdId.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtAtdId.BackColor = System.Drawing.Color.Honeydew;
            this.txtAtdId.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtAtdId.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAtdId.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAtdId.Limpar = true;
            this.txtAtdId.Location = new System.Drawing.Point(88, 88);
            this.txtAtdId.Name = "txtAtdId";
            this.txtAtdId.NaoAjustarEdicao = true;
            this.txtAtdId.Obrigatorio = false;
            this.txtAtdId.ObrigatorioMensagem = "";
            this.txtAtdId.PreValidacaoMensagem = "";
            this.txtAtdId.PreValidado = false;
            this.txtAtdId.SelectAllOnFocus = false;
            this.txtAtdId.Size = new System.Drawing.Size(100, 21);
            this.txtAtdId.TabIndex = 158;
            // 
            // lblProduto
            // 
            this.lblProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.lblProduto.BackColor = System.Drawing.Color.Honeydew;
            this.lblProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.lblProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Limpar = true;
            this.lblProduto.Location = new System.Drawing.Point(88, 63);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.NaoAjustarEdicao = true;
            this.lblProduto.Obrigatorio = false;
            this.lblProduto.ObrigatorioMensagem = "";
            this.lblProduto.PreValidacaoMensagem = "";
            this.lblProduto.PreValidado = false;
            this.lblProduto.SelectAllOnFocus = false;
            this.lblProduto.Size = new System.Drawing.Size(375, 21);
            this.lblProduto.TabIndex = 159;
            // 
            // chkVerTodos
            // 
            this.chkVerTodos.AutoSize = true;
            this.chkVerTodos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkVerTodos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkVerTodos.Limpar = false;
            this.chkVerTodos.Location = new System.Drawing.Point(731, 511);
            this.chkVerTodos.Name = "chkVerTodos";
            this.chkVerTodos.Obrigatorio = false;
            this.chkVerTodos.ObrigatorioMensagem = null;
            this.chkVerTodos.PreValidacaoMensagem = null;
            this.chkVerTodos.PreValidado = false;
            this.chkVerTodos.Size = new System.Drawing.Size(149, 17);
            this.chkVerTodos.TabIndex = 160;
            this.chkVerTodos.Text = "Ver Todos os Movimentos";
            this.chkVerTodos.UseVisualStyleBackColor = true;
            this.chkVerTodos.CheckedChanged += new System.EventHandler(this.chkVerTodos_CheckedChanged);
            // 
            // colDtMov
            // 
            dataGridViewCellStyle1.Format = "DD/MM/YYYY hh:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.colDtMov.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDtMov.HeaderText = "Data";
            this.colDtMov.Name = "colDtMov";
            this.colDtMov.ReadOnly = true;
            // 
            // colUnidade
            // 
            this.colUnidade.HeaderText = "Unidade";
            this.colUnidade.Name = "colUnidade";
            this.colUnidade.ReadOnly = true;
            this.colUnidade.Visible = false;
            this.colUnidade.Width = 75;
            // 
            // colSetor
            // 
            this.colSetor.HeaderText = "Setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.ReadOnly = true;
            this.colSetor.Visible = false;
            this.colSetor.Width = 110;
            // 
            // colProduto
            // 
            this.colProduto.HeaderText = "Produto";
            this.colProduto.Name = "colProduto";
            this.colProduto.ReadOnly = true;
            this.colProduto.Width = 290;
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
            // colQtdE
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle2.Format = "N0";
            this.colQtdE.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtdE.HeaderText = "E";
            this.colQtdE.Name = "colQtdE";
            this.colQtdE.ReadOnly = true;
            this.colQtdE.Width = 35;
            // 
            // colQtdS
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colQtdS.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQtdS.HeaderText = "S";
            this.colQtdS.Name = "colQtdS";
            this.colQtdS.ReadOnly = true;
            this.colQtdS.Width = 35;
            // 
            // colSaldo
            // 
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.ReadOnly = true;
            this.colSaldo.Width = 50;
            // 
            // colTipo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colTipo.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Visible = false;
            this.colTipo.Width = 50;
            // 
            // colSubTipo
            // 
            this.colSubTipo.HeaderText = "Movimento";
            this.colSubTipo.Name = "colSubTipo";
            this.colSubTipo.ReadOnly = true;
            this.colSubTipo.Width = 340;
            // 
            // colReqId
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colReqId.DefaultCellStyle = dataGridViewCellStyle5;
            this.colReqId.HeaderText = "Pedido";
            this.colReqId.Name = "colReqId";
            this.colReqId.ReadOnly = true;
            this.colReqId.Width = 60;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuário";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            this.colUsuario.Width = 150;
            // 
            // colUsuarioEstorno
            // 
            this.colUsuarioEstorno.HeaderText = "Usuário Estorno";
            this.colUsuarioEstorno.Name = "colUsuarioEstorno";
            this.colUsuarioEstorno.ReadOnly = true;
            this.colUsuarioEstorno.Visible = false;
            this.colUsuarioEstorno.Width = 200;
            // 
            // colSubTp
            // 
            this.colSubTp.HeaderText = "SubTp";
            this.colSubTp.Name = "colSubTp";
            this.colSubTp.ReadOnly = true;
            this.colSubTp.Visible = false;
            // 
            // colDtFat
            // 
            this.colDtFat.HeaderText = "DtFat";
            this.colDtFat.Name = "colDtFat";
            this.colDtFat.ReadOnly = true;
            this.colDtFat.Visible = false;
            // 
            // colHrFat
            // 
            this.colHrFat.HeaderText = "HrFat";
            this.colHrFat.Name = "colHrFat";
            this.colHrFat.ReadOnly = true;
            this.colHrFat.Visible = false;
            // 
            // colFlEstorno
            // 
            this.colFlEstorno.HeaderText = "ESTORN";
            this.colFlEstorno.Name = "colFlEstorno";
            this.colFlEstorno.ReadOnly = true;
            // 
            // colIdRef
            // 
            this.colIdRef.HeaderText = "REF";
            this.colIdRef.Name = "colIdRef";
            this.colIdRef.ReadOnly = true;
            // 
            // FrmConsultaMovimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 556);
            this.Controls.Add(this.chkVerTodos);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.txtAtdId);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.txtNumPedido);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.btnLimparProduto);
            this.Controls.Add(this.hacLabel7);
            this.Controls.Add(this.cmbSubTipoMov);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgMovimento);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.cmbTipoMov);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmConsultaMovimento";
            this.Text = "FrmConsultaMovimento";
            this.Load += new System.EventHandler(this.FrmConsultaMovimento_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacLabel hacLabel3;
        private HacCmbLocal cmbLocal;
        private HacLabel hacLabel2;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel1;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacCmbSetor cmbSetor;
        private HacComboBox cmbTipoMov;
        private HacLabel hacLabel4;
        private HacTextBox txtData;
        private HacLabel hacLabel6;
        private HacDataGridView dtgMovimento;
        private System.Windows.Forms.Label label2;
        private HacLabel hacLabel7;
        private HacComboBox cmbSubTipoMov;
        private HacButton btnLimparProduto;
        private HacLabel lblPedido;
        private HacTextBox txtNumPedido;
        private HacLabel hacLabel5;
        private HacTextBox txtAtdId;
        private HacTextBox lblProduto;
        private HacCheckBox chkVerTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioEstorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtFat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHrFat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlEstorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRef;
    }
}