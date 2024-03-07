namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmSelecaoProntuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelecaoProntuario));
            this.dgvProntuario = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colProntuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProntuario)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProntuario
            // 
            this.dgvProntuario.AllowUserToAddRows = false;
            this.dgvProntuario.AllowUserToDeleteRows = false;
            this.dgvProntuario.AllowUserToOrderColumns = true;
            this.dgvProntuario.AllowUserToResizeColumns = false;
            this.dgvProntuario.AllowUserToResizeRows = false;
            this.dgvProntuario.AlterarStatus = false;
            this.dgvProntuario.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProntuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProntuario.ColumnHeadersHeight = 21;
            this.dgvProntuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProntuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProntuario});
            this.dgvProntuario.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.dgvProntuario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProntuario.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvProntuario.GridPesquisa = true;
            this.dgvProntuario.Limpar = true;
            this.dgvProntuario.Location = new System.Drawing.Point(7, 38);
            this.dgvProntuario.MultiSelect = false;
            this.dgvProntuario.Name = "dgvProntuario";
            this.dgvProntuario.NaoAjustarEdicao = true;
            this.dgvProntuario.Obrigatorio = false;
            this.dgvProntuario.ObrigatorioMensagem = null;
            this.dgvProntuario.PreValidacaoMensagem = null;
            this.dgvProntuario.PreValidado = false;
            this.dgvProntuario.ReadOnly = true;
            this.dgvProntuario.RowHeadersVisible = false;
            this.dgvProntuario.RowHeadersWidth = 25;
            this.dgvProntuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProntuario.Size = new System.Drawing.Size(325, 223);
            this.dgvProntuario.TabIndex = 12;
            this.dgvProntuario.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPessoas_CellMouseDoubleClick);
            this.dgvProntuario.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPessoas_CellMouseDoubleClick);
            // 
            // colProntuario
            // 
            this.colProntuario.HeaderText = "Prontuário";
            this.colProntuario.Name = "colProntuario";
            this.colProntuario.ReadOnly = true;
            this.colProntuario.Width = 300;
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
            this.tspCommand.Size = new System.Drawing.Size(344, 28);
            this.tspCommand.TabIndex = 13;
            this.tspCommand.TituloTela = null;
            // 
            // FrmSelecaoProntuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 273);
            this.ControlBox = false;
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.dgvProntuario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelecaoProntuario";
            this.ShowInTaskbar = false;
            this.Text = "Seleção de Prontuário";
            this.Load += new System.EventHandler(this.FrmSelecaoProntuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProntuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.DataGridView grdBeneficiario;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvProntuario;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProntuario;
    }
}