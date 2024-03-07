
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class UnidadeLocalSetorUsuario : Control, IUnidadeLocalSetorUsuario
	{
		private Model.UnidadeLocalSetorUsuario entity = new Model.UnidadeLocalSetorUsuario() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public UnidadeLocalSetorUsuarioDataTable Sel(UnidadeLocalSetorUsuarioDTO dto)
        {
            return entity.Sel(dto);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public UnidadeLocalSetorUsuarioDTO SelChave(UnidadeLocalSetorUsuarioDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public UnidadeLocalSetorUsuarioDTO Ins(UnidadeLocalSetorUsuarioDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(UnidadeLocalSetorUsuarioDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(UnidadeLocalSetorUsuarioDTO dto)
		{
			entity.Upd(dto);
		}

        public UnidadeLocalSetorUsuarioDataTable UsuarioPorSetor(UnidadeLocalSetorUsuarioDTO dto)
        {
            return entity.UsuarioPorSetor(dto);
        }

        public UnidadeLocalSetorUsuarioDataTable AssociarSetorUsuario(UnidadeLocalSetorUsuarioDTO dto)
        {
            return entity.AssociarSetorUsuario(dto);
        }

        public System.Data.DataTable ObterAcessoUsuarioSetor(UnidadeLocalSetorUsuarioDTO dto)
        {
            return entity.ObterAcessoUsuarioSetor(dto);
        }
	}
}
