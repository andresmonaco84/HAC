namespace Hac.Windows.Forms.Controls
{
    partial class HacUsuario
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
            this.txtNomeUsuario = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtMatricula = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.btnPesquisarUsuario = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.SuspendLayout();
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeUsuario.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeUsuario.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.txtNomeUsuario.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeUsuario.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeUsuario.Limpar = true;
            this.txtNomeUsuario.Location = new System.Drawing.Point(70, 3);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.NaoAjustarEdicao = false;
            this.txtNomeUsuario.Obrigatorio = false;
            this.txtNomeUsuario.ObrigatorioMensagem = null;
            this.txtNomeUsuario.PreValidacaoMensagem = null;
            this.txtNomeUsuario.PreValidado = false;
            this.txtNomeUsuario.SelectAllOnFocus = false;
            this.txtNomeUsuario.Size = new System.Drawing.Size(261, 18);
            this.txtNomeUsuario.TabIndex = 9;
            // 
            // txtMatricula
            // 
            this.txtMatricula.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtMatricula.BackColor = System.Drawing.Color.Honeydew;
            this.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatricula.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtMatricula.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtMatricula.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Limpar = true;
            this.txtMatricula.Location = new System.Drawing.Point(0, 3);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.NaoAjustarEdicao = false;
            this.txtMatricula.Obrigatorio = false;
            this.txtMatricula.ObrigatorioMensagem = null;
            this.txtMatricula.PreValidacaoMensagem = null;
            this.txtMatricula.PreValidado = false;
            this.txtMatricula.SelectAllOnFocus = false;
            this.txtMatricula.Size = new System.Drawing.Size(66, 18);
            this.txtMatricula.TabIndex = 8;
            this.txtMatricula.Leave += new System.EventHandler(this.txtMatricula_Leave);
            // 
            // btnPesquisarUsuario
            // 
            this.btnPesquisarUsuario.AlterarStatus = true;
            this.btnPesquisarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarUsuario.BackgroundImage = global::Hac.Windows.Forms.Controls.Properties.Resources.imgLupa;
            this.btnPesquisarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarUsuario.FlatAppearance.BorderSize = 0;
            this.btnPesquisarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarUsuario.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarUsuario.Location = new System.Drawing.Point(337, 1);
            this.btnPesquisarUsuario.Name = "btnPesquisarUsuario";
            this.btnPesquisarUsuario.Size = new System.Drawing.Size(23, 20);
            this.btnPesquisarUsuario.TabIndex = 10;
            this.btnPesquisarUsuario.UseVisualStyleBackColor = false;
            this.btnPesquisarUsuario.Click += new System.EventHandler(this.btnPesquisarUsuario_Click);
            // 
            // HacUsuario
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.txtNomeUsuario);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.btnPesquisarUsuario);
            this.Name = "HacUsuario";
            this.Size = new System.Drawing.Size(363, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacTextBox txtNomeUsuario;
        private Hac.Windows.Forms.Controls.HacTextBox txtMatricula;
        private Hac.Windows.Forms.Controls.HacButton btnPesquisarUsuario;


    }
}
