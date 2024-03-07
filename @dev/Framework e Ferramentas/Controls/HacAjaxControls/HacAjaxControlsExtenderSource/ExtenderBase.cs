using System.Web.UI;
/*
 * Desenvolvido por: Guilherme Holdack - Outubro 2007
 */
namespace HacAjaxControlsExtender
{
    public abstract class ExtenderBase : ExtenderControl
    {
        internal const string Control_Not_Found = "Controle '{0}' não encontrado, referenciado pela propriedade '{1}'  de '{2}'";
        internal const string Target_Is_Null = "Defina um TargetControlID.";

        /// <summary>
        /// Locate control by walking up the control tree
        /// ref: Ajax Control Toolkit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal Control FindControlHelper(string id)
        {
            Control c = base.FindControl(id);
            Control nc = NamingContainer;

            while ((null == c) && (null != nc))
            {
                c = nc.FindControl(id);
                nc = nc.NamingContainer;
            }
            return c;
        }
    }
}