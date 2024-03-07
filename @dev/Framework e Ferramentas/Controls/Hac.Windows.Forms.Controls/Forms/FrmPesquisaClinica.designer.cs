namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaClinica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaClinica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescricaoClinica = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblDescricaoClinica = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPesquisaClinica = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.Idt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaClinica)).BeginInit();
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
            this.tspCommand.Size = new System.Drawing.Size(546, 28);
            this.tspCommand.TabIndex = 0;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescricaoClinica);
            this.groupBox1.Controls.Add(this.lblDescricaoClinica);
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtDescricaoClinica
            // 
            this.txtDescricaoClinica.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoClinica.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoClinica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoClinica.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoClinica.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoClinica.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoClinica.Limpar = true;
            this.txtDescricaoClinica.Location = new System.Drawing.Point(142, 19);
            this.txtDescricaoClinica.Name = "txtDescricaoClinica";
            this.txtDescricaoClinica.NaoAjustarEdicao = false;
            this.txtDescricaoClinica.Obrigatorio = false;
            this.txtDescricaoClinica.ObrigatorioMensagem = null;
            this.txtDescricaoClinica.PreValidacaoMensagem = null;
            this.txtDescricaoClinica.PreValidado = false;
            this.txtDescricaoClinica.SelectAllOnFocus = false;
            this.txtDescricaoClinica.Size = new System.Drawing.Size(388, 18);
            this.txtDescricaoClinica.TabIndex = 1;
            this.txtDescricaoClinica.TextChanged += new System.EventHandler(this.txtNomeClinica_TextChanged);
            // 
            // lblDescricaoClinica
            // 
            this.lblDescricaoClinica.AutoSize = true;
            this.lblDescricaoClinica.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoClinica.Location = new System.Drawing.Point(7, 22);
            this.lblDescricaoClinica.Name = "lblDescricaoClinica";
            this.lblDescricaoClinica.Size = new System.Drawing.Size(116, 14);
            this.lblDescricaoClinica.TabIndex = 0;
            this.lblDescricaoClinica.Text = "Descrição Clínica:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPesquisaClinica);
            this.groupBox2.Location = new System.Drawing.Point(5, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 363);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dgvPesquisaClinica
            // 
            this.dgvPesquisaClinica.AllowUserToAddRows = false;
            this.dgvPesquisaClinica.AllowUserToDeleteRows = false;
            this.dgvPesquisaClinica.AllowUserToResizeRows = false;
            this.dgvPesquisaClinica.AlterarStatus = false;
            this.dgvPesquisaClinica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaClinica.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaClinica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaClinica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaClinica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idt,
            this.Codigo,
            this.Descricao});
            this.dgvPesquisaClinica.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaClinica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPesquisaClinica.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaClinica.GridPesquisa = false;
            this.dgvPesquisaClinica.Limpar = false;
            this.dgvPesquisaClinica.Location = new System.Drawing.Point(6, 12);
            this.dgvPesquisaClinica.MultiSelect = false;
            this.dgvPesquisaClinica.Name = "dgvPesquisaClinica";
            this.dgvPesquisaClinica.NaoAjustarEdicao = false;
            this.dgvPesquisaClinica.Obrigatorio = false;
            this.dgvPesquisaClinica.ObrigatorioMensagem = null;
            this.dgvPesquisaClinica.PreValidacaoMensagem = null;
            this.dgvPesquisaClinica.PreValidado = false;
            this.dgvPesquisaClinica.ReadOnly = true;
            this.dgvPesquisaClinica.RowHeadersVisible = false;
            this.dgvPesquisaClinica.RowHeadersWidth = 25;
            this.dgvPesquisaClinica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaClinica.Size = new System.Drawing.Size(525, 345);
            this.dgvPesquisaClinica.TabIndex = 0;
            this.dgvPesquisaClinica.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaClinica_CellDoubleClick);
            // 
            // Idt
            // 
            this.Idt.HeaderText = "Idt";
            this.Idt.Name = "Idt";
            this.Idt.ReadOnly = true;
            this.Idt.Visible = false;
            this.Idt.Width = 60;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 380;
            // 
            // FrmPesquisaClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tspCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaClinica";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaClinica";
            this.Load += new System.EventHandler(this.FrmPesquisaClinica_Load);
            this.Activated += new System.EventHandler(this.FrmPesquisaClinica_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaClinica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoClinica;
        private Hac.Windows.Forms.Controls.HacLabel lblDescricaoClinica;
        private System.Windows.Forms.GroupBox groupBox2;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaClinica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}