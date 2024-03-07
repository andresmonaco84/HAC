using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmReqPedidoPad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReqPedidoPad));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.dtgPedidoPadrao = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPedidoPadraoIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataUltDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataUltPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelecione = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbMatMed = new System.Windows.Forms.GroupBox();
            this.rbTodos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMateriais = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMedicamentos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.chbEnvioFarmacia = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidoPadrao)).BeginInit();
            this.groupBox.SuspendLayout();
            this.grbMatMed.SuspendLayout();
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
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 121;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Geração de Pedido Padrão";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            // 
            // dtgPedidoPadrao
            // 
            this.dtgPedidoPadrao.AllowUserToAddRows = false;
            this.dtgPedidoPadrao.AllowUserToResizeRows = false;
            this.dtgPedidoPadrao.AlterarStatus = true;
            this.dtgPedidoPadrao.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidoPadrao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dtgPedidoPadrao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedidoPadrao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colPedidoPadraoIdt,
            this.colDsUnidade,
            this.colDsLocal,
            this.colDsSetor,
            this.colDataUltDisp,
            this.colDataUltPedido,
            this.colStatus});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPedidoPadrao.DefaultCellStyle = dataGridViewCellStyle24;
            this.dtgPedidoPadrao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgPedidoPadrao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgPedidoPadrao.GridPesquisa = false;
            this.dtgPedidoPadrao.Limpar = true;
            this.dtgPedidoPadrao.Location = new System.Drawing.Point(6, 71);
            this.dtgPedidoPadrao.Name = "dtgPedidoPadrao";
            this.dtgPedidoPadrao.NaoAjustarEdicao = false;
            this.dtgPedidoPadrao.Obrigatorio = false;
            this.dtgPedidoPadrao.ObrigatorioMensagem = null;
            this.dtgPedidoPadrao.PreValidacaoMensagem = null;
            this.dtgPedidoPadrao.PreValidado = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPedidoPadrao.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dtgPedidoPadrao.RowHeadersVisible = false;
            this.dtgPedidoPadrao.RowHeadersWidth = 18;
            this.dtgPedidoPadrao.RowTemplate.Height = 18;
            this.dtgPedidoPadrao.Size = new System.Drawing.Size(770, 415);
            this.dtgPedidoPadrao.TabIndex = 122;
            this.dtgPedidoPadrao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgPedidoPadrao_CellFormatting);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.Width = 30;
            // 
            // colPedidoPadraoIdt
            // 
            this.colPedidoPadraoIdt.HeaderText = "ID";
            this.colPedidoPadraoIdt.Name = "colPedidoPadraoIdt";
            this.colPedidoPadraoIdt.Visible = false;
            // 
            // colDsUnidade
            // 
            this.colDsUnidade.HeaderText = "Unidade";
            this.colDsUnidade.Name = "colDsUnidade";
            this.colDsUnidade.ReadOnly = true;
            this.colDsUnidade.Width = 145;
            // 
            // colDsLocal
            // 
            this.colDsLocal.HeaderText = "Local";
            this.colDsLocal.Name = "colDsLocal";
            this.colDsLocal.ReadOnly = true;
            this.colDsLocal.Width = 145;
            // 
            // colDsSetor
            // 
            this.colDsSetor.HeaderText = "Setor";
            this.colDsSetor.Name = "colDsSetor";
            this.colDsSetor.ReadOnly = true;
            this.colDsSetor.Width = 145;
            // 
            // colDataUltDisp
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataUltDisp.DefaultCellStyle = dataGridViewCellStyle22;
            this.colDataUltDisp.HeaderText = "Data Última Dispensação";
            this.colDataUltDisp.Name = "colDataUltDisp";
            this.colDataUltDisp.ReadOnly = true;
            this.colDataUltDisp.Width = 150;
            // 
            // colDataUltPedido
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataUltPedido.DefaultCellStyle = dataGridViewCellStyle23;
            this.colDataUltPedido.HeaderText = "Data Último Pedido";
            this.colDataUltPedido.Name = "colDataUltPedido";
            this.colDataUltPedido.ReadOnly = true;
            this.colDataUltPedido.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            // 
            // lblSelecione
            // 
            this.lblSelecione.AutoSize = true;
            this.lblSelecione.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSelecione.Location = new System.Drawing.Point(7, 53);
            this.lblSelecione.Name = "lblSelecione";
            this.lblSelecione.Size = new System.Drawing.Size(262, 13);
            this.lblSelecione.TabIndex = 123;
            this.lblSelecione.Text = "Selecione os setores os quais serão gerados";
            this.lblSelecione.Visible = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbCE);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(670, 28);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(102, 36);
            this.groupBox.TabIndex = 124;
            this.groupBox.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Limpar = false;
            this.rbCE.Location = new System.Drawing.Point(59, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = true;
            this.rbCE.ObrigatorioMensagem = "Escolha Um estoque HAC/ACS/CE";
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 118;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.Click += new System.EventHandler(this.rbCE_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbHac.Limpar = false;
            this.rbHac.Location = new System.Drawing.Point(9, 13);
            this.rbHac.Name = "rbHac";
            this.rbHac.Obrigatorio = true;
            this.rbHac.ObrigatorioMensagem = "Escolha Um estoque HAC/ACS/CE";
            this.rbHac.PreValidacaoMensagem = null;
            this.rbHac.PreValidado = false;
            this.rbHac.Size = new System.Drawing.Size(47, 17);
            this.rbHac.TabIndex = 2;
            this.rbHac.TabStop = true;
            this.rbHac.Text = "HAC";
            this.rbHac.UseVisualStyleBackColor = true;
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(25, 506);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(53, 12);
            this.hacLabel6.TabIndex = 134;
            this.hacLabel6.Text = "Impressa";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(25, 489);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(120, 12);
            this.hacLabel5.TabIndex = 133;
            this.hacLabel5.Text = "Aguardando impressão";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(8, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 132;
            this.label2.Text = "  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 131;
            this.label1.Text = "  ";
            // 
            // grbMatMed
            // 
            this.grbMatMed.Controls.Add(this.rbTodos);
            this.grbMatMed.Controls.Add(this.rbApenasMateriais);
            this.grbMatMed.Controls.Add(this.rbApenasMedicamentos);
            this.grbMatMed.Location = new System.Drawing.Point(473, 28);
            this.grbMatMed.Name = "grbMatMed";
            this.grbMatMed.Size = new System.Drawing.Size(187, 36);
            this.grbMatMed.TabIndex = 135;
            this.grbMatMed.TabStop = false;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbTodos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Limpar = true;
            this.rbTodos.Location = new System.Drawing.Point(9, 13);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Obrigatorio = false;
            this.rbTodos.ObrigatorioMensagem = null;
            this.rbTodos.PreValidacaoMensagem = null;
            this.rbTodos.PreValidado = false;
            this.rbTodos.Size = new System.Drawing.Size(68, 17);
            this.rbTodos.TabIndex = 15;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "TODOS";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbApenasMateriais
            // 
            this.rbApenasMateriais.AutoSize = true;
            this.rbApenasMateriais.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbApenasMateriais.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbApenasMateriais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbApenasMateriais.Limpar = true;
            this.rbApenasMateriais.Location = new System.Drawing.Point(79, 13);
            this.rbApenasMateriais.Name = "rbApenasMateriais";
            this.rbApenasMateriais.Obrigatorio = false;
            this.rbApenasMateriais.ObrigatorioMensagem = null;
            this.rbApenasMateriais.PreValidacaoMensagem = null;
            this.rbApenasMateriais.PreValidado = false;
            this.rbApenasMateriais.Size = new System.Drawing.Size(51, 17);
            this.rbApenasMateriais.TabIndex = 17;
            this.rbApenasMateriais.Text = "MAT";
            this.rbApenasMateriais.UseVisualStyleBackColor = true;
            // 
            // rbApenasMedicamentos
            // 
            this.rbApenasMedicamentos.AutoSize = true;
            this.rbApenasMedicamentos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.rbApenasMedicamentos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbApenasMedicamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbApenasMedicamentos.Limpar = true;
            this.rbApenasMedicamentos.Location = new System.Drawing.Point(131, 13);
            this.rbApenasMedicamentos.Name = "rbApenasMedicamentos";
            this.rbApenasMedicamentos.Obrigatorio = false;
            this.rbApenasMedicamentos.ObrigatorioMensagem = null;
            this.rbApenasMedicamentos.PreValidacaoMensagem = null;
            this.rbApenasMedicamentos.PreValidado = false;
            this.rbApenasMedicamentos.Size = new System.Drawing.Size(52, 17);
            this.rbApenasMedicamentos.TabIndex = 16;
            this.rbApenasMedicamentos.Text = "MED";
            this.rbApenasMedicamentos.UseVisualStyleBackColor = true;
            // 
            // chbEnvioFarmacia
            // 
            this.chbEnvioFarmacia.AutoSize = true;
            this.chbEnvioFarmacia.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.chbEnvioFarmacia.Enabled = false;
            this.chbEnvioFarmacia.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.chbEnvioFarmacia.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEnvioFarmacia.Limpar = true;
            this.chbEnvioFarmacia.Location = new System.Drawing.Point(297, 39);
            this.chbEnvioFarmacia.Name = "chbEnvioFarmacia";
            this.chbEnvioFarmacia.Obrigatorio = false;
            this.chbEnvioFarmacia.ObrigatorioMensagem = null;
            this.chbEnvioFarmacia.PreValidacaoMensagem = null;
            this.chbEnvioFarmacia.PreValidado = false;
            this.chbEnvioFarmacia.Size = new System.Drawing.Size(169, 21);
            this.chbEnvioFarmacia.TabIndex = 136;
            this.chbEnvioFarmacia.Text = "ENVIO FARMÁCIA";
            this.chbEnvioFarmacia.UseVisualStyleBackColor = true;
            this.chbEnvioFarmacia.Visible = false;
            // 
            // FrmReqPedidoPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 556);
            this.Controls.Add(this.chbEnvioFarmacia);
            this.Controls.Add(this.grbMatMed);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.lblSelecione);
            this.Controls.Add(this.dtgPedidoPadrao);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmReqPedidoPad";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmReqPedidoPad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedidoPadrao)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.grbMatMed.ResumeLayout(false);
            this.grbMatMed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacDataGridView dtgPedidoPadrao;
        private HacLabel lblSelecione;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbHac;
        private HacRadioButton rbCE;
        private HacLabel hacLabel6;
        private HacLabel hacLabel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoPadraoIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataUltDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataUltPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.GroupBox grbMatMed;
        private HacRadioButton rbTodos;
        private HacRadioButton rbApenasMateriais;
        private HacRadioButton rbApenasMedicamentos;
        private HacCheckBox chbEnvioFarmacia;
    }
}