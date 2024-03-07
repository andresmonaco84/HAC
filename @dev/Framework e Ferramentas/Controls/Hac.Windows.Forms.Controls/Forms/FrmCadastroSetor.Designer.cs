namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmCadastroSetor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroSetor));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grdSetor = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoAcomodacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAD_SET_FL_ATIVO_OK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAD_SET_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.cboUnidade = new Hac.Windows.Forms.Controls.HacCmbUnidade(this.components);
            this.cboLocal = new Hac.Windows.Forms.Controls.HacCmbLocal(this.components);
            this.txtAndar = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigo = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtDescricao = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtRamal = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.cboStatus = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.chkGravAtend = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.chkEstoqueProprio = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.chkPermiteInternacao = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.chkPreferencialACS = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.txtTelefone = new Hac.Windows.Forms.Controls.HacMaskedTextBox(this.components);
            this.chkAtendAlmox = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.chkServMulher = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdSetor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Unidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Local:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Andar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Descrição:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Telefone:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Código:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(246, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Ramal:";
            // 
            // grdSetor
            // 
            this.grdSetor.AllowUserToAddRows = false;
            this.grdSetor.AllowUserToDeleteRows = false;
            this.grdSetor.AllowUserToOrderColumns = true;
            this.grdSetor.AllowUserToResizeRows = false;
            this.grdSetor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSetor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.TipoAcomodacao,
            this.dataGridViewTextBoxColumn4,
            this.CAD_SET_FL_ATIVO_OK,
            this.CAD_SET_ID});
            this.grdSetor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdSetor.Location = new System.Drawing.Point(15, 247);
            this.grdSetor.MultiSelect = false;
            this.grdSetor.Name = "grdSetor";
            this.grdSetor.RowHeadersVisible = false;
            this.grdSetor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSetor.Size = new System.Drawing.Size(576, 282);
            this.grdSetor.TabIndex = 23;
            this.grdSetor.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdSetor_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CAD_SET_CD_SETOR";
            this.dataGridViewTextBoxColumn3.HeaderText = "Código";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // TipoAcomodacao
            // 
            this.TipoAcomodacao.DataPropertyName = "CAD_SET_DS_SETOR";
            this.TipoAcomodacao.HeaderText = "Descrição";
            this.TipoAcomodacao.Name = "TipoAcomodacao";
            this.TipoAcomodacao.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CAD_SET_NR_ANDAR";
            this.dataGridViewTextBoxColumn4.HeaderText = "Andar";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // CAD_SET_FL_ATIVO_OK
            // 
            this.CAD_SET_FL_ATIVO_OK.DataPropertyName = "CAD_SET_FL_ATIVO_OK";
            this.CAD_SET_FL_ATIVO_OK.HeaderText = "Status";
            this.CAD_SET_FL_ATIVO_OK.Name = "CAD_SET_FL_ATIVO_OK";
            // 
            // CAD_SET_ID
            // 
            this.CAD_SET_ID.DataPropertyName = "CAD_SET_ID";
            this.CAD_SET_ID.HeaderText = "idtSetor";
            this.CAD_SET_ID.Name = "CAD_SET_ID";
            this.CAD_SET_ID.Visible = false;
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.Size = new System.Drawing.Size(603, 28);
            this.tspCommand.TabIndex = 34;
            this.tspCommand.Text = "hacToolStrip1";
            this.tspCommand.TituloTela = ":: Cadastro de Setor ::";
            this.tspCommand.SairClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_SairClick);
            this.tspCommand.SalvarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_SalvarClick);
            this.tspCommand.PesquisarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_PesquisarClick);
            // 
            // cboUnidade
            // 
            this.cboUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cboUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cboUnidade.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboUnidade.Enabled = false;
            this.cboUnidade.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboUnidade.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.Limpar = false;
            this.cboUnidade.Location = new System.Drawing.Point(103, 50);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.NomeComboLocal = "cboLocal";
            this.cboUnidade.NomeComboSetor = "";
            this.cboUnidade.Obrigatorio = true;
            this.cboUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cboUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cboUnidade.PreValidado = false;
            this.cboUnidade.Size = new System.Drawing.Size(213, 20);
            this.cboUnidade.SomenteUnidade = false;
            this.cboUnidade.TabIndex = 56;
            this.cboUnidade.Text = "<Selecione>";
            // 
            // cboLocal
            // 
            this.cboLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cboLocal.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboLocal.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboLocal.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.Limpar = false;
            this.cboLocal.Location = new System.Drawing.Point(103, 81);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.NomeComboSetor = "";
            this.cboLocal.NomeComboUnidade = "cboUnidade";
            this.cboLocal.Obrigatorio = true;
            this.cboLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cboLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cboLocal.PreValidado = false;
            this.cboLocal.Size = new System.Drawing.Size(213, 20);
            this.cboLocal.TabIndex = 58;
            this.cboLocal.Text = "<Selecione>";
            // 
            // txtAndar
            // 
            this.txtAndar.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtAndar.BackColor = System.Drawing.Color.Honeydew;
            this.txtAndar.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtAndar.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtAndar.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAndar.Limpar = true;
            this.txtAndar.Location = new System.Drawing.Point(103, 112);
            this.txtAndar.MaxLength = 2;
            this.txtAndar.Name = "txtAndar";
            this.txtAndar.NaoAjustarEdicao = false;
            this.txtAndar.Obrigatorio = false;
            this.txtAndar.ObrigatorioMensagem = "";
            this.txtAndar.PreValidacaoMensagem = "";
            this.txtAndar.PreValidado = false;
            this.txtAndar.SelectAllOnFocus = true;
            this.txtAndar.Size = new System.Drawing.Size(100, 21);
            this.txtAndar.TabIndex = 59;
            // 
            // txtCodigo
            // 
            this.txtCodigo.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigo.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigo.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtCodigo.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodigo.Limpar = true;
            this.txtCodigo.Location = new System.Drawing.Point(306, 112);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.NaoAjustarEdicao = false;
            this.txtCodigo.Obrigatorio = true;
            this.txtCodigo.ObrigatorioMensagem = "Insira o Código.";
            this.txtCodigo.PreValidacaoMensagem = "";
            this.txtCodigo.PreValidado = false;
            this.txtCodigo.SelectAllOnFocus = true;
            this.txtCodigo.Size = new System.Drawing.Size(100, 21);
            this.txtCodigo.TabIndex = 60;
            // 
            // txtDescricao
            // 
            this.txtDescricao.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricao.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricao.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricao.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDescricao.Limpar = true;
            this.txtDescricao.Location = new System.Drawing.Point(103, 144);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.NaoAjustarEdicao = false;
            this.txtDescricao.Obrigatorio = true;
            this.txtDescricao.ObrigatorioMensagem = "Insira a Descrição.";
            this.txtDescricao.PreValidacaoMensagem = "";
            this.txtDescricao.PreValidado = false;
            this.txtDescricao.SelectAllOnFocus = true;
            this.txtDescricao.Size = new System.Drawing.Size(213, 21);
            this.txtDescricao.TabIndex = 61;
            // 
            // txtRamal
            // 
            this.txtRamal.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtRamal.BackColor = System.Drawing.Color.Honeydew;
            this.txtRamal.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtRamal.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtRamal.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtRamal.Limpar = true;
            this.txtRamal.Location = new System.Drawing.Point(306, 176);
            this.txtRamal.MaxLength = 10;
            this.txtRamal.Name = "txtRamal";
            this.txtRamal.NaoAjustarEdicao = false;
            this.txtRamal.Obrigatorio = false;
            this.txtRamal.ObrigatorioMensagem = "";
            this.txtRamal.PreValidacaoMensagem = "";
            this.txtRamal.PreValidado = false;
            this.txtRamal.SelectAllOnFocus = true;
            this.txtRamal.Size = new System.Drawing.Size(52, 21);
            this.txtRamal.TabIndex = 63;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.Honeydew;
            this.cboStatus.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.cboStatus.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cboStatus.Limpar = true;
            this.cboStatus.Location = new System.Drawing.Point(103, 208);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Obrigatorio = false;
            this.cboStatus.ObrigatorioMensagem = "Selecione o Status .";
            this.cboStatus.PreValidacaoMensagem = "Selecione o Status";
            this.cboStatus.PreValidado = false;
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 64;
            this.cboStatus.Text = "<Selecione>";
            // 
            // chkGravAtend
            // 
            this.chkGravAtend.AutoSize = true;
            this.chkGravAtend.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.chkGravAtend.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.chkGravAtend.Limpar = true;
            this.chkGravAtend.Location = new System.Drawing.Point(432, 53);
            this.chkGravAtend.Name = "chkGravAtend";
            this.chkGravAtend.Obrigatorio = false;
            this.chkGravAtend.ObrigatorioMensagem = null;
            this.chkGravAtend.PreValidacaoMensagem = null;
            this.chkGravAtend.PreValidado = false;
            this.chkGravAtend.Size = new System.Drawing.Size(126, 17);
            this.chkGravAtend.TabIndex = 65;
            this.chkGravAtend.Text = "Grava Atendimento ?";
            this.chkGravAtend.UseVisualStyleBackColor = true;
            // 
            // chkEstoqueProprio
            // 
            this.chkEstoqueProprio.AutoSize = true;
            this.chkEstoqueProprio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.chkEstoqueProprio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.chkEstoqueProprio.Limpar = true;
            this.chkEstoqueProprio.Location = new System.Drawing.Point(432, 84);
            this.chkEstoqueProprio.Name = "chkEstoqueProprio";
            this.chkEstoqueProprio.Obrigatorio = false;
            this.chkEstoqueProprio.ObrigatorioMensagem = null;
            this.chkEstoqueProprio.PreValidacaoMensagem = null;
            this.chkEstoqueProprio.PreValidado = false;
            this.chkEstoqueProprio.Size = new System.Drawing.Size(134, 17);
            this.chkEstoqueProprio.TabIndex = 66;
            this.chkEstoqueProprio.Text = "Tem Estoque Próprio ?";
            this.chkEstoqueProprio.UseVisualStyleBackColor = true;
            // 
            // chkPermiteInternacao
            // 
            this.chkPermiteInternacao.AutoSize = true;
            this.chkPermiteInternacao.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.chkPermiteInternacao.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.chkPermiteInternacao.Limpar = true;
            this.chkPermiteInternacao.Location = new System.Drawing.Point(432, 116);
            this.chkPermiteInternacao.Name = "chkPermiteInternacao";
            this.chkPermiteInternacao.Obrigatorio = false;
            this.chkPermiteInternacao.ObrigatorioMensagem = null;
            this.chkPermiteInternacao.PreValidacaoMensagem = null;
            this.chkPermiteInternacao.PreValidado = false;
            this.chkPermiteInternacao.Size = new System.Drawing.Size(124, 17);
            this.chkPermiteInternacao.TabIndex = 67;
            this.chkPermiteInternacao.Text = "Permite Internação ?";
            this.chkPermiteInternacao.UseVisualStyleBackColor = true;
            // 
            // chkPreferencialACS
            // 
            this.chkPreferencialACS.AutoSize = true;
            this.chkPreferencialACS.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.chkPreferencialACS.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.chkPreferencialACS.Limpar = true;
            this.chkPreferencialACS.Location = new System.Drawing.Point(432, 146);
            this.chkPreferencialACS.Name = "chkPreferencialACS";
            this.chkPreferencialACS.Obrigatorio = false;
            this.chkPreferencialACS.ObrigatorioMensagem = null;
            this.chkPreferencialACS.PreValidacaoMensagem = null;
            this.chkPreferencialACS.PreValidado = false;
            this.chkPreferencialACS.Size = new System.Drawing.Size(145, 17);
            this.chkPreferencialACS.TabIndex = 68;
            this.chkPreferencialACS.Text = "Preferencial Plano ACS ?";
            this.chkPreferencialACS.UseVisualStyleBackColor = true;
            // 
            // txtTelefone
            // 
            this.txtTelefone.AcceptedFormatMasked = Hac.Windows.Forms.Controls.AcceptedFormatMasked.Telefone;
            this.txtTelefone.BackColor = System.Drawing.Color.Honeydew;
            this.txtTelefone.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtTelefone.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtTelefone.Limpar = true;
            this.txtTelefone.Location = new System.Drawing.Point(103, 177);
            this.txtTelefone.Mask = "(00)0000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.NaoAjustarEdicao = false;
            this.txtTelefone.Obrigatorio = false;
            this.txtTelefone.ObrigatorioMensagem = "";
            this.txtTelefone.PreValidacaoMensagem = "";
            this.txtTelefone.PreValidado = false;
            this.txtTelefone.SelectAllOnFocus = false;
            this.txtTelefone.Size = new System.Drawing.Size(91, 20);
            this.txtTelefone.TabIndex = 69;
            // 
            // chkAtendAlmox
            // 
            this.chkAtendAlmox.AutoSize = true;
            this.chkAtendAlmox.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.chkAtendAlmox.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Desabilitado;
            this.chkAtendAlmox.Limpar = true;
            this.chkAtendAlmox.Location = new System.Drawing.Point(432, 177);
            this.chkAtendAlmox.Name = "chkAtendAlmox";
            this.chkAtendAlmox.Obrigatorio = false;
            this.chkAtendAlmox.ObrigatorioMensagem = null;
            this.chkAtendAlmox.PreValidacaoMensagem = null;
            this.chkAtendAlmox.PreValidado = false;
            this.chkAtendAlmox.Size = new System.Drawing.Size(160, 17);
            this.chkAtendAlmox.TabIndex = 70;
            this.chkAtendAlmox.Text = "Atende como almoxarifado ?";
            this.chkAtendAlmox.UseVisualStyleBackColor = true;
            // 
            // chkServMulher
            // 
            this.chkServMulher.AutoSize = true;
            this.chkServMulher.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.chkServMulher.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Desabilitado;
            this.chkServMulher.Limpar = true;
            this.chkServMulher.Location = new System.Drawing.Point(431, 208);
            this.chkServMulher.Name = "chkServMulher";
            this.chkServMulher.Obrigatorio = false;
            this.chkServMulher.ObrigatorioMensagem = null;
            this.chkServMulher.PreValidacaoMensagem = null;
            this.chkServMulher.PreValidado = false;
            this.chkServMulher.Size = new System.Drawing.Size(158, 17);
            this.chkServMulher.TabIndex = 71;
            this.chkServMulher.Text = "Atende Serviço da Mulher ?";
            this.chkServMulher.UseVisualStyleBackColor = true;
            // 
            // FrmCadastroSetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 541);
            this.Controls.Add(this.chkServMulher);
            this.Controls.Add(this.chkAtendAlmox);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.chkPreferencialACS);
            this.Controls.Add(this.chkPermiteInternacao);
            this.Controls.Add(this.chkEstoqueProprio);
            this.Controls.Add(this.chkGravAtend);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.txtRamal);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtAndar);
            this.Controls.Add(this.cboLocal);
            this.Controls.Add(this.cboUnidade);
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.grdSetor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.ModoTela = Hac.Windows.Forms.Controls.ModoEdicao.Edicao;
            this.Name = "FrmCadastroSetor";
            this.Text = "SGS - Sistema de Gestão Hospitalar ";
            this.Load += new System.EventHandler(this.FrmCadastroSetor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSetor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView grdSetor;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacCmbUnidade cboUnidade;
        private Hac.Windows.Forms.Controls.HacCmbLocal cboLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAcomodacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAD_SET_FL_ATIVO_OK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAD_SET_ID;
        private Hac.Windows.Forms.Controls.HacTextBox txtAndar;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigo;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricao;
        private Hac.Windows.Forms.Controls.HacTextBox txtRamal;
        private Hac.Windows.Forms.Controls.HacComboBox cboStatus;
        private Hac.Windows.Forms.Controls.HacCheckBox chkGravAtend;
        private Hac.Windows.Forms.Controls.HacCheckBox chkEstoqueProprio;
        private Hac.Windows.Forms.Controls.HacCheckBox chkPermiteInternacao;
        private Hac.Windows.Forms.Controls.HacCheckBox chkPreferencialACS;
        private Hac.Windows.Forms.Controls.HacMaskedTextBox txtTelefone;
        private Hac.Windows.Forms.Controls.HacCheckBox chkAtendAlmox;
        private Hac.Windows.Forms.Controls.HacCheckBox chkServMulher;
    }
}