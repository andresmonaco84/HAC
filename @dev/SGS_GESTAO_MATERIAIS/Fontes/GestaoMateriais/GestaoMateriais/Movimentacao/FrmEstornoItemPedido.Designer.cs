namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmEstornoItemPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstornoItemPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.tsEstornar = new System.Windows.Forms.ToolStripButton();
            this.tsIndiceDev = new System.Windows.Forms.ToolStripButton();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnPesquisaPac = new System.Windows.Forms.PictureBox();
            this.txtNomePac = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtNroInternacao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtCodProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblCodBarra = new System.Windows.Forms.Label();
            this.grbAtendimento = new System.Windows.Forms.GroupBox();
            this.btnHistorico = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.grpTipoAtendimento = new System.Windows.Forms.GroupBox();
            this.rbAmbulatorio = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbInternado = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.tabConsumo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlIndiceDev = new System.Windows.Forms.Panel();
            this.chkSetor = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtIndiceDev = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtQtdDev = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdForn = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.btnCancelarPlanilha = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnGerarIndice = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDtIni = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel12 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgBaixas = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdtMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtMovRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdFilialReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdUnidadeCentroDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLocalCentroDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSetorCentroDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdUnidadeReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLocalReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSetorReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFracionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReutiliza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoteFab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadePed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetorPed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCentroDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLegendaFrac = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grbDevolver = new System.Windows.Forms.GroupBox();
            this.rbDevFarm = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbDevAlmoxUTI = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.tsHac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).BeginInit();
            this.grbAtendimento.SuspendLayout();
            this.grpTipoAtendimento.SuspendLayout();
            this.tabConsumo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlIndiceDev.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaixas)).BeginInit();
            this.grbDevolver.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEstornar,
            this.tsIndiceDev});
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = "txtNroInternacao";
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 101;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Devolução/Estorno Pedidos";
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            // 
            // tsEstornar
            // 
            this.tsEstornar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsEstornar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsEstornar.Image = ((System.Drawing.Image)(resources.GetObject("tsEstornar.Image")));
            this.tsEstornar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEstornar.Name = "tsEstornar";
            this.tsEstornar.Size = new System.Drawing.Size(175, 25);
            this.tsEstornar.Text = "Estornar Itens Selecionados  ";
            this.tsEstornar.Click += new System.EventHandler(this.tsEstornar_Click);
            // 
            // tsIndiceDev
            // 
            this.tsIndiceDev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsIndiceDev.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsIndiceDev.Image = ((System.Drawing.Image)(resources.GetObject("tsIndiceDev.Image")));
            this.tsIndiceDev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsIndiceDev.Name = "tsIndiceDev";
            this.tsIndiceDev.Size = new System.Drawing.Size(137, 25);
            this.tsIndiceDev.Text = "  Índice de Devolução  ";
            this.tsIndiceDev.Visible = false;
            this.tsIndiceDev.Click += new System.EventHandler(this.tsIndiceDev_Click);
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(165, 45);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(55, 13);
            this.hacLabel7.TabIndex = 123;
            this.hacLabel7.Text = "Paciente";
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(7, 45);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(79, 13);
            this.hacLabel9.TabIndex = 122;
            this.hacLabel9.Text = "Atendimento";
            // 
            // btnPesquisaPac
            // 
            this.btnPesquisaPac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisaPac.BackgroundImage")));
            this.btnPesquisaPac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaPac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaPac.Location = new System.Drawing.Point(575, 41);
            this.btnPesquisaPac.Name = "btnPesquisaPac";
            this.btnPesquisaPac.Size = new System.Drawing.Size(34, 21);
            this.btnPesquisaPac.TabIndex = 121;
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
            this.txtNomePac.Location = new System.Drawing.Point(222, 41);
            this.txtNomePac.Name = "txtNomePac";
            this.txtNomePac.NaoAjustarEdicao = true;
            this.txtNomePac.Obrigatorio = false;
            this.txtNomePac.ObrigatorioMensagem = null;
            this.txtNomePac.PreValidacaoMensagem = null;
            this.txtNomePac.PreValidado = false;
            this.txtNomePac.SelectAllOnFocus = false;
            this.txtNomePac.Size = new System.Drawing.Size(350, 21);
            this.txtNomePac.TabIndex = 120;
            // 
            // txtNroInternacao
            // 
            this.txtNroInternacao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtNroInternacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtNroInternacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroInternacao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtNroInternacao.Enabled = false;
            this.txtNroInternacao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNroInternacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNroInternacao.Limpar = true;
            this.txtNroInternacao.Location = new System.Drawing.Point(87, 41);
            this.txtNroInternacao.MaxLength = 10;
            this.txtNroInternacao.Name = "txtNroInternacao";
            this.txtNroInternacao.NaoAjustarEdicao = true;
            this.txtNroInternacao.Obrigatorio = false;
            this.txtNroInternacao.ObrigatorioMensagem = null;
            this.txtNroInternacao.PreValidacaoMensagem = null;
            this.txtNroInternacao.PreValidado = false;
            this.txtNroInternacao.SelectAllOnFocus = false;
            this.txtNroInternacao.Size = new System.Drawing.Size(72, 21);
            this.txtNroInternacao.TabIndex = 119;
            this.txtNroInternacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroInternacao.Validated += new System.EventHandler(this.txtNroInternacao_Validated);
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCodProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtCodProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodProduto.Limpar = true;
            this.txtCodProduto.Location = new System.Drawing.Point(375, 131);
            this.txtCodProduto.MaxLength = 50;
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.NaoAjustarEdicao = false;
            this.txtCodProduto.Obrigatorio = false;
            this.txtCodProduto.ObrigatorioMensagem = null;
            this.txtCodProduto.PreValidacaoMensagem = null;
            this.txtCodProduto.PreValidado = false;
            this.txtCodProduto.SelectAllOnFocus = false;
            this.txtCodProduto.Size = new System.Drawing.Size(178, 21);
            this.txtCodProduto.TabIndex = 128;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodProduto_Validating);
            // 
            // lblCodBarra
            // 
            this.lblCodBarra.AutoSize = true;
            this.lblCodBarra.Font = new System.Drawing.Font("Verdana", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCodBarra.Location = new System.Drawing.Point(174, 137);
            this.lblCodBarra.Name = "lblCodBarra";
            this.lblCodBarra.Size = new System.Drawing.Size(200, 13);
            this.lblCodBarra.TabIndex = 127;
            this.lblCodBarra.Text = "Cód. Barra Produto Devolução";
            // 
            // grbAtendimento
            // 
            this.grbAtendimento.Controls.Add(this.btnHistorico);
            this.grbAtendimento.Controls.Add(this.grpTipoAtendimento);
            this.grbAtendimento.Controls.Add(this.cmbSetor);
            this.grbAtendimento.Controls.Add(this.cmbLocal);
            this.grbAtendimento.Controls.Add(this.hacLabel4);
            this.grbAtendimento.Controls.Add(this.cmbUnidade);
            this.grbAtendimento.Controls.Add(this.hacLabel5);
            this.grbAtendimento.Controls.Add(this.hacLabel6);
            this.grbAtendimento.Controls.Add(this.txtNomePac);
            this.grbAtendimento.Controls.Add(this.txtNroInternacao);
            this.grbAtendimento.Controls.Add(this.btnPesquisaPac);
            this.grbAtendimento.Controls.Add(this.hacLabel7);
            this.grbAtendimento.Controls.Add(this.hacLabel9);
            this.grbAtendimento.Location = new System.Drawing.Point(6, 23);
            this.grbAtendimento.Name = "grbAtendimento";
            this.grbAtendimento.Size = new System.Drawing.Size(768, 94);
            this.grbAtendimento.TabIndex = 129;
            this.grbAtendimento.TabStop = false;
            // 
            // btnHistorico
            // 
            this.btnHistorico.AlterarStatus = true;
            this.btnHistorico.BackColor = System.Drawing.Color.White;
            this.btnHistorico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHistorico.BackgroundImage")));
            this.btnHistorico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnHistorico.Location = new System.Drawing.Point(612, 68);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(152, 20);
            this.btnHistorico.TabIndex = 136;
            this.btnHistorico.Text = "Histórico Geral Paciente";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // grpTipoAtendimento
            // 
            this.grpTipoAtendimento.Controls.Add(this.rbAmbulatorio);
            this.grpTipoAtendimento.Controls.Add(this.rbInternado);
            this.grpTipoAtendimento.Enabled = false;
            this.grpTipoAtendimento.Location = new System.Drawing.Point(614, 35);
            this.grpTipoAtendimento.Name = "grpTipoAtendimento";
            this.grpTipoAtendimento.Size = new System.Drawing.Size(150, 30);
            this.grpTipoAtendimento.TabIndex = 135;
            this.grpTipoAtendimento.TabStop = false;
            this.grpTipoAtendimento.Text = "Tipo de Atendimento";
            // 
            // rbAmbulatorio
            // 
            this.rbAmbulatorio.AutoSize = true;
            this.rbAmbulatorio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAmbulatorio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAmbulatorio.Limpar = false;
            this.rbAmbulatorio.Location = new System.Drawing.Point(79, 11);
            this.rbAmbulatorio.Name = "rbAmbulatorio";
            this.rbAmbulatorio.Obrigatorio = false;
            this.rbAmbulatorio.ObrigatorioMensagem = null;
            this.rbAmbulatorio.PreValidacaoMensagem = null;
            this.rbAmbulatorio.PreValidado = false;
            this.rbAmbulatorio.Size = new System.Drawing.Size(61, 17);
            this.rbAmbulatorio.TabIndex = 1;
            this.rbAmbulatorio.TabStop = true;
            this.rbAmbulatorio.Text = "Externo";
            this.rbAmbulatorio.UseVisualStyleBackColor = true;
            // 
            // rbInternado
            // 
            this.rbInternado.AutoSize = true;
            this.rbInternado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbInternado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbInternado.Limpar = false;
            this.rbInternado.Location = new System.Drawing.Point(13, 11);
            this.rbInternado.Name = "rbInternado";
            this.rbInternado.Obrigatorio = false;
            this.rbInternado.ObrigatorioMensagem = null;
            this.rbInternado.PreValidacaoMensagem = null;
            this.rbInternado.PreValidado = false;
            this.rbInternado.Size = new System.Drawing.Size(58, 17);
            this.rbInternado.TabIndex = 0;
            this.rbInternado.TabStop = true;
            this.rbInternado.Text = "Interno";
            this.rbInternado.UseVisualStyleBackColor = true;
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = true;
            this.cmbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.Enabled = false;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = true;
            this.cmbSetor.Location = new System.Drawing.Point(566, 12);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(197, 21);
            this.cmbSetor.TabIndex = 134;
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbLocal.Enabled = false;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(305, 12);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(190, 21);
            this.cmbLocal.TabIndex = 133;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(3, 15);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(53, 13);
            this.hacLabel4.TabIndex = 129;
            this.hacLabel4.Text = "Unidade";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
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
            this.cmbUnidade.Location = new System.Drawing.Point(58, 12);
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
            this.cmbUnidade.TabIndex = 132;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(263, 15);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(36, 13);
            this.hacLabel5.TabIndex = 130;
            this.hacLabel5.Text = "Local";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(522, 15);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 131;
            this.hacLabel6.Text = "Setor";
            // 
            // tabConsumo
            // 
            this.tabConsumo.Controls.Add(this.tabPage1);
            this.tabConsumo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConsumo.Location = new System.Drawing.Point(6, 136);
            this.tabConsumo.Name = "tabConsumo";
            this.tabConsumo.SelectedIndex = 0;
            this.tabConsumo.Size = new System.Drawing.Size(775, 385);
            this.tabConsumo.TabIndex = 130;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlIndiceDev);
            this.tabPage1.Controls.Add(this.dtgBaixas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 359);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Movimentos Dispensação";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlIndiceDev
            // 
            this.pnlIndiceDev.Controls.Add(this.chkSetor);
            this.pnlIndiceDev.Controls.Add(this.groupBox1);
            this.pnlIndiceDev.Controls.Add(this.btnCancelarPlanilha);
            this.pnlIndiceDev.Controls.Add(this.btnGerarIndice);
            this.pnlIndiceDev.Controls.Add(this.panel2);
            this.pnlIndiceDev.Controls.Add(this.txtDtFim);
            this.pnlIndiceDev.Controls.Add(this.hacLabel11);
            this.pnlIndiceDev.Controls.Add(this.txtDtIni);
            this.pnlIndiceDev.Controls.Add(this.hacLabel12);
            this.pnlIndiceDev.Location = new System.Drawing.Point(218, 28);
            this.pnlIndiceDev.Name = "pnlIndiceDev";
            this.pnlIndiceDev.Size = new System.Drawing.Size(314, 197);
            this.pnlIndiceDev.TabIndex = 167;
            this.pnlIndiceDev.Visible = false;
            // 
            // chkSetor
            // 
            this.chkSetor.AutoSize = true;
            this.chkSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chkSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkSetor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSetor.Limpar = true;
            this.chkSetor.Location = new System.Drawing.Point(38, 63);
            this.chkSetor.Name = "chkSetor";
            this.chkSetor.Obrigatorio = false;
            this.chkSetor.ObrigatorioMensagem = null;
            this.chkSetor.PreValidacaoMensagem = null;
            this.chkSetor.PreValidado = false;
            this.chkSetor.Size = new System.Drawing.Size(79, 17);
            this.chkSetor.TabIndex = 169;
            this.chkSetor.Text = "Por Setor";
            this.chkSetor.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.hacLabel3);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Controls.Add(this.txtIndiceDev);
            this.groupBox1.Controls.Add(this.txtQtdDev);
            this.groupBox1.Controls.Add(this.hacLabel1);
            this.groupBox1.Controls.Add(this.txtQtdForn);
            this.groupBox1.Location = new System.Drawing.Point(14, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 100);
            this.groupBox1.TabIndex = 168;
            this.groupBox1.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.AlterarStatus = true;
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.Export_Excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(225, 70);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(22, 22);
            this.btnExcel.TabIndex = 169;
            this.toolTip1.SetToolTip(this.btnExcel, "GERAR PLANILHA DE DEVOLUÇÕES");
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(4, 75);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(157, 13);
            this.hacLabel3.TabIndex = 170;
            this.hacLabel3.Text = "Índice Geral Devolução %";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(62, 48);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(92, 13);
            this.hacLabel2.TabIndex = 52;
            this.hacLabel2.Text = "Qtd. Devolvida";
            // 
            // txtIndiceDev
            // 
            this.txtIndiceDev.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtIndiceDev.BackColor = System.Drawing.Color.Honeydew;
            this.txtIndiceDev.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtIndiceDev.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtIndiceDev.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIndiceDev.Limpar = true;
            this.txtIndiceDev.Location = new System.Drawing.Point(164, 70);
            this.txtIndiceDev.Name = "txtIndiceDev";
            this.txtIndiceDev.NaoAjustarEdicao = false;
            this.txtIndiceDev.Obrigatorio = false;
            this.txtIndiceDev.ObrigatorioMensagem = "";
            this.txtIndiceDev.PreValidacaoMensagem = "";
            this.txtIndiceDev.PreValidado = false;
            this.txtIndiceDev.ReadOnly = true;
            this.txtIndiceDev.SelectAllOnFocus = false;
            this.txtIndiceDev.Size = new System.Drawing.Size(53, 21);
            this.txtIndiceDev.TabIndex = 169;
            // 
            // txtQtdDev
            // 
            this.txtQtdDev.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdDev.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdDev.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdDev.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtQtdDev.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdDev.Limpar = true;
            this.txtQtdDev.Location = new System.Drawing.Point(164, 43);
            this.txtQtdDev.Name = "txtQtdDev";
            this.txtQtdDev.NaoAjustarEdicao = false;
            this.txtQtdDev.Obrigatorio = false;
            this.txtQtdDev.ObrigatorioMensagem = "";
            this.txtQtdDev.PreValidacaoMensagem = "";
            this.txtQtdDev.PreValidado = false;
            this.txtQtdDev.ReadOnly = true;
            this.txtQtdDev.SelectAllOnFocus = false;
            this.txtQtdDev.Size = new System.Drawing.Size(84, 21);
            this.txtQtdDev.TabIndex = 51;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(32, 21);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(122, 13);
            this.hacLabel1.TabIndex = 50;
            this.hacLabel1.Text = "Qtd. Total Fornecida";
            // 
            // txtQtdForn
            // 
            this.txtQtdForn.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdForn.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdForn.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdForn.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtQtdForn.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdForn.Limpar = true;
            this.txtQtdForn.Location = new System.Drawing.Point(164, 16);
            this.txtQtdForn.Name = "txtQtdForn";
            this.txtQtdForn.NaoAjustarEdicao = false;
            this.txtQtdForn.Obrigatorio = false;
            this.txtQtdForn.ObrigatorioMensagem = "";
            this.txtQtdForn.PreValidacaoMensagem = "";
            this.txtQtdForn.PreValidado = false;
            this.txtQtdForn.ReadOnly = true;
            this.txtQtdForn.SelectAllOnFocus = false;
            this.txtQtdForn.Size = new System.Drawing.Size(83, 21);
            this.txtQtdForn.TabIndex = 49;
            // 
            // btnCancelarPlanilha
            // 
            this.btnCancelarPlanilha.AlterarStatus = true;
            this.btnCancelarPlanilha.BackColor = System.Drawing.Color.White;
            this.btnCancelarPlanilha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarPlanilha.BackgroundImage")));
            this.btnCancelarPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarPlanilha.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelarPlanilha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarPlanilha.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelarPlanilha.Location = new System.Drawing.Point(216, 60);
            this.btnCancelarPlanilha.Name = "btnCancelarPlanilha";
            this.btnCancelarPlanilha.Size = new System.Drawing.Size(83, 22);
            this.btnCancelarPlanilha.TabIndex = 19;
            this.btnCancelarPlanilha.Text = "Cancelar";
            this.btnCancelarPlanilha.UseVisualStyleBackColor = true;
            this.btnCancelarPlanilha.Click += new System.EventHandler(this.btnCancelarPlanilha_Click);
            // 
            // btnGerarIndice
            // 
            this.btnGerarIndice.AlterarStatus = true;
            this.btnGerarIndice.BackColor = System.Drawing.Color.White;
            this.btnGerarIndice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGerarIndice.BackgroundImage")));
            this.btnGerarIndice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarIndice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnGerarIndice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarIndice.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnGerarIndice.Location = new System.Drawing.Point(124, 60);
            this.btnGerarIndice.Name = "btnGerarIndice";
            this.btnGerarIndice.Size = new System.Drawing.Size(83, 22);
            this.btnGerarIndice.TabIndex = 17;
            this.btnGerarIndice.Text = "Gerar";
            this.btnGerarIndice.UseVisualStyleBackColor = true;
            this.btnGerarIndice.Click += new System.EventHandler(this.btnGerarIndice_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 21);
            this.panel2.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(8, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Índice de Devolução";
            // 
            // txtDtFim
            // 
            this.txtDtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtFim.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtFim.Limpar = false;
            this.txtDtFim.Location = new System.Drawing.Point(219, 31);
            this.txtDtFim.MaxLength = 10;
            this.txtDtFim.Name = "txtDtFim";
            this.txtDtFim.NaoAjustarEdicao = false;
            this.txtDtFim.Obrigatorio = false;
            this.txtDtFim.ObrigatorioMensagem = "";
            this.txtDtFim.PreValidacaoMensagem = "";
            this.txtDtFim.PreValidado = false;
            this.txtDtFim.SelectAllOnFocus = false;
            this.txtDtFim.Size = new System.Drawing.Size(80, 21);
            this.txtDtFim.TabIndex = 15;
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(160, 34);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(58, 13);
            this.hacLabel11.TabIndex = 14;
            this.hacLabel11.Text = "Data Fim";
            // 
            // txtDtIni
            // 
            this.txtDtIni.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtIni.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtIni.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDtIni.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtIni.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtIni.Limpar = false;
            this.txtDtIni.Location = new System.Drawing.Point(75, 31);
            this.txtDtIni.MaxLength = 10;
            this.txtDtIni.Name = "txtDtIni";
            this.txtDtIni.NaoAjustarEdicao = false;
            this.txtDtIni.Obrigatorio = false;
            this.txtDtIni.ObrigatorioMensagem = "";
            this.txtDtIni.PreValidacaoMensagem = "";
            this.txtDtIni.PreValidado = false;
            this.txtDtIni.SelectAllOnFocus = false;
            this.txtDtIni.Size = new System.Drawing.Size(80, 21);
            this.txtDtIni.TabIndex = 13;
            // 
            // hacLabel12
            // 
            this.hacLabel12.AutoSize = true;
            this.hacLabel12.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel12.Location = new System.Drawing.Point(5, 34);
            this.hacLabel12.Name = "hacLabel12";
            this.hacLabel12.Size = new System.Drawing.Size(69, 13);
            this.hacLabel12.TabIndex = 12;
            this.hacLabel12.Text = "Data Início";
            // 
            // dtgBaixas
            // 
            this.dtgBaixas.AllowUserToAddRows = false;
            this.dtgBaixas.AllowUserToDeleteRows = false;
            this.dtgBaixas.AllowUserToResizeColumns = false;
            this.dtgBaixas.AllowUserToResizeRows = false;
            this.dtgBaixas.AlterarStatus = true;
            this.dtgBaixas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgBaixas.BackgroundColor = System.Drawing.Color.White;
            this.dtgBaixas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBaixas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtMov,
            this.colIdtMovRef,
            this.colIdFilialReq,
            this.colIdUnidadeCentroDisp,
            this.colIdLocalCentroDisp,
            this.colIdSetorCentroDisp,
            this.colIdUnidadeReq,
            this.colIdLocalReq,
            this.colIdSetorReq,
            this.colTipoPedido,
            this.colIdtProduto,
            this.colIdLote,
            this.colFracionado,
            this.colReutiliza,
            this.colExcluir,
            this.colPedido,
            this.colDataMov,
            this.colDsProduto,
            this.colLoteFab,
            this.colQtde,
            this.colAtendimento,
            this.colUnidadePed,
            this.colSetorPed,
            this.colCentroDisp,
            this.colEstoque});
            this.dtgBaixas.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgBaixas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgBaixas.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgBaixas.GridPesquisa = false;
            this.dtgBaixas.Limpar = true;
            this.dtgBaixas.Location = new System.Drawing.Point(6, 9);
            this.dtgBaixas.Name = "dtgBaixas";
            this.dtgBaixas.NaoAjustarEdicao = false;
            this.dtgBaixas.Obrigatorio = false;
            this.dtgBaixas.ObrigatorioMensagem = null;
            this.dtgBaixas.PreValidacaoMensagem = null;
            this.dtgBaixas.PreValidado = false;
            this.dtgBaixas.RowHeadersVisible = false;
            this.dtgBaixas.RowHeadersWidth = 21;
            this.dtgBaixas.RowTemplate.Height = 18;
            this.dtgBaixas.Size = new System.Drawing.Size(755, 350);
            this.dtgBaixas.TabIndex = 81;
            this.dtgBaixas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBaixas_CellClick);
            this.dtgBaixas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBaixas_CellDoubleClick);
            this.dtgBaixas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgBaixas_CellFormatting);
            this.dtgBaixas.DoubleClick += new System.EventHandler(this.dtgBaixas_DoubleClick);
            // 
            // colIdtMov
            // 
            this.colIdtMov.HeaderText = "colIdtMov";
            this.colIdtMov.Name = "colIdtMov";
            this.colIdtMov.ReadOnly = true;
            this.colIdtMov.Visible = false;
            // 
            // colIdtMovRef
            // 
            this.colIdtMovRef.HeaderText = "colIdtMovRef";
            this.colIdtMovRef.Name = "colIdtMovRef";
            this.colIdtMovRef.Visible = false;
            // 
            // colIdFilialReq
            // 
            this.colIdFilialReq.HeaderText = "colIdFilialReq";
            this.colIdFilialReq.Name = "colIdFilialReq";
            this.colIdFilialReq.Visible = false;
            // 
            // colIdUnidadeCentroDisp
            // 
            this.colIdUnidadeCentroDisp.HeaderText = "colIdUnidadeCentroDisp";
            this.colIdUnidadeCentroDisp.Name = "colIdUnidadeCentroDisp";
            this.colIdUnidadeCentroDisp.Visible = false;
            // 
            // colIdLocalCentroDisp
            // 
            this.colIdLocalCentroDisp.HeaderText = "colIdLocalCentroDisp";
            this.colIdLocalCentroDisp.Name = "colIdLocalCentroDisp";
            this.colIdLocalCentroDisp.Visible = false;
            // 
            // colIdSetorCentroDisp
            // 
            this.colIdSetorCentroDisp.HeaderText = "colIdSetorCentroDisp";
            this.colIdSetorCentroDisp.Name = "colIdSetorCentroDisp";
            this.colIdSetorCentroDisp.Visible = false;
            // 
            // colIdUnidadeReq
            // 
            this.colIdUnidadeReq.HeaderText = "colIdUnidadeReq";
            this.colIdUnidadeReq.Name = "colIdUnidadeReq";
            this.colIdUnidadeReq.Visible = false;
            // 
            // colIdLocalReq
            // 
            this.colIdLocalReq.HeaderText = "colIdLocalReq";
            this.colIdLocalReq.Name = "colIdLocalReq";
            this.colIdLocalReq.Visible = false;
            // 
            // colIdSetorReq
            // 
            this.colIdSetorReq.HeaderText = "colIdSetorReq";
            this.colIdSetorReq.Name = "colIdSetorReq";
            this.colIdSetorReq.Visible = false;
            // 
            // colTipoPedido
            // 
            this.colTipoPedido.HeaderText = "colTipoPedido";
            this.colTipoPedido.Name = "colTipoPedido";
            this.colTipoPedido.Visible = false;
            // 
            // colIdtProduto
            // 
            this.colIdtProduto.HeaderText = "colIdtProduto";
            this.colIdtProduto.Name = "colIdtProduto";
            this.colIdtProduto.Visible = false;
            // 
            // colIdLote
            // 
            this.colIdLote.HeaderText = "colIdLote";
            this.colIdLote.Name = "colIdLote";
            this.colIdLote.ReadOnly = true;
            this.colIdLote.Visible = false;
            // 
            // colFracionado
            // 
            this.colFracionado.HeaderText = "colFracionado";
            this.colFracionado.Name = "colFracionado";
            this.colFracionado.ReadOnly = true;
            this.colFracionado.Visible = false;
            // 
            // colReutiliza
            // 
            this.colReutiliza.HeaderText = "colReutiliza";
            this.colReutiliza.Name = "colReutiliza";
            this.colReutiliza.ReadOnly = true;
            this.colReutiliza.Visible = false;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colExcluir.Width = 50;
            // 
            // colPedido
            // 
            this.colPedido.HeaderText = "Pedido";
            this.colPedido.Name = "colPedido";
            this.colPedido.ReadOnly = true;
            this.colPedido.Width = 65;
            // 
            // colDataMov
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataMov.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDataMov.HeaderText = "Data Mov.";
            this.colDataMov.Name = "colDataMov";
            this.colDataMov.ReadOnly = true;
            this.colDataMov.Width = 118;
            // 
            // colDsProduto
            // 
            this.colDsProduto.HeaderText = "Produto";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 310;
            // 
            // colLoteFab
            // 
            this.colLoteFab.HeaderText = "Lote";
            this.colLoteFab.Name = "colLoteFab";
            this.colLoteFab.ReadOnly = true;
            this.colLoteFab.Width = 75;
            // 
            // colQtde
            // 
            dataGridViewCellStyle2.Format = "N0";
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtde.HeaderText = "Qtde.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 55;
            // 
            // colAtendimento
            // 
            this.colAtendimento.HeaderText = "Atendimento";
            this.colAtendimento.Name = "colAtendimento";
            this.colAtendimento.ReadOnly = true;
            this.colAtendimento.Width = 90;
            // 
            // colUnidadePed
            // 
            this.colUnidadePed.HeaderText = "Unidade Pedido";
            this.colUnidadePed.Name = "colUnidadePed";
            this.colUnidadePed.ReadOnly = true;
            this.colUnidadePed.Width = 120;
            // 
            // colSetorPed
            // 
            this.colSetorPed.HeaderText = "Setor Pedido";
            this.colSetorPed.Name = "colSetorPed";
            this.colSetorPed.ReadOnly = true;
            this.colSetorPed.Width = 160;
            // 
            // colCentroDisp
            // 
            this.colCentroDisp.HeaderText = "Centro Disp.";
            this.colCentroDisp.Name = "colCentroDisp";
            this.colCentroDisp.ReadOnly = true;
            this.colCentroDisp.Width = 150;
            // 
            // colEstoque
            // 
            this.colEstoque.HeaderText = "Estoque";
            this.colEstoque.Name = "colEstoque";
            this.colEstoque.ReadOnly = true;
            this.colEstoque.Width = 65;
            // 
            // lblLegendaFrac
            // 
            this.lblLegendaFrac.AutoSize = true;
            this.lblLegendaFrac.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblLegendaFrac.ForeColor = System.Drawing.Color.Gray;
            this.lblLegendaFrac.Location = new System.Drawing.Point(12, 525);
            this.lblLegendaFrac.Name = "lblLegendaFrac";
            this.lblLegendaFrac.Size = new System.Drawing.Size(139, 13);
            this.lblLegendaFrac.TabIndex = 146;
            this.lblLegendaFrac.Text = "* ITEM FRACIONADO";
            this.lblLegendaFrac.Visible = false;
            // 
            // grbDevolver
            // 
            this.grbDevolver.Controls.Add(this.rbDevFarm);
            this.grbDevolver.Controls.Add(this.rbDevAlmoxUTI);
            this.grbDevolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDevolver.Location = new System.Drawing.Point(583, 120);
            this.grbDevolver.Name = "grbDevolver";
            this.grbDevolver.Size = new System.Drawing.Size(190, 35);
            this.grbDevolver.TabIndex = 137;
            this.grbDevolver.TabStop = false;
            this.grbDevolver.Text = "DEVOLVER PARA";
            this.grbDevolver.Visible = false;
            // 
            // rbDevFarm
            // 
            this.rbDevFarm.AutoSize = true;
            this.rbDevFarm.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbDevFarm.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDevFarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDevFarm.Limpar = false;
            this.rbDevFarm.Location = new System.Drawing.Point(97, 15);
            this.rbDevFarm.Name = "rbDevFarm";
            this.rbDevFarm.Obrigatorio = false;
            this.rbDevFarm.ObrigatorioMensagem = null;
            this.rbDevFarm.PreValidacaoMensagem = null;
            this.rbDevFarm.PreValidado = false;
            this.rbDevFarm.Size = new System.Drawing.Size(87, 17);
            this.rbDevFarm.TabIndex = 1;
            this.rbDevFarm.Text = "Farm. Central";
            this.rbDevFarm.UseVisualStyleBackColor = true;
            // 
            // rbDevAlmoxUTI
            // 
            this.rbDevAlmoxUTI.AutoSize = true;
            this.rbDevAlmoxUTI.Checked = true;
            this.rbDevAlmoxUTI.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbDevAlmoxUTI.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDevAlmoxUTI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDevAlmoxUTI.Limpar = false;
            this.rbDevAlmoxUTI.Location = new System.Drawing.Point(11, 15);
            this.rbDevAlmoxUTI.Name = "rbDevAlmoxUTI";
            this.rbDevAlmoxUTI.Obrigatorio = false;
            this.rbDevAlmoxUTI.ObrigatorioMensagem = null;
            this.rbDevAlmoxUTI.PreValidacaoMensagem = null;
            this.rbDevAlmoxUTI.PreValidado = false;
            this.rbDevAlmoxUTI.Size = new System.Drawing.Size(77, 17);
            this.rbDevAlmoxUTI.TabIndex = 0;
            this.rbDevAlmoxUTI.TabStop = true;
            this.rbDevAlmoxUTI.Text = "Almox. UTI";
            this.rbDevAlmoxUTI.UseVisualStyleBackColor = true;
            // 
            // FrmEstornoItemPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 542);
            this.Controls.Add(this.grbDevolver);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.lblLegendaFrac);
            this.Controls.Add(this.lblCodBarra);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.grbAtendimento);
            this.Controls.Add(this.tabConsumo);
            this.Name = "FrmEstornoItemPedido";
            this.Text = "FrmEstornoItemPedido";
            this.Load += new System.EventHandler(this.FrmEstornoItemPedido_Load);
            this.tsHac.ResumeLayout(false);
            this.tsHac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaPac)).EndInit();
            this.grbAtendimento.ResumeLayout(false);
            this.grbAtendimento.PerformLayout();
            this.grpTipoAtendimento.ResumeLayout(false);
            this.grpTipoAtendimento.PerformLayout();
            this.tabConsumo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlIndiceDev.ResumeLayout(false);
            this.pnlIndiceDev.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaixas)).EndInit();
            this.grbDevolver.ResumeLayout(false);
            this.grbDevolver.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacLabel hacLabel9;
        private System.Windows.Forms.PictureBox btnPesquisaPac;
        private SGS.Componentes.HacTextBox txtNomePac;
        private SGS.Componentes.HacTextBox txtNroInternacao;
        private SGS.Componentes.HacTextBox txtCodProduto;
        private System.Windows.Forms.Label lblCodBarra;
        private System.Windows.Forms.GroupBox grbAtendimento;
        private System.Windows.Forms.TabControl tabConsumo;
        private System.Windows.Forms.TabPage tabPage1;
        private SGS.Componentes.HacDataGridView dtgBaixas;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private System.Windows.Forms.ToolStripButton tsEstornar;
        private System.Windows.Forms.GroupBox grpTipoAtendimento;
        private SGS.Componentes.HacRadioButton rbAmbulatorio;
        private SGS.Componentes.HacRadioButton rbInternado;
        private SGS.Componentes.HacButton btnHistorico;
        private SGS.Componentes.HacLabel lblLegendaFrac;
        private System.Windows.Forms.Panel pnlIndiceDev;
        private SGS.Componentes.HacButton btnCancelarPlanilha;
        private SGS.Componentes.HacButton btnGerarIndice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private SGS.Componentes.HacTextBox txtDtFim;
        private SGS.Componentes.HacLabel hacLabel11;
        private SGS.Componentes.HacTextBox txtDtIni;
        private SGS.Componentes.HacLabel hacLabel12;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacTextBox txtIndiceDev;
        private SGS.Componentes.HacTextBox txtQtdDev;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacTextBox txtQtdForn;
        private SGS.Componentes.HacButton btnExcel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton tsIndiceDev;
        private SGS.Componentes.HacCheckBox chkSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtMovRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdFilialReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdUnidadeCentroDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLocalCentroDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSetorCentroDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdUnidadeReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLocalReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSetorReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFracionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReutiliza;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoteFab;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadePed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetorPed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCentroDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoque;
        private System.Windows.Forms.GroupBox grbDevolver;
        private SGS.Componentes.HacRadioButton rbDevFarm;
        private SGS.Componentes.HacRadioButton rbDevAlmoxUTI;
    }
}