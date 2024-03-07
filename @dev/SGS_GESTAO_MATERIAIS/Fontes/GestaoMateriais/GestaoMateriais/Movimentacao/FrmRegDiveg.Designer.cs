using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmRegDiveg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegDiveg));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkResolvida = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtUsuario = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDescricao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtDsProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblObs = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkResolvida);
            this.groupBox1.Controls.Add(this.hacLabel1);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.hacLabel4);
            this.groupBox1.Controls.Add(this.hacLabel11);
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Controls.Add(this.txtDsProduto);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 150);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            // 
            // chkResolvida
            // 
            this.chkResolvida.AutoSize = true;
            this.chkResolvida.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkResolvida.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkResolvida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResolvida.Limpar = false;
            this.chkResolvida.Location = new System.Drawing.Point(469, 121);
            this.chkResolvida.Name = "chkResolvida";
            this.chkResolvida.Obrigatorio = false;
            this.chkResolvida.ObrigatorioMensagem = null;
            this.chkResolvida.PreValidacaoMensagem = null;
            this.chkResolvida.PreValidado = false;
            this.chkResolvida.Size = new System.Drawing.Size(154, 17);
            this.chkResolvida.TabIndex = 120;
            this.chkResolvida.Text = "Divergência Resolvida";
            this.chkResolvida.UseVisualStyleBackColor = true;
            this.chkResolvida.Visible = false;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(31, 118);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(50, 13);
            this.hacLabel1.TabIndex = 123;
            this.hacLabel1.Text = "Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUsuario.BackColor = System.Drawing.Color.Honeydew;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUsuario.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUsuario.Limpar = true;
            this.txtUsuario.Location = new System.Drawing.Point(87, 115);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.NaoAjustarEdicao = false;
            this.txtUsuario.Obrigatorio = true;
            this.txtUsuario.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtUsuario.PreValidacaoMensagem = null;
            this.txtUsuario.PreValidado = false;
            this.txtUsuario.SelectAllOnFocus = false;
            this.txtUsuario.Size = new System.Drawing.Size(237, 21);
            this.txtUsuario.TabIndex = 122;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(31, 20);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(51, 13);
            this.hacLabel4.TabIndex = 121;
            this.hacLabel4.Text = "Produto";
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(8, 44);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(75, 13);
            this.hacLabel11.TabIndex = 118;
            this.hacLabel11.Text = "Divergência";
            // 
            // txtDescricao
            // 
            this.txtDescricao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDescricao.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDescricao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDescricao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDescricao.Limpar = true;
            this.txtDescricao.Location = new System.Drawing.Point(87, 44);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.NaoAjustarEdicao = false;
            this.txtDescricao.Obrigatorio = true;
            this.txtDescricao.ObrigatorioMensagem = "Digite a descrição da divergência";
            this.txtDescricao.PreValidacaoMensagem = null;
            this.txtDescricao.PreValidado = false;
            this.txtDescricao.SelectAllOnFocus = false;
            this.txtDescricao.Size = new System.Drawing.Size(536, 65);
            this.txtDescricao.TabIndex = 116;
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDsProduto.Enabled = false;
            this.txtDsProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(87, 17);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = false;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(536, 21);
            this.txtDsProduto.TabIndex = 3;
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
            this.tsHac.Size = new System.Drawing.Size(661, 28);
            this.tsHac.TabIndex = 109;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Registro de Divergência";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblObs.Location = new System.Drawing.Point(12, 187);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(518, 13);
            this.lblObs.TabIndex = 119;
            this.lblObs.Text = "Obs.: Ao salvar esta divergência, será enviado um e-mail para o almoxarifado";
            this.lblObs.Visible = false;
            // 
            // FrmRegDiveg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 212);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmRegDiveg";
            this.Text = "FrmRegDiveg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegDiveg_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private HacLabel hacLabel11;
        private HacTextBox txtDescricao;
        private HacTextBox txtDsProduto;
        private HacToolStrip tsHac;
        private HacLabel hacLabel4;
        private HacLabel hacLabel1;
        private HacTextBox txtUsuario;
        private HacLabel lblObs;
        private HacCheckBox chkResolvida;
    }
}