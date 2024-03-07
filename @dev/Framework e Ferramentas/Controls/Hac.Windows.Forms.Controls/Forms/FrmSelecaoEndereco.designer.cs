namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmSelecaoEndereco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelecaoEndereco));
            this.dgvEnderecos = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.colTipoLogradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomeLogradouro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComplemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdtEndereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnderecos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEnderecos
            // 
            this.dgvEnderecos.AllowUserToAddRows = false;
            this.dgvEnderecos.AllowUserToDeleteRows = false;
            this.dgvEnderecos.AllowUserToOrderColumns = true;
            this.dgvEnderecos.AllowUserToResizeColumns = false;
            this.dgvEnderecos.AllowUserToResizeRows = false;
            this.dgvEnderecos.AlterarStatus = false;
            this.dgvEnderecos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEnderecos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEnderecos.ColumnHeadersHeight = 21;
            this.dgvEnderecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEnderecos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipoLogradouro,
            this.colNomeLogradouro,
            this.colBairro,
            this.colCidade,
            this.colUF,
            this.colCEP,
            this.colComplemento,
            this.colIdtEndereco});
            this.dgvEnderecos.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.dgvEnderecos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEnderecos.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvEnderecos.GridPesquisa = true;
            this.dgvEnderecos.Limpar = true;
            this.dgvEnderecos.Location = new System.Drawing.Point(7, 38);
            this.dgvEnderecos.MultiSelect = false;
            this.dgvEnderecos.Name = "dgvEnderecos";
            this.dgvEnderecos.NaoAjustarEdicao = true;
            this.dgvEnderecos.Obrigatorio = false;
            this.dgvEnderecos.ObrigatorioMensagem = null;
            this.dgvEnderecos.PreValidacaoMensagem = null;
            this.dgvEnderecos.PreValidado = false;
            this.dgvEnderecos.ReadOnly = true;
            this.dgvEnderecos.RowHeadersVisible = false;
            this.dgvEnderecos.RowHeadersWidth = 25;
            this.dgvEnderecos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnderecos.Size = new System.Drawing.Size(904, 229);
            this.dgvEnderecos.TabIndex = 12;
            this.dgvEnderecos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEnderecos_CellMouseDoubleClick);
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
            // colTipoLogradouro
            // 
            this.colTipoLogradouro.HeaderText = "Tipo Logradouro";
            this.colTipoLogradouro.Name = "colTipoLogradouro";
            this.colTipoLogradouro.ReadOnly = true;
            this.colTipoLogradouro.Width = 120;
            // 
            // colNomeLogradouro
            // 
            this.colNomeLogradouro.HeaderText = "Nome Logradouro";
            this.colNomeLogradouro.Name = "colNomeLogradouro";
            this.colNomeLogradouro.ReadOnly = true;
            this.colNomeLogradouro.Width = 250;
            // 
            // colBairro
            // 
            this.colBairro.HeaderText = "Bairro";
            this.colBairro.Name = "colBairro";
            this.colBairro.ReadOnly = true;
            this.colBairro.Width = 150;
            // 
            // colCidade
            // 
            this.colCidade.HeaderText = "Cidade";
            this.colCidade.Name = "colCidade";
            this.colCidade.ReadOnly = true;
            this.colCidade.Width = 150;
            // 
            // colUF
            // 
            this.colUF.HeaderText = "UF";
            this.colUF.Name = "colUF";
            this.colUF.ReadOnly = true;
            this.colUF.Width = 50;
            // 
            // colCEP
            // 
            this.colCEP.HeaderText = "CEP";
            this.colCEP.Name = "colCEP";
            this.colCEP.ReadOnly = true;
            this.colCEP.Width = 90;
            // 
            // colComplemento
            // 
            this.colComplemento.HeaderText = "Complemento";
            this.colComplemento.Name = "colComplemento";
            this.colComplemento.ReadOnly = true;
            this.colComplemento.Width = 90;
            // 
            // colIdtEndereco
            // 
            this.colIdtEndereco.HeaderText = "IdtEndereco";
            this.colIdtEndereco.Name = "colIdtEndereco";
            this.colIdtEndereco.ReadOnly = true;
            this.colIdtEndereco.Visible = false;
            // 
            // FrmSelecaoEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 270);
            this.ControlBox = false;
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.dgvEnderecos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelecaoEndereco";
            this.ShowInTaskbar = false;
            this.Text = "Pesquisa de Pacientes";
            this.Load += new System.EventHandler(this.FrmSelecaoEndereco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnderecos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.DataGridView grdBeneficiario;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvEnderecos;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoLogradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeLogradouro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComplemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdtEndereco;
    }
}