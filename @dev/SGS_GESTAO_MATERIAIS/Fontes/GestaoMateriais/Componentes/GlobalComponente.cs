using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.SGS.GestaoMateriaisView;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Componentes
{
    public static class GlobalComponentes
    {
        private static GemCommon _componentes;
        public static GemCommon Componentes
        {
            // get { return _componentes != null ? _componentes : _componentes = new GemCommon(new Seguranca.DTO.SegurancaDTO()); }
            get { return _componentes != null ? _componentes : _componentes = new GemCommon(null); }
        }

        private static CommonSeguranca _seguranca;
        public static CommonSeguranca Seguranca
        {
            get { return _seguranca != null ? _seguranca : _seguranca = new CommonSeguranca(null); }
        }
    }
}