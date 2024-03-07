using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;


namespace HospitalAnaCosta.SGS.Impressao
{
    public class Impressao
    {
        Font fontTitulo;
        Font fontTexto;
        Font fontLabel; // BOLD
        Font fontDestacado; // BOLD
        Font fontTextoMsg;
        PrintDocument doc;
        private float MargemEsquerda; 
        float MargemDireita;
        float MargemTopo;


        public Impressao()
        {
            // define fontes padrões
            fontTitulo = new Font("Arial", 12);
            fontTexto = new Font("Times New Roman", 10);
            fontLabel = new Font("Times New Roman", 10, FontStyle.Bold);
            fontTextoMsg = new Font("Times New Roman", 14);
            fontDestacado = new Font("Times New Roman", 14);
            doc = new PrintDocument();
        }

        private void imprimir(object sender, PrintPageEventArgs e)
        {

            MargemEsquerda = e.PageSettings.Margins.Left = 10;
            MargemDireita = e.PageSettings.PrintableArea.Width - MargemEsquerda;
            MargemTopo = e.PageSettings.HardMarginY;


        }

    }
}
