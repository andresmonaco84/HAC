using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmConsumoPaciente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsumoPaciente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNomePac = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtNroInternacao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtCodProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblCodProd = new System.Windows.Forms.Label();
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQuartoLeito = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocal = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeConvenio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtCodConvenio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.grbFiltrarMTMD = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.tabConsumo = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLegenda = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgHistConsumo = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdtMovimentoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTpMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeletarHist = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDataHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoteFab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQtdHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdInteiraHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFaturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataRessup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsQtdeConvertida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCE = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkFracionar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblContaFaturada = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDtTranf = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtHrTransf = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.grpTipoAtendimento = new System.Windows.Forms.GroupBox();
            this.rbAmbulatorio = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbInternado = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.lblEU = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.pnlPendentes = new System.Windows.Forms.Panel();
            this.btnRelDevolucao = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnFecharPendentes = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblPend = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgItensPendentes = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colDsMatMedPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatMedIdtPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdForn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdCons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdPendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnPendentes = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnRegerarFaturamento = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnHistorico = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnFinalizarCE = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.btnPesquisaPac = new System.Windows.Forms.PictureBox();
            this.cbApenasFaturar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbCE = new System.Windows.Forms.GroupBox();
            this.btnFecharCE = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.cmbCE = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.cbDigitar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.cbConsignado = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbFiltrarMTMD.SuspendLayout();
            this.tabConsumo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).BeginInit();
            this.grpTipoAtendimento.SuspendLayout();
            this.pnlPendentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensPendentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).BeginInit();
            this.grbCE.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNomePac
            // 
            this.txtNomePac.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomePac.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomePac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomePac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNomePac.Enabled = false;
            this.txtNomePac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNomePac.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomePac.Limpar = true;
            this.txtNomePac.Location = new System.Drawing.Point(208, 63);
            this.txtNomePac.Name = "txtNomePac";
            this.txtNomePac.NaoAjustarEdicao = false;
            this.txtNomePac.Obrigatorio = false;
            this.txtNomePac.ObrigatorioMensagem = null;
            this.txtNomePac.PreValidacaoMensagem = null;
            this.txtNomePac.PreValidado = false;
            this.txtNomePac.SelectAllOnFocus = false;
            this.txtNomePac.Size = new System.Drawing.Size(359, 21);
            this.txtNomePac.TabIndex = 71;
            // 
            // txtNroInternacao
            // 
            this.txtNroInternacao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtNroInternacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtNroInternacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroInternacao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.txtNroInternacao.Enabled = false;
            this.txtNroInternacao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNroInternacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNroInternacao.Limpar = true;
            this.txtNroInternacao.Location = new System.Drawing.Point(82, 63);
            this.txtNroInternacao.MaxLength = 10;
            this.txtNroInternacao.Name = "txtNroInternacao";
            this.txtNroInternacao.NaoAjustarEdicao = false;
            this.txtNroInternacao.Obrigatorio = false;
            this.txtNroInternacao.ObrigatorioMensagem = null;
            this.txtNroInternacao.PreValidacaoMensagem = null;
            this.txtNroInternacao.PreValidado = false;
            this.txtNroInternacao.SelectAllOnFocus = false;
            this.txtNroInternacao.Size = new System.Drawing.Size(65, 21);
            this.txtNroInternacao.TabIndex = 69;
            this.txtNroInternacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroInternacao.Validated += new System.EventHandler(this.txtNroInternacao_Validated);
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Pesquisa;
            this.txtCodProduto.Enabled = false;
            this.txtCodProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtCodProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodProduto.Limpar = true;
            this.txtCodProduto.Location = new System.Drawing.Point(82, 118);
            this.txtCodProduto.MaxLength = 50;
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.NaoAjustarEdicao = false;
            this.txtCodProduto.Obrigatorio = true;
            this.txtCodProduto.ObrigatorioMensagem = "C�digo Obrigatorio";
            this.txtCodProduto.PreValidacaoMensagem = null;
            this.txtCodProduto.PreValidado = false;
            this.txtCodProduto.SelectAllOnFocus = false;
            this.txtCodProduto.Size = new System.Drawing.Size(173, 21);
            this.txtCodProduto.TabIndex = 74;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProduto_Validating);
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Location = new System.Drawing.Point(2, 122);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(69, 13);
            this.lblCodProd.TabIndex = 73;
            this.lblCodProd.Text = "Cod. Produto";
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
            this.cmbSetor.Location = new System.Drawing.Point(483, 32);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = false;
            this.cmbSetor.ObrigatorioMensagem = null;
            this.cmbSetor.PreValidacaoMensagem = "Setor n�o pode estar em branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(165, 21);
            this.cmbSetor.TabIndex = 87;
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
            this.cmbLocal.Location = new System.Drawing.Point(288, 32);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = false;
            this.cmbLocal.ObrigatorioMensagem = null;
            this.cmbLocal.PreValidacaoMensagem = "Local de atendimento n�o pode estar em branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(148, 21);
            this.cmbLocal.TabIndex = 86;
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
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(82, 32);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = false;
            this.cmbUnidade.ObrigatorioMensagem = null;
            this.cmbUnidade.PreValidacaoMensagem = "Unidade n�o pode estar em branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(160, 21);
            this.cmbUnidade.SomenteAtiva = true;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 85;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(442, 35);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 84;
            this.hacLabel3.Text = "Setor";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(246, 35);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 83;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(2, 35);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 82;
            this.hacLabel1.Text = "Unidade";
            // 
            // txtQuartoLeito
            // 
            this.txtQuartoLeito.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtQuartoLeito.BackColor = System.Drawing.Color.Honeydew;
            this.txtQuartoLeito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuartoLeito.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQuartoLeito.Enabled = false;
            this.txtQuartoLeito.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQuartoLeito.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQuartoLeito.Limpar = true;
            this.txtQuartoLeito.Location = new System.Drawing.Point(698, 91);
            this.txtQuartoLeito.Name = "txtQuartoLeito";
            this.txtQuartoLeito.NaoAjustarEdicao = false;
            this.txtQuartoLeito.Obrigatorio = false;
            this.txtQuartoLeito.ObrigatorioMensagem = null;
            this.txtQuartoLeito.PreValidacaoMensagem = null;
            this.txtQuartoLeito.PreValidado = false;
            this.txtQuartoLeito.ReadOnly = true;
            this.txtQuartoLeito.SelectAllOnFocus = false;
            this.txtQuartoLeito.Size = new System.Drawing.Size(80, 21);
            this.txtQuartoLeito.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Quarto/Leito";
            // 
            // txtLocal
            // 
            this.txtLocal.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtLocal.BackColor = System.Drawing.Color.Honeydew;
            this.txtLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtLocal.Enabled = false;
            this.txtLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtLocal.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtLocal.Limpar = true;
            this.txtLocal.Location = new System.Drawing.Point(492, 90);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.NaoAjustarEdicao = false;
            this.txtLocal.Obrigatorio = false;
            this.txtLocal.ObrigatorioMensagem = null;
            this.txtLocal.PreValidacaoMensagem = null;
            this.txtLocal.PreValidado = false;
            this.txtLocal.ReadOnly = true;
            this.txtLocal.SelectAllOnFocus = false;
            this.txtLocal.Size = new System.Drawing.Size(137, 21);
            this.txtLocal.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Local";
            // 
            // txtNomeConvenio
            // 
            this.txtNomeConvenio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomeConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeConvenio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNomeConvenio.Enabled = false;
            this.txtNomeConvenio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNomeConvenio.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomeConvenio.Limpar = true;
            this.txtNomeConvenio.Location = new System.Drawing.Point(151, 90);
            this.txtNomeConvenio.Name = "txtNomeConvenio";
            this.txtNomeConvenio.NaoAjustarEdicao = false;
            this.txtNomeConvenio.Obrigatorio = false;
            this.txtNomeConvenio.ObrigatorioMensagem = null;
            this.txtNomeConvenio.PreValidacaoMensagem = null;
            this.txtNomeConvenio.PreValidado = false;
            this.txtNomeConvenio.ReadOnly = true;
            this.txtNomeConvenio.SelectAllOnFocus = false;
            this.txtNomeConvenio.Size = new System.Drawing.Size(293, 21);
            this.txtNomeConvenio.TabIndex = 90;
            // 
            // txtCodConvenio
            // 
            this.txtCodConvenio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodConvenio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCodConvenio.Enabled = false;
            this.txtCodConvenio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtCodConvenio.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodConvenio.Limpar = true;
            this.txtCodConvenio.Location = new System.Drawing.Point(82, 90);
            this.txtCodConvenio.Name = "txtCodConvenio";
            this.txtCodConvenio.NaoAjustarEdicao = false;
            this.txtCodConvenio.Obrigatorio = false;
            this.txtCodConvenio.ObrigatorioMensagem = "";
            this.txtCodConvenio.PreValidacaoMensagem = null;
            this.txtCodConvenio.PreValidado = false;
            this.txtCodConvenio.ReadOnly = true;
            this.txtCodConvenio.SelectAllOnFocus = false;
            this.txtCodConvenio.Size = new System.Drawing.Size(65, 21);
            this.txtCodConvenio.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Conv�nio";
            // 
            // grbFiltrarMTMD
            // 
            this.grbFiltrarMTMD.Controls.Add(this.rbAcs);
            this.grbFiltrarMTMD.Controls.Add(this.rbHac);
            this.grbFiltrarMTMD.Enabled = false;
            this.grbFiltrarMTMD.Location = new System.Drawing.Point(657, 112);
            this.grbFiltrarMTMD.Name = "grbFiltrarMTMD";
            this.grbFiltrarMTMD.Size = new System.Drawing.Size(121, 36);
            this.grbFiltrarMTMD.TabIndex = 95;
            this.grbFiltrarMTMD.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbAcs.Limpar = true;
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
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbHac.Limpar = true;
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
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(2, 66);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(79, 13);
            this.hacLabel4.TabIndex = 97;
            this.hacLabel4.Text = "Atendimento";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(149, 66);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(55, 13);
            this.hacLabel5.TabIndex = 98;
            this.hacLabel5.Text = "Paciente";
            // 
            // tabConsumo
            // 
            this.tabConsumo.Controls.Add(this.tabPage2);
            this.tabConsumo.Location = new System.Drawing.Point(3, 154);
            this.tabConsumo.Name = "tabConsumo";
            this.tabConsumo.SelectedIndex = 0;
            this.tabConsumo.Size = new System.Drawing.Size(775, 317);
            this.tabConsumo.TabIndex = 100;
            this.tabConsumo.SelectedIndexChanged += new System.EventHandler(this.tabConsumo_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblLegenda);
            this.tabPage2.Controls.Add(this.dtgHistConsumo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hist�rico de Consumo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblLegenda
            // 
            this.lblLegenda.AutoSize = true;
            this.lblLegenda.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblLegenda.Location = new System.Drawing.Point(6, 273);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(423, 12);
            this.lblLegenda.TabIndex = 122;
            this.lblLegenda.Text = "* Os itens que est�o em amarelo j� foram faturados e n�o podem serem estornados";
            this.lblLegenda.Visible = false;
            // 
            // dtgHistConsumo
            // 
            this.dtgHistConsumo.AllowUserToAddRows = false;
            this.dtgHistConsumo.AllowUserToDeleteRows = false;
            this.dtgHistConsumo.AllowUserToResizeColumns = false;
            this.dtgHistConsumo.AllowUserToResizeRows = false;
            this.dtgHistConsumo.AlterarStatus = true;
            this.dtgHistConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgHistConsumo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgHistConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistConsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtMovimentoHist,
            this.colSubTpMov,
            this.colIdtProdutoHist,
            this.colDeletarHist,
            this.colDataHist,
            this.colDsProdutoHist,
            this.colLoteFab,
            this.colMAV,
            this.colQtdHist,
            this.colQtdInteiraHist,
            this.colFaturado,
            this.colDataRessup,
            this.colIdFilial,
            this.colDsQtdeConvertida,
            this.colPedido});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHistConsumo.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtgHistConsumo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgHistConsumo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgHistConsumo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgHistConsumo.GridPesquisa = false;
            this.dtgHistConsumo.Limpar = true;
            this.dtgHistConsumo.Location = new System.Drawing.Point(6, 6);
            this.dtgHistConsumo.Name = "dtgHistConsumo";
            this.dtgHistConsumo.NaoAjustarEdicao = false;
            this.dtgHistConsumo.Obrigatorio = false;
            this.dtgHistConsumo.ObrigatorioMensagem = null;
            this.dtgHistConsumo.PreValidacaoMensagem = null;
            this.dtgHistConsumo.PreValidado = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dtgHistConsumo.RowHeadersWidth = 25;
            this.dtgHistConsumo.Size = new System.Drawing.Size(755, 265);
            this.dtgHistConsumo.TabIndex = 81;
            this.dtgHistConsumo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHistConsumo_CellDoubleClick);
            this.dtgHistConsumo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgHistConsumo_CellFormatting);
            // 
            // colIdtMovimentoHist
            // 
            this.colIdtMovimentoHist.HeaderText = "IdtMovimentoHist";
            this.colIdtMovimentoHist.Name = "colIdtMovimentoHist";
            this.colIdtMovimentoHist.ReadOnly = true;
            this.colIdtMovimentoHist.Visible = false;
            // 
            // colSubTpMov
            // 
            this.colSubTpMov.HeaderText = "colSubTpMov";
            this.colSubTpMov.Name = "colSubTpMov";
            this.colSubTpMov.Visible = false;
            // 
            // colIdtProdutoHist
            // 
            this.colIdtProdutoHist.HeaderText = "IdtProdutoHist";
            this.colIdtProdutoHist.Name = "colIdtProdutoHist";
            this.colIdtProdutoHist.Visible = false;
            // 
            // colDeletarHist
            // 
            this.colDeletarHist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDeletarHist.HeaderText = "Excluir";
            this.colDeletarHist.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDeletarHist.Name = "colDeletarHist";
            this.colDeletarHist.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDeletarHist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeletarHist.ToolTipText = "Excluir Linha";
            this.colDeletarHist.Width = 45;
            // 
            // colDataHist
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataHist.DefaultCellStyle = dataGridViewCellStyle12;
            this.colDataHist.HeaderText = "Data Consumo";
            this.colDataHist.Name = "colDataHist";
            this.colDataHist.ReadOnly = true;
            this.colDataHist.Width = 120;
            // 
            // colDsProdutoHist
            // 
            this.colDsProdutoHist.HeaderText = "Descri��o do Item";
            this.colDsProdutoHist.Name = "colDsProdutoHist";
            this.colDsProdutoHist.ReadOnly = true;
            this.colDsProdutoHist.Width = 310;
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
            this.colMAV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMAV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMAV.TrueValue = "S";
            this.colMAV.Width = 35;
            // 
            // colQtdHist
            // 
            this.colQtdHist.HeaderText = "Consumo";
            this.colQtdHist.Name = "colQtdHist";
            this.colQtdHist.ReadOnly = true;
            this.colQtdHist.Width = 62;
            // 
            // colQtdInteiraHist
            // 
            this.colQtdInteiraHist.HeaderText = "QtdInteiraHist";
            this.colQtdInteiraHist.Name = "colQtdInteiraHist";
            this.colQtdInteiraHist.Visible = false;
            // 
            // colFaturado
            // 
            this.colFaturado.HeaderText = "Faturado";
            this.colFaturado.Name = "colFaturado";
            this.colFaturado.Visible = false;
            // 
            // colDataRessup
            // 
            this.colDataRessup.HeaderText = "Data Ressup.";
            this.colDataRessup.Name = "colDataRessup";
            this.colDataRessup.ReadOnly = true;
            this.colDataRessup.Visible = false;
            // 
            // colIdFilial
            // 
            this.colIdFilial.HeaderText = "colIdFilial";
            this.colIdFilial.Name = "colIdFilial";
            this.colIdFilial.ReadOnly = true;
            this.colIdFilial.Visible = false;
            // 
            // colDsQtdeConvertida
            // 
            this.colDsQtdeConvertida.HeaderText = "Convers�o";
            this.colDsQtdeConvertida.Name = "colDsQtdeConvertida";
            this.colDsQtdeConvertida.ReadOnly = true;
            this.colDsQtdeConvertida.Width = 65;
            // 
            // colPedido
            // 
            this.colPedido.HeaderText = "Pedido (Baixa Direta)";
            this.colPedido.Name = "colPedido";
            this.colPedido.ReadOnly = true;
            this.colPedido.Width = 130;
            // 
            // cbCE
            // 
            this.cbCE.AutoSize = true;
            this.cbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCE.Limpar = false;
            this.cbCE.Location = new System.Drawing.Point(261, 122);
            this.cbCE.Name = "cbCE";
            this.cbCE.Obrigatorio = false;
            this.cbCE.ObrigatorioMensagem = null;
            this.cbCE.PreValidacaoMensagem = null;
            this.cbCE.PreValidado = false;
            this.cbCE.Size = new System.Drawing.Size(197, 17);
            this.cbCE.TabIndex = 101;
            this.cbCE.Text = "CARRINHO DE EMERG�NCIA";
            this.cbCE.UseVisualStyleBackColor = true;
            this.cbCE.Click += new System.EventHandler(this.cbCE_Click);
            // 
            // chkFracionar
            // 
            this.chkFracionar.AutoSize = true;
            this.chkFracionar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkFracionar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkFracionar.Limpar = false;
            this.chkFracionar.Location = new System.Drawing.Point(7, 498);
            this.chkFracionar.Name = "chkFracionar";
            this.chkFracionar.Obrigatorio = false;
            this.chkFracionar.ObrigatorioMensagem = null;
            this.chkFracionar.PreValidacaoMensagem = null;
            this.chkFracionar.PreValidado = false;
            this.chkFracionar.Size = new System.Drawing.Size(182, 17);
            this.chkFracionar.TabIndex = 103;
            this.chkFracionar.Text = "Fracionar Pr�ximo Produto Inteiro";
            this.chkFracionar.UseVisualStyleBackColor = true;
            // 
            // lblContaFaturada
            // 
            this.lblContaFaturada.AutoSize = true;
            this.lblContaFaturada.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblContaFaturada.ForeColor = System.Drawing.Color.Red;
            this.lblContaFaturada.Location = new System.Drawing.Point(4, 474);
            this.lblContaFaturada.Name = "lblContaFaturada";
            this.lblContaFaturada.Size = new System.Drawing.Size(163, 18);
            this.lblContaFaturada.TabIndex = 108;
            this.lblContaFaturada.Text = "CONTA FATURADA";
            this.lblContaFaturada.Visible = false;
            // 
            // txtDtTranf
            // 
            this.txtDtTranf.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDtTranf.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtTranf.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDtTranf.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtTranf.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtTranf.Limpar = false;
            this.txtDtTranf.Location = new System.Drawing.Point(409, 475);
            this.txtDtTranf.Name = "txtDtTranf";
            this.txtDtTranf.NaoAjustarEdicao = false;
            this.txtDtTranf.Obrigatorio = false;
            this.txtDtTranf.ObrigatorioMensagem = "";
            this.txtDtTranf.PreValidacaoMensagem = "";
            this.txtDtTranf.PreValidado = false;
            this.txtDtTranf.SelectAllOnFocus = false;
            this.txtDtTranf.Size = new System.Drawing.Size(100, 21);
            this.txtDtTranf.TabIndex = 109;
            this.txtDtTranf.Visible = false;
            // 
            // txtHrTransf
            // 
            this.txtHrTransf.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtHrTransf.BackColor = System.Drawing.Color.Honeydew;
            this.txtHrTransf.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtHrTransf.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtHrTransf.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtHrTransf.Limpar = false;
            this.txtHrTransf.Location = new System.Drawing.Point(515, 475);
            this.txtHrTransf.Name = "txtHrTransf";
            this.txtHrTransf.NaoAjustarEdicao = false;
            this.txtHrTransf.Obrigatorio = false;
            this.txtHrTransf.ObrigatorioMensagem = "";
            this.txtHrTransf.PreValidacaoMensagem = "";
            this.txtHrTransf.PreValidado = false;
            this.txtHrTransf.SelectAllOnFocus = false;
            this.txtHrTransf.Size = new System.Drawing.Size(100, 21);
            this.txtHrTransf.TabIndex = 110;
            this.txtHrTransf.Visible = false;
            // 
            // grpTipoAtendimento
            // 
            this.grpTipoAtendimento.Controls.Add(this.rbAmbulatorio);
            this.grpTipoAtendimento.Controls.Add(this.rbInternado);
            this.grpTipoAtendimento.Location = new System.Drawing.Point(627, 53);
            this.grpTipoAtendimento.Name = "grpTipoAtendimento";
            this.grpTipoAtendimento.Size = new System.Drawing.Size(149, 33);
            this.grpTipoAtendimento.TabIndex = 124;
            this.grpTipoAtendimento.TabStop = false;
            this.grpTipoAtendimento.Text = "Tipo de Atendimento";
            // 
            // rbAmbulatorio
            // 
            this.rbAmbulatorio.AutoSize = true;
            this.rbAmbulatorio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAmbulatorio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAmbulatorio.Limpar = false;
            this.rbAmbulatorio.Location = new System.Drawing.Point(79, 14);
            this.rbAmbulatorio.Name = "rbAmbulatorio";
            this.rbAmbulatorio.Obrigatorio = false;
            this.rbAmbulatorio.ObrigatorioMensagem = null;
            this.rbAmbulatorio.PreValidacaoMensagem = null;
            this.rbAmbulatorio.PreValidado = false;
            this.rbAmbulatorio.Size = new System.Drawing.Size(61, 17);
            this.rbAmbulatorio.TabIndex = 1;
            this.rbAmbulatorio.TabStop = true;
            this.rbAmbulatorio.Text = "Externo";
            this.rbAmbulatorio.UseVisualStyleBackColor = true;
            // 
            // rbInternado
            // 
            this.rbInternado.AutoSize = true;
            this.rbInternado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbInternado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbInternado.Limpar = false;
            this.rbInternado.Location = new System.Drawing.Point(13, 14);
            this.rbInternado.Name = "rbInternado";
            this.rbInternado.Obrigatorio = false;
            this.rbInternado.ObrigatorioMensagem = null;
            this.rbInternado.PreValidacaoMensagem = null;
            this.rbInternado.PreValidado = false;
            this.rbInternado.Size = new System.Drawing.Size(58, 17);
            this.rbInternado.TabIndex = 0;
            this.rbInternado.TabStop = true;
            this.rbInternado.Text = "Interno";
            this.rbInternado.UseVisualStyleBackColor = true;
            // 
            // lblEU
            // 
            this.lblEU.AutoSize = true;
            this.lblEU.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEU.ForeColor = System.Drawing.Color.Green;
            this.lblEU.Location = new System.Drawing.Point(598, 150);
            this.lblEU.Name = "lblEU";
            this.lblEU.Size = new System.Drawing.Size(179, 17);
            this.lblEU.TabIndex = 126;
            this.lblEU.Text = "ESTOQUE �NICO HAC";
            this.lblEU.Visible = false;
            // 
            // pnlPendentes
            // 
            this.pnlPendentes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendentes.Controls.Add(this.btnRelDevolucao);
            this.pnlPendentes.Controls.Add(this.btnFecharPendentes);
            this.pnlPendentes.Controls.Add(this.lblPend);
            this.pnlPendentes.Controls.Add(this.dtgItensPendentes);
            this.pnlPendentes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPendentes.Location = new System.Drawing.Point(3, 118);
            this.pnlPendentes.Name = "pnlPendentes";
            this.pnlPendentes.Size = new System.Drawing.Size(775, 378);
            this.pnlPendentes.TabIndex = 130;
            this.pnlPendentes.Visible = false;
            // 
            // btnRelDevolucao
            // 
            this.btnRelDevolucao.AlterarStatus = false;
            this.btnRelDevolucao.BackColor = System.Drawing.Color.White;
            this.btnRelDevolucao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRelDevolucao.BackgroundImage")));
            this.btnRelDevolucao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelDevolucao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnRelDevolucao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelDevolucao.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnRelDevolucao.Location = new System.Drawing.Point(527, 8);
            this.btnRelDevolucao.Name = "btnRelDevolucao";
            this.btnRelDevolucao.Size = new System.Drawing.Size(215, 22);
            this.btnRelDevolucao.TabIndex = 131;
            this.btnRelDevolucao.Text = "GERAR RELAT�RIO DEVOLU��O";
            this.btnRelDevolucao.UseVisualStyleBackColor = true;
            this.btnRelDevolucao.Click += new System.EventHandler(this.btnRelDevolucao_Click);
            // 
            // btnFecharPendentes
            // 
            this.btnFecharPendentes.AlterarStatus = false;
            this.btnFecharPendentes.BackColor = System.Drawing.Color.White;
            this.btnFecharPendentes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFecharPendentes.BackgroundImage")));
            this.btnFecharPendentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharPendentes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnFecharPendentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharPendentes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnFecharPendentes.Location = new System.Drawing.Point(751, 0);
            this.btnFecharPendentes.Name = "btnFecharPendentes";
            this.btnFecharPendentes.Size = new System.Drawing.Size(22, 22);
            this.btnFecharPendentes.TabIndex = 110;
            this.btnFecharPendentes.Text = "X";
            this.btnFecharPendentes.UseVisualStyleBackColor = true;
            this.btnFecharPendentes.Click += new System.EventHandler(this.btnFecharPendentes_Click);
            // 
            // lblPend
            // 
            this.lblPend.AutoSize = true;
            this.lblPend.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPend.ForeColor = System.Drawing.Color.Red;
            this.lblPend.Location = new System.Drawing.Point(6, 6);
            this.lblPend.Name = "lblPend";
            this.lblPend.Size = new System.Drawing.Size(249, 22);
            this.lblPend.TabIndex = 72;
            this.lblPend.Text = "PEND�NCIAS PACIENTE";
            // 
            // dtgItensPendentes
            // 
            this.dtgItensPendentes.AllowUserToAddRows = false;
            this.dtgItensPendentes.AlterarStatus = true;
            this.dtgItensPendentes.BackgroundColor = System.Drawing.Color.White;
            this.dtgItensPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItensPendentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDsMatMedPend,
            this.dataGridViewCheckBoxColumn1,
            this.colMatMedIdtPend,
            this.colQtdForn,
            this.colQtdCons,
            this.colQtdPendente,
            this.colSetor});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItensPendentes.DefaultCellStyle = dataGridViewCellStyle19;
            this.dtgItensPendentes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgItensPendentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItensPendentes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItensPendentes.GridPesquisa = false;
            this.dtgItensPendentes.Limpar = true;
            this.dtgItensPendentes.Location = new System.Drawing.Point(9, 36);
            this.dtgItensPendentes.MultiSelect = false;
            this.dtgItensPendentes.Name = "dtgItensPendentes";
            this.dtgItensPendentes.NaoAjustarEdicao = false;
            this.dtgItensPendentes.Obrigatorio = false;
            this.dtgItensPendentes.ObrigatorioMensagem = null;
            this.dtgItensPendentes.PreValidacaoMensagem = null;
            this.dtgItensPendentes.PreValidado = false;
            this.dtgItensPendentes.ReadOnly = true;
            this.dtgItensPendentes.RowHeadersVisible = false;
            this.dtgItensPendentes.RowHeadersWidth = 25;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgItensPendentes.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dtgItensPendentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItensPendentes.Size = new System.Drawing.Size(754, 327);
            this.dtgItensPendentes.TabIndex = 71;
            this.dtgItensPendentes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItensPendentes_CellDoubleClick);
            // 
            // colDsMatMedPend
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDsMatMedPend.DefaultCellStyle = dataGridViewCellStyle15;
            this.colDsMatMedPend.HeaderText = "Descri��o do Mat/Med";
            this.colDsMatMedPend.Name = "colDsMatMedPend";
            this.colDsMatMedPend.ReadOnly = true;
            this.colDsMatMedPend.Width = 270;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "N";
            this.dataGridViewCheckBoxColumn1.HeaderText = "MAR";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.TrueValue = "S";
            this.dataGridViewCheckBoxColumn1.Width = 35;
            // 
            // colMatMedIdtPend
            // 
            this.colMatMedIdtPend.HeaderText = "colMatMedIdtPend";
            this.colMatMedIdtPend.Name = "colMatMedIdtPend";
            this.colMatMedIdtPend.ReadOnly = true;
            this.colMatMedIdtPend.Visible = false;
            // 
            // colQtdForn
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = null;
            this.colQtdForn.DefaultCellStyle = dataGridViewCellStyle16;
            this.colQtdForn.HeaderText = "Qtd. Forn.";
            this.colQtdForn.Name = "colQtdForn";
            this.colQtdForn.ReadOnly = true;
            this.colQtdForn.Width = 90;
            // 
            // colQtdCons
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = null;
            this.colQtdCons.DefaultCellStyle = dataGridViewCellStyle17;
            this.colQtdCons.HeaderText = "Qtd. Consumo";
            this.colQtdCons.Name = "colQtdCons";
            this.colQtdCons.ReadOnly = true;
            this.colQtdCons.Width = 115;
            // 
            // colQtdPendente
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.Format = "N0";
            this.colQtdPendente.DefaultCellStyle = dataGridViewCellStyle18;
            this.colQtdPendente.HeaderText = "Qtd. Pendente";
            this.colQtdPendente.Name = "colQtdPendente";
            this.colQtdPendente.ReadOnly = true;
            this.colQtdPendente.Width = 115;
            // 
            // colSetor
            // 
            this.colSetor.HeaderText = "Setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.ReadOnly = true;
            this.colSetor.Width = 120;
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
            this.dataGridViewImageColumn1.Width = 45;
            // 
            // btnPendentes
            // 
            this.btnPendentes.AlterarStatus = true;
            this.btnPendentes.BackColor = System.Drawing.Color.White;
            this.btnPendentes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPendentes.BackgroundImage")));
            this.btnPendentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPendentes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPendentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendentes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPendentes.Location = new System.Drawing.Point(621, 474);
            this.btnPendentes.Name = "btnPendentes";
            this.btnPendentes.Size = new System.Drawing.Size(155, 22);
            this.btnPendentes.TabIndex = 129;
            this.btnPendentes.Text = "PEND�NCIAS PACIENTE";
            this.btnPendentes.UseVisualStyleBackColor = true;
            this.btnPendentes.Click += new System.EventHandler(this.btnPendentes_Click);
            // 
            // btnRegerarFaturamento
            // 
            this.btnRegerarFaturamento.AlterarStatus = true;
            this.btnRegerarFaturamento.BackColor = System.Drawing.Color.White;
            this.btnRegerarFaturamento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegerarFaturamento.BackgroundImage")));
            this.btnRegerarFaturamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegerarFaturamento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnRegerarFaturamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegerarFaturamento.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnRegerarFaturamento.Location = new System.Drawing.Point(673, 521);
            this.btnRegerarFaturamento.Name = "btnRegerarFaturamento";
            this.btnRegerarFaturamento.Size = new System.Drawing.Size(105, 34);
            this.btnRegerarFaturamento.TabIndex = 125;
            this.btnRegerarFaturamento.Text = "REENVIAR FATURAMENTO";
            this.btnRegerarFaturamento.UseVisualStyleBackColor = true;
            this.btnRegerarFaturamento.Visible = false;
            this.btnRegerarFaturamento.Click += new System.EventHandler(this.btnRegerarFaturamento_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.AlterarStatus = true;
            this.btnHistorico.BackColor = System.Drawing.Color.White;
            this.btnHistorico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHistorico.BackgroundImage")));
            this.btnHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnHistorico.Location = new System.Drawing.Point(134, 149);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(105, 22);
            this.btnHistorico.TabIndex = 123;
            this.btnHistorico.Text = "Hist�rico";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // btnFinalizarCE
            // 
            this.btnFinalizarCE.AlterarStatus = true;
            this.btnFinalizarCE.BackColor = System.Drawing.Color.White;
            this.btnFinalizarCE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFinalizarCE.BackgroundImage")));
            this.btnFinalizarCE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizarCE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnFinalizarCE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarCE.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnFinalizarCE.Location = new System.Drawing.Point(260, 142);
            this.btnFinalizarCE.Name = "btnFinalizarCE";
            this.btnFinalizarCE.Size = new System.Drawing.Size(277, 22);
            this.btnFinalizarCE.TabIndex = 102;
            this.btnFinalizarCE.Text = "Finalizar Consumo do Carrinho de Emerg�ncia";
            this.btnFinalizarCE.UseVisualStyleBackColor = true;
            this.btnFinalizarCE.Visible = false;
            this.btnFinalizarCE.Click += new System.EventHandler(this.btnFinalizarCE_Click);
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = "txtNroInternacao";
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 99;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Consumo Paciente";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.ImprimirClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_ImprimirClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            this.tsHac.SairClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SairClick);
            // 
            // btnPesquisaPac
            // 
            this.btnPesquisaPac.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.btnPesquisaPac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaPac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaPac.Location = new System.Drawing.Point(573, 62);
            this.btnPesquisaPac.Name = "btnPesquisaPac";
            this.btnPesquisaPac.Size = new System.Drawing.Size(34, 21);
            this.btnPesquisaPac.TabIndex = 72;
            this.btnPesquisaPac.TabStop = false;
            this.btnPesquisaPac.Click += new System.EventHandler(this.btnPesquisaPac_Click);
            // 
            // cbApenasFaturar
            // 
            this.cbApenasFaturar.AutoSize = true;
            this.cbApenasFaturar.Checked = true;
            this.cbApenasFaturar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbApenasFaturar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cbApenasFaturar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbApenasFaturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApenasFaturar.Limpar = false;
            this.cbApenasFaturar.Location = new System.Drawing.Point(515, 122);
            this.cbApenasFaturar.Name = "cbApenasFaturar";
            this.cbApenasFaturar.Obrigatorio = false;
            this.cbApenasFaturar.ObrigatorioMensagem = null;
            this.cbApenasFaturar.PreValidacaoMensagem = null;
            this.cbApenasFaturar.PreValidado = false;
            this.cbApenasFaturar.Size = new System.Drawing.Size(137, 17);
            this.cbApenasFaturar.TabIndex = 132;
            this.cbApenasFaturar.Text = "APENAS FATURAR";
            this.cbApenasFaturar.UseVisualStyleBackColor = true;
            this.cbApenasFaturar.Visible = false;
            this.cbApenasFaturar.Click += new System.EventHandler(this.cbApenasFaturar_Click);
            // 
            // grbCE
            // 
            this.grbCE.Controls.Add(this.btnFecharCE);
            this.grbCE.Controls.Add(this.cmbCE);
            this.grbCE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCE.Location = new System.Drawing.Point(254, 117);
            this.grbCE.Name = "grbCE";
            this.grbCE.Size = new System.Drawing.Size(324, 43);
            this.grbCE.TabIndex = 133;
            this.grbCE.TabStop = false;
            this.grbCE.Text = " Selecione o Carrinho de Emerg�ncia ";
            this.grbCE.Visible = false;
            // 
            // btnFecharCE
            // 
            this.btnFecharCE.AlterarStatus = false;
            this.btnFecharCE.BackColor = System.Drawing.Color.White;
            this.btnFecharCE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFecharCE.BackgroundImage")));
            this.btnFecharCE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharCE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnFecharCE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharCE.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnFecharCE.Location = new System.Drawing.Point(297, 11);
            this.btnFecharCE.Name = "btnFecharCE";
            this.btnFecharCE.Size = new System.Drawing.Size(22, 22);
            this.btnFecharCE.TabIndex = 128;
            this.btnFecharCE.Text = "X";
            this.btnFecharCE.UseVisualStyleBackColor = true;
            this.btnFecharCE.Click += new System.EventHandler(this.btnFecharCE_Click);
            // 
            // cmbCE
            // 
            this.cmbCE.BackColor = System.Drawing.Color.Honeydew;
            this.cmbCE.DisplayMember = "CAD_SET_DS_SETOR";
            this.cmbCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbCE.FormattingEnabled = true;
            this.cmbCE.Limpar = false;
            this.cmbCE.Location = new System.Drawing.Point(10, 17);
            this.cmbCE.MaxDropDownItems = 10;
            this.cmbCE.Name = "cmbCE";
            this.cmbCE.Obrigatorio = false;
            this.cmbCE.ObrigatorioMensagem = null;
            this.cmbCE.PreValidacaoMensagem = null;
            this.cmbCE.PreValidado = false;
            this.cmbCE.Size = new System.Drawing.Size(282, 21);
            this.cmbCE.TabIndex = 127;
            this.cmbCE.ValueMember = "CAD_SET_ID";
            this.cmbCE.SelectionChangeCommitted += new System.EventHandler(this.cmbCE_SelectionChangeCommitted);
            // 
            // cbDigitar
            // 
            this.cbDigitar.AutoSize = true;
            this.cbDigitar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbDigitar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbDigitar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDigitar.Limpar = true;
            this.cbDigitar.Location = new System.Drawing.Point(512, 122);
            this.cbDigitar.Name = "cbDigitar";
            this.cbDigitar.Obrigatorio = false;
            this.cbDigitar.ObrigatorioMensagem = null;
            this.cbDigitar.PreValidacaoMensagem = null;
            this.cbDigitar.PreValidado = false;
            this.cbDigitar.Size = new System.Drawing.Size(123, 17);
            this.cbDigitar.TabIndex = 175;
            this.cbDigitar.Text = "DIGITAR QTDE.";
            this.cbDigitar.UseVisualStyleBackColor = true;
            this.cbDigitar.Visible = false;
            this.cbDigitar.Click += new System.EventHandler(this.cbDigitar_Click);
            // 
            // cbConsignado
            // 
            this.cbConsignado.AutoSize = true;
            this.cbConsignado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbConsignado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbConsignado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConsignado.Limpar = true;
            this.cbConsignado.Location = new System.Drawing.Point(661, 33);
            this.cbConsignado.Name = "cbConsignado";
            this.cbConsignado.Obrigatorio = false;
            this.cbConsignado.ObrigatorioMensagem = null;
            this.cbConsignado.PreValidacaoMensagem = null;
            this.cbConsignado.PreValidado = false;
            this.cbConsignado.Size = new System.Drawing.Size(111, 17);
            this.cbConsignado.TabIndex = 176;
            this.cbConsignado.Text = "CONSIGNADO";
            this.cbConsignado.UseVisualStyleBackColor = true;
            this.cbConsignado.Visible = false;
            this.cbConsignado.Click += new System.EventHandler(this.cbConsignado_Click);
            // 
            // FrmConsumoPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 556);
            this.Controls.Add(this.cbConsignado);
            this.Controls.Add(this.cbDigitar);
            this.Controls.Add(this.grbCE);
            this.Controls.Add(this.pnlPendentes);
            this.Controls.Add(this.btnPendentes);
            this.Controls.Add(this.lblEU);
            this.Controls.Add(this.btnRegerarFaturamento);
            this.Controls.Add(this.cbApenasFaturar);
            this.Controls.Add(this.grpTipoAtendimento);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.txtHrTransf);
            this.Controls.Add(this.txtDtTranf);
            this.Controls.Add(this.lblContaFaturada);
            this.Controls.Add(this.chkFracionar);
            this.Controls.Add(this.btnFinalizarCE);
            this.Controls.Add(this.cbCE);
            this.Controls.Add(this.tabConsumo);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.grbFiltrarMTMD);
            this.Controls.Add(this.txtQuartoLeito);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNomeConvenio);
            this.Controls.Add(this.txtCodConvenio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.lblCodProd);
            this.Controls.Add(this.btnPesquisaPac);
            this.Controls.Add(this.txtNomePac);
            this.Controls.Add(this.txtNroInternacao);
            this.Name = "FrmConsumoPaciente";
            this.Text = "Gest�o de Materiais e Medicamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsumoPaciente_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsumoPaciente_Load);
            this.grbFiltrarMTMD.ResumeLayout(false);
            this.grbFiltrarMTMD.PerformLayout();
            this.tabConsumo.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).EndInit();
            this.grpTipoAtendimento.ResumeLayout(false);
            this.grpTipoAtendimento.PerformLayout();
            this.pnlPendentes.ResumeLayout(false);
            this.pnlPendentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensPendentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).EndInit();
            this.grbCE.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnPesquisaPac;
        private HacTextBox txtNomePac;
        private HacTextBox txtNroInternacao;
        private HacTextBox txtCodProduto;
        private System.Windows.Forms.Label lblCodProd;
        private HacCmbSetor cmbSetor;
        private HacCmbLocal cmbLocal;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel3;
        private HacLabel hacLabel2;
        private HacLabel hacLabel1;
        private HacTextBox txtQuartoLeito;
        private System.Windows.Forms.Label label5;
        private HacTextBox txtLocal;
        private System.Windows.Forms.Label label4;
        private HacTextBox txtNomeConvenio;
        private HacTextBox txtCodConvenio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbFiltrarMTMD;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacLabel hacLabel4;
        private HacLabel hacLabel5;
        private HacToolStrip tsHac;
        private System.Windows.Forms.TabControl tabConsumo;
        private System.Windows.Forms.TabPage tabPage2;
        private HacDataGridView dtgHistConsumo;
        private HacLabel lblLegenda;
        private HacCheckBox cbCE;
        private HacButton btnFinalizarCE;
        private HacCheckBox chkFracionar;
        private HacLabel lblContaFaturada;
        private HacTextBox txtDtTranf;
        private HacTextBox txtHrTransf;
        private HacButton btnHistorico;
        private System.Windows.Forms.GroupBox grpTipoAtendimento;
        private HacRadioButton rbAmbulatorio;
        private HacRadioButton rbInternado;
        private HacButton btnRegerarFaturamento;
        private HacLabel lblEU;
        private HacButton btnPendentes;
        private System.Windows.Forms.Panel pnlPendentes;
        private HacButton btnFecharPendentes;
        private HacLabel lblPend;
        private HacDataGridView dtgItensPendentes;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private HacButton btnRelDevolucao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsMatMedPend;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdtPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdForn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdCons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdPendente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtMovimentoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTpMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProdutoHist;
        private System.Windows.Forms.DataGridViewImageColumn colDeletarHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProdutoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoteFab;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdInteiraHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFaturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataRessup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsQtdeConvertida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedido;
        private HacCheckBox cbApenasFaturar;
        private System.Windows.Forms.GroupBox grbCE;
        private HacComboBox cmbCE;
        private HacButton btnFecharCE;
        private HacCheckBox cbDigitar;
        private HacCheckBox cbConsignado;
    }
}
