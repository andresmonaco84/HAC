using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    [Serializable()]
    public class PacienteEntity : Entity
    {
        public PacienteEntity()
        {

        }
       
        #region "Private Declarations"
        // dados de atendimento/liberação

        private string strCodigoBarras = string.Empty;

        private string strIdtPaciente = string.Empty;
        private string strAtendimento = string.Empty;

        private string strCodigoConvenio = "";
        private string strConvenio = string.Empty;        
        private string strPadrao = string.Empty;
        private string strCodigoPlano = string.Empty;
        private string strPlano = string.Empty;
        private string strTipoPlano = string.Empty;
        private string strTipoAtendimento = string.Empty;

        private string strPaciente = string.Empty;
        private string strTipoPaciente = string.Empty;
        private string strProntuario = string.Empty;
        private string strDataNascimento = string.Empty;
        private string strIdade = string.Empty;
        private string strSexo = string.Empty;
        private string strTelefone = string.Empty;
        
        //private string strBeneficiario = string.Empty;
        private string strCredencial = string.Empty;
        private string strRG = string.Empty;
        private string strValidadeCredencial = string.Empty;

        private string strStatusLiberacao = string.Empty;
        private string strOrigem = string.Empty;
        #endregion

        #region "Public Properties"
        public string IdtPaciente
        {
            set { strIdtPaciente = value; }
            get { return strIdtPaciente; }
        }
        public string Atendimento
        {
            set { strAtendimento = value; }
            get { return strAtendimento; }
        }
        public string CodigoConvenio
        {
            set { strCodigoConvenio = value; }
            get { return strCodigoConvenio; }
        }
        public string Convenio
        {
            set { strConvenio = value.ToUpper(); }
            get { return strConvenio; }
        }
        public string Padrao
        {
            set { strPadrao = value.ToUpper(); }
            get { return strPadrao; }
        }
        public string CodigoPlano
        {
            set { strCodigoPlano = value.ToUpper(); }
            get { return strCodigoPlano; }
        }
        public string Plano
        {
            set { strPlano = value.ToUpper(); }
            get { return strPlano; }
        }
        public string TipoPlano
        {
            set { strTipoPlano = value.ToUpper(); }
            get { return strTipoPlano; }
        }
        public string Paciente
        {
            set { strPaciente = value; }
            get { return strPaciente; }
        }
        public string TipoPaciente
        {
            set { strTipoPaciente = value; }
            get { return strTipoPaciente; }
        }
        public string TipoAtendimento
        {
            set { strTipoAtendimento = value; }
            get { return strTipoAtendimento; }
        }
        

        public string Prontuario
        {
            set { strProntuario = value; }
            get { return strProntuario; }
        }
        public string DataNascimento
        {
            set { strDataNascimento = value; }
            get { return strDataNascimento; }
        }
        public string Idade
        {
            set { strIdade = value; }
            get { return strIdade; }
        }
        public string Sexo
        {
            set { strSexo = value; }
            get { return strSexo; }
        }
        public string Telefone
        {
            set { strTelefone = value; }
            get { return strTelefone; }
        }

                
        public string Credencial
        {
            set { strCredencial = value; }
            get { return strCredencial; }
        }
        public string RG
        {
            set { strRG = value; }
            get { return strRG; }
        }
        public string Validade
        {
            set { strValidadeCredencial = value; }
            get { return strValidadeCredencial; }
        }

        public string Origem
        {
            set { strOrigem = value; }
            get { return strOrigem; }
        }

        public string StatusLiberacao
        {
            set { strStatusLiberacao = value; }
            get { return strStatusLiberacao; }
        }



        #endregion 
    

    }
}
