
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class AssPerfilUsuario : Control, IAssPerfilUsuario
	{
		private Model.AssPerfilUsuario entity = new Model.AssPerfilUsuario() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public AssPerfilUsuarioDataTable Sel(AssPerfilUsuarioDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public AssPerfilUsuarioDTO SelChave(AssPerfilUsuarioDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public AssPerfilUsuarioDTO Ins(AssPerfilUsuarioDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(AssPerfilUsuarioDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(AssPerfilUsuarioDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}
	}
}
