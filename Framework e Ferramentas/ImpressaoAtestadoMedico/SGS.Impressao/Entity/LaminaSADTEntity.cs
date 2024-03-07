using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    [Serializable()]
    public class LaminaSADTEntity : Entity
    {
        public LaminaSADTEntity()
        {
            PossuiCodigoDeBarras = false;
        }
        #region "Private Declarations"
        // dados de atendimento/liberação

        private string strCodigoBarras = string.Empty;
        private string strAtendimento = string.Empty;
        private string strTipoIntLib = string.Empty;
        private string strIdtProduto = string.Empty;
        private string strCodigoEspecialidade = string.Empty;
        private string strCodigoTabelaMedica = string.Empty;
        private string strCodigoExame = string.Empty;

        private string strDataAtendimento = string.Empty;
        private string strHoraAtendimento = string.Empty;

        //private string strMedico = string.Empty;      

        //private string strUnidade = string.Empty;
        private string strLocal = string.Empty;
        private string strIDLocal = string.Empty;
        private string strSetor = string.Empty;
        //private string strSetorLib = string.Empty;

        //private string strInstitutoGeriatria = string.Empty;
        private string strOrigem = string.Empty;

        private string strCodigoProduto = string.Empty;
        private string strDescricaoProduto = string.Empty;

       // private string strDataResultado = string.Empty;
       // private string strUnidadeEntrega = string.Empty;
       // private string strDataEntrega = string.Empty;

       // private string strIDPaciente = string.Empty;
        private string strPaciente = string.Empty;

        private string strDataAtual = string.Empty;
        #endregion

        #region "Public Properties"

        public string Atendimento
        {
            set { strAtendimento = value; }
            get { return strAtendimento; }
        }

        public string TipoIntLib
        {
            set { strTipoIntLib = value; }
            get { return strTipoIntLib; }
        }

        public string IdtProduto
        {
            set { strIdtProduto = value; }
            get { return strIdtProduto; }
        }

        public string CodigoEspecialidade
        {
            set { strCodigoEspecialidade = value; }
            get { return strCodigoEspecialidade; }
        }

        public string CodigoTabelaMedica
        {
            set { strCodigoTabelaMedica = value; }
            get { return strCodigoTabelaMedica; }
        }

        public string CodigoExame
        {
            set { strCodigoExame = value; }
            get { return strCodigoExame; }
        }

        public string DataAtendimento
        {
            set { strDataAtendimento = value; }
            get { return strDataAtendimento; }
        }
        public string DataAtual
        {
            set { strDataAtual = value; }
            get { return strDataAtual; }
        }

        //public string DataResultado
        //{
        //    set { strDataResultado = value; }
        //    get { return strDataResultado; }
        //}

        //public string DataEntrega
        //{
        //    set { strDataEntrega = value; }
        //    get { return strDataEntrega; }
        //}

        //public string UnidadeEntrega
        //{
        //    set { strUnidadeEntrega = value; }
        //    get { return strUnidadeEntrega; }
        //}

        public string HoraAtendimento
        {
            set { strHoraAtendimento = value; }
            get { return strHoraAtendimento; }
        }

        //public string Medico
        //{
        //    set { strMedico = value; }
        //    get { return strMedico; }
        //}

    
        //public string IDPaciente
        //{
        //    set { strIDPaciente = value; }
        //    get { return strIDPaciente; }
        //}
        public string Paciente
        {
            set { strPaciente = value; }
            get { return strPaciente; }
        }
      

        //public string Unidade
        //{
        //    set { strUnidade = value; }
        //    get { return strUnidade; }
        //}

        public string IDLocal
        {
            set { strIDLocal = value; }
            get { return strIDLocal; }
        }

        public string Local
        {
            set { strLocal = value; }
            get { return strLocal; }
        }
        public string Setor
        {
            set { strSetor = value; }
            get { return strSetor; }
        }

        //public string SetorLiberacao
        //{
        //    set { strSetorLib = value; }
        //    get { return strSetorLib; }
        //}

        //public string InstitutoGeriatria
        //{
        //    set { strInstitutoGeriatria = value; }
        //    get { return strInstitutoGeriatria; }
        //}

        //public string Origem
        //{
        //    set { strOrigem = value; }
        //    get { return strOrigem; }
        //}

      

        //public string CodigoProduto
        //{
        //    set { strCodigoProduto = value; }
        //    get { return strCodigoProduto; }
        //}
        //public string DescricaoProduto
        //{
        //    set { strDescricaoProduto = value; }
        //    get { return strDescricaoProduto; }
        //}


        #endregion
    }
}
