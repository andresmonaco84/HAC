namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmDispensacaoPendencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDispensacaoPendencias));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgPedidos = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.hacToolStrip1 = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.colIdPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPedidos
            // 
            this.dtgPedidos.AllowUserToAddRows = false;
            this.dtgPedidos.AlterarStatus = false;
            this.dtgPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dtgPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPedido,
            this.colData,
            this.colSetor,
            this.colItem,
            this.colQtde});
            this.dtgPedidos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgPedidos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgPedidos.GridPesquisa = false;
            this.dtgPedidos.Limpar = false;
            this.dtgPedidos.Location = new System.Drawing.Point(1, 30);
            this.dtgPedidos.Name = "dtgPedidos";
            this.dtgPedidos.NaoAjustarEdicao = false;
            this.dtgPedidos.Obrigatorio = false;
            this.dtgPedidos.ObrigatorioMensagem = null;
            this.dtgPedidos.PreValidacaoMensagem = null;
            this.dtgPedidos.PreValidado = false;
            this.dtgPedidos.RowHeadersVisible = false;
            this.dtgPedidos.RowHeadersWidth = 25;
            this.dtgPedidos.RowTemplate.Height = 18;
            this.dtgPedidos.Size = new System.Drawing.Size(660, 258);
            this.dtgPedidos.TabIndex = 3;
            // 
            // hacToolStrip1
            // 
            this.hacToolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacToolStrip1.BackgroundImage")));
            this.hacToolStrip1.CancelarVisivel = false;
            this.hacToolStrip1.ExcluirVisivel = false;
            this.hacToolStrip1.ImprimirVisivel = false;
            this.hacToolStrip1.LimparVisivel = false;
            this.hacToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.hacToolStrip1.MatMedVisivel = false;
            this.hacToolStrip1.Name = "hacToolStrip1";
            this.hacToolStrip1.NomeControleFoco = null;
            this.hacToolStrip1.NovoVisivel = false;
            this.hacToolStrip1.PesquisarVisivel = false;
            this.hacToolStrip1.SalvarVisivel = false;
            this.hacToolStrip1.Size = new System.Drawing.Size(666, 28);
            this.hacToolStrip1.TabIndex = 2;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = "Pendências de Pedidos com Dispensação em Andamento";
            // 
            // colIdPedido
            // 
            this.colIdPedido.HeaderText = "Pedido";
            this.colIdPedido.Name = "colIdPedido";
            this.colIdPedido.ReadOnly = true;
            this.colIdPedido.Width = 60;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data Pedido";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 95;
            // 
            // colSetor
            // 
            this.colSetor.HeaderText = "Setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.ReadOnly = true;
            this.colSetor.Width = 180;
            // 
            // colItem
            // 
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
            this.colItem.Width = 210;
            // 
            // colQtde
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle1;
            this.colQtde.HeaderText = "Qtd. Forn.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 77;
            // 
            // FrmDispensacaoPendencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 290);
            this.Controls.Add(this.dtgPedidos);
            this.Controls.Add(this.hacToolStrip1);
            this.Name = "FrmDispensacaoPendencias";
            this.Text = "FrmDispensacaoPendencias";
            this.Load += new System.EventHandler(this.FrmDispensacaoPendencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacDataGridView dtgPedidos;
        private SGS.Componentes.HacToolStrip hacToolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
    }
}