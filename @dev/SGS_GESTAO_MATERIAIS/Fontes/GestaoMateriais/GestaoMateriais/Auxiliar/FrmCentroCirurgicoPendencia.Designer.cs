namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmCentroCirurgicoPendencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCentroCirurgicoPendencia));
            this.hacToolStrip1 = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.dtgCCirurgico = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdtAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtConsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCCirurgico)).BeginInit();
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
            this.hacToolStrip1.Size = new System.Drawing.Size(441, 28);
            this.hacToolStrip1.TabIndex = 0;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = "Pendências Centro Cirurgico";
            // 
            // dtgCCirurgico
            // 
            this.dtgCCirurgico.AllowUserToAddRows = false;
            this.dtgCCirurgico.AlterarStatus = false;
            this.dtgCCirurgico.BackgroundColor = System.Drawing.Color.White;
            this.dtgCCirurgico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCCirurgico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtAtendimento,
            this.colDtConsumo,
            this.colQtde});
            this.dtgCCirurgico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCCirurgico.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgCCirurgico.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgCCirurgico.GridPesquisa = false;
            this.dtgCCirurgico.Limpar = false;
            this.dtgCCirurgico.Location = new System.Drawing.Point(0, 28);
            this.dtgCCirurgico.Name = "dtgCCirurgico";
            this.dtgCCirurgico.NaoAjustarEdicao = false;
            this.dtgCCirurgico.Obrigatorio = false;
            this.dtgCCirurgico.ObrigatorioMensagem = null;
            this.dtgCCirurgico.PreValidacaoMensagem = null;
            this.dtgCCirurgico.PreValidado = false;
            this.dtgCCirurgico.RowHeadersVisible = false;
            this.dtgCCirurgico.RowHeadersWidth = 25;
            this.dtgCCirurgico.RowTemplate.Height = 18;
            this.dtgCCirurgico.Size = new System.Drawing.Size(441, 203);
            this.dtgCCirurgico.TabIndex = 1;
            // 
            // colIdtAtendimento
            // 
            this.colIdtAtendimento.HeaderText = "Seq.";
            this.colIdtAtendimento.Name = "colIdtAtendimento";
            this.colIdtAtendimento.ReadOnly = true;
            // 
            // colDtConsumo
            // 
            this.colDtConsumo.HeaderText = "Data Consumo";
            this.colDtConsumo.Name = "colDtConsumo";
            this.colDtConsumo.ReadOnly = true;
            // 
            // colQtde
            // 
            this.colQtde.HeaderText = "Qtde Produtos não salvos";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 200;
            // 
            // FrmCentroCirurgicoPendencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 231);
            this.Controls.Add(this.dtgCCirurgico);
            this.Controls.Add(this.hacToolStrip1);
            this.Name = "FrmCentroCirurgicoPendencia";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmCentroCirurgicoPendencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCCirurgico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacToolStrip hacToolStrip1;
        private HospitalAnaCosta.SGS.Componentes.HacDataGridView dtgCCirurgico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
    }
}