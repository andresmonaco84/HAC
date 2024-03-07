namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmInfMatMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInfMatMed));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMes = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtAno = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbSalvar = new System.Windows.Forms.GroupBox();
            this.chbReceita = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbEstoque = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.btnGerarDados = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.grbSalvar.SuspendLayout();
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
            this.tsHac.Size = new System.Drawing.Size(473, 28);
            this.tsHac.TabIndex = 125;
            this.tsHac.Text = "Relatório Inf. Mat/Med HAC/ACS";
            this.tsHac.TituloTela = "Relatório Inf. Mat/Med HAC/ACS";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(108, 48);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(12, 13);
            this.hacLabel3.TabIndex = 138;
            this.hacLabel3.Text = "/";
            // 
            // txtMes
            // 
            this.txtMes.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMes.BackColor = System.Drawing.Color.Honeydew;
            this.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtMes.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMes.Limpar = true;
            this.txtMes.Location = new System.Drawing.Point(76, 44);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.NaoAjustarEdicao = true;
            this.txtMes.Obrigatorio = false;
            this.txtMes.ObrigatorioMensagem = null;
            this.txtMes.PreValidacaoMensagem = null;
            this.txtMes.PreValidado = false;
            this.txtMes.SelectAllOnFocus = false;
            this.txtMes.Size = new System.Drawing.Size(30, 21);
            this.txtMes.TabIndex = 136;
            // 
            // txtAno
            // 
            this.txtAno.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAno.BackColor = System.Drawing.Color.Honeydew;
            this.txtAno.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAno.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAno.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAno.Limpar = true;
            this.txtAno.Location = new System.Drawing.Point(122, 44);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.NaoAjustarEdicao = true;
            this.txtAno.Obrigatorio = false;
            this.txtAno.ObrigatorioMensagem = "";
            this.txtAno.PreValidacaoMensagem = "";
            this.txtAno.PreValidado = false;
            this.txtAno.SelectAllOnFocus = false;
            this.txtAno.Size = new System.Drawing.Size(40, 21);
            this.txtAno.TabIndex = 137;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(17, 48);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(56, 13);
            this.hacLabel1.TabIndex = 135;
            this.hacLabel1.Text = "Mês/Ano";
            // 
            // grbSalvar
            // 
            this.grbSalvar.Controls.Add(this.btnGerarDados);
            this.grbSalvar.Controls.Add(this.chbReceita);
            this.grbSalvar.Controls.Add(this.chbEstoque);
            this.grbSalvar.Location = new System.Drawing.Point(20, 73);
            this.grbSalvar.Name = "grbSalvar";
            this.grbSalvar.Size = new System.Drawing.Size(348, 54);
            this.grbSalvar.TabIndex = 139;
            this.grbSalvar.TabStop = false;
            // 
            // chbReceita
            // 
            this.chbReceita.AutoSize = true;
            this.chbReceita.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbReceita.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbReceita.Limpar = true;
            this.chbReceita.Location = new System.Drawing.Point(144, 22);
            this.chbReceita.Name = "chbReceita";
            this.chbReceita.Obrigatorio = false;
            this.chbReceita.ObrigatorioMensagem = null;
            this.chbReceita.PreValidacaoMensagem = null;
            this.chbReceita.PreValidado = false;
            this.chbReceita.Size = new System.Drawing.Size(63, 17);
            this.chbReceita.TabIndex = 141;
            this.chbReceita.Text = "Receita";
            this.chbReceita.UseVisualStyleBackColor = true;
            // 
            // chbEstoque
            // 
            this.chbEstoque.AutoSize = true;
            this.chbEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbEstoque.Limpar = true;
            this.chbEstoque.Location = new System.Drawing.Point(11, 22);
            this.chbEstoque.Name = "chbEstoque";
            this.chbEstoque.Obrigatorio = false;
            this.chbEstoque.ObrigatorioMensagem = null;
            this.chbEstoque.PreValidacaoMensagem = null;
            this.chbEstoque.PreValidado = false;
            this.chbEstoque.Size = new System.Drawing.Size(127, 17);
            this.chbEstoque.TabIndex = 140;
            this.chbEstoque.Text = "Fechamento Estoque";
            this.chbEstoque.UseVisualStyleBackColor = true;
            // 
            // btnGerarDados
            // 
            this.btnGerarDados.AlterarStatus = true;
            this.btnGerarDados.BackColor = System.Drawing.Color.White;
            this.btnGerarDados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGerarDados.BackgroundImage")));
            this.btnGerarDados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarDados.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnGerarDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarDados.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnGerarDados.Location = new System.Drawing.Point(221, 19);
            this.btnGerarDados.Name = "btnGerarDados";
            this.btnGerarDados.Size = new System.Drawing.Size(105, 22);
            this.btnGerarDados.TabIndex = 142;
            this.btnGerarDados.Text = "Gerar Dados";
            this.btnGerarDados.UseVisualStyleBackColor = false;
            this.btnGerarDados.Click += new System.EventHandler(this.btnGerarDados_Click);
            // 
            // FrmInfMatMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 139);
            this.Controls.Add(this.grbSalvar);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmInfMatMed";
            this.Text = "Relatório Inf. Mat/Med HAC/ACS";
            this.Load += new System.EventHandler(this.FrmInfMatMed_Load);
            this.grbSalvar.ResumeLayout(false);
            this.grbSalvar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacTextBox txtMes;
        private SGS.Componentes.HacTextBox txtAno;
        private SGS.Componentes.HacLabel hacLabel1;
        private System.Windows.Forms.GroupBox grbSalvar;
        private SGS.Componentes.HacCheckBox chbReceita;
        private SGS.Componentes.HacCheckBox chbEstoque;
        private SGS.Componentes.HacButton btnGerarDados;
    }
}