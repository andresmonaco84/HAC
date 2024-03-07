using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmImpressaoPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpressaoPedido));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.cmbTipoRequisicao = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chkImprimir = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.dtgReqMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colReqIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnReimpUlt = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtQtdReimpressao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtReqNum = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.btnReimpReqNum = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chkHomeCare = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnStatusImpresso = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.tmPedidoAuto = new System.Windows.Forms.Timer(this.components);
            this.tmPacienteTransf = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReqMatMed)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(794, 28);
            this.tsHac.TabIndex = 5;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Impressão de Pedido";
            // 
            // cmbTipoRequisicao
            // 
            this.cmbTipoRequisicao.BackColor = System.Drawing.Color.Honeydew;
            this.cmbTipoRequisicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRequisicao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbTipoRequisicao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbTipoRequisicao.FormattingEnabled = true;
            this.cmbTipoRequisicao.Limpar = true;
            this.cmbTipoRequisicao.Location = new System.Drawing.Point(77, 74);
            this.cmbTipoRequisicao.Name = "cmbTipoRequisicao";
            this.cmbTipoRequisicao.Obrigatorio = false;
            this.cmbTipoRequisicao.ObrigatorioMensagem = null;
            this.cmbTipoRequisicao.PreValidacaoMensagem = null;
            this.cmbTipoRequisicao.PreValidado = false;
            this.cmbTipoRequisicao.Size = new System.Drawing.Size(323, 21);
            this.cmbTipoRequisicao.TabIndex = 6;
            this.cmbTipoRequisicao.SelectedIndexChanged += new System.EventHandler(this.cmbTipoRequisicao_SelectedIndexChanged);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(12, 79);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(31, 13);
            this.hacLabel1.TabIndex = 7;
            this.hacLabel1.Text = "Tipo";
            // 
            // chkImprimir
            // 
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chkImprimir.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImprimir.Limpar = true;
            this.chkImprimir.Location = new System.Drawing.Point(424, 78);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Obrigatorio = false;
            this.chkImprimir.ObrigatorioMensagem = null;
            this.chkImprimir.PreValidacaoMensagem = null;
            this.chkImprimir.PreValidado = false;
            this.chkImprimir.Size = new System.Drawing.Size(84, 17);
            this.chkImprimir.TabIndex = 8;
            this.chkImprimir.Text = "IMPRIMIR";
            this.chkImprimir.UseVisualStyleBackColor = true;
            this.chkImprimir.CheckedChanged += new System.EventHandler(this.chkImprimir_CheckedChanged);
            // 
            // dtgReqMatMed
            // 
            this.dtgReqMatMed.AllowUserToAddRows = false;
            this.dtgReqMatMed.AllowUserToDeleteRows = false;
            this.dtgReqMatMed.AlterarStatus = true;
            this.dtgReqMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgReqMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReqMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReqIdt,
            this.colIdtUnidade,
            this.colDsUnidade,
            this.colIdtLocal,
            this.colDsLocal,
            this.colIdtSetor,
            this.colDsSetor,
            this.colData});
            this.dtgReqMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgReqMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgReqMatMed.GridPesquisa = false;
            this.dtgReqMatMed.Limpar = true;
            this.dtgReqMatMed.Location = new System.Drawing.Point(11, 164);
            this.dtgReqMatMed.Name = "dtgReqMatMed";
            this.dtgReqMatMed.NaoAjustarEdicao = false;
            this.dtgReqMatMed.Obrigatorio = false;
            this.dtgReqMatMed.ObrigatorioMensagem = null;
            this.dtgReqMatMed.PreValidacaoMensagem = null;
            this.dtgReqMatMed.PreValidado = false;
            this.dtgReqMatMed.ReadOnly = true;
            this.dtgReqMatMed.RowHeadersWidth = 25;
            this.dtgReqMatMed.Size = new System.Drawing.Size(771, 292);
            this.dtgReqMatMed.TabIndex = 69;
            // 
            // colReqIdt
            // 
            this.colReqIdt.HeaderText = "Req Idt";
            this.colReqIdt.Name = "colReqIdt";
            this.colReqIdt.ReadOnly = true;
            this.colReqIdt.Visible = false;
            // 
            // colIdtUnidade
            // 
            this.colIdtUnidade.HeaderText = "Unidade Idt";
            this.colIdtUnidade.Name = "colIdtUnidade";
            this.colIdtUnidade.ReadOnly = true;
            this.colIdtUnidade.Visible = false;
            // 
            // colDsUnidade
            // 
            this.colDsUnidade.HeaderText = "Unidade";
            this.colDsUnidade.Name = "colDsUnidade";
            this.colDsUnidade.ReadOnly = true;
            this.colDsUnidade.Width = 215;
            // 
            // colIdtLocal
            // 
            this.colIdtLocal.HeaderText = "IdtLocal";
            this.colIdtLocal.Name = "colIdtLocal";
            this.colIdtLocal.ReadOnly = true;
            this.colIdtLocal.Visible = false;
            // 
            // colDsLocal
            // 
            this.colDsLocal.HeaderText = "Local";
            this.colDsLocal.Name = "colDsLocal";
            this.colDsLocal.ReadOnly = true;
            this.colDsLocal.Width = 215;
            // 
            // colIdtSetor
            // 
            this.colIdtSetor.HeaderText = "Setor Idt";
            this.colIdtSetor.Name = "colIdtSetor";
            this.colIdtSetor.ReadOnly = true;
            this.colIdtSetor.Visible = false;
            // 
            // colDsSetor
            // 
            this.colDsSetor.HeaderText = "Setor";
            this.colDsSetor.Name = "colDsSetor";
            this.colDsSetor.ReadOnly = true;
            this.colDsSetor.Width = 200;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            // 
            // timer
            // 
            this.timer.Interval = 8000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnReimpUlt
            // 
            this.btnReimpUlt.AlterarStatus = false;
            this.btnReimpUlt.BackColor = System.Drawing.Color.White;
            this.btnReimpUlt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReimpUlt.BackgroundImage")));
            this.btnReimpUlt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReimpUlt.Enabled = false;
            this.btnReimpUlt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnReimpUlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimpUlt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnReimpUlt.Location = new System.Drawing.Point(555, 79);
            this.btnReimpUlt.Name = "btnReimpUlt";
            this.btnReimpUlt.Size = new System.Drawing.Size(161, 22);
            this.btnReimpUlt.TabIndex = 70;
            this.btnReimpUlt.Text = "REIMPRIMIR ÚLTIMOS ";
            this.btnReimpUlt.UseVisualStyleBackColor = true;
            this.btnReimpUlt.Click += new System.EventHandler(this.btnReimpUlt_Click);
            // 
            // txtQtdReimpressao
            // 
            this.txtQtdReimpressao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdReimpressao.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdReimpressao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdReimpressao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtQtdReimpressao.Enabled = false;
            this.txtQtdReimpressao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdReimpressao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdReimpressao.Limpar = false;
            this.txtQtdReimpressao.Location = new System.Drawing.Point(722, 80);
            this.txtQtdReimpressao.MaxLength = 2;
            this.txtQtdReimpressao.Name = "txtQtdReimpressao";
            this.txtQtdReimpressao.NaoAjustarEdicao = false;
            this.txtQtdReimpressao.Obrigatorio = false;
            this.txtQtdReimpressao.ObrigatorioMensagem = "";
            this.txtQtdReimpressao.PreValidacaoMensagem = null;
            this.txtQtdReimpressao.PreValidado = false;
            this.txtQtdReimpressao.SelectAllOnFocus = false;
            this.txtQtdReimpressao.Size = new System.Drawing.Size(60, 21);
            this.txtQtdReimpressao.TabIndex = 91;
            this.txtQtdReimpressao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReqNum
            // 
            this.txtReqNum.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtReqNum.BackColor = System.Drawing.Color.Honeydew;
            this.txtReqNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReqNum.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtReqNum.Enabled = false;
            this.txtReqNum.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtReqNum.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtReqNum.Limpar = true;
            this.txtReqNum.Location = new System.Drawing.Point(722, 108);
            this.txtReqNum.MaxLength = 9;
            this.txtReqNum.Name = "txtReqNum";
            this.txtReqNum.NaoAjustarEdicao = false;
            this.txtReqNum.Obrigatorio = false;
            this.txtReqNum.ObrigatorioMensagem = "";
            this.txtReqNum.PreValidacaoMensagem = null;
            this.txtReqNum.PreValidado = false;
            this.txtReqNum.SelectAllOnFocus = false;
            this.txtReqNum.Size = new System.Drawing.Size(60, 21);
            this.txtReqNum.TabIndex = 93;
            this.txtReqNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReimpReqNum
            // 
            this.btnReimpReqNum.AlterarStatus = false;
            this.btnReimpReqNum.BackColor = System.Drawing.Color.White;
            this.btnReimpReqNum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReimpReqNum.BackgroundImage")));
            this.btnReimpReqNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReimpReqNum.Enabled = false;
            this.btnReimpReqNum.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnReimpReqNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimpReqNum.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnReimpReqNum.Location = new System.Drawing.Point(555, 107);
            this.btnReimpReqNum.Name = "btnReimpReqNum";
            this.btnReimpReqNum.Size = new System.Drawing.Size(161, 22);
            this.btnReimpReqNum.TabIndex = 92;
            this.btnReimpReqNum.Text = "REIMPRIMIR PEDIDO N°";
            this.btnReimpReqNum.UseVisualStyleBackColor = true;
            this.btnReimpReqNum.Click += new System.EventHandler(this.btnReimpReqNum_Click);
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = true;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.Enabled = false;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(600, 39);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(180, 21);
            this.cmbSetor.TabIndex = 99;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.Enabled = false;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(339, 39);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(180, 21);
            this.cmbLocal.TabIndex = 98;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(12, 42);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(53, 13);
            this.hacLabel4.TabIndex = 94;
            this.hacLabel4.Text = "Unidade";
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
            this.cmbUnidade.Location = new System.Drawing.Point(77, 39);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(180, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 97;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(297, 42);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(36, 13);
            this.hacLabel5.TabIndex = 95;
            this.hacLabel5.Text = "Local";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(556, 42);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 96;
            this.hacLabel6.Text = "Setor";
            // 
            // chkHomeCare
            // 
            this.chkHomeCare.AutoSize = true;
            this.chkHomeCare.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chkHomeCare.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkHomeCare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHomeCare.Limpar = true;
            this.chkHomeCare.Location = new System.Drawing.Point(77, 107);
            this.chkHomeCare.Name = "chkHomeCare";
            this.chkHomeCare.Obrigatorio = false;
            this.chkHomeCare.ObrigatorioMensagem = null;
            this.chkHomeCare.PreValidacaoMensagem = null;
            this.chkHomeCare.PreValidado = false;
            this.chkHomeCare.Size = new System.Drawing.Size(245, 17);
            this.chkHomeCare.TabIndex = 100;
            this.chkHomeCare.Text = "APENAS ATENDIMENTO DOMICILIAR";
            this.chkHomeCare.UseVisualStyleBackColor = true;
            this.chkHomeCare.Visible = false;
            // 
            // btnStatusImpresso
            // 
            this.btnStatusImpresso.AlterarStatus = false;
            this.btnStatusImpresso.BackColor = System.Drawing.Color.White;
            this.btnStatusImpresso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStatusImpresso.BackgroundImage")));
            this.btnStatusImpresso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusImpresso.Enabled = false;
            this.btnStatusImpresso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnStatusImpresso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusImpresso.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnStatusImpresso.Location = new System.Drawing.Point(474, 135);
            this.btnStatusImpresso.Name = "btnStatusImpresso";
            this.btnStatusImpresso.Size = new System.Drawing.Size(306, 22);
            this.btnStatusImpresso.TabIndex = 101;
            this.btnStatusImpresso.Text = "ALTERAR P/ STATUS IMPRESSO PEDIDO ACIMA";
            this.btnStatusImpresso.UseVisualStyleBackColor = true;
            this.btnStatusImpresso.Visible = false;
            this.btnStatusImpresso.Click += new System.EventHandler(this.btnStatusImpresso_Click);
            // 
            // tmPedidoAuto
            // 
            this.tmPedidoAuto.Interval = 120000;
            this.tmPedidoAuto.Tick += new System.EventHandler(this.tmPedidoAuto_Tick);
            // 
            // tmPacienteTransf
            // 
            this.tmPacienteTransf.Interval = 300000;
            this.tmPacienteTransf.Tick += new System.EventHandler(this.tmPacienteTransf_Tick);
            // 
            // FrmImpressaoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 468);
            this.Controls.Add(this.btnStatusImpresso);
            this.Controls.Add(this.chkHomeCare);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.txtReqNum);
            this.Controls.Add(this.btnReimpReqNum);
            this.Controls.Add(this.txtQtdReimpressao);
            this.Controls.Add(this.btnReimpUlt);
            this.Controls.Add(this.dtgReqMatMed);
            this.Controls.Add(this.chkImprimir);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.cmbTipoRequisicao);
            this.Controls.Add(this.tsHac);
            this.ModoTela = HospitalAnaCosta.SGS.Componentes.ModoEdicao.Edicao;
            this.Name = "FrmImpressaoPedido";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmImpressaoPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReqMatMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacComboBox cmbTipoRequisicao;
        private HacLabel hacLabel1;
        private HacCheckBox chkImprimir;
        private HacDataGridView dtgReqMatMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.Timer timer;
        private HacButton btnReimpUlt;
        private HacTextBox txtQtdReimpressao;
        private HacTextBox txtReqNum;
        private HacButton btnReimpReqNum;
        private HacCmbSetor cmbSetor;
        private HacCmbLocal cmbLocal;
        private HacLabel hacLabel4;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel5;
        private HacLabel hacLabel6;
        private HacCheckBox chkHomeCare;
        private HacButton btnStatusImpresso;
        private System.Windows.Forms.Timer tmPedidoAuto;
        private System.Windows.Forms.Timer tmPacienteTransf;
    }
}