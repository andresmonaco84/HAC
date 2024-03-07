namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmReplicarSubPlanos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReplicarSubPlanos));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSelTodos = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.dgvPesquisaSubPlano = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.tsbOK = new System.Windows.Forms.ToolStripButton();
            this.colSeleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdtSubPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaSubPlano)).BeginInit();
            this.tspCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSelTodos);
            this.groupBox2.Controls.Add(this.dgvPesquisaSubPlano);
            this.groupBox2.Location = new System.Drawing.Point(5, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 407);
            this.groupBox2.TabIndex = 48;
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
            // 
            // dgvPesquisaSubPlano
            // 
            this.dgvPesquisaSubPlano.AllowUserToAddRows = false;
            this.dgvPesquisaSubPlano.AllowUserToDeleteRows = false;
            this.dgvPesquisaSubPlano.AllowUserToResizeRows = false;
            this.dgvPesquisaSubPlano.AlterarStatus = false;
            this.dgvPesquisaSubPlano.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaSubPlano.BackgroundColor = System.Drawing.Color.White;
            this.dgvPesquisaSubPlano.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaSubPlano.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaSubPlano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaSubPlano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleciona,
            this.IdtSubPlano,
            this.Codigo,
            this.Descricao});
            this.dgvPesquisaSubPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaSubPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaSubPlano.GridPesquisa = false;
            this.dgvPesquisaSubPlano.Limpar = false;
            this.dgvPesquisaSubPlano.Location = new System.Drawing.Point(6, 12);
            this.dgvPesquisaSubPlano.MultiSelect = false;
            this.dgvPesquisaSubPlano.Name = "dgvPesquisaSubPlano";
            this.dgvPesquisaSubPlano.NaoAjustarEdicao = false;
            this.dgvPesquisaSubPlano.Obrigatorio = false;
            this.dgvPesquisaSubPlano.ObrigatorioMensagem = null;
            this.dgvPesquisaSubPlano.PreValidacaoMensagem = null;
            this.dgvPesquisaSubPlano.PreValidado = false;
            this.dgvPesquisaSubPlano.RowHeadersVisible = false;
            this.dgvPesquisaSubPlano.RowHeadersWidth = 25;
            this.dgvPesquisaSubPlano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaSubPlano.Size = new System.Drawing.Size(563, 389);
            this.dgvPesquisaSubPlano.TabIndex = 155;
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
            this.tspCommand.Size = new System.Drawing.Size(588, 25);
            this.tspCommand.TabIndex = 153;
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
            // 
            // colSeleciona
            // 
            this.colSeleciona.HeaderText = "";
            this.colSeleciona.Name = "colSeleciona";
            this.colSeleciona.Width = 30;
            // 
            // IdtSubPlano
            // 
            this.IdtSubPlano.HeaderText = "Código";
            this.IdtSubPlano.Name = "IdtSubPlano";
            this.IdtSubPlano.Width = 60;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Prestador";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 380;
            // 
            // FrmReplicarSubPlanos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 448);
            this.ControlBox = false;
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReplicarSubPlanos";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaSubPlano";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaSubPlano)).EndInit();
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaSubPlano;
        private HacToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton tsbOK;
        private HacCheckBox chkSelTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdtSubPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}