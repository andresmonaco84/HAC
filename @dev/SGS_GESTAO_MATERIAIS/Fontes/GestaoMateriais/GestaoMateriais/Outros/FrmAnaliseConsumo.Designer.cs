using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmAnaliseConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaliseConsumo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HacToolStrip(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbAcs = new HacRadioButton(this.components);
            this.rbHac = new HacRadioButton(this.components);
            this.dtgItensRessuprir = new HacDataGridView(this.components);
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDsUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtUltDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercEstoqueMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercConsumida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPedidoPadraoIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelecione = new HacLabel(this.components);
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensRessuprir)).BeginInit();
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
            this.tsHac.Size = new System.Drawing.Size(794, 28);
            this.tsHac.TabIndex = 6;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Produtos a Ressuprir";
            this.tsHac.SalvarClick += new ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbAcs);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(677, 31);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(109, 36);
            this.groupBox.TabIndex = 103;
            this.groupBox.TabStop = false;
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(57, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = "";
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 3;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.CheckedChanged += new System.EventHandler(this.rbAcs_CheckedChanged);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = EstadoObjeto.Habilitado;
            this.rbHac.Limpar = true;
            this.rbHac.Location = new System.Drawing.Point(8, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = false;
            this.rbHac.ObrigatorioMensagem = "";
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 2;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.CheckedChanged += new System.EventHandler(this.rbHac_CheckedChanged);
            // 
            // dtgItensRessuprir
            // 
            this.dtgItensRessuprir.AllowUserToAddRows = false;
            this.dtgItensRessuprir.AlterarStatus = true;
            this.dtgItensRessuprir.BackgroundColor = System.Drawing.Color.White;
            this.dtgItensRessuprir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItensRessuprir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colDsUnidade,
            this.colDsLocal,
            this.colDsSetor,
            this.colDsProduto,
            this.colDtUltDisp,
            this.colPercEstoqueMin,
            this.colPercConsumida,
            this.colPedidoPadraoIdt,
            this.colIdProduto});
            this.dtgItensRessuprir.Editavel = ControleEdicao.Nunca;
            this.dtgItensRessuprir.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItensRessuprir.EstadoInicial = EstadoObjeto.Habilitado;
            this.dtgItensRessuprir.GridPesquisa = false;
            this.dtgItensRessuprir.Limpar = true;
            this.dtgItensRessuprir.Location = new System.Drawing.Point(5, 74);
            this.dtgItensRessuprir.Name = "dtgItensRessuprir";
            this.dtgItensRessuprir.NaoAjustarEdicao = false;
            this.dtgItensRessuprir.Obrigatorio = false;
            this.dtgItensRessuprir.ObrigatorioMensagem = null;
            this.dtgItensRessuprir.PreValidacaoMensagem = null;
            this.dtgItensRessuprir.PreValidado = false;
            this.dtgItensRessuprir.RowHeadersWidth = 25;
            this.dtgItensRessuprir.Size = new System.Drawing.Size(782, 415);
            this.dtgItensRessuprir.TabIndex = 125;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.Visible = false;
            this.colCheck.Width = 25;
            // 
            // colDsUnidade
            // 
            this.colDsUnidade.HeaderText = "Unidade";
            this.colDsUnidade.Name = "colDsUnidade";
            this.colDsUnidade.ReadOnly = true;
            this.colDsUnidade.Width = 80;
            // 
            // colDsLocal
            // 
            this.colDsLocal.HeaderText = "Local";
            this.colDsLocal.Name = "colDsLocal";
            this.colDsLocal.ReadOnly = true;
            this.colDsLocal.Width = 80;
            // 
            // colDsSetor
            // 
            this.colDsSetor.HeaderText = "Setor";
            this.colDsSetor.Name = "colDsSetor";
            this.colDsSetor.ReadOnly = true;
            this.colDsSetor.Width = 95;
            // 
            // colDsProduto
            // 
            this.colDsProduto.HeaderText = "Produto";
            this.colDsProduto.Name = "colDsProduto";
            this.colDsProduto.ReadOnly = true;
            this.colDsProduto.Width = 140;
            // 
            // colDtUltDisp
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDtUltDisp.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDtUltDisp.HeaderText = "Última Dispensação";
            this.colDtUltDisp.Name = "colDtUltDisp";
            this.colDtUltDisp.ReadOnly = true;
            this.colDtUltDisp.Width = 130;
            // 
            // colPercEstoqueMin
            // 
            this.colPercEstoqueMin.HeaderText = "Ressup. (%)";
            this.colPercEstoqueMin.Name = "colPercEstoqueMin";
            this.colPercEstoqueMin.ReadOnly = true;
            this.colPercEstoqueMin.Width = 90;
            // 
            // colPercConsumida
            // 
            this.colPercConsumida.HeaderText = "Atual (%)";
            this.colPercConsumida.Name = "colPercConsumida";
            this.colPercConsumida.ReadOnly = true;
            this.colPercConsumida.Width = 92;
            // 
            // colPedidoPadraoIdt
            // 
            this.colPedidoPadraoIdt.HeaderText = "colPedidoPadraoIdt";
            this.colPedidoPadraoIdt.Name = "colPedidoPadraoIdt";
            this.colPedidoPadraoIdt.ReadOnly = true;
            this.colPedidoPadraoIdt.Visible = false;
            // 
            // colIdProduto
            // 
            this.colIdProduto.HeaderText = "colIdProduto";
            this.colIdProduto.Name = "colIdProduto";
            this.colIdProduto.ReadOnly = true;
            this.colIdProduto.Visible = false;
            // 
            // lblSelecione
            // 
            this.lblSelecione.AutoSize = true;
            this.lblSelecione.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSelecione.Location = new System.Drawing.Point(7, 55);
            this.lblSelecione.Name = "lblSelecione";
            this.lblSelecione.Size = new System.Drawing.Size(608, 13);
            this.lblSelecione.TabIndex = 126;
            this.lblSelecione.Text = "Selecione os produtos referentes aos setores os quais serão gerados os pedidos pa" +
                "ra o reabastecimento";
            this.lblSelecione.Visible = false;
            // 
            // FrmAnaliseConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.lblSelecione);
            this.Controls.Add(this.dtgItensRessuprir);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.tsHac);
            this.ModoTela = ModoEdicao.Edicao;
            this.Name = "FrmAnaliseConsumo";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmAnaliseConsumo_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItensRessuprir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacDataGridView dtgItensRessuprir;
        private HacLabel lblSelecione;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtUltDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercEstoqueMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercConsumida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoPadraoIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProduto;
    }
}