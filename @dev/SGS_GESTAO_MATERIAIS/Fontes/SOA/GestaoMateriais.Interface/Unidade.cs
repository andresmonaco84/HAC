using System.Data;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IUnidade
	{
		DataTable Sel(UnidadeDTO dto);

		UnidadeDTO Ins(UnidadeDTO dto);

		void Del(UnidadeDTO dto);
		
		void Upd(UnidadeDTO dto);
		
		UnidadeDTO SelChave(UnidadeDTO dto);

        UnidadeDataTable ListarUnidadeDoLocal(UnidadeDTO dto, int? idtLocal);

        UnidadeDataTable ListarUnidadesMaster();
	}
}
