using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Control
{
	public class HistoricoNFEstorno : Control, IHistoricoNFEstorno
	{
		private Model.HistoricoNFEstorno entity = new Model.HistoricoNFEstorno() ;

		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public HistoricoNFEstornoDataTable Listar(HistoricoNFEstornoDTO dto)
		{	
			return entity.Listar(dto);
		}        		
		
		///<summary>
		/// Insere um registro
		/// </summary>
        public HistoricoNFEstornoDTO Incluir(HistoricoNFEstornoDTO dto, int? qtdDevolucaoParcial, decimal? precoUnitario)
		{
            entity.Incluir(dto, qtdDevolucaoParcial, precoUnitario);
			return dto;
		}		
	}
}