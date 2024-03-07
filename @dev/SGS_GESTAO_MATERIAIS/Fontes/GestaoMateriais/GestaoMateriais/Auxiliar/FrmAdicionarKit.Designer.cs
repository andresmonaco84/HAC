namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmAdicionarKit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdicionarKit));
            this.cmbKit = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgItem = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnCancelar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnOk = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnRemover = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtdeMultiplica = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbKit
            // 
            this.cmbKit.BackColor = System.Drawing.Color.Honeydew;
            this.cmbKit.DisplayMember = "CAD_MTMD_KIT_DSC";
            this.cmbKit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKit.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbKit.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbKit.FormattingEnabled = true;
            this.cmbKit.Limpar = false;
            this.cmbKit.Location = new System.Drawing.Point(42, 36);
            this.cmbKit.MaxDropDownItems = 10;
            this.cmbKit.Name = "cmbKit";
            this.cmbKit.Obrigatorio = false;
            this.cmbKit.ObrigatorioMensagem = null;
            this.cmbKit.PreValidacaoMensagem = null;
            this.cmbKit.PreValidado = false;
            this.cmbKit.Size = new System.Drawing.Size(464, 21);
            this.cmbKit.TabIndex = 128;
            this.cmbKit.ValueMember = "CAD_MTMD_KIT_ID";
            this.cmbKit.SelectionChangeCommitted += new System.EventHandler(this.cmbKit_SelectionChangeCommitted);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(9, 39);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(29, 13);
            this.hacLabel1.TabIndex = 129;
            this.hacLabel1.Text = "KIT";
            // 
            // dtgItem
            // 
            this.dtgItem.AllowUserToAddRows = false;
            this.dtgItem.AllowUserToDeleteRows = false;
            this.dtgItem.AllowUserToResizeColumns = false;
            this.dtgItem.AllowUserToResizeRows = false;
            this.dtgItem.AlterarStatus = false;
            this.dtgItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProduto,
            this.colDsProduto,
            this.colQtde});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgItem.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItem.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItem.GridPesquisa = false;
            this.dtgItem.Limpar = true;
            this.dtgItem.Location = new System.Drawing.Point(12, 66);
            this.dtgItem.Name = "dtgItem";
            this.dtgItem.NaoAjustarEdicao = true;
            this.dtgItem.Obrigatorio = false;
            this.dtgItem.ObrigatorioMensagem = null;
            this.dtgItem.PreValidacaoMensagem = null;
            this.dtgItem.PreValidado = false;
            this.dtgItem.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgItem.RowHeadersVisible = false;
            this.dtgItem.RowHeadersWidth = 18;
            this.dtgItem.RowTemplate.Height = 18;
            this.dtgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItem.Size = new System.Drawing.Size(494, 217);
            this.dtgItem.TabIndex = 131;
            // 
            // colIdProduto
            // 
            this.colIdProduto.DataPropertyName = "CAD_MTMD_ID";
            this.colIdProduto.HeaderText = "IdProduto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.ReadOnly = true;
            this.colIdProduto.Visible = false;
            this.colIdProduto.Width = 50;
            // 
            // colDsProduto
            // 
            this.colDsProduto.DataPropertyName = "CAD_MTMD_NOMEFANTASIA";
            this.colDsProduto.HeaderText = "Produto";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 400;
            // 
            // colQtde
            // 
            this.colQtde.DataPropertyName = "CAD_MTMD_QTDE";
            dataGridViewCellStyle2.Format = "N0";
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtde.HeaderText = "Qtde.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 70;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "Excluir";
            this.dataGridViewImageColumn1.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.ToolTipText = "Excluir Linha";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel1.Controls.Add(this.hacLabel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 24);
            this.panel1.TabIndex = 68;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.ForeColor = System.Drawing.Color.ForestGreen;
            this.hacLabel7.Location = new System.Drawing.Point(6, 4);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(97, 13);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Selecionar Kit";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AlterarStatus = true;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(400, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 22);
            this.btnCancelar.TabIndex = 133;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnOk
            // 
            this.btnOk.AlterarStatus = true;
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(174, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 22);
            this.btnOk.TabIndex = 132;
            this.btnOk.Text = "Adicionar Itens";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.AlterarStatus = true;
            this.btnRemover.BackColor = System.Drawing.Color.White;
            this.btnRemover.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemover.BackgroundImage")));
            this.btnRemover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemover.Enabled = false;
            this.btnRemover.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnRemover.Location = new System.Drawing.Point(287, 296);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(105, 22);
            this.btnRemover.TabIndex = 134;
            this.btnRemover.Text = "Remover Itens";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(13, 300);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(99, 13);
            this.hacLabel2.TabIndex = 145;
            this.hacLabel2.Text = "Qtde. Multiplicar";
            // 
            // txtQtdeMultiplica
            // 
            this.txtQtdeMultiplica.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtdeMultiplica.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtdeMultiplica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtdeMultiplica.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtdeMultiplica.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtQtdeMultiplica.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtdeMultiplica.Limpar = true;
            this.txtQtdeMultiplica.Location = new System.Drawing.Point(113, 296);
            this.txtQtdeMultiplica.MaxLength = 1;
            this.txtQtdeMultiplica.Name = "txtQtdeMultiplica";
            this.txtQtdeMultiplica.NaoAjustarEdicao = true;
            this.txtQtdeMultiplica.Obrigatorio = false;
            this.txtQtdeMultiplica.ObrigatorioMensagem = null;
            this.txtQtdeMultiplica.PreValidacaoMensagem = null;
            this.txtQtdeMultiplica.PreValidado = false;
            this.txtQtdeMultiplica.SelectAllOnFocus = false;
            this.txtQtdeMultiplica.Size = new System.Drawing.Size(40, 21);
            this.txtQtdeMultiplica.TabIndex = 144;
            // 
            // FrmAdicionarKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 331);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.txtQtdeMultiplica);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtgItem);
            this.Controls.Add(this.cmbKit);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAdicionarKit";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmAdicionarKit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacComboBox cmbKit;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacDataGridView dtgItem;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private SGS.Componentes.HacButton btnCancelar;
        private SGS.Componentes.HacButton btnOk;
        private SGS.Componentes.HacButton btnRemover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacTextBox txtQtdeMultiplica;
    }
}