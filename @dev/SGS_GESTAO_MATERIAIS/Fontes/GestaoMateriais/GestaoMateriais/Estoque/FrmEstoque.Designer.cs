using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmEstoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstoque));
            this.dtgMatMed = new HacDataGridView(this.components);
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercRessuprimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFornecido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsumido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercentual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpMatMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlFracionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDtFornecimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSimilar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colIdtProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsHac = new HacToolStrip(this.components);
            this.lblProdNaoPadrao = new HacLabel(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.hacLabel7 = new HacLabel(this.components);
            this.hacLabel6 = new HacLabel(this.components);
            this.hacLabel5 = new HacLabel(this.components);
            this.hacLabel4 = new HacLabel(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hacLabel8 = new HacLabel(this.components);
            this.hacLabel3 = new HacLabel(this.components);
            this.cmbLocal = new HacCmbLocal(this.components);
            this.hacLabel2 = new HacLabel(this.components);
            this.cmbUnidade = new HacCmbUnidade(this.components);
            this.hacLabel1 = new HacLabel(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbCE = new HacRadioButton(this.components);
            this.rbAcs = new HacRadioButton(this.components);
            this.rbHac = new HacRadioButton(this.components);
            this.cmbSetor = new HacCmbSetor(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.AlterarStatus = true;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDsProduto,
            this.colPercRessuprimento,
            this.colQtdePadrao,
            this.ColFornecido,
            this.colConsumido,
            this.colOutros,
            this.colQtdeEstoque,
            this.colPercentual,
            this.colIr,
            this.colTpMatMed,
            this.colFlFracionado,
            this.colDtFornecimento,
            this.colSimilar,
            this.colIdtProduto});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgMatMed.Editavel = ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = EstadoObjeto.Habilitado;
            this.dtgMatMed.GridColor = System.Drawing.Color.Silver;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(6, 70);
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
            this.dtgMatMed.Size = new System.Drawing.Size(780, 396);
            this.dtgMatMed.TabIndex = 115;
            this.dtgMatMed.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgMatMed_CellFormatting);
            this.dtgMatMed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellClick);
            // 
            // colDsProduto
            // 
            this.colDsProduto.HeaderText = "Descrição";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 205;
            // 
            // colPercRessuprimento
            // 
            this.colPercRessuprimento.HeaderText = "colPercRessuprimento";
            this.colPercRessuprimento.Name = "colPercRessuprimento";
            this.colPercRessuprimento.Visible = false;
            // 
            // colQtdePadrao
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colQtdePadrao.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQtdePadrao.HeaderText = "Fixo";
            this.colQtdePadrao.Name = "colQtdePadrao";
            this.colQtdePadrao.ReadOnly = true;
            this.colQtdePadrao.Width = 43;
            // 
            // ColFornecido
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.ColFornecido.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColFornecido.HeaderText = "Fornecido*";
            this.ColFornecido.Name = "ColFornecido";
            this.ColFornecido.ReadOnly = true;
            this.ColFornecido.Width = 62;
            // 
            // colConsumido
            // 
            this.colConsumido.HeaderText = "Consumo";
            this.colConsumido.Name = "colConsumido";
            this.colConsumido.ReadOnly = true;
            this.colConsumido.Width = 60;
            // 
            // colOutros
            // 
            this.colOutros.HeaderText = "Outros";
            this.colOutros.Name = "colOutros";
            this.colOutros.ReadOnly = true;
            this.colOutros.Width = 50;
            // 
            // colQtdeEstoque
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colQtdeEstoque.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQtdeEstoque.HeaderText = "Saldo";
            this.colQtdeEstoque.Name = "colQtdeEstoque";
            this.colQtdeEstoque.ReadOnly = true;
            this.colQtdeEstoque.Width = 70;
            // 
            // colPercentual
            // 
            this.colPercentual.HeaderText = "%";
            this.colPercentual.Name = "colPercentual";
            this.colPercentual.ReadOnly = true;
            this.colPercentual.Width = 30;
            // 
            // colIr
            // 
            this.colIr.HeaderText = "IR";
            this.colIr.Name = "colIr";
            this.colIr.ReadOnly = true;
            this.colIr.Width = 30;
            // 
            // colTpMatMed
            // 
            this.colTpMatMed.HeaderText = "Tipo";
            this.colTpMatMed.Name = "colTpMatMed";
            this.colTpMatMed.ReadOnly = true;
            this.colTpMatMed.Width = 40;
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
            this.colFlFracionado.Width = 40;
            // 
            // colDtFornecimento
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.colDtFornecimento.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDtFornecimento.HeaderText = "Dt. Forn.";
            this.colDtFornecimento.Name = "colDtFornecimento";
            this.colDtFornecimento.ReadOnly = true;
            this.colDtFornecimento.Width = 125;
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
            // colIdtProduto
            // 
            this.colIdtProduto.HeaderText = "ID";
            this.colIdtProduto.Name = "colIdtProduto";
            this.colIdtProduto.ReadOnly = true;
            this.colIdtProduto.Visible = false;
            this.colIdtProduto.Width = 50;
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
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 120;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Estoque On-Line";
            // 
            // lblProdNaoPadrao
            // 
            this.lblProdNaoPadrao.AutoSize = true;
            this.lblProdNaoPadrao.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProdNaoPadrao.Location = new System.Drawing.Point(222, 22);
            this.lblProdNaoPadrao.Name = "lblProdNaoPadrao";
            this.lblProdNaoPadrao.Size = new System.Drawing.Size(103, 12);
            this.lblProdNaoPadrao.TabIndex = 121;
            this.lblProdNaoPadrao.Text = "Produto não Padrão";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(686, 544);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 20);
            this.pictureBox1.TabIndex = 122;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.hacLabel7);
            this.groupBox1.Controls.Add(this.hacLabel6);
            this.groupBox1.Controls.Add(this.hacLabel5);
            this.groupBox1.Controls.Add(this.hacLabel4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblProdNaoPadrao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 86);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legenda (Cor das Células)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(206, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 132;
            this.label5.Text = "  ";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(222, 45);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(84, 12);
            this.hacLabel7.TabIndex = 131;
            this.hacLabel7.Text = "Estoque Padrão";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(24, 68);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(151, 12);
            this.hacLabel6.TabIndex = 130;
            this.hacLabel6.Text = "Produto esgotado no estoque";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(24, 45);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(171, 12);
            this.hacLabel5.TabIndex = 129;
            this.hacLabel5.Text = "Falta no estoque entre 80 e 99%";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(24, 22);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(166, 12);
            this.hacLabel4.TabIndex = 128;
            this.hacLabel4.Text = "Atingiu Ponto de Ressuprimento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightBlue;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.ForeColor = System.Drawing.Color.LightBlue;
            this.label4.Location = new System.Drawing.Point(206, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 127;
            this.label4.Text = "  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(7, 20);
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
            this.label2.Location = new System.Drawing.Point(7, 44);
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
            this.label1.Location = new System.Drawing.Point(7, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 124;
            this.label1.Text = "  ";
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(357, 469);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(429, 12);
            this.hacLabel8.TabIndex = 132;
            this.hacLabel8.Text = "* Coluna Fornecido é a soma do que foi fornecido com a qtd. existente anteriormen" +
                "te";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(410, 40);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 137;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(238, 37);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(170, 21);
            this.cmbLocal.TabIndex = 136;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(199, 40);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 135;
            this.hacLabel2.Text = "Local";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = ControleEdicao.Sempre;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = EstadoObjeto.Habilitado;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(59, 37);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(138, 21);
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 134;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(4, 40);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 133;
            this.hacLabel1.Text = "Unidade";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbCE);
            this.groupBox.Controls.Add(this.rbAcs);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(647, 28);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(141, 36);
            this.groupBox.TabIndex = 139;
            this.groupBox.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = ControleEdicao.Sempre;
            this.rbCE.EstadoInicial = EstadoObjeto.Habilitado;
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(99, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 118;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.Click += new System.EventHandler(this.rbCE_Click);
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(52, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 3;
            this.rbAcs.TabStop = true;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Click += new System.EventHandler(this.rbAcs_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(5, 13);
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
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.Editavel = ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(450, 37);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 138;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 140;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmEstoque
            // 
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.hacLabel8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.dtgMatMed);
            this.Name = "FrmEstoque";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmEstoqueOnLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgMatMed;
        private HacToolStrip tsHac;
        private HacLabel lblProdNaoPadrao;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private HacLabel hacLabel4;
        private HacLabel hacLabel5;
        private HacLabel hacLabel6;
        private System.Windows.Forms.Label label5;
        private HacLabel hacLabel7;
        private HacLabel hacLabel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercRessuprimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdePadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFornecido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsumido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercentual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpMatMed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFlFracionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtFornecimento;
        private System.Windows.Forms.DataGridViewLinkColumn colSimilar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProduto;
        private HacLabel hacLabel3;
        private HacCmbLocal cmbLocal;
        private HacLabel hacLabel2;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel1;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbCE;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacCmbSetor cmbSetor;
        private System.Windows.Forms.Button button1;
    }
}
