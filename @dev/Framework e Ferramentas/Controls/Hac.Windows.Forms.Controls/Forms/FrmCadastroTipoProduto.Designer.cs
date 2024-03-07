namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmCadastroTipoProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroTipoProduto));
            this.grpPrincipal = new System.Windows.Forms.GroupBox();
            this.lblCodigoDespesa = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cboCodigoDespesa = new Hac.Windows.Forms.Controls.HacCmbLocal(this.components);
            this.txtIndice = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblTipo = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.txtCodigoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblStatus = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cboStatus = new Hac.Windows.Forms.Controls.HacCmbLocal(this.components);
            this.lblDescricao = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.grpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPrincipal
            // 
            this.grpPrincipal.Controls.Add(this.lblCodigoDespesa);
            this.grpPrincipal.Controls.Add(this.cboCodigoDespesa);
            this.grpPrincipal.Controls.Add(this.txtIndice);
            this.grpPrincipal.Controls.Add(this.lblTipo);
            this.grpPrincipal.Controls.Add(this.txtCodigoConvenio);
            this.grpPrincipal.Controls.Add(this.lblStatus);
            this.grpPrincipal.Controls.Add(this.cboStatus);
            this.grpPrincipal.Controls.Add(this.lblDescricao);
            this.grpPrincipal.Font = new System.Drawing.Font("Verdana", 9F);
            this.grpPrincipal.Location = new System.Drawing.Point(5, 31);
            this.grpPrincipal.Name = "grpPrincipal";
            this.grpPrincipal.Size = new System.Drawing.Size(402, 198);
            this.grpPrincipal.TabIndex = 200;
            this.grpPrincipal.TabStop = false;
            this.grpPrincipal.Text = "Cadastro de Tipo de Produto";
            // 
            // lblCodigoDespesa
            // 
            this.lblCodigoDespesa.AutoSize = true;
            this.lblCodigoDespesa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoDespesa.Location = new System.Drawing.Point(15, 143);
            this.lblCodigoDespesa.Name = "lblCodigoDespesa";
            this.lblCodigoDespesa.Size = new System.Drawing.Size(115, 14);
            this.lblCodigoDespesa.TabIndex = 201;
            this.lblCodigoDespesa.Text = "Código Despesa:";
            // 
            // cboCodigoDespesa
            // 
            this.cboCodigoDespesa.BackColor = System.Drawing.Color.Honeydew;
            this.cboCodigoDespesa.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboCodigoDespesa.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboCodigoDespesa.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.cboCodigoDespesa.FormattingEnabled = true;
            this.cboCodigoDespesa.Limpar = false;
            this.cboCodigoDespesa.Location = new System.Drawing.Point(132, 138);
            this.cboCodigoDespesa.Name = "cboCodigoDespesa";
            this.cboCodigoDespesa.NomeComboSetor = null;
            this.cboCodigoDespesa.NomeComboUnidade = null;
            this.cboCodigoDespesa.Obrigatorio = true;
            this.cboCodigoDespesa.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cboCodigoDespesa.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cboCodigoDespesa.PreValidado = true;
            this.cboCodigoDespesa.Size = new System.Drawing.Size(166, 20);
            this.cboCodigoDespesa.TabIndex = 200;
            this.cboCodigoDespesa.Text = "<Selecione>";
            // 
            // txtIndice
            // 
            this.txtIndice.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtIndice.BackColor = System.Drawing.Color.Honeydew;
            this.txtIndice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIndice.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtIndice.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtIndice.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndice.Limpar = true;
            this.txtIndice.Location = new System.Drawing.Point(132, 24);
            this.txtIndice.MaxLength = 3;
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.NaoAjustarEdicao = true;
            this.txtIndice.Obrigatorio = false;
            this.txtIndice.ObrigatorioMensagem = null;
            this.txtIndice.PreValidacaoMensagem = null;
            this.txtIndice.PreValidado = false;
            this.txtIndice.SelectAllOnFocus = false;
            this.txtIndice.Size = new System.Drawing.Size(54, 18);
            this.txtIndice.TabIndex = 189;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(13, 25);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(92, 14);
            this.lblTipo.TabIndex = 190;
            this.lblTipo.Text = "Tipo Produto:";
            // 
            // txtCodigoConvenio
            // 
            this.txtCodigoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoConvenio.Limpar = true;
            this.txtCodigoConvenio.Location = new System.Drawing.Point(132, 51);
            this.txtCodigoConvenio.MaxLength = 50;
            this.txtCodigoConvenio.Multiline = true;
            this.txtCodigoConvenio.Name = "txtCodigoConvenio";
            this.txtCodigoConvenio.NaoAjustarEdicao = true;
            this.txtCodigoConvenio.Obrigatorio = false;
            this.txtCodigoConvenio.ObrigatorioMensagem = null;
            this.txtCodigoConvenio.PreValidacaoMensagem = null;
            this.txtCodigoConvenio.PreValidado = false;
            this.txtCodigoConvenio.SelectAllOnFocus = false;
            this.txtCodigoConvenio.Size = new System.Drawing.Size(251, 78);
            this.txtCodigoConvenio.TabIndex = 199;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(15, 172);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 14);
            this.lblStatus.TabIndex = 195;
            this.lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.Honeydew;
            this.cboStatus.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.cboStatus.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboStatus.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Limpar = false;
            this.cboStatus.Location = new System.Drawing.Point(132, 167);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.NomeComboSetor = null;
            this.cboStatus.NomeComboUnidade = null;
            this.cboStatus.Obrigatorio = true;
            this.cboStatus.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cboStatus.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cboStatus.PreValidado = true;
            this.cboStatus.Size = new System.Drawing.Size(166, 20);
            this.cboStatus.TabIndex = 193;
            this.cboStatus.Text = "<Selecione>";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(14, 49);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(72, 14);
            this.lblDescricao.TabIndex = 184;
            this.lblDescricao.Text = "Descrição:";
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(414, 28);
            this.tspCommand.TabIndex = 201;
            this.tspCommand.Text = ".:Relatórios:.";
            this.tspCommand.TituloTela = null;
            // 
            // FrmCadastroTipoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 237);
            this.ControlBox = false;
            this.Controls.Add(this.grpPrincipal);
            this.Controls.Add(this.tspCommand);
            this.Name = "FrmCadastroTipoProduto";
            this.Text = "FrmCadastroTipoProduto";
            this.grpPrincipal.ResumeLayout(false);
            this.grpPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPrincipal;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoConvenio;
        private Hac.Windows.Forms.Controls.HacTextBox txtIndice;
        private Hac.Windows.Forms.Controls.HacLabel lblTipo;
        private Hac.Windows.Forms.Controls.HacLabel lblStatus;
        private Hac.Windows.Forms.Controls.HacCmbLocal cboStatus;
        private Hac.Windows.Forms.Controls.HacLabel lblDescricao;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacLabel lblCodigoDespesa;
        private Hac.Windows.Forms.Controls.HacCmbLocal cboCodigoDespesa;
    }
}