namespace Hac.Windows.Forms.Controls
{
    partial class HacBancoConta
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.hacLabel7 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cboAgenciaConta = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.hacLabel8 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cboBanco = new Hac.Windows.Forms.Controls.HacComboBox(this.components);
            this.SuspendLayout();
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(308, 7);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(268, 14);
            this.hacLabel7.TabIndex = 4;
            this.hacLabel7.Text = "Agência/Conta Corrente/Conta Caixa RM:";
            // 
            // cboAgenciaConta
            // 
            this.cboAgenciaConta.BackColor = System.Drawing.Color.Honeydew;
            this.cboAgenciaConta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgenciaConta.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.cboAgenciaConta.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboAgenciaConta.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.cboAgenciaConta.FormattingEnabled = true;
            this.cboAgenciaConta.Limpar = true;
            this.cboAgenciaConta.Location = new System.Drawing.Point(579, 3);
            this.cboAgenciaConta.Name = "cboAgenciaConta";
            this.cboAgenciaConta.Obrigatorio = false;
            this.cboAgenciaConta.ObrigatorioMensagem = "Selecione a Ag/C. Corrente/C. Caixa RM";
            this.cboAgenciaConta.PreValidacaoMensagem = null;
            this.cboAgenciaConta.PreValidado = false;
            this.cboAgenciaConta.Size = new System.Drawing.Size(243, 20);
            this.cboAgenciaConta.TabIndex = 2;
            this.cboAgenciaConta.SelectedIndexChanged += new System.EventHandler(this.cboAgenciaConta_SelectedIndexChanged);
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(6, 7);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(50, 14);
            this.hacLabel8.TabIndex = 3;
            this.hacLabel8.Text = "Banco:";
            // 
            // cboBanco
            // 
            this.cboBanco.BackColor = System.Drawing.Color.Honeydew;
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.cboBanco.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.cboBanco.Font = new System.Drawing.Font("Verdana", 6.75F);
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Limpar = true;
            this.cboBanco.Location = new System.Drawing.Point(59, 3);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Obrigatorio = false;
            this.cboBanco.ObrigatorioMensagem = "Selecione a Ag/C. Corrente/C. Caixa RM";
            this.cboBanco.PreValidacaoMensagem = null;
            this.cboBanco.PreValidado = false;
            this.cboBanco.Size = new System.Drawing.Size(243, 20);
            this.cboBanco.TabIndex = 0;
            // 
            // HacBancoConta
            // 
            this.AutoSize = true;
            this.Controls.Add(this.cboBanco);
            this.Controls.Add(this.hacLabel7);
            this.Controls.Add(this.cboAgenciaConta);
            this.Controls.Add(this.hacLabel8);
            this.Name = "HacBancoConta";
            this.Size = new System.Drawing.Size(825, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private HacLabel hacLabel7;
        private HacComboBox cboAgenciaConta;
        private HacLabel hacLabel8;
        private HacComboBox cboBanco;

    }
}
