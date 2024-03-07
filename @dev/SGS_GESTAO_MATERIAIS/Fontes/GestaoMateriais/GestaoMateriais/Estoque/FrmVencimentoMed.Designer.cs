namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmVencimentoMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVencimentoMed));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtNumLote = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.grbPeriodo = new System.Windows.Forms.GroupBox();
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtCodLote = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.colCodProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbPeriodo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMed)).BeginInit();
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
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(684, 28);
            this.tsHac.TabIndex = 0;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Medicamentos a Vencer";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(293, 74);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(93, 13);
            this.hacLabel6.TabIndex = 154;
            this.hacLabel6.Text = "Num. Lote Fab.";
            // 
            // txtNumLote
            // 
            this.txtNumLote.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNumLote.BackColor = System.Drawing.Color.Honeydew;
            this.txtNumLote.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtNumLote.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNumLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNumLote.Limpar = true;
            this.txtNumLote.Location = new System.Drawing.Point(388, 70);
            this.txtNumLote.MaxLength = 30;
            this.txtNumLote.Name = "txtNumLote";
            this.txtNumLote.NaoAjustarEdicao = true;
            this.txtNumLote.Obrigatorio = false;
            this.txtNumLote.ObrigatorioMensagem = "";
            this.txtNumLote.PreValidacaoMensagem = "";
            this.txtNumLote.PreValidado = false;
            this.txtNumLote.SelectAllOnFocus = false;
            this.txtNumLote.Size = new System.Drawing.Size(106, 21);
            this.txtNumLote.TabIndex = 2;
            // 
            // grbPeriodo
            // 
            this.grbPeriodo.Controls.Add(this.txtFim);
            this.grbPeriodo.Controls.Add(this.txtInicio);
            this.grbPeriodo.Controls.Add(this.hacLabel5);
            this.grbPeriodo.Controls.Add(this.hacLabel1);
            this.grbPeriodo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPeriodo.Location = new System.Drawing.Point(15, 36);
            this.grbPeriodo.Name = "grbPeriodo";
            this.grbPeriodo.Size = new System.Drawing.Size(265, 53);
            this.grbPeriodo.TabIndex = 1;
            this.grbPeriodo.TabStop = false;
            this.grbPeriodo.Text = "Período Validade (obrigatório)";
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
            this.txtFim.Location = new System.Drawing.Point(156, 22);
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
            this.hacLabel5.Location = new System.Drawing.Point(130, 25);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(27, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(7, 25);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(38, 13);
            this.hacLabel1.TabIndex = 28;
            this.hacLabel1.Text = "Início";
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
            this.btnLimparProduto.Location = new System.Drawing.Point(542, 18);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 4;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Visible = false;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(11, 24);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(19, 14);
            this.lblProduto.TabIndex = 161;
            this.lblProduto.Text = "--";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProduto);
            this.groupBox1.Controls.Add(this.btnLimparProduto);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 51);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produto";
            // 
            // dtgMed
            // 
            this.dtgMed.AllowUserToAddRows = false;
            this.dtgMed.AlterarStatus = true;
            this.dtgMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMed.ColumnHeadersHeight = 21;
            this.dtgMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodProd,
            this.colMedicamento,
            this.colCodLote,
            this.colNumLote,
            this.colDataVal,
            this.colQtdLote});
            this.dtgMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMed.GridPesquisa = false;
            this.dtgMed.Limpar = true;
            this.dtgMed.Location = new System.Drawing.Point(13, 158);
            this.dtgMed.Name = "dtgMed";
            this.dtgMed.NaoAjustarEdicao = true;
            this.dtgMed.Obrigatorio = false;
            this.dtgMed.ObrigatorioMensagem = null;
            this.dtgMed.PreValidacaoMensagem = null;
            this.dtgMed.PreValidado = false;
            this.dtgMed.RowHeadersVisible = false;
            this.dtgMed.RowHeadersWidth = 25;
            this.dtgMed.RowTemplate.Height = 18;
            this.dtgMed.Size = new System.Drawing.Size(659, 381);
            this.dtgMed.TabIndex = 5;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(293, 49);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(62, 13);
            this.hacLabel2.TabIndex = 156;
            this.hacLabel2.Text = "Cod. Lote";
            // 
            // txtCodLote
            // 
            this.txtCodLote.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodLote.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodLote.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtCodLote.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtCodLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodLote.Limpar = true;
            this.txtCodLote.Location = new System.Drawing.Point(388, 45);
            this.txtCodLote.MaxLength = 5;
            this.txtCodLote.Name = "txtCodLote";
            this.txtCodLote.NaoAjustarEdicao = true;
            this.txtCodLote.Obrigatorio = false;
            this.txtCodLote.ObrigatorioMensagem = "";
            this.txtCodLote.PreValidacaoMensagem = "";
            this.txtCodLote.PreValidado = false;
            this.txtCodLote.SelectAllOnFocus = false;
            this.txtCodLote.Size = new System.Drawing.Size(62, 21);
            this.txtCodLote.TabIndex = 1;
            // 
            // colCodProd
            // 
            this.colCodProd.DataPropertyName = "CAD_MTMD_ID";
            this.colCodProd.HeaderText = "ID Med.";
            this.colCodProd.Name = "colCodProd";
            this.colCodProd.ReadOnly = true;
            this.colCodProd.Width = 55;
            // 
            // colMedicamento
            // 
            this.colMedicamento.DataPropertyName = "CAD_MTMD_NOMEFANTASIA";
            this.colMedicamento.HeaderText = "Medicamento";
            this.colMedicamento.Name = "colMedicamento";
            this.colMedicamento.ReadOnly = true;
            this.colMedicamento.Width = 247;
            // 
            // colCodLote
            // 
            this.colCodLote.DataPropertyName = "MTMD_COD_LOTE";
            this.colCodLote.HeaderText = "Cod. Lote";
            this.colCodLote.Name = "colCodLote";
            this.colCodLote.ReadOnly = true;
            this.colCodLote.Width = 60;
            // 
            // colNumLote
            // 
            this.colNumLote.DataPropertyName = "MTMD_NUM_LOTE";
            this.colNumLote.HeaderText = "Num. Lote Fab.";
            this.colNumLote.Name = "colNumLote";
            this.colNumLote.ReadOnly = true;
            this.colNumLote.Width = 92;
            // 
            // colDataVal
            // 
            this.colDataVal.DataPropertyName = "MTMD_DT_VALIDADE";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colDataVal.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDataVal.HeaderText = "Dt. Validade";
            this.colDataVal.Name = "colDataVal";
            this.colDataVal.ReadOnly = true;
            this.colDataVal.Width = 78;
            // 
            // colQtdLote
            // 
            this.colQtdLote.DataPropertyName = "MTMD_QTDE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colQtdLote.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtdLote.HeaderText = "Qtd. Entradas Lote";
            this.colQtdLote.Name = "colQtdLote";
            this.colQtdLote.ReadOnly = true;
            this.colQtdLote.Width = 107;
            // 
            // FrmVencimentoMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 551);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.txtCodLote);
            this.Controls.Add(this.dtgMed);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPeriodo);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.txtNumLote);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmVencimentoMed";
            this.Text = "FrmVencimentoMed";
            this.Load += new System.EventHandler(this.FrmVencimentoMed_Load);
            this.grbPeriodo.ResumeLayout(false);
            this.grbPeriodo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacTextBox txtNumLote;
        private System.Windows.Forms.GroupBox grbPeriodo;
        private SGS.Componentes.HacTextBox txtFim;
        private SGS.Componentes.HacTextBox txtInicio;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacButton btnLimparProduto;
        private SGS.Componentes.HacLabel lblProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacDataGridView dtgMed;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacTextBox txtCodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdLote;
    }
}