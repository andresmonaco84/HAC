
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class TipoFracao : Control, ITipoFracao
	{
		private Model.TipoFracao entity = new Model.TipoFracao() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public TipoFracaoDataTable Sel(TipoFracaoDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public TipoFracaoDTO SelChave(TipoFracaoDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public TipoFracaoDTO Ins(TipoFracaoDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(TipoFracaoDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(TipoFracaoDTO dto)
		{	
			entity.Upd(dto);
		}


        public TipoFracaoDTO ConverteFracao(TipoFracaoDTO dto)
        {
            return entity.ConverteFracao(dto);
        }
    }
}
