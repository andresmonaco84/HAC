using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    [Serializable()]
    public class ClinicaEntity : Entity
    {
        public ClinicaEntity()
        {

        }
      
        private string strIdtClinica = string.Empty;
        private string strCodigoClinica = string.Empty;
        private string strDescricao = string.Empty;
        private string strDescricaoResumida = string.Empty;

        private string strTelefone = string.Empty;
        private string strEndereco = string.Empty;
        private string strTipoEndereco = string.Empty;
        private string strTipoLogradouro = string.Empty;
        private string strLogradouro = string.Empty;
        private string strNumeroEndereco = string.Empty;
        private string strComplementoEnd = string.Empty;
        private string strBairro = string.Empty;
        private string strCEP = string.Empty;
        private string strCidade = string.Empty;
        private string strUF = string.Empty;
               
        private string strOrigem = string.Empty;

              

        #region "Public Properties"

        public string IdtClinica
        {
            set { strIdtClinica = value; }
            get { return strIdtClinica; }
        }

        public string CodigoClinica
        {
            set { strCodigoClinica = value; }
            get { return strCodigoClinica; }
        }

        public string Descricao
        {
            set { strDescricao = value; }
            get { return strDescricao; }
        }

        public string DescricaoResumida
        {
            set { strDescricaoResumida = value; }
            get { return strDescricaoResumida; }
        }
       
        public string Telefone
        {
            set { strTelefone = value; }
            get { return strTelefone; }
        }

        public string Endereco
        {
            set { strEndereco = value; }
            get { return strEndereco; }
        }
        public string TipoEndereco
        {
            set { strTipoEndereco = value; }
            get { return strTipoEndereco; }
        }
        public string TipoLogradouro
        {
            set { strTipoLogradouro = value; }
            get { return strTipoLogradouro; }
        }
        public string Logradouro
        {
            set { strLogradouro = value; }
            get { return strLogradouro; }
        }
        public string Complemento
        {
            set { strComplementoEnd = value; }
            get { return strComplementoEnd; }
        }
        public string NumeroEndereco
        {
            set { strNumeroEndereco = value; }
            get { return strNumeroEndereco; }
        }

        public string Bairro
        {
            set { strBairro = value; }
            get { return strBairro; }
        }

        public string CEP
        {
            set { strCEP = value; }
            get { return strCEP; }
        }

        public string Cidade
        {
            set { strCidade = value; }
            get { return strCidade; }
        }
        public string UF
        {
            set { strUF = value; }
            get { return strUF; }
        }

        public string Origem
        {
            set { strOrigem = value; }
            get { return strOrigem; }
        }

        #endregion 
    

    }
}
