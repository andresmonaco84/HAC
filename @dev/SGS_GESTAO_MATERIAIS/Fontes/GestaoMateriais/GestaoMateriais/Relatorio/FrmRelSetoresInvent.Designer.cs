namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmRelSetoresInvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelSetoresInvent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgSetores = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbEstoque = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.grbRelatorio = new System.Windows.Forms.GroupBox();
            this.rbDemonstSintetico = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbDigita = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbDemonstAnalitico = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSetores)).BeginInit();
            this.grbEstoque.SuspendLayout();
            this.grbRelatorio.SuspendLayout();
            this.SuspendLayout();
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
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(604, 28);
            this.tsHac.TabIndex = 0;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Setores c/ saldo sem contagem efetuada";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFim);
            this.groupBox2.Controls.Add(this.txtInicio);
            this.groupBox2.Controls.Add(this.hacLabel5);
            this.groupBox2.Controls.Add(this.hacLabel6);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período Inventário para pesquisa";
            // 
            // txtFim
            // 
            this.txtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Limpar = true;
            this.txtFim.Location = new System.Drawing.Point(154, 22);
            this.txtFim.MaxLength = 10;
            this.txtFim.Name = "txtFim";
            this.txtFim.NaoAjustarEdicao = true;
            this.txtFim.Obrigatorio = false;
            this.txtFim.ObrigatorioMensagem = null;
            this.txtFim.PreValidacaoMensagem = null;
            this.txtFim.PreValidado = false;
            this.txtFim.SelectAllOnFocus = false;
            this.txtFim.Size = new System.Drawing.Size(80, 20);
            this.txtFim.TabIndex = 2;
            this.txtFim.TabStop = false;
            // 
            // txtInicio
            // 
            this.txtInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Limpar = true;
            this.txtInicio.Location = new System.Drawing.Point(46, 22);
            this.txtInicio.MaxLength = 10;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.NaoAjustarEdicao = true;
            this.txtInicio.Obrigatorio = false;
            this.txtInicio.ObrigatorioMensagem = null;
            this.txtInicio.PreValidacaoMensagem = null;
            this.txtInicio.PreValidado = false;
            this.txtInicio.SelectAllOnFocus = false;
            this.txtInicio.Size = new System.Drawing.Size(80, 20);
            this.txtInicio.TabIndex = 1;
            this.txtInicio.TabStop = false;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(128, 26);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(27, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(7, 26);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 28;
            this.hacLabel6.Text = "Início";
            // 
            // dtgSetores
            // 
            this.dtgSetores.AllowUserToAddRows = false;
            this.dtgSetores.AllowUserToDeleteRows = false;
            this.dtgSetores.AllowUserToResizeColumns = false;
            this.dtgSetores.AllowUserToResizeRows = false;
            this.dtgSetores.AlterarStatus = true;
            this.dtgSetores.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSetores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSetores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSetores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEstoque,
            this.colUnidade,
            this.colSetor});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSetores.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgSetores.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgSetores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgSetores.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgSetores.GridPesquisa = false;
            this.dtgSetores.Limpar = true;
            this.dtgSetores.Location = new System.Drawing.Point(10, 105);
            this.dtgSetores.Name = "dtgSetores";
            this.dtgSetores.NaoAjustarEdicao = true;
            this.dtgSetores.Obrigatorio = false;
            this.dtgSetores.ObrigatorioMensagem = null;
            this.dtgSetores.PreValidacaoMensagem = null;
            this.dtgSetores.PreValidado = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSetores.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgSetores.RowHeadersVisible = false;
            this.dtgSetores.RowHeadersWidth = 21;
            this.dtgSetores.RowTemplate.Height = 18;
            this.dtgSetores.Size = new System.Drawing.Size(580, 312);
            this.dtgSetores.TabIndex = 2;
            // 
            // colEstoque
            // 
            this.colEstoque.DataPropertyName = "ESTOQUE";
            this.colEstoque.HeaderText = "Estoque";
            this.colEstoque.Name = "colEstoque";
            this.colEstoque.ReadOnly = true;
            this.colEstoque.Width = 60;
            // 
            // colUnidade
            // 
            this.colUnidade.DataPropertyName = "UNIDADE";
            this.colUnidade.HeaderText = "Unidade";
            this.colUnidade.Name = "colUnidade";
            this.colUnidade.ReadOnly = true;
            this.colUnidade.Width = 250;
            // 
            // colSetor
            // 
            this.colSetor.DataPropertyName = "SETOR";
            dataGridViewCellStyle2.NullValue = null;
            this.colSetor.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSetor.HeaderText = "Setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.ReadOnly = true;
            this.colSetor.Width = 250;
            // 
            // grbEstoque
            // 
            this.grbEstoque.Controls.Add(this.rbCE);
            this.grbEstoque.Controls.Add(this.rbHac);
            this.grbEstoque.Controls.Add(this.rbAcs);
            this.grbEstoque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEstoque.Location = new System.Drawing.Point(273, 38);
            this.grbEstoque.Name = "grbEstoque";
            this.grbEstoque.Size = new System.Drawing.Size(157, 53);
            this.grbEstoque.TabIndex = 2;
            this.grbEstoque.TabStop = false;
            this.grbEstoque.Text = "Estoque";
            this.grbEstoque.Visible = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(112, 22);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(41, 17);
            this.rbCE.TabIndex = 3;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(7, 22);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(50, 17);
            this.rbHac.TabIndex = 1;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(60, 22);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(50, 17);
            this.rbAcs.TabIndex = 2;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            // 
            // grbRelatorio
            // 
            this.grbRelatorio.Controls.Add(this.rbDemonstSintetico);
            this.grbRelatorio.Controls.Add(this.rbDigita);
            this.grbRelatorio.Controls.Add(this.rbDemonstAnalitico);
            this.grbRelatorio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbRelatorio.Location = new System.Drawing.Point(10, 105);
            this.grbRelatorio.Name = "grbRelatorio";
            this.grbRelatorio.Size = new System.Drawing.Size(580, 98);
            this.grbRelatorio.TabIndex = 3;
            this.grbRelatorio.TabStop = false;
            this.grbRelatorio.Text = "Relatório";
            this.grbRelatorio.Visible = false;
            // 
            // rbDemonstSintetico
            // 
            this.rbDemonstSintetico.AutoSize = true;
            this.rbDemonstSintetico.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbDemonstSintetico.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDemonstSintetico.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDemonstSintetico.Limpar = true;
            this.rbDemonstSintetico.Location = new System.Drawing.Point(7, 67);
            this.rbDemonstSintetico.Name = "rbDemonstSintetico";
            this.rbDemonstSintetico.Obrigatorio = false;
            this.rbDemonstSintetico.ObrigatorioMensagem = "";
            this.rbDemonstSintetico.PreValidacaoMensagem = null;
            this.rbDemonstSintetico.PreValidado = false;
            this.rbDemonstSintetico.Size = new System.Drawing.Size(449, 17);
            this.rbDemonstSintetico.TabIndex = 3;
            this.rbDemonstSintetico.TabStop = true;
            this.rbDemonstSintetico.Text = "Demonstrativo geral da contagem efetuada dos setores sintético";
            this.rbDemonstSintetico.UseVisualStyleBackColor = true;
            // 
            // rbDigita
            // 
            this.rbDigita.AutoSize = true;
            this.rbDigita.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbDigita.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDigita.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDigita.Limpar = true;
            this.rbDigita.Location = new System.Drawing.Point(7, 21);
            this.rbDigita.Name = "rbDigita";
            this.rbDigita.Obrigatorio = false;
            this.rbDigita.ObrigatorioMensagem = null;
            this.rbDigita.PreValidacaoMensagem = null;
            this.rbDigita.PreValidado = false;
            this.rbDigita.Size = new System.Drawing.Size(210, 17);
            this.rbDigita.TabIndex = 1;
            this.rbDigita.Text = "Digitação final geral setores";
            this.rbDigita.UseVisualStyleBackColor = true;
            // 
            // rbDemonstAnalitico
            // 
            this.rbDemonstAnalitico.AutoSize = true;
            this.rbDemonstAnalitico.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbDemonstAnalitico.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDemonstAnalitico.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDemonstAnalitico.Limpar = true;
            this.rbDemonstAnalitico.Location = new System.Drawing.Point(7, 44);
            this.rbDemonstAnalitico.Name = "rbDemonstAnalitico";
            this.rbDemonstAnalitico.Obrigatorio = false;
            this.rbDemonstAnalitico.ObrigatorioMensagem = null;
            this.rbDemonstAnalitico.PreValidacaoMensagem = null;
            this.rbDemonstAnalitico.PreValidado = false;
            this.rbDemonstAnalitico.Size = new System.Drawing.Size(449, 17);
            this.rbDemonstAnalitico.TabIndex = 2;
            this.rbDemonstAnalitico.Text = "Demonstrativo geral da contagem efetuada dos setores analítico";
            this.rbDemonstAnalitico.UseVisualStyleBackColor = true;
            // 
            // FrmRelSetoresInvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 423);
            this.Controls.Add(this.grbRelatorio);
            this.Controls.Add(this.grbEstoque);
            this.Controls.Add(this.dtgSetores);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmRelSetoresInvent";
            this.Text = "Relatório para Gestão de Inventário";
            this.Load += new System.EventHandler(this.FrmRelSetoresInvent_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSetores)).EndInit();
            this.grbEstoque.ResumeLayout(false);
            this.grbEstoque.PerformLayout();
            this.grbRelatorio.ResumeLayout(false);
            this.grbRelatorio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacTextBox txtInicio;
        private SGS.Componentes.HacTextBox txtFim;        
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacDataGridView dtgSetores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.GroupBox grbEstoque;
        private SGS.Componentes.HacRadioButton rbCE;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacRadioButton rbAcs;
        private System.Windows.Forms.GroupBox grbRelatorio;
        private SGS.Componentes.HacRadioButton rbDemonstSintetico;
        private SGS.Componentes.HacRadioButton rbDigita;
        private SGS.Componentes.HacRadioButton rbDemonstAnalitico;
    }
}