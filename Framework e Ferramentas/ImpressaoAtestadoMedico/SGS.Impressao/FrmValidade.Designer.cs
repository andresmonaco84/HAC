namespace SGS.ClientControl
{
    partial class FrmValidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValidade));
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CAD_PVE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAD_PVE_DS_EXAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAD_PVE_QT_VALIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAD_PVE_UN_TEMPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAD_PVE_FL_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionar.Location = new System.Drawing.Point(48, 238);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(122, 23);
            this.btnSelecionar.TabIndex = 0;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(196, 238);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(122, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CAD_PVE_ID,
            this.CAD_PVE_DS_EXAME,
            this.CAD_PVE_QT_VALIDADE,
            this.CAD_PVE_UN_TEMPO,
            this.CAD_PVE_FL_STATUS});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(48, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(270, 166);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // CAD_PVE_ID
            // 
            this.CAD_PVE_ID.DataPropertyName = "CAD_PVE_ID";
            this.CAD_PVE_ID.HeaderText = "CAD_PVE_ID";
            this.CAD_PVE_ID.Name = "CAD_PVE_ID";
            this.CAD_PVE_ID.ReadOnly = true;
            this.CAD_PVE_ID.Visible = false;
            // 
            // CAD_PVE_DS_EXAME
            // 
            this.CAD_PVE_DS_EXAME.DataPropertyName = "CAD_PVE_DS_EXAME";
            this.CAD_PVE_DS_EXAME.HeaderText = "TIPO";
            this.CAD_PVE_DS_EXAME.Name = "CAD_PVE_DS_EXAME";
            this.CAD_PVE_DS_EXAME.ReadOnly = true;
            this.CAD_PVE_DS_EXAME.Width = 130;
            // 
            // CAD_PVE_QT_VALIDADE
            // 
            this.CAD_PVE_QT_VALIDADE.DataPropertyName = "CAD_PVE_QT_VALIDADE";
            this.CAD_PVE_QT_VALIDADE.HeaderText = "QTD.";
            this.CAD_PVE_QT_VALIDADE.Name = "CAD_PVE_QT_VALIDADE";
            this.CAD_PVE_QT_VALIDADE.ReadOnly = true;
            this.CAD_PVE_QT_VALIDADE.Width = 60;
            // 
            // CAD_PVE_UN_TEMPO
            // 
            this.CAD_PVE_UN_TEMPO.DataPropertyName = "CAD_PVE_UN_TEMPO";
            this.CAD_PVE_UN_TEMPO.HeaderText = "TEMPO";
            this.CAD_PVE_UN_TEMPO.Name = "CAD_PVE_UN_TEMPO";
            this.CAD_PVE_UN_TEMPO.ReadOnly = true;
            this.CAD_PVE_UN_TEMPO.Width = 80;
            // 
            // CAD_PVE_FL_STATUS
            // 
            this.CAD_PVE_FL_STATUS.DataPropertyName = "CAD_PVE_FL_STATUS";
            this.CAD_PVE_FL_STATUS.HeaderText = "CAD_PVE_FL_STATUS";
            this.CAD_PVE_FL_STATUS.Name = "CAD_PVE_FL_STATUS";
            this.CAD_PVE_FL_STATUS.ReadOnly = true;
            this.CAD_PVE_FL_STATUS.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione o Período de Validade";
            // 
            // FrmValidade
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(374, 279);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSelecionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmValidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hospital Ana Costa - Gerenciador de impressão";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmValidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAD_PVE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAD_PVE_DS_EXAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAD_PVE_QT_VALIDADE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAD_PVE_UN_TEMPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAD_PVE_FL_STATUS;
        private System.Windows.Forms.Label label1;

    }
}