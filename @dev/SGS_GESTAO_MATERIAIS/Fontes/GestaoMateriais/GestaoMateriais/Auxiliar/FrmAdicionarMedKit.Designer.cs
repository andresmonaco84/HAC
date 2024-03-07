namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmAdicionarMedKit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdicionarMedKit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblKitDsc = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblKit = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgItem = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(484, 28);
            this.tsHac.TabIndex = 133;
            this.tsHac.TituloTela = "Selecionar Medicamento";
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // lblKitDsc
            // 
            this.lblKitDsc.AutoSize = true;
            this.lblKitDsc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblKitDsc.Location = new System.Drawing.Point(35, 35);
            this.lblKitDsc.Name = "lblKitDsc";
            this.lblKitDsc.Size = new System.Drawing.Size(13, 14);
            this.lblKitDsc.TabIndex = 135;
            this.lblKitDsc.Text = "-";
            // 
            // lblKit
            // 
            this.lblKit.AutoSize = true;
            this.lblKit.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblKit.Location = new System.Drawing.Point(6, 36);
            this.lblKit.Name = "lblKit";
            this.lblKit.Size = new System.Drawing.Size(32, 13);
            this.lblKit.TabIndex = 134;
            this.lblKit.Text = "KIT:";
            // 
            // dtgItem
            // 
            this.dtgItem.AllowUserToAddRows = false;
            this.dtgItem.AllowUserToDeleteRows = false;
            this.dtgItem.AllowUserToResizeColumns = false;
            this.dtgItem.AllowUserToResizeRows = false;
            this.dtgItem.AlterarStatus = false;
            this.dtgItem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeletar,
            this.colIdProduto,
            this.colDsProduto});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItem.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgItem.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItem.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItem.GridPesquisa = false;
            this.dtgItem.Limpar = true;
            this.dtgItem.Location = new System.Drawing.Point(4, 62);
            this.dtgItem.Name = "dtgItem";
            this.dtgItem.NaoAjustarEdicao = true;
            this.dtgItem.Obrigatorio = false;
            this.dtgItem.ObrigatorioMensagem = null;
            this.dtgItem.PreValidacaoMensagem = null;
            this.dtgItem.PreValidado = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgItem.RowHeadersVisible = false;
            this.dtgItem.RowHeadersWidth = 18;
            this.dtgItem.RowTemplate.Height = 18;
            this.dtgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItem.Size = new System.Drawing.Size(478, 277);
            this.dtgItem.TabIndex = 136;
            this.dtgItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItem_CellDoubleClick);
            // 
            // colDeletar
            // 
            this.colDeletar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDeletar.HeaderText = "Excluir";
            this.colDeletar.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDeletar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeletar.ToolTipText = "Excluir Linha";
            this.colDeletar.Width = 50;
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
            // FrmAdicionarMedKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 357);
            this.Controls.Add(this.dtgItem);
            this.Controls.Add(this.lblKitDsc);
            this.Controls.Add(this.lblKit);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmAdicionarMedKit";
            this.Text = "Associa. Med. Kit Aplicação";
            this.Load += new System.EventHandler(this.FrmAdicionarMedKit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel lblKitDsc;
        private SGS.Componentes.HacLabel lblKit;
        private SGS.Componentes.HacDataGridView dtgItem;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
    }
}