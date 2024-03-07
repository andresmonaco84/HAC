
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.Seguranca.DTO;
using HospitalAnaCosta.Services.Seguranca.Interface;

namespace HospitalAnaCosta.Services.Seguranca.Control
{
	public class PermissaoUsuario : Control, IPermissaoUsuario
	{
		private Model.PermissaoUsuario entity = new Model.PermissaoUsuario() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public PermissaoUsuarioDataTable Listar(PermissaoUsuarioDTO dto)
		{	
			return entity.Listar(dto);
		}

		/// <summary>
		/// Obter pela chave
		/// </summary>
		public PermissaoUsuarioDTO Pesquisar(PermissaoUsuarioDTO dto)
		{	
			return entity.Pesquisar(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public PermissaoUsuarioDTO Incluir(PermissaoUsuarioDTO dto)
		{
			//PassportVO passportVO = (PassportVO)Credential;
			//dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Incluir(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Excluir(PermissaoUsuarioDTO dto)
		{
			entity.Excluir(dto);
		}
		
	}
}
