namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmRelEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelEstoque));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chbComLote = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbOrdenarEnd = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.gbMatMed = new System.Windows.Forms.GroupBox();
            this.rbTodos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMateriais = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMedicamentos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbMedSimilar = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.chbGrupo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblGrupo = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbGrupo = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.txtData = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblData = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.rbConsig = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox6.SuspendLayout();
            this.gbMatMed.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chbComLote);
            this.groupBox6.Controls.Add(this.chbOrdenarEnd);
            this.groupBox6.Controls.Add(this.gbMatMed);
            this.groupBox6.Controls.Add(this.chbGrupo);
            this.groupBox6.Controls.Add(this.lblGrupo);
            this.groupBox6.Controls.Add(this.cmbGrupo);
            this.groupBox6.Controls.Add(this.txtData);
            this.groupBox6.Controls.Add(this.lblData);
            this.groupBox6.Controls.Add(this.cmbSetor);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.cmbLocal);
            this.groupBox6.Controls.Add(this.hacLabel1);
            this.groupBox6.Controls.Add(this.cmbUnidade);
            this.groupBox6.Controls.Add(this.hacLabel2);
            this.groupBox6.Controls.Add(this.hacLabel4);
            this.groupBox6.Location = new System.Drawing.Point(12, 28);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(495, 188);
            this.groupBox6.TabIndex = 101;
            this.groupBox6.TabStop = false;
            // 
            // chbComLote
            // 
            this.chbComLote.AutoSize = true;
            this.chbComLote.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbComLote.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbComLote.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.chbComLote.Limpar = false;
            this.chbComLote.Location = new System.Drawing.Point(159, 159);
            this.chbComLote.Name = "chbComLote";
            this.chbComLote.Obrigatorio = false;
            this.chbComLote.ObrigatorioMensagem = null;
            this.chbComLote.PreValidacaoMensagem = null;
            this.chbComLote.PreValidado = false;
            this.chbComLote.Size = new System.Drawing.Size(54, 17);
            this.chbComLote.TabIndex = 155;
            this.chbComLote.Text = "Lote";
            this.chbComLote.UseVisualStyleBackColor = true;
            this.chbComLote.Visible = false;
            this.chbComLote.Click += new System.EventHandler(this.chbComLote_Click);
            // 
            // chbOrdenarEnd
            // 
            this.chbOrdenarEnd.AutoSize = true;
            this.chbOrdenarEnd.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbOrdenarEnd.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbOrdenarEnd.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.chbOrdenarEnd.Limpar = false;
            this.chbOrdenarEnd.Location = new System.Drawing.Point(149, 106);
            this.chbOrdenarEnd.Name = "chbOrdenarEnd";
            this.chbOrdenarEnd.Obrigatorio = false;
            this.chbOrdenarEnd.ObrigatorioMensagem = null;
            this.chbOrdenarEnd.PreValidacaoMensagem = null;
            this.chbOrdenarEnd.PreValidado = false;
            this.chbOrdenarEnd.Size = new System.Drawing.Size(130, 17);
            this.chbOrdenarEnd.TabIndex = 155;
            this.chbOrdenarEnd.Text = "Ordenar Endereço";
            this.chbOrdenarEnd.UseVisualStyleBackColor = true;
            this.chbOrdenarEnd.Click += new System.EventHandler(this.chbOrdenarEnd_Click);
            // 
            // gbMatMed
            // 
            this.gbMatMed.Controls.Add(this.rbTodos);
            this.gbMatMed.Controls.Add(this.rbApenasMateriais);
            this.gbMatMed.Controls.Add(this.rbApenasMedicamentos);
            this.gbMatMed.Controls.Add(this.rbMedSimilar);
            this.gbMatMed.Location = new System.Drawing.Point(294, 52);
            this.gbMatMed.Name = "gbMatMed";
            this.gbMatMed.Size = new System.Drawing.Size(195, 125);
            this.gbMatMed.TabIndex = 135;
            this.gbMatMed.TabStop = false;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbTodos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbTodos.Limpar = true;
            this.rbTodos.Location = new System.Drawing.Point(7, 18);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Obrigatorio = false;
            this.rbTodos.ObrigatorioMensagem = null;
            this.rbTodos.PreValidacaoMensagem = null;
            this.rbTodos.PreValidado = false;
            this.rbTodos.Size = new System.Drawing.Size(63, 17);
            this.rbTodos.TabIndex = 8;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "TODOS";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.Click += new System.EventHandler(this.rbMedSimilar_Click);
            // 
            // rbApenasMateriais
            // 
            this.rbApenasMateriais.AutoSize = true;
            this.rbApenasMateriais.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbApenasMateriais.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbApenasMateriais.Limpar = true;
            this.rbApenasMateriais.Location = new System.Drawing.Point(7, 42);
            this.rbApenasMateriais.Name = "rbApenasMateriais";
            this.rbApenasMateriais.Obrigatorio = false;
            this.rbApenasMateriais.ObrigatorioMensagem = null;
            this.rbApenasMateriais.PreValidacaoMensagem = null;
            this.rbApenasMateriais.PreValidado = false;
            this.rbApenasMateriais.Size = new System.Drawing.Size(129, 17);
            this.rbApenasMateriais.TabIndex = 7;
            this.rbApenasMateriais.Text = "APENAS MATERIAIS";
            this.rbApenasMateriais.UseVisualStyleBackColor = true;
            this.rbApenasMateriais.Click += new System.EventHandler(this.rbMedSimilar_Click);
            // 
            // rbApenasMedicamentos
            // 
            this.rbApenasMedicamentos.AutoSize = true;
            this.rbApenasMedicamentos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbApenasMedicamentos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbApenasMedicamentos.Limpar = true;
            this.rbApenasMedicamentos.Location = new System.Drawing.Point(7, 68);
            this.rbApenasMedicamentos.Name = "rbApenasMedicamentos";
            this.rbApenasMedicamentos.Obrigatorio = false;
            this.rbApenasMedicamentos.ObrigatorioMensagem = null;
            this.rbApenasMedicamentos.PreValidacaoMensagem = null;
            this.rbApenasMedicamentos.PreValidado = false;
            this.rbApenasMedicamentos.Size = new System.Drawing.Size(158, 17);
            this.rbApenasMedicamentos.TabIndex = 6;
            this.rbApenasMedicamentos.Text = "APENAS MEDICAMENTOS";
            this.rbApenasMedicamentos.UseVisualStyleBackColor = true;
            this.rbApenasMedicamentos.Click += new System.EventHandler(this.rbMedSimilar_Click);
            // 
            // rbMedSimilar
            // 
            this.rbMedSimilar.AutoSize = true;
            this.rbMedSimilar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbMedSimilar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbMedSimilar.Limpar = true;
            this.rbMedSimilar.Location = new System.Drawing.Point(7, 95);
            this.rbMedSimilar.Name = "rbMedSimilar";
            this.rbMedSimilar.Obrigatorio = false;
            this.rbMedSimilar.ObrigatorioMensagem = null;
            this.rbMedSimilar.PreValidacaoMensagem = null;
            this.rbMedSimilar.PreValidado = false;
            this.rbMedSimilar.Size = new System.Drawing.Size(187, 17);
            this.rbMedSimilar.TabIndex = 9;
            this.rbMedSimilar.Text = "MEDICAMENTOS C/ SIMILARES";
            this.rbMedSimilar.UseVisualStyleBackColor = true;
            this.rbMedSimilar.Click += new System.EventHandler(this.rbMedSimilar_Click);
            // 
            // chbGrupo
            // 
            this.chbGrupo.AutoSize = true;
            this.chbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.chbGrupo.Limpar = false;
            this.chbGrupo.Location = new System.Drawing.Point(57, 159);
            this.chbGrupo.Name = "chbGrupo";
            this.chbGrupo.Obrigatorio = false;
            this.chbGrupo.ObrigatorioMensagem = null;
            this.chbGrupo.PreValidacaoMensagem = null;
            this.chbGrupo.PreValidado = false;
            this.chbGrupo.Size = new System.Drawing.Size(91, 17);
            this.chbGrupo.TabIndex = 154;
            this.chbGrupo.Text = "Por Grupo";
            this.chbGrupo.UseVisualStyleBackColor = true;
            this.chbGrupo.Visible = false;
            this.chbGrupo.Click += new System.EventHandler(this.chbGrupo_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblGrupo.Location = new System.Drawing.Point(11, 135);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(42, 13);
            this.lblGrupo.TabIndex = 153;
            this.lblGrupo.Text = "Grupo";
            this.lblGrupo.Visible = false;
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.cmbGrupo.DisplayMember = "CAD_MTMD_GRUPO_DESCRICAO";
            this.cmbGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Limpar = true;
            this.cmbGrupo.Location = new System.Drawing.Point(57, 132);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Obrigatorio = false;
            this.cmbGrupo.ObrigatorioMensagem = null;
            this.cmbGrupo.PreValidacaoMensagem = null;
            this.cmbGrupo.PreValidado = false;
            this.cmbGrupo.Size = new System.Drawing.Size(231, 21);
            this.cmbGrupo.TabIndex = 152;
            this.cmbGrupo.Text = "<Selecione>";
            this.cmbGrupo.ValueMember = "CAD_MTMD_GRUPO_ID";
            this.cmbGrupo.Visible = false;
            this.cmbGrupo.SelectionChangeCommitted += new System.EventHandler(this.cmbGrupo_SelectionChangeCommitted);
            // 
            // txtData
            // 
            this.txtData.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtData.BackColor = System.Drawing.Color.Honeydew;
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtData.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Limpar = true;
            this.txtData.Location = new System.Drawing.Point(57, 104);
            this.txtData.MaxLength = 10;
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = true;
            this.txtData.Obrigatorio = false;
            this.txtData.ObrigatorioMensagem = null;
            this.txtData.PreValidacaoMensagem = null;
            this.txtData.PreValidado = false;
            this.txtData.SelectAllOnFocus = false;
            this.txtData.Size = new System.Drawing.Size(80, 20);
            this.txtData.TabIndex = 150;
            this.txtData.TabStop = false;
            this.txtData.Visible = false;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(19, 108);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(34, 13);
            this.lblData.TabIndex = 151;
            this.lblData.Text = "Data";
            this.lblData.Visible = false;
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
            this.cmbSetor.Location = new System.Drawing.Point(57, 75);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(202, 21);
            this.cmbSetor.TabIndex = 3;
            this.cmbSetor.Text = "<Selecione>";
            this.cmbSetor.SelectionChangeCommitted += new System.EventHandler(this.cmbSetor_SelectionChangeCommitted);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbConsig);
            this.groupBox4.Controls.Add(this.rbCE);
            this.groupBox4.Controls.Add(this.rbHac);
            this.groupBox4.Controls.Add(this.rbAcs);
            this.groupBox4.Location = new System.Drawing.Point(332, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 36);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(57, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = "";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 119;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.Click += new System.EventHandler(this.rbEstoque_Click);
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
            this.rbHac.TabIndex = 5;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.Click += new System.EventHandler(this.rbEstoque_Click);
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(155, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 6;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Visible = false;
            this.rbAcs.Click += new System.EventHandler(this.rbEstoque_Click);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(57, 46);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidacaoMensagem = "Local Não Pode Estar em Branco";
            this.cmbLocal.PreValidado = true;
            this.cmbLocal.Size = new System.Drawing.Size(202, 21);
            this.cmbLocal.TabIndex = 2;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(4, 20);
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
            this.cmbUnidade.Location = new System.Drawing.Point(57, 17);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(202, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 1;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(20, 49);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 133;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(18, 78);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(38, 13);
            this.hacLabel4.TabIndex = 134;
            this.hacLabel4.Text = "Setor";
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
            this.tsHac.Size = new System.Drawing.Size(517, 28);
            this.tsHac.TabIndex = 102;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Estoque dos setores para contagem";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            // 
            // rbConsig
            // 
            this.rbConsig.AutoSize = true;
            this.rbConsig.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbConsig.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbConsig.Limpar = true;
            this.rbConsig.Location = new System.Drawing.Point(100, 13);
            this.rbConsig.Name = "rbConsig";
            this.rbConsig.Obrigatorio = false;
            this.rbConsig.ObrigatorioMensagem = "";
            this.rbConsig.PreValidacaoMensagem = null;
            this.rbConsig.PreValidado = false;
            this.rbConsig.Size = new System.Drawing.Size(55, 17);
            this.rbConsig.TabIndex = 120;
            this.rbConsig.TabStop = true;
            this.rbConsig.Text = "CONS";
            this.rbConsig.UseVisualStyleBackColor = true;
            this.rbConsig.Click += new System.EventHandler(this.rbEstoque_Click);
            // 
            // FrmRelEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 226);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmRelEstoque";
            this.Text = "Relatório para Inventário";
            this.Load += new System.EventHandler(this.FrmRelEstoque_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbMatMed.ResumeLayout(false);
            this.gbMatMed.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private HospitalAnaCosta.SGS.Componentes.HacCmbSetor cmbSetor;
        private System.Windows.Forms.GroupBox groupBox4;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbCE;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbHac;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbAcs;
        private HospitalAnaCosta.SGS.Componentes.HacCmbLocal cmbLocal;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel1;
        private HospitalAnaCosta.SGS.Componentes.HacCmbUnidade cmbUnidade;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel2;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel4;
        private HospitalAnaCosta.SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox gbMatMed;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbTodos;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbApenasMateriais;
        private HospitalAnaCosta.SGS.Componentes.HacRadioButton rbApenasMedicamentos;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtData;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblData;
        private HospitalAnaCosta.SGS.Componentes.HacLabel lblGrupo;
        private HospitalAnaCosta.SGS.Componentes.HacComboBox cmbGrupo;
        private HospitalAnaCosta.SGS.Componentes.HacCheckBox chbGrupo;
        private SGS.Componentes.HacRadioButton rbMedSimilar;
        private SGS.Componentes.HacCheckBox chbOrdenarEnd;
        private SGS.Componentes.HacCheckBox chbComLote;
        private SGS.Componentes.HacRadioButton rbConsig;
    }
}