using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmTransfMatMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransfMatMed));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbOrigem = new System.Windows.Forms.GroupBox();
            this.grbTodoSaldo = new System.Windows.Forms.GroupBox();
            this.cmbKit = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.chbItensKit = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbTodoSaldo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.grbDestino = new System.Windows.Forms.GroupBox();
            this.lblObsEU = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocalDestino = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbSetorDestino = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidadeDestino = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.grbProduto = new System.Windows.Forms.GroupBox();
            this.lblNumLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdLote = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdPadrao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblQtdPadrao = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdTransf = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtEstoqueDestino = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtEstoqueOrigem = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDsProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.rbConsig = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.grbOrigem.SuspendLayout();
            this.grbTodoSaldo.SuspendLayout();
            this.grbFilial.SuspendLayout();
            this.grbDestino.SuspendLayout();
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
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 0;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Transferência de Mat/Med entre Setores";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // grbOrigem
            // 
            this.grbOrigem.Controls.Add(this.grbTodoSaldo);
            this.grbOrigem.Controls.Add(this.grbFilial);
            this.grbOrigem.Controls.Add(this.hacLabel3);
            this.grbOrigem.Controls.Add(this.cmbLocal);
            this.grbOrigem.Controls.Add(this.cmbSetor);
            this.grbOrigem.Controls.Add(this.hacLabel2);
            this.grbOrigem.Controls.Add(this.hacLabel1);
            this.grbOrigem.Controls.Add(this.cmbUnidade);
            this.grbOrigem.Location = new System.Drawing.Point(5, 32);
            this.grbOrigem.Name = "grbOrigem";
            this.grbOrigem.Size = new System.Drawing.Size(770, 99);
            this.grbOrigem.TabIndex = 1;
            this.grbOrigem.TabStop = false;
            this.grbOrigem.Text = "Origem";
            // 
            // grbTodoSaldo
            // 
            this.grbTodoSaldo.Controls.Add(this.cmbKit);
            this.grbTodoSaldo.Controls.Add(this.chbItensKit);
            this.grbTodoSaldo.Controls.Add(this.chbTodoSaldo);
            this.grbTodoSaldo.Location = new System.Drawing.Point(9, 44);
            this.grbTodoSaldo.Name = "grbTodoSaldo";
            this.grbTodoSaldo.Size = new System.Drawing.Size(589, 49);
            this.grbTodoSaldo.TabIndex = 154;
            this.grbTodoSaldo.TabStop = false;
            this.grbTodoSaldo.Visible = false;
            // 
            // cmbKit
            // 
            this.cmbKit.BackColor = System.Drawing.Color.Honeydew;
            this.cmbKit.DisplayMember = "CAD_MTMD_KIT_DSC";
            this.cmbKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKit.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbKit.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbKit.FormattingEnabled = true;
            this.cmbKit.Limpar = true;
            this.cmbKit.Location = new System.Drawing.Point(219, 17);
            this.cmbKit.MaxDropDownItems = 10;
            this.cmbKit.Name = "cmbKit";
            this.cmbKit.Obrigatorio = false;
            this.cmbKit.ObrigatorioMensagem = null;
            this.cmbKit.PreValidacaoMensagem = null;
            this.cmbKit.PreValidado = false;
            this.cmbKit.Size = new System.Drawing.Size(353, 21);
            this.cmbKit.TabIndex = 155;
            this.cmbKit.ValueMember = "CAD_MTMD_KIT_ID";
            // 
            // chbItensKit
            // 
            this.chbItensKit.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbItensKit.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbItensKit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chbItensKit.ForeColor = System.Drawing.Color.Black;
            this.chbItensKit.Limpar = true;
            this.chbItensKit.Location = new System.Drawing.Point(128, 12);
            this.chbItensKit.Name = "chbItensKit";
            this.chbItensKit.Obrigatorio = false;
            this.chbItensKit.ObrigatorioMensagem = null;
            this.chbItensKit.PreValidacaoMensagem = null;
            this.chbItensKit.PreValidado = false;
            this.chbItensKit.Size = new System.Drawing.Size(84, 35);
            this.chbItensKit.TabIndex = 154;
            this.chbItensKit.Text = "Itens Kit";
            this.chbItensKit.UseVisualStyleBackColor = true;
            this.chbItensKit.Click += new System.EventHandler(this.chbItensKit_Click);
            // 
            // chbTodoSaldo
            // 
            this.chbTodoSaldo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbTodoSaldo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbTodoSaldo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.chbTodoSaldo.ForeColor = System.Drawing.Color.Red;
            this.chbTodoSaldo.Limpar = true;
            this.chbTodoSaldo.Location = new System.Drawing.Point(10, 12);
            this.chbTodoSaldo.Name = "chbTodoSaldo";
            this.chbTodoSaldo.Obrigatorio = false;
            this.chbTodoSaldo.ObrigatorioMensagem = null;
            this.chbTodoSaldo.PreValidacaoMensagem = null;
            this.chbTodoSaldo.PreValidado = false;
            this.chbTodoSaldo.Size = new System.Drawing.Size(116, 35);
            this.chbTodoSaldo.TabIndex = 153;
            this.chbTodoSaldo.Text = "Todo o Saldo";
            this.chbTodoSaldo.UseVisualStyleBackColor = true;
            this.chbTodoSaldo.Click += new System.EventHandler(this.chbTodoSaldo_Click);
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbConsig);
            this.grbFilial.Controls.Add(this.rbCE);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(605, 44);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(158, 36);
            this.grbFilial.TabIndex = 123;
            this.grbFilial.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbCE.Limpar = false;
            this.rbCE.Location = new System.Drawing.Point(59, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = null;
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 2;
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
            this.rbHac.Location = new System.Drawing.Point(8, 13);
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
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(531, 23);
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
            this.cmbLocal.Location = new System.Drawing.Point(317, 19);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = "cmbSetor";
            this.cmbLocal.NomeComboUnidade = "cmbUnidade";
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(190, 21);
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
            this.cmbSetor.Location = new System.Drawing.Point(575, 18);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = "cmbLocal";
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 122;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(275, 23);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 119;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(3, 23);
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
            this.cmbUnidade.Location = new System.Drawing.Point(62, 20);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = "cmbLocal";
            this.cmbUnidade.NomeComboSetor = "cmbSetor";
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(190, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 118;
            this.cmbUnidade.Text = "<Selecione>";
            this.cmbUnidade.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidade_SelectionChangeCommitted);
            // 
            // grbDestino
            // 
            this.grbDestino.Controls.Add(this.lblObsEU);
            this.grbDestino.Controls.Add(this.hacLabel4);
            this.grbDestino.Controls.Add(this.cmbLocalDestino);
            this.grbDestino.Controls.Add(this.cmbSetorDestino);
            this.grbDestino.Controls.Add(this.hacLabel5);
            this.grbDestino.Controls.Add(this.hacLabel6);
            this.grbDestino.Controls.Add(this.cmbUnidadeDestino);
            this.grbDestino.Location = new System.Drawing.Point(5, 137);
            this.grbDestino.Name = "grbDestino";
            this.grbDestino.Size = new System.Drawing.Size(770, 70);
            this.grbDestino.TabIndex = 3;
            this.grbDestino.TabStop = false;
            this.grbDestino.Text = "Destino";
            // 
            // lblObsEU
            // 
            this.lblObsEU.AutoSize = true;
            this.lblObsEU.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblObsEU.ForeColor = System.Drawing.Color.Green;
            this.lblObsEU.Location = new System.Drawing.Point(349, 48);
            this.lblObsEU.Name = "lblObsEU";
            this.lblObsEU.Size = new System.Drawing.Size(404, 13);
            this.lblObsEU.TabIndex = 123;
            this.lblObsEU.Text = "Setor Destino é Estoque Único e irá abastecer o Estoque HAC";
            this.lblObsEU.Visible = false;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(531, 23);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(38, 13);
            this.hacLabel4.TabIndex = 121;
            this.hacLabel4.Text = "Setor";
            // 
            // cmbLocalDestino
            // 
            this.cmbLocalDestino.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocalDestino.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocalDestino.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbLocalDestino.FormattingEnabled = true;
            this.cmbLocalDestino.Limpar = false;
            this.cmbLocalDestino.Location = new System.Drawing.Point(317, 19);
            this.cmbLocalDestino.Name = "cmbLocalDestino";
            this.cmbLocalDestino.NomeComboSetor = "cmbSetorDestino";
            this.cmbLocalDestino.NomeComboUnidade = "cmbUnidadeDestino";
            this.cmbLocalDestino.Obrigatorio = true;
            this.cmbLocalDestino.ObrigatorioMensagem = "Local de Destino Não Pode Estar em Branco";
            this.cmbLocalDestino.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocalDestino.PreValidado = false;
            this.cmbLocalDestino.Size = new System.Drawing.Size(190, 21);
            this.cmbLocalDestino.TabIndex = 120;
            this.cmbLocalDestino.Text = "<Selecione>";
            this.cmbLocalDestino.SelectedIndexChanged += new System.EventHandler(this.cmbLocalDestino_SelectedIndexChanged);
            this.cmbLocalDestino.SelectionChangeCommitted += new System.EventHandler(this.cmbLocalDestino_SelectionChangeCommitted);
            // 
            // cmbSetorDestino
            // 
            this.cmbSetorDestino.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetorDestino.ComEstoque = true;
            this.cmbSetorDestino.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetorDestino.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbSetorDestino.FormattingEnabled = true;
            this.cmbSetorDestino.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetorDestino.Internacao = true;
            this.cmbSetorDestino.Limpar = false;
            this.cmbSetorDestino.Location = new System.Drawing.Point(575, 18);
            this.cmbSetorDestino.Name = "cmbSetorDestino";
            this.cmbSetorDestino.NaoAjustarEdicao = false;
            this.cmbSetorDestino.NomeComboLocal = "cmbLocalDestino";
            this.cmbSetorDestino.Obrigatorio = true;
            this.cmbSetorDestino.ObrigatorioMensagem = "Setor de Destino Não Pode Estar em Branco";
            this.cmbSetorDestino.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetorDestino.PreValidado = false;
            this.cmbSetorDestino.SetorUsuario = false;
            this.cmbSetorDestino.Size = new System.Drawing.Size(190, 21);
            this.cmbSetorDestino.TabIndex = 122;
            this.cmbSetorDestino.Text = "<Selecione>";
            this.cmbSetorDestino.SelectionChangeCommitted += new System.EventHandler(this.cmbSetorDestino_SelectionChangeCommitted);
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(275, 23);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(36, 13);
            this.hacLabel5.TabIndex = 119;
            this.hacLabel5.Text = "Local";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(3, 23);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(53, 13);
            this.hacLabel6.TabIndex = 117;
            this.hacLabel6.Text = "Unidade";
            // 
            // cmbUnidadeDestino
            // 
            this.cmbUnidadeDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidadeDestino.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidadeDestino.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidadeDestino.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbUnidadeDestino.Enabled = false;
            this.cmbUnidadeDestino.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbUnidadeDestino.FormattingEnabled = true;
            this.cmbUnidadeDestino.GravaAtendimento = false;
            this.cmbUnidadeDestino.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidadeDestino.Limpar = false;
            this.cmbUnidadeDestino.Location = new System.Drawing.Point(62, 20);
            this.cmbUnidadeDestino.Name = "cmbUnidadeDestino";
            this.cmbUnidadeDestino.NomeComboLocal = "cmbLocalDestino";
            this.cmbUnidadeDestino.NomeComboSetor = "cmbSetorDestino";
            this.cmbUnidadeDestino.Obrigatorio = true;
            this.cmbUnidadeDestino.ObrigatorioMensagem = "Unidade de Destino Não Pode Estar em Branco";
            this.cmbUnidadeDestino.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidadeDestino.PreValidado = false;
            this.cmbUnidadeDestino.Size = new System.Drawing.Size(190, 21);
            this.cmbUnidadeDestino.SomenteAtiva = true;
            this.cmbUnidadeDestino.SomenteUnidade = false;
            this.cmbUnidadeDestino.TabIndex = 118;
            this.cmbUnidadeDestino.Text = "<Selecione>";
            this.cmbUnidadeDestino.SelectionChangeCommitted += new System.EventHandler(this.cmbUnidadeDestino_SelectionChangeCommitted);
            // 
            // grbProduto
            // 
            this.grbProduto.Controls.Add(this.lblNumLote);
            this.grbProduto.Controls.Add(this.txtQtdLote);
            this.grbProduto.Controls.Add(this.lblLote);
            this.grbProduto.Controls.Add(this.txtQtdPadrao);
            this.grbProduto.Controls.Add(this.lblQtdPadrao);
            this.grbProduto.Controls.Add(this.txtQtdTransf);
            this.grbProduto.Controls.Add(this.hacLabel9);
            this.grbProduto.Controls.Add(this.txtEstoqueDestino);
            this.grbProduto.Controls.Add(this.hacLabel8);
            this.grbProduto.Controls.Add(this.txtEstoqueOrigem);
            this.grbProduto.Controls.Add(this.hacLabel7);
            this.grbProduto.Controls.Add(this.txtDsProduto);
            this.grbProduto.Controls.Add(this.label2);
            this.grbProduto.Controls.Add(this.txtIdProduto);
            this.grbProduto.Controls.Add(this.label1);
            this.grbProduto.Location = new System.Drawing.Point(6, 213);
            this.grbProduto.Name = "grbProduto";
            this.grbProduto.Size = new System.Drawing.Size(768, 125);
            this.grbProduto.TabIndex = 4;
            this.grbProduto.TabStop = false;
            this.grbProduto.Text = "Produto a ser transferido";
            // 
            // lblNumLote
            // 
            this.lblNumLote.AutoSize = true;
            this.lblNumLote.Font = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumLote.Location = new System.Drawing.Point(476, 58);
            this.lblNumLote.Name = "lblNumLote";
            this.lblNumLote.Size = new System.Drawing.Size(0, 12);
            this.lblNumLote.TabIndex = 86;
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
            this.txtQtdLote.Location = new System.Drawing.Point(397, 54);
            this.txtQtdLote.Name = "txtQtdLote";
            this.txtQtdLote.NaoAjustarEdicao = false;
            this.txtQtdLote.Obrigatorio = true;
            this.txtQtdLote.ObrigatorioMensagem = "Qtd. Estoque no Setor de Destino Não Pode Estar Em Branco";
            this.txtQtdLote.PreValidacaoMensagem = null;
            this.txtQtdLote.PreValidado = false;
            this.txtQtdLote.ReadOnly = true;
            this.txtQtdLote.SelectAllOnFocus = false;
            this.txtQtdLote.Size = new System.Drawing.Size(70, 21);
            this.txtQtdLote.TabIndex = 85;
            this.txtQtdLote.TabStop = false;
            this.txtQtdLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdLote.Visible = false;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblLote.Location = new System.Drawing.Point(333, 58);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(59, 13);
            this.lblLote.TabIndex = 84;
            this.lblLote.Text = "Qtd. Lote";
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
            this.txtQtdPadrao.Location = new System.Drawing.Point(397, 85);
            this.txtQtdPadrao.Name = "txtQtdPadrao";
            this.txtQtdPadrao.NaoAjustarEdicao = false;
            this.txtQtdPadrao.Obrigatorio = true;
            this.txtQtdPadrao.ObrigatorioMensagem = "Qtd. Estoque no Setor de Destino Não Pode Estar Em Branco";
            this.txtQtdPadrao.PreValidacaoMensagem = null;
            this.txtQtdPadrao.PreValidado = false;
            this.txtQtdPadrao.ReadOnly = true;
            this.txtQtdPadrao.SelectAllOnFocus = false;
            this.txtQtdPadrao.Size = new System.Drawing.Size(70, 21);
            this.txtQtdPadrao.TabIndex = 83;
            this.txtQtdPadrao.TabStop = false;
            this.txtQtdPadrao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdPadrao.Visible = false;
            // 
            // lblQtdPadrao
            // 
            this.lblQtdPadrao.AutoSize = true;
            this.lblQtdPadrao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblQtdPadrao.Location = new System.Drawing.Point(318, 89);
            this.lblQtdPadrao.Name = "lblQtdPadrao";
            this.lblQtdPadrao.Size = new System.Drawing.Size(75, 13);
            this.lblQtdPadrao.TabIndex = 82;
            this.lblQtdPadrao.Text = "Qtd. Padrão";
            this.lblQtdPadrao.Visible = false;
            // 
            // txtQtdTransf
            // 
            this.txtQtdTransf.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdTransf.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdTransf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdTransf.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtQtdTransf.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtdTransf.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdTransf.Limpar = true;
            this.txtQtdTransf.Location = new System.Drawing.Point(695, 85);
            this.txtQtdTransf.MaxLength = 5;
            this.txtQtdTransf.Name = "txtQtdTransf";
            this.txtQtdTransf.NaoAjustarEdicao = false;
            this.txtQtdTransf.Obrigatorio = true;
            this.txtQtdTransf.ObrigatorioMensagem = "Qtd. Transferência Não Pode Estar Em Branco";
            this.txtQtdTransf.PreValidacaoMensagem = null;
            this.txtQtdTransf.PreValidado = false;
            this.txtQtdTransf.SelectAllOnFocus = false;
            this.txtQtdTransf.Size = new System.Drawing.Size(50, 21);
            this.txtQtdTransf.TabIndex = 81;
            this.txtQtdTransf.TabStop = false;
            this.txtQtdTransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(576, 89);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(112, 13);
            this.hacLabel9.TabIndex = 80;
            this.hacLabel9.Text = "Qtd. Transferência";
            // 
            // txtEstoqueDestino
            // 
            this.txtEstoqueDestino.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtEstoqueDestino.BackColor = System.Drawing.Color.Honeydew;
            this.txtEstoqueDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstoqueDestino.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtEstoqueDestino.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtEstoqueDestino.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtEstoqueDestino.Limpar = true;
            this.txtEstoqueDestino.Location = new System.Drawing.Point(209, 85);
            this.txtEstoqueDestino.Name = "txtEstoqueDestino";
            this.txtEstoqueDestino.NaoAjustarEdicao = false;
            this.txtEstoqueDestino.Obrigatorio = true;
            this.txtEstoqueDestino.ObrigatorioMensagem = "Qtd. Estoque no Setor de Destino Não Pode Estar Em Branco";
            this.txtEstoqueDestino.PreValidacaoMensagem = null;
            this.txtEstoqueDestino.PreValidado = false;
            this.txtEstoqueDestino.ReadOnly = true;
            this.txtEstoqueDestino.SelectAllOnFocus = false;
            this.txtEstoqueDestino.Size = new System.Drawing.Size(91, 21);
            this.txtEstoqueDestino.TabIndex = 79;
            this.txtEstoqueDestino.TabStop = false;
            this.txtEstoqueDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(7, 89);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(198, 13);
            this.hacLabel8.TabIndex = 78;
            this.hacLabel8.Text = "Qtd. Estoque no Setor de Destino";
            // 
            // txtEstoqueOrigem
            // 
            this.txtEstoqueOrigem.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtEstoqueOrigem.BackColor = System.Drawing.Color.Honeydew;
            this.txtEstoqueOrigem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstoqueOrigem.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtEstoqueOrigem.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtEstoqueOrigem.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtEstoqueOrigem.Limpar = true;
            this.txtEstoqueOrigem.Location = new System.Drawing.Point(209, 54);
            this.txtEstoqueOrigem.Name = "txtEstoqueOrigem";
            this.txtEstoqueOrigem.NaoAjustarEdicao = false;
            this.txtEstoqueOrigem.Obrigatorio = true;
            this.txtEstoqueOrigem.ObrigatorioMensagem = "Qtd. Estoque no Setor de Origem Não Pode Estar Em Branco";
            this.txtEstoqueOrigem.PreValidacaoMensagem = null;
            this.txtEstoqueOrigem.PreValidado = false;
            this.txtEstoqueOrigem.ReadOnly = true;
            this.txtEstoqueOrigem.SelectAllOnFocus = false;
            this.txtEstoqueOrigem.Size = new System.Drawing.Size(91, 21);
            this.txtEstoqueOrigem.TabIndex = 77;
            this.txtEstoqueOrigem.TabStop = false;
            this.txtEstoqueOrigem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(7, 57);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(197, 13);
            this.hacLabel7.TabIndex = 76;
            this.hacLabel7.Text = "Qtd. Estoque no Setor de Origem";
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDsProduto.Enabled = false;
            this.txtDsProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(228, 21);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = false;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(519, 21);
            this.txtDsProduto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
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
            this.txtIdProduto.Location = new System.Drawing.Point(62, 22);
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
            // rbConsig
            // 
            this.rbConsig.AutoSize = true;
            this.rbConsig.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbConsig.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbConsig.Limpar = false;
            this.rbConsig.Location = new System.Drawing.Point(102, 13);
            this.rbConsig.Name = "rbConsig";
            this.rbConsig.Obrigatorio = false;
            this.rbConsig.ObrigatorioMensagem = "";
            this.rbConsig.PreValidacaoMensagem = null;
            this.rbConsig.PreValidado = false;
            this.rbConsig.Size = new System.Drawing.Size(55, 17);
            this.rbConsig.TabIndex = 121;
            this.rbConsig.TabStop = true;
            this.rbConsig.Text = "CONS";
            this.rbConsig.UseVisualStyleBackColor = true;
            this.rbConsig.CheckedChanged += new System.EventHandler(this.rbConsig_CheckedChanged);
            // 
            // FrmTransfMatMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 347);
            this.Controls.Add(this.grbProduto);
            this.Controls.Add(this.grbDestino);
            this.Controls.Add(this.grbOrigem);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmTransfMatMed";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmTransfMatMed_Load);
            this.grbOrigem.ResumeLayout(false);
            this.grbOrigem.PerformLayout();
            this.grbTodoSaldo.ResumeLayout(false);
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.grbDestino.ResumeLayout(false);
            this.grbDestino.PerformLayout();
            this.grbProduto.ResumeLayout(false);
            this.grbProduto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox grbOrigem;
        private HacLabel hacLabel3;
        private HacCmbLocal cmbLocal;
        private HacCmbSetor cmbSetor;
        private HacLabel hacLabel2;
        private HacLabel hacLabel1;
        private HacCmbUnidade cmbUnidade;
        private System.Windows.Forms.GroupBox grbDestino;
        private HacLabel hacLabel4;
        private HacCmbLocal cmbLocalDestino;
        private HacCmbSetor cmbSetorDestino;
        private HacLabel hacLabel5;
        private HacLabel hacLabel6;
        private HacCmbUnidade cmbUnidadeDestino;
        private System.Windows.Forms.GroupBox grbFilial;
        private HacRadioButton rbHac;
        private System.Windows.Forms.GroupBox grbProduto;
        private HacTextBox txtDsProduto;
        private System.Windows.Forms.Label label2;
        private HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label1;
        private HacTextBox txtEstoqueDestino;
        private HacLabel hacLabel8;
        private HacTextBox txtEstoqueOrigem;
        private HacLabel hacLabel7;
        private HacTextBox txtQtdTransf;
        private HacLabel hacLabel9;
        private HacTextBox txtQtdPadrao;
        private HacLabel lblQtdPadrao;
        private HacRadioButton rbCE;
        private HacLabel lblObsEU;
        private HacTextBox txtQtdLote;
        private HacLabel lblLote;
        private HacLabel lblNumLote;
        private System.Windows.Forms.GroupBox grbTodoSaldo;
        private HacCheckBox chbTodoSaldo;
        private HacCheckBox chbItensKit;
        private HacComboBox cmbKit;
        private HacRadioButton rbConsig;

    }
}