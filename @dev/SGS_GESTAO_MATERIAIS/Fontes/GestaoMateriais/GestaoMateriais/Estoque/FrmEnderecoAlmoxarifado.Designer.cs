namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmEnderecoAlmoxarifado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnderecoAlmoxarifado));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.txtEndAlmoxHAC = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblHac = new System.Windows.Forms.Label();
            this.txtEndFarm = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblCC = new System.Windows.Forms.Label();
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
            this.tsHac.Size = new System.Drawing.Size(354, 28);
            this.tsHac.TabIndex = 82;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Endereço Produto";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // txtEndAlmoxHAC
            // 
            this.txtEndAlmoxHAC.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtEndAlmoxHAC.BackColor = System.Drawing.Color.Honeydew;
            this.txtEndAlmoxHAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndAlmoxHAC.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtEndAlmoxHAC.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtEndAlmoxHAC.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtEndAlmoxHAC.Limpar = false;
            this.txtEndAlmoxHAC.Location = new System.Drawing.Point(245, 47);
            this.txtEndAlmoxHAC.MaxLength = 6;
            this.txtEndAlmoxHAC.Name = "txtEndAlmoxHAC";
            this.txtEndAlmoxHAC.NaoAjustarEdicao = false;
            this.txtEndAlmoxHAC.Obrigatorio = false;
            this.txtEndAlmoxHAC.ObrigatorioMensagem = null;
            this.txtEndAlmoxHAC.PreValidacaoMensagem = null;
            this.txtEndAlmoxHAC.PreValidado = false;
            this.txtEndAlmoxHAC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEndAlmoxHAC.SelectAllOnFocus = false;
            this.txtEndAlmoxHAC.Size = new System.Drawing.Size(75, 21);
            this.txtEndAlmoxHAC.TabIndex = 1;
            // 
            // lblHac
            // 
            this.lblHac.AutoSize = true;
            this.lblHac.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHac.ForeColor = System.Drawing.Color.Black;
            this.lblHac.Location = new System.Drawing.Point(16, 51);
            this.lblHac.Name = "lblHac";
            this.lblHac.Size = new System.Drawing.Size(199, 13);
            this.lblHac.TabIndex = 86;
            this.lblHac.Text = "Endereço Item Almoxarifado:";
            this.lblHac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEndFarm
            // 
            this.txtEndFarm.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtEndFarm.BackColor = System.Drawing.Color.Honeydew;
            this.txtEndFarm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndFarm.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtEndFarm.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtEndFarm.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtEndFarm.Limpar = false;
            this.txtEndFarm.Location = new System.Drawing.Point(245, 77);
            this.txtEndFarm.MaxLength = 6;
            this.txtEndFarm.Name = "txtEndFarm";
            this.txtEndFarm.NaoAjustarEdicao = false;
            this.txtEndFarm.Obrigatorio = false;
            this.txtEndFarm.ObrigatorioMensagem = null;
            this.txtEndFarm.PreValidacaoMensagem = null;
            this.txtEndFarm.PreValidado = false;
            this.txtEndFarm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEndFarm.SelectAllOnFocus = false;
            this.txtEndFarm.Size = new System.Drawing.Size(75, 21);
            this.txtEndFarm.TabIndex = 2;
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCC.ForeColor = System.Drawing.Color.Black;
            this.lblCC.Location = new System.Drawing.Point(16, 81);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(223, 13);
            this.lblCC.TabIndex = 88;
            this.lblCC.Text = "Endereço Item Farmácia Central:";
            this.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmEnderecoAlmoxarifado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 119);
            this.Controls.Add(this.txtEndFarm);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.txtEndAlmoxHAC);
            this.Controls.Add(this.lblHac);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmEnderecoAlmoxarifado";
            this.Text = "FrmEnderecoAlmoxarifado";
            this.Load += new System.EventHandler(this.FrmEnderecoAlmoxarifado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacTextBox txtEndAlmoxHAC;
        private System.Windows.Forms.Label lblHac;
        private SGS.Componentes.HacTextBox txtEndFarm;
        private System.Windows.Forms.Label lblCC;
    }
}