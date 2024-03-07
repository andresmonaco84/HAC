using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmCodBarraMatMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCodBarraMatMed));
            this.tsHac = new HacToolStrip(this.components);
            this.hacLabel1 = new HacLabel(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HacRadioButton(this.components);
            this.rbHac = new HacRadioButton(this.components);
            this.hacLabel2 = new HacLabel(this.components);
            this.txtDsProduto = new HacTextBox(this.components);
            this.hacLabel3 = new HacLabel(this.components);
            this.txtIdProduto = new HacTextBox(this.components);
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(650, 28);
            this.tsHac.TabIndex = 0;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Código de Barra";
            this.tsHac.MatMedClick += new ToolStripHacEventHandler(this.tsHac_MatMedClick);
            this.tsHac.ExcluirClick += new ToolStripHacEventHandler(this.tsHac_ExcluirClick);
            this.tsHac.NovoClick += new ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.SalvarClick += new ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(15, 100);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(32, 13);
            this.hacLabel1.TabIndex = 1;
            this.hacLabel1.Text = "Filial";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbAcs);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(52, 87);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(109, 36);
            this.groupBox.TabIndex = 101;
            this.groupBox.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = ControleEdicao.NovoRegistro;
            this.rbAcs.EstadoInicial = EstadoObjeto.Desabilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(57, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = true;
            this.rbAcs.ObrigatorioMensagem = "Escolha Um estoque HAC/ACCS";
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 3;
            this.rbAcs.TabStop = true;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.CheckedChanged += new System.EventHandler(this.rbAcs_CheckedChanged);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = EstadoObjeto.Desabilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(8, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = true;
            this.rbHac.ObrigatorioMensagem = "Escolha Um estoque HAC/ACCS";
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 2;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.CheckedChanged += new System.EventHandler(this.rbHac_CheckedChanged);
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(222, 51);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(51, 13);
            this.hacLabel2.TabIndex = 102;
            this.hacLabel2.Text = "Produto";
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.White;
            this.txtDsProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDsProduto.Editavel = ControleEdicao.Nunca;
            this.txtDsProduto.Enabled = false;
            this.txtDsProduto.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(279, 48);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = false;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(315, 21);
            this.txtDsProduto.TabIndex = 103;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(9, 52);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(107, 13);
            this.hacLabel3.TabIndex = 104;
            this.hacLabel3.Text = "Código de Barras";
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtIdProduto.BackColor = System.Drawing.Color.White;
            this.txtIdProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProduto.Editavel = ControleEdicao.Sempre;
            this.txtIdProduto.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtIdProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdProduto.Limpar = true;
            this.txtIdProduto.Location = new System.Drawing.Point(118, 48);
            this.txtIdProduto.MaxLength = 50;
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = true;
            this.txtIdProduto.ObrigatorioMensagem = "Informe o Código de Barras";
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(100, 21);
            this.txtIdProduto.TabIndex = 105;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdProduto_Validating);
            // 
            // FrmCodBarraMatMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 160);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtDsProduto);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmCodBarraMatMed";
            this.Text = "FrmCodBarraMatMed";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacLabel hacLabel1;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacLabel hacLabel2;
        private HacTextBox txtDsProduto;
        private HacLabel hacLabel3;
        private HacTextBox txtIdProduto;
    }
}