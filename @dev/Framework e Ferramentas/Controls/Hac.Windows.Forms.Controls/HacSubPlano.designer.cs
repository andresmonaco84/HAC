namespace Hac.Windows.Forms.Controls
{
    partial class HacSubPlano
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
            this.txtDescricaoSubPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoSubPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.btnPesquisarSubPlano = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.SuspendLayout();
            // 
            // txtDescricaoSubPlano
            // 
            this.txtDescricaoSubPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoSubPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoSubPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoSubPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoSubPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoSubPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoSubPlano.Limpar = true;
            this.txtDescricaoSubPlano.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoSubPlano.Name = "txtDescricaoSubPlano";
            this.txtDescricaoSubPlano.NaoAjustarEdicao = true;
            this.txtDescricaoSubPlano.Obrigatorio = false;
            this.txtDescricaoSubPlano.ObrigatorioMensagem = null;
            this.txtDescricaoSubPlano.PreValidacaoMensagem = null;
            this.txtDescricaoSubPlano.PreValidado = false;
            this.txtDescricaoSubPlano.SelectAllOnFocus = false;
            this.txtDescricaoSubPlano.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoSubPlano.TabIndex = 29;
            // 
            // txtCodigoSubPlano
            // 
            this.txtCodigoSubPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoSubPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoSubPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoSubPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoSubPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoSubPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoSubPlano.Limpar = true;
            this.txtCodigoSubPlano.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoSubPlano.MaxLength = 5;
            this.txtCodigoSubPlano.Name = "txtCodigoSubPlano";
            this.txtCodigoSubPlano.NaoAjustarEdicao = true;
            this.txtCodigoSubPlano.Obrigatorio = false;
            this.txtCodigoSubPlano.ObrigatorioMensagem = null;
            this.txtCodigoSubPlano.PreValidacaoMensagem = null;
            this.txtCodigoSubPlano.PreValidado = false;
            this.txtCodigoSubPlano.SelectAllOnFocus = false;
            this.txtCodigoSubPlano.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoSubPlano.TabIndex = 28;
            this.txtCodigoSubPlano.Leave += new System.EventHandler(this.txtCodigoSubPlano_Leave);
            // 
            // btnPesquisarSubPlano
            // 
            this.btnPesquisarSubPlano.AlterarStatus = true;
            this.btnPesquisarSubPlano.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarSubPlano.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarSubPlano.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarSubPlano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarSubPlano.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarSubPlano.FlatAppearance.BorderSize = 0;
            this.btnPesquisarSubPlano.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarSubPlano.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarSubPlano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarSubPlano.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarSubPlano.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarSubPlano.Location = new System.Drawing.Point(336, 1);
            this.btnPesquisarSubPlano.Name = "btnPesquisarSubPlano";
            this.btnPesquisarSubPlano.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarSubPlano.TabIndex = 30;
            this.btnPesquisarSubPlano.UseVisualStyleBackColor = false;
            this.btnPesquisarSubPlano.Click += new System.EventHandler(this.btnPesquisarSubPlano_Click);
            // 
            // HacSubPlano
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnPesquisarSubPlano);
            this.Controls.Add(this.txtDescricaoSubPlano);
            this.Controls.Add(this.txtCodigoSubPlano);
            this.Name = "HacSubPlano";
            this.Size = new System.Drawing.Size(360, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacButton btnPesquisarSubPlano;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoSubPlano;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoSubPlano;

    }
}
