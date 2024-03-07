using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmItensReq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItensReq));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblPedido = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblNumReq = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.chkAjudaAtualizarGrid = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colReqItemIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidadeVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdCentDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdeFornecida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodPresc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeColumns = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
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
            this.colDeletar,
            this.colReqItemIdt,
            this.colDsProd,
            this.colMAV,
            this.colMatMedIdt,
            this.colDsUnidadeVenda,
            this.colEstoqueLocal,
            this.colQtdePadrao,
            this.colQtdCentDisp,
            this.colQtde,
            this.colQtdeFornecida,
            this.colCodPresc,
            this.colData,
            this.colUsuPedido});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMatMed.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgMatMed.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = true;
            this.dtgMatMed.Location = new System.Drawing.Point(0, 61);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMatMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.Size = new System.Drawing.Size(804, 300);
            this.dtgMatMed.TabIndex = 71;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            this.dtgMatMed.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellEndEdit);
            this.dtgMatMed.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgMatMed_CellFormatting);
            this.dtgMatMed.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgMatMed_CellValidating);
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
            this.tsHac.Size = new System.Drawing.Size(804, 28);
            this.tsHac.TabIndex = 72;
            this.tsHac.TituloTela = "Itens do Pedido";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblPedido.Location = new System.Drawing.Point(7, 36);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(72, 16);
            this.lblPedido.TabIndex = 73;
            this.lblPedido.Text = "Pedido N°";
            // 
            // lblNumReq
            // 
            this.lblNumReq.AutoSize = true;
            this.lblNumReq.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumReq.Location = new System.Drawing.Point(80, 35);
            this.lblNumReq.Name = "lblNumReq";
            this.lblNumReq.Size = new System.Drawing.Size(19, 18);
            this.lblNumReq.TabIndex = 74;
            this.lblNumReq.Text = "0";
            // 
            // chkAjudaAtualizarGrid
            // 
            this.chkAjudaAtualizarGrid.AutoSize = true;
            this.chkAjudaAtualizarGrid.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkAjudaAtualizarGrid.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkAjudaAtualizarGrid.Limpar = false;
            this.chkAjudaAtualizarGrid.Location = new System.Drawing.Point(648, 378);
            this.chkAjudaAtualizarGrid.Name = "chkAjudaAtualizarGrid";
            this.chkAjudaAtualizarGrid.Obrigatorio = false;
            this.chkAjudaAtualizarGrid.ObrigatorioMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidacaoMensagem = null;
            this.chkAjudaAtualizarGrid.PreValidado = false;
            this.chkAjudaAtualizarGrid.Size = new System.Drawing.Size(15, 14);
            this.chkAjudaAtualizarGrid.TabIndex = 115;
            this.chkAjudaAtualizarGrid.UseVisualStyleBackColor = true;
            this.chkAjudaAtualizarGrid.Visible = false;
            // 
            // colDeletar
            // 
            this.colDeletar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDeletar.HeaderText = "Excluir";
            this.colDeletar.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDeletar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeletar.ToolTipText = "Excluir Linha";
            this.colDeletar.Width = 40;
            // 
            // colReqItemIdt
            // 
            this.colReqItemIdt.HeaderText = "Pedido N°";
            this.colReqItemIdt.Name = "colReqItemIdt";
            this.colReqItemIdt.ReadOnly = true;
            this.colReqItemIdt.Visible = false;
            this.colReqItemIdt.Width = 80;
            // 
            // colDsProd
            // 
            this.colDsProd.HeaderText = "Descrição do Item";
            this.colDsProd.Name = "colDsProd";
            this.colDsProd.ReadOnly = true;
            this.colDsProd.Width = 220;
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
            this.colDsUnidadeVenda.Width = 68;
            // 
            // colEstoqueLocal
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colEstoqueLocal.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEstoqueLocal.HeaderText = "Qtd. Local";
            this.colEstoqueLocal.Name = "colEstoqueLocal";
            this.colEstoqueLocal.ReadOnly = true;
            this.colEstoqueLocal.Width = 85;
            // 
            // colQtdePadrao
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colQtdePadrao.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQtdePadrao.HeaderText = "Qtd. Padrão";
            this.colQtdePadrao.Name = "colQtdePadrao";
            this.colQtdePadrao.ReadOnly = true;
            this.colQtdePadrao.Visible = false;
            this.colQtdePadrao.Width = 65;
            // 
            // colQtdCentDisp
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colQtdCentDisp.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQtdCentDisp.HeaderText = "Qt. C.Disp.";
            this.colQtdCentDisp.Name = "colQtdCentDisp";
            this.colQtdCentDisp.ReadOnly = true;
            this.colQtdCentDisp.Width = 85;
            // 
            // colQtde
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.colQtde.DefaultCellStyle = dataGridViewCellStyle5;
            this.colQtde.HeaderText = "Qtd. Ped.";
            this.colQtde.MaxInputLength = 3;
            this.colQtde.Name = "colQtde";
            this.colQtde.Width = 80;
            // 
            // colQtdeFornecida
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQtdeFornecida.DefaultCellStyle = dataGridViewCellStyle6;
            this.colQtdeFornecida.HeaderText = "Qtd. Rec.";
            this.colQtdeFornecida.Name = "colQtdeFornecida";
            this.colQtdeFornecida.ReadOnly = true;
            this.colQtdeFornecida.Width = 80;
            // 
            // colCodPresc
            // 
            this.colCodPresc.HeaderText = "Cód. Presc.";
            this.colCodPresc.Name = "colCodPresc";
            this.colCodPresc.ReadOnly = true;
            this.colCodPresc.Width = 90;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data Pedido";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Visible = false;
            this.colData.Width = 120;
            // 
            // colUsuPedido
            // 
            this.colUsuPedido.HeaderText = "Usuário Pedido";
            this.colUsuPedido.Name = "colUsuPedido";
            this.colUsuPedido.ReadOnly = true;
            this.colUsuPedido.Visible = false;
            this.colUsuPedido.Width = 150;
            // 
            // FrmItensReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 360);
            this.Controls.Add(this.chkAjudaAtualizarGrid);
            this.Controls.Add(this.lblNumReq);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.dtgMatMed);
            this.MaximizeBox = false;
            this.Name = "FrmItensReq";
            this.Text = "Gestão de Materiais e Medicamentos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgMatMed;
        private HacToolStrip tsHac;
        private HacLabel lblPedido;
        private HacLabel lblNumReq;
        private HacCheckBox chkAjudaAtualizarGrid;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqItemIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsProd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMAV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidadeVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstoqueLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdePadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdCentDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdeFornecida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodPresc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuPedido;
    }
}