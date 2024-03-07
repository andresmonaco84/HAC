using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmLiberacaoAlmox_old
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLiberacaoAlmox_old));
            this.dtgMatMed = new HacDataGridView(this.components);
            this.colReqItemIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidadeVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadeMedidaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdCentDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeFornecida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsHac = new HacToolStrip(this.components);
            this.hacLabel1 = new HacLabel(this.components);
            this.hacLabel2 = new HacLabel(this.components);
            this.hacLabel3 = new HacLabel(this.components);
            this.hacLabel4 = new HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hacLabel5 = new HacLabel(this.components);
            this.txtTipo = new HacTextBox(this.components);
            this.txtFilial = new HacTextBox(this.components);
            this.txtData = new HacTextBox(this.components);
            this.hacLabel10 = new HacLabel(this.components);
            this.txtSetor = new HacTextBox(this.components);
            this.txtLocal = new HacTextBox(this.components);
            this.txtUnidade = new HacTextBox(this.components);
            this.txtIdRequisicao = new HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIdProduto = new HacTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtReqNum = new HacTextBox(this.components);
            this.btnImpReqNum = new HacButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.colReqItemIdt,
            this.colDeletar,
            this.colDsProd,
            this.colMatMedIdt,
            this.colDsUnidadeVenda,
            this.colUnidadeMedidaItem,
            this.colQtde,
            this.colEstoqueLocal,
            this.colQtdePadrao,
            this.colQtdCentDisp,
            this.colQtdeFornecida});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgMatMed.Editavel = ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(9, 51);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(750, 347);
            this.dtgMatMed.TabIndex = 70;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            // 
            // colReqItemIdt
            // 
            this.colReqItemIdt.HeaderText = "ReqItemIdt";
            this.colReqItemIdt.Name = "colReqItemIdt";
            this.colReqItemIdt.ReadOnly = true;
            this.colReqItemIdt.Visible = false;
            // 
            // colDeletar
            // 
            this.colDeletar.HeaderText = "Excluir";
            this.colDeletar.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.ReadOnly = true;
            this.colDeletar.ToolTipText = "Excluir Linha";
            this.colDeletar.Width = 42;
            // 
            // colDsProd
            // 
            this.colDsProd.HeaderText = "Descrição do Material";
            this.colDsProd.Name = "colDsProd";
            this.colDsProd.ReadOnly = true;
            this.colDsProd.Width = 178;
            // 
            // colMatMedIdt
            // 
            this.colMatMedIdt.HeaderText = "colMatMedIdt";
            this.colMatMedIdt.Name = "colMatMedIdt";
            this.colMatMedIdt.ReadOnly = true;
            this.colMatMedIdt.Visible = false;
            // 
            // colDsUnidadeVenda
            // 
            this.colDsUnidadeVenda.HeaderText = "Unidade";
            this.colDsUnidadeVenda.Name = "colDsUnidadeVenda";
            this.colDsUnidadeVenda.ReadOnly = true;
            this.colDsUnidadeVenda.Width = 65;
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
            this.colQtde.HeaderText = "Qtd. Requis.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 90;
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
            this.colQtdePadrao.Width = 88;
            // 
            // colQtdCentDisp
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.colQtdCentDisp.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQtdCentDisp.HeaderText = "Qtd. Cent. Disp.";
            this.colQtdCentDisp.Name = "colQtdCentDisp";
            this.colQtdCentDisp.ReadOnly = true;
            this.colQtdCentDisp.Width = 110;
            // 
            // colQtdeFornecida
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.colQtdeFornecida.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtdeFornecida.HeaderText = "Qtd. Forn.";
            this.colQtdeFornecida.Name = "colQtdeFornecida";
            this.colQtdeFornecida.ReadOnly = true;
            this.colQtdeFornecida.Width = 77;
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = "";
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 71;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Dispensação";
            this.tsHac.CancelarClick += new ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.NovoClick += new ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.SalvarClick += new ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(8, 56);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 103;
            this.hacLabel1.Text = "Unidade";
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
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 92);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requisição";
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
            this.txtTipo.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtTipo.BackColor = System.Drawing.Color.White;
            this.txtTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipo.Editavel = ControleEdicao.Nunca;
            this.txtTipo.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtTipo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTipo.Limpar = true;
            this.txtTipo.Location = new System.Drawing.Point(292, 22);
            this.txtTipo.MaxLength = 50;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.NaoAjustarEdicao = false;
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
            this.txtFilial.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtFilial.BackColor = System.Drawing.Color.White;
            this.txtFilial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilial.Editavel = ControleEdicao.Nunca;
            this.txtFilial.EstadoInicial = EstadoObjeto.Desabilitado;
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
            this.txtData.AcceptedFormat = AcceptedFormat.Data;
            this.txtData.BackColor = System.Drawing.Color.White;
            this.txtData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData.Editavel = ControleEdicao.Nunca;
            this.txtData.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtData.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtData.Limpar = true;
            this.txtData.Location = new System.Drawing.Point(512, 22);
            this.txtData.MaxLength = 50;
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = false;
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
            this.txtSetor.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtSetor.BackColor = System.Drawing.Color.White;
            this.txtSetor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSetor.Editavel = ControleEdicao.Nunca;
            this.txtSetor.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtSetor.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSetor.Limpar = true;
            this.txtSetor.Location = new System.Drawing.Point(512, 52);
            this.txtSetor.MaxLength = 50;
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.NaoAjustarEdicao = false;
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
            this.txtLocal.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtLocal.BackColor = System.Drawing.Color.White;
            this.txtLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocal.Editavel = ControleEdicao.Nunca;
            this.txtLocal.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtLocal.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtLocal.Limpar = true;
            this.txtLocal.Location = new System.Drawing.Point(292, 52);
            this.txtLocal.MaxLength = 50;
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.NaoAjustarEdicao = false;
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
            this.txtUnidade.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtUnidade.BackColor = System.Drawing.Color.White;
            this.txtUnidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidade.Editavel = ControleEdicao.Nunca;
            this.txtUnidade.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtUnidade.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidade.Limpar = true;
            this.txtUnidade.Location = new System.Drawing.Point(69, 52);
            this.txtUnidade.MaxLength = 50;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.NaoAjustarEdicao = false;
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
            this.txtIdRequisicao.AcceptedFormat = AcceptedFormat.Numerico;
            this.txtIdRequisicao.BackColor = System.Drawing.Color.White;
            this.txtIdRequisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdRequisicao.Editavel = ControleEdicao.Sempre;
            this.txtIdRequisicao.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtIdRequisicao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdRequisicao.Limpar = true;
            this.txtIdRequisicao.Location = new System.Drawing.Point(69, 22);
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
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Código";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIdProduto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtgMatMed);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 404);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itens da Requisição";
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtIdProduto.BackColor = System.Drawing.Color.White;
            this.txtIdProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProduto.Editavel = ControleEdicao.Nunca;
            this.txtIdProduto.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtIdProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdProduto.Limpar = true;
            this.txtIdProduto.Location = new System.Drawing.Point(114, 21);
            this.txtIdProduto.MaxLength = 50;
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = false;
            this.txtIdProduto.ObrigatorioMensagem = null;
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(178, 21);
            this.txtIdProduto.TabIndex = 110;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdProduto_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Código de Barra";
            // 
            // txtReqNum
            // 
            this.txtReqNum.AcceptedFormat = AcceptedFormat.Numerico;
            this.txtReqNum.BackColor = System.Drawing.Color.Honeydew;
            this.txtReqNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReqNum.Editavel = ControleEdicao.Sempre;
            this.txtReqNum.EstadoInicial = EstadoObjeto.Habilitado;
            this.txtReqNum.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtReqNum.Limpar = false;
            this.txtReqNum.Location = new System.Drawing.Point(701, 33);
            this.txtReqNum.MaxLength = 9;
            this.txtReqNum.Name = "txtReqNum";
            this.txtReqNum.NaoAjustarEdicao = true;
            this.txtReqNum.Obrigatorio = false;
            this.txtReqNum.ObrigatorioMensagem = "";
            this.txtReqNum.PreValidacaoMensagem = null;
            this.txtReqNum.PreValidado = false;
            this.txtReqNum.SelectAllOnFocus = false;
            this.txtReqNum.Size = new System.Drawing.Size(79, 21);
            this.txtReqNum.TabIndex = 110;
            this.txtReqNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnImpReqNum
            // 
            this.btnImpReqNum.AlterarStatus = false;
            this.btnImpReqNum.BackColor = System.Drawing.Color.White;
            this.btnImpReqNum.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpReqNum.BackgroundImage")));
            this.btnImpReqNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImpReqNum.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnImpReqNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImpReqNum.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnImpReqNum.Location = new System.Drawing.Point(546, 32);
            this.btnImpReqNum.Name = "btnImpReqNum";
            this.btnImpReqNum.Size = new System.Drawing.Size(149, 22);
            this.btnImpReqNum.TabIndex = 109;
            this.btnImpReqNum.Text = "IMPRIMIR PEDIDO N°";
            this.btnImpReqNum.UseVisualStyleBackColor = true;
            this.btnImpReqNum.Click += new System.EventHandler(this.btnImpReqNum_Click);
            // 
            // FrmLiberacaoAlmox
            // 
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.txtReqNum);
            this.Controls.Add(this.btnImpReqNum);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmLiberacaoAlmox";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmLiberacaoAlmox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgMatMed;
        private HacToolStrip tsHac;
        private HacLabel hacLabel1;
        private HacLabel hacLabel2;
        private HacLabel hacLabel3;
        private HacLabel hacLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacTextBox txtIdRequisicao;
        private System.Windows.Forms.Label label1;
        private HacTextBox txtSetor;
        private HacTextBox txtLocal;
        private HacTextBox txtUnidade;
        private HacTextBox txtFilial;
        private HacTextBox txtData;
        private HacLabel hacLabel10;
        private System.Windows.Forms.GroupBox groupBox2;
        private HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label2;
        private HacLabel hacLabel5;
        private HacTextBox txtTipo;
        private HacTextBox txtReqNum;
        private HacButton btnImpReqNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqItemIdt;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidadeVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadeMedidaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdePadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdCentDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeFornecida;
    }
}
