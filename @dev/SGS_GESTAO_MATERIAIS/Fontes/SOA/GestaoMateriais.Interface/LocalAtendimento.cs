using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface ILocalAtendimento
	{
		LocalAtendimentoDataTable Sel(LocalAtendimentoDTO dto);

		LocalAtendimentoDTO Ins(LocalAtendimentoDTO dto);

		void Del(LocalAtendimentoDTO dto);
		
		void Upd(LocalAtendimentoDTO dto);
		
		LocalAtendimentoDTO SelChave(LocalAtendimentoDTO dto);

        LocalAtendimentoDataTable SelPorUnidade(LocalAtendimentoDTO dto);
	}
}
