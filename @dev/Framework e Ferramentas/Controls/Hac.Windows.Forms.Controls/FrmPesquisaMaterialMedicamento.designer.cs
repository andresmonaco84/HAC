namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaMaterialMedicamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaMaterialMedicamento));
            this.txtNomeProcedimento = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblProcedimentoProposto = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.dgvPesquisaProdutoMatMed = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeFantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodAnvisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.txtCod = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblCod = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProdutoMatMed)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeProcedimento
            // 
            this.txtNomeProcedimento.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeProcedimento.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeProcedimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeProcedimento.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNomeProcedimento.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeProcedimento.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProcedimento.Limpar = true;
            this.txtNomeProcedimento.Location = new System.Drawing.Point(300, 34);
            this.txtNomeProcedimento.Name = "txtNomeProcedimento";
            this.txtNomeProcedimento.NaoAjustarEdicao = false;
            this.txtNomeProcedimento.Obrigatorio = false;
            this.txtNomeProcedimento.ObrigatorioMensagem = null;
            this.txtNomeProcedimento.PreValidacaoMensagem = null;
            this.txtNomeProcedimento.PreValidado = false;
            this.txtNomeProcedimento.SelectAllOnFocus = false;
            this.txtNomeProcedimento.Size = new System.Drawing.Size(240, 18);
            this.txtNomeProcedimento.TabIndex = 1;
            this.txtNomeProcedimento.TextChanged += new System.EventHandler(this.txtNomeProcedimentoProposto_TextChanged);
            // 
            // lblProcedimentoProposto
            // 
            this.lblProcedimentoProposto.AutoSize = true;
            this.lblProcedimentoProposto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcedimentoProposto.Location = new System.Drawing.Point(198, 36);
            this.lblProcedimentoProposto.Name = "lblProcedimentoProposto";
            this.lblProcedimentoProposto.Size = new System.Drawing.Size(84, 14);
            this.lblProcedimentoProposto.TabIndex = 153;
            this.lblProcedimentoProposto.Text = "Nome Fant.:";
            // 
            // dgvPesquisaProdutoMatMed
            // 
            this.dgvPesquisaProdutoMatMed.AllowUserToAddRows = false;
            this.dgvPesquisaProdutoMatMed.AllowUserToDeleteRows = false;
            this.dgvPesquisaProdutoMatMed.AllowUserToResizeRows = false;
            this.dgvPesquisaProdutoMatMed.AlterarStatus = false;
            this.dgvPesquisaProdutoMatMed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaProdutoMatMed.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaProdutoMatMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaProdutoMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaProdutoMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.colNomeFantasia,
            this.colFabricante,
            this.colCodAnvisa,
            this.Descricao});
            this.dgvPesquisaProdutoMatMed.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaProdutoMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPesquisaProdutoMatMed.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaProdutoMatMed.GridPesquisa = false;
            this.dgvPesquisaProdutoMatMed.Limpar = false;
            this.dgvPesquisaProdutoMatMed.Location = new System.Drawing.Point(3, 63);
            this.dgvPesquisaProdutoMatMed.MultiSelect = false;
            this.dgvPesquisaProdutoMatMed.Name = "dgvPesquisaProdutoMatMed";
            this.dgvPesquisaProdutoMatMed.NaoAjustarEdicao = false;
            this.dgvPesquisaProdutoMatMed.Obrigatorio = false;
            this.dgvPesquisaProdutoMatMed.ObrigatorioMensagem = null;
            this.dgvPesquisaProdutoMatMed.PreValidacaoMensagem = null;
            this.dgvPesquisaProdutoMatMed.PreValidado = false;
            this.dgvPesquisaProdutoMatMed.ReadOnly = true;
            this.dgvPesquisaProdutoMatMed.RowHeadersVisible = false;
            this.dgvPesquisaProdutoMatMed.RowHeadersWidth = 25;
            this.dgvPesquisaProdutoMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaProdutoMatMed.Size = new System.Drawing.Size(541, 403);
            this.dgvPesquisaProdutoMatMed.TabIndex = 154;
            this.dgvPesquisaProdutoMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaProcedimentoProposto_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Cod.";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 60;
            // 
            // colNomeFantasia
            // 
            this.colNomeFantasia.HeaderText = "Nome Fantasia";
            this.colNomeFantasia.Name = "colNomeFantasia";
            this.colNomeFantasia.ReadOnly = true;
            this.colNomeFantasia.Width = 300;
            // 
            // colFabricante
            // 
            this.colFabricante.HeaderText = "Fabricante";
            this.colFabricante.Name = "colFabricante";
            this.colFabricante.ReadOnly = true;
            this.colFabricante.Width = 170;
            // 
            // colCodAnvisa
            // 
            this.colCodAnvisa.HeaderText = "Cod. ANVISA";
            this.colCodAnvisa.Name = "colCodAnvisa";
            this.colCodAnvisa.ReadOnly = true;
            this.colCodAnvisa.Width = 130;
            // 
            // Descricao
            // 
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 300;
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
            this.tspCommand.Size = new System.Drawing.Size(547, 28);
            this.tspCommand.TabIndex = 151;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // txtCod
            // 
            this.txtCod.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCod.BackColor = System.Drawing.Color.Honeydew;
            this.txtCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCod.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCod.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCod.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Limpar = true;
            this.txtCod.Location = new System.Drawing.Point(93, 34);
            this.txtCod.Name = "txtCod";
            this.txtCod.NaoAjustarEdicao = false;
            this.txtCod.Obrigatorio = false;
            this.txtCod.ObrigatorioMensagem = null;
            this.txtCod.PreValidacaoMensagem = null;
            this.txtCod.PreValidado = false;
            this.txtCod.SelectAllOnFocus = false;
            this.txtCod.Size = new System.Drawing.Size(95, 18);
            this.txtCod.TabIndex = 0;
            this.txtCod.TextChanged += new System.EventHandler(this.txtCod_TextChanged);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCod.Location = new System.Drawing.Point(3, 36);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(56, 14);
            this.lblCod.TabIndex = 156;
            this.lblCod.Text = "Codigo:";
            // 
            // FrmPesquisaMaterialMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 473);
            this.ControlBox = false;
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.dgvPesquisaProdutoMatMed);
            this.Controls.Add(this.txtNomeProcedimento);
            this.Controls.Add(this.lblProcedimentoProposto);
            this.Controls.Add(this.tspCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaMaterialMedicamento";
            this.Text = "FrmPesquisaProcedimentoProposto";
            this.Load += new System.EventHandler(this.FrmPesquisaProcedimento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaProdutoMatMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacTextBox txtNomeProcedimento;
        private Hac.Windows.Forms.Controls.HacLabel lblProcedimentoProposto;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaProdutoMatMed;
        private HacTextBox txtCod;
        private HacLabel lblCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeFantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodAnvisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}