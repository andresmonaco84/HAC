using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HospitalAnaCosta.Framework.Web
{
    /// <summary>
    /// Summary description for BasePage
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        protected const string ASCENDING = "ASC";
        public const string DESCENDING = "DESC";

        #region "Propriedades"
        private string _nomePaginaErro = "~/erro_detalhe.aspx";
        private bool _isPopUp = false;
        private bool _sessionExpirada = false;

        /// <summary>
        /// Configura o nome da página de erro. Default="erro_detalhe.aspx"
        /// </summary>
        public string NomePaginaErro
        {
            get { return _nomePaginaErro; }
            set { _nomePaginaErro = value; }
        }
        
        /// <summary>
        /// Indica se a página é poupup
        /// </summary>
        public bool IsPopup
        {
            get { return _isPopUp; }
            set { _isPopUp = value; }
        }
        
        /// <summary>
        /// Indica se a sessão está expirada
        /// </summary>
        public bool SessionExpirada
        {
            get { return _sessionExpirada; }
            set { _sessionExpirada = value; }
        }
        #endregion

        #region "Métodos Protected"

        /// <summary>
        /// Define os valores do Sort Direction e Sort Expression
        /// </summary>
        /// <param name="strNomeSortDirection">Nome do Sort Direction</param>
        /// <param name="strNomeSortExpression">Nome do Sort Expression</param>
        /// <param name="strValorSortExpression">Valor do Sort Expression Novo</param>
        /// <param name="strValorSortExpressionAtual">Valor do Sort Expression Atual</param>
        protected void DefinirSort(string strNomeSortDirection, string strNomeSortExpression, string strValorSortExpression, string strValorSortExpressionAtual)
        {
            if (strValorSortExpressionAtual.Equals(ViewState[strNomeSortExpression].ToString()))
            {
                if (ViewState[strNomeSortDirection].ToString().Equals(ASCENDING))
                {
                    ViewState[strNomeSortDirection] = DESCENDING;
                }
                else
                {
                    ViewState[strNomeSortDirection] = ASCENDING;
                }
            }
            else
            {
                ViewState[strNomeSortDirection] = ASCENDING;
                ViewState[strNomeSortExpression] = strValorSortExpressionAtual;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session["isLogged"] == null)
            {
                string mensagem = "O tempo de espera excedeu, favor executar login novamente.";
                Session.Add("SessaoExpirada", mensagem);
                throw new Exception(mensagem);
            }
        }

        protected override void OnError(EventArgs e)
        {
            // At this point we have information about the error
            HttpContext ctx = HttpContext.Current;
            Exception exception = ctx.Server.GetLastError();
            //if (exception is HacException)
            //{
            //    ctx.Server.ClearError();
            //    Response.Redirect("../login.aspx");
            //}
            Session["Exception"] = exception;
            string strUrl = ctx.Request.Url.ToString().Replace("?", "\n?");
            strUrl = strUrl.Replace("&", "\n&");
            Session["URL"] = strUrl;

            //// --------------------------------------------------
            //// To let the page finish running we clear the error
            //// --------------------------------------------------
            // ctx.Server.ClearError();

            //base.OnError(e);  (Comentado pois dava erro com Ajax.Net)
            string strIsPopUp = this.IsPopup ? "S" : "N";
            string strSessionExpirada = this.SessionExpirada ? "S" : "N";
            string strUrlTransfer = this.NomePaginaErro + "?ispopup=" + strIsPopUp + "&sessionexpirada=" + strSessionExpirada;
            Response.Redirect(strUrlTransfer);
            //Server.Transfer(strUrlTransfer); //(Comentado pois dava erro com Ajax.Net)
            
        }

        #endregion "Métodos Protected"

        #region "Métodos Públicos"

        /// <summary>
        /// Não deixa dar Cache na página
        /// </summary>
        public void SetNoCache()
        {
            Response.Expires = -1;
        }

        /// <summary>
        /// Armazena em uma Session o valor da url atual
        /// </summary>
        public void SetURLAtual()
        {
            Session["PaginaCorrente"] = HttpContext.Current.Request.Url.ToString();
        }

        #endregion "FIM - Métodos Públicos"
    }
}
