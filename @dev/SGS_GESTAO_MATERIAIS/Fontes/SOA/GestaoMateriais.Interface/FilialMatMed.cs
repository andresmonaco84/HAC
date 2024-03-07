using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
// using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IFilialMatMed
	{
		FilialMatMedDataTable Sel(FilialMatMedDTO dto);

		FilialMatMedDTO Ins(FilialMatMedDTO dto);

		void Del(FilialMatMedDTO dto);
		
		void Upd(FilialMatMedDTO dto);
		
		FilialMatMedDTO SelChave(FilialMatMedDTO dto);

        FilialMatMedDTO.Filial ObterFilialAtendimento(FilialMatMedDTO dtoIntern);

        System.Data.DataTable ObterDadosFilialRM(decimal idFilial);

        System.Data.DataTable ObterEmpresaEmprestimo(decimal? idEmpresa);

        System.Data.DataTable InserirEmpresaEmprestimo(string descricaoEmpresa, string cnpjEmpresa);
	}
}