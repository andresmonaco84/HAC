namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaConvenio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaConvenio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescricaoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblDescricaoConvenio = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPesquisaConvenio = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.IdtConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaConvenio)).BeginInit();
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
            this.tspCommand.TabIndex = 151;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescricaoConvenio);
            this.groupBox1.Controls.Add(this.lblDescricaoConvenio);
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 49);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // txtDescricaoConvenio
            // 
            this.txtDescricaoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoConvenio.Limpar = true;
            this.txtDescricaoConvenio.Location = new System.Drawing.Point(142, 19);
            this.txtDescricaoConvenio.Name = "txtDescricaoConvenio";
            this.txtDescricaoConvenio.NaoAjustarEdicao = false;
            this.txtDescricaoConvenio.Obrigatorio = false;
            this.txtDescricaoConvenio.ObrigatorioMensagem = null;
            this.txtDescricaoConvenio.PreValidacaoMensagem = null;
            this.txtDescricaoConvenio.PreValidado = false;
            this.txtDescricaoConvenio.SelectAllOnFocus = false;
            this.txtDescricaoConvenio.Size = new System.Drawing.Size(388, 18);
            this.txtDescricaoConvenio.TabIndex = 46;
            this.txtDescricaoConvenio.TextChanged += new System.EventHandler(this.txtNomeConvenio_TextChanged);
            // 
            // lblDescricaoConvenio
            // 
            this.lblDescricaoConvenio.AutoSize = true;
            this.lblDescricaoConvenio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoConvenio.Location = new System.Drawing.Point(7, 22);
            this.lblDescricaoConvenio.Name = "lblDescricaoConvenio";
            this.lblDescricaoConvenio.Size = new System.Drawing.Size(135, 14);
            this.lblDescricaoConvenio.TabIndex = 0;
            this.lblDescricaoConvenio.Text = "Descrição Convênio:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPesquisaConvenio);
            this.groupBox2.Location = new System.Drawing.Point(5, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 363);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // dgvPesquisaConvenio
            // 
            this.dgvPesquisaConvenio.AllowUserToAddRows = false;
            this.dgvPesquisaConvenio.AllowUserToDeleteRows = false;
            this.dgvPesquisaConvenio.AllowUserToResizeRows = false;
            this.dgvPesquisaConvenio.AlterarStatus = false;
            this.dgvPesquisaConvenio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaConvenio.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaConvenio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaConvenio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaConvenio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdtConvenio,
            this.Codigo,
            this.Descricao});
            this.dgvPesquisaConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaConvenio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPesquisaConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaConvenio.GridPesquisa = false;
            this.dgvPesquisaConvenio.Limpar = false;
            this.dgvPesquisaConvenio.Location = new System.Drawing.Point(6, 12);
            this.dgvPesquisaConvenio.MultiSelect = false;
            this.dgvPesquisaConvenio.Name = "dgvPesquisaConvenio";
            this.dgvPesquisaConvenio.NaoAjustarEdicao = false;
            this.dgvPesquisaConvenio.Obrigatorio = false;
            this.dgvPesquisaConvenio.ObrigatorioMensagem = null;
            this.dgvPesquisaConvenio.PreValidacaoMensagem = null;
            this.dgvPesquisaConvenio.PreValidado = false;
            this.dgvPesquisaConvenio.ReadOnly = true;
            this.dgvPesquisaConvenio.RowHeadersVisible = false;
            this.dgvPesquisaConvenio.RowHeadersWidth = 25;
            this.dgvPesquisaConvenio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaConvenio.Size = new System.Drawing.Size(525, 345);
            this.dgvPesquisaConvenio.TabIndex = 155;
            this.dgvPesquisaConvenio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaConvenio_CellDoubleClick);
            // 
            // IdtConvenio
            // 
            this.IdtConvenio.HeaderText = "Código";
            this.IdtConvenio.Name = "IdtConvenio";
            this.IdtConvenio.ReadOnly = true;
            this.IdtConvenio.Width = 60;
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
            this.Descricao.Width = 380;
            // 
            // FrmPesquisaConvenio
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
            this.Name = "FrmPesquisaConvenio";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaConvenio";
            this.Load += new System.EventHandler(this.FrmPesquisaConvenio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaConvenio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoConvenio;
        private Hac.Windows.Forms.Controls.HacLabel lblDescricaoConvenio;
        private System.Windows.Forms.GroupBox groupBox2;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdtConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}