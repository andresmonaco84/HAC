using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmGrupos
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
            this.dtgMatMed = new HacDataGridView(this.components);
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsMatMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubGrupo = new HacTextBox(this.components);
            this.hacLabel3 = new HacLabel(this.components);
            this.txtGrupo = new HacTextBox(this.components);
            this.hacLabel2 = new HacLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMatMed
            // 
            this.dtgMatMed.AllowUserToAddRows = false;
            this.dtgMatMed.AllowUserToDeleteRows = false;
            this.dtgMatMed.AllowUserToResizeColumns = false;
            this.dtgMatMed.AllowUserToResizeRows = false;
            this.dtgMatMed.AlterarStatus = false;
            this.dtgMatMed.BackgroundColor = System.Drawing.Color.White;
            this.dtgMatMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatMed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatMedIdt,
            this.colDsMatMed});
            this.dtgMatMed.Editavel = ControleEdicao.Sempre;
            this.dtgMatMed.EstadoInicial = EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = false;
            this.dtgMatMed.Location = new System.Drawing.Point(21, 73);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.Size = new System.Drawing.Size(750, 471);
            this.dtgMatMed.TabIndex = 9;
            // 
            // colMatMedIdt
            // 
            this.colMatMedIdt.HeaderText = "Column1";
            this.colMatMedIdt.Name = "colMatMedIdt";
            this.colMatMedIdt.Visible = false;
            // 
            // colDsMatMed
            // 
            this.colDsMatMed.HeaderText = "Descrição";
            this.colDsMatMed.Name = "colDsMatMed";
            this.colDsMatMed.ReadOnly = true;
            this.colDsMatMed.Width = 700;
            // 
            // txtSubGrupo
            // 
            this.txtSubGrupo.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtSubGrupo.BackColor = System.Drawing.Color.White;
            this.txtSubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubGrupo.Editavel = ControleEdicao.Nunca;
            this.txtSubGrupo.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtSubGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSubGrupo.Limpar = false;
            this.txtSubGrupo.Location = new System.Drawing.Point(100, 46);
            this.txtSubGrupo.Name = "txtSubGrupo";
            this.txtSubGrupo.NaoAjustarEdicao = false;
            this.txtSubGrupo.Obrigatorio = false;
            this.txtSubGrupo.ObrigatorioMensagem = null;
            this.txtSubGrupo.PreValidacaoMensagem = null;
            this.txtSubGrupo.PreValidado = false;
            this.txtSubGrupo.ReadOnly = true;
            this.txtSubGrupo.SelectAllOnFocus = false;
            this.txtSubGrupo.Size = new System.Drawing.Size(391, 21);
            this.txtSubGrupo.TabIndex = 8;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(26, 46);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(64, 13);
            this.hacLabel3.TabIndex = 7;
            this.hacLabel3.Text = "SubGrupo";
            // 
            // txtGrupo
            // 
            this.txtGrupo.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.txtGrupo.BackColor = System.Drawing.Color.White;
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Editavel = ControleEdicao.Nunca;
            this.txtGrupo.EstadoInicial = EstadoObjeto.Desabilitado;
            this.txtGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtGrupo.Limpar = false;
            this.txtGrupo.Location = new System.Drawing.Point(100, 22);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.NaoAjustarEdicao = false;
            this.txtGrupo.Obrigatorio = false;
            this.txtGrupo.ObrigatorioMensagem = null;
            this.txtGrupo.PreValidacaoMensagem = null;
            this.txtGrupo.PreValidado = false;
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.SelectAllOnFocus = false;
            this.txtGrupo.Size = new System.Drawing.Size(391, 21);
            this.txtGrupo.TabIndex = 6;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(26, 25);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(42, 13);
            this.hacLabel2.TabIndex = 5;
            this.hacLabel2.Text = "Grupo";
            // 
            // FrmGrupoMatMed
            // 
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.txtSubGrupo);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.hacLabel2);
            this.Name = "FrmGrupoMatMed";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmGrupoMatMed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgMatMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsMatMed;
        private HacTextBox txtSubGrupo;
        private HacLabel hacLabel3;
        private HacTextBox txtGrupo;
        private HacLabel hacLabel2;


    }
}
