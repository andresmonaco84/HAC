using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmGeraArquivoContabil : FrmBase
    {
        public FrmGeraArquivoContabil()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            int nLote = 6,    DtLanc = 8,  nDoc = 8,      nContDev = 20, nContCred = 20, nContraPart = 20;
            int VlrLanc = 18, CodHist = 8, FilialLan = 3, CCusto = 10,   Dept = 25,      DtCotac = 8;
            int Vlr2 = 18,    TpPart = 1,  CdPart = 25,   CtGerenc = 20, VlrRat = 18;
            FileDlg.ShowDialog();
            txtArquivo.Text = FileDlg.FileName;

        }
    }
}