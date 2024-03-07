namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmSelecaoPacienteAtendimento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelecaoPacienteAtendimento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvResultado = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.hacToolStrip1 = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.colHAC_PRESTADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCNV_FANTASIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomePlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvResultado);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 202);
            this.groupBox1.TabIndex = 149;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleção de Convênio e Plano do Paciente";
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AllowUserToOrderColumns = true;
            this.dgvResultado.AllowUserToResizeColumns = false;
            this.dgvResultado.AllowUserToResizeRows = false;
            this.dgvResultado.AlterarStatus = false;
            this.dgvResultado.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHAC_PRESTADOR,
            this.colCNV_FANTASIA,
            this.colPlano,
            this.colNomePlano,
            this.colCredencial,
            this.colIdtPaciente,
            this.colNome});
            this.dgvResultado.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.dgvResultado.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvResultado.GridPesquisa = false;
            this.dgvResultado.Limpar = true;
            this.dgvResultado.Location = new System.Drawing.Point(5, 21);
            this.dgvResultado.MultiSelect = false;
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.NaoAjustarEdicao = true;
            this.dgvResultado.Obrigatorio = false;
            this.dgvResultado.ObrigatorioMensagem = null;
            this.dgvResultado.PreValidacaoMensagem = null;
            this.dgvResultado.PreValidado = false;
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.RowHeadersVisible = false;
            this.dgvResultado.RowHeadersWidth = 25;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResultado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultado.Size = new System.Drawing.Size(826, 175);
            this.dgvResultado.TabIndex = 1;
            this.dgvResultado.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResultado_CellMouseDoubleClick);
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
            this.hacToolStrip1.SairVisivel = false;
            this.hacToolStrip1.SalvarVisivel = false;
            this.hacToolStrip1.Size = new System.Drawing.Size(847, 25);
            this.hacToolStrip1.TabIndex = 150;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = null;
            this.hacToolStrip1.ToolTipSalvar = "Salvar";
            // 
            // colHAC_PRESTADOR
            // 
            this.colHAC_PRESTADOR.DataPropertyName = "CAD_CNV_CD_HAC_PRESTADOR";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colHAC_PRESTADOR.DefaultCellStyle = dataGridViewCellStyle1;
            this.colHAC_PRESTADOR.HeaderText = "Cód. Conv.";
            this.colHAC_PRESTADOR.Name = "colHAC_PRESTADOR";
            this.colHAC_PRESTADOR.ReadOnly = true;
            this.colHAC_PRESTADOR.Width = 50;
            // 
            // colCNV_FANTASIA
            // 
            this.colCNV_FANTASIA.DataPropertyName = "CAD_CNV_NM_FANTASIA";
            this.colCNV_FANTASIA.HeaderText = "Convênio";
            this.colCNV_FANTASIA.Name = "colCNV_FANTASIA";
            this.colCNV_FANTASIA.ReadOnly = true;
            this.colCNV_FANTASIA.Width = 180;
            // 
            // colPlano
            // 
            this.colPlano.DataPropertyName = "CodPlano";
            this.colPlano.HeaderText = "Cód. Plano";
            this.colPlano.Name = "colPlano";
            this.colPlano.ReadOnly = true;
            this.colPlano.Width = 50;
            // 
            // colNomePlano
            // 
            this.colNomePlano.DataPropertyName = "DesPlano";
            this.colNomePlano.HeaderText = "Plano";
            this.colNomePlano.Name = "colNomePlano";
            this.colNomePlano.ReadOnly = true;
            this.colNomePlano.Width = 180;
            // 
            // colCredencial
            // 
            this.colCredencial.DataPropertyName = "cad_pac_cd_credencial";
            this.colCredencial.HeaderText = "Credencial";
            this.colCredencial.Name = "colCredencial";
            this.colCredencial.ReadOnly = true;
            // 
            // colIdtPaciente
            // 
            this.colIdtPaciente.DataPropertyName = "cad_pac_id_paciente";
            this.colIdtPaciente.HeaderText = "Paciente";
            this.colIdtPaciente.Name = "colIdtPaciente";
            this.colIdtPaciente.ReadOnly = true;
            this.colIdtPaciente.Width = 60;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "nomePessoa";
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 180;
            // 
            // FrmSelecaoPacienteAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 238);
            this.ControlBox = false;
            this.Controls.Add(this.hacToolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSelecaoPacienteAtendimento";
            this.ShowInTaskbar = false;
            this.Text = "FrmPacienteAtendimento";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvResultado;
        private Hac.Windows.Forms.Controls.HacToolStrip hacToolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAC_PRESTADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCNV_FANTASIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomePlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
    }
}