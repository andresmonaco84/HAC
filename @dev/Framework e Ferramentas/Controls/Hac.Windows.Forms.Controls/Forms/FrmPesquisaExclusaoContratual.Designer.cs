namespace Hac.Windows.Forms.Controls
{
    partial class FrmPesquisaExclusaoContratual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaExclusaoContratual));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxPesquisar = new System.Windows.Forms.GroupBox();
            this.txtCodSeqBen = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCredencialHac = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodSeq = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.ctlPlano = new Hac.Windows.Forms.Controls.HacPlano();
            this.btnPesquisarCID10Principal = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoPlano = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.ctlConvenio = new Hac.Windows.Forms.Controls.HacConvenio();
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4 = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.txtDescricaoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.txtCodigoConvenio = new Hac.Windows.Forms.Controls.HacTextBox(this.components);
            this.lblConvenio = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblPlano = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.lblCredencial = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.grdExclusao = new Hac.Windows.Forms.Controls.HacDataGridView(this.components);
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tspCommand = new Hac.Windows.Forms.Controls.HacToolStrip(this.components);
            this.gbxPesquisar.SuspendLayout();
            this.ctlPlano.SuspendLayout();
            this.ctlConvenio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExclusao)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxPesquisar
            // 
            this.gbxPesquisar.Controls.Add(this.txtCodSeqBen);
            this.gbxPesquisar.Controls.Add(this.txtCredencialHac);
            this.gbxPesquisar.Controls.Add(this.txtCodSeq);
            this.gbxPesquisar.Controls.Add(this.ctlPlano);
            this.gbxPesquisar.Controls.Add(this.ctlConvenio);
            this.gbxPesquisar.Controls.Add(this.lblConvenio);
            this.gbxPesquisar.Controls.Add(this.lblPlano);
            this.gbxPesquisar.Controls.Add(this.lblCredencial);
            this.gbxPesquisar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPesquisar.Location = new System.Drawing.Point(6, 33);
            this.gbxPesquisar.Name = "gbxPesquisar";
            this.gbxPesquisar.Size = new System.Drawing.Size(754, 93);
            this.gbxPesquisar.TabIndex = 1;
            this.gbxPesquisar.TabStop = false;
            this.gbxPesquisar.Text = "Pesquisa por:";
            // 
            // txtCodSeqBen
            // 
            this.txtCodSeqBen.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCodSeqBen.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodSeqBen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodSeqBen.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodSeqBen.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodSeqBen.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodSeqBen.Limpar = true;
            this.txtCodSeqBen.Location = new System.Drawing.Point(241, 66);
            this.txtCodSeqBen.MaxLength = 3;
            this.txtCodSeqBen.Name = "txtCodSeqBen";
            this.txtCodSeqBen.NaoAjustarEdicao = true;
            this.txtCodSeqBen.Obrigatorio = true;
            this.txtCodSeqBen.ObrigatorioMensagem = "Credencial Obrigatória";
            this.txtCodSeqBen.PreValidacaoMensagem = null;
            this.txtCodSeqBen.PreValidado = false;
            this.txtCodSeqBen.SelectAllOnFocus = true;
            this.txtCodSeqBen.Size = new System.Drawing.Size(26, 18);
            this.txtCodSeqBen.TabIndex = 169;
            // 
            // txtCredencialHac
            // 
            this.txtCredencialHac.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCredencialHac.BackColor = System.Drawing.Color.Honeydew;
            this.txtCredencialHac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCredencialHac.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCredencialHac.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCredencialHac.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredencialHac.Limpar = true;
            this.txtCredencialHac.Location = new System.Drawing.Point(130, 66);
            this.txtCredencialHac.MaxLength = 8;
            this.txtCredencialHac.Name = "txtCredencialHac";
            this.txtCredencialHac.NaoAjustarEdicao = true;
            this.txtCredencialHac.Obrigatorio = true;
            this.txtCredencialHac.ObrigatorioMensagem = "Credencial Obrigatória";
            this.txtCredencialHac.PreValidacaoMensagem = null;
            this.txtCredencialHac.PreValidado = false;
            this.txtCredencialHac.SelectAllOnFocus = true;
            this.txtCredencialHac.Size = new System.Drawing.Size(105, 18);
            this.txtCredencialHac.TabIndex = 168;
            this.txtCredencialHac.Leave += new System.EventHandler(this.txtCredencialHac_Leave);
            // 
            // txtCodSeq
            // 
            this.txtCodSeq.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.Numerico;
            this.txtCodSeq.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodSeq.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodSeq.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodSeq.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodSeq.Limpar = true;
            this.txtCodSeq.Location = new System.Drawing.Point(98, 66);
            this.txtCodSeq.MaxLength = 3;
            this.txtCodSeq.Name = "txtCodSeq";
            this.txtCodSeq.NaoAjustarEdicao = true;
            this.txtCodSeq.Obrigatorio = true;
            this.txtCodSeq.ObrigatorioMensagem = "Credencial Obrigatória";
            this.txtCodSeq.PreValidacaoMensagem = null;
            this.txtCodSeq.PreValidado = false;
            this.txtCodSeq.SelectAllOnFocus = true;
            this.txtCodSeq.Size = new System.Drawing.Size(26, 18);
            this.txtCodSeq.TabIndex = 167;
            // 
            // ctlPlano
            // 
            this.ctlPlano.AutoSize = true;
            this.ctlPlano.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlPlano.Controls.Add(this.btnPesquisarCID10Principal);
            this.ctlPlano.Controls.Add(this.txtDescricaoPlano);
            this.ctlPlano.Controls.Add(this.txtCodigoPlano);
            this.ctlPlano.Enabled = false;
            this.ctlPlano.IdtConvenio = 0;
            this.ctlPlano.Location = new System.Drawing.Point(98, 39);
            this.ctlPlano.Name = "ctlPlano";
            this.ctlPlano.NaoAjustarEdicao = true;
            this.ctlPlano.Obrigatorio = false;
            this.ctlPlano.ObrigatorioMensagem = null;
            this.ctlPlano.Size = new System.Drawing.Size(360, 24);
            this.ctlPlano.TabIndex = 166;
            this.ctlPlano.Pesquisar += new Hac.Windows.Forms.Controls.HacPlano.PesquisarDelegate(this.ctlPlano_Pesquisar);
            this.ctlPlano.Leave += new System.EventHandler(this.ctlPlano_Leave);
            // 
            // btnPesquisarCID10Principal
            // 
            this.btnPesquisarCID10Principal.AlterarStatus = true;
            this.btnPesquisarCID10Principal.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarCID10Principal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisarCID10Principal.BackgroundImage")));
            this.btnPesquisarCID10Principal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisarCID10Principal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarCID10Principal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnPesquisarCID10Principal.FlatAppearance.BorderSize = 0;
            this.btnPesquisarCID10Principal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarCID10Principal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarCID10Principal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarCID10Principal.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnPesquisarCID10Principal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPesquisarCID10Principal.Location = new System.Drawing.Point(336, 1);
            this.btnPesquisarCID10Principal.Name = "btnPesquisarCID10Principal";
            this.btnPesquisarCID10Principal.Size = new System.Drawing.Size(21, 20);
            this.btnPesquisarCID10Principal.TabIndex = 2;
            this.btnPesquisarCID10Principal.UseVisualStyleBackColor = false;
            // 
            // txtDescricaoPlano
            // 
            this.txtDescricaoPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoPlano.Limpar = true;
            this.txtDescricaoPlano.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoPlano.Name = "txtDescricaoPlano";
            this.txtDescricaoPlano.NaoAjustarEdicao = false;
            this.txtDescricaoPlano.Obrigatorio = false;
            this.txtDescricaoPlano.ObrigatorioMensagem = null;
            this.txtDescricaoPlano.PreValidacaoMensagem = null;
            this.txtDescricaoPlano.PreValidado = false;
            this.txtDescricaoPlano.SelectAllOnFocus = false;
            this.txtDescricaoPlano.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoPlano.TabIndex = 1;
            // 
            // txtCodigoPlano
            // 
            this.txtCodigoPlano.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoPlano.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoPlano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoPlano.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoPlano.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoPlano.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPlano.Limpar = true;
            this.txtCodigoPlano.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoPlano.MaxLength = 5;
            this.txtCodigoPlano.Name = "txtCodigoPlano";
            this.txtCodigoPlano.NaoAjustarEdicao = false;
            this.txtCodigoPlano.Obrigatorio = false;
            this.txtCodigoPlano.ObrigatorioMensagem = null;
            this.txtCodigoPlano.PreValidacaoMensagem = null;
            this.txtCodigoPlano.PreValidado = false;
            this.txtCodigoPlano.SelectAllOnFocus = false;
            this.txtCodigoPlano.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoPlano.TabIndex = 0;
            // 
            // ctlConvenio
            // 
            this.ctlConvenio.AutoSize = true;
            this.ctlConvenio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlConvenio.Controls.Add(this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4);
            this.ctlConvenio.Controls.Add(this.txtDescricaoConvenio);
            this.ctlConvenio.Controls.Add(this.txtCodigoConvenio);
            this.ctlConvenio.Enabled = false;
            this.ctlConvenio.Location = new System.Drawing.Point(98, 15);
            this.ctlConvenio.Name = "ctlConvenio";
            this.ctlConvenio.NaoAjustarEdicao = true;
            this.ctlConvenio.Obrigatorio = false;
            this.ctlConvenio.ObrigatorioMensagem = null;
            this.ctlConvenio.Size = new System.Drawing.Size(360, 24);
            this.ctlConvenio.TabIndex = 165;
            this.ctlConvenio.Pesquisar += new Hac.Windows.Forms.Controls.HacConvenio.PesquisarDelegate(this.ctlConvenio_Pesquisar);
            // 
            // object_c2275fce_0120_45fa_ad72_ae42d53c6bc4
            // 
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.AlterarStatus = true;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.BackColor = System.Drawing.Color.Transparent;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.BackgroundImage")));
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.FlatAppearance.BorderSize = 0;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.Location = new System.Drawing.Point(336, 1);
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.Name = "object_c2275fce_0120_45fa_ad72_ae42d53c6bc4";
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.Size = new System.Drawing.Size(21, 20);
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.TabIndex = 2;
            this.object_c2275fce_0120_45fa_ad72_ae42d53c6bc4.UseVisualStyleBackColor = false;
            // 
            // txtDescricaoConvenio
            // 
            this.txtDescricaoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtDescricaoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtDescricaoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtDescricaoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtDescricaoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoConvenio.Limpar = true;
            this.txtDescricaoConvenio.Location = new System.Drawing.Point(50, 3);
            this.txtDescricaoConvenio.Name = "txtDescricaoConvenio";
            this.txtDescricaoConvenio.NaoAjustarEdicao = false;
            this.txtDescricaoConvenio.Obrigatorio = false;
            this.txtDescricaoConvenio.ObrigatorioMensagem = null;
            this.txtDescricaoConvenio.PreValidacaoMensagem = null;
            this.txtDescricaoConvenio.PreValidado = false;
            this.txtDescricaoConvenio.SelectAllOnFocus = false;
            this.txtDescricaoConvenio.Size = new System.Drawing.Size(280, 18);
            this.txtDescricaoConvenio.TabIndex = 1;
            // 
            // txtCodigoConvenio
            // 
            this.txtCodigoConvenio.AcceptedFormat = Hac.Windows.Forms.Controls.AcceptedFormat.AlfaNumerico;
            this.txtCodigoConvenio.BackColor = System.Drawing.Color.Honeydew;
            this.txtCodigoConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoConvenio.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.txtCodigoConvenio.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.txtCodigoConvenio.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoConvenio.Limpar = true;
            this.txtCodigoConvenio.Location = new System.Drawing.Point(0, 3);
            this.txtCodigoConvenio.MaxLength = 5;
            this.txtCodigoConvenio.Name = "txtCodigoConvenio";
            this.txtCodigoConvenio.NaoAjustarEdicao = false;
            this.txtCodigoConvenio.Obrigatorio = false;
            this.txtCodigoConvenio.ObrigatorioMensagem = null;
            this.txtCodigoConvenio.PreValidacaoMensagem = null;
            this.txtCodigoConvenio.PreValidado = false;
            this.txtCodigoConvenio.SelectAllOnFocus = false;
            this.txtCodigoConvenio.Size = new System.Drawing.Size(44, 18);
            this.txtCodigoConvenio.TabIndex = 0;
            // 
            // lblConvenio
            // 
            this.lblConvenio.AutoSize = true;
            this.lblConvenio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenio.Location = new System.Drawing.Point(8, 19);
            this.lblConvenio.Name = "lblConvenio";
            this.lblConvenio.Size = new System.Drawing.Size(71, 14);
            this.lblConvenio.TabIndex = 0;
            this.lblConvenio.Text = "Convênio:";
            // 
            // lblPlano
            // 
            this.lblPlano.AutoSize = true;
            this.lblPlano.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlano.Location = new System.Drawing.Point(8, 43);
            this.lblPlano.Name = "lblPlano";
            this.lblPlano.Size = new System.Drawing.Size(47, 14);
            this.lblPlano.TabIndex = 1;
            this.lblPlano.Text = "Plano:";
            // 
            // lblCredencial
            // 
            this.lblCredencial.AutoSize = true;
            this.lblCredencial.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredencial.Location = new System.Drawing.Point(8, 66);
            this.lblCredencial.Name = "lblCredencial";
            this.lblCredencial.Size = new System.Drawing.Size(78, 14);
            this.lblCredencial.TabIndex = 2;
            this.lblCredencial.Text = "Credencial:";
            // 
            // grdExclusao
            // 
            this.grdExclusao.AllowUserToAddRows = false;
            this.grdExclusao.AllowUserToDeleteRows = false;
            this.grdExclusao.AllowUserToOrderColumns = true;
            this.grdExclusao.AllowUserToResizeColumns = false;
            this.grdExclusao.AllowUserToResizeRows = false;
            this.grdExclusao.AlterarStatus = false;
            this.grdExclusao.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdExclusao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdExclusao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExclusao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colCodigo2,
            this.colDescricao});
            this.grdExclusao.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Nunca;
            this.grdExclusao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdExclusao.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.grdExclusao.GridPesquisa = true;
            this.grdExclusao.Limpar = true;
            this.grdExclusao.Location = new System.Drawing.Point(6, 130);
            this.grdExclusao.MultiSelect = false;
            this.grdExclusao.Name = "grdExclusao";
            this.grdExclusao.NaoAjustarEdicao = true;
            this.grdExclusao.Obrigatorio = false;
            this.grdExclusao.ObrigatorioMensagem = null;
            this.grdExclusao.PreValidacaoMensagem = null;
            this.grdExclusao.PreValidado = false;
            this.grdExclusao.ReadOnly = true;
            this.grdExclusao.RowHeadersVisible = false;
            this.grdExclusao.RowHeadersWidth = 25;
            this.grdExclusao.Size = new System.Drawing.Size(754, 268);
            this.grdExclusao.TabIndex = 2;
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "CODPLA";
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colCodigo2
            // 
            this.colCodigo2.DataPropertyName = "CODEXC";
            this.colCodigo2.HeaderText = "Código";
            this.colCodigo2.Name = "colCodigo2";
            this.colCodigo2.ReadOnly = true;
            // 
            // colDescricao
            // 
            this.colDescricao.DataPropertyName = "DESEXC";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            // 
            // tspCommand
            // 
            this.tspCommand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tspCommand.BackgroundImage")));
            this.tspCommand.CancelarVisivel = false;
            this.tspCommand.ExcluirVisivel = false;
            this.tspCommand.ImprimirVisivel = false;
            this.tspCommand.Location = new System.Drawing.Point(0, 0);
            this.tspCommand.MatMedVisivel = false;
            this.tspCommand.Name = "tspCommand";
            this.tspCommand.NomeControleFoco = null;
            this.tspCommand.NovoVisivel = false;
            this.tspCommand.SalvarVisivel = false;
            this.tspCommand.Size = new System.Drawing.Size(765, 28);
            this.tspCommand.TabIndex = 0;
            this.tspCommand.Text = "hacToolStrip1";
            this.tspCommand.TituloTela = "";
            this.tspCommand.BeforePesquisar += new Hac.Windows.Forms.Controls.AfterBeforeHacEventHandler(this.tspCommand_BeforePesquisar);
            this.tspCommand.PesquisarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_PesquisarClick);
            this.tspCommand.CancelarClick += new Hac.Windows.Forms.Controls.ToolStripHacEventHandler(this.tspCommand_CancelarClick);
            // 
            // FrmPesquisaExclusaoContratual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 404);
            this.ControlBox = false;
            this.Controls.Add(this.tspCommand);
            this.Controls.Add(this.grdExclusao);
            this.Controls.Add(this.gbxPesquisar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesquisaExclusaoContratual";
            this.ShowInTaskbar = false;
            this.Text = "Consulta_Exclusao_Contratual";
            this.Load += new System.EventHandler(this.FrmPesquisaExclusaoContratual_Load);
            this.gbxPesquisar.ResumeLayout(false);
            this.gbxPesquisar.PerformLayout();
            this.ctlPlano.ResumeLayout(false);
            this.ctlPlano.PerformLayout();
            this.ctlConvenio.ResumeLayout(false);
            this.ctlConvenio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExclusao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPesquisar;
        private Hac.Windows.Forms.Controls.HacLabel lblConvenio;
        private Hac.Windows.Forms.Controls.HacLabel lblPlano;
        private Hac.Windows.Forms.Controls.HacLabel lblCredencial;
        private Hac.Windows.Forms.Controls.HacDataGridView grdExclusao;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private Hac.Windows.Forms.Controls.HacToolStrip tspCommand;
        private Hac.Windows.Forms.Controls.HacPlano ctlPlano;
        private Hac.Windows.Forms.Controls.HacButton btnPesquisarCID10Principal;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoPlano;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoPlano;
        private Hac.Windows.Forms.Controls.HacConvenio ctlConvenio;
        private Hac.Windows.Forms.Controls.HacButton object_c2275fce_0120_45fa_ad72_ae42d53c6bc4;
        private Hac.Windows.Forms.Controls.HacTextBox txtDescricaoConvenio;
        private Hac.Windows.Forms.Controls.HacTextBox txtCodigoConvenio;
        private HacTextBox txtCodSeqBen;
        private HacTextBox txtCredencialHac;
        private HacTextBox txtCodSeq;
    }
}