namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmRelPrescricaoImp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelPrescricaoImp));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbPeriodo = new System.Windows.Forms.GroupBox();
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel12 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtIdadeAte = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.txtIdadeDe = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cmbDoenca = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.cmbDiagnostico = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel10 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel13 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnAtualizarFormCompletos = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtQtdTotalPrc = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtQtdCompletas = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtQtdIncompletas = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.btnPercAutorModif = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.rbRelMed = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.btnGerarRel = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.rbConsumoSetores = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbConsumoDoDi = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grbPeriodo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
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
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(663, 28);
            this.tsHac.TabIndex = 104;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Relatórios de Prescrições";
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // grbPeriodo
            // 
            this.grbPeriodo.Controls.Add(this.txtFim);
            this.grbPeriodo.Controls.Add(this.txtInicio);
            this.grbPeriodo.Controls.Add(this.hacLabel5);
            this.grbPeriodo.Controls.Add(this.hacLabel6);
            this.grbPeriodo.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPeriodo.Location = new System.Drawing.Point(10, 33);
            this.grbPeriodo.Name = "grbPeriodo";
            this.grbPeriodo.Size = new System.Drawing.Size(261, 52);
            this.grbPeriodo.TabIndex = 105;
            this.grbPeriodo.TabStop = false;
            this.grbPeriodo.Text = "Período para pesquisa (obrigatório)";
            // 
            // txtFim
            // 
            this.txtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Limpar = false;
            this.txtFim.Location = new System.Drawing.Point(154, 22);
            this.txtFim.MaxLength = 10;
            this.txtFim.Name = "txtFim";
            this.txtFim.NaoAjustarEdicao = true;
            this.txtFim.Obrigatorio = false;
            this.txtFim.ObrigatorioMensagem = null;
            this.txtFim.PreValidacaoMensagem = null;
            this.txtFim.PreValidado = false;
            this.txtFim.SelectAllOnFocus = false;
            this.txtFim.Size = new System.Drawing.Size(80, 20);
            this.txtFim.TabIndex = 2;
            this.txtFim.TabStop = false;
            // 
            // txtInicio
            // 
            this.txtInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Limpar = false;
            this.txtInicio.Location = new System.Drawing.Point(46, 22);
            this.txtInicio.MaxLength = 10;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.NaoAjustarEdicao = true;
            this.txtInicio.Obrigatorio = false;
            this.txtInicio.ObrigatorioMensagem = null;
            this.txtInicio.PreValidacaoMensagem = null;
            this.txtInicio.PreValidado = false;
            this.txtInicio.SelectAllOnFocus = false;
            this.txtInicio.Size = new System.Drawing.Size(80, 20);
            this.txtInicio.TabIndex = 1;
            this.txtInicio.TabStop = false;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(128, 25);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(27, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(7, 25);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 28;
            this.hacLabel6.Text = "Início";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.rbConsumoDoDi);
            this.groupBox1.Controls.Add(this.rbConsumoSetores);
            this.groupBox1.Controls.Add(this.btnGerarRel);
            this.groupBox1.Controls.Add(this.rbRelMed);
            this.groupBox1.Controls.Add(this.hacLabel8);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.txtIdadeAte);
            this.groupBox1.Controls.Add(this.hacLabel9);
            this.groupBox1.Controls.Add(this.txtIdadeDe);
            this.groupBox1.Controls.Add(this.btnLimparProduto);
            this.groupBox1.Controls.Add(this.lblProduto);
            this.groupBox1.Controls.Add(this.hacLabel12);
            this.groupBox1.Location = new System.Drawing.Point(10, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 253);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            // 
            // btnLimparProduto
            // 
            this.btnLimparProduto.AlterarStatus = true;
            this.btnLimparProduto.BackColor = System.Drawing.Color.White;
            this.btnLimparProduto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimparProduto.BackgroundImage")));
            this.btnLimparProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimparProduto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnLimparProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparProduto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnLimparProduto.Location = new System.Drawing.Point(526, 14);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 159;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Visible = false;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(65, 17);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 14);
            this.lblProduto.TabIndex = 161;
            // 
            // hacLabel12
            // 
            this.hacLabel12.AutoSize = true;
            this.hacLabel12.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel12.Location = new System.Drawing.Point(7, 18);
            this.hacLabel12.Name = "hacLabel12";
            this.hacLabel12.Size = new System.Drawing.Size(51, 13);
            this.hacLabel12.TabIndex = 160;
            this.hacLabel12.Text = "Produto";
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(278, 54);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(58, 13);
            this.hacLabel8.TabIndex = 203;
            this.hacLabel8.Text = "Idade de";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(17, 76);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(38, 13);
            this.hacLabel4.TabIndex = 202;
            this.hacLabel4.Text = "Setor";
            // 
            // txtIdadeAte
            // 
            this.txtIdadeAte.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Decimal;
            this.txtIdadeAte.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdadeAte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdadeAte.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdadeAte.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtIdadeAte.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdadeAte.Limpar = true;
            this.txtIdadeAte.Location = new System.Drawing.Point(413, 50);
            this.txtIdadeAte.MaxLength = 3;
            this.txtIdadeAte.Name = "txtIdadeAte";
            this.txtIdadeAte.NaoAjustarEdicao = true;
            this.txtIdadeAte.Obrigatorio = false;
            this.txtIdadeAte.ObrigatorioMensagem = "";
            this.txtIdadeAte.PreValidacaoMensagem = null;
            this.txtIdadeAte.PreValidado = false;
            this.txtIdadeAte.SelectAllOnFocus = false;
            this.txtIdadeAte.Size = new System.Drawing.Size(45, 21);
            this.txtIdadeAte.TabIndex = 198;
            this.txtIdadeAte.TabStop = false;
            this.txtIdadeAte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(19, 47);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 201;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(384, 54);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(25, 13);
            this.hacLabel9.TabIndex = 204;
            this.hacLabel9.Text = "até";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = true;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = true;
            this.cmbUnidade.Location = new System.Drawing.Point(56, 15);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(202, 21);
            this.cmbUnidade.SomenteAtiva = true;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 194;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // txtIdadeDe
            // 
            this.txtIdadeDe.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Decimal;
            this.txtIdadeDe.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdadeDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdadeDe.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdadeDe.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtIdadeDe.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdadeDe.Limpar = true;
            this.txtIdadeDe.Location = new System.Drawing.Point(336, 50);
            this.txtIdadeDe.MaxLength = 3;
            this.txtIdadeDe.Name = "txtIdadeDe";
            this.txtIdadeDe.NaoAjustarEdicao = true;
            this.txtIdadeDe.Obrigatorio = false;
            this.txtIdadeDe.ObrigatorioMensagem = "";
            this.txtIdadeDe.PreValidacaoMensagem = null;
            this.txtIdadeDe.PreValidado = false;
            this.txtIdadeDe.SelectAllOnFocus = false;
            this.txtIdadeDe.Size = new System.Drawing.Size(45, 21);
            this.txtIdadeDe.TabIndex = 197;
            this.txtIdadeDe.TabStop = false;
            this.txtIdadeDe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(3, 18);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 200;
            this.hacLabel1.Text = "Unidade";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(56, 44);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(202, 21);
            this.cmbLocal.TabIndex = 195;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = true;
            this.cmbSetor.Location = new System.Drawing.Point(56, 73);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(202, 21);
            this.cmbSetor.TabIndex = 196;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cmbDoenca);
            this.groupBox8.Controls.Add(this.cmbDiagnostico);
            this.groupBox8.Controls.Add(this.hacLabel11);
            this.groupBox8.Controls.Add(this.hacLabel10);
            this.groupBox8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(276, 72);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(354, 61);
            this.groupBox8.TabIndex = 205;
            this.groupBox8.TabStop = false;
            // 
            // cmbDoenca
            // 
            this.cmbDoenca.BackColor = System.Drawing.Color.Honeydew;
            this.cmbDoenca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoenca.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbDoenca.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbDoenca.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoenca.FormattingEnabled = true;
            this.cmbDoenca.Limpar = true;
            this.cmbDoenca.Location = new System.Drawing.Point(118, 37);
            this.cmbDoenca.Name = "cmbDoenca";
            this.cmbDoenca.Obrigatorio = false;
            this.cmbDoenca.ObrigatorioMensagem = null;
            this.cmbDoenca.PreValidacaoMensagem = null;
            this.cmbDoenca.PreValidado = false;
            this.cmbDoenca.Size = new System.Drawing.Size(230, 20);
            this.cmbDoenca.TabIndex = 3;
            this.cmbDoenca.SelectionChangeCommitted += new System.EventHandler(this.cmbDoenca_SelectionChangeCommitted);
            // 
            // cmbDiagnostico
            // 
            this.cmbDiagnostico.BackColor = System.Drawing.Color.Honeydew;
            this.cmbDiagnostico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiagnostico.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbDiagnostico.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbDiagnostico.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiagnostico.FormattingEnabled = true;
            this.cmbDiagnostico.Limpar = true;
            this.cmbDiagnostico.Location = new System.Drawing.Point(118, 11);
            this.cmbDiagnostico.Name = "cmbDiagnostico";
            this.cmbDiagnostico.Obrigatorio = false;
            this.cmbDiagnostico.ObrigatorioMensagem = null;
            this.cmbDiagnostico.PreValidacaoMensagem = null;
            this.cmbDiagnostico.PreValidado = false;
            this.cmbDiagnostico.Size = new System.Drawing.Size(230, 20);
            this.cmbDiagnostico.TabIndex = 2;
            this.cmbDiagnostico.SelectionChangeCommitted += new System.EventHandler(this.cmbDiagnostico_SelectionChangeCommitted);
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(13, 41);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(105, 13);
            this.hacLabel11.TabIndex = 192;
            this.hacLabel11.Text = "Doença de Base:";
            // 
            // hacLabel10
            // 
            this.hacLabel10.AutoSize = true;
            this.hacLabel10.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel10.Location = new System.Drawing.Point(2, 15);
            this.hacLabel10.Name = "hacLabel10";
            this.hacLabel10.Size = new System.Drawing.Size(115, 13);
            this.hacLabel10.TabIndex = 191;
            this.hacLabel10.Text = "Diagnóstico Infec.:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPercAutorModif);
            this.groupBox2.Controls.Add(this.txtQtdIncompletas);
            this.groupBox2.Controls.Add(this.txtQtdCompletas);
            this.groupBox2.Controls.Add(this.txtQtdTotalPrc);
            this.groupBox2.Controls.Add(this.btnAtualizarFormCompletos);
            this.groupBox2.Controls.Add(this.hacLabel13);
            this.groupBox2.Controls.Add(this.hacLabel7);
            this.groupBox2.Controls.Add(this.hacLabel3);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(278, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 75);
            this.groupBox2.TabIndex = 206;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Qtd. Formulários Completos/Incompletos no Período";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(7, 25);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(100, 12);
            this.hacLabel3.TabIndex = 192;
            this.hacLabel3.Text = "Qtd. Prescrições:";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(12, 51);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(94, 12);
            this.hacLabel7.TabIndex = 193;
            this.hacLabel7.Text = "Qtd. Completas:";
            // 
            // hacLabel13
            // 
            this.hacLabel13.AutoSize = true;
            this.hacLabel13.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel13.Location = new System.Drawing.Point(185, 51);
            this.hacLabel13.Name = "hacLabel13";
            this.hacLabel13.Size = new System.Drawing.Size(106, 12);
            this.hacLabel13.TabIndex = 194;
            this.hacLabel13.Text = "Qtd. Incompletas:";
            // 
            // btnAtualizarFormCompletos
            // 
            this.btnAtualizarFormCompletos.AlterarStatus = true;
            this.btnAtualizarFormCompletos.BackColor = System.Drawing.Color.White;
            this.btnAtualizarFormCompletos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAtualizarFormCompletos.BackgroundImage")));
            this.btnAtualizarFormCompletos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizarFormCompletos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnAtualizarFormCompletos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarFormCompletos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAtualizarFormCompletos.Location = new System.Drawing.Point(184, 19);
            this.btnAtualizarFormCompletos.Name = "btnAtualizarFormCompletos";
            this.btnAtualizarFormCompletos.Size = new System.Drawing.Size(67, 22);
            this.btnAtualizarFormCompletos.TabIndex = 207;
            this.btnAtualizarFormCompletos.Text = "Atualizar";
            this.btnAtualizarFormCompletos.UseVisualStyleBackColor = true;
            this.btnAtualizarFormCompletos.Click += new System.EventHandler(this.btnAtualizarFormCompletos_Click);
            // 
            // txtQtdTotalPrc
            // 
            this.txtQtdTotalPrc.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Decimal;
            this.txtQtdTotalPrc.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdTotalPrc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdTotalPrc.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdTotalPrc.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtQtdTotalPrc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdTotalPrc.Limpar = true;
            this.txtQtdTotalPrc.Location = new System.Drawing.Point(108, 21);
            this.txtQtdTotalPrc.MaxLength = 3;
            this.txtQtdTotalPrc.Name = "txtQtdTotalPrc";
            this.txtQtdTotalPrc.NaoAjustarEdicao = true;
            this.txtQtdTotalPrc.Obrigatorio = false;
            this.txtQtdTotalPrc.ObrigatorioMensagem = "";
            this.txtQtdTotalPrc.PreValidacaoMensagem = null;
            this.txtQtdTotalPrc.PreValidado = false;
            this.txtQtdTotalPrc.ReadOnly = true;
            this.txtQtdTotalPrc.SelectAllOnFocus = false;
            this.txtQtdTotalPrc.Size = new System.Drawing.Size(70, 20);
            this.txtQtdTotalPrc.TabIndex = 205;
            this.txtQtdTotalPrc.TabStop = false;
            this.txtQtdTotalPrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtdCompletas
            // 
            this.txtQtdCompletas.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Decimal;
            this.txtQtdCompletas.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdCompletas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdCompletas.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdCompletas.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtQtdCompletas.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdCompletas.Limpar = true;
            this.txtQtdCompletas.Location = new System.Drawing.Point(108, 47);
            this.txtQtdCompletas.MaxLength = 3;
            this.txtQtdCompletas.Name = "txtQtdCompletas";
            this.txtQtdCompletas.NaoAjustarEdicao = true;
            this.txtQtdCompletas.Obrigatorio = false;
            this.txtQtdCompletas.ObrigatorioMensagem = "";
            this.txtQtdCompletas.PreValidacaoMensagem = null;
            this.txtQtdCompletas.PreValidado = false;
            this.txtQtdCompletas.ReadOnly = true;
            this.txtQtdCompletas.SelectAllOnFocus = false;
            this.txtQtdCompletas.Size = new System.Drawing.Size(70, 20);
            this.txtQtdCompletas.TabIndex = 207;
            this.txtQtdCompletas.TabStop = false;
            this.txtQtdCompletas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtdIncompletas
            // 
            this.txtQtdIncompletas.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Decimal;
            this.txtQtdIncompletas.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdIncompletas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdIncompletas.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdIncompletas.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtQtdIncompletas.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdIncompletas.Limpar = true;
            this.txtQtdIncompletas.Location = new System.Drawing.Point(291, 47);
            this.txtQtdIncompletas.MaxLength = 3;
            this.txtQtdIncompletas.Name = "txtQtdIncompletas";
            this.txtQtdIncompletas.NaoAjustarEdicao = true;
            this.txtQtdIncompletas.Obrigatorio = false;
            this.txtQtdIncompletas.ObrigatorioMensagem = "";
            this.txtQtdIncompletas.PreValidacaoMensagem = null;
            this.txtQtdIncompletas.PreValidado = false;
            this.txtQtdIncompletas.ReadOnly = true;
            this.txtQtdIncompletas.SelectAllOnFocus = false;
            this.txtQtdIncompletas.Size = new System.Drawing.Size(70, 20);
            this.txtQtdIncompletas.TabIndex = 207;
            this.txtQtdIncompletas.TabStop = false;
            this.txtQtdIncompletas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPercAutorModif
            // 
            this.btnPercAutorModif.AlterarStatus = true;
            this.btnPercAutorModif.BackColor = System.Drawing.Color.White;
            this.btnPercAutorModif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPercAutorModif.BackgroundImage")));
            this.btnPercAutorModif.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPercAutorModif.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPercAutorModif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPercAutorModif.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPercAutorModif.Location = new System.Drawing.Point(256, 19);
            this.btnPercAutorModif.Name = "btnPercAutorModif";
            this.btnPercAutorModif.Size = new System.Drawing.Size(110, 22);
            this.btnPercAutorModif.TabIndex = 208;
            this.btnPercAutorModif.Text = "% Autor./Modif.";
            this.btnPercAutorModif.UseVisualStyleBackColor = true;
            this.btnPercAutorModif.Click += new System.EventHandler(this.btnPercAutorModif_Click);
            // 
            // rbRelMed
            // 
            this.rbRelMed.AutoSize = true;
            this.rbRelMed.Checked = true;
            this.rbRelMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbRelMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbRelMed.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRelMed.Limpar = true;
            this.rbRelMed.Location = new System.Drawing.Point(23, 143);
            this.rbRelMed.Name = "rbRelMed";
            this.rbRelMed.Obrigatorio = false;
            this.rbRelMed.ObrigatorioMensagem = null;
            this.rbRelMed.PreValidacaoMensagem = null;
            this.rbRelMed.PreValidado = false;
            this.rbRelMed.Size = new System.Drawing.Size(547, 17);
            this.rbRelMed.TabIndex = 206;
            this.rbRelMed.TabStop = true;
            this.rbRelMed.Text = "Mapeamento estatístico de consumo por prescrição médica com base em um medicament" +
    "o";
            this.rbRelMed.UseVisualStyleBackColor = true;
            this.rbRelMed.Click += new System.EventHandler(this.rbRelMed_Click);
            // 
            // btnGerarRel
            // 
            this.btnGerarRel.AlterarStatus = true;
            this.btnGerarRel.BackColor = System.Drawing.Color.White;
            this.btnGerarRel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGerarRel.BackgroundImage")));
            this.btnGerarRel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarRel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnGerarRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarRel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnGerarRel.Location = new System.Drawing.Point(232, 223);
            this.btnGerarRel.Name = "btnGerarRel";
            this.btnGerarRel.Size = new System.Drawing.Size(110, 22);
            this.btnGerarRel.TabIndex = 209;
            this.btnGerarRel.Text = "Gerar Relatório";
            this.btnGerarRel.UseVisualStyleBackColor = true;
            this.btnGerarRel.Click += new System.EventHandler(this.btnGerarRel_Click);
            // 
            // rbConsumoSetores
            // 
            this.rbConsumoSetores.AutoSize = true;
            this.rbConsumoSetores.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbConsumoSetores.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbConsumoSetores.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConsumoSetores.Limpar = true;
            this.rbConsumoSetores.Location = new System.Drawing.Point(23, 166);
            this.rbConsumoSetores.Name = "rbConsumoSetores";
            this.rbConsumoSetores.Obrigatorio = false;
            this.rbConsumoSetores.ObrigatorioMensagem = null;
            this.rbConsumoSetores.PreValidacaoMensagem = null;
            this.rbConsumoSetores.PreValidado = false;
            this.rbConsumoSetores.Size = new System.Drawing.Size(341, 17);
            this.rbConsumoSetores.TabIndex = 210;
            this.rbConsumoSetores.Text = "Consumo por prescrição nos setores (com demografia)";
            this.rbConsumoSetores.UseVisualStyleBackColor = true;
            this.rbConsumoSetores.Click += new System.EventHandler(this.rbConsumoSetores_Click);
            // 
            // rbConsumoDoDi
            // 
            this.rbConsumoDoDi.AutoSize = true;
            this.rbConsumoDoDi.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbConsumoDoDi.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbConsumoDoDi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConsumoDoDi.Limpar = true;
            this.rbConsumoDoDi.Location = new System.Drawing.Point(23, 189);
            this.rbConsumoDoDi.Name = "rbConsumoDoDi";
            this.rbConsumoDoDi.Obrigatorio = false;
            this.rbConsumoDoDi.ObrigatorioMensagem = null;
            this.rbConsumoDoDi.PreValidacaoMensagem = null;
            this.rbConsumoDoDi.PreValidado = false;
            this.rbConsumoDoDi.Size = new System.Drawing.Size(429, 17);
            this.rbConsumoDoDi.TabIndex = 211;
            this.rbConsumoDoDi.Text = "Consumo por prescrição agrupado por demografia/doença/diagnóstico";
            this.rbConsumoDoDi.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbLocal);
            this.groupBox3.Controls.Add(this.cmbSetor);
            this.groupBox3.Controls.Add(this.hacLabel1);
            this.groupBox3.Controls.Add(this.cmbUnidade);
            this.groupBox3.Controls.Add(this.hacLabel2);
            this.groupBox3.Controls.Add(this.hacLabel4);
            this.groupBox3.Location = new System.Drawing.Point(8, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 100);
            this.groupBox3.TabIndex = 207;
            this.groupBox3.TabStop = false;
            // 
            // FrmRelPrescricaoImp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 367);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPeriodo);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmRelPrescricaoImp";
            this.Text = "Relatórios de Prescrições";
            this.Load += new System.EventHandler(this.FrmRelPrescricaoImp_Load);
            this.grbPeriodo.ResumeLayout(false);
            this.grbPeriodo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox grbPeriodo;
        private SGS.Componentes.HacTextBox txtFim;
        private SGS.Componentes.HacTextBox txtInicio;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacButton btnLimparProduto;
        private SGS.Componentes.HacLabel lblProduto;
        private SGS.Componentes.HacLabel hacLabel12;
        private SGS.Componentes.HacLabel hacLabel8;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacTextBox txtIdadeAte;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel9;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacTextBox txtIdadeDe;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private System.Windows.Forms.GroupBox groupBox8;
        private SGS.Componentes.HacComboBox cmbDoenca;
        private SGS.Componentes.HacComboBox cmbDiagnostico;
        private SGS.Componentes.HacLabel hacLabel11;
        private SGS.Componentes.HacLabel hacLabel10;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacTextBox txtQtdIncompletas;
        private SGS.Componentes.HacTextBox txtQtdCompletas;
        private SGS.Componentes.HacTextBox txtQtdTotalPrc;
        private SGS.Componentes.HacButton btnAtualizarFormCompletos;
        private SGS.Componentes.HacLabel hacLabel13;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacButton btnPercAutorModif;
        private SGS.Componentes.HacRadioButton rbRelMed;
        private SGS.Componentes.HacRadioButton rbConsumoDoDi;
        private SGS.Componentes.HacRadioButton rbConsumoSetores;
        private SGS.Componentes.HacButton btnGerarRel;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}