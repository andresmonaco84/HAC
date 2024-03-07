namespace Hac.Windows.Forms.Controls.Forms
{
    partial class FrmReplicarPlanos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReplicarPlanos));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSelTodos = new Hac.Windows.Forms.Controls.HacCheckBox(this.components);
            this.dgvPesquisaPlano = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colSeleciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdtPlano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.tsbOK = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTodos = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.rbInf = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.rbSup = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.rbCom = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.rmMid = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.rmPremium = new Hac.Windows.Forms.Controls.HacRadioButton(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaPlano)).BeginInit();
            this.tspCommand.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSelTodos);
            this.groupBox2.Controls.Add(this.dgvPesquisaPlano);
            this.groupBox2.Location = new System.Drawing.Point(7, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 383);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // chkSelTodos
            // 
            this.chkSelTodos.AutoSize = true;
            this.chkSelTodos.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.chkSelTodos.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.chkSelTodos.Limpar = true;
            this.chkSelTodos.Location = new System.Drawing.Point(16, 17);
            this.chkSelTodos.Name = "chkSelTodos";
            this.chkSelTodos.NaoAjustarEdicao = true;
            this.chkSelTodos.Obrigatorio = false;
            this.chkSelTodos.ObrigatorioMensagem = null;
            this.chkSelTodos.PreValidacaoMensagem = null;
            this.chkSelTodos.PreValidado = false;
            this.chkSelTodos.Size = new System.Drawing.Size(15, 14);
            this.chkSelTodos.TabIndex = 190;
            this.chkSelTodos.UseVisualStyleBackColor = true;
            this.chkSelTodos.Visible = false;
            this.chkSelTodos.CheckedChanged += new System.EventHandler(this.chkSelTodos_CheckedChanged);
            // 
            // dgvPesquisaPlano
            // 
            this.dgvPesquisaPlano.AllowUserToAddRows = false;
            this.dgvPesquisaPlano.AllowUserToDeleteRows = false;
            this.dgvPesquisaPlano.AllowUserToResizeRows = false;
            this.dgvPesquisaPlano.AlterarStatus = false;
            this.dgvPesquisaPlano.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPesquisaPlano.BackgroundColor = System.Drawing.Color.White;
            this.dgvPesquisaPlano.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Verdana", 9F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPesquisaPlano.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvPesquisaPlano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesquisaPlano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeleciona,
            this.IdtPlano,
            this.Codigo,
            this.Descricao,
            this.Categoria});
            this.dgvPesquisaPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.dgvPesquisaPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.dgvPesquisaPlano.GridPesquisa = false;
            this.dgvPesquisaPlano.Limpar = false;
            this.dgvPesquisaPlano.Location = new System.Drawing.Point(6, 12);
            this.dgvPesquisaPlano.MultiSelect = false;
            this.dgvPesquisaPlano.Name = "dgvPesquisaPlano";
            this.dgvPesquisaPlano.NaoAjustarEdicao = false;
            this.dgvPesquisaPlano.Obrigatorio = false;
            this.dgvPesquisaPlano.ObrigatorioMensagem = null;
            this.dgvPesquisaPlano.PreValidacaoMensagem = null;
            this.dgvPesquisaPlano.PreValidado = false;
            this.dgvPesquisaPlano.RowHeadersVisible = false;
            this.dgvPesquisaPlano.RowHeadersWidth = 25;
            this.dgvPesquisaPlano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPesquisaPlano.Size = new System.Drawing.Size(590, 365);
            this.dgvPesquisaPlano.TabIndex = 155;
            // 
            // colSeleciona
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.NullValue = false;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.White;
            this.colSeleciona.DefaultCellStyle = dataGridViewCellStyle20;
            this.colSeleciona.Frozen = true;
            this.colSeleciona.HeaderText = "";
            this.colSeleciona.Name = "colSeleciona";
            this.colSeleciona.Width = 30;
            // 
            // IdtPlano
            // 
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.White;
            this.IdtPlano.DefaultCellStyle = dataGridViewCellStyle21;
            this.IdtPlano.Frozen = true;
            this.IdtPlano.HeaderText = "Código";
            this.IdtPlano.Name = "IdtPlano";
            this.IdtPlano.Width = 60;
            // 
            // Codigo
            // 
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.White;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle22;
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Prestador";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Descricao
            // 
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.White;
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle23;
            this.Descricao.Frozen = true;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 330;
            // 
            // Categoria
            // 
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White;
            this.Categoria.DefaultCellStyle = dataGridViewCellStyle24;
            this.Categoria.Frozen = true;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 80;
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOK});
            this.tspCommand.LimparVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.PesquisarVisivel = false;
            this.tspCommand.SairVisivel = false;
            this.tspCommand.SalvarHabilitado = false;
            this.tspCommand.SalvarText = "Salvar";
            this.tspCommand.SalvarTextTamanho = 70;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(615, 25);
            this.tspCommand.TabIndex = 153;
            this.tspCommand.Text = "tspCommand";
            this.tspCommand.TituloTela = "";
            this.tspCommand.ToolTipSalvar = "Salvar";
            // 
            // tsbOK
            // 
            this.tsbOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOK.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.tsbOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOK.Name = "tsbOK";
            this.tsbOK.Size = new System.Drawing.Size(31, 22);
            this.tsbOK.Text = "OK";
            this.tsbOK.Click += new System.EventHandler(this.tsbOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rmPremium);
            this.groupBox1.Controls.Add(this.rmMid);
            this.groupBox1.Controls.Add(this.rbCom);
            this.groupBox1.Controls.Add(this.rbTodos);
            this.groupBox1.Controls.Add(this.rbInf);
            this.groupBox1.Controls.Add(this.rbSup);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(109, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 37);
            this.groupBox1.TabIndex = 154;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar Categoria";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rbTodos.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rbTodos.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Limpar = false;
            this.rbTodos.Location = new System.Drawing.Point(13, 16);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Obrigatorio = false;
            this.rbTodos.ObrigatorioMensagem = null;
            this.rbTodos.PreValidacaoMensagem = null;
            this.rbTodos.PreValidado = false;
            this.rbTodos.Size = new System.Drawing.Size(58, 17);
            this.rbTodos.TabIndex = 155;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.Click += new System.EventHandler(this.rbTodos_Click);
            // 
            // rbInf
            // 
            this.rbInf.AutoSize = true;
            this.rbInf.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rbInf.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rbInf.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInf.Limpar = false;
            this.rbInf.Location = new System.Drawing.Point(158, 16);
            this.rbInf.Name = "rbInf";
            this.rbInf.Obrigatorio = false;
            this.rbInf.ObrigatorioMensagem = null;
            this.rbInf.PreValidacaoMensagem = null;
            this.rbInf.PreValidado = false;
            this.rbInf.Size = new System.Drawing.Size(68, 17);
            this.rbInf.TabIndex = 1;
            this.rbInf.Text = "Inferior";
            this.rbInf.UseVisualStyleBackColor = true;
            this.rbInf.Click += new System.EventHandler(this.rbInf_Click);
            // 
            // rbSup
            // 
            this.rbSup.AutoSize = true;
            this.rbSup.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rbSup.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rbSup.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSup.Limpar = false;
            this.rbSup.Location = new System.Drawing.Point(79, 16);
            this.rbSup.Name = "rbSup";
            this.rbSup.Obrigatorio = false;
            this.rbSup.ObrigatorioMensagem = null;
            this.rbSup.PreValidacaoMensagem = null;
            this.rbSup.PreValidado = false;
            this.rbSup.Size = new System.Drawing.Size(74, 17);
            this.rbSup.TabIndex = 0;
            this.rbSup.Text = "Superior";
            this.rbSup.UseVisualStyleBackColor = true;
            this.rbSup.Click += new System.EventHandler(this.rbSup_Click);
            // 
            // rbCom
            // 
            this.rbCom.AutoSize = true;
            this.rbCom.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rbCom.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rbCom.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCom.Limpar = false;
            this.rbCom.Location = new System.Drawing.Point(231, 16);
            this.rbCom.Name = "rbCom";
            this.rbCom.Obrigatorio = false;
            this.rbCom.ObrigatorioMensagem = null;
            this.rbCom.PreValidacaoMensagem = null;
            this.rbCom.PreValidado = false;
            this.rbCom.Size = new System.Drawing.Size(91, 17);
            this.rbCom.TabIndex = 156;
            this.rbCom.Text = "Community";
            this.rbCom.UseVisualStyleBackColor = true;
            this.rbCom.Click += new System.EventHandler(this.rbCom_Click);
            // 
            // rmMid
            // 
            this.rmMid.AutoSize = true;
            this.rmMid.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rmMid.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rmMid.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmMid.Limpar = false;
            this.rmMid.Location = new System.Drawing.Point(327, 16);
            this.rmMid.Name = "rmMid";
            this.rmMid.Obrigatorio = false;
            this.rmMid.ObrigatorioMensagem = null;
            this.rmMid.PreValidacaoMensagem = null;
            this.rmMid.PreValidado = false;
            this.rmMid.Size = new System.Drawing.Size(85, 17);
            this.rmMid.TabIndex = 157;
            this.rmMid.Text = "Midmarket";
            this.rmMid.UseVisualStyleBackColor = true;
            this.rmMid.Click += new System.EventHandler(this.rmMid_Click);
            // 
            // rmPremium
            // 
            this.rmPremium.AutoSize = true;
            this.rmPremium.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.rmPremium.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.rmPremium.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmPremium.Limpar = false;
            this.rmPremium.Location = new System.Drawing.Point(419, 16);
            this.rmPremium.Name = "rmPremium";
            this.rmPremium.Obrigatorio = false;
            this.rmPremium.ObrigatorioMensagem = null;
            this.rmPremium.PreValidacaoMensagem = null;
            this.rmPremium.PreValidado = false;
            this.rmPremium.Size = new System.Drawing.Size(76, 17);
            this.rmPremium.TabIndex = 158;
            this.rmPremium.Text = "Premium";
            this.rmPremium.UseVisualStyleBackColor = true;
            this.rmPremium.Click += new System.EventHandler(this.rmPremium_Click);
            // 
            // FrmReplicarPlanos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 445);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReplicarPlanos";
            this.ShowInTaskbar = false;
            this.Text = "FrmPesquisaPlano";
            this.Load += new System.EventHandler(this.FrmReplicarPlanos_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesquisaPlano)).EndInit();
            this.tspCommand.ResumeLayout(false);
            this.tspCommand.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Hac.Windows.Forms.Controls.HacDataGridView dgvPesquisaPlano;
        private HacToolStrip tspCommand;
        private System.Windows.Forms.ToolStripButton tsbOK;
        private HacCheckBox chkSelTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private HacRadioButton rbTodos;
        private HacRadioButton rbInf;
        private HacRadioButton rbSup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdtPlano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private HacRadioButton rmPremium;
        private HacRadioButton rmMid;
        private HacRadioButton rbCom;
    }
}