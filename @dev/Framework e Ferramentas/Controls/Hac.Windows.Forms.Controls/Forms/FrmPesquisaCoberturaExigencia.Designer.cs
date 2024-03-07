namespace Hac.Windows.Forms.Controls
{
    partial class FrmPesquisaCoberturaExigencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaCoberturaExigencia));
            this.ctlPlano = new Hac.Windows.Forms.Controls.HacPlano();
            this.btnPesquisarPlano = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.ctlConvenio = new Hac.Windows.Forms.Controls.HacConvenio();
            this.btnPesquisarConvenio = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblPlano = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblConvenio = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbxLocalAtendimento = new System.Windows.Forms.GroupBox();
            this.grdLocalAtendimento = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colUnidadeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASS_CUL_DT_INI_VIGENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASS_CUL_DT_FIM_VIGENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxDocumentosExigidos = new System.Windows.Forms.GroupBox();
            this.grdDocumentosExigidos = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdTipoAcomodacao = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASS_CTP_DT_INI_VIGENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASS_CTP_DT_FIM_VIGENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbGeral = new System.Windows.Forms.GroupBox();
            this.gbxTipoAcomodacao = new System.Windows.Forms.GroupBox();
            this.txtOrientacao = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.gbxTipoAtendimento = new System.Windows.Forms.GroupBox();
            this.grdTipoAtendimento = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASS_PTA_DT_INI_VIGENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASS_PTA_DT_FIM_VIGENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodSeqBen = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodBen = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodEst = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblCredencial = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.ctlPlano.SuspendLayout();
            this.ctlConvenio.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbxLocalAtendimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocalAtendimento)).BeginInit();
            this.gbxDocumentosExigidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentosExigidos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoAcomodacao)).BeginInit();
            this.grbGeral.SuspendLayout();
            this.gbxTipoAcomodacao.SuspendLayout();
            this.gbxTipoAtendimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoAtendimento)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlPlano
            // 
            this.ctlPlano.AutoSize = true;
            this.ctlPlano.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlPlano.Controls.Add(this.btnPesquisarPlano);
            this.ctlPlano.Controls.Add(this.txtDescricaoPlano);
            this.ctlPlano.Controls.Add(this.txtCodigoPlano);
            this.ctlPlano.Enabled = false;
            this.ctlPlano.IdtConvenio = 0;
            this.ctlPlano.Limpar = true;
            this.ctlPlano.Location = new System.Drawing.Point(84, 56);
            this.ctlPlano.ModoConsulta = false;
            this.ctlPlano.Name = "ctlPlano";
            this.ctlPlano.NaoAjustarEdicao = true;
            this.ctlPlano.Obrigatorio = false;
            this.ctlPlano.ObrigatorioMensagem = null;
            this.ctlPlano.Size = new System.Drawing.Size(360, 24);
            this.ctlPlano.TabIndex = 4;
            this.ctlPlano.Pesquisar += new Hac.Windows.Forms.Controls.HacPlano.PesquisarDelegate(this.ctlPlano_Pesquisar);
            // 
            // btnPesquisarPlano
            // 
            this.btnPesquisarPlano.AlterarStatus = true;
            this.btnPesquisarPlano.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarPlano.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisarPlano.BackgroundImage")));
            this.btnPesquisarPlano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarPlano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarPlano.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarPlano.FlatAppearance.BorderSize = 0;
            this.btnPesquisarPlano.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarPlano.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarPlano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarPlano.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarPlano.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarPlano.Location = new System.Drawing.Point(336, 1);
            this.btnPesquisarPlano.Name = "btnPesquisarPlano";
            this.btnPesquisarPlano.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarPlano.TabIndex = 2;
            this.btnPesquisarPlano.UseVisualStyleBackColor = false;
            // 
            // txtDescricaoPlano
            // 
            this.txtDescricaoPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoPlano.Limpar = true;
            this.txtDescricaoPlano.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoPlano.Name = "txtDescricaoPlano";
            this.txtDescricaoPlano.NaoAjustarEdicao = true;
            this.txtDescricaoPlano.Obrigatorio = false;
            this.txtDescricaoPlano.ObrigatorioMensagem = null;
            this.txtDescricaoPlano.PreValidacaoMensagem = null;
            this.txtDescricaoPlano.PreValidado = false;
            this.txtDescricaoPlano.SelectAllOnFocus = false;
            this.txtDescricaoPlano.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoPlano.TabIndex = 1;
            // 
            // txtCodigoPlano
            // 
            this.txtCodigoPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPlano.Limpar = true;
            this.txtCodigoPlano.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoPlano.MaxLength = 5;
            this.txtCodigoPlano.Name = "txtCodigoPlano";
            this.txtCodigoPlano.NaoAjustarEdicao = true;
            this.txtCodigoPlano.Obrigatorio = false;
            this.txtCodigoPlano.ObrigatorioMensagem = null;
            this.txtCodigoPlano.PreValidacaoMensagem = null;
            this.txtCodigoPlano.PreValidado = false;
            this.txtCodigoPlano.SelectAllOnFocus = false;
            this.txtCodigoPlano.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoPlano.TabIndex = 0;
            // 
            // ctlConvenio
            // 
            this.ctlConvenio.AutoSize = true;
            this.ctlConvenio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlConvenio.Controls.Add(this.btnPesquisarConvenio);
            this.ctlConvenio.Controls.Add(this.txtDescricaoConvenio);
            this.ctlConvenio.Controls.Add(this.txtCodigoConvenio);
            this.ctlConvenio.Enabled = false;
            this.ctlConvenio.Limpar = true;
            this.ctlConvenio.Location = new System.Drawing.Point(84, 32);
            this.ctlConvenio.ModoConsulta = false;
            this.ctlConvenio.Name = "ctlConvenio";
            this.ctlConvenio.NaoAjustarEdicao = true;
            this.ctlConvenio.Obrigatorio = false;
            this.ctlConvenio.ObrigatorioMensagem = null;
            this.ctlConvenio.Size = new System.Drawing.Size(360, 24);
            this.ctlConvenio.TabIndex = 2;
            this.ctlConvenio.Pesquisar += new Hac.Windows.Forms.Controls.HacConvenio.PesquisarDelegate(this.ctlConvenio_Pesquisar);
            // 
            // btnPesquisarConvenio
            // 
            this.btnPesquisarConvenio.AlterarStatus = true;
            this.btnPesquisarConvenio.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarConvenio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisarConvenio.BackgroundImage")));
            this.btnPesquisarConvenio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarConvenio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarConvenio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarConvenio.FlatAppearance.BorderSize = 0;
            this.btnPesquisarConvenio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarConvenio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarConvenio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarConvenio.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarConvenio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarConvenio.Location = new System.Drawing.Point(336, 1);
            this.btnPesquisarConvenio.Name = "btnPesquisarConvenio";
            this.btnPesquisarConvenio.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarConvenio.TabIndex = 2;
            this.btnPesquisarConvenio.UseVisualStyleBackColor = false;
            // 
            // txtDescricaoConvenio
            // 
            this.txtDescricaoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoConvenio.Limpar = true;
            this.txtDescricaoConvenio.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoConvenio.Name = "txtDescricaoConvenio";
            this.txtDescricaoConvenio.NaoAjustarEdicao = true;
            this.txtDescricaoConvenio.Obrigatorio = false;
            this.txtDescricaoConvenio.ObrigatorioMensagem = null;
            this.txtDescricaoConvenio.PreValidacaoMensagem = null;
            this.txtDescricaoConvenio.PreValidado = false;
            this.txtDescricaoConvenio.SelectAllOnFocus = false;
            this.txtDescricaoConvenio.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoConvenio.TabIndex = 1;
            // 
            // txtCodigoConvenio
            // 
            this.txtCodigoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoConvenio.Limpar = true;
            this.txtCodigoConvenio.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoConvenio.MaxLength = 5;
            this.txtCodigoConvenio.Name = "txtCodigoConvenio";
            this.txtCodigoConvenio.NaoAjustarEdicao = true;
            this.txtCodigoConvenio.Obrigatorio = false;
            this.txtCodigoConvenio.ObrigatorioMensagem = null;
            this.txtCodigoConvenio.PreValidacaoMensagem = null;
            this.txtCodigoConvenio.PreValidado = false;
            this.txtCodigoConvenio.SelectAllOnFocus = false;
            this.txtCodigoConvenio.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoConvenio.TabIndex = 0;
            // 
            // lblPlano
            // 
            this.lblPlano.AutoSize = true;
            this.lblPlano.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlano.Location = new System.Drawing.Point(36, 62);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(47, 14);
            this.lblPlano.TabIndex = 3;
            this.lblPlano.Text = "Plano:";
            // 
            // lblConvenio
            // 
            this.lblConvenio.AutoSize = true;
            this.lblConvenio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenio.Location = new System.Drawing.Point(12, 38);
            this.lblConvenio.Name = "lblConvenio";
            this.lblConvenio.Size = new System.Drawing.Size(71, 14);
            this.lblConvenio.TabIndex = 1;
            this.lblConvenio.Text = "Convênio:";
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(984, 28);
            this.tspCommand.TabIndex = 0;
            this.tspCommand.Text = "hacToolStrip1";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            this.tspCommand.BeforePesquisar += new Hac.Windows.Forms.Controls.AfterBeforeHacEventHandler(this.tspCommand_BeforePesquisar);
            this.tspCommand.LimparClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_LimparClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gbxLocalAtendimento);
            this.groupBox3.Controls.Add(this.gbxDocumentosExigidos);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(5, 293);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(972, 377);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "INFORMAÇÕES POR UNIDADE/LOCAL";
            // 
            // gbxLocalAtendimento
            // 
            this.gbxLocalAtendimento.Controls.Add(this.grdLocalAtendimento);
            this.gbxLocalAtendimento.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxLocalAtendimento.Location = new System.Drawing.Point(8, 18);
            this.gbxLocalAtendimento.Name = "gbxLocalAtendimento";
            this.gbxLocalAtendimento.Size = new System.Drawing.Size(562, 174);
            this.gbxLocalAtendimento.TabIndex = 0;
            this.gbxLocalAtendimento.TabStop = false;
            this.gbxLocalAtendimento.Text = "Selecione a Unidade/Local de Atendimento para mostrar os dados das tabelas abaixo" +
    "";
            // 
            // grdLocalAtendimento
            // 
            this.grdLocalAtendimento.AllowUserToAddRows = false;
            this.grdLocalAtendimento.AllowUserToDeleteRows = false;
            this.grdLocalAtendimento.AllowUserToOrderColumns = true;
            this.grdLocalAtendimento.AllowUserToResizeRows = false;
            this.grdLocalAtendimento.AlterarStatus = false;
            this.grdLocalAtendimento.BackgroundColor = System.Drawing.Color.White;
            this.grdLocalAtendimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLocalAtendimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUnidadeId,
            this.colLocalId,
            this.colUnidade,
            this.LocalAtendimento,
            this.ASS_CUL_DT_INI_VIGENCIA,
            this.ASS_CUL_DT_FIM_VIGENCIA});
            this.grdLocalAtendimento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.grdLocalAtendimento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLocalAtendimento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdLocalAtendimento.GridPesquisa = false;
            this.grdLocalAtendimento.Limpar = true;
            this.grdLocalAtendimento.Location = new System.Drawing.Point(10, 21);
            this.grdLocalAtendimento.MultiSelect = false;
            this.grdLocalAtendimento.Name = "grdLocalAtendimento";
            this.grdLocalAtendimento.NaoAjustarEdicao = true;
            this.grdLocalAtendimento.Obrigatorio = false;
            this.grdLocalAtendimento.ObrigatorioMensagem = null;
            this.grdLocalAtendimento.PreValidacaoMensagem = null;
            this.grdLocalAtendimento.PreValidado = false;
            this.grdLocalAtendimento.ReadOnly = true;
            this.grdLocalAtendimento.RowHeadersVisible = false;
            this.grdLocalAtendimento.RowHeadersWidth = 25;
            this.grdLocalAtendimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLocalAtendimento.Size = new System.Drawing.Size(542, 144);
            this.grdLocalAtendimento.TabIndex = 0;
            
            this.grdLocalAtendimento.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdLocalAtendimento_DataBindingComplete);
            this.grdLocalAtendimento.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLocalAtendimento_RowEnter);
            // 
            // colUnidadeId
            // 
            this.colUnidadeId.DataPropertyName = "CAD_UNI_ID_UNIDADE";
            this.colUnidadeId.HeaderText = "colUnidadeId";
            this.colUnidadeId.Name = "colUnidadeId";
            this.colUnidadeId.ReadOnly = true;
            this.colUnidadeId.Visible = false;
            this.colUnidadeId.Width = 48;
            // 
            // colLocalId
            // 
            this.colLocalId.DataPropertyName = "CAD_LAT_ID_LOCAL_ATENDIMENTO";
            this.colLocalId.HeaderText = "colLocalId";
            this.colLocalId.Name = "colLocalId";
            this.colLocalId.ReadOnly = true;
            this.colLocalId.Visible = false;
            // 
            // colUnidade
            // 
            this.colUnidade.DataPropertyName = "CAD_UNI_DS_UNIDADE";
            this.colUnidade.HeaderText = "Unidade";
            this.colUnidade.Name = "colUnidade";
            this.colUnidade.ReadOnly = true;
            this.colUnidade.Width = 180;
            // 
            // LocalAtendimento
            // 
            this.LocalAtendimento.DataPropertyName = "CAD_LAT_DS_LOCAL_ATENDIMENTO";
            this.LocalAtendimento.HeaderText = "Local de Atendimento";
            this.LocalAtendimento.Name = "LocalAtendimento";
            this.LocalAtendimento.ReadOnly = true;
            this.LocalAtendimento.Width = 190;
            // 
            // ASS_CUL_DT_INI_VIGENCIA
            // 
            this.ASS_CUL_DT_INI_VIGENCIA.DataPropertyName = "ASS_CLP_DT_INI_VIGENCIA";
            this.ASS_CUL_DT_INI_VIGENCIA.HeaderText = "Início Vigência";
            this.ASS_CUL_DT_INI_VIGENCIA.Name = "ASS_CUL_DT_INI_VIGENCIA";
            this.ASS_CUL_DT_INI_VIGENCIA.ReadOnly = true;
            this.ASS_CUL_DT_INI_VIGENCIA.Width = 82;
            // 
            // ASS_CUL_DT_FIM_VIGENCIA
            // 
            this.ASS_CUL_DT_FIM_VIGENCIA.DataPropertyName = "ASS_CLP_DT_FIM_VIGENCIA";
            this.ASS_CUL_DT_FIM_VIGENCIA.HeaderText = "Fim Vigência";
            this.ASS_CUL_DT_FIM_VIGENCIA.Name = "ASS_CUL_DT_FIM_VIGENCIA";
            this.ASS_CUL_DT_FIM_VIGENCIA.ReadOnly = true;
            this.ASS_CUL_DT_FIM_VIGENCIA.Width = 82;
            // 
            // gbxDocumentosExigidos
            // 
            this.gbxDocumentosExigidos.Controls.Add(this.grdDocumentosExigidos);
            this.gbxDocumentosExigidos.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDocumentosExigidos.Location = new System.Drawing.Point(575, 195);
            this.gbxDocumentosExigidos.Name = "gbxDocumentosExigidos";
            this.gbxDocumentosExigidos.Size = new System.Drawing.Size(390, 174);
            this.gbxDocumentosExigidos.TabIndex = 2;
            this.gbxDocumentosExigidos.TabStop = false;
            this.gbxDocumentosExigidos.Text = "Documentos Exigidos do Plano";
            // 
            // grdDocumentosExigidos
            // 
            this.grdDocumentosExigidos.AllowUserToAddRows = false;
            this.grdDocumentosExigidos.AllowUserToDeleteRows = false;
            this.grdDocumentosExigidos.AllowUserToOrderColumns = true;
            this.grdDocumentosExigidos.AllowUserToResizeRows = false;
            this.grdDocumentosExigidos.AlterarStatus = false;
            this.grdDocumentosExigidos.BackgroundColor = System.Drawing.Color.White;
            this.grdDocumentosExigidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumentosExigidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.grdDocumentosExigidos.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.grdDocumentosExigidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdDocumentosExigidos.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdDocumentosExigidos.GridPesquisa = false;
            this.grdDocumentosExigidos.Limpar = true;
            this.grdDocumentosExigidos.Location = new System.Drawing.Point(10, 21);
            this.grdDocumentosExigidos.MultiSelect = false;
            this.grdDocumentosExigidos.Name = "grdDocumentosExigidos";
            this.grdDocumentosExigidos.NaoAjustarEdicao = true;
            this.grdDocumentosExigidos.Obrigatorio = false;
            this.grdDocumentosExigidos.ObrigatorioMensagem = null;
            this.grdDocumentosExigidos.PreValidacaoMensagem = null;
            this.grdDocumentosExigidos.PreValidado = false;
            this.grdDocumentosExigidos.ReadOnly = true;
            this.grdDocumentosExigidos.RowHeadersVisible = false;
            this.grdDocumentosExigidos.RowHeadersWidth = 25;
            this.grdDocumentosExigidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDocumentosExigidos.Size = new System.Drawing.Size(370, 144);
            this.grdDocumentosExigidos.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CAD_LAT_DS_LOCAL_ATENDIMENTO";
            this.dataGridViewTextBoxColumn7.HeaderText = "Local de Atendimento";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CAD_DOC_DS_DOCUMENTO";
            this.dataGridViewTextBoxColumn8.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 365;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdTipoAcomodacao);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F);
            this.groupBox1.Location = new System.Drawing.Point(8, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Acomodação do Plano";
            // 
            // grdTipoAcomodacao
            // 
            this.grdTipoAcomodacao.AllowUserToAddRows = false;
            this.grdTipoAcomodacao.AllowUserToDeleteRows = false;
            this.grdTipoAcomodacao.AllowUserToOrderColumns = true;
            this.grdTipoAcomodacao.AllowUserToResizeRows = false;
            this.grdTipoAcomodacao.AlterarStatus = false;
            this.grdTipoAcomodacao.BackgroundColor = System.Drawing.Color.White;
            this.grdTipoAcomodacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTipoAcomodacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.ASS_CTP_DT_INI_VIGENCIA,
            this.ASS_CTP_DT_FIM_VIGENCIA});
            this.grdTipoAcomodacao.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.grdTipoAcomodacao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdTipoAcomodacao.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdTipoAcomodacao.GridPesquisa = false;
            this.grdTipoAcomodacao.Limpar = true;
            this.grdTipoAcomodacao.Location = new System.Drawing.Point(10, 21);
            this.grdTipoAcomodacao.MultiSelect = false;
            this.grdTipoAcomodacao.Name = "grdTipoAcomodacao";
            this.grdTipoAcomodacao.NaoAjustarEdicao = true;
            this.grdTipoAcomodacao.Obrigatorio = false;
            this.grdTipoAcomodacao.ObrigatorioMensagem = null;
            this.grdTipoAcomodacao.PreValidacaoMensagem = null;
            this.grdTipoAcomodacao.PreValidado = false;
            this.grdTipoAcomodacao.ReadOnly = true;
            this.grdTipoAcomodacao.RowHeadersVisible = false;
            this.grdTipoAcomodacao.RowHeadersWidth = 25;
            this.grdTipoAcomodacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTipoAcomodacao.Size = new System.Drawing.Size(542, 144);
            this.grdTipoAcomodacao.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TIS_TAC_DS_TIPO_ACOMODACAO";
            this.dataGridViewTextBoxColumn9.HeaderText = "Tipo Acomodação";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 370;
            // 
            // ASS_CTP_DT_INI_VIGENCIA
            // 
            this.ASS_CTP_DT_INI_VIGENCIA.DataPropertyName = "ASS_CTP_DT_INI_VIGENCIA";
            this.ASS_CTP_DT_INI_VIGENCIA.HeaderText = "Início Vigência";
            this.ASS_CTP_DT_INI_VIGENCIA.Name = "ASS_CTP_DT_INI_VIGENCIA";
            this.ASS_CTP_DT_INI_VIGENCIA.ReadOnly = true;
            this.ASS_CTP_DT_INI_VIGENCIA.Width = 82;
            // 
            // ASS_CTP_DT_FIM_VIGENCIA
            // 
            this.ASS_CTP_DT_FIM_VIGENCIA.DataPropertyName = "ASS_CTP_DT_FIM_VIGENCIA";
            this.ASS_CTP_DT_FIM_VIGENCIA.HeaderText = "Fim Vigência";
            this.ASS_CTP_DT_FIM_VIGENCIA.Name = "ASS_CTP_DT_FIM_VIGENCIA";
            this.ASS_CTP_DT_FIM_VIGENCIA.ReadOnly = true;
            this.ASS_CTP_DT_FIM_VIGENCIA.Width = 82;
            // 
            // grbGeral
            // 
            this.grbGeral.Controls.Add(this.gbxTipoAcomodacao);
            this.grbGeral.Controls.Add(this.gbxTipoAtendimento);
            this.grbGeral.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.grbGeral.Location = new System.Drawing.Point(5, 87);
            this.grbGeral.Name = "grbGeral";
            this.grbGeral.Size = new System.Drawing.Size(972, 201);
            this.grbGeral.TabIndex = 9;
            this.grbGeral.TabStop = false;
            this.grbGeral.Text = "GERAL";
            // 
            // gbxTipoAcomodacao
            // 
            this.gbxTipoAcomodacao.Controls.Add(this.txtOrientacao);
            this.gbxTipoAcomodacao.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxTipoAcomodacao.Location = new System.Drawing.Point(575, 18);
            this.gbxTipoAcomodacao.Name = "gbxTipoAcomodacao";
            this.gbxTipoAcomodacao.Size = new System.Drawing.Size(390, 105);
            this.gbxTipoAcomodacao.TabIndex = 1;
            this.gbxTipoAcomodacao.TabStop = false;
            this.gbxTipoAcomodacao.Text = "Orientações do Plano";
            // 
            // txtOrientacao
            // 
            this.txtOrientacao.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtOrientacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtOrientacao.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtOrientacao.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtOrientacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtOrientacao.Limpar = true;
            this.txtOrientacao.Location = new System.Drawing.Point(10, 21);
            this.txtOrientacao.Multiline = true;
            this.txtOrientacao.Name = "txtOrientacao";
            this.txtOrientacao.NaoAjustarEdicao = true;
            this.txtOrientacao.Obrigatorio = false;
            this.txtOrientacao.ObrigatorioMensagem = "";
            this.txtOrientacao.PreValidacaoMensagem = "";
            this.txtOrientacao.PreValidado = false;
            this.txtOrientacao.ReadOnly = true;
            this.txtOrientacao.SelectAllOnFocus = false;
            this.txtOrientacao.Size = new System.Drawing.Size(370, 76);
            this.txtOrientacao.TabIndex = 0;
            // 
            // gbxTipoAtendimento
            // 
            this.gbxTipoAtendimento.Controls.Add(this.grdTipoAtendimento);
            this.gbxTipoAtendimento.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxTipoAtendimento.Location = new System.Drawing.Point(8, 18);
            this.gbxTipoAtendimento.Name = "gbxTipoAtendimento";
            this.gbxTipoAtendimento.Size = new System.Drawing.Size(562, 174);
            this.gbxTipoAtendimento.TabIndex = 0;
            this.gbxTipoAtendimento.TabStop = false;
            this.gbxTipoAtendimento.Text = "Tipos de Atendimento do Plano";
            // 
            // grdTipoAtendimento
            // 
            this.grdTipoAtendimento.AllowUserToAddRows = false;
            this.grdTipoAtendimento.AllowUserToDeleteRows = false;
            this.grdTipoAtendimento.AllowUserToOrderColumns = true;
            this.grdTipoAtendimento.AllowUserToResizeRows = false;
            this.grdTipoAtendimento.AlterarStatus = false;
            this.grdTipoAtendimento.BackgroundColor = System.Drawing.Color.White;
            this.grdTipoAtendimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTipoAtendimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.ASS_PTA_DT_INI_VIGENCIA,
            this.ASS_PTA_DT_FIM_VIGENCIA});
            this.grdTipoAtendimento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.grdTipoAtendimento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdTipoAtendimento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdTipoAtendimento.GridPesquisa = false;
            this.grdTipoAtendimento.Limpar = true;
            this.grdTipoAtendimento.Location = new System.Drawing.Point(10, 21);
            this.grdTipoAtendimento.MultiSelect = false;
            this.grdTipoAtendimento.Name = "grdTipoAtendimento";
            this.grdTipoAtendimento.NaoAjustarEdicao = true;
            this.grdTipoAtendimento.Obrigatorio = false;
            this.grdTipoAtendimento.ObrigatorioMensagem = null;
            this.grdTipoAtendimento.PreValidacaoMensagem = null;
            this.grdTipoAtendimento.PreValidado = false;
            this.grdTipoAtendimento.ReadOnly = true;
            this.grdTipoAtendimento.RowHeadersVisible = false;
            this.grdTipoAtendimento.RowHeadersWidth = 25;
            this.grdTipoAtendimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTipoAtendimento.Size = new System.Drawing.Size(542, 144);
            this.grdTipoAtendimento.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TIS_TAT_DS_TPATENDIMENTO";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tipo de Atendimento";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 370;
            // 
            // ASS_PTA_DT_INI_VIGENCIA
            // 
            this.ASS_PTA_DT_INI_VIGENCIA.DataPropertyName = "ASS_PTA_DT_INI_VIGENCIA";
            this.ASS_PTA_DT_INI_VIGENCIA.HeaderText = "Início Vigência";
            this.ASS_PTA_DT_INI_VIGENCIA.Name = "ASS_PTA_DT_INI_VIGENCIA";
            this.ASS_PTA_DT_INI_VIGENCIA.ReadOnly = true;
            this.ASS_PTA_DT_INI_VIGENCIA.Width = 82;
            // 
            // ASS_PTA_DT_FIM_VIGENCIA
            // 
            this.ASS_PTA_DT_FIM_VIGENCIA.DataPropertyName = "ASS_PTA_DT_FIM_VIGENCIA";
            this.ASS_PTA_DT_FIM_VIGENCIA.HeaderText = "Fim Vigência";
            this.ASS_PTA_DT_FIM_VIGENCIA.Name = "ASS_PTA_DT_FIM_VIGENCIA";
            this.ASS_PTA_DT_FIM_VIGENCIA.ReadOnly = true;
            this.ASS_PTA_DT_FIM_VIGENCIA.Width = 82;
            // 
            // txtCodSeqBen
            // 
            this.txtCodSeqBen.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodSeqBen.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodSeqBen.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtCodSeqBen.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodSeqBen.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtCodSeqBen.Limpar = false;
            this.txtCodSeqBen.Location = new System.Drawing.Point(652, 59);
            this.txtCodSeqBen.MaxLength = 2;
            this.txtCodSeqBen.Name = "txtCodSeqBen";
            this.txtCodSeqBen.NaoAjustarEdicao = false;
            this.txtCodSeqBen.Obrigatorio = false;
            this.txtCodSeqBen.ObrigatorioMensagem = "";
            this.txtCodSeqBen.PreValidacaoMensagem = "";
            this.txtCodSeqBen.PreValidado = false;
            this.txtCodSeqBen.SelectAllOnFocus = false;
            this.txtCodSeqBen.Size = new System.Drawing.Size(22, 18);
            this.txtCodSeqBen.TabIndex = 8;
            this.txtCodSeqBen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodSeqBen_KeyPress);
            // 
            // txtCodBen
            // 
            this.txtCodBen.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodBen.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodBen.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtCodBen.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodBen.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtCodBen.Limpar = false;
            this.txtCodBen.Location = new System.Drawing.Point(579, 59);
            this.txtCodBen.MaxLength = 7;
            this.txtCodBen.Name = "txtCodBen";
            this.txtCodBen.NaoAjustarEdicao = false;
            this.txtCodBen.Obrigatorio = false;
            this.txtCodBen.ObrigatorioMensagem = "";
            this.txtCodBen.PreValidacaoMensagem = "";
            this.txtCodBen.PreValidado = false;
            this.txtCodBen.SelectAllOnFocus = false;
            this.txtCodBen.Size = new System.Drawing.Size(72, 18);
            this.txtCodBen.TabIndex = 7;
            this.txtCodBen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodBen_KeyPress);
            // 
            // txtCodEst
            // 
            this.txtCodEst.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodEst.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodEst.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtCodEst.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodEst.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.txtCodEst.Limpar = false;
            this.txtCodEst.Location = new System.Drawing.Point(551, 59);
            this.txtCodEst.MaxLength = 3;
            this.txtCodEst.Name = "txtCodEst";
            this.txtCodEst.NaoAjustarEdicao = false;
            this.txtCodEst.Obrigatorio = false;
            this.txtCodEst.ObrigatorioMensagem = "";
            this.txtCodEst.PreValidacaoMensagem = "";
            this.txtCodEst.PreValidado = false;
            this.txtCodEst.SelectAllOnFocus = false;
            this.txtCodEst.Size = new System.Drawing.Size(27, 18);
            this.txtCodEst.TabIndex = 6;
            this.txtCodEst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodEst_KeyPress);
            // 
            // lblCredencial
            // 
            this.lblCredencial.AutoSize = true;
            this.lblCredencial.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredencial.Location = new System.Drawing.Point(466, 62);
            this.lblCredencial.Name = "lblCredencial";
            this.lblCredencial.Size = new System.Drawing.Size(78, 14);
            this.lblCredencial.TabIndex = 5;
            this.lblCredencial.Text = "Credencial:";
            // 
            // FrmPesquisaCoberturaExigencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 678);
            this.ControlBox = false;
            this.Controls.Add(this.txtCodSeqBen);
            this.Controls.Add(this.txtCodBen);
            this.Controls.Add(this.txtCodEst);
            this.Controls.Add(this.lblCredencial);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grbGeral);
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.ctlPlano);
            this.Controls.Add(this.ctlConvenio);
            this.Controls.Add(this.lblConvenio);
            this.Controls.Add(this.lblPlano);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaCoberturaExigencia";
            this.ShowInTaskbar = false;
            this.Text = "SGS - Sistema de Gestão de Saúde";
            this.ctlPlano.ResumeLayout(false);
            this.ctlPlano.PerformLayout();
            this.ctlConvenio.ResumeLayout(false);
            this.ctlConvenio.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gbxLocalAtendimento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLocalAtendimento)).EndInit();
            this.gbxDocumentosExigidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentosExigidos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoAcomodacao)).EndInit();
            this.grbGeral.ResumeLayout(false);
            this.gbxTipoAcomodacao.ResumeLayout(false);
            this.gbxTipoAcomodacao.PerformLayout();
            this.gbxTipoAtendimento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoAtendimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacPlano ctlPlano;
        private Hac.Windows.Forms.Controls.HacButton btnPesquisarPlano;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoPlano;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoPlano;
        private Hac.Windows.Forms.Controls.HacConvenio ctlConvenio;
        private Hac.Windows.Forms.Controls.HacButton btnPesquisarConvenio;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoConvenio;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoConvenio;
        private Hac.Windows.Forms.Controls.HacLabel lblPlano;
        private Hac.Windows.Forms.Controls.HacLabel lblConvenio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbxLocalAtendimento;
        private HacDataGridView grdLocalAtendimento;
        private System.Windows.Forms.GroupBox gbxDocumentosExigidos;
        private HacDataGridView grdDocumentosExigidos;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacDataGridView grdTipoAcomodacao;
        private System.Windows.Forms.GroupBox grbGeral;
        private System.Windows.Forms.GroupBox gbxTipoAcomodacao;
        private HacTextBox txtOrientacao;
        private System.Windows.Forms.GroupBox gbxTipoAtendimento;
        private HacDataGridView grdTipoAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private HacTextBox txtCodSeqBen;
        private HacTextBox txtCodBen;
        private HacTextBox txtCodEst;
        private HacLabel lblCredencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASS_CTP_DT_INI_VIGENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASS_CTP_DT_FIM_VIGENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASS_PTA_DT_INI_VIGENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASS_PTA_DT_FIM_VIGENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASS_CUL_DT_INI_VIGENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ASS_CUL_DT_FIM_VIGENCIA;
    }
}