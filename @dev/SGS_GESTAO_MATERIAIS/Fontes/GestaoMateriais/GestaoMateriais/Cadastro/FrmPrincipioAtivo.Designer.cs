using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmPrincipioAtivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipioAtivo));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.dtgMatMed = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.colMatMedIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMatMedDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblMed = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.grbAddMed = new System.Windows.Forms.GroupBox();
            this.btnAdd = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.cmbMatMed = new HospitalAnaCosta.SGS.Componentes.HacComboBox(this.components);
            this.grbSal = new System.Windows.Forms.GroupBox();
            this.grbDadosMed = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtOrientacao = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.cbFlebitante = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.cbIrritante = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.cbVesicante = new HospitalAnaCosta.SGS.Componentes.HacCheckBox(this.components);
            this.lblDosagem = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblFormaFarm = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblSal = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).BeginInit();
            this.grbAddMed.SuspendLayout();
            this.grbSal.SuspendLayout();
            this.grbDadosMed.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsHac
            // 
            this.tsHac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsHac.BackgroundImage")));
            this.tsHac.CancelarVisivel = false;
            this.tsHac.ExcluirVisivel = false;
            this.tsHac.ImprimirVisivel = false;
            this.tsHac.LimparVisivel = false;
            this.tsHac.Location = new System.Drawing.Point(0, 0);
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(782, 28);
            this.tsHac.TabIndex = 122;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Cadastro de Similares";
            this.tsHac.SalvarClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_SalvarClick);
            this.tsHac.MatMedClick += new HospitalAnaCosta.SGS.Componentes.ToolStripHacEventHandler(this.tsHac_MatMedClick);
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
            this.colDeletar,
            this.colMatMedDescricao});
            this.dtgMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.dtgMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgMatMed.GridPesquisa = false;
            this.dtgMatMed.Limpar = false;
            this.dtgMatMed.Location = new System.Drawing.Point(8, 202);
            this.dtgMatMed.Name = "dtgMatMed";
            this.dtgMatMed.NaoAjustarEdicao = false;
            this.dtgMatMed.Obrigatorio = false;
            this.dtgMatMed.ObrigatorioMensagem = null;
            this.dtgMatMed.PreValidacaoMensagem = null;
            this.dtgMatMed.PreValidado = false;
            this.dtgMatMed.RowHeadersWidth = 25;
            this.dtgMatMed.Size = new System.Drawing.Size(764, 245);
            this.dtgMatMed.TabIndex = 123;
            this.dtgMatMed.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMatMed_CellDoubleClick);
            // 
            // colMatMedIdt
            // 
            this.colMatMedIdt.HeaderText = "colMatMedIdt";
            this.colMatMedIdt.Name = "colMatMedIdt";
            this.colMatMedIdt.Visible = false;
            // 
            // colDeletar
            // 
            this.colDeletar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDeletar.HeaderText = "Excluir";
            this.colDeletar.Image = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_excluir;
            this.colDeletar.Name = "colDeletar";
            this.colDeletar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDeletar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeletar.ToolTipText = "Excluir Linha";
            this.colDeletar.Width = 50;
            // 
            // colMatMedDescricao
            // 
            this.colMatMedDescricao.HeaderText = "Produto";
            this.colMatMedDescricao.Name = "colMatMedDescricao";
            this.colMatMedDescricao.ReadOnly = true;
            this.colMatMedDescricao.Width = 650;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(10, 37);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(112, 13);
            this.hacLabel1.TabIndex = 124;
            this.hacLabel1.Text = "Item Selecionado:";
            // 
            // lblMed
            // 
            this.lblMed.AutoSize = true;
            this.lblMed.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMed.Location = new System.Drawing.Point(123, 34);
            this.lblMed.Name = "lblMed";
            this.lblMed.Size = new System.Drawing.Size(16, 18);
            this.lblMed.TabIndex = 125;
            this.lblMed.Text = "-";
            // 
            // grbAddMed
            // 
            this.grbAddMed.Controls.Add(this.btnAdd);
            this.grbAddMed.Controls.Add(this.hacLabel7);
            this.grbAddMed.Controls.Add(this.cmbMatMed);
            this.grbAddMed.Enabled = false;
            this.grbAddMed.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAddMed.Location = new System.Drawing.Point(6, 146);
            this.grbAddMed.Name = "grbAddMed";
            this.grbAddMed.Size = new System.Drawing.Size(764, 48);
            this.grbAddMed.TabIndex = 127;
            this.grbAddMed.TabStop = false;
            this.grbAddMed.Text = "Adicionar item similar";
            // 
            // btnAdd
            // 
            this.btnAdd.AlterarStatus = true;
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(657, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 22);
            this.btnAdd.TabIndex = 127;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(4, 25);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(51, 13);
            this.hacLabel7.TabIndex = 126;
            this.hacLabel7.Text = "Produto";
            // 
            // cmbMatMed
            // 
            this.cmbMatMed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMatMed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMatMed.BackColor = System.Drawing.Color.Honeydew;
            this.cmbMatMed.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.cmbMatMed.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.cmbMatMed.FormattingEnabled = true;
            this.cmbMatMed.Limpar = true;
            this.cmbMatMed.Location = new System.Drawing.Point(61, 21);
            this.cmbMatMed.Name = "cmbMatMed";
            this.cmbMatMed.Obrigatorio = false;
            this.cmbMatMed.ObrigatorioMensagem = null;
            this.cmbMatMed.PreValidacaoMensagem = null;
            this.cmbMatMed.PreValidado = false;
            this.cmbMatMed.Size = new System.Drawing.Size(580, 21);
            this.cmbMatMed.TabIndex = 125;
            this.cmbMatMed.Text = "<Selecione>";
            this.cmbMatMed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMatMed_KeyDown);
            // 
            // grbSal
            // 
            this.grbSal.Controls.Add(this.grbDadosMed);
            this.grbSal.Controls.Add(this.lblDosagem);
            this.grbSal.Controls.Add(this.hacLabel6);
            this.grbSal.Controls.Add(this.lblFormaFarm);
            this.grbSal.Controls.Add(this.hacLabel4);
            this.grbSal.Controls.Add(this.lblSal);
            this.grbSal.Controls.Add(this.hacLabel2);
            this.grbSal.Location = new System.Drawing.Point(8, 55);
            this.grbSal.Name = "grbSal";
            this.grbSal.Size = new System.Drawing.Size(762, 85);
            this.grbSal.TabIndex = 128;
            this.grbSal.TabStop = false;
            // 
            // grbDadosMed
            // 
            this.grbDadosMed.Controls.Add(this.btnSalvar);
            this.grbDadosMed.Controls.Add(this.hacLabel5);
            this.grbDadosMed.Controls.Add(this.txtOrientacao);
            this.grbDadosMed.Controls.Add(this.cbFlebitante);
            this.grbDadosMed.Controls.Add(this.cbIrritante);
            this.grbDadosMed.Controls.Add(this.cbVesicante);
            this.grbDadosMed.Location = new System.Drawing.Point(407, 9);
            this.grbDadosMed.Name = "grbDadosMed";
            this.grbDadosMed.Size = new System.Drawing.Size(349, 69);
            this.grbDadosMed.TabIndex = 129;
            this.grbDadosMed.TabStop = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.AlterarStatus = true;
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.disk;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(324, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(18, 18);
            this.btnSalvar.TabIndex = 164;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(3, 44);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(69, 13);
            this.hacLabel5.TabIndex = 163;
            this.hacLabel5.Text = "Orientação";
            // 
            // txtOrientacao
            // 
            this.txtOrientacao.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtOrientacao.BackColor = System.Drawing.Color.Honeydew;
            this.txtOrientacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrientacao.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtOrientacao.Enabled = false;
            this.txtOrientacao.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtOrientacao.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtOrientacao.Limpar = true;
            this.txtOrientacao.Location = new System.Drawing.Point(73, 40);
            this.txtOrientacao.MaxLength = 100;
            this.txtOrientacao.Name = "txtOrientacao";
            this.txtOrientacao.NaoAjustarEdicao = false;
            this.txtOrientacao.Obrigatorio = false;
            this.txtOrientacao.ObrigatorioMensagem = "Digite a Descrição";
            this.txtOrientacao.PreValidacaoMensagem = null;
            this.txtOrientacao.PreValidado = false;
            this.txtOrientacao.SelectAllOnFocus = false;
            this.txtOrientacao.Size = new System.Drawing.Size(269, 21);
            this.txtOrientacao.TabIndex = 162;
            // 
            // cbFlebitante
            // 
            this.cbFlebitante.AutoSize = true;
            this.cbFlebitante.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbFlebitante.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbFlebitante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFlebitante.Limpar = true;
            this.cbFlebitante.Location = new System.Drawing.Point(215, 15);
            this.cbFlebitante.Name = "cbFlebitante";
            this.cbFlebitante.Obrigatorio = false;
            this.cbFlebitante.ObrigatorioMensagem = null;
            this.cbFlebitante.PreValidacaoMensagem = null;
            this.cbFlebitante.PreValidado = false;
            this.cbFlebitante.Size = new System.Drawing.Size(105, 17);
            this.cbFlebitante.TabIndex = 161;
            this.cbFlebitante.Text = "FLEBITANTE";
            this.cbFlebitante.UseVisualStyleBackColor = true;
            // 
            // cbIrritante
            // 
            this.cbIrritante.AutoSize = true;
            this.cbIrritante.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbIrritante.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbIrritante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIrritante.Limpar = true;
            this.cbIrritante.Location = new System.Drawing.Point(12, 15);
            this.cbIrritante.Name = "cbIrritante";
            this.cbIrritante.Obrigatorio = false;
            this.cbIrritante.ObrigatorioMensagem = null;
            this.cbIrritante.PreValidacaoMensagem = null;
            this.cbIrritante.PreValidado = false;
            this.cbIrritante.Size = new System.Drawing.Size(96, 17);
            this.cbIrritante.TabIndex = 161;
            this.cbIrritante.Text = "IRRITANTE";
            this.cbIrritante.UseVisualStyleBackColor = true;
            // 
            // cbVesicante
            // 
            this.cbVesicante.AutoSize = true;
            this.cbVesicante.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.cbVesicante.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.cbVesicante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVesicante.Limpar = true;
            this.cbVesicante.Location = new System.Drawing.Point(112, 15);
            this.cbVesicante.Name = "cbVesicante";
            this.cbVesicante.Obrigatorio = false;
            this.cbVesicante.ObrigatorioMensagem = null;
            this.cbVesicante.PreValidacaoMensagem = null;
            this.cbVesicante.PreValidado = false;
            this.cbVesicante.Size = new System.Drawing.Size(98, 17);
            this.cbVesicante.TabIndex = 160;
            this.cbVesicante.Text = "VESICANTE";
            this.cbVesicante.UseVisualStyleBackColor = true;
            // 
            // lblDosagem
            // 
            this.lblDosagem.AutoSize = true;
            this.lblDosagem.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblDosagem.Location = new System.Drawing.Point(95, 62);
            this.lblDosagem.Name = "lblDosagem";
            this.lblDosagem.Size = new System.Drawing.Size(21, 14);
            this.lblDosagem.TabIndex = 130;
            this.lblDosagem.Text = "--";
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(25, 63);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(71, 13);
            this.hacLabel6.TabIndex = 129;
            this.hacLabel6.Text = "DOSAGEM:";
            // 
            // lblFormaFarm
            // 
            this.lblFormaFarm.AutoSize = true;
            this.lblFormaFarm.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFormaFarm.Location = new System.Drawing.Point(95, 38);
            this.lblFormaFarm.Name = "lblFormaFarm";
            this.lblFormaFarm.Size = new System.Drawing.Size(21, 14);
            this.lblFormaFarm.TabIndex = 128;
            this.lblFormaFarm.Text = "--";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(5, 39);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(91, 13);
            this.hacLabel4.TabIndex = 127;
            this.hacLabel4.Text = "FORMA FARM.:";
            // 
            // lblSal
            // 
            this.lblSal.AutoSize = true;
            this.lblSal.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblSal.Location = new System.Drawing.Point(95, 14);
            this.lblSal.Name = "lblSal";
            this.lblSal.Size = new System.Drawing.Size(21, 14);
            this.lblSal.TabIndex = 126;
            this.lblSal.Text = "--";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(62, 15);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(34, 13);
            this.hacLabel2.TabIndex = 125;
            this.hacLabel2.Text = "SAL:";
            // 
            // FrmPrincipioAtivo
            // 
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.grbSal);
            this.Controls.Add(this.grbAddMed);
            this.Controls.Add(this.lblMed);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.dtgMatMed);
            this.Controls.Add(this.tsHac);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPrincipioAtivo";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmPrincipioAtivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatMed)).EndInit();
            this.grbAddMed.ResumeLayout(false);
            this.grbAddMed.PerformLayout();
            this.grbSal.ResumeLayout(false);
            this.grbSal.PerformLayout();
            this.grbDadosMed.ResumeLayout(false);
            this.grbDadosMed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacDataGridView dtgMatMed;
        private HacLabel hacLabel1;
        private HacLabel lblMed;
        private System.Windows.Forms.GroupBox grbAddMed;
        private HacButton btnAdd;
        private HacLabel hacLabel7;
        private HacComboBox cmbMatMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedIdt;
        private System.Windows.Forms.DataGridViewImageColumn colDeletar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatMedDescricao;
        private System.Windows.Forms.GroupBox grbSal;
        private HacLabel lblDosagem;
        private HacLabel hacLabel6;
        private HacLabel lblFormaFarm;
        private HacLabel hacLabel4;
        private HacLabel lblSal;
        private HacLabel hacLabel2;
        private System.Windows.Forms.GroupBox grbDadosMed;
        private HacCheckBox cbVesicante;
        private HacCheckBox cbFlebitante;
        private HacCheckBox cbIrritante;
        private HacLabel hacLabel5;
        private HacTextBox txtOrientacao;
        private HacButton btnSalvar;
    }
}
