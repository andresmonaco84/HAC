namespace Hac.Windows.Forms.Controls
{
    partial class HacCmbSetor
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HacCmbSetor
            // 
            this.Editavel = Hac.Windows.Forms.Controls.ControleEdicao.Sempre;
            this.EstadoInicial = Hac.Windows.Forms.Controls.EstadoObjeto.Habilitado;
            this.Obrigatorio = true;
            this.ObrigatorioMensagem = "Setor Não Pode Estar em Branco";
            this.PreValidacaoMensagem = "Setor Não Pode Estar em Branco";
            this.PreValidado = true;
            this.ResumeLayout(false);

        }

        #endregion
    }
}
