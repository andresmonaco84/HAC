namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmGeraArquivoContabil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGeraArquivoContabil));
            this.FileDlg = new System.Windows.Forms.OpenFileDialog();
            this.txtArquivo = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.btnFile = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacDataGridView1 = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtLan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnCtDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnCtCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnCotraPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colvlrLan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompHist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilialLan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDtCota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVlr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCdPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContGer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVlrRat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.hacDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArquivo
            // 
            this.txtArquivo.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtArquivo.BackColor = System.Drawing.Color.Honeydew;
            this.txtArquivo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtArquivo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtArquivo.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtArquivo.Limpar = false;
            this.txtArquivo.Location = new System.Drawing.Point(30, 34);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.NaoAjustarEdicao = false;
            this.txtArquivo.Obrigatorio = false;
            this.txtArquivo.ObrigatorioMensagem = "";
            this.txtArquivo.PreValidacaoMensagem = "";
            this.txtArquivo.PreValidado = false;
            this.txtArquivo.SelectAllOnFocus = false;
            this.txtArquivo.Size = new System.Drawing.Size(379, 21);
            this.txtArquivo.TabIndex = 0;
            // 
            // btnFile
            // 
            this.btnFile.AlterarStatus = true;
            this.btnFile.BackColor = System.Drawing.Color.White;
            this.btnFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFile.BackgroundImage")));
            this.btnFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(424, 34);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(105, 22);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "Abrir";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // hacDataGridView1
            // 
            this.hacDataGridView1.AlterarStatus = false;
            this.hacDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.hacDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hacDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLote,
            this.colDtLan,
            this.colnDoc,
            this.colnCtDev,
            this.colnCtCre,
            this.colnCotraPart,
            this.colvlrLan,
            this.colCodHist,
            this.colCompHist,
            this.colFilialLan,
            this.colcCusto,
            this.colDept,
            this.colDtCota,
            this.colVlr2,
            this.colTpPart,
            this.colCdPart,
            this.colContGer,
            this.colVlrRat});
            this.hacDataGridView1.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.hacDataGridView1.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.hacDataGridView1.GridPesquisa = false;
            this.hacDataGridView1.Limpar = false;
            this.hacDataGridView1.Location = new System.Drawing.Point(7, 80);
            this.hacDataGridView1.Name = "hacDataGridView1";
            this.hacDataGridView1.NaoAjustarEdicao = false;
            this.hacDataGridView1.Obrigatorio = false;
            this.hacDataGridView1.ObrigatorioMensagem = null;
            this.hacDataGridView1.PreValidacaoMensagem = null;
            this.hacDataGridView1.PreValidado = false;
            this.hacDataGridView1.RowHeadersWidth = 25;
            this.hacDataGridView1.Size = new System.Drawing.Size(763, 464);
            this.hacDataGridView1.TabIndex = 2;
            // 
            // colLote
            // 
            this.colLote.HeaderText = "colLote";
            this.colLote.Name = "colLote";
            // 
            // colDtLan
            // 
            this.colDtLan.HeaderText = "colDtLan";
            this.colDtLan.Name = "colDtLan";
            // 
            // colnDoc
            // 
            this.colnDoc.HeaderText = "colnDoc";
            this.colnDoc.Name = "colnDoc";
            // 
            // colnCtDev
            // 
            this.colnCtDev.HeaderText = "colnCtDev";
            this.colnCtDev.Name = "colnCtDev";
            // 
            // colnCtCre
            // 
            this.colnCtCre.HeaderText = "colnCtCre";
            this.colnCtCre.Name = "colnCtCre";
            // 
            // colnCotraPart
            // 
            this.colnCotraPart.HeaderText = "colnCotraPart";
            this.colnCotraPart.Name = "colnCotraPart";
            // 
            // colvlrLan
            // 
            this.colvlrLan.HeaderText = "colvlrLan";
            this.colvlrLan.Name = "colvlrLan";
            // 
            // colCodHist
            // 
            this.colCodHist.HeaderText = "colCodHist";
            this.colCodHist.Name = "colCodHist";
            // 
            // colCompHist
            // 
            this.colCompHist.HeaderText = "colCompHist";
            this.colCompHist.Name = "colCompHist";
            // 
            // colFilialLan
            // 
            this.colFilialLan.HeaderText = "colFilialLan";
            this.colFilialLan.Name = "colFilialLan";
            // 
            // colcCusto
            // 
            this.colcCusto.HeaderText = "colcCusto";
            this.colcCusto.Name = "colcCusto";
            // 
            // colDept
            // 
            this.colDept.HeaderText = "colDept";
            this.colDept.Name = "colDept";
            // 
            // colDtCota
            // 
            this.colDtCota.HeaderText = "colDtCota";
            this.colDtCota.Name = "colDtCota";
            // 
            // colVlr2
            // 
            this.colVlr2.HeaderText = "colVlr2";
            this.colVlr2.Name = "colVlr2";
            // 
            // colTpPart
            // 
            this.colTpPart.HeaderText = "colTpPart";
            this.colTpPart.Name = "colTpPart";
            // 
            // colCdPart
            // 
            this.colCdPart.HeaderText = "colCdPart";
            this.colCdPart.Name = "colCdPart";
            // 
            // colContGer
            // 
            this.colContGer.HeaderText = "colContGer";
            this.colContGer.Name = "colContGer";
            // 
            // colVlrRat
            // 
            this.colVlrRat.HeaderText = "colVlrRat";
            this.colVlrRat.Name = "colVlrRat";
            // 
            // FrmGeraArquivoContabil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 556);
            this.Controls.Add(this.hacDataGridView1);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtArquivo);
            this.Name = "FrmGeraArquivoContabil";
            this.Text = "FrmGeraArquivoContabil";
            ((System.ComponentModel.ISupportInitialize)(this.hacDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog FileDlg;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtArquivo;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnFile;
        private HospitalAnaCosta.SGS.Componentes.HacDataGridView hacDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtLan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnCtDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnCtCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnCotraPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colvlrLan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilialLan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtCota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVlr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCdPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContGer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVlrRat;
    }
}