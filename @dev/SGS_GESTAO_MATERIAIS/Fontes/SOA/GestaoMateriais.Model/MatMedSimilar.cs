using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class MatMedSimilar : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public MatMedSimilarDataTable Sel(MatMedSimilarDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdPrincipioAtivo.DbType));

			//Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));

			//Parametro pCAD_FL_ATIVO
			param.Add(Connection.CreateParameter("pCAD_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

			//Parametro pCAD_MTMD_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));
			#endregion	
			
			MatMedSimilarDataTable result = new MatMedSimilarDataTable();
			string query = "PRC_CAD_MTMD_SIMILAR_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public MatMedSimilarDataTable ListarSimilares(MatMedSimilarDTO dto, MaterialMedicamentoDTO dtoMatMed)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_PRIATI_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdPrincipioAtivo.DbType));

            //Parametro pCAD_FL_ATIVO
            param.Add(Connection.CreateParameter("pCAD_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

            if (dtoMatMed != null)
            {
                //Parametro pCAD_MTMD_GRUPO_ID
                param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dtoMatMed.IdtGrupo.DBValue, ParameterDirection.Input, dtoMatMed.IdtGrupo.DbType));

                //Parametro pCAD_MTMD_SUBGRUPO_ID
                param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dtoMatMed.IdtSubGrupo.DBValue, ParameterDirection.Input, dtoMatMed.IdtSubGrupo.DbType));
            }
            #endregion

            MatMedSimilarDataTable result = new MatMedSimilarDataTable();
            string query = "PRC_CAD_MTMD_SIMILAR_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }
		
		/// <summary>
        /// Exclui o registro
        /// </summary>      
		public void Del(MatMedSimilarDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_PRIATI_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdPrincipioAtivo.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));

            //Parametro pCAD_FL_ATIVO
            //param.Add(Connection.CreateParameter("pCAD_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

            //Parametro pCAD_MTMD_DT_ATUALIZACAO
            //param.Add(Connection.CreateParameter("pCAD_MTMD_DT_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));
		
   	        #endregion				
			//Executa o procedimento
            
			string query = "PRC_CAD_MTMD_SIMILAR_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}		
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
        public MatMedSimilarDTO Ins(MatMedSimilarDTO dto)
		{			
			string query = "PRC_CAD_MTMD_SIMILAR_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();				
			
			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdPrincipioAtivo.DBValue, ParameterDirection.InputOutput, dto.IdPrincipioAtivo.DbType));
			
			//Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));
			
			//Parametro pCAD_FL_ATIVO
			param.Add(Connection.CreateParameter("pCAD_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));					
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.IdPrincipioAtivo.Value = Int32.Parse(param["pCAD_MTMD_PRIATI_ID"].Value.ToString());
            return dto;
		}

        public void AtualizarEstoqueOnlineSimilares(MatMedSimilarDTO dto)
        {
            if (dto != null && !dto.IdPrincipioAtivo.Value.IsNull && dto.IdPrincipioAtivo.Value.ToString() != "0")
            {
                string queryExec = "DECLARE\n" +
                "PERC NUMBER;\n" +
                "BEGIN\n" +
                "FOR X IN (SELECT L.CAD_SET_ID,\n" +
                "                 L.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                "                 L.CAD_UNI_ID_UNIDADE,\n" +
                "                 L.CAD_MTMD_FILIAL_ID,\n" +
                "                 L.CAD_MTMD_ID,\n" +
                "                 M.CAD_MTMD_PRIATI_ID,\n" +
                "                 L.MTMD_PEDPAD_QTDE,\n" +
                "                 L.MTMD_ID_ORIGINAL,\n" +
                "                 (SELECT MM.CAD_MTMD_ID\n" +
                "                    FROM\n" +
                "                    TB_MTMD_ESTOQUE_LOCAL LL JOIN\n" +
                "                    TB_CAD_MTMD_MAT_MED MM ON MM.CAD_MTMD_ID = LL.CAD_MTMD_ID\n" +
                "                    WHERE CAD_SET_ID = L.CAD_SET_ID AND LL.CAD_MTMD_FILIAL_ID = L.CAD_MTMD_FILIAL_ID AND\n" +
                "                          MM.CAD_MTMD_PRIATI_ID != 0 AND MM.CAD_MTMD_GRUPO_ID IN (1,6) AND\n" +
                "                          LL.MTMD_PEDPAD_QTDE > 0 AND MM.CAD_MTMD_PRIATI_ID = M.CAD_MTMD_PRIATI_ID AND ROWNUM = 1) ORIGINAL\n" +
                "          FROM TB_MTMD_ESTOQUE_LOCAL L JOIN\n" +
                "               TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = L.CAD_MTMD_ID\n" +
                "          WHERE M.CAD_MTMD_PRIATI_ID = " + dto.IdPrincipioAtivo.Value + " AND\n" +
                "                M.CAD_MTMD_GRUPO_ID IN (1,6) AND\n" +
                "                L.MTMD_PEDPAD_QTDE IS NULL AND\n" +
                "                (\n" +
                "                  SELECT MM.CAD_MTMD_ID\n" +
                "                    FROM\n" +
                "                    TB_MTMD_ESTOQUE_LOCAL LL JOIN\n" +
                "                    TB_CAD_MTMD_MAT_MED MM ON MM.CAD_MTMD_ID = LL.CAD_MTMD_ID\n" +
                "                    WHERE CAD_SET_ID = L.CAD_SET_ID AND LL.CAD_MTMD_FILIAL_ID = L.CAD_MTMD_FILIAL_ID AND\n" +
                "                          MM.CAD_MTMD_PRIATI_ID != 0 AND MM.CAD_MTMD_GRUPO_ID IN (1,6) AND\n" +
                "                          LL.MTMD_PEDPAD_QTDE > 0 AND MM.CAD_MTMD_PRIATI_ID = M.CAD_MTMD_PRIATI_ID AND ROWNUM = 1\n" +
                "                 ) IS NOT NULL AND\n" +
                "                (L.MTMD_ID_ORIGINAL IS NULL OR\n" +
                "                L.MTMD_ID_ORIGINAL != (\n" +
                "                                        SELECT MM.CAD_MTMD_ID\n" +
                "                                          FROM\n" +
                "                                          TB_MTMD_ESTOQUE_LOCAL LL JOIN\n" +
                "                                          TB_CAD_MTMD_MAT_MED MM ON MM.CAD_MTMD_ID = LL.CAD_MTMD_ID\n" +
                "                                          WHERE CAD_SET_ID = L.CAD_SET_ID AND LL.CAD_MTMD_FILIAL_ID = L.CAD_MTMD_FILIAL_ID AND\n" +
                "                                                MM.CAD_MTMD_PRIATI_ID != 0 AND MM.CAD_MTMD_GRUPO_ID IN (1,6) AND\n" +
                "                                                LL.MTMD_PEDPAD_QTDE > 0 AND MM.CAD_MTMD_PRIATI_ID = M.CAD_MTMD_PRIATI_ID AND ROWNUM = 1\n" +
                "                                       ))\n" +
                "          ) LOOP\n" +
                "                UPDATE TB_MTMD_ESTOQUE_LOCAL\n" +
                "                   SET MTMD_ID_ORIGINAL = X.ORIGINAL\n" +
                "                 WHERE CAD_SET_ID = X.CAD_SET_ID AND CAD_MTMD_FILIAL_ID = X.CAD_MTMD_FILIAL_ID AND\n" +
                "                       CAD_MTMD_ID = X.CAD_MTMD_ID;\n" +
                "\n" +
                "                PRC_MTMD_ESTOQUE_PER_CONSUMO_U(X.CAD_MTMD_ID,\n" +
                "                                                X.CAD_MTMD_FILIAL_ID,\n" +
                "                                                X.CAD_UNI_ID_UNIDADE,\n" +
                "                                                X.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                "                                                X.CAD_SET_ID,\n" +
                "                                                PERC);\n" +
                "          END LOOP;\n" +
                "END;";

                Connection.ExecuteCommand(queryExec);
            }
        }

        public DataTable ValidarSetoresComSimilaresDuplicados(string strItensIDs)
        {
            string sqlString = "SELECT DISTINCT\n" +
                                    "UNI.CAD_UNI_DS_RESUMIDA || ' / ' || SETOR.CAD_SET_CD_SETOR || ' / ' || DECODE(P.CAD_MTMD_FILIAL_ID,2,'ACS',DECODE(P.CAD_MTMD_FILIAL_ID,1,'HAC','CE')) SETOR_SIMILAR_DUPLICADO\n" +
                                    "FROM\n" +
                                    "TB_MTMD_PEDIDO_PADRAO_ITENS PI JOIN\n" +
                                    "TB_MTMD_PEDIDO_PADRAO P ON P.MTMD_PEDPAD_ID = PI.MTMD_PEDPAD_ID JOIN\n" +
                                    "TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = PI.CAD_MTMD_ID JOIN\n" +
                                    "TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = P.CAD_SET_ID JOIN\n" +
                                    "TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE\n" +
                                    "WHERE PI.CAD_MTMD_ID IN (" + strItensIDs + ")\n" +
                                    "AND (SELECT COUNT(PI2.CAD_MTMD_ID)\n" +
                                    "      FROM SGS.TB_MTMD_PEDIDO_PADRAO_ITENS PI2 JOIN\n" +
                                    "            TB_MTMD_PEDIDO_PADRAO P2 ON P2.MTMD_PEDPAD_ID = PI2.MTMD_PEDPAD_ID JOIN\n" +
                                    "            TB_CAD_MTMD_MAT_MED M2 ON M2.CAD_MTMD_ID = PI2.CAD_MTMD_ID\n" +
                                    "      WHERE P2.CAD_SET_ID = P.CAD_SET_ID\n" +
                                    "      AND P2.CAD_MTMD_FILIAL_ID = P.CAD_MTMD_FILIAL_ID\n" +
                                    "      AND PI2.CAD_MTMD_ID IN (" + strItensIDs + ")) > 1\n" +
                                    "ORDER BY UNI.CAD_UNI_DS_RESUMIDA || ' / ' || SETOR.CAD_SET_CD_SETOR || ' / ' || DECODE(P.CAD_MTMD_FILIAL_ID,2,'ACS',DECODE(P.CAD_MTMD_FILIAL_ID,1,'HAC','CE'))";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }
	}
}