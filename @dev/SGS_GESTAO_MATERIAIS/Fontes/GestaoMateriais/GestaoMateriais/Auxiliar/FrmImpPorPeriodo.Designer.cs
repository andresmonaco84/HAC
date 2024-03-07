namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmImpPorPeriodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpPorPeriodo));
            this.btnImprimir = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnCancelar = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDtProced = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nmMinIni = new System.Windows.Forms.NumericUpDown();
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.nmHoraIni = new System.Windows.Forms.NumericUpDown();
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDtIni = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel2 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nmMinFim = new System.Windows.Forms.NumericUpDown();
            this.hacLabel3 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.nmHoraFim = new System.Windows.Forms.NumericUpDown();
            this.hacLabel5 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtDtFim = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacLabel6 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel9 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel8 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel10 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel11 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.hacLabel12 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinIni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHoraIni)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinFim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHoraFim)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.AlterarStatus = true;
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(319, 127);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(105, 22);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AlterarStatus = true;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(437, 127);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 22);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDtProced);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 47);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Procedimento";
            // 
            // txtDtProced
            // 
            this.txtDtProced.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtProced.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtProced.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDtProced.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtProced.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtProced.Limpar = false;
            this.txtDtProced.Location = new System.Drawing.Point(6, 19);
            this.txtDtProced.MaxLength = 10;
            this.txtDtProced.Name = "txtDtProced";
            this.txtDtProced.NaoAjustarEdicao = false;
            this.txtDtProced.Obrigatorio = false;
            this.txtDtProced.ObrigatorioMensagem = "";
            this.txtDtProced.PreValidacaoMensagem = "";
            this.txtDtProced.PreValidado = false;
            this.txtDtProced.SelectAllOnFocus = false;
            this.txtDtProced.Size = new System.Drawing.Size(100, 21);
            this.txtDtProced.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nmMinIni);
            this.groupBox2.Controls.Add(this.hacLabel4);
            this.groupBox2.Controls.Add(this.nmHoraIni);
            this.groupBox2.Controls.Add(this.hacLabel1);
            this.groupBox2.Controls.Add(this.txtDtIni);
            this.groupBox2.Controls.Add(this.hacLabel2);
            this.groupBox2.Location = new System.Drawing.Point(136, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período Inicial";
            // 
            // nmMinIni
            // 
            this.nmMinIni.Location = new System.Drawing.Point(52, 73);
            this.nmMinIni.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nmMinIni.Name = "nmMinIni";
            this.nmMinIni.Size = new System.Drawing.Size(41, 20);
            this.nmMinIni.TabIndex = 22;
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(6, 75);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(44, 13);
            this.hacLabel4.TabIndex = 21;
            this.hacLabel4.Text = "Minuto";
            // 
            // nmHoraIni
            // 
            this.nmHoraIni.Location = new System.Drawing.Point(52, 48);
            this.nmHoraIni.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nmHoraIni.Name = "nmHoraIni";
            this.nmHoraIni.Size = new System.Drawing.Size(41, 20);
            this.nmHoraIni.TabIndex = 20;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(6, 52);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(34, 13);
            this.hacLabel1.TabIndex = 19;
            this.hacLabel1.Text = "Hora";
            // 
            // txtDtIni
            // 
            this.txtDtIni.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtIni.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtIni.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDtIni.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtIni.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtIni.Limpar = false;
            this.txtDtIni.Location = new System.Drawing.Point(52, 23);
            this.txtDtIni.MaxLength = 10;
            this.txtDtIni.Name = "txtDtIni";
            this.txtDtIni.NaoAjustarEdicao = false;
            this.txtDtIni.Obrigatorio = false;
            this.txtDtIni.ObrigatorioMensagem = "";
            this.txtDtIni.PreValidacaoMensagem = "";
            this.txtDtIni.PreValidado = false;
            this.txtDtIni.SelectAllOnFocus = false;
            this.txtDtIni.Size = new System.Drawing.Size(100, 21);
            this.txtDtIni.TabIndex = 18;
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(6, 26);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(34, 13);
            this.hacLabel2.TabIndex = 17;
            this.hacLabel2.Text = "Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nmMinFim);
            this.groupBox3.Controls.Add(this.hacLabel3);
            this.groupBox3.Controls.Add(this.nmHoraFim);
            this.groupBox3.Controls.Add(this.hacLabel5);
            this.groupBox3.Controls.Add(this.txtDtFim);
            this.groupBox3.Controls.Add(this.hacLabel6);
            this.groupBox3.Location = new System.Drawing.Point(342, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Período Final";
            // 
            // nmMinFim
            // 
            this.nmMinFim.Location = new System.Drawing.Point(52, 73);
            this.nmMinFim.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nmMinFim.Name = "nmMinFim";
            this.nmMinFim.Size = new System.Drawing.Size(41, 20);
            this.nmMinFim.TabIndex = 22;
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(6, 75);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(44, 13);
            this.hacLabel3.TabIndex = 21;
            this.hacLabel3.Text = "Minuto";
            // 
            // nmHoraFim
            // 
            this.nmHoraFim.Location = new System.Drawing.Point(52, 48);
            this.nmHoraFim.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nmHoraFim.Name = "nmHoraFim";
            this.nmHoraFim.Size = new System.Drawing.Size(41, 20);
            this.nmHoraFim.TabIndex = 20;
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(6, 52);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(34, 13);
            this.hacLabel5.TabIndex = 19;
            this.hacLabel5.Text = "Hora";
            // 
            // txtDtFim
            // 
            this.txtDtFim.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtDtFim.BackColor = System.Drawing.Color.Honeydew;
            this.txtDtFim.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtDtFim.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtDtFim.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtDtFim.Limpar = false;
            this.txtDtFim.Location = new System.Drawing.Point(52, 23);
            this.txtDtFim.MaxLength = 10;
            this.txtDtFim.Name = "txtDtFim";
            this.txtDtFim.NaoAjustarEdicao = false;
            this.txtDtFim.Obrigatorio = false;
            this.txtDtFim.ObrigatorioMensagem = "";
            this.txtDtFim.PreValidacaoMensagem = "";
            this.txtDtFim.PreValidado = false;
            this.txtDtFim.SelectAllOnFocus = false;
            this.txtDtFim.Size = new System.Drawing.Size(100, 21);
            this.txtDtFim.TabIndex = 18;
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(6, 26);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(34, 13);
            this.hacLabel6.TabIndex = 17;
            this.hacLabel6.Text = "Data";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(554, 125);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ajuda";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.hacLabel12);
            this.panel1.Controls.Add(this.hacLabel11);
            this.panel1.Controls.Add(this.hacLabel10);
            this.panel1.Controls.Add(this.hacLabel9);
            this.panel1.Controls.Add(this.hacLabel8);
            this.panel1.Controls.Add(this.hacLabel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 106);
            this.panel1.TabIndex = 25;
            // 
            // hacLabel7
            // 
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.Location = new System.Drawing.Point(24, 8);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(519, 31);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Para Imprimir uma relação completa dos produtos consumidos para o Paciente deixe " +
                "todos os campos em Branco";
            // 
            // hacLabel9
            // 
            this.hacLabel9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel9.Location = new System.Drawing.Point(24, 57);
            this.hacLabel9.Name = "hacLabel9";
            this.hacLabel9.Size = new System.Drawing.Size(519, 45);
            this.hacLabel9.TabIndex = 2;
            this.hacLabel9.Text = "A Hora é Obrigatória na impressão por periodo, se você deixa-la zerada o sistema " +
                "entende que como Zero Hora e irá filtrar na data digitada iniciando ou terminand" +
                "o neste horário";
            // 
            // hacLabel8
            // 
            this.hacLabel8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel8.Location = new System.Drawing.Point(24, 37);
            this.hacLabel8.Name = "hacLabel8";
            this.hacLabel8.Size = new System.Drawing.Size(519, 16);
            this.hacLabel8.TabIndex = 1;
            this.hacLabel8.Text = "Para imprimir a relação de um periodo Digite a Data e Hora de inicio e fim ";
            // 
            // hacLabel10
            // 
            this.hacLabel10.AutoSize = true;
            this.hacLabel10.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel10.Location = new System.Drawing.Point(6, 8);
            this.hacLabel10.Name = "hacLabel10";
            this.hacLabel10.Size = new System.Drawing.Size(18, 18);
            this.hacLabel10.TabIndex = 3;
            this.hacLabel10.Text = "?";
            // 
            // hacLabel11
            // 
            this.hacLabel11.AutoSize = true;
            this.hacLabel11.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel11.Location = new System.Drawing.Point(6, 37);
            this.hacLabel11.Name = "hacLabel11";
            this.hacLabel11.Size = new System.Drawing.Size(18, 18);
            this.hacLabel11.TabIndex = 4;
            this.hacLabel11.Text = "?";
            // 
            // hacLabel12
            // 
            this.hacLabel12.AutoSize = true;
            this.hacLabel12.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel12.Location = new System.Drawing.Point(6, 69);
            this.hacLabel12.Name = "hacLabel12";
            this.hacLabel12.Size = new System.Drawing.Size(19, 18);
            this.hacLabel12.TabIndex = 5;
            this.hacLabel12.Text = "*";
            // 
            // FrmImpPorPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 280);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Name = "FrmImpPorPeriodo";
            this.Text = "Impressão Materiais e Medicamentos";
            this.Load += new System.EventHandler(this.FrmImpPorPeriodo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinIni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHoraIni)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinFim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmHoraFim)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacButton btnImprimir;
        private HospitalAnaCosta.SGS.Componentes.HacButton btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtDtProced;
        private System.Windows.Forms.GroupBox groupBox2;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel1;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtDtIni;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel2;
        private System.Windows.Forms.NumericUpDown nmMinIni;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel4;
        private System.Windows.Forms.NumericUpDown nmHoraIni;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nmMinFim;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel3;
        private System.Windows.Forms.NumericUpDown nmHoraFim;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel5;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtDtFim;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel9;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel7;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel10;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel8;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel12;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel11;
    }
}