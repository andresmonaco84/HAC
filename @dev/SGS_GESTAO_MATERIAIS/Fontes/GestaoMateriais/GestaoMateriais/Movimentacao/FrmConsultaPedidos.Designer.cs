using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmPedidosConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidosConsulta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.dtgPedido = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colReqIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpRequisicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioDispensa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDevolvido = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbTodos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbCancelado = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAlmox = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbNaDisp = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbDispensado = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.chkPendente = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtNumAtend = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbTipoPedido = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedido)).BeginInit();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(792, 28);
            this.tsHac.TabIndex = 134;
            this.tsHac.TituloTela = "Pesquisa de Pedidos";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            // 
            // dtgPedido
            // 
            this.dtgPedido.AllowUserToAddRows = false;
            this.dtgPedido.AlterarStatus = true;
            this.dtgPedido.BackgroundColor = System.Drawing.Color.White;
            this.dtgPedido.ColumnHeadersHeight = 21;
            this.dtgPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReqIdt,
            this.colTpRequisicao,
            this.colOrigem,
            this.colIdStatus,
            this.colStatus,
            this.colDataReq,
            this.colUsuarioPedido,
            this.colDataDisp,
            this.colUsuarioDispensa,
            this.colIdtAtendimento,
            this.colKit,
            this.colPendente});
            this.dtgPedido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgPedido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgPedido.GridPesquisa = false;
            this.dtgPedido.Limpar = true;
            this.dtgPedido.Location = new System.Drawing.Point(7, 156);
            this.dtgPedido.Name = "dtgPedido";
            this.dtgPedido.NaoAjustarEdicao = true;
            this.dtgPedido.Obrigatorio = false;
            this.dtgPedido.ObrigatorioMensagem = null;
            this.dtgPedido.PreValidacaoMensagem = null;
            this.dtgPedido.PreValidado = false;
            this.dtgPedido.RowHeadersVisible = false;
            this.dtgPedido.RowHeadersWidth = 25;
            this.dtgPedido.RowTemplate.Height = 18;
            this.dtgPedido.Size = new System.Drawing.Size(773, 388);
            this.dtgPedido.TabIndex = 17;
            this.dtgPedido.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPedido_CellDoubleClick);
            this.dtgPedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgPedido_CellFormatting);
            // 
            // colReqIdt
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReqIdt.DefaultCellStyle = dataGridViewCellStyle1;
            this.colReqIdt.HeaderText = "ID";
            this.colReqIdt.Name = "colReqIdt";
            this.colReqIdt.ReadOnly = true;
            this.colReqIdt.Width = 55;
            // 
            // colTpRequisicao
            // 
            this.colTpRequisicao.HeaderText = "Tipo";
            this.colTpRequisicao.Name = "colTpRequisicao";
            this.colTpRequisicao.ReadOnly = true;
            this.colTpRequisicao.Width = 140;
            // 
            // colOrigem
            // 
            this.colOrigem.HeaderText = "Centro Disp.";
            this.colOrigem.Name = "colOrigem";
            this.colOrigem.ReadOnly = true;
            // 
            // colIdStatus
            // 
            this.colIdStatus.HeaderText = "colIdStatus";
            this.colIdStatus.Name = "colIdStatus";
            this.colIdStatus.Visible = false;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 180;
            // 
            // colDataReq
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataReq.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataReq.HeaderText = "Dt Pedido";
            this.colDataReq.Name = "colDataReq";
            this.colDataReq.ReadOnly = true;
            this.colDataReq.Width = 110;
            // 
            // colUsuarioPedido
            // 
            this.colUsuarioPedido.HeaderText = "Pedido Por";
            this.colUsuarioPedido.Name = "colUsuarioPedido";
            this.colUsuarioPedido.ReadOnly = true;
            this.colUsuarioPedido.Width = 140;
            // 
            // colDataDisp
            // 
            this.colDataDisp.HeaderText = "Dt Disp.";
            this.colDataDisp.Name = "colDataDisp";
            this.colDataDisp.ReadOnly = true;
            this.colDataDisp.Width = 110;
            // 
            // colUsuarioDispensa
            // 
            this.colUsuarioDispensa.HeaderText = "Dispensado Por";
            this.colUsuarioDispensa.Name = "colUsuarioDispensa";
            this.colUsuarioDispensa.ReadOnly = true;
            this.colUsuarioDispensa.Width = 140;
            // 
            // colIdtAtendimento
            // 
            this.colIdtAtendimento.HeaderText = "Atendimento";
            this.colIdtAtendimento.Name = "colIdtAtendimento";
            this.colIdtAtendimento.ReadOnly = true;
            // 
            // colKit
            // 
            this.colKit.HeaderText = "Kit";
            this.colKit.Name = "colKit";
            this.colKit.ReadOnly = true;
            this.colKit.Width = 250;
            // 
            // colPendente
            // 
            this.colPendente.HeaderText = "Pendente";
            this.colPendente.Name = "colPendente";
            this.colPendente.ReadOnly = true;
            this.colPendente.Width = 60;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(445, 40);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 140;
            this.hacLabel3.Text = "Setor";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = false;
            this.cmbLocal.Location = new System.Drawing.Point(262, 37);
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
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(223, 40);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 138;
            this.hacLabel2.Text = "Local";
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
            this.cmbUnidade.Location = new System.Drawing.Point(58, 37);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidacaoMensagem = "Unidade Não Pode Estar em Branco";
            this.cmbUnidade.PreValidado = true;
            this.cmbUnidade.Size = new System.Drawing.Size(160, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 1;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(3, 40);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 136;
            this.hacLabel1.Text = "Unidade";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbAcs);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(686, 28);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(99, 36);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(52, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = null;
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 5;
            this.rbAcs.TabStop = true;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(5, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = null;
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 4;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.ComEstoque = false;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = false;
            this.cmbSetor.Limpar = false;
            this.cmbSetor.Location = new System.Drawing.Point(485, 37);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.cmbSetor.PreValidado = true;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(190, 21);
            this.cmbSetor.TabIndex = 3;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDevolvido);
            this.groupBox1.Controls.Add(this.rbTodos);
            this.groupBox1.Controls.Add(this.rbCancelado);
            this.groupBox1.Controls.Add(this.rbAlmox);
            this.groupBox1.Controls.Add(this.rbNaDisp);
            this.groupBox1.Controls.Add(this.rbDispensado);
            this.groupBox1.Location = new System.Drawing.Point(5, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 37);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // rbDevolvido
            // 
            this.rbDevolvido.AutoSize = true;
            this.rbDevolvido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbDevolvido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDevolvido.Limpar = false;
            this.rbDevolvido.Location = new System.Drawing.Point(446, 15);
            this.rbDevolvido.Name = "rbDevolvido";
            this.rbDevolvido.Obrigatorio = false;
            this.rbDevolvido.ObrigatorioMensagem = null;
            this.rbDevolvido.PreValidacaoMensagem = null;
            this.rbDevolvido.PreValidado = false;
            this.rbDevolvido.Size = new System.Drawing.Size(73, 17);
            this.rbDevolvido.TabIndex = 154;
            this.rbDevolvido.TabStop = true;
            this.rbDevolvido.Text = "Devolvido";
            this.rbDevolvido.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbTodos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbTodos.Limpar = false;
            this.rbTodos.Location = new System.Drawing.Point(601, 15);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Obrigatorio = false;
            this.rbTodos.ObrigatorioMensagem = null;
            this.rbTodos.PreValidacaoMensagem = null;
            this.rbTodos.PreValidado = false;
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 16;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbCancelado
            // 
            this.rbCancelado.AutoSize = true;
            this.rbCancelado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCancelado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCancelado.Limpar = false;
            this.rbCancelado.Location = new System.Drawing.Point(525, 15);
            this.rbCancelado.Name = "rbCancelado";
            this.rbCancelado.Obrigatorio = false;
            this.rbCancelado.ObrigatorioMensagem = null;
            this.rbCancelado.PreValidacaoMensagem = null;
            this.rbCancelado.PreValidado = false;
            this.rbCancelado.Size = new System.Drawing.Size(76, 17);
            this.rbCancelado.TabIndex = 15;
            this.rbCancelado.TabStop = true;
            this.rbCancelado.Text = "Cancelado";
            this.rbCancelado.UseVisualStyleBackColor = true;
            // 
            // rbAlmox
            // 
            this.rbAlmox.AutoSize = true;
            this.rbAlmox.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAlmox.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAlmox.Limpar = false;
            this.rbAlmox.Location = new System.Drawing.Point(7, 15);
            this.rbAlmox.Name = "rbAlmox";
            this.rbAlmox.Obrigatorio = false;
            this.rbAlmox.ObrigatorioMensagem = null;
            this.rbAlmox.PreValidacaoMensagem = null;
            this.rbAlmox.PreValidado = false;
            this.rbAlmox.Size = new System.Drawing.Size(185, 17);
            this.rbAlmox.TabIndex = 12;
            this.rbAlmox.TabStop = true;
            this.rbAlmox.Text = "Enviado ao Almox./Fila Impressão";
            this.rbAlmox.UseVisualStyleBackColor = true;
            // 
            // rbNaDisp
            // 
            this.rbNaDisp.AutoSize = true;
            this.rbNaDisp.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbNaDisp.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbNaDisp.Limpar = false;
            this.rbNaDisp.Location = new System.Drawing.Point(198, 15);
            this.rbNaDisp.Name = "rbNaDisp";
            this.rbNaDisp.Obrigatorio = false;
            this.rbNaDisp.ObrigatorioMensagem = null;
            this.rbNaDisp.PreValidacaoMensagem = null;
            this.rbNaDisp.PreValidado = false;
            this.rbNaDisp.Size = new System.Drawing.Size(151, 17);
            this.rbNaDisp.TabIndex = 13;
            this.rbNaDisp.TabStop = true;
            this.rbNaDisp.Text = "Impresso/Na Dispensação";
            this.rbNaDisp.UseVisualStyleBackColor = true;
            // 
            // rbDispensado
            // 
            this.rbDispensado.AutoSize = true;
            this.rbDispensado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbDispensado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbDispensado.Limpar = false;
            this.rbDispensado.Location = new System.Drawing.Point(357, 15);
            this.rbDispensado.Name = "rbDispensado";
            this.rbDispensado.Obrigatorio = false;
            this.rbDispensado.ObrigatorioMensagem = null;
            this.rbDispensado.PreValidacaoMensagem = null;
            this.rbDispensado.PreValidado = false;
            this.rbDispensado.Size = new System.Drawing.Size(81, 17);
            this.rbDispensado.TabIndex = 14;
            this.rbDispensado.TabStop = true;
            this.rbDispensado.Text = "Dispensado";
            this.rbDispensado.UseVisualStyleBackColor = true;
            // 
            // chkPendente
            // 
            this.chkPendente.AutoSize = true;
            this.chkPendente.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkPendente.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkPendente.Limpar = false;
            this.chkPendente.Location = new System.Drawing.Point(672, 123);
            this.chkPendente.Name = "chkPendente";
            this.chkPendente.Obrigatorio = false;
            this.chkPendente.ObrigatorioMensagem = null;
            this.chkPendente.PreValidacaoMensagem = null;
            this.chkPendente.PreValidado = false;
            this.chkPendente.Size = new System.Drawing.Size(113, 17);
            this.chkPendente.TabIndex = 16;
            this.chkPendente.Text = "TIPO PENDENTE";
            this.chkPendente.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFim);
            this.groupBox2.Controls.Add(this.txtInicio);
            this.groupBox2.Controls.Add(this.hacLabel4);
            this.groupBox2.Controls.Add(this.hacLabel5);
            this.groupBox2.Location = new System.Drawing.Point(470, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 42);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período";
            // 
            // txtFim
            // 
            this.txtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Limpar = false;
            this.txtFim.Location = new System.Drawing.Point(227, 14);
            this.txtFim.MaxLength = 10;
            this.txtFim.Name = "txtFim";
            this.txtFim.NaoAjustarEdicao = true;
            this.txtFim.Obrigatorio = false;
            this.txtFim.ObrigatorioMensagem = null;
            this.txtFim.PreValidacaoMensagem = null;
            this.txtFim.PreValidado = false;
            this.txtFim.SelectAllOnFocus = false;
            this.txtFim.Size = new System.Drawing.Size(80, 20);
            this.txtFim.TabIndex = 11;
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
            this.txtInicio.Limpar = false;
            this.txtInicio.Location = new System.Drawing.Point(80, 14);
            this.txtInicio.MaxLength = 10;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.NaoAjustarEdicao = true;
            this.txtInicio.Obrigatorio = false;
            this.txtInicio.ObrigatorioMensagem = null;
            this.txtInicio.PreValidacaoMensagem = null;
            this.txtInicio.PreValidado = false;
            this.txtInicio.SelectAllOnFocus = false;
            this.txtInicio.Size = new System.Drawing.Size(80, 20);
            this.txtInicio.TabIndex = 10;
            this.txtInicio.TabStop = false;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(168, 18);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(58, 13);
            this.hacLabel4.TabIndex = 150;
            this.hacLabel4.Text = "Data Fim";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(10, 18);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(69, 13);
            this.hacLabel5.TabIndex = 149;
            this.hacLabel5.Text = "Data Início";
            // 
            // txtNumAtend
            // 
            this.txtNumAtend.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtNumAtend.BackColor = System.Drawing.Color.Honeydew;
            this.txtNumAtend.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtNumAtend.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNumAtend.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNumAtend.Limpar = false;
            this.txtNumAtend.Location = new System.Drawing.Point(388, 78);
            this.txtNumAtend.MaxLength = 10;
            this.txtNumAtend.Name = "txtNumAtend";
            this.txtNumAtend.NaoAjustarEdicao = true;
            this.txtNumAtend.Obrigatorio = false;
            this.txtNumAtend.ObrigatorioMensagem = "";
            this.txtNumAtend.PreValidacaoMensagem = "";
            this.txtNumAtend.PreValidado = false;
            this.txtNumAtend.SelectAllOnFocus = false;
            this.txtNumAtend.Size = new System.Drawing.Size(74, 21);
            this.txtNumAtend.TabIndex = 17;
            this.txtNumAtend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumAtend_KeyUp);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(273, 82);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(113, 13);
            this.hacLabel6.TabIndex = 152;
            this.hacLabel6.Text = "Num. Atendimento";
            // 
            // cmbTipoPedido
            // 
            this.cmbTipoPedido.BackColor = System.Drawing.Color.Honeydew;
            this.cmbTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPedido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbTipoPedido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbTipoPedido.FormattingEnabled = true;
            this.cmbTipoPedido.Limpar = false;
            this.cmbTipoPedido.Location = new System.Drawing.Point(79, 78);
            this.cmbTipoPedido.Name = "cmbTipoPedido";
            this.cmbTipoPedido.Obrigatorio = false;
            this.cmbTipoPedido.ObrigatorioMensagem = null;
            this.cmbTipoPedido.PreValidacaoMensagem = null;
            this.cmbTipoPedido.PreValidado = false;
            this.cmbTipoPedido.Size = new System.Drawing.Size(189, 21);
            this.cmbTipoPedido.TabIndex = 7;
            this.cmbTipoPedido.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoRequisicao_SelectionChangeCommitted);
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(4, 82);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(73, 13);
            this.hacLabel7.TabIndex = 153;
            this.hacLabel7.Text = "Tipo Pedido";
            // 
            // FrmPedidosConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 556);
            this.Controls.Add(this.hacLabel7);
            this.Controls.Add(this.cmbTipoPedido);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.txtNumAtend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkPendente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.dtgPedido);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmPedidosConsulta";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmPedidosConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedido)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacDataGridView dtgPedido;
        private HacLabel hacLabel3;
        private HacCmbLocal cmbLocal;
        private HacLabel hacLabel2;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel1;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacCmbSetor cmbSetor;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacCheckBox chkPendente;
        private HacRadioButton rbDispensado;
        private HacRadioButton rbNaDisp;
        private HacRadioButton rbAlmox;
        private HacRadioButton rbCancelado;
        private System.Windows.Forms.GroupBox groupBox2;
        private HacTextBox txtFim;
        private HacTextBox txtInicio;
        private HacLabel hacLabel4;
        private HacLabel hacLabel5;
        private HacTextBox txtNumAtend;
        private HacLabel hacLabel6;
        private HacRadioButton rbTodos;
        private HacComboBox cmbTipoPedido;
        private HacLabel hacLabel7;
        private HacRadioButton rbDevolvido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpRequisicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioDispensa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendente;
    }
}