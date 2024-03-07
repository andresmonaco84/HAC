using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmQtdMatMed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQtdMatMed));
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDsMatMed = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtQtde = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.btnOk = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnCancelar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.lblEstoque = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtEstoqueUnidade = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblUnidVenda = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtUnidadeDeVenda = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.lblTpFracao = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtTpFracao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.cmbPeriodoGerar = new HospitalAnaCosta.SGS.Componentes.HacPeriodoHrsGerarPedido(this.components);
            this.lblPeriodoGerar = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel1.Controls.Add(this.hacLabel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 24);
            this.panel1.TabIndex = 67;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.ForeColor = System.Drawing.Color.ForestGreen;
            this.hacLabel7.Location = new System.Drawing.Point(6, 4);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(311, 13);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Digitação de Qtd. de Materiais e Medicamentos";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(12, 39);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(63, 13);
            this.hacLabel1.TabIndex = 68;
            this.hacLabel1.Text = "Descrição";
            // 
            // txtDsMatMed
            // 
            this.txtDsMatMed.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDsMatMed.BackColor = System.Drawing.Color.Honeydew;
            this.txtDsMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDsMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDsMatMed.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDsMatMed.Limpar = false;
            this.txtDsMatMed.Location = new System.Drawing.Point(87, 36);
            this.txtDsMatMed.Name = "txtDsMatMed";
            this.txtDsMatMed.NaoAjustarEdicao = false;
            this.txtDsMatMed.Obrigatorio = false;
            this.txtDsMatMed.ObrigatorioMensagem = null;
            this.txtDsMatMed.PreValidacaoMensagem = null;
            this.txtDsMatMed.PreValidado = false;
            this.txtDsMatMed.ReadOnly = true;
            this.txtDsMatMed.SelectAllOnFocus = false;
            this.txtDsMatMed.Size = new System.Drawing.Size(372, 21);
            this.txtDsMatMed.TabIndex = 69;
            this.txtDsMatMed.TabStop = false;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(12, 72);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(72, 13);
            this.hacLabel2.TabIndex = 70;
            this.hacLabel2.Text = "Quantidade";
            // 
            // txtQtde
            // 
            this.txtQtde.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtQtde.BackColor = System.Drawing.Color.Honeydew;
            this.txtQtde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtde.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtQtde.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtQtde.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtQtde.Limpar = false;
            this.txtQtde.Location = new System.Drawing.Point(87, 69);
            this.txtQtde.MaxLength = 5;
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.NaoAjustarEdicao = false;
            this.txtQtde.Obrigatorio = false;
            this.txtQtde.ObrigatorioMensagem = null;
            this.txtQtde.PreValidacaoMensagem = null;
            this.txtQtde.PreValidado = false;
            this.txtQtde.SelectAllOnFocus = false;
            this.txtQtde.Size = new System.Drawing.Size(75, 21);
            this.txtQtde.TabIndex = 71;
            // 
            // btnOk
            // 
            this.btnOk.AlterarStatus = true;
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(144, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 22);
            this.btnOk.TabIndex = 72;
            this.btnOk.Text = "Confirmar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AlterarStatus = true;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(255, 137);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 22);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblEstoque.Location = new System.Drawing.Point(323, 72);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(39, 13);
            this.lblEstoque.TabIndex = 74;
            this.lblEstoque.Text = "Saldo";
            // 
            // txtEstoqueUnidade
            // 
            this.txtEstoqueUnidade.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtEstoqueUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.txtEstoqueUnidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstoqueUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtEstoqueUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtEstoqueUnidade.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtEstoqueUnidade.Limpar = false;
            this.txtEstoqueUnidade.Location = new System.Drawing.Point(368, 69);
            this.txtEstoqueUnidade.Name = "txtEstoqueUnidade";
            this.txtEstoqueUnidade.NaoAjustarEdicao = false;
            this.txtEstoqueUnidade.Obrigatorio = false;
            this.txtEstoqueUnidade.ObrigatorioMensagem = null;
            this.txtEstoqueUnidade.PreValidacaoMensagem = null;
            this.txtEstoqueUnidade.PreValidado = false;
            this.txtEstoqueUnidade.ReadOnly = true;
            this.txtEstoqueUnidade.SelectAllOnFocus = false;
            this.txtEstoqueUnidade.Size = new System.Drawing.Size(91, 21);
            this.txtEstoqueUnidade.TabIndex = 75;
            this.txtEstoqueUnidade.TabStop = false;
            // 
            // lblUnidVenda
            // 
            this.lblUnidVenda.AutoSize = true;
            this.lblUnidVenda.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblUnidVenda.Location = new System.Drawing.Point(168, 72);
            this.lblUnidVenda.Name = "lblUnidVenda";
            this.lblUnidVenda.Size = new System.Drawing.Size(45, 13);
            this.lblUnidVenda.TabIndex = 77;
            this.lblUnidVenda.Text = "Fração";
            // 
            // txtUnidadeDeVenda
            // 
            this.txtUnidadeDeVenda.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidadeDeVenda.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidadeDeVenda.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidadeDeVenda.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidadeDeVenda.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidadeDeVenda.Limpar = false;
            this.txtUnidadeDeVenda.Location = new System.Drawing.Point(217, 69);
            this.txtUnidadeDeVenda.Name = "txtUnidadeDeVenda";
            this.txtUnidadeDeVenda.NaoAjustarEdicao = false;
            this.txtUnidadeDeVenda.Obrigatorio = false;
            this.txtUnidadeDeVenda.ObrigatorioMensagem = "";
            this.txtUnidadeDeVenda.PreValidacaoMensagem = "";
            this.txtUnidadeDeVenda.PreValidado = false;
            this.txtUnidadeDeVenda.SelectAllOnFocus = false;
            this.txtUnidadeDeVenda.Size = new System.Drawing.Size(100, 21);
            this.txtUnidadeDeVenda.TabIndex = 78;
            // 
            // lblTpFracao
            // 
            this.lblTpFracao.AutoSize = true;
            this.lblTpFracao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTpFracao.Location = new System.Drawing.Point(12, 102);
            this.lblTpFracao.Name = "lblTpFracao";
            this.lblTpFracao.Size = new System.Drawing.Size(50, 13);
            this.lblTpFracao.TabIndex = 79;
            this.lblTpFracao.Text = "Fração:";
            this.lblTpFracao.Visible = false;
            // 
            // txtTpFracao
            // 
            this.txtTpFracao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtTpFracao.BackColor = System.Drawing.Color.Honeydew;
            this.txtTpFracao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtTpFracao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtTpFracao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTpFracao.Limpar = true;
            this.txtTpFracao.Location = new System.Drawing.Point(87, 99);
            this.txtTpFracao.Name = "txtTpFracao";
            this.txtTpFracao.NaoAjustarEdicao = false;
            this.txtTpFracao.Obrigatorio = false;
            this.txtTpFracao.ObrigatorioMensagem = "";
            this.txtTpFracao.PreValidacaoMensagem = "";
            this.txtTpFracao.PreValidado = false;
            this.txtTpFracao.SelectAllOnFocus = false;
            this.txtTpFracao.Size = new System.Drawing.Size(75, 21);
            this.txtTpFracao.TabIndex = 80;
            this.txtTpFracao.Visible = false;
            // 
            // cmbPeriodoGerar
            // 
            this.cmbPeriodoGerar.BackColor = System.Drawing.Color.Honeydew;
            this.cmbPeriodoGerar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodoGerar.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbPeriodoGerar.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbPeriodoGerar.FormattingEnabled = true;
            this.cmbPeriodoGerar.Limpar = true;
            this.cmbPeriodoGerar.Location = new System.Drawing.Point(405, 102);
            this.cmbPeriodoGerar.Name = "cmbPeriodoGerar";
            this.cmbPeriodoGerar.Obrigatorio = true;
            this.cmbPeriodoGerar.ObrigatorioMensagem = "Selecione o Período Gerar";
            this.cmbPeriodoGerar.PreValidacaoMensagem = null;
            this.cmbPeriodoGerar.PreValidado = false;
            this.cmbPeriodoGerar.Size = new System.Drawing.Size(54, 21);
            this.cmbPeriodoGerar.TabIndex = 131;
            this.cmbPeriodoGerar.Visible = false;
            // 
            // lblPeriodoGerar
            // 
            this.lblPeriodoGerar.AutoSize = true;
            this.lblPeriodoGerar.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPeriodoGerar.Location = new System.Drawing.Point(319, 105);
            this.lblPeriodoGerar.Name = "lblPeriodoGerar";
            this.lblPeriodoGerar.Size = new System.Drawing.Size(83, 13);
            this.lblPeriodoGerar.TabIndex = 132;
            this.lblPeriodoGerar.Text = "Período Dose";
            this.lblPeriodoGerar.Visible = false;
            // 
            // FrmQtdMatMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(505, 180);
            this.Controls.Add(this.cmbPeriodoGerar);
            this.Controls.Add(this.lblPeriodoGerar);
            this.Controls.Add(this.txtTpFracao);
            this.Controls.Add(this.lblTpFracao);
            this.Controls.Add(this.txtUnidadeDeVenda);
            this.Controls.Add(this.lblUnidVenda);
            this.Controls.Add(this.txtEstoqueUnidade);
            this.Controls.Add(this.lblEstoque);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.txtDsMatMed);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmQtdMatMed";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQtdMatMed_FormClosing);
            this.Load += new System.EventHandler(this.FrmQtdMatMed_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private HacLabel hacLabel7;
        private HacLabel hacLabel1;
        private HacTextBox txtDsMatMed;
        private HacLabel hacLabel2;
        private HacTextBox txtQtde;
        private HacButton btnOk;
        private HacButton btnCancelar;
        private HacLabel lblEstoque;
        private HacTextBox txtEstoqueUnidade;
        private HacLabel lblUnidVenda;
        private HacTextBox txtUnidadeDeVenda;
        private HacLabel lblTpFracao;
        private HacTextBox txtTpFracao;
        private HacPeriodoHrsGerarPedido cmbPeriodoGerar;
        private HacLabel lblPeriodoGerar;
    }
}
