namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmEmprestimo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmprestimo));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.grbConcedido = new System.Windows.Forms.GroupBox();
            this.rbEntradaDevolucao = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbSaidaConcedido = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSaidaDevolucao = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbEntradaObtido = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.grbEmprestimo = new System.Windows.Forms.GroupBox();
            this.grbTP = new System.Windows.Forms.GroupBox();
            this.rbMedicamento = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbMaterial = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.txtCodBarra = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtValidade = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtNumLoteFab = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel13 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbSaidaProduto = new System.Windows.Forms.GroupBox();
            this.grbEntradaProduto = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grbProduto = new System.Windows.Forms.GroupBox();
            this.lblNumLoteFab = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel12 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblValidade = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblCodLote = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtDsProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtQtde = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.btnRegistrarMov = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.txtSaldoAlmox = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblSaldoAlmox = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbEmpresa = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.grbSetorMov = new System.Windows.Forms.GroupBox();
            this.rbFarm = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAlmox = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.txtDescricaoNovaEmpresa = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.btnNovaEmpresa = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.grbConcedido.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbEmprestimo.SuspendLayout();
            this.grbTP.SuspendLayout();
            this.grbSaidaProduto.SuspendLayout();
            this.grbEntradaProduto.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grbProduto.SuspendLayout();
            this.grbSetorMov.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(645, 28);
            this.tsHac.TabIndex = 133;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Empréstimo - Registro de Movimentação";
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.AfterCancelar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterCancelar);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
            // 
            // grbConcedido
            // 
            this.grbConcedido.Controls.Add(this.rbEntradaDevolucao);
            this.grbConcedido.Controls.Add(this.rbSaidaConcedido);
            this.grbConcedido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConcedido.Location = new System.Drawing.Point(6, 10);
            this.grbConcedido.Name = "grbConcedido";
            this.grbConcedido.Size = new System.Drawing.Size(178, 69);
            this.grbConcedido.TabIndex = 2;
            this.grbConcedido.TabStop = false;
            this.grbConcedido.Text = "Empréstimo Concedido";
            // 
            // rbEntradaDevolucao
            // 
            this.rbEntradaDevolucao.AutoSize = true;
            this.rbEntradaDevolucao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbEntradaDevolucao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbEntradaDevolucao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEntradaDevolucao.Limpar = true;
            this.rbEntradaDevolucao.Location = new System.Drawing.Point(12, 44);
            this.rbEntradaDevolucao.Name = "rbEntradaDevolucao";
            this.rbEntradaDevolucao.Obrigatorio = false;
            this.rbEntradaDevolucao.ObrigatorioMensagem = null;
            this.rbEntradaDevolucao.PreValidacaoMensagem = null;
            this.rbEntradaDevolucao.PreValidado = false;
            this.rbEntradaDevolucao.Size = new System.Drawing.Size(133, 17);
            this.rbEntradaDevolucao.TabIndex = 1;
            this.rbEntradaDevolucao.TabStop = true;
            this.rbEntradaDevolucao.Text = "Entrada Devolução";
            this.rbEntradaDevolucao.UseVisualStyleBackColor = true;
            this.rbEntradaDevolucao.Click += new System.EventHandler(this.rbEntradaDevolucao_Click);
            // 
            // rbSaidaConcedido
            // 
            this.rbSaidaConcedido.AutoSize = true;
            this.rbSaidaConcedido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbSaidaConcedido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbSaidaConcedido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSaidaConcedido.Limpar = true;
            this.rbSaidaConcedido.Location = new System.Drawing.Point(12, 21);
            this.rbSaidaConcedido.Name = "rbSaidaConcedido";
            this.rbSaidaConcedido.Obrigatorio = false;
            this.rbSaidaConcedido.ObrigatorioMensagem = null;
            this.rbSaidaConcedido.PreValidacaoMensagem = null;
            this.rbSaidaConcedido.PreValidado = false;
            this.rbSaidaConcedido.Size = new System.Drawing.Size(121, 17);
            this.rbSaidaConcedido.TabIndex = 0;
            this.rbSaidaConcedido.TabStop = true;
            this.rbSaidaConcedido.Text = "Saída Concedido";
            this.rbSaidaConcedido.UseVisualStyleBackColor = true;
            this.rbSaidaConcedido.Click += new System.EventHandler(this.rbSaidaConcedido_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSaidaDevolucao);
            this.groupBox1.Controls.Add(this.rbEntradaObtido);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(199, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empréstimo Obtido";
            // 
            // rbSaidaDevolucao
            // 
            this.rbSaidaDevolucao.AutoSize = true;
            this.rbSaidaDevolucao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbSaidaDevolucao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbSaidaDevolucao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSaidaDevolucao.Limpar = true;
            this.rbSaidaDevolucao.Location = new System.Drawing.Point(12, 44);
            this.rbSaidaDevolucao.Name = "rbSaidaDevolucao";
            this.rbSaidaDevolucao.Obrigatorio = false;
            this.rbSaidaDevolucao.ObrigatorioMensagem = null;
            this.rbSaidaDevolucao.PreValidacaoMensagem = null;
            this.rbSaidaDevolucao.PreValidado = false;
            this.rbSaidaDevolucao.Size = new System.Drawing.Size(121, 17);
            this.rbSaidaDevolucao.TabIndex = 1;
            this.rbSaidaDevolucao.TabStop = true;
            this.rbSaidaDevolucao.Text = "Saída Devolução";
            this.rbSaidaDevolucao.UseVisualStyleBackColor = true;
            this.rbSaidaDevolucao.Click += new System.EventHandler(this.rbSaidaDevolucao_Click);
            // 
            // rbEntradaObtido
            // 
            this.rbEntradaObtido.AutoSize = true;
            this.rbEntradaObtido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbEntradaObtido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbEntradaObtido.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEntradaObtido.Limpar = true;
            this.rbEntradaObtido.Location = new System.Drawing.Point(12, 21);
            this.rbEntradaObtido.Name = "rbEntradaObtido";
            this.rbEntradaObtido.Obrigatorio = false;
            this.rbEntradaObtido.ObrigatorioMensagem = null;
            this.rbEntradaObtido.PreValidacaoMensagem = null;
            this.rbEntradaObtido.PreValidado = false;
            this.rbEntradaObtido.Size = new System.Drawing.Size(110, 17);
            this.rbEntradaObtido.TabIndex = 0;
            this.rbEntradaObtido.TabStop = true;
            this.rbEntradaObtido.Text = "Entrada Obtido";
            this.rbEntradaObtido.UseVisualStyleBackColor = true;
            this.rbEntradaObtido.Click += new System.EventHandler(this.rbEntradaObtido_Click);
            // 
            // grbEmprestimo
            // 
            this.grbEmprestimo.Controls.Add(this.grbConcedido);
            this.grbEmprestimo.Controls.Add(this.groupBox1);
            this.grbEmprestimo.Location = new System.Drawing.Point(12, 33);
            this.grbEmprestimo.Name = "grbEmprestimo";
            this.grbEmprestimo.Size = new System.Drawing.Size(387, 89);
            this.grbEmprestimo.TabIndex = 0;
            this.grbEmprestimo.TabStop = false;
            // 
            // grbTP
            // 
            this.grbTP.Controls.Add(this.rbMedicamento);
            this.grbTP.Controls.Add(this.rbMaterial);
            this.grbTP.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTP.Location = new System.Drawing.Point(446, 41);
            this.grbTP.Name = "grbTP";
            this.grbTP.Size = new System.Drawing.Size(121, 33);
            this.grbTP.TabIndex = 0;
            this.grbTP.TabStop = false;
            // 
            // rbMedicamento
            // 
            this.rbMedicamento.AutoSize = true;
            this.rbMedicamento.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbMedicamento.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbMedicamento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMedicamento.Limpar = true;
            this.rbMedicamento.Location = new System.Drawing.Point(64, 12);
            this.rbMedicamento.Name = "rbMedicamento";
            this.rbMedicamento.Obrigatorio = false;
            this.rbMedicamento.ObrigatorioMensagem = null;
            this.rbMedicamento.PreValidacaoMensagem = null;
            this.rbMedicamento.PreValidado = false;
            this.rbMedicamento.Size = new System.Drawing.Size(52, 17);
            this.rbMedicamento.TabIndex = 1;
            this.rbMedicamento.Text = "MED";
            this.rbMedicamento.UseVisualStyleBackColor = true;
            this.rbMedicamento.Click += new System.EventHandler(this.rbMedicamento_Click);
            // 
            // rbMaterial
            // 
            this.rbMaterial.AutoSize = true;
            this.rbMaterial.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbMaterial.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbMaterial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMaterial.Limpar = true;
            this.rbMaterial.Location = new System.Drawing.Point(8, 12);
            this.rbMaterial.Name = "rbMaterial";
            this.rbMaterial.Obrigatorio = false;
            this.rbMaterial.ObrigatorioMensagem = null;
            this.rbMaterial.PreValidacaoMensagem = null;
            this.rbMaterial.PreValidado = false;
            this.rbMaterial.Size = new System.Drawing.Size(52, 17);
            this.rbMaterial.TabIndex = 0;
            this.rbMaterial.Text = "MAT";
            this.rbMaterial.UseVisualStyleBackColor = true;
            this.rbMaterial.Click += new System.EventHandler(this.rbMaterial_Click);
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodBarra.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodBarra.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCodBarra.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtCodBarra.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodBarra.Limpar = true;
            this.txtCodBarra.Location = new System.Drawing.Point(76, 20);
            this.txtCodBarra.MaxLength = 50;
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.NaoAjustarEdicao = true;
            this.txtCodBarra.Obrigatorio = false;
            this.txtCodBarra.ObrigatorioMensagem = null;
            this.txtCodBarra.PreValidacaoMensagem = null;
            this.txtCodBarra.PreValidado = false;
            this.txtCodBarra.SelectAllOnFocus = false;
            this.txtCodBarra.Size = new System.Drawing.Size(115, 21);
            this.txtCodBarra.TabIndex = 0;
            this.txtCodBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodBarra.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodBarra_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 166;
            this.label3.Text = "Cod. Barra";
            // 
            // txtValidade
            // 
            this.txtValidade.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtValidade.BackColor = System.Drawing.Color.Honeydew;
            this.txtValidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtValidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidade.Limpar = true;
            this.txtValidade.Location = new System.Drawing.Point(281, 19);
            this.txtValidade.MaxLength = 10;
            this.txtValidade.Name = "txtValidade";
            this.txtValidade.NaoAjustarEdicao = true;
            this.txtValidade.Obrigatorio = false;
            this.txtValidade.ObrigatorioMensagem = null;
            this.txtValidade.PreValidacaoMensagem = null;
            this.txtValidade.PreValidado = false;
            this.txtValidade.SelectAllOnFocus = false;
            this.txtValidade.Size = new System.Drawing.Size(80, 20);
            this.txtValidade.TabIndex = 2;
            this.txtValidade.TabStop = false;
            this.txtValidade.Validating += new System.ComponentModel.CancelEventHandler(this.txtValidade_Validating);
            // 
            // txtNumLoteFab
            // 
            this.txtNumLoteFab.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtNumLoteFab.BackColor = System.Drawing.Color.Honeydew;
            this.txtNumLoteFab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumLoteFab.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtNumLoteFab.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtNumLoteFab.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNumLoteFab.Limpar = true;
            this.txtNumLoteFab.Location = new System.Drawing.Point(88, 19);
            this.txtNumLoteFab.MaxLength = 15;
            this.txtNumLoteFab.Name = "txtNumLoteFab";
            this.txtNumLoteFab.NaoAjustarEdicao = true;
            this.txtNumLoteFab.Obrigatorio = false;
            this.txtNumLoteFab.ObrigatorioMensagem = null;
            this.txtNumLoteFab.PreValidacaoMensagem = null;
            this.txtNumLoteFab.PreValidado = false;
            this.txtNumLoteFab.SelectAllOnFocus = false;
            this.txtNumLoteFab.Size = new System.Drawing.Size(125, 21);
            this.txtNumLoteFab.TabIndex = 1;
            this.txtNumLoteFab.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumLoteFab.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumLoteFab_Validating);
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(219, 23);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(61, 13);
            this.hacLabel11.TabIndex = 171;
            this.hacLabel11.Text = "Validade:";
            // 
            // hacLabel13
            // 
            this.hacLabel13.AutoSize = true;
            this.hacLabel13.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel13.Location = new System.Drawing.Point(6, 23);
            this.hacLabel13.Name = "hacLabel13";
            this.hacLabel13.Size = new System.Drawing.Size(82, 13);
            this.hacLabel13.TabIndex = 170;
            this.hacLabel13.Text = "N° Lote Fab.:";
            // 
            // grbSaidaProduto
            // 
            this.grbSaidaProduto.Controls.Add(this.txtCodBarra);
            this.grbSaidaProduto.Controls.Add(this.label3);
            this.grbSaidaProduto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSaidaProduto.Location = new System.Drawing.Point(5, 20);
            this.grbSaidaProduto.Name = "grbSaidaProduto";
            this.grbSaidaProduto.Size = new System.Drawing.Size(200, 51);
            this.grbSaidaProduto.TabIndex = 0;
            this.grbSaidaProduto.TabStop = false;
            this.grbSaidaProduto.Text = "Saída Produto";
            // 
            // grbEntradaProduto
            // 
            this.grbEntradaProduto.Controls.Add(this.txtNumLoteFab);
            this.grbEntradaProduto.Controls.Add(this.hacLabel13);
            this.grbEntradaProduto.Controls.Add(this.txtValidade);
            this.grbEntradaProduto.Controls.Add(this.hacLabel11);
            this.grbEntradaProduto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbEntradaProduto.Location = new System.Drawing.Point(210, 20);
            this.grbEntradaProduto.Name = "grbEntradaProduto";
            this.grbEntradaProduto.Size = new System.Drawing.Size(369, 51);
            this.grbEntradaProduto.TabIndex = 1;
            this.grbEntradaProduto.TabStop = false;
            this.grbEntradaProduto.Text = "Entrada Produto";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grbEntradaProduto);
            this.groupBox4.Controls.Add(this.grbSaidaProduto);
            this.groupBox4.Controls.Add(this.grbProduto);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(11, 147);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(585, 167);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Identificação do Produto";
            // 
            // grbProduto
            // 
            this.grbProduto.Controls.Add(this.lblNumLoteFab);
            this.grbProduto.Controls.Add(this.hacLabel12);
            this.grbProduto.Controls.Add(this.lblValidade);
            this.grbProduto.Controls.Add(this.hacLabel7);
            this.grbProduto.Controls.Add(this.grbTP);
            this.grbProduto.Controls.Add(this.lblCodLote);
            this.grbProduto.Controls.Add(this.hacLabel6);
            this.grbProduto.Controls.Add(this.label1);
            this.grbProduto.Controls.Add(this.txtIdProduto);
            this.grbProduto.Controls.Add(this.txtDsProduto);
            this.grbProduto.Controls.Add(this.label2);
            this.grbProduto.Location = new System.Drawing.Point(5, 76);
            this.grbProduto.Name = "grbProduto";
            this.grbProduto.Size = new System.Drawing.Size(574, 80);
            this.grbProduto.TabIndex = 2;
            this.grbProduto.TabStop = false;
            this.grbProduto.Text = "Produto";
            // 
            // lblNumLoteFab
            // 
            this.lblNumLoteFab.AutoSize = true;
            this.lblNumLoteFab.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumLoteFab.ForeColor = System.Drawing.Color.Red;
            this.lblNumLoteFab.Location = new System.Drawing.Point(194, 55);
            this.lblNumLoteFab.Name = "lblNumLoteFab";
            this.lblNumLoteFab.Size = new System.Drawing.Size(10, 12);
            this.lblNumLoteFab.TabIndex = 148;
            this.lblNumLoteFab.Text = "-";
            // 
            // hacLabel12
            // 
            this.hacLabel12.AutoSize = true;
            this.hacLabel12.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel12.Location = new System.Drawing.Point(119, 55);
            this.hacLabel12.Name = "hacLabel12";
            this.hacLabel12.Size = new System.Drawing.Size(78, 12);
            this.hacLabel12.TabIndex = 147;
            this.hacLabel12.Text = "N° Lote Fab.:";
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblValidade.ForeColor = System.Drawing.Color.Red;
            this.lblValidade.Location = new System.Drawing.Point(379, 55);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(10, 12);
            this.lblValidade.TabIndex = 146;
            this.lblValidade.Text = "-";
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(324, 55);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(58, 12);
            this.hacLabel7.TabIndex = 145;
            this.hacLabel7.Text = "Validade:";
            // 
            // lblCodLote
            // 
            this.lblCodLote.AutoSize = true;
            this.lblCodLote.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCodLote.ForeColor = System.Drawing.Color.Red;
            this.lblCodLote.Location = new System.Drawing.Point(73, 55);
            this.lblCodLote.Name = "lblCodLote";
            this.lblCodLote.Size = new System.Drawing.Size(10, 12);
            this.lblCodLote.TabIndex = 144;
            this.lblCodLote.Text = "-";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(12, 55);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(64, 12);
            this.hacLabel6.TabIndex = 143;
            this.hacLabel6.Text = "Cod. Lote:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtIdProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtIdProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtIdProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdProduto.Limpar = true;
            this.txtIdProduto.Location = new System.Drawing.Point(34, 20);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = false;
            this.txtIdProduto.ObrigatorioMensagem = null;
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(71, 21);
            this.txtIdProduto.TabIndex = 3;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdProduto_Validating);
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDsProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(196, 20);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = true;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.ReadOnly = true;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(370, 21);
            this.txtDsProduto.TabIndex = 5;
            this.txtDsProduto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "DESCRIÇÃO";
            // 
            // txtQtde
            // 
            this.txtQtde.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtde.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtde.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtQtde.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtQtde.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtde.Limpar = true;
            this.txtQtde.Location = new System.Drawing.Point(106, 376);
            this.txtQtde.MaxLength = 5;
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.NaoAjustarEdicao = false;
            this.txtQtde.Obrigatorio = true;
            this.txtQtde.ObrigatorioMensagem = "Qtd. Transferência Não Pode Estar Em Branco";
            this.txtQtde.PreValidacaoMensagem = null;
            this.txtQtde.PreValidado = false;
            this.txtQtde.SelectAllOnFocus = false;
            this.txtQtde.Size = new System.Drawing.Size(62, 21);
            this.txtQtde.TabIndex = 5;
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel9
            // 
            this.hacLabel9.AutoSize = true;
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(22, 380);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(81, 13);
            this.hacLabel9.TabIndex = 175;
            this.hacLabel9.Text = "Quantidade";
            // 
            // btnRegistrarMov
            // 
            this.btnRegistrarMov.AlterarStatus = true;
            this.btnRegistrarMov.BackColor = System.Drawing.Color.White;
            this.btnRegistrarMov.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegistrarMov.BackgroundImage")));
            this.btnRegistrarMov.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarMov.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnRegistrarMov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarMov.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnRegistrarMov.Location = new System.Drawing.Point(184, 376);
            this.btnRegistrarMov.Name = "btnRegistrarMov";
            this.btnRegistrarMov.Size = new System.Drawing.Size(140, 22);
            this.btnRegistrarMov.TabIndex = 6;
            this.btnRegistrarMov.Text = "Registrar Movimento";
            this.btnRegistrarMov.UseVisualStyleBackColor = true;
            this.btnRegistrarMov.Click += new System.EventHandler(this.btnRegistrarMov_Click);
            // 
            // txtSaldoAlmox
            // 
            this.txtSaldoAlmox.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtSaldoAlmox.BackColor = System.Drawing.Color.Honeydew;
            this.txtSaldoAlmox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSaldoAlmox.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtSaldoAlmox.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtSaldoAlmox.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSaldoAlmox.Limpar = true;
            this.txtSaldoAlmox.Location = new System.Drawing.Point(106, 340);
            this.txtSaldoAlmox.Name = "txtSaldoAlmox";
            this.txtSaldoAlmox.NaoAjustarEdicao = false;
            this.txtSaldoAlmox.Obrigatorio = true;
            this.txtSaldoAlmox.ObrigatorioMensagem = "Qtd. Estoque no Setor de Destino Não Pode Estar Em Branco";
            this.txtSaldoAlmox.PreValidacaoMensagem = null;
            this.txtSaldoAlmox.PreValidado = false;
            this.txtSaldoAlmox.ReadOnly = true;
            this.txtSaldoAlmox.SelectAllOnFocus = false;
            this.txtSaldoAlmox.Size = new System.Drawing.Size(62, 21);
            this.txtSaldoAlmox.TabIndex = 177;
            this.txtSaldoAlmox.TabStop = false;
            this.txtSaldoAlmox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldoAlmox
            // 
            this.lblSaldoAlmox.AutoSize = true;
            this.lblSaldoAlmox.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSaldoAlmox.Location = new System.Drawing.Point(16, 343);
            this.lblSaldoAlmox.Name = "lblSaldoAlmox";
            this.lblSaldoAlmox.Size = new System.Drawing.Size(88, 13);
            this.lblSaldoAlmox.TabIndex = 176;
            this.lblSaldoAlmox.Text = "Saldo Estoque";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.BackColor = System.Drawing.Color.Honeydew;
            this.cmbEmpresa.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbEmpresa.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Limpar = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(4, 23);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Obrigatorio = true;
            this.cmbEmpresa.ObrigatorioMensagem = "Obrigatório indicação do motivo";
            this.cmbEmpresa.PreValidacaoMensagem = null;
            this.cmbEmpresa.PreValidado = false;
            this.cmbEmpresa.Size = new System.Drawing.Size(191, 21);
            this.cmbEmpresa.TabIndex = 1;
            this.cmbEmpresa.Text = "<Selecione>";
            this.cmbEmpresa.SelectionChangeCommitted += new System.EventHandler(this.cmbEmpresa_SelectionChangeCommitted);
            // 
            // grbSetorMov
            // 
            this.grbSetorMov.Controls.Add(this.rbFarm);
            this.grbSetorMov.Controls.Add(this.rbAlmox);
            this.grbSetorMov.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSetorMov.Location = new System.Drawing.Point(182, 327);
            this.grbSetorMov.Name = "grbSetorMov";
            this.grbSetorMov.Size = new System.Drawing.Size(189, 38);
            this.grbSetorMov.TabIndex = 179;
            this.grbSetorMov.TabStop = false;
            this.grbSetorMov.Text = "Setor Movimento";
            // 
            // rbFarm
            // 
            this.rbFarm.AutoSize = true;
            this.rbFarm.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbFarm.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbFarm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFarm.Limpar = false;
            this.rbFarm.Location = new System.Drawing.Point(110, 16);
            this.rbFarm.Name = "rbFarm";
            this.rbFarm.Obrigatorio = false;
            this.rbFarm.ObrigatorioMensagem = null;
            this.rbFarm.PreValidacaoMensagem = null;
            this.rbFarm.PreValidado = false;
            this.rbFarm.Size = new System.Drawing.Size(77, 17);
            this.rbFarm.TabIndex = 1;
            this.rbFarm.Text = "Farmácia";
            this.rbFarm.UseVisualStyleBackColor = true;
            this.rbFarm.Click += new System.EventHandler(this.rbFarm_Click);
            // 
            // rbAlmox
            // 
            this.rbAlmox.AutoSize = true;
            this.rbAlmox.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbAlmox.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.rbAlmox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAlmox.Limpar = false;
            this.rbAlmox.Location = new System.Drawing.Point(6, 16);
            this.rbAlmox.Name = "rbAlmox";
            this.rbAlmox.Obrigatorio = false;
            this.rbAlmox.ObrigatorioMensagem = null;
            this.rbAlmox.PreValidacaoMensagem = null;
            this.rbAlmox.PreValidado = false;
            this.rbAlmox.Size = new System.Drawing.Size(101, 17);
            this.rbAlmox.TabIndex = 0;
            this.rbAlmox.Text = "Almoxarifado";
            this.rbAlmox.UseVisualStyleBackColor = true;
            this.rbAlmox.Click += new System.EventHandler(this.rbAlmox_Click);
            // 
            // txtDescricaoNovaEmpresa
            // 
            this.txtDescricaoNovaEmpresa.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoNovaEmpresa.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoNovaEmpresa.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDescricaoNovaEmpresa.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDescricaoNovaEmpresa.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDescricaoNovaEmpresa.Limpar = true;
            this.txtDescricaoNovaEmpresa.Location = new System.Drawing.Point(4, 55);
            this.txtDescricaoNovaEmpresa.MaxLength = 50;
            this.txtDescricaoNovaEmpresa.Name = "txtDescricaoNovaEmpresa";
            this.txtDescricaoNovaEmpresa.NaoAjustarEdicao = true;
            this.txtDescricaoNovaEmpresa.Obrigatorio = true;
            this.txtDescricaoNovaEmpresa.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDescricaoNovaEmpresa.PreValidacaoMensagem = null;
            this.txtDescricaoNovaEmpresa.PreValidado = false;
            this.txtDescricaoNovaEmpresa.SelectAllOnFocus = false;
            this.txtDescricaoNovaEmpresa.Size = new System.Drawing.Size(191, 21);
            this.txtDescricaoNovaEmpresa.TabIndex = 3;
            this.txtDescricaoNovaEmpresa.TabStop = false;
            this.txtDescricaoNovaEmpresa.Visible = false;
            // 
            // btnNovaEmpresa
            // 
            this.btnNovaEmpresa.AlterarStatus = true;
            this.btnNovaEmpresa.BackColor = System.Drawing.Color.White;
            this.btnNovaEmpresa.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde_botao;
            this.btnNovaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNovaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovaEmpresa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnNovaEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaEmpresa.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnNovaEmpresa.Location = new System.Drawing.Point(201, 22);
            this.btnNovaEmpresa.Name = "btnNovaEmpresa";
            this.btnNovaEmpresa.Size = new System.Drawing.Size(22, 22);
            this.btnNovaEmpresa.TabIndex = 2;
            this.btnNovaEmpresa.Text = "+";
            this.btnNovaEmpresa.UseVisualStyleBackColor = true;
            this.btnNovaEmpresa.Click += new System.EventHandler(this.btnNovaEmpresa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.btnNovaEmpresa);
            this.groupBox2.Controls.Add(this.txtDescricaoNovaEmpresa);
            this.groupBox2.Controls.Add(this.cmbEmpresa);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(405, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 89);
            this.groupBox2.TabIndex = 182;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Empresa";
            // 
            // btnSalvar
            // 
            this.btnSalvar.AlterarStatus = true;
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.disk;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(201, 56);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(18, 18);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Visible = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FrmEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 414);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbSetorMov);
            this.Controls.Add(this.txtSaldoAlmox);
            this.Controls.Add(this.lblSaldoAlmox);
            this.Controls.Add(this.btnRegistrarMov);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.hacLabel9);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbEmprestimo);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmEmprestimo";
            this.Text = "Empréstimo";
            this.Load += new System.EventHandler(this.FrmEmprestimo_Load);
            this.grbConcedido.ResumeLayout(false);
            this.grbConcedido.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbEmprestimo.ResumeLayout(false);
            this.grbTP.ResumeLayout(false);
            this.grbTP.PerformLayout();
            this.grbSaidaProduto.ResumeLayout(false);
            this.grbSaidaProduto.PerformLayout();
            this.grbEntradaProduto.ResumeLayout(false);
            this.grbEntradaProduto.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.grbProduto.ResumeLayout(false);
            this.grbProduto.PerformLayout();
            this.grbSetorMov.ResumeLayout(false);
            this.grbSetorMov.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox grbConcedido;
        private SGS.Componentes.HacRadioButton rbEntradaDevolucao;
        private SGS.Componentes.HacRadioButton rbSaidaConcedido;
        private System.Windows.Forms.GroupBox groupBox1;
        private SGS.Componentes.HacRadioButton rbSaidaDevolucao;
        private SGS.Componentes.HacRadioButton rbEntradaObtido;
        private System.Windows.Forms.GroupBox grbEmprestimo;
        private System.Windows.Forms.GroupBox grbTP;
        private SGS.Componentes.HacRadioButton rbMedicamento;
        private SGS.Componentes.HacRadioButton rbMaterial;
        private SGS.Componentes.HacTextBox txtCodBarra;
        private System.Windows.Forms.Label label3;
        private SGS.Componentes.HacTextBox txtValidade;
        private SGS.Componentes.HacTextBox txtNumLoteFab;
        private SGS.Componentes.HacLabel hacLabel11;
        private SGS.Componentes.HacLabel hacLabel13;
        private System.Windows.Forms.GroupBox grbSaidaProduto;
        private System.Windows.Forms.GroupBox grbEntradaProduto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox grbProduto;
        private System.Windows.Forms.Label label1;
        private SGS.Componentes.HacTextBox txtIdProduto;
        private SGS.Componentes.HacTextBox txtDsProduto;
        private System.Windows.Forms.Label label2;
        private SGS.Componentes.HacLabel lblNumLoteFab;
        private SGS.Componentes.HacLabel hacLabel12;
        private SGS.Componentes.HacLabel lblValidade;
        private SGS.Componentes.HacLabel hacLabel7;
        private SGS.Componentes.HacLabel lblCodLote;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacTextBox txtQtde;
        private SGS.Componentes.HacLabel hacLabel9;
        private SGS.Componentes.HacButton btnRegistrarMov;
        private SGS.Componentes.HacTextBox txtSaldoAlmox;
        private SGS.Componentes.HacLabel lblSaldoAlmox;
        private SGS.Componentes.HacComboBox cmbEmpresa;
        private System.Windows.Forms.GroupBox grbSetorMov;
        private SGS.Componentes.HacRadioButton rbFarm;
        private SGS.Componentes.HacRadioButton rbAlmox;
        private SGS.Componentes.HacTextBox txtDescricaoNovaEmpresa;
        private SGS.Componentes.HacButton btnNovaEmpresa;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacButton btnSalvar;
    }
}