namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaProfissionalSolicitante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaProfissionalSolicitante));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.txtNomeProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.dgvPesquisaProfissinalSolicitante = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.btnPesquisarProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.TipoConselho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UFConselho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoConselho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProfissional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProfissinalSolicitante)).BeginInit();
            this.SuspendLayout();
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.PesquisarVisivel = false;
            this.tspCommand.SalvarHabilitado = false;
            this.tspCommand.SalvarText = "Salvar";
            this.tspCommand.SalvarTextTamanho = 70;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(656, 28);
            this.tspCommand.TabIndex = 151;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // txtNomeProfissionalSolicitante
            // 
            this.txtNomeProfissionalSolicitante.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeProfissionalSolicitante.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeProfissionalSolicitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProfissionalSolicitante.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNomeProfissionalSolicitante.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProfissionalSolicitante.Limpar = true;
            this.txtNomeProfissionalSolicitante.Location = new System.Drawing.Point(141, 42);
            this.txtNomeProfissionalSolicitante.Name = "txtNomeProfissionalSolicitante";
            this.txtNomeProfissionalSolicitante.NaoAjustarEdicao = false;
            this.txtNomeProfissionalSolicitante.Obrigatorio = false;
            this.txtNomeProfissionalSolicitante.ObrigatorioMensagem = null;
            this.txtNomeProfissionalSolicitante.PreValidacaoMensagem = null;
            this.txtNomeProfissionalSolicitante.PreValidado = false;
            this.txtNomeProfissionalSolicitante.SelectAllOnFocus = false;
            this.txtNomeProfissionalSolicitante.Size = new System.Drawing.Size(348, 18);
            this.txtNomeProfissionalSolicitante.TabIndex = 152;
            this.txtNomeProfissionalSolicitante.TextChanged += new System.EventHandler(this.txtNomeProfissionalSolicitante_TextChanged);
            // 
            // lblProfissionalSolicitante
            // 
            this.lblProfissionalSolicitante.AutoSize = true;
            this.lblProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfissionalSolicitante.Location = new System.Drawing.Point(11, 43);
            this.lblProfissionalSolicitante.Name = "lblProfissionalSolicitante";
            this.lblProfissionalSolicitante.Size = new System.Drawing.Size(124, 14);
            this.lblProfissionalSolicitante.TabIndex = 153;
            this.lblProfissionalSolicitante.Text = "Nome Profissional:";
            // 
            // dgvPesquisaProfissinalSolicitante
            // 
            this.dgvPesquisaProfissinalSolicitante.AllowUserToAddRows = false;
            this.dgvPesquisaProfissinalSolicitante.AllowUserToDeleteRows = false;
            this.dgvPesquisaProfissinalSolicitante.AllowUserToResizeRows = false;
            this.dgvPesquisaProfissinalSolicitante.AlterarStatus = false;
            this.dgvPesquisaProfissinalSolicitante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaProfissinalSolicitante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPesquisaProfissinalSolicitante.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaProfissinalSolicitante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaProfissinalSolicitante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaProfissinalSolicitante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoConselho,
            this.UFConselho,
            this.CodigoConselho,
            this.NomeProfissional});
            this.dgvPesquisaProfissinalSolicitante.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaProfissinalSolicitante.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaProfissinalSolicitante.GridPesquisa = false;
            this.dgvPesquisaProfissinalSolicitante.Limpar = false;
            this.dgvPesquisaProfissinalSolicitante.Location = new System.Drawing.Point(12, 74);
            this.dgvPesquisaProfissinalSolicitante.MultiSelect = false;
            this.dgvPesquisaProfissinalSolicitante.Name = "dgvPesquisaProfissinalSolicitante";
            this.dgvPesquisaProfissinalSolicitante.NaoAjustarEdicao = false;
            this.dgvPesquisaProfissinalSolicitante.Obrigatorio = false;
            this.dgvPesquisaProfissinalSolicitante.ObrigatorioMensagem = null;
            this.dgvPesquisaProfissinalSolicitante.PreValidacaoMensagem = null;
            this.dgvPesquisaProfissinalSolicitante.PreValidado = false;
            this.dgvPesquisaProfissinalSolicitante.ReadOnly = true;
            this.dgvPesquisaProfissinalSolicitante.RowHeadersVisible = false;
            this.dgvPesquisaProfissinalSolicitante.RowHeadersWidth = 25;
            this.dgvPesquisaProfissinalSolicitante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaProfissinalSolicitante.Size = new System.Drawing.Size(632, 387);
            this.dgvPesquisaProfissinalSolicitante.TabIndex = 154;
            this.dgvPesquisaProfissinalSolicitante.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaProfissinalSolicitante_CellDoubleClick);
            // 
            // btnPesquisarProfissionalSolicitante
            // 
            this.btnPesquisarProfissionalSolicitante.AlterarStatus = true;
            this.btnPesquisarProfissionalSolicitante.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalSolicitante.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarProfissionalSolicitante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPesquisarProfissionalSolicitante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.BorderSize = 0;
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalSolicitante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarProfissionalSolicitante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarProfissionalSolicitante.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarProfissionalSolicitante.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarProfissionalSolicitante.Location = new System.Drawing.Point(490, 36);
            this.btnPesquisarProfissionalSolicitante.Name = "btnPesquisarProfissionalSolicitante";
            this.btnPesquisarProfissionalSolicitante.Size = new System.Drawing.Size(34, 30);
            this.btnPesquisarProfissionalSolicitante.TabIndex = 155;
            this.btnPesquisarProfissionalSolicitante.UseVisualStyleBackColor = false;
            this.btnPesquisarProfissionalSolicitante.Click += new System.EventHandler(this.btnPesquisarProfissionalSolicitante_Click);
            // 
            // TipoConselho
            // 
            this.TipoConselho.HeaderText = "Tipo Conselho";
            this.TipoConselho.Name = "TipoConselho";
            this.TipoConselho.ReadOnly = true;
            this.TipoConselho.Width = 111;
            // 
            // UFConselho
            // 
            this.UFConselho.HeaderText = "UF";
            this.UFConselho.Name = "UFConselho";
            this.UFConselho.ReadOnly = true;
            this.UFConselho.Width = 48;
            // 
            // CodigoConselho
            // 
            this.CodigoConselho.HeaderText = "Código Conselho";
            this.CodigoConselho.Name = "CodigoConselho";
            this.CodigoConselho.ReadOnly = true;
            this.CodigoConselho.Width = 127;
            // 
            // NomeProfissional
            // 
            this.NomeProfissional.HeaderText = "Nome";
            this.NomeProfissional.Name = "NomeProfissional";
            this.NomeProfissional.ReadOnly = true;
            this.NomeProfissional.Width = 68;
            // 
            // FrmPesquisaProfissionalSolicitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 473);
            this.ControlBox = false;
            this.Controls.Add(this.btnPesquisarProfissionalSolicitante);
            this.Controls.Add(this.dgvPesquisaProfissinalSolicitante);
            this.Controls.Add(this.txtNomeProfissionalSolicitante);
            this.Controls.Add(this.lblProfissionalSolicitante);
            this.Controls.Add(this.tspCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaProfissionalSolicitante";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaProfissionalSolicitante";
            this.Load += new System.EventHandler(this.FrmPesquisaProfissionalSolicitante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProfissinalSolicitante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacTextBox txtNomeProfissionalSolicitante;
        private Hac.Windows.Forms.Controls.HacLabel lblProfissionalSolicitante;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaProfissinalSolicitante;
        private HacButton btnPesquisarProfissionalSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoConselho;
        private System.Windows.Forms.DataGridViewTextBoxColumn UFConselho;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoConselho;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProfissional;
    }
}