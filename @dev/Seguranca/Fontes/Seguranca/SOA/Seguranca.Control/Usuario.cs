
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using System.Data;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class Usuario : Control, IUsuario
	{
		private Model.Usuario entity = new Model.Usuario() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public UsuarioDataTable Sel(UsuarioDTO dto)
		{	
			return entity.Sel(dto);
		}

        public DataTable buscaPorNome(UsuarioDTO dto)
        {
            return entity.buscaPorNome(dto);
        }

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public UsuarioDTO SelChave(UsuarioDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public UsuarioDTO Ins(UsuarioDTO dto)
		{
            entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(UsuarioDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(UsuarioDTO dto)
		{            
			entity.Upd(dto);
		}

        ///<summary>
        /// Coloca senha padrão para o usuário
        /// </summary>		
        public void AtribuirSenhaPadrao(UsuarioDTO dto)
        {
            entity.AtribuirSenhaPadrao(dto);
        }

        public UsuarioDTO Gravar(UsuarioDTO dto)
        {
            if (dto.Idt.Value.IsNull)
            {
                entity.Ins(dto);
            }
            else
            {
                entity.Upd(dto);
            }

            return dto;
        }

        public string GeraToken(string usuario, bool recuperar, bool alterar)
        {
            Random r = new Random();
            int token = r.Next(1, int.MaxValue);
            string acao = recuperar ? "RECUPERAR" : alterar ? "ALTERAR" : string.Empty;
            string result = string.Empty;
            try
            {
                result = entity.GeraToken(usuario + token.ToString(), acao);
            }
            catch (Exception)
            {
                r = new Random();
                token = r.Next(1, int.MaxValue);
                result = entity.GeraToken(usuario + token.ToString(), acao);
            }
            return result;
        }
	}
}
