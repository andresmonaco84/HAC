using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class LocalAtendimento : Control, ILocalAtendimento
	{
		private Model.LocalAtendimento entity = new Model.LocalAtendimento() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public LocalAtendimentoDataTable Sel(LocalAtendimentoDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public LocalAtendimentoDTO SelChave(LocalAtendimentoDTO dto)
		{	
			return entity.SelChave(dto);
		}

        /// <summary>
        /// Obtem Local de atendimento pela Unidade
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public LocalAtendimentoDataTable SelPorUnidade(LocalAtendimentoDTO dto)
        {
            return entity.SelPorUnidade(dto);
        }

		///<summary>
		/// Insere um registro
		/// </summary>
		public LocalAtendimentoDTO Ins(LocalAtendimentoDTO dto)
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
		public void Del(LocalAtendimentoDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(LocalAtendimentoDTO dto)
		{
            //PassportVO passportVO = (PassportVO)Credential;
            //dto.DataUltimaAtualizacao.Value = DateTime.Now;
            //dto.IdtUsuario.Value = passportVO.Usuario.Idt;
		
			entity.Upd(dto);
		}
	}
}
