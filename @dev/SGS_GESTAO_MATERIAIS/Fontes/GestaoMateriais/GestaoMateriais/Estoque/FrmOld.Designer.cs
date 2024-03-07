namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmOld

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOld));
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cmbunidade = new Hac.Windows.Forms.Controls.HacCmbUnidade(this.components);
            this.hacLabel2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cmbLocal = new Hac.Windows.Forms.Controls.HacCmbLocal(this.components);
            this.hacLabel3 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacDataGridView1 = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colIdtProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsumido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeSolicitada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercentual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel4 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacTextBox1 = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.hacTextBox2 = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.hacButton1 = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.hacButton2 = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.cmbSetor = new Hac.Windows.Forms.Controls.HacCmbSetor(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hacDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel1.Controls.Add(this.hacLabel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 24);
            this.panel1.TabIndex = 67;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.hacLabel7.Location = new System.Drawing.Point(6, 4);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(395, 13);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Controle de Estoque e Solicitação Padrão - Estoque On-Line";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 40);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 68;
            this.hacLabel1.Text = "Unidade";
            // 
            // cmbunidade
            // 
            this.cmbunidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbunidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbunidade.FormattingEnabled = true;
            this.cmbunidade.Location = new System.Drawing.Point(65, 37);
            this.cmbunidade.Name = "cmbunidade";
            this.cmbunidade.Size = new System.Drawing.Size(196, 21);
            this.cmbunidade.TabIndex = 69;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(267, 40);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 70;
            this.hacLabel2.Text = "Local";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Location = new System.Drawing.Point(320, 36);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(227, 21);
            this.cmbLocal.TabIndex = 71;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(553, 40);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 76;
            this.hacLabel3.Text = "Setor";
            // 
            // hacDataGridView1
            // 
            this.hacDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.hacDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hacDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtProduto,
            this.colDsProduto,
            this.colConsumido,
            this.colQtdeSolicitada,
            this.colPercentual,
            this.colQtdeEstoque});
            this.hacDataGridView1.GridPesquisa = false;
            this.hacDataGridView1.Location = new System.Drawing.Point(9, 94);
            this.hacDataGridView1.Name = "hacDataGridView1";
            this.hacDataGridView1.RowHeadersWidth = 25;
            this.hacDataGridView1.Size = new System.Drawing.Size(780, 301);
            this.hacDataGridView1.TabIndex = 78;
            // 
            // colIdtProduto
            // 
            this.colIdtProduto.HeaderText = "Column1";
            this.colIdtProduto.Name = "colIdtProduto";
            this.colIdtProduto.Visible = false;
            // 
            // colDsProduto
            // 
            this.colDsProduto.HeaderText = "Descrição";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 350;
            // 
            // colConsumido
            // 
            this.colConsumido.HeaderText = "Consumido";
            this.colConsumido.Name = "colConsumido";
            this.colConsumido.ReadOnly = true;
            // 
            // colQtdeSolicitada
            // 
            this.colQtdeSolicitada.HeaderText = "Qtde Padrão";
            this.colQtdeSolicitada.Name = "colQtdeSolicitada";
            this.colQtdeSolicitada.ReadOnly = true;
            // 
            // colPercentual
            // 
            this.colPercentual.HeaderText = "%";
            this.colPercentual.Name = "colPercentual";
            this.colPercentual.ReadOnly = true;
            // 
            // colQtdeEstoque
            // 
            this.colQtdeEstoque.HeaderText = "Est. Local";
            this.colQtdeEstoque.Name = "colQtdeEstoque";
            this.colQtdeEstoque.ReadOnly = true;
            this.colQtdeEstoque.Width = 80;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(6, 71);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(51, 13);
            this.hacLabel4.TabIndex = 79;
            this.hacLabel4.Text = "Produto";
            // 
            // hacTextBox1
            // 
            this.hacTextBox1.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Unknown;
            this.hacTextBox1.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hacTextBox1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox1.Location = new System.Drawing.Point(65, 64);
            this.hacTextBox1.Name = "hacTextBox1";
            this.hacTextBox1.Required = false;
            this.hacTextBox1.RequiredMessageError = null;
            this.hacTextBox1.SelectAllOnFocus = false;
            this.hacTextBox1.Size = new System.Drawing.Size(76, 21);
            this.hacTextBox1.TabIndex = 80;
            // 
            // hacTextBox2
            // 
            this.hacTextBox2.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Unknown;
            this.hacTextBox2.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hacTextBox2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox2.Location = new System.Drawing.Point(147, 63);
            this.hacTextBox2.Name = "hacTextBox2";
            this.hacTextBox2.Required = false;
            this.hacTextBox2.RequiredMessageError = null;
            this.hacTextBox2.SelectAllOnFocus = false;
            this.hacTextBox2.Size = new System.Drawing.Size(530, 21);
            this.hacTextBox2.TabIndex = 81;
            // 
            // hacButton1
            // 
            this.hacButton1.BackColor = System.Drawing.Color.White;
            this.hacButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton1.BackgroundImage")));
            this.hacButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton1.Location = new System.Drawing.Point(683, 62);
            this.hacButton1.Name = "hacButton1";
            this.hacButton1.Size = new System.Drawing.Size(121, 22);
            this.hacButton1.TabIndex = 82;
            this.hacButton1.Text = "Pesquisa Mat/Med";
            this.hacButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hacButton1.UseVisualStyleBackColor = true;
            this.hacButton1.Click += new System.EventHandler(this.hacButton1_Click);
            // 
            // hacButton2
            // 
            this.hacButton2.BackColor = System.Drawing.Color.White;
            this.hacButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton2.BackgroundImage")));
            this.hacButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton2.Location = new System.Drawing.Point(345, 401);
            this.hacButton2.Name = "hacButton2";
            this.hacButton2.Size = new System.Drawing.Size(121, 22);
            this.hacButton2.TabIndex = 83;
            this.hacButton2.Text = "Pesquisa Estoque";
            this.hacButton2.UseVisualStyleBackColor = true;
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Location = new System.Drawing.Point(597, 35);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.Size = new System.Drawing.Size(207, 21);
            this.cmbSetor.TabIndex = 84;
            // 
            // FrmEstoque
            // 
            this.ClientSize = new System.Drawing.Size(810, 426);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.hacButton2);
            this.Controls.Add(this.hacButton1);
            this.Controls.Add(this.hacTextBox2);
            this.Controls.Add(this.hacTextBox1);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.hacDataGridView1);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbunidade);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEstoque";
            this.Text = "Gestão de Materiais";
            this.Load += new System.EventHandler(this.FrmEstoque_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hacDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel7;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel1;
        private Hac.Windows.Forms.Controls.HacCmbUnidade cmbunidade;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel2;
        private Hac.Windows.Forms.Controls.HacCmbLocal cmbLocal;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel3;
        private Hac.Windows.Forms.Controls.HacDataGridView hacDataGridView1;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel4;
        private Hac.Windows.Forms.Controls.HacTextBox hacTextBox1;
        private Hac.Windows.Forms.Controls.HacTextBox hacTextBox2;
        private Hac.Windows.Forms.Controls.HacButton hacButton1;
        private Hac.Windows.Forms.Controls.HacButton hacButton2;
        private Hac.Windows.Forms.Controls.HacCmbSetor cmbSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsumido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeSolicitada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercentual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeEstoque;

    }
}
