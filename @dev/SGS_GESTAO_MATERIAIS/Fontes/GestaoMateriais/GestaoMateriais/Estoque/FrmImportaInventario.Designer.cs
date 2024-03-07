namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    partial class FrmImportaInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportaInventario));
            this.hacLabel1 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtUnidade = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtLocal = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.txtSetor = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.hacButton1 = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacButton2 = new HospitalAnaCosta.SGS.Componentes.HacButton(this.components);
            this.hacLabel4 = new HospitalAnaCosta.SGS.Componentes.HacLabel(this.components);
            this.txtData = new HospitalAnaCosta.SGS.Componentes.HacTextBox(this.components);
            this.SuspendLayout();
            // 
            // hacLabel1
            // 
            this.hacLabel1.AutoSize = true;
            this.hacLabel1.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel1.Location = new System.Drawing.Point(12, 19);
            this.hacLabel1.Name = "hacLabel1";
            this.hacLabel1.Size = new System.Drawing.Size(53, 13);
            this.hacLabel1.TabIndex = 0;
            this.hacLabel1.Text = "Unidade";
            // 
            // txtUnidade
            // 
            this.txtUnidade.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtUnidade.BackColor = System.Drawing.Color.Honeydew;
            this.txtUnidade.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtUnidade.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtUnidade.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtUnidade.Limpar = false;
            this.txtUnidade.Location = new System.Drawing.Point(71, 15);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.NaoAjustarEdicao = false;
            this.txtUnidade.Obrigatorio = false;
            this.txtUnidade.ObrigatorioMensagem = "";
            this.txtUnidade.PreValidacaoMensagem = "";
            this.txtUnidade.PreValidado = false;
            this.txtUnidade.SelectAllOnFocus = false;
            this.txtUnidade.Size = new System.Drawing.Size(133, 21);
            this.txtUnidade.TabIndex = 3;
            // 
            // txtLocal
            // 
            this.txtLocal.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtLocal.BackColor = System.Drawing.Color.Honeydew;
            this.txtLocal.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtLocal.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtLocal.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtLocal.Limpar = false;
            this.txtLocal.Location = new System.Drawing.Point(210, 15);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.NaoAjustarEdicao = false;
            this.txtLocal.Obrigatorio = false;
            this.txtLocal.ObrigatorioMensagem = "";
            this.txtLocal.PreValidacaoMensagem = "";
            this.txtLocal.PreValidado = false;
            this.txtLocal.SelectAllOnFocus = false;
            this.txtLocal.Size = new System.Drawing.Size(117, 21);
            this.txtLocal.TabIndex = 4;
            // 
            // txtSetor
            // 
            this.txtSetor.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.AlfaNumerico;
            this.txtSetor.BackColor = System.Drawing.Color.Honeydew;
            this.txtSetor.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Nunca;
            this.txtSetor.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Desabilitado;
            this.txtSetor.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtSetor.Limpar = false;
            this.txtSetor.Location = new System.Drawing.Point(333, 15);
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.NaoAjustarEdicao = false;
            this.txtSetor.Obrigatorio = false;
            this.txtSetor.ObrigatorioMensagem = "";
            this.txtSetor.PreValidacaoMensagem = "";
            this.txtSetor.PreValidado = false;
            this.txtSetor.SelectAllOnFocus = false;
            this.txtSetor.Size = new System.Drawing.Size(137, 21);
            this.txtSetor.TabIndex = 5;
            // 
            // hacButton1
            // 
            this.hacButton1.AlterarStatus = true;
            this.hacButton1.BackColor = System.Drawing.Color.White;
            this.hacButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton1.BackgroundImage")));
            this.hacButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton1.Location = new System.Drawing.Point(80, 106);
            this.hacButton1.Name = "hacButton1";
            this.hacButton1.Size = new System.Drawing.Size(148, 22);
            this.hacButton1.TabIndex = 6;
            this.hacButton1.Text = "Iniciar Importação";
            this.hacButton1.UseVisualStyleBackColor = true;
            this.hacButton1.Click += new System.EventHandler(this.hacButton1_Click);
            // 
            // hacButton2
            // 
            this.hacButton2.AlterarStatus = true;
            this.hacButton2.BackColor = System.Drawing.Color.White;
            this.hacButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hacButton2.BackgroundImage")));
            this.hacButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hacButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.hacButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hacButton2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacButton2.Location = new System.Drawing.Point(254, 106);
            this.hacButton2.Name = "hacButton2";
            this.hacButton2.Size = new System.Drawing.Size(148, 22);
            this.hacButton2.TabIndex = 7;
            this.hacButton2.Text = "Cancelar";
            this.hacButton2.UseVisualStyleBackColor = true;
            this.hacButton2.Click += new System.EventHandler(this.hacButton2_Click);
            // 
            // hacLabel4
            // 
            this.hacLabel4.AutoSize = true;
            this.hacLabel4.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.hacLabel4.Location = new System.Drawing.Point(31, 48);
            this.hacLabel4.Name = "hacLabel4";
            this.hacLabel4.Size = new System.Drawing.Size(34, 13);
            this.hacLabel4.TabIndex = 8;
            this.hacLabel4.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.AcceptedFormat = HospitalAnaCosta.SGS.Componentes.AcceptedFormat.Data;
            this.txtData.BackColor = System.Drawing.Color.Honeydew;
            this.txtData.Editavel = HospitalAnaCosta.SGS.Componentes.ControleEdicao.Sempre;
            this.txtData.EstadoInicial = HospitalAnaCosta.SGS.Componentes.EstadoObjeto.Habilitado;
            this.txtData.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.txtData.Limpar = false;
            this.txtData.Location = new System.Drawing.Point(71, 45);
            this.txtData.MaxLength = 10;
            this.txtData.Name = "txtData";
            this.txtData.NaoAjustarEdicao = false;
            this.txtData.Obrigatorio = true;
            this.txtData.ObrigatorioMensagem = "Data Obrigatória";
            this.txtData.PreValidacaoMensagem = "";
            this.txtData.PreValidado = false;
            this.txtData.SelectAllOnFocus = false;
            this.txtData.Size = new System.Drawing.Size(100, 21);
            this.txtData.TabIndex = 9;
            // 
            // FrmImportaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 153);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.hacLabel4);
            this.Controls.Add(this.hacButton2);
            this.Controls.Add(this.hacButton1);
            this.Controls.Add(this.txtSetor);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.hacLabel1);
            this.Name = "FrmImportaInventario";
            this.Text = "Importar Contagem Inventário";
            this.Load += new System.EventHandler(this.FrmImportaInventario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel1;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtUnidade;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtLocal;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtSetor;
        private HospitalAnaCosta.SGS.Componentes.HacButton hacButton1;
        private HospitalAnaCosta.SGS.Componentes.HacButton hacButton2;
        private HospitalAnaCosta.SGS.Componentes.HacLabel hacLabel4;
        private HospitalAnaCosta.SGS.Componentes.HacTextBox txtData;
    }
}