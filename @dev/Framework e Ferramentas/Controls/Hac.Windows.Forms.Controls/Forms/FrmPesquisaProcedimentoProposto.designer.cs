namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaProcedimentoProposto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaProcedimentoProposto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.txtNomeProcedimentoProposto = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblProcedimentoProposto = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.dgvPesquisaProcedimentoProposto = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProcedimentoProposto)).BeginInit();
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
            // txtNomeProcedimentoProposto
            // 
            this.txtNomeProcedimentoProposto.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeProcedimentoProposto.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeProcedimentoProposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProcedimentoProposto.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNomeProcedimentoProposto.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeProcedimentoProposto.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProcedimentoProposto.Limpar = true;
            this.txtNomeProcedimentoProposto.Location = new System.Drawing.Point(116, 42);
            this.txtNomeProcedimentoProposto.Name = "txtNomeProcedimentoProposto";
            this.txtNomeProcedimentoProposto.NaoAjustarEdicao = false;
            this.txtNomeProcedimentoProposto.Obrigatorio = false;
            this.txtNomeProcedimentoProposto.ObrigatorioMensagem = null;
            this.txtNomeProcedimentoProposto.PreValidacaoMensagem = null;
            this.txtNomeProcedimentoProposto.PreValidado = false;
            this.txtNomeProcedimentoProposto.SelectAllOnFocus = false;
            this.txtNomeProcedimentoProposto.Size = new System.Drawing.Size(373, 18);
            this.txtNomeProcedimentoProposto.TabIndex = 152;
            this.txtNomeProcedimentoProposto.TextChanged += new System.EventHandler(this.txtNomeProcedimentoProposto_TextChanged);
            // 
            // lblProcedimentoProposto
            // 
            this.lblProcedimentoProposto.AutoSize = true;
            this.lblProcedimentoProposto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcedimentoProposto.Location = new System.Drawing.Point(11, 43);
            this.lblProcedimentoProposto.Name = "lblProcedimentoProposto";
            this.lblProcedimentoProposto.Size = new System.Drawing.Size(98, 14);
            this.lblProcedimentoProposto.TabIndex = 153;
            this.lblProcedimentoProposto.Text = "Procedimento:";
            // 
            // dgvPesquisaProcedimentoProposto
            // 
            this.dgvPesquisaProcedimentoProposto.AllowUserToAddRows = false;
            this.dgvPesquisaProcedimentoProposto.AllowUserToDeleteRows = false;
            this.dgvPesquisaProcedimentoProposto.AllowUserToResizeRows = false;
            this.dgvPesquisaProcedimentoProposto.AlterarStatus = false;
            this.dgvPesquisaProcedimentoProposto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaProcedimentoProposto.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaProcedimentoProposto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaProcedimentoProposto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaProcedimentoProposto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descricao});
            this.dgvPesquisaProcedimentoProposto.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaProcedimentoProposto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPesquisaProcedimentoProposto.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaProcedimentoProposto.GridPesquisa = false;
            this.dgvPesquisaProcedimentoProposto.Limpar = false;
            this.dgvPesquisaProcedimentoProposto.Location = new System.Drawing.Point(12, 74);
            this.dgvPesquisaProcedimentoProposto.MultiSelect = false;
            this.dgvPesquisaProcedimentoProposto.Name = "dgvPesquisaProcedimentoProposto";
            this.dgvPesquisaProcedimentoProposto.NaoAjustarEdicao = false;
            this.dgvPesquisaProcedimentoProposto.Obrigatorio = false;
            this.dgvPesquisaProcedimentoProposto.ObrigatorioMensagem = null;
            this.dgvPesquisaProcedimentoProposto.PreValidacaoMensagem = null;
            this.dgvPesquisaProcedimentoProposto.PreValidado = false;
            this.dgvPesquisaProcedimentoProposto.ReadOnly = true;
            this.dgvPesquisaProcedimentoProposto.RowHeadersVisible = false;
            this.dgvPesquisaProcedimentoProposto.RowHeadersWidth = 25;
            this.dgvPesquisaProcedimentoProposto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaProcedimentoProposto.Size = new System.Drawing.Size(477, 387);
            this.dgvPesquisaProcedimentoProposto.TabIndex = 154;
            this.dgvPesquisaProcedimentoProposto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaProcedimentoProposto_CellDoubleClick);
            this.dgvPesquisaProcedimentoProposto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPesquisaProcedimentoProposto_KeyDown);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 60;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 380;
            // 
            // FrmPesquisaProcedimentoProposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 473);
            this.ControlBox = false;
            this.Controls.Add(this.dgvPesquisaProcedimentoProposto);
            this.Controls.Add(this.txtNomeProcedimentoProposto);
            this.Controls.Add(this.lblProcedimentoProposto);
            this.Controls.Add(this.tspCommand);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaProcedimentoProposto";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaProcedimentoProposto";
            this.Load += new System.EventHandler(this.FrmPesquisaProcedimentoProposto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProcedimentoProposto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacTextBox txtNomeProcedimentoProposto;
        private Hac.Windows.Forms.Controls.HacLabel lblProcedimentoProposto;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaProcedimentoProposto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}