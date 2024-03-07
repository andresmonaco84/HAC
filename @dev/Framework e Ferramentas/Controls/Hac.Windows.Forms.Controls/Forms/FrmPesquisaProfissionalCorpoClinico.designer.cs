namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaProfissionalCorpoClinico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaProfissionalCorpoClinico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.txtNomeProfissionalCorpoClinico = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblProfissionalSolicitante = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.dgvPesquisaProfissinalCorpoClinico = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.TipoConselho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UFConselho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoConselho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProfissional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProfissinalCorpoClinico)).BeginInit();
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
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(501, 28);
            this.tspCommand.TabIndex = 151;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // txtNomeProfissionalCorpoClinico
            // 
            this.txtNomeProfissionalCorpoClinico.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeProfissionalCorpoClinico.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeProfissionalCorpoClinico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProfissionalCorpoClinico.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNomeProfissionalCorpoClinico.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeProfissionalCorpoClinico.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProfissionalCorpoClinico.Limpar = true;
            this.txtNomeProfissionalCorpoClinico.Location = new System.Drawing.Point(141, 42);
            this.txtNomeProfissionalCorpoClinico.Name = "txtNomeProfissionalCorpoClinico";
            this.txtNomeProfissionalCorpoClinico.NaoAjustarEdicao = false;
            this.txtNomeProfissionalCorpoClinico.Obrigatorio = false;
            this.txtNomeProfissionalCorpoClinico.ObrigatorioMensagem = null;
            this.txtNomeProfissionalCorpoClinico.PreValidacaoMensagem = null;
            this.txtNomeProfissionalCorpoClinico.PreValidado = false;
            this.txtNomeProfissionalCorpoClinico.SelectAllOnFocus = false;
            this.txtNomeProfissionalCorpoClinico.Size = new System.Drawing.Size(348, 18);
            this.txtNomeProfissionalCorpoClinico.TabIndex = 152;
            this.txtNomeProfissionalCorpoClinico.TextChanged += new System.EventHandler(this.txtNomeProfissionalCorpoClinico_TextChanged);
            this.txtNomeProfissionalCorpoClinico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeProfissionalCorpoClinico_KeyPress);
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
            // dgvPesquisaProfissinalCorpoClinico
            // 
            this.dgvPesquisaProfissinalCorpoClinico.AllowUserToAddRows = false;
            this.dgvPesquisaProfissinalCorpoClinico.AllowUserToDeleteRows = false;
            this.dgvPesquisaProfissinalCorpoClinico.AlterarStatus = false;
            this.dgvPesquisaProfissinalCorpoClinico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaProfissinalCorpoClinico.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaProfissinalCorpoClinico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaProfissinalCorpoClinico.ColumnHeadersHeight = 21;
            this.dgvPesquisaProfissinalCorpoClinico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPesquisaProfissinalCorpoClinico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoConselho,
            this.UFConselho,
            this.CodigoConselho,
            this.NomeProfissional});
            this.dgvPesquisaProfissinalCorpoClinico.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaProfissinalCorpoClinico.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaProfissinalCorpoClinico.GridPesquisa = false;
            this.dgvPesquisaProfissinalCorpoClinico.Limpar = false;
            this.dgvPesquisaProfissinalCorpoClinico.Location = new System.Drawing.Point(12, 74);
            this.dgvPesquisaProfissinalCorpoClinico.MultiSelect = false;
            this.dgvPesquisaProfissinalCorpoClinico.Name = "dgvPesquisaProfissinalCorpoClinico";
            this.dgvPesquisaProfissinalCorpoClinico.NaoAjustarEdicao = false;
            this.dgvPesquisaProfissinalCorpoClinico.Obrigatorio = false;
            this.dgvPesquisaProfissinalCorpoClinico.ObrigatorioMensagem = null;
            this.dgvPesquisaProfissinalCorpoClinico.PreValidacaoMensagem = null;
            this.dgvPesquisaProfissinalCorpoClinico.PreValidado = false;
            this.dgvPesquisaProfissinalCorpoClinico.ReadOnly = true;
            this.dgvPesquisaProfissinalCorpoClinico.RowHeadersVisible = false;
            this.dgvPesquisaProfissinalCorpoClinico.RowHeadersWidth = 25;
            this.dgvPesquisaProfissinalCorpoClinico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaProfissinalCorpoClinico.Size = new System.Drawing.Size(477, 387);
            this.dgvPesquisaProfissinalCorpoClinico.TabIndex = 154;
            this.dgvPesquisaProfissinalCorpoClinico.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaProfissinalSolicitante_CellDoubleClick);
            this.dgvPesquisaProfissinalCorpoClinico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPesquisaProfissinalCorpoClinico_KeyDown);
            // 
            // TipoConselho
            // 
            this.TipoConselho.HeaderText = "Tipo";
            this.TipoConselho.Name = "TipoConselho";
            this.TipoConselho.ReadOnly = true;
            this.TipoConselho.Width = 40;
            // 
            // UFConselho
            // 
            this.UFConselho.HeaderText = "UF";
            this.UFConselho.Name = "UFConselho";
            this.UFConselho.ReadOnly = true;
            this.UFConselho.Width = 40;
            // 
            // CodigoConselho
            // 
            this.CodigoConselho.HeaderText = "Conselho";
            this.CodigoConselho.Name = "CodigoConselho";
            this.CodigoConselho.ReadOnly = true;
            this.CodigoConselho.Width = 70;
            // 
            // NomeProfissional
            // 
            this.NomeProfissional.HeaderText = "Nome";
            this.NomeProfissional.Name = "NomeProfissional";
            this.NomeProfissional.ReadOnly = true;
            this.NomeProfissional.Width = 300;
            // 
            // FrmPesquisaProfissionalCorpoClinico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 473);
            this.ControlBox = false;
            this.Controls.Add(this.dgvPesquisaProfissinalCorpoClinico);
            this.Controls.Add(this.txtNomeProfissionalCorpoClinico);
            this.Controls.Add(this.lblProfissionalSolicitante);
            this.Controls.Add(this.tspCommand);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaProfissionalCorpoClinico";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaProfissionalSolicitante";
            this.Load += new System.EventHandler(this.FrmPesquisaProfissionalCorpoClinico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProfissinalCorpoClinico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacTextBox txtNomeProfissionalCorpoClinico;
        private Hac.Windows.Forms.Controls.HacLabel lblProfissionalSolicitante;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaProfissinalCorpoClinico;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoConselho;
        private System.Windows.Forms.DataGridViewTextBoxColumn UFConselho;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoConselho;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProfissional;
    }
}