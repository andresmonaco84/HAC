using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
/*
 * Desenvolvido por: Guilherme Holdack - Outubro 2007
 */
#region Assembly Resource Attribute
[assembly: System.Web.UI.WebResource("HacAjaxControlsExtender.HacLoadingPage.LoadingPageBehavior.js", "text/javascript")]
#endregion
//TODO: arrumar....
namespace HacAjaxControlsExtender
{
    public class LoadingPageExtender : WebControl
    {
        private string _divLoading;

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "carregando", "carregarPagina('" + LoadingDiv + "')", true);

            
            
        }
        protected override  void  OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ClientScriptManager cs = this.Page.ClientScript;
            cs.RegisterClientScriptInclude("carregando", Page.ClientScript.GetWebResourceUrl(this.GetType(), "HacAjaxControlsExtender.HacLoadingPage.LoadingPageBehavior.js"));
              
        }

        [Description("Div que terá o conteúdo de 'Aguarde...'")]
        public string LoadingDiv
        {
            get
            {
                return _divLoading;
            }
            set
            {
                _divLoading = value;
            }
        }

    }
}