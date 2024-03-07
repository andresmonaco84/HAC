using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmAddSubGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddSubGrupo));
            this.dtgSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.btnOk = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.chkSelTodos = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colGrupoIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubGrupoIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSubGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSubGrupo
            // 
            this.dtgSubGrupo.AllowUserToAddRows = false;
            this.dtgSubGrupo.AllowUserToDeleteRows = false;
            this.dtgSubGrupo.AllowUserToResizeColumns = false;
            this.dtgSubGrupo.AllowUserToResizeRows = false;
            this.dtgSubGrupo.AlterarStatus = false;
            this.dtgSubGrupo.BackgroundColor = System.Drawing.Color.White;
            this.dtgSubGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSubGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colGrupoIdt,
            this.colDsGrupo,
            this.colSubGrupoIdt,
            this.colDsSubGrupo});
            this.dtgSubGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgSubGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgSubGrupo.GridPesquisa = false;
            this.dtgSubGrupo.Limpar = false;
            this.dtgSubGrupo.Location = new System.Drawing.Point(12, 36);
            this.dtgSubGrupo.Name = "dtgSubGrupo";
            this.dtgSubGrupo.NaoAjustarEdicao = false;
            this.dtgSubGrupo.Obrigatorio = false;
            this.dtgSubGrupo.ObrigatorioMensagem = null;
            this.dtgSubGrupo.PreValidacaoMensagem = null;
            this.dtgSubGrupo.PreValidado = false;
            this.dtgSubGrupo.RowHeadersWidth = 25;
            this.dtgSubGrupo.Size = new System.Drawing.Size(758, 393);
            this.dtgSubGrupo.TabIndex = 81;
            this.dtgSubGrupo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSubGrupo_CellDoubleClick);
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
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 95;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Selecione os Sub Grupos";
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
            this.btnOk.Location = new System.Drawing.Point(339, 439);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 22);
            this.btnOk.TabIndex = 96;
            this.btnOk.Text = "Confirmar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSelTodos
            // 
            this.chkSelTodos.AutoSize = true;
            this.chkSelTodos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.chkSelTodos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.chkSelTodos.Limpar = false;
            this.chkSelTodos.Location = new System.Drawing.Point(46, 40);
            this.chkSelTodos.Name = "chkSelTodos";
            this.chkSelTodos.Obrigatorio = false;
            this.chkSelTodos.ObrigatorioMensagem = null;
            this.chkSelTodos.PreValidacaoMensagem = null;
            this.chkSelTodos.PreValidado = false;
            this.chkSelTodos.Size = new System.Drawing.Size(15, 14);
            this.chkSelTodos.TabIndex = 97;
            this.chkSelTodos.UseVisualStyleBackColor = true;
            this.chkSelTodos.Click += new System.EventHandler(this.chkSelTodos_Click);
            // 
            // colCheck
            // 
            this.colCheck.FalseValue = "false";
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.TrueValue = "true";
            this.colCheck.Width = 30;
            // 
            // colGrupoIdt
            // 
            this.colGrupoIdt.HeaderText = "GRUPO";
            this.colGrupoIdt.Name = "colGrupoIdt";
            this.colGrupoIdt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGrupoIdt.Width = 50;
            // 
            // colDsGrupo
            // 
            this.colDsGrupo.HeaderText = "Grupo";
            this.colDsGrupo.Name = "colDsGrupo";
            this.colDsGrupo.ReadOnly = true;
            this.colDsGrupo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDsGrupo.Width = 300;
            // 
            // colSubGrupoIdt
            // 
            this.colSubGrupoIdt.HeaderText = "ID";
            this.colSubGrupoIdt.Name = "colSubGrupoIdt";
            this.colSubGrupoIdt.ReadOnly = true;
            this.colSubGrupoIdt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSubGrupoIdt.Width = 50;
            // 
            // colDsSubGrupo
            // 
            this.colDsSubGrupo.HeaderText = "Sub Grupo";
            this.colDsSubGrupo.Name = "colDsSubGrupo";
            this.colDsSubGrupo.ReadOnly = true;
            this.colDsSubGrupo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDsSubGrupo.Width = 300;
            // 
            // FrmAddSubGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 470);
            this.Controls.Add(this.chkSelTodos);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.dtgSubGrupo);
            this.Name = "FrmAddSubGrupo";
            this.Text = "FrmAddSubGrupo";
            this.Load += new System.EventHandler(this.FrmAddSubGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgSubGrupo;
        private HacToolStrip tsHac;
        private HacButton btnOk;
        private HacCheckBox chkSelTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupoIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubGrupoIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSubGrupo;
    }
}