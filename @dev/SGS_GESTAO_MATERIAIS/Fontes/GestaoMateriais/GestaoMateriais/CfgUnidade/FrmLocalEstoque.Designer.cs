using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmTiposCCusto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTiposCCusto));
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDescTipoCCusto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtIdtTipoCCusto = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.cmbSetor = new HospitalAnaCosta.SGS.Componentes.HacCmbSetor(this.components);
            this.cmbLocal = new HospitalAnaCosta.SGS.Componentes.HacCmbLocal(this.components);
            this.cmbUnidade = new HospitalAnaCosta.SGS.Componentes.HacCmbUnidade(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbLocalEstoque = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chbAtivo = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtTpMovimentacao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "Excluir";
            this.dataGridViewImageColumn2.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.ToolTipText = "Excluir Linha";
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "Excluir";
            this.dataGridViewImageColumn1.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.ToolTipText = "Excluir Linha";
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 0;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Cadastro de Locais de Estoque";
            this.tsHac.CancelarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_CancelarClick);
            this.tsHac.NovoClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_NovoClick);
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(187, 67);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(63, 13);
            this.hacLabel5.TabIndex = 131;
            this.hacLabel5.Text = "Descrição";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(8, 67);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(47, 13);
            this.hacLabel4.TabIndex = 130;
            this.hacLabel4.Text = "Código";
            // 
            // txtDescTipoCCusto
            // 
            this.txtDescTipoCCusto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtDescTipoCCusto.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescTipoCCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescTipoCCusto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtDescTipoCCusto.Enabled = false;
            this.txtDescTipoCCusto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtDescTipoCCusto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDescTipoCCusto.Limpar = true;
            this.txtDescTipoCCusto.Location = new System.Drawing.Point(256, 64);
            this.txtDescTipoCCusto.Name = "txtDescTipoCCusto";
            this.txtDescTipoCCusto.NaoAjustarEdicao = false;
            this.txtDescTipoCCusto.Obrigatorio = true;
            this.txtDescTipoCCusto.ObrigatorioMensagem = "Digite a Descrição";
            this.txtDescTipoCCusto.PreValidacaoMensagem = null;
            this.txtDescTipoCCusto.PreValidado = false;
            this.txtDescTipoCCusto.SelectAllOnFocus = false;
            this.txtDescTipoCCusto.Size = new System.Drawing.Size(404, 21);
            this.txtDescTipoCCusto.TabIndex = 129;
            // 
            // txtIdtTipoCCusto
            // 
            this.txtIdtTipoCCusto.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtIdtTipoCCusto.BackColor = System.Drawing.Color.Honeydew;
            this.txtIdtTipoCCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdtTipoCCusto.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtIdtTipoCCusto.Enabled = false;
            this.txtIdtTipoCCusto.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtIdtTipoCCusto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtIdtTipoCCusto.Limpar = true;
            this.txtIdtTipoCCusto.Location = new System.Drawing.Point(79, 64);
            this.txtIdtTipoCCusto.MaxLength = 10;
            this.txtIdtTipoCCusto.Name = "txtIdtTipoCCusto";
            this.txtIdtTipoCCusto.NaoAjustarEdicao = false;
            this.txtIdtTipoCCusto.Obrigatorio = false;
            this.txtIdtTipoCCusto.ObrigatorioMensagem = null;
            this.txtIdtTipoCCusto.PreValidacaoMensagem = null;
            this.txtIdtTipoCCusto.PreValidado = false;
            this.txtIdtTipoCCusto.SelectAllOnFocus = false;
            this.txtIdtTipoCCusto.Size = new System.Drawing.Size(95, 21);
            this.txtIdtTipoCCusto.TabIndex = 128;
            this.txtIdtTipoCCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSetor
            // 
            this.cmbSetor.BackColor = System.Drawing.Color.Honeydew;
            this.cmbSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbSetor.Internacao = true;
            this.cmbSetor.Limpar = true;
            this.cmbSetor.Location = new System.Drawing.Point(560, 132);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.NomeComboLocal = null;
            this.cmbSetor.Obrigatorio = true;
            this.cmbSetor.ObrigatorioMensagem = "Selecione um Setor";
            this.cmbSetor.PreValidacaoMensagem = "";
            this.cmbSetor.PreValidado = false;
            this.cmbSetor.SetorUsuario = false;
            this.cmbSetor.Size = new System.Drawing.Size(210, 21);
            this.cmbSetor.TabIndex = 127;
            this.cmbSetor.Text = "<Selecione>";
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Limpar = true;
            this.cmbLocal.Location = new System.Drawing.Point(325, 132);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.NomeComboSetor = null;
            this.cmbLocal.NomeComboUnidade = null;
            this.cmbLocal.Obrigatorio = true;
            this.cmbLocal.ObrigatorioMensagem = "Selecione um Setor";
            this.cmbLocal.PreValidacaoMensagem = "";
            this.cmbLocal.PreValidado = false;
            this.cmbLocal.Size = new System.Drawing.Size(170, 21);
            this.cmbLocal.TabIndex = 126;
            this.cmbLocal.Text = "<Selecione>";
            // 
            // cmbUnidade
            // 
            this.cmbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.cmbUnidade.DisplayMember = "CAD_DS_UNI_UNIDADE";
            this.cmbUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbUnidade.Enabled = false;
            this.cmbUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbUnidade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbUnidade.FormattingEnabled = true;
            this.cmbUnidade.GravaAtendimento = false;
            this.cmbUnidade.IdtUsuario = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cmbUnidade.Limpar = true;
            this.cmbUnidade.Location = new System.Drawing.Point(80, 132);
            this.cmbUnidade.Name = "cmbUnidade";
            this.cmbUnidade.NomeComboLocal = null;
            this.cmbUnidade.NomeComboSetor = null;
            this.cmbUnidade.Obrigatorio = true;
            this.cmbUnidade.ObrigatorioMensagem = "Selecione uma Unidade";
            this.cmbUnidade.PreValidacaoMensagem = "";
            this.cmbUnidade.PreValidado = false;
            this.cmbUnidade.Size = new System.Drawing.Size(170, 21);
            this.cmbUnidade.SomenteAtiva = false;
            this.cmbUnidade.SomenteUnidade = false;
            this.cmbUnidade.TabIndex = 125;
            this.cmbUnidade.Text = "<Selecione>";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(516, 135);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(38, 13);
            this.hacLabel3.TabIndex = 124;
            this.hacLabel3.Text = "Setor";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(283, 135);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(36, 13);
            this.hacLabel2.TabIndex = 123;
            this.hacLabel2.Text = "Local";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(8, 135);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 122;
            this.hacLabel1.Text = "Unidade";
            // 
            // cmbLocalEstoque
            // 
            this.cmbLocalEstoque.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLocalEstoque.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cmbLocalEstoque.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cmbLocalEstoque.FormattingEnabled = true;
            this.cmbLocalEstoque.Limpar = true;
            this.cmbLocalEstoque.Location = new System.Drawing.Point(79, 36);
            this.cmbLocalEstoque.Name = "cmbLocalEstoque";
            this.cmbLocalEstoque.Obrigatorio = false;
            this.cmbLocalEstoque.ObrigatorioMensagem = null;
            this.cmbLocalEstoque.PreValidacaoMensagem = null;
            this.cmbLocalEstoque.PreValidado = false;
            this.cmbLocalEstoque.Size = new System.Drawing.Size(416, 21);
            this.cmbLocalEstoque.TabIndex = 132;
            this.cmbLocalEstoque.Text = "<Selecione>";
            this.cmbLocalEstoque.SelectionChangeCommitted += new System.EventHandler(this.cmbTiposCCusto_SelectionChangeCommitted);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(8, 39);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(62, 13);
            this.hacLabel6.TabIndex = 133;
            this.hacLabel6.Text = "Selecione";
            // 
            // chbAtivo
            // 
            this.chbAtivo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chbAtivo.AutoSize = true;
            this.chbAtivo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chbAtivo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chbAtivo.Limpar = true;
            this.chbAtivo.Location = new System.Drawing.Point(610, 35);
            this.chbAtivo.Name = "chbAtivo";
            this.chbAtivo.Obrigatorio = false;
            this.chbAtivo.ObrigatorioMensagem = null;
            this.chbAtivo.PreValidacaoMensagem = null;
            this.chbAtivo.PreValidado = false;
            this.chbAtivo.Size = new System.Drawing.Size(50, 17);
            this.chbAtivo.TabIndex = 134;
            this.chbAtivo.Text = "Ativo";
            this.chbAtivo.UseVisualStyleBackColor = true;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(8, 99);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(69, 13);
            this.hacLabel7.TabIndex = 135;
            this.hacLabel7.Text = "Movimento";
            // 
            // txtTpMovimentacao
            // 
            this.txtTpMovimentacao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtTpMovimentacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtTpMovimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTpMovimentacao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtTpMovimentacao.Enabled = false;
            this.txtTpMovimentacao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtTpMovimentacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtTpMovimentacao.Limpar = true;
            this.txtTpMovimentacao.Location = new System.Drawing.Point(79, 96);
            this.txtTpMovimentacao.Name = "txtTpMovimentacao";
            this.txtTpMovimentacao.NaoAjustarEdicao = false;
            this.txtTpMovimentacao.Obrigatorio = true;
            this.txtTpMovimentacao.ObrigatorioMensagem = "Digite a Movimentacao";
            this.txtTpMovimentacao.PreValidacaoMensagem = null;
            this.txtTpMovimentacao.PreValidado = false;
            this.txtTpMovimentacao.SelectAllOnFocus = false;
            this.txtTpMovimentacao.Size = new System.Drawing.Size(95, 21);
            this.txtTpMovimentacao.TabIndex = 136;
            // 
            // FrmTiposCCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 181);
            this.Controls.Add(this.txtTpMovimentacao);
            this.Controls.Add(this.hacLabel7);
            this.Controls.Add(this.chbAtivo);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.cmbLocalEstoque);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.txtDescTipoCCusto);
            this.Controls.Add(this.txtIdtTipoCCusto);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.cmbLocal);
            this.Controls.Add(this.cmbUnidade);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.tsHac);
            this.ModoTela = HospitalAnaCosta.SGS.Componentes.ModoEdicao.Edicao;
            this.Name = "FrmTiposCCusto";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmTiposCCusto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private HacToolStrip tsHac;
        private HacLabel hacLabel5;
        private HacLabel hacLabel4;
        private HacTextBox txtDescTipoCCusto;
        private HacTextBox txtIdtTipoCCusto;
        private HacCmbSetor cmbSetor;
        private HacCmbLocal cmbLocal;
        private HacCmbUnidade cmbUnidade;
        private HacLabel hacLabel3;
        private HacLabel hacLabel2;
        private HacLabel hacLabel1;
        private HacComboBox cmbLocalEstoque;
        private HacLabel hacLabel6;
        private HacCheckBox chbAtivo;
        private HacLabel hacLabel7;
        private HacTextBox txtTpMovimentacao;

    }
}