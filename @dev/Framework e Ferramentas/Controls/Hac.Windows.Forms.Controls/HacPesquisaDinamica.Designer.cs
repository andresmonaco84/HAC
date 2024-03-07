namespace Hac.Windows.Forms.Controls
{
    partial class HacPesquisaDinamica
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPesquisaDinamica = new System.Windows.Forms.TabControl();
            this.tabPageClinica = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlClinica = new Hac.Windows.Forms.Controls.HacClinica();
            this.dgvClinica = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbxUnidadePagamento = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.dgvUnidadePagamento = new System.Windows.Forms.DataGridView();
            this.colIdtUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbxBaseCalculo = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.dgvBaseCalculo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtMesAnoPagamento = new Hac.Windows.Forms.Controls.HacMaskedTextBox(this.components);
            this.hacLabel2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacComboBox1 = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.colCodigoClinica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricaoClinica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPesquisaDinamica.SuspendLayout();
            this.tabPageClinica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinica)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadePagamento)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseCalculo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPesquisaDinamica
            // 
            this.tabPesquisaDinamica.Controls.Add(this.tabPageClinica);
            this.tabPesquisaDinamica.Controls.Add(this.tabPage1);
            this.tabPesquisaDinamica.Controls.Add(this.tabPage2);
            this.tabPesquisaDinamica.Location = new System.Drawing.Point(6, 63);
            this.tabPesquisaDinamica.Name = "tabPesquisaDinamica";
            this.tabPesquisaDinamica.SelectedIndex = 0;
            this.tabPesquisaDinamica.Size = new System.Drawing.Size(511, 314);
            this.tabPesquisaDinamica.TabIndex = 2;
            // 
            // tabPageClinica
            // 
            this.tabPageClinica.Controls.Add(this.label1);
            this.tabPageClinica.Controls.Add(this.ctlClinica);
            this.tabPageClinica.Controls.Add(this.dgvClinica);
            this.tabPageClinica.Controls.Add(this.toolStrip1);
            this.tabPageClinica.Location = new System.Drawing.Point(4, 22);
            this.tabPageClinica.Name = "tabPageClinica";
            this.tabPageClinica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClinica.Size = new System.Drawing.Size(503, 288);
            this.tabPageClinica.TabIndex = 0;
            this.tabPageClinica.Text = "Clínica";
            this.tabPageClinica.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clínica.:";
            // 
            // ctlClinica
            // 
            this.ctlClinica.AutoSize = true;
            this.ctlClinica.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlClinica.Enabled = false;
            this.ctlClinica.Limpar = true;
            this.ctlClinica.Location = new System.Drawing.Point(83, 35);
            this.ctlClinica.Name = "ctlClinica";
            this.ctlClinica.NaoAjustarEdicao = false;
            this.ctlClinica.Obrigatorio = false;
            this.ctlClinica.ObrigatorioMensagem = null;
            this.ctlClinica.Size = new System.Drawing.Size(360, 24);
            this.ctlClinica.TabIndex = 2;
            // 
            // dgvClinica
            // 
            this.dgvClinica.AllowUserToAddRows = false;
            this.dgvClinica.AllowUserToResizeRows = false;
            this.dgvClinica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClinica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoClinica,
            this.colDescricaoClinica});
            this.dgvClinica.Location = new System.Drawing.Point(6, 65);
            this.dgvClinica.Name = "dgvClinica";
            this.dgvClinica.RowHeadersVisible = false;
            this.dgvClinica.Size = new System.Drawing.Size(487, 218);
            this.dgvClinica.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(497, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Hac.Windows.Forms.Controls.Properties.Resources.btnAdicionar;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Hac.Windows.Forms.Controls.Properties.Resources.btnRemover;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxUnidadePagamento);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Controls.Add(this.dgvUnidadePagamento);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(503, 288);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Unid. Pagto";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbxUnidadePagamento
            // 
            this.cbxUnidadePagamento.BackColor = System.Drawing.Color.Honeydew;
            this.cbxUnidadePagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidadePagamento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.cbxUnidadePagamento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cbxUnidadePagamento.FormattingEnabled = true;
            this.cbxUnidadePagamento.Limpar = false;
            this.cbxUnidadePagamento.Location = new System.Drawing.Point(83, 35);
            this.cbxUnidadePagamento.Name = "cbxUnidadePagamento";
            this.cbxUnidadePagamento.Obrigatorio = false;
            this.cbxUnidadePagamento.ObrigatorioMensagem = null;
            this.cbxUnidadePagamento.PreValidacaoMensagem = null;
            this.cbxUnidadePagamento.PreValidado = false;
            this.cbxUnidadePagamento.Size = new System.Drawing.Size(261, 21);
            this.cbxUnidadePagamento.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unid. Pagto.:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(497, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Hac.Windows.Forms.Controls.Properties.Resources.btnAdicionar;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton1";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Hac.Windows.Forms.Controls.Properties.Resources.btnRemover;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton2";
            // 
            // dgvUnidadePagamento
            // 
            this.dgvUnidadePagamento.AllowUserToAddRows = false;
            this.dgvUnidadePagamento.AllowUserToResizeRows = false;
            this.dgvUnidadePagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidadePagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtUnidade,
            this.dataGridViewTextBoxColumn2});
            this.dgvUnidadePagamento.Location = new System.Drawing.Point(6, 65);
            this.dgvUnidadePagamento.Name = "dgvUnidadePagamento";
            this.dgvUnidadePagamento.RowHeadersVisible = false;
            this.dgvUnidadePagamento.Size = new System.Drawing.Size(487, 218);
            this.dgvUnidadePagamento.TabIndex = 2;
            // 
            // colIdtUnidade
            // 
            this.colIdtUnidade.DataPropertyName = "CAD_UNI_ID_UNIDADE";
            this.colIdtUnidade.HeaderText = "IdtUnidade";
            this.colIdtUnidade.Name = "colIdtUnidade";
            this.colIdtUnidade.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CAD_UNI_DS_UNIDADE";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 340;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbxBaseCalculo);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Controls.Add(this.dgvBaseCalculo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(503, 288);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Base Cálculo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbxBaseCalculo
            // 
            this.cbxBaseCalculo.BackColor = System.Drawing.Color.Honeydew;
            this.cbxBaseCalculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaseCalculo.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.cbxBaseCalculo.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cbxBaseCalculo.FormattingEnabled = true;
            this.cbxBaseCalculo.Limpar = false;
            this.cbxBaseCalculo.Location = new System.Drawing.Point(83, 35);
            this.cbxBaseCalculo.Name = "cbxBaseCalculo";
            this.cbxBaseCalculo.Obrigatorio = false;
            this.cbxBaseCalculo.ObrigatorioMensagem = null;
            this.cbxBaseCalculo.PreValidacaoMensagem = null;
            this.cbxBaseCalculo.PreValidado = false;
            this.cbxBaseCalculo.Size = new System.Drawing.Size(261, 21);
            this.cbxBaseCalculo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Base Calculo.:";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(497, 25);
            this.toolStrip3.TabIndex = 4;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::Hac.Windows.Forms.Controls.Properties.Resources.btnAdicionar;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton1";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::Hac.Windows.Forms.Controls.Properties.Resources.btnRemover;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton2";
            // 
            // dgvBaseCalculo
            // 
            this.dgvBaseCalculo.AllowUserToAddRows = false;
            this.dgvBaseCalculo.AllowUserToResizeRows = false;
            this.dgvBaseCalculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaseCalculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            this.dgvBaseCalculo.Location = new System.Drawing.Point(6, 65);
            this.dgvBaseCalculo.Name = "dgvBaseCalculo";
            this.dgvBaseCalculo.RowHeadersVisible = false;
            this.dgvBaseCalculo.Size = new System.Drawing.Size(487, 218);
            this.dgvBaseCalculo.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CAD_REP_TP_BASE_CALCULO";
            this.dataGridViewTextBoxColumn4.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 340;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtMesAnoPagamento);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Controls.Add(this.hacLabel1);
            this.groupBox1.Controls.Add(this.hacComboBox1);
            this.groupBox1.Controls.Add(this.tabPesquisaDinamica);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 396);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisa Pagamento Médico";
            // 
            // edtMesAnoPagamento
            // 
            this.edtMesAnoPagamento.AcceptedFormatMasked = Hac.Windows.Forms.Controls.AcceptedFormatMasked.Data;
            this.edtMesAnoPagamento.BackColor = System.Drawing.Color.Honeydew;
            this.edtMesAnoPagamento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.edtMesAnoPagamento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.edtMesAnoPagamento.Limpar = false;
            this.edtMesAnoPagamento.Location = new System.Drawing.Point(145, 32);
            this.edtMesAnoPagamento.Mask = "00/0000";
            this.edtMesAnoPagamento.Name = "edtMesAnoPagamento";
            this.edtMesAnoPagamento.NaoAjustarEdicao = false;
            this.edtMesAnoPagamento.Obrigatorio = false;
            this.edtMesAnoPagamento.ObrigatorioMensagem = "";
            this.edtMesAnoPagamento.PreValidacaoMensagem = "";
            this.edtMesAnoPagamento.PreValidado = false;
            this.edtMesAnoPagamento.SelectAllOnFocus = false;
            this.edtMesAnoPagamento.Size = new System.Drawing.Size(100, 20);
            this.edtMesAnoPagamento.TabIndex = 7;
            this.edtMesAnoPagamento.ValidatingType = typeof(System.DateTime);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(9, 36);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(133, 13);
            this.hacLabel2.TabIndex = 6;
            this.hacLabel2.Text = "Mês/Ano Pagamento.:";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(280, 36);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(105, 13);
            this.hacLabel1.TabIndex = 5;
            this.hacLabel1.Text = "Fonte Pagadora.:";
            // 
            // hacComboBox1
            // 
            this.hacComboBox1.BackColor = System.Drawing.Color.Honeydew;
            this.hacComboBox1.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.hacComboBox1.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Desabilitado;
            this.hacComboBox1.FormattingEnabled = true;
            this.hacComboBox1.Limpar = false;
            this.hacComboBox1.Location = new System.Drawing.Point(391, 32);
            this.hacComboBox1.Name = "hacComboBox1";
            this.hacComboBox1.Obrigatorio = false;
            this.hacComboBox1.ObrigatorioMensagem = null;
            this.hacComboBox1.PreValidacaoMensagem = null;
            this.hacComboBox1.PreValidado = false;
            this.hacComboBox1.Size = new System.Drawing.Size(121, 21);
            this.hacComboBox1.TabIndex = 4;
            this.hacComboBox1.Text = "<Selecione>";
            // 
            // colCodigoClinica
            // 
            this.colCodigoClinica.DataPropertyName = "CAD_CLC_ID";
            this.colCodigoClinica.HeaderText = "Idt";
            this.colCodigoClinica.Name = "colCodigoClinica";
            // 
            // colDescricaoClinica
            // 
            this.colDescricaoClinica.DataPropertyName = "CAD_CLC_DS_DESCRICAO";
            this.colDescricaoClinica.HeaderText = "Descrição";
            this.colDescricaoClinica.Name = "colDescricaoClinica";
            this.colDescricaoClinica.Width = 340;
            // 
            // HacPesquisaDinamica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "HacPesquisaDinamica";
            this.Size = new System.Drawing.Size(540, 404);
            this.tabPesquisaDinamica.ResumeLayout(false);
            this.tabPageClinica.ResumeLayout(false);
            this.tabPageClinica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinica)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadePagamento)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseCalculo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPesquisaDinamica;
        private System.Windows.Forms.TabPage tabPageClinica;
        private System.Windows.Forms.DataGridView dgvClinica;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private HacComboBox hacComboBox1;
        private HacLabel hacLabel2;
        private HacLabel hacLabel1;
        private System.Windows.Forms.DataGridView dgvUnidadePagamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private HacClinica ctlClinica;
        private HacComboBox cbxUnidadePagamento;
        private HacComboBox cbxBaseCalculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.DataGridView dgvBaseCalculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private HacMaskedTextBox edtMesAnoPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoClinica;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricaoClinica;


    }
}
