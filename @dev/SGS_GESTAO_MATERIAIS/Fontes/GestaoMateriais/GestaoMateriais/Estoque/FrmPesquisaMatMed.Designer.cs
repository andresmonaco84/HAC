using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmPesquisaMatMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaMatMed));
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFracionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDsUnidadeVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPesquisa = new System.Windows.Forms.PictureBox();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtNomeFantasia = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeColumns = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.AlterarStatus = false;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdt,
            this.colDescricao,
            this.colFracionado,
            this.colDsUnidadeVenda});
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(9, 62);
            this.dtgMatMed.MultiSelect = false;
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.ReadOnly = true;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.RowTemplate.Height = 18;
            this.dtgMatMed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(587, 290);
            this.dtgMatMed.TabIndex = 71;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            // 
            // colIdt
            // 
            this.colIdt.HeaderText = "Idt";
            this.colIdt.Name = "colIdt";
            this.colIdt.ReadOnly = true;
            this.colIdt.Visible = false;
            // 
            // colDescricao
            // 
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 500;
            // 
            // colFracionado
            // 
            this.colFracionado.FalseValue = "0";
            this.colFracionado.HeaderText = "Frac.";
            this.colFracionado.Name = "colFracionado";
            this.colFracionado.ReadOnly = true;
            this.colFracionado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFracionado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colFracionado.TrueValue = "1";
            this.colFracionado.Width = 40;
            // 
            // colDsUnidadeVenda
            // 
            this.colDsUnidadeVenda.HeaderText = "DsUnidade";
            this.colDsUnidadeVenda.Name = "colDsUnidadeVenda";
            this.colDsUnidadeVenda.ReadOnly = true;
            this.colDsUnidadeVenda.Visible = false;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.btnPesquisa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisa.Location = new System.Drawing.Point(327, 35);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(39, 21);
            this.btnPesquisa.TabIndex = 74;
            this.btnPesquisa.TabStop = false;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 38);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(63, 13);
            this.hacLabel1.TabIndex = 73;
            this.hacLabel1.Text = "Descrição";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomeFantasia.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeFantasia.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtNomeFantasia.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNomeFantasia.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomeFantasia.Limpar = true;
            this.txtNomeFantasia.Location = new System.Drawing.Point(75, 35);
            this.txtNomeFantasia.MaxLength = 20;
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.NaoAjustarEdicao = false;
            this.txtNomeFantasia.Obrigatorio = false;
            this.txtNomeFantasia.ObrigatorioMensagem = null;
            this.txtNomeFantasia.PreValidacaoMensagem = null;
            this.txtNomeFantasia.PreValidado = false;
            this.txtNomeFantasia.SelectAllOnFocus = false;
            this.txtNomeFantasia.Size = new System.Drawing.Size(250, 21);
            this.txtNomeFantasia.TabIndex = 72;
            this.txtNomeFantasia.Validated += new System.EventHandler(this.txtNomeFantasia_Validated);
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
            this.tsHac.Size = new System.Drawing.Size(614, 28);
            this.tsHac.TabIndex = 81;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Pesquisa de Materiais e Medicamentos";
            this.tsHac.SairClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SairClick);
            // 
            // FrmPesquisaMatMed
            // 
            this.ClientSize = new System.Drawing.Size(614, 363);
            this.ControlBox = false;
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.txtNomeFantasia);
            this.Controls.Add(this.dtgMatMed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaMatMed";
            this.Text = "Sistema de Gestão Hospitalar";
            this.Shown += new System.EventHandler(this.FrmPesquisaMatMed_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgMatMed;
        private System.Windows.Forms.PictureBox btnPesquisa;
        private HacLabel hacLabel1;
        private HacTextBox txtNomeFantasia;
        private HacToolStrip tsHac;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFracionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidadeVenda;
    }
}
