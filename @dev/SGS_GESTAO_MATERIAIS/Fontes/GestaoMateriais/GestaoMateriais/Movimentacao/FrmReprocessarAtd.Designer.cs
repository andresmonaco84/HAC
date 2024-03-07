namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmReprocessarAtd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReprocessarAtd));
            this.txtAtd = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbPeriodo = new System.Windows.Forms.GroupBox();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtMinIni = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtHoraIni = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtMinFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);            
            this.txtHoraFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cbPeriodoCompleto = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.cbDuplicar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnReprocessar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbPeriodo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAtd
            // 
            this.txtAtd.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAtd.BackColor = System.Drawing.Color.Honeydew;
            this.txtAtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAtd.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAtd.Enabled = false;
            this.txtAtd.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAtd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAtd.Limpar = true;
            this.txtAtd.Location = new System.Drawing.Point(100, 45);
            this.txtAtd.MaxLength = 10;
            this.txtAtd.Name = "txtAtd";
            this.txtAtd.NaoAjustarEdicao = false;
            this.txtAtd.Obrigatorio = true;
            this.txtAtd.ObrigatorioMensagem = "Campo DE Obrigatório";
            this.txtAtd.PreValidacaoMensagem = null;
            this.txtAtd.PreValidado = false;
            this.txtAtd.SelectAllOnFocus = false;
            this.txtAtd.Size = new System.Drawing.Size(76, 21);
            this.txtAtd.TabIndex = 107;
            this.txtAtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(16, 48);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(79, 13);
            this.hacLabel4.TabIndex = 108;
            this.hacLabel4.Text = "Atendimento";
            // 
            // grbPeriodo
            // 
            this.grbPeriodo.Controls.Add(this.hacLabel7);
            this.grbPeriodo.Controls.Add(this.hacLabel3);
            this.grbPeriodo.Controls.Add(this.hacLabel2);
            this.grbPeriodo.Controls.Add(this.hacLabel1);
            this.grbPeriodo.Controls.Add(this.txtInicio);
            this.grbPeriodo.Controls.Add(this.txtMinIni);
            this.grbPeriodo.Controls.Add(this.txtHoraIni);
            this.grbPeriodo.Controls.Add(this.txtFim);
            this.grbPeriodo.Controls.Add(this.txtMinFim);
            this.grbPeriodo.Controls.Add(this.txtHoraFim);            
            this.grbPeriodo.Controls.Add(this.hacLabel5);
            this.grbPeriodo.Controls.Add(this.hacLabel6);
            this.grbPeriodo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPeriodo.Location = new System.Drawing.Point(17, 106);
            this.grbPeriodo.Name = "grbPeriodo";
            this.grbPeriodo.Size = new System.Drawing.Size(254, 77);
            this.grbPeriodo.TabIndex = 109;
            this.grbPeriodo.TabStop = false;
            this.grbPeriodo.Text = "Período p/ Reprocessamento";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(206, 52);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(12, 13);
            this.hacLabel7.TabIndex = 129;
            this.hacLabel7.Text = ":";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(206, 25);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(12, 13);
            this.hacLabel3.TabIndex = 111;
            this.hacLabel3.Text = ":";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(135, 53);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(48, 13);
            this.hacLabel2.TabIndex = 31;
            this.hacLabel2.Text = "hh:mm";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(135, 26);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(48, 13);
            this.hacLabel1.TabIndex = 30;
            this.hacLabel1.Text = "hh:mm";            
            // 
            // txtInicio
            // 
            this.txtInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Limpar = false;
            this.txtInicio.Location = new System.Drawing.Point(48, 22);
            this.txtInicio.MaxLength = 10;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.NaoAjustarEdicao = true;
            this.txtInicio.Obrigatorio = false;
            this.txtInicio.ObrigatorioMensagem = null;
            this.txtInicio.PreValidacaoMensagem = null;
            this.txtInicio.PreValidado = false;
            this.txtInicio.SelectAllOnFocus = false;
            this.txtInicio.Size = new System.Drawing.Size(77, 20);
            this.txtInicio.TabIndex = 1;
            this.txtInicio.TabStop = false;
            // 
            // txtMinIni
            // 
            this.txtMinIni.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMinIni.BackColor = System.Drawing.Color.Honeydew;
            this.txtMinIni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMinIni.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMinIni.Enabled = false;
            this.txtMinIni.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtMinIni.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMinIni.Limpar = true;
            this.txtMinIni.Location = new System.Drawing.Point(216, 22);
            this.txtMinIni.MaxLength = 2;
            this.txtMinIni.Name = "txtMinIni";
            this.txtMinIni.NaoAjustarEdicao = false;
            this.txtMinIni.Obrigatorio = true;
            this.txtMinIni.ObrigatorioMensagem = "";
            this.txtMinIni.PreValidacaoMensagem = null;
            this.txtMinIni.PreValidado = false;
            this.txtMinIni.SelectAllOnFocus = false;
            this.txtMinIni.Size = new System.Drawing.Size(23, 21);
            this.txtMinIni.TabIndex = 3;
            this.txtMinIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHoraIni
            // 
            this.txtHoraIni.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtHoraIni.BackColor = System.Drawing.Color.Honeydew;
            this.txtHoraIni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHoraIni.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtHoraIni.Enabled = false;
            this.txtHoraIni.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtHoraIni.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtHoraIni.Limpar = true;
            this.txtHoraIni.Location = new System.Drawing.Point(185, 22);
            this.txtHoraIni.MaxLength = 2;
            this.txtHoraIni.Name = "txtHoraIni";
            this.txtHoraIni.NaoAjustarEdicao = false;
            this.txtHoraIni.Obrigatorio = true;
            this.txtHoraIni.ObrigatorioMensagem = "";
            this.txtHoraIni.PreValidacaoMensagem = null;
            this.txtHoraIni.PreValidado = false;
            this.txtHoraIni.SelectAllOnFocus = false;
            this.txtHoraIni.Size = new System.Drawing.Size(23, 21);
            this.txtHoraIni.TabIndex = 2;
            this.txtHoraIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFim
            // 
            this.txtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Limpar = false;
            this.txtFim.Location = new System.Drawing.Point(48, 49);
            this.txtFim.MaxLength = 10;
            this.txtFim.Name = "txtFim";
            this.txtFim.NaoAjustarEdicao = true;
            this.txtFim.Obrigatorio = false;
            this.txtFim.ObrigatorioMensagem = null;
            this.txtFim.PreValidacaoMensagem = null;
            this.txtFim.PreValidado = false;
            this.txtFim.SelectAllOnFocus = false;
            this.txtFim.Size = new System.Drawing.Size(77, 20);
            this.txtFim.TabIndex = 4;
            this.txtFim.TabStop = false;
            // 
            // txtMinFim
            // 
            this.txtMinFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMinFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtMinFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMinFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMinFim.Enabled = false;
            this.txtMinFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtMinFim.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMinFim.Limpar = true;
            this.txtMinFim.Location = new System.Drawing.Point(216, 49);
            this.txtMinFim.MaxLength = 2;
            this.txtMinFim.Name = "txtMinFim";
            this.txtMinFim.NaoAjustarEdicao = false;
            this.txtMinFim.Obrigatorio = true;
            this.txtMinFim.ObrigatorioMensagem = "";
            this.txtMinFim.PreValidacaoMensagem = null;
            this.txtMinFim.PreValidado = false;
            this.txtMinFim.SelectAllOnFocus = false;
            this.txtMinFim.Size = new System.Drawing.Size(23, 21);
            this.txtMinFim.TabIndex = 6;
            this.txtMinFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHoraFim
            // 
            this.txtHoraFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtHoraFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtHoraFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHoraFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtHoraFim.Enabled = false;
            this.txtHoraFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtHoraFim.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtHoraFim.Limpar = true;
            this.txtHoraFim.Location = new System.Drawing.Point(185, 49);
            this.txtHoraFim.MaxLength = 2;
            this.txtHoraFim.Name = "txtHoraFim";
            this.txtHoraFim.NaoAjustarEdicao = false;
            this.txtHoraFim.Obrigatorio = true;
            this.txtHoraFim.ObrigatorioMensagem = "";
            this.txtHoraFim.PreValidacaoMensagem = null;
            this.txtHoraFim.PreValidado = false;
            this.txtHoraFim.SelectAllOnFocus = false;
            this.txtHoraFim.Size = new System.Drawing.Size(23, 21);
            this.txtHoraFim.TabIndex = 5;
            this.txtHoraFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(22, 53);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(27, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(9, 26);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 28;
            this.hacLabel6.Text = "Início";
            // 
            // cbPeriodoCompleto
            // 
            this.cbPeriodoCompleto.AutoSize = true;
            this.cbPeriodoCompleto.Checked = true;
            this.cbPeriodoCompleto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPeriodoCompleto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbPeriodoCompleto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbPeriodoCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPeriodoCompleto.Limpar = false;
            this.cbPeriodoCompleto.Location = new System.Drawing.Point(21, 81);
            this.cbPeriodoCompleto.Name = "cbPeriodoCompleto";
            this.cbPeriodoCompleto.Obrigatorio = false;
            this.cbPeriodoCompleto.ObrigatorioMensagem = null;
            this.cbPeriodoCompleto.PreValidacaoMensagem = null;
            this.cbPeriodoCompleto.PreValidado = false;
            this.cbPeriodoCompleto.Size = new System.Drawing.Size(127, 17);
            this.cbPeriodoCompleto.TabIndex = 110;
            this.cbPeriodoCompleto.Text = "Período Completo";
            this.cbPeriodoCompleto.UseVisualStyleBackColor = true;
            this.cbPeriodoCompleto.Click += new System.EventHandler(this.cbPeriodoCompleto_Click);
            // 
            // cbDuplicar
            // 
            this.cbDuplicar.AutoSize = true;
            this.cbDuplicar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbDuplicar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbDuplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDuplicar.Limpar = false;
            this.cbDuplicar.Location = new System.Drawing.Point(186, 48);
            this.cbDuplicar.Name = "cbDuplicar";
            this.cbDuplicar.Obrigatorio = false;
            this.cbDuplicar.ObrigatorioMensagem = null;
            this.cbDuplicar.PreValidacaoMensagem = null;
            this.cbDuplicar.PreValidado = false;
            this.cbDuplicar.Size = new System.Drawing.Size(239, 17);
            this.cbDuplicar.TabIndex = 111;
            this.cbDuplicar.Text = "Duplicar no Faturamento (não excluir)";
            this.cbDuplicar.UseVisualStyleBackColor = true;
            // 
            // btnReprocessar
            // 
            this.btnReprocessar.AlterarStatus = true;
            this.btnReprocessar.BackColor = System.Drawing.Color.White;
            this.btnReprocessar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReprocessar.BackgroundImage")));
            this.btnReprocessar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprocessar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnReprocessar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprocessar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnReprocessar.Location = new System.Drawing.Point(279, 158);
            this.btnReprocessar.Name = "btnReprocessar";
            this.btnReprocessar.Size = new System.Drawing.Size(152, 22);
            this.btnReprocessar.TabIndex = 112;
            this.btnReprocessar.Text = "REPROCESSAR CONTA";
            this.btnReprocessar.UseVisualStyleBackColor = true;
            this.btnReprocessar.Click += new System.EventHandler(this.btnReprocessar_Click);
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
            this.tsHac.Size = new System.Drawing.Size(445, 28);
            this.tsHac.TabIndex = 126;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Reprocessamento de Conta";
            // 
            // FrmReprocessarAtd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 195);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.btnReprocessar);
            this.Controls.Add(this.cbDuplicar);
            this.Controls.Add(this.cbPeriodoCompleto);
            this.Controls.Add(this.grbPeriodo);
            this.Controls.Add(this.txtAtd);
            this.Controls.Add(this.hacLabel4);
            this.Name = "FrmReprocessarAtd";
            this.Text = "Reprocessamento de Conta";
            this.Titulo = "SGS";
            this.grbPeriodo.ResumeLayout(false);
            this.grbPeriodo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacTextBox txtAtd;
        private SGS.Componentes.HacLabel hacLabel4;
        private System.Windows.Forms.GroupBox grbPeriodo;
        private SGS.Componentes.HacTextBox txtFim;
        private SGS.Componentes.HacTextBox txtInicio;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacTextBox txtHoraIni;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacCheckBox cbPeriodoCompleto;
        private SGS.Componentes.HacCheckBox cbDuplicar;
        private SGS.Componentes.HacButton btnReprocessar;
        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacTextBox txtMinFim;
        private SGS.Componentes.HacTextBox txtHoraFim;
        private SGS.Componentes.HacTextBox txtMinIni;
    }
}