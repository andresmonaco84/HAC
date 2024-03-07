namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmKitItemPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKitItemPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNumReq = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblPedido = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgPersonalisado = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKitAssociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKitItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersonalisado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumReq
            // 
            this.lblNumReq.AutoSize = true;
            this.lblNumReq.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumReq.Location = new System.Drawing.Point(80, 32);
            this.lblNumReq.Name = "lblNumReq";
            this.lblNumReq.Size = new System.Drawing.Size(19, 18);
            this.lblNumReq.TabIndex = 76;
            this.lblNumReq.Text = "0";
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPedido.Location = new System.Drawing.Point(8, 33);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(72, 16);
            this.lblPedido.TabIndex = 75;
            this.lblPedido.Text = "Pedido N°";
            // 
            // dtgPersonalisado
            // 
            this.dtgPersonalisado.AllowUserToAddRows = false;
            this.dtgPersonalisado.AllowUserToDeleteRows = false;
            this.dtgPersonalisado.AllowUserToResizeColumns = false;
            this.dtgPersonalisado.AllowUserToResizeRows = false;
            this.dtgPersonalisado.AlterarStatus = false;
            this.dtgPersonalisado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPersonalisado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPersonalisado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPersonalisado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDsProd,
            this.colKitAssociado,
            this.colKitItem,
            this.colQtde});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPersonalisado.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgPersonalisado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgPersonalisado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgPersonalisado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgPersonalisado.GridPesquisa = false;
            this.dtgPersonalisado.Limpar = true;
            this.dtgPersonalisado.Location = new System.Drawing.Point(0, 53);
            this.dtgPersonalisado.Name = "dtgPersonalisado";
            this.dtgPersonalisado.NaoAjustarEdicao = false;
            this.dtgPersonalisado.Obrigatorio = false;
            this.dtgPersonalisado.ObrigatorioMensagem = null;
            this.dtgPersonalisado.PreValidacaoMensagem = null;
            this.dtgPersonalisado.PreValidado = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPersonalisado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgPersonalisado.RowHeadersVisible = false;
            this.dtgPersonalisado.RowHeadersWidth = 25;
            this.dtgPersonalisado.Size = new System.Drawing.Size(774, 335);
            this.dtgPersonalisado.TabIndex = 77;
            this.dtgPersonalisado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgPersonalisado_CellFormatting);
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
            this.tsHac.Size = new System.Drawing.Size(774, 28);
            this.tsHac.TabIndex = 78;
            this.tsHac.TituloTela = "Kits Pedido";
            // 
            // colDsProd
            // 
            this.colDsProd.DataPropertyName = "PRODUTO_PAI_KIT";
            this.colDsProd.HeaderText = "Medicamento";
            this.colDsProd.Name = "colDsProd";
            this.colDsProd.ReadOnly = true;
            this.colDsProd.Width = 220;
            // 
            // colKitAssociado
            // 
            this.colKitAssociado.DataPropertyName = "CAD_MTMD_KIT_DSC";
            this.colKitAssociado.HeaderText = "Kit Associado";
            this.colKitAssociado.Name = "colKitAssociado";
            this.colKitAssociado.ReadOnly = true;
            this.colKitAssociado.Width = 220;
            // 
            // colKitItem
            // 
            this.colKitItem.DataPropertyName = "CAD_MTMD_NOMEFANTASIA";
            this.colKitItem.HeaderText = "Item Kit";
            this.colKitItem.Name = "colKitItem";
            this.colKitItem.ReadOnly = true;
            this.colKitItem.Width = 260;
            // 
            // colQtde
            // 
            this.colQtde.DataPropertyName = "MTMD_REQITEM_QTD_SOLICITADA";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtde.HeaderText = "Qtd.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 50;
            // 
            // FrmKitItemPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 388);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.dtgPersonalisado);
            this.Controls.Add(this.lblNumReq);
            this.Controls.Add(this.lblPedido);
            this.Name = "FrmKitItemPedido";
            this.Text = "FrmKitItemPedido";
            this.Load += new System.EventHandler(this.FrmKitItemPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersonalisado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacLabel lblNumReq;
        private SGS.Componentes.HacLabel lblPedido;
        private SGS.Componentes.HacDataGridView dtgPersonalisado;
        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKitAssociado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKitItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
    }
}