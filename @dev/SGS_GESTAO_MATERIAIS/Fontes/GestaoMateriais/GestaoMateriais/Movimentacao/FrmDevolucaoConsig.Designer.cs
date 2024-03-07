namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmDevolucaoConsig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucaoConsig));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbOrigem = new System.Windows.Forms.GroupBox();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.txtQtdEstoque = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbProduto = new System.Windows.Forms.GroupBox();
            this.txtFornecedor = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblValidade = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdDev = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtProdDsc = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.grbOrigem.SuspendLayout();
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
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(747, 28);
            this.tsHac.TabIndex = 0;
            this.tsHac.Text = "Devolução de Consignado";
            this.tsHac.TituloTela = "Devolução de Consignado";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
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
            this.grbOrigem.Location = new System.Drawing.Point(12, 31);
            this.grbOrigem.Name = "grbOrigem";
            this.grbOrigem.Size = new System.Drawing.Size(723, 59);
            this.grbOrigem.TabIndex = 0;
            this.grbOrigem.TabStop = false;
            this.grbOrigem.Text = "SETOR BAIXA";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(474, 27);
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
            this.cmbLocal.Location = new System.Drawing.Point(284, 24);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = "cmbSetor";
            this.cmbLocal.NomeComboUnidade = "cmbUnidade";
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(180, 21);
            this.cmbLocal.TabIndex = 120;
            this.cmbLocal.Text = "<Selecione>";
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
            this.cmbSetor.Location = new System.Drawing.Point(514, 24);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = "cmbLocal";
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(200, 21);
            this.cmbSetor.TabIndex = 122;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(245, 27);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 119;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(3, 27);
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
            this.cmbUnidade.Location = new System.Drawing.Point(59, 24);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = "cmbLocal";
            this.cmbUnidade.NomeComboSetor = "cmbSetor";
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(180, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 118;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // txtQtdEstoque
            // 
            this.txtQtdEstoque.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdEstoque.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdEstoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdEstoque.Enabled = false;
            this.txtQtdEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdEstoque.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdEstoque.Limpar = true;
            this.txtQtdEstoque.Location = new System.Drawing.Point(662, 92);
            this.txtQtdEstoque.Name = "txtQtdEstoque";
            this.txtQtdEstoque.NaoAjustarEdicao = false;
            this.txtQtdEstoque.Obrigatorio = true;
            this.txtQtdEstoque.ObrigatorioMensagem = "Qtd. Estoque no Setor de Origem Não Pode Estar Em Branco";
            this.txtQtdEstoque.PreValidacaoMensagem = null;
            this.txtQtdEstoque.PreValidado = false;
            this.txtQtdEstoque.ReadOnly = true;
            this.txtQtdEstoque.SelectAllOnFocus = false;
            this.txtQtdEstoque.Size = new System.Drawing.Size(51, 21);
            this.txtQtdEstoque.TabIndex = 5;
            this.txtQtdEstoque.TabStop = false;
            this.txtQtdEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(433, 96);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(227, 13);
            this.hacLabel7.TabIndex = 111;
            this.hacLabel7.Text = "Saldo Atual Setor Estoque Consignado";
            // 
            // grbProduto
            // 
            this.grbProduto.Controls.Add(this.txtFornecedor);
            this.grbProduto.Controls.Add(this.txtQtdEstoque);
            this.grbProduto.Controls.Add(this.hacLabel7);
            this.grbProduto.Controls.Add(this.hacLabel11);
            this.grbProduto.Controls.Add(this.lblValidade);
            this.grbProduto.Controls.Add(this.hacLabel4);
            this.grbProduto.Controls.Add(this.txtQtdDev);
            this.grbProduto.Controls.Add(this.txtProdDsc);
            this.grbProduto.Controls.Add(this.hacLabel9);
            this.grbProduto.Controls.Add(this.label3);
            this.grbProduto.Controls.Add(this.txtIdProduto);
            this.grbProduto.Controls.Add(this.label4);
            this.grbProduto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProduto.Location = new System.Drawing.Point(12, 97);
            this.grbProduto.Name = "grbProduto";
            this.grbProduto.Size = new System.Drawing.Size(723, 125);
            this.grbProduto.TabIndex = 1;
            this.grbProduto.TabStop = false;
            this.grbProduto.Text = "PRODUTO CONSIGNADO";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtFornecedor.BackColor = System.Drawing.Color.Honeydew;
            this.txtFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFornecedor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.txtFornecedor.Enabled = false;
            this.txtFornecedor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtFornecedor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtFornecedor.Limpar = true;
            this.txtFornecedor.Location = new System.Drawing.Point(187, 60);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.NaoAjustarEdicao = false;
            this.txtFornecedor.Obrigatorio = false;
            this.txtFornecedor.ObrigatorioMensagem = "";
            this.txtFornecedor.PreValidacaoMensagem = null;
            this.txtFornecedor.PreValidado = false;
            this.txtFornecedor.SelectAllOnFocus = false;
            this.txtFornecedor.Size = new System.Drawing.Size(526, 20);
            this.txtFornecedor.TabIndex = 3;
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(114, 64);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(71, 13);
            this.hacLabel11.TabIndex = 141;
            this.hacLabel11.Text = "Fornecedor";
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblValidade.Location = new System.Drawing.Point(551, 70);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(0, 12);
            this.lblValidade.TabIndex = 87;
            this.lblValidade.Visible = false;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(551, 54);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(0, 12);
            this.hacLabel4.TabIndex = 86;
            this.hacLabel4.Visible = false;
            // 
            // txtQtdDev
            // 
            this.txtQtdDev.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdDev.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdDev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdDev.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtQtdDev.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdDev.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdDev.Limpar = true;
            this.txtQtdDev.Location = new System.Drawing.Point(187, 92);
            this.txtQtdDev.MaxLength = 5;
            this.txtQtdDev.Name = "txtQtdDev";
            this.txtQtdDev.NaoAjustarEdicao = false;
            this.txtQtdDev.Obrigatorio = true;
            this.txtQtdDev.ObrigatorioMensagem = "Qtd. Transferência Não Pode Estar Em Branco";
            this.txtQtdDev.PreValidacaoMensagem = null;
            this.txtQtdDev.PreValidado = false;
            this.txtQtdDev.SelectAllOnFocus = false;
            this.txtQtdDev.Size = new System.Drawing.Size(52, 21);
            this.txtQtdDev.TabIndex = 4;
            this.txtQtdDev.TabStop = false;
            this.txtQtdDev.Text = "1";
            this.txtQtdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProdDsc
            // 
            this.txtProdDsc.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtProdDsc.BackColor = System.Drawing.Color.Honeydew;
            this.txtProdDsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProdDsc.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtProdDsc.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtProdDsc.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtProdDsc.Limpar = true;
            this.txtProdDsc.Location = new System.Drawing.Point(187, 27);
            this.txtProdDsc.Name = "txtProdDsc";
            this.txtProdDsc.NaoAjustarEdicao = false;
            this.txtProdDsc.Obrigatorio = true;
            this.txtProdDsc.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtProdDsc.PreValidacaoMensagem = null;
            this.txtProdDsc.PreValidado = false;
            this.txtProdDsc.ReadOnly = true;
            this.txtProdDsc.SelectAllOnFocus = false;
            this.txtProdDsc.Size = new System.Drawing.Size(526, 20);
            this.txtProdDsc.TabIndex = 2;
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(99, 96);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(87, 13);
            this.hacLabel9.TabIndex = 80;
            this.hacLabel9.Text = "Qtd. Devolver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrição";
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
            this.txtIdProduto.Location = new System.Drawing.Point(31, 26);
            this.txtIdProduto.MaxLength = 50;
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = false;
            this.txtIdProduto.ObrigatorioMensagem = null;
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(75, 21);
            this.txtIdProduto.TabIndex = 1;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdProduto_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID";
            // 
            // FrmDevolucaoConsig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 233);
            this.Controls.Add(this.grbProduto);
            this.Controls.Add(this.grbOrigem);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmDevolucaoConsig";
            this.Text = "Devolução de Consignado";
            this.Load += new System.EventHandler(this.FrmDevolucaoConsig_Load);
            this.grbOrigem.ResumeLayout(false);
            this.grbOrigem.PerformLayout();
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
        private SGS.Componentes.HacTextBox txtQtdEstoque;
        private SGS.Componentes.HacLabel hacLabel7;
        private System.Windows.Forms.GroupBox grbProduto;
        private SGS.Componentes.HacLabel hacLabel11;
        private SGS.Componentes.HacLabel lblValidade;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacTextBox txtQtdDev;
        private SGS.Componentes.HacTextBox txtProdDsc;
        private SGS.Componentes.HacLabel hacLabel9;
        private System.Windows.Forms.Label label3;
        private SGS.Componentes.HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label4;
        private SGS.Componentes.HacTextBox txtFornecedor;
    }
}