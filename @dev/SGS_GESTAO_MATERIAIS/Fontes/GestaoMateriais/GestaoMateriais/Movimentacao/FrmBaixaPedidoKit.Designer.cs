namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmBaixaPedidoKit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaixaPedidoKit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblNumPedido = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblKit = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgItensBaixa = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdtProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChkBaixar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQtdEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdBaixada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataBaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensBaixa)).BeginInit();
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
            this.tsHac.Size = new System.Drawing.Size(730, 28);
            this.tsHac.TabIndex = 124;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Baixa de Kit";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(170, 37);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(22, 13);
            this.hacLabel4.TabIndex = 135;
            this.hacLabel4.Text = "Kit";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(12, 37);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(45, 13);
            this.hacLabel1.TabIndex = 136;
            this.hacLabel1.Text = "Pedido";
            // 
            // lblNumPedido
            // 
            this.lblNumPedido.AutoSize = true;
            this.lblNumPedido.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumPedido.Location = new System.Drawing.Point(55, 36);
            this.lblNumPedido.Name = "lblNumPedido";
            this.lblNumPedido.Size = new System.Drawing.Size(98, 14);
            this.lblNumPedido.TabIndex = 137;
            this.lblNumPedido.Text = "lblNumPedido";
            // 
            // lblKit
            // 
            this.lblKit.AutoSize = true;
            this.lblKit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblKit.Location = new System.Drawing.Point(191, 36);
            this.lblKit.Name = "lblKit";
            this.lblKit.Size = new System.Drawing.Size(41, 14);
            this.lblKit.TabIndex = 138;
            this.lblKit.Text = "lblKit";
            // 
            // dtgItensBaixa
            // 
            this.dtgItensBaixa.AllowUserToAddRows = false;
            this.dtgItensBaixa.AllowUserToDeleteRows = false;
            this.dtgItensBaixa.AllowUserToResizeColumns = false;
            this.dtgItensBaixa.AllowUserToResizeRows = false;
            this.dtgItensBaixa.AlterarStatus = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgItensBaixa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgItensBaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgItensBaixa.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItensBaixa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgItensBaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItensBaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtProduto,
            this.colChkBaixar,
            this.colDsProduto,
            this.colMAV,
            this.colQtdEstoque,
            this.colQtdSol,
            this.colQtdBaixada,
            this.colQtdPend,
            this.colDataBaixa});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItensBaixa.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgItensBaixa.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgItensBaixa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItensBaixa.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItensBaixa.GridPesquisa = false;
            this.dtgItensBaixa.Limpar = true;
            this.dtgItensBaixa.Location = new System.Drawing.Point(4, 60);
            this.dtgItensBaixa.Name = "dtgItensBaixa";
            this.dtgItensBaixa.NaoAjustarEdicao = false;
            this.dtgItensBaixa.Obrigatorio = false;
            this.dtgItensBaixa.ObrigatorioMensagem = null;
            this.dtgItensBaixa.PreValidacaoMensagem = null;
            this.dtgItensBaixa.PreValidado = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItensBaixa.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgItensBaixa.RowHeadersVisible = false;
            this.dtgItensBaixa.RowHeadersWidth = 21;
            this.dtgItensBaixa.RowTemplate.Height = 18;
            this.dtgItensBaixa.Size = new System.Drawing.Size(723, 304);
            this.dtgItensBaixa.TabIndex = 139;
            // 
            // colIdtProduto
            // 
            this.colIdtProduto.DataPropertyName = "CAD_MTMD_ID";
            this.colIdtProduto.HeaderText = "IdtProduto";
            this.colIdtProduto.Name = "colIdtProduto";
            this.colIdtProduto.Visible = false;
            this.colIdtProduto.Width = 95;
            // 
            // colChkBaixar
            // 
            this.colChkBaixar.FalseValue = "false";
            this.colChkBaixar.HeaderText = "Baixar";
            this.colChkBaixar.Name = "colChkBaixar";
            this.colChkBaixar.TrueValue = "true";
            this.colChkBaixar.Width = 39;
            // 
            // colDsProduto
            // 
            this.colDsProduto.DataPropertyName = "CAD_MTMD_NOMEFANTASIA";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDsProduto.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDsProduto.HeaderText = "Descrição do Produto";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDsProduto.Width = 280;
            // 
            // colMAV
            // 
            this.colMAV.DataPropertyName = "CAD_MTMD_FL_MAV";
            this.colMAV.FalseValue = "N";
            this.colMAV.HeaderText = "MAR";
            this.colMAV.Name = "colMAV";
            this.colMAV.ReadOnly = true;
            this.colMAV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMAV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMAV.TrueValue = "S";
            this.colMAV.Width = 35;
            // 
            // colQtdEstoque
            // 
            this.colQtdEstoque.DataPropertyName = "MTMD_ESTLOC_QTDE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colQtdEstoque.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQtdEstoque.HeaderText = "Qtd. Estoque";
            this.colQtdEstoque.Name = "colQtdEstoque";
            this.colQtdEstoque.ReadOnly = true;
            this.colQtdEstoque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQtdEstoque.Width = 79;
            // 
            // colQtdSol
            // 
            this.colQtdSol.DataPropertyName = "MTMD_REQITEM_QTD_SOLICITADA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.colQtdSol.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQtdSol.HeaderText = "Qtd. Solicitada";
            this.colQtdSol.Name = "colQtdSol";
            this.colQtdSol.ReadOnly = true;
            this.colQtdSol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQtdSol.Width = 93;
            // 
            // colQtdBaixada
            // 
            this.colQtdBaixada.DataPropertyName = "MTMD_REQITEM_QTD_FORNECIDA";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.colQtdBaixada.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtdBaixada.HeaderText = "Qtd. Baixada";
            this.colQtdBaixada.Name = "colQtdBaixada";
            this.colQtdBaixada.ReadOnly = true;
            this.colQtdBaixada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQtdBaixada.Width = 92;
            // 
            // colQtdPend
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.colQtdPend.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQtdPend.HeaderText = "Qtd. Pendente";
            this.colQtdPend.Name = "colQtdPend";
            this.colQtdPend.ReadOnly = true;
            this.colQtdPend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQtdPend.Width = 95;
            // 
            // colDataBaixa
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "g";
            dataGridViewCellStyle8.NullValue = null;
            this.colDataBaixa.DefaultCellStyle = dataGridViewCellStyle8;
            this.colDataBaixa.HeaderText = "Data Baixa";
            this.colDataBaixa.Name = "colDataBaixa";
            this.colDataBaixa.ReadOnly = true;
            this.colDataBaixa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDataBaixa.Visible = false;
            this.colDataBaixa.Width = 120;
            // 
            // FrmBaixaPedidoKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 368);
            this.Controls.Add(this.dtgItensBaixa);
            this.Controls.Add(this.lblKit);
            this.Controls.Add(this.lblNumPedido);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmBaixaPedidoKit";
            this.Text = "Baixa de Kit";
            this.Load += new System.EventHandler(this.FrmBaixaPedidoKit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensBaixa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacLabel lblNumPedido;
        private SGS.Componentes.HacLabel lblKit;
        private SGS.Componentes.HacDataGridView dtgItensBaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChkBaixar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdBaixada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataBaixa;
    }
}