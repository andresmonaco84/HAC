namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmSelecaoPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelecaoPaciente));
            this.dgvPacientes = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProntuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AllowUserToOrderColumns = true;
            this.dgvPacientes.AllowUserToResizeColumns = false;
            this.dgvPacientes.AllowUserToResizeRows = false;
            this.dgvPacientes.AlterarStatus = false;
            this.dgvPacientes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConvenio,
            this.colPlano,
            this.colCredencial,
            this.colProntuario,
            this.colCPF,
            this.colRG,
            this.colNome,
            this.colEstadoCivil,
            this.colSexo,
            this.colIdtPaciente});
            this.dgvPacientes.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.dgvPacientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPacientes.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPacientes.GridPesquisa = true;
            this.dgvPacientes.Limpar = true;
            this.dgvPacientes.Location = new System.Drawing.Point(7, 35);
            this.dgvPacientes.MultiSelect = false;
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.NaoAjustarEdicao = true;
            this.dgvPacientes.Obrigatorio = false;
            this.dgvPacientes.ObrigatorioMensagem = null;
            this.dgvPacientes.PreValidacaoMensagem = null;
            this.dgvPacientes.PreValidado = false;
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.RowHeadersVisible = false;
            this.dgvPacientes.RowHeadersWidth = 25;
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(904, 229);
            this.dgvPacientes.TabIndex = 12;
            this.dgvPacientes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPacientes_CellMouseDoubleClick);
            // 
            // colConvenio
            // 
            this.colConvenio.HeaderText = "Convênio";
            this.colConvenio.Name = "colConvenio";
            this.colConvenio.ReadOnly = true;
            this.colConvenio.Width = 70;
            // 
            // colPlano
            // 
            this.colPlano.HeaderText = "Plano";
            this.colPlano.Name = "colPlano";
            this.colPlano.ReadOnly = true;
            this.colPlano.Width = 60;
            // 
            // colCredencial
            // 
            this.colCredencial.HeaderText = "Credencial";
            this.colCredencial.Name = "colCredencial";
            this.colCredencial.ReadOnly = true;
            this.colCredencial.Width = 120;
            // 
            // colProntuario
            // 
            this.colProntuario.HeaderText = "Prontuário";
            this.colProntuario.Name = "colProntuario";
            this.colProntuario.ReadOnly = true;
            this.colProntuario.Width = 90;
            // 
            // colCPF
            // 
            this.colCPF.HeaderText = "CPF";
            this.colCPF.Name = "colCPF";
            this.colCPF.ReadOnly = true;
            this.colCPF.Width = 90;
            // 
            // colRG
            // 
            this.colRG.HeaderText = "RG";
            this.colRG.Name = "colRG";
            this.colRG.ReadOnly = true;
            this.colRG.Width = 90;
            // 
            // colNome
            // 
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 195;
            // 
            // colEstadoCivil
            // 
            this.colEstadoCivil.HeaderText = "Est. Civil";
            this.colEstadoCivil.Name = "colEstadoCivil";
            this.colEstadoCivil.ReadOnly = true;
            this.colEstadoCivil.Width = 85;
            // 
            // colSexo
            // 
            this.colSexo.HeaderText = "Sexo";
            this.colSexo.Name = "colSexo";
            this.colSexo.ReadOnly = true;
            this.colSexo.Width = 80;
            // 
            // colIdtPaciente
            // 
            this.colIdtPaciente.HeaderText = "IdtPaciente";
            this.colIdtPaciente.Name = "colIdtPaciente";
            this.colIdtPaciente.ReadOnly = true;
            this.colIdtPaciente.Visible = false;
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.PesquisarVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(917, 28);
            this.tspCommand.TabIndex = 13;
            this.tspCommand.TituloTela = null;
            this.tspCommand.SairClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_SairClick);
            // 
            // FrmPesquisaPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 270);
            this.ControlBox = false;
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.dgvPacientes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaPaciente";
            this.ShowInTaskbar = false;
            this.Text = "Pesquisa de Pacientes";
            this.Load += new System.EventHandler(this.FrmPesquisaPaciente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.DataGridView grdBeneficiario;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProntuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexo;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtPaciente;
    }
}