using System.Data;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Interface
{
	public interface IBeneficiarioACS
	{
		BeneficiarioACSDataTable Listar(BeneficiarioACSDTO dto);

        /// <summary>
        /// Listar todos os registros
        /// Parametro situacao = "I", "A" ou NULL.
        /// </summary>
        BeneficiarioACSDataTable Listar(BeneficiarioACSDTO dto, string situacao, bool incluirHomeCare, bool existeHomeCare);        

		BeneficiarioACSDTO Incluir(BeneficiarioACSDTO dto);

		void Excluir(BeneficiarioACSDTO dto);
		
		void Alterar(BeneficiarioACSDTO dto);
		
		BeneficiarioACSDTO Pesquisar(BeneficiarioACSDTO dto);

	    DataTable ListarCarenciaBeneficiario(string strCodPlano, int? codEst, int? codBen, int? codSeqBen);

	    DataTable ListarCarenciaPorCid(string strCodPlano, int? codEst, int? codBen, int? codSeqBen);

        bool IdentificacaoCronico(BeneficiarioACSDTO dto);

        bool? ValidaRestricaoFinanceira(BeneficiarioACSDTO dto);
	}
}
