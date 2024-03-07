namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmSelecaoPessoaPaciente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelecaoPessoaPaciente));
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvPessoas = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataNascimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeMae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoCivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataAtualizacaoPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPessoaFlagAtivoOK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPacientes = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomePlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProntuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataAtualizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPacienteFlagAtivoOK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxPessoa = new System.Windows.Forms.GroupBox();
            this.gbxPaciente = new System.Windows.Forms.GroupBox();
            this.btnAdicionarNovoPaciente = new System.Windows.Forms.ToolStripButton();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPessoas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.gbxPessoa.SuspendLayout();
            this.gbxPaciente.SuspendLayout();
            this.tspCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(94, 25);
            this.toolStripLabel1.Text = "Novo Paciente";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // dgvPessoas
            // 
            this.dgvPessoas.AllowUserToAddRows = false;
            this.dgvPessoas.AllowUserToDeleteRows = false;
            this.dgvPessoas.AllowUserToOrderColumns = true;
            this.dgvPessoas.AllowUserToResizeColumns = false;
            this.dgvPessoas.AllowUserToResizeRows = false;
            this.dgvPessoas.AlterarStatus = false;
            this.dgvPessoas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPessoas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPessoas.ColumnHeadersHeight = 21;
            this.dgvPessoas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPessoas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNome,
            this.colDataNascimento,
            this.colSexo,
            this.colNomeMae,
            this.colEstadoCivil,
            this.colRG,
            this.colCPF,
            this.colIdtPessoa,
            this.colDataAtualizacaoPessoa,
            this.colPessoaFlagAtivoOK});
            this.dgvPessoas.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.dgvPessoas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPessoas.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPessoas.GridPesquisa = true;
            this.dgvPessoas.Limpar = true;
            this.dgvPessoas.Location = new System.Drawing.Point(10, 20);
            this.dgvPessoas.MultiSelect = false;
            this.dgvPessoas.Name = "dgvPessoas";
            this.dgvPessoas.NaoAjustarEdicao = true;
            this.dgvPessoas.Obrigatorio = false;
            this.dgvPessoas.ObrigatorioMensagem = null;
            this.dgvPessoas.PreValidacaoMensagem = null;
            this.dgvPessoas.PreValidado = false;
            this.dgvPessoas.ReadOnly = true;
            this.dgvPessoas.RowHeadersVisible = false;
            this.dgvPessoas.RowHeadersWidth = 25;
            this.dgvPessoas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPessoas.Size = new System.Drawing.Size(904, 173);
            this.dgvPessoas.TabIndex = 15;
            this.dgvPessoas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPessoas_CellMouseClick);
            this.dgvPessoas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPessoas_CellMouseDoubleClick);
            // 
            // colNome
            // 
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 220;
            // 
            // colDataNascimento
            // 
            this.colDataNascimento.HeaderText = "Data Nasc.";
            this.colDataNascimento.Name = "colDataNascimento";
            this.colDataNascimento.ReadOnly = true;
            this.colDataNascimento.Width = 90;
            // 
            // colSexo
            // 
            this.colSexo.HeaderText = "Sexo";
            this.colSexo.Name = "colSexo";
            this.colSexo.ReadOnly = true;
            this.colSexo.Width = 80;
            // 
            // colNomeMae
            // 
            this.colNomeMae.HeaderText = "Nome Mãe";
            this.colNomeMae.Name = "colNomeMae";
            this.colNomeMae.ReadOnly = true;
            this.colNomeMae.Width = 180;
            // 
            // colEstadoCivil
            // 
            this.colEstadoCivil.HeaderText = "Est. Civil";
            this.colEstadoCivil.Name = "colEstadoCivil";
            this.colEstadoCivil.ReadOnly = true;
            this.colEstadoCivil.Width = 80;
            // 
            // colRG
            // 
            this.colRG.HeaderText = "RG";
            this.colRG.Name = "colRG";
            this.colRG.ReadOnly = true;
            this.colRG.Width = 70;
            // 
            // colCPF
            // 
            this.colCPF.HeaderText = "CPF";
            this.colCPF.Name = "colCPF";
            this.colCPF.ReadOnly = true;
            this.colCPF.Width = 70;
            // 
            // colIdtPessoa
            // 
            this.colIdtPessoa.HeaderText = "IdtPessoa";
            this.colIdtPessoa.Name = "colIdtPessoa";
            this.colIdtPessoa.ReadOnly = true;
            this.colIdtPessoa.Visible = false;
            // 
            // colDataAtualizacaoPessoa
            // 
            this.colDataAtualizacaoPessoa.HeaderText = "Data";
            this.colDataAtualizacaoPessoa.Name = "colDataAtualizacaoPessoa";
            this.colDataAtualizacaoPessoa.ReadOnly = true;
            this.colDataAtualizacaoPessoa.Width = 90;
            // 
            // colPessoaFlagAtivoOK
            // 
            this.colPessoaFlagAtivoOK.HeaderText = "Status";
            this.colPessoaFlagAtivoOK.Name = "colPessoaFlagAtivoOK";
            this.colPessoaFlagAtivoOK.ReadOnly = true;
            this.colPessoaFlagAtivoOK.Visible = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConvenio,
            this.colNomeConvenio,
            this.colPlano,
            this.colNomePlano,
            this.colCredencial,
            this.colProntuario,
            this.colDataAtualizacao,
            this.colIdtPaciente,
            this.colStatusPlano,
            this.colPacienteFlagAtivoOK});
            this.dgvPacientes.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.dgvPacientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPacientes.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPacientes.GridPesquisa = true;
            this.dgvPacientes.Limpar = true;
            this.dgvPacientes.Location = new System.Drawing.Point(9, 20);
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
            this.dgvPacientes.TabIndex = 16;
            this.dgvPacientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPacientes_CellMouseClick);
            this.dgvPacientes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPacientes_CellMouseDoubleClick);
            this.dgvPacientes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_RowEnter);
            // 
            // colConvenio
            // 
            this.colConvenio.HeaderText = "Convênio";
            this.colConvenio.Name = "colConvenio";
            this.colConvenio.ReadOnly = true;
            this.colConvenio.Width = 70;
            // 
            // colNomeConvenio
            // 
            this.colNomeConvenio.HeaderText = "Nome Convênio";
            this.colNomeConvenio.Name = "colNomeConvenio";
            this.colNomeConvenio.ReadOnly = true;
            this.colNomeConvenio.Width = 190;
            // 
            // colPlano
            // 
            this.colPlano.HeaderText = "Plano";
            this.colPlano.Name = "colPlano";
            this.colPlano.ReadOnly = true;
            this.colPlano.Width = 55;
            // 
            // colNomePlano
            // 
            this.colNomePlano.HeaderText = "Nome  Plano";
            this.colNomePlano.Name = "colNomePlano";
            this.colNomePlano.ReadOnly = true;
            this.colNomePlano.Width = 190;
            // 
            // colCredencial
            // 
            this.colCredencial.HeaderText = "Credencial";
            this.colCredencial.Name = "colCredencial";
            this.colCredencial.ReadOnly = true;
            this.colCredencial.Width = 110;
            // 
            // colProntuario
            // 
            this.colProntuario.HeaderText = "Prontuário";
            this.colProntuario.Name = "colProntuario";
            this.colProntuario.ReadOnly = true;
            // 
            // colDataAtualizacao
            // 
            this.colDataAtualizacao.HeaderText = "Data";
            this.colDataAtualizacao.Name = "colDataAtualizacao";
            this.colDataAtualizacao.ReadOnly = true;
            this.colDataAtualizacao.Width = 85;
            // 
            // colIdtPaciente
            // 
            this.colIdtPaciente.HeaderText = "IdtPaciente";
            this.colIdtPaciente.Name = "colIdtPaciente";
            this.colIdtPaciente.ReadOnly = true;
            this.colIdtPaciente.Visible = false;
            // 
            // colStatusPlano
            // 
            this.colStatusPlano.HeaderText = "Status Plano";
            this.colStatusPlano.Name = "colStatusPlano";
            this.colStatusPlano.ReadOnly = true;
            this.colStatusPlano.Width = 80;
            // 
            // colPacienteFlagAtivoOK
            // 
            this.colPacienteFlagAtivoOK.HeaderText = "Status";
            this.colPacienteFlagAtivoOK.Name = "colPacienteFlagAtivoOK";
            this.colPacienteFlagAtivoOK.ReadOnly = true;
            this.colPacienteFlagAtivoOK.Visible = false;
            // 
            // gbxPessoa
            // 
            this.gbxPessoa.Controls.Add(this.dgvPessoas);
            this.gbxPessoa.Location = new System.Drawing.Point(5, 34);
            this.gbxPessoa.Name = "gbxPessoa";
            this.gbxPessoa.Size = new System.Drawing.Size(922, 207);
            this.gbxPessoa.TabIndex = 17;
            this.gbxPessoa.TabStop = false;
            this.gbxPessoa.Text = "PESSOA";
            // 
            // gbxPaciente
            // 
            this.gbxPaciente.Controls.Add(this.dgvPacientes);
            this.gbxPaciente.Location = new System.Drawing.Point(5, 249);
            this.gbxPaciente.Name = "gbxPaciente";
            this.gbxPaciente.Size = new System.Drawing.Size(922, 260);
            this.gbxPaciente.TabIndex = 18;
            this.gbxPaciente.TabStop = false;
            this.gbxPaciente.Text = "PACIENTE";
            // 
            // btnAdicionarNovoPaciente
            // 
            this.btnAdicionarNovoPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdicionarNovoPaciente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdicionarNovoPaciente.Image = global::Hac.Windows.Forms.Controls.Properties.Resources.Add_patient;
            this.btnAdicionarNovoPaciente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionarNovoPaciente.Name = "btnAdicionarNovoPaciente";
            this.btnAdicionarNovoPaciente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdicionarNovoPaciente.Size = new System.Drawing.Size(159, 25);
            this.btnAdicionarNovoPaciente.Text = "Nova Pessoa / Paciente";
            this.btnAdicionarNovoPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdicionarNovoPaciente.ToolTipText = "Adicionar Nova Pessoa/Paciente";
            this.btnAdicionarNovoPaciente.Click += new System.EventHandler(this.btnAdicionarNovoPaciente_Click);
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionarNovoPaciente});
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.PesquisarVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(933, 28);
            this.tspCommand.TabIndex = 14;
            this.tspCommand.TituloTela = null;
            this.tspCommand.ToolTipSalvar = "Salvar";
            this.tspCommand.SairClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_SairClick);
            // 
            // FrmSelecaoPessoaPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 520);
            this.ControlBox = false;
            this.Controls.Add(this.gbxPaciente);
            this.Controls.Add(this.gbxPessoa);
            this.Controls.Add(this.tspCommand);
            this.Name = "FrmSelecaoPessoaPaciente";
            this.Text = "FrmSelecaoPessoaPaciente";
            this.Load += new System.EventHandler(this.FrmSelecaoPessoaPaciente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPessoas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.gbxPessoa.ResumeLayout(false);
            this.gbxPaciente.ResumeLayout(false);
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacDataGridView dgvPessoas;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPacientes;
        private System.Windows.Forms.GroupBox gbxPessoa;
        private System.Windows.Forms.GroupBox gbxPaciente;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataNascimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeMae;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoCivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataAtualizacaoPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPessoaFlagAtivoOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomePlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProntuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataAtualizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPacienteFlagAtivoOK;
        private System.Windows.Forms.ToolStripButton btnAdicionarNovoPaciente;
        private HacToolStrip tspCommand;
    }
}