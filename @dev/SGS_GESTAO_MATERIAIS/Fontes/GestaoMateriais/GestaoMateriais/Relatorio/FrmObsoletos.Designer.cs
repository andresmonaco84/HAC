namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmObsoletos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObsoletos));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.gbFecha = new System.Windows.Forms.GroupBox();
            this.grbFilial = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.gbCobrados = new System.Windows.Forms.GroupBox();
            this.rbCobradosAmbos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbNaoCobrados = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbCobrados = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.chbSemEstoque = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbFecha = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.gbFecha.SuspendLayout();
            this.grbFilial.SuspendLayout();
            this.gbCobrados.SuspendLayout();
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
            this.tsHac.Size = new System.Drawing.Size(523, 28);
            this.tsHac.TabIndex = 126;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Relatório de Produtos Obsoletos";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            // 
            // gbFecha
            // 
            this.gbFecha.Controls.Add(this.grbFilial);
            this.gbFecha.Controls.Add(this.txtFim);
            this.gbFecha.Controls.Add(this.txtInicio);
            this.gbFecha.Controls.Add(this.hacLabel5);
            this.gbFecha.Controls.Add(this.hacLabel6);
            this.gbFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFecha.Location = new System.Drawing.Point(16, 106);
            this.gbFecha.Name = "gbFecha";
            this.gbFecha.Size = new System.Drawing.Size(457, 53);
            this.gbFecha.TabIndex = 3;
            this.gbFecha.TabStop = false;
            this.gbFecha.Text = "Período para pesquisa";
            // 
            // grbFilial
            // 
            this.grbFilial.Controls.Add(this.rbAcs);
            this.grbFilial.Controls.Add(this.rbHac);
            this.grbFilial.Location = new System.Drawing.Point(325, 9);
            this.grbFilial.Name = "grbFilial";
            this.grbFilial.Size = new System.Drawing.Size(123, 36);
            this.grbFilial.TabIndex = 6;
            this.grbFilial.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = false;
            this.rbAcs.Location = new System.Drawing.Point(63, 13);
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
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(10, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(50, 17);
            this.rbHac.TabIndex = 1;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // txtFim
            // 
            this.txtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Limpar = true;
            this.txtFim.Location = new System.Drawing.Point(230, 21);
            this.txtFim.MaxLength = 10;
            this.txtFim.Name = "txtFim";
            this.txtFim.NaoAjustarEdicao = true;
            this.txtFim.Obrigatorio = false;
            this.txtFim.ObrigatorioMensagem = null;
            this.txtFim.PreValidacaoMensagem = null;
            this.txtFim.PreValidado = false;
            this.txtFim.SelectAllOnFocus = false;
            this.txtFim.Size = new System.Drawing.Size(80, 20);
            this.txtFim.TabIndex = 5;
            this.txtFim.TabStop = false;
            // 
            // txtInicio
            // 
            this.txtInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Limpar = true;
            this.txtInicio.Location = new System.Drawing.Point(45, 21);
            this.txtInicio.MaxLength = 10;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.NaoAjustarEdicao = true;
            this.txtInicio.Obrigatorio = false;
            this.txtInicio.ObrigatorioMensagem = null;
            this.txtInicio.PreValidacaoMensagem = null;
            this.txtInicio.PreValidado = false;
            this.txtInicio.SelectAllOnFocus = false;
            this.txtInicio.Size = new System.Drawing.Size(80, 20);
            this.txtInicio.TabIndex = 4;
            this.txtInicio.TabStop = false;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(128, 25);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(100, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim Fechamento";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(6, 25);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 28;
            this.hacLabel6.Text = "Início";
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(13, 47);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(42, 13);
            this.hacLabel9.TabIndex = 130;
            this.hacLabel9.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbGrupo.DisplayMember = "CAD_MTMD_GRUPO_DESCRICAO";
            this.cmbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Limpar = true;
            this.cmbGrupo.Location = new System.Drawing.Point(61, 44);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Obrigatorio = false;
            this.cmbGrupo.ObrigatorioMensagem = null;
            this.cmbGrupo.PreValidacaoMensagem = null;
            this.cmbGrupo.PreValidado = false;
            this.cmbGrupo.Size = new System.Drawing.Size(412, 21);
            this.cmbGrupo.TabIndex = 1;
            this.cmbGrupo.Text = "<Selecione>";
            this.cmbGrupo.ValueMember = "CAD_MTMD_GRUPO_ID";
            // 
            // gbCobrados
            // 
            this.gbCobrados.Controls.Add(this.rbCobradosAmbos);
            this.gbCobrados.Controls.Add(this.rbNaoCobrados);
            this.gbCobrados.Controls.Add(this.rbCobrados);
            this.gbCobrados.Location = new System.Drawing.Point(16, 197);
            this.gbCobrados.Name = "gbCobrados";
            this.gbCobrados.Size = new System.Drawing.Size(288, 36);
            this.gbCobrados.TabIndex = 8;
            this.gbCobrados.TabStop = false;
            // 
            // rbCobradosAmbos
            // 
            this.rbCobradosAmbos.AutoSize = true;
            this.rbCobradosAmbos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCobradosAmbos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCobradosAmbos.Limpar = false;
            this.rbCobradosAmbos.Location = new System.Drawing.Point(213, 13);
            this.rbCobradosAmbos.Name = "rbCobradosAmbos";
            this.rbCobradosAmbos.Obrigatorio = false;
            this.rbCobradosAmbos.ObrigatorioMensagem = null;
            this.rbCobradosAmbos.PreValidacaoMensagem = null;
            this.rbCobradosAmbos.PreValidado = false;
            this.rbCobradosAmbos.Size = new System.Drawing.Size(63, 17);
            this.rbCobradosAmbos.TabIndex = 3;
            this.rbCobradosAmbos.Text = "AMBOS";
            this.rbCobradosAmbos.UseVisualStyleBackColor = true;
            // 
            // rbNaoCobrados
            // 
            this.rbNaoCobrados.AutoSize = true;
            this.rbNaoCobrados.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbNaoCobrados.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbNaoCobrados.Limpar = false;
            this.rbNaoCobrados.Location = new System.Drawing.Point(97, 13);
            this.rbNaoCobrados.Name = "rbNaoCobrados";
            this.rbNaoCobrados.Obrigatorio = false;
            this.rbNaoCobrados.ObrigatorioMensagem = null;
            this.rbNaoCobrados.PreValidacaoMensagem = null;
            this.rbNaoCobrados.PreValidado = false;
            this.rbNaoCobrados.Size = new System.Drawing.Size(111, 17);
            this.rbNaoCobrados.TabIndex = 2;
            this.rbNaoCobrados.Text = "NÃO COBRADOS";
            this.rbNaoCobrados.UseVisualStyleBackColor = true;
            // 
            // rbCobrados
            // 
            this.rbCobrados.AutoSize = true;
            this.rbCobrados.Checked = true;
            this.rbCobrados.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCobrados.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCobrados.Limpar = false;
            this.rbCobrados.Location = new System.Drawing.Point(10, 13);
            this.rbCobrados.Name = "rbCobrados";
            this.rbCobrados.Obrigatorio = false;
            this.rbCobrados.ObrigatorioMensagem = null;
            this.rbCobrados.PreValidacaoMensagem = null;
            this.rbCobrados.PreValidado = false;
            this.rbCobrados.Size = new System.Drawing.Size(85, 17);
            this.rbCobrados.TabIndex = 1;
            this.rbCobrados.TabStop = true;
            this.rbCobrados.Text = "COBRADOS";
            this.rbCobrados.UseVisualStyleBackColor = true;
            // 
            // chbSemEstoque
            // 
            this.chbSemEstoque.AutoSize = true;
            this.chbSemEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbSemEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbSemEstoque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.chbSemEstoque.Limpar = true;
            this.chbSemEstoque.Location = new System.Drawing.Point(16, 177);
            this.chbSemEstoque.Name = "chbSemEstoque";
            this.chbSemEstoque.Obrigatorio = false;
            this.chbSemEstoque.ObrigatorioMensagem = null;
            this.chbSemEstoque.PreValidacaoMensagem = null;
            this.chbSemEstoque.PreValidado = false;
            this.chbSemEstoque.Size = new System.Drawing.Size(404, 17);
            this.chbSemEstoque.TabIndex = 7;
            this.chbSemEstoque.Text = "Produtos sem estoque e sem compra nos últimos 6 meses";
            this.chbSemEstoque.UseVisualStyleBackColor = true;
            this.chbSemEstoque.Click += new System.EventHandler(this.chbSemEstoque_Click);
            // 
            // chbFecha
            // 
            this.chbFecha.AutoSize = true;
            this.chbFecha.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbFecha.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.chbFecha.Limpar = true;
            this.chbFecha.Location = new System.Drawing.Point(16, 79);
            this.chbFecha.Name = "chbFecha";
            this.chbFecha.Obrigatorio = false;
            this.chbFecha.ObrigatorioMensagem = null;
            this.chbFecha.PreValidacaoMensagem = null;
            this.chbFecha.PreValidado = false;
            this.chbFecha.Size = new System.Drawing.Size(314, 17);
            this.chbFecha.TabIndex = 2;
            this.chbFecha.Text = "Produtos com estoque e sem movimentação";
            this.chbFecha.UseVisualStyleBackColor = true;
            this.chbFecha.Click += new System.EventHandler(this.chbFecha_Click);
            // 
            // FrmObsoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 245);
            this.Controls.Add(this.chbFecha);
            this.Controls.Add(this.chbSemEstoque);
            this.Controls.Add(this.gbCobrados);
            this.Controls.Add(this.hacLabel9);
            this.Controls.Add(this.cmbGrupo);
            this.Controls.Add(this.gbFecha);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmObsoletos";
            this.Text = "Relatório de Produtos Obsoletos";
            this.Load += new System.EventHandler(this.FrmObsoletos_Load);
            this.gbFecha.ResumeLayout(false);
            this.gbFecha.PerformLayout();
            this.grbFilial.ResumeLayout(false);
            this.grbFilial.PerformLayout();
            this.gbCobrados.ResumeLayout(false);
            this.gbCobrados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox gbFecha;
        private SGS.Componentes.HacTextBox txtFim;
        private SGS.Componentes.HacTextBox txtInicio;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacLabel hacLabel9;
        private SGS.Componentes.HacComboBox cmbGrupo;
        private System.Windows.Forms.GroupBox gbCobrados;
        private SGS.Componentes.HacRadioButton rbCobradosAmbos;
        private SGS.Componentes.HacRadioButton rbNaoCobrados;
        private SGS.Componentes.HacRadioButton rbCobrados;
        private SGS.Componentes.HacCheckBox chbSemEstoque;
        private System.Windows.Forms.GroupBox grbFilial;
        private SGS.Componentes.HacRadioButton rbAcs;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacCheckBox chbFecha;
    }
}