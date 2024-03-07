
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
    public interface ILocalEstoque
	{
        LocalEstoqueDataTable Sel(LocalEstoqueDTO dto);

		LocalEstoqueDTO Ins(LocalEstoqueDTO dto);

		void Del(LocalEstoqueDTO dto);
		
		void Upd(LocalEstoqueDTO dto);
		
		LocalEstoqueDTO SelChave(LocalEstoqueDTO dto);

        void Gravar(LocalEstoqueDTO dto);

        LocalEstoqueDataTable EstoqueUsuario(LocalEstoqueDTO dto);

	}
}
