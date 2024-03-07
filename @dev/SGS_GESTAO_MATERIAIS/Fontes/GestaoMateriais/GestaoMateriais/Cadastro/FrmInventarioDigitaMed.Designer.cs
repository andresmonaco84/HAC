namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmInventarioDigitaMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventarioDigitaMed));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.tsImportar = new System.Windows.Forms.ToolStripButton();
            this.gbEstoque = new System.Windows.Forms.GroupBox();
            this.lblEstoqueUnificado = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblDigitacao = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnVerificar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtData = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.dtgMatMed = new System.Windows.Forms.DataGridView();
            this.colIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumFabLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colZerar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblContagemFechada = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblFechar = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnFecharNum = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtCodProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblCodProd = new System.Windows.Forms.Label();
            this.cbDigitar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnPesquisaItens = new System.Windows.Forms.PictureBox();
            this.tsHac.SuspendLayout();
            this.gbEstoque.SuspendLayout();
            this.grbFilial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaItens)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsImportar});
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(781, 28);
            this.tsHac.TabIndex = 84;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Inventário Medicamento";
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            // 
            // tsImportar
            // 
            this.tsImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsImportar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsImportar.Image = ((System.Drawing.Image)(resources.GetObject("tsImportar.Image")));
            this.tsImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImportar.Name = "tsImportar";
            this.tsImportar.Size = new System.Drawing.Size(150, 25);
            this.tsImportar.Text = "Importar para o Estoque";
            this.tsImportar.Click += new System.EventHandler(this.tsImportar_Click);
            // 
            // gbEstoque
            // 
            this.gbEstoque.Controls.Add(this.lblEstoqueUnificado);
            this.gbEstoque.Controls.Add(this.lblDigitacao);
            this.gbEstoque.Controls.Add(this.btnVerificar);
            this.gbEstoque.Controls.Add(this.txtData);
            this.gbEstoque.Controls.Add(this.hacLabel6);
            this.gbEstoque.Controls.Add(this.cmbSetor);
            this.gbEstoque.Controls.Add(this.hacLabel3);
            this.gbEstoque.Controls.Add(this.grbFilial);
            this.gbEstoque.Controls.Add(this.cmbLocal);
            this.gbEstoque.Controls.Add(this.hacLabel1);
            this.gbEstoque.Controls.Add(this.hacLabel2);
            this.gbEstoque.Controls.Add(this.cmbUnidade);
            this.gbEstoque.Location = new System.Drawing.Point(9, 28);
            this.gbEstoque.Name = "gbEstoque";
            this.gbEstoque.Size = new System.Drawing.Size(681, 82);
            this.gbEstoque.TabIndex = 128;
            this.gbEstoque.TabStop = false;
            // 
            // lblEstoqueUnificado
            // 
            this.lblEstoqueUnificado.AutoSize = true;
            this.lblEstoqueUnificado.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEstoqueUnificado.ForeColor = System.Drawing.Color.Green;
            this.lblEstoqueUnificado.Location = new System.Drawing.Point(668, 56);
            this.lblEstoqueUnificado.Name = "lblEstoqueUnificado";
            this.lblEstoqueUnificado.Size = new System.Drawing.Size(0, 12);
            this.lblEstoqueUnificado.TabIndex = 162;
            this.lblEstoqueUnificado.Visible = false;
            // 
            // lblDigitacao
            // 
            this.lblDigitacao.AutoSize = true;
            this.lblDigitacao.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDigitacao.ForeColor = System.Drawing.Color.Red;
            this.lblDigitacao.Location = new System.Drawing.Point(453, 53);
            this.lblDigitacao.Name = "lblDigitacao";
            this.lblDigitacao.Size = new System.Drawing.Size(0, 17);
            this.lblDigitacao.TabIndex = 151;
            // 
            // btnVerificar
            // 
            this.btnVerificar.AlterarStatus = true;
            this.btnVerificar.BackColor = System.Drawing.Color.White;
            this.btnVerificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerificar.BackgroundImage")));
            this.btnVerificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnVerificar.Location = new System.Drawing.Point(271, 51);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(167, 22);
            this.btnVerificar.TabIndex = 150;
            this.btnVerificar.Text = "CARREGAR INVENTÁRIO";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // txtData
            // 
            this.txtData.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtData.BackColor = System.Drawing.Color.Honeydew;
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtData.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Limpar = false;
            this.txtData.Location = new System.Drawing.Point(60, 51);
            this.txtData.MaxLength = 10;
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = true;
            this.txtData.Obrigatorio = false;
            this.txtData.ObrigatorioMensagem = null;
            this.txtData.PreValidacaoMensagem = null;
            this.txtData.PreValidado = false;
            this.txtData.SelectAllOnFocus = false;
            this.txtData.Size = new System.Drawing.Size(80, 20);
            this.txtData.TabIndex = 10;
            this.txtData.TabStop = false;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(20, 55);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(34, 13);
            this.hacLabel6.TabIndex = 149;
            this.hacLabel6.Text = "Data";
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = true;
            this.cmbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = true;
            this.cmbSetor.Location = new System.Drawing.Point(483, 19);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 125;
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(443, 22);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 124;
            this.hacLabel3.Text = "Setor";
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbCE);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(149, 41);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(111, 36);
            this.grbFilial.TabIndex = 126;
            this.grbFilial.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(63, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = true;
            this.rbCE.Size = new System.Drawing.Size(41, 17);
            this.rbCE.TabIndex = 118;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.Click += new System.EventHandler(this.rbEstoque_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(7, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(50, 17);
            this.rbHac.TabIndex = 2;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.Click += new System.EventHandler(this.rbEstoque_Click);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(293, 19);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(146, 21);
            this.cmbLocal.TabIndex = 123;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(3, 22);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 120;
            this.hacLabel1.Text = "Unidade";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(255, 22);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 122;
            this.hacLabel2.Text = "Local";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbUnidade.Limpar = true;
            this.cmbUnidade.Location = new System.Drawing.Point(60, 19);
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
            this.cmbUnidade.TabIndex = 121;
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToResizeColumns = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMatMed.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdt,
            this.colCodLote,
            this.colNumFabLote,
            this.colDescricao,
            this.colQtd,
            this.colDel,
            this.colZerar,
            this.colData});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle15;
            this.dtgMatMed.Location = new System.Drawing.Point(9, 149);
            this.dtgMatMed.MultiSelect = false;
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.RowTemplate.Height = 18;
            this.dtgMatMed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(764, 420);
            this.dtgMatMed.TabIndex = 129;
            this.dtgMatMed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellContentClick);
            // 
            // colIdt
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdt.DefaultCellStyle = dataGridViewCellStyle10;
            this.colIdt.HeaderText = "ID";
            this.colIdt.MaxInputLength = 9;
            this.colIdt.Name = "colIdt";
            this.colIdt.ReadOnly = true;
            this.colIdt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIdt.Width = 76;
            // 
            // colCodLote
            // 
            this.colCodLote.HeaderText = "Cd. Lote";
            this.colCodLote.Name = "colCodLote";
            this.colCodLote.ReadOnly = true;
            this.colCodLote.Width = 70;
            // 
            // colNumFabLote
            // 
            this.colNumFabLote.HeaderText = "Lote Fab.";
            this.colNumFabLote.Name = "colNumFabLote";
            this.colNumFabLote.ReadOnly = true;
            this.colNumFabLote.Width = 78;
            // 
            // colDescricao
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescricao.DefaultCellStyle = dataGridViewCellStyle11;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 416;
            // 
            // colQtd
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.colQtd.DefaultCellStyle = dataGridViewCellStyle12;
            this.colQtd.HeaderText = "Quantidade";
            this.colQtd.MaxInputLength = 5;
            this.colQtd.Name = "colQtd";
            this.colQtd.ReadOnly = true;
            this.colQtd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQtd.Width = 80;
            // 
            // colDel
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.NullValue = "-";
            this.colDel.DefaultCellStyle = dataGridViewCellStyle13;
            this.colDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colDel.HeaderText = "";
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDel.Text = "-";
            this.colDel.ToolTipText = "SUBTRAIR";
            this.colDel.Visible = false;
            this.colDel.Width = 18;
            // 
            // colZerar
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.NullValue = "0";
            this.colZerar.DefaultCellStyle = dataGridViewCellStyle14;
            this.colZerar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colZerar.HeaderText = "";
            this.colZerar.Name = "colZerar";
            this.colZerar.ReadOnly = true;
            this.colZerar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colZerar.Text = "0";
            this.colZerar.ToolTipText = "ZERAR";
            this.colZerar.Visible = false;
            this.colZerar.Width = 18;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Visible = false;
            // 
            // lblContagemFechada
            // 
            this.lblContagemFechada.AutoSize = true;
            this.lblContagemFechada.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblContagemFechada.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblContagemFechada.Location = new System.Drawing.Point(592, 586);
            this.lblContagemFechada.Name = "lblContagemFechada";
            this.lblContagemFechada.Size = new System.Drawing.Size(15, 13);
            this.lblContagemFechada.TabIndex = 160;
            this.lblContagemFechada.Text = "0";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(471, 586);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(122, 13);
            this.hacLabel7.TabIndex = 159;
            this.hacLabel7.Text = "Contagem Fechada:";
            // 
            // lblFechar
            // 
            this.lblFechar.AutoSize = true;
            this.lblFechar.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFechar.Location = new System.Drawing.Point(628, 586);
            this.lblFechar.Name = "lblFechar";
            this.lblFechar.Size = new System.Drawing.Size(108, 13);
            this.lblFechar.TabIndex = 158;
            this.lblFechar.Text = "Fechar Contagem";
            // 
            // btnFecharNum
            // 
            this.btnFecharNum.AlterarStatus = true;
            this.btnFecharNum.BackColor = System.Drawing.Color.White;
            this.btnFecharNum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFecharNum.BackgroundImage")));
            this.btnFecharNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharNum.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnFecharNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharNum.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnFecharNum.Location = new System.Drawing.Point(740, 582);
            this.btnFecharNum.Name = "btnFecharNum";
            this.btnFecharNum.Size = new System.Drawing.Size(31, 22);
            this.btnFecharNum.TabIndex = 157;
            this.btnFecharNum.Text = "-";
            this.btnFecharNum.UseVisualStyleBackColor = true;
            this.btnFecharNum.Click += new System.EventHandler(this.btnFecharNum_Click);
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
            this.txtCodProduto.Location = new System.Drawing.Point(83, 119);
            this.txtCodProduto.MaxLength = 50;
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.NaoAjustarEdicao = false;
            this.txtCodProduto.Obrigatorio = true;
            this.txtCodProduto.ObrigatorioMensagem = "Código Obrigatorio";
            this.txtCodProduto.PreValidacaoMensagem = null;
            this.txtCodProduto.PreValidado = false;
            this.txtCodProduto.SelectAllOnFocus = false;
            this.txtCodProduto.Size = new System.Drawing.Size(173, 21);
            this.txtCodProduto.TabIndex = 162;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProduto_Validating);
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProd.Location = new System.Drawing.Point(9, 123);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(70, 13);
            this.lblCodProd.TabIndex = 161;
            this.lblCodProd.Text = "Cod. Barra";
            // 
            // cbDigitar
            // 
            this.cbDigitar.AutoSize = true;
            this.cbDigitar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbDigitar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbDigitar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDigitar.Limpar = true;
            this.cbDigitar.Location = new System.Drawing.Point(272, 122);
            this.cbDigitar.Name = "cbDigitar";
            this.cbDigitar.Obrigatorio = false;
            this.cbDigitar.ObrigatorioMensagem = null;
            this.cbDigitar.PreValidacaoMensagem = null;
            this.cbDigitar.PreValidado = false;
            this.cbDigitar.Size = new System.Drawing.Size(123, 17);
            this.cbDigitar.TabIndex = 163;
            this.cbDigitar.Text = "DIGITAR QTDE.";
            this.cbDigitar.UseVisualStyleBackColor = true;
            this.cbDigitar.Visible = false;
            this.cbDigitar.Click += new System.EventHandler(this.cbDigitar_Click);
            // 
            // btnPesquisaItens
            // 
            this.btnPesquisaItens.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.btnPesquisaItens.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaItens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaItens.Location = new System.Drawing.Point(742, 123);
            this.btnPesquisaItens.Name = "btnPesquisaItens";
            this.btnPesquisaItens.Size = new System.Drawing.Size(34, 21);
            this.btnPesquisaItens.TabIndex = 201;
            this.btnPesquisaItens.TabStop = false;
            this.btnPesquisaItens.Visible = false;
            this.btnPesquisaItens.Click += new System.EventHandler(this.btnPesquisaItens_Click);
            // 
            // FrmInventarioDigitaMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 616);
            this.Controls.Add(this.btnPesquisaItens);
            this.Controls.Add(this.cbDigitar);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.lblCodProd);
            this.Controls.Add(this.lblContagemFechada);
            this.Controls.Add(this.hacLabel7);
            this.Controls.Add(this.lblFechar);
            this.Controls.Add(this.btnFecharNum);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.gbEstoque);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmInventarioDigitaMed";
            this.Text = "FrmInventarioDigitaMed";
            this.Load += new System.EventHandler(this.FrmInventarioDigitaMed_Load);
            this.tsHac.ResumeLayout(false);
            this.tsHac.PerformLayout();
            this.gbEstoque.ResumeLayout(false);
            this.gbEstoque.PerformLayout();
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaItens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.ToolStripButton tsImportar;
        private System.Windows.Forms.GroupBox gbEstoque;
        private SGS.Componentes.HacLabel lblEstoqueUnificado;
        private SGS.Componentes.HacLabel lblDigitacao;
        private SGS.Componentes.HacButton btnVerificar;
        private SGS.Componentes.HacTextBox txtData;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacLabel hacLabel3;
        private System.Windows.Forms.GroupBox grbFilial;
        private SGS.Componentes.HacRadioButton rbCE;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private System.Windows.Forms.DataGridView dtgMatMed;
        private SGS.Componentes.HacLabel lblContagemFechada;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacLabel lblFechar;
        private SGS.Componentes.HacButton btnFecharNum;
        private SGS.Componentes.HacTextBox txtCodProduto;
        private System.Windows.Forms.Label lblCodProd;
        private SGS.Componentes.HacCheckBox cbDigitar;
        private System.Windows.Forms.PictureBox btnPesquisaItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumFabLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtd;
        private System.Windows.Forms.DataGridViewButtonColumn colDel;
        private System.Windows.Forms.DataGridViewButtonColumn colZerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
    }
}