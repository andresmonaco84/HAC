namespace HospitalAnaCosta.SGS.GestaoMateriais.Gerencial
{
    partial class FrmBookAmil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBookAmil));
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMes = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtAno = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.cmbUnidadeMaster = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBookFarm = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbComprasUrg = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(105, 47);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(12, 13);
            this.hacLabel3.TabIndex = 142;
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
            this.txtMes.Location = new System.Drawing.Point(73, 43);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.NaoAjustarEdicao = true;
            this.txtMes.Obrigatorio = false;
            this.txtMes.ObrigatorioMensagem = null;
            this.txtMes.PreValidacaoMensagem = null;
            this.txtMes.PreValidado = false;
            this.txtMes.SelectAllOnFocus = false;
            this.txtMes.Size = new System.Drawing.Size(30, 21);
            this.txtMes.TabIndex = 140;
            // 
            // txtAno
            // 
            this.txtAno.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAno.BackColor = System.Drawing.Color.Honeydew;
            this.txtAno.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAno.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAno.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAno.Limpar = true;
            this.txtAno.Location = new System.Drawing.Point(119, 43);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.NaoAjustarEdicao = true;
            this.txtAno.Obrigatorio = false;
            this.txtAno.ObrigatorioMensagem = "";
            this.txtAno.PreValidacaoMensagem = "";
            this.txtAno.PreValidado = false;
            this.txtAno.SelectAllOnFocus = false;
            this.txtAno.Size = new System.Drawing.Size(40, 21);
            this.txtAno.TabIndex = 141;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(14, 47);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(56, 13);
            this.hacLabel1.TabIndex = 139;
            this.hacLabel1.Text = "Mês/Ano";
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
            this.tsHac.Size = new System.Drawing.Size(371, 28);
            this.tsHac.TabIndex = 143;
            this.tsHac.Text = "Book Amil";
            this.tsHac.TituloTela = "Book Amil";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            // 
            // cmbUnidadeMaster
            // 
            this.cmbUnidadeMaster.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidadeMaster.DisplayMember = "CAD_UNI_DS_UNIDADE";
            this.cmbUnidadeMaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadeMaster.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbUnidadeMaster.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidadeMaster.FormattingEnabled = true;
            this.cmbUnidadeMaster.Limpar = false;
            this.cmbUnidadeMaster.Location = new System.Drawing.Point(17, 98);
            this.cmbUnidadeMaster.MaxDropDownItems = 10;
            this.cmbUnidadeMaster.Name = "cmbUnidadeMaster";
            this.cmbUnidadeMaster.Obrigatorio = false;
            this.cmbUnidadeMaster.ObrigatorioMensagem = null;
            this.cmbUnidadeMaster.PreValidacaoMensagem = null;
            this.cmbUnidadeMaster.PreValidado = false;
            this.cmbUnidadeMaster.Size = new System.Drawing.Size(333, 21);
            this.cmbUnidadeMaster.TabIndex = 144;
            this.cmbUnidadeMaster.ValueMember = "CAD_UNI_ID_UNIDADE";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(14, 82);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(124, 13);
            this.hacLabel2.TabIndex = 145;
            this.hacLabel2.Text = "Unidade Master Amil";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbComprasUrg);
            this.groupBox1.Controls.Add(this.rbBookFarm);
            this.groupBox1.Location = new System.Drawing.Point(179, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 57);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            // 
            // rbBookFarm
            // 
            this.rbBookFarm.AutoSize = true;
            this.rbBookFarm.Checked = true;
            this.rbBookFarm.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbBookFarm.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbBookFarm.Limpar = false;
            this.rbBookFarm.Location = new System.Drawing.Point(10, 13);
            this.rbBookFarm.Name = "rbBookFarm";
            this.rbBookFarm.Obrigatorio = false;
            this.rbBookFarm.ObrigatorioMensagem = null;
            this.rbBookFarm.PreValidacaoMensagem = null;
            this.rbBookFarm.PreValidado = false;
            this.rbBookFarm.Size = new System.Drawing.Size(112, 17);
            this.rbBookFarm.TabIndex = 147;
            this.rbBookFarm.TabStop = true;
            this.rbBookFarm.Text = "BOOK FARMÁCIA";
            this.rbBookFarm.UseVisualStyleBackColor = true;
            this.rbBookFarm.Click += new System.EventHandler(this.rbComprasUrg_Click);
            // 
            // rbComprasUrg
            // 
            this.rbComprasUrg.AutoSize = true;
            this.rbComprasUrg.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbComprasUrg.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbComprasUrg.Limpar = false;
            this.rbComprasUrg.Location = new System.Drawing.Point(10, 33);
            this.rbComprasUrg.Name = "rbComprasUrg";
            this.rbComprasUrg.Obrigatorio = false;
            this.rbComprasUrg.ObrigatorioMensagem = null;
            this.rbComprasUrg.PreValidacaoMensagem = null;
            this.rbComprasUrg.PreValidado = false;
            this.rbComprasUrg.Size = new System.Drawing.Size(156, 17);
            this.rbComprasUrg.TabIndex = 148;
            this.rbComprasUrg.Text = "COMPRAS EM URGÊNCIA";
            this.rbComprasUrg.UseVisualStyleBackColor = true;
            this.rbComprasUrg.Click += new System.EventHandler(this.rbComprasUrg_Click);
            // 
            // FrmBookAmil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 134);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbUnidadeMaster);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.hacLabel1);
            this.Name = "FrmBookAmil";
            this.Text = "Book Amil";
            this.Load += new System.EventHandler(this.FrmBookAmil_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacTextBox txtMes;
        private SGS.Componentes.HacTextBox txtAno;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacComboBox cmbUnidadeMaster;
        private SGS.Componentes.HacLabel hacLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacRadioButton rbBookFarm;
        private SGS.Componentes.HacRadioButton rbComprasUrg;
    }
}