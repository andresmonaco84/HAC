using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmPesqBenefHomeCare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqBenefHomeCare));
            this.hacToolStrip1 = new HacToolStrip(this.components);
            this.hacLabel1 = new HacLabel(this.components);
            this.txtNomBenef = new HacTextBox(this.components);
            this.btnPesquisar = new HacButton(this.components);
            this.dtgBeneficiario = new HacDataGridView(this.components);
            this.colIdtHomeCare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNmBeneficiario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCdPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBeneficiario)).BeginInit();
            this.SuspendLayout();
            // 
            // hacToolStrip1
            // 
            this.hacToolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacToolStrip1.BackgroundImage")));
            this.hacToolStrip1.CancelarVisivel = false;
            this.hacToolStrip1.ExcluirVisivel = false;
            this.hacToolStrip1.ImprimirVisivel = false;
            this.hacToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.hacToolStrip1.MatMedVisivel = false;
            this.hacToolStrip1.Name = "hacToolStrip1";
            this.hacToolStrip1.NomeControleFoco = null;
            this.hacToolStrip1.NovoVisivel = false;
            this.hacToolStrip1.PesquisarVisivel = false;
            this.hacToolStrip1.SalvarVisivel = false;
            this.hacToolStrip1.Size = new System.Drawing.Size(622, 28);
            this.hacToolStrip1.TabIndex = 0;
            this.hacToolStrip1.Text = "hacToolStrip1";
            this.hacToolStrip1.TituloTela = "Pesquisa Beneficiário Internação Domiciliar";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(12, 44);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(40, 13);
            this.hacLabel1.TabIndex = 1;
            this.hacLabel1.Text = "Nome";
            // 
            // txtNomBenef
            // 
            this.txtNomBenef.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtNomBenef.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomBenef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomBenef.Editavel = ControleEdicao.Nunca;
            this.txtNomBenef.EstadoInicial = EstadoObjeto.Habilitado;
            this.txtNomBenef.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtNomBenef.Limpar = false;
            this.txtNomBenef.Location = new System.Drawing.Point(58, 41);
            this.txtNomBenef.Name = "txtNomBenef";
            this.txtNomBenef.NaoAjustarEdicao = false;
            this.txtNomBenef.Obrigatorio = false;
            this.txtNomBenef.ObrigatorioMensagem = "";
            this.txtNomBenef.PreValidacaoMensagem = "";
            this.txtNomBenef.PreValidado = false;
            this.txtNomBenef.SelectAllOnFocus = false;
            this.txtNomBenef.Size = new System.Drawing.Size(441, 21);
            this.txtNomBenef.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.AlterarStatus = true;
            this.btnPesquisar.BackColor = System.Drawing.Color.White;
            this.btnPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.BackgroundImage")));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(508, 41);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(105, 22);
            this.btnPesquisar.TabIndex = 3;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dtgBeneficiario
            // 
            this.dtgBeneficiario.AllowUserToAddRows = false;
            this.dtgBeneficiario.AllowUserToDeleteRows = false;
            this.dtgBeneficiario.AlterarStatus = false;
            this.dtgBeneficiario.BackgroundColor = System.Drawing.Color.White;
            this.dtgBeneficiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBeneficiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdtHomeCare,
            this.colNmBeneficiario,
            this.colCdPlano});
            this.dtgBeneficiario.Editavel = ControleEdicao.Sempre;
            this.dtgBeneficiario.EstadoInicial = EstadoObjeto.Habilitado;
            this.dtgBeneficiario.GridPesquisa = false;
            this.dtgBeneficiario.Limpar = false;
            this.dtgBeneficiario.Location = new System.Drawing.Point(6, 77);
            this.dtgBeneficiario.Name = "dtgBeneficiario";
            this.dtgBeneficiario.NaoAjustarEdicao = false;
            this.dtgBeneficiario.Obrigatorio = false;
            this.dtgBeneficiario.ObrigatorioMensagem = null;
            this.dtgBeneficiario.PreValidacaoMensagem = null;
            this.dtgBeneficiario.PreValidado = false;
            this.dtgBeneficiario.RowHeadersWidth = 25;
            this.dtgBeneficiario.Size = new System.Drawing.Size(607, 244);
            this.dtgBeneficiario.TabIndex = 4;
            this.dtgBeneficiario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBeneficiario_CellDoubleClick);
            // 
            // colIdtHomeCare
            // 
            this.colIdtHomeCare.HeaderText = "IDT";
            this.colIdtHomeCare.Name = "colIdtHomeCare";
            this.colIdtHomeCare.ReadOnly = true;
            this.colIdtHomeCare.Width = 50;
            // 
            // colNmBeneficiario
            // 
            this.colNmBeneficiario.HeaderText = "Nome";
            this.colNmBeneficiario.Name = "colNmBeneficiario";
            this.colNmBeneficiario.ReadOnly = true;
            this.colNmBeneficiario.Width = 430;
            // 
            // colCdPlano
            // 
            this.colCdPlano.HeaderText = "Plano";
            this.colCdPlano.Name = "colCdPlano";
            this.colCdPlano.ReadOnly = true;
            this.colCdPlano.Width = 60;
            // 
            // FrmPesqBenefHomeCare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 333);
            this.Controls.Add(this.dtgBeneficiario);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtNomBenef);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.hacToolStrip1);
            this.ModoTela = ModoEdicao.Edicao;
            this.Name = "FrmPesqBenefHomeCare";
            this.Text = "SGS - Sistema de Gestão Hospitalar E";
            ((System.ComponentModel.ISupportInitialize)(this.dtgBeneficiario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip hacToolStrip1;
        private HacLabel hacLabel1;
        private HacTextBox txtNomBenef;
        private HacButton btnPesquisar;
        private HacDataGridView dtgBeneficiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtHomeCare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNmBeneficiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCdPlano;
    }
}