
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class MatMedFuncionalidade : Control, IMatMedFuncionalidade
	{
		private Model.MatMedFuncionalidade entity = new Model.MatMedFuncionalidade() ;

        /// <summary>
        /// Listar todos os registros
        /// </summary>
		public MatMedFuncionalidadeDataTable Sel(MatMedFuncionalidadeDTO dto)
		{	
			return entity.Sel(dto);
		}

        /// <summary>
        /// Obter pela chave
        /// </summary>
		public MatMedFuncionalidadeDTO SelChave(MatMedFuncionalidadeDTO dto)
		{	
			return entity.SelChave(dto);
		}
		
		///<summary>
		/// Insere um registro
		/// </summary>
		public MatMedFuncionalidadeDTO Ins(MatMedFuncionalidadeDTO dto)
		{
			entity.Ins(dto);
			return dto;
		}

		///<summary>
		/// Apaga um registro
		/// </summary>		
		public void Del(MatMedFuncionalidadeDTO dto)
		{
			entity.Del(dto);
		}

        public void Atualizar(MatMedFuncionalidadeDTO dto)
        {
            entity.Atualizar(dto);
        }
	}
}