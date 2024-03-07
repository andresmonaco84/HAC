using HospitalAnaCosta.SGS.Componentes;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    partial class FrmPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgPedido = new HospitalAnaCosta.SGS.Componentes.HacDataGridView(this.components);
            this.tsHac = new HospitalAnaCosta.SGS.Componentes.HacToolStrip(this.components);
            this.lblNumAtendimento = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.lblAtendimento = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.colReqIdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAntimicrobiano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPedido
            // 
            this.dtgPedido.AllowUserToAddRows = false;
            this.dtgPedido.AlterarStatus = true;
            this.dtgPedido.BackgroundColor = System.Drawing.Color.White;
            this.dtgPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReqIdt,
            this.colDataReq,
            this.colDataDisp,
            this.colStatus,
            this.colIdStatus,
            this.colPendente,
            this.colAntimicrobiano,
            this.colKit});
            this.dtgPedido.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.dtgPedido.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.dtgPedido.GridPesquisa = false;
            this.dtgPedido.Limpar = true;
            this.dtgPedido.Location = new System.Drawing.Point(4, 64);
            this.dtgPedido.Name = "dtgPedido";
            this.dtgPedido.NaoAjustarEdicao = false;
            this.dtgPedido.Obrigatorio = false;
            this.dtgPedido.ObrigatorioMensagem = null;
            this.dtgPedido.PreValidacaoMensagem = null;
            this.dtgPedido.PreValidado = false;
            this.dtgPedido.RowHeadersWidth = 25;
            this.dtgPedido.Size = new System.Drawing.Size(790, 292);
            this.dtgPedido.TabIndex = 132;
            this.dtgPedido.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPedido_CellDoubleClick);
            this.dtgPedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgPedido_CellFormatting);
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
            this.tsHac.Size = new System.Drawing.Size(794, 28);
            this.tsHac.TabIndex = 133;
            this.tsHac.TituloTela = "Pedidos do Paciente";
            // 
            // lblNumAtendimento
            // 
            this.lblNumAtendimento.AutoSize = true;
            this.lblNumAtendimento.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblNumAtendimento.Location = new System.Drawing.Point(106, 35);
            this.lblNumAtendimento.Name = "lblNumAtendimento";
            this.lblNumAtendimento.Size = new System.Drawing.Size(19, 18);
            this.lblNumAtendimento.TabIndex = 135;
            this.lblNumAtendimento.Text = "0";
            // 
            // lblAtendimento
            // 
            this.lblAtendimento.AutoSize = true;
            this.lblAtendimento.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblAtendimento.Location = new System.Drawing.Point(11, 37);
            this.lblAtendimento.Name = "lblAtendimento";
            this.lblAtendimento.Size = new System.Drawing.Size(91, 16);
            this.lblAtendimento.TabIndex = 136;
            this.lblAtendimento.Text = "Atendimento";
            // 
            // colReqIdt
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReqIdt.DefaultCellStyle = dataGridViewCellStyle1;
            this.colReqIdt.HeaderText = "ID";
            this.colReqIdt.Name = "colReqIdt";
            this.colReqIdt.ReadOnly = true;
            this.colReqIdt.Width = 75;
            // 
            // colDataReq
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDataReq.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataReq.HeaderText = "Data Pedido";
            this.colDataReq.Name = "colDataReq";
            this.colDataReq.ReadOnly = true;
            this.colDataReq.Width = 140;
            // 
            // colDataDisp
            // 
            this.colDataDisp.HeaderText = "Data Dispensação";
            this.colDataDisp.Name = "colDataDisp";
            this.colDataDisp.ReadOnly = true;
            this.colDataDisp.Width = 140;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 290;
            // 
            // colIdStatus
            // 
            this.colIdStatus.HeaderText = "colIdStatus";
            this.colIdStatus.Name = "colIdStatus";
            this.colIdStatus.Visible = false;
            // 
            // colPendente
            // 
            this.colPendente.HeaderText = "colPendente";
            this.colPendente.Name = "colPendente";
            this.colPendente.ReadOnly = true;
            this.colPendente.Visible = false;
            // 
            // colAntimicrobiano
            // 
            this.colAntimicrobiano.HeaderText = "Antimicrobiano";
            this.colAntimicrobiano.Name = "colAntimicrobiano";
            this.colAntimicrobiano.ReadOnly = true;
            this.colAntimicrobiano.Width = 110;
            // 
            // colKit
            // 
            this.colKit.HeaderText = "Kit UTI";
            this.colKit.Name = "colKit";
            this.colKit.ReadOnly = true;
            this.colKit.Width = 280;
            // 
            // FrmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 360);
            this.Controls.Add(this.lblAtendimento);
            this.Controls.Add(this.lblNumAtendimento);
            this.Controls.Add(this.tsHac);
            this.Controls.Add(this.dtgPedido);
            this.Name = "FrmPedidos";
            this.Text = "Gestão de Materiais e Medicamentos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HacDataGridView dtgPedido;
        private HacToolStrip tsHac;
        private HacLabel lblNumAtendimento;
        private HacLabel lblAtendimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqIdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataDisp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAntimicrobiano;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKit;
    }
}