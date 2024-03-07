using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmDispensacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDispensacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colReqItemIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV_Disp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidadeVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnidadeMedidaItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdCentDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeFornecida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDssimilar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.tsPendencias = new System.Windows.Forms.ToolStripButton();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlPendentes = new System.Windows.Forms.Panel();
            this.btnCancelar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnDispensar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnFecharPendentes = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblPend = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgItensPendentes = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colDsMatMedPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatMedIdtPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdReqPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdFornPend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdPendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnPendentes = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtReqNum = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.btnImpReqNum = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblEstoqueUnificado = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnKits = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.tsHac.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlPendentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensPendentes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AlterarStatus = true;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReqItemIdt,
            this.colDeletar,
            this.colDsProd,
            this.colMAV_Disp,
            this.colMatMedIdt,
            this.colDsUnidadeVenda,
            this.colUnidadeMedidaItem,
            this.colQtde,
            this.colEstoqueLocal,
            this.colQtdePadrao,
            this.colQtdCentDisp,
            this.colQtdeFornecida,
            this.colDssimilar});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle24;
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(9, 51);
            this.dtgMatMed.MultiSelect = false;
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.ReadOnly = true;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dtgMatMed.RowHeadersVisible = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgMatMed.RowsDefaultCellStyle = dataGridViewCellStyle26;
            this.dtgMatMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMatMed.Size = new System.Drawing.Size(750, 329);
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
            this.colDsProd.Width = 240;
            // 
            // colMAV_Disp
            // 
            this.colMAV_Disp.FalseValue = "N";
            this.colMAV_Disp.HeaderText = "MAR";
            this.colMAV_Disp.Name = "colMAV_Disp";
            this.colMAV_Disp.ReadOnly = true;
            this.colMAV_Disp.TrueValue = "S";
            this.colMAV_Disp.Width = 35;
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
            this.colDsUnidadeVenda.Width = 80;
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            dataGridViewCellStyle19.NullValue = null;
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle19;
            this.colQtde.HeaderText = "Qtd. Req.";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 65;
            // 
            // colEstoqueLocal
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N0";
            dataGridViewCellStyle20.NullValue = null;
            this.colEstoqueLocal.DefaultCellStyle = dataGridViewCellStyle20;
            this.colEstoqueLocal.HeaderText = "Qtd Local";
            this.colEstoqueLocal.Name = "colEstoqueLocal";
            this.colEstoqueLocal.ReadOnly = true;
            this.colEstoqueLocal.Visible = false;
            this.colEstoqueLocal.Width = 80;
            // 
            // colQtdePadrao
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            this.colQtdePadrao.DefaultCellStyle = dataGridViewCellStyle21;
            this.colQtdePadrao.HeaderText = "Qtd. Padrão";
            this.colQtdePadrao.Name = "colQtdePadrao";
            this.colQtdePadrao.ReadOnly = true;
            this.colQtdePadrao.Visible = false;
            this.colQtdePadrao.Width = 88;
            // 
            // colQtdCentDisp
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N0";
            this.colQtdCentDisp.DefaultCellStyle = dataGridViewCellStyle22;
            this.colQtdCentDisp.HeaderText = "Qtd. Cent. Disp.";
            this.colQtdCentDisp.Name = "colQtdCentDisp";
            this.colQtdCentDisp.ReadOnly = true;
            this.colQtdCentDisp.Visible = false;
            this.colQtdCentDisp.Width = 110;
            // 
            // colQtdeFornecida
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.Format = "N0";
            dataGridViewCellStyle23.NullValue = null;
            this.colQtdeFornecida.DefaultCellStyle = dataGridViewCellStyle23;
            this.colQtdeFornecida.HeaderText = "Qtd. Forn.";
            this.colQtdeFornecida.Name = "colQtdeFornecida";
            this.colQtdeFornecida.ReadOnly = true;
            this.colQtdeFornecida.Width = 65;
            // 
            // colDssimilar
            // 
            this.colDssimilar.HeaderText = "Similar";
            this.colDssimilar.Name = "colDssimilar";
            this.colDssimilar.ReadOnly = true;
            this.colDssimilar.Width = 205;
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPendencias});
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = "";
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 71;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Dispensação";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // tsPendencias
            // 
            this.tsPendencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsPendencias.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsPendencias.Image = ((System.Drawing.Image)(resources.GetObject("tsPendencias.Image")));
            this.tsPendencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPendencias.Name = "tsPendencias";
            this.tsPendencias.Size = new System.Drawing.Size(148, 25);
            this.tsPendencias.Text = "Pedidos Pendentes Disp.";
            this.tsPendencias.ToolTipText = "Pedidos Pendentes na Dispensação";
            this.tsPendencias.Click += new System.EventHandler(this.tsPendencias_Click);
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
            this.groupBox1.Controls.Add(this.btnKits);
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
            this.txtUnidade.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
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
            this.txtIdRequisicao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtIdRequisicao.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdRequisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdRequisicao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdRequisicao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
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
            this.groupBox2.Controls.Add(this.pnlPendentes);
            this.groupBox2.Controls.Add(this.txtIdProduto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtgMatMed);
            this.groupBox2.Controls.Add(this.btnPendentes);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 390);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itens da Requisição";
            // 
            // pnlPendentes
            // 
            this.pnlPendentes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendentes.Controls.Add(this.btnCancelar);
            this.pnlPendentes.Controls.Add(this.btnDispensar);
            this.pnlPendentes.Controls.Add(this.btnFecharPendentes);
            this.pnlPendentes.Controls.Add(this.lblPend);
            this.pnlPendentes.Controls.Add(this.dtgItensPendentes);
            this.pnlPendentes.Location = new System.Drawing.Point(9, 19);
            this.pnlPendentes.Name = "pnlPendentes";
            this.pnlPendentes.Size = new System.Drawing.Size(750, 361);
            this.pnlPendentes.TabIndex = 111;
            this.pnlPendentes.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AlterarStatus = false;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(358, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 22);
            this.btnCancelar.TabIndex = 112;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDispensar
            // 
            this.btnDispensar.AlterarStatus = false;
            this.btnDispensar.BackColor = System.Drawing.Color.White;
            this.btnDispensar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDispensar.BackgroundImage")));
            this.btnDispensar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispensar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnDispensar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispensar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnDispensar.Location = new System.Drawing.Point(257, 6);
            this.btnDispensar.Name = "btnDispensar";
            this.btnDispensar.Size = new System.Drawing.Size(95, 22);
            this.btnDispensar.TabIndex = 111;
            this.btnDispensar.Text = "DISPENSAR";
            this.btnDispensar.UseVisualStyleBackColor = true;
            this.btnDispensar.Click += new System.EventHandler(this.btnDispensar_Click);
            // 
            // btnFecharPendentes
            // 
            this.btnFecharPendentes.AlterarStatus = false;
            this.btnFecharPendentes.BackColor = System.Drawing.Color.White;
            this.btnFecharPendentes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFecharPendentes.BackgroundImage")));
            this.btnFecharPendentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharPendentes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnFecharPendentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharPendentes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnFecharPendentes.Location = new System.Drawing.Point(724, 2);
            this.btnFecharPendentes.Name = "btnFecharPendentes";
            this.btnFecharPendentes.Size = new System.Drawing.Size(22, 22);
            this.btnFecharPendentes.TabIndex = 110;
            this.btnFecharPendentes.Text = "X";
            this.btnFecharPendentes.UseVisualStyleBackColor = true;
            this.btnFecharPendentes.Click += new System.EventHandler(this.btnOkPendentes_Click);
            // 
            // lblPend
            // 
            this.lblPend.AutoSize = true;
            this.lblPend.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPend.ForeColor = System.Drawing.Color.Red;
            this.lblPend.Location = new System.Drawing.Point(6, 6);
            this.lblPend.Name = "lblPend";
            this.lblPend.Size = new System.Drawing.Size(225, 22);
            this.lblPend.TabIndex = 72;
            this.lblPend.Text = "P  E  N  D  E  N  T  E  S";
            // 
            // dtgItensPendentes
            // 
            this.dtgItensPendentes.AllowUserToAddRows = false;
            this.dtgItensPendentes.AlterarStatus = true;
            this.dtgItensPendentes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItensPendentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dtgItensPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItensPendentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDsMatMedPend,
            this.colMAV,
            this.colMatMedIdtPend,
            this.colQtdReqPend,
            this.colQtdFornPend,
            this.colQtdPendente});
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItensPendentes.DefaultCellStyle = dataGridViewCellStyle32;
            this.dtgItensPendentes.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgItensPendentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItensPendentes.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgItensPendentes.GridPesquisa = false;
            this.dtgItensPendentes.Limpar = true;
            this.dtgItensPendentes.Location = new System.Drawing.Point(8, 34);
            this.dtgItensPendentes.MultiSelect = false;
            this.dtgItensPendentes.Name = "dtgItensPendentes";
            this.dtgItensPendentes.NaoAjustarEdicao = false;
            this.dtgItensPendentes.Obrigatorio = false;
            this.dtgItensPendentes.ObrigatorioMensagem = null;
            this.dtgItensPendentes.PreValidacaoMensagem = null;
            this.dtgItensPendentes.PreValidado = false;
            this.dtgItensPendentes.ReadOnly = true;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItensPendentes.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dtgItensPendentes.RowHeadersVisible = false;
            this.dtgItensPendentes.RowHeadersWidth = 25;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgItensPendentes.RowsDefaultCellStyle = dataGridViewCellStyle34;
            this.dtgItensPendentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItensPendentes.Size = new System.Drawing.Size(732, 315);
            this.dtgItensPendentes.TabIndex = 71;
            this.dtgItensPendentes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgItensPendentes_CellFormatting);
            // 
            // colDsMatMedPend
            // 
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDsMatMedPend.DefaultCellStyle = dataGridViewCellStyle28;
            this.colDsMatMedPend.HeaderText = "Descrição do Material";
            this.colDsMatMedPend.Name = "colDsMatMedPend";
            this.colDsMatMedPend.ReadOnly = true;
            this.colDsMatMedPend.Width = 300;
            // 
            // colMAV
            // 
            this.colMAV.FalseValue = "N";
            this.colMAV.HeaderText = "MAR";
            this.colMAV.Name = "colMAV";
            this.colMAV.ReadOnly = true;
            this.colMAV.TrueValue = "S";
            this.colMAV.Width = 35;
            // 
            // colMatMedIdtPend
            // 
            this.colMatMedIdtPend.HeaderText = "colMatMedIdtPend";
            this.colMatMedIdtPend.Name = "colMatMedIdtPend";
            this.colMatMedIdtPend.ReadOnly = true;
            this.colMatMedIdtPend.Visible = false;
            // 
            // colQtdReqPend
            // 
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.Format = "N0";
            dataGridViewCellStyle29.NullValue = null;
            this.colQtdReqPend.DefaultCellStyle = dataGridViewCellStyle29;
            this.colQtdReqPend.HeaderText = "Qtd. Req.";
            this.colQtdReqPend.Name = "colQtdReqPend";
            this.colQtdReqPend.ReadOnly = true;
            this.colQtdReqPend.Width = 80;
            // 
            // colQtdFornPend
            // 
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.Format = "N0";
            dataGridViewCellStyle30.NullValue = null;
            this.colQtdFornPend.DefaultCellStyle = dataGridViewCellStyle30;
            this.colQtdFornPend.HeaderText = "Qtd. Forn.";
            this.colQtdFornPend.Name = "colQtdFornPend";
            this.colQtdFornPend.ReadOnly = true;
            this.colQtdFornPend.Width = 80;
            // 
            // colQtdPendente
            // 
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.Format = "N0";
            this.colQtdPendente.DefaultCellStyle = dataGridViewCellStyle31;
            this.colQtdPendente.HeaderText = "Qtd. Pendente";
            this.colQtdPendente.Name = "colQtdPendente";
            this.colQtdPendente.ReadOnly = true;
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtIdProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtIdProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
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
            // btnPendentes
            // 
            this.btnPendentes.AlterarStatus = false;
            this.btnPendentes.BackColor = System.Drawing.Color.White;
            this.btnPendentes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPendentes.BackgroundImage")));
            this.btnPendentes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPendentes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPendentes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendentes.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPendentes.Location = new System.Drawing.Point(669, 21);
            this.btnPendentes.Name = "btnPendentes";
            this.btnPendentes.Size = new System.Drawing.Size(88, 22);
            this.btnPendentes.TabIndex = 111;
            this.btnPendentes.Text = "PENDENTES";
            this.btnPendentes.UseVisualStyleBackColor = true;
            this.btnPendentes.Visible = false;
            this.btnPendentes.Click += new System.EventHandler(this.btnPendentes_Click);
            // 
            // txtReqNum
            // 
            this.txtReqNum.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtReqNum.BackColor = System.Drawing.Color.Honeydew;
            this.txtReqNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReqNum.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtReqNum.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtReqNum.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtReqNum.Limpar = true;
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
            // lblEstoqueUnificado
            // 
            this.lblEstoqueUnificado.AutoSize = true;
            this.lblEstoqueUnificado.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEstoqueUnificado.ForeColor = System.Drawing.Color.Green;
            this.lblEstoqueUnificado.Location = new System.Drawing.Point(308, 38);
            this.lblEstoqueUnificado.Name = "lblEstoqueUnificado";
            this.lblEstoqueUnificado.Size = new System.Drawing.Size(0, 12);
            this.lblEstoqueUnificado.TabIndex = 162;
            // 
            // btnKits
            // 
            this.btnKits.AlterarStatus = false;
            this.btnKits.BackColor = System.Drawing.Color.White;
            this.btnKits.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKits.BackgroundImage")));
            this.btnKits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKits.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnKits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKits.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnKits.Location = new System.Drawing.Point(710, 52);
            this.btnKits.Name = "btnKits";
            this.btnKits.Size = new System.Drawing.Size(50, 22);
            this.btnKits.TabIndex = 125;
            this.btnKits.Text = "KITS";
            this.btnKits.UseVisualStyleBackColor = true;
            this.btnKits.Visible = false;
            this.btnKits.Click += new System.EventHandler(this.btnKits_Click);
            // 
            // FrmDispensacao
            // 
            this.ClientSize = new System.Drawing.Size(792, 548);
            this.Controls.Add(this.lblEstoqueUnificado);
            this.Controls.Add(this.txtReqNum);
            this.Controls.Add(this.btnImpReqNum);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmDispensacao";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDispensacao_FormClosing);
            this.Load += new System.EventHandler(this.FrmLiberacaoAlmox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.tsHac.ResumeLayout(false);
            this.tsHac.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlPendentes.ResumeLayout(false);
            this.pnlPendentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensPendentes)).EndInit();
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
        private HacButton btnPendentes;
        private System.Windows.Forms.Panel pnlPendentes;
        private HacDataGridView dtgItensPendentes;
        private HacButton btnFecharPendentes;
        private HacLabel lblPend;
        private HacButton btnCancelar;
        private HacButton btnDispensar;
        private HacLabel lblEstoqueUnificado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsMatMedPend;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdtPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdReqPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdFornPend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdPendente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqItemIdt;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV_Disp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidadeVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidadeMedidaItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdePadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdCentDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeFornecida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDssimilar;
        private System.Windows.Forms.ToolStripButton tsPendencias;
        private HacButton btnKits;
    }
}
