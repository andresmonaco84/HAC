
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class SubGrupoMatMed : Control, ISubGrupoMatMed
	{
		private Model.SubGrupoMatMed entity = new Model.SubGrupoMatMed() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public SubGrupoMatMedDataTable Sel(SubGrupoMatMedDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public SubGrupoMatMedDTO SelChave(SubGrupoMatMedDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public SubGrupoMatMedDTO Ins(SubGrupoMatMedDTO dto)
		{

			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(SubGrupoMatMedDTO dto)
		{
			entity.Del(dto);
		}
		
		///<summary>
		/// Atualiza um registro
		/// </summary>		
		public void Upd(SubGrupoMatMedDTO dto)
		{
		
			entity.Upd(dto);
		}
	}
}
