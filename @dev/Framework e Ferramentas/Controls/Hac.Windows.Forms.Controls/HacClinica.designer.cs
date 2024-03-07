namespace Hac.Windows.Forms.Controls
{
    partial class HacClinica
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
            this.btnPesquisarClinica = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoClinica = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoClinica = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnPesquisarClinica
            // 
            this.btnPesquisarClinica.AlterarStatus = true;
            this.btnPesquisarClinica.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarClinica.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarClinica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarClinica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarClinica.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarClinica.FlatAppearance.BorderSize = 0;
            this.btnPesquisarClinica.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarClinica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarClinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarClinica.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarClinica.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarClinica.Location = new System.Drawing.Point(336, 1);
            this.btnPesquisarClinica.Name = "btnPesquisarClinica";
            this.btnPesquisarClinica.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarClinica.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnPesquisarClinica, "Pesquisar Clínica");
            this.btnPesquisarClinica.UseVisualStyleBackColor = false;
            this.btnPesquisarClinica.Click += new System.EventHandler(this.btnPesquisarClinica_Click);
            // 
            // txtDescricaoClinica
            // 
            this.txtDescricaoClinica.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoClinica.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoClinica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoClinica.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtDescricaoClinica.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoClinica.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoClinica.Limpar = true;
            this.txtDescricaoClinica.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoClinica.Name = "txtDescricaoClinica";
            this.txtDescricaoClinica.NaoAjustarEdicao = true;
            this.txtDescricaoClinica.Obrigatorio = false;
            this.txtDescricaoClinica.ObrigatorioMensagem = null;
            this.txtDescricaoClinica.PreValidacaoMensagem = null;
            this.txtDescricaoClinica.PreValidado = false;
            this.txtDescricaoClinica.SelectAllOnFocus = false;
            this.txtDescricaoClinica.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoClinica.TabIndex = 1;
            // 
            // txtCodigoClinica
            // 
            this.txtCodigoClinica.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCodigoClinica.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoClinica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoClinica.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoClinica.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoClinica.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoClinica.Limpar = true;
            this.txtCodigoClinica.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoClinica.Name = "txtCodigoClinica";
            this.txtCodigoClinica.NaoAjustarEdicao = true;
            this.txtCodigoClinica.Obrigatorio = false;
            this.txtCodigoClinica.ObrigatorioMensagem = null;
            this.txtCodigoClinica.PreValidacaoMensagem = null;
            this.txtCodigoClinica.PreValidado = false;
            this.txtCodigoClinica.SelectAllOnFocus = false;
            this.txtCodigoClinica.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoClinica.TabIndex = 0;
            this.txtCodigoClinica.TextChanged += new System.EventHandler(this.txtCodigoClinica_TextChanged);
            this.txtCodigoClinica.Leave += new System.EventHandler(this.txtCodigoClinica_Leave);
            // 
            // HacClinica
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarClinica);
            this.Controls.Add(this.txtDescricaoClinica);
            this.Controls.Add(this.txtCodigoClinica);
            this.Name = "HacClinica";
            this.Size = new System.Drawing.Size(360, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarClinica;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoClinica;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoClinica;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
