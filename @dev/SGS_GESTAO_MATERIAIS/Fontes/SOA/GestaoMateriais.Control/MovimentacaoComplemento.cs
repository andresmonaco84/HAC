
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class MovimentacaoComplemento : Control, IMovimentacaoComplemento
	{
		private Model.MovimentacaoComplemento entity = new Model.MovimentacaoComplemento() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public MovimentacaoComplementoDataTable Sel(MovimentacaoComplementoDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public MovimentacaoComplementoDTO SelChave(MovimentacaoComplementoDTO dto)
		{	
			return entity.SelChave(dto);
		}

        /// <summary>
        /// Registra Divergencia
        /// </summary>
        /// <param name="dto"></param>
        public void RegistrarDivergencia(MovimentacaoComplementoDTO dto, MovimentacaoDTO dtoMov)
        {
            entity.RegistrarDivergencia(dto, dtoMov);
        }
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public MovimentacaoComplementoDTO Ins(MovimentacaoComplementoDTO dto)
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
		public void Del(MovimentacaoComplementoDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(MovimentacaoComplementoDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}
	}
}
