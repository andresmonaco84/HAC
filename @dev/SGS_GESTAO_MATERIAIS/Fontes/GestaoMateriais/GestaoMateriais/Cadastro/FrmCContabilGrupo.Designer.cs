namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmCContabilGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCContabilGrupo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.dtgGrupo = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbQuebra = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbBaixa = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.txtDataInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDataFinal = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtContaCredito = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtContaDebito = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnNovo = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblGrupo = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblContaCredito = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblContaDebito = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.colGrupoIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsContaCred = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsContaDeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataIni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContaCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContaDebito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).BeginInit();
            this.grbFilial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 0;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Conta Contábil / Grupo";
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // dtgGrupo
            // 
            this.dtgGrupo.AllowUserToAddRows = false;
            this.dtgGrupo.AllowUserToDeleteRows = false;
            this.dtgGrupo.AllowUserToResizeColumns = false;
            this.dtgGrupo.AllowUserToResizeRows = false;
            this.dtgGrupo.AlterarStatus = false;
            this.dtgGrupo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgGrupo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgGrupo.ColumnHeadersHeight = 20;
            this.dtgGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGrupoIdt,
            this.colDsGrupo,
            this.colDsContaCred,
            this.colDsContaDeb,
            this.colSetor,
            this.colDataIni,
            this.colDataFim,
            this.colContaCredito,
            this.colContaDebito,
            this.colIdSetor});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgGrupo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgGrupo.GridPesquisa = false;
            this.dtgGrupo.Limpar = true;
            this.dtgGrupo.Location = new System.Drawing.Point(5, 66);
            this.dtgGrupo.MultiSelect = false;
            this.dtgGrupo.Name = "dtgGrupo";
            this.dtgGrupo.NaoAjustarEdicao = false;
            this.dtgGrupo.Obrigatorio = false;
            this.dtgGrupo.ObrigatorioMensagem = null;
            this.dtgGrupo.PreValidacaoMensagem = null;
            this.dtgGrupo.PreValidado = false;
            this.dtgGrupo.RowHeadersVisible = false;
            this.dtgGrupo.RowHeadersWidth = 25;
            this.dtgGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupo.Size = new System.Drawing.Size(770, 339);
            this.dtgGrupo.TabIndex = 2;
            this.dtgGrupo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupo_RowEnter);
            this.dtgGrupo.SelectionChanged += new System.EventHandler(this.dtgGrupo_SelectionChanged);
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbAcs);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(653, 26);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(117, 36);
            this.grbFilial.TabIndex = 1;
            this.grbFilial.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(58, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(49, 17);
            this.rbAcs.TabIndex = 3;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Click += new System.EventHandler(this.rbAcs_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
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
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbQuebra);
            this.groupBox1.Controls.Add(this.rbBaixa);
            this.groupBox1.Location = new System.Drawing.Point(344, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 36);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbQuebra
            // 
            this.rbQuebra.AutoSize = true;
            this.rbQuebra.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbQuebra.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbQuebra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbQuebra.Limpar = true;
            this.rbQuebra.Location = new System.Drawing.Point(149, 13);
            this.rbQuebra.Name = "rbQuebra";
            this.rbQuebra.Obrigatorio = false;
            this.rbQuebra.ObrigatorioMensagem = null;
            this.rbQuebra.PreValidacaoMensagem = null;
            this.rbQuebra.PreValidado = false;
            this.rbQuebra.Size = new System.Drawing.Size(132, 17);
            this.rbQuebra.TabIndex = 3;
            this.rbQuebra.Text = "QUEBRA / PERDA";
            this.rbQuebra.UseVisualStyleBackColor = true;
            this.rbQuebra.Click += new System.EventHandler(this.rbQuebra_Click);
            // 
            // rbBaixa
            // 
            this.rbBaixa.AutoSize = true;
            this.rbBaixa.Checked = true;
            this.rbBaixa.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbBaixa.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbBaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBaixa.Limpar = true;
            this.rbBaixa.Location = new System.Drawing.Point(7, 13);
            this.rbBaixa.Name = "rbBaixa";
            this.rbBaixa.Obrigatorio = false;
            this.rbBaixa.ObrigatorioMensagem = null;
            this.rbBaixa.PreValidacaoMensagem = null;
            this.rbBaixa.PreValidado = false;
            this.rbBaixa.Size = new System.Drawing.Size(127, 17);
            this.rbBaixa.TabIndex = 2;
            this.rbBaixa.TabStop = true;
            this.rbBaixa.Text = "BAIXA CONSUMO";
            this.rbBaixa.UseVisualStyleBackColor = true;
            this.rbBaixa.Click += new System.EventHandler(this.rbBaixa_Click);
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
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
            this.cmbSetor.Location = new System.Drawing.Point(553, 440);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = false;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(200, 21);
            this.cmbSetor.TabIndex = 5;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(513, 443);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 133;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(331, 440);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = false;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(168, 21);
            this.cmbLocal.TabIndex = 4;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(40, 443);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 129;
            this.hacLabel1.Text = "Unidade";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(284, 443);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 131;
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
            this.cmbUnidade.Location = new System.Drawing.Point(102, 440);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = false;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(168, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 3;
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDataInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataInicio.Limpar = true;
            this.txtDataInicio.Location = new System.Drawing.Point(102, 476);
            this.txtDataInicio.MaxLength = 10;
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.NaoAjustarEdicao = true;
            this.txtDataInicio.Obrigatorio = true;
            this.txtDataInicio.ObrigatorioMensagem = "Digite a data início da vigência";
            this.txtDataInicio.PreValidacaoMensagem = null;
            this.txtDataInicio.PreValidado = false;
            this.txtDataInicio.SelectAllOnFocus = false;
            this.txtDataInicio.Size = new System.Drawing.Size(80, 20);
            this.txtDataInicio.TabIndex = 6;
            this.txtDataInicio.TabStop = false;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(24, 479);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(69, 13);
            this.hacLabel6.TabIndex = 151;
            this.hacLabel6.Text = "Data Início";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataFinal.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataFinal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDataFinal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFinal.Limpar = true;
            this.txtDataFinal.Location = new System.Drawing.Point(285, 476);
            this.txtDataFinal.MaxLength = 10;
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.NaoAjustarEdicao = true;
            this.txtDataFinal.Obrigatorio = false;
            this.txtDataFinal.ObrigatorioMensagem = null;
            this.txtDataFinal.PreValidacaoMensagem = null;
            this.txtDataFinal.PreValidado = false;
            this.txtDataFinal.SelectAllOnFocus = false;
            this.txtDataFinal.Size = new System.Drawing.Size(80, 20);
            this.txtDataFinal.TabIndex = 7;
            this.txtDataFinal.TabStop = false;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(207, 479);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(64, 13);
            this.hacLabel4.TabIndex = 153;
            this.hacLabel4.Text = "Data Final";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(4, 16);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(87, 13);
            this.hacLabel5.TabIndex = 154;
            this.hacLabel5.Text = "Conta Crédito";
            // 
            // txtContaCredito
            // 
            this.txtContaCredito.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtContaCredito.BackColor = System.Drawing.Color.Honeydew;
            this.txtContaCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContaCredito.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtContaCredito.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtContaCredito.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtContaCredito.Limpar = true;
            this.txtContaCredito.Location = new System.Drawing.Point(99, 12);
            this.txtContaCredito.Name = "txtContaCredito";
            this.txtContaCredito.NaoAjustarEdicao = false;
            this.txtContaCredito.Obrigatorio = true;
            this.txtContaCredito.ObrigatorioMensagem = "Conta Crédito deve estar Preenchido";
            this.txtContaCredito.PreValidacaoMensagem = null;
            this.txtContaCredito.PreValidado = false;
            this.txtContaCredito.SelectAllOnFocus = false;
            this.txtContaCredito.Size = new System.Drawing.Size(168, 21);
            this.txtContaCredito.TabIndex = 8;
            this.txtContaCredito.Validating += new System.ComponentModel.CancelEventHandler(this.txtConta_Validating);
            // 
            // txtContaDebito
            // 
            this.txtContaDebito.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtContaDebito.BackColor = System.Drawing.Color.Honeydew;
            this.txtContaDebito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContaDebito.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtContaDebito.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtContaDebito.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtContaDebito.Limpar = true;
            this.txtContaDebito.Location = new System.Drawing.Point(99, 10);
            this.txtContaDebito.Name = "txtContaDebito";
            this.txtContaDebito.NaoAjustarEdicao = false;
            this.txtContaDebito.Obrigatorio = true;
            this.txtContaDebito.ObrigatorioMensagem = "Conta Débito deve estar Preenchido";
            this.txtContaDebito.PreValidacaoMensagem = null;
            this.txtContaDebito.PreValidado = false;
            this.txtContaDebito.SelectAllOnFocus = false;
            this.txtContaDebito.Size = new System.Drawing.Size(168, 21);
            this.txtContaDebito.TabIndex = 9;
            this.txtContaDebito.Validating += new System.ComponentModel.CancelEventHandler(this.txtConta_Validating);
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(8, 14);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(82, 13);
            this.hacLabel7.TabIndex = 156;
            this.hacLabel7.Text = "Conta Débito";
            // 
            // btnNovo
            // 
            this.btnNovo.AlterarStatus = true;
            this.btnNovo.BackColor = System.Drawing.Color.White;
            this.btnNovo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNovo.BackgroundImage")));
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Enabled = false;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(376, 475);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(306, 22);
            this.btnNovo.TabIndex = 10;
            this.btnNovo.Text = "INSERIR NOVA CONTA REFERENTE A ESTE GRUPO";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblGrupo.Location = new System.Drawing.Point(40, 415);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(0, 14);
            this.lblGrupo.TabIndex = 159;
            // 
            // lblContaCredito
            // 
            this.lblContaCredito.AutoSize = true;
            this.lblContaCredito.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblContaCredito.Location = new System.Drawing.Point(10, 39);
            this.lblContaCredito.Name = "lblContaCredito";
            this.lblContaCredito.Size = new System.Drawing.Size(0, 14);
            this.lblContaCredito.TabIndex = 160;
            // 
            // lblContaDebito
            // 
            this.lblContaDebito.AutoSize = true;
            this.lblContaDebito.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblContaDebito.Location = new System.Drawing.Point(15, 36);
            this.lblContaDebito.Name = "lblContaDebito";
            this.lblContaDebito.Size = new System.Drawing.Size(0, 14);
            this.lblContaDebito.TabIndex = 161;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtContaCredito);
            this.groupBox2.Controls.Add(this.hacLabel5);
            this.groupBox2.Controls.Add(this.lblContaCredito);
            this.groupBox2.Location = new System.Drawing.Point(3, 499);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 60);
            this.groupBox2.TabIndex = 162;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtContaDebito);
            this.groupBox3.Controls.Add(this.hacLabel7);
            this.groupBox3.Controls.Add(this.lblContaDebito);
            this.groupBox3.Location = new System.Drawing.Point(376, 499);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 60);
            this.groupBox3.TabIndex = 163;
            this.groupBox3.TabStop = false;
            // 
            // colGrupoIdt
            // 
            this.colGrupoIdt.HeaderText = "COD";
            this.colGrupoIdt.Name = "colGrupoIdt";
            this.colGrupoIdt.ReadOnly = true;
            this.colGrupoIdt.Width = 50;
            // 
            // colDsGrupo
            // 
            this.colDsGrupo.HeaderText = "Grupo";
            this.colDsGrupo.Name = "colDsGrupo";
            this.colDsGrupo.ReadOnly = true;
            this.colDsGrupo.Width = 200;
            // 
            // colDsContaCred
            // 
            this.colDsContaCred.HeaderText = "Descrição Conta Credito";
            this.colDsContaCred.Name = "colDsContaCred";
            this.colDsContaCred.ReadOnly = true;
            this.colDsContaCred.Width = 200;
            // 
            // colDsContaDeb
            // 
            this.colDsContaDeb.HeaderText = "Descrição Conta Débito";
            this.colDsContaDeb.Name = "colDsContaDeb";
            this.colDsContaDeb.ReadOnly = true;
            this.colDsContaDeb.Width = 200;
            // 
            // colSetor
            // 
            this.colSetor.HeaderText = "Setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.ReadOnly = true;
            this.colSetor.Width = 180;
            // 
            // colDataIni
            // 
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.colDataIni.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataIni.HeaderText = "Data Início";
            this.colDataIni.Name = "colDataIni";
            this.colDataIni.ReadOnly = true;
            // 
            // colDataFim
            // 
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.colDataFim.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDataFim.HeaderText = "Data Final";
            this.colDataFim.Name = "colDataFim";
            this.colDataFim.ReadOnly = true;
            // 
            // colContaCredito
            // 
            this.colContaCredito.HeaderText = "colContaCredito";
            this.colContaCredito.Name = "colContaCredito";
            this.colContaCredito.Visible = false;
            // 
            // colContaDebito
            // 
            this.colContaDebito.HeaderText = "colContaDebito";
            this.colContaDebito.Name = "colContaDebito";
            this.colContaDebito.Visible = false;
            // 
            // colIdSetor
            // 
            this.colIdSetor.HeaderText = "colIdSetor";
            this.colIdSetor.Name = "colIdSetor";
            this.colIdSetor.Visible = false;
            // 
            // FrmCContabilGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 564);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.dtgGrupo);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmCContabilGrupo";
            this.Text = "FrmCContabilGrupo";
            this.Load += new System.EventHandler(this.FrmCContabilGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).EndInit();
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacToolStrip tsHac;
        private HospitalAnaCosta.SGS.Componentes.HacDataGridView dtgGrupo;
        private System.Windows.Forms.GroupBox grbFilial;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbAcs;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbHac;
        private System.Windows.Forms.GroupBox groupBox1;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbQuebra;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbBaixa;
        private HospitalAnaCosta.SGS.Componentes.HacCmbSetor cmbSetor;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel3;
        private HospitalAnaCosta.SGS.Componentes.HacCmbLocal cmbLocal;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel1;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel2;
        private HospitalAnaCosta.SGS.Componentes.HacCmbUnidade cmbUnidade;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtDataInicio;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel6;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtDataFinal;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel4;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel5;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtContaCredito;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtContaDebito;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel7;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnNovo;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblGrupo;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblContaCredito;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblContaDebito;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupoIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsContaCred;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsContaDeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContaCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContaDebito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSetor;
    }
}