namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmUnidadesEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnidadesEstoque));
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel4 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cboLocal = new Hac.Windows.Forms.Controls.HacCmbLocal(this.components);
            this.dtgUnidaEstoque = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colDsUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSatelite = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunidIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel3 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cboUnidade = new Hac.Windows.Forms.Controls.HacCmbUnidade(this.components);
            this.hacLabel2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.txtUniDescricao = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.hacLabel1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.btnSair = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.btnCancelar = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.btnSalvar = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.btnNovo = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.hacLabel5 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.txtIdt = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUnidaEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel1.Controls.Add(this.hacLabel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 24);
            this.panel1.TabIndex = 59;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.ForeColor = System.Drawing.Color.ForestGreen;
            this.hacLabel4.Location = new System.Drawing.Point(6, 4);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(225, 13);
            this.hacLabel4.TabIndex = 0;
            this.hacLabel4.Text = "Cadastro de Unidades de Estoque";
            // 
            // cboLocal
            // 
            this.cboLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cboLocal.FormattingEnabled = true;
            this.cboLocal.Location = new System.Drawing.Point(93, 114);
            this.cboLocal.Name = "cboLocal";
            this.cboLocal.Size = new System.Drawing.Size(238, 21);
            this.cboLocal.TabIndex = 60;
            // 
            // dtgUnidaEstoque
            // 
            this.dtgUnidaEstoque.BackgroundColor = System.Drawing.Color.White;
            this.dtgUnidaEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUnidaEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDsUnidade,
            this.colUnidade,
            this.colLocal,
            this.colSatelite,
            this.colIdt,
            this.colIdtLocal,
            this.colunidIdt});
            this.dtgUnidaEstoque.Location = new System.Drawing.Point(27, 153);
            this.dtgUnidaEstoque.Name = "dtgUnidaEstoque";
            this.dtgUnidaEstoque.RowHeadersWidth = 25;
            this.dtgUnidaEstoque.Size = new System.Drawing.Size(687, 239);
            this.dtgUnidaEstoque.TabIndex = 58;
            this.dtgUnidaEstoque.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgUnidaEstoque_RowHeaderMouseDoubleClick);
            // 
            // colDsUnidade
            // 
            this.colDsUnidade.HeaderText = "Descrição";
            this.colDsUnidade.Name = "colDsUnidade";
            this.colDsUnidade.ReadOnly = true;
            this.colDsUnidade.Width = 240;
            // 
            // colUnidade
            // 
            this.colUnidade.DataPropertyName = "UniDescricao";
            this.colUnidade.HeaderText = "Unidade";
            this.colUnidade.Name = "colUnidade";
            this.colUnidade.ReadOnly = true;
            this.colUnidade.Width = 195;
            // 
            // colLocal
            // 
            this.colLocal.DataPropertyName = "LocalDescricao";
            this.colLocal.HeaderText = "Local";
            this.colLocal.Name = "colLocal";
            this.colLocal.ReadOnly = true;
            this.colLocal.Width = 195;
            // 
            // colSatelite
            // 
            this.colSatelite.HeaderText = "Satélite";
            this.colSatelite.Name = "colSatelite";
            this.colSatelite.ReadOnly = true;
            this.colSatelite.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSatelite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSatelite.Width = 10;
            // 
            // colIdt
            // 
            this.colIdt.HeaderText = "Column1";
            this.colIdt.Name = "colIdt";
            this.colIdt.ReadOnly = true;
            this.colIdt.Visible = false;
            // 
            // colIdtLocal
            // 
            this.colIdtLocal.HeaderText = "Column1";
            this.colIdtLocal.Name = "colIdtLocal";
            this.colIdtLocal.ReadOnly = true;
            this.colIdtLocal.Visible = false;
            // 
            // colunidIdt
            // 
            this.colunidIdt.HeaderText = "Column1";
            this.colunidIdt.Name = "colunidIdt";
            this.colunidIdt.ReadOnly = true;
            this.colunidIdt.Visible = false;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(24, 122);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(36, 13);
            this.hacLabel3.TabIndex = 56;
            this.hacLabel3.Text = "Local";
            // 
            // cboUnidade
            // 
            this.cboUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.Location = new System.Drawing.Point(93, 87);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.Size = new System.Drawing.Size(238, 21);
            this.cboUnidade.TabIndex = 55;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(24, 95);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(53, 13);
            this.hacLabel2.TabIndex = 54;
            this.hacLabel2.Text = "Unidade";
            // 
            // txtUniDescricao
            // 
            this.txtUniDescricao.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Unknown;
            this.txtUniDescricao.BackColor = System.Drawing.Color.Honeydew;
            this.txtUniDescricao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUniDescricao.Location = new System.Drawing.Point(93, 60);
            this.txtUniDescricao.Name = "txtUniDescricao";
            this.txtUniDescricao.Required = false;
            this.txtUniDescricao.RequiredMessageError = null;
            this.txtUniDescricao.SelectAllOnFocus = false;
            this.txtUniDescricao.Size = new System.Drawing.Size(394, 21);
            this.txtUniDescricao.TabIndex = 53;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(24, 68);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(63, 13);
            this.hacLabel1.TabIndex = 52;
            this.hacLabel1.Text = "Descrição";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSair.BackgroundImage")));
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(483, 398);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(105, 22);
            this.btnSair.TabIndex = 51;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(372, 398);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 22);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvar.BackgroundImage")));
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(261, 398);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(105, 22);
            this.btnSalvar.TabIndex = 48;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.White;
            this.btnNovo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNovo.BackgroundImage")));
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(140, 398);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(115, 22);
            this.btnNovo.TabIndex = 47;
            this.btnNovo.Text = "Nova";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(24, 44);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(47, 13);
            this.hacLabel5.TabIndex = 61;
            this.hacLabel5.Text = "Código";
            // 
            // txtIdt
            // 
            this.txtIdt.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Unknown;
            this.txtIdt.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdt.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdt.Location = new System.Drawing.Point(93, 33);
            this.txtIdt.Name = "txtIdt";
            this.txtIdt.ReadOnly = true;
            this.txtIdt.Required = false;
            this.txtIdt.RequiredMessageError = null;
            this.txtIdt.SelectAllOnFocus = false;
            this.txtIdt.Size = new System.Drawing.Size(68, 21);
            this.txtIdt.TabIndex = 62;
            // 
            // FrmUnidadesEstoque
            // 
            this.ClientSize = new System.Drawing.Size(737, 432);
            this.Controls.Add(this.txtIdt);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.cboLocal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgUnidaEstoque);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cboUnidade);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.txtUniDescricao);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Name = "FrmUnidadesEstoque";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmUnidadesEstoque_Load);
            this.Shown += new System.EventHandler(this.FrmUnidadesEstoque_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUnidaEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnSair;
        private Hac.Windows.Forms.Controls.HacButton btnCancelar;
        private Hac.Windows.Forms.Controls.HacButton btnSalvar;
        private Hac.Windows.Forms.Controls.HacButton btnNovo;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel1;
        private Hac.Windows.Forms.Controls.HacTextBox txtUniDescricao;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel2;
        private Hac.Windows.Forms.Controls.HacCmbUnidade cboUnidade;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel3;
        private System.Windows.Forms.Panel panel1;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel4;
        private Hac.Windows.Forms.Controls.HacCmbLocal cboLocal;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel5;
        private Hac.Windows.Forms.Controls.HacTextBox txtIdt;
        private Hac.Windows.Forms.Controls.HacDataGridView dtgUnidaEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSatelite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunidIdt;
    }
}
