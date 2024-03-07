using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAnaCosta.SGS.Impressao
{
    [Serializable()]
    public class AtendimentoEntity : Entity
    {
        public AtendimentoEntity()
        {
            PossuiCodigoDeBarras = true;
        }
        #region "Private Declarations"
        // dados de atendimento/liberação
      

        private string strCodigoBarras = string.Empty;
        private string strAtendimento = string.Empty;
        private string strDataAtendimento = string.Empty;
        private string strHoraAtendimento = string.Empty;
        private string strDataSolicitacao = string.Empty;
        private string strDataAtual = string.Empty;
        private string strMedico = string.Empty;
        private string strConvenio = string.Empty;
        private string strDataFimConvenio = string.Empty;     
        private string strPadrao = string.Empty;
        private string strCodigoPlano = string.Empty;
        private string strPlano = string.Empty;
        private string strDataFimPlano = string.Empty;
        private string strTipoPlano = string.Empty;
        private string strTipoAtendimento = string.Empty;

        private string strPaciente = string.Empty;
        private string strTipoPaciente = string.Empty;
        private string strProntuario = string.Empty;
        private string strDataNascimento = string.Empty;
        private string strIdade = string.Empty;
        private string strSexo = string.Empty;
        private string strTelefone = string.Empty;

        //private string strEndereco = string.Empty;
        //private string strTipoEndereco = string.Empty;
        //private string strLogradouro = string.Empty;
        //private string strNumeroEndereco = string.Empty;
        //private string strComplementoEnd = string.Empty;
        //private string strBairro = string.Empty;
        //private string strCidade = string.Empty;
        //private string strUF = string.Empty;

        //private string strBeneficiario = string.Empty;
        private string strCredencial = string.Empty;
        private string strRG = string.Empty;
        private string strValidadeCredencial = string.Empty;

        private string strIDUnidade = string.Empty;
        private string strUnidade = string.Empty;
        private string strLocal = string.Empty;
        private string strIDLocal = string.Empty;
        private string strSetor = string.Empty;
        //private string strSetorLib = string.Empty;
        
        //private string strInstitutoGeriatria = string.Empty;
        private string strOrigem = string.Empty;
        private string strStatusLiberacao = string.Empty;

        private string strCodigoProduto = string.Empty;
        private string strDescricaoProduto = string.Empty;

        
        private string strCodigoConvenio = string.Empty;

        private string strIDPaciente = string.Empty;


        #endregion

        #region "Public Properties"

        public string Atendimento
        {
            set { strAtendimento = value; }
            get { return strAtendimento; }
        }
        public string DataAtendimento
        {
            set { strDataAtendimento = value; }
            get { return strDataAtendimento; }
        }
        public string HoraAtendimento
        {
            set { strHoraAtendimento = value; }
            get { return strHoraAtendimento; }
        }
        public string DataSolicitacao
        {
            set { strDataSolicitacao = value; }
            get { return strDataSolicitacao; }
        }
        public string DataAtual
        {
            set { strDataAtual = value; }
            get { return strDataAtual; }
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
        public string DataFimConvenio
        {
            set { strDataFimConvenio = value; }
            get { return strDataFimConvenio; }
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
            set { strPlano = value; }
            get { return strPlano; }
        }
        public string DataFimPlano
        {
            set { strDataFimPlano = value; }
            get { return strDataFimPlano; }
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


        //public string Endereco
        //{
        //    set { strEndereco = value; }
        //    get { return strEndereco; }
        //}
        //public string TipoEndereco
        //{
        //    set { strTipoEndereco = value; }
        //    get { return strTipoEndereco; }
        //}
        //public string Logradouro
        //{
        //    set { strLogradouro = value; }
        //    get { return strLogradouro; }
        //}
        //public string Complemento
        //{
        //    set { strComplementoEnd = value; }
        //    get { return strComplementoEnd; }
        //}
        //public string NumeroEndereco
        //{
        //    set { strNumeroEndereco = value; }
        //    get { return strNumeroEndereco; }
        //}

        //public string Bairro
        //{
        //    set { strBairro = value; }
        //    get { return strBairro; }
        //}
        //public string Cidade
        //{
        //    set { strCidade = value; }
        //    get { return strCidade; }
        //}
        //public string UF
        //{
        //    set { strUF = value; }
        //    get { return strUF; }
        //}


        //public string Beneficiario
        //{
        //    set { strBeneficiario = value; }
        //    get { return strBeneficiario; }
        //}
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

        public string IDUnidade
        {
            set { strIDUnidade = value; }
            get { return strIDUnidade; }
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

        public string CodigoProduto
        {
            set { strCodigoProduto = value; }
            get { return strCodigoProduto; }
        }
        public string DescricaoProduto
        {
            set { strDescricaoProduto = value; }
            get { return strDescricaoProduto; }
        }


        #endregion 
        /*
                #region "Private Declarations"
                // dados de atendimento/liberação
                private string strCodigoBarras = string.Empty;
                private string strAtendimento = string.Empty;
                private string strData = "Data: ";
                private string strHora = "Hora: ";
                private string strHoraTmp = string.Empty;
                private string strMedico = "Médico: ";
                private string strConvenio = "Conv.: ";
                private string strPadrao = "Padrão: ";
                private string strPlano = "Plano: ";
                private string strTipoPlano = "Tipo: ";
                private string strPaciente = "Nome: ";
                private string strProntuario = "Pront.: ";
                private string strDtNasc = "Nasc.: ";
                private string strIdade = "Idade: ";
                private string strSexo = "Sexo: ";
                private string strTelefone = "Tel.: ";
                private string strEndereco = "End.: ";
                private string strBairro = "Bairro: ";
                private string strCidade = "Cidade: ";
                private string strUnidade = "Unid.: ";
                private string strBeneficiario = "Benef.: ";
                private string strMatricula = "Matríc.: ";
                private string strRG = "R.G.: ";
                private string strValidade = "Valid.: ";
                private string strSetor = "Setor: ";
                private string strSetorLib = "Setor Lib.: ";
                private string strLocal = "Local: ";
                private string strTipoAtend = "Tipo Atend.: ";
                private string strUnidadeLib = "Unid. Lib.: ";
                private string strTipoAcomod = "Tipo Acomod.: ";
                private string strInstitutoGeriatria = string.Empty;
                private string strUnidadeReferenciada = "Cod. Prest.:";
                private string strTipoLogradouro = string.Empty;
                private string strAbramge = string.Empty;
                private string strComplementoEnd = "Complemento: ";

                private string strInternacaoPreCadastro = string.Empty;
                private string strInternacaoTipoPaciente = string.Empty; //INTERNO EXTERNO
                private string strInternacaoQuartoLeito = "Quarto/Leito: ";
                private string strInternacaoTipoQuartoLeito = "Tipo:";
                private string strInternacaoTipo = "Tipo.:"; //cortesia, dif. classe

                // dados da clínica
                private string strCodClinica = "Código da Clínica: ";
                private string strClinica = "Nome: ";
                private string strNro = "Nro: ";
                private string strCEP = "CEP: ";
                private string strComplemento = "Compl.: ";
                private string strMunicipio = "Município: ";
                private string strUF = "UF: ";
                private string strTelefoneCli = "Telefone: ";

                // dados dos exames
                private string strCodigoExame = "";
                private string strDescricaoExame = "";
                private string strEnderecoEntrega = "";
                private string strDataEntrega = "";
                private string strProcedencia = "";

                //fat
                private string strCodigoConvenio = "";

                ////// dados de impressão
                ////private int tipoImpressora;
                ////private int origem;
                ////private int qtdImpressoes;
                ////private int tipoImpressao;
                ////private string strStatusLiberacao;
                ////private PrinterResolutionKind tipoResolucao;
                #endregion

                #region "Public Properties"
                public string CodigoBarras
                {
                    set { strCodigoBarras = value; }
                    get { return strCodigoBarras; }
                }
                public string Atendimento
                {
                    set { strAtendimento = value; }
                    get { return strAtendimento; }
                }
                public string Data
                {
                    set { strData = string.Concat(strData, value); }
                    get { return strData; }
                }
                public string Hora
                {
                    set { strHora = string.Concat(strHora, value); }
                    get { return strHora; }
                }
                public string HoraTmp
                {
                    set { strHoraTmp = value; }
                    get { return strHoraTmp; }
                }
                public string Medico
                {
                    set { strMedico = string.Concat(strMedico, value); }
                    get { return strMedico; }
                }
                public string Convenio
                {
                    set { strConvenio = string.Concat(strConvenio, value.ToUpper()); }
                    get { return strConvenio; }
                }
                public string Padrao
                {
                    set { strPadrao = string.Concat(strPadrao, value.ToUpper()); }
                    get { return strPadrao; }
                }
                public string Plano
                {
                    set { strPlano = string.Concat(strPlano, value.ToUpper()); }
                    get { return strPlano; }
                }
                public string TipoPlano
                {
                    set { strTipoPlano = string.Concat(strTipoPlano, value.ToUpper()); }
                    get { return strTipoPlano; }
                }
                public string Paciente
                {
                    set { strPaciente = string.Concat(strPaciente, value); }
                    get { return strPaciente; }
                }
                public string Prontuario
                {
                    set { strProntuario = string.Concat(strProntuario, value); }
                    get { return strProntuario; }
                }
                public string DtNasc
                {
                    set { strDtNasc = string.Concat(strDtNasc, value); }
                    get { return strDtNasc; }
                }
                public string Idade
                {
                    set { strIdade = string.Concat(strIdade, value); }
                    get { return strIdade; }
                }
                public string Sexo
                {
                    set { strSexo = string.Concat(strSexo, value); }
                    get { return strSexo; }
                }
                public string Telefone
                {
                    set { strTelefone = string.Concat(strTelefone, value); }
                    get { return strTelefone; }
                }
                public string TelefoneCli
                {
                    set { strTelefoneCli = string.Concat(strTelefoneCli, value); }
                    get { return strTelefoneCli; }
                }
                public string Endereco
                {
                    set { strEndereco = string.Concat(strEndereco, value); }
                    get { return strEndereco; }
                }
                public string UnidadeReferenciada
                {
                    set { strUnidadeReferenciada = string.Concat(strUnidadeReferenciada, value); }
                    get { return strUnidadeReferenciada; }
                }
                public string Bairro
                {
                    set { strBairro = string.Concat(strBairro, value); }
                    get { return strBairro; }
                }
                public string Cidade
                {
                    set { strCidade = string.Concat(strCidade, value); }
                    get { return strCidade; }
                }
                public string Unidade
                {
                    set { strUnidade = string.Concat(strUnidade, value); }
                    get { return strUnidade; }
                }
                public string Beneficiario
                {
                    set { strBeneficiario = string.Concat(strBeneficiario, value); }
                    get { return strBeneficiario; }
                }
                public string Matricula
                {
                    set { strMatricula = string.Concat(strMatricula, value); }
                    get { return strMatricula; }
                }
                public string RG
                {
                    set { strRG = string.Concat(strRG, value); }
                    get { return strRG; }
                }
                public string Validade
                {
                    set { strValidade = string.Concat(strValidade, value); }
                    get { return strValidade; }
                }
                public string Setor
                {
                    set { strSetor = string.Concat(strSetor, value); }
                    get { return strSetor; }
                }
                public string SetorLib
                {
                    set { strSetorLib = string.Concat(strSetorLib, value); }
                    get { return strSetorLib; }
                }
                public string Local
                {
                    set { strLocal = string.Concat(strLocal, value); }
                    get { return strLocal; }
                }
                public string Abramge
                {
                    set { strAbramge = string.Concat(strAbramge, value); }
                    get { return strAbramge; }
                }

                public string ComplementoEnd
                {
                    set { strComplementoEnd = string.Concat(strComplementoEnd, value); }
                    get { return strComplementoEnd; }
                }

                public string TipoAtend
                {
                    set { strTipoAtend = string.Concat(strTipoAtend, value); }
                    get { return strTipoAtend; }
                }
        
                public string CodigoExame
                {
                    set { strCodigoExame = value; }
                    get { return strCodigoExame; }
                }
                public string DescricaoExame
                {
                    set { strDescricaoExame = value; }
                    get { return strDescricaoExame; }
                }
                public string EnderecoEntrega
                {
                    set { strEnderecoEntrega = value; }
                    get { return strEnderecoEntrega; }
                }
                public string DataEntrega
                {
                    set { strDataEntrega = value; }
                    get { return strDataEntrega; }
                }
                public string Procedencia
                {
                    set { strProcedencia = value; }
                    get { return strProcedencia; }
                }
                public string TipoAcomod
                {
                    set { strTipoAcomod = string.Concat(strTipoAcomod, value); }
                    get { return strTipoAcomod; }
                }

                public string UnidadeLib
                {
                    set { strUnidadeLib = string.Concat(strUnidadeLib, value); }
                    get { return strUnidadeLib; }
                }
                public string InternacaoPreCadastro
                {
                    set { strInternacaoPreCadastro = string.Concat(strInternacaoPreCadastro, value); }
                    get { return strInternacaoPreCadastro; }
                }
                public string InternacaoTipoPaciente
                {
                    set { strInternacaoTipoPaciente = string.Concat(strInternacaoTipoPaciente, value); }
                    get { return strInternacaoTipoPaciente; }
                }
                public string InternacaoQuartoLeito
                {
                    set { strInternacaoQuartoLeito = string.Concat(strInternacaoQuartoLeito, value); }
                    get { return strInternacaoQuartoLeito; }
                }
                public string InternacaoTipoQuartoLeito
                {
                    set { strInternacaoTipoQuartoLeito = string.Concat(strInternacaoTipoQuartoLeito, value); }
                    get { return strInternacaoTipoQuartoLeito; }
                }
                public string InternacaoTipo
                {
                    set { strInternacaoTipo = string.Concat(strInternacaoTipo, value); }
                    get { return strInternacaoTipo; }
                }
                public string CodigoConvenio
                {
                    set { strCodigoConvenio = string.Concat(strCodigoConvenio, value); }
                    get { return strCodigoConvenio; }
                }
                public string InstitutoGeriatria
                {
                    set { strInstitutoGeriatria = value; }
                    get { return strInstitutoGeriatria; }
                }
                public string TipoLogradouro
                {
                    set { strTipoLogradouro = value; }
                    get { return strTipoLogradouro; }
                }

      
                public string CodigoClinica
                {
                    set { strCodClinica = string.Concat(strCodClinica, value); }
                    get { return strCodClinica; }
                }
                public string Clinica
                {
                    set { strClinica = string.Concat(strClinica, value); }
                    get { return strClinica; }
                }
                public string Nro
                {
                    set { strNro = string.Concat(strNro, value); }
                    get { return strNro; }
                }
                public string Cep
                {
                    set { strCEP = string.Concat(strCEP, value); }
                    get { return strCEP; }
                }

                public string Complemento
                {
                    set { strComplementoEnd = string.Concat(strComplementoEnd, value); }
                    get { return strComplementoEnd; }
                }
                public string Municipio
                {
                    set { strMunicipio = String.Concat(strMunicipio, value); }
                    get { return strMunicipio; }
                }
                public string UF
                {
                    set { strUF = string.Concat(strUF, value); }
                    get { return strUF; }
                }

                #endregion 
         */

    }
}
