namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmRelConsumoGrupoMercado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelConsumoGrupoMercado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.dtg = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.ANO_MES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.radUltimos3meses = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.radMesAtual = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.grbFilial.SuspendLayout();
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
            this.tsHac.Size = new System.Drawing.Size(621, 28);
            this.tsHac.TabIndex = 126;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Consumo de Drogas e Medicamentos por Grupo e Mercado";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.AfterPesquisar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterPesquisar);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Controls.Add(this.dtg);
            this.groupBox1.Controls.Add(this.grbFilial);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 489);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.AlterarStatus = true;
            this.btnPesquisar.BackColor = System.Drawing.Color.White;
            this.btnPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.BackgroundImage")));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(463, 46);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(105, 22);
            this.btnPesquisar.TabIndex = 89;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Visible = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dtg
            // 
            this.dtg.AllowUserToAddRows = false;
            this.dtg.AllowUserToDeleteRows = false;
            this.dtg.AllowUserToResizeColumns = false;
            this.dtg.AllowUserToResizeRows = false;
            this.dtg.AlterarStatus = true;
            this.dtg.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ANO_MES,
            this.TP,
            this.VALOR});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtg.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtg.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtg.GridPesquisa = false;
            this.dtg.Limpar = true;
            this.dtg.Location = new System.Drawing.Point(57, 114);
            this.dtg.Name = "dtg";
            this.dtg.NaoAjustarEdicao = false;
            this.dtg.Obrigatorio = false;
            this.dtg.ObrigatorioMensagem = null;
            this.dtg.PreValidacaoMensagem = null;
            this.dtg.PreValidado = false;
            this.dtg.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtg.RowHeadersWidth = 25;
            this.dtg.Size = new System.Drawing.Size(472, 308);
            this.dtg.TabIndex = 88;
            // 
            // ANO_MES
            // 
            this.ANO_MES.DataPropertyName = "ANO_MES";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = null;
            this.ANO_MES.DefaultCellStyle = dataGridViewCellStyle2;
            this.ANO_MES.HeaderText = "Mês / Ano";
            this.ANO_MES.Name = "ANO_MES";
            this.ANO_MES.ReadOnly = true;
            this.ANO_MES.Width = 130;
            // 
            // TP
            // 
            this.TP.DataPropertyName = "TP";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.TP.DefaultCellStyle = dataGridViewCellStyle3;
            this.TP.HeaderText = "Tipo";
            this.TP.Name = "TP";
            this.TP.ReadOnly = true;
            this.TP.Width = 150;
            // 
            // VALOR
            // 
            this.VALOR.DataPropertyName = "VALOR";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.VALOR.DefaultCellStyle = dataGridViewCellStyle4;
            this.VALOR.HeaderText = "Valor";
            this.VALOR.Name = "VALOR";
            this.VALOR.ReadOnly = true;
            this.VALOR.Width = 130;
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.radUltimos3meses);
            this.grbFilial.Controls.Add(this.radMesAtual);
            this.grbFilial.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFilial.Location = new System.Drawing.Point(56, 23);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(388, 60);
            this.grbFilial.TabIndex = 5;
            this.grbFilial.TabStop = false;
            this.grbFilial.Text = "Prévia / Estimativa";
            // 
            // radUltimos3meses
            // 
            this.radUltimos3meses.AutoSize = true;
            this.radUltimos3meses.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.radUltimos3meses.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.radUltimos3meses.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radUltimos3meses.Limpar = false;
            this.radUltimos3meses.Location = new System.Drawing.Point(206, 27);
            this.radUltimos3meses.Name = "radUltimos3meses";
            this.radUltimos3meses.Obrigatorio = false;
            this.radUltimos3meses.ObrigatorioMensagem = null;
            this.radUltimos3meses.PreValidacaoMensagem = null;
            this.radUltimos3meses.PreValidado = false;
            this.radUltimos3meses.Size = new System.Drawing.Size(131, 18);
            this.radUltimos3meses.TabIndex = 2;
            this.radUltimos3meses.Text = " Últimos 3 meses";
            this.radUltimos3meses.UseVisualStyleBackColor = true;
            // 
            // radMesAtual
            // 
            this.radMesAtual.AutoSize = true;
            this.radMesAtual.Checked = true;
            this.radMesAtual.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.radMesAtual.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.radMesAtual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMesAtual.Limpar = false;
            this.radMesAtual.Location = new System.Drawing.Point(42, 27);
            this.radMesAtual.Name = "radMesAtual";
            this.radMesAtual.Obrigatorio = false;
            this.radMesAtual.ObrigatorioMensagem = null;
            this.radMesAtual.PreValidacaoMensagem = null;
            this.radMesAtual.PreValidado = false;
            this.radMesAtual.Size = new System.Drawing.Size(85, 18);
            this.radMesAtual.TabIndex = 1;
            this.radMesAtual.TabStop = true;
            this.radMesAtual.Text = "mês atual";
            this.radMesAtual.UseVisualStyleBackColor = true;
            // 
            // FrmRelConsumoGrupoMercado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 532);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmRelConsumoGrupoMercado";
            this.Text = "FrmRelConsumoGrupoMercado";
            this.Load += new System.EventHandler(this.FrmRelConsumoGrupoMercado_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbFilial;
        private SGS.Componentes.HacRadioButton radUltimos3meses;
        private SGS.Componentes.HacRadioButton radMesAtual;
        private SGS.Componentes.HacDataGridView dtg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANO_MES;
        private System.Windows.Forms.DataGridViewTextBoxColumn TP;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR;
        private SGS.Componentes.HacButton btnPesquisar;
    }
}