namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmMarcas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarcas));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblMatMed = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgMarcas = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMes3 = new System.Windows.Forms.Label();
            this.txtMarca = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(590, 28);
            this.tsHac.TabIndex = 81;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Marcas de Material";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.AfterNovo += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_AfterNovo);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // lblMatMed
            // 
            this.lblMatMed.AutoSize = true;
            this.lblMatMed.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMatMed.Location = new System.Drawing.Point(14, 36);
            this.lblMatMed.Name = "lblMatMed";
            this.lblMatMed.Size = new System.Drawing.Size(19, 14);
            this.lblMatMed.TabIndex = 83;
            this.lblMatMed.Text = "--";
            // 
            // dtgMarcas
            // 
            this.dtgMarcas.AllowUserToAddRows = false;
            this.dtgMarcas.AllowUserToDeleteRows = false;
            this.dtgMarcas.AlterarStatus = false;
            this.dtgMarcas.BackgroundColor = System.Drawing.Color.White;
            this.dtgMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdt,
            this.colExcluir,
            this.colDescricao,
            this.colNumMarca});
            this.dtgMarcas.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMarcas.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMarcas.GridPesquisa = false;
            this.dtgMarcas.Limpar = false;
            this.dtgMarcas.Location = new System.Drawing.Point(8, 91);
            this.dtgMarcas.MultiSelect = false;
            this.dtgMarcas.Name = "dtgMarcas";
            this.dtgMarcas.NaoAjustarEdicao = true;
            this.dtgMarcas.Obrigatorio = false;
            this.dtgMarcas.ObrigatorioMensagem = null;
            this.dtgMarcas.PreValidacaoMensagem = null;
            this.dtgMarcas.PreValidado = false;
            this.dtgMarcas.ReadOnly = true;
            this.dtgMarcas.RowHeadersVisible = false;
            this.dtgMarcas.RowHeadersWidth = 25;
            this.dtgMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMarcas.Size = new System.Drawing.Size(574, 205);
            this.dtgMarcas.TabIndex = 82;
            this.dtgMarcas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMarcas_CellDoubleClick);            
            // 
            // colIdt
            // 
            this.colIdt.DataPropertyName = "CAD_MTMD_ID";
            this.colIdt.HeaderText = "Idt";
            this.colIdt.Name = "colIdt";
            this.colIdt.ReadOnly = true;
            this.colIdt.Visible = false;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "Excluir";
            this.colExcluir.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.ReadOnly = true;
            this.colExcluir.Width = 50;
            // 
            // colDescricao
            // 
            this.colDescricao.DataPropertyName = "CAD_MTMD_DSC_MARCA";
            this.colDescricao.HeaderText = "Marca";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 505;
            // 
            // colNumMarca
            // 
            this.colNumMarca.DataPropertyName = "CAD_MTMD_MARCA_NUM";
            this.colNumMarca.HeaderText = "NumMarca";
            this.colNumMarca.Name = "colNumMarca";
            this.colNumMarca.ReadOnly = true;
            this.colNumMarca.Visible = false;
            // 
            // lblMes3
            // 
            this.lblMes3.AutoSize = true;
            this.lblMes3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes3.Location = new System.Drawing.Point(14, 66);
            this.lblMes3.Name = "lblMes3";
            this.lblMes3.Size = new System.Drawing.Size(40, 13);
            this.lblMes3.TabIndex = 84;
            this.lblMes3.Text = "Marca:";
            this.lblMes3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMarca
            // 
            this.txtMarca.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtMarca.BackColor = System.Drawing.Color.Honeydew;
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtMarca.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtMarca.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMarca.Limpar = true;
            this.txtMarca.Location = new System.Drawing.Point(57, 61);
            this.txtMarca.MaxLength = 50;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.NaoAjustarEdicao = false;
            this.txtMarca.Obrigatorio = false;
            this.txtMarca.ObrigatorioMensagem = null;
            this.txtMarca.PreValidacaoMensagem = null;
            this.txtMarca.PreValidado = false;
            this.txtMarca.SelectAllOnFocus = false;
            this.txtMarca.Size = new System.Drawing.Size(504, 21);
            this.txtMarca.TabIndex = 85;
            // 
            // FrmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 306);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblMes3);
            this.Controls.Add(this.lblMatMed);
            this.Controls.Add(this.dtgMarcas);
            this.Controls.Add(this.tsHac);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMarcas";
            this.Text = "FrmMarcas";
            this.Load += new System.EventHandler(this.FrmMarcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel lblMatMed;
        private SGS.Componentes.HacDataGridView dtgMarcas;
        private System.Windows.Forms.Label lblMes3;
        private SGS.Componentes.HacTextBox txtMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdt;
        private System.Windows.Forms.DataGridViewImageColumn colExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumMarca;
    }
}