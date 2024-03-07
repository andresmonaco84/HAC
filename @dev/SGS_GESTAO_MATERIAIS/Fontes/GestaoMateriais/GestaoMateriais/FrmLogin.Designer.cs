namespace HospitalAnaCosta.SGS.GestaoMateriais
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel1 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.hacLabel2 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.txtUsuario = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.hacLabel3 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.txtSenha = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.hacLabel4 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cmbUnidade = new Hac.Windows.Forms.Controls.HacCmbUnidade(this.components);
            this.hacLabel5 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cmbLocal = new Hac.Windows.Forms.Controls.HacCmbLocal(this.components);
            this.hacLabel6 = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.cmbSetor = new Hac.Windows.Forms.Controls.HacCmbSetor(this.components);
            this.btnLogin = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.chkLocal = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_cadeado;
            this.pictureBox2.Location = new System.Drawing.Point(0, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 183);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_login_sgs;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 99);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.hacLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 21);
            this.panel1.TabIndex = 2;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(174, 3);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(48, 13);
            this.hacLabel1.TabIndex = 0;
            this.hacLabel1.Text = "Log In";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(168, 133);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(50, 13);
            this.hacLabel2.TabIndex = 3;
            this.hacLabel2.Text = "Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtUsuario.BackColor = System.Drawing.Color.Honeydew;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(224, 130);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.SelectAllOnFocus = false;
            this.txtUsuario.Size = new System.Drawing.Size(174, 21);
            this.txtUsuario.TabIndex = 4;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(175, 160);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(43, 13);
            this.hacLabel3.TabIndex = 5;
            this.hacLabel3.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtSenha.BackColor = System.Drawing.Color.Honeydew;
            this.txtSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSenha.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(224, 157);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.SelectAllOnFocus = false;
            this.txtSenha.Size = new System.Drawing.Size(174, 21);
            this.txtSenha.TabIndex = 6;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(165, 188);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(53, 13);
            this.hacLabel4.TabIndex = 7;
            this.hacLabel4.Text = "Unidade";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.Location = new System.Drawing.Point(224, 184);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.Size = new System.Drawing.Size(177, 21);
            this.cmbUnidade.TabIndex = 8;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(106, 215);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(112, 13);
            this.hacLabel5.TabIndex = 9;
            this.hacLabel5.Text = "Local Atendimento";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Location = new System.Drawing.Point(224, 211);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(177, 21);
            this.cmbLocal.TabIndex = 10;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(180, 241);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 11;
            this.hacLabel6.Text = "Setor";
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Location = new System.Drawing.Point(224, 238);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.Size = new System.Drawing.Size(177, 21);
            this.cmbSetor.TabIndex = 12;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(294, 272);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 22);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkLocal
            // 
            this.chkLocal.AutoSize = true;
            this.chkLocal.Location = new System.Drawing.Point(172, 275);
            this.chkLocal.Name = "chkLocal";
            this.chkLocal.Size = new System.Drawing.Size(116, 17);
            this.chkLocal.TabIndex = 14;
            this.chkLocal.Text = "Salvar Localização";
            this.chkLocal.UseVisualStyleBackColor = true;
            this.chkLocal.Click += new System.EventHandler(this.chkLocal_Click);
            // 
            // FrmLogin
            // 
            this.ClientSize = new System.Drawing.Size(413, 306);
            this.ControlBox = false;
            this.Controls.Add(this.chkLocal);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel1;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel2;
        private Hac.Windows.Forms.Controls.HacTextBox txtUsuario;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel3;
        private Hac.Windows.Forms.Controls.HacTextBox txtSenha;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel4;
        private Hac.Windows.Forms.Controls.HacCmbUnidade cmbUnidade;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel5;
        private Hac.Windows.Forms.Controls.HacCmbLocal cmbLocal;
        private Hac.Windows.Forms.Controls.HacLabel hacLabel6;
        private Hac.Windows.Forms.Controls.HacCmbSetor cmbSetor;
        private Hac.Windows.Forms.Controls.HacButton btnLogin;
        private Hac.Windows.Forms.Controls.HacCheckBox chkLocal;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
