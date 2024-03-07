using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmManutProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManutProd));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkCobrado = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.txtTpFracao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.chkReutilizavel = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkMaterEstoque = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkBaixaAutomatica = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkFracionado = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkAtivo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtUnidControle = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtUnidVenda = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtUnidCompra = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtCodMne = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtIdRm = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbMedicamento = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbMaterial = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.txtDsProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdProduto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodAnvisa = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chkMAV = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkControlaLote = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkDiluente = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chkPadrao = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 5;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Produto";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkCobrado);
            this.groupBox9.Controls.Add(this.txtTpFracao);
            this.groupBox9.Controls.Add(this.chkReutilizavel);
            this.groupBox9.Controls.Add(this.chkMaterEstoque);
            this.groupBox9.Controls.Add(this.chkBaixaAutomatica);
            this.groupBox9.Controls.Add(this.chkFracionado);
            this.groupBox9.Enabled = false;
            this.groupBox9.Location = new System.Drawing.Point(8, 89);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(219, 87);
            this.groupBox9.TabIndex = 34;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Detalhes";
            // 
            // chkCobrado
            // 
            this.chkCobrado.AutoCheck = false;
            this.chkCobrado.AutoSize = true;
            this.chkCobrado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkCobrado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkCobrado.Limpar = true;
            this.chkCobrado.Location = new System.Drawing.Point(7, 63);
            this.chkCobrado.Name = "chkCobrado";
            this.chkCobrado.Obrigatorio = false;
            this.chkCobrado.ObrigatorioMensagem = null;
            this.chkCobrado.PreValidacaoMensagem = null;
            this.chkCobrado.PreValidado = false;
            this.chkCobrado.Size = new System.Drawing.Size(66, 17);
            this.chkCobrado.TabIndex = 142;
            this.chkCobrado.Text = "Cobrado";
            this.chkCobrado.UseVisualStyleBackColor = true;
            // 
            // txtTpFracao
            // 
            this.txtTpFracao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtTpFracao.BackColor = System.Drawing.Color.Honeydew;
            this.txtTpFracao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtTpFracao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtTpFracao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTpFracao.Limpar = true;
            this.txtTpFracao.Location = new System.Drawing.Point(114, 58);
            this.txtTpFracao.Name = "txtTpFracao";
            this.txtTpFracao.NaoAjustarEdicao = false;
            this.txtTpFracao.Obrigatorio = false;
            this.txtTpFracao.ObrigatorioMensagem = "";
            this.txtTpFracao.PreValidacaoMensagem = "";
            this.txtTpFracao.PreValidado = false;
            this.txtTpFracao.SelectAllOnFocus = false;
            this.txtTpFracao.Size = new System.Drawing.Size(100, 21);
            this.txtTpFracao.TabIndex = 133;
            // 
            // chkReutilizavel
            // 
            this.chkReutilizavel.AutoCheck = false;
            this.chkReutilizavel.AutoSize = true;
            this.chkReutilizavel.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkReutilizavel.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkReutilizavel.Limpar = true;
            this.chkReutilizavel.Location = new System.Drawing.Point(116, 39);
            this.chkReutilizavel.Name = "chkReutilizavel";
            this.chkReutilizavel.Obrigatorio = false;
            this.chkReutilizavel.ObrigatorioMensagem = null;
            this.chkReutilizavel.PreValidacaoMensagem = null;
            this.chkReutilizavel.PreValidado = false;
            this.chkReutilizavel.Size = new System.Drawing.Size(80, 17);
            this.chkReutilizavel.TabIndex = 141;
            this.chkReutilizavel.Text = "Reutilizavel";
            this.chkReutilizavel.UseVisualStyleBackColor = true;
            // 
            // chkMaterEstoque
            // 
            this.chkMaterEstoque.AutoCheck = false;
            this.chkMaterEstoque.AutoSize = true;
            this.chkMaterEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkMaterEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkMaterEstoque.Limpar = true;
            this.chkMaterEstoque.Location = new System.Drawing.Point(7, 39);
            this.chkMaterEstoque.Name = "chkMaterEstoque";
            this.chkMaterEstoque.Obrigatorio = false;
            this.chkMaterEstoque.ObrigatorioMensagem = null;
            this.chkMaterEstoque.PreValidacaoMensagem = null;
            this.chkMaterEstoque.PreValidado = false;
            this.chkMaterEstoque.Size = new System.Drawing.Size(101, 17);
            this.chkMaterEstoque.TabIndex = 140;
            this.chkMaterEstoque.Text = "Manter Estoque";
            this.chkMaterEstoque.UseVisualStyleBackColor = true;
            // 
            // chkBaixaAutomatica
            // 
            this.chkBaixaAutomatica.AutoCheck = false;
            this.chkBaixaAutomatica.AutoSize = true;
            this.chkBaixaAutomatica.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkBaixaAutomatica.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkBaixaAutomatica.Limpar = true;
            this.chkBaixaAutomatica.Location = new System.Drawing.Point(7, 16);
            this.chkBaixaAutomatica.Name = "chkBaixaAutomatica";
            this.chkBaixaAutomatica.Obrigatorio = false;
            this.chkBaixaAutomatica.ObrigatorioMensagem = null;
            this.chkBaixaAutomatica.PreValidacaoMensagem = null;
            this.chkBaixaAutomatica.PreValidado = false;
            this.chkBaixaAutomatica.Size = new System.Drawing.Size(108, 17);
            this.chkBaixaAutomatica.TabIndex = 12;
            this.chkBaixaAutomatica.Text = "Baixa Automática";
            this.chkBaixaAutomatica.UseVisualStyleBackColor = true;
            // 
            // chkFracionado
            // 
            this.chkFracionado.AutoCheck = false;
            this.chkFracionado.AutoSize = true;
            this.chkFracionado.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkFracionado.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkFracionado.Limpar = true;
            this.chkFracionado.Location = new System.Drawing.Point(116, 16);
            this.chkFracionado.Name = "chkFracionado";
            this.chkFracionado.Obrigatorio = false;
            this.chkFracionado.ObrigatorioMensagem = null;
            this.chkFracionado.PreValidacaoMensagem = null;
            this.chkFracionado.PreValidado = false;
            this.chkFracionado.Size = new System.Drawing.Size(79, 17);
            this.chkFracionado.TabIndex = 10;
            this.chkFracionado.Text = "Fracionado";
            this.chkFracionado.UseVisualStyleBackColor = true;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoCheck = false;
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkAtivo.Enabled = false;
            this.chkAtivo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivo.Limpar = true;
            this.chkAtivo.Location = new System.Drawing.Point(689, 64);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Obrigatorio = false;
            this.chkAtivo.ObrigatorioMensagem = null;
            this.chkAtivo.PreValidacaoMensagem = null;
            this.chkAtivo.PreValidado = false;
            this.chkAtivo.Size = new System.Drawing.Size(63, 17);
            this.chkAtivo.TabIndex = 11;
            this.chkAtivo.Text = "ATIVO";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtUnidControle);
            this.groupBox8.Controls.Add(this.txtUnidVenda);
            this.groupBox8.Controls.Add(this.txtUnidCompra);
            this.groupBox8.Controls.Add(this.hacLabel2);
            this.groupBox8.Controls.Add(this.hacLabel6);
            this.groupBox8.Controls.Add(this.hacLabel5);
            this.groupBox8.Location = new System.Drawing.Point(238, 139);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(539, 37);
            this.groupBox8.TabIndex = 35;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Unidades de Medida";
            // 
            // txtUnidControle
            // 
            this.txtUnidControle.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidControle.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidControle.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidControle.Enabled = false;
            this.txtUnidControle.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidControle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidControle.Limpar = true;
            this.txtUnidControle.Location = new System.Drawing.Point(428, 15);
            this.txtUnidControle.Name = "txtUnidControle";
            this.txtUnidControle.NaoAjustarEdicao = false;
            this.txtUnidControle.Obrigatorio = false;
            this.txtUnidControle.ObrigatorioMensagem = "";
            this.txtUnidControle.PreValidacaoMensagem = "";
            this.txtUnidControle.PreValidado = false;
            this.txtUnidControle.ReadOnly = true;
            this.txtUnidControle.SelectAllOnFocus = false;
            this.txtUnidControle.Size = new System.Drawing.Size(100, 18);
            this.txtUnidControle.TabIndex = 5;
            // 
            // txtUnidVenda
            // 
            this.txtUnidVenda.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidVenda.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidVenda.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidVenda.Enabled = false;
            this.txtUnidVenda.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidVenda.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidVenda.Limpar = true;
            this.txtUnidVenda.Location = new System.Drawing.Point(235, 15);
            this.txtUnidVenda.Name = "txtUnidVenda";
            this.txtUnidVenda.NaoAjustarEdicao = false;
            this.txtUnidVenda.Obrigatorio = false;
            this.txtUnidVenda.ObrigatorioMensagem = "";
            this.txtUnidVenda.PreValidacaoMensagem = "";
            this.txtUnidVenda.PreValidado = false;
            this.txtUnidVenda.ReadOnly = true;
            this.txtUnidVenda.SelectAllOnFocus = false;
            this.txtUnidVenda.Size = new System.Drawing.Size(130, 18);
            this.txtUnidVenda.TabIndex = 4;
            // 
            // txtUnidCompra
            // 
            this.txtUnidCompra.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidCompra.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidCompra.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidCompra.Enabled = false;
            this.txtUnidCompra.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidCompra.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidCompra.Limpar = true;
            this.txtUnidCompra.Location = new System.Drawing.Point(58, 15);
            this.txtUnidCompra.Name = "txtUnidCompra";
            this.txtUnidCompra.NaoAjustarEdicao = false;
            this.txtUnidCompra.Obrigatorio = false;
            this.txtUnidCompra.ObrigatorioMensagem = "";
            this.txtUnidCompra.PreValidacaoMensagem = "";
            this.txtUnidCompra.PreValidado = false;
            this.txtUnidCompra.ReadOnly = true;
            this.txtUnidCompra.SelectAllOnFocus = false;
            this.txtUnidCompra.Size = new System.Drawing.Size(130, 18);
            this.txtUnidCompra.TabIndex = 3;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(371, 18);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(56, 13);
            this.hacLabel2.TabIndex = 2;
            this.hacLabel2.Text = "Controle";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(193, 18);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(42, 13);
            this.hacLabel6.TabIndex = 1;
            this.hacLabel6.Text = "Venda";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(5, 18);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(53, 13);
            this.hacLabel5.TabIndex = 0;
            this.hacLabel5.Text = "Compra";
            // 
            // txtCodMne
            // 
            this.txtCodMne.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodMne.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodMne.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCodMne.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtCodMne.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodMne.Limpar = true;
            this.txtCodMne.Location = new System.Drawing.Point(238, 58);
            this.txtCodMne.Name = "txtCodMne";
            this.txtCodMne.NaoAjustarEdicao = false;
            this.txtCodMne.Obrigatorio = false;
            this.txtCodMne.ObrigatorioMensagem = "";
            this.txtCodMne.PreValidacaoMensagem = "";
            this.txtCodMne.PreValidado = false;
            this.txtCodMne.SelectAllOnFocus = false;
            this.txtCodMne.Size = new System.Drawing.Size(116, 21);
            this.txtCodMne.TabIndex = 46;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(172, 63);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(47, 13);
            this.hacLabel4.TabIndex = 45;
            this.hacLabel4.Text = "Código";
            // 
            // txtIdRm
            // 
            this.txtIdRm.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtIdRm.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdRm.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtIdRm.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtIdRm.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdRm.Limpar = true;
            this.txtIdRm.Location = new System.Drawing.Point(60, 58);
            this.txtIdRm.Name = "txtIdRm";
            this.txtIdRm.NaoAjustarEdicao = false;
            this.txtIdRm.Obrigatorio = false;
            this.txtIdRm.ObrigatorioMensagem = "";
            this.txtIdRm.PreValidacaoMensagem = "";
            this.txtIdRm.PreValidado = false;
            this.txtIdRm.SelectAllOnFocus = false;
            this.txtIdRm.Size = new System.Drawing.Size(100, 21);
            this.txtIdRm.TabIndex = 44;
            // 
            // hacLabel8
            // 
            this.hacLabel8.AutoSize = true;
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(5, 63);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(42, 13);
            this.hacLabel8.TabIndex = 43;
            this.hacLabel8.Text = "ID RM";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbMedicamento);
            this.groupBox3.Controls.Add(this.rbMaterial);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(238, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 38);
            this.groupBox3.TabIndex = 128;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo do Produto";
            // 
            // rbMedicamento
            // 
            this.rbMedicamento.AutoCheck = false;
            this.rbMedicamento.AutoSize = true;
            this.rbMedicamento.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbMedicamento.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbMedicamento.Limpar = true;
            this.rbMedicamento.Location = new System.Drawing.Point(75, 17);
            this.rbMedicamento.Name = "rbMedicamento";
            this.rbMedicamento.Obrigatorio = false;
            this.rbMedicamento.ObrigatorioMensagem = null;
            this.rbMedicamento.PreValidacaoMensagem = null;
            this.rbMedicamento.PreValidado = false;
            this.rbMedicamento.Size = new System.Drawing.Size(89, 17);
            this.rbMedicamento.TabIndex = 1;
            this.rbMedicamento.TabStop = true;
            this.rbMedicamento.Text = "Medicamento";
            this.rbMedicamento.UseVisualStyleBackColor = true;
            // 
            // rbMaterial
            // 
            this.rbMaterial.AutoCheck = false;
            this.rbMaterial.AutoSize = true;
            this.rbMaterial.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbMaterial.Enabled = false;
            this.rbMaterial.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbMaterial.Limpar = true;
            this.rbMaterial.Location = new System.Drawing.Point(7, 17);
            this.rbMaterial.Name = "rbMaterial";
            this.rbMaterial.Obrigatorio = false;
            this.rbMaterial.ObrigatorioMensagem = null;
            this.rbMaterial.PreValidacaoMensagem = null;
            this.rbMaterial.PreValidado = false;
            this.rbMaterial.Size = new System.Drawing.Size(62, 17);
            this.rbMaterial.TabIndex = 0;
            this.rbMaterial.TabStop = true;
            this.rbMaterial.Text = "Material";
            this.rbMaterial.UseVisualStyleBackColor = true;
            // 
            // txtDsProduto
            // 
            this.txtDsProduto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsProduto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsProduto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDsProduto.Enabled = false;
            this.txtDsProduto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsProduto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsProduto.Limpar = true;
            this.txtDsProduto.Location = new System.Drawing.Point(238, 31);
            this.txtDsProduto.Name = "txtDsProduto";
            this.txtDsProduto.NaoAjustarEdicao = false;
            this.txtDsProduto.Obrigatorio = true;
            this.txtDsProduto.ObrigatorioMensagem = "Descrição do Produto Não Pode Estar Em Branco";
            this.txtDsProduto.PreValidacaoMensagem = null;
            this.txtDsProduto.PreValidado = false;
            this.txtDsProduto.SelectAllOnFocus = false;
            this.txtDsProduto.Size = new System.Drawing.Size(505, 21);
            this.txtDsProduto.TabIndex = 132;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 131;
            this.label2.Text = "Descrição";
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
            this.txtIdProduto.Location = new System.Drawing.Point(60, 32);
            this.txtIdProduto.MaxLength = 50;
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.NaoAjustarEdicao = false;
            this.txtIdProduto.Obrigatorio = false;
            this.txtIdProduto.ObrigatorioMensagem = null;
            this.txtIdProduto.PreValidacaoMensagem = null;
            this.txtIdProduto.PreValidado = false;
            this.txtIdProduto.SelectAllOnFocus = false;
            this.txtIdProduto.Size = new System.Drawing.Size(100, 21);
            this.txtIdProduto.TabIndex = 130;
            this.txtIdProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "ID SGS";
            // 
            // txtCodAnvisa
            // 
            this.txtCodAnvisa.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtCodAnvisa.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodAnvisa.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtCodAnvisa.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtCodAnvisa.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtCodAnvisa.Limpar = true;
            this.txtCodAnvisa.Location = new System.Drawing.Point(448, 58);
            this.txtCodAnvisa.Name = "txtCodAnvisa";
            this.txtCodAnvisa.NaoAjustarEdicao = false;
            this.txtCodAnvisa.Obrigatorio = false;
            this.txtCodAnvisa.ObrigatorioMensagem = "";
            this.txtCodAnvisa.PreValidacaoMensagem = "";
            this.txtCodAnvisa.PreValidado = false;
            this.txtCodAnvisa.ReadOnly = true;
            this.txtCodAnvisa.SelectAllOnFocus = false;
            this.txtCodAnvisa.Size = new System.Drawing.Size(116, 21);
            this.txtCodAnvisa.TabIndex = 2;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(368, 63);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(76, 13);
            this.hacLabel1.TabIndex = 133;
            this.hacLabel1.Text = "Cod. Anvisa";
            // 
            // chkMAV
            // 
            this.chkMAV.AutoCheck = false;
            this.chkMAV.AutoSize = true;
            this.chkMAV.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkMAV.Enabled = false;
            this.chkMAV.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkMAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMAV.Limpar = true;
            this.chkMAV.Location = new System.Drawing.Point(419, 106);
            this.chkMAV.Name = "chkMAV";
            this.chkMAV.Obrigatorio = false;
            this.chkMAV.ObrigatorioMensagem = null;
            this.chkMAV.PreValidacaoMensagem = null;
            this.chkMAV.PreValidado = false;
            this.chkMAV.Size = new System.Drawing.Size(53, 17);
            this.chkMAV.TabIndex = 135;
            this.chkMAV.Text = "MAR";
            this.chkMAV.UseVisualStyleBackColor = true;
            this.chkMAV.Visible = false;
            // 
            // chkControlaLote
            // 
            this.chkControlaLote.AutoCheck = false;
            this.chkControlaLote.AutoSize = true;
            this.chkControlaLote.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkControlaLote.Enabled = false;
            this.chkControlaLote.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkControlaLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkControlaLote.Limpar = true;
            this.chkControlaLote.Location = new System.Drawing.Point(480, 106);
            this.chkControlaLote.Name = "chkControlaLote";
            this.chkControlaLote.Obrigatorio = false;
            this.chkControlaLote.ObrigatorioMensagem = null;
            this.chkControlaLote.PreValidacaoMensagem = null;
            this.chkControlaLote.PreValidado = false;
            this.chkControlaLote.Size = new System.Drawing.Size(129, 17);
            this.chkControlaLote.TabIndex = 136;
            this.chkControlaLote.Text = "CONTROLA LOTE";
            this.chkControlaLote.UseVisualStyleBackColor = true;
            // 
            // chkDiluente
            // 
            this.chkDiluente.AutoSize = true;
            this.chkDiluente.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkDiluente.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkDiluente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDiluente.Limpar = true;
            this.chkDiluente.Location = new System.Drawing.Point(689, 106);
            this.chkDiluente.Name = "chkDiluente";
            this.chkDiluente.Obrigatorio = false;
            this.chkDiluente.ObrigatorioMensagem = null;
            this.chkDiluente.PreValidacaoMensagem = null;
            this.chkDiluente.PreValidado = false;
            this.chkDiluente.Size = new System.Drawing.Size(88, 17);
            this.chkDiluente.TabIndex = 1;
            this.chkDiluente.Text = "DILUENTE";
            this.chkDiluente.UseVisualStyleBackColor = true;
            this.chkDiluente.Click += new System.EventHandler(this.chkDiluente_Click);
            // 
            // chkPadrao
            // 
            this.chkPadrao.AutoCheck = false;
            this.chkPadrao.AutoSize = true;
            this.chkPadrao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkPadrao.Enabled = false;
            this.chkPadrao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chkPadrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPadrao.Limpar = true;
            this.chkPadrao.Location = new System.Drawing.Point(602, 64);
            this.chkPadrao.Name = "chkPadrao";
            this.chkPadrao.Obrigatorio = false;
            this.chkPadrao.ObrigatorioMensagem = null;
            this.chkPadrao.PreValidacaoMensagem = null;
            this.chkPadrao.PreValidado = false;
            this.chkPadrao.Size = new System.Drawing.Size(77, 17);
            this.chkPadrao.TabIndex = 137;
            this.chkPadrao.Text = "PADRÃO";
            this.chkPadrao.UseVisualStyleBackColor = true;
            // 
            // FrmManutProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 189);
            this.Controls.Add(this.chkPadrao);
            this.Controls.Add(this.chkDiluente);
            this.Controls.Add(this.chkControlaLote);
            this.Controls.Add(this.chkMAV);
            this.Controls.Add(this.txtCodAnvisa);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.txtDsProduto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtCodMne);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.txtIdRm);
            this.Controls.Add(this.hacLabel8);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmManutProd";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmManutProd_Load);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox9;
        private HacCheckBox chkBaixaAutomatica;
        private HacCheckBox chkAtivo;
        private HacCheckBox chkFracionado;
        private System.Windows.Forms.GroupBox groupBox8;
        private HacTextBox txtUnidControle;
        private HacTextBox txtUnidVenda;
        private HacTextBox txtUnidCompra;
        private HacLabel hacLabel2;
        private HacLabel hacLabel6;
        private HacLabel hacLabel5;
        private HacTextBox txtCodMne;
        private HacLabel hacLabel4;
        private HacTextBox txtIdRm;
        private HacLabel hacLabel8;
        private System.Windows.Forms.GroupBox groupBox3;
        private HacRadioButton rbMedicamento;
        private HacRadioButton rbMaterial;
        private HacTextBox txtDsProduto;
        private System.Windows.Forms.Label label2;
        private HacTextBox txtIdProduto;
        private System.Windows.Forms.Label label1;
        private HacCheckBox chkReutilizavel;
        private HacCheckBox chkMaterEstoque;
        private HacTextBox txtTpFracao;
        private HacTextBox txtCodAnvisa;
        private HacLabel hacLabel1;
        private HacCheckBox chkCobrado;
        private HacCheckBox chkMAV;
        private HacCheckBox chkControlaLote;
        private HacCheckBox chkDiluente;
        private HacCheckBox chkPadrao;
    }
}