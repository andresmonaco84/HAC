namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmEstoqueOnlineLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstoqueOnlineLote));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblEstComp = new System.Windows.Forms.ToolStripLabel();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.mnuEstoqueOnLine = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemImp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransfere = new System.Windows.Forms.ToolStripMenuItem();
            this.chkLotesSaldo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkTodos = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtAtualiza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlAtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDataVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFlFracionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdtProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimilar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colEnderecoAlmox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsHac.SuspendLayout();
            this.grbFilial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.mnuEstoqueOnLine.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstComp});
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 121;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Estoque On-Line Lote";
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // lblEstComp
            // 
            this.lblEstComp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEstComp.ForeColor = System.Drawing.Color.Red;
            this.lblEstComp.Name = "lblEstComp";
            this.lblEstComp.Size = new System.Drawing.Size(69, 25);
            this.lblEstComp.Text = "lblEstComp";
            this.lblEstComp.Visible = false;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(409, 36);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 148;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(237, 33);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(170, 21);
            this.cmbLocal.TabIndex = 147;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(199, 36);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 146;
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
            this.cmbUnidade.Location = new System.Drawing.Point(60, 33);
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
            this.cmbUnidade.TabIndex = 145;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(3, 36);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 144;
            this.hacLabel1.Text = "Unidade";
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbCE);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(646, 24);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(141, 36);
            this.grbFilial.TabIndex = 150;
            this.grbFilial.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(73, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = true;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 118;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.CheckedChanged += new System.EventHandler(this.rbCE_CheckedChanged);
            this.rbCE.Click += new System.EventHandler(this.rbCE_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(20, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 2;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.CheckedChanged += new System.EventHandler(this.rbHac_CheckedChanged);
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
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
            this.cmbSetor.Location = new System.Drawing.Point(449, 33);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 149;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
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
            this.colDsProduto,
            this.colCodLote,
            this.colNumLote,
            this.colQtdeLote,
            this.colDtAtualiza,
            this.colFlAtivo,
            this.colDataVal,
            this.colMAV,
            this.colFlFracionado,
            this.colIdtProduto,
            this.colSimilar,
            this.colEnderecoAlmox});
            this.dtgMatMed.ContextMenuStrip = this.mnuEstoqueOnLine;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridColor = System.Drawing.Color.Silver;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(6, 84);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.RowTemplate.Height = 18;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(780, 435);
            this.dtgMatMed.TabIndex = 152;
            this.dtgMatMed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellClick);
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            this.dtgMatMed.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgMatMed_CellFormatting);
            this.dtgMatMed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtgMatMed_MouseDown);
            // 
            // mnuEstoqueOnLine
            // 
            this.mnuEstoqueOnLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemImp,
            this.mnuTransfere});
            this.mnuEstoqueOnLine.Name = "mnuEstoqueOnLine";
            this.mnuEstoqueOnLine.Size = new System.Drawing.Size(148, 48);
            // 
            // mnuItemImp
            // 
            this.mnuItemImp.Name = "mnuItemImp";
            this.mnuItemImp.Size = new System.Drawing.Size(147, 22);
            this.mnuItemImp.Text = "Imprimir Item";
            this.mnuItemImp.Visible = false;
            this.mnuItemImp.Click += new System.EventHandler(this.mnuItemImp_Click);
            // 
            // mnuTransfere
            // 
            this.mnuTransfere.Name = "mnuTransfere";
            this.mnuTransfere.Size = new System.Drawing.Size(147, 22);
            this.mnuTransfere.Text = "Transferência";
            this.mnuTransfere.Click += new System.EventHandler(this.mnuTransfere_Click);
            // 
            // chkLotesSaldo
            // 
            this.chkLotesSaldo.AutoSize = true;
            this.chkLotesSaldo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chkLotesSaldo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkLotesSaldo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLotesSaldo.Limpar = true;
            this.chkLotesSaldo.Location = new System.Drawing.Point(259, 62);
            this.chkLotesSaldo.Name = "chkLotesSaldo";
            this.chkLotesSaldo.Obrigatorio = false;
            this.chkLotesSaldo.ObrigatorioMensagem = null;
            this.chkLotesSaldo.PreValidacaoMensagem = null;
            this.chkLotesSaldo.PreValidado = false;
            this.chkLotesSaldo.Size = new System.Drawing.Size(198, 17);
            this.chkLotesSaldo.TabIndex = 153;
            this.chkLotesSaldo.Text = "APENAS LOTES COM SALDO";
            this.chkLotesSaldo.UseVisualStyleBackColor = true;
            this.chkLotesSaldo.Click += new System.EventHandler(this.chkLotesSaldo_Click);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Checked = true;
            this.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chkTodos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkTodos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.Limpar = true;
            this.chkTodos.Location = new System.Drawing.Point(10, 62);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Obrigatorio = false;
            this.chkTodos.ObrigatorioMensagem = null;
            this.chkTodos.PreValidacaoMensagem = null;
            this.chkTodos.PreValidado = false;
            this.chkTodos.Size = new System.Drawing.Size(242, 17);
            this.chkTodos.TabIndex = 154;
            this.chkTodos.Text = "TODOS MEDICAMENTOS COM LOTE";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.Click += new System.EventHandler(this.chkTodos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hacLabel6);
            this.groupBox1.Controls.Add(this.hacLabel5);
            this.groupBox1.Controls.Add(this.hacLabel4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(367, 522);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 40);
            this.groupBox1.TabIndex = 155;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legenda (Cor das Células)";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(368, 19);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(46, 12);
            this.hacLabel6.TabIndex = 130;
            this.hacLabel6.Text = "Vencido";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(195, 19);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(148, 12);
            this.hacLabel5.TabIndex = 129;
            this.hacLabel5.Text = "Vence nos próximos 30 dias";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(23, 20);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(148, 12);
            this.hacLabel4.TabIndex = 128;
            this.hacLabel4.Text = "Vence nos próximos 60 dias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 126;
            this.label3.Text = "  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(179, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 125;
            this.label2.Text = "  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(351, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 124;
            this.label1.Text = "  ";
            // 
            // colDsProduto
            // 
            this.colDsProduto.HeaderText = "Medicamento";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 285;
            // 
            // colCodLote
            // 
            this.colCodLote.HeaderText = "Cod Lote";
            this.colCodLote.Name = "colCodLote";
            this.colCodLote.ReadOnly = true;
            this.colCodLote.Width = 73;
            // 
            // colNumLote
            // 
            this.colNumLote.HeaderText = "Lote Fabr.";
            this.colNumLote.Name = "colNumLote";
            this.colNumLote.ReadOnly = true;
            this.colNumLote.Width = 78;
            // 
            // colQtdeLote
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colQtdeLote.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtdeLote.HeaderText = "Saldo";
            this.colQtdeLote.Name = "colQtdeLote";
            this.colQtdeLote.ReadOnly = true;
            this.colQtdeLote.Width = 75;
            // 
            // colDtAtualiza
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.colDtAtualiza.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDtAtualiza.HeaderText = "Dt. Atualização";
            this.colDtAtualiza.Name = "colDtAtualiza";
            this.colDtAtualiza.ReadOnly = true;
            this.colDtAtualiza.Width = 125;
            // 
            // colFlAtivo
            // 
            this.colFlAtivo.HeaderText = "Ativo";
            this.colFlAtivo.Name = "colFlAtivo";
            this.colFlAtivo.ReadOnly = true;
            this.colFlAtivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFlAtivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colFlAtivo.Visible = false;
            this.colFlAtivo.Width = 50;
            // 
            // colDataVal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.colDataVal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDataVal.HeaderText = "Dt. Val.";
            this.colDataVal.Name = "colDataVal";
            this.colDataVal.ReadOnly = true;
            this.colDataVal.Width = 90;
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
            // colFlFracionado
            // 
            this.colFlFracionado.FalseValue = "0";
            this.colFlFracionado.HeaderText = "Frac.";
            this.colFlFracionado.Name = "colFlFracionado";
            this.colFlFracionado.ReadOnly = true;
            this.colFlFracionado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFlFracionado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colFlFracionado.TrueValue = "1";
            this.colFlFracionado.Width = 35;
            // 
            // colIdtProduto
            // 
            this.colIdtProduto.HeaderText = "ID";
            this.colIdtProduto.Name = "colIdtProduto";
            this.colIdtProduto.ReadOnly = true;
            this.colIdtProduto.Width = 50;
            // 
            // colSimilar
            // 
            this.colSimilar.ActiveLinkColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSimilar.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSimilar.HeaderText = "";
            this.colSimilar.LinkColor = System.Drawing.Color.Blue;
            this.colSimilar.Name = "colSimilar";
            this.colSimilar.Text = "SIMILARES";
            this.colSimilar.UseColumnTextForLinkValue = true;
            this.colSimilar.VisitedLinkColor = System.Drawing.Color.Blue;
            this.colSimilar.Width = 75;
            // 
            // colEnderecoAlmox
            // 
            this.colEnderecoAlmox.HeaderText = "Endereço";
            this.colEnderecoAlmox.Name = "colEnderecoAlmox";
            this.colEnderecoAlmox.ReadOnly = true;
            this.colEnderecoAlmox.Visible = false;
            this.colEnderecoAlmox.Width = 60;
            // 
            // FrmEstoqueOnlineLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.chkLotesSaldo);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmEstoqueOnlineLote";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmEstoqueOnlineLote_Load);
            this.tsHac.ResumeLayout(false);
            this.tsHac.PerformLayout();
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.mnuEstoqueOnLine.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel1;
        private System.Windows.Forms.GroupBox grbFilial;
        private SGS.Componentes.HacRadioButton rbCE;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacDataGridView dtgMatMed;
        private System.Windows.Forms.ToolStripLabel lblEstComp;
        private SGS.Componentes.HacCheckBox chkLotesSaldo;
        private SGS.Componentes.HacCheckBox chkTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip mnuEstoqueOnLine;
        private System.Windows.Forms.ToolStripMenuItem mnuItemImp;
        private System.Windows.Forms.ToolStripMenuItem mnuTransfere;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtAtualiza;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFlAtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFlFracionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProduto;
        private System.Windows.Forms.DataGridViewLinkColumn colSimilar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnderecoAlmox;
    }
}