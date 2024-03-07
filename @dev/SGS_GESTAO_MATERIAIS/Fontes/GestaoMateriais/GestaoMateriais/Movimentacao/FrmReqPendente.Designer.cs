using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmReqPendente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReqPendente));
            this.lblSelecione = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbCE = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbAcs = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbHac = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.dtgPedido = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colReqIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsUnidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReqTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.chbAntimicrobianos = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.chbPsico = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.grbMatMed = new System.Windows.Forms.GroupBox();
            this.rbTodos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMateriais = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.rbApenasMedicamentos = new HospitalAnaCosta.SGS.Componentes.HacRadioButton(this.components);
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedido)).BeginInit();
            this.grbMatMed.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelecione
            // 
            this.lblSelecione.AutoSize = true;
            this.lblSelecione.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSelecione.Location = new System.Drawing.Point(4, 51);
            this.lblSelecione.Name = "lblSelecione";
            this.lblSelecione.Size = new System.Drawing.Size(249, 13);
            this.lblSelecione.TabIndex = 130;
            this.lblSelecione.Text = "Selecione os pedidos que serão liberados:";
            this.lblSelecione.Visible = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbCE);
            this.groupBox.Controls.Add(this.rbAcs);
            this.groupBox.Controls.Add(this.rbHac);
            this.groupBox.Location = new System.Drawing.Point(646, 28);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(144, 36);
            this.groupBox.TabIndex = 128;
            this.groupBox.TabStop = false;
            // 
            // rbCE
            // 
            this.rbCE.AutoSize = true;
            this.rbCE.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbCE.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbCE.Limpar = true;
            this.rbCE.Location = new System.Drawing.Point(103, 13);
            this.rbCE.Name = "rbCE";
            this.rbCE.Obrigatorio = false;
            this.rbCE.ObrigatorioMensagem = null;
            this.rbCE.PreValidacaoMensagem = null;
            this.rbCE.PreValidado = false;
            this.rbCE.Size = new System.Drawing.Size(39, 17);
            this.rbCE.TabIndex = 132;
            this.rbCE.TabStop = true;
            this.rbCE.Text = "CE";
            this.rbCE.UseVisualStyleBackColor = true;
            this.rbCE.Click += new System.EventHandler(this.rbCE_Click);
            // 
            // rbAcs
            // 
            this.rbAcs.AutoSize = true;
            this.rbAcs.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbAcs.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.rbAcs.Limpar = true;
            this.rbAcs.Location = new System.Drawing.Point(56, 13);
            this.rbAcs.Name = "rbAcs";
            this.rbAcs.Obrigatorio = false;
            this.rbAcs.ObrigatorioMensagem = "";
            this.rbAcs.PreValidacaoMensagem = null;
            this.rbAcs.PreValidado = false;
            this.rbAcs.Size = new System.Drawing.Size(46, 17);
            this.rbAcs.TabIndex = 3;
            this.rbAcs.Text = "ACS";
            this.rbAcs.UseVisualStyleBackColor = true;
            this.rbAcs.Click += new System.EventHandler(this.rbAcs_Click);
            // 
            // rbHac
            // 
            this.rbHac.AutoSize = true;
            this.rbHac.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.rbHac.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
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
            this.rbHac.Click += new System.EventHandler(this.rbHac_Click);
            // 
            // dtgPedido
            // 
            this.dtgPedido.AllowUserToAddRows = false;
            this.dtgPedido.AlterarStatus = true;
            this.dtgPedido.BackgroundColor = System.Drawing.Color.White;
            this.dtgPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colReqIdt,
            this.colDsUnidade,
            this.colDsLocal,
            this.colDsSetor,
            this.colReqTipo,
            this.colData,
            this.colIdRef,
            this.colIdTipo});
            this.dtgPedido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgPedido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgPedido.GridPesquisa = false;
            this.dtgPedido.Limpar = true;
            this.dtgPedido.Location = new System.Drawing.Point(7, 70);
            this.dtgPedido.Name = "dtgPedido";
            this.dtgPedido.NaoAjustarEdicao = false;
            this.dtgPedido.Obrigatorio = false;
            this.dtgPedido.ObrigatorioMensagem = null;
            this.dtgPedido.PreValidacaoMensagem = null;
            this.dtgPedido.PreValidado = false;
            this.dtgPedido.RowHeadersWidth = 25;
            this.dtgPedido.Size = new System.Drawing.Size(782, 415);
            this.dtgPedido.TabIndex = 131;
            this.dtgPedido.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPedido_CellDoubleClick);
            this.dtgPedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgPedido_CellFormatting);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCheck.Width = 30;
            // 
            // colReqIdt
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReqIdt.DefaultCellStyle = dataGridViewCellStyle10;
            this.colReqIdt.HeaderText = "ID";
            this.colReqIdt.Name = "colReqIdt";
            this.colReqIdt.ReadOnly = true;
            this.colReqIdt.Width = 62;
            // 
            // colDsUnidade
            // 
            this.colDsUnidade.HeaderText = "Unidade";
            this.colDsUnidade.Name = "colDsUnidade";
            this.colDsUnidade.ReadOnly = true;
            this.colDsUnidade.Width = 110;
            // 
            // colDsLocal
            // 
            this.colDsLocal.HeaderText = "Local";
            this.colDsLocal.Name = "colDsLocal";
            this.colDsLocal.ReadOnly = true;
            // 
            // colDsSetor
            // 
            this.colDsSetor.HeaderText = "Setor";
            this.colDsSetor.Name = "colDsSetor";
            this.colDsSetor.ReadOnly = true;
            this.colDsSetor.Width = 140;
            // 
            // colReqTipo
            // 
            this.colReqTipo.HeaderText = "Tipo";
            this.colReqTipo.Name = "colReqTipo";
            this.colReqTipo.ReadOnly = true;
            this.colReqTipo.Width = 110;
            // 
            // colData
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colData.DefaultCellStyle = dataGridViewCellStyle11;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 120;
            // 
            // colIdRef
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIdRef.DefaultCellStyle = dataGridViewCellStyle12;
            this.colIdRef.HeaderText = "ID Ref.";
            this.colIdRef.Name = "colIdRef";
            this.colIdRef.ReadOnly = true;
            this.colIdRef.Width = 64;
            // 
            // colIdTipo
            // 
            this.colIdTipo.HeaderText = "colIdTipo";
            this.colIdTipo.Name = "colIdTipo";
            this.colIdTipo.Visible = false;
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(794, 28);
            this.tsHac.TabIndex = 7;
            this.tsHac.TituloTela = "Liberação de Pedidos Pendentes";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.LimparClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_LimparClick);
            this.tsHac.AfterLimpar += new HospitalAnaCosta.SGS.Componentes.AfterBeforeHacEventHandler(this.tsHac_AfterLimpar);
            // 
            // chbAntimicrobianos
            // 
            this.chbAntimicrobianos.AutoSize = true;
            this.chbAntimicrobianos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chbAntimicrobianos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbAntimicrobianos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAntimicrobianos.Limpar = true;
            this.chbAntimicrobianos.Location = new System.Drawing.Point(509, 42);
            this.chbAntimicrobianos.Name = "chbAntimicrobianos";
            this.chbAntimicrobianos.Obrigatorio = false;
            this.chbAntimicrobianos.ObrigatorioMensagem = null;
            this.chbAntimicrobianos.PreValidacaoMensagem = null;
            this.chbAntimicrobianos.PreValidado = false;
            this.chbAntimicrobianos.Size = new System.Drawing.Size(132, 17);
            this.chbAntimicrobianos.TabIndex = 132;
            this.chbAntimicrobianos.Text = "Antimicrobianos";
            this.chbAntimicrobianos.UseVisualStyleBackColor = true;
            this.chbAntimicrobianos.Click += new System.EventHandler(this.chbAntimicrobianos_Click);
            // 
            // chbPsico
            // 
            this.chbPsico.AutoSize = true;
            this.chbPsico.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chbPsico.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chbPsico.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPsico.Limpar = true;
            this.chbPsico.Location = new System.Drawing.Point(389, 42);
            this.chbPsico.Name = "chbPsico";
            this.chbPsico.Obrigatorio = false;
            this.chbPsico.ObrigatorioMensagem = null;
            this.chbPsico.PreValidacaoMensagem = null;
            this.chbPsico.PreValidado = false;
            this.chbPsico.Size = new System.Drawing.Size(113, 17);
            this.chbPsico.TabIndex = 133;
            this.chbPsico.Text = "Psicotrópicos";
            this.chbPsico.UseVisualStyleBackColor = true;
            this.chbPsico.Click += new System.EventHandler(this.chbPsico_Click);
            // 
            // grbMatMed
            // 
            this.grbMatMed.Controls.Add(this.rbTodos);
            this.grbMatMed.Controls.Add(this.rbApenasMateriais);
            this.grbMatMed.Controls.Add(this.rbApenasMedicamentos);
            this.grbMatMed.Location = new System.Drawing.Point(601, 491);
            this.grbMatMed.Name = "grbMatMed";
            this.grbMatMed.Size = new System.Drawing.Size(187, 36);
            this.grbMatMed.TabIndex = 136;
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
            this.rbTodos.Click += new System.EventHandler(this.rbTodos_Click);
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
            this.rbApenasMateriais.Click += new System.EventHandler(this.rbApenasMateriais_Click);
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
            this.rbApenasMedicamentos.Click += new System.EventHandler(this.rbApenasMedicamentos_Click);
            // 
            // FrmReqPendente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 538);
            this.Controls.Add(this.grbMatMed);
            this.Controls.Add(this.chbPsico);
            this.Controls.Add(this.chbAntimicrobianos);
            this.Controls.Add(this.dtgPedido);
            this.Controls.Add(this.lblSelecione);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmReqPendente";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmReqPendente_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedido)).EndInit();
            this.grbMatMed.ResumeLayout(false);
            this.grbMatMed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacLabel lblSelecione;
        private System.Windows.Forms.GroupBox groupBox;
        private HacRadioButton rbAcs;
        private HacRadioButton rbHac;
        private HacDataGridView dtgPedido;
        private HacRadioButton rbCE;
        private HacCheckBox chbAntimicrobianos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsLocal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTipo;
        private HacCheckBox chbPsico;
        private System.Windows.Forms.GroupBox grbMatMed;
        private HacRadioButton rbTodos;
        private HacRadioButton rbApenasMateriais;
        private HacRadioButton rbApenasMedicamentos;

    }
}