using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmEstoqueConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstoqueConsumo));
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.dtgEstoqueConsumo = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDsUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtFilial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacToolStrip1 = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstoqueConsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(533, 37);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 137;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(319, 33);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = "cmbSetor";
            this.cmbLocal.NomeComboUnidade = "cmbUnidade";
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(190, 21);
            this.cmbLocal.TabIndex = 136;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(577, 32);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = "cmbLocal";
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 138;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(277, 37);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 135;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(5, 37);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 133;
            this.hacLabel1.Text = "Unidade";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            //this.cmbUnidade.Internacao = false;
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(64, 34);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = "cmbLocal";
            this.cmbUnidade.NomeComboSetor = "cmbSetor";
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(190, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 134;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // dtgEstoqueConsumo
            // 
            this.dtgEstoqueConsumo.AllowUserToAddRows = false;
            this.dtgEstoqueConsumo.AlterarStatus = false;
            this.dtgEstoqueConsumo.BackgroundColor = System.Drawing.Color.White;
            this.dtgEstoqueConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstoqueConsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeletar,
            this.colDsUnidade,
            this.colDsLocal,
            this.colDsSetor,
            this.colDsFilial,
            this.colIdtUnidade,
            this.colIdtLocal,
            this.colIdtSetor,
            this.colIdtFilial});
            this.dtgEstoqueConsumo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgEstoqueConsumo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgEstoqueConsumo.GridPesquisa = false;
            this.dtgEstoqueConsumo.Limpar = false;
            this.dtgEstoqueConsumo.Location = new System.Drawing.Point(14, 131);
            this.dtgEstoqueConsumo.Name = "dtgEstoqueConsumo";
            this.dtgEstoqueConsumo.NaoAjustarEdicao = false;
            this.dtgEstoqueConsumo.Obrigatorio = false;
            this.dtgEstoqueConsumo.ObrigatorioMensagem = null;
            this.dtgEstoqueConsumo.PreValidacaoMensagem = null;
            this.dtgEstoqueConsumo.PreValidado = false;
            this.dtgEstoqueConsumo.RowHeadersVisible = false;
            this.dtgEstoqueConsumo.RowHeadersWidth = 18;
            this.dtgEstoqueConsumo.RowTemplate.Height = 18;
            this.dtgEstoqueConsumo.Size = new System.Drawing.Size(752, 106);
            this.dtgEstoqueConsumo.TabIndex = 139;
            this.dtgEstoqueConsumo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstoqueConsumo_CellDoubleClick);
            // 
            // colDeletar
            // 
            this.colDeletar.HeaderText = "DEL";
            this.colDeletar.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.ReadOnly = true;
            this.colDeletar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeletar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeletar.Width = 50;
            // 
            // colDsUnidade
            // 
            this.colDsUnidade.HeaderText = "Unidade";
            this.colDsUnidade.Name = "colDsUnidade";
            this.colDsUnidade.ReadOnly = true;
            this.colDsUnidade.Width = 200;
            // 
            // colDsLocal
            // 
            this.colDsLocal.HeaderText = "Local";
            this.colDsLocal.Name = "colDsLocal";
            this.colDsLocal.ReadOnly = true;
            this.colDsLocal.Width = 150;
            // 
            // colDsSetor
            // 
            this.colDsSetor.HeaderText = "Setor";
            this.colDsSetor.Name = "colDsSetor";
            this.colDsSetor.ReadOnly = true;
            this.colDsSetor.Width = 200;
            // 
            // colDsFilial
            // 
            this.colDsFilial.HeaderText = "Filial";
            this.colDsFilial.Name = "colDsFilial";
            this.colDsFilial.ReadOnly = true;
            // 
            // colIdtUnidade
            // 
            this.colIdtUnidade.HeaderText = "Column1";
            this.colIdtUnidade.Name = "colIdtUnidade";
            this.colIdtUnidade.ReadOnly = true;
            this.colIdtUnidade.Visible = false;
            // 
            // colIdtLocal
            // 
            this.colIdtLocal.HeaderText = "Column1";
            this.colIdtLocal.Name = "colIdtLocal";
            this.colIdtLocal.ReadOnly = true;
            this.colIdtLocal.Visible = false;
            // 
            // colIdtSetor
            // 
            this.colIdtSetor.HeaderText = "Column1";
            this.colIdtSetor.Name = "colIdtSetor";
            this.colIdtSetor.ReadOnly = true;
            this.colIdtSetor.Visible = false;
            // 
            // colIdtFilial
            // 
            this.colIdtFilial.HeaderText = "Column1";
            this.colIdtFilial.Name = "colIdtFilial";
            this.colIdtFilial.ReadOnly = true;
            this.colIdtFilial.Visible = false;
            // 
            // hacToolStrip1
            // 
            this.hacToolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacToolStrip1.BackgroundImage")));
            this.hacToolStrip1.ExcluirVisivel = false;
            this.hacToolStrip1.ImprimirVisivel = false;
            this.hacToolStrip1.LimparVisivel = false;
            this.hacToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.hacToolStrip1.MatMedVisivel = false;
            this.hacToolStrip1.Name = "hacToolStrip1";
            this.hacToolStrip1.NomeControleFoco = null;
            this.hacToolStrip1.PesquisarVisivel = false;
            this.hacToolStrip1.Size = new System.Drawing.Size(778, 28);
            this.hacToolStrip1.TabIndex = 0;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = "Estoque de Consumo";
            this.hacToolStrip1.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.hacToolStrip1_NovoClick);
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(12, 112);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(399, 13);
            this.hacLabel4.TabIndex = 140;
            this.hacLabel4.Text = "Esta unidade irá consumir os produtos dos estoques listados abaixo:";
            // 
            // FrmEstoqueConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 259);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.dtgEstoqueConsumo);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacToolStrip1);
            this.Name = "FrmEstoqueConsumo";
            this.Text = "FrmEstoqueConsumo";
            this.Load += new System.EventHandler(this.FrmEstoqueConsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstoqueConsumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip hacToolStrip1;
        private HacLabel hacLabel3;
        private HacCmbLocal cmbLocal;
        private HacCmbSetor cmbSetor;
        private HacLabel hacLabel2;
        private HacLabel hacLabel1;
        private HacCmbUnidade cmbUnidade;
        private HacDataGridView dtgEstoqueConsumo;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsFilial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtFilial;
        private HacLabel hacLabel4;
    }
}