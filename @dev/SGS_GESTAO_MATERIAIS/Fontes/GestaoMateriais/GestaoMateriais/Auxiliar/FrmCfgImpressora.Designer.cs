using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmCfgImpressora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCfgImpressora));
            this.hacToolStrip1 = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grpImpressora = new System.Windows.Forms.GroupBox();
            this.rbZebra = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbBematech = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.grbPorta = new System.Windows.Forms.GroupBox();
            this.grbHAC = new System.Windows.Forms.GroupBox();
            this.btnOkHAC = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtNomeImpHAC = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.rbRedeUSB_HAC = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.btnZerarHAC = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.rbSerialHAC2 = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbParalelaHAC2 = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbSerialHAC = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbParalelaHAC = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.grbACS = new System.Windows.Forms.GroupBox();
            this.btnOkACS = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtNomeImpACS = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.rbRedeUSB_ACS = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.btnZerarACS = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.rbSerialACS2 = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbParalelaACS2 = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbSerialACS = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbParalelaACS = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBixoImprimir = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbBemaImprimir = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.txtNomeBixolon = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.grpImpressora.SuspendLayout();
            this.grbPorta.SuspendLayout();
            this.grbHAC.SuspendLayout();
            this.grbACS.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hacToolStrip1
            // 
            this.hacToolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacToolStrip1.BackgroundImage")));
            this.hacToolStrip1.CancelarVisivel = false;
            this.hacToolStrip1.ExcluirVisivel = false;
            this.hacToolStrip1.ImprimirVisivel = false;
            this.hacToolStrip1.LimparVisivel = false;
            this.hacToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.hacToolStrip1.MatMedVisivel = false;
            this.hacToolStrip1.Name = "hacToolStrip1";
            this.hacToolStrip1.NomeControleFoco = null;
            this.hacToolStrip1.NovoVisivel = false;
            this.hacToolStrip1.PesquisarVisivel = false;
            this.hacToolStrip1.SalvarVisivel = false;
            this.hacToolStrip1.Size = new System.Drawing.Size(365, 28);
            this.hacToolStrip1.TabIndex = 0;
            this.hacToolStrip1.TituloTela = "Configuração de Impressoras";
            // 
            // grpImpressora
            // 
            this.grpImpressora.Controls.Add(this.rbZebra);
            this.grpImpressora.Controls.Add(this.rbBematech);
            this.grpImpressora.Location = new System.Drawing.Point(11, 87);
            this.grpImpressora.Name = "grpImpressora";
            this.grpImpressora.Size = new System.Drawing.Size(168, 45);
            this.grpImpressora.TabIndex = 1;
            this.grpImpressora.TabStop = false;
            this.grpImpressora.Text = "Impressora Produtos";
            this.grpImpressora.Visible = false;
            // 
            // rbZebra
            // 
            this.rbZebra.AutoSize = true;
            this.rbZebra.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbZebra.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbZebra.Limpar = false;
            this.rbZebra.Location = new System.Drawing.Point(90, 19);
            this.rbZebra.Name = "rbZebra";
            this.rbZebra.Obrigatorio = false;
            this.rbZebra.ObrigatorioMensagem = null;
            this.rbZebra.PreValidacaoMensagem = null;
            this.rbZebra.PreValidado = false;
            this.rbZebra.Size = new System.Drawing.Size(53, 17);
            this.rbZebra.TabIndex = 1;
            this.rbZebra.TabStop = true;
            this.rbZebra.Text = "Zebra";
            this.rbZebra.UseVisualStyleBackColor = true;
            this.rbZebra.CheckedChanged += new System.EventHandler(this.rbZebra_CheckedChanged);
            // 
            // rbBematech
            // 
            this.rbBematech.AutoSize = true;
            this.rbBematech.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbBematech.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbBematech.Limpar = false;
            this.rbBematech.Location = new System.Drawing.Point(11, 19);
            this.rbBematech.Name = "rbBematech";
            this.rbBematech.Obrigatorio = false;
            this.rbBematech.ObrigatorioMensagem = null;
            this.rbBematech.PreValidacaoMensagem = null;
            this.rbBematech.PreValidado = false;
            this.rbBematech.Size = new System.Drawing.Size(73, 17);
            this.rbBematech.TabIndex = 0;
            this.rbBematech.TabStop = true;
            this.rbBematech.Text = "Bematech";
            this.rbBematech.UseVisualStyleBackColor = true;
            this.rbBematech.CheckedChanged += new System.EventHandler(this.rbBematech_CheckedChanged);
            // 
            // grbPorta
            // 
            this.grbPorta.Controls.Add(this.grbHAC);
            this.grbPorta.Controls.Add(this.grbACS);
            this.grbPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPorta.Location = new System.Drawing.Point(11, 89);
            this.grbPorta.Name = "grbPorta";
            this.grbPorta.Size = new System.Drawing.Size(301, 314);
            this.grbPorta.TabIndex = 2;
            this.grbPorta.TabStop = false;
            this.grbPorta.Text = "Porta Zebra (Impressão Cod. Barra Mat/Med)";
            // 
            // grbHAC
            // 
            this.grbHAC.Controls.Add(this.btnOkHAC);
            this.grbHAC.Controls.Add(this.txtNomeImpHAC);
            this.grbHAC.Controls.Add(this.label1);
            this.grbHAC.Controls.Add(this.rbRedeUSB_HAC);
            this.grbHAC.Controls.Add(this.btnZerarHAC);
            this.grbHAC.Controls.Add(this.rbSerialHAC2);
            this.grbHAC.Controls.Add(this.rbParalelaHAC2);
            this.grbHAC.Controls.Add(this.rbSerialHAC);
            this.grbHAC.Controls.Add(this.rbParalelaHAC);
            this.grbHAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHAC.ForeColor = System.Drawing.Color.DarkGreen;
            this.grbHAC.Location = new System.Drawing.Point(9, 22);
            this.grbHAC.Name = "grbHAC";
            this.grbHAC.Size = new System.Drawing.Size(282, 139);
            this.grbHAC.TabIndex = 2;
            this.grbHAC.TabStop = false;
            this.grbHAC.Text = "HAC";
            // 
            // btnOkHAC
            // 
            this.btnOkHAC.AlterarStatus = true;
            this.btnOkHAC.BackColor = System.Drawing.Color.White;
            this.btnOkHAC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOkHAC.BackgroundImage")));
            this.btnOkHAC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOkHAC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnOkHAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkHAC.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnOkHAC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOkHAC.Location = new System.Drawing.Point(244, 110);
            this.btnOkHAC.Name = "btnOkHAC";
            this.btnOkHAC.Size = new System.Drawing.Size(35, 22);
            this.btnOkHAC.TabIndex = 6;
            this.btnOkHAC.Text = "OK";
            this.btnOkHAC.UseVisualStyleBackColor = false;
            this.btnOkHAC.Click += new System.EventHandler(this.btnOkHAC_Click);
            // 
            // txtNomeImpHAC
            // 
            this.txtNomeImpHAC.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomeImpHAC.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeImpHAC.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNomeImpHAC.Enabled = false;
            this.txtNomeImpHAC.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNomeImpHAC.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomeImpHAC.Limpar = false;
            this.txtNomeImpHAC.Location = new System.Drawing.Point(11, 111);
            this.txtNomeImpHAC.MaxLength = 100;
            this.txtNomeImpHAC.Name = "txtNomeImpHAC";
            this.txtNomeImpHAC.NaoAjustarEdicao = true;
            this.txtNomeImpHAC.Obrigatorio = false;
            this.txtNomeImpHAC.ObrigatorioMensagem = "";
            this.txtNomeImpHAC.PreValidacaoMensagem = null;
            this.txtNomeImpHAC.PreValidado = false;
            this.txtNomeImpHAC.SelectAllOnFocus = false;
            this.txtNomeImpHAC.Size = new System.Drawing.Size(231, 21);
            this.txtNomeImpHAC.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome instalação impressora";
            // 
            // rbRedeUSB_HAC
            // 
            this.rbRedeUSB_HAC.AutoSize = true;
            this.rbRedeUSB_HAC.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbRedeUSB_HAC.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbRedeUSB_HAC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRedeUSB_HAC.Limpar = false;
            this.rbRedeUSB_HAC.Location = new System.Drawing.Point(12, 71);
            this.rbRedeUSB_HAC.Name = "rbRedeUSB_HAC";
            this.rbRedeUSB_HAC.Obrigatorio = false;
            this.rbRedeUSB_HAC.ObrigatorioMensagem = null;
            this.rbRedeUSB_HAC.PreValidacaoMensagem = null;
            this.rbRedeUSB_HAC.PreValidado = false;
            this.rbRedeUSB_HAC.Size = new System.Drawing.Size(106, 17);
            this.rbRedeUSB_HAC.TabIndex = 6;
            this.rbRedeUSB_HAC.TabStop = true;
            this.rbRedeUSB_HAC.Text = "USB ou Rede";
            this.rbRedeUSB_HAC.UseVisualStyleBackColor = true;
            this.rbRedeUSB_HAC.Click += new System.EventHandler(this.rbRedeUSBHAC_Click);
            // 
            // btnZerarHAC
            // 
            this.btnZerarHAC.AlterarStatus = true;
            this.btnZerarHAC.BackColor = System.Drawing.Color.White;
            this.btnZerarHAC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZerarHAC.BackgroundImage")));
            this.btnZerarHAC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZerarHAC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnZerarHAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZerarHAC.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnZerarHAC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZerarHAC.Location = new System.Drawing.Point(151, 69);
            this.btnZerarHAC.Name = "btnZerarHAC";
            this.btnZerarHAC.Size = new System.Drawing.Size(124, 22);
            this.btnZerarHAC.TabIndex = 5;
            this.btnZerarHAC.Text = "Zerar config. HAC";
            this.btnZerarHAC.UseVisualStyleBackColor = false;
            this.btnZerarHAC.Click += new System.EventHandler(this.btnZerarHAC_Click);
            // 
            // rbSerialHAC2
            // 
            this.rbSerialHAC2.AutoSize = true;
            this.rbSerialHAC2.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbSerialHAC2.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbSerialHAC2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSerialHAC2.Limpar = false;
            this.rbSerialHAC2.Location = new System.Drawing.Point(143, 21);
            this.rbSerialHAC2.Name = "rbSerialHAC2";
            this.rbSerialHAC2.Obrigatorio = false;
            this.rbSerialHAC2.ObrigatorioMensagem = null;
            this.rbSerialHAC2.PreValidacaoMensagem = null;
            this.rbSerialHAC2.PreValidado = false;
            this.rbSerialHAC2.Size = new System.Drawing.Size(112, 17);
            this.rbSerialHAC2.TabIndex = 2;
            this.rbSerialHAC2.TabStop = true;
            this.rbSerialHAC2.Text = "Serial - COM2";
            this.rbSerialHAC2.UseVisualStyleBackColor = true;
            this.rbSerialHAC2.Click += new System.EventHandler(this.rbSerial_Click);
            // 
            // rbParalelaHAC2
            // 
            this.rbParalelaHAC2.AutoSize = true;
            this.rbParalelaHAC2.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbParalelaHAC2.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbParalelaHAC2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbParalelaHAC2.Limpar = false;
            this.rbParalelaHAC2.Location = new System.Drawing.Point(143, 45);
            this.rbParalelaHAC2.Name = "rbParalelaHAC2";
            this.rbParalelaHAC2.Obrigatorio = false;
            this.rbParalelaHAC2.ObrigatorioMensagem = null;
            this.rbParalelaHAC2.PreValidacaoMensagem = null;
            this.rbParalelaHAC2.PreValidado = false;
            this.rbParalelaHAC2.Size = new System.Drawing.Size(124, 17);
            this.rbParalelaHAC2.TabIndex = 3;
            this.rbParalelaHAC2.TabStop = true;
            this.rbParalelaHAC2.Text = "Paralela - LPT2";
            this.rbParalelaHAC2.UseVisualStyleBackColor = true;
            this.rbParalelaHAC2.Click += new System.EventHandler(this.rbParalela_Click);
            // 
            // rbSerialHAC
            // 
            this.rbSerialHAC.AutoSize = true;
            this.rbSerialHAC.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbSerialHAC.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbSerialHAC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSerialHAC.Limpar = false;
            this.rbSerialHAC.Location = new System.Drawing.Point(12, 21);
            this.rbSerialHAC.Name = "rbSerialHAC";
            this.rbSerialHAC.Obrigatorio = false;
            this.rbSerialHAC.ObrigatorioMensagem = null;
            this.rbSerialHAC.PreValidacaoMensagem = null;
            this.rbSerialHAC.PreValidado = false;
            this.rbSerialHAC.Size = new System.Drawing.Size(112, 17);
            this.rbSerialHAC.TabIndex = 0;
            this.rbSerialHAC.TabStop = true;
            this.rbSerialHAC.Text = "Serial - COM1";
            this.rbSerialHAC.UseVisualStyleBackColor = true;
            this.rbSerialHAC.Click += new System.EventHandler(this.rbSerial_Click);
            // 
            // rbParalelaHAC
            // 
            this.rbParalelaHAC.AutoSize = true;
            this.rbParalelaHAC.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbParalelaHAC.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbParalelaHAC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbParalelaHAC.Limpar = false;
            this.rbParalelaHAC.Location = new System.Drawing.Point(12, 45);
            this.rbParalelaHAC.Name = "rbParalelaHAC";
            this.rbParalelaHAC.Obrigatorio = false;
            this.rbParalelaHAC.ObrigatorioMensagem = null;
            this.rbParalelaHAC.PreValidacaoMensagem = null;
            this.rbParalelaHAC.PreValidado = false;
            this.rbParalelaHAC.Size = new System.Drawing.Size(124, 17);
            this.rbParalelaHAC.TabIndex = 1;
            this.rbParalelaHAC.TabStop = true;
            this.rbParalelaHAC.Text = "Paralela - LPT1";
            this.rbParalelaHAC.UseVisualStyleBackColor = true;
            this.rbParalelaHAC.Click += new System.EventHandler(this.rbParalela_Click);
            // 
            // grbACS
            // 
            this.grbACS.Controls.Add(this.btnOkACS);
            this.grbACS.Controls.Add(this.txtNomeImpACS);
            this.grbACS.Controls.Add(this.label2);
            this.grbACS.Controls.Add(this.rbRedeUSB_ACS);
            this.grbACS.Controls.Add(this.btnZerarACS);
            this.grbACS.Controls.Add(this.rbSerialACS2);
            this.grbACS.Controls.Add(this.rbParalelaACS2);
            this.grbACS.Controls.Add(this.rbSerialACS);
            this.grbACS.Controls.Add(this.rbParalelaACS);
            this.grbACS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbACS.ForeColor = System.Drawing.Color.DarkOrange;
            this.grbACS.Location = new System.Drawing.Point(9, 167);
            this.grbACS.Name = "grbACS";
            this.grbACS.Size = new System.Drawing.Size(282, 139);
            this.grbACS.TabIndex = 3;
            this.grbACS.TabStop = false;
            this.grbACS.Text = "ACS";
            // 
            // btnOkACS
            // 
            this.btnOkACS.AlterarStatus = true;
            this.btnOkACS.BackColor = System.Drawing.Color.White;
            this.btnOkACS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOkACS.BackgroundImage")));
            this.btnOkACS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOkACS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnOkACS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkACS.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnOkACS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOkACS.Location = new System.Drawing.Point(244, 111);
            this.btnOkACS.Name = "btnOkACS";
            this.btnOkACS.Size = new System.Drawing.Size(35, 22);
            this.btnOkACS.TabIndex = 7;
            this.btnOkACS.Text = "OK";
            this.btnOkACS.UseVisualStyleBackColor = false;
            this.btnOkACS.Click += new System.EventHandler(this.btnOkACS_Click);
            // 
            // txtNomeImpACS
            // 
            this.txtNomeImpACS.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomeImpACS.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeImpACS.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNomeImpACS.Enabled = false;
            this.txtNomeImpACS.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNomeImpACS.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomeImpACS.Limpar = false;
            this.txtNomeImpACS.Location = new System.Drawing.Point(11, 112);
            this.txtNomeImpACS.MaxLength = 100;
            this.txtNomeImpACS.Name = "txtNomeImpACS";
            this.txtNomeImpACS.NaoAjustarEdicao = true;
            this.txtNomeImpACS.Obrigatorio = false;
            this.txtNomeImpACS.ObrigatorioMensagem = "";
            this.txtNomeImpACS.PreValidacaoMensagem = null;
            this.txtNomeImpACS.PreValidado = false;
            this.txtNomeImpACS.SelectAllOnFocus = false;
            this.txtNomeImpACS.Size = new System.Drawing.Size(231, 21);
            this.txtNomeImpACS.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome instalação impressora";
            // 
            // rbRedeUSB_ACS
            // 
            this.rbRedeUSB_ACS.AutoSize = true;
            this.rbRedeUSB_ACS.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbRedeUSB_ACS.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbRedeUSB_ACS.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRedeUSB_ACS.Limpar = false;
            this.rbRedeUSB_ACS.Location = new System.Drawing.Point(12, 72);
            this.rbRedeUSB_ACS.Name = "rbRedeUSB_ACS";
            this.rbRedeUSB_ACS.Obrigatorio = false;
            this.rbRedeUSB_ACS.ObrigatorioMensagem = null;
            this.rbRedeUSB_ACS.PreValidacaoMensagem = null;
            this.rbRedeUSB_ACS.PreValidado = false;
            this.rbRedeUSB_ACS.Size = new System.Drawing.Size(106, 17);
            this.rbRedeUSB_ACS.TabIndex = 7;
            this.rbRedeUSB_ACS.TabStop = true;
            this.rbRedeUSB_ACS.Text = "USB ou Rede";
            this.rbRedeUSB_ACS.UseVisualStyleBackColor = true;
            this.rbRedeUSB_ACS.Click += new System.EventHandler(this.rbRedeUSBACS_Click);
            // 
            // btnZerarACS
            // 
            this.btnZerarACS.AlterarStatus = true;
            this.btnZerarACS.BackColor = System.Drawing.Color.White;
            this.btnZerarACS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZerarACS.BackgroundImage")));
            this.btnZerarACS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZerarACS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnZerarACS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZerarACS.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnZerarACS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnZerarACS.Location = new System.Drawing.Point(152, 71);
            this.btnZerarACS.Name = "btnZerarACS";
            this.btnZerarACS.Size = new System.Drawing.Size(124, 22);
            this.btnZerarACS.TabIndex = 4;
            this.btnZerarACS.Text = "Zerar config. ACS";
            this.btnZerarACS.UseVisualStyleBackColor = false;
            this.btnZerarACS.Click += new System.EventHandler(this.btnZerarACS_Click);
            // 
            // rbSerialACS2
            // 
            this.rbSerialACS2.AutoSize = true;
            this.rbSerialACS2.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbSerialACS2.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbSerialACS2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSerialACS2.Limpar = false;
            this.rbSerialACS2.Location = new System.Drawing.Point(144, 22);
            this.rbSerialACS2.Name = "rbSerialACS2";
            this.rbSerialACS2.Obrigatorio = false;
            this.rbSerialACS2.ObrigatorioMensagem = null;
            this.rbSerialACS2.PreValidacaoMensagem = null;
            this.rbSerialACS2.PreValidado = false;
            this.rbSerialACS2.Size = new System.Drawing.Size(112, 17);
            this.rbSerialACS2.TabIndex = 4;
            this.rbSerialACS2.TabStop = true;
            this.rbSerialACS2.Text = "Serial - COM2";
            this.rbSerialACS2.UseVisualStyleBackColor = true;
            this.rbSerialACS2.Click += new System.EventHandler(this.rbSerial_Click);
            // 
            // rbParalelaACS2
            // 
            this.rbParalelaACS2.AutoSize = true;
            this.rbParalelaACS2.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbParalelaACS2.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbParalelaACS2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbParalelaACS2.Limpar = false;
            this.rbParalelaACS2.Location = new System.Drawing.Point(144, 46);
            this.rbParalelaACS2.Name = "rbParalelaACS2";
            this.rbParalelaACS2.Obrigatorio = false;
            this.rbParalelaACS2.ObrigatorioMensagem = null;
            this.rbParalelaACS2.PreValidacaoMensagem = null;
            this.rbParalelaACS2.PreValidado = false;
            this.rbParalelaACS2.Size = new System.Drawing.Size(124, 17);
            this.rbParalelaACS2.TabIndex = 5;
            this.rbParalelaACS2.TabStop = true;
            this.rbParalelaACS2.Text = "Paralela - LPT2";
            this.rbParalelaACS2.UseVisualStyleBackColor = true;
            this.rbParalelaACS2.Click += new System.EventHandler(this.rbParalela_Click);
            // 
            // rbSerialACS
            // 
            this.rbSerialACS.AutoSize = true;
            this.rbSerialACS.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbSerialACS.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbSerialACS.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSerialACS.Limpar = false;
            this.rbSerialACS.Location = new System.Drawing.Point(12, 22);
            this.rbSerialACS.Name = "rbSerialACS";
            this.rbSerialACS.Obrigatorio = false;
            this.rbSerialACS.ObrigatorioMensagem = null;
            this.rbSerialACS.PreValidacaoMensagem = null;
            this.rbSerialACS.PreValidado = false;
            this.rbSerialACS.Size = new System.Drawing.Size(112, 17);
            this.rbSerialACS.TabIndex = 0;
            this.rbSerialACS.TabStop = true;
            this.rbSerialACS.Text = "Serial - COM1";
            this.rbSerialACS.UseVisualStyleBackColor = true;
            this.rbSerialACS.Click += new System.EventHandler(this.rbSerial_Click);
            // 
            // rbParalelaACS
            // 
            this.rbParalelaACS.AutoSize = true;
            this.rbParalelaACS.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbParalelaACS.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbParalelaACS.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbParalelaACS.Limpar = false;
            this.rbParalelaACS.Location = new System.Drawing.Point(12, 46);
            this.rbParalelaACS.Name = "rbParalelaACS";
            this.rbParalelaACS.Obrigatorio = false;
            this.rbParalelaACS.ObrigatorioMensagem = null;
            this.rbParalelaACS.PreValidacaoMensagem = null;
            this.rbParalelaACS.PreValidado = false;
            this.rbParalelaACS.Size = new System.Drawing.Size(124, 17);
            this.rbParalelaACS.TabIndex = 1;
            this.rbParalelaACS.TabStop = true;
            this.rbParalelaACS.Text = "Paralela - LPT1";
            this.rbParalelaACS.UseVisualStyleBackColor = true;
            this.rbParalelaACS.Click += new System.EventHandler(this.rbParalela_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbBixoImprimir);
            this.groupBox1.Controls.Add(this.rbBemaImprimir);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impressora de Pedidos";
            // 
            // rbBixoImprimir
            // 
            this.rbBixoImprimir.AutoSize = true;
            this.rbBixoImprimir.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbBixoImprimir.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbBixoImprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBixoImprimir.Limpar = false;
            this.rbBixoImprimir.Location = new System.Drawing.Point(101, 22);
            this.rbBixoImprimir.Name = "rbBixoImprimir";
            this.rbBixoImprimir.Obrigatorio = false;
            this.rbBixoImprimir.ObrigatorioMensagem = null;
            this.rbBixoImprimir.PreValidacaoMensagem = null;
            this.rbBixoImprimir.PreValidado = false;
            this.rbBixoImprimir.Size = new System.Drawing.Size(81, 17);
            this.rbBixoImprimir.TabIndex = 4;
            this.rbBixoImprimir.Text = "BIXOLON";
            this.rbBixoImprimir.UseVisualStyleBackColor = true;
            this.rbBixoImprimir.Click += new System.EventHandler(this.rbBixoImprimir_Click);
            // 
            // rbBemaImprimir
            // 
            this.rbBemaImprimir.AutoSize = true;
            this.rbBemaImprimir.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbBemaImprimir.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbBemaImprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBemaImprimir.Limpar = false;
            this.rbBemaImprimir.Location = new System.Drawing.Point(6, 23);
            this.rbBemaImprimir.Name = "rbBemaImprimir";
            this.rbBemaImprimir.Obrigatorio = false;
            this.rbBemaImprimir.ObrigatorioMensagem = null;
            this.rbBemaImprimir.PreValidacaoMensagem = null;
            this.rbBemaImprimir.PreValidado = false;
            this.rbBemaImprimir.Size = new System.Drawing.Size(93, 17);
            this.rbBemaImprimir.TabIndex = 0;
            this.rbBemaImprimir.Text = "BEMATECH";
            this.rbBemaImprimir.UseVisualStyleBackColor = true;
            this.rbBemaImprimir.Click += new System.EventHandler(this.rbBemaImprimir_Click);
            // 
            // txtNomeBixolon
            // 
            this.txtNomeBixolon.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNomeBixolon.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeBixolon.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNomeBixolon.Enabled = false;
            this.txtNomeBixolon.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNomeBixolon.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomeBixolon.Limpar = false;
            this.txtNomeBixolon.Location = new System.Drawing.Point(194, 52);
            this.txtNomeBixolon.MaxLength = 100;
            this.txtNomeBixolon.Name = "txtNomeBixolon";
            this.txtNomeBixolon.NaoAjustarEdicao = true;
            this.txtNomeBixolon.Obrigatorio = false;
            this.txtNomeBixolon.ObrigatorioMensagem = "";
            this.txtNomeBixolon.PreValidacaoMensagem = null;
            this.txtNomeBixolon.PreValidado = false;
            this.txtNomeBixolon.SelectAllOnFocus = false;
            this.txtNomeBixolon.Size = new System.Drawing.Size(153, 21);
            this.txtNomeBixolon.TabIndex = 5;
            this.txtNomeBixolon.Validating += new System.ComponentModel.CancelEventHandler(this.txtNomeBixolon_Validating);
            // 
            // FrmCfgImpressora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 411);
            this.Controls.Add(this.txtNomeBixolon);
            this.Controls.Add(this.grbPorta);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpImpressora);
            this.Controls.Add(this.hacToolStrip1);
            this.Name = "FrmCfgImpressora";
            this.Text = "SGS  ";
            this.Load += new System.EventHandler(this.FrmCfgImpressora_Load);
            this.grpImpressora.ResumeLayout(false);
            this.grpImpressora.PerformLayout();
            this.grbPorta.ResumeLayout(false);
            this.grbHAC.ResumeLayout(false);
            this.grbHAC.PerformLayout();
            this.grbACS.ResumeLayout(false);
            this.grbACS.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip hacToolStrip1;
        private System.Windows.Forms.GroupBox grpImpressora;
        private HacRadioButton rbZebra;
        private HacRadioButton rbBematech;
        private System.Windows.Forms.GroupBox grbPorta;
        private HacRadioButton rbSerialHAC;
        private HacRadioButton rbParalelaHAC;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacRadioButton rbBixoImprimir;
        private HacRadioButton rbBemaImprimir;
        private HacRadioButton rbParalelaACS;
        private HacRadioButton rbSerialACS;
        private System.Windows.Forms.GroupBox grbHAC;
        private HacRadioButton rbSerialHAC2;
        private HacRadioButton rbParalelaHAC2;
        private System.Windows.Forms.GroupBox grbACS;
        private HacRadioButton rbSerialACS2;
        private HacRadioButton rbParalelaACS2;
        private HacButton btnZerarHAC;
        private HacButton btnZerarACS;
        private HacRadioButton rbRedeUSB_HAC;
        private HacTextBox txtNomeImpHAC;
        private System.Windows.Forms.Label label1;
        private HacTextBox txtNomeImpACS;
        private System.Windows.Forms.Label label2;
        private HacRadioButton rbRedeUSB_ACS;
        private HacButton btnOkHAC;
        private HacButton btnOkACS;
        private HacTextBox txtNomeBixolon;
    }
}