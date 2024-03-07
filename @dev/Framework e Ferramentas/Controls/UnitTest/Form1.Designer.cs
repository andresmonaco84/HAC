namespace UnitTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hacConvenio1 = new HospitalAnaCosta.SGS.Internacao.Controls.HacConvenio();
            this.hacButton1 = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.hacButton2 = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.userControl11 = new UnitTest.UserControl1();
            this.hacMaskedTextBox1 = new Hac.Windows.Forms.Controls.HacMaskedTextBox(this.components);
            this.SuspendLayout();
            // 
            // hacConvenio1
            // 
            this.hacConvenio1.AutoSize = true;
            this.hacConvenio1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hacConvenio1.Enabled = false;
            this.hacConvenio1.Location = new System.Drawing.Point(70, 78);
            this.hacConvenio1.Name = "hacConvenio1";
            this.hacConvenio1.NaoAjustarEdicao = false;
            this.hacConvenio1.Obrigatorio = false;
            this.hacConvenio1.ObrigatorioMensagem = null;
            this.hacConvenio1.Size = new System.Drawing.Size(360, 24);
            this.hacConvenio1.TabIndex = 0;
            // 
            // hacButton1
            // 
            this.hacButton1.AlterarStatus = true;
            this.hacButton1.BackColor = System.Drawing.Color.White;
            this.hacButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton1.BackgroundImage")));
            this.hacButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton1.Location = new System.Drawing.Point(89, 24);
            this.hacButton1.Name = "hacButton1";
            this.hacButton1.Size = new System.Drawing.Size(105, 22);
            this.hacButton1.TabIndex = 1;
            this.hacButton1.Text = "Habilitar";
            this.hacButton1.UseVisualStyleBackColor = true;
            this.hacButton1.Click += new System.EventHandler(this.hacButton1_Click);
            // 
            // hacButton2
            // 
            this.hacButton2.AlterarStatus = true;
            this.hacButton2.BackColor = System.Drawing.Color.White;
            this.hacButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton2.BackgroundImage")));
            this.hacButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton2.Location = new System.Drawing.Point(239, 23);
            this.hacButton2.Name = "hacButton2";
            this.hacButton2.Size = new System.Drawing.Size(105, 22);
            this.hacButton2.TabIndex = 2;
            this.hacButton2.Text = "Desabilitar";
            this.hacButton2.UseVisualStyleBackColor = true;
            this.hacButton2.Click += new System.EventHandler(this.hacButton2_Click);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(60, 176);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(397, 134);
            this.userControl11.TabIndex = 3;
            // 
            // hacMaskedTextBox1
            // 
            this.hacMaskedTextBox1.AcceptedFormatMasked = Hac.Windows.Forms.Controls.AcceptedFormatMasked.Data;
            this.hacMaskedTextBox1.BackColor = System.Drawing.Color.Honeydew;
            this.hacMaskedTextBox1.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.hacMaskedTextBox1.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.hacMaskedTextBox1.Limpar = false;
            this.hacMaskedTextBox1.Location = new System.Drawing.Point(263, 337);
            this.hacMaskedTextBox1.Mask = "00/00/0000";
            this.hacMaskedTextBox1.Name = "hacMaskedTextBox1";
            this.hacMaskedTextBox1.NaoAjustarEdicao = false;
            this.hacMaskedTextBox1.Obrigatorio = false;
            this.hacMaskedTextBox1.ObrigatorioMensagem = "";
            this.hacMaskedTextBox1.PreValidacaoMensagem = "";
            this.hacMaskedTextBox1.PreValidado = false;
            this.hacMaskedTextBox1.SelectAllOnFocus = false;
            this.hacMaskedTextBox1.Size = new System.Drawing.Size(70, 20);
            this.hacMaskedTextBox1.TabIndex = 4;
            this.hacMaskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 408);
            this.Controls.Add(this.hacMaskedTextBox1);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.hacButton2);
            this.Controls.Add(this.hacButton1);
            this.Controls.Add(this.hacConvenio1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Internacao.Controls.HacConvenio hacConvenio1;
        private Hac.Windows.Forms.Controls.HacButton hacButton1;
        private Hac.Windows.Forms.Controls.HacButton hacButton2;
        private UserControl1 userControl11;
        private Hac.Windows.Forms.Controls.HacMaskedTextBox hacMaskedTextBox1;


    }
}

