namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaPlano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaPlano));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescricaoPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblDescricaoPlano = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPesquisaPlano = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.IdtPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaPlano)).BeginInit();
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
            this.tspCommand.Size = new System.Drawing.Size(564, 28);
            this.tspCommand.TabIndex = 151;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescricaoPlano);
            this.groupBox1.Controls.Add(this.lblDescricaoPlano);
            this.groupBox1.Location = new System.Drawing.Point(6, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 49);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // txtDescricaoPlano
            // 
            this.txtDescricaoPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoPlano.Limpar = true;
            this.txtDescricaoPlano.Location = new System.Drawing.Point(135, 19);
            this.txtDescricaoPlano.Name = "txtDescricaoPlano";
            this.txtDescricaoPlano.NaoAjustarEdicao = false;
            this.txtDescricaoPlano.Obrigatorio = false;
            this.txtDescricaoPlano.ObrigatorioMensagem = null;
            this.txtDescricaoPlano.PreValidacaoMensagem = null;
            this.txtDescricaoPlano.PreValidado = false;
            this.txtDescricaoPlano.SelectAllOnFocus = false;
            this.txtDescricaoPlano.Size = new System.Drawing.Size(388, 18);
            this.txtDescricaoPlano.TabIndex = 46;
            this.txtDescricaoPlano.TextChanged += new System.EventHandler(this.txtNomePlano_TextChanged);
            // 
            // lblDescricaoPlano
            // 
            this.lblDescricaoPlano.AutoSize = true;
            this.lblDescricaoPlano.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoPlano.Location = new System.Drawing.Point(7, 22);
            this.lblDescricaoPlano.Name = "lblDescricaoPlano";
            this.lblDescricaoPlano.Size = new System.Drawing.Size(111, 14);
            this.lblDescricaoPlano.TabIndex = 0;
            this.lblDescricaoPlano.Text = "Descrição Plano:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPesquisaPlano);
            this.groupBox2.Location = new System.Drawing.Point(5, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 363);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // dgvPesquisaPlano
            // 
            this.dgvPesquisaPlano.AllowUserToAddRows = false;
            this.dgvPesquisaPlano.AllowUserToDeleteRows = false;
            this.dgvPesquisaPlano.AllowUserToResizeRows = false;
            this.dgvPesquisaPlano.AlterarStatus = false;
            this.dgvPesquisaPlano.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaPlano.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaPlano.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaPlano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaPlano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdtPlano,
            this.Codigo,
            this.Descricao,
            this.Categoria});
            this.dgvPesquisaPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaPlano.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPesquisaPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaPlano.GridPesquisa = false;
            this.dgvPesquisaPlano.Limpar = false;
            this.dgvPesquisaPlano.Location = new System.Drawing.Point(6, 12);
            this.dgvPesquisaPlano.MultiSelect = false;
            this.dgvPesquisaPlano.Name = "dgvPesquisaPlano";
            this.dgvPesquisaPlano.NaoAjustarEdicao = false;
            this.dgvPesquisaPlano.Obrigatorio = false;
            this.dgvPesquisaPlano.ObrigatorioMensagem = null;
            this.dgvPesquisaPlano.PreValidacaoMensagem = null;
            this.dgvPesquisaPlano.PreValidado = false;
            this.dgvPesquisaPlano.ReadOnly = true;
            this.dgvPesquisaPlano.RowHeadersVisible = false;
            this.dgvPesquisaPlano.RowHeadersWidth = 25;
            this.dgvPesquisaPlano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaPlano.Size = new System.Drawing.Size(542, 345);
            this.dgvPesquisaPlano.TabIndex = 155;
            this.dgvPesquisaPlano.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaPlano_CellDoubleClick);
            // 
            // IdtPlano
            // 
            this.IdtPlano.HeaderText = "Código";
            this.IdtPlano.Name = "IdtPlano";
            this.IdtPlano.ReadOnly = true;
            this.IdtPlano.Width = 60;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Prestador";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 320;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 70;
            // 
            // FrmPesquisaPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 448);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tspCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaPlano";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaPlano";
            this.Load += new System.EventHandler(this.FrmPesquisaPlano_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaPlano)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoPlano;
        private Hac.Windows.Forms.Controls.HacLabel lblDescricaoPlano;
        private System.Windows.Forms.GroupBox groupBox2;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdtPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
    }
}