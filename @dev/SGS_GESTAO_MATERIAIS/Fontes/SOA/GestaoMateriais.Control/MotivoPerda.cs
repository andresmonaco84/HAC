
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class MotivoPerda : Control, IMotivoPerda
	{
		private Model.MotivoPerda entity = new Model.MotivoPerda();

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public MotivoPerdaDataTable Sel(MotivoPerdaDTO dto, string flTipoDevolucao)
		{
            return entity.Sel(dto, flTipoDevolucao);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public MotivoPerdaDTO SelChave(MotivoPerdaDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public MotivoPerdaDTO Ins(MotivoPerdaDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;

			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(MotivoPerdaDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(MotivoPerdaDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}
	}
}
