
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.Seguranca.Control
{
	public class Sistema : Control, ISistema
	{
		private Model.Sistema entity = new Model.Sistema() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public SistemaDataTable Sel(SistemaDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public SistemaDTO SelChave(SistemaDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public SistemaDTO Ins(SistemaDTO dto)
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
		public void Del(SistemaDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(SistemaDTO dto)
		{
            //PassportDTO passportVO = (PassportDTO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}
	}
}
