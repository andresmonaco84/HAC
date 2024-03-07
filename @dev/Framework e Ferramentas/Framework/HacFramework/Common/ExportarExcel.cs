using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalAnaCosta.Framework
{
    /// <summary>
    /// Classe que exporta os dados de um datagrid, table ou gridview para Excel
    /// </summary>
    public class ExportarExcel
    {
        /// <summary>
        /// Exporta os dados passados no datagrid para Excel
        /// </summary>
        /// <param name="grdExportar">DATA GRID</param>
        /// <param name="strNomeArquivo">NOME DO ARQUIVO (SEM EXTENSÃO)</param>
        /// <param name="blnGerarIdentificadorUnico">
        /// TRUE : GERA IDENTIFICADOR ÚNICO (E CONCATENA COM O NOME DO ARQUIVO)
        /// FALSE: NÃO GERA IDENTIFICADOR ÚNICO
        /// </param>
        public void Exportar(DataGrid grdExportar, string strNomeArquivo, bool blnGerarIdentificadorUnico)
        {
            Guid g = new Guid();
            HttpResponse oResponse = HttpContext.Current.Response;

            oResponse.Clear();
            oResponse.AddHeader("Content-Disposition", "attachment; filename=" + strNomeArquivo + (blnGerarIdentificadorUnico ? g.ToString() : "") + ".xls");
            oResponse.ContentType = "application/vnd.ms-excel";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            grdExportar.DataBind();
            grdExportar.RenderControl(htmlWrite);
            oResponse.Write(stringWrite.ToString());
            oResponse.End();
        }

        /// <summary>
        /// Exporta os dados passados no objeto Table para Excel
        /// </summary>
        /// <param name="grdExportar">DATA GRID</param>
        /// <param name="strNomeArquivo">NOME DO ARQUIVO (SEM EXTENSÃO)</param>
        /// <param name="blnGerarIdentificadorUnico">
        /// TRUE : GERA IDENTIFICADOR ÚNICO (E CONCATENA COM O NOME DO ARQUIVO)
        /// FALSE: NÃO GERA IDENTIFICADOR ÚNICO
        /// </param>
        public void Exportar(Table tblExportar, string strNomeArquivo, bool blnGerarIdentificadorUnico)
        {
            Guid g = new Guid();
            HttpResponse oResponse = HttpContext.Current.Response;

            oResponse.Clear();
            oResponse.AddHeader("Content-Disposition", "attachment; filename=" + strNomeArquivo + (blnGerarIdentificadorUnico ? g.ToString() : "") + ".xls");
            oResponse.ContentType = "application/vnd.ms-excel";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            tblExportar.RenderControl(htmlWrite);
            oResponse.Write(stringWrite.ToString());
            oResponse.End();
        }

        // TODO: ACERTAR O EXPORTAR PARA GRIDVIEW
        /// <summary>
        /// Exporta os dados passados no GridView para Excel
        /// </summary>
        /// <param name="grdExportar">GRIDVIEW</param>
        /// <param name="strNomeArquivo">NOME DO ARQUIVO (SEM EXTENSÃO)</param>
        /// <param name="blnGerarIdentificadorUnico">
        /// TRUE : GERA IDENTIFICADOR ÚNICO (E CONCATENA COM O NOME DO ARQUIVO)
        /// FALSE: NÃO GERA IDENTIFICADOR ÚNICO
        /// </param>
        public void Exportar(GridView grdExportar, string strNomeArquivo, bool blnGerarIdentificadorUnico)
        {
            Guid g = new Guid();
            HttpResponse oResponse = HttpContext.Current.Response;

            oResponse.Clear();
            oResponse.AddHeader("Content-Disposition", "attachment; filename=" + strNomeArquivo + (blnGerarIdentificadorUnico ? g.ToString() : "") + ".xls");
            oResponse.ContentType = "application/vnd.ms-excel";

            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            grdExportar.EnableViewState = false;
            grdExportar.DataBind();
            grdExportar.RenderControl(htmlWrite);
            oResponse.Write(stringWrite.ToString());
            oResponse.End();
        }
    }
}
