namespace Hac.Windows.Forms.Controls
{
    partial class HacPlano
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
            this.txtDescricaoPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.btnPesquisarPlano = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.SuspendLayout();
            // 
            // txtDescricaoPlano
            // 
            this.txtDescricaoPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtDescricaoPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoPlano.Limpar = true;
            this.txtDescricaoPlano.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoPlano.Name = "txtDescricaoPlano";
            this.txtDescricaoPlano.NaoAjustarEdicao = true;
            this.txtDescricaoPlano.Obrigatorio = false;
            this.txtDescricaoPlano.ObrigatorioMensagem = null;
            this.txtDescricaoPlano.PreValidacaoMensagem = null;
            this.txtDescricaoPlano.PreValidado = false;
            this.txtDescricaoPlano.SelectAllOnFocus = false;
            this.txtDescricaoPlano.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoPlano.TabIndex = 1;
            // 
            // txtCodigoPlano
            // 
            this.txtCodigoPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPlano.Limpar = true;
            this.txtCodigoPlano.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoPlano.MaxLength = 5;
            this.txtCodigoPlano.Name = "txtCodigoPlano";
            this.txtCodigoPlano.NaoAjustarEdicao = true;
            this.txtCodigoPlano.Obrigatorio = false;
            this.txtCodigoPlano.ObrigatorioMensagem = null;
            this.txtCodigoPlano.PreValidacaoMensagem = null;
            this.txtCodigoPlano.PreValidado = false;
            this.txtCodigoPlano.SelectAllOnFocus = false;
            this.txtCodigoPlano.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoPlano.TabIndex = 0;
            this.txtCodigoPlano.Leave += new System.EventHandler(this.txtCodigoPlano_Leave);
            // 
            // btnPesquisarPlano
            // 
            this.btnPesquisarPlano.AlterarStatus = true;
            this.btnPesquisarPlano.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarPlano.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarPlano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarPlano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarPlano.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarPlano.FlatAppearance.BorderSize = 0;
            this.btnPesquisarPlano.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarPlano.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarPlano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarPlano.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarPlano.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarPlano.Location = new System.Drawing.Point(336, 1);
            this.btnPesquisarPlano.Name = "btnPesquisarPlano";
            this.btnPesquisarPlano.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarPlano.TabIndex = 2;
            this.btnPesquisarPlano.UseVisualStyleBackColor = false;
            this.btnPesquisarPlano.Click += new System.EventHandler(this.btnPesquisarPlano_Click);
            // 
            // HacPlano
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarPlano);
            this.Controls.Add(this.txtDescricaoPlano);
            this.Controls.Add(this.txtCodigoPlano);
            this.Name = "HacPlano";
            this.Size = new System.Drawing.Size(360, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarPlano;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoPlano;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoPlano;

    }
}
