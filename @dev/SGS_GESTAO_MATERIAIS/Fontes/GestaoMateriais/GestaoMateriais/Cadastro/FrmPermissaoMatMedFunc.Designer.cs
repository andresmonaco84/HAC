namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmPermissaoMatMedFunc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermissaoMatMedFunc));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgListaFuncionalidade = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNmFuncionalidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncionalidadePai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNmPagina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaFuncionalidade)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgListaFuncionalidade);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 125);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione o tipo";
            // 
            // dtgListaFuncionalidade
            // 
            this.dtgListaFuncionalidade.AllowUserToAddRows = false;
            this.dtgListaFuncionalidade.AllowUserToDeleteRows = false;
            this.dtgListaFuncionalidade.AllowUserToResizeColumns = false;
            this.dtgListaFuncionalidade.AllowUserToResizeRows = false;
            this.dtgListaFuncionalidade.AlterarStatus = false;
            this.dtgListaFuncionalidade.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListaFuncionalidade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgListaFuncionalidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaFuncionalidade.ColumnHeadersVisible = false;
            this.dtgListaFuncionalidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdt,
            this.colNmFuncionalidade,
            this.colFuncionalidadePai,
            this.colMenu,
            this.colNmPagina});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgListaFuncionalidade.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgListaFuncionalidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgListaFuncionalidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgListaFuncionalidade.GridPesquisa = false;
            this.dtgListaFuncionalidade.Limpar = true;
            this.dtgListaFuncionalidade.Location = new System.Drawing.Point(8, 17);
            this.dtgListaFuncionalidade.Name = "dtgListaFuncionalidade";
            this.dtgListaFuncionalidade.NaoAjustarEdicao = false;
            this.dtgListaFuncionalidade.Obrigatorio = false;
            this.dtgListaFuncionalidade.ObrigatorioMensagem = null;
            this.dtgListaFuncionalidade.PreValidacaoMensagem = null;
            this.dtgListaFuncionalidade.PreValidado = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListaFuncionalidade.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgListaFuncionalidade.RowHeadersVisible = false;
            this.dtgListaFuncionalidade.RowHeadersWidth = 18;
            this.dtgListaFuncionalidade.RowTemplate.Height = 18;
            this.dtgListaFuncionalidade.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgListaFuncionalidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaFuncionalidade.Size = new System.Drawing.Size(430, 103);
            this.dtgListaFuncionalidade.TabIndex = 8;
            this.dtgListaFuncionalidade.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaFuncionalidade_RowEnter);
            // 
            // colIdt
            // 
            this.colIdt.HeaderText = "ID";
            this.colIdt.Name = "colIdt";
            this.colIdt.ReadOnly = true;
            this.colIdt.Visible = false;
            this.colIdt.Width = 70;
            // 
            // colNmFuncionalidade
            // 
            this.colNmFuncionalidade.HeaderText = "Nome";
            this.colNmFuncionalidade.Name = "colNmFuncionalidade";
            this.colNmFuncionalidade.ReadOnly = true;
            this.colNmFuncionalidade.Width = 427;
            // 
            // colFuncionalidadePai
            // 
            this.colFuncionalidadePai.HeaderText = "Pai";
            this.colFuncionalidadePai.Name = "colFuncionalidadePai";
            this.colFuncionalidadePai.ReadOnly = true;
            this.colFuncionalidadePai.Visible = false;
            this.colFuncionalidadePai.Width = 150;
            // 
            // colMenu
            // 
            this.colMenu.HeaderText = "Menu";
            this.colMenu.Name = "colMenu";
            this.colMenu.ReadOnly = true;
            this.colMenu.Visible = false;
            this.colMenu.Width = 50;
            // 
            // colNmPagina
            // 
            this.colNmPagina.HeaderText = "colNmPagina";
            this.colNmPagina.Name = "colNmPagina";
            this.colNmPagina.ReadOnly = true;
            this.colNmPagina.Visible = false;
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
            this.tsHac.Size = new System.Drawing.Size(669, 28);
            this.tsHac.TabIndex = 99;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Configuração de Mat/Med por Tipo de Pedido";
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgMatMed);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 405);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produtos relacionados";
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AlterarStatus = false;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProduto,
            this.colDel,
            this.colDescricao,
            this.colQtdeMax});
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(6, 18);
            this.dtgMatMed.MultiSelect = false;
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = true;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(632, 380);
            this.dtgMatMed.TabIndex = 72;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            this.dtgMatMed.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgMatMed_CellValidating);
            this.dtgMatMed.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellValueChanged);
            // 
            // colIdProduto
            // 
            this.colIdProduto.HeaderText = "Idt";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.Visible = false;
            // 
            // colDel
            // 
            this.colDel.HeaderText = "Excluir";
            this.colDel.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDel.Name = "colDel";
            this.colDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDel.Width = 45;
            // 
            // colDescricao
            // 
            this.colDescricao.HeaderText = " Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Width = 485;
            // 
            // colQtdeMax
            // 
            this.colQtdeMax.HeaderText = "Qtd. Máx.";
            this.colQtdeMax.MaxInputLength = 3;
            this.colQtdeMax.Name = "colQtdeMax";
            this.colQtdeMax.Width = 80;
            // 
            // FrmPermissaoMatMedFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 576);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmPermissaoMatMedFunc";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmPermissaoMatMedSetor_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaFuncionalidade)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private HospitalAnaCosta.SGS.Componentes.HacDataGridView dtgListaFuncionalidade;
        private HospitalAnaCosta.SGS.Componentes.HacDataGridView dtgMatMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
        private System.Windows.Forms.DataGridViewImageColumn colDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNmFuncionalidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncionalidadePai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNmPagina;
    }
}