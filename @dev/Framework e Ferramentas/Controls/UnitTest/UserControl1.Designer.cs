namespace UnitTest
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.hacConvenio1 = new HospitalAnaCosta.SGS.Internacao.Controls.HacConvenio();
            this.hacButton2 = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.hacButton1 = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.SuspendLayout();
            // 
            // hacConvenio1
            // 
            this.hacConvenio1.AutoSize = true;
            this.hacConvenio1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hacConvenio1.Enabled = false;
            this.hacConvenio1.Location = new System.Drawing.Point(34, 69);
            this.hacConvenio1.Name = "hacConvenio1";
            this.hacConvenio1.Obrigatorio = false;
            this.hacConvenio1.ObrigatorioMensagem = null;
            this.hacConvenio1.Size = new System.Drawing.Size(360, 24);
            this.hacConvenio1.TabIndex = 0;
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
            this.hacButton2.Location = new System.Drawing.Point(198, 23);
            this.hacButton2.Name = "hacButton2";
            this.hacButton2.Size = new System.Drawing.Size(105, 22);
            this.hacButton2.TabIndex = 4;
            this.hacButton2.Text = "Desabilitar";
            this.hacButton2.UseVisualStyleBackColor = true;
            this.hacButton2.Click += new System.EventHandler(this.hacButton2_Click);
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
            this.hacButton1.Location = new System.Drawing.Point(48, 24);
            this.hacButton1.Name = "hacButton1";
            this.hacButton1.Size = new System.Drawing.Size(105, 22);
            this.hacButton1.TabIndex = 3;
            this.hacButton1.Text = "Habilitar";
            this.hacButton1.UseVisualStyleBackColor = true;
            this.hacButton1.Click += new System.EventHandler(this.hacButton1_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hacButton2);
            this.Controls.Add(this.hacButton1);
            this.Controls.Add(this.hacConvenio1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(407, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private HospitalAnaCosta.SGS.Internacao.Controls.HacConvenio hacConvenio1;
        private Hac.Windows.Forms.Controls.HacButton hacButton2;
        private Hac.Windows.Forms.Controls.HacButton hacButton1;
    }
}
