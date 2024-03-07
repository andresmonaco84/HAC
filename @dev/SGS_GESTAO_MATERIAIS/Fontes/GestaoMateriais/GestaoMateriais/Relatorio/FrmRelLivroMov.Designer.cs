namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmRelLivroMov
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelLivroMov));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiretorTec = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel19 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtFarmaceutico = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtEstado = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMunicipio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtEndereco = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtDataRef = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtCNPJ = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel14 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtNomeEmpresa = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtMes = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtAno = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(546, 28);
            this.tsHac.TabIndex = 125;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Impressão do Livro Oficial de Registro";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiretorTec);
            this.groupBox1.Controls.Add(this.hacLabel7);
            this.groupBox1.Controls.Add(this.hacLabel19);
            this.groupBox1.Controls.Add(this.txtFarmaceutico);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Controls.Add(this.hacLabel3);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.hacLabel6);
            this.groupBox1.Controls.Add(this.txtMunicipio);
            this.groupBox1.Controls.Add(this.hacLabel8);
            this.groupBox1.Controls.Add(this.txtEndereco);
            this.groupBox1.Controls.Add(this.txtDataRef);
            this.groupBox1.Controls.Add(this.txtCNPJ);
            this.groupBox1.Controls.Add(this.hacLabel14);
            this.groupBox1.Controls.Add(this.txtNomeEmpresa);
            this.groupBox1.Controls.Add(this.hacLabel11);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 204);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            // 
            // txtDiretorTec
            // 
            this.txtDiretorTec.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDiretorTec.BackColor = System.Drawing.Color.Honeydew;
            this.txtDiretorTec.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDiretorTec.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDiretorTec.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDiretorTec.Limpar = false;
            this.txtDiretorTec.Location = new System.Drawing.Point(112, 159);
            this.txtDiretorTec.MaxLength = 40;
            this.txtDiretorTec.Name = "txtDiretorTec";
            this.txtDiretorTec.NaoAjustarEdicao = true;
            this.txtDiretorTec.Obrigatorio = false;
            this.txtDiretorTec.ObrigatorioMensagem = "";
            this.txtDiretorTec.PreValidacaoMensagem = "";
            this.txtDiretorTec.PreValidado = false;
            this.txtDiretorTec.SelectAllOnFocus = false;
            this.txtDiretorTec.Size = new System.Drawing.Size(316, 21);
            this.txtDiretorTec.TabIndex = 192;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(16, 163);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(92, 13);
            this.hacLabel7.TabIndex = 191;
            this.hacLabel7.Text = "Diretor(a) Téc.";
            // 
            // hacLabel19
            // 
            this.hacLabel19.AutoSize = true;
            this.hacLabel19.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel19.Location = new System.Drawing.Point(9, 134);
            this.hacLabel19.Name = "hacLabel19";
            this.hacLabel19.Size = new System.Drawing.Size(100, 13);
            this.hacLabel19.TabIndex = 189;
            this.hacLabel19.Text = "Farmacêutico(a)";
            // 
            // txtFarmaceutico
            // 
            this.txtFarmaceutico.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtFarmaceutico.BackColor = System.Drawing.Color.Honeydew;
            this.txtFarmaceutico.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtFarmaceutico.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtFarmaceutico.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtFarmaceutico.Limpar = false;
            this.txtFarmaceutico.Location = new System.Drawing.Point(112, 130);
            this.txtFarmaceutico.MaxLength = 40;
            this.txtFarmaceutico.Name = "txtFarmaceutico";
            this.txtFarmaceutico.NaoAjustarEdicao = true;
            this.txtFarmaceutico.Obrigatorio = false;
            this.txtFarmaceutico.ObrigatorioMensagem = "";
            this.txtFarmaceutico.PreValidacaoMensagem = "";
            this.txtFarmaceutico.PreValidado = false;
            this.txtFarmaceutico.SelectAllOnFocus = false;
            this.txtFarmaceutico.Size = new System.Drawing.Size(316, 21);
            this.txtFarmaceutico.TabIndex = 190;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(15, 27);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(94, 13);
            this.hacLabel2.TabIndex = 175;
            this.hacLabel2.Text = "Nome Empresa";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(48, 52);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(60, 13);
            this.hacLabel3.TabIndex = 176;
            this.hacLabel3.Text = "Endereço";
            // 
            // txtEstado
            // 
            this.txtEstado.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtEstado.BackColor = System.Drawing.Color.Honeydew;
            this.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtEstado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtEstado.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtEstado.Limpar = false;
            this.txtEstado.Location = new System.Drawing.Point(390, 73);
            this.txtEstado.MaxLength = 2;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.NaoAjustarEdicao = true;
            this.txtEstado.Obrigatorio = false;
            this.txtEstado.ObrigatorioMensagem = "";
            this.txtEstado.PreValidacaoMensagem = "";
            this.txtEstado.PreValidado = false;
            this.txtEstado.SelectAllOnFocus = false;
            this.txtEstado.Size = new System.Drawing.Size(37, 21);
            this.txtEstado.TabIndex = 184;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(47, 77);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(59, 13);
            this.hacLabel6.TabIndex = 177;
            this.hacLabel6.Text = "Município";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtMunicipio.BackColor = System.Drawing.Color.Honeydew;
            this.txtMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMunicipio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMunicipio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtMunicipio.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMunicipio.Limpar = false;
            this.txtMunicipio.Location = new System.Drawing.Point(113, 73);
            this.txtMunicipio.MaxLength = 30;
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.NaoAjustarEdicao = true;
            this.txtMunicipio.Obrigatorio = false;
            this.txtMunicipio.ObrigatorioMensagem = "";
            this.txtMunicipio.PreValidacaoMensagem = "";
            this.txtMunicipio.PreValidado = false;
            this.txtMunicipio.SelectAllOnFocus = false;
            this.txtMunicipio.Size = new System.Drawing.Size(178, 21);
            this.txtMunicipio.TabIndex = 183;
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(69, 105);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(36, 13);
            this.hacLabel8.TabIndex = 179;
            this.hacLabel8.Text = "CNPJ";
            // 
            // txtEndereco
            // 
            this.txtEndereco.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtEndereco.BackColor = System.Drawing.Color.Honeydew;
            this.txtEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEndereco.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtEndereco.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtEndereco.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtEndereco.Limpar = false;
            this.txtEndereco.Location = new System.Drawing.Point(113, 47);
            this.txtEndereco.MaxLength = 80;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.NaoAjustarEdicao = true;
            this.txtEndereco.Obrigatorio = false;
            this.txtEndereco.ObrigatorioMensagem = "";
            this.txtEndereco.PreValidacaoMensagem = "";
            this.txtEndereco.PreValidado = false;
            this.txtEndereco.SelectAllOnFocus = false;
            this.txtEndereco.Size = new System.Drawing.Size(316, 21);
            this.txtEndereco.TabIndex = 182;
            // 
            // txtDataRef
            // 
            this.txtDataRef.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataRef.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataRef.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDataRef.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDataRef.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDataRef.Limpar = false;
            this.txtDataRef.Location = new System.Drawing.Point(347, 102);
            this.txtDataRef.MaxLength = 10;
            this.txtDataRef.Name = "txtDataRef";
            this.txtDataRef.NaoAjustarEdicao = true;
            this.txtDataRef.Obrigatorio = false;
            this.txtDataRef.ObrigatorioMensagem = "";
            this.txtDataRef.PreValidacaoMensagem = "";
            this.txtDataRef.PreValidado = false;
            this.txtDataRef.SelectAllOnFocus = false;
            this.txtDataRef.Size = new System.Drawing.Size(80, 21);
            this.txtDataRef.TabIndex = 188;
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCNPJ.BackColor = System.Drawing.Color.Honeydew;
            this.txtCNPJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCNPJ.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCNPJ.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtCNPJ.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCNPJ.Limpar = false;
            this.txtCNPJ.Location = new System.Drawing.Point(113, 102);
            this.txtCNPJ.MaxLength = 18;
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.NaoAjustarEdicao = true;
            this.txtCNPJ.Obrigatorio = false;
            this.txtCNPJ.ObrigatorioMensagem = "";
            this.txtCNPJ.PreValidacaoMensagem = "";
            this.txtCNPJ.PreValidado = false;
            this.txtCNPJ.SelectAllOnFocus = false;
            this.txtCNPJ.Size = new System.Drawing.Size(150, 21);
            this.txtCNPJ.TabIndex = 186;
            // 
            // hacLabel14
            // 
            this.hacLabel14.AutoSize = true;
            this.hacLabel14.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel14.Location = new System.Drawing.Point(282, 106);
            this.hacLabel14.Name = "hacLabel14";
            this.hacLabel14.Size = new System.Drawing.Size(66, 13);
            this.hacLabel14.TabIndex = 187;
            this.hacLabel14.Text = "Data Ref.:";
            // 
            // txtNomeEmpresa
            // 
            this.txtNomeEmpresa.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomeEmpresa.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeEmpresa.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNomeEmpresa.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNomeEmpresa.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomeEmpresa.Limpar = false;
            this.txtNomeEmpresa.Location = new System.Drawing.Point(113, 22);
            this.txtNomeEmpresa.MaxLength = 40;
            this.txtNomeEmpresa.Name = "txtNomeEmpresa";
            this.txtNomeEmpresa.NaoAjustarEdicao = true;
            this.txtNomeEmpresa.Obrigatorio = false;
            this.txtNomeEmpresa.ObrigatorioMensagem = "";
            this.txtNomeEmpresa.PreValidacaoMensagem = "";
            this.txtNomeEmpresa.PreValidado = false;
            this.txtNomeEmpresa.SelectAllOnFocus = false;
            this.txtNomeEmpresa.Size = new System.Drawing.Size(316, 21);
            this.txtNomeEmpresa.TabIndex = 181;
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(298, 77);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(87, 13);
            this.hacLabel11.TabIndex = 180;
            this.hacLabel11.Text = "Estado (Sigla)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbAcs);
            this.groupBox4.Controls.Add(this.rbHac);
            this.groupBox4.Location = new System.Drawing.Point(342, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(111, 36);
            this.groupBox4.TabIndex = 127;
            this.groupBox4.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAcs.Limpar = false;
            this.rbAcs.Location = new System.Drawing.Point(59, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(49, 17);
            this.rbAcs.TabIndex = 1;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Click += new System.EventHandler(this.rbAcs_CheckedChanged);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Checked = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(6, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(50, 17);
            this.rbHac.TabIndex = 0;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.Click += new System.EventHandler(this.rbHac_CheckedChanged);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(103, 79);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(12, 13);
            this.hacLabel1.TabIndex = 138;
            this.hacLabel1.Text = "/";
            // 
            // txtMes
            // 
            this.txtMes.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtMes.BackColor = System.Drawing.Color.Honeydew;
            this.txtMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtMes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtMes.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtMes.Limpar = false;
            this.txtMes.Location = new System.Drawing.Point(71, 75);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.NaoAjustarEdicao = true;
            this.txtMes.Obrigatorio = false;
            this.txtMes.ObrigatorioMensagem = null;
            this.txtMes.PreValidacaoMensagem = null;
            this.txtMes.PreValidado = false;
            this.txtMes.SelectAllOnFocus = false;
            this.txtMes.Size = new System.Drawing.Size(30, 21);
            this.txtMes.TabIndex = 136;
            // 
            // txtAno
            // 
            this.txtAno.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtAno.BackColor = System.Drawing.Color.Honeydew;
            this.txtAno.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtAno.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtAno.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtAno.Limpar = false;
            this.txtAno.Location = new System.Drawing.Point(117, 75);
            this.txtAno.MaxLength = 4;
            this.txtAno.Name = "txtAno";
            this.txtAno.NaoAjustarEdicao = true;
            this.txtAno.Obrigatorio = false;
            this.txtAno.ObrigatorioMensagem = "";
            this.txtAno.PreValidacaoMensagem = "";
            this.txtAno.PreValidado = false;
            this.txtAno.SelectAllOnFocus = false;
            this.txtAno.Size = new System.Drawing.Size(40, 21);
            this.txtAno.TabIndex = 137;
            this.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(13, 79);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(56, 13);
            this.hacLabel4.TabIndex = 135;
            this.hacLabel4.Text = "Mês/Ano";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(14, 45);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(53, 13);
            this.hacLabel5.TabIndex = 149;
            this.hacLabel5.Text = "Unidade";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = true;
            this.cmbUnidade.Location = new System.Drawing.Point(70, 42);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(254, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 148;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(221, 79);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 14);
            this.lblProduto.TabIndex = 151;
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(167, 80);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(51, 13);
            this.hacLabel9.TabIndex = 150;
            this.hacLabel9.Text = "Produto";
            // 
            // FrmRelLivroMov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 334);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.hacLabel9);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmRelLivroMov";
            this.Text = "Impressão do Livro Oficial de Registro";
            this.Load += new System.EventHandler(this.FrmRelLivroMov_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel3;
        private SGS.Componentes.HacTextBox txtEstado;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacTextBox txtMunicipio;
        private SGS.Componentes.HacLabel hacLabel8;
        private SGS.Componentes.HacTextBox txtEndereco;
        private SGS.Componentes.HacTextBox txtDataRef;
        private SGS.Componentes.HacTextBox txtCNPJ;
        private SGS.Componentes.HacLabel hacLabel14;
        private SGS.Componentes.HacTextBox txtNomeEmpresa;
        private SGS.Componentes.HacLabel hacLabel11;
        private System.Windows.Forms.GroupBox groupBox4;
        private SGS.Componentes.HacRadioButton rbAcs;
        private SGS.Componentes.HacRadioButton rbHac;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacTextBox txtMes;
        private SGS.Componentes.HacTextBox txtAno;
        private SGS.Componentes.HacLabel hacLabel4;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacCmbUnidade cmbUnidade;
        private SGS.Componentes.HacTextBox txtDiretorTec;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacLabel hacLabel19;
        private SGS.Componentes.HacTextBox txtFarmaceutico;
        private SGS.Componentes.HacLabel lblProduto;
        private SGS.Componentes.HacLabel hacLabel9;
    }
}