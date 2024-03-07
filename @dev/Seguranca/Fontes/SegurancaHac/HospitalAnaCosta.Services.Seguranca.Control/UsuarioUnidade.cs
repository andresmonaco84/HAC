
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class UsuarioUnidade : Control, IUsuarioUnidade
	{
		private Model.UsuarioUnidade entity = new Model.UsuarioUnidade() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public UsuarioUnidadeDataTable Listar(UsuarioUnidadeDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public UsuarioUnidadeDTO Pesquisar(UsuarioUnidadeDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public UsuarioUnidadeDTO Incluir(UsuarioUnidadeDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(UsuarioUnidadeDTO dto)
		{
			entity.Excluir(dto);
		}		
	}
}
