using System.Data;
using HospitalAnaCosta.Services.BeneficiarioACS.Model;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.Services.BeneficiarioACS.Interface;
using HospitalAnaCosta.Framework;
//using HospitalAnaCosta.Services.BeneficiarioACS.DTO.Exceptions;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Control
{
    public class BeneficiarioACS : Control, IBeneficiarioACS
    {
        private Model.BeneficiarioACS entity = new Model.BeneficiarioACS();

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public BeneficiarioACSDataTable Listar(BeneficiarioACSDTO dto)
        {
            return entity.Listar(dto);
        }

        /// <summary>
        /// Listar todos os registros
        /// Parametro situacao = "I", "A" ou NULL.
        /// </summary>
        public BeneficiarioACSDataTable Listar(BeneficiarioACSDTO dto, string situacao, bool incluirHomeCare, bool existeHomeCare)
        {
            return entity.Listar(dto, situacao, incluirHomeCare, existeHomeCare);
        }

        private int sync = 0;

        /// <summary>
        /// Obter pela chave
        /// </summary>        
        public BeneficiarioACSDTO Pesquisar(BeneficiarioACSDTO dto)
        {
            if (sync > 5)
            {
                sync = 0;
                throw new HacException("Beneficiário Transferido muitas vezes, por favor entrar em contato com o Plano - ACS"); 
            }
            dto = entity.Pesquisar(dto);

            if (dto == null)
            {
                throw new CadastroBeneficiarioNotFoundException("Beneficiário não encontrado.");
            }

            switch (dto.CdSituacaoBeneficiario.Value.ToString())
            {
                case "5":
                    throw new HacException("Beneficiário Excluído, por favor entrar em contato com o Plano – ACS");
                    break;
                case "6":
                    throw new HacException("Beneficiário Suspenso,por favor entrar em contato com o Plano – ACS");
                    break;
                case "7":
                    sync++;
                    Pesquisar(BenefTransferido(dto));
                    break;
            }

            return dto;
        }

        protected BeneficiarioACSDTO BenefTransferido(BeneficiarioACSDTO dto)
        {
            return entity.PesquisarBenefTransferido(dto);
        }

        ///<summary>
        /// Insere um registro
        /// </summary>
        public BeneficiarioACSDTO Incluir(BeneficiarioACSDTO dto)
        {
            entity.Incluir(dto);
            return dto;
        }

        ///<summary>
        /// Apaga um registro
        /// </summary>		
        public void Excluir(BeneficiarioACSDTO dto)
        {
            entity.Excluir(dto);
        }

        ///<summary>
        /// Atualiza um registro
        /// </summary>		
        public void Alterar(BeneficiarioACSDTO dto)
        {
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Alterar(dto);
		}

        public DataTable ListarCarenciaBeneficiario(string strCodPlano, int? codEst, int? codBen, int? codSeqBen)
        {
            DataTable dtbAgenda = entity.ListarCarenciaBeneficiario(strCodPlano, codEst, codBen, codSeqBen);
            return dtbAgenda;
        }

        public DataTable ListarCarenciaPorCid(string strCodPlano, int? codEst, int? codBen, int? codSeqBen)
        {
            DataTable dtbAgenda = entity.ListarCarenciaPorCid(strCodPlano, codEst, codBen, codSeqBen);
            return dtbAgenda;
        }

        public bool IdentificacaoCronico(BeneficiarioACSDTO dto)
        {
            return entity.IdentificacaoCronico(dto);
        }

        public bool? ValidaRestricaoFinanceira(BeneficiarioACSDTO dto)
        {
            bool? retorno = true;
            string ret = entity.ValidaRestricaoFinanceira(dto);
            // Está assim por definição do plano de saúde

            if (ret == "S")
            {
                retorno = false;
            }
            else
            {
                retorno = false;
            }

            if (ret.Length == 0)
            {
                retorno = null;
            }

            return retorno;
        }
    }
}
