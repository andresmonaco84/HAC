namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmLiberaAtendimento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLiberaAtendimento));
            this.txtAtd = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgAtendimento = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnLiberar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.cbAberto = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.colAtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAberto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlAberto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtendimento)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAtd
            // 
            this.txtAtd.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAtd.BackColor = System.Drawing.Color.Honeydew;
            this.txtAtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAtd.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtAtd.Enabled = false;
            this.txtAtd.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtAtd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAtd.Limpar = true;
            this.txtAtd.Location = new System.Drawing.Point(97, 37);
            this.txtAtd.MaxLength = 10;
            this.txtAtd.Name = "txtAtd";
            this.txtAtd.NaoAjustarEdicao = false;
            this.txtAtd.Obrigatorio = true;
            this.txtAtd.ObrigatorioMensagem = "Campo DE Obrigatório";
            this.txtAtd.PreValidacaoMensagem = null;
            this.txtAtd.PreValidado = false;
            this.txtAtd.SelectAllOnFocus = false;
            this.txtAtd.Size = new System.Drawing.Size(76, 21);
            this.txtAtd.TabIndex = 100;
            this.txtAtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAtd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAtd_KeyUp);
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(12, 40);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(79, 13);
            this.hacLabel4.TabIndex = 101;
            this.hacLabel4.Text = "Atendimento";
            // 
            // dtgAtendimento
            // 
            this.dtgAtendimento.AllowUserToAddRows = false;
            this.dtgAtendimento.AllowUserToDeleteRows = false;
            this.dtgAtendimento.AllowUserToOrderColumns = true;
            this.dtgAtendimento.AllowUserToResizeColumns = false;
            this.dtgAtendimento.AllowUserToResizeRows = false;
            this.dtgAtendimento.AlterarStatus = true;
            this.dtgAtendimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgAtendimento.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAtendimento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgAtendimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAtendimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAtd,
            this.colAberto,
            this.colData,
            this.colFlAberto});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAtendimento.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgAtendimento.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgAtendimento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgAtendimento.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgAtendimento.GridPesquisa = false;
            this.dtgAtendimento.Limpar = false;
            this.dtgAtendimento.Location = new System.Drawing.Point(12, 99);
            this.dtgAtendimento.Name = "dtgAtendimento";
            this.dtgAtendimento.NaoAjustarEdicao = true;
            this.dtgAtendimento.Obrigatorio = false;
            this.dtgAtendimento.ObrigatorioMensagem = null;
            this.dtgAtendimento.PreValidacaoMensagem = null;
            this.dtgAtendimento.PreValidado = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAtendimento.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgAtendimento.RowHeadersVisible = false;
            this.dtgAtendimento.RowHeadersWidth = 25;
            this.dtgAtendimento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAtendimento.Size = new System.Drawing.Size(325, 242);
            this.dtgAtendimento.TabIndex = 102;
            this.dtgAtendimento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAtendimento_CellClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "Excluir";
            this.dataGridViewImageColumn1.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.ToolTipText = "Excluir Linha";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // btnLiberar
            // 
            this.btnLiberar.AlterarStatus = true;
            this.btnLiberar.BackColor = System.Drawing.Color.White;
            this.btnLiberar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLiberar.BackgroundImage")));
            this.btnLiberar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLiberar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiberar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnLiberar.Location = new System.Drawing.Point(12, 64);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(325, 22);
            this.btnLiberar.TabIndex = 103;
            this.btnLiberar.Text = "Clique aqui p/ liberar Atendimento p/ ajuste imediato";
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Visible = false;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // cbAberto
            // 
            this.cbAberto.AutoSize = true;
            this.cbAberto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbAberto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cbAberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAberto.Limpar = false;
            this.cbAberto.Location = new System.Drawing.Point(179, 41);
            this.cbAberto.Name = "cbAberto";
            this.cbAberto.Obrigatorio = false;
            this.cbAberto.ObrigatorioMensagem = null;
            this.cbAberto.PreValidacaoMensagem = null;
            this.cbAberto.PreValidado = false;
            this.cbAberto.Size = new System.Drawing.Size(76, 17);
            this.cbAberto.TabIndex = 104;
            this.cbAberto.Text = "ABERTO";
            this.cbAberto.UseVisualStyleBackColor = true;
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
            this.tsHac.Size = new System.Drawing.Size(364, 28);
            this.tsHac.TabIndex = 105;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            // 
            // colAtd
            // 
            this.colAtd.DataPropertyName = "ATD_ATE_ID";
            this.colAtd.HeaderText = "Atendimento";
            this.colAtd.Name = "colAtd";
            this.colAtd.ReadOnly = true;
            this.colAtd.Width = 110;
            // 
            // colAberto
            // 
            this.colAberto.DataPropertyName = "FL_ABERTO";
            this.colAberto.HeaderText = "Aberto";
            this.colAberto.Name = "colAberto";
            this.colAberto.ReadOnly = true;
            this.colAberto.Width = 70;
            // 
            // colData
            // 
            this.colData.DataPropertyName = "ATD_DATA";
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 120;
            // 
            // colFlAberto
            // 
            this.colFlAberto.DataPropertyName = "ATD_FL_ABERTO";
            this.colFlAberto.HeaderText = "colFlAberto";
            this.colFlAberto.Name = "colFlAberto";
            this.colFlAberto.ReadOnly = true;
            this.colFlAberto.Visible = false;
            // 
            // FrmLiberaAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 349);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.cbAberto);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.dtgAtendimento);
            this.Controls.Add(this.txtAtd);
            this.Controls.Add(this.hacLabel4);
            this.Name = "FrmLiberaAtendimento";
            this.Text = "Libera Atendimento para Ajustes";
            this.Load += new System.EventHandler(this.FrmLiberaAtendimento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtendimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacTextBox txtAtd;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacDataGridView dtgAtendimento;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private SGS.Componentes.HacButton btnLiberar;
        private SGS.Componentes.HacCheckBox cbAberto;
        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAberto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlAberto;
    }
}