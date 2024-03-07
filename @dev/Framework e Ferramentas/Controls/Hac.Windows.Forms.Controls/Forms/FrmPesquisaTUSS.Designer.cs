namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaTUSS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaTUSS));
            this.txtCod = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.hacLabel1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.grb1 = new System.Windows.Forms.GroupBox();
            this.lblCodTUSS1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblTabela1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblProduto1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel4 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel3 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.grb2 = new System.Windows.Forms.GroupBox();
            this.lblCodTUSS2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblTabela2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblProduto2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel8 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel9 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel10 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.grb1.SuspendLayout();
            this.grb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCod
            // 
            this.txtCod.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCod.BackColor = System.Drawing.Color.Honeydew;
            this.txtCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCod.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCod.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCod.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Limpar = true;
            this.txtCod.Location = new System.Drawing.Point(204, 41);
            this.txtCod.MaxLength = 10;
            this.txtCod.Name = "txtCod";
            this.txtCod.NaoAjustarEdicao = false;
            this.txtCod.Obrigatorio = false;
            this.txtCod.ObrigatorioMensagem = null;
            this.txtCod.PreValidacaoMensagem = null;
            this.txtCod.PreValidado = false;
            this.txtCod.SelectAllOnFocus = false;
            this.txtCod.Size = new System.Drawing.Size(120, 18);
            this.txtCod.TabIndex = 161;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(12, 43);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(188, 14);
            this.hacLabel1.TabIndex = 162;
            this.hacLabel1.Text = "Cod. SIMPRO / BRASINDICE :";
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(738, 28);
            this.tspCommand.TabIndex = 163;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "Pesquisar TUSS";
            this.tspCommand.ToolTipSalvar = "Salvar";
            this.tspCommand.PesquisarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_PesquisarClick);
            // 
            // grb1
            // 
            this.grb1.Controls.Add(this.lblCodTUSS1);
            this.grb1.Controls.Add(this.lblTabela1);
            this.grb1.Controls.Add(this.lblProduto1);
            this.grb1.Controls.Add(this.hacLabel4);
            this.grb1.Controls.Add(this.hacLabel3);
            this.grb1.Controls.Add(this.hacLabel2);
            this.grb1.Location = new System.Drawing.Point(11, 75);
            this.grb1.Name = "grb1";
            this.grb1.Size = new System.Drawing.Size(715, 97);
            this.grb1.TabIndex = 164;
            this.grb1.TabStop = false;
            // 
            // lblCodTUSS1
            // 
            this.lblCodTUSS1.AutoSize = true;
            this.lblCodTUSS1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodTUSS1.Location = new System.Drawing.Point(95, 66);
            this.lblCodTUSS1.Name = "lblCodTUSS1";
            this.lblCodTUSS1.Size = new System.Drawing.Size(22, 17);
            this.lblCodTUSS1.TabIndex = 167;
            this.lblCodTUSS1.Text = "--";
            // 
            // lblTabela1
            // 
            this.lblTabela1.AutoSize = true;
            this.lblTabela1.Font = new System.Drawing.Font("Verdana", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabela1.Location = new System.Drawing.Point(95, 44);
            this.lblTabela1.Name = "lblTabela1";
            this.lblTabela1.Size = new System.Drawing.Size(19, 13);
            this.lblTabela1.TabIndex = 166;
            this.lblTabela1.Text = "--";
            // 
            // lblProduto1
            // 
            this.lblProduto1.AutoSize = true;
            this.lblProduto1.Font = new System.Drawing.Font("Verdana", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto1.Location = new System.Drawing.Point(95, 20);
            this.lblProduto1.Name = "lblProduto1";
            this.lblProduto1.Size = new System.Drawing.Size(19, 13);
            this.lblProduto1.TabIndex = 165;
            this.lblProduto1.Text = "--";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(11, 68);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(81, 14);
            this.hacLabel4.TabIndex = 165;
            this.hacLabel4.Text = "Cod. TUSS :";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(34, 43);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(58, 14);
            this.hacLabel3.TabIndex = 164;
            this.hacLabel3.Text = "Tabela :";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(26, 19);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(66, 14);
            this.hacLabel2.TabIndex = 163;
            this.hacLabel2.Text = "Produto :";
            // 
            // grb2
            // 
            this.grb2.Controls.Add(this.lblCodTUSS2);
            this.grb2.Controls.Add(this.lblTabela2);
            this.grb2.Controls.Add(this.lblProduto2);
            this.grb2.Controls.Add(this.hacLabel8);
            this.grb2.Controls.Add(this.hacLabel9);
            this.grb2.Controls.Add(this.hacLabel10);
            this.grb2.Location = new System.Drawing.Point(11, 172);
            this.grb2.Name = "grb2";
            this.grb2.Size = new System.Drawing.Size(715, 97);
            this.grb2.TabIndex = 165;
            this.grb2.TabStop = false;
            this.grb2.Visible = false;
            // 
            // lblCodTUSS2
            // 
            this.lblCodTUSS2.AutoSize = true;
            this.lblCodTUSS2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodTUSS2.Location = new System.Drawing.Point(95, 66);
            this.lblCodTUSS2.Name = "lblCodTUSS2";
            this.lblCodTUSS2.Size = new System.Drawing.Size(22, 17);
            this.lblCodTUSS2.TabIndex = 167;
            this.lblCodTUSS2.Text = "--";
            // 
            // lblTabela2
            // 
            this.lblTabela2.AutoSize = true;
            this.lblTabela2.Font = new System.Drawing.Font("Verdana", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabela2.Location = new System.Drawing.Point(95, 44);
            this.lblTabela2.Name = "lblTabela2";
            this.lblTabela2.Size = new System.Drawing.Size(19, 13);
            this.lblTabela2.TabIndex = 166;
            this.lblTabela2.Text = "--";
            // 
            // lblProduto2
            // 
            this.lblProduto2.AutoSize = true;
            this.lblProduto2.Font = new System.Drawing.Font("Verdana", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto2.Location = new System.Drawing.Point(95, 20);
            this.lblProduto2.Name = "lblProduto2";
            this.lblProduto2.Size = new System.Drawing.Size(19, 13);
            this.lblProduto2.TabIndex = 165;
            this.lblProduto2.Text = "--";
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(11, 68);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(81, 14);
            this.hacLabel8.TabIndex = 165;
            this.hacLabel8.Text = "Cod. TUSS :";
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(34, 43);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(58, 14);
            this.hacLabel9.TabIndex = 164;
            this.hacLabel9.Text = "Tabela :";
            // 
            // hacLabel10
            // 
            this.hacLabel10.AutoSize = true;
            this.hacLabel10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel10.Location = new System.Drawing.Point(26, 19);
            this.hacLabel10.Name = "hacLabel10";
            this.hacLabel10.Size = new System.Drawing.Size(66, 14);
            this.hacLabel10.TabIndex = 163;
            this.hacLabel10.Text = "Produto :";
            // 
            // FrmPesquisaTUSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 275);
            this.Controls.Add(this.grb2);
            this.Controls.Add(this.grb1);
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.hacLabel1);
            this.Name = "FrmPesquisaTUSS";
            this.Text = "FrmPesquisaTUSS";
            this.grb1.ResumeLayout(false);
            this.grb1.PerformLayout();
            this.grb2.ResumeLayout(false);
            this.grb2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacTextBox txtCod;
        private HacLabel hacLabel1;
        private HacToolStrip tspCommand;
        private System.Windows.Forms.GroupBox grb1;
        private HacLabel hacLabel4;
        private HacLabel hacLabel3;
        private HacLabel hacLabel2;
        private HacLabel lblCodTUSS1;
        private HacLabel lblTabela1;
        private HacLabel lblProduto1;
        private System.Windows.Forms.GroupBox grb2;
        private HacLabel lblCodTUSS2;
        private HacLabel lblTabela2;
        private HacLabel lblProduto2;
        private HacLabel hacLabel8;
        private HacLabel hacLabel9;
        private HacLabel hacLabel10;
    }
}