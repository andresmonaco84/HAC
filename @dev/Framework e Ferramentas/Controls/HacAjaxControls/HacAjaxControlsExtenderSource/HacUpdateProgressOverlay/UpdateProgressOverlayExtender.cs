using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
/*
 * Desenvolvido por: Guilherme Holdack - Outubro 2007
 */
#region Assembly Resource Attribute
[assembly: System.Web.UI.WebResource("HacAjaxControlsExtender.HacUpdateProgressOverlay.UpdateProgressOverlayBehavior.js", "text/javascript")]
#endregion

namespace HacAjaxControlsExtender
{
    [TargetControlType(typeof(UpdateProgress))]
    public class UpdateProgressOverlayExtender : ExtenderBase
    {

        private string _controlToOverlayID;
        private string _cssClass;
        private OverlayType _overlayType;

        [Description("Classe CSS para aplicar ao controle UpdateProgress.")]
        public string CssClass
        {
            get { return _cssClass; }
            set { _cssClass = value; }
        }

        [Description("Um controle para receber o Overlay. Se deixado em branco, e o tipo de Overlay não for \"Browser\", será utilizado o AssociatedUpdatePanelID do TargetControlID.")]
        public string ControlToOverlayID
        {
            get { return _controlToOverlayID; }
            set { _controlToOverlayID = value; }
        }

        [Description("Executa o Overlay sobre um controle específico ou na área de visualização do browser.")]
        [DefaultValue(typeof(OverlayType), "Control")]
        public OverlayType OverlayType
        {
            get { return _overlayType; }
            set { _overlayType = value; }
        }

        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
        {
            ScriptBehaviorDescriptor descriptor =
                new ScriptBehaviorDescriptor("Hac.UpdateProgressOverlayBehavior", targetControl.ClientID);

            UpdateProgress up = targetControl as UpdateProgress;
            string asscUpdatePanelClientId = string.IsNullOrEmpty(up.AssociatedUpdatePanelID) ?
                null : GetClientId(up.AssociatedUpdatePanelID, "AssociatedUpdatePanelID");


            string controlToOverlayID = null;
            if (_overlayType != OverlayType.Browser)
            {
                controlToOverlayID = string.IsNullOrEmpty(ControlToOverlayID) ?
                    asscUpdatePanelClientId : GetClientId(ControlToOverlayID, "ControlToOverlayID");
            }

            descriptor.AddProperty("controlToOverlayID", controlToOverlayID);
            descriptor.AddProperty("associatedUpdatePanelID", asscUpdatePanelClientId);
            descriptor.AddProperty("displayAfter", up.DisplayAfter);
            descriptor.AddProperty("targetCssClass", this.CssClass);
            return new ScriptDescriptor[] { descriptor };
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            ScriptReference reference = new ScriptReference(
                "HacAjaxControlsExtender.HacUpdateProgressOverlay.UpdateProgressOverlayBehavior.js", "HacAjaxControlsExtender");
            return new ScriptReference[] { reference };
        }

        private string GetClientId(string controlID, string propertyName)
        {
            Control control = base.FindControlHelper(controlID);
            if (control == null)
            {
                throw new HttpException(
                   String.Format(Control_Not_Found, controlID,
                       propertyName, this.ID));
            }

            return control.ClientID;
        }
    }

    public enum OverlayType
    {
        Control = 0,
        Browser = 1
    }
}