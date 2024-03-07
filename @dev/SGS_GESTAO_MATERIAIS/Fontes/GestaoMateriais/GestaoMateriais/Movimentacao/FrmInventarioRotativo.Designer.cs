namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmInventarioRotativo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventarioRotativo));
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbConsig = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNumLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdLote = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdPadrao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblQtdPadrao = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtNovaQtd = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdEstoque = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtUnidadeVenda = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtDsProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblFracao = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbFilial.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbConsig);
            this.grbFilial.Controls.Add(this.rbCE);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(539, 64);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(173, 38);
            this.grbFilial.TabIndex = 124;
            this.grbFilial.TabStop = false;
            // 
            // rbConsig
            // 
            this.rbConsig.AutoSize = true;
            this.rbConsig.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbConsig.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbConsig.Limpar = false;
            this.rbConsig.Location = new System.Drawing.Point(110, 13);
            this.rbConsig.Name = "rbConsig";
            this.rbConsig.Obrigatorio = false;
            this.rbConsig.ObrigatorioMensagem = "";
            this.rbConsig.PreValidacaoMensagem = null;
            this.rbConsig.PreValidado = false;
            this.rbConsig.Size = new System.Drawing.Size(55, 17);
            this.rbConsig.TabIndex = 120;
            this.rbConsig.TabStop = true;
            this.rbConsig.Text = "CONS";
            this.rbConsig.UseVisualStyleBackColor = true;
            this.rbConsig.CheckedChanged += new System.EventHandler(this.rbConsig_CheckedChanged);
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbCE.Limpar = false;
            this.rbCE.Location = new System.Drawing.Point(64, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 119;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.CheckedChanged += new System.EventHandler(this.rbCE_CheckedChanged);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(11, 13);
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
            this.rbHac.CheckedChanged += new System.EventHandler(this.rbHac_CheckedChanged);
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
            this.cmbSetor.Location = new System.Drawing.Point(533, 38);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(180, 21);
            this.cmbSetor.TabIndex = 123;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(300, 38);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(180, 21);
            this.cmbLocal.TabIndex = 122;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(4, 41);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 118;
            this.hacLabel1.Text = "Unidade";
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
            this.cmbUnidade.Location = new System.Drawing.Point(69, 38);
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
            this.cmbUnidade.TabIndex = 121;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(258, 41);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 119;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(489, 41);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 120;
            this.hacLabel3.Text = "Setor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNumLote);
            this.groupBox2.Controls.Add(this.txtQtdLote);
            this.groupBox2.Controls.Add(this.lblLote);
            this.groupBox2.Controls.Add(this.txtQtdPadrao);
            this.groupBox2.Controls.Add(this.lblQtdPadrao);
            this.groupBox2.Controls.Add(this.txtNovaQtd);
            this.groupBox2.Controls.Add(this.hacLabel6);
            this.groupBox2.Controls.Add(this.txtQtdEstoque);
            this.groupBox2.Controls.Add(this.hacLabel7);
            this.groupBox2.Controls.Add(this.txtUnidadeVenda);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDsProduto);
            this.groupBox2.Controls.Add(this.lblFracao);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtIdProduto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 136);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produto";
            // 
            // lblNumLote
            // 
            this.lblNumLote.AutoSize = true;
            this.lblNumLote.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumLote.Location = new System.Drawing.Point(460, 86);
            this.lblNumLote.Name = "lblNumLote";
            this.lblNumLote.Size = new System.Drawing.Size(0, 12);
            this.lblNumLote.TabIndex = 119;
            this.lblNumLote.Visible = false;
            // 
            // txtQtdLote
            // 
            this.txtQtdLote.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdLote.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdLote.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdLote.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdLote.Limpar = true;
            this.txtQtdLote.Location = new System.Drawing.Point(457, 59);
            this.txtQtdLote.Name = "txtQtdLote";
            this.txtQtdLote.NaoAjustarEdicao = false;
            this.txtQtdLote.Obrigatorio = true;
            this.txtQtdLote.ObrigatorioMensagem = "Qtd. Estoque no Setor de Destino Não Pode Estar Em Branco";
            this.txtQtdLote.PreValidacaoMensagem = null;
            this.txtQtdLote.PreValidado = false;
            this.txtQtdLote.ReadOnly = true;
            this.txtQtdLote.SelectAllOnFocus = false;
            this.txtQtdLote.Size = new System.Drawing.Size(45, 21);
            this.txtQtdLote.TabIndex = 118;
            this.txtQtdLote.TabStop = false;
            this.txtQtdLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdLote.Visible = false;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblLote.Location = new System.Drawing.Point(386, 63);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(67, 13);
            this.lblLote.TabIndex = 117;
            this.lblLote.Text = "Saldo Lote";
            this.lblLote.Visible = false;
            // 
            // txtQtdPadrao
            // 
            this.txtQtdPadrao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdPadrao.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdPadrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdPadrao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdPadrao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdPadrao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdPadrao.Limpar = true;
            this.txtQtdPadrao.Location = new System.Drawing.Point(304, 59);
            this.txtQtdPadrao.Name = "txtQtdPadrao";
            this.txtQtdPadrao.NaoAjustarEdicao = false;
            this.txtQtdPadrao.Obrigatorio = true;
            this.txtQtdPadrao.ObrigatorioMensagem = "Qtd. Estoque no Setor de Destino Não Pode Estar Em Branco";
            this.txtQtdPadrao.PreValidacaoMensagem = null;
            this.txtQtdPadrao.PreValidado = false;
            this.txtQtdPadrao.ReadOnly = true;
            this.txtQtdPadrao.SelectAllOnFocus = false;
            this.txtQtdPadrao.Size = new System.Drawing.Size(50, 21);
            this.txtQtdPadrao.TabIndex = 116;
            this.txtQtdPadrao.TabStop = false;
            this.txtQtdPadrao.Visible = false;
            // 
            // lblQtdPadrao
            // 
            this.lblQtdPadrao.AutoSize = true;
            this.lblQtdPadrao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblQtdPadrao.Location = new System.Drawing.Point(223, 63);
            this.lblQtdPadrao.Name = "lblQtdPadrao";
            this.lblQtdPadrao.Size = new System.Drawing.Size(75, 13);
            this.lblQtdPadrao.TabIndex = 115;
            this.lblQtdPadrao.Text = "Qtd. Padrão";
            this.lblQtdPadrao.Visible = false;
            // 
            // txtNovaQtd
            // 
            this.txtNovaQtd.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtNovaQtd.BackColor = System.Drawing.Color.Honeydew;
            this.txtNovaQtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNovaQtd.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtNovaQtd.Enabled = false;
            this.txtNovaQtd.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNovaQtd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNovaQtd.Limpar = true;
            this.txtNovaQtd.Location = new System.Drawing.Point(649, 96);
            this.txtNovaQtd.MaxLength = 10;
            this.txtNovaQtd.Name = "txtNovaQtd";
            this.txtNovaQtd.NaoAjustarEdicao = false;
            this.txtNovaQtd.Obrigatorio = true;
            this.txtNovaQtd.ObrigatorioMensagem = "Nova Qtd. Não Pode Estar em Branco";
            this.txtNovaQtd.PreValidacaoMensagem = null;
            this.txtNovaQtd.PreValidado = false;
            this.txtNovaQtd.SelectAllOnFocus = false;
            this.txtNovaQtd.Size = new System.Drawing.Size(50, 21);
            this.txtNovaQtd.TabIndex = 114;
            this.txtNovaQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(584, 99);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(64, 13);
            this.hacLabel6.TabIndex = 113;
            this.hacLabel6.Text = "Nova Qtd.";
            // 
            // txtQtdEstoque
            // 
            this.txtQtdEstoque.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdEstoque.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdEstoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdEstoque.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdEstoque.Limpar = true;
            this.txtQtdEstoque.Location = new System.Drawing.Point(649, 60);
            this.txtQtdEstoque.Name = "txtQtdEstoque";
            this.txtQtdEstoque.NaoAjustarEdicao = false;
            this.txtQtdEstoque.Obrigatorio = true;
            this.txtQtdEstoque.ObrigatorioMensagem = "Qtd. Estoque no Setor de Origem Não Pode Estar Em Branco";
            this.txtQtdEstoque.PreValidacaoMensagem = null;
            this.txtQtdEstoque.PreValidado = false;
            this.txtQtdEstoque.ReadOnly = true;
            this.txtQtdEstoque.SelectAllOnFocus = false;
            this.txtQtdEstoque.Size = new System.Drawing.Size(50, 21);
            this.txtQtdEstoque.TabIndex = 112;
            this.txtQtdEstoque.TabStop = false;
            this.txtQtdEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(510, 63);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(138, 13);
            this.hacLabel7.TabIndex = 111;
            this.hacLabel7.Text = "Saldo Total Atual Setor";
            // 
            // txtUnidadeVenda
            // 
            this.txtUnidadeVenda.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidadeVenda.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidadeVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidadeVenda.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidadeVenda.Enabled = false;
            this.txtUnidadeVenda.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidadeVenda.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidadeVenda.Limpar = true;
            this.txtUnidadeVenda.Location = new System.Drawing.Point(59, 60);
            this.txtUnidadeVenda.Name = "txtUnidadeVenda";
            this.txtUnidadeVenda.NaoAjustarEdicao = false;
            this.txtUnidadeVenda.Obrigatorio = true;
            this.txtUnidadeVenda.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtUnidadeVenda.PreValidacaoMensagem = null;
            this.txtUnidadeVenda.PreValidado = false;
            this.txtUnidadeVenda.SelectAllOnFocus = false;
            this.txtUnidadeVenda.Size = new System.Drawing.Size(157, 21);
            this.txtUnidadeVenda.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Unidade";
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDsProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDsProduto.Enabled = false;
            this.txtDsProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(225, 21);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = false;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(474, 21);
            this.txtDsProduto.TabIndex = 3;
            // 
            // lblFracao
            // 
            this.lblFracao.AutoSize = true;
            this.lblFracao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFracao.Location = new System.Drawing.Point(678, 100);
            this.lblFracao.Name = "lblFracao";
            this.lblFracao.Size = new System.Drawing.Size(0, 13);
            this.lblFracao.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição";
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtIdProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtIdProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdProduto.Limpar = true;
            this.txtIdProduto.Location = new System.Drawing.Point(59, 22);
            this.txtIdProduto.MaxLength = 50;
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = false;
            this.txtIdProduto.ObrigatorioMensagem = null;
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(100, 21);
            this.txtIdProduto.TabIndex = 1;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdProduto_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(726, 28);
            this.tsHac.TabIndex = 98;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Inventário Rotativo";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // FrmInventarioRotativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 263);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbFilial);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmInventarioRotativo";
            this.Text = "FrmInventarioRotativo";
            this.Load += new System.EventHandler(this.FrmInventarioRotativo_Load);
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox grbFilial;
        private SGS.Componentes.HacRadioButton rbCE;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacTextBox txtQtdPadrao;
        private SGS.Componentes.HacLabel lblQtdPadrao;
        private SGS.Componentes.HacTextBox txtNovaQtd;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacTextBox txtQtdEstoque;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacTextBox txtUnidadeVenda;
        private System.Windows.Forms.Label label3;
        private SGS.Componentes.HacTextBox txtDsProduto;
        private SGS.Componentes.HacLabel lblFracao;
        private System.Windows.Forms.Label label2;
        private SGS.Componentes.HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label1;
        private SGS.Componentes.HacTextBox txtQtdLote;
        private SGS.Componentes.HacLabel lblLote;
        private SGS.Componentes.HacLabel lblNumLote;
        private SGS.Componentes.HacRadioButton rbConsig;
    }
}