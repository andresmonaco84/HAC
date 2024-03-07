namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmTransfAtd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransfAtd));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtAtdDE = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtAtdPARA = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
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
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(415, 28);
            this.tsHac.TabIndex = 1;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Transferência de Atendimento";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(52, 39);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(79, 13);
            this.hacLabel4.TabIndex = 99;
            this.hacLabel4.Text = "Atendimento";
            // 
            // txtAtdDE
            // 
            this.txtAtdDE.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAtdDE.BackColor = System.Drawing.Color.Honeydew;
            this.txtAtdDE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAtdDE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAtdDE.Enabled = false;
            this.txtAtdDE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAtdDE.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAtdDE.Limpar = true;
            this.txtAtdDE.Location = new System.Drawing.Point(53, 58);
            this.txtAtdDE.MaxLength = 10;
            this.txtAtdDE.Name = "txtAtdDE";
            this.txtAtdDE.NaoAjustarEdicao = false;
            this.txtAtdDE.Obrigatorio = true;
            this.txtAtdDE.ObrigatorioMensagem = "Campo DE Obrigatório";
            this.txtAtdDE.PreValidacaoMensagem = null;
            this.txtAtdDE.PreValidado = false;
            this.txtAtdDE.SelectAllOnFocus = false;
            this.txtAtdDE.Size = new System.Drawing.Size(76, 21);
            this.txtAtdDE.TabIndex = 1;
            this.txtAtdDE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(24, 61);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(24, 13);
            this.hacLabel1.TabIndex = 100;
            this.hacLabel1.Text = "DE";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(8, 88);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(41, 13);
            this.hacLabel2.TabIndex = 102;
            this.hacLabel2.Text = "PARA";
            // 
            // txtAtdPARA
            // 
            this.txtAtdPARA.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAtdPARA.BackColor = System.Drawing.Color.Honeydew;
            this.txtAtdPARA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAtdPARA.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAtdPARA.Enabled = false;
            this.txtAtdPARA.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAtdPARA.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAtdPARA.Limpar = true;
            this.txtAtdPARA.Location = new System.Drawing.Point(53, 85);
            this.txtAtdPARA.MaxLength = 10;
            this.txtAtdPARA.Name = "txtAtdPARA";
            this.txtAtdPARA.NaoAjustarEdicao = false;
            this.txtAtdPARA.Obrigatorio = true;
            this.txtAtdPARA.ObrigatorioMensagem = "Campo PARA Obrigatório";
            this.txtAtdPARA.PreValidacaoMensagem = null;
            this.txtAtdPARA.PreValidado = false;
            this.txtAtdPARA.SelectAllOnFocus = false;
            this.txtAtdPARA.Size = new System.Drawing.Size(76, 21);
            this.txtAtdPARA.TabIndex = 2;
            this.txtAtdPARA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel3
            // 
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.ForeColor = System.Drawing.Color.Red;
            this.hacLabel3.Location = new System.Drawing.Point(146, 68);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(267, 52);
            this.hacLabel3.TabIndex = 103;
            this.hacLabel3.Text = "* Transferência apenas nos registros das movimentações do estoque, não interferin" +
                "do em quantidades atuais ou no faturamento";
            // 
            // FrmTransfAtd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 124);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.txtAtdDE);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.txtAtdPARA); 
            this.Controls.Add(this.tsHac);
            this.Name = "FrmTransfAtd";
            this.Text = "Transferência de Atendimento";
            this.Load += new System.EventHandler(this.FrmTransfAtd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacToolStrip tsHac;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel4;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtAtdDE;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel1;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel2;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtAtdPARA;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel3;
    }
}