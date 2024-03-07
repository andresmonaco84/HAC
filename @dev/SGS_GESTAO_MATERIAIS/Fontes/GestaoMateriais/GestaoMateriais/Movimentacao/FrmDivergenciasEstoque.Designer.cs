using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmDivergenciasEstoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDivergenciasEstoque));
            this.dtgDivergencia = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colReqIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDivergencia)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDivergencia
            // 
            this.dtgDivergencia.AllowUserToAddRows = false;
            this.dtgDivergencia.AlterarStatus = true;
            this.dtgDivergencia.BackgroundColor = System.Drawing.Color.White;
            this.dtgDivergencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDivergencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReqIdt,
            this.colDsUnidade,
            this.colDsSetor,
            this.colDsProduto,
            this.colQtd,
            this.colData,
            this.colIdMov});
            this.dtgDivergencia.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgDivergencia.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgDivergencia.GridPesquisa = false;
            this.dtgDivergencia.Limpar = true;
            this.dtgDivergencia.Location = new System.Drawing.Point(3, 72);
            this.dtgDivergencia.Name = "dtgDivergencia";
            this.dtgDivergencia.NaoAjustarEdicao = false;
            this.dtgDivergencia.Obrigatorio = false;
            this.dtgDivergencia.ObrigatorioMensagem = null;
            this.dtgDivergencia.PreValidacaoMensagem = null;
            this.dtgDivergencia.PreValidado = false;
            this.dtgDivergencia.RowHeadersVisible = false;
            this.dtgDivergencia.RowHeadersWidth = 25;
            this.dtgDivergencia.Size = new System.Drawing.Size(776, 365);
            this.dtgDivergencia.TabIndex = 135;
            this.dtgDivergencia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDivergencia_CellDoubleClick);
            // 
            // colReqIdt
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReqIdt.DefaultCellStyle = dataGridViewCellStyle1;
            this.colReqIdt.HeaderText = "ID Pedido";
            this.colReqIdt.Name = "colReqIdt";
            this.colReqIdt.ReadOnly = true;
            this.colReqIdt.Width = 78;
            // 
            // colDsUnidade
            // 
            this.colDsUnidade.HeaderText = "Unidade";
            this.colDsUnidade.Name = "colDsUnidade";
            this.colDsUnidade.ReadOnly = true;
            this.colDsUnidade.Width = 80;
            // 
            // colDsSetor
            // 
            this.colDsSetor.HeaderText = "Setor";
            this.colDsSetor.Name = "colDsSetor";
            this.colDsSetor.ReadOnly = true;
            this.colDsSetor.Width = 140;
            // 
            // colDsProduto
            // 
            this.colDsProduto.HeaderText = "Produto";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 160;
            // 
            // colQtd
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colQtd.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtd.HeaderText = "Qtd. Movimento";
            this.colQtd.Name = "colQtd";
            this.colQtd.ReadOnly = true;
            this.colQtd.Width = 110;
            // 
            // colData
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colData.DefaultCellStyle = dataGridViewCellStyle3;
            this.colData.HeaderText = "Data Movimento";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 130;
            // 
            // colIdMov
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIdMov.DefaultCellStyle = dataGridViewCellStyle4;
            this.colIdMov.HeaderText = "ID Mov.";
            this.colIdMov.Name = "colIdMov";
            this.colIdMov.ReadOnly = true;
            this.colIdMov.Visible = false;
            this.colIdMov.Width = 64;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbCE);
            this.groupBox.Controls.Add(this.rbAcs);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(622, 29);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(150, 36);
            this.groupBox.TabIndex = 133;
            this.groupBox.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(107, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 137;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.Click += new System.EventHandler(this.rbCE_Click);
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(57, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = "";
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 3;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Click += new System.EventHandler(this.rbAcs_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(8, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = "";
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 2;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
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
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 132;
            this.tsHac.TituloTela = "Pesquisa de Divergências de Abastecimento de Estoque";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(679, 534);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 20);
            this.pictureBox1.TabIndex = 136;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmDivergenciasEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 556);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtgDivergencia);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmDivergenciasEstoque";
            this.Text = "FrmDivergenciasEstoque";
            this.Load += new System.EventHandler(this.FrmDivergenciasEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDivergencia)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgDivergencia;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacToolStrip tsHac;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdMov;
        private System.Windows.Forms.PictureBox pictureBox1;
        private HacRadioButton rbCE;
    }
}