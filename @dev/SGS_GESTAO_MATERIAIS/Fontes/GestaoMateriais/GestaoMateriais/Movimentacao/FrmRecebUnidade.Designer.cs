using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmRecebUnidade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecebUnidade));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDataDisp = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblDataDisp = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtStatus = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtTipo = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtFilial = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtData = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel10 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtSetor = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtLocal = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtUnidade = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtIdRequisicao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuarioDispCabecalho = new System.Windows.Forms.Label();
            this.lblUsuarioReq = new System.Windows.Forms.Label();
            this.lblUsuarioDisp = new System.Windows.Forms.Label();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblEstoqueUnificado = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnReceber = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnDevolver = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.colDevolver = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReqItemIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidadeVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadeMedidaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdCentDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeFornecida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriAtivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiverg = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgMatMed);
            this.groupBox2.Location = new System.Drawing.Point(11, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 297);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itens da Requisição";
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AlterarStatus = true;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDevolver,
            this.colReqItemIdt,
            this.colDsProd,
            this.colMatMedIdt,
            this.colDsUnidadeVenda,
            this.colUnidadeMedidaItem,
            this.colQtde,
            this.colEstoqueLocal,
            this.colQtdePadrao,
            this.colQtdCentDisp,
            this.colQtdeFornecida,
            this.colPriAtivo,
            this.colDiverg});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(9, 25);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = true;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.Size = new System.Drawing.Size(750, 255);
            this.dtgMatMed.TabIndex = 70;
            this.dtgMatMed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellClick);
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            this.dtgMatMed.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgMatMed_CellFormatting);
            this.dtgMatMed.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgMatMed_CellMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDataDisp);
            this.groupBox1.Controls.Add(this.lblDataDisp);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.hacLabel6);
            this.groupBox1.Controls.Add(this.hacLabel5);
            this.groupBox1.Controls.Add(this.txtTipo);
            this.groupBox1.Controls.Add(this.txtFilial);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.hacLabel10);
            this.groupBox1.Controls.Add(this.txtSetor);
            this.groupBox1.Controls.Add(this.txtLocal);
            this.groupBox1.Controls.Add(this.txtUnidade);
            this.groupBox1.Controls.Add(this.txtIdRequisicao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hacLabel1);
            this.groupBox1.Controls.Add(this.hacLabel4);
            this.groupBox1.Controls.Add(this.hacLabel3);
            this.groupBox1.Controls.Add(this.hacLabel2);
            this.groupBox1.Location = new System.Drawing.Point(11, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 119);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requisição";
            // 
            // txtDataDisp
            // 
            this.txtDataDisp.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDataDisp.BackColor = System.Drawing.Color.Honeydew;
            this.txtDataDisp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataDisp.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDataDisp.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDataDisp.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDataDisp.Limpar = true;
            this.txtDataDisp.Location = new System.Drawing.Point(585, 82);
            this.txtDataDisp.MaxLength = 50;
            this.txtDataDisp.Name = "txtDataDisp";
            this.txtDataDisp.NaoAjustarEdicao = true;
            this.txtDataDisp.Obrigatorio = false;
            this.txtDataDisp.ObrigatorioMensagem = "";
            this.txtDataDisp.PreValidacaoMensagem = null;
            this.txtDataDisp.PreValidado = false;
            this.txtDataDisp.SelectAllOnFocus = false;
            this.txtDataDisp.Size = new System.Drawing.Size(165, 21);
            this.txtDataDisp.TabIndex = 128;
            this.txtDataDisp.Visible = false;
            // 
            // lblDataDisp
            // 
            this.lblDataDisp.AutoSize = true;
            this.lblDataDisp.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDataDisp.Location = new System.Drawing.Point(471, 86);
            this.lblDataDisp.Name = "lblDataDisp";
            this.lblDataDisp.Size = new System.Drawing.Size(110, 13);
            this.lblDataDisp.TabIndex = 127;
            this.lblDataDisp.Text = "Data Dispensação";
            this.lblDataDisp.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtStatus.BackColor = System.Drawing.Color.Honeydew;
            this.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatus.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtStatus.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtStatus.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtStatus.Limpar = true;
            this.txtStatus.Location = new System.Drawing.Point(67, 82);
            this.txtStatus.MaxLength = 50;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.NaoAjustarEdicao = true;
            this.txtStatus.Obrigatorio = false;
            this.txtStatus.ObrigatorioMensagem = "";
            this.txtStatus.PreValidacaoMensagem = null;
            this.txtStatus.PreValidado = false;
            this.txtStatus.SelectAllOnFocus = false;
            this.txtStatus.Size = new System.Drawing.Size(390, 21);
            this.txtStatus.TabIndex = 126;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(14, 86);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(43, 13);
            this.hacLabel6.TabIndex = 125;
            this.hacLabel6.Text = "Status";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(256, 26);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(31, 13);
            this.hacLabel5.TabIndex = 124;
            this.hacLabel5.Text = "Tipo";
            // 
            // txtTipo
            // 
            this.txtTipo.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtTipo.BackColor = System.Drawing.Color.Honeydew;
            this.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtTipo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtTipo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTipo.Limpar = true;
            this.txtTipo.Location = new System.Drawing.Point(292, 22);
            this.txtTipo.MaxLength = 50;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.NaoAjustarEdicao = true;
            this.txtTipo.Obrigatorio = false;
            this.txtTipo.ObrigatorioMensagem = "";
            this.txtTipo.PreValidacaoMensagem = null;
            this.txtTipo.PreValidado = false;
            this.txtTipo.SelectAllOnFocus = false;
            this.txtTipo.Size = new System.Drawing.Size(165, 21);
            this.txtTipo.TabIndex = 118;
            // 
            // txtFilial
            // 
            this.txtFilial.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtFilial.BackColor = System.Drawing.Color.Honeydew;
            this.txtFilial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilial.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtFilial.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtFilial.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtFilial.Limpar = true;
            this.txtFilial.Location = new System.Drawing.Point(717, 22);
            this.txtFilial.MaxLength = 50;
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.NaoAjustarEdicao = true;
            this.txtFilial.Obrigatorio = false;
            this.txtFilial.ObrigatorioMensagem = "Digite a filial";
            this.txtFilial.PreValidacaoMensagem = null;
            this.txtFilial.PreValidado = false;
            this.txtFilial.SelectAllOnFocus = false;
            this.txtFilial.Size = new System.Drawing.Size(41, 21);
            this.txtFilial.TabIndex = 123;
            // 
            // txtData
            // 
            this.txtData.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtData.BackColor = System.Drawing.Color.Honeydew;
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtData.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtData.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtData.Limpar = true;
            this.txtData.Location = new System.Drawing.Point(512, 22);
            this.txtData.MaxLength = 50;
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = true;
            this.txtData.Obrigatorio = false;
            this.txtData.ObrigatorioMensagem = "";
            this.txtData.PreValidacaoMensagem = null;
            this.txtData.PreValidado = false;
            this.txtData.SelectAllOnFocus = false;
            this.txtData.Size = new System.Drawing.Size(165, 21);
            this.txtData.TabIndex = 122;
            // 
            // hacLabel10
            // 
            this.hacLabel10.AutoSize = true;
            this.hacLabel10.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel10.Location = new System.Drawing.Point(474, 26);
            this.hacLabel10.Name = "hacLabel10";
            this.hacLabel10.Size = new System.Drawing.Size(34, 13);
            this.hacLabel10.TabIndex = 121;
            this.hacLabel10.Text = "Data";
            // 
            // txtSetor
            // 
            this.txtSetor.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtSetor.BackColor = System.Drawing.Color.Honeydew;
            this.txtSetor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtSetor.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSetor.Limpar = true;
            this.txtSetor.Location = new System.Drawing.Point(512, 52);
            this.txtSetor.MaxLength = 50;
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.NaoAjustarEdicao = true;
            this.txtSetor.Obrigatorio = false;
            this.txtSetor.ObrigatorioMensagem = "";
            this.txtSetor.PreValidacaoMensagem = null;
            this.txtSetor.PreValidado = false;
            this.txtSetor.SelectAllOnFocus = false;
            this.txtSetor.Size = new System.Drawing.Size(165, 21);
            this.txtSetor.TabIndex = 117;
            // 
            // txtLocal
            // 
            this.txtLocal.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtLocal.BackColor = System.Drawing.Color.Honeydew;
            this.txtLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtLocal.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtLocal.Limpar = true;
            this.txtLocal.Location = new System.Drawing.Point(292, 52);
            this.txtLocal.MaxLength = 50;
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.NaoAjustarEdicao = true;
            this.txtLocal.Obrigatorio = false;
            this.txtLocal.ObrigatorioMensagem = "";
            this.txtLocal.PreValidacaoMensagem = null;
            this.txtLocal.PreValidado = false;
            this.txtLocal.SelectAllOnFocus = false;
            this.txtLocal.Size = new System.Drawing.Size(165, 21);
            this.txtLocal.TabIndex = 116;
            // 
            // txtUnidade
            // 
            this.txtUnidade.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidade.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidade.Limpar = true;
            this.txtUnidade.Location = new System.Drawing.Point(67, 52);
            this.txtUnidade.MaxLength = 50;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.NaoAjustarEdicao = true;
            this.txtUnidade.Obrigatorio = false;
            this.txtUnidade.ObrigatorioMensagem = "";
            this.txtUnidade.PreValidacaoMensagem = null;
            this.txtUnidade.PreValidado = false;
            this.txtUnidade.SelectAllOnFocus = false;
            this.txtUnidade.Size = new System.Drawing.Size(165, 21);
            this.txtUnidade.TabIndex = 115;
            // 
            // txtIdRequisicao
            // 
            this.txtIdRequisicao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtIdRequisicao.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdRequisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdRequisicao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdRequisicao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtIdRequisicao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdRequisicao.Limpar = true;
            this.txtIdRequisicao.Location = new System.Drawing.Point(67, 22);
            this.txtIdRequisicao.MaxLength = 13;
            this.txtIdRequisicao.Name = "txtIdRequisicao";
            this.txtIdRequisicao.NaoAjustarEdicao = true;
            this.txtIdRequisicao.Obrigatorio = false;
            this.txtIdRequisicao.ObrigatorioMensagem = null;
            this.txtIdRequisicao.PreValidacaoMensagem = null;
            this.txtIdRequisicao.PreValidado = false;
            this.txtIdRequisicao.SelectAllOnFocus = false;
            this.txtIdRequisicao.Size = new System.Drawing.Size(165, 21);
            this.txtIdRequisicao.TabIndex = 108;
            this.txtIdRequisicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdRequisicao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdRequisicao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Código";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 56);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 103;
            this.hacLabel1.Text = "Unidade";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(682, 26);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(32, 13);
            this.hacLabel4.TabIndex = 106;
            this.hacLabel4.Text = "Filial";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(470, 56);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 105;
            this.hacLabel3.Text = "Setor";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(251, 56);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 104;
            this.hacLabel2.Text = "Local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Usuário Requisição:";
            // 
            // lblUsuarioDispCabecalho
            // 
            this.lblUsuarioDispCabecalho.AutoSize = true;
            this.lblUsuarioDispCabecalho.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUsuarioDispCabecalho.Location = new System.Drawing.Point(8, 27);
            this.lblUsuarioDispCabecalho.Name = "lblUsuarioDispCabecalho";
            this.lblUsuarioDispCabecalho.Size = new System.Drawing.Size(131, 13);
            this.lblUsuarioDispCabecalho.TabIndex = 113;
            this.lblUsuarioDispCabecalho.Text = "Usuário Dispensação:";
            // 
            // lblUsuarioReq
            // 
            this.lblUsuarioReq.AutoSize = true;
            this.lblUsuarioReq.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUsuarioReq.Location = new System.Drawing.Point(137, 7);
            this.lblUsuarioReq.Name = "lblUsuarioReq";
            this.lblUsuarioReq.Size = new System.Drawing.Size(0, 13);
            this.lblUsuarioReq.TabIndex = 114;
            // 
            // lblUsuarioDisp
            // 
            this.lblUsuarioDisp.AutoSize = true;
            this.lblUsuarioDisp.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUsuarioDisp.Location = new System.Drawing.Point(137, 27);
            this.lblUsuarioDisp.Name = "lblUsuarioDisp";
            this.lblUsuarioDisp.Size = new System.Drawing.Size(19, 13);
            this.lblUsuarioDisp.TabIndex = 115;
            this.lblUsuarioDisp.Text = "--";
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUsuario.Controls.Add(this.label2);
            this.pnlUsuario.Controls.Add(this.lblUsuarioDisp);
            this.pnlUsuario.Controls.Add(this.lblUsuarioDispCabecalho);
            this.pnlUsuario.Controls.Add(this.lblUsuarioReq);
            this.pnlUsuario.Location = new System.Drawing.Point(14, 470);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(505, 50);
            this.pnlUsuario.TabIndex = 116;
            this.pnlUsuario.Visible = false;
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = "";
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(790, 28);
            this.tsHac.TabIndex = 109;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Recebimento Pedido Setor";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // lblEstoqueUnificado
            // 
            this.lblEstoqueUnificado.AutoSize = true;
            this.lblEstoqueUnificado.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEstoqueUnificado.ForeColor = System.Drawing.Color.Green;
            this.lblEstoqueUnificado.Location = new System.Drawing.Point(658, 32);
            this.lblEstoqueUnificado.Name = "lblEstoqueUnificado";
            this.lblEstoqueUnificado.Size = new System.Drawing.Size(0, 12);
            this.lblEstoqueUnificado.TabIndex = 163;
            // 
            // btnReceber
            // 
            this.btnReceber.AlterarStatus = false;
            this.btnReceber.BackColor = System.Drawing.Color.White;
            this.btnReceber.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReceber.BackgroundImage")));
            this.btnReceber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceber.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnReceber.Location = new System.Drawing.Point(649, 471);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(121, 22);
            this.btnReceber.TabIndex = 164;
            this.btnReceber.Text = "RECEBER ITENS";
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Visible = false;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.AlterarStatus = false;
            this.btnDevolver.BackColor = System.Drawing.Color.White;
            this.btnDevolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDevolver.BackgroundImage")));
            this.btnDevolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnDevolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolver.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnDevolver.Location = new System.Drawing.Point(649, 499);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(121, 22);
            this.btnDevolver.TabIndex = 165;
            this.btnDevolver.Text = "DEVOLVER ITENS";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Visible = false;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // colDevolver
            // 
            this.colDevolver.HeaderText = "";
            this.colDevolver.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDevolver.Name = "colDevolver";
            this.colDevolver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDevolver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDevolver.ToolTipText = "Devolver Item";
            this.colDevolver.Visible = false;
            this.colDevolver.Width = 40;
            // 
            // colReqItemIdt
            // 
            this.colReqItemIdt.HeaderText = "ReqItemIdt";
            this.colReqItemIdt.Name = "colReqItemIdt";
            this.colReqItemIdt.ReadOnly = true;
            this.colReqItemIdt.Visible = false;
            // 
            // colDsProd
            // 
            this.colDsProd.HeaderText = "Descrição do Material";
            this.colDsProd.Name = "colDsProd";
            this.colDsProd.ReadOnly = true;
            this.colDsProd.Width = 300;
            // 
            // colMatMedIdt
            // 
            this.colMatMedIdt.HeaderText = "colMatMedIdt";
            this.colMatMedIdt.Name = "colMatMedIdt";
            this.colMatMedIdt.Visible = false;
            // 
            // colDsUnidadeVenda
            // 
            this.colDsUnidadeVenda.HeaderText = "Unidade";
            this.colDsUnidadeVenda.Name = "colDsUnidadeVenda";
            this.colDsUnidadeVenda.ReadOnly = true;
            this.colDsUnidadeVenda.Visible = false;
            this.colDsUnidadeVenda.Width = 70;
            // 
            // colUnidadeMedidaItem
            // 
            this.colUnidadeMedidaItem.HeaderText = "Unid.";
            this.colUnidadeMedidaItem.Name = "colUnidadeMedidaItem";
            this.colUnidadeMedidaItem.ReadOnly = true;
            this.colUnidadeMedidaItem.Visible = false;
            this.colUnidadeMedidaItem.Width = 5;
            // 
            // colQtde
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQtde.HeaderText = "Qtd. Solicitada";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 120;
            // 
            // colEstoqueLocal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colEstoqueLocal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEstoqueLocal.HeaderText = "Qtd Local";
            this.colEstoqueLocal.Name = "colEstoqueLocal";
            this.colEstoqueLocal.ReadOnly = true;
            this.colEstoqueLocal.Visible = false;
            this.colEstoqueLocal.Width = 80;
            // 
            // colQtdePadrao
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colQtdePadrao.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQtdePadrao.HeaderText = "Qtd. Padrão";
            this.colQtdePadrao.Name = "colQtdePadrao";
            this.colQtdePadrao.ReadOnly = true;
            this.colQtdePadrao.Visible = false;
            this.colQtdePadrao.Width = 90;
            // 
            // colQtdCentDisp
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.colQtdCentDisp.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQtdCentDisp.HeaderText = "Qtd. Cent. Disp.";
            this.colQtdCentDisp.Name = "colQtdCentDisp";
            this.colQtdCentDisp.ReadOnly = true;
            this.colQtdCentDisp.Visible = false;
            this.colQtdCentDisp.Width = 110;
            // 
            // colQtdeFornecida
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.colQtdeFornecida.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtdeFornecida.HeaderText = "Qtd. Recebida";
            this.colQtdeFornecida.Name = "colQtdeFornecida";
            this.colQtdeFornecida.ReadOnly = true;
            this.colQtdeFornecida.Width = 120;
            // 
            // colPriAtivo
            // 
            this.colPriAtivo.HeaderText = "Pri. Ativo";
            this.colPriAtivo.Name = "colPriAtivo";
            this.colPriAtivo.ReadOnly = true;
            this.colPriAtivo.Visible = false;
            // 
            // colDiverg
            // 
            this.colDiverg.ActiveLinkColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDiverg.DefaultCellStyle = dataGridViewCellStyle7;
            this.colDiverg.HeaderText = "Divergencias";
            this.colDiverg.LinkColor = System.Drawing.Color.Blue;
            this.colDiverg.Name = "colDiverg";
            this.colDiverg.ReadOnly = true;
            this.colDiverg.Text = "DIVERGÊNCIA";
            this.colDiverg.UseColumnTextForLinkValue = true;
            this.colDiverg.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // FrmRecebUnidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 564);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnReceber);
            this.Controls.Add(this.lblEstoqueUnificado);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.ModoTela = HospitalAnaCosta.SGS.Componentes.ModoEdicao.Edicao;
            this.Name = "FrmRecebUnidade";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmLiberacaoAlmox_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private HacDataGridView dtgMatMed;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacLabel hacLabel5;
        private HacTextBox txtTipo;
        private HacTextBox txtFilial;
        private HacTextBox txtData;
        private HacLabel hacLabel10;
        private HacTextBox txtSetor;
        private HacTextBox txtLocal;
        private HacTextBox txtUnidade;
        private HacTextBox txtIdRequisicao;
        private System.Windows.Forms.Label label1;
        private HacLabel hacLabel1;
        private HacLabel hacLabel4;
        private HacLabel hacLabel3;
        private HacLabel hacLabel2;
        private HacToolStrip tsHac;
        private HacTextBox txtStatus;
        private HacLabel hacLabel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuarioDispCabecalho;
        private System.Windows.Forms.Label lblUsuarioReq;
        private System.Windows.Forms.Label lblUsuarioDisp;
        private System.Windows.Forms.Panel pnlUsuario;
        private HacTextBox txtDataDisp;
        private HacLabel lblDataDisp;
        private HacLabel lblEstoqueUnificado;
        private HacButton btnReceber;
        private HacButton btnDevolver;
        private System.Windows.Forms.DataGridViewImageColumn colDevolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqItemIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidadeVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadeMedidaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdePadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdCentDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeFornecida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriAtivo;
        private System.Windows.Forms.DataGridViewLinkColumn colDiverg;
    }
}