namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmLivroRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLivroRegistro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.tsbGerarDados = new System.Windows.Forms.ToolStripButton();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMes = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtAno = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbEstoque = new System.Windows.Forms.GroupBox();
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.chbExcluirDadosPosteriores = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.dtgItem = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistManual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdPerda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblData = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.tsHac.SuspendLayout();
            this.grbEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGerarDados});
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(934, 28);
            this.tsHac.TabIndex = 126;
            this.tsHac.Text = "Livro Oficial de Registro";
            this.tsHac.TituloTela = "Livro Oficial de Registro";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            this.tsHac.ImprimirClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_ImprimirClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // tsbGerarDados
            // 
            this.tsbGerarDados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbGerarDados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsbGerarDados.Image = ((System.Drawing.Image)(resources.GetObject("tsbGerarDados.Image")));
            this.tsbGerarDados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGerarDados.Name = "tsbGerarDados";
            this.tsbGerarDados.Size = new System.Drawing.Size(112, 25);
            this.tsbGerarDados.Text = "Gerar Dados Livro";
            this.tsbGerarDados.Click += new System.EventHandler(this.tsbGerarDados_Click);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(102, 86);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(12, 13);
            this.hacLabel3.TabIndex = 142;
            this.hacLabel3.Text = "/";
            // 
            // txtMes
            // 
            this.txtMes.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMes.BackColor = System.Drawing.Color.Honeydew;
            this.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtMes.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMes.Limpar = true;
            this.txtMes.Location = new System.Drawing.Point(70, 82);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.NaoAjustarEdicao = true;
            this.txtMes.Obrigatorio = false;
            this.txtMes.ObrigatorioMensagem = null;
            this.txtMes.PreValidacaoMensagem = null;
            this.txtMes.PreValidado = false;
            this.txtMes.SelectAllOnFocus = false;
            this.txtMes.Size = new System.Drawing.Size(30, 21);
            this.txtMes.TabIndex = 140;
            // 
            // txtAno
            // 
            this.txtAno.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAno.BackColor = System.Drawing.Color.Honeydew;
            this.txtAno.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAno.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAno.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAno.Limpar = true;
            this.txtAno.Location = new System.Drawing.Point(116, 82);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.NaoAjustarEdicao = true;
            this.txtAno.Obrigatorio = false;
            this.txtAno.ObrigatorioMensagem = "";
            this.txtAno.PreValidacaoMensagem = "";
            this.txtAno.PreValidado = false;
            this.txtAno.SelectAllOnFocus = false;
            this.txtAno.Size = new System.Drawing.Size(40, 21);
            this.txtAno.TabIndex = 141;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(8, 86);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(56, 13);
            this.hacLabel1.TabIndex = 139;
            this.hacLabel1.Text = "Mês/Ano";
            // 
            // grbEstoque
            // 
            this.grbEstoque.Controls.Add(this.rbHac);
            this.grbEstoque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEstoque.Location = new System.Drawing.Point(291, 31);
            this.grbEstoque.Name = "grbEstoque";
            this.grbEstoque.Size = new System.Drawing.Size(73, 41);
            this.grbEstoque.TabIndex = 143;
            this.grbEstoque.TabStop = false;
            this.grbEstoque.Text = "Estoque";
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(10, 17);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(50, 17);
            this.rbHac.TabIndex = 1;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(229, 84);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 16);
            this.lblProduto.TabIndex = 145;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(172, 86);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(51, 13);
            this.hacLabel2.TabIndex = 144;
            this.hacLabel2.Text = "Produto";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(10, 47);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(53, 13);
            this.hacLabel4.TabIndex = 147;
            this.hacLabel4.Text = "Unidade";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(68, 44);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(210, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 146;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // chbExcluirDadosPosteriores
            // 
            this.chbExcluirDadosPosteriores.AutoSize = true;
            this.chbExcluirDadosPosteriores.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbExcluirDadosPosteriores.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbExcluirDadosPosteriores.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbExcluirDadosPosteriores.Limpar = true;
            this.chbExcluirDadosPosteriores.Location = new System.Drawing.Point(378, 49);
            this.chbExcluirDadosPosteriores.Name = "chbExcluirDadosPosteriores";
            this.chbExcluirDadosPosteriores.Obrigatorio = false;
            this.chbExcluirDadosPosteriores.ObrigatorioMensagem = null;
            this.chbExcluirDadosPosteriores.PreValidacaoMensagem = null;
            this.chbExcluirDadosPosteriores.PreValidado = false;
            this.chbExcluirDadosPosteriores.Size = new System.Drawing.Size(249, 17);
            this.chbExcluirDadosPosteriores.TabIndex = 148;
            this.chbExcluirDadosPosteriores.Text = "Excluir Dados Posteriores (caso exista)";
            this.chbExcluirDadosPosteriores.UseVisualStyleBackColor = true;
            // 
            // dtgItem
            // 
            this.dtgItem.AllowUserToAddRows = false;
            this.dtgItem.AllowUserToDeleteRows = false;
            this.dtgItem.AllowUserToResizeColumns = false;
            this.dtgItem.AllowUserToResizeRows = false;
            this.dtgItem.AlterarStatus = false;
            this.dtgItem.BackgroundColor = System.Drawing.Color.White;
            this.dtgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colIdProduto,
            this.colData,
            this.colHistorico,
            this.colHistManual,
            this.colObs,
            this.colQtdeEntrada,
            this.colQtdSaida,
            this.colQtdPerda,
            this.colQtdEstoque});
            this.dtgItem.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItem.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItem.GridPesquisa = false;
            this.dtgItem.Limpar = true;
            this.dtgItem.Location = new System.Drawing.Point(4, 124);
            this.dtgItem.Name = "dtgItem";
            this.dtgItem.NaoAjustarEdicao = true;
            this.dtgItem.Obrigatorio = false;
            this.dtgItem.ObrigatorioMensagem = null;
            this.dtgItem.PreValidacaoMensagem = null;
            this.dtgItem.PreValidado = false;
            this.dtgItem.RowHeadersVisible = false;
            this.dtgItem.RowHeadersWidth = 25;
            this.dtgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItem.Size = new System.Drawing.Size(925, 565);
            this.dtgItem.TabIndex = 158;
            this.dtgItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItem_CellValueChanged);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 75;
            // 
            // colIdProduto
            // 
            this.colIdProduto.HeaderText = "colIdProduto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.ReadOnly = true;
            this.colIdProduto.Visible = false;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 75;
            // 
            // colHistorico
            // 
            this.colHistorico.HeaderText = "Histórico";
            this.colHistorico.MaxInputLength = 249;
            this.colHistorico.Name = "colHistorico";
            this.colHistorico.ReadOnly = true;
            this.colHistorico.Width = 250;
            // 
            // colHistManual
            // 
            this.colHistManual.HeaderText = "Historico Manual";
            this.colHistManual.Name = "colHistManual";
            this.colHistManual.Width = 200;
            // 
            // colObs
            // 
            this.colObs.HeaderText = "Observação";
            this.colObs.MaxInputLength = 249;
            this.colObs.Name = "colObs";
            this.colObs.Width = 200;
            // 
            // colQtdeEntrada
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.colQtdeEntrada.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQtdeEntrada.HeaderText = "Qtd. Entrada";
            this.colQtdeEntrada.Name = "colQtdeEntrada";
            this.colQtdeEntrada.ReadOnly = true;
            this.colQtdeEntrada.Width = 90;
            // 
            // colQtdSaida
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.colQtdSaida.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtdSaida.HeaderText = "Qtd. Saida";
            this.colQtdSaida.Name = "colQtdSaida";
            this.colQtdSaida.ReadOnly = true;
            this.colQtdSaida.Width = 80;
            // 
            // colQtdPerda
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Format = "N0";
            this.colQtdPerda.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQtdPerda.HeaderText = "Qtd. Perda";
            this.colQtdPerda.Name = "colQtdPerda";
            this.colQtdPerda.ReadOnly = true;
            this.colQtdPerda.Width = 80;
            // 
            // colQtdEstoque
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.colQtdEstoque.DefaultCellStyle = dataGridViewCellStyle8;
            this.colQtdEstoque.HeaderText = "Estoque";
            this.colQtdEstoque.Name = "colQtdEstoque";
            this.colQtdEstoque.ReadOnly = true;
            this.colQtdEstoque.Width = 80;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.Red;
            this.lblData.Location = new System.Drawing.Point(230, 106);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(0, 12);
            this.lblData.TabIndex = 159;
            // 
            // FrmLivroRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 702);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtgItem);
            this.Controls.Add(this.chbExcluirDadosPosteriores);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.grbEstoque);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmLivroRegistro";
            this.Text = "Livro Oficial de Registro";
            this.Load += new System.EventHandler(this.FrmLivroRegistro_Load);
            this.tsHac.ResumeLayout(false);
            this.tsHac.PerformLayout();
            this.grbEstoque.ResumeLayout(false);
            this.grbEstoque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacTextBox txtMes;
        private SGS.Componentes.HacTextBox txtAno;
        private SGS.Componentes.HacLabel hacLabel1;
        private System.Windows.Forms.GroupBox grbEstoque;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacLabel lblProduto;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacCheckBox chbExcluirDadosPosteriores;
        private System.Windows.Forms.ToolStripButton tsbGerarDados;
        private SGS.Componentes.HacDataGridView dtgItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistManual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdPerda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdEstoque;
        private SGS.Componentes.HacLabel lblData;
    }
}