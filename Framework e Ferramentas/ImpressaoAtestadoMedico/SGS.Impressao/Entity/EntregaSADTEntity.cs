using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    [Serializable()]
    public class EntregaSADTEntity : Entity
    {
        public EntregaSADTEntity()
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
        private string strDataAtendimentoSelecionado = string.Empty;
        private string strHoraAtendimento = string.Empty;
        private string strDataAtual = string.Empty;

        private string strMedico = string.Empty;
        private string strCodigoConvenio = string.Empty;
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
           
        private string strCredencial = string.Empty;
        private string strRG = string.Empty;
        private string strValidadeCredencial = string.Empty;

        private string strUnidade = string.Empty;
        private string strLocal = string.Empty;
        private string strIDLocal = string.Empty;
        private string strSetor = string.Empty;
        
        private string strOrigem = string.Empty;
        
        private string strDataResultado = string.Empty;
        private string strUnidadeEntrega = string.Empty;

        private string strIDPaciente = string.Empty;
        private string strCodigoProduto = string.Empty;
        private string strMnemonicoProduto = string.Empty;

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
        public string DataAtendimentoSelecionado
        {
            set { strDataAtendimentoSelecionado = value; }
            get { return strDataAtendimentoSelecionado; }
        }
        
        public string DataResultado
        {
            set { strDataResultado = value; }
            get { return strDataResultado; }
        }

        public string UnidadeEntrega
        {
            set { strUnidadeEntrega = value; }
            get { return strUnidadeEntrega; }
        }

        public string HoraAtendimento
        {
            set { strHoraAtendimento = value; }
            get { return strHoraAtendimento; }
        }

        public string Medico
        {
            set { strMedico = value; }
            get { return strMedico; }
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
        public string IDPaciente
        {
            set { strIDPaciente = value; }
            get { return strIDPaciente; }
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

        public string Unidade
        {
            set { strUnidade = value; }
            get { return strUnidade; }
        }

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
             
        public string Origem
        {
            set { strOrigem = value; }
            get { return strOrigem; }
        }

        public string CodigoProduto
        {
            set { strCodigoProduto = value; }
            get { return strCodigoProduto; }
        }

        public string MnemonicoProduto
        {
            set { strMnemonicoProduto = value; }
            get { return strMnemonicoProduto; }
        }
        
        #endregion 
    
    
        
    }
}
