namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmPesquisaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.txtNomeUsuario = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblNomeUsuario = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.dgvPesquisaUsuario = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.Idt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
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
            this.tspCommand.Size = new System.Drawing.Size(501, 28);
            this.tspCommand.TabIndex = 151;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtNomeUsuario.BackColor = System.Drawing.Color.Honeydew;
            this.txtNomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeUsuario.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtNomeUsuario.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtNomeUsuario.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeUsuario.Limpar = true;
            this.txtNomeUsuario.Location = new System.Drawing.Point(117, 42);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.NaoAjustarEdicao = false;
            this.txtNomeUsuario.Obrigatorio = false;
            this.txtNomeUsuario.ObrigatorioMensagem = null;
            this.txtNomeUsuario.PreValidacaoMensagem = null;
            this.txtNomeUsuario.PreValidado = false;
            this.txtNomeUsuario.SelectAllOnFocus = false;
            this.txtNomeUsuario.Size = new System.Drawing.Size(372, 18);
            this.txtNomeUsuario.TabIndex = 152;
            this.txtNomeUsuario.TextChanged += new System.EventHandler(this.txtNomeUsuario_TextChanged);
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.AutoSize = true;
            this.lblNomeUsuario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeUsuario.Location = new System.Drawing.Point(11, 43);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(100, 14);
            this.lblNomeUsuario.TabIndex = 153;
            this.lblNomeUsuario.Text = "Nome Usuário:";
            // 
            // dgvPesquisaUsuario
            // 
            this.dgvPesquisaUsuario.AllowUserToAddRows = false;
            this.dgvPesquisaUsuario.AllowUserToDeleteRows = false;
            this.dgvPesquisaUsuario.AllowUserToResizeRows = false;
            this.dgvPesquisaUsuario.AlterarStatus = false;
            this.dgvPesquisaUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaUsuario.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPesquisaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idt,
            this.Matricula,
            this.Nome});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPesquisaUsuario.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPesquisaUsuario.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaUsuario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPesquisaUsuario.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaUsuario.GridPesquisa = false;
            this.dgvPesquisaUsuario.Limpar = false;
            this.dgvPesquisaUsuario.Location = new System.Drawing.Point(12, 74);
            this.dgvPesquisaUsuario.MultiSelect = false;
            this.dgvPesquisaUsuario.Name = "dgvPesquisaUsuario";
            this.dgvPesquisaUsuario.NaoAjustarEdicao = false;
            this.dgvPesquisaUsuario.Obrigatorio = false;
            this.dgvPesquisaUsuario.ObrigatorioMensagem = null;
            this.dgvPesquisaUsuario.PreValidacaoMensagem = null;
            this.dgvPesquisaUsuario.PreValidado = false;
            this.dgvPesquisaUsuario.ReadOnly = true;
            this.dgvPesquisaUsuario.RowHeadersVisible = false;
            this.dgvPesquisaUsuario.RowHeadersWidth = 25;
            this.dgvPesquisaUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesquisaUsuario.Size = new System.Drawing.Size(477, 387);
            this.dgvPesquisaUsuario.TabIndex = 154;
            this.dgvPesquisaUsuario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesquisaUsuario_CellDoubleClick);
            // 
            // Idt
            // 
            this.Idt.HeaderText = "Idt";
            this.Idt.Name = "Idt";
            this.Idt.ReadOnly = true;
            this.Idt.Visible = false;
            // 
            // Matricula
            // 
            this.Matricula.HeaderText = "Matrícula";
            this.Matricula.Name = "Matricula";
            this.Matricula.ReadOnly = true;
            this.Matricula.Width = 70;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 380;
            // 
            // FrmPesquisaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 473);
            this.ControlBox = false;
            this.Controls.Add(this.dgvPesquisaUsuario);
            this.Controls.Add(this.txtNomeUsuario);
            this.Controls.Add(this.lblNomeUsuario);
            this.Controls.Add(this.tspCommand);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaUsuario";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaProcedimentoProposto";
            this.Load += new System.EventHandler(this.FrmPesquisaUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacTextBox txtNomeUsuario;
        private Hac.Windows.Forms.Controls.HacLabel lblNomeUsuario;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
    }
}