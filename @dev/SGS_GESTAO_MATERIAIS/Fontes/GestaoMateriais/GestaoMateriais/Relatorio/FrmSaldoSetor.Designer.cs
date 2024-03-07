using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmSaldoSetor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaldoSetor));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chbPadraoNao = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbPadrao = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbSepse = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbDDD = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbLote = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbOrdenarEnd = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbAgruparSetor = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbPeriodo = new System.Windows.Forms.GroupBox();
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.grbEstoque = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTipoPedido = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnLimparProduto = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.cmbTipoPedido = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblProd = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbMatMed = new System.Windows.Forms.GroupBox();
            this.rbTodos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMateriais = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMedicamentos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.lblSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.rbConsig = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.chbPlanilhaCompleta = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox6.SuspendLayout();
            this.grbPeriodo.SuspendLayout();
            this.grbEstoque.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grbMatMed.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chbOrdenarEnd);
            this.groupBox6.Controls.Add(this.chbPlanilhaCompleta);
            this.groupBox6.Controls.Add(this.chbPadraoNao);
            this.groupBox6.Controls.Add(this.chbPadrao);
            this.groupBox6.Controls.Add(this.chbSepse);
            this.groupBox6.Controls.Add(this.chbDDD);
            this.groupBox6.Controls.Add(this.chbLote);
            this.groupBox6.Controls.Add(this.chbAgruparSetor);
            this.groupBox6.Controls.Add(this.grbPeriodo);
            this.groupBox6.Controls.Add(this.cmbSetor);
            this.groupBox6.Controls.Add(this.grbEstoque);
            this.groupBox6.Controls.Add(this.cmbLocal);
            this.groupBox6.Controls.Add(this.hacLabel1);
            this.groupBox6.Controls.Add(this.cmbUnidade);
            this.groupBox6.Controls.Add(this.hacLabel2);
            this.groupBox6.Controls.Add(this.hacLabel4);
            this.groupBox6.Location = new System.Drawing.Point(12, 36);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(758, 114);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // chbPadraoNao
            // 
            this.chbPadraoNao.AutoSize = true;
            this.chbPadraoNao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbPadraoNao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPadraoNao.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPadraoNao.Limpar = true;
            this.chbPadraoNao.Location = new System.Drawing.Point(192, 55);
            this.chbPadraoNao.Name = "chbPadraoNao";
            this.chbPadraoNao.Obrigatorio = false;
            this.chbPadraoNao.ObrigatorioMensagem = null;
            this.chbPadraoNao.PreValidacaoMensagem = null;
            this.chbPadraoNao.PreValidado = false;
            this.chbPadraoNao.Size = new System.Drawing.Size(157, 17);
            this.chbPadraoNao.TabIndex = 160;
            this.chbPadraoNao.Text = "APENAS NÃO PADRÃO";
            this.chbPadraoNao.UseVisualStyleBackColor = true;
            this.chbPadraoNao.Visible = false;
            this.chbPadraoNao.Click += new System.EventHandler(this.chbPadraoNao_Click);
            // 
            // chbPadrao
            // 
            this.chbPadrao.AutoSize = true;
            this.chbPadrao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbPadrao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPadrao.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPadrao.Limpar = true;
            this.chbPadrao.Location = new System.Drawing.Point(355, 55);
            this.chbPadrao.Name = "chbPadrao";
            this.chbPadrao.Obrigatorio = false;
            this.chbPadrao.ObrigatorioMensagem = null;
            this.chbPadrao.PreValidacaoMensagem = null;
            this.chbPadrao.PreValidado = false;
            this.chbPadrao.Size = new System.Drawing.Size(128, 17);
            this.chbPadrao.TabIndex = 158;
            this.chbPadrao.Text = "APENAS PADRÃO";
            this.chbPadrao.UseVisualStyleBackColor = true;
            this.chbPadrao.Visible = false;
            this.chbPadrao.Click += new System.EventHandler(this.chbPadrao_Click);
            // 
            // chbSepse
            // 
            this.chbSepse.AutoSize = true;
            this.chbSepse.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbSepse.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbSepse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSepse.Limpar = true;
            this.chbSepse.Location = new System.Drawing.Point(273, 76);
            this.chbSepse.Name = "chbSepse";
            this.chbSepse.Obrigatorio = false;
            this.chbSepse.ObrigatorioMensagem = null;
            this.chbSepse.PreValidacaoMensagem = null;
            this.chbSepse.PreValidado = false;
            this.chbSepse.Size = new System.Drawing.Size(66, 17);
            this.chbSepse.TabIndex = 159;
            this.chbSepse.Text = "SEPSE";
            this.chbSepse.UseVisualStyleBackColor = true;
            this.chbSepse.Visible = false;
            this.chbSepse.Click += new System.EventHandler(this.chbSepse_Click);
            // 
            // chbDDD
            // 
            this.chbDDD.AutoSize = true;
            this.chbDDD.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbDDD.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbDDD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDDD.Limpar = true;
            this.chbDDD.Location = new System.Drawing.Point(278, 87);
            this.chbDDD.Name = "chbDDD";
            this.chbDDD.Obrigatorio = false;
            this.chbDDD.ObrigatorioMensagem = null;
            this.chbDDD.PreValidacaoMensagem = null;
            this.chbDDD.PreValidado = false;
            this.chbDDD.Size = new System.Drawing.Size(306, 17);
            this.chbDDD.TabIndex = 158;
            this.chbDDD.Text = "CONSUMO ANTIBIÓTICOS DDD UTIs ADULTO";
            this.chbDDD.UseVisualStyleBackColor = true;
            this.chbDDD.Visible = false;
            // 
            // chbLote
            // 
            this.chbLote.AutoSize = true;
            this.chbLote.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbLote.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbLote.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLote.Limpar = true;
            this.chbLote.Location = new System.Drawing.Point(490, 55);
            this.chbLote.Name = "chbLote";
            this.chbLote.Obrigatorio = false;
            this.chbLote.ObrigatorioMensagem = null;
            this.chbLote.PreValidacaoMensagem = null;
            this.chbLote.PreValidado = false;
            this.chbLote.Size = new System.Drawing.Size(86, 17);
            this.chbLote.TabIndex = 157;
            this.chbLote.Text = "COM LOTE";
            this.chbLote.UseVisualStyleBackColor = true;
            this.chbLote.Visible = false;
            this.chbLote.Click += new System.EventHandler(this.chbLote_Click);
            // 
            // chbOrdenarEnd
            // 
            this.chbOrdenarEnd.AutoSize = true;
            this.chbOrdenarEnd.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbOrdenarEnd.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbOrdenarEnd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.chbOrdenarEnd.Limpar = true;
            this.chbOrdenarEnd.Location = new System.Drawing.Point(490, 87);
            this.chbOrdenarEnd.Name = "chbOrdenarEnd";
            this.chbOrdenarEnd.Obrigatorio = false;
            this.chbOrdenarEnd.ObrigatorioMensagem = null;
            this.chbOrdenarEnd.PreValidacaoMensagem = null;
            this.chbOrdenarEnd.PreValidado = false;
            this.chbOrdenarEnd.Size = new System.Drawing.Size(130, 17);
            this.chbOrdenarEnd.TabIndex = 156;
            this.chbOrdenarEnd.Text = "Ordenar Endereço";
            this.chbOrdenarEnd.UseVisualStyleBackColor = true;
            this.chbOrdenarEnd.Visible = false;
            // 
            // chbAgruparSetor
            // 
            this.chbAgruparSetor.AutoSize = true;
            this.chbAgruparSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbAgruparSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbAgruparSetor.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAgruparSetor.Limpar = true;
            this.chbAgruparSetor.Location = new System.Drawing.Point(278, 72);
            this.chbAgruparSetor.Name = "chbAgruparSetor";
            this.chbAgruparSetor.Obrigatorio = false;
            this.chbAgruparSetor.ObrigatorioMensagem = null;
            this.chbAgruparSetor.PreValidacaoMensagem = null;
            this.chbAgruparSetor.PreValidado = false;
            this.chbAgruparSetor.Size = new System.Drawing.Size(204, 17);
            this.chbAgruparSetor.TabIndex = 101;
            this.chbAgruparSetor.Text = "Agrupar Por Unidade/Setor";
            this.chbAgruparSetor.UseVisualStyleBackColor = true;
            this.chbAgruparSetor.Visible = false;
            // 
            // grbPeriodo
            // 
            this.grbPeriodo.Controls.Add(this.txtFim);
            this.grbPeriodo.Controls.Add(this.txtInicio);
            this.grbPeriodo.Controls.Add(this.hacLabel5);
            this.grbPeriodo.Controls.Add(this.hacLabel6);
            this.grbPeriodo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPeriodo.Location = new System.Drawing.Point(10, 51);
            this.grbPeriodo.Name = "grbPeriodo";
            this.grbPeriodo.Size = new System.Drawing.Size(253, 53);
            this.grbPeriodo.TabIndex = 4;
            this.grbPeriodo.TabStop = false;
            this.grbPeriodo.Text = "Período para pesquisa";
            this.grbPeriodo.Visible = false;
            // 
            // txtFim
            // 
            this.txtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Limpar = true;
            this.txtFim.Location = new System.Drawing.Point(154, 22);
            this.txtFim.MaxLength = 10;
            this.txtFim.Name = "txtFim";
            this.txtFim.NaoAjustarEdicao = true;
            this.txtFim.Obrigatorio = false;
            this.txtFim.ObrigatorioMensagem = null;
            this.txtFim.PreValidacaoMensagem = null;
            this.txtFim.PreValidado = false;
            this.txtFim.SelectAllOnFocus = false;
            this.txtFim.Size = new System.Drawing.Size(80, 20);
            this.txtFim.TabIndex = 6;
            this.txtFim.TabStop = false;
            // 
            // txtInicio
            // 
            this.txtInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Limpar = true;
            this.txtInicio.Location = new System.Drawing.Point(46, 22);
            this.txtInicio.MaxLength = 10;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.NaoAjustarEdicao = true;
            this.txtInicio.Obrigatorio = false;
            this.txtInicio.ObrigatorioMensagem = null;
            this.txtInicio.PreValidacaoMensagem = null;
            this.txtInicio.PreValidado = false;
            this.txtInicio.SelectAllOnFocus = false;
            this.txtInicio.Size = new System.Drawing.Size(80, 20);
            this.txtInicio.TabIndex = 5;
            this.txtInicio.TabStop = false;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(128, 25);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(27, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(7, 25);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 28;
            this.hacLabel6.Text = "Início";
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = true;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = true;
            this.cmbSetor.Location = new System.Drawing.Point(556, 19);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(188, 21);
            this.cmbSetor.TabIndex = 3;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // grbEstoque
            // 
            this.grbEstoque.Controls.Add(this.rbConsig);
            this.grbEstoque.Controls.Add(this.rbCE);
            this.grbEstoque.Controls.Add(this.rbHac);
            this.grbEstoque.Controls.Add(this.rbAcs);
            this.grbEstoque.Location = new System.Drawing.Point(590, 42);
            this.grbEstoque.Name = "grbEstoque";
            this.grbEstoque.Size = new System.Drawing.Size(155, 36);
            this.grbEstoque.TabIndex = 7;
            this.grbEstoque.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(56, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 3;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(7, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 1;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAcs.Enabled = false;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(154, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 2;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Visible = false;
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(307, 19);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(180, 21);
            this.cmbLocal.TabIndex = 2;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(4, 22);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 132;
            this.hacLabel1.Text = "Unidade";
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
            this.cmbUnidade.Location = new System.Drawing.Point(62, 19);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(180, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 1;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(265, 22);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 133;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(512, 22);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(38, 13);
            this.hacLabel4.TabIndex = 134;
            this.hacLabel4.Text = "Setor";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTipoPedido);
            this.groupBox3.Controls.Add(this.btnLimparProduto);
            this.groupBox3.Controls.Add(this.cmbTipoPedido);
            this.groupBox3.Controls.Add(this.lblProduto);
            this.groupBox3.Controls.Add(this.lblProd);
            this.groupBox3.Controls.Add(this.grbMatMed);
            this.groupBox3.Controls.Add(this.lblSubGrupo);
            this.groupBox3.Controls.Add(this.cmbSubGrupo);
            this.groupBox3.Controls.Add(this.hacLabel9);
            this.groupBox3.Controls.Add(this.cmbGrupo);
            this.groupBox3.Location = new System.Drawing.Point(12, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(758, 127);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleção de Filtro Opcional";
            // 
            // lblTipoPedido
            // 
            this.lblTipoPedido.AutoSize = true;
            this.lblTipoPedido.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTipoPedido.Location = new System.Drawing.Point(7, 68);
            this.lblTipoPedido.Name = "lblTipoPedido";
            this.lblTipoPedido.Size = new System.Drawing.Size(73, 13);
            this.lblTipoPedido.TabIndex = 155;
            this.lblTipoPedido.Text = "Tipo Pedido";
            this.lblTipoPedido.Visible = false;
            // 
            // btnLimparProduto
            // 
            this.btnLimparProduto.AlterarStatus = true;
            this.btnLimparProduto.BackColor = System.Drawing.Color.White;
            this.btnLimparProduto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimparProduto.BackgroundImage")));
            this.btnLimparProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimparProduto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnLimparProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparProduto.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnLimparProduto.Location = new System.Drawing.Point(403, 89);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(105, 22);
            this.btnLimparProduto.TabIndex = 158;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.UseVisualStyleBackColor = true;
            this.btnLimparProduto.Visible = false;
            this.btnLimparProduto.Click += new System.EventHandler(this.btnLimparProduto_Click);
            // 
            // cmbTipoPedido
            // 
            this.cmbTipoPedido.BackColor = System.Drawing.Color.Honeydew;
            this.cmbTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPedido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbTipoPedido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbTipoPedido.FormattingEnabled = true;
            this.cmbTipoPedido.Limpar = false;
            this.cmbTipoPedido.Location = new System.Drawing.Point(82, 64);
            this.cmbTipoPedido.Name = "cmbTipoPedido";
            this.cmbTipoPedido.Obrigatorio = false;
            this.cmbTipoPedido.ObrigatorioMensagem = null;
            this.cmbTipoPedido.PreValidacaoMensagem = null;
            this.cmbTipoPedido.PreValidado = false;
            this.cmbTipoPedido.Size = new System.Drawing.Size(219, 21);
            this.cmbTipoPedido.TabIndex = 154;
            this.cmbTipoPedido.Visible = false;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(87, 91);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 14);
            this.lblProduto.TabIndex = 157;
            this.lblProduto.Visible = false;
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProd.Location = new System.Drawing.Point(26, 92);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(51, 13);
            this.lblProd.TabIndex = 156;
            this.lblProd.Text = "Produto";
            this.lblProd.Visible = false;
            // 
            // grbMatMed
            // 
            this.grbMatMed.Controls.Add(this.rbTodos);
            this.grbMatMed.Controls.Add(this.rbApenasMateriais);
            this.grbMatMed.Controls.Add(this.rbApenasMedicamentos);
            this.grbMatMed.Location = new System.Drawing.Point(544, 15);
            this.grbMatMed.Name = "grbMatMed";
            this.grbMatMed.Size = new System.Drawing.Size(191, 98);
            this.grbMatMed.TabIndex = 14;
            this.grbMatMed.TabStop = false;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbTodos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbTodos.Limpar = true;
            this.rbTodos.Location = new System.Drawing.Point(9, 17);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Obrigatorio = false;
            this.rbTodos.ObrigatorioMensagem = null;
            this.rbTodos.PreValidacaoMensagem = null;
            this.rbTodos.PreValidado = false;
            this.rbTodos.Size = new System.Drawing.Size(63, 17);
            this.rbTodos.TabIndex = 15;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "TODOS";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbApenasMateriais
            // 
            this.rbApenasMateriais.AutoSize = true;
            this.rbApenasMateriais.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbApenasMateriais.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbApenasMateriais.Limpar = true;
            this.rbApenasMateriais.Location = new System.Drawing.Point(9, 71);
            this.rbApenasMateriais.Name = "rbApenasMateriais";
            this.rbApenasMateriais.Obrigatorio = false;
            this.rbApenasMateriais.ObrigatorioMensagem = null;
            this.rbApenasMateriais.PreValidacaoMensagem = null;
            this.rbApenasMateriais.PreValidado = false;
            this.rbApenasMateriais.Size = new System.Drawing.Size(129, 17);
            this.rbApenasMateriais.TabIndex = 17;
            this.rbApenasMateriais.Text = "APENAS MATERIAIS";
            this.rbApenasMateriais.UseVisualStyleBackColor = true;
            // 
            // rbApenasMedicamentos
            // 
            this.rbApenasMedicamentos.AutoSize = true;
            this.rbApenasMedicamentos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbApenasMedicamentos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbApenasMedicamentos.Limpar = true;
            this.rbApenasMedicamentos.Location = new System.Drawing.Point(9, 44);
            this.rbApenasMedicamentos.Name = "rbApenasMedicamentos";
            this.rbApenasMedicamentos.Obrigatorio = false;
            this.rbApenasMedicamentos.ObrigatorioMensagem = null;
            this.rbApenasMedicamentos.PreValidacaoMensagem = null;
            this.rbApenasMedicamentos.PreValidado = false;
            this.rbApenasMedicamentos.Size = new System.Drawing.Size(158, 17);
            this.rbApenasMedicamentos.TabIndex = 16;
            this.rbApenasMedicamentos.Text = "APENAS MEDICAMENTOS";
            this.rbApenasMedicamentos.UseVisualStyleBackColor = true;
            // 
            // lblSubGrupo
            // 
            this.lblSubGrupo.AutoSize = true;
            this.lblSubGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSubGrupo.Location = new System.Drawing.Point(8, 59);
            this.lblSubGrupo.Name = "lblSubGrupo";
            this.lblSubGrupo.Size = new System.Drawing.Size(69, 13);
            this.lblSubGrupo.TabIndex = 127;
            this.lblSubGrupo.Text = "Sub-Grupo";
            // 
            // cmbSubGrupo
            // 
            this.cmbSubGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSubGrupo.DisplayMember = "CAD_MTMD_SUBGRUPO_DESCRICAO";
            this.cmbSubGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbSubGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSubGrupo.FormattingEnabled = true;
            this.cmbSubGrupo.Limpar = true;
            this.cmbSubGrupo.Location = new System.Drawing.Point(82, 56);
            this.cmbSubGrupo.Name = "cmbSubGrupo";
            this.cmbSubGrupo.Obrigatorio = false;
            this.cmbSubGrupo.ObrigatorioMensagem = null;
            this.cmbSubGrupo.PreValidacaoMensagem = null;
            this.cmbSubGrupo.PreValidado = false;
            this.cmbSubGrupo.Size = new System.Drawing.Size(412, 21);
            this.cmbSubGrupo.TabIndex = 13;
            this.cmbSubGrupo.Text = "<Selecione>";
            this.cmbSubGrupo.ValueMember = "CAD_MTMD_SUBGRUPO_ID";
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(35, 30);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(42, 13);
            this.hacLabel9.TabIndex = 125;
            this.hacLabel9.Text = "Grupo";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbGrupo.DisplayMember = "CAD_MTMD_GRUPO_DESCRICAO";
            this.cmbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Limpar = true;
            this.cmbGrupo.Location = new System.Drawing.Point(82, 25);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Obrigatorio = false;
            this.cmbGrupo.ObrigatorioMensagem = null;
            this.cmbGrupo.PreValidacaoMensagem = null;
            this.cmbGrupo.PreValidado = false;
            this.cmbGrupo.Size = new System.Drawing.Size(412, 21);
            this.cmbGrupo.TabIndex = 12;
            this.cmbGrupo.Text = "<Selecione>";
            this.cmbGrupo.ValueMember = "CAD_MTMD_GRUPO_ID";
            this.cmbGrupo.SelectionChangeCommitted += new System.EventHandler(this.cmbGrupo_SelectionChangeCommitted);
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 100;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Relatório de Saldos em Estoque do Setor";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // rbConsig
            // 
            this.rbConsig.AutoSize = true;
            this.rbConsig.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbConsig.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbConsig.Limpar = true;
            this.rbConsig.Location = new System.Drawing.Point(97, 13);
            this.rbConsig.Name = "rbConsig";
            this.rbConsig.Obrigatorio = false;
            this.rbConsig.ObrigatorioMensagem = "";
            this.rbConsig.PreValidacaoMensagem = null;
            this.rbConsig.PreValidado = false;
            this.rbConsig.Size = new System.Drawing.Size(55, 17);
            this.rbConsig.TabIndex = 123;
            this.rbConsig.TabStop = true;
            this.rbConsig.Text = "CONS";
            this.rbConsig.UseVisualStyleBackColor = true;
            // 
            // chbPlanilhaCompleta
            // 
            this.chbPlanilhaCompleta.AutoSize = true;
            this.chbPlanilhaCompleta.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbPlanilhaCompleta.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPlanilhaCompleta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPlanilhaCompleta.Limpar = true;
            this.chbPlanilhaCompleta.Location = new System.Drawing.Point(625, 87);
            this.chbPlanilhaCompleta.Name = "chbPlanilhaCompleta";
            this.chbPlanilhaCompleta.Obrigatorio = false;
            this.chbPlanilhaCompleta.ObrigatorioMensagem = null;
            this.chbPlanilhaCompleta.PreValidacaoMensagem = null;
            this.chbPlanilhaCompleta.PreValidado = false;
            this.chbPlanilhaCompleta.Size = new System.Drawing.Size(129, 17);
            this.chbPlanilhaCompleta.TabIndex = 161;
            this.chbPlanilhaCompleta.Text = "Planilha Completa";
            this.chbPlanilhaCompleta.UseVisualStyleBackColor = true;
            this.chbPlanilhaCompleta.Visible = false;
            this.chbPlanilhaCompleta.Click += new System.EventHandler(this.chbPlanilhaCompleta_Click);
            // 
            // FrmSaldoSetor
            // 
            this.AccessibleName = "FrmSaldoSetor";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 297);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmSaldoSetor";
            this.Text = "Relatórios para Gestão de Estoque";
            this.Load += new System.EventHandler(this.FrmSaldoSetor_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grbPeriodo.ResumeLayout(false);
            this.grbPeriodo.PerformLayout();
            this.grbEstoque.ResumeLayout(false);
            this.grbEstoque.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbMatMed.ResumeLayout(false);
            this.grbMatMed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private HacCmbSetor cmbSetor;
        private System.Windows.Forms.GroupBox grbEstoque;
        private HacRadioButton rbHac;
        private HacRadioButton rbAcs;
        private HacCmbLocal cmbLocal;
        private HacLabel hacLabel1;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel2;
        private HacLabel hacLabel4;
        private HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grbMatMed;
        private HacLabel lblSubGrupo;
        private HacComboBox cmbSubGrupo;
        private HacLabel hacLabel9;
        private HacComboBox cmbGrupo;
        private HacRadioButton rbApenasMateriais;
        private HacRadioButton rbApenasMedicamentos;
        private HacRadioButton rbTodos;
        private HacRadioButton rbCE;
        private System.Windows.Forms.GroupBox grbPeriodo;
        private HacTextBox txtFim;
        private HacTextBox txtInicio;
        private HacLabel hacLabel5;
        private HacLabel hacLabel6;
        private HacButton btnLimparProduto;
        private HacLabel lblProduto;
        private HacLabel lblProd;
        private HacCheckBox chbAgruparSetor;
        private HacCheckBox chbOrdenarEnd;
        private HacCheckBox chbLote;
        private HacCheckBox chbDDD;
        private HacLabel lblTipoPedido;
        private HacComboBox cmbTipoPedido;
        private HacCheckBox chbSepse;
        private HacCheckBox chbPadrao;
        private HacCheckBox chbPadraoNao;
        private HacRadioButton rbConsig;
        private HacCheckBox chbPlanilhaCompleta;        
    }
}