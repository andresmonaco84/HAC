using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmIndiceRotatividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIndiceRotatividade));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbAnaFinanc = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMes = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtAno = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.lblObs = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chbRelResumido = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
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
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(583, 28);
            this.tsHac.TabIndex = 122;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Relatório de Índice de Rotatividade de Produtos";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbRelResumido);
            this.groupBox1.Controls.Add(this.chbAnaFinanc);
            this.groupBox1.Controls.Add(this.btnLimparProduto);
            this.groupBox1.Controls.Add(this.hacLabel4);
            this.groupBox1.Controls.Add(this.txtMes);
            this.groupBox1.Controls.Add(this.txtAno);
            this.groupBox1.Controls.Add(this.hacLabel5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.lblProduto);
            this.groupBox1.Controls.Add(this.hacLabel3);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Controls.Add(this.cmbSubGrupo);
            this.groupBox1.Controls.Add(this.hacLabel1);
            this.groupBox1.Controls.Add(this.cmbGrupo);
            this.groupBox1.Location = new System.Drawing.Point(10, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 176);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleção de Filtro";
            // 
            // chbAnaFinanc
            // 
            this.chbAnaFinanc.AutoSize = true;
            this.chbAnaFinanc.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbAnaFinanc.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbAnaFinanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAnaFinanc.Limpar = true;
            this.chbAnaFinanc.Location = new System.Drawing.Point(323, 26);
            this.chbAnaFinanc.Name = "chbAnaFinanc";
            this.chbAnaFinanc.Obrigatorio = false;
            this.chbAnaFinanc.ObrigatorioMensagem = null;
            this.chbAnaFinanc.PreValidacaoMensagem = null;
            this.chbAnaFinanc.PreValidado = false;
            this.chbAnaFinanc.Size = new System.Drawing.Size(225, 17);
            this.chbAnaFinanc.TabIndex = 124;
            this.chbAnaFinanc.Text = "ANÁLISE FINANCEIRA (estimativa)";
            this.chbAnaFinanc.UseVisualStyleBackColor = true;
            this.chbAnaFinanc.Click += new System.EventHandler(this.chbAnaFinanc_Click);
            // 
            // btnLimparProduto
            // 
            this.btnLimparProduto.AlterarStatus = true;
            this.btnLimparProduto.BackColor = System.Drawing.Color.White;
            this.btnLimparProduto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimparProduto.BackgroundImage")));
            this.btnLimparProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimparProduto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnLimparProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparProduto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnLimparProduto.Location = new System.Drawing.Point(397, 118);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 155;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Visible = false;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(122, 27);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(12, 13);
            this.hacLabel4.TabIndex = 143;
            this.hacLabel4.Text = "/";
            // 
            // txtMes
            // 
            this.txtMes.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMes.BackColor = System.Drawing.Color.Honeydew;
            this.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtMes.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMes.Limpar = false;
            this.txtMes.Location = new System.Drawing.Point(90, 23);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.NaoAjustarEdicao = true;
            this.txtMes.Obrigatorio = false;
            this.txtMes.ObrigatorioMensagem = null;
            this.txtMes.PreValidacaoMensagem = null;
            this.txtMes.PreValidado = false;
            this.txtMes.SelectAllOnFocus = false;
            this.txtMes.Size = new System.Drawing.Size(30, 21);
            this.txtMes.TabIndex = 141;
            // 
            // txtAno
            // 
            this.txtAno.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtAno.BackColor = System.Drawing.Color.Honeydew;
            this.txtAno.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAno.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAno.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAno.Limpar = false;
            this.txtAno.Location = new System.Drawing.Point(136, 23);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.NaoAjustarEdicao = true;
            this.txtAno.Obrigatorio = false;
            this.txtAno.ObrigatorioMensagem = "";
            this.txtAno.PreValidacaoMensagem = "";
            this.txtAno.PreValidado = false;
            this.txtAno.SelectAllOnFocus = false;
            this.txtAno.Size = new System.Drawing.Size(40, 21);
            this.txtAno.TabIndex = 142;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(16, 28);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(56, 13);
            this.hacLabel5.TabIndex = 140;
            this.hacLabel5.Text = "Mês/Ano";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbAcs);
            this.groupBox4.Controls.Add(this.rbHac);
            this.groupBox4.Location = new System.Drawing.Point(197, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(111, 36);
            this.groupBox4.TabIndex = 139;
            this.groupBox4.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = false;
            this.rbAcs.Location = new System.Drawing.Point(59, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 1;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(6, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 0;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(87, 121);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 14);
            this.lblProduto.TabIndex = 129;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(16, 122);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(51, 13);
            this.hacLabel3.TabIndex = 128;
            this.hacLabel3.Text = "Produto";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(15, 90);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(69, 13);
            this.hacLabel2.TabIndex = 127;
            this.hacLabel2.Text = "Sub-Grupo";
            // 
            // cmbSubGrupo
            // 
            this.cmbSubGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSubGrupo.DisplayMember = "CAD_MTMD_SUBGRUPO_DESCRICAO";
            this.cmbSubGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbSubGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSubGrupo.FormattingEnabled = true;
            this.cmbSubGrupo.Limpar = false;
            this.cmbSubGrupo.Location = new System.Drawing.Point(90, 86);
            this.cmbSubGrupo.Name = "cmbSubGrupo";
            this.cmbSubGrupo.Obrigatorio = false;
            this.cmbSubGrupo.ObrigatorioMensagem = null;
            this.cmbSubGrupo.PreValidacaoMensagem = null;
            this.cmbSubGrupo.PreValidado = false;
            this.cmbSubGrupo.Size = new System.Drawing.Size(412, 21);
            this.cmbSubGrupo.TabIndex = 126;
            this.cmbSubGrupo.Text = "<Selecione>";
            this.cmbSubGrupo.ValueMember = "CAD_MTMD_SUBGRUPO_ID";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(15, 61);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(42, 13);
            this.hacLabel1.TabIndex = 125;
            this.hacLabel1.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbGrupo.DisplayMember = "CAD_MTMD_GRUPO_DESCRICAO";
            this.cmbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Limpar = false;
            this.cmbGrupo.Location = new System.Drawing.Point(90, 56);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Obrigatorio = false;
            this.cmbGrupo.ObrigatorioMensagem = null;
            this.cmbGrupo.PreValidacaoMensagem = null;
            this.cmbGrupo.PreValidado = false;
            this.cmbGrupo.Size = new System.Drawing.Size(412, 21);
            this.cmbGrupo.TabIndex = 124;
            this.cmbGrupo.Text = "<Selecione>";
            this.cmbGrupo.ValueMember = "CAD_MTMD_GRUPO_ID";
            this.cmbGrupo.SelectionChangeCommitted += new System.EventHandler(this.cmbGrupo_SelectionChangeCommitted);
            // 
            // lblObs
            // 
            this.lblObs.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblObs.ForeColor = System.Drawing.Color.Red;
            this.lblObs.Location = new System.Drawing.Point(9, 221);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(500, 41);
            this.lblObs.TabIndex = 129;
            this.lblObs.Text = "Atenção: O consumo dos 3 últimos meses é demonstrado quando a referência for o MÊ" +
    "S/ANO corrente";
            // 
            // chbRelResumido
            // 
            this.chbRelResumido.AutoSize = true;
            this.chbRelResumido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbRelResumido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbRelResumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRelResumido.Limpar = true;
            this.chbRelResumido.Location = new System.Drawing.Point(20, 151);
            this.chbRelResumido.Name = "chbRelResumido";
            this.chbRelResumido.Obrigatorio = false;
            this.chbRelResumido.ObrigatorioMensagem = null;
            this.chbRelResumido.PreValidacaoMensagem = null;
            this.chbRelResumido.PreValidado = false;
            this.chbRelResumido.Size = new System.Drawing.Size(167, 17);
            this.chbRelResumido.TabIndex = 130;
            this.chbRelResumido.Text = "RELATÓRIO RESUMIDO";
            this.chbRelResumido.UseVisualStyleBackColor = true;
            // 
            // FrmIndiceRotatividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 267);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmIndiceRotatividade";
            this.Text = "Relatórios para Gestão de Estoque";
            this.Load += new System.EventHandler(this.FrmIndiceRotatividade_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacLabel hacLabel2;
        private HacComboBox cmbSubGrupo;
        private HacLabel hacLabel1;
        private HacComboBox cmbGrupo;
        private HacLabel lblProduto;
        private HacLabel hacLabel3;
        private HacLabel hacLabel4;
        private HacTextBox txtMes;
        private HacTextBox txtAno;
        private HacLabel hacLabel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacButton btnLimparProduto;
        private HacCheckBox chbAnaFinanc;
        private HacLabel lblObs;
        private HacCheckBox chbRelResumido;
    }
}