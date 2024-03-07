using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Forms
{
	/// <summary>
    /// Summary description for FrmFoto.
	/// </summary>
    public class FrmFoto : FrmBase
	{
	    private WebCamCapture webCamCapture;

        private System.Windows.Forms.PictureBox pictureBox1;

        private GroupBox gbxBotoes;
        private Hac.Windows.Forms.Controls.HacButton btnSalvar;
        private Hac.Windows.Forms.Controls.HacButton btnRecapturar;
        private ToolTip toolTip1;
        private Hac.Windows.Forms.Controls.HacLabel lblFotoNaoCadastrada;
        private System.ComponentModel.IContainer components;

		public FrmFoto()
		{
			InitializeComponent();

		    ConfigurarBotoes();
		}

        public void ConfigurarBotoes()
        {
            Bitmap imgButton = new Bitmap(new Bitmap(global::Hac.Windows.Forms.Controls.Properties.Resources.btnOk), btnSalvar.Width, btnSalvar.Height);
            btnSalvar.BackgroundImage = null;
            btnSalvar.Image = imgButton;

            imgButton = new Bitmap(new Bitmap(global::Hac.Windows.Forms.Controls.Properties.Resources.replace2), btnRecapturar.Width, btnRecapturar.Height);
            btnRecapturar.BackgroundImage = null;
            btnRecapturar.Image = imgButton;
        }

	    /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.webCamCapture = new Hac.Windows.Forms.Controls.Forms.WebCamCapture();
            this.gbxBotoes = new System.Windows.Forms.GroupBox();
            this.btnRecapturar = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.btnSalvar = new Hac.Windows.Forms.Controls.HacButton(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblFotoNaoCadastrada = new Hac.Windows.Forms.Controls.HacLabel(this.components);
            this.gbxBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // webCamCapture
            // 
            this.webCamCapture.CaptureHeight = 240;
            this.webCamCapture.CaptureWidth = 320;
            this.webCamCapture.FrameNumber = ((ulong)(0ul));
            this.webCamCapture.Location = new System.Drawing.Point(17, 17);
            this.webCamCapture.Name = "WebCamCapture";
            this.webCamCapture.Size = new System.Drawing.Size(342, 252);
            this.webCamCapture.TabIndex = 0;
            this.webCamCapture.TimeToCapture_milliseconds = 100;
            this.webCamCapture.ImageCaptured += new Hac.Windows.Forms.Controls.Forms.WebCamCapture.WebCamEventHandler(this.WebCamCapture_ImageCaptured);
            // 
            // gbxBotoes
            // 
            this.gbxBotoes.Controls.Add(this.btnRecapturar);
            this.gbxBotoes.Controls.Add(this.btnSalvar);
            this.gbxBotoes.Location = new System.Drawing.Point(6, 249);
            this.gbxBotoes.Name = "gbxBotoes";
            this.gbxBotoes.Size = new System.Drawing.Size(320, 61);
            this.gbxBotoes.TabIndex = 4;
            this.gbxBotoes.TabStop = false;
            // 
            // btnRecapturar
            // 
            this.btnRecapturar.AlterarStatus = true;
            this.btnRecapturar.BackColor = System.Drawing.Color.Transparent;
            this.btnRecapturar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecapturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecapturar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnRecapturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecapturar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnRecapturar.Location = new System.Drawing.Point(172, 9);
            this.btnRecapturar.Name = "btnRecapturar";
            this.btnRecapturar.Size = new System.Drawing.Size(50, 49);
            this.btnRecapturar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnRecapturar, "Recapturar a Foto");
            this.btnRecapturar.UseVisualStyleBackColor = false;
            this.btnRecapturar.Click += new System.EventHandler(this.btnRecapturar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AlterarStatus = true;
            this.btnSalvar.BackColor = System.Drawing.Color.Transparent;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(98, 9);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(50, 49);
            this.btnSalvar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnSalvar, "Salvar a Foto");
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblFotoNaoCadastrada
            // 
            this.lblFotoNaoCadastrada.AutoSize = true;
            this.lblFotoNaoCadastrada.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFotoNaoCadastrada.Location = new System.Drawing.Point(3, 313);
            this.lblFotoNaoCadastrada.Name = "lblFotoNaoCadastrada";
            this.lblFotoNaoCadastrada.Size = new System.Drawing.Size(237, 13);
            this.lblFotoNaoCadastrada.TabIndex = 5;
            this.lblFotoNaoCadastrada.Text = "Foto não cadastrada para este paciente.";
            // 
            // FrmFoto
            // 
            this.ClientSize = new System.Drawing.Size(332, 329);
            this.Controls.Add(this.lblFotoNaoCadastrada);
            this.Controls.Add(this.gbxBotoes);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmFoto";
            this.Text = "Foto do Paciente";
            this.Load += new System.EventHandler(this.FrmFoto_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmFoto_Closing);
            this.gbxBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FrmFoto());
		}

        private void FrmFoto_Load(object sender, System.EventArgs e)
		{
            lblFotoNaoCadastrada.Visible = false;

			// set the image capture size
            webCamCapture.CaptureHeight = this.pictureBox1.Height;
            webCamCapture.CaptureWidth = this.pictureBox1.Width;
            webCamCapture.Start(1);

            CarregarFoto();
        }


        private void FrmFoto_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            this.webCamCapture.Stop();
		}

        private void WebCamCapture_ImageCaptured(object source, WebcamEventArgs e)
        {
            this.pictureBox1.Image = e.WebCamImage;
        }


        private string ConvertImage(Bitmap sBit)
        {
            MemoryStream imageStream = new MemoryStream();
            sBit.Save(imageStream, ImageFormat.Jpeg);

            return Convert.ToBase64String(imageStream.ToArray());
        }


        #region "buttons"
        private void btnRecapturar_Click(object sender, EventArgs e)
        {
            this.webCamCapture.Start(this.webCamCapture.FrameNumber);
            
            btnSalvar.Enabled = true;
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.webCamCapture.Stop();

            IDataObject tempObj = Clipboard.GetDataObject();
            System.Drawing.Bitmap tempImg = (System.Drawing.Bitmap)tempObj.GetData(System.Windows.Forms.DataFormats.Bitmap);
            GC.Collect();
            if (tempImg != null)
            {
                String str = ConvertImage(tempImg);

                Paciente.SavePicture(_IdtPessoa, str);
                
                MessageBox.Show("Operação realizada com sucesso.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else
            {
                MessageBox.Show("Câmera não encontrada !");
            }
        }

        private void CarregarFoto()
        {
            Clipboard.Clear();

            this.webCamCapture.Stop();
            
            string base64String = Paciente.GetPicture(Convert.ToInt32(_IdtPessoa));

            if (base64String == "msg:1")
            {
                btnSalvar.Enabled = true;

                lblFotoNaoCadastrada.Visible = true;

                this.webCamCapture.Start(1);
            }
            else
            {
                btnSalvar.Enabled = false;

                lblFotoNaoCadastrada.Visible = false;

                MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64String));

                pictureBox1.Image = Image.FromStream(stream);
            }
        }
        #endregion


        public static void AbrirFormFoto(Int32 idtPessoa)
        {
            FrmFoto frm = new FrmFoto();
            frm._IdtPessoa = idtPessoa;
            frm.ShowDialog();
        }

	    private Int32 _IdtPessoa;
        public Int32 IdtPessoa
        {
            get { return _IdtPessoa; }
            set { _IdtPessoa = value; }
        }
    }
}
