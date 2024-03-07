namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmPedidoAutoAltera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoAutoAltera));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.lblCodPrescricao = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblItemCabecalho = new System.Windows.Forms.Label();
            this.lblDataDose = new System.Windows.Forms.Label();
            this.txtDtGerar = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel12 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMinuto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtHora = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkReplicar = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(464, 28);
            this.tsHac.TabIndex = 84;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Alteração Pedido Auto.";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 86;
            this.label13.Text = "Dt. Hr. Dose:";
            // 
            // lblCodPrescricao
            // 
            this.lblCodPrescricao.AutoSize = true;
            this.lblCodPrescricao.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPrescricao.Location = new System.Drawing.Point(107, 36);
            this.lblCodPrescricao.Name = "lblCodPrescricao";
            this.lblCodPrescricao.Size = new System.Drawing.Size(0, 17);
            this.lblCodPrescricao.TabIndex = 143;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 142;
            this.label4.Text = "Cód. Prescrição:";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(47, 62);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(0, 16);
            this.lblItem.TabIndex = 145;
            // 
            // lblItemCabecalho
            // 
            this.lblItemCabecalho.AutoSize = true;
            this.lblItemCabecalho.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCabecalho.Location = new System.Drawing.Point(11, 64);
            this.lblItemCabecalho.Name = "lblItemCabecalho";
            this.lblItemCabecalho.Size = new System.Drawing.Size(39, 13);
            this.lblItemCabecalho.TabIndex = 144;
            this.lblItemCabecalho.Text = "Item:";
            // 
            // lblDataDose
            // 
            this.lblDataDose.AutoSize = true;
            this.lblDataDose.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDose.Location = new System.Drawing.Point(91, 88);
            this.lblDataDose.Name = "lblDataDose";
            this.lblDataDose.Size = new System.Drawing.Size(0, 16);
            this.lblDataDose.TabIndex = 147;
            // 
            // txtDtGerar
            // 
            this.txtDtGerar.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtGerar.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtGerar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDtGerar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtGerar.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtGerar.Limpar = false;
            this.txtDtGerar.Location = new System.Drawing.Point(122, 18);
            this.txtDtGerar.MaxLength = 10;
            this.txtDtGerar.Name = "txtDtGerar";
            this.txtDtGerar.NaoAjustarEdicao = false;
            this.txtDtGerar.Obrigatorio = false;
            this.txtDtGerar.ObrigatorioMensagem = "";
            this.txtDtGerar.PreValidacaoMensagem = "";
            this.txtDtGerar.PreValidado = false;
            this.txtDtGerar.SelectAllOnFocus = false;
            this.txtDtGerar.Size = new System.Drawing.Size(80, 21);
            this.txtDtGerar.TabIndex = 1;
            // 
            // hacLabel12
            // 
            this.hacLabel12.AutoSize = true;
            this.hacLabel12.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel12.Location = new System.Drawing.Point(7, 23);
            this.hacLabel12.Name = "hacLabel12";
            this.hacLabel12.Size = new System.Drawing.Size(113, 13);
            this.hacLabel12.TabIndex = 148;
            this.hacLabel12.Text = "Data Gerar Pedido";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(215, 23);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(128, 13);
            this.hacLabel1.TabIndex = 150;
            this.hacLabel1.Text = "Horário Gerar Pedido";
            // 
            // txtMinuto
            // 
            this.txtMinuto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMinuto.BackColor = System.Drawing.Color.Honeydew;
            this.txtMinuto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMinuto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtMinuto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMinuto.Limpar = true;
            this.txtMinuto.Location = new System.Drawing.Point(380, 18);
            this.txtMinuto.MaxLength = 2;
            this.txtMinuto.Name = "txtMinuto";
            this.txtMinuto.NaoAjustarEdicao = false;
            this.txtMinuto.Obrigatorio = false;
            this.txtMinuto.ObrigatorioMensagem = "";
            this.txtMinuto.PreValidacaoMensagem = "";
            this.txtMinuto.PreValidado = false;
            this.txtMinuto.SelectAllOnFocus = false;
            this.txtMinuto.Size = new System.Drawing.Size(28, 21);
            this.txtMinuto.TabIndex = 3;
            // 
            // txtHora
            // 
            this.txtHora.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtHora.BackColor = System.Drawing.Color.Honeydew;
            this.txtHora.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtHora.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtHora.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtHora.Limpar = true;
            this.txtHora.Location = new System.Drawing.Point(345, 18);
            this.txtHora.MaxLength = 2;
            this.txtHora.Name = "txtHora";
            this.txtHora.NaoAjustarEdicao = false;
            this.txtHora.Obrigatorio = false;
            this.txtHora.ObrigatorioMensagem = "";
            this.txtHora.PreValidacaoMensagem = "";
            this.txtHora.PreValidado = false;
            this.txtHora.SelectAllOnFocus = false;
            this.txtHora.Size = new System.Drawing.Size(28, 21);
            this.txtHora.TabIndex = 2;
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hacLabel11.Location = new System.Drawing.Point(372, 22);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(10, 13);
            this.hacLabel11.TabIndex = 161;
            this.hacLabel11.Text = ":";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkReplicar);
            this.groupBox1.Controls.Add(this.txtDtGerar);
            this.groupBox1.Controls.Add(this.txtMinuto);
            this.groupBox1.Controls.Add(this.hacLabel12);
            this.groupBox1.Controls.Add(this.txtHora);
            this.groupBox1.Controls.Add(this.hacLabel1);
            this.groupBox1.Controls.Add(this.hacLabel11);
            this.groupBox1.Location = new System.Drawing.Point(11, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkReplicar
            // 
            this.chkReplicar.AutoSize = true;
            this.chkReplicar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkReplicar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkReplicar.Font = new System.Drawing.Font("Verdana", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReplicar.Limpar = true;
            this.chkReplicar.Location = new System.Drawing.Point(12, 50);
            this.chkReplicar.Name = "chkReplicar";
            this.chkReplicar.Obrigatorio = false;
            this.chkReplicar.ObrigatorioMensagem = null;
            this.chkReplicar.PreValidacaoMensagem = null;
            this.chkReplicar.PreValidado = false;
            this.chkReplicar.Size = new System.Drawing.Size(34, 16);
            this.chkReplicar.TabIndex = 162;
            this.chkReplicar.Text = "--";
            this.chkReplicar.UseVisualStyleBackColor = true;
            // 
            // FrmPedidoAutoAltera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 212);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDataDose);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lblItemCabecalho);
            this.Controls.Add(this.lblCodPrescricao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmPedidoAutoAltera";
            this.Text = "Alteração Pedido Auto.";
            this.Load += new System.EventHandler(this.FrmPedidoAutoAltera_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCodPrescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblItemCabecalho;
        private System.Windows.Forms.Label lblDataDose;
        private SGS.Componentes.HacTextBox txtDtGerar;
        private SGS.Componentes.HacLabel hacLabel12;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacTextBox txtMinuto;
        private SGS.Componentes.HacTextBox txtHora;
        private SGS.Componentes.HacLabel hacLabel11;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacCheckBox chkReplicar;
    }
}