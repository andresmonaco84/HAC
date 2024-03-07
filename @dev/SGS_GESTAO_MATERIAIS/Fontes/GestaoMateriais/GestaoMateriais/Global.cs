using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.SGS.GestaoMateriaisView;

namespace HospitalAnaCosta.SGS.GestaoMateriais
{
    public static class Global
    {
        private static GemCommon _common;
        public static GemCommon Common
        {
            get { return _common != null ? _common : _common = new GemCommon(null); }            
            //get { return _common != null ? _common : _common = new GemCommon(FrmPrincipal.dtoSeguranca); }            
        }
    }
}