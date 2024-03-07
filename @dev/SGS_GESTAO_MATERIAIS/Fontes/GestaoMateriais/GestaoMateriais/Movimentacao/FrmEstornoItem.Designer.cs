namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmEstornoItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstornoItem));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbOrigem = new System.Windows.Forms.GroupBox();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.grbDevolver = new System.Windows.Forms.GroupBox();
            this.rbDevFarm = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbDevAlmox = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.grbProduto = new System.Windows.Forms.GroupBox();
            this.cmbMotivo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblValidade = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblNumLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdTransf = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtDsProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblDevHotelaria = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbOrigem.SuspendLayout();
            this.grbDevolver.SuspendLayout();
            this.grbProduto.SuspendLayout();
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
            this.tsHac.Size = new System.Drawing.Size(674, 28);
            this.tsHac.TabIndex = 1;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Registro de Devolução Setor";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // grbOrigem
            // 
            this.grbOrigem.Controls.Add(this.hacLabel3);
            this.grbOrigem.Controls.Add(this.cmbLocal);
            this.grbOrigem.Controls.Add(this.cmbSetor);
            this.grbOrigem.Controls.Add(this.hacLabel2);
            this.grbOrigem.Controls.Add(this.hacLabel1);
            this.grbOrigem.Controls.Add(this.cmbUnidade);
            this.grbOrigem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbOrigem.Location = new System.Drawing.Point(11, 35);
            this.grbOrigem.Name = "grbOrigem";
            this.grbOrigem.Size = new System.Drawing.Size(301, 108);
            this.grbOrigem.TabIndex = 0;
            this.grbOrigem.TabStop = false;
            this.grbOrigem.Text = "Origem";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(19, 80);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 121;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(59, 49);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = "cmbSetor";
            this.cmbLocal.NomeComboUnidade = "cmbUnidade";
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(233, 21);
            this.cmbLocal.TabIndex = 120;
            this.cmbLocal.Text = "<Selecione>";
            this.cmbLocal.SelectionChangeCommitted += new System.EventHandler(this.cmbLocal_SelectionChangeCommitted);
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
            this.cmbSetor.Location = new System.Drawing.Point(59, 77);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = "cmbLocal";
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(233, 21);
            this.cmbSetor.TabIndex = 122;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(20, 52);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 119;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(3, 24);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 117;
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
            this.cmbUnidade.Location = new System.Drawing.Point(59, 21);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = "cmbLocal";
            this.cmbUnidade.NomeComboSetor = "cmbSetor";
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(233, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 118;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // grbDevolver
            // 
            this.grbDevolver.Controls.Add(this.rbDevFarm);
            this.grbDevolver.Controls.Add(this.rbDevAlmox);
            this.grbDevolver.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDevolver.Location = new System.Drawing.Point(322, 37);
            this.grbDevolver.Name = "grbDevolver";
            this.grbDevolver.Size = new System.Drawing.Size(177, 74);
            this.grbDevolver.TabIndex = 1;
            this.grbDevolver.TabStop = false;
            this.grbDevolver.Text = "DEVOLVER PARA";
            // 
            // rbDevFarm
            // 
            this.rbDevFarm.AutoSize = true;
            this.rbDevFarm.Checked = true;
            this.rbDevFarm.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbDevFarm.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDevFarm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDevFarm.Limpar = false;
            this.rbDevFarm.Location = new System.Drawing.Point(12, 22);
            this.rbDevFarm.Name = "rbDevFarm";
            this.rbDevFarm.Obrigatorio = false;
            this.rbDevFarm.ObrigatorioMensagem = null;
            this.rbDevFarm.PreValidacaoMensagem = null;
            this.rbDevFarm.PreValidado = false;
            this.rbDevFarm.Size = new System.Drawing.Size(122, 17);
            this.rbDevFarm.TabIndex = 1;
            this.rbDevFarm.TabStop = true;
            this.rbDevFarm.Text = "Farmácia Central";
            this.rbDevFarm.UseVisualStyleBackColor = true;
            // 
            // rbDevAlmox
            // 
            this.rbDevAlmox.AutoSize = true;
            this.rbDevAlmox.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbDevAlmox.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDevAlmox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDevAlmox.Limpar = false;
            this.rbDevAlmox.Location = new System.Drawing.Point(12, 47);
            this.rbDevAlmox.Name = "rbDevAlmox";
            this.rbDevAlmox.Obrigatorio = false;
            this.rbDevAlmox.ObrigatorioMensagem = null;
            this.rbDevAlmox.PreValidacaoMensagem = null;
            this.rbDevAlmox.PreValidado = false;
            this.rbDevAlmox.Size = new System.Drawing.Size(147, 17);
            this.rbDevAlmox.TabIndex = 0;
            this.rbDevAlmox.Text = "Almoxarifado Central";
            this.rbDevAlmox.UseVisualStyleBackColor = true;
            // 
            // grbProduto
            // 
            this.grbProduto.Controls.Add(this.cmbMotivo);
            this.grbProduto.Controls.Add(this.hacLabel11);
            this.grbProduto.Controls.Add(this.lblValidade);
            this.grbProduto.Controls.Add(this.lblNumLote);
            this.grbProduto.Controls.Add(this.txtQtdTransf);
            this.grbProduto.Controls.Add(this.txtDsProduto);
            this.grbProduto.Controls.Add(this.hacLabel9);
            this.grbProduto.Controls.Add(this.label2);
            this.grbProduto.Controls.Add(this.txtIdProduto);
            this.grbProduto.Controls.Add(this.label1);
            this.grbProduto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProduto.Location = new System.Drawing.Point(11, 149);
            this.grbProduto.Name = "grbProduto";
            this.grbProduto.Size = new System.Drawing.Size(649, 87);
            this.grbProduto.TabIndex = 2;
            this.grbProduto.TabStop = false;
            this.grbProduto.Text = "Produto";
            // 
            // cmbMotivo
            // 
            this.cmbMotivo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbMotivo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.cmbMotivo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbMotivo.FormattingEnabled = true;
            this.cmbMotivo.Limpar = true;
            this.cmbMotivo.Location = new System.Drawing.Point(246, 56);
            this.cmbMotivo.Name = "cmbMotivo";
            this.cmbMotivo.Obrigatorio = true;
            this.cmbMotivo.ObrigatorioMensagem = "Obrigatório indicação do motivo";
            this.cmbMotivo.PreValidacaoMensagem = null;
            this.cmbMotivo.PreValidado = false;
            this.cmbMotivo.Size = new System.Drawing.Size(242, 21);
            this.cmbMotivo.TabIndex = 4;
            this.cmbMotivo.Text = "<Selecione>";
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(199, 59);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(44, 13);
            this.hacLabel11.TabIndex = 141;
            this.hacLabel11.Text = "Motivo";
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblValidade.Location = new System.Drawing.Point(551, 66);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(0, 12);
            this.lblValidade.TabIndex = 87;
            this.lblValidade.Visible = false;
            // 
            // lblNumLote
            // 
            this.lblNumLote.AutoSize = true;
            this.lblNumLote.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumLote.Location = new System.Drawing.Point(551, 50);
            this.lblNumLote.Name = "lblNumLote";
            this.lblNumLote.Size = new System.Drawing.Size(0, 12);
            this.lblNumLote.TabIndex = 86;
            this.lblNumLote.Visible = false;
            // 
            // txtQtdTransf
            // 
            this.txtQtdTransf.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdTransf.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdTransf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdTransf.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtQtdTransf.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdTransf.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdTransf.Limpar = false;
            this.txtQtdTransf.Location = new System.Drawing.Point(94, 55);
            this.txtQtdTransf.MaxLength = 5;
            this.txtQtdTransf.Name = "txtQtdTransf";
            this.txtQtdTransf.NaoAjustarEdicao = false;
            this.txtQtdTransf.Obrigatorio = true;
            this.txtQtdTransf.ObrigatorioMensagem = "Qtd. Transferência Não Pode Estar Em Branco";
            this.txtQtdTransf.PreValidacaoMensagem = null;
            this.txtQtdTransf.PreValidado = false;
            this.txtQtdTransf.SelectAllOnFocus = false;
            this.txtQtdTransf.Size = new System.Drawing.Size(40, 21);
            this.txtQtdTransf.TabIndex = 3;
            this.txtQtdTransf.TabStop = false;
            this.txtQtdTransf.Text = "1";
            this.txtQtdTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdTransf.Enter += new System.EventHandler(this.txtQtdTransf_Enter);
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDsProduto.Enabled = false;
            this.txtDsProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(246, 23);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = false;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(394, 20);
            this.txtDsProduto.TabIndex = 2;
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(5, 59);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(87, 13);
            this.hacLabel9.TabIndex = 80;
            this.hacLabel9.Text = "Qtd. Devolver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 26);
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
            this.txtIdProduto.Location = new System.Drawing.Point(76, 22);
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
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód. Barra";
            // 
            // lblDevHotelaria
            // 
            this.lblDevHotelaria.AutoSize = true;
            this.lblDevHotelaria.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDevHotelaria.ForeColor = System.Drawing.Color.Green;
            this.lblDevHotelaria.Location = new System.Drawing.Point(325, 120);
            this.lblDevHotelaria.Name = "lblDevHotelaria";
            this.lblDevHotelaria.Size = new System.Drawing.Size(214, 14);
            this.lblDevHotelaria.TabIndex = 122;
            this.lblDevHotelaria.Text = "DEVOLUÇÃO PARA HOTELARIA";
            // 
            // FrmEstornoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 255);
            this.Controls.Add(this.lblDevHotelaria);
            this.Controls.Add(this.grbProduto);
            this.Controls.Add(this.grbDevolver);
            this.Controls.Add(this.grbOrigem);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmEstornoItem";
            this.Text = "Registro de Devolução";
            this.Load += new System.EventHandler(this.FrmEstornoItem_Load);
            this.grbOrigem.ResumeLayout(false);
            this.grbOrigem.PerformLayout();
            this.grbDevolver.ResumeLayout(false);
            this.grbDevolver.PerformLayout();
            this.grbProduto.ResumeLayout(false);
            this.grbProduto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox grbOrigem;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private System.Windows.Forms.GroupBox grbDevolver;
        private SGS.Componentes.HacRadioButton rbDevFarm;
        private SGS.Componentes.HacRadioButton rbDevAlmox;
        private System.Windows.Forms.GroupBox grbProduto;
        private SGS.Componentes.HacLabel lblNumLote;
        private SGS.Componentes.HacTextBox txtQtdTransf;
        private SGS.Componentes.HacLabel hacLabel9;
        private SGS.Componentes.HacTextBox txtDsProduto;
        private System.Windows.Forms.Label label2;
        private SGS.Componentes.HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label1;
        private SGS.Componentes.HacLabel hacLabel11;
        private SGS.Componentes.HacLabel lblValidade;
        private SGS.Componentes.HacComboBox cmbMotivo;
        private SGS.Componentes.HacLabel lblDevHotelaria;
    }
}