namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmConferenciaPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConferenciaPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.btnFinalizar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtCodProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblCodProd = new System.Windows.Forms.Label();
            this.dtgMatMed = new System.Windows.Forms.DataGridView();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumFabLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdForn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdConf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colQtdDif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDataDisp = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblDataDisp = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtStatus = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtSetor = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtLocal = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtUnidade = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtIdRequisicao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cbDigitar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuarioDisp = new System.Windows.Forms.Label();
            this.lblUsuarioDispCabecalho = new System.Windows.Forms.Label();
            this.lblUsuarioReq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(744, 28);
            this.tsHac.TabIndex = 85;
            this.tsHac.TituloTela = "Conferência de Pedido Padrão";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.AlterarStatus = false;
            this.btnFinalizar.BackColor = System.Drawing.Color.White;
            this.btnFinalizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.BackgroundImage")));
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(546, 160);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(187, 22);
            this.btnFinalizar.TabIndex = 171;
            this.btnFinalizar.Text = "DEVOLVER DIF. / FINALIZAR";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Visible = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCodProduto.Enabled = false;
            this.txtCodProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtCodProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodProduto.Limpar = true;
            this.txtCodProduto.Location = new System.Drawing.Point(88, 161);
            this.txtCodProduto.MaxLength = 50;
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.NaoAjustarEdicao = false;
            this.txtCodProduto.Obrigatorio = true;
            this.txtCodProduto.ObrigatorioMensagem = "Código Obrigatorio";
            this.txtCodProduto.PreValidacaoMensagem = null;
            this.txtCodProduto.PreValidado = false;
            this.txtCodProduto.SelectAllOnFocus = false;
            this.txtCodProduto.Size = new System.Drawing.Size(137, 21);
            this.txtCodProduto.TabIndex = 170;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProduto_Validating);
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodProd.Location = new System.Drawing.Point(14, 165);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(70, 13);
            this.lblCodProd.TabIndex = 169;
            this.lblCodProd.Text = "Cod. Barra";
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeColumns = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMatMed.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProduto,
            this.colDescricao,
            this.colCodLote,
            this.colNumFabLote,
            this.colQtdForn,
            this.colQtdConf,
            this.colDel,
            this.colQtdDif,
            this.colIdLote,
            this.colData,
            this.colIdGrupo});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgMatMed.Location = new System.Drawing.Point(7, 191);
            this.dtgMatMed.MultiSelect = false;
            this.dtgMatMed.Name = "dtgMatMed";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.RowTemplate.Height = 18;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(730, 302);
            this.dtgMatMed.TabIndex = 168;
            this.dtgMatMed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellContentClick);
            this.dtgMatMed.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgMatMed_CellFormatting);
            // 
            // colIdProduto
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdProduto.DefaultCellStyle = dataGridViewCellStyle2;
            this.colIdProduto.HeaderText = "ID";
            this.colIdProduto.MaxInputLength = 9;
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.ReadOnly = true;
            this.colIdProduto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIdProduto.Visible = false;
            this.colIdProduto.Width = 110;
            // 
            // colDescricao
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescricao.HeaderText = "Produto";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 345;
            // 
            // colCodLote
            // 
            this.colCodLote.HeaderText = "Cd. Lote";
            this.colCodLote.Name = "colCodLote";
            this.colCodLote.ReadOnly = true;
            this.colCodLote.Visible = false;
            this.colCodLote.Width = 70;
            // 
            // colNumFabLote
            // 
            this.colNumFabLote.HeaderText = "Lote Fab.";
            this.colNumFabLote.Name = "colNumFabLote";
            this.colNumFabLote.ReadOnly = true;
            this.colNumFabLote.Width = 85;
            // 
            // colQtdForn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colQtdForn.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQtdForn.HeaderText = "Qt. Fornecida";
            this.colQtdForn.MaxInputLength = 5;
            this.colQtdForn.Name = "colQtdForn";
            this.colQtdForn.ReadOnly = true;
            this.colQtdForn.Width = 90;
            // 
            // colQtdConf
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.colQtdConf.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQtdConf.HeaderText = "Qt. Conferida";
            this.colQtdConf.MaxInputLength = 5;
            this.colQtdConf.Name = "colQtdConf";
            this.colQtdConf.ReadOnly = true;
            // 
            // colDel
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.NullValue = "-";
            this.colDel.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colDel.HeaderText = "";
            this.colDel.Name = "colDel";
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDel.Text = "-";
            this.colDel.ToolTipText = "SUBTRAIR";
            this.colDel.Width = 20;
            // 
            // colQtdDif
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "N0";
            this.colQtdDif.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQtdDif.HeaderText = "Qt. Dif.";
            this.colQtdDif.Name = "colQtdDif";
            this.colQtdDif.ReadOnly = true;
            this.colQtdDif.Width = 70;
            // 
            // colIdLote
            // 
            this.colIdLote.HeaderText = "colIdLote";
            this.colIdLote.Name = "colIdLote";
            this.colIdLote.Visible = false;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Visible = false;
            // 
            // colIdGrupo
            // 
            this.colIdGrupo.HeaderText = "colIdGrupo";
            this.colIdGrupo.Name = "colIdGrupo";
            this.colIdGrupo.ReadOnly = true;
            this.colIdGrupo.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDataDisp);
            this.groupBox1.Controls.Add(this.lblDataDisp);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.hacLabel6);
            this.groupBox1.Controls.Add(this.txtSetor);
            this.groupBox1.Controls.Add(this.txtLocal);
            this.groupBox1.Controls.Add(this.txtUnidade);
            this.groupBox1.Controls.Add(this.txtIdRequisicao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hacLabel1);
            this.groupBox1.Controls.Add(this.hacLabel3);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 119);
            this.groupBox1.TabIndex = 172;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requisição";
            // 
            // txtDataDisp
            // 
            this.txtDataDisp.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataDisp.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataDisp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataDisp.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDataDisp.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDataDisp.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDataDisp.Limpar = true;
            this.txtDataDisp.Location = new System.Drawing.Point(512, 18);
            this.txtDataDisp.MaxLength = 50;
            this.txtDataDisp.Name = "txtDataDisp";
            this.txtDataDisp.NaoAjustarEdicao = true;
            this.txtDataDisp.Obrigatorio = false;
            this.txtDataDisp.ObrigatorioMensagem = "";
            this.txtDataDisp.PreValidacaoMensagem = null;
            this.txtDataDisp.PreValidado = false;
            this.txtDataDisp.SelectAllOnFocus = false;
            this.txtDataDisp.Size = new System.Drawing.Size(165, 21);
            this.txtDataDisp.TabIndex = 128;
            this.txtDataDisp.Visible = false;
            // 
            // lblDataDisp
            // 
            this.lblDataDisp.AutoSize = true;
            this.lblDataDisp.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDataDisp.Location = new System.Drawing.Point(398, 22);
            this.lblDataDisp.Name = "lblDataDisp";
            this.lblDataDisp.Size = new System.Drawing.Size(110, 13);
            this.lblDataDisp.TabIndex = 127;
            this.lblDataDisp.Text = "Data Dispensação";
            this.lblDataDisp.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtStatus.BackColor = System.Drawing.Color.Honeydew;
            this.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatus.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtStatus.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtStatus.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtStatus.Limpar = true;
            this.txtStatus.Location = new System.Drawing.Point(67, 82);
            this.txtStatus.MaxLength = 50;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.NaoAjustarEdicao = true;
            this.txtStatus.Obrigatorio = false;
            this.txtStatus.ObrigatorioMensagem = "";
            this.txtStatus.PreValidacaoMensagem = null;
            this.txtStatus.PreValidado = false;
            this.txtStatus.SelectAllOnFocus = false;
            this.txtStatus.Size = new System.Drawing.Size(390, 21);
            this.txtStatus.TabIndex = 126;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(14, 86);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(43, 13);
            this.hacLabel6.TabIndex = 125;
            this.hacLabel6.Text = "Status";
            // 
            // txtSetor
            // 
            this.txtSetor.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtSetor.BackColor = System.Drawing.Color.Honeydew;
            this.txtSetor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtSetor.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSetor.Limpar = true;
            this.txtSetor.Location = new System.Drawing.Point(512, 52);
            this.txtSetor.MaxLength = 50;
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.NaoAjustarEdicao = true;
            this.txtSetor.Obrigatorio = false;
            this.txtSetor.ObrigatorioMensagem = "";
            this.txtSetor.PreValidacaoMensagem = null;
            this.txtSetor.PreValidado = false;
            this.txtSetor.SelectAllOnFocus = false;
            this.txtSetor.Size = new System.Drawing.Size(165, 21);
            this.txtSetor.TabIndex = 117;
            // 
            // txtLocal
            // 
            this.txtLocal.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtLocal.BackColor = System.Drawing.Color.Honeydew;
            this.txtLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtLocal.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtLocal.Limpar = true;
            this.txtLocal.Location = new System.Drawing.Point(292, 52);
            this.txtLocal.MaxLength = 50;
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.NaoAjustarEdicao = true;
            this.txtLocal.Obrigatorio = false;
            this.txtLocal.ObrigatorioMensagem = "";
            this.txtLocal.PreValidacaoMensagem = null;
            this.txtLocal.PreValidado = false;
            this.txtLocal.SelectAllOnFocus = false;
            this.txtLocal.Size = new System.Drawing.Size(165, 21);
            this.txtLocal.TabIndex = 116;
            // 
            // txtUnidade
            // 
            this.txtUnidade.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidade.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidade.Limpar = true;
            this.txtUnidade.Location = new System.Drawing.Point(67, 52);
            this.txtUnidade.MaxLength = 50;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.NaoAjustarEdicao = true;
            this.txtUnidade.Obrigatorio = false;
            this.txtUnidade.ObrigatorioMensagem = "";
            this.txtUnidade.PreValidacaoMensagem = null;
            this.txtUnidade.PreValidado = false;
            this.txtUnidade.SelectAllOnFocus = false;
            this.txtUnidade.Size = new System.Drawing.Size(165, 21);
            this.txtUnidade.TabIndex = 115;
            // 
            // txtIdRequisicao
            // 
            this.txtIdRequisicao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtIdRequisicao.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdRequisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdRequisicao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdRequisicao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtIdRequisicao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdRequisicao.Limpar = true;
            this.txtIdRequisicao.Location = new System.Drawing.Point(67, 22);
            this.txtIdRequisicao.MaxLength = 13;
            this.txtIdRequisicao.Name = "txtIdRequisicao";
            this.txtIdRequisicao.NaoAjustarEdicao = true;
            this.txtIdRequisicao.Obrigatorio = false;
            this.txtIdRequisicao.ObrigatorioMensagem = null;
            this.txtIdRequisicao.PreValidacaoMensagem = null;
            this.txtIdRequisicao.PreValidado = false;
            this.txtIdRequisicao.SelectAllOnFocus = false;
            this.txtIdRequisicao.Size = new System.Drawing.Size(165, 21);
            this.txtIdRequisicao.TabIndex = 108;
            this.txtIdRequisicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdRequisicao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdRequisicao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Código";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 56);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 103;
            this.hacLabel1.Text = "Unidade";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(470, 56);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 105;
            this.hacLabel3.Text = "Setor";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(251, 56);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 104;
            this.hacLabel2.Text = "Local";
            // 
            // cbDigitar
            // 
            this.cbDigitar.AutoSize = true;
            this.cbDigitar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbDigitar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbDigitar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDigitar.Limpar = true;
            this.cbDigitar.Location = new System.Drawing.Point(237, 165);
            this.cbDigitar.Name = "cbDigitar";
            this.cbDigitar.Obrigatorio = false;
            this.cbDigitar.ObrigatorioMensagem = null;
            this.cbDigitar.PreValidacaoMensagem = null;
            this.cbDigitar.PreValidado = false;
            this.cbDigitar.Size = new System.Drawing.Size(123, 17);
            this.cbDigitar.TabIndex = 173;
            this.cbDigitar.Text = "DIGITAR QTDE.";
            this.cbDigitar.UseVisualStyleBackColor = true;
            this.cbDigitar.Click += new System.EventHandler(this.cbDigitar_Click);
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUsuario.Controls.Add(this.label2);
            this.pnlUsuario.Controls.Add(this.lblUsuarioDisp);
            this.pnlUsuario.Controls.Add(this.lblUsuarioDispCabecalho);
            this.pnlUsuario.Controls.Add(this.lblUsuarioReq);
            this.pnlUsuario.Location = new System.Drawing.Point(7, 501);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(505, 50);
            this.pnlUsuario.TabIndex = 174;
            this.pnlUsuario.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Usuário Requisição:";
            // 
            // lblUsuarioDisp
            // 
            this.lblUsuarioDisp.AutoSize = true;
            this.lblUsuarioDisp.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUsuarioDisp.Location = new System.Drawing.Point(137, 27);
            this.lblUsuarioDisp.Name = "lblUsuarioDisp";
            this.lblUsuarioDisp.Size = new System.Drawing.Size(19, 13);
            this.lblUsuarioDisp.TabIndex = 115;
            this.lblUsuarioDisp.Text = "--";
            // 
            // lblUsuarioDispCabecalho
            // 
            this.lblUsuarioDispCabecalho.AutoSize = true;
            this.lblUsuarioDispCabecalho.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUsuarioDispCabecalho.Location = new System.Drawing.Point(8, 27);
            this.lblUsuarioDispCabecalho.Name = "lblUsuarioDispCabecalho";
            this.lblUsuarioDispCabecalho.Size = new System.Drawing.Size(131, 13);
            this.lblUsuarioDispCabecalho.TabIndex = 113;
            this.lblUsuarioDispCabecalho.Text = "Usuário Dispensação:";
            // 
            // lblUsuarioReq
            // 
            this.lblUsuarioReq.AutoSize = true;
            this.lblUsuarioReq.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUsuarioReq.Location = new System.Drawing.Point(137, 7);
            this.lblUsuarioReq.Name = "lblUsuarioReq";
            this.lblUsuarioReq.Size = new System.Drawing.Size(0, 13);
            this.lblUsuarioReq.TabIndex = 114;
            // 
            // FrmConferenciaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 561);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.cbDigitar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.lblCodProd);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmConferenciaPedido";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmConferenciaPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacButton btnFinalizar;
        private SGS.Componentes.HacTextBox txtCodProduto;
        private System.Windows.Forms.Label lblCodProd;
        private System.Windows.Forms.DataGridView dtgMatMed;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacTextBox txtDataDisp;
        private SGS.Componentes.HacLabel lblDataDisp;
        private SGS.Componentes.HacTextBox txtStatus;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacTextBox txtSetor;
        private SGS.Componentes.HacTextBox txtLocal;
        private SGS.Componentes.HacTextBox txtUnidade;
        private SGS.Componentes.HacTextBox txtIdRequisicao;
        private System.Windows.Forms.Label label1;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacCheckBox cbDigitar;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuarioDisp;
        private System.Windows.Forms.Label lblUsuarioDispCabecalho;
        private System.Windows.Forms.Label lblUsuarioReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumFabLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdForn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdConf;
        private System.Windows.Forms.DataGridViewButtonColumn colDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdDif;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdGrupo;
    }
}