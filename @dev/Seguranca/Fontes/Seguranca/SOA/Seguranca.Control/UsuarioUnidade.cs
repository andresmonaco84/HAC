
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class UsuarioUnidade : Control, IUsuarioUnidade
	{
		private Model.UsuarioUnidade entity = new Model.UsuarioUnidade() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public UsuarioUnidadeDataTable Sel(UsuarioUnidadeDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public UsuarioUnidadeDTO SelChave(UsuarioUnidadeDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public UsuarioUnidadeDTO Ins(UsuarioUnidadeDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(UsuarioUnidadeDTO dto)
		{
			entity.Del(dto);
		}
	}
}
