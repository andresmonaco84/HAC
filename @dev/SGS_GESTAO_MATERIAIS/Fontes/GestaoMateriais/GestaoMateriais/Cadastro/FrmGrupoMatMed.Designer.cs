using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmGrupoMatMed
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
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabGrupo = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colSubGrupoIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsSubGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgGrupo = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colGrupoIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMatMed = new System.Windows.Forms.TabPage();
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsMatMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubGrupo = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtGrupo = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.tabPrincipal.SuspendLayout();
            this.tabGrupo.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubGrupo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).BeginInit();
            this.tabMatMed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabGrupo);
            this.tabPrincipal.Controls.Add(this.tabMatMed);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(792, 566);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabGrupo
            // 
            this.tabGrupo.Controls.Add(this.panel3);
            this.tabGrupo.Controls.Add(this.panel1);
            this.tabGrupo.Location = new System.Drawing.Point(4, 22);
            this.tabGrupo.Name = "tabGrupo";
            this.tabGrupo.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrupo.Size = new System.Drawing.Size(784, 540);
            this.tabGrupo.TabIndex = 0;
            this.tabGrupo.Text = "Grupos e Sub Grupos";
            this.tabGrupo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgSubGrupo);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 256);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(778, 280);
            this.panel3.TabIndex = 3;
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
            this.colSubGrupoIdt,
            this.colDsSubGrupo});
            this.dtgSubGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSubGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgSubGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgSubGrupo.GridPesquisa = false;
            this.dtgSubGrupo.Limpar = false;
            this.dtgSubGrupo.Location = new System.Drawing.Point(0, 24);
            this.dtgSubGrupo.Name = "dtgSubGrupo";
            this.dtgSubGrupo.NaoAjustarEdicao = false;
            this.dtgSubGrupo.Obrigatorio = false;
            this.dtgSubGrupo.ObrigatorioMensagem = null;
            this.dtgSubGrupo.PreValidacaoMensagem = null;
            this.dtgSubGrupo.PreValidado = false;
            this.dtgSubGrupo.RowHeadersWidth = 25;
            this.dtgSubGrupo.Size = new System.Drawing.Size(778, 256);
            this.dtgSubGrupo.TabIndex = 80;
            this.dtgSubGrupo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSubGrupo_CellDoubleClick);
            // 
            // colSubGrupoIdt
            // 
            this.colSubGrupoIdt.HeaderText = "ID";
            this.colSubGrupoIdt.Name = "colSubGrupoIdt";
            this.colSubGrupoIdt.ReadOnly = true;
            // 
            // colDsSubGrupo
            // 
            this.colDsSubGrupo.HeaderText = "Descrição";
            this.colDsSubGrupo.Name = "colDsSubGrupo";
            this.colDsSubGrupo.ReadOnly = true;
            this.colDsSubGrupo.Width = 600;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgGrupo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 253);
            this.panel1.TabIndex = 2;
            // 
            // dtgGrupo
            // 
            this.dtgGrupo.AllowUserToAddRows = false;
            this.dtgGrupo.AllowUserToDeleteRows = false;
            this.dtgGrupo.AllowUserToResizeColumns = false;
            this.dtgGrupo.AllowUserToResizeRows = false;
            this.dtgGrupo.AlterarStatus = false;
            this.dtgGrupo.BackgroundColor = System.Drawing.Color.White;
            this.dtgGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGrupoIdt,
            this.colDsGrupo});
            this.dtgGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgGrupo.GridPesquisa = false;
            this.dtgGrupo.Limpar = false;
            this.dtgGrupo.Location = new System.Drawing.Point(0, 24);
            this.dtgGrupo.Name = "dtgGrupo";
            this.dtgGrupo.NaoAjustarEdicao = false;
            this.dtgGrupo.Obrigatorio = false;
            this.dtgGrupo.ObrigatorioMensagem = null;
            this.dtgGrupo.PreValidacaoMensagem = null;
            this.dtgGrupo.PreValidado = false;
            this.dtgGrupo.RowHeadersWidth = 25;
            this.dtgGrupo.Size = new System.Drawing.Size(750, 223);
            this.dtgGrupo.TabIndex = 71;
            this.dtgGrupo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupo_CellDoubleClick);
            this.dtgGrupo.SelectionChanged += new System.EventHandler(this.dtgGrupo_SelectionChanged);
            // 
            // colGrupoIdt
            // 
            this.colGrupoIdt.HeaderText = "ID";
            this.colGrupoIdt.Name = "colGrupoIdt";
            this.colGrupoIdt.ReadOnly = true;
            // 
            // colDsGrupo
            // 
            this.colDsGrupo.HeaderText = "Descrição";
            this.colDsGrupo.Name = "colDsGrupo";
            this.colDsGrupo.ReadOnly = true;
            this.colDsGrupo.Width = 600;
            // 
            // tabMatMed
            // 
            this.tabMatMed.Controls.Add(this.dtgMatMed);
            this.tabMatMed.Controls.Add(this.txtSubGrupo);
            this.tabMatMed.Controls.Add(this.hacLabel3);
            this.tabMatMed.Controls.Add(this.txtGrupo);
            this.tabMatMed.Controls.Add(this.hacLabel2);
            this.tabMatMed.Location = new System.Drawing.Point(4, 22);
            this.tabMatMed.Name = "tabMatMed";
            this.tabMatMed.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatMed.Size = new System.Drawing.Size(784, 540);
            this.tabMatMed.TabIndex = 1;
            this.tabMatMed.Text = "Materiais e Medicamentos";
            this.tabMatMed.UseVisualStyleBackColor = true;
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
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = false;
            this.dtgMatMed.Location = new System.Drawing.Point(3, 61);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.Size = new System.Drawing.Size(750, 471);
            this.dtgMatMed.TabIndex = 4;
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
            this.txtSubGrupo.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtSubGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.txtSubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtSubGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtSubGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSubGrupo.Limpar = false;
            this.txtSubGrupo.Location = new System.Drawing.Point(82, 34);
            this.txtSubGrupo.Name = "txtSubGrupo";
            this.txtSubGrupo.NaoAjustarEdicao = false;
            this.txtSubGrupo.Obrigatorio = false;
            this.txtSubGrupo.ObrigatorioMensagem = null;
            this.txtSubGrupo.PreValidacaoMensagem = null;
            this.txtSubGrupo.PreValidado = false;
            this.txtSubGrupo.ReadOnly = true;
            this.txtSubGrupo.SelectAllOnFocus = false;
            this.txtSubGrupo.Size = new System.Drawing.Size(391, 21);
            this.txtSubGrupo.TabIndex = 3;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(8, 34);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(64, 13);
            this.hacLabel3.TabIndex = 2;
            this.hacLabel3.Text = "SubGrupo";
            // 
            // txtGrupo
            // 
            this.txtGrupo.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtGrupo.BackColor = System.Drawing.Color.Honeydew;
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtGrupo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtGrupo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtGrupo.Limpar = false;
            this.txtGrupo.Location = new System.Drawing.Point(82, 10);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.NaoAjustarEdicao = false;
            this.txtGrupo.Obrigatorio = false;
            this.txtGrupo.ObrigatorioMensagem = null;
            this.txtGrupo.PreValidacaoMensagem = null;
            this.txtGrupo.PreValidado = false;
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.SelectAllOnFocus = false;
            this.txtGrupo.Size = new System.Drawing.Size(391, 21);
            this.txtGrupo.TabIndex = 1;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(8, 13);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(42, 13);
            this.hacLabel2.TabIndex = 0;
            this.hacLabel2.Text = "Grupo";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel4.Controls.Add(this.hacLabel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(778, 24);
            this.panel4.TabIndex = 69;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.ForeColor = System.Drawing.Color.ForestGreen;
            this.hacLabel1.Location = new System.Drawing.Point(6, 4);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(250, 13);
            this.hacLabel1.TabIndex = 0;
            this.hacLabel1.Text = "SubGrupos Materiais e Medicamentos";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel2.Controls.Add(this.hacLabel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 24);
            this.panel2.TabIndex = 68;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.ForeColor = System.Drawing.Color.ForestGreen;
            this.hacLabel7.Location = new System.Drawing.Point(6, 4);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(230, 13);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Grupos  Materiais e Medicamentos";
            // 
            // FrmGrupoMatMed
            // 
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tabPrincipal);
            this.Name = "FrmGrupoMatMed";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmGrupoMatMed_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabGrupo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubGrupo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).EndInit();
            this.tabMatMed.ResumeLayout(false);
            this.tabMatMed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabGrupo;
        private System.Windows.Forms.Panel panel3;
        private HacDataGridView dtgSubGrupo;
        private System.Windows.Forms.Panel panel4;
        private HacLabel hacLabel1;
        private System.Windows.Forms.Panel panel1;
        private HacDataGridView dtgGrupo;
        private System.Windows.Forms.Panel panel2;
        private HacLabel hacLabel7;
        private System.Windows.Forms.TabPage tabMatMed;
        private HacLabel hacLabel2;
        private HacDataGridView dtgMatMed;
        private HacTextBox txtSubGrupo;
        private HacLabel hacLabel3;
        private HacTextBox txtGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubGrupoIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsSubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupoIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsMatMed;

    }
}
