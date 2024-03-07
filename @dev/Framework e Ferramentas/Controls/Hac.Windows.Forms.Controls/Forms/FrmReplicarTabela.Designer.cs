namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmReplicarTabela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReplicarTabela));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.tsbOK = new System.Windows.Forms.ToolStripButton();
            this.dgvPesquisa = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.lblItem = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.colSeleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Idt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).BeginInit();
            this.SuspendLayout();
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
            this.tspCommand.Size = new System.Drawing.Size(488, 25);
            this.tspCommand.TabIndex = 191;
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
            // dgvPesquisa
            // 
            this.dgvPesquisa.AllowUserToAddRows = false;
            this.dgvPesquisa.AllowUserToDeleteRows = false;
            this.dgvPesquisa.AllowUserToResizeRows = false;
            this.dgvPesquisa.AlterarStatus = false;
            this.dgvPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisa.BackgroundColor = System.Drawing.Color.White;
            this.dgvPesquisa.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleciona,
            this.Idt,
            this.Descricao});
            this.dgvPesquisa.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisa.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisa.GridPesquisa = false;
            this.dgvPesquisa.Limpar = false;
            this.dgvPesquisa.Location = new System.Drawing.Point(6, 58);
            this.dgvPesquisa.MultiSelect = false;
            this.dgvPesquisa.Name = "dgvPesquisa";
            this.dgvPesquisa.NaoAjustarEdicao = false;
            this.dgvPesquisa.Obrigatorio = false;
            this.dgvPesquisa.ObrigatorioMensagem = null;
            this.dgvPesquisa.PreValidacaoMensagem = null;
            this.dgvPesquisa.PreValidado = false;
            this.dgvPesquisa.RowHeadersVisible = false;
            this.dgvPesquisa.RowHeadersWidth = 25;
            this.dgvPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPesquisa.Size = new System.Drawing.Size(454, 315);
            this.dgvPesquisa.TabIndex = 192;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(16, 35);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(0, 14);
            this.lblItem.TabIndex = 193;
            // 
            // colSeleciona
            // 
            this.colSeleciona.HeaderText = "";
            this.colSeleciona.Name = "colSeleciona";
            this.colSeleciona.Width = 30;
            // 
            // Idt
            // 
            this.Idt.HeaderText = "Código";
            this.Idt.Name = "Idt";
            this.Idt.Visible = false;
            this.Idt.Width = 60;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 380;
            // 
            // FrmReplicarTabela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 388);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.dgvPesquisa);
            this.Name = "FrmReplicarTabela";
            this.Text = "FrmReplicarTabela";
            this.Load += new System.EventHandler(this.FrmReplicarTabela_Load);
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton tsbOK;
        private HacDataGridView dgvPesquisa;
        private HacLabel lblItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}