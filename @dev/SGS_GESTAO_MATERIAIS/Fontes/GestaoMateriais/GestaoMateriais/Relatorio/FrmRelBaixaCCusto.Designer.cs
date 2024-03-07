namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmRelBaixaCCusto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelBaixaCCusto));
            this.tsRel = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMes = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtAno = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnPesquisaCCusto = new System.Windows.Forms.PictureBox();
            this.txtCCusto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCCustoDsc = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbPorMovimento = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbPlanilhaSimples = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chbTodosSetores = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblGrupo = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbGrupo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbDevolucoes = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.rbConsig = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaCCusto)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsRel
            // 
            this.tsRel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsRel.BackgroundImage")));
            this.tsRel.CancelarVisivel = false;
            this.tsRel.ExcluirVisivel = false;
            this.tsRel.ImprimirVisivel = false;
            this.tsRel.LimparVisivel = false;
            this.tsRel.Location = new System.Drawing.Point(0, 0);
            this.tsRel.Name = "tsRel";
            this.tsRel.NomeControleFoco = null;
            this.tsRel.NovoVisivel = false;
            this.tsRel.SalvarVisivel = false;
            this.tsRel.Size = new System.Drawing.Size(505, 28);
            this.tsRel.TabIndex = 1;
            this.tsRel.Text = "hacToolStrip1";
            this.tsRel.TituloTela = "Relatório Hist. Consumo Setor";
            this.tsRel.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsRel_PesquisarClick);
            this.tsRel.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsRel_MatMedClick);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(96, 44);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(12, 13);
            this.hacLabel3.TabIndex = 138;
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
            this.txtMes.Location = new System.Drawing.Point(65, 40);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.NaoAjustarEdicao = true;
            this.txtMes.Obrigatorio = false;
            this.txtMes.ObrigatorioMensagem = null;
            this.txtMes.PreValidacaoMensagem = null;
            this.txtMes.PreValidado = false;
            this.txtMes.SelectAllOnFocus = false;
            this.txtMes.Size = new System.Drawing.Size(30, 21);
            this.txtMes.TabIndex = 136;
            // 
            // txtAno
            // 
            this.txtAno.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAno.BackColor = System.Drawing.Color.Honeydew;
            this.txtAno.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAno.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAno.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAno.Limpar = true;
            this.txtAno.Location = new System.Drawing.Point(108, 40);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.NaoAjustarEdicao = true;
            this.txtAno.Obrigatorio = false;
            this.txtAno.ObrigatorioMensagem = "";
            this.txtAno.PreValidacaoMensagem = "";
            this.txtAno.PreValidado = false;
            this.txtAno.SelectAllOnFocus = false;
            this.txtAno.Size = new System.Drawing.Size(40, 21);
            this.txtAno.TabIndex = 137;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(7, 44);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(56, 13);
            this.hacLabel1.TabIndex = 135;
            this.hacLabel1.Text = "Mês/Ano";
            // 
            // btnPesquisaCCusto
            // 
            this.btnPesquisaCCusto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisaCCusto.BackgroundImage")));
            this.btnPesquisaCCusto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaCCusto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisaCCusto.Location = new System.Drawing.Point(198, 14);
            this.btnPesquisaCCusto.Name = "btnPesquisaCCusto";
            this.btnPesquisaCCusto.Size = new System.Drawing.Size(34, 21);
            this.btnPesquisaCCusto.TabIndex = 143;
            this.btnPesquisaCCusto.TabStop = false;
            this.btnPesquisaCCusto.Click += new System.EventHandler(this.btnPesquisaCCusto_Click);
            // 
            // txtCCusto
            // 
            this.txtCCusto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCCusto.BackColor = System.Drawing.Color.Honeydew;
            this.txtCCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCCusto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtCCusto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtCCusto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCCusto.Limpar = true;
            this.txtCCusto.Location = new System.Drawing.Point(109, 14);
            this.txtCCusto.Name = "txtCCusto";
            this.txtCCusto.NaoAjustarEdicao = true;
            this.txtCCusto.Obrigatorio = false;
            this.txtCCusto.ObrigatorioMensagem = null;
            this.txtCCusto.PreValidacaoMensagem = null;
            this.txtCCusto.PreValidado = false;
            this.txtCCusto.SelectAllOnFocus = false;
            this.txtCCusto.Size = new System.Drawing.Size(86, 21);
            this.txtCCusto.TabIndex = 140;
            this.txtCCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCCusto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCCusto_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 139;
            this.label1.Text = "Centro de Custo";
            // 
            // lblCCustoDsc
            // 
            this.lblCCustoDsc.AutoSize = true;
            this.lblCCustoDsc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCCustoDsc.Location = new System.Drawing.Point(8, 45);
            this.lblCCustoDsc.Name = "lblCCustoDsc";
            this.lblCCustoDsc.Size = new System.Drawing.Size(15, 12);
            this.lblCCustoDsc.TabIndex = 144;
            this.lblCCustoDsc.Text = "--";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbConsig);
            this.groupBox4.Controls.Add(this.rbAcs);
            this.groupBox4.Controls.Add(this.rbHac);
            this.groupBox4.Location = new System.Drawing.Point(160, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(122, 36);
            this.groupBox4.TabIndex = 145;
            this.groupBox4.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = false;
            this.rbAcs.Location = new System.Drawing.Point(118, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 1;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Visible = false;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(9, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 0;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
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
            this.cmbSetor.Location = new System.Drawing.Point(59, 70);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = false;
            this.cmbSetor.ObrigatorioMensagem = null;
            this.cmbSetor.PreValidacaoMensagem = "Setor não pode estar em branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(251, 21);
            this.cmbSetor.TabIndex = 151;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(59, 43);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = false;
            this.cmbLocal.ObrigatorioMensagem = null;
            this.cmbLocal.PreValidacaoMensagem = "Local de atendimento não pode estar em branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(251, 21);
            this.cmbLocal.TabIndex = 150;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(59, 16);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = false;
            this.cmbUnidade.ObrigatorioMensagem = null;
            this.cmbUnidade.PreValidacaoMensagem = "Unidade não pode estar em branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(251, 21);
            this.cmbUnidade.SomenteAtiva = true;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 149;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(18, 73);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(38, 13);
            this.hacLabel2.TabIndex = 148;
            this.hacLabel2.Text = "Setor";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(19, 46);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(36, 13);
            this.hacLabel4.TabIndex = 147;
            this.hacLabel4.Text = "Local";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(3, 19);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(53, 13);
            this.hacLabel5.TabIndex = 146;
            this.hacLabel5.Text = "Unidade";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbPorMovimento);
            this.groupBox1.Controls.Add(this.chbPlanilhaSimples);
            this.groupBox1.Controls.Add(this.btnLimparProduto);
            this.groupBox1.Controls.Add(this.lblProduto);
            this.groupBox1.Controls.Add(this.hacLabel6);
            this.groupBox1.Controls.Add(this.chbTodosSetores);
            this.groupBox1.Controls.Add(this.cmbUnidade);
            this.groupBox1.Controls.Add(this.cmbSetor);
            this.groupBox1.Controls.Add(this.hacLabel5);
            this.groupBox1.Controls.Add(this.cmbLocal);
            this.groupBox1.Controls.Add(this.hacLabel4);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Location = new System.Drawing.Point(8, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 165);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // chbPorMovimento
            // 
            this.chbPorMovimento.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbPorMovimento.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPorMovimento.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Italic);
            this.chbPorMovimento.Limpar = false;
            this.chbPorMovimento.Location = new System.Drawing.Point(330, 37);
            this.chbPorMovimento.Name = "chbPorMovimento";
            this.chbPorMovimento.Obrigatorio = false;
            this.chbPorMovimento.ObrigatorioMensagem = null;
            this.chbPorMovimento.PreValidacaoMensagem = null;
            this.chbPorMovimento.PreValidado = false;
            this.chbPorMovimento.Size = new System.Drawing.Size(118, 35);
            this.chbPorMovimento.TabIndex = 153;
            this.chbPorMovimento.Text = "Por Movimento";
            this.chbPorMovimento.UseVisualStyleBackColor = true;
            this.chbPorMovimento.Click += new System.EventHandler(this.chbPorMovimento_Click);
            // 
            // chbPlanilhaSimples
            // 
            this.chbPlanilhaSimples.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbPlanilhaSimples.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPlanilhaSimples.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Italic);
            this.chbPlanilhaSimples.Limpar = false;
            this.chbPlanilhaSimples.Location = new System.Drawing.Point(330, 11);
            this.chbPlanilhaSimples.Name = "chbPlanilhaSimples";
            this.chbPlanilhaSimples.Obrigatorio = false;
            this.chbPlanilhaSimples.ObrigatorioMensagem = null;
            this.chbPlanilhaSimples.PreValidacaoMensagem = null;
            this.chbPlanilhaSimples.PreValidado = false;
            this.chbPlanilhaSimples.Size = new System.Drawing.Size(118, 35);
            this.chbPlanilhaSimples.TabIndex = 152;
            this.chbPlanilhaSimples.Text = "Planilha Simples";
            this.chbPlanilhaSimples.UseVisualStyleBackColor = true;
            this.chbPlanilhaSimples.Click += new System.EventHandler(this.chbPlanilhaSimples_Click);
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
            this.btnLimparProduto.Location = new System.Drawing.Point(370, 131);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 156;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Visible = false;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(57, 136);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 12);
            this.lblProduto.TabIndex = 154;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(4, 135);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(51, 13);
            this.hacLabel6.TabIndex = 153;
            this.hacLabel6.Text = "Produto";
            // 
            // chbTodosSetores
            // 
            this.chbTodosSetores.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbTodosSetores.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbTodosSetores.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chbTodosSetores.Limpar = false;
            this.chbTodosSetores.Location = new System.Drawing.Point(330, 65);
            this.chbTodosSetores.Name = "chbTodosSetores";
            this.chbTodosSetores.Obrigatorio = false;
            this.chbTodosSetores.ObrigatorioMensagem = null;
            this.chbTodosSetores.PreValidacaoMensagem = null;
            this.chbTodosSetores.PreValidado = false;
            this.chbTodosSetores.Size = new System.Drawing.Size(142, 35);
            this.chbTodosSetores.TabIndex = 154;
            this.chbTodosSetores.Text = "Todos os Setores";
            this.chbTodosSetores.UseVisualStyleBackColor = true;
            this.chbTodosSetores.Click += new System.EventHandler(this.chbTodosSetores_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblGrupo.Location = new System.Drawing.Point(22, 172);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(42, 13);
            this.lblGrupo.TabIndex = 155;
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
            this.cmbGrupo.Location = new System.Drawing.Point(67, 169);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Obrigatorio = false;
            this.cmbGrupo.ObrigatorioMensagem = null;
            this.cmbGrupo.PreValidacaoMensagem = null;
            this.cmbGrupo.PreValidado = false;
            this.cmbGrupo.Size = new System.Drawing.Size(413, 21);
            this.cmbGrupo.TabIndex = 155;
            this.cmbGrupo.Text = "<Selecione>";
            this.cmbGrupo.ValueMember = "CAD_MTMD_GRUPO_ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCCusto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnPesquisaCCusto);
            this.groupBox2.Controls.Add(this.lblCCustoDsc);
            this.groupBox2.Location = new System.Drawing.Point(8, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 70);
            this.groupBox2.TabIndex = 156;
            this.groupBox2.TabStop = false;
            // 
            // chbGrupo
            // 
            this.chbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbGrupo.Font = new System.Drawing.Font("Verdana", 8F);
            this.chbGrupo.Limpar = false;
            this.chbGrupo.Location = new System.Drawing.Point(338, 34);
            this.chbGrupo.Name = "chbGrupo";
            this.chbGrupo.Obrigatorio = false;
            this.chbGrupo.ObrigatorioMensagem = null;
            this.chbGrupo.PreValidacaoMensagem = null;
            this.chbGrupo.PreValidado = false;
            this.chbGrupo.Size = new System.Drawing.Size(169, 35);
            this.chbGrupo.TabIndex = 157;
            this.chbGrupo.Text = "Grupo sintético s/ setor";
            this.chbGrupo.UseVisualStyleBackColor = true;
            // 
            // chbDevolucoes
            // 
            this.chbDevolucoes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbDevolucoes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbDevolucoes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chbDevolucoes.Limpar = false;
            this.chbDevolucoes.Location = new System.Drawing.Point(354, 244);
            this.chbDevolucoes.Name = "chbDevolucoes";
            this.chbDevolucoes.Obrigatorio = false;
            this.chbDevolucoes.ObrigatorioMensagem = null;
            this.chbDevolucoes.PreValidacaoMensagem = null;
            this.chbDevolucoes.PreValidado = false;
            this.chbDevolucoes.Size = new System.Drawing.Size(164, 35);
            this.chbDevolucoes.TabIndex = 160;
            this.chbDevolucoes.Text = "DEVOLUÇÕES MÊS";
            this.chbDevolucoes.UseVisualStyleBackColor = true;
            this.chbDevolucoes.Click += new System.EventHandler(this.chbDevolucoes_Click);
            // 
            // rbConsig
            // 
            this.rbConsig.AutoSize = true;
            this.rbConsig.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbConsig.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbConsig.Limpar = true;
            this.rbConsig.Location = new System.Drawing.Point(59, 13);
            this.rbConsig.Name = "rbConsig";
            this.rbConsig.Obrigatorio = false;
            this.rbConsig.ObrigatorioMensagem = "";
            this.rbConsig.PreValidacaoMensagem = null;
            this.rbConsig.PreValidado = false;
            this.rbConsig.Size = new System.Drawing.Size(55, 17);
            this.rbConsig.TabIndex = 124;
            this.rbConsig.TabStop = true;
            this.rbConsig.Text = "CONS";
            this.rbConsig.UseVisualStyleBackColor = true;
            // 
            // FrmRelBaixaCCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 320);
            this.Controls.Add(this.chbDevolucoes);
            this.Controls.Add(this.chbGrupo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.cmbGrupo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.tsRel);
            this.Name = "FrmRelBaixaCCusto";
            this.Text = "Relatório Consumo Setor";
            this.Titulo = "SGS";
            this.Load += new System.EventHandler(this.FrmRelBaixaCCusto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisaCCusto)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsRel;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacTextBox txtMes;
        private SGS.Componentes.HacTextBox txtAno;
        private SGS.Componentes.HacLabel hacLabel1;
        private System.Windows.Forms.PictureBox btnPesquisaCCusto;
        private SGS.Componentes.HacTextBox txtCCusto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCCustoDsc;
        private System.Windows.Forms.GroupBox groupBox4;
        private SGS.Componentes.HacRadioButton rbAcs;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacLabel hacLabel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacLabel lblGrupo;
        private SGS.Componentes.HacComboBox cmbGrupo;
        private SGS.Componentes.HacCheckBox chbTodosSetores;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacLabel lblProduto;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacButton btnLimparProduto;
        private SGS.Componentes.HacCheckBox chbGrupo;
        private SGS.Componentes.HacCheckBox chbPlanilhaSimples;
        private SGS.Componentes.HacCheckBox chbPorMovimento;
        private SGS.Componentes.HacCheckBox chbDevolucoes;
        private SGS.Componentes.HacRadioButton rbConsig;
    }
}