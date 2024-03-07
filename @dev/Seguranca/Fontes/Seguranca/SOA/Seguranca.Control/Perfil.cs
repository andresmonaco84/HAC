
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class Perfil : Control, IPerfil
	{
		private Model.Perfil entity = new Model.Perfil() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public PerfilDataTable Sel(PerfilDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public PerfilDTO SelChave(PerfilDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public PerfilDTO Ins(PerfilDTO dto)
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
		public void Del(PerfilDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(PerfilDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}

        public PerfilDTO Gravar(PerfilDTO dto)
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


        //public PerfilDataTable ObterPorModulo(PerfilDTO dto)
        //{
        //    return entity.ObterPorModulo(dto);
        //}
	}
}
