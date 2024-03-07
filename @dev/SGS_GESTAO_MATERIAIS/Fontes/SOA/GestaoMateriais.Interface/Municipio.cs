using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IMunicipio
	{
		MunicipioDataTable Listar(MunicipioDTO dto);

        MunicipioDTO Incluir(MunicipioDTO dto);

        void Excluir(MunicipioDTO dto);

        void Alterar(MunicipioDTO dto);

        MunicipioDTO Pesquisar(MunicipioDTO dto);
	}
}
