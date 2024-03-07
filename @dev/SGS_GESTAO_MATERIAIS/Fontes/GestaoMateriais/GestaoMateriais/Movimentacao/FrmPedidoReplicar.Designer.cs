namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmPedidoReplicar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoReplicar));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chbAtendDom = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbTipoRequisicao = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblCentroDisp = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chbApenasFornecidos = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnSugerir = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(613, 28);
            this.tsHac.TabIndex = 84;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Replicação de Pedidos";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmbSetor);
            this.groupBox6.Controls.Add(this.cmbLocal);
            this.groupBox6.Controls.Add(this.hacLabel2);
            this.groupBox6.Controls.Add(this.cmbUnidade);
            this.groupBox6.Controls.Add(this.hacLabel7);
            this.groupBox6.Controls.Add(this.hacLabel8);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(12, 42);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(328, 113);
            this.groupBox6.TabIndex = 85;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Filtrar Setor";
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = true;
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
            this.cmbSetor.Location = new System.Drawing.Point(65, 80);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = false;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(245, 21);
            this.cmbSetor.TabIndex = 3;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(65, 53);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = false;
            this.cmbLocal.Size = new System.Drawing.Size(245, 21);
            this.cmbLocal.TabIndex = 2;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(7, 29);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(53, 13);
            this.hacLabel2.TabIndex = 132;
            this.hacLabel2.Text = "Unidade";
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
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = true;
            this.cmbUnidade.Location = new System.Drawing.Point(65, 26);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = false;
            this.cmbUnidade.Size = new System.Drawing.Size(245, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 1;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(23, 56);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(36, 13);
            this.hacLabel7.TabIndex = 133;
            this.hacLabel7.Text = "Local";
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(21, 83);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(38, 13);
            this.hacLabel8.TabIndex = 134;
            this.hacLabel8.Text = "Setor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFim);
            this.groupBox2.Controls.Add(this.txtInicio);
            this.groupBox2.Controls.Add(this.hacLabel5);
            this.groupBox2.Controls.Add(this.hacLabel6);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(346, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 55);
            this.groupBox2.TabIndex = 86;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período Replicação";
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
            this.txtFim.Location = new System.Drawing.Point(155, 23);
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
            this.txtInicio.Location = new System.Drawing.Point(47, 23);
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
            this.hacLabel5.Location = new System.Drawing.Point(129, 27);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(27, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(8, 27);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 28;
            this.hacLabel6.Text = "Início";
            // 
            // chbAtendDom
            // 
            this.chbAtendDom.AutoSize = true;
            this.chbAtendDom.Checked = true;
            this.chbAtendDom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAtendDom.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbAtendDom.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbAtendDom.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAtendDom.Limpar = true;
            this.chbAtendDom.Location = new System.Drawing.Point(350, 107);
            this.chbAtendDom.Name = "chbAtendDom";
            this.chbAtendDom.Obrigatorio = false;
            this.chbAtendDom.ObrigatorioMensagem = null;
            this.chbAtendDom.PreValidacaoMensagem = null;
            this.chbAtendDom.PreValidado = false;
            this.chbAtendDom.Size = new System.Drawing.Size(177, 17);
            this.chbAtendDom.TabIndex = 158;
            this.chbAtendDom.Text = "Atendimento Domiciliar";
            this.chbAtendDom.UseVisualStyleBackColor = true;
            this.chbAtendDom.Click += new System.EventHandler(this.chbAtendDom_Click);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(14, 174);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(73, 13);
            this.hacLabel1.TabIndex = 160;
            this.hacLabel1.Text = "Tipo Pedido";
            // 
            // cmbTipoRequisicao
            // 
            this.cmbTipoRequisicao.BackColor = System.Drawing.Color.Honeydew;
            this.cmbTipoRequisicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRequisicao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbTipoRequisicao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbTipoRequisicao.FormattingEnabled = true;
            this.cmbTipoRequisicao.Limpar = true;
            this.cmbTipoRequisicao.Location = new System.Drawing.Point(95, 169);
            this.cmbTipoRequisicao.Name = "cmbTipoRequisicao";
            this.cmbTipoRequisicao.Obrigatorio = false;
            this.cmbTipoRequisicao.ObrigatorioMensagem = null;
            this.cmbTipoRequisicao.PreValidacaoMensagem = null;
            this.cmbTipoRequisicao.PreValidado = false;
            this.cmbTipoRequisicao.Size = new System.Drawing.Size(245, 21);
            this.cmbTipoRequisicao.TabIndex = 159;
            this.cmbTipoRequisicao.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoRequisicao_SelectionChangeCommitted);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(14, 211);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(140, 13);
            this.hacLabel3.TabIndex = 161;
            this.hacLabel3.Text = "Centro de Dispensação";
            // 
            // lblCentroDisp
            // 
            this.lblCentroDisp.AutoSize = true;
            this.lblCentroDisp.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCentroDisp.Location = new System.Drawing.Point(156, 209);
            this.lblCentroDisp.Name = "lblCentroDisp";
            this.lblCentroDisp.Size = new System.Drawing.Size(15, 17);
            this.lblCentroDisp.TabIndex = 162;
            this.lblCentroDisp.Text = "-";
            // 
            // chbApenasFornecidos
            // 
            this.chbApenasFornecidos.AutoSize = true;
            this.chbApenasFornecidos.Checked = true;
            this.chbApenasFornecidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbApenasFornecidos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbApenasFornecidos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbApenasFornecidos.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbApenasFornecidos.Limpar = false;
            this.chbApenasFornecidos.Location = new System.Drawing.Point(350, 132);
            this.chbApenasFornecidos.Name = "chbApenasFornecidos";
            this.chbApenasFornecidos.Obrigatorio = false;
            this.chbApenasFornecidos.ObrigatorioMensagem = null;
            this.chbApenasFornecidos.PreValidacaoMensagem = null;
            this.chbApenasFornecidos.PreValidado = false;
            this.chbApenasFornecidos.Size = new System.Drawing.Size(147, 17);
            this.chbApenasFornecidos.TabIndex = 163;
            this.chbApenasFornecidos.Text = "Apenas Fornecidos";
            this.chbApenasFornecidos.UseVisualStyleBackColor = true;
            // 
            // btnSugerir
            // 
            this.btnSugerir.AlterarStatus = true;
            this.btnSugerir.BackColor = System.Drawing.Color.White;
            this.btnSugerir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSugerir.BackgroundImage")));
            this.btnSugerir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSugerir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSugerir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSugerir.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSugerir.Location = new System.Drawing.Point(457, 209);
            this.btnSugerir.Name = "btnSugerir";
            this.btnSugerir.Size = new System.Drawing.Size(137, 22);
            this.btnSugerir.TabIndex = 164;
            this.btnSugerir.Text = "REPLICAR PEDIDOS";
            this.btnSugerir.UseVisualStyleBackColor = true;
            this.btnSugerir.Click += new System.EventHandler(this.btnSugerir_Click);
            // 
            // FrmPedidoReplicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 245);
            this.Controls.Add(this.btnSugerir);
            this.Controls.Add(this.chbApenasFornecidos);
            this.Controls.Add(this.lblCentroDisp);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.cmbTipoRequisicao);
            this.Controls.Add(this.chbAtendDom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmPedidoReplicar";
            this.Text = "FrmPedidoReplicar";
            this.Load += new System.EventHandler(this.FrmPedidoReplicar_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox6;
        private SGS.Componentes.HacCmbSetor cmbSetor;
        private SGS.Componentes.HacCmbLocal cmbLocal;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacLabel hacLabel8;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacTextBox txtFim;
        private SGS.Componentes.HacTextBox txtInicio;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacCheckBox chbAtendDom;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacComboBox cmbTipoRequisicao;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacLabel lblCentroDisp;
        private SGS.Componentes.HacCheckBox chbApenasFornecidos;
        private SGS.Componentes.HacButton btnSugerir;
    }
}