namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaSubPlano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaSubPlano));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescricaoSubPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblDescricaoPlano = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPesquisaSubPlano = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaSubPlano)).BeginInit();
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
            this.tspCommand.Size = new System.Drawing.Size(544, 28);
            this.tspCommand.TabIndex = 151;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescricaoSubPlano);
            this.groupBox1.Controls.Add(this.lblDescricaoPlano);
            this.groupBox1.Location = new System.Drawing.Point(6, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 49);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // txtDescricaoSubPlano
            // 
            this.txtDescricaoSubPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoSubPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoSubPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoSubPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoSubPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoSubPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoSubPlano.Limpar = true;
            this.txtDescricaoSubPlano.Location = new System.Drawing.Point(153, 19);
            this.txtDescricaoSubPlano.Name = "txtDescricaoSubPlano";
            this.txtDescricaoSubPlano.NaoAjustarEdicao = false;
            this.txtDescricaoSubPlano.Obrigatorio = false;
            this.txtDescricaoSubPlano.ObrigatorioMensagem = null;
            this.txtDescricaoSubPlano.PreValidacaoMensagem = null;
            this.txtDescricaoSubPlano.PreValidado = false;
            this.txtDescricaoSubPlano.SelectAllOnFocus = false;
            this.txtDescricaoSubPlano.Size = new System.Drawing.Size(372, 18);
            this.txtDescricaoSubPlano.TabIndex = 46;
            this.txtDescricaoSubPlano.TextChanged += new System.EventHandler(this.txtNomeSubPlano_TextChanged);
            // 
            // lblDescricaoPlano
            // 
            this.lblDescricaoPlano.AutoSize = true;
            this.lblDescricaoPlano.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoPlano.Location = new System.Drawing.Point(7, 22);
            this.lblDescricaoPlano.Name = "lblDescricaoPlano";
            this.lblDescricaoPlano.Size = new System.Drawing.Size(139, 14);
            this.lblDescricaoPlano.TabIndex = 0;
            this.lblDescricaoPlano.Text = "Descrição Sub Plano:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPesquisaSubPlano);
            this.groupBox2.Location = new System.Drawing.Point(5, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 363);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
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
            this.Codigo,
            this.Descricao});
            this.dgvPesquisaSubPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaSubPlano.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
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
            this.dgvPesquisaSubPlano.ReadOnly = true;
            this.dgvPesquisaSubPlano.RowHeadersVisible = false;
            this.dgvPesquisaSubPlano.RowHeadersWidth = 25;
            this.dgvPesquisaSubPlano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaSubPlano.Size = new System.Drawing.Size(523, 345);
            this.dgvPesquisaSubPlano.TabIndex = 155;
            this.dgvPesquisaSubPlano.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaSubPlano_CellDoubleClick);
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
            // FrmPesquisaSubPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 448);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tspCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaSubPlano";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaPlano";
            this.Load += new System.EventHandler(this.FrmPesquisaSubPlano_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaSubPlano)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoSubPlano;
        private Hac.Windows.Forms.Controls.HacLabel lblDescricaoPlano;
        private System.Windows.Forms.GroupBox groupBox2;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaSubPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}