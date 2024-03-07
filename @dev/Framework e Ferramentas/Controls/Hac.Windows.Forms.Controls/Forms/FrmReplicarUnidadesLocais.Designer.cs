namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmReplicarUnidadesLocais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReplicarUnidadesLocais));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboLocal = new Hac.Windows.Forms.Controls.HacCmbLocal(this.components);
            this.cboUnidade = new Hac.Windows.Forms.Controls.HacCmbUnidade(this.components);
            this.hacLabel19 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel25 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.tsbOK = new System.Windows.Forms.ToolStripButton();
            this.btnExcluirProdutoItem = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.btnAdicionarProdutoItem = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.dgvPesquisaUnidadeLocal = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colIdtUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaUnidadeLocal)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLocal
            // 
            this.cboLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cboLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocal.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboLocal.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboLocal.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.Limpar = true;
            this.cboLocal.Location = new System.Drawing.Point(102, 62);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.NomeComboSetor = null;
            this.cboLocal.NomeComboUnidade = "cboUnidade";
            this.cboLocal.Obrigatorio = false;
            this.cboLocal.ObrigatorioMensagem = "";
            this.cboLocal.PreValidacaoMensagem = "";
            this.cboLocal.PreValidado = false;
            this.cboLocal.Size = new System.Drawing.Size(229, 20);
            this.cboLocal.TabIndex = 327;
            this.cboLocal.UtilizaTabelaAssociacaoUnidadeLocal = false;
            // 
            // cboUnidade
            // 
            this.cboUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cboUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cboUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidade.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboUnidade.Enabled = false;
            this.cboUnidade.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboUnidade.Fatura = false;
            this.cboUnidade.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.GravaAtendimento = false;
            this.cboUnidade.IdtConvenio = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cboUnidade.Internacao = false;
            this.cboUnidade.Limpar = true;
            this.cboUnidade.Location = new System.Drawing.Point(102, 36);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.NomeComboLocal = "cboLocal";
            this.cboUnidade.NomeComboSetor = null;
            this.cboUnidade.Obrigatorio = false;
            this.cboUnidade.ObrigatorioMensagem = "";
            this.cboUnidade.PreValidacaoMensagem = "";
            this.cboUnidade.PreValidado = false;
            this.cboUnidade.Size = new System.Drawing.Size(229, 20);
            this.cboUnidade.SomenteAtiva = true;
            this.cboUnidade.SomenteUnidade = false;
            this.cboUnidade.TabIndex = 326;
            // 
            // hacLabel19
            // 
            this.hacLabel19.AutoSize = true;
            this.hacLabel19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel19.Location = new System.Drawing.Point(20, 40);
            this.hacLabel19.Name = "hacLabel19";
            this.hacLabel19.Size = new System.Drawing.Size(64, 14);
            this.hacLabel19.TabIndex = 329;
            this.hacLabel19.Text = "Unidade:";
            // 
            // hacLabel25
            // 
            this.hacLabel25.AutoSize = true;
            this.hacLabel25.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel25.Location = new System.Drawing.Point(21, 64);
            this.hacLabel25.Name = "hacLabel25";
            this.hacLabel25.Size = new System.Drawing.Size(44, 14);
            this.hacLabel25.TabIndex = 328;
            this.hacLabel25.Text = "Local:";
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOK});
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.PesquisarVisivel = false;
            this.tspCommand.SairVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(547, 25);
            this.tspCommand.TabIndex = 330;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // tsbOK
            // 
            this.tsbOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOK.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.tsbOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOK.Name = "tsbOK";
            this.tsbOK.Size = new System.Drawing.Size(31, 22);
            this.tsbOK.Text = "OK";
            this.tsbOK.Click += new System.EventHandler(this.tsbOK_Click);
            // 
            // btnExcluirProdutoItem
            // 
            this.btnExcluirProdutoItem.AlterarStatus = true;
            this.btnExcluirProdutoItem.BackColor = System.Drawing.Color.Transparent;
            this.btnExcluirProdutoItem.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.btnRemover;
            this.btnExcluirProdutoItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcluirProdutoItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluirProdutoItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnExcluirProdutoItem.FlatAppearance.BorderSize = 0;
            this.btnExcluirProdutoItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExcluirProdutoItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExcluirProdutoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirProdutoItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnExcluirProdutoItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExcluirProdutoItem.Location = new System.Drawing.Point(374, 63);
            this.btnExcluirProdutoItem.Name = "btnExcluirProdutoItem";
            this.btnExcluirProdutoItem.Size = new System.Drawing.Size(21, 20);
            this.btnExcluirProdutoItem.TabIndex = 334;
            this.btnExcluirProdutoItem.UseVisualStyleBackColor = false;
            this.btnExcluirProdutoItem.Click += new System.EventHandler(this.btnExcluirProdutoItem_Click);
            // 
            // btnAdicionarProdutoItem
            // 
            this.btnAdicionarProdutoItem.AlterarStatus = true;
            this.btnAdicionarProdutoItem.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarProdutoItem.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.edit_add_p;
            this.btnAdicionarProdutoItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionarProdutoItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarProdutoItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnAdicionarProdutoItem.FlatAppearance.BorderSize = 0;
            this.btnAdicionarProdutoItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarProdutoItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarProdutoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarProdutoItem.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAdicionarProdutoItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdicionarProdutoItem.Location = new System.Drawing.Point(344, 63);
            this.btnAdicionarProdutoItem.Name = "btnAdicionarProdutoItem";
            this.btnAdicionarProdutoItem.Size = new System.Drawing.Size(21, 20);
            this.btnAdicionarProdutoItem.TabIndex = 333;
            this.btnAdicionarProdutoItem.UseVisualStyleBackColor = false;
            this.btnAdicionarProdutoItem.Click += new System.EventHandler(this.btnAdicionarProdutoItem_Click);
            // 
            // dgvPesquisaUnidadeLocal
            // 
            this.dgvPesquisaUnidadeLocal.AllowUserToAddRows = false;
            this.dgvPesquisaUnidadeLocal.AllowUserToDeleteRows = false;
            this.dgvPesquisaUnidadeLocal.AllowUserToResizeRows = false;
            this.dgvPesquisaUnidadeLocal.AlterarStatus = false;
            this.dgvPesquisaUnidadeLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaUnidadeLocal.BackgroundColor = System.Drawing.Color.White;
            this.dgvPesquisaUnidadeLocal.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaUnidadeLocal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaUnidadeLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaUnidadeLocal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtUnidade,
            this.colIdtLocal,
            this.colUnidade,
            this.colLocal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPesquisaUnidadeLocal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPesquisaUnidadeLocal.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaUnidadeLocal.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaUnidadeLocal.GridPesquisa = false;
            this.dgvPesquisaUnidadeLocal.Limpar = false;
            this.dgvPesquisaUnidadeLocal.Location = new System.Drawing.Point(12, 97);
            this.dgvPesquisaUnidadeLocal.Name = "dgvPesquisaUnidadeLocal";
            this.dgvPesquisaUnidadeLocal.NaoAjustarEdicao = false;
            this.dgvPesquisaUnidadeLocal.Obrigatorio = false;
            this.dgvPesquisaUnidadeLocal.ObrigatorioMensagem = null;
            this.dgvPesquisaUnidadeLocal.PreValidacaoMensagem = null;
            this.dgvPesquisaUnidadeLocal.PreValidado = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaUnidadeLocal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPesquisaUnidadeLocal.RowHeadersVisible = false;
            this.dgvPesquisaUnidadeLocal.RowHeadersWidth = 25;
            this.dgvPesquisaUnidadeLocal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaUnidadeLocal.Size = new System.Drawing.Size(523, 274);
            this.dgvPesquisaUnidadeLocal.TabIndex = 335;
            // 
            // colIdtUnidade
            // 
            this.colIdtUnidade.HeaderText = "";
            this.colIdtUnidade.Name = "colIdtUnidade";
            this.colIdtUnidade.Visible = false;
            this.colIdtUnidade.Width = 60;
            // 
            // colIdtLocal
            // 
            this.colIdtLocal.HeaderText = "";
            this.colIdtLocal.Name = "colIdtLocal";
            this.colIdtLocal.Visible = false;
            // 
            // colUnidade
            // 
            this.colUnidade.HeaderText = "Unidade";
            this.colUnidade.Name = "colUnidade";
            this.colUnidade.Width = 250;
            // 
            // colLocal
            // 
            this.colLocal.HeaderText = "Local";
            this.colLocal.Name = "colLocal";
            this.colLocal.Width = 250;
            // 
            // FrmReplicarUnidadesLocais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 383);
            this.ControlBox = false;
            this.Controls.Add(this.dgvPesquisaUnidadeLocal);
            this.Controls.Add(this.btnExcluirProdutoItem);
            this.Controls.Add(this.btnAdicionarProdutoItem);
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.cboLocal);
            this.Controls.Add(this.cboUnidade);
            this.Controls.Add(this.hacLabel19);
            this.Controls.Add(this.hacLabel25);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReplicarUnidadesLocais";
            this.ShowInTaskbar = false;
            this.Text = "FrmReplicarUnidadesLocais";
            this.Load += new System.EventHandler(this.FrmReplicarUnidadesLocais_Load);
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaUnidadeLocal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacCmbLocal cboLocal;
        private HacCmbUnidade cboUnidade;
        private HacLabel hacLabel19;
        private HacLabel hacLabel25;
        private HacToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton tsbOK;
        private HacButton btnExcluirProdutoItem;
        private HacButton btnAdicionarProdutoItem;
        private HacDataGridView dgvPesquisaUnidadeLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocal;
    }
}