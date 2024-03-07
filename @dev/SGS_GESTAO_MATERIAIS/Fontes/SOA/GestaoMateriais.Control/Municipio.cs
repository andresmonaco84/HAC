
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class Municipio : Control, IMunicipio
	{
		private Model.Municipio entity = new Model.Municipio() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public MunicipioDataTable Listar(MunicipioDTO dto)
		{	
			return entity.Listar(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public MunicipioDTO Pesquisar(MunicipioDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public MunicipioDTO Incluir(MunicipioDTO dto)
		{
			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(MunicipioDTO dto)
		{
			entity.Excluir(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Alterar(MunicipioDTO dto)
		{
			entity.Alterar(dto);
		}
	}
}
