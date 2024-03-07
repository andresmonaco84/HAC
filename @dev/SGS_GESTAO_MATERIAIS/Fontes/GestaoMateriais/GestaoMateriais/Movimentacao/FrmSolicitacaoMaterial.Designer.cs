using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmSolicitacaoMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSolicitacaoMaterial));
            this.txtReqIdt = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtData = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReqItemIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidadeVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeFornecida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.grbFilial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.SuspendLayout();
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
            this.txtReqIdt.Location = new System.Drawing.Point(91, 100);
            this.txtReqIdt.Name = "txtReqIdt";
            this.txtReqIdt.NaoAjustarEdicao = false;
            this.txtReqIdt.Obrigatorio = false;
            this.txtReqIdt.ObrigatorioMensagem = null;
            this.txtReqIdt.PreValidacaoMensagem = null;
            this.txtReqIdt.PreValidado = false;
            this.txtReqIdt.ReadOnly = true;
            this.txtReqIdt.SelectAllOnFocus = false;
            this.txtReqIdt.Size = new System.Drawing.Size(100, 21);
            this.txtReqIdt.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 66;
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
            this.txtData.Location = new System.Drawing.Point(336, 100);
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = true;
            this.txtData.Obrigatorio = false;
            this.txtData.ObrigatorioMensagem = null;
            this.txtData.PreValidacaoMensagem = null;
            this.txtData.PreValidado = false;
            this.txtData.ReadOnly = true;
            this.txtData.SelectAllOnFocus = false;
            this.txtData.Size = new System.Drawing.Size(108, 21);
            this.txtData.TabIndex = 62;
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Enabled = false;
            this.grbFilial.Location = new System.Drawing.Point(703, 88);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(59, 36);
            this.grbFilial.TabIndex = 69;
            this.grbFilial.TabStop = false;
            this.grbFilial.Visible = false;
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
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
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
            this.colReqItemIdt,
            this.colDsProd,
            this.colMatMedIdt,
            this.colDsUnidadeVenda,
            this.colQtde,
            this.colEstoqueLocal,
            this.colQtdeFornecida});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(6, 136);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 21;
            this.dtgMatMed.RowTemplate.Height = 18;
            this.dtgMatMed.Size = new System.Drawing.Size(779, 337);
            this.dtgMatMed.TabIndex = 70;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
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
            // colReqItemIdt
            // 
            this.colReqItemIdt.HeaderText = "ReqItemIdt";
            this.colReqItemIdt.Name = "colReqItemIdt";
            this.colReqItemIdt.ReadOnly = true;
            this.colReqItemIdt.Visible = false;
            // 
            // colDsProd
            // 
            this.colDsProd.HeaderText = "Descrição do Material";
            this.colDsProd.Name = "colDsProd";
            this.colDsProd.ReadOnly = true;
            this.colDsProd.Width = 300;
            // 
            // colMatMedIdt
            // 
            this.colMatMedIdt.HeaderText = "colMatMedIdt";
            this.colMatMedIdt.Name = "colMatMedIdt";
            this.colMatMedIdt.Visible = false;
            // 
            // colDsUnidadeVenda
            // 
            this.colDsUnidadeVenda.HeaderText = "Unidade";
            this.colDsUnidadeVenda.Name = "colDsUnidadeVenda";
            this.colDsUnidadeVenda.ReadOnly = true;
            // 
            // colQtde
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtde.HeaderText = "Qtd. Requis.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            // 
            // colEstoqueLocal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colEstoqueLocal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEstoqueLocal.HeaderText = "Qtd Local";
            this.colEstoqueLocal.Name = "colEstoqueLocal";
            this.colEstoqueLocal.ReadOnly = true;
            // 
            // colQtdeFornecida
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.colQtdeFornecida.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQtdeFornecida.HeaderText = "Qtd. Fornecer";
            this.colQtdeFornecida.Name = "colQtdeFornecida";
            this.colQtdeFornecida.ReadOnly = true;
            this.colQtdeFornecida.Visible = false;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(5, 40);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 71;
            this.hacLabel1.Text = "Unidade";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(294, 40);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 73;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(538, 40);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 75;
            this.hacLabel3.Text = "Setor";
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
            this.cmbUnidade.Location = new System.Drawing.Point(91, 37);
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
            this.cmbUnidade.TabIndex = 77;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(336, 37);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(180, 21);
            this.cmbLocal.TabIndex = 78;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
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
            this.cmbSetor.Location = new System.Drawing.Point(582, 37);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(180, 21);
            this.cmbSetor.TabIndex = 79;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Data do Pedido";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cbStatus.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbStatus.Limpar = true;
            this.cbStatus.Location = new System.Drawing.Point(531, 104);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Obrigatorio = false;
            this.cbStatus.ObrigatorioMensagem = null;
            this.cbStatus.PreValidacaoMensagem = null;
            this.cbStatus.PreValidado = false;
            this.cbStatus.Size = new System.Drawing.Size(111, 17);
            this.cbStatus.TabIndex = 81;
            this.cbStatus.Text = "Enviar Solicitação";
            this.cbStatus.UseVisualStyleBackColor = true;
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
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 82;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Impressos e Materiais";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Tipo Pedido";
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbTipo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Limpar = false;
            this.cmbTipo.Location = new System.Drawing.Point(91, 67);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Obrigatorio = true;
            this.cmbTipo.ObrigatorioMensagem = "Tipo Pedido Não Pode Estar em Branco";
            this.cmbTipo.PreValidacaoMensagem = "Tipo Pedido Não Pode Estar em Branco";
            this.cmbTipo.PreValidado = true;
            this.cmbTipo.Size = new System.Drawing.Size(353, 21);
            this.cmbTipo.TabIndex = 85;
            // 
            // FrmSolicitacaoMaterial
            // 
            this.ClientSize = new System.Drawing.Size(792, 534);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.txtReqIdt);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtData);
            this.Name = "FrmSolicitacaoMaterial";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSolicitacaoMaterial_FormClosing);
            this.Load += new System.EventHandler(this.FrmSolicitacao_Load);
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacTextBox txtReqIdt;
        private System.Windows.Forms.Label label5;
        private HacTextBox txtData;
        private System.Windows.Forms.GroupBox grbFilial;
        private HacRadioButton rbHac;
        private HacDataGridView dtgMatMed;
        private HacLabel hacLabel1;
        private HacLabel hacLabel2;
        private HacLabel hacLabel3;
        private HacCmbUnidade cmbUnidade;
        private HacCmbLocal cmbLocal;
        private HacCmbSetor cmbSetor;
        private System.Windows.Forms.Label label1;
        private HacCheckBox cbStatus;
        private HacToolStrip tsHac;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqItemIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidadeVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeFornecida;
        private System.Windows.Forms.Label label2;
        private HacComboBox cmbTipo;
    }
}
