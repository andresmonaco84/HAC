namespace HospitalAnaCosta.SGS.GestaoMateriais.HomeCare
{
    partial class FrmAtdDomiciliarPendencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAtdDomiciliarPendencias));
            this.hacToolStrip1 = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.dtgAtdDom = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdtAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtdDom)).BeginInit();
            this.SuspendLayout();
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
            this.hacToolStrip1.Size = new System.Drawing.Size(524, 28);
            this.hacToolStrip1.TabIndex = 1;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = "Pendências Atendimento Domiciliar";
            // 
            // dtgAtdDom
            // 
            this.dtgAtdDom.AllowUserToAddRows = false;
            this.dtgAtdDom.AllowUserToDeleteRows = false;
            this.dtgAtdDom.AllowUserToOrderColumns = true;
            this.dtgAtdDom.AlterarStatus = false;
            this.dtgAtdDom.BackgroundColor = System.Drawing.Color.White;
            this.dtgAtdDom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAtdDom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtAtendimento,
            this.colIdtPedido,
            this.colQtde});
            this.dtgAtdDom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAtdDom.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgAtdDom.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgAtdDom.GridPesquisa = false;
            this.dtgAtdDom.Limpar = false;
            this.dtgAtdDom.Location = new System.Drawing.Point(0, 28);
            this.dtgAtdDom.Name = "dtgAtdDom";
            this.dtgAtdDom.NaoAjustarEdicao = false;
            this.dtgAtdDom.Obrigatorio = false;
            this.dtgAtdDom.ObrigatorioMensagem = null;
            this.dtgAtdDom.PreValidacaoMensagem = null;
            this.dtgAtdDom.PreValidado = false;
            this.dtgAtdDom.ReadOnly = true;
            this.dtgAtdDom.RowHeadersVisible = false;
            this.dtgAtdDom.RowHeadersWidth = 25;
            this.dtgAtdDom.RowTemplate.Height = 18;
            this.dtgAtdDom.Size = new System.Drawing.Size(524, 244);
            this.dtgAtdDom.TabIndex = 2;
            // 
            // colIdtAtendimento
            // 
            this.colIdtAtendimento.DataPropertyName = "ATD_ATE_ID";
            this.colIdtAtendimento.HeaderText = "Atendimento";
            this.colIdtAtendimento.Name = "colIdtAtendimento";
            this.colIdtAtendimento.ReadOnly = true;
            // 
            // colIdtPedido
            // 
            this.colIdtPedido.DataPropertyName = "MTMD_REQ_ID";
            this.colIdtPedido.HeaderText = "Pedido";
            this.colIdtPedido.Name = "colIdtPedido";
            this.colIdtPedido.ReadOnly = true;
            // 
            // colQtde
            // 
            this.colQtde.DataPropertyName = "QTD_PENDENTE";
            this.colQtde.HeaderText = "Qtde Pendente";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 120;
            // 
            // FrmAtdDomiciliarPendencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 272);
            this.Controls.Add(this.dtgAtdDom);
            this.Controls.Add(this.hacToolStrip1);
            this.Name = "FrmAtdDomiciliarPendencias";
            this.Text = "Gestão de Materiais e Medicamentos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtdDom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip hacToolStrip1;
        private SGS.Componentes.HacDataGridView dtgAtdDom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
    }
}