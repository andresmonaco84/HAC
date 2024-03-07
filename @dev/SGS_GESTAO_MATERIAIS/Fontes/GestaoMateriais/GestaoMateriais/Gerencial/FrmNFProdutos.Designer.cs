namespace HospitalAnaCosta.SGS.GestaoMateriais.Gerencial
{
    partial class FrmNFProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNFProdutos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEstoque = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.dtgCompras = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoteFab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoanterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVlrUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpMovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustoMedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCompras)).BeginInit();
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
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(723, 28);
            this.tsHac.TabIndex = 6;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Nota Fiscal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEstoque);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblNumero);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblFornecedor);
            this.groupBox2.Location = new System.Drawing.Point(8, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 46);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nota Fiscal";
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoque.Location = new System.Drawing.Point(654, 21);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(11, 13);
            this.lblEstoque.TabIndex = 10;
            this.lblEstoque.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(605, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Estoque";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(38, 21);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(11, 13);
            this.lblNumero.TabIndex = 6;
            this.lblNumero.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Núm.";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFornecedor.Location = new System.Drawing.Point(105, 21);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(10, 13);
            this.lblFornecedor.TabIndex = 5;
            this.lblFornecedor.Text = "-";
            // 
            // dtgCompras
            // 
            this.dtgCompras.AllowUserToAddRows = false;
            this.dtgCompras.AllowUserToDeleteRows = false;
            this.dtgCompras.AllowUserToResizeRows = false;
            this.dtgCompras.AlterarStatus = true;
            this.dtgCompras.BackgroundColor = System.Drawing.Color.White;
            this.dtgCompras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgCompras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCompras.ColumnHeadersHeight = 18;
            this.dtgCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExcluir,
            this.colIdProduto,
            this.colProduto,
            this.colLoteFab,
            this.colData,
            this.colQtd,
            this.colSaldoanterior,
            this.colQtdeCompra,
            this.colUnidade,
            this.colVlrUnitario,
            this.colTpMovimento,
            this.colCustoMedio,
            this.colIdLote});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCompras.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCompras.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgCompras.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgCompras.GridPesquisa = true;
            this.dtgCompras.Limpar = true;
            this.dtgCompras.Location = new System.Drawing.Point(8, 85);
            this.dtgCompras.Name = "dtgCompras";
            this.dtgCompras.NaoAjustarEdicao = false;
            this.dtgCompras.Obrigatorio = false;
            this.dtgCompras.ObrigatorioMensagem = null;
            this.dtgCompras.PreValidacaoMensagem = null;
            this.dtgCompras.PreValidado = false;
            this.dtgCompras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCompras.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgCompras.RowHeadersVisible = false;
            this.dtgCompras.RowHeadersWidth = 18;
            this.dtgCompras.RowTemplate.Height = 18;
            this.dtgCompras.Size = new System.Drawing.Size(703, 244);
            this.dtgCompras.TabIndex = 8;
            this.dtgCompras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCompras_CellDoubleClick);
            // 
            // colExcluir
            // 
            this.colExcluir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colExcluir.HeaderText = "";
            this.colExcluir.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colExcluir.ToolTipText = "Excluir produto desta NF?";
            this.colExcluir.Width = 30;
            // 
            // colIdProduto
            // 
            this.colIdProduto.HeaderText = "colIdProduto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.Visible = false;
            // 
            // colProduto
            // 
            this.colProduto.HeaderText = "Produto";
            this.colProduto.Name = "colProduto";
            this.colProduto.ReadOnly = true;
            this.colProduto.Width = 250;
            // 
            // colLoteFab
            // 
            this.colLoteFab.HeaderText = "Lote Fab.";
            this.colLoteFab.Name = "colLoteFab";
            this.colLoteFab.ReadOnly = true;
            this.colLoteFab.Width = 70;
            // 
            // colData
            // 
            dataGridViewCellStyle2.Format = "DD/mm/AAAA HH:MM";
            dataGridViewCellStyle2.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle2;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 115;
            // 
            // colQtd
            // 
            this.colQtd.HeaderText = "Qtd Ent.";
            this.colQtd.Name = "colQtd";
            this.colQtd.ReadOnly = true;
            this.colQtd.Width = 60;
            // 
            // colSaldoanterior
            // 
            this.colSaldoanterior.HeaderText = "Est. Ant.";
            this.colSaldoanterior.Name = "colSaldoanterior";
            this.colSaldoanterior.ReadOnly = true;
            this.colSaldoanterior.Width = 60;
            // 
            // colQtdeCompra
            // 
            this.colQtdeCompra.HeaderText = "Qtd. Nota";
            this.colQtdeCompra.Name = "colQtdeCompra";
            this.colQtdeCompra.ReadOnly = true;
            this.colQtdeCompra.Width = 60;
            // 
            // colUnidade
            // 
            this.colUnidade.HeaderText = "Apres.";
            this.colUnidade.Name = "colUnidade";
            this.colUnidade.ReadOnly = true;
            this.colUnidade.Width = 50;
            // 
            // colVlrUnitario
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.colVlrUnitario.DefaultCellStyle = dataGridViewCellStyle3;
            this.colVlrUnitario.HeaderText = "Prc. Unit.";
            this.colVlrUnitario.Name = "colVlrUnitario";
            this.colVlrUnitario.ReadOnly = true;
            this.colVlrUnitario.Width = 60;
            // 
            // colTpMovimento
            // 
            this.colTpMovimento.HeaderText = "Tipo";
            this.colTpMovimento.Name = "colTpMovimento";
            this.colTpMovimento.ReadOnly = true;
            this.colTpMovimento.Width = 40;
            // 
            // colCustoMedio
            // 
            this.colCustoMedio.HeaderText = "C.Med.";
            this.colCustoMedio.Name = "colCustoMedio";
            this.colCustoMedio.ReadOnly = true;
            this.colCustoMedio.Width = 50;
            // 
            // colIdLote
            // 
            this.colIdLote.HeaderText = "colIdLote";
            this.colIdLote.Name = "colIdLote";
            this.colIdLote.Visible = false;
            // 
            // FrmNFProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 339);
            this.Controls.Add(this.dtgCompras);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmNFProdutos";
            this.Text = "Nota Fiscal";
            this.Load += new System.EventHandler(this.FrmNFProdutos_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFornecedor;
        private HospitalAnaCosta.SGS.Componentes.HacDataGridView dtgCompras;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoteFab;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoanterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVlrUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpMovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustoMedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLote;
    }
}