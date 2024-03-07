using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Faturamento
{
    partial class FrmFaturamentoReceita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFaturamentoReceita));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hacLabel5 = new HacLabel(this.components);
            this.hacLabel4 = new HacLabel(this.components);
            this.txtQuartoLeito = new HacTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocal = new HacTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeConvenio = new HacTextBox(this.components);
            this.txtCodConvenio = new HacTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomePac = new HacTextBox(this.components);
            this.txtNroInternacao = new HacTextBox(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsHac = new HacToolStrip(this.components);
            this.btnPesquisaPac = new System.Windows.Forms.PictureBox();
            this.dtgHistConsumo = new HacDataGridView(this.components);
            this.colIdtMovimentoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecoCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdInteiraHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFaturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbFiltrarMTMD = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HacRadioButton(this.components);
            this.rbHac = new HacRadioButton(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.rbInternado = new HacRadioButton(this.components);
            this.rbAmbulatorio = new HacRadioButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbFiltrarMTMD.SuspendLayout();
            this.SuspendLayout();
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(187, 44);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(55, 13);
            this.hacLabel5.TabIndex = 121;
            this.hacLabel5.Text = "Paciente";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(2, 44);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(79, 13);
            this.hacLabel4.TabIndex = 120;
            this.hacLabel4.Text = "Atendimento";
            // 
            // txtQuartoLeito
            // 
            this.txtQuartoLeito.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtQuartoLeito.BackColor = System.Drawing.Color.White;
            this.txtQuartoLeito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuartoLeito.Editavel = ControleEdicao.Nunca;
            this.txtQuartoLeito.Enabled = false;
            this.txtQuartoLeito.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtQuartoLeito.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQuartoLeito.Limpar = true;
            this.txtQuartoLeito.Location = new System.Drawing.Point(698, 73);
            this.txtQuartoLeito.Name = "txtQuartoLeito";
            this.txtQuartoLeito.NaoAjustarEdicao = false;
            this.txtQuartoLeito.Obrigatorio = false;
            this.txtQuartoLeito.ObrigatorioMensagem = null;
            this.txtQuartoLeito.PreValidacaoMensagem = null;
            this.txtQuartoLeito.PreValidado = false;
            this.txtQuartoLeito.ReadOnly = true;
            this.txtQuartoLeito.SelectAllOnFocus = false;
            this.txtQuartoLeito.Size = new System.Drawing.Size(80, 21);
            this.txtQuartoLeito.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 117;
            this.label5.Text = "Quarto/Leito";
            // 
            // txtLocal
            // 
            this.txtLocal.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtLocal.BackColor = System.Drawing.Color.White;
            this.txtLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocal.Editavel = ControleEdicao.Nunca;
            this.txtLocal.Enabled = false;
            this.txtLocal.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtLocal.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtLocal.Limpar = true;
            this.txtLocal.Location = new System.Drawing.Point(501, 72);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.NaoAjustarEdicao = false;
            this.txtLocal.Obrigatorio = false;
            this.txtLocal.ObrigatorioMensagem = null;
            this.txtLocal.PreValidacaoMensagem = null;
            this.txtLocal.PreValidado = false;
            this.txtLocal.ReadOnly = true;
            this.txtLocal.SelectAllOnFocus = false;
            this.txtLocal.Size = new System.Drawing.Size(128, 21);
            this.txtLocal.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "Local";
            // 
            // txtNomeConvenio
            // 
            this.txtNomeConvenio.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtNomeConvenio.BackColor = System.Drawing.Color.White;
            this.txtNomeConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeConvenio.Editavel = ControleEdicao.Nunca;
            this.txtNomeConvenio.Enabled = false;
            this.txtNomeConvenio.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtNomeConvenio.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomeConvenio.Limpar = true;
            this.txtNomeConvenio.Location = new System.Drawing.Point(187, 72);
            this.txtNomeConvenio.Name = "txtNomeConvenio";
            this.txtNomeConvenio.NaoAjustarEdicao = false;
            this.txtNomeConvenio.Obrigatorio = false;
            this.txtNomeConvenio.ObrigatorioMensagem = null;
            this.txtNomeConvenio.PreValidacaoMensagem = null;
            this.txtNomeConvenio.PreValidado = false;
            this.txtNomeConvenio.ReadOnly = true;
            this.txtNomeConvenio.SelectAllOnFocus = false;
            this.txtNomeConvenio.Size = new System.Drawing.Size(277, 21);
            this.txtNomeConvenio.TabIndex = 114;
            // 
            // txtCodConvenio
            // 
            this.txtCodConvenio.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtCodConvenio.BackColor = System.Drawing.Color.White;
            this.txtCodConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodConvenio.Editavel = ControleEdicao.Nunca;
            this.txtCodConvenio.Enabled = false;
            this.txtCodConvenio.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtCodConvenio.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodConvenio.Limpar = true;
            this.txtCodConvenio.Location = new System.Drawing.Point(82, 72);
            this.txtCodConvenio.Name = "txtCodConvenio";
            this.txtCodConvenio.NaoAjustarEdicao = false;
            this.txtCodConvenio.Obrigatorio = false;
            this.txtCodConvenio.ObrigatorioMensagem = "";
            this.txtCodConvenio.PreValidacaoMensagem = null;
            this.txtCodConvenio.PreValidado = false;
            this.txtCodConvenio.ReadOnly = true;
            this.txtCodConvenio.SelectAllOnFocus = false;
            this.txtCodConvenio.Size = new System.Drawing.Size(100, 21);
            this.txtCodConvenio.TabIndex = 113;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 112;
            this.label6.Text = "Convênio";
            // 
            // txtNomePac
            // 
            this.txtNomePac.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtNomePac.BackColor = System.Drawing.Color.White;
            this.txtNomePac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomePac.Editavel = ControleEdicao.Nunca;
            this.txtNomePac.Enabled = false;
            this.txtNomePac.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtNomePac.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomePac.Limpar = true;
            this.txtNomePac.Location = new System.Drawing.Point(248, 41);
            this.txtNomePac.Name = "txtNomePac";
            this.txtNomePac.NaoAjustarEdicao = false;
            this.txtNomePac.Obrigatorio = false;
            this.txtNomePac.ObrigatorioMensagem = null;
            this.txtNomePac.PreValidacaoMensagem = null;
            this.txtNomePac.PreValidado = false;
            this.txtNomePac.SelectAllOnFocus = false;
            this.txtNomePac.Size = new System.Drawing.Size(381, 21);
            this.txtNomePac.TabIndex = 102;
            // 
            // txtNroInternacao
            // 
            this.txtNroInternacao.AcceptedFormat = AcceptedFormat.Numerico;
            this.txtNroInternacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtNroInternacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroInternacao.Editavel = ControleEdicao.Sempre;
            this.txtNroInternacao.Enabled = false;
            this.txtNroInternacao.EstadoInicial = EstadoObjeto.Habilitado;
            this.txtNroInternacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNroInternacao.Limpar = true;
            this.txtNroInternacao.Location = new System.Drawing.Point(82, 41);
            this.txtNroInternacao.MaxLength = 10;
            this.txtNroInternacao.Name = "txtNroInternacao";
            this.txtNroInternacao.NaoAjustarEdicao = false;
            this.txtNroInternacao.Obrigatorio = false;
            this.txtNroInternacao.ObrigatorioMensagem = null;
            this.txtNroInternacao.PreValidacaoMensagem = null;
            this.txtNroInternacao.PreValidado = false;
            this.txtNroInternacao.SelectAllOnFocus = false;
            this.txtNroInternacao.Size = new System.Drawing.Size(100, 21);
            this.txtNroInternacao.TabIndex = 101;
            this.txtNroInternacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroInternacao.Validated += new System.EventHandler(this.txtNroInternacao_Validated);
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
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "Excluir";
            this.dataGridViewImageColumn2.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.ToolTipText = "Excluir Linha";
            this.dataGridViewImageColumn2.Width = 50;
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
            this.tsHac.NomeControleFoco = "txtNroInternacao";
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 122;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Faturamento de Receita";
            // 
            // btnPesquisaPac
            // 
            this.btnPesquisaPac.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.btnPesquisaPac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaPac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaPac.Location = new System.Drawing.Point(635, 41);
            this.btnPesquisaPac.Name = "btnPesquisaPac";
            this.btnPesquisaPac.Size = new System.Drawing.Size(34, 21);
            this.btnPesquisaPac.TabIndex = 103;
            this.btnPesquisaPac.TabStop = false;
            this.btnPesquisaPac.Click += new System.EventHandler(this.btnPesquisaPac_Click);
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
            this.colIdtProdutoHist,
            this.colDataHist,
            this.colDsProdutoHist,
            this.colQtdHist,
            this.colPrecoCusto,
            this.colQtdInteiraHist,
            this.colFaturado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHistConsumo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgHistConsumo.Editavel = ControleEdicao.Nunca;
            this.dtgHistConsumo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgHistConsumo.EstadoInicial = EstadoObjeto.Habilitado;
            this.dtgHistConsumo.GridPesquisa = false;
            this.dtgHistConsumo.Limpar = true;
            this.dtgHistConsumo.Location = new System.Drawing.Point(15, 173);
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
            this.dtgHistConsumo.RowHeadersWidth = 25;
            this.dtgHistConsumo.Size = new System.Drawing.Size(755, 192);
            this.dtgHistConsumo.TabIndex = 123;
            this.dtgHistConsumo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgHistConsumo_CellFormatting);
            // 
            // colIdtMovimentoHist
            // 
            this.colIdtMovimentoHist.HeaderText = "IdtMovimentoHist";
            this.colIdtMovimentoHist.Name = "colIdtMovimentoHist";
            this.colIdtMovimentoHist.ReadOnly = true;
            this.colIdtMovimentoHist.Visible = false;
            // 
            // colIdtProdutoHist
            // 
            this.colIdtProdutoHist.HeaderText = "IdtProdutoHist";
            this.colIdtProdutoHist.Name = "colIdtProdutoHist";
            this.colIdtProdutoHist.Visible = false;
            // 
            // colDataHist
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataHist.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataHist.HeaderText = "Data Consumo";
            this.colDataHist.Name = "colDataHist";
            this.colDataHist.ReadOnly = true;
            this.colDataHist.Width = 150;
            // 
            // colDsProdutoHist
            // 
            this.colDsProdutoHist.HeaderText = "Descrição do Material";
            this.colDsProdutoHist.Name = "colDsProdutoHist";
            this.colDsProdutoHist.ReadOnly = true;
            this.colDsProdutoHist.Width = 350;
            // 
            // colQtdHist
            // 
            this.colQtdHist.HeaderText = "Qtd. Consumida";
            this.colQtdHist.Name = "colQtdHist";
            this.colQtdHist.ReadOnly = true;
            this.colQtdHist.Width = 110;
            // 
            // colPrecoCusto
            // 
            this.colPrecoCusto.HeaderText = "Preço de Custo";
            this.colPrecoCusto.Name = "colPrecoCusto";
            this.colPrecoCusto.Width = 110;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAmbulatorio);
            this.groupBox1.Controls.Add(this.rbInternado);
            this.groupBox1.Location = new System.Drawing.Point(112, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 36);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            // 
            // grbFiltrarMTMD
            // 
            this.grbFiltrarMTMD.Controls.Add(this.rbAcs);
            this.grbFiltrarMTMD.Controls.Add(this.rbHac);
            this.grbFiltrarMTMD.Enabled = false;
            this.grbFiltrarMTMD.Location = new System.Drawing.Point(112, 99);
            this.grbFiltrarMTMD.Name = "grbFiltrarMTMD";
            this.grbFiltrarMTMD.Size = new System.Drawing.Size(121, 36);
            this.grbFiltrarMTMD.TabIndex = 124;
            this.grbFiltrarMTMD.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = ControleEdicao.Nunca;
            this.rbAcs.EstadoInicial = EstadoObjeto.Desabilitado;
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
            this.rbHac.Editavel = ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = EstadoObjeto.Desabilitado;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Tipo de Atendimento";
            // 
            // rbInternado
            // 
            this.rbInternado.AutoSize = true;
            this.rbInternado.Editavel = ControleEdicao.Sempre;
            this.rbInternado.EstadoInicial = EstadoObjeto.Habilitado;
            this.rbInternado.Limpar = false;
            this.rbInternado.Location = new System.Drawing.Point(6, 13);
            this.rbInternado.Name = "rbInternado";
            this.rbInternado.Obrigatorio = false;
            this.rbInternado.ObrigatorioMensagem = null;
            this.rbInternado.PreValidacaoMensagem = null;
            this.rbInternado.PreValidado = false;
            this.rbInternado.Size = new System.Drawing.Size(70, 17);
            this.rbInternado.TabIndex = 127;
            this.rbInternado.TabStop = true;
            this.rbInternado.Text = "Internado";
            this.rbInternado.UseVisualStyleBackColor = true;
            // 
            // rbAmbulatorio
            // 
            this.rbAmbulatorio.AutoSize = true;
            this.rbAmbulatorio.Editavel = ControleEdicao.Sempre;
            this.rbAmbulatorio.EstadoInicial = EstadoObjeto.Habilitado;
            this.rbAmbulatorio.Limpar = false;
            this.rbAmbulatorio.Location = new System.Drawing.Point(78, 12);
            this.rbAmbulatorio.Name = "rbAmbulatorio";
            this.rbAmbulatorio.Obrigatorio = false;
            this.rbAmbulatorio.ObrigatorioMensagem = null;
            this.rbAmbulatorio.PreValidacaoMensagem = null;
            this.rbAmbulatorio.PreValidado = false;
            this.rbAmbulatorio.Size = new System.Drawing.Size(80, 17);
            this.rbAmbulatorio.TabIndex = 128;
            this.rbAmbulatorio.TabStop = true;
            this.rbAmbulatorio.Text = "Ambulatorio";
            this.rbAmbulatorio.UseVisualStyleBackColor = true;
            // 
            // FrmFaturamentoReceita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 377);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbFiltrarMTMD);
            this.Controls.Add(this.dtgHistConsumo);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.txtQuartoLeito);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNomeConvenio);
            this.Controls.Add(this.txtCodConvenio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPesquisaPac);
            this.Controls.Add(this.txtNomePac);
            this.Controls.Add(this.txtNroInternacao);
            this.Name = "FrmFaturamentoReceita";
            this.Text = "FaturamentoReceita";
            this.Load += new System.EventHandler(this.FaturamentoReceita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbFiltrarMTMD.ResumeLayout(false);
            this.grbFiltrarMTMD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacLabel hacLabel5;
        private HacLabel hacLabel4;
        private HacTextBox txtQuartoLeito;
        private System.Windows.Forms.Label label5;
        private HacTextBox txtLocal;
        private System.Windows.Forms.Label label4;
        private HacTextBox txtNomeConvenio;
        private HacTextBox txtCodConvenio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox btnPesquisaPac;
        private HacTextBox txtNomePac;
        private HacTextBox txtNroInternacao;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private HacDataGridView dtgHistConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtMovimentoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProdutoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProdutoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdInteiraHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFaturado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbFiltrarMTMD;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private System.Windows.Forms.Label label1;
        private HacRadioButton rbInternado;
        private HacRadioButton rbAmbulatorio;
    }
}