using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmMovimentacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMovimentacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.hacToolStrip1 = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.colIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsTpMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSubTpMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgMovimento = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colIdtMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTipoMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoMovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtdAteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReqId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuEstorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtTpMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtSubMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlEstorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnPesquisar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtDtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblProduto = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chkMostraMov = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblSaldo = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblTotalSaidas = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblTotalEntrada = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimento)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.hacToolStrip1.Size = new System.Drawing.Size(771, 28);
            this.hacToolStrip1.TabIndex = 1;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = "Movimentação Material Medicamentos";
            // 
            // colIdt
            // 
            this.colIdt.HeaderText = "ID";
            this.colIdt.Name = "colIdt";
            this.colIdt.ReadOnly = true;
            this.colIdt.Visible = false;
            this.colIdt.Width = 50;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 80;
            // 
            // ColAtendimento
            // 
            this.ColAtendimento.HeaderText = "Atendimento";
            this.ColAtendimento.Name = "ColAtendimento";
            this.ColAtendimento.ReadOnly = true;
            this.ColAtendimento.Width = 70;
            // 
            // colIdtReq
            // 
            this.colIdtReq.HeaderText = "Requisição";
            this.colIdtReq.Name = "colIdtReq";
            this.colIdtReq.ReadOnly = true;
            this.colIdtReq.Width = 70;
            // 
            // colDsTpMov
            // 
            this.colDsTpMov.HeaderText = "Movimento";
            this.colDsTpMov.Name = "colDsTpMov";
            this.colDsTpMov.ReadOnly = true;
            this.colDsTpMov.Width = 80;
            // 
            // colDsSubTpMov
            // 
            this.colDsSubTpMov.HeaderText = "Sub. Tipo";
            this.colDsSubTpMov.Name = "colDsSubTpMov";
            this.colDsSubTpMov.ReadOnly = true;
            this.colDsSubTpMov.Width = 200;
            // 
            // colQtde
            // 
            this.colQtde.HeaderText = "Qtde";
            this.colQtde.Name = "colQtde";
            this.colQtde.ReadOnly = true;
            this.colQtde.Width = 50;
            // 
            // colOperador
            // 
            this.colOperador.HeaderText = "Operador";
            this.colOperador.Name = "colOperador";
            this.colOperador.ReadOnly = true;
            this.colOperador.Width = 130;
            // 
            // dtgMovimento
            // 
            this.dtgMovimento.AllowUserToAddRows = false;
            this.dtgMovimento.AllowUserToDeleteRows = false;
            this.dtgMovimento.AllowUserToResizeColumns = false;
            this.dtgMovimento.AllowUserToResizeRows = false;
            this.dtgMovimento.AlterarStatus = false;
            this.dtgMovimento.BackgroundColor = System.Drawing.Color.White;
            this.dtgMovimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMovimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtMov,
            this.colDtMov,
            this.colSubTipoMov,
            this.colEntrada,
            this.colSaida,
            this.colSaldoMovimento,
            this.colAtdAteId,
            this.colReqId,
            this.colCodLote,
            this.colUsuario,
            this.colUsuEstorno,
            this.colIdtTpMov,
            this.colIdtSubMov,
            this.colFlEstorno});
            this.dtgMovimento.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.dtgMovimento.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMovimento.GridPesquisa = false;
            this.dtgMovimento.Limpar = false;
            this.dtgMovimento.Location = new System.Drawing.Point(5, 91);
            this.dtgMovimento.Name = "dtgMovimento";
            this.dtgMovimento.NaoAjustarEdicao = false;
            this.dtgMovimento.Obrigatorio = false;
            this.dtgMovimento.ObrigatorioMensagem = null;
            this.dtgMovimento.PreValidacaoMensagem = null;
            this.dtgMovimento.PreValidado = false;
            this.dtgMovimento.RowHeadersVisible = false;
            this.dtgMovimento.RowHeadersWidth = 18;
            this.dtgMovimento.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgMovimento.RowTemplate.Height = 18;
            this.dtgMovimento.Size = new System.Drawing.Size(754, 368);
            this.dtgMovimento.TabIndex = 2;
            this.dtgMovimento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgMovimento_CellFormatting);
            this.dtgMovimento.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgMovimento_RowPostPaint);
            // 
            // colIdtMov
            // 
            this.colIdtMov.HeaderText = "ID";
            this.colIdtMov.Name = "colIdtMov";
            this.colIdtMov.ReadOnly = true;
            this.colIdtMov.Visible = false;
            this.colIdtMov.Width = 70;
            // 
            // colDtMov
            // 
            dataGridViewCellStyle1.Format = "DD/MM/YYYY hh:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.colDtMov.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDtMov.HeaderText = "Data";
            this.colDtMov.Name = "colDtMov";
            this.colDtMov.ReadOnly = true;
            this.colDtMov.Width = 115;
            // 
            // colSubTipoMov
            // 
            this.colSubTipoMov.HeaderText = "Descrição";
            this.colSubTipoMov.Name = "colSubTipoMov";
            this.colSubTipoMov.ReadOnly = true;
            this.colSubTipoMov.Width = 410;
            // 
            // colEntrada
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colEntrada.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEntrada.HeaderText = "Entrada";
            this.colEntrada.Name = "colEntrada";
            this.colEntrada.ReadOnly = true;
            this.colEntrada.Width = 50;
            // 
            // colSaida
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colSaida.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSaida.HeaderText = "Saida";
            this.colSaida.Name = "colSaida";
            this.colSaida.ReadOnly = true;
            this.colSaida.Width = 50;
            // 
            // colSaldoMovimento
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colSaldoMovimento.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSaldoMovimento.HeaderText = "Saldo";
            this.colSaldoMovimento.Name = "colSaldoMovimento";
            this.colSaldoMovimento.ReadOnly = true;
            this.colSaldoMovimento.Width = 50;
            // 
            // colAtdAteId
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colAtdAteId.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAtdAteId.HeaderText = "Atendimento";
            this.colAtdAteId.Name = "colAtdAteId";
            this.colAtdAteId.ReadOnly = true;
            this.colAtdAteId.Width = 70;
            // 
            // colReqId
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colReqId.DefaultCellStyle = dataGridViewCellStyle6;
            this.colReqId.HeaderText = "Pedido";
            this.colReqId.Name = "colReqId";
            this.colReqId.ReadOnly = true;
            this.colReqId.Width = 55;
            // 
            // colCodLote
            // 
            this.colCodLote.HeaderText = "Cd. Lote";
            this.colCodLote.Name = "colCodLote";
            this.colCodLote.ReadOnly = true;
            this.colCodLote.Width = 70;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuário";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            this.colUsuario.Width = 200;
            // 
            // colUsuEstorno
            // 
            this.colUsuEstorno.HeaderText = "Usu.Estor.";
            this.colUsuEstorno.Name = "colUsuEstorno";
            this.colUsuEstorno.ReadOnly = true;
            this.colUsuEstorno.Visible = false;
            // 
            // colIdtTpMov
            // 
            this.colIdtTpMov.HeaderText = "TP";
            this.colIdtTpMov.Name = "colIdtTpMov";
            this.colIdtTpMov.ReadOnly = true;
            this.colIdtTpMov.Visible = false;
            this.colIdtTpMov.Width = 50;
            // 
            // colIdtSubMov
            // 
            this.colIdtSubMov.HeaderText = "SUB";
            this.colIdtSubMov.Name = "colIdtSubMov";
            this.colIdtSubMov.ReadOnly = true;
            this.colIdtSubMov.Visible = false;
            this.colIdtSubMov.Width = 50;
            // 
            // colFlEstorno
            // 
            this.colFlEstorno.HeaderText = "Est.";
            this.colFlEstorno.Name = "colFlEstorno";
            this.colFlEstorno.ReadOnly = true;
            this.colFlEstorno.Visible = false;
            this.colFlEstorno.Width = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLote);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Controls.Add(this.txtDtFim);
            this.panel1.Controls.Add(this.hacLabel2);
            this.panel1.Controls.Add(this.txtDtInicio);
            this.panel1.Controls.Add(this.hacLabel1);
            this.panel1.Controls.Add(this.lblProduto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 59);
            this.panel1.TabIndex = 3;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Verdana", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblLote.Location = new System.Drawing.Point(8, 36);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(0, 16);
            this.lblLote.TabIndex = 142;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.AlterarStatus = true;
            this.btnPesquisar.BackColor = System.Drawing.Color.White;
            this.btnPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.BackgroundImage")));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(696, 32);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(70, 22);
            this.btnPesquisar.TabIndex = 141;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtDtFim
            // 
            this.txtDtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtFim.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtFim.Limpar = false;
            this.txtDtFim.Location = new System.Drawing.Point(611, 33);
            this.txtDtFim.MaxLength = 10;
            this.txtDtFim.Name = "txtDtFim";
            this.txtDtFim.NaoAjustarEdicao = false;
            this.txtDtFim.Obrigatorio = false;
            this.txtDtFim.ObrigatorioMensagem = "";
            this.txtDtFim.PreValidacaoMensagem = "";
            this.txtDtFim.PreValidado = false;
            this.txtDtFim.SelectAllOnFocus = false;
            this.txtDtFim.Size = new System.Drawing.Size(80, 21);
            this.txtDtFim.TabIndex = 140;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(581, 39);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(31, 13);
            this.hacLabel2.TabIndex = 139;
            this.hacLabel2.Text = "Até:";
            // 
            // txtDtInicio
            // 
            this.txtDtInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.NovoRegistro;
            this.txtDtInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtInicio.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtInicio.Limpar = false;
            this.txtDtInicio.Location = new System.Drawing.Point(499, 34);
            this.txtDtInicio.MaxLength = 10;
            this.txtDtInicio.Name = "txtDtInicio";
            this.txtDtInicio.NaoAjustarEdicao = false;
            this.txtDtInicio.Obrigatorio = false;
            this.txtDtInicio.ObrigatorioMensagem = "";
            this.txtDtInicio.PreValidacaoMensagem = "";
            this.txtDtInicio.PreValidado = false;
            this.txtDtInicio.SelectAllOnFocus = false;
            this.txtDtInicio.Size = new System.Drawing.Size(80, 21);
            this.txtDtInicio.TabIndex = 138;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(464, 39);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(36, 13);
            this.hacLabel1.TabIndex = 137;
            this.hacLabel1.Text = "  De:";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Verdana", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(3, 12);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(191, 16);
            this.lblProduto.TabIndex = 136;
            this.lblProduto.Text = "Material ou Medicamento";
            this.lblProduto.Click += new System.EventHandler(this.lblProduto_Click);
            this.lblProduto.DoubleClick += new System.EventHandler(this.lblProduto_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.hacLabel7);
            this.panel2.Controls.Add(this.hacLabel6);
            this.panel2.Controls.Add(this.chkMostraMov);
            this.panel2.Controls.Add(this.lblSaldo);
            this.panel2.Controls.Add(this.hacLabel5);
            this.panel2.Controls.Add(this.lblTotalSaidas);
            this.panel2.Controls.Add(this.hacLabel4);
            this.panel2.Controls.Add(this.lblTotalEntrada);
            this.panel2.Controls.Add(this.hacLabel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 50);
            this.panel2.TabIndex = 4;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.ForeColor = System.Drawing.Color.Gray;
            this.hacLabel7.Location = new System.Drawing.Point(100, 32);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(177, 13);
            this.hacLabel7.TabIndex = 145;
            this.hacLabel7.Text = "* MOVIMENTO ESTORNADO";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.ForeColor = System.Drawing.Color.Brown;
            this.hacLabel6.Location = new System.Drawing.Point(7, 32);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(78, 13);
            this.hacLabel6.TabIndex = 144;
            this.hacLabel6.Text = "* ESTORNO";
            // 
            // chkMostraMov
            // 
            this.chkMostraMov.AutoSize = true;
            this.chkMostraMov.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkMostraMov.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkMostraMov.Limpar = true;
            this.chkMostraMov.Location = new System.Drawing.Point(559, 8);
            this.chkMostraMov.Name = "chkMostraMov";
            this.chkMostraMov.Obrigatorio = false;
            this.chkMostraMov.ObrigatorioMensagem = null;
            this.chkMostraMov.PreValidacaoMensagem = null;
            this.chkMostraMov.PreValidado = false;
            this.chkMostraMov.Size = new System.Drawing.Size(182, 17);
            this.chkMostraMov.TabIndex = 143;
            this.chkMostraMov.Text = "Mostrar todas as Movimentações";
            this.chkMostraMov.UseVisualStyleBackColor = true;
            this.chkMostraMov.Click += new System.EventHandler(this.chkMostraMov_Click);
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(477, 5);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(19, 18);
            this.lblSaldo.TabIndex = 142;
            this.lblSaldo.Text = "0";
            this.lblSaldo.Visible = false;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(419, 5);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(59, 18);
            this.hacLabel5.TabIndex = 141;
            this.hacLabel5.Text = "Saldo:";
            this.hacLabel5.Visible = false;
            // 
            // lblTotalSaidas
            // 
            this.lblTotalSaidas.AutoSize = true;
            this.lblTotalSaidas.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTotalSaidas.Location = new System.Drawing.Point(352, 5);
            this.lblTotalSaidas.Name = "lblTotalSaidas";
            this.lblTotalSaidas.Size = new System.Drawing.Size(19, 18);
            this.lblTotalSaidas.TabIndex = 140;
            this.lblTotalSaidas.Text = "0";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(232, 5);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(114, 18);
            this.hacLabel4.TabIndex = 139;
            this.hacLabel4.Text = "Total Saidas:";
            // 
            // lblTotalEntrada
            // 
            this.lblTotalEntrada.AutoSize = true;
            this.lblTotalEntrada.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTotalEntrada.Location = new System.Drawing.Point(151, 5);
            this.lblTotalEntrada.Name = "lblTotalEntrada";
            this.lblTotalEntrada.Size = new System.Drawing.Size(19, 18);
            this.lblTotalEntrada.TabIndex = 138;
            this.lblTotalEntrada.Text = "0";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(12, 5);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(133, 18);
            this.hacLabel3.TabIndex = 137;
            this.hacLabel3.Text = "Total Entradas:";
            // 
            // FrmMovimentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 514);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtgMovimento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hacToolStrip1);
            this.ModoTela = HospitalAnaCosta.SGS.Componentes.ModoEdicao.Edicao;
            this.Name = "FrmMovimentacao";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmMovimentacao_Load);
            this.Shown += new System.EventHandler(this.FrmMovimentacao_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMovimento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip hacToolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsTpMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSubTpMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperador;
        private HacDataGridView dtgMovimento;
        private System.Windows.Forms.Panel panel1;
        private HacTextBox txtDtFim;
        private HacLabel hacLabel2;
        private HacTextBox txtDtInicio;
        private HacLabel hacLabel1;
        private HacLabel lblProduto;
        private HacButton btnPesquisar;
        private System.Windows.Forms.Panel panel2;
        private HacLabel hacLabel3;
        private HacLabel lblTotalSaidas;
        private HacLabel hacLabel4;
        private HacLabel lblTotalEntrada;
        private HacLabel lblSaldo;
        private HacLabel hacLabel5;
        private HacCheckBox chkMostraMov;
        private HacLabel hacLabel6;
        private HacLabel lblLote;
        private HacLabel hacLabel7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTipoMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoMovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtdAteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuEstorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtTpMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtSubMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlEstorno;
    }
}