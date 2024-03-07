using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmBaixaProdFrac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaixaProdFrac));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQtdLote = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdEstoque = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtUnidadeVenda = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtDsProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblFracao = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grbTipo = new System.Windows.Forms.GroupBox();
            this.rbMat = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbFrac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbInteiroFrac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cbCE = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnFinalizarCE = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
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
            this.lblEU = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbFilial.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).BeginInit();
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
            this.tsHac.Size = new System.Drawing.Size(805, 28);
            this.tsHac.TabIndex = 96;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Baixa Fracionado ou Material";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            this.tsHac.SairClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SairClick);
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbAcs);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Enabled = false;
            this.grbFilial.Location = new System.Drawing.Point(682, 68);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(114, 36);
            this.grbFilial.TabIndex = 109;
            this.grbFilial.TabStop = false;
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
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.CheckedChanged += new System.EventHandler(this.rbAcs_CheckedChanged);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
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
            this.cmbSetor.Location = new System.Drawing.Point(584, 43);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(180, 21);
            this.cmbSetor.TabIndex = 108;
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
            this.cmbLocal.Location = new System.Drawing.Point(330, 43);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(180, 21);
            this.cmbLocal.TabIndex = 107;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(7, 46);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 103;
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
            this.cmbUnidade.Location = new System.Drawing.Point(72, 43);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(180, 21);
            this.cmbUnidade.SomenteAtiva = true;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 106;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(288, 46);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 104;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(540, 46);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 105;
            this.hacLabel3.Text = "Setor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQtdLote);
            this.groupBox2.Controls.Add(this.lblLote);
            this.groupBox2.Controls.Add(this.txtQtdEstoque);
            this.groupBox2.Controls.Add(this.hacLabel7);
            this.groupBox2.Controls.Add(this.txtUnidadeVenda);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDsProduto);
            this.groupBox2.Controls.Add(this.lblFracao);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtIdProduto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 73);
            this.groupBox2.TabIndex = 110;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produto";
            // 
            // txtQtdLote
            // 
            this.txtQtdLote.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdLote.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdLote.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdLote.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdLote.Limpar = true;
            this.txtQtdLote.Location = new System.Drawing.Point(505, 46);
            this.txtQtdLote.Name = "txtQtdLote";
            this.txtQtdLote.NaoAjustarEdicao = false;
            this.txtQtdLote.Obrigatorio = true;
            this.txtQtdLote.ObrigatorioMensagem = "Qtd. Estoque no Setor de Origem Não Pode Estar Em Branco";
            this.txtQtdLote.PreValidacaoMensagem = null;
            this.txtQtdLote.PreValidado = false;
            this.txtQtdLote.ReadOnly = true;
            this.txtQtdLote.SelectAllOnFocus = false;
            this.txtQtdLote.Size = new System.Drawing.Size(70, 21);
            this.txtQtdLote.TabIndex = 129;
            this.txtQtdLote.TabStop = false;
            this.txtQtdLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdLote.Visible = false;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblLote.Location = new System.Drawing.Point(443, 51);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(59, 13);
            this.lblLote.TabIndex = 128;
            this.lblLote.Text = "Qtd. Lote";
            this.lblLote.Visible = false;
            // 
            // txtQtdEstoque
            // 
            this.txtQtdEstoque.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdEstoque.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdEstoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdEstoque.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdEstoque.Limpar = true;
            this.txtQtdEstoque.Location = new System.Drawing.Point(667, 46);
            this.txtQtdEstoque.Name = "txtQtdEstoque";
            this.txtQtdEstoque.NaoAjustarEdicao = false;
            this.txtQtdEstoque.Obrigatorio = true;
            this.txtQtdEstoque.ObrigatorioMensagem = "Qtd. Estoque no Setor de Origem Não Pode Estar Em Branco";
            this.txtQtdEstoque.PreValidacaoMensagem = null;
            this.txtQtdEstoque.PreValidado = false;
            this.txtQtdEstoque.ReadOnly = true;
            this.txtQtdEstoque.SelectAllOnFocus = false;
            this.txtQtdEstoque.Size = new System.Drawing.Size(80, 21);
            this.txtQtdEstoque.TabIndex = 112;
            this.txtQtdEstoque.TabStop = false;
            this.txtQtdEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(583, 49);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(80, 13);
            this.hacLabel7.TabIndex = 111;
            this.hacLabel7.Text = "Qtd. Estoque";
            // 
            // txtUnidadeVenda
            // 
            this.txtUnidadeVenda.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidadeVenda.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidadeVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidadeVenda.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidadeVenda.Enabled = false;
            this.txtUnidadeVenda.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidadeVenda.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidadeVenda.Limpar = true;
            this.txtUnidadeVenda.Location = new System.Drawing.Point(62, 46);
            this.txtUnidadeVenda.Name = "txtUnidadeVenda";
            this.txtUnidadeVenda.NaoAjustarEdicao = false;
            this.txtUnidadeVenda.Obrigatorio = true;
            this.txtUnidadeVenda.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtUnidadeVenda.PreValidacaoMensagem = null;
            this.txtUnidadeVenda.PreValidado = false;
            this.txtUnidadeVenda.SelectAllOnFocus = false;
            this.txtUnidadeVenda.Size = new System.Drawing.Size(229, 21);
            this.txtUnidadeVenda.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Unidade";
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDsProduto.Enabled = false;
            this.txtDsProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(228, 21);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = false;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(519, 21);
            this.txtDsProduto.TabIndex = 3;
            // 
            // lblFracao
            // 
            this.lblFracao.AutoSize = true;
            this.lblFracao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFracao.Location = new System.Drawing.Point(716, 100);
            this.lblFracao.Name = "lblFracao";
            this.lblFracao.Size = new System.Drawing.Size(0, 13);
            this.lblFracao.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição";
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
            this.txtIdProduto.Location = new System.Drawing.Point(62, 22);
            this.txtIdProduto.MaxLength = 50;
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = false;
            this.txtIdProduto.ObrigatorioMensagem = null;
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(100, 21);
            this.txtIdProduto.TabIndex = 1;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdProduto_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // grbTipo
            // 
            this.grbTipo.Controls.Add(this.rbMat);
            this.grbTipo.Controls.Add(this.rbFrac);
            this.grbTipo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTipo.Location = new System.Drawing.Point(8, 73);
            this.grbTipo.Name = "grbTipo";
            this.grbTipo.Size = new System.Drawing.Size(290, 54);
            this.grbTipo.TabIndex = 111;
            this.grbTipo.TabStop = false;
            this.grbTipo.Text = "Tipo Mat/Med";
            // 
            // rbMat
            // 
            this.rbMat.AutoSize = true;
            this.rbMat.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbMat.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbMat.Limpar = true;
            this.rbMat.Location = new System.Drawing.Point(125, 23);
            this.rbMat.Name = "rbMat";
            this.rbMat.Obrigatorio = false;
            this.rbMat.ObrigatorioMensagem = null;
            this.rbMat.PreValidacaoMensagem = null;
            this.rbMat.PreValidado = false;
            this.rbMat.Size = new System.Drawing.Size(148, 17);
            this.rbMat.TabIndex = 1;
            this.rbMat.TabStop = true;
            this.rbMat.Text = "Material de Uso Geral";
            this.rbMat.UseVisualStyleBackColor = true;
            this.rbMat.Click += new System.EventHandler(this.rbMat_Click);
            // 
            // rbFrac
            // 
            this.rbFrac.AutoSize = true;
            this.rbFrac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbFrac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbFrac.Limpar = true;
            this.rbFrac.Location = new System.Drawing.Point(14, 23);
            this.rbFrac.Name = "rbFrac";
            this.rbFrac.Obrigatorio = false;
            this.rbFrac.ObrigatorioMensagem = null;
            this.rbFrac.PreValidacaoMensagem = null;
            this.rbFrac.PreValidado = false;
            this.rbFrac.Size = new System.Drawing.Size(93, 17);
            this.rbFrac.TabIndex = 0;
            this.rbFrac.TabStop = true;
            this.rbFrac.Text = "Fracionados";
            this.rbFrac.UseVisualStyleBackColor = true;
            this.rbFrac.Click += new System.EventHandler(this.rbFrac_Click);
            // 
            // rbInteiroFrac
            // 
            this.rbInteiroFrac.AutoSize = true;
            this.rbInteiroFrac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbInteiroFrac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbInteiroFrac.Limpar = true;
            this.rbInteiroFrac.Location = new System.Drawing.Point(603, 110);
            this.rbInteiroFrac.Name = "rbInteiroFrac";
            this.rbInteiroFrac.Obrigatorio = false;
            this.rbInteiroFrac.ObrigatorioMensagem = null;
            this.rbInteiroFrac.PreValidacaoMensagem = null;
            this.rbInteiroFrac.PreValidado = false;
            this.rbInteiroFrac.Size = new System.Drawing.Size(177, 17);
            this.rbInteiroFrac.TabIndex = 2;
            this.rbInteiroFrac.TabStop = true;
            this.rbInteiroFrac.Text = "Medicamento Inteiro Fracionado";
            this.rbInteiroFrac.UseVisualStyleBackColor = true;
            this.rbInteiroFrac.Visible = false;
            this.rbInteiroFrac.Click += new System.EventHandler(this.rbInteiroFrac_Click);
            // 
            // cbCE
            // 
            this.cbCE.AutoSize = true;
            this.cbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCE.Limpar = false;
            this.cbCE.Location = new System.Drawing.Point(311, 84);
            this.cbCE.Name = "cbCE";
            this.cbCE.Obrigatorio = false;
            this.cbCE.ObrigatorioMensagem = null;
            this.cbCE.PreValidacaoMensagem = null;
            this.cbCE.PreValidado = false;
            this.cbCE.Size = new System.Drawing.Size(197, 17);
            this.cbCE.TabIndex = 112;
            this.cbCE.Text = "CARRINHO DE EMERGÊNCIA";
            this.cbCE.UseVisualStyleBackColor = true;
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
            this.btnFinalizarCE.Location = new System.Drawing.Point(309, 105);
            this.btnFinalizarCE.Name = "btnFinalizarCE";
            this.btnFinalizarCE.Size = new System.Drawing.Size(277, 22);
            this.btnFinalizarCE.TabIndex = 113;
            this.btnFinalizarCE.Text = "Finalizar Consumo do Carrinho de Emergência";
            this.btnFinalizarCE.UseVisualStyleBackColor = true;
            this.btnFinalizarCE.Visible = false;
            this.btnFinalizarCE.Click += new System.EventHandler(this.btnFinalizarCE_Click);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHistConsumo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgHistConsumo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgHistConsumo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgHistConsumo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgHistConsumo.GridPesquisa = false;
            this.dtgHistConsumo.Limpar = true;
            this.dtgHistConsumo.Location = new System.Drawing.Point(7, 212);
            this.dtgHistConsumo.Name = "dtgHistConsumo";
            this.dtgHistConsumo.NaoAjustarEdicao = false;
            this.dtgHistConsumo.Obrigatorio = false;
            this.dtgHistConsumo.ObrigatorioMensagem = null;
            this.dtgHistConsumo.PreValidacaoMensagem = null;
            this.dtgHistConsumo.PreValidado = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgHistConsumo.RowHeadersVisible = false;
            this.dtgHistConsumo.RowHeadersWidth = 21;
            this.dtgHistConsumo.RowTemplate.Height = 18;
            this.dtgHistConsumo.Size = new System.Drawing.Size(789, 166);
            this.dtgHistConsumo.TabIndex = 114;
            this.dtgHistConsumo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHistConsumo_CellDoubleClick);
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
            this.colChkExcluir.Visible = false;
            this.colChkExcluir.Width = 50;
            // 
            // colDataHist
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataHist.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataHist.HeaderText = "Data Consumo";
            this.colDataHist.Name = "colDataHist";
            this.colDataHist.ReadOnly = true;
            this.colDataHist.Width = 120;
            // 
            // colDsProdutoHist
            // 
            this.colDsProdutoHist.HeaderText = "Descrição do Material";
            this.colDsProdutoHist.Name = "colDsProdutoHist";
            this.colDsProdutoHist.ReadOnly = true;
            this.colDsProdutoHist.Width = 400;
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
            this.colDsQtdeConvertida.Visible = false;
            this.colDsQtdeConvertida.Width = 90;
            // 
            // lblEU
            // 
            this.lblEU.AutoSize = true;
            this.lblEU.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEU.ForeColor = System.Drawing.Color.Green;
            this.lblEU.Location = new System.Drawing.Point(523, 84);
            this.lblEU.Name = "lblEU";
            this.lblEU.Size = new System.Drawing.Size(154, 14);
            this.lblEU.TabIndex = 127;
            this.lblEU.Text = "ESTOQUE ÚNICO HAC";
            this.lblEU.Visible = false;
            // 
            // FrmBaixaProdFrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 414);
            this.Controls.Add(this.lblEU);
            this.Controls.Add(this.rbInteiroFrac);
            this.Controls.Add(this.dtgHistConsumo);
            this.Controls.Add(this.btnFinalizarCE);
            this.Controls.Add(this.cbCE);
            this.Controls.Add(this.grbTipo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmBaixaProdFrac";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBaixaProdFrac_FormClosing);
            this.Load += new System.EventHandler(this.FrmBaixaProdFrac_Load);
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbTipo.ResumeLayout(false);
            this.grbTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox grbFilial;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacCmbSetor cmbSetor;
        private HacCmbLocal cmbLocal;
        private HacLabel hacLabel1;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel2;
        private HacLabel hacLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private HacTextBox txtQtdEstoque;
        private HacLabel hacLabel7;
        private HacTextBox txtUnidadeVenda;
        private System.Windows.Forms.Label label3;
        private HacTextBox txtDsProduto;
        private HacLabel lblFracao;
        private System.Windows.Forms.Label label2;
        private HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbTipo;
        private HacRadioButton rbMat;
        private HacRadioButton rbFrac;
        private HacCheckBox cbCE;
        private HacButton btnFinalizarCE;
        private HacRadioButton rbInteiroFrac;
        private HacDataGridView dtgHistConsumo;
        private HacLabel lblEU;
        private HacTextBox txtQtdLote;
        private HacLabel lblLote;
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
    }
}