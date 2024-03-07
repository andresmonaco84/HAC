namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmProtocolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProtocolo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblAtendimento = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtNumProtocolo = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtInicio = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.dtgProtocolos = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colNumProt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImprimir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProtocolos)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(451, 28);
            this.tsHac.TabIndex = 1;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Protocolos Paciente";
            this.tsHac.PesquisarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_PesquisarClick);
            // 
            // lblAtendimento
            // 
            this.lblAtendimento.AutoSize = true;
            this.lblAtendimento.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblAtendimento.Location = new System.Drawing.Point(91, 39);
            this.lblAtendimento.Name = "lblAtendimento";
            this.lblAtendimento.Size = new System.Drawing.Size(19, 13);
            this.lblAtendimento.TabIndex = 1;
            this.lblAtendimento.Text = "--";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(8, 39);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(84, 13);
            this.hacLabel2.TabIndex = 35;
            this.hacLabel2.Text = "Atendimento:";
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(8, 67);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(99, 13);
            this.hacLabel1.TabIndex = 34;
            this.hacLabel1.Text = "Num. Protocolo:";
            // 
            // txtNumProtocolo
            // 
            this.txtNumProtocolo.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Numerico;
            this.txtNumProtocolo.BackColor = System.Drawing.Color.Honeydew;
            this.txtNumProtocolo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumProtocolo.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtNumProtocolo.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtNumProtocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumProtocolo.Limpar = true;
            this.txtNumProtocolo.Location = new System.Drawing.Point(109, 64);
            this.txtNumProtocolo.MaxLength = 8;
            this.txtNumProtocolo.Name = "txtNumProtocolo";
            this.txtNumProtocolo.NaoAjustarEdicao = true;
            this.txtNumProtocolo.Obrigatorio = false;
            this.txtNumProtocolo.ObrigatorioMensagem = null;
            this.txtNumProtocolo.PreValidacaoMensagem = null;
            this.txtNumProtocolo.PreValidado = false;
            this.txtNumProtocolo.SelectAllOnFocus = false;
            this.txtNumProtocolo.Size = new System.Drawing.Size(80, 20);
            this.txtNumProtocolo.TabIndex = 2;
            this.txtNumProtocolo.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFim);
            this.groupBox2.Controls.Add(this.txtInicio);
            this.groupBox2.Controls.Add(this.hacLabel5);
            this.groupBox2.Controls.Add(this.hacLabel6);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período do Protocolo para pesquisa";
            // 
            // txtFim
            // 
            this.txtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtFim.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Limpar = true;
            this.txtFim.Location = new System.Drawing.Point(154, 22);
            this.txtFim.MaxLength = 10;
            this.txtFim.Name = "txtFim";
            this.txtFim.NaoAjustarEdicao = true;
            this.txtFim.Obrigatorio = false;
            this.txtFim.ObrigatorioMensagem = null;
            this.txtFim.PreValidacaoMensagem = null;
            this.txtFim.PreValidado = false;
            this.txtFim.SelectAllOnFocus = false;
            this.txtFim.Size = new System.Drawing.Size(80, 20);
            this.txtFim.TabIndex = 2;
            this.txtFim.TabStop = false;
            // 
            // txtInicio
            // 
            this.txtInicio.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtInicio.BackColor = System.Drawing.Color.Honeydew;
            this.txtInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInicio.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtInicio.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Limpar = true;
            this.txtInicio.Location = new System.Drawing.Point(46, 22);
            this.txtInicio.MaxLength = 10;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.NaoAjustarEdicao = true;
            this.txtInicio.Obrigatorio = false;
            this.txtInicio.ObrigatorioMensagem = null;
            this.txtInicio.PreValidacaoMensagem = null;
            this.txtInicio.PreValidado = false;
            this.txtInicio.SelectAllOnFocus = false;
            this.txtInicio.Size = new System.Drawing.Size(80, 20);
            this.txtInicio.TabIndex = 1;
            this.txtInicio.TabStop = false;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(128, 26);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(27, 13);
            this.hacLabel5.TabIndex = 29;
            this.hacLabel5.Text = "Fim";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(7, 26);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(38, 13);
            this.hacLabel6.TabIndex = 28;
            this.hacLabel6.Text = "Início";
            // 
            // dtgProtocolos
            // 
            this.dtgProtocolos.AllowUserToAddRows = false;
            this.dtgProtocolos.AllowUserToDeleteRows = false;
            this.dtgProtocolos.AllowUserToResizeColumns = false;
            this.dtgProtocolos.AllowUserToResizeRows = false;
            this.dtgProtocolos.AlterarStatus = true;
            this.dtgProtocolos.BackgroundColor = System.Drawing.Color.White;
            this.dtgProtocolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProtocolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumProt,
            this.colData,
            this.colQtd,
            this.colImprimir});
            this.dtgProtocolos.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgProtocolos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgProtocolos.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgProtocolos.GridPesquisa = false;
            this.dtgProtocolos.Limpar = true;
            this.dtgProtocolos.Location = new System.Drawing.Point(11, 154);
            this.dtgProtocolos.Name = "dtgProtocolos";
            this.dtgProtocolos.NaoAjustarEdicao = true;
            this.dtgProtocolos.Obrigatorio = false;
            this.dtgProtocolos.ObrigatorioMensagem = null;
            this.dtgProtocolos.PreValidacaoMensagem = null;
            this.dtgProtocolos.PreValidado = false;
            this.dtgProtocolos.RowHeadersVisible = false;
            this.dtgProtocolos.RowHeadersWidth = 21;
            this.dtgProtocolos.RowTemplate.Height = 18;
            this.dtgProtocolos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProtocolos.Size = new System.Drawing.Size(410, 219);
            this.dtgProtocolos.TabIndex = 10;
            this.dtgProtocolos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProtocolos_CellClick);
            // 
            // colNumProt
            // 
            this.colNumProt.DataPropertyName = "UNIDADE";
            this.colNumProt.HeaderText = "Num. Protocolo";
            this.colNumProt.Name = "colNumProt";
            this.colNumProt.ReadOnly = true;
            this.colNumProt.Width = 120;
            // 
            // colData
            // 
            this.colData.DataPropertyName = "ESTOQUE";
            this.colData.HeaderText = "Data Protocolo";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 120;
            // 
            // colQtd
            // 
            this.colQtd.DataPropertyName = "SETOR";
            dataGridViewCellStyle3.NullValue = null;
            this.colQtd.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQtd.HeaderText = "Qtd. Itens";
            this.colQtd.Name = "colQtd";
            this.colQtd.ReadOnly = true;
            this.colQtd.Width = 80;
            // 
            // colImprimir
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colImprimir.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImprimir.HeaderText = "";
            this.colImprimir.Name = "colImprimir";
            this.colImprimir.Text = "IMPRIMIR";
            this.colImprimir.UseColumnTextForButtonValue = true;
            this.colImprimir.Width = 80;
            // 
            // FrmProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 382);
            this.Controls.Add(this.dtgProtocolos);
            this.Controls.Add(this.lblAtendimento);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.txtNumProtocolo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tsHac);
            this.Name = "FrmProtocolo";
            this.Text = "Protocolos Paciente";
            this.Load += new System.EventHandler(this.FrmProtocolo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProtocolos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SGS.Componentes.HacToolStrip tsHac;
        private SGS.Componentes.HacLabel lblAtendimento;
        private SGS.Componentes.HacLabel hacLabel2;
        private SGS.Componentes.HacLabel hacLabel1;
        private SGS.Componentes.HacTextBox txtNumProtocolo;
        private System.Windows.Forms.GroupBox groupBox2;
        private SGS.Componentes.HacTextBox txtFim;
        private SGS.Componentes.HacTextBox txtInicio;
        private SGS.Componentes.HacLabel hacLabel5;
        private SGS.Componentes.HacLabel hacLabel6;
        private SGS.Componentes.HacDataGridView dtgProtocolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumProt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtd;
        private System.Windows.Forms.DataGridViewButtonColumn colImprimir;
    }
}