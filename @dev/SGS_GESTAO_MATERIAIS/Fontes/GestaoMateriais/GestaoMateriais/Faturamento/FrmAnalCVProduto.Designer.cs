using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Faturamento
{
    partial class FrmAnalCVProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnalCVProduto));
            this.hacLabel9 = new HacLabel(this.components);
            this.hacLabel6 = new HacLabel(this.components);
            this.hacTextBox1 = new HacTextBox(this.components);
            this.colPrecoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacComboBox1 = new HacComboBox(this.components);
            this.colPercLucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgHistConsumo = new HacDataGridView(this.components);
            this.colIdtMovimentoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProdutoHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecoCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel7 = new HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hacRadioButton3 = new HacRadioButton(this.components);
            this.hacRadioButton4 = new HacRadioButton(this.components);
            this.hacRadioButton1 = new HacRadioButton(this.components);
            this.hacRadioButton2 = new HacRadioButton(this.components);
            this.hacTextBox2 = new HacTextBox(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsHac = new HacToolStrip(this.components);
            this.hacLabel4 = new HacLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(5, 120);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(57, 13);
            this.hacLabel9.TabIndex = 183;
            this.hacLabel9.Text = "Produtos";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(29, 52);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(29, 13);
            this.hacLabel6.TabIndex = 177;
            this.hacLabel6.Text = "Mês";
            // 
            // hacTextBox1
            // 
            this.hacTextBox1.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox1.BackColor = System.Drawing.Color.White;
            this.hacTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hacTextBox1.Editavel = ControleEdicao.Nunca;
            this.hacTextBox1.Enabled = false;
            this.hacTextBox1.EstadoInicial = EstadoObjeto.Desabilitado;
            this.hacTextBox1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox1.Limpar = true;
            this.hacTextBox1.Location = new System.Drawing.Point(178, 84);
            this.hacTextBox1.Name = "hacTextBox1";
            this.hacTextBox1.NaoAjustarEdicao = false;
            this.hacTextBox1.Obrigatorio = false;
            this.hacTextBox1.ObrigatorioMensagem = null;
            this.hacTextBox1.PreValidacaoMensagem = null;
            this.hacTextBox1.PreValidado = false;
            this.hacTextBox1.SelectAllOnFocus = false;
            this.hacTextBox1.Size = new System.Drawing.Size(509, 21);
            this.hacTextBox1.TabIndex = 174;
            // 
            // colPrecoVenda
            // 
            this.colPrecoVenda.HeaderText = "Preço de Venda";
            this.colPrecoVenda.Name = "colPrecoVenda";
            this.colPrecoVenda.Width = 110;
            // 
            // hacComboBox1
            // 
            this.hacComboBox1.BackColor = System.Drawing.Color.White;
            this.hacComboBox1.Editavel = ControleEdicao.Nunca;
            this.hacComboBox1.EstadoInicial = EstadoObjeto.Desabilitado;
            this.hacComboBox1.FormattingEnabled = true;
            this.hacComboBox1.Limpar = false;
            this.hacComboBox1.Location = new System.Drawing.Point(64, 49);
            this.hacComboBox1.Name = "hacComboBox1";
            this.hacComboBox1.Obrigatorio = false;
            this.hacComboBox1.ObrigatorioMensagem = null;
            this.hacComboBox1.PreValidacaoMensagem = null;
            this.hacComboBox1.PreValidado = false;
            this.hacComboBox1.Size = new System.Drawing.Size(121, 21);
            this.hacComboBox1.TabIndex = 178;
            // 
            // colPercLucro
            // 
            this.colPercLucro.HeaderText = "% Lucro";
            this.colPercLucro.Name = "colPercLucro";
            // 
            // dtgHistConsumo
            // 
            this.dtgHistConsumo.AllowUserToAddRows = false;
            this.dtgHistConsumo.AllowUserToDeleteRows = false;
            this.dtgHistConsumo.AllowUserToResizeColumns = false;
            this.dtgHistConsumo.AllowUserToResizeRows = false;
            this.dtgHistConsumo.AlterarStatus = true;
            this.dtgHistConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgHistConsumo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHistConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistConsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtMovimentoHist,
            this.colIdtProdutoHist,
            this.colDsProdutoHist,
            this.colPrecoCusto,
            this.colPrecoVenda,
            this.colPercLucro});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHistConsumo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgHistConsumo.Editavel = ControleEdicao.Nunca;
            this.dtgHistConsumo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgHistConsumo.EstadoInicial = EstadoObjeto.Habilitado;
            this.dtgHistConsumo.GridPesquisa = false;
            this.dtgHistConsumo.Limpar = true;
            this.dtgHistConsumo.Location = new System.Drawing.Point(8, 136);
            this.dtgHistConsumo.Name = "dtgHistConsumo";
            this.dtgHistConsumo.NaoAjustarEdicao = false;
            this.dtgHistConsumo.Obrigatorio = false;
            this.dtgHistConsumo.ObrigatorioMensagem = null;
            this.dtgHistConsumo.PreValidacaoMensagem = null;
            this.dtgHistConsumo.PreValidado = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHistConsumo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgHistConsumo.RowHeadersWidth = 25;
            this.dtgHistConsumo.Size = new System.Drawing.Size(762, 305);
            this.dtgHistConsumo.TabIndex = 181;
            // 
            // colIdtMovimentoHist
            // 
            this.colIdtMovimentoHist.HeaderText = "IdtMovimentoHist";
            this.colIdtMovimentoHist.Name = "colIdtMovimentoHist";
            this.colIdtMovimentoHist.ReadOnly = true;
            this.colIdtMovimentoHist.Visible = false;
            // 
            // colIdtProdutoHist
            // 
            this.colIdtProdutoHist.HeaderText = "IdtProdutoHist";
            this.colIdtProdutoHist.Name = "colIdtProdutoHist";
            this.colIdtProdutoHist.Visible = false;
            // 
            // colDsProdutoHist
            // 
            this.colDsProdutoHist.HeaderText = "Descrição";
            this.colDsProdutoHist.Name = "colDsProdutoHist";
            this.colDsProdutoHist.ReadOnly = true;
            this.colDsProdutoHist.Width = 400;
            // 
            // colPrecoCusto
            // 
            this.colPrecoCusto.HeaderText = "Preço de Custo";
            this.colPrecoCusto.Name = "colPrecoCusto";
            this.colPrecoCusto.Width = 110;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(200, 51);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(103, 13);
            this.hacLabel7.TabIndex = 180;
            this.hacLabel7.Text = "Tipo de Empresa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hacRadioButton3);
            this.groupBox1.Controls.Add(this.hacRadioButton4);
            this.groupBox1.Controls.Add(this.hacRadioButton1);
            this.groupBox1.Controls.Add(this.hacRadioButton2);
            this.groupBox1.Location = new System.Drawing.Point(309, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 46);
            this.groupBox1.TabIndex = 179;
            this.groupBox1.TabStop = false;
            // 
            // hacRadioButton3
            // 
            this.hacRadioButton3.AutoSize = true;
            this.hacRadioButton3.Editavel = ControleEdicao.Nunca;
            this.hacRadioButton3.EstadoInicial = EstadoObjeto.Desabilitado;
            this.hacRadioButton3.Limpar = false;
            this.hacRadioButton3.Location = new System.Drawing.Point(111, 18);
            this.hacRadioButton3.Name = "hacRadioButton3";
            this.hacRadioButton3.Obrigatorio = false;
            this.hacRadioButton3.ObrigatorioMensagem = null;
            this.hacRadioButton3.PreValidacaoMensagem = null;
            this.hacRadioButton3.PreValidado = false;
            this.hacRadioButton3.Size = new System.Drawing.Size(39, 17);
            this.hacRadioButton3.TabIndex = 141;
            this.hacRadioButton3.TabStop = true;
            this.hacRadioButton3.Text = "FU";
            this.hacRadioButton3.UseVisualStyleBackColor = true;
            // 
            // hacRadioButton4
            // 
            this.hacRadioButton4.AutoSize = true;
            this.hacRadioButton4.Editavel = ControleEdicao.Nunca;
            this.hacRadioButton4.EstadoInicial = EstadoObjeto.Desabilitado;
            this.hacRadioButton4.Limpar = false;
            this.hacRadioButton4.Location = new System.Drawing.Point(156, 18);
            this.hacRadioButton4.Name = "hacRadioButton4";
            this.hacRadioButton4.Obrigatorio = false;
            this.hacRadioButton4.ObrigatorioMensagem = null;
            this.hacRadioButton4.PreValidacaoMensagem = null;
            this.hacRadioButton4.PreValidado = false;
            this.hacRadioButton4.Size = new System.Drawing.Size(39, 17);
            this.hacRadioButton4.TabIndex = 142;
            this.hacRadioButton4.TabStop = true;
            this.hacRadioButton4.Text = "PA";
            this.hacRadioButton4.UseVisualStyleBackColor = true;
            // 
            // hacRadioButton1
            // 
            this.hacRadioButton1.AutoSize = true;
            this.hacRadioButton1.Editavel = ControleEdicao.Nunca;
            this.hacRadioButton1.EstadoInicial = EstadoObjeto.Desabilitado;
            this.hacRadioButton1.Limpar = false;
            this.hacRadioButton1.Location = new System.Drawing.Point(7, 18);
            this.hacRadioButton1.Name = "hacRadioButton1";
            this.hacRadioButton1.Obrigatorio = false;
            this.hacRadioButton1.ObrigatorioMensagem = null;
            this.hacRadioButton1.PreValidacaoMensagem = null;
            this.hacRadioButton1.PreValidado = false;
            this.hacRadioButton1.Size = new System.Drawing.Size(39, 17);
            this.hacRadioButton1.TabIndex = 139;
            this.hacRadioButton1.TabStop = true;
            this.hacRadioButton1.Text = "SP";
            this.hacRadioButton1.UseVisualStyleBackColor = true;
            // 
            // hacRadioButton2
            // 
            this.hacRadioButton2.AutoSize = true;
            this.hacRadioButton2.Editavel = ControleEdicao.Nunca;
            this.hacRadioButton2.EstadoInicial = EstadoObjeto.Desabilitado;
            this.hacRadioButton2.Limpar = false;
            this.hacRadioButton2.Location = new System.Drawing.Point(52, 18);
            this.hacRadioButton2.Name = "hacRadioButton2";
            this.hacRadioButton2.Obrigatorio = false;
            this.hacRadioButton2.ObrigatorioMensagem = null;
            this.hacRadioButton2.PreValidacaoMensagem = null;
            this.hacRadioButton2.PreValidado = false;
            this.hacRadioButton2.Size = new System.Drawing.Size(53, 17);
            this.hacRadioButton2.TabIndex = 140;
            this.hacRadioButton2.TabStop = true;
            this.hacRadioButton2.Text = "PSAC";
            this.hacRadioButton2.UseVisualStyleBackColor = true;
            // 
            // hacTextBox2
            // 
            this.hacTextBox2.AcceptedFormat = AcceptedFormat.Numerico;
            this.hacTextBox2.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hacTextBox2.Editavel = ControleEdicao.Sempre;
            this.hacTextBox2.Enabled = false;
            this.hacTextBox2.EstadoInicial = EstadoObjeto.Habilitado;
            this.hacTextBox2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox2.Limpar = true;
            this.hacTextBox2.Location = new System.Drawing.Point(64, 84);
            this.hacTextBox2.MaxLength = 10;
            this.hacTextBox2.Name = "hacTextBox2";
            this.hacTextBox2.NaoAjustarEdicao = false;
            this.hacTextBox2.Obrigatorio = false;
            this.hacTextBox2.ObrigatorioMensagem = null;
            this.hacTextBox2.PreValidacaoMensagem = null;
            this.hacTextBox2.PreValidado = false;
            this.hacTextBox2.SelectAllOnFocus = false;
            this.hacTextBox2.Size = new System.Drawing.Size(100, 21);
            this.hacTextBox2.TabIndex = 173;
            this.hacTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(693, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 21);
            this.pictureBox1.TabIndex = 175;
            this.pictureBox1.TabStop = false;
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = "txtNroInternacao";
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 172;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Análise Custo X Venda de Produtos";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(8, 87);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(51, 13);
            this.hacLabel4.TabIndex = 184;
            this.hacLabel4.Text = "Produto";
            // 
            // FrmAnalCVProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.hacLabel9);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.hacTextBox1);
            this.Controls.Add(this.hacComboBox1);
            this.Controls.Add(this.dtgHistConsumo);
            this.Controls.Add(this.hacLabel7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.hacTextBox2);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmAnalCVProduto";
            this.Text = "FrmAnalCVProduto";
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistConsumo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacLabel hacLabel9;
        private HacLabel hacLabel6;
        private HacTextBox hacTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoVenda;
        private HacComboBox hacComboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercLucro;
        private HacDataGridView dtgHistConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtMovimentoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtProdutoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProdutoHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecoCusto;
        private HacLabel hacLabel7;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacRadioButton hacRadioButton3;
        private HacRadioButton hacRadioButton4;
        private HacRadioButton hacRadioButton1;
        private HacRadioButton hacRadioButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private HacTextBox hacTextBox2;
        private HacToolStrip tsHac;
        private HacLabel hacLabel4;
    }
}