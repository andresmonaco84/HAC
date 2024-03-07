namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmCadKit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadKit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbKit = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNovo = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnAddItem = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtde = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.chbAtivo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDescricao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtCod = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.dtgItem = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsAssMed = new System.Windows.Forms.ToolStripButton();
            this.tsHac.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAssMed});
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(537, 28);
            this.tsHac.TabIndex = 123;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Cadastro de Kit";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(12, 22);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(29, 13);
            this.hacLabel1.TabIndex = 127;
            this.hacLabel1.Text = "KIT";
            // 
            // cmbKit
            // 
            this.cmbKit.BackColor = System.Drawing.Color.Honeydew;
            this.cmbKit.DisplayMember = "CAD_MTMD_KIT_DSC";
            this.cmbKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKit.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbKit.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbKit.FormattingEnabled = true;
            this.cmbKit.Limpar = false;
            this.cmbKit.Location = new System.Drawing.Point(45, 19);
            this.cmbKit.MaxDropDownItems = 10;
            this.cmbKit.Name = "cmbKit";
            this.cmbKit.Obrigatorio = false;
            this.cmbKit.ObrigatorioMensagem = null;
            this.cmbKit.PreValidacaoMensagem = null;
            this.cmbKit.PreValidado = false;
            this.cmbKit.Size = new System.Drawing.Size(382, 21);
            this.cmbKit.TabIndex = 126;
            this.cmbKit.ValueMember = "CAD_MTMD_KIT_ID";
            this.cmbKit.SelectionChangeCommitted += new System.EventHandler(this.cmbKit_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Controls.Add(this.btnAddItem);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Controls.Add(this.txtQtde);
            this.groupBox1.Controls.Add(this.lblProduto);
            this.groupBox1.Controls.Add(this.hacLabel3);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 79);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item";
            // 
            // btnNovo
            // 
            this.btnNovo.AlterarStatus = true;
            this.btnNovo.BackColor = System.Drawing.Color.White;
            this.btnNovo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNovo.BackgroundImage")));
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(250, 49);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 22);
            this.btnNovo.TabIndex = 157;
            this.btnNovo.Text = "LIMPAR ITEM";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Visible = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.AlterarStatus = true;
            this.btnAddItem.BackColor = System.Drawing.Color.White;
            this.btnAddItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddItem.BackgroundImage")));
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.Enabled = false;
            this.btnAddItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(140, 49);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 22);
            this.btnAddItem.TabIndex = 156;
            this.btnAddItem.Text = "GRAVAR ITEM";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(21, 53);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(38, 13);
            this.hacLabel2.TabIndex = 143;
            this.hacLabel2.Text = "Qtde.";
            // 
            // txtQtde
            // 
            this.txtQtde.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtde.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtde.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtQtde.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtde.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtde.Limpar = true;
            this.txtQtde.Location = new System.Drawing.Point(59, 49);
            this.txtQtde.MaxLength = 3;
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.NaoAjustarEdicao = true;
            this.txtQtde.Obrigatorio = false;
            this.txtQtde.ObrigatorioMensagem = null;
            this.txtQtde.PreValidacaoMensagem = null;
            this.txtQtde.PreValidado = false;
            this.txtQtde.SelectAllOnFocus = false;
            this.txtQtde.Size = new System.Drawing.Size(48, 21);
            this.txtQtde.TabIndex = 142;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(57, 24);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 13);
            this.lblProduto.TabIndex = 131;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(6, 24);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(51, 13);
            this.hacLabel3.TabIndex = 130;
            this.hacLabel3.Text = "Produto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.chbAtivo);
            this.groupBox2.Controls.Add(this.hacLabel5);
            this.groupBox2.Controls.Add(this.cmbKit);
            this.groupBox2.Controls.Add(this.hacLabel4);
            this.groupBox2.Controls.Add(this.hacLabel1);
            this.groupBox2.Controls.Add(this.txtDescricao);
            this.groupBox2.Controls.Add(this.txtCod);
            this.groupBox2.Location = new System.Drawing.Point(18, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 85);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AlterarStatus = true;
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.disk;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(467, 52);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(18, 18);
            this.btnSalvar.TabIndex = 156;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // chbAtivo
            // 
            this.chbAtivo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chbAtivo.AutoSize = true;
            this.chbAtivo.Checked = true;
            this.chbAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAtivo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chbAtivo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chbAtivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.chbAtivo.Limpar = false;
            this.chbAtivo.Location = new System.Drawing.Point(437, 22);
            this.chbAtivo.Name = "chbAtivo";
            this.chbAtivo.Obrigatorio = false;
            this.chbAtivo.ObrigatorioMensagem = null;
            this.chbAtivo.PreValidacaoMensagem = null;
            this.chbAtivo.PreValidado = false;
            this.chbAtivo.Size = new System.Drawing.Size(60, 17);
            this.chbAtivo.TabIndex = 135;
            this.chbAtivo.Text = "Ativo";
            this.chbAtivo.UseVisualStyleBackColor = true;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(105, 54);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(63, 13);
            this.hacLabel5.TabIndex = 135;
            this.hacLabel5.Text = "Descrição";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(10, 54);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(34, 13);
            this.hacLabel4.TabIndex = 134;
            this.hacLabel4.Text = "Cód.";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDescricao.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDescricao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDescricao.Limpar = true;
            this.txtDescricao.Location = new System.Drawing.Point(169, 51);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.NaoAjustarEdicao = false;
            this.txtDescricao.Obrigatorio = true;
            this.txtDescricao.ObrigatorioMensagem = "Digite a Descrição";
            this.txtDescricao.PreValidacaoMensagem = null;
            this.txtDescricao.PreValidado = false;
            this.txtDescricao.SelectAllOnFocus = false;
            this.txtDescricao.Size = new System.Drawing.Size(286, 21);
            this.txtDescricao.TabIndex = 133;
            // 
            // txtCod
            // 
            this.txtCod.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtCod.BackColor = System.Drawing.Color.Honeydew;
            this.txtCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCod.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCod.Enabled = false;
            this.txtCod.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtCod.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCod.Limpar = true;
            this.txtCod.Location = new System.Drawing.Point(46, 51);
            this.txtCod.MaxLength = 10;
            this.txtCod.Name = "txtCod";
            this.txtCod.NaoAjustarEdicao = false;
            this.txtCod.Obrigatorio = false;
            this.txtCod.ObrigatorioMensagem = null;
            this.txtCod.PreValidacaoMensagem = null;
            this.txtCod.PreValidado = false;
            this.txtCod.SelectAllOnFocus = false;
            this.txtCod.Size = new System.Drawing.Size(55, 21);
            this.txtCod.TabIndex = 132;
            this.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgItem
            // 
            this.dtgItem.AllowUserToAddRows = false;
            this.dtgItem.AllowUserToDeleteRows = false;
            this.dtgItem.AllowUserToResizeColumns = false;
            this.dtgItem.AllowUserToResizeRows = false;
            this.dtgItem.AlterarStatus = false;
            this.dtgItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeletar,
            this.colIdProduto,
            this.colDsProduto,
            this.colQtde});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgItem.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItem.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItem.GridPesquisa = false;
            this.dtgItem.Limpar = true;
            this.dtgItem.Location = new System.Drawing.Point(18, 212);
            this.dtgItem.Name = "dtgItem";
            this.dtgItem.NaoAjustarEdicao = true;
            this.dtgItem.Obrigatorio = false;
            this.dtgItem.ObrigatorioMensagem = null;
            this.dtgItem.PreValidacaoMensagem = null;
            this.dtgItem.PreValidado = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgItem.RowHeadersVisible = false;
            this.dtgItem.RowHeadersWidth = 18;
            this.dtgItem.RowTemplate.Height = 18;
            this.dtgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItem.Size = new System.Drawing.Size(501, 278);
            this.dtgItem.TabIndex = 130;
            this.dtgItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItem_CellClick);
            this.dtgItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItem_CellDoubleClick);
            this.dtgItem.SelectionChanged += new System.EventHandler(this.dtgItem_SelectionChanged);
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
            this.colDeletar.Width = 50;
            // 
            // colIdProduto
            // 
            this.colIdProduto.DataPropertyName = "CAD_MTMD_ID";
            this.colIdProduto.HeaderText = "IdProduto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.ReadOnly = true;
            this.colIdProduto.Visible = false;
            this.colIdProduto.Width = 50;
            // 
            // colDsProduto
            // 
            this.colDsProduto.DataPropertyName = "CAD_MTMD_NOMEFANTASIA";
            this.colDsProduto.HeaderText = "Produto";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 370;
            // 
            // colQtde
            // 
            this.colQtde.DataPropertyName = "CAD_MTMD_QTDE";
            dataGridViewCellStyle2.Format = "N0";
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtde.HeaderText = "Qtde.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 70;
            // 
            // tsAssMed
            // 
            this.tsAssMed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsAssMed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsAssMed.Image = ((System.Drawing.Image)(resources.GetObject("tsAssMed.Image")));
            this.tsAssMed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAssMed.Name = "tsAssMed";
            this.tsAssMed.Size = new System.Drawing.Size(122, 17);
            this.tsAssMed.Text = "Associar Aplic. Med.";
            this.tsAssMed.Click += new System.EventHandler(this.tsAssMed_Click);
            // 
            // FrmCadKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 506);
            this.Controls.Add(this.dtgItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmCadKit";
            this.Text = "Cadastro de Kit de Mat/Med";
            this.Load += new System.EventHandler(this.FrmCadKit_Load);
            this.tsHac.ResumeLayout(false);
            this.tsHac.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacComboBox cmbKit;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacLabel lblProduto;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacTextBox txtQtde;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacTextBox txtDescricao;
        private SGS.Componentes.HacTextBox txtCod;
        private SGS.Componentes.HacCheckBox chbAtivo;
        private SGS.Componentes.HacDataGridView dtgItem;
        private SGS.Componentes.HacButton btnSalvar;
        private SGS.Componentes.HacButton btnAddItem;
        private SGS.Componentes.HacButton btnNovo;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.ToolStripButton tsAssMed;
    }
}