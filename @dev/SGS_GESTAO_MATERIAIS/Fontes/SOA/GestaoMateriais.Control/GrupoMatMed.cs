
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class GrupoMatMed : Control, IGrupoMatMed
	{
		private Model.GrupoMatMed entity = new Model.GrupoMatMed() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public GrupoMatMedDataTable Sel(GrupoMatMedDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
        public GrupoMatMedDTO SelChave(GrupoMatMedDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public GrupoMatMedDTO Ins(GrupoMatMedDTO dto)
		{

			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(GrupoMatMedDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(GrupoMatMedDTO dto)
		{
			entity.Upd(dto);
		}
	}
}
