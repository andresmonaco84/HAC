using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais
{
    partial class FrmPacienteSetor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPacienteSetor));
            this.dtgAtendimento = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.hacToolStrip1 = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.colIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNmPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuarto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtTransf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpAtendimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtendimento)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgAtendimento
            // 
            this.dtgAtendimento.AllowUserToAddRows = false;
            this.dtgAtendimento.AllowUserToDeleteRows = false;
            this.dtgAtendimento.AllowUserToOrderColumns = true;
            this.dtgAtendimento.AllowUserToResizeColumns = false;
            this.dtgAtendimento.AllowUserToResizeRows = false;
            this.dtgAtendimento.AlterarStatus = false;
            this.dtgAtendimento.BackgroundColor = System.Drawing.Color.White;
            this.dtgAtendimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAtendimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdt,
            this.colNmPaciente,
            this.colQuarto,
            this.colLeito,
            this.colSetor,
            this.colDtTransf,
            this.colDtAlta,
            this.colTpAtendimento,
            this.colTpPlano});
            this.dtgAtendimento.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgAtendimento.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgAtendimento.GridPesquisa = false;
            this.dtgAtendimento.Limpar = false;
            this.dtgAtendimento.Location = new System.Drawing.Point(0, 31);
            this.dtgAtendimento.Name = "dtgAtendimento";
            this.dtgAtendimento.NaoAjustarEdicao = false;
            this.dtgAtendimento.Obrigatorio = false;
            this.dtgAtendimento.ObrigatorioMensagem = null;
            this.dtgAtendimento.PreValidacaoMensagem = null;
            this.dtgAtendimento.PreValidado = false;
            this.dtgAtendimento.RowHeadersVisible = false;
            this.dtgAtendimento.RowHeadersWidth = 25;
            this.dtgAtendimento.Size = new System.Drawing.Size(633, 331);
            this.dtgAtendimento.TabIndex = 0;
            this.dtgAtendimento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAtendimento_CellDoubleClick);
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
            this.hacToolStrip1.SalvarVisivel = false;
            this.hacToolStrip1.Size = new System.Drawing.Size(635, 28);
            this.hacToolStrip1.TabIndex = 1;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = "Seleção Atendimento";
            this.hacToolStrip1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.hacToolStrip1_MouseDoubleClick);
            // 
            // colIdt
            // 
            this.colIdt.HeaderText = "Atendimento";
            this.colIdt.Name = "colIdt";
            this.colIdt.ReadOnly = true;
            this.colIdt.Width = 80;
            // 
            // colNmPaciente
            // 
            this.colNmPaciente.HeaderText = "Nome Paciente";
            this.colNmPaciente.Name = "colNmPaciente";
            this.colNmPaciente.ReadOnly = true;
            this.colNmPaciente.Width = 300;
            // 
            // colQuarto
            // 
            this.colQuarto.HeaderText = "Quarto";
            this.colQuarto.Name = "colQuarto";
            this.colQuarto.ReadOnly = true;
            this.colQuarto.Width = 50;
            // 
            // colLeito
            // 
            this.colLeito.HeaderText = "Leito";
            this.colLeito.Name = "colLeito";
            this.colLeito.ReadOnly = true;
            this.colLeito.Width = 50;
            // 
            // colSetor
            // 
            this.colSetor.HeaderText = "setor";
            this.colSetor.Name = "colSetor";
            this.colSetor.Visible = false;
            // 
            // colDtTransf
            // 
            this.colDtTransf.HeaderText = "dtTransf";
            this.colDtTransf.Name = "colDtTransf";
            this.colDtTransf.ReadOnly = true;
            this.colDtTransf.Visible = false;
            // 
            // colDtAlta
            // 
            this.colDtAlta.HeaderText = "DtAlta";
            this.colDtAlta.Name = "colDtAlta";
            this.colDtAlta.ReadOnly = true;
            this.colDtAlta.Visible = false;
            // 
            // colTpAtendimento
            // 
            this.colTpAtendimento.HeaderText = "TIPO ATE";
            this.colTpAtendimento.Name = "colTpAtendimento";
            this.colTpAtendimento.ReadOnly = true;
            this.colTpAtendimento.Visible = false;
            // 
            // colTpPlano
            // 
            this.colTpPlano.HeaderText = "TIPO PLANO";
            this.colTpPlano.Name = "colTpPlano";
            this.colTpPlano.Visible = false;
            // 
            // FrmPacienteSetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 362);
            this.Controls.Add(this.hacToolStrip1);
            this.Controls.Add(this.dtgAtendimento);
            this.MaximizeBox = false;
            this.ModoTela = HospitalAnaCosta.SGS.Componentes.ModoEdicao.Edicao;
            this.Name = "FrmPacienteSetor";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            this.Load += new System.EventHandler(this.FrmAtendimentoSetor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtendimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgAtendimento;
        private HacToolStrip hacToolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNmPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuarto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtTransf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpPlano;
    }
}