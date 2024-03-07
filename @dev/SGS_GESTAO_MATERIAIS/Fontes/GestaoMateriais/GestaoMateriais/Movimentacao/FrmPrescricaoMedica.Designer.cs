using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    partial class FrmPrescricaoMedica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrescricaoMedica));
            this.label5 = new System.Windows.Forms.Label();
            this.dtgPrescricao = new HacDataGridView(this.components);
            this.colDtPrescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDsMatMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHrMatMed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hacTextBox7 = new HacTextBox(this.components);
            this.hacTextBox5 = new HacTextBox(this.components);
            this.hacTextBox4 = new HacTextBox(this.components);
            this.hacTextBox3 = new HacTextBox(this.components);
            this.hacTextBox2 = new HacTextBox(this.components);
            this.hacTextBox1 = new HacTextBox(this.components);
            this.hacLabel1 = new HacLabel(this.components);
            this.hacLabel2 = new HacLabel(this.components);
            this.hacLabel3 = new HacLabel(this.components);
            this.hacLabel4 = new HacLabel(this.components);
            this.hacLabel5 = new HacLabel(this.components);
            this.hacTextBox6 = new HacTextBox(this.components);
            this.hacTextBox8 = new HacTextBox(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hacButton1 = new HacButton(this.components);
            this.hacButton2 = new HacButton(this.components);
            this.hacButton3 = new HacButton(this.components);
            this.hacButton8 = new HacButton(this.components);
            this.hacButton9 = new HacButton(this.components);
            this.hacLabel6 = new HacLabel(this.components);
            this.hacTextBox9 = new HacTextBox(this.components);
            this.hacTextBox10 = new HacTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hacLabel7 = new HacLabel(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrescricao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(633, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Andar/Ala";
            // 
            // dtgPrescricao
            // 
            this.dtgPrescricao.BackgroundColor = System.Drawing.Color.White;
            this.dtgPrescricao.AllowUserToAddRows = false;
            this.dtgPrescricao.AllowUserToDeleteRows = false;
            this.dtgPrescricao.AllowUserToResizeColumns = false;
            this.dtgPrescricao.AllowUserToResizeRows = false;
            this.dtgPrescricao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPrescricao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDtPrescricao,
            this.colDsMatMed,
            this.colHrMatMed});
            this.dtgPrescricao.Location = new System.Drawing.Point(12, 181);
            this.dtgPrescricao.Name = "dtgPrescricao";
            this.dtgPrescricao.RowHeadersWidth = 25;
            this.dtgPrescricao.Size = new System.Drawing.Size(768, 317);
            this.dtgPrescricao.TabIndex = 13;
            // 
            // colDtPrescricao
            // 
            this.colDtPrescricao.HeaderText = "Data";
            this.colDtPrescricao.Name = "colDtPrescricao";
            this.colDtPrescricao.ReadOnly = true;
            this.colDtPrescricao.Width = 110;
            // 
            // colDsMatMed
            // 
            this.colDsMatMed.HeaderText = "Prescrição Médica";
            this.colDsMatMed.Name = "colDsMatMed";
            this.colDsMatMed.ReadOnly = true;
            this.colDsMatMed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDsMatMed.Width = 400;
            // 
            // colHrMatMed
            // 
            this.colHrMatMed.HeaderText = "Horário de Medicação";
            this.colHrMatMed.Name = "colHrMatMed";
            this.colHrMatMed.ReadOnly = true;
            this.colHrMatMed.Width = 200;
            // 
            // hacTextBox7
            // 
            this.hacTextBox7.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox7.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox7.Location = new System.Drawing.Point(693, 139);
            this.hacTextBox7.Name = "hacTextBox7";
            this.hacTextBox7.SelectAllOnFocus = false;
            this.hacTextBox7.Size = new System.Drawing.Size(88, 21);
            this.hacTextBox7.TabIndex = 12;
            // 
            // hacTextBox5
            // 
            this.hacTextBox5.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox5.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox5.Location = new System.Drawing.Point(551, 139);
            this.hacTextBox5.Name = "hacTextBox5";
            this.hacTextBox5.SelectAllOnFocus = false;
            this.hacTextBox5.Size = new System.Drawing.Size(76, 21);
            this.hacTextBox5.TabIndex = 8;
            // 
            // hacTextBox4
            // 
            this.hacTextBox4.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox4.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox4.Location = new System.Drawing.Point(171, 139);
            this.hacTextBox4.Name = "hacTextBox4";
            this.hacTextBox4.SelectAllOnFocus = false;
            this.hacTextBox4.Size = new System.Drawing.Size(332, 21);
            this.hacTextBox4.TabIndex = 6;
            // 
            // hacTextBox3
            // 
            this.hacTextBox3.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox3.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox3.Location = new System.Drawing.Point(95, 139);
            this.hacTextBox3.Name = "hacTextBox3";
            this.hacTextBox3.SelectAllOnFocus = false;
            this.hacTextBox3.Size = new System.Drawing.Size(70, 21);
            this.hacTextBox3.TabIndex = 5;
            // 
            // hacTextBox2
            // 
            this.hacTextBox2.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox2.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox2.Location = new System.Drawing.Point(232, 112);
            this.hacTextBox2.Name = "hacTextBox2";
            this.hacTextBox2.SelectAllOnFocus = false;
            this.hacTextBox2.Size = new System.Drawing.Size(395, 21);
            this.hacTextBox2.TabIndex = 3;
            this.hacTextBox2.TextChanged += new System.EventHandler(this.hacTextBox2_TextChanged);
            // 
            // hacTextBox1
            // 
            this.hacTextBox1.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox1.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox1.Location = new System.Drawing.Point(95, 112);
            this.hacTextBox1.Name = "hacTextBox1";
            this.hacTextBox1.SelectAllOnFocus = false;
            this.hacTextBox1.Size = new System.Drawing.Size(70, 21);
            this.hacTextBox1.TabIndex = 1;
            this.hacTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(10, 115);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(66, 13);
            this.hacLabel1.TabIndex = 52;
            this.hacLabel1.Text = "Sequencia";
            // 
            // hacLabel2
            // 
            this.hacLabel2.AutoSize = true;
            this.hacLabel2.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel2.Location = new System.Drawing.Point(171, 115);
            this.hacLabel2.Name = "hacLabel2";
            this.hacLabel2.Size = new System.Drawing.Size(55, 13);
            this.hacLabel2.TabIndex = 53;
            this.hacLabel2.Text = "Paciente";
            // 
            // hacLabel3
            // 
            this.hacLabel3.AutoSize = true;
            this.hacLabel3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel3.Location = new System.Drawing.Point(10, 142);
            this.hacLabel3.Name = "hacLabel3";
            this.hacLabel3.Size = new System.Drawing.Size(61, 13);
            this.hacLabel3.TabIndex = 54;
            this.hacLabel3.Text = "Convênio";
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(509, 142);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(36, 13);
            this.hacLabel4.TabIndex = 55;
            this.hacLabel4.Text = "Local";
            // 
            // hacLabel5
            // 
            this.hacLabel5.AutoSize = true;
            this.hacLabel5.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel5.Location = new System.Drawing.Point(10, 61);
            this.hacLabel5.Name = "hacLabel5";
            this.hacLabel5.Size = new System.Drawing.Size(46, 13);
            this.hacLabel5.TabIndex = 57;
            this.hacLabel5.Text = "Médico";
            // 
            // hacTextBox6
            // 
            this.hacTextBox6.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox6.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox6.Location = new System.Drawing.Point(95, 58);
            this.hacTextBox6.Name = "hacTextBox6";
            this.hacTextBox6.SelectAllOnFocus = false;
            this.hacTextBox6.Size = new System.Drawing.Size(70, 21);
            this.hacTextBox6.TabIndex = 58;
            // 
            // hacTextBox8
            // 
            this.hacTextBox8.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox8.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox8.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox8.Location = new System.Drawing.Point(171, 58);
            this.hacTextBox8.Name = "hacTextBox8";
            this.hacTextBox8.SelectAllOnFocus = false;
            this.hacTextBox8.Size = new System.Drawing.Size(456, 21);
            this.hacTextBox8.TabIndex = 59;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(633, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 21);
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_pesquisa_identificacao_paciente;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(633, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 21);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // hacButton1
            // 
            this.hacButton1.BackColor = System.Drawing.Color.White;
            this.hacButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton1.BackgroundImage")));
            this.hacButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton1.Location = new System.Drawing.Point(583, 518);
            this.hacButton1.Name = "hacButton1";
            this.hacButton1.Size = new System.Drawing.Size(105, 22);
            this.hacButton1.TabIndex = 51;
            this.hacButton1.Text = "Sair";
            this.hacButton1.UseVisualStyleBackColor = true;
            this.hacButton1.Click += new System.EventHandler(this.hacButton1_Click);
            // 
            // hacButton2
            // 
            this.hacButton2.BackColor = System.Drawing.Color.White;
            this.hacButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton2.BackgroundImage")));
            this.hacButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton2.Location = new System.Drawing.Point(426, 518);
            this.hacButton2.Name = "hacButton2";
            this.hacButton2.Size = new System.Drawing.Size(151, 22);
            this.hacButton2.TabIndex = 50;
            this.hacButton2.Text = "Material/Medicamento";
            this.hacButton2.UseVisualStyleBackColor = true;
            // 
            // hacButton3
            // 
            this.hacButton3.BackColor = System.Drawing.Color.White;
            this.hacButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton3.BackgroundImage")));
            this.hacButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton3.Location = new System.Drawing.Point(315, 518);
            this.hacButton3.Name = "hacButton3";
            this.hacButton3.Size = new System.Drawing.Size(105, 22);
            this.hacButton3.TabIndex = 49;
            this.hacButton3.Text = "Cancelar";
            this.hacButton3.UseVisualStyleBackColor = true;
            // 
            // hacButton8
            // 
            this.hacButton8.BackColor = System.Drawing.Color.White;
            this.hacButton8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton8.BackgroundImage")));
            this.hacButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton8.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton8.Location = new System.Drawing.Point(204, 518);
            this.hacButton8.Name = "hacButton8";
            this.hacButton8.Size = new System.Drawing.Size(105, 22);
            this.hacButton8.TabIndex = 48;
            this.hacButton8.Text = "Salvar";
            this.hacButton8.UseVisualStyleBackColor = true;
            // 
            // hacButton9
            // 
            this.hacButton9.BackColor = System.Drawing.Color.White;
            this.hacButton9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton9.BackgroundImage")));
            this.hacButton9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton9.Location = new System.Drawing.Point(83, 518);
            this.hacButton9.Name = "hacButton9";
            this.hacButton9.Size = new System.Drawing.Size(115, 22);
            this.hacButton9.TabIndex = 47;
            this.hacButton9.Text = "Nova Solicitação";
            this.hacButton9.UseVisualStyleBackColor = true;
            this.hacButton9.Click += new System.EventHandler(this.hacButton9_Click);
            // 
            // hacLabel6
            // 
            this.hacLabel6.AutoSize = true;
            this.hacLabel6.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel6.Location = new System.Drawing.Point(10, 88);
            this.hacLabel6.Name = "hacLabel6";
            this.hacLabel6.Size = new System.Drawing.Size(45, 13);
            this.hacLabel6.TabIndex = 61;
            this.hacLabel6.Text = "Clínica";
            // 
            // hacTextBox9
            // 
            this.hacTextBox9.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox9.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox9.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox9.Location = new System.Drawing.Point(95, 85);
            this.hacTextBox9.Name = "hacTextBox9";
            this.hacTextBox9.ReadOnly = true;
            this.hacTextBox9.SelectAllOnFocus = false;
            this.hacTextBox9.Size = new System.Drawing.Size(532, 21);
            this.hacTextBox9.TabIndex = 62;
            // 
            // hacTextBox10
            // 
            this.hacTextBox10.AcceptedFormat = AcceptedFormat.AlfaNumerico;
            this.hacTextBox10.BackColor = System.Drawing.Color.Honeydew;
            this.hacTextBox10.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacTextBox10.Location = new System.Drawing.Point(95, 31);
            this.hacTextBox10.Name = "hacTextBox10";
            this.hacTextBox10.SelectAllOnFocus = false;
            this.hacTextBox10.Size = new System.Drawing.Size(100, 21);
            this.hacTextBox10.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Número Pedido";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.fundo_barras_verde;
            this.panel1.Controls.Add(this.hacLabel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 24);
            this.panel1.TabIndex = 65;
            // 
            // hacLabel7
            // 
            this.hacLabel7.AutoSize = true;
            this.hacLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hacLabel7.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel7.ForeColor = System.Drawing.Color.ForestGreen;
            this.hacLabel7.Location = new System.Drawing.Point(6, 4);
            this.hacLabel7.Name = "hacLabel7";
            this.hacLabel7.Size = new System.Drawing.Size(125, 13);
            this.hacLabel7.TabIndex = 0;
            this.hacLabel7.Text = "Prescrição Médica";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::HospitalAnaCosta.SGS.GestaoMateriais.Properties.Resources.img_lupa;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(201, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 21);
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            // 
            // FrmPrescricaoMedica
            // 
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hacTextBox10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hacTextBox9);
            this.Controls.Add(this.hacLabel6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.hacTextBox8);
            this.Controls.Add(this.hacTextBox6);
            this.Controls.Add(this.hacLabel5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.hacLabel3);
            this.Controls.Add(this.hacLabel2);
            this.Controls.Add(this.hacLabel1);
            this.Controls.Add(this.hacButton1);
            this.Controls.Add(this.hacButton2);
            this.Controls.Add(this.hacButton3);
            this.Controls.Add(this.hacButton8);
            this.Controls.Add(this.hacButton9);
            this.Controls.Add(this.dtgPrescricao);
            this.Controls.Add(this.hacTextBox7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hacTextBox5);
            this.Controls.Add(this.hacTextBox4);
            this.Controls.Add(this.hacTextBox3);
            this.Controls.Add(this.hacTextBox2);
            this.Controls.Add(this.hacTextBox1);
            this.Name = "FrmPrescricaoMedica";
            this.Text = "Gestão de Materiais e Medicamentos";
            this.Shown += new System.EventHandler(this.FrmPrescricaoMedica_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrescricao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacTextBox hacTextBox1;
        private HacTextBox hacTextBox2;
        private HacTextBox hacTextBox3;
        private HacTextBox hacTextBox4;
        private HacTextBox hacTextBox5;
        private System.Windows.Forms.Label label5;
        private HacTextBox hacTextBox7;
        private HacDataGridView dtgPrescricao;
        private HacButton hacButton1;
        private HacButton hacButton2;
        private HacButton hacButton3;
        private HacButton hacButton8;
        private HacButton hacButton9;
        private HacLabel hacLabel1;
        private HacLabel hacLabel2;
        private HacLabel hacLabel3;
        private HacLabel hacLabel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private HacLabel hacLabel5;
        private HacTextBox hacTextBox6;
        private HacTextBox hacTextBox8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private HacLabel hacLabel6;
        private HacTextBox hacTextBox9;
        private HacTextBox hacTextBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private HacLabel hacLabel7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDtPrescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDsMatMed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHrMatMed;
    }
}
