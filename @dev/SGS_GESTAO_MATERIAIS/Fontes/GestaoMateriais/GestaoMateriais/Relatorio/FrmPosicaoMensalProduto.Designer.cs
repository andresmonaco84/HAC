namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmPosicaoMensalProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosicaoMensalProduto));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.nmMes = new System.Windows.Forms.NumericUpDown();
            this.txtAno = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtMes = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.chbGrupo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblUnidade = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.lblGrupo = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.grbPosMensal = new System.Windows.Forms.GroupBox();
            this.chbInventario = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.grbSaidas = new System.Windows.Forms.GroupBox();
            this.chbQuebra = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbNovoFormato = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblTotal = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnGerarArquivo = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.chbDevolucao = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlanQtdsConsCCusto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.rbCentroCustoSint = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbCentroCustoAnal = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbUHSint = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbCentroCustoData = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbUHAnal = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.sfDir = new System.Windows.Forms.SaveFileDialog();
            this.tsRel = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.btnExcel = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chbContabil = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbGerarPrevia = new System.Windows.Forms.GroupBox();
            this.btnGerarPrevia = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblDataAtualizacaoPrevia = new System.Windows.Forms.Label();
            this.chbPadraoNao = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbPadrao = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMes)).BeginInit();
            this.grbPosMensal.SuspendLayout();
            this.grbSaidas.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbGerarPrevia.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbAcs);
            this.groupBox4.Controls.Add(this.rbHac);
            this.groupBox4.Location = new System.Drawing.Point(337, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 36);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = false;
            this.rbAcs.Location = new System.Drawing.Point(53, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 6;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(6, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 5;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(11, 50);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(56, 13);
            this.hacLabel1.TabIndex = 0;
            this.hacLabel1.Text = "Mês/Ano";
            // 
            // nmMes
            // 
            this.nmMes.Location = new System.Drawing.Point(430, 31);
            this.nmMes.Name = "nmMes";
            this.nmMes.Size = new System.Drawing.Size(35, 20);
            this.nmMes.TabIndex = 133;
            this.nmMes.Visible = false;
            // 
            // txtAno
            // 
            this.txtAno.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAno.BackColor = System.Drawing.Color.Honeydew;
            this.txtAno.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAno.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAno.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAno.Limpar = false;
            this.txtAno.Location = new System.Drawing.Point(114, 46);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.NaoAjustarEdicao = true;
            this.txtAno.Obrigatorio = false;
            this.txtAno.ObrigatorioMensagem = "";
            this.txtAno.PreValidacaoMensagem = "";
            this.txtAno.PreValidado = false;
            this.txtAno.SelectAllOnFocus = false;
            this.txtAno.Size = new System.Drawing.Size(40, 21);
            this.txtAno.TabIndex = 2;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMes
            // 
            this.txtMes.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMes.BackColor = System.Drawing.Color.Honeydew;
            this.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtMes.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMes.Limpar = false;
            this.txtMes.Location = new System.Drawing.Point(70, 46);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.NaoAjustarEdicao = true;
            this.txtMes.Obrigatorio = false;
            this.txtMes.ObrigatorioMensagem = null;
            this.txtMes.PreValidacaoMensagem = null;
            this.txtMes.PreValidado = false;
            this.txtMes.SelectAllOnFocus = false;
            this.txtMes.Size = new System.Drawing.Size(30, 21);
            this.txtMes.TabIndex = 1;
            // 
            // chbGrupo
            // 
            this.chbGrupo.AutoSize = true;
            this.chbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbGrupo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
            this.chbGrupo.Limpar = false;
            this.chbGrupo.Location = new System.Drawing.Point(165, 48);
            this.chbGrupo.Name = "chbGrupo";
            this.chbGrupo.Obrigatorio = false;
            this.chbGrupo.ObrigatorioMensagem = null;
            this.chbGrupo.PreValidacaoMensagem = null;
            this.chbGrupo.PreValidado = false;
            this.chbGrupo.Size = new System.Drawing.Size(85, 18);
            this.chbGrupo.TabIndex = 3;
            this.chbGrupo.Text = "Por Grupo";
            this.chbGrupo.UseVisualStyleBackColor = true;
            this.chbGrupo.Click += new System.EventHandler(this.chbGrupo_Click);
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUnidade.Location = new System.Drawing.Point(3, 21);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(53, 13);
            this.lblUnidade.TabIndex = 135;
            this.lblUnidade.Text = "Unidade";
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
            this.cmbUnidade.Limpar = true;
            this.cmbUnidade.Location = new System.Drawing.Point(73, 18);
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
            this.cmbUnidade.TabIndex = 6;
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblGrupo.Location = new System.Drawing.Point(3, 78);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(42, 13);
            this.lblGrupo.TabIndex = 137;
            this.lblGrupo.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbGrupo.DisplayMember = "CAD_MTMD_GRUPO_DESCRICAO";
            this.cmbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Limpar = true;
            this.cmbGrupo.Location = new System.Drawing.Point(73, 74);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Obrigatorio = false;
            this.cmbGrupo.ObrigatorioMensagem = null;
            this.cmbGrupo.PreValidacaoMensagem = null;
            this.cmbGrupo.PreValidado = false;
            this.cmbGrupo.Size = new System.Drawing.Size(341, 21);
            this.cmbGrupo.TabIndex = 7;
            this.cmbGrupo.Text = "<Selecione>";
            this.cmbGrupo.ValueMember = "CAD_MTMD_GRUPO_ID";
            this.cmbGrupo.SelectionChangeCommitted += new System.EventHandler(this.cmbGrupo_SelectionChangeCommitted);
            // 
            // grbPosMensal
            // 
            this.grbPosMensal.Controls.Add(this.chbPadraoNao);
            this.grbPosMensal.Controls.Add(this.chbPadrao);
            this.grbPosMensal.Controls.Add(this.chbInventario);
            this.grbPosMensal.Controls.Add(this.lblSubGrupo);
            this.grbPosMensal.Controls.Add(this.cmbSubGrupo);
            this.grbPosMensal.Controls.Add(this.cmbUnidade);
            this.grbPosMensal.Controls.Add(this.lblGrupo);
            this.grbPosMensal.Controls.Add(this.lblUnidade);
            this.grbPosMensal.Controls.Add(this.cmbGrupo);
            this.grbPosMensal.Location = new System.Drawing.Point(11, 75);
            this.grbPosMensal.Name = "grbPosMensal";
            this.grbPosMensal.Size = new System.Drawing.Size(453, 138);
            this.grbPosMensal.TabIndex = 5;
            this.grbPosMensal.TabStop = false;
            // 
            // chbInventario
            // 
            this.chbInventario.AutoSize = true;
            this.chbInventario.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbInventario.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbInventario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
            this.chbInventario.Limpar = false;
            this.chbInventario.Location = new System.Drawing.Point(267, 20);
            this.chbInventario.Name = "chbInventario";
            this.chbInventario.Obrigatorio = false;
            this.chbInventario.ObrigatorioMensagem = null;
            this.chbInventario.PreValidacaoMensagem = null;
            this.chbInventario.PreValidado = false;
            this.chbInventario.Size = new System.Drawing.Size(133, 18);
            this.chbInventario.TabIndex = 140;
            this.chbInventario.Text = "Coluna Inventário";
            this.chbInventario.UseVisualStyleBackColor = true;
            this.chbInventario.Click += new System.EventHandler(this.chbInventario_Click);
            // 
            // lblSubGrupo
            // 
            this.lblSubGrupo.AutoSize = true;
            this.lblSubGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSubGrupo.Location = new System.Drawing.Point(3, 108);
            this.lblSubGrupo.Name = "lblSubGrupo";
            this.lblSubGrupo.Size = new System.Drawing.Size(69, 13);
            this.lblSubGrupo.TabIndex = 139;
            this.lblSubGrupo.Text = "Sub-Grupo";
            // 
            // cmbSubGrupo
            // 
            this.cmbSubGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSubGrupo.DisplayMember = "CAD_MTMD_SUBGRUPO_DESCRICAO";
            this.cmbSubGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbSubGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSubGrupo.FormattingEnabled = true;
            this.cmbSubGrupo.Limpar = false;
            this.cmbSubGrupo.Location = new System.Drawing.Point(73, 104);
            this.cmbSubGrupo.Name = "cmbSubGrupo";
            this.cmbSubGrupo.Obrigatorio = false;
            this.cmbSubGrupo.ObrigatorioMensagem = null;
            this.cmbSubGrupo.PreValidacaoMensagem = null;
            this.cmbSubGrupo.PreValidado = false;
            this.cmbSubGrupo.Size = new System.Drawing.Size(341, 21);
            this.cmbSubGrupo.TabIndex = 8;
            this.cmbSubGrupo.Text = "<Selecione>";
            this.cmbSubGrupo.ValueMember = "CAD_MTMD_SUBGRUPO_ID";
            // 
            // grbSaidas
            // 
            this.grbSaidas.Controls.Add(this.chbQuebra);
            this.grbSaidas.Controls.Add(this.groupBox2);
            this.grbSaidas.Controls.Add(this.chbDevolucao);
            this.grbSaidas.Controls.Add(this.groupBox1);
            this.grbSaidas.Location = new System.Drawing.Point(10, 73);
            this.grbSaidas.Name = "grbSaidas";
            this.grbSaidas.Size = new System.Drawing.Size(448, 295);
            this.grbSaidas.TabIndex = 5;
            this.grbSaidas.TabStop = false;
            this.grbSaidas.Visible = false;
            // 
            // chbQuebra
            // 
            this.chbQuebra.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbQuebra.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbQuebra.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chbQuebra.Limpar = false;
            this.chbQuebra.Location = new System.Drawing.Point(206, 7);
            this.chbQuebra.Name = "chbQuebra";
            this.chbQuebra.Obrigatorio = false;
            this.chbQuebra.ObrigatorioMensagem = null;
            this.chbQuebra.PreValidacaoMensagem = null;
            this.chbQuebra.PreValidado = false;
            this.chbQuebra.Size = new System.Drawing.Size(207, 35);
            this.chbQuebra.TabIndex = 7;
            this.chbQuebra.Text = "Pesquisar Quebras/Perdas";
            this.chbQuebra.UseVisualStyleBackColor = true;
            this.chbQuebra.Click += new System.EventHandler(this.chbQuebra_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbNovoFormato);
            this.groupBox2.Controls.Add(this.hacLabel6);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.hacLabel4);
            this.groupBox2.Controls.Add(this.btnGerarArquivo);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 105);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GERAÇÃO DO ARQUIVO PARA A CONTABILIDADE";
            // 
            // chbNovoFormato
            // 
            this.chbNovoFormato.AutoSize = true;
            this.chbNovoFormato.Checked = true;
            this.chbNovoFormato.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbNovoFormato.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbNovoFormato.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbNovoFormato.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chbNovoFormato.ForeColor = System.Drawing.Color.Green;
            this.chbNovoFormato.Limpar = false;
            this.chbNovoFormato.Location = new System.Drawing.Point(10, 21);
            this.chbNovoFormato.Name = "chbNovoFormato";
            this.chbNovoFormato.Obrigatorio = false;
            this.chbNovoFormato.ObrigatorioMensagem = null;
            this.chbNovoFormato.PreValidacaoMensagem = null;
            this.chbNovoFormato.PreValidado = false;
            this.chbNovoFormato.Size = new System.Drawing.Size(138, 18);
            this.chbNovoFormato.TabIndex = 138;
            this.chbNovoFormato.Text = "FORMATO NOVO";
            this.chbNovoFormato.UseVisualStyleBackColor = true;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(3, 80);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(426, 12);
            this.hacLabel6.TabIndex = 137;
            this.hacLabel6.Text = "Para Conferência: (Total Devoluções * 2) + (Total GE29A * 2) + (Total GE29C_Dir)";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(277, 49);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(16, 14);
            this.lblTotal.TabIndex = 136;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(147, 50);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(127, 13);
            this.hacLabel4.TabIndex = 135;
            this.hacLabel4.Text = "Total gravado no txt:";
            // 
            // btnGerarArquivo
            // 
            this.btnGerarArquivo.AlterarStatus = true;
            this.btnGerarArquivo.BackColor = System.Drawing.Color.White;
            this.btnGerarArquivo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGerarArquivo.BackgroundImage")));
            this.btnGerarArquivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarArquivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnGerarArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarArquivo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnGerarArquivo.Location = new System.Drawing.Point(10, 46);
            this.btnGerarArquivo.Name = "btnGerarArquivo";
            this.btnGerarArquivo.Size = new System.Drawing.Size(122, 22);
            this.btnGerarArquivo.TabIndex = 15;
            this.btnGerarArquivo.Text = "Gerar Arquivo HAC";
            this.btnGerarArquivo.UseVisualStyleBackColor = true;
            this.btnGerarArquivo.Click += new System.EventHandler(this.btnGerarArquivo_Click);
            // 
            // chbDevolucao
            // 
            this.chbDevolucao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbDevolucao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbDevolucao.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chbDevolucao.Limpar = false;
            this.chbDevolucao.Location = new System.Drawing.Point(14, 7);
            this.chbDevolucao.Name = "chbDevolucao";
            this.chbDevolucao.Obrigatorio = false;
            this.chbDevolucao.ObrigatorioMensagem = null;
            this.chbDevolucao.PreValidacaoMensagem = null;
            this.chbDevolucao.PreValidado = false;
            this.chbDevolucao.Size = new System.Drawing.Size(186, 35);
            this.chbDevolucao.TabIndex = 6;
            this.chbDevolucao.Text = "Pesquisar Devoluções";
            this.chbDevolucao.UseVisualStyleBackColor = true;
            this.chbDevolucao.Click += new System.EventHandler(this.chbDevolucao_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPlanQtdsConsCCusto);
            this.groupBox1.Controls.Add(this.rbCentroCustoSint);
            this.groupBox1.Controls.Add(this.rbCentroCustoAnal);
            this.groupBox1.Controls.Add(this.rbUHSint);
            this.groupBox1.Controls.Add(this.rbCentroCustoData);
            this.groupBox1.Controls.Add(this.rbUHAnal);
            this.groupBox1.Location = new System.Drawing.Point(7, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 140);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnPlanQtdsConsCCusto
            // 
            this.btnPlanQtdsConsCCusto.AlterarStatus = true;
            this.btnPlanQtdsConsCCusto.BackColor = System.Drawing.Color.White;
            this.btnPlanQtdsConsCCusto.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.Export_Excel;
            this.btnPlanQtdsConsCCusto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlanQtdsConsCCusto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanQtdsConsCCusto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPlanQtdsConsCCusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanQtdsConsCCusto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPlanQtdsConsCCusto.Location = new System.Drawing.Point(391, 86);
            this.btnPlanQtdsConsCCusto.Name = "btnPlanQtdsConsCCusto";
            this.btnPlanQtdsConsCCusto.Size = new System.Drawing.Size(18, 18);
            this.btnPlanQtdsConsCCusto.TabIndex = 136;
            this.toolTip1.SetToolTip(this.btnPlanQtdsConsCCusto, "Gerar Planilha c/ QTDS. (Consumo C. Custo)");
            this.btnPlanQtdsConsCCusto.UseVisualStyleBackColor = true;
            this.btnPlanQtdsConsCCusto.Click += new System.EventHandler(this.btnPlanQtdsConsCCusto_Click);
            // 
            // rbCentroCustoSint
            // 
            this.rbCentroCustoSint.AutoSize = true;
            this.rbCentroCustoSint.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCentroCustoSint.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCentroCustoSint.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCentroCustoSint.Limpar = false;
            this.rbCentroCustoSint.Location = new System.Drawing.Point(6, 108);
            this.rbCentroCustoSint.Name = "rbCentroCustoSint";
            this.rbCentroCustoSint.Obrigatorio = false;
            this.rbCentroCustoSint.ObrigatorioMensagem = null;
            this.rbCentroCustoSint.PreValidacaoMensagem = null;
            this.rbCentroCustoSint.PreValidado = false;
            this.rbCentroCustoSint.Size = new System.Drawing.Size(400, 17);
            this.rbCentroCustoSint.TabIndex = 13;
            this.rbCentroCustoSint.Text = "GE29C_Dir - Despesas/Quebras/Perdas dos C. Custos (Sintético)";
            this.rbCentroCustoSint.UseVisualStyleBackColor = true;
            this.rbCentroCustoSint.CheckedChanged += new System.EventHandler(this.rbCentroCustoSint_CheckedChanged);
            // 
            // rbCentroCustoAnal
            // 
            this.rbCentroCustoAnal.AutoSize = true;
            this.rbCentroCustoAnal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCentroCustoAnal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCentroCustoAnal.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCentroCustoAnal.Limpar = false;
            this.rbCentroCustoAnal.Location = new System.Drawing.Point(6, 85);
            this.rbCentroCustoAnal.Name = "rbCentroCustoAnal";
            this.rbCentroCustoAnal.Obrigatorio = false;
            this.rbCentroCustoAnal.ObrigatorioMensagem = null;
            this.rbCentroCustoAnal.PreValidacaoMensagem = null;
            this.rbCentroCustoAnal.PreValidado = false;
            this.rbCentroCustoAnal.Size = new System.Drawing.Size(386, 17);
            this.rbCentroCustoAnal.TabIndex = 12;
            this.rbCentroCustoAnal.Text = "GE29B_Dir - Despesas dos Centros de Custos Geral (Analítico)";
            this.rbCentroCustoAnal.UseVisualStyleBackColor = true;
            this.rbCentroCustoAnal.CheckedChanged += new System.EventHandler(this.rbCentroCustoAnal_CheckedChanged);
            // 
            // rbUHSint
            // 
            this.rbUHSint.AutoSize = true;
            this.rbUHSint.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbUHSint.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbUHSint.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUHSint.Limpar = false;
            this.rbUHSint.Location = new System.Drawing.Point(6, 40);
            this.rbUHSint.Name = "rbUHSint";
            this.rbUHSint.Obrigatorio = false;
            this.rbUHSint.ObrigatorioMensagem = null;
            this.rbUHSint.PreValidacaoMensagem = null;
            this.rbUHSint.PreValidado = false;
            this.rbUHSint.Size = new System.Drawing.Size(387, 17);
            this.rbUHSint.TabIndex = 10;
            this.rbUHSint.Text = "GE29A_Dir - Saídas para Unidades de Atendimentos (Sintético)";
            this.rbUHSint.UseVisualStyleBackColor = true;
            this.rbUHSint.CheckedChanged += new System.EventHandler(this.rbUHSint_CheckedChanged);
            // 
            // rbCentroCustoData
            // 
            this.rbCentroCustoData.AutoSize = true;
            this.rbCentroCustoData.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCentroCustoData.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCentroCustoData.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCentroCustoData.Limpar = false;
            this.rbCentroCustoData.Location = new System.Drawing.Point(6, 62);
            this.rbCentroCustoData.Name = "rbCentroCustoData";
            this.rbCentroCustoData.Obrigatorio = false;
            this.rbCentroCustoData.ObrigatorioMensagem = null;
            this.rbCentroCustoData.PreValidacaoMensagem = null;
            this.rbCentroCustoData.PreValidado = false;
            this.rbCentroCustoData.Size = new System.Drawing.Size(381, 17);
            this.rbCentroCustoData.TabIndex = 11;
            this.rbCentroCustoData.Text = "GE29B - Despesas dos Centros de Custos por Data (Analítico)";
            this.rbCentroCustoData.UseVisualStyleBackColor = true;
            this.rbCentroCustoData.CheckedChanged += new System.EventHandler(this.rbCentroCustoData_CheckedChanged);
            // 
            // rbUHAnal
            // 
            this.rbUHAnal.AutoSize = true;
            this.rbUHAnal.Checked = true;
            this.rbUHAnal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbUHAnal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbUHAnal.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUHAnal.Limpar = false;
            this.rbUHAnal.Location = new System.Drawing.Point(6, 18);
            this.rbUHAnal.Name = "rbUHAnal";
            this.rbUHAnal.Obrigatorio = false;
            this.rbUHAnal.ObrigatorioMensagem = null;
            this.rbUHAnal.PreValidacaoMensagem = null;
            this.rbUHAnal.PreValidado = false;
            this.rbUHAnal.Size = new System.Drawing.Size(362, 17);
            this.rbUHAnal.TabIndex = 9;
            this.rbUHAnal.TabStop = true;
            this.rbUHAnal.Text = "GE29A - Saídas para Unidades de Atendimentos (Analítico)";
            this.rbUHAnal.UseVisualStyleBackColor = true;
            this.rbUHAnal.CheckedChanged += new System.EventHandler(this.rbUHAnal_CheckedChanged);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(101, 50);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(12, 13);
            this.hacLabel3.TabIndex = 134;
            this.hacLabel3.Text = "/";
            // 
            // tsRel
            // 
            this.tsRel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsRel.BackgroundImage")));
            this.tsRel.CancelarVisivel = false;
            this.tsRel.ExcluirVisivel = false;
            this.tsRel.ImprimirVisivel = false;
            this.tsRel.LimparVisivel = false;
            this.tsRel.Location = new System.Drawing.Point(0, 0);
            this.tsRel.MatMedVisivel = false;
            this.tsRel.Name = "tsRel";
            this.tsRel.NomeControleFoco = null;
            this.tsRel.NovoVisivel = false;
            this.tsRel.SalvarVisivel = false;
            this.tsRel.Size = new System.Drawing.Size(476, 28);
            this.tsRel.TabIndex = 0;
            this.tsRel.Text = "hacToolStrip1";
            this.tsRel.TituloTela = "Posição Mensal de Estoque";
            this.tsRel.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.hacToolStrip1_ImprimirClick);
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
            this.btnExcel.Location = new System.Drawing.Point(446, 45);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(22, 22);
            this.btnExcel.TabIndex = 135;
            this.toolTip1.SetToolTip(this.btnExcel, "Análise Custo Médio");
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // chbContabil
            // 
            this.chbContabil.AutoSize = true;
            this.chbContabil.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbContabil.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbContabil.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
            this.chbContabil.Limpar = false;
            this.chbContabil.Location = new System.Drawing.Point(257, 48);
            this.chbContabil.Name = "chbContabil";
            this.chbContabil.Obrigatorio = false;
            this.chbContabil.ObrigatorioMensagem = null;
            this.chbContabil.PreValidacaoMensagem = null;
            this.chbContabil.PreValidado = false;
            this.chbContabil.Size = new System.Drawing.Size(74, 18);
            this.chbContabil.TabIndex = 136;
            this.chbContabil.Text = "Contábil";
            this.chbContabil.UseVisualStyleBackColor = true;
            this.chbContabil.Visible = false;
            this.chbContabil.Click += new System.EventHandler(this.chbContabil_Click);
            // 
            // grbGerarPrevia
            // 
            this.grbGerarPrevia.Controls.Add(this.btnGerarPrevia);
            this.grbGerarPrevia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGerarPrevia.Location = new System.Drawing.Point(10, 375);
            this.grbGerarPrevia.Name = "grbGerarPrevia";
            this.grbGerarPrevia.Size = new System.Drawing.Size(144, 54);
            this.grbGerarPrevia.TabIndex = 137;
            this.grbGerarPrevia.TabStop = false;
            this.grbGerarPrevia.Text = "PRÉVIA MÊS ATUAL";
            this.grbGerarPrevia.Visible = false;
            // 
            // btnGerarPrevia
            // 
            this.btnGerarPrevia.AlterarStatus = true;
            this.btnGerarPrevia.BackColor = System.Drawing.Color.White;
            this.btnGerarPrevia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGerarPrevia.BackgroundImage")));
            this.btnGerarPrevia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarPrevia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnGerarPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarPrevia.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnGerarPrevia.Location = new System.Drawing.Point(9, 22);
            this.btnGerarPrevia.Name = "btnGerarPrevia";
            this.btnGerarPrevia.Size = new System.Drawing.Size(122, 22);
            this.btnGerarPrevia.TabIndex = 16;
            this.btnGerarPrevia.Text = "GERAR PRÉVIA";
            this.btnGerarPrevia.UseVisualStyleBackColor = true;
            this.btnGerarPrevia.Click += new System.EventHandler(this.btnGerarPrevia_Click);
            // 
            // timer
            // 
            this.timer.Interval = 20000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblDataAtualizacaoPrevia
            // 
            this.lblDataAtualizacaoPrevia.AutoSize = true;
            this.lblDataAtualizacaoPrevia.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold);
            this.lblDataAtualizacaoPrevia.ForeColor = System.Drawing.Color.Red;
            this.lblDataAtualizacaoPrevia.Location = new System.Drawing.Point(163, 397);
            this.lblDataAtualizacaoPrevia.Name = "lblDataAtualizacaoPrevia";
            this.lblDataAtualizacaoPrevia.Size = new System.Drawing.Size(0, 22);
            this.lblDataAtualizacaoPrevia.TabIndex = 138;
            // 
            // chbPadraoNao
            // 
            this.chbPadraoNao.AutoSize = true;
            this.chbPadraoNao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbPadraoNao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPadraoNao.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPadraoNao.Limpar = true;
            this.chbPadraoNao.Location = new System.Drawing.Point(73, 50);
            this.chbPadraoNao.Name = "chbPadraoNao";
            this.chbPadraoNao.Obrigatorio = false;
            this.chbPadraoNao.ObrigatorioMensagem = null;
            this.chbPadraoNao.PreValidacaoMensagem = null;
            this.chbPadraoNao.PreValidado = false;
            this.chbPadraoNao.Size = new System.Drawing.Size(157, 17);
            this.chbPadraoNao.TabIndex = 162;
            this.chbPadraoNao.Text = "APENAS NÃO PADRÃO";
            this.chbPadraoNao.UseVisualStyleBackColor = true;
            this.chbPadraoNao.Visible = false;
            this.chbPadraoNao.Click += new System.EventHandler(this.chbPadraoNao_Click);
            // 
            // chbPadrao
            // 
            this.chbPadrao.AutoSize = true;
            this.chbPadrao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbPadrao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPadrao.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPadrao.Limpar = true;
            this.chbPadrao.Location = new System.Drawing.Point(234, 50);
            this.chbPadrao.Name = "chbPadrao";
            this.chbPadrao.Obrigatorio = false;
            this.chbPadrao.ObrigatorioMensagem = null;
            this.chbPadrao.PreValidacaoMensagem = null;
            this.chbPadrao.PreValidado = false;
            this.chbPadrao.Size = new System.Drawing.Size(128, 17);
            this.chbPadrao.TabIndex = 161;
            this.chbPadrao.Text = "APENAS PADRÃO";
            this.chbPadrao.UseVisualStyleBackColor = true;
            this.chbPadrao.Visible = false;
            this.chbPadrao.Click += new System.EventHandler(this.chbPadrao_Click);
            // 
            // FrmPosicaoMensalProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 438);
            this.Controls.Add(this.lblDataAtualizacaoPrevia);
            this.Controls.Add(this.grbGerarPrevia);
            this.Controls.Add(this.chbContabil);
            this.Controls.Add(this.grbSaidas);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.chbGrupo);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.nmMes);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tsRel);
            this.Controls.Add(this.grbPosMensal);
            this.Name = "FrmPosicaoMensalProduto";
            this.Text = "Relatórios para Gestão de Estoque";
            this.Load += new System.EventHandler(this.FrmPosicaoMensalProduto_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMes)).EndInit();
            this.grbPosMensal.ResumeLayout(false);
            this.grbPosMensal.PerformLayout();
            this.grbSaidas.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbGerarPrevia.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacToolStrip tsRel;
        private System.Windows.Forms.GroupBox groupBox4;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbAcs;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbHac;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel1;
        private System.Windows.Forms.NumericUpDown nmMes;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtAno;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtMes;
        private HospitalAnaCosta.SGS.Componentes.HacCheckBox chbGrupo;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblUnidade;
        private HospitalAnaCosta.SGS.Componentes.HacCmbUnidade cmbUnidade;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblGrupo;
        private HospitalAnaCosta.SGS.Componentes.HacComboBox cmbGrupo;
        private System.Windows.Forms.GroupBox grbPosMensal;
        private System.Windows.Forms.GroupBox grbSaidas;
        private System.Windows.Forms.GroupBox groupBox1;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbCentroCustoData;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbUHAnal;
        private HospitalAnaCosta.SGS.Componentes.HacCheckBox chbDevolucao;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbUHSint;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbCentroCustoSint;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbCentroCustoAnal;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel4;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnGerarArquivo;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblTotal;
        private System.Windows.Forms.SaveFileDialog sfDir;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblSubGrupo;
        private HospitalAnaCosta.SGS.Componentes.HacComboBox cmbSubGrupo;
        private HospitalAnaCosta.SGS.Componentes.HacCheckBox chbQuebra;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacButton btnExcel;
        private System.Windows.Forms.ToolTip toolTip1;
        private SGS.Componentes.HacCheckBox chbInventario;
        private SGS.Componentes.HacCheckBox chbNovoFormato;
        private SGS.Componentes.HacButton btnPlanQtdsConsCCusto;
        private SGS.Componentes.HacCheckBox chbContabil;
        private System.Windows.Forms.GroupBox grbGerarPrevia;
        private SGS.Componentes.HacButton btnGerarPrevia;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblDataAtualizacaoPrevia;
        private SGS.Componentes.HacCheckBox chbPadraoNao;
        private SGS.Componentes.HacCheckBox chbPadrao;
    }
}