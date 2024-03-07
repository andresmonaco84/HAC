using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Relatorio
{
    partial class FrmRelatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorios));
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.btnIR = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnEmprestimos = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnSaldo = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnPosicaoMensal = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btmSaidasUnidades = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.gbFechamento = new System.Windows.Forms.GroupBox();
            this.btnDivergencias = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnConfNF = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.gbGerencial = new System.Windows.Forms.GroupBox();
            this.btnPedidos = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnBaixasSetor = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnConsumoMedicamentoGrupoMercado = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnBaixasEntradas = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnConsumoSetor = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnObsoletos = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnConsumoPac = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.btnBaixas = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.gbFechamento.SuspendLayout();
            this.gbGerencial.SuspendLayout();
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
            this.tsHac.MatMedVisivel = false;
            this.tsHac.Name = "tsHac";
            this.tsHac.NomeControleFoco = null;
            this.tsHac.NovoVisivel = false;
            this.tsHac.PesquisarVisivel = false;
            this.tsHac.SalvarVisivel = false;
            this.tsHac.Size = new System.Drawing.Size(339, 28);
            this.tsHac.TabIndex = 123;
            this.tsHac.Text = "hacToolStrip1";
            this.tsHac.TituloTela = "Relatórios para Gestão de Estoque";
            // 
            // btnIR
            // 
            this.btnIR.AlterarStatus = true;
            this.btnIR.BackColor = System.Drawing.Color.White;
            this.btnIR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIR.BackgroundImage")));
            this.btnIR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIR.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnIR.Location = new System.Drawing.Point(6, 16);
            this.btnIR.Name = "btnIR";
            this.btnIR.Size = new System.Drawing.Size(298, 22);
            this.btnIR.TabIndex = 4;
            this.btnIR.Text = "ÍNDICE DE ROTATIVIDADE";
            this.btnIR.UseVisualStyleBackColor = true;
            this.btnIR.Click += new System.EventHandler(this.btnIR_Click);
            // 
            // btnEmprestimos
            // 
            this.btnEmprestimos.AlterarStatus = true;
            this.btnEmprestimos.BackColor = System.Drawing.Color.White;
            this.btnEmprestimos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmprestimos.BackgroundImage")));
            this.btnEmprestimos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmprestimos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnEmprestimos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmprestimos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnEmprestimos.Location = new System.Drawing.Point(8, 296);
            this.btnEmprestimos.Name = "btnEmprestimos";
            this.btnEmprestimos.Size = new System.Drawing.Size(298, 22);
            this.btnEmprestimos.TabIndex = 5;
            this.btnEmprestimos.Text = "EMPRÉSTIMOS";
            this.btnEmprestimos.UseVisualStyleBackColor = true;
            this.btnEmprestimos.Click += new System.EventHandler(this.btnConsumo_Click);
            // 
            // btnSaldo
            // 
            this.btnSaldo.AlterarStatus = true;
            this.btnSaldo.BackColor = System.Drawing.Color.White;
            this.btnSaldo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaldo.BackgroundImage")));
            this.btnSaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaldo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaldo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSaldo.Location = new System.Drawing.Point(6, 156);
            this.btnSaldo.Name = "btnSaldo";
            this.btnSaldo.Size = new System.Drawing.Size(298, 22);
            this.btnSaldo.TabIndex = 3;
            this.btnSaldo.Text = "SALDOS EM ESTOQUE NO SETOR";
            this.btnSaldo.UseVisualStyleBackColor = true;
            this.btnSaldo.Click += new System.EventHandler(this.btnSaldo_Click);
            // 
            // btnPosicaoMensal
            // 
            this.btnPosicaoMensal.AlterarStatus = true;
            this.btnPosicaoMensal.BackColor = System.Drawing.Color.White;
            this.btnPosicaoMensal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPosicaoMensal.BackgroundImage")));
            this.btnPosicaoMensal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosicaoMensal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPosicaoMensal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosicaoMensal.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPosicaoMensal.Location = new System.Drawing.Point(6, 16);
            this.btnPosicaoMensal.Name = "btnPosicaoMensal";
            this.btnPosicaoMensal.Size = new System.Drawing.Size(298, 22);
            this.btnPosicaoMensal.TabIndex = 1;
            this.btnPosicaoMensal.Text = "POSIÇÃO MENSAL DE ESTOQUE";
            this.btnPosicaoMensal.UseVisualStyleBackColor = true;
            this.btnPosicaoMensal.Click += new System.EventHandler(this.btnPosicaoMensal_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btmSaidasUnidades
            // 
            this.btmSaidasUnidades.AlterarStatus = true;
            this.btmSaidasUnidades.BackColor = System.Drawing.Color.White;
            this.btmSaidasUnidades.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btmSaidasUnidades.BackgroundImage")));
            this.btmSaidasUnidades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btmSaidasUnidades.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btmSaidasUnidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmSaidasUnidades.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btmSaidasUnidades.Location = new System.Drawing.Point(6, 44);
            this.btmSaidasUnidades.Name = "btmSaidasUnidades";
            this.btmSaidasUnidades.Size = new System.Drawing.Size(298, 22);
            this.btmSaidasUnidades.TabIndex = 2;
            this.btmSaidasUnidades.Text = "SAÍDAS/DESPESAS DAS UNIDADES";
            this.btmSaidasUnidades.UseVisualStyleBackColor = true;
            this.btmSaidasUnidades.Click += new System.EventHandler(this.btmSaidasUnidades_Click);
            // 
            // gbFechamento
            // 
            this.gbFechamento.Controls.Add(this.btnDivergencias);
            this.gbFechamento.Controls.Add(this.btnConfNF);
            this.gbFechamento.Controls.Add(this.btmSaidasUnidades);
            this.gbFechamento.Controls.Add(this.btnPosicaoMensal);
            this.gbFechamento.Location = new System.Drawing.Point(12, 31);
            this.gbFechamento.Name = "gbFechamento";
            this.gbFechamento.Size = new System.Drawing.Size(315, 137);
            this.gbFechamento.TabIndex = 124;
            this.gbFechamento.TabStop = false;
            this.gbFechamento.Visible = false;
            // 
            // btnDivergencias
            // 
            this.btnDivergencias.AlterarStatus = true;
            this.btnDivergencias.BackColor = System.Drawing.Color.White;
            this.btnDivergencias.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDivergencias.BackgroundImage")));
            this.btnDivergencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDivergencias.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnDivergencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivergencias.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnDivergencias.Location = new System.Drawing.Point(6, 100);
            this.btnDivergencias.Name = "btnDivergencias";
            this.btnDivergencias.Size = new System.Drawing.Size(298, 22);
            this.btnDivergencias.TabIndex = 8;
            this.btnDivergencias.Text = "DIVERGÊNCIAS CONTÁBIL X ESTOQUE";
            this.btnDivergencias.UseVisualStyleBackColor = true;
            this.btnDivergencias.Click += new System.EventHandler(this.btnDivergencias_Click);
            // 
            // btnConfNF
            // 
            this.btnConfNF.AlterarStatus = true;
            this.btnConfNF.BackColor = System.Drawing.Color.White;
            this.btnConfNF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfNF.BackgroundImage")));
            this.btnConfNF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfNF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnConfNF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfNF.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnConfNF.Location = new System.Drawing.Point(6, 72);
            this.btnConfNF.Name = "btnConfNF";
            this.btnConfNF.Size = new System.Drawing.Size(298, 22);
            this.btnConfNF.TabIndex = 3;
            this.btnConfNF.Text = "CONFERÊNCIA DE ENTRADAS DE NF E GRUPO";
            this.btnConfNF.UseVisualStyleBackColor = true;
            this.btnConfNF.Click += new System.EventHandler(this.btnConfNF_Click);
            // 
            // gbGerencial
            // 
            this.gbGerencial.Controls.Add(this.btnPedidos);
            this.gbGerencial.Controls.Add(this.btnBaixasSetor);
            this.gbGerencial.Controls.Add(this.btnConsumoMedicamentoGrupoMercado);
            this.gbGerencial.Controls.Add(this.btnBaixasEntradas);
            this.gbGerencial.Controls.Add(this.btnConsumoSetor);
            this.gbGerencial.Controls.Add(this.btnObsoletos);
            this.gbGerencial.Controls.Add(this.btnConsumoPac);
            this.gbGerencial.Controls.Add(this.btnBaixas);
            this.gbGerencial.Controls.Add(this.btnEmprestimos);
            this.gbGerencial.Controls.Add(this.btnIR);
            this.gbGerencial.Controls.Add(this.btnSaldo);
            this.gbGerencial.Location = new System.Drawing.Point(12, 40);
            this.gbGerencial.Name = "gbGerencial";
            this.gbGerencial.Size = new System.Drawing.Size(315, 327);
            this.gbGerencial.TabIndex = 125;
            this.gbGerencial.TabStop = false;
            this.gbGerencial.Visible = false;
            // 
            // btnPedidos
            // 
            this.btnPedidos.AlterarStatus = true;
            this.btnPedidos.BackColor = System.Drawing.Color.White;
            this.btnPedidos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPedidos.BackgroundImage")));
            this.btnPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPedidos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPedidos.Location = new System.Drawing.Point(8, 268);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(298, 22);
            this.btnPedidos.TabIndex = 129;
            this.btnPedidos.Text = "PEDIDOS";
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnBaixasSetor
            // 
            this.btnBaixasSetor.AlterarStatus = true;
            this.btnBaixasSetor.BackColor = System.Drawing.Color.White;
            this.btnBaixasSetor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBaixasSetor.BackgroundImage")));
            this.btnBaixasSetor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaixasSetor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnBaixasSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaixasSetor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnBaixasSetor.Location = new System.Drawing.Point(6, 240);
            this.btnBaixasSetor.Name = "btnBaixasSetor";
            this.btnBaixasSetor.Size = new System.Drawing.Size(298, 22);
            this.btnBaixasSetor.TabIndex = 127;
            this.btnBaixasSetor.Text = "BAIXAS SETOR x FATURAMENTO";
            this.btnBaixasSetor.UseVisualStyleBackColor = true;
            this.btnBaixasSetor.Click += new System.EventHandler(this.btnBaixasSetor_Click);
            // 
            // btnConsumoMedicamentoGrupoMercado
            // 
            this.btnConsumoMedicamentoGrupoMercado.AlterarStatus = true;
            this.btnConsumoMedicamentoGrupoMercado.BackColor = System.Drawing.Color.White;
            this.btnConsumoMedicamentoGrupoMercado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsumoMedicamentoGrupoMercado.BackgroundImage")));
            this.btnConsumoMedicamentoGrupoMercado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsumoMedicamentoGrupoMercado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnConsumoMedicamentoGrupoMercado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumoMedicamentoGrupoMercado.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnConsumoMedicamentoGrupoMercado.Location = new System.Drawing.Point(6, 212);
            this.btnConsumoMedicamentoGrupoMercado.Name = "btnConsumoMedicamentoGrupoMercado";
            this.btnConsumoMedicamentoGrupoMercado.Size = new System.Drawing.Size(298, 22);
            this.btnConsumoMedicamentoGrupoMercado.TabIndex = 128;
            this.btnConsumoMedicamentoGrupoMercado.Text = " CONSUMO DE MEDICAMENTO GRUPO/MERCADO";
            this.btnConsumoMedicamentoGrupoMercado.UseVisualStyleBackColor = true;
            this.btnConsumoMedicamentoGrupoMercado.Click += new System.EventHandler(this.btnConsumoMedicamentoGrupoMercado_Click);
            // 
            // btnBaixasEntradas
            // 
            this.btnBaixasEntradas.AlterarStatus = true;
            this.btnBaixasEntradas.BackColor = System.Drawing.Color.White;
            this.btnBaixasEntradas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBaixasEntradas.BackgroundImage")));
            this.btnBaixasEntradas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaixasEntradas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnBaixasEntradas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaixasEntradas.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnBaixasEntradas.Location = new System.Drawing.Point(7, 44);
            this.btnBaixasEntradas.Name = "btnBaixasEntradas";
            this.btnBaixasEntradas.Size = new System.Drawing.Size(298, 22);
            this.btnBaixasEntradas.TabIndex = 127;
            this.btnBaixasEntradas.Text = "BAIXAS/ENTRADAS DE MAT/MED POR SETOR";
            this.btnBaixasEntradas.UseVisualStyleBackColor = true;
            this.btnBaixasEntradas.Click += new System.EventHandler(this.btnBaixasEntradas_Click);
            // 
            // btnConsumoSetor
            // 
            this.btnConsumoSetor.AlterarStatus = true;
            this.btnConsumoSetor.BackColor = System.Drawing.Color.White;
            this.btnConsumoSetor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsumoSetor.BackgroundImage")));
            this.btnConsumoSetor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsumoSetor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnConsumoSetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumoSetor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnConsumoSetor.Location = new System.Drawing.Point(6, 100);
            this.btnConsumoSetor.Name = "btnConsumoSetor";
            this.btnConsumoSetor.Size = new System.Drawing.Size(298, 22);
            this.btnConsumoSetor.TabIndex = 126;
            this.btnConsumoSetor.Text = "BAIXAS AO PACIENTE POR SETOR";
            this.btnConsumoSetor.UseVisualStyleBackColor = true;
            this.btnConsumoSetor.Click += new System.EventHandler(this.btnConsumoSetor_Click);
            // 
            // btnObsoletos
            // 
            this.btnObsoletos.AlterarStatus = true;
            this.btnObsoletos.BackColor = System.Drawing.Color.White;
            this.btnObsoletos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObsoletos.BackgroundImage")));
            this.btnObsoletos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObsoletos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnObsoletos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObsoletos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnObsoletos.Location = new System.Drawing.Point(6, 184);
            this.btnObsoletos.Name = "btnObsoletos";
            this.btnObsoletos.Size = new System.Drawing.Size(298, 22);
            this.btnObsoletos.TabIndex = 8;
            this.btnObsoletos.Text = "PRODUTOS OBSOLETOS";
            this.btnObsoletos.UseVisualStyleBackColor = true;
            this.btnObsoletos.Click += new System.EventHandler(this.btnObsoletos_Click);
            // 
            // btnConsumoPac
            // 
            this.btnConsumoPac.AlterarStatus = true;
            this.btnConsumoPac.BackColor = System.Drawing.Color.White;
            this.btnConsumoPac.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsumoPac.BackgroundImage")));
            this.btnConsumoPac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsumoPac.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnConsumoPac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumoPac.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnConsumoPac.Location = new System.Drawing.Point(6, 128);
            this.btnConsumoPac.Name = "btnConsumoPac";
            this.btnConsumoPac.Size = new System.Drawing.Size(298, 22);
            this.btnConsumoPac.TabIndex = 7;
            this.btnConsumoPac.Text = "CONSUMO POR PACIENTE";
            this.btnConsumoPac.UseVisualStyleBackColor = true;
            this.btnConsumoPac.Click += new System.EventHandler(this.btnConsumoPac_Click);
            // 
            // btnBaixas
            // 
            this.btnBaixas.AlterarStatus = true;
            this.btnBaixas.BackColor = System.Drawing.Color.White;
            this.btnBaixas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBaixas.BackgroundImage")));
            this.btnBaixas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaixas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnBaixas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaixas.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnBaixas.Location = new System.Drawing.Point(6, 72);
            this.btnBaixas.Name = "btnBaixas";
            this.btnBaixas.Size = new System.Drawing.Size(298, 22);
            this.btnBaixas.TabIndex = 6;
            this.btnBaixas.Text = "BAIXAS DIÁRIAS NO SETOR";
            this.btnBaixas.UseVisualStyleBackColor = true;
            this.btnBaixas.Click += new System.EventHandler(this.btnBaixas_Click);
            // 
            // FrmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 376);
            this.Controls.Add(this.gbGerencial);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.gbFechamento);
            this.Name = "FrmRelatorios";
            this.Text = "Relatórios para Gestão de Estoque";
            this.Load += new System.EventHandler(this.FrmRelatorios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.gbFechamento.ResumeLayout(false);
            this.gbGerencial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacToolStrip tsHac;
        private HacButton btnIR;
        private HacButton btnEmprestimos;
        private HacButton btnSaldo;
        private HacButton btnPosicaoMensal;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private HacButton btmSaidasUnidades;
        private System.Windows.Forms.GroupBox gbGerencial;
        private System.Windows.Forms.GroupBox gbFechamento;
        private HacButton btnConfNF;
        private HacButton btnDivergencias;
        private HacButton btnBaixas;
        private HacButton btnConsumoPac;
        private HacButton btnObsoletos;
        private HacButton btnConsumoSetor;
        private HacButton btnBaixasEntradas;
        private HacButton btnConsumoMedicamentoGrupoMercado;
        private HacButton btnBaixasSetor;
        private HacButton btnPedidos;
    }
}