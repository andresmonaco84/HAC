using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
	public partial class HistoricoNFEstorno : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public HistoricoNFEstornoDataTable Listar(HistoricoNFEstornoDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

			//Parametro pCAD_MTMD_ID_ACERTO
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID_ACERTO", dto.IdtProdutoAcerto.DBValue, ParameterDirection.Input, dto.IdtProdutoAcerto.DbType));

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

			//Parametro pMTMD_NR_NOTA
			param.Add(Connection.CreateParameter("pMTMD_NR_NOTA", dto.NrNota.DBValue, ParameterDirection.Input, dto.NrNota.DbType));

			//Parametro pIDMOV
			param.Add(Connection.CreateParameter("pIDMOV", dto.IdMovRM.DBValue, ParameterDirection.Input, dto.IdMovRM.DbType));

			//Parametro pMTMD_QTDE
			param.Add(Connection.CreateParameter("pMTMD_QTDE", dto.QtdeEstorno.DBValue, ParameterDirection.Input, dto.QtdeEstorno.DbType));

			//Parametro pDS_FORNECEDOR
			param.Add(Connection.CreateParameter("pDS_FORNECEDOR", dto.DsFornecedor.DBValue, ParameterDirection.Input, dto.DsFornecedor.DbType));

			//Parametro pTP_MOVIMENTO
			param.Add(Connection.CreateParameter("pTP_MOVIMENTO", dto.TpMov.DBValue, ParameterDirection.Input, dto.TpMov.DbType));

			//Parametro pNF_MOTIVO_ESTORNO
			param.Add(Connection.CreateParameter("pNF_MOTIVO_ESTORNO", dto.Motivo.DBValue, ParameterDirection.Input, dto.Motivo.DbType));

			//Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.IdMovSGS.DBValue, ParameterDirection.Input, dto.IdMovSGS.DbType));

			//Parametro pMTMD_MOV_DATA
			param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.UsuarioAtualizacao.DBValue, ParameterDirection.Input, dto.UsuarioAtualizacao.DbType));

            //Parametro pSTATUS
            param.Add(Connection.CreateParameter("pSTATUS", dto.StatusEstorno.DBValue, ParameterDirection.Input, dto.StatusEstorno.DbType));
            
			#endregion	
			
			HistoricoNFEstornoDataTable result = new HistoricoNFEstornoDataTable();
			string query = "PRC_MTMD_HISTORICO_NF_ESTOR_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}		
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(HistoricoNFEstornoDTO dto, int? qtdDevolucaoParcial, decimal? precoUnitario)
		{			
			string query = "PRC_MTMD_HISTORICO_NF_ESTOR_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_MTMD_ID_ACERTO
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID_ACERTO", dto.IdtProdutoAcerto.DBValue, ParameterDirection.Input, dto.IdtProdutoAcerto.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			//Parametro pMTMD_NR_NOTA
			param.Add(Connection.CreateParameter("pMTMD_NR_NOTA", dto.NrNota.DBValue, ParameterDirection.Input, dto.NrNota.DbType));
			
			//Parametro pIDMOV
			param.Add(Connection.CreateParameter("pIDMOV", dto.IdMovRM.DBValue, ParameterDirection.Input, dto.IdMovRM.DbType));
			
			//Parametro pMTMD_QTDE
			param.Add(Connection.CreateParameter("pMTMD_QTDE", dto.QtdeEstorno.DBValue, ParameterDirection.Input, dto.QtdeEstorno.DbType));
			
			//Parametro pDS_FORNECEDOR
			param.Add(Connection.CreateParameter("pDS_FORNECEDOR", dto.DsFornecedor.DBValue, ParameterDirection.Input, dto.DsFornecedor.DbType));
			
			//Parametro pTP_MOVIMENTO
			param.Add(Connection.CreateParameter("pTP_MOVIMENTO", dto.TpMov.DBValue, ParameterDirection.Input, dto.TpMov.DbType));
			
			//Parametro pNF_MOTIVO_ESTORNO
			param.Add(Connection.CreateParameter("pNF_MOTIVO_ESTORNO", dto.Motivo.DBValue, ParameterDirection.Input, dto.Motivo.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.UsuarioAtualizacao.DBValue, ParameterDirection.Input, dto.UsuarioAtualizacao.DbType));

            //Parametro pSTATUS
            param.Add(Connection.CreateParameter("pSTATUS", dto.StatusEstorno.DBValue, ParameterDirection.Input, dto.StatusEstorno.DbType));

            //Parametro pPRECO_UNITARIO
            if (precoUnitario != null)
                param.Add(Connection.CreateParameter("pPRECO_UNITARIO", precoUnitario.Value, ParameterDirection.Input, DbType.Decimal));

            //Parametro pQTD_DEVOLUCAO_PARCIAL
            if (qtdDevolucaoParcial != null)
                param.Add(Connection.CreateParameter("pQTD_DEVOLUCAO_PARCIAL", qtdDevolucaoParcial.Value, ParameterDirection.Input,DbType.Int32));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}	
	}
}