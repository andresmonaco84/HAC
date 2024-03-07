using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmDispKitCirurgico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDispKitCirurgico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPesquisaPac = new System.Windows.Forms.PictureBox();
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
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.tabConsumo = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgHistConsumo = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdtMovimentoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTpMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeletarHist = new System.Windows.Forms.DataGridViewImageColumn();
            this.colChkExcluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDataHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdInteiraHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFaturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataRessup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsQtdeConvertida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbCE = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnFinalizarCE = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.chkFracionar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnExcluir = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtDtTranf = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtHrTransf = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblContaFaturada = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblItensNaoSalvos = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chkExcluirProximo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.txtDscPesquisa = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnHistorico = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnPendencia = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).BeginInit();
            this.grbFiltrarMTMD.SuspendLayout();
            this.tabConsumo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisaPac
            // 
            this.btnPesquisaPac.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.btnPesquisaPac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaPac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaPac.Location = new System.Drawing.Point(635, 63);
            this.btnPesquisaPac.Name = "btnPesquisaPac";
            this.btnPesquisaPac.Size = new System.Drawing.Size(34, 21);
            this.btnPesquisaPac.TabIndex = 72;
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
            this.txtNomePac.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomePac.Limpar = true;
            this.txtNomePac.Location = new System.Drawing.Point(248, 63);
            this.txtNomePac.Name = "txtNomePac";
            this.txtNomePac.NaoAjustarEdicao = false;
            this.txtNomePac.Obrigatorio = false;
            this.txtNomePac.ObrigatorioMensagem = null;
            this.txtNomePac.PreValidacaoMensagem = null;
            this.txtNomePac.PreValidado = false;
            this.txtNomePac.SelectAllOnFocus = false;
            this.txtNomePac.Size = new System.Drawing.Size(381, 21);
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
            this.txtNroInternacao.Size = new System.Drawing.Size(100, 21);
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
            this.txtCodProduto.Obrigatorio = false;
            this.txtCodProduto.ObrigatorioMensagem = "Código Obrigatorio";
            this.txtCodProduto.PreValidacaoMensagem = null;
            this.txtCodProduto.PreValidado = false;
            this.txtCodProduto.SelectAllOnFocus = false;
            this.txtCodProduto.Size = new System.Drawing.Size(173, 21);
            this.txtCodProduto.TabIndex = 74;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProduto.Enter += new System.EventHandler(this.txtCodProduto_Enter);
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
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(605, 35);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = false;
            this.cmbSetor.ObrigatorioMensagem = null;
            this.cmbSetor.PreValidacaoMensagem = "Setor não pode estar em branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(170, 21);
            this.cmbSetor.TabIndex = 87;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(337, 35);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = false;
            this.cmbLocal.ObrigatorioMensagem = null;
            this.cmbLocal.PreValidacaoMensagem = "Local de atendimento não pode estar em branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(170, 21);
            this.cmbLocal.TabIndex = 86;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
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
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(82, 35);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = false;
            this.cmbUnidade.ObrigatorioMensagem = null;
            this.cmbUnidade.PreValidacaoMensagem = "Unidade não pode estar em branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(170, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 85;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(561, 38);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 84;
            this.hacLabel3.Text = "Setor";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(295, 38);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 83;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(2, 38);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 82;
            this.hacLabel1.Text = "Unidade";
            this.hacLabel1.DoubleClick += new System.EventHandler(this.hacLabel1_DoubleClick);
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
            this.txtLocal.Location = new System.Drawing.Point(501, 90);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.NaoAjustarEdicao = false;
            this.txtLocal.Obrigatorio = false;
            this.txtLocal.ObrigatorioMensagem = null;
            this.txtLocal.PreValidacaoMensagem = null;
            this.txtLocal.PreValidado = false;
            this.txtLocal.ReadOnly = true;
            this.txtLocal.SelectAllOnFocus = false;
            this.txtLocal.Size = new System.Drawing.Size(128, 21);
            this.txtLocal.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 94);
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
            this.txtNomeConvenio.Location = new System.Drawing.Point(187, 90);
            this.txtNomeConvenio.Name = "txtNomeConvenio";
            this.txtNomeConvenio.NaoAjustarEdicao = false;
            this.txtNomeConvenio.Obrigatorio = false;
            this.txtNomeConvenio.ObrigatorioMensagem = null;
            this.txtNomeConvenio.PreValidacaoMensagem = null;
            this.txtNomeConvenio.PreValidado = false;
            this.txtNomeConvenio.ReadOnly = true;
            this.txtNomeConvenio.SelectAllOnFocus = false;
            this.txtNomeConvenio.Size = new System.Drawing.Size(277, 21);
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
            this.txtCodConvenio.Size = new System.Drawing.Size(100, 21);
            this.txtCodConvenio.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Convênio";
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
            this.hacLabel5.Location = new System.Drawing.Point(187, 66);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(55, 13);
            this.hacLabel5.TabIndex = 98;
            this.hacLabel5.Text = "Paciente";
            // 
            // tsHac
            // 
            this.tsHac.BackColor = System.Drawing.SystemColors.Control;
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = "txtNroInternacao";
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 99;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Dispensação KIT  Centro Cirurgico";
            this.tsHac.SairClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SairClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
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
            this.tabPage2.Controls.Add(this.dtgHistConsumo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Histórico de Consumo";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dtgHistConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistConsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtMovimentoHist,
            this.colSubTpMov,
            this.colIdtProdutoHist,
            this.colDeletarHist,
            this.colChkExcluir,
            this.colDataHist,
            this.colDsProdutoHist,
            this.colQtdHist,
            this.colQtdInteiraHist,
            this.colFaturado,
            this.colDataRessup,
            this.colIdFilial,
            this.colDsQtdeConvertida});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHistConsumo.DefaultCellStyle = dataGridViewCellStyle19;
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
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dtgHistConsumo.RowHeadersVisible = false;
            this.dtgHistConsumo.RowHeadersWidth = 21;
            this.dtgHistConsumo.RowTemplate.Height = 18;
            this.dtgHistConsumo.Size = new System.Drawing.Size(755, 282);
            this.dtgHistConsumo.TabIndex = 81;
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
            this.colDeletarHist.Visible = false;
            this.colDeletarHist.Width = 50;
            // 
            // colChkExcluir
            // 
            this.colChkExcluir.HeaderText = "Excluir";
            this.colChkExcluir.Name = "colChkExcluir";
            this.colChkExcluir.Width = 50;
            // 
            // colDataHist
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataHist.DefaultCellStyle = dataGridViewCellStyle18;
            this.colDataHist.HeaderText = "Data Consumo";
            this.colDataHist.Name = "colDataHist";
            this.colDataHist.ReadOnly = true;
            this.colDataHist.Width = 120;
            // 
            // colDsProdutoHist
            // 
            this.colDsProdutoHist.HeaderText = "Descrição do Produto";
            this.colDsProdutoHist.Name = "colDsProdutoHist";
            this.colDsProdutoHist.ReadOnly = true;
            this.colDsProdutoHist.Width = 340;
            // 
            // colQtdHist
            // 
            this.colQtdHist.HeaderText = "Consumo";
            this.colQtdHist.Name = "colQtdHist";
            this.colQtdHist.ReadOnly = true;
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
            this.colDsQtdeConvertida.HeaderText = "Conversão";
            this.colDsQtdeConvertida.Name = "colDsQtdeConvertida";
            this.colDsQtdeConvertida.ReadOnly = true;
            this.colDsQtdeConvertida.Width = 90;
            // 
            // cbCE
            // 
            this.cbCE.AutoSize = true;
            this.cbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Pesquisa;
            this.cbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCE.Limpar = true;
            this.cbCE.Location = new System.Drawing.Point(7, 500);
            this.cbCE.Name = "cbCE";
            this.cbCE.Obrigatorio = false;
            this.cbCE.ObrigatorioMensagem = null;
            this.cbCE.PreValidacaoMensagem = null;
            this.cbCE.PreValidado = false;
            this.cbCE.Size = new System.Drawing.Size(197, 17);
            this.cbCE.TabIndex = 101;
            this.cbCE.Text = "CARRINHO DE EMERGÊNCIA";
            this.cbCE.UseVisualStyleBackColor = true;
            this.cbCE.Visible = false;
            this.cbCE.Click += new System.EventHandler(this.cbCE_Click);
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
            this.btnFinalizarCE.Location = new System.Drawing.Point(7, 522);
            this.btnFinalizarCE.Name = "btnFinalizarCE";
            this.btnFinalizarCE.Size = new System.Drawing.Size(277, 22);
            this.btnFinalizarCE.TabIndex = 102;
            this.btnFinalizarCE.Text = "Finalizar Consumo do Carrinho de Emergência";
            this.btnFinalizarCE.UseVisualStyleBackColor = true;
            this.btnFinalizarCE.Visible = false;
            this.btnFinalizarCE.Click += new System.EventHandler(this.btnFinalizarCE_Click);
            // 
            // chkFracionar
            // 
            this.chkFracionar.AutoSize = true;
            this.chkFracionar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkFracionar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkFracionar.Limpar = false;
            this.chkFracionar.Location = new System.Drawing.Point(210, 499);
            this.chkFracionar.Name = "chkFracionar";
            this.chkFracionar.Obrigatorio = false;
            this.chkFracionar.ObrigatorioMensagem = null;
            this.chkFracionar.PreValidacaoMensagem = null;
            this.chkFracionar.PreValidado = false;
            this.chkFracionar.Size = new System.Drawing.Size(182, 17);
            this.chkFracionar.TabIndex = 103;
            this.chkFracionar.Text = "Fracionar Próximo Produto Inteiro";
            this.chkFracionar.UseVisualStyleBackColor = true;
            this.chkFracionar.Visible = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.AlterarStatus = true;
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcluir.BackgroundImage")));
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(431, 149);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(184, 22);
            this.btnExcluir.TabIndex = 104;
            this.btnExcluir.Text = "Excluir itens selecionados";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtDtTranf
            // 
            this.txtDtTranf.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDtTranf.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtTranf.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.txtDtTranf.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDtTranf.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtTranf.Limpar = false;
            this.txtDtTranf.Location = new System.Drawing.Point(382, 473);
            this.txtDtTranf.Name = "txtDtTranf";
            this.txtDtTranf.NaoAjustarEdicao = false;
            this.txtDtTranf.Obrigatorio = false;
            this.txtDtTranf.ObrigatorioMensagem = "";
            this.txtDtTranf.PreValidacaoMensagem = "";
            this.txtDtTranf.PreValidado = false;
            this.txtDtTranf.SelectAllOnFocus = false;
            this.txtDtTranf.Size = new System.Drawing.Size(100, 21);
            this.txtDtTranf.TabIndex = 105;
            this.txtDtTranf.Visible = false;
            // 
            // txtHrTransf
            // 
            this.txtHrTransf.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtHrTransf.BackColor = System.Drawing.Color.Honeydew;
            this.txtHrTransf.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.txtHrTransf.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtHrTransf.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtHrTransf.Limpar = false;
            this.txtHrTransf.Location = new System.Drawing.Point(529, 473);
            this.txtHrTransf.Name = "txtHrTransf";
            this.txtHrTransf.NaoAjustarEdicao = false;
            this.txtHrTransf.Obrigatorio = false;
            this.txtHrTransf.ObrigatorioMensagem = "";
            this.txtHrTransf.PreValidacaoMensagem = "";
            this.txtHrTransf.PreValidado = false;
            this.txtHrTransf.SelectAllOnFocus = false;
            this.txtHrTransf.Size = new System.Drawing.Size(100, 21);
            this.txtHrTransf.TabIndex = 106;
            this.txtHrTransf.Visible = false;
            // 
            // lblContaFaturada
            // 
            this.lblContaFaturada.AutoSize = true;
            this.lblContaFaturada.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblContaFaturada.ForeColor = System.Drawing.Color.Red;
            this.lblContaFaturada.Location = new System.Drawing.Point(4, 476);
            this.lblContaFaturada.Name = "lblContaFaturada";
            this.lblContaFaturada.Size = new System.Drawing.Size(163, 18);
            this.lblContaFaturada.TabIndex = 107;
            this.lblContaFaturada.Text = "CONTA FATURADA";
            this.lblContaFaturada.Visible = false;
            // 
            // lblItensNaoSalvos
            // 
            this.lblItensNaoSalvos.AutoSize = true;
            this.lblItensNaoSalvos.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblItensNaoSalvos.ForeColor = System.Drawing.Color.Red;
            this.lblItensNaoSalvos.Location = new System.Drawing.Point(187, 476);
            this.lblItensNaoSalvos.Name = "lblItensNaoSalvos";
            this.lblItensNaoSalvos.Size = new System.Drawing.Size(163, 18);
            this.lblItensNaoSalvos.TabIndex = 108;
            this.lblItensNaoSalvos.Text = "CONTA FATURADA";
            this.lblItensNaoSalvos.Visible = false;
            // 
            // chkExcluirProximo
            // 
            this.chkExcluirProximo.AutoSize = true;
            this.chkExcluirProximo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.chkExcluirProximo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkExcluirProximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExcluirProximo.Limpar = true;
            this.chkExcluirProximo.Location = new System.Drawing.Point(261, 121);
            this.chkExcluirProximo.Name = "chkExcluirProximo";
            this.chkExcluirProximo.Obrigatorio = false;
            this.chkExcluirProximo.ObrigatorioMensagem = null;
            this.chkExcluirProximo.PreValidacaoMensagem = null;
            this.chkExcluirProximo.PreValidado = false;
            this.chkExcluirProximo.Size = new System.Drawing.Size(237, 17);
            this.chkExcluirProximo.TabIndex = 109;
            this.chkExcluirProximo.Text = "EXCLUIR PRÓXIMO(S) PRODUTO(S)";
            this.chkExcluirProximo.UseVisualStyleBackColor = true;
            this.chkExcluirProximo.Click += new System.EventHandler(this.chkExcluirProximo_Click);
            // 
            // txtDscPesquisa
            // 
            this.txtDscPesquisa.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDscPesquisa.BackColor = System.Drawing.Color.Honeydew;
            this.txtDscPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDscPesquisa.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDscPesquisa.Enabled = false;
            this.txtDscPesquisa.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDscPesquisa.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDscPesquisa.Limpar = true;
            this.txtDscPesquisa.Location = new System.Drawing.Point(290, 150);
            this.txtDscPesquisa.MaxLength = 10;
            this.txtDscPesquisa.Name = "txtDscPesquisa";
            this.txtDscPesquisa.NaoAjustarEdicao = true;
            this.txtDscPesquisa.Obrigatorio = false;
            this.txtDscPesquisa.ObrigatorioMensagem = "";
            this.txtDscPesquisa.PreValidacaoMensagem = null;
            this.txtDscPesquisa.PreValidado = false;
            this.txtDscPesquisa.SelectAllOnFocus = false;
            this.txtDscPesquisa.Size = new System.Drawing.Size(130, 21);
            this.txtDscPesquisa.TabIndex = 75;
            this.txtDscPesquisa.TextChanged += new System.EventHandler(this.txtDscPesquisa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "Filtrar pela Descrição do Produto";
            // 
            // btnHistorico
            // 
            this.btnHistorico.AlterarStatus = true;
            this.btnHistorico.BackColor = System.Drawing.Color.White;
            this.btnHistorico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHistorico.BackgroundImage")));
            this.btnHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorico.Enabled = false;
            this.btnHistorico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnHistorico.Location = new System.Drawing.Point(510, 120);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(105, 22);
            this.btnHistorico.TabIndex = 124;
            this.btnHistorico.Text = "Histórico";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // btnPendencia
            // 
            this.btnPendencia.AlterarStatus = true;
            this.btnPendencia.BackColor = System.Drawing.Color.White;
            this.btnPendencia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPendencia.BackgroundImage")));
            this.btnPendencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPendencia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPendencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendencia.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPendencia.Location = new System.Drawing.Point(668, 474);
            this.btnPendencia.Name = "btnPendencia";
            this.btnPendencia.Size = new System.Drawing.Size(105, 22);
            this.btnPendencia.TabIndex = 125;
            this.btnPendencia.Text = "Pendências";
            this.btnPendencia.UseVisualStyleBackColor = true;
            this.btnPendencia.Visible = false;
            // 
            // FrmDispKitCirurgico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 556);
            this.Controls.Add(this.btnPendencia);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDscPesquisa);
            this.Controls.Add(this.chkExcluirProximo);
            this.Controls.Add(this.lblItensNaoSalvos);
            this.Controls.Add(this.lblContaFaturada);
            this.Controls.Add(this.txtHrTransf);
            this.Controls.Add(this.txtDtTranf);
            this.Controls.Add(this.btnExcluir);
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
            this.Name = "FrmDispKitCirurgico";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmConsumoPaciente_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsumoPaciente_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).EndInit();
            this.grbFiltrarMTMD.ResumeLayout(false);
            this.grbFiltrarMTMD.PerformLayout();
            this.tabConsumo.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).EndInit();
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
        private HacCheckBox cbCE;
        private HacButton btnFinalizarCE;
        private HacCheckBox chkFracionar;
        private HacButton btnExcluir;
        private HacTextBox txtDtTranf;
        private HacTextBox txtHrTransf;
        private HacLabel lblContaFaturada;
        private HacLabel lblItensNaoSalvos;
        private HacCheckBox chkExcluirProximo;
        private HacTextBox txtDscPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtMovimentoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTpMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProdutoHist;
        private System.Windows.Forms.DataGridViewImageColumn colDeletarHist;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProdutoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdInteiraHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFaturado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataRessup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsQtdeConvertida;
        private System.Windows.Forms.Label label1;
        private HacButton btnHistorico;
        private HacButton btnPendencia;
    }
}
