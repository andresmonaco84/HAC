using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.Seguranca.Forms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtUsuario = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.pnlUnidade = new System.Windows.Forms.Panel();
            this.btnCancelarUnidade = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnSalvarUnidade = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.pnlBarraTituloLocallizacao = new System.Windows.Forms.Panel();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.pnlTrocaSenha = new System.Windows.Forms.Panel();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.txtSenhaAtual = new System.Windows.Forms.TextBox();
            this.btnCancelarNovaSenha = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnSalvarNovaSenha = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBarraTituloTrocaSenha = new System.Windows.Forms.Panel();
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnCancelar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnLogin = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTrocaSenha = new System.Windows.Forms.Label();
            this.lblTrocarLocalizacao = new System.Windows.Forms.Label();
            this.toolStatus = new System.Windows.Forms.StatusStrip();
            this.lblUnidade = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLocal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSetor = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlUnidade.SuspendLayout();
            this.pnlBarraTituloLocallizacao.SuspendLayout();
            this.pnlTrocaSenha.SuspendLayout();
            this.pnlBarraTituloTrocaSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStatus.SuspendLayout();
            this.SuspendLayout();
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
            this.hacLabel2.Location = new System.Drawing.Point(124, 133);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(50, 13);
            this.hacLabel2.TabIndex = 3;
            this.hacLabel2.Text = "Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUsuario.BackColor = System.Drawing.Color.Honeydew;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtUsuario.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtUsuario.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUsuario.Limpar = false;
            this.txtUsuario.Location = new System.Drawing.Point(180, 130);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.NaoAjustarEdicao = false;
            this.txtUsuario.Obrigatorio = false;
            this.txtUsuario.ObrigatorioMensagem = null;
            this.txtUsuario.PreValidacaoMensagem = null;
            this.txtUsuario.PreValidado = false;
            this.txtUsuario.SelectAllOnFocus = false;
            this.txtUsuario.Size = new System.Drawing.Size(174, 21);
            this.txtUsuario.TabIndex = 4;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(131, 160);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(43, 13);
            this.hacLabel3.TabIndex = 5;
            this.hacLabel3.Text = "Senha";
            // 
            // pnlUnidade
            // 
            this.pnlUnidade.Controls.Add(this.btnCancelarUnidade);
            this.pnlUnidade.Controls.Add(this.btnSalvarUnidade);
            this.pnlUnidade.Controls.Add(this.cmbSetor);
            this.pnlUnidade.Controls.Add(this.hacLabel6);
            this.pnlUnidade.Controls.Add(this.cmbLocal);
            this.pnlUnidade.Controls.Add(this.hacLabel5);
            this.pnlUnidade.Controls.Add(this.cmbUnidade);
            this.pnlUnidade.Controls.Add(this.hacLabel4);
            this.pnlUnidade.Controls.Add(this.pnlBarraTituloLocallizacao);
            this.pnlUnidade.Location = new System.Drawing.Point(3, 331);
            this.pnlUnidade.Name = "pnlUnidade";
            this.pnlUnidade.Size = new System.Drawing.Size(413, 140);
            this.pnlUnidade.TabIndex = 18;
            this.pnlUnidade.Visible = false;
            // 
            // btnCancelarUnidade
            // 
            this.btnCancelarUnidade.AlterarStatus = true;
            this.btnCancelarUnidade.BackColor = System.Drawing.Color.White;
            this.btnCancelarUnidade.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarUnidade.BackgroundImage")));
            this.btnCancelarUnidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarUnidade.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelarUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarUnidade.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelarUnidade.Location = new System.Drawing.Point(214, 111);
            this.btnCancelarUnidade.Name = "btnCancelarUnidade";
            this.btnCancelarUnidade.Size = new System.Drawing.Size(105, 22);
            this.btnCancelarUnidade.TabIndex = 25;
            this.btnCancelarUnidade.Text = "Cancelar";
            this.btnCancelarUnidade.UseVisualStyleBackColor = true;
            this.btnCancelarUnidade.Click += new System.EventHandler(this.btnCancelarUnidade_Click);
            // 
            // btnSalvarUnidade
            // 
            this.btnSalvarUnidade.AlterarStatus = true;
            this.btnSalvarUnidade.BackColor = System.Drawing.Color.White;
            this.btnSalvarUnidade.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvarUnidade.BackgroundImage")));
            this.btnSalvarUnidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvarUnidade.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvarUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarUnidade.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvarUnidade.Location = new System.Drawing.Point(86, 111);
            this.btnSalvarUnidade.Name = "btnSalvarUnidade";
            this.btnSalvarUnidade.Size = new System.Drawing.Size(105, 22);
            this.btnSalvarUnidade.TabIndex = 24;
            this.btnSalvarUnidade.Text = "Salvar";
            this.btnSalvarUnidade.UseVisualStyleBackColor = true;
            this.btnSalvarUnidade.Click += new System.EventHandler(this.btnSalvarUnidade_Click);
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(142, 81);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(177, 21);
            this.cmbSetor.TabIndex = 23;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(98, 84);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 22;
            this.hacLabel6.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(142, 54);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(177, 21);
            this.cmbLocal.TabIndex = 21;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(24, 58);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(112, 13);
            this.hacLabel5.TabIndex = 20;
            this.hacLabel5.Text = "Local Atendimento";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = false;
            this.cmbUnidade.Location = new System.Drawing.Point(142, 27);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(177, 21);
            this.cmbUnidade.SomenteAtiva = true;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 19;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(83, 31);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(53, 13);
            this.hacLabel4.TabIndex = 18;
            this.hacLabel4.Text = "Unidade";
            // 
            // pnlBarraTituloLocallizacao
            // 
            this.pnlBarraTituloLocallizacao.BackColor = System.Drawing.Color.Green;
            this.pnlBarraTituloLocallizacao.Controls.Add(this.hacLabel7);
            this.pnlBarraTituloLocallizacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTituloLocallizacao.ForeColor = System.Drawing.Color.White;
            this.pnlBarraTituloLocallizacao.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTituloLocallizacao.Name = "pnlBarraTituloLocallizacao";
            this.pnlBarraTituloLocallizacao.Size = new System.Drawing.Size(413, 21);
            this.pnlBarraTituloLocallizacao.TabIndex = 17;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(124, 4);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(156, 13);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Selecionar Localização";
            // 
            // pnlTrocaSenha
            // 
            this.pnlTrocaSenha.Controls.Add(this.txtNovaSenha);
            this.pnlTrocaSenha.Controls.Add(this.txtSenhaAtual);
            this.pnlTrocaSenha.Controls.Add(this.btnCancelarNovaSenha);
            this.pnlTrocaSenha.Controls.Add(this.btnSalvarNovaSenha);
            this.pnlTrocaSenha.Controls.Add(this.label2);
            this.pnlTrocaSenha.Controls.Add(this.label1);
            this.pnlTrocaSenha.Controls.Add(this.pnlBarraTituloTrocaSenha);
            this.pnlTrocaSenha.Location = new System.Drawing.Point(0, 378);
            this.pnlTrocaSenha.Name = "pnlTrocaSenha";
            this.pnlTrocaSenha.Size = new System.Drawing.Size(413, 140);
            this.pnlTrocaSenha.TabIndex = 19;
            this.pnlTrocaSenha.Visible = false;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.BackColor = System.Drawing.Color.Honeydew;
            this.txtNovaSenha.Location = new System.Drawing.Point(145, 71);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.Size = new System.Drawing.Size(174, 20);
            this.txtNovaSenha.TabIndex = 27;
            this.txtNovaSenha.UseSystemPasswordChar = true;
            this.txtNovaSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNovaSenha_KeyPress);
            // 
            // txtSenhaAtual
            // 
            this.txtSenhaAtual.BackColor = System.Drawing.Color.Honeydew;
            this.txtSenhaAtual.Location = new System.Drawing.Point(145, 44);
            this.txtSenhaAtual.Name = "txtSenhaAtual";
            this.txtSenhaAtual.Size = new System.Drawing.Size(174, 20);
            this.txtSenhaAtual.TabIndex = 26;
            this.txtSenhaAtual.UseSystemPasswordChar = true;
            // 
            // btnCancelarNovaSenha
            // 
            this.btnCancelarNovaSenha.AlterarStatus = true;
            this.btnCancelarNovaSenha.BackColor = System.Drawing.Color.White;
            this.btnCancelarNovaSenha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarNovaSenha.BackgroundImage")));
            this.btnCancelarNovaSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarNovaSenha.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelarNovaSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarNovaSenha.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelarNovaSenha.Location = new System.Drawing.Point(214, 99);
            this.btnCancelarNovaSenha.Name = "btnCancelarNovaSenha";
            this.btnCancelarNovaSenha.Size = new System.Drawing.Size(105, 22);
            this.btnCancelarNovaSenha.TabIndex = 24;
            this.btnCancelarNovaSenha.Text = "Cancelar";
            this.btnCancelarNovaSenha.UseVisualStyleBackColor = true;
            this.btnCancelarNovaSenha.Click += new System.EventHandler(this.btnCancelarNovaSenha_Click);
            // 
            // btnSalvarNovaSenha
            // 
            this.btnSalvarNovaSenha.AlterarStatus = true;
            this.btnSalvarNovaSenha.BackColor = System.Drawing.Color.White;
            this.btnSalvarNovaSenha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalvarNovaSenha.BackgroundImage")));
            this.btnSalvarNovaSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvarNovaSenha.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvarNovaSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarNovaSenha.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvarNovaSenha.Location = new System.Drawing.Point(103, 99);
            this.btnSalvarNovaSenha.Name = "btnSalvarNovaSenha";
            this.btnSalvarNovaSenha.Size = new System.Drawing.Size(105, 22);
            this.btnSalvarNovaSenha.TabIndex = 23;
            this.btnSalvarNovaSenha.Text = "Salvar";
            this.btnSalvarNovaSenha.UseVisualStyleBackColor = true;
            this.btnSalvarNovaSenha.Click += new System.EventHandler(this.btnSalvarNovaSenha_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nova Senha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Senha atual";
            // 
            // pnlBarraTituloTrocaSenha
            // 
            this.pnlBarraTituloTrocaSenha.BackColor = System.Drawing.Color.Green;
            this.pnlBarraTituloTrocaSenha.Controls.Add(this.hacLabel8);
            this.pnlBarraTituloTrocaSenha.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTituloTrocaSenha.ForeColor = System.Drawing.Color.White;
            this.pnlBarraTituloTrocaSenha.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTituloTrocaSenha.Name = "pnlBarraTituloTrocaSenha";
            this.pnlBarraTituloTrocaSenha.Size = new System.Drawing.Size(413, 21);
            this.pnlBarraTituloTrocaSenha.TabIndex = 18;
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(159, 4);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(94, 13);
            this.hacLabel8.TabIndex = 0;
            this.hacLabel8.Text = "Trocar Senha";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AlterarStatus = true;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(238, 206);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 22);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AlterarStatus = true;
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(127, 206);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 22);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HospitalAnaCosta.SGS.Seguranca.Forms.Properties.Resources.img_cadeado;
            this.pictureBox2.Location = new System.Drawing.Point(0, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::HospitalAnaCosta.SGS.Seguranca.Forms.Properties.Resources.img_login_sgs;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 99);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTrocaSenha
            // 
            this.lblTrocaSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTrocaSenha.Image = global::HospitalAnaCosta.SGS.Seguranca.Forms.Properties.Resources.lock_edit;
            this.lblTrocaSenha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrocaSenha.Location = new System.Drawing.Point(9, 241);
            this.lblTrocaSenha.Name = "lblTrocaSenha";
            this.lblTrocaSenha.Size = new System.Drawing.Size(107, 23);
            this.lblTrocaSenha.TabIndex = 21;
            this.lblTrocaSenha.Text = "Trocar Senha";
            this.lblTrocaSenha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrocaSenha.Click += new System.EventHandler(this.lblTrocaSenha_Click);
            // 
            // lblTrocarLocalizacao
            // 
            this.lblTrocarLocalizacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTrocarLocalizacao.Image = global::HospitalAnaCosta.SGS.Seguranca.Forms.Properties.Resources.house;
            this.lblTrocarLocalizacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrocarLocalizacao.Location = new System.Drawing.Point(131, 241);
            this.lblTrocarLocalizacao.Name = "lblTrocarLocalizacao";
            this.lblTrocarLocalizacao.Size = new System.Drawing.Size(122, 23);
            this.lblTrocarLocalizacao.TabIndex = 22;
            this.lblTrocarLocalizacao.Text = "Trocar Localização";
            this.lblTrocarLocalizacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTrocarLocalizacao.Click += new System.EventHandler(this.lblTrocarLocalizacao_Click);
            // 
            // toolStatus
            // 
            this.toolStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUnidade,
            this.lblLocal,
            this.lblSetor});
            this.toolStatus.Location = new System.Drawing.Point(0, 554);
            this.toolStatus.Name = "toolStatus";
            this.toolStatus.Size = new System.Drawing.Size(413, 22);
            this.toolStatus.TabIndex = 24;
            this.toolStatus.Text = "statusStrip1";
            // 
            // lblUnidade
            // 
            this.lblUnidade.BackColor = System.Drawing.Color.Transparent;
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(0, 17);
            // 
            // lblLocal
            // 
            this.lblLocal.BackColor = System.Drawing.Color.Transparent;
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSetor
            // 
            this.lblSetor.BackColor = System.Drawing.Color.Transparent;
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(0, 17);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.Honeydew;
            this.txtSenha.Location = new System.Drawing.Point(180, 158);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(174, 20);
            this.txtSenha.TabIndex = 5;
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(413, 576);
            this.ControlBox = false;
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.pnlTrocaSenha);
            this.Controls.Add(this.toolStatus);
            this.Controls.Add(this.pnlUnidade);
            this.Controls.Add(this.lblTrocarLocalizacao);
            this.Controls.Add(this.lblTrocaSenha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "SGS - Sistema de Gestão Hospitalar I";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlUnidade.ResumeLayout(false);
            this.pnlUnidade.PerformLayout();
            this.pnlBarraTituloLocallizacao.ResumeLayout(false);
            this.pnlBarraTituloLocallizacao.PerformLayout();
            this.pnlTrocaSenha.ResumeLayout(false);
            this.pnlTrocaSenha.PerformLayout();
            this.pnlBarraTituloTrocaSenha.ResumeLayout(false);
            this.pnlBarraTituloTrocaSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStatus.ResumeLayout(false);
            this.toolStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel1;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel2;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtUsuario;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel3;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnLogin;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnCancelar;
        private HospitalAnaCosta.SGS.Componentes.HacCmbSetor cmbSetor;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel6;
        private HospitalAnaCosta.SGS.Componentes.HacCmbLocal cmbLocal;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel5;
        private HospitalAnaCosta.SGS.Componentes.HacCmbUnidade cmbUnidade;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel4;
        private System.Windows.Forms.Panel pnlBarraTituloLocallizacao;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel7;
        private System.Windows.Forms.Panel pnlUnidade;
        private System.Windows.Forms.Panel pnlTrocaSenha;
        private System.Windows.Forms.Panel pnlBarraTituloTrocaSenha;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel8;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnCancelarNovaSenha;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnSalvarNovaSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrocaSenha;
        private System.Windows.Forms.Label lblTrocarLocalizacao;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnCancelarUnidade;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnSalvarUnidade;
        private System.Windows.Forms.StatusStrip toolStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblUnidade;
        private System.Windows.Forms.ToolStripStatusLabel lblLocal;
        private System.Windows.Forms.ToolStripStatusLabel lblSetor;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtSenhaAtual;
        private System.Windows.Forms.TextBox txtNovaSenha;
    }
}
