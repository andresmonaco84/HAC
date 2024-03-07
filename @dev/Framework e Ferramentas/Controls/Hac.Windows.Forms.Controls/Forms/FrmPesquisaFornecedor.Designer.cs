namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaFornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaFornecedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.txtCod = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.hacLabel1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.txtNome = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblProcedimentoProposto = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.dgvPesquisaForn = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumAuto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbACS = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.rbHAC = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaForn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.PesquisarVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(604, 28);
            this.tspCommand.TabIndex = 152;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "Pesquisa de Fornecedor";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // txtCod
            // 
            this.txtCod.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCod.BackColor = System.Drawing.Color.Honeydew;
            this.txtCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCod.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCod.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCod.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Limpar = true;
            this.txtCod.Location = new System.Drawing.Point(54, 42);
            this.txtCod.MaxLength = 10;
            this.txtCod.Name = "txtCod";
            this.txtCod.NaoAjustarEdicao = false;
            this.txtCod.Obrigatorio = false;
            this.txtCod.ObrigatorioMensagem = null;
            this.txtCod.PreValidacaoMensagem = null;
            this.txtCod.PreValidado = false;
            this.txtCod.SelectAllOnFocus = false;
            this.txtCod.Size = new System.Drawing.Size(74, 18);
            this.txtCod.TabIndex = 157;
            this.txtCod.TextChanged += new System.EventHandler(this.txtCod_TextChanged);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(10, 44);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(41, 14);
            this.hacLabel1.TabIndex = 160;
            this.hacLabel1.Text = "Cod.:";
            // 
            // txtNome
            // 
            this.txtNome.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNome.BackColor = System.Drawing.Color.Honeydew;
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNome.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNome.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Limpar = true;
            this.txtNome.Location = new System.Drawing.Point(218, 42);
            this.txtNome.MaxLength = 20;
            this.txtNome.Name = "txtNome";
            this.txtNome.NaoAjustarEdicao = false;
            this.txtNome.Obrigatorio = false;
            this.txtNome.ObrigatorioMensagem = null;
            this.txtNome.PreValidacaoMensagem = null;
            this.txtNome.PreValidado = false;
            this.txtNome.SelectAllOnFocus = false;
            this.txtNome.Size = new System.Drawing.Size(232, 18);
            this.txtNome.TabIndex = 158;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lblProcedimentoProposto
            // 
            this.lblProcedimentoProposto.AutoSize = true;
            this.lblProcedimentoProposto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcedimentoProposto.Location = new System.Drawing.Point(136, 44);
            this.lblProcedimentoProposto.Name = "lblProcedimentoProposto";
            this.lblProcedimentoProposto.Size = new System.Drawing.Size(84, 14);
            this.lblProcedimentoProposto.TabIndex = 159;
            this.lblProcedimentoProposto.Text = "Nome Forn.:";
            // 
            // dgvPesquisaForn
            // 
            this.dgvPesquisaForn.AllowUserToAddRows = false;
            this.dgvPesquisaForn.AllowUserToDeleteRows = false;
            this.dgvPesquisaForn.AllowUserToResizeRows = false;
            this.dgvPesquisaForn.AlterarStatus = false;
            this.dgvPesquisaForn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaForn.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaForn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaForn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaForn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCod,
            this.colNome,
            this.colNumAuto});
            this.dgvPesquisaForn.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.dgvPesquisaForn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPesquisaForn.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaForn.GridPesquisa = false;
            this.dgvPesquisaForn.Limpar = false;
            this.dgvPesquisaForn.Location = new System.Drawing.Point(4, 73);
            this.dgvPesquisaForn.MultiSelect = false;
            this.dgvPesquisaForn.Name = "dgvPesquisaForn";
            this.dgvPesquisaForn.NaoAjustarEdicao = true;
            this.dgvPesquisaForn.Obrigatorio = false;
            this.dgvPesquisaForn.ObrigatorioMensagem = null;
            this.dgvPesquisaForn.PreValidacaoMensagem = null;
            this.dgvPesquisaForn.PreValidado = false;
            this.dgvPesquisaForn.ReadOnly = true;
            this.dgvPesquisaForn.RowHeadersVisible = false;
            this.dgvPesquisaForn.RowHeadersWidth = 25;
            this.dgvPesquisaForn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaForn.ShowCellErrors = false;
            this.dgvPesquisaForn.Size = new System.Drawing.Size(600, 344);
            this.dgvPesquisaForn.TabIndex = 161;
            this.dgvPesquisaForn.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPesquisaForn_CellMouseDoubleClick);
            // 
            // colCod
            // 
            this.colCod.DataPropertyName = "CAD_FORN_CODCFO";
            this.colCod.HeaderText = "Cod.";
            this.colCod.Name = "colCod";
            this.colCod.ReadOnly = true;
            this.colCod.Width = 80;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "CAD_FORN_NOME";
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 300;
            // 
            // colNumAuto
            // 
            this.colNumAuto.DataPropertyName = "CAD_FORN_NUM_AUTORIZA";
            this.colNumAuto.HeaderText = "Núm. Autorização Func.";
            this.colNumAuto.Name = "colNumAuto";
            this.colNumAuto.ReadOnly = true;
            this.colNumAuto.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbACS);
            this.groupBox1.Controls.Add(this.rbHAC);
            this.groupBox1.Location = new System.Drawing.Point(463, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 36);
            this.groupBox1.TabIndex = 162;
            this.groupBox1.TabStop = false;
            // 
            // rbACS
            // 
            this.rbACS.AutoSize = true;
            this.rbACS.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rbACS.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rbACS.Limpar = false;
            this.rbACS.Location = new System.Drawing.Point(63, 13);
            this.rbACS.Name = "rbACS";
            this.rbACS.Obrigatorio = false;
            this.rbACS.ObrigatorioMensagem = null;
            this.rbACS.PreValidacaoMensagem = null;
            this.rbACS.PreValidado = false;
            this.rbACS.Size = new System.Drawing.Size(46, 17);
            this.rbACS.TabIndex = 164;
            this.rbACS.Text = "ACS";
            this.rbACS.UseVisualStyleBackColor = true;
            this.rbACS.Click += new System.EventHandler(this.rbACS_Click);
            // 
            // rbHAC
            // 
            this.rbHAC.AutoSize = true;
            this.rbHAC.Checked = true;
            this.rbHAC.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rbHAC.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rbHAC.Limpar = false;
            this.rbHAC.Location = new System.Drawing.Point(10, 13);
            this.rbHAC.Name = "rbHAC";
            this.rbHAC.Obrigatorio = false;
            this.rbHAC.ObrigatorioMensagem = null;
            this.rbHAC.PreValidacaoMensagem = null;
            this.rbHAC.PreValidado = false;
            this.rbHAC.Size = new System.Drawing.Size(47, 17);
            this.rbHAC.TabIndex = 163;
            this.rbHAC.TabStop = true;
            this.rbHAC.Text = "HAC";
            this.rbHAC.UseVisualStyleBackColor = true;
            this.rbHAC.Click += new System.EventHandler(this.rbHAC_Click);
            // 
            // FrmPesquisaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPesquisaForn);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblProcedimentoProposto);
            this.Controls.Add(this.tspCommand);
            this.Name = "FrmPesquisaFornecedor";
            this.Text = "Pesquisa de Fornecedor";
            this.Load += new System.EventHandler(this.FrmPesquisaFornecedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaForn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tspCommand;
        private HacTextBox txtCod;
        private HacLabel hacLabel1;
        private HacTextBox txtNome;
        private HacLabel lblProcedimentoProposto;
        private HacDataGridView dgvPesquisaForn;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacRadioButton rbACS;
        private HacRadioButton rbHAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumAuto;
    }
}