namespace Hac.Windows.Forms.Controls
{
    partial class FrmPesquisaCarencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaCarencia));
            this.lblPlano = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblConvenio = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblCredencial = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.gbxPesquisa = new System.Windows.Forms.GroupBox();
            this.txtCodSeqBen = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCredencialHac = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodSeq = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.ctlConvenio = new Hac.Windows.Forms.Controls.HacConvenio();
            this.ctlPlano = new Hac.Windows.Forms.Controls.HacPlano();
            this.gbxCarencia = new System.Windows.Forms.GroupBox();
            this.grdCarencia = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colServico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataFimCarencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxCPT = new System.Windows.Forms.GroupBox();
            this.grdCPT = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.dgvCPTCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCPTDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCPTDataTermino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxPesquisa.SuspendLayout();
            this.gbxCarencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCarencia)).BeginInit();
            this.gbxCPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCPT)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlano
            // 
            this.lblPlano.AutoSize = true;
            this.lblPlano.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlano.Location = new System.Drawing.Point(453, 21);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(47, 14);
            this.lblPlano.TabIndex = 32;
            this.lblPlano.Text = "Plano:";
            // 
            // lblConvenio
            // 
            this.lblConvenio.AutoSize = true;
            this.lblConvenio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenio.Location = new System.Drawing.Point(7, 21);
            this.lblConvenio.Name = "lblConvenio";
            this.lblConvenio.Size = new System.Drawing.Size(71, 14);
            this.lblConvenio.TabIndex = 26;
            this.lblConvenio.Text = "Convênio:";
            // 
            // lblCredencial
            // 
            this.lblCredencial.AutoSize = true;
            this.lblCredencial.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredencial.Location = new System.Drawing.Point(7, 45);
            this.lblCredencial.Name = "lblCredencial";
            this.lblCredencial.Size = new System.Drawing.Size(78, 14);
            this.lblCredencial.TabIndex = 38;
            this.lblCredencial.Text = "Credencial:";
            // 
            // gbxPesquisa
            // 
            this.gbxPesquisa.Controls.Add(this.txtCodSeqBen);
            this.gbxPesquisa.Controls.Add(this.txtCredencialHac);
            this.gbxPesquisa.Controls.Add(this.txtCodSeq);
            this.gbxPesquisa.Controls.Add(this.ctlConvenio);
            this.gbxPesquisa.Controls.Add(this.ctlPlano);
            this.gbxPesquisa.Controls.Add(this.lblCredencial);
            this.gbxPesquisa.Controls.Add(this.lblConvenio);
            this.gbxPesquisa.Controls.Add(this.lblPlano);
            this.gbxPesquisa.Font = new System.Drawing.Font("Verdana", 9F);
            this.gbxPesquisa.Location = new System.Drawing.Point(6, 34);
            this.gbxPesquisa.Name = "gbxPesquisa";
            this.gbxPesquisa.Size = new System.Drawing.Size(867, 74);
            this.gbxPesquisa.TabIndex = 40;
            this.gbxPesquisa.TabStop = false;
            this.gbxPesquisa.Text = "Pesquisa Por:";
            // 
            // txtCodSeqBen
            // 
            this.txtCodSeqBen.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCodSeqBen.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodSeqBen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodSeqBen.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodSeqBen.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodSeqBen.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodSeqBen.Limpar = true;
            this.txtCodSeqBen.Location = new System.Drawing.Point(234, 41);
            this.txtCodSeqBen.MaxLength = 3;
            this.txtCodSeqBen.Name = "txtCodSeqBen";
            this.txtCodSeqBen.NaoAjustarEdicao = true;
            this.txtCodSeqBen.Obrigatorio = true;
            this.txtCodSeqBen.ObrigatorioMensagem = "Credencial Obrigatória";
            this.txtCodSeqBen.PreValidacaoMensagem = null;
            this.txtCodSeqBen.PreValidado = false;
            this.txtCodSeqBen.SelectAllOnFocus = true;
            this.txtCodSeqBen.Size = new System.Drawing.Size(26, 18);
            this.txtCodSeqBen.TabIndex = 44;
            // 
            // txtCredencialHac
            // 
            this.txtCredencialHac.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCredencialHac.BackColor = System.Drawing.Color.Honeydew;
            this.txtCredencialHac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCredencialHac.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCredencialHac.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCredencialHac.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredencialHac.Limpar = true;
            this.txtCredencialHac.Location = new System.Drawing.Point(125, 41);
            this.txtCredencialHac.MaxLength = 11;
            this.txtCredencialHac.Name = "txtCredencialHac";
            this.txtCredencialHac.NaoAjustarEdicao = true;
            this.txtCredencialHac.Obrigatorio = true;
            this.txtCredencialHac.ObrigatorioMensagem = "Credencial Obrigatória";
            this.txtCredencialHac.PreValidacaoMensagem = null;
            this.txtCredencialHac.PreValidado = false;
            this.txtCredencialHac.SelectAllOnFocus = true;
            this.txtCredencialHac.Size = new System.Drawing.Size(105, 18);
            this.txtCredencialHac.TabIndex = 43;
            this.txtCredencialHac.Leave += new System.EventHandler(this.txtCredencialHac_Leave);
            // 
            // txtCodSeq
            // 
            this.txtCodSeq.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCodSeq.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodSeq.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodSeq.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodSeq.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodSeq.Limpar = true;
            this.txtCodSeq.Location = new System.Drawing.Point(89, 41);
            this.txtCodSeq.MaxLength = 3;
            this.txtCodSeq.Name = "txtCodSeq";
            this.txtCodSeq.NaoAjustarEdicao = true;
            this.txtCodSeq.Obrigatorio = true;
            this.txtCodSeq.ObrigatorioMensagem = "Credencial Obrigatória";
            this.txtCodSeq.PreValidacaoMensagem = null;
            this.txtCodSeq.PreValidado = false;
            this.txtCodSeq.SelectAllOnFocus = true;
            this.txtCodSeq.Size = new System.Drawing.Size(32, 18);
            this.txtCodSeq.TabIndex = 42;
            // 
            // ctlConvenio
            // 
            this.ctlConvenio.AutoSize = true;
            this.ctlConvenio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlConvenio.Enabled = false;
            this.ctlConvenio.Limpar = true;
            this.ctlConvenio.Location = new System.Drawing.Point(89, 14);
            this.ctlConvenio.ModoConsulta = false;
            this.ctlConvenio.Name = "ctlConvenio";
            this.ctlConvenio.NaoAjustarEdicao = true;
            this.ctlConvenio.Obrigatorio = false;
            this.ctlConvenio.ObrigatorioMensagem = null;
            this.ctlConvenio.Size = new System.Drawing.Size(360, 24);
            this.ctlConvenio.TabIndex = 41;
            this.ctlConvenio.Pesquisar += new Hac.Windows.Forms.Controls.HacConvenio.PesquisarDelegate(this.ctlConvenio_Pesquisar);
            // 
            // ctlPlano
            // 
            this.ctlPlano.AutoSize = true;
            this.ctlPlano.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlPlano.Enabled = false;
            this.ctlPlano.IdtConvenio = 0;
            this.ctlPlano.Limpar = true;
            this.ctlPlano.Location = new System.Drawing.Point(502, 14);
            this.ctlPlano.ModoConsulta = false;
            this.ctlPlano.Name = "ctlPlano";
            this.ctlPlano.NaoAjustarEdicao = true;
            this.ctlPlano.Obrigatorio = false;
            this.ctlPlano.ObrigatorioMensagem = null;
            this.ctlPlano.Size = new System.Drawing.Size(360, 24);
            this.ctlPlano.TabIndex = 40;
            this.ctlPlano.Leave += new System.EventHandler(this.ctlPlano_Leave);
            // 
            // gbxCarencia
            // 
            this.gbxCarencia.Controls.Add(this.grdCarencia);
            this.gbxCarencia.Font = new System.Drawing.Font("Verdana", 9F);
            this.gbxCarencia.Location = new System.Drawing.Point(7, 113);
            this.gbxCarencia.Name = "gbxCarencia";
            this.gbxCarencia.Size = new System.Drawing.Size(865, 148);
            this.gbxCarencia.TabIndex = 41;
            this.gbxCarencia.TabStop = false;
            this.gbxCarencia.Text = "Serviço";
            // 
            // grdCarencia
            // 
            this.grdCarencia.AllowUserToAddRows = false;
            this.grdCarencia.AllowUserToDeleteRows = false;
            this.grdCarencia.AlterarStatus = false;
            this.grdCarencia.BackgroundColor = System.Drawing.Color.White;
            this.grdCarencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCarencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServico,
            this.colDescricao,
            this.colDataFimCarencia});
            this.grdCarencia.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.grdCarencia.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdCarencia.GridPesquisa = false;
            this.grdCarencia.Limpar = true;
            this.grdCarencia.Location = new System.Drawing.Point(10, 20);
            this.grdCarencia.Name = "grdCarencia";
            this.grdCarencia.NaoAjustarEdicao = false;
            this.grdCarencia.Obrigatorio = false;
            this.grdCarencia.ObrigatorioMensagem = null;
            this.grdCarencia.PreValidacaoMensagem = null;
            this.grdCarencia.PreValidado = false;
            this.grdCarencia.ReadOnly = true;
            this.grdCarencia.RowHeadersWidth = 25;
            this.grdCarencia.Size = new System.Drawing.Size(845, 119);
            this.grdCarencia.TabIndex = 0;
            // 
            // colServico
            // 
            this.colServico.DataPropertyName = "CODSER";
            this.colServico.HeaderText = "Serviço";
            this.colServico.Name = "colServico";
            this.colServico.ReadOnly = true;
            this.colServico.Width = 150;
            // 
            // colDescricao
            // 
            this.colDescricao.DataPropertyName = "NOMSER";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 480;
            // 
            // colDataFimCarencia
            // 
            this.colDataFimCarencia.DataPropertyName = "DATFIMCAR";
            this.colDataFimCarencia.HeaderText = "Data Fim Carência";
            this.colDataFimCarencia.Name = "colDataFimCarencia";
            this.colDataFimCarencia.ReadOnly = true;
            this.colDataFimCarencia.Width = 150;
            // 
            // gbxCPT
            // 
            this.gbxCPT.Controls.Add(this.grdCPT);
            this.gbxCPT.Font = new System.Drawing.Font("Verdana", 9F);
            this.gbxCPT.Location = new System.Drawing.Point(8, 266);
            this.gbxCPT.Name = "gbxCPT";
            this.gbxCPT.Size = new System.Drawing.Size(864, 148);
            this.gbxCPT.TabIndex = 42;
            this.gbxCPT.TabStop = false;
            this.gbxCPT.Text = "Cobertura Partial Temporária (CPT)";
            // 
            // grdCPT
            // 
            this.grdCPT.AllowUserToAddRows = false;
            this.grdCPT.AllowUserToDeleteRows = false;
            this.grdCPT.AlterarStatus = false;
            this.grdCPT.BackgroundColor = System.Drawing.Color.White;
            this.grdCPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCPT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCPTCodigo,
            this.dgvCPTDescricao,
            this.dgvCPTDataTermino});
            this.grdCPT.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.grdCPT.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdCPT.GridPesquisa = false;
            this.grdCPT.Limpar = true;
            this.grdCPT.Location = new System.Drawing.Point(11, 19);
            this.grdCPT.Name = "grdCPT";
            this.grdCPT.NaoAjustarEdicao = false;
            this.grdCPT.Obrigatorio = false;
            this.grdCPT.ObrigatorioMensagem = null;
            this.grdCPT.PreValidacaoMensagem = null;
            this.grdCPT.PreValidado = false;
            this.grdCPT.ReadOnly = true;
            this.grdCPT.RowHeadersWidth = 25;
            this.grdCPT.Size = new System.Drawing.Size(845, 119);
            this.grdCPT.TabIndex = 0;
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(880, 28);
            this.tspCommand.TabIndex = 43;
            this.tspCommand.Text = "hacToolStrip1";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            this.tspCommand.BeforePesquisar += new Hac.Windows.Forms.Controls.AfterBeforeHacEventHandler(this.tspCommand_BeforePesquisar);
            this.tspCommand.PesquisarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_PesquisarClick);
            this.tspCommand.LimparClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_LimparClick);
            this.tspCommand.AfterLimpar += new Hac.Windows.Forms.Controls.AfterBeforeHacEventHandler(this.tspCommand_AfterLimpar);
            this.tspCommand.BeforeImprimir += new Hac.Windows.Forms.Controls.AfterBeforeHacEventHandler(this.tspCommand_BeforeImprimir);
            this.tspCommand.ImprimirClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_ImprimirClick);
            // 
            // dgvCPTCodigo
            // 
            this.dgvCPTCodigo.DataPropertyName = "CID";
            this.dgvCPTCodigo.HeaderText = "CID";
            this.dgvCPTCodigo.Name = "dgvCPTCodigo";
            this.dgvCPTCodigo.ReadOnly = true;
            this.dgvCPTCodigo.Width = 150;
            // 
            // dgvCPTDescricao
            // 
            this.dgvCPTDescricao.DataPropertyName = "DESCID";
            this.dgvCPTDescricao.HeaderText = "Descrição";
            this.dgvCPTDescricao.Name = "dgvCPTDescricao";
            this.dgvCPTDescricao.ReadOnly = true;
            this.dgvCPTDescricao.Width = 480;
            // 
            // dgvCPTDataTermino
            // 
            this.dgvCPTDataTermino.DataPropertyName = "DATLIMITE";
            this.dgvCPTDataTermino.HeaderText = "Data de Término";
            this.dgvCPTDataTermino.Name = "dgvCPTDataTermino";
            this.dgvCPTDataTermino.ReadOnly = true;
            this.dgvCPTDataTermino.Width = 150;
            // 
            // FrmPesquisaCarencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 421);
            this.ControlBox = false;
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.gbxCPT);
            this.Controls.Add(this.gbxCarencia);
            this.Controls.Add(this.gbxPesquisa);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaCarencia";
            this.ShowInTaskbar = false;
            this.Text = "Pesquisar Carência";
            this.gbxPesquisa.ResumeLayout(false);
            this.gbxPesquisa.PerformLayout();
            this.gbxCarencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCarencia)).EndInit();
            this.gbxCPT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCPT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacLabel lblPlano;
        private Hac.Windows.Forms.Controls.HacLabel lblConvenio;
        private Hac.Windows.Forms.Controls.HacLabel lblCredencial;
        private System.Windows.Forms.GroupBox gbxPesquisa;
        private System.Windows.Forms.GroupBox gbxCarencia;
        
        //private System.Windows.Forms.DataGridView grdCarencia;
        private Hac.Windows.Forms.Controls.HacDataGridView grdCarencia;

        private System.Windows.Forms.GroupBox gbxCPT;
        
        //private System.Windows.Forms.DataGridView grdCPT;
        private Hac.Windows.Forms.Controls.HacDataGridView grdCPT;

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacPlano ctlPlano;
        private Hac.Windows.Forms.Controls.HacConvenio ctlConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataFimCarencia;
        private HacTextBox txtCodSeqBen;
        private HacTextBox txtCredencialHac;
        private HacTextBox txtCodSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCPTCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCPTDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCPTDataTermino;
    }
}
