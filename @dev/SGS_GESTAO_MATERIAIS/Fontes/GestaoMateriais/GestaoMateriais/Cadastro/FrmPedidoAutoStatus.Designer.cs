namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    partial class FrmPedidoAutoStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoAutoStatus));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.txtUltimoProc = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.chkEmExecucao = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
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
            this.tsHac.Size = new System.Drawing.Size(325, 28);
            this.tsHac.TabIndex = 83;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Status Pedidos Auto.";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // txtUltimoProc
            // 
            this.txtUltimoProc.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUltimoProc.BackColor = System.Drawing.Color.Honeydew;
            this.txtUltimoProc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUltimoProc.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUltimoProc.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUltimoProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUltimoProc.Limpar = true;
            this.txtUltimoProc.Location = new System.Drawing.Point(159, 40);
            this.txtUltimoProc.Name = "txtUltimoProc";
            this.txtUltimoProc.NaoAjustarEdicao = false;
            this.txtUltimoProc.Obrigatorio = false;
            this.txtUltimoProc.ObrigatorioMensagem = null;
            this.txtUltimoProc.PreValidacaoMensagem = null;
            this.txtUltimoProc.PreValidado = false;
            this.txtUltimoProc.ReadOnly = true;
            this.txtUltimoProc.SelectAllOnFocus = false;
            this.txtUltimoProc.Size = new System.Drawing.Size(143, 20);
            this.txtUltimoProc.TabIndex = 85;
            this.txtUltimoProc.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 13);
            this.label13.TabIndex = 84;
            this.label13.Text = "Dt. Hr. Último Processo";
            // 
            // chkEmExecucao
            // 
            this.chkEmExecucao.AutoSize = true;
            this.chkEmExecucao.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEmExecucao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkEmExecucao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkEmExecucao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEmExecucao.Limpar = true;
            this.chkEmExecucao.Location = new System.Drawing.Point(183, 75);
            this.chkEmExecucao.Name = "chkEmExecucao";
            this.chkEmExecucao.Obrigatorio = false;
            this.chkEmExecucao.ObrigatorioMensagem = null;
            this.chkEmExecucao.PreValidacaoMensagem = null;
            this.chkEmExecucao.PreValidado = false;
            this.chkEmExecucao.Size = new System.Drawing.Size(115, 17);
            this.chkEmExecucao.TabIndex = 133;
            this.chkEmExecucao.Text = "EM EXECUÇÃO";
            this.chkEmExecucao.UseVisualStyleBackColor = true;
            this.chkEmExecucao.Click += new System.EventHandler(this.chkEmExecucao_Click);
            // 
            // FrmPedidoAutoStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 107);
            this.Controls.Add(this.chkEmExecucao);
            this.Controls.Add(this.txtUltimoProc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmPedidoAutoStatus";
            this.Text = "FrmPedidoAutoStatus";
            this.Load += new System.EventHandler(this.FrmPedidoAutoStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacTextBox txtUltimoProc;
        private System.Windows.Forms.Label label13;
        private SGS.Componentes.HacCheckBox chkEmExecucao;
    }
}