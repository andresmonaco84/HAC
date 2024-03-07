namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmReplicarTipoProcedimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReplicarTipoProcedimento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.tsbOK = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSelTodos = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.dgvPesquisa = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colTabelas = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Idt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tspCommand.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tspCommand.Size = new System.Drawing.Size(453, 25);
            this.tspCommand.TabIndex = 154;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSelTodos);
            this.groupBox2.Controls.Add(this.dgvPesquisa);
            this.groupBox2.Location = new System.Drawing.Point(6, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 351);
            this.groupBox2.TabIndex = 155;
            this.groupBox2.TabStop = false;
            // 
            // chkSelTodos
            // 
            this.chkSelTodos.AutoSize = true;
            this.chkSelTodos.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.chkSelTodos.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.chkSelTodos.Limpar = true;
            this.chkSelTodos.Location = new System.Drawing.Point(16, 17);
            this.chkSelTodos.Name = "chkSelTodos";
            this.chkSelTodos.NaoAjustarEdicao = true;
            this.chkSelTodos.Obrigatorio = false;
            this.chkSelTodos.ObrigatorioMensagem = null;
            this.chkSelTodos.PreValidacaoMensagem = null;
            this.chkSelTodos.PreValidado = false;
            this.chkSelTodos.Size = new System.Drawing.Size(15, 14);
            this.chkSelTodos.TabIndex = 190;
            this.chkSelTodos.UseVisualStyleBackColor = true;
            this.chkSelTodos.Visible = false;
            this.chkSelTodos.CheckedChanged += new System.EventHandler(this.chkSelTodos_CheckedChanged);
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
            this.colTabelas,
            this.Idt,
            this.Descricao,
            this.colSeleciona});
            this.dgvPesquisa.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisa.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisa.GridPesquisa = false;
            this.dgvPesquisa.Limpar = false;
            this.dgvPesquisa.Location = new System.Drawing.Point(6, 12);
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
            this.dgvPesquisa.Size = new System.Drawing.Size(425, 335);
            this.dgvPesquisa.TabIndex = 155;
            this.dgvPesquisa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisa_CellContentClick);
            // 
            // colTabelas
            // 
            this.colTabelas.HeaderText = "";
            this.colTabelas.Name = "colTabelas";
            this.colTabelas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTabelas.Text = "Tabelas";
            this.colTabelas.UseColumnTextForButtonValue = true;
            this.colTabelas.Width = 80;
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
            this.Descricao.Width = 300;
            // 
            // colSeleciona
            // 
            this.colSeleciona.HeaderText = "";
            this.colSeleciona.Name = "colSeleciona";
            this.colSeleciona.ReadOnly = true;
            this.colSeleciona.Width = 30;
            // 
            // FrmReplicarTipoProcedimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 390);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tspCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReplicarTipoProcedimento";
            this.ShowInTaskbar = false;
            this.Text = "FrmReplicarTipoProcedimento";
            this.Load += new System.EventHandler(this.FrmReplicarTipoProcedimento_Load);
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton tsbOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private HacCheckBox chkSelTodos;
        private HacDataGridView dgvPesquisa;
        private System.Windows.Forms.DataGridViewButtonColumn colTabelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleciona;

    }
}