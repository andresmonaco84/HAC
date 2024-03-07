using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
	public partial class InventarioMatMed : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public InventarioMatMedDataTable Listar(InventarioMatMedDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdFilial.DBValue, ParameterDirection.Input, dto.IdFilial.DbType));

			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));

			//Parametro pCAD_MTMD_DT_INVENTARIO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INVENTARIO", dto.DataInventario.DBValue, ParameterDirection.Input, dto.DataInventario.DbType));

			//Parametro pCAD_MTMD_QTDE_1
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_1", dto.Qtde1.DBValue, ParameterDirection.Input, dto.Qtde1.DbType));

			//Parametro pCAD_MTMD_QTDE_2
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_2", dto.Qtde2.DBValue, ParameterDirection.Input, dto.Qtde2.DbType));

			//Parametro pCAD_MTMD_QTDE_3
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_3", dto.Qtde3.DBValue, ParameterDirection.Input, dto.Qtde3.DbType));

			//Parametro pCAD_MTMD_QTDE_FINAL
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_FINAL", dto.QtdeFinal.DBValue, ParameterDirection.Input, dto.QtdeFinal.DbType));

			//Parametro pCAD_MTMD_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));

            //Parametro pMTMD_COD_LOTE
            param.Add(Connection.CreateParameter("pMTMD_COD_LOTE", dto.CodLote.DBValue, ParameterDirection.Input, dto.CodLote.DbType));

            //Parametro pMTMD_NUM_LOTE
            param.Add(Connection.CreateParameter("pMTMD_NUM_LOTE", dto.NumLoteFab.DBValue, ParameterDirection.Input, dto.NumLoteFab.DbType));

            //Parametro pFL_MEDICAMENTO
            param.Add(Connection.CreateParameter("pFL_MEDICAMENTO", dto.FlMedicamento.DBValue, ParameterDirection.Input, dto.FlMedicamento.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            if (!dto.IdtGrupo.Value.IsNull && dto.IdtGrupo.Value > 0) //Parametro pCAD_MTMD_GRUPO_ID
                param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			#endregion	
			
			InventarioMatMedDataTable result = new InventarioMatMedDataTable();
			string query = "PRC_CAD_MTMD_INVENTARIO_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

        /// <summary>
        /// Listar o andamento/fechamento do inventário
        /// </summary>
        public InventarioMatMedDataTable ListarControle(InventarioMatMedDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
            
            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdFilial.DBValue, ParameterDirection.Input, dto.IdFilial.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));

            //Parametro pCAD_MTMD_DT_INVENTARIO
            param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INVENTARIO", dto.DataInventario.DBValue, ParameterDirection.Input, dto.DataInventario.DbType));

            //Parametro pCAD_MTMD_ANDAMENTO
            param.Add(Connection.CreateParameter("pCAD_MTMD_ANDAMENTO", dto.FlAndamento.DBValue, ParameterDirection.Input, dto.FlAndamento.DbType));

            //Parametro pFL_MEDICAMENTO
            param.Add(Connection.CreateParameter("pFL_MEDICAMENTO", dto.FlMedicamento.DBValue, ParameterDirection.Input, dto.FlMedicamento.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
            #endregion

            InventarioMatMedDataTable result = new InventarioMatMedDataTable();
            string query = "PRC_CAD_MTMD_INVENT_FECHA_L";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }        		
		
		/// <summary>
		/// Exclui o registro
		/// </summary>        
		public void Excluir(InventarioMatMedDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_DT_INVENTARIO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INVENTARIO", dto.DataInventario.DBValue, ParameterDirection.Input, dto.DataInventario.DbType));
			
			// Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdFilial.DBValue, ParameterDirection.Input, dto.IdFilial.DbType));
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));
			
			// Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));

            //Parametro pMTMD_COD_LOTE
            param.Add(Connection.CreateParameter("pMTMD_COD_LOTE", dto.CodLote.DBValue, ParameterDirection.Input, dto.CodLote.DbType));
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_CAD_MTMD_INVENTARIO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}		
				
		/// <summary>
		/// Grava o registro
		/// </summary>			
		public void Gravar(InventarioMatMedDTO dto, string codBarraImport, int? qtdeImport)
		{
            string query = "PRC_CAD_MTMD_INVENTARIO_G";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();				
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdProduto.DBValue, ParameterDirection.Input, dto.IdProduto.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdFilial.DBValue, ParameterDirection.Input, dto.IdFilial.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));
			
			//Parametro pCAD_MTMD_DT_INVENTARIO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INVENTARIO", dto.DataInventario.DBValue, ParameterDirection.Input, dto.DataInventario.DbType));
			
			//Parametro pCAD_MTMD_QTDE_1
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_1", dto.Qtde1.DBValue, ParameterDirection.Input, dto.Qtde1.DbType));
			
			//Parametro pCAD_MTMD_QTDE_2
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_2", dto.Qtde2.DBValue, ParameterDirection.Input, dto.Qtde2.DbType));
			
			//Parametro pCAD_MTMD_QTDE_3
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_3", dto.Qtde3.DBValue, ParameterDirection.Input, dto.Qtde3.DbType));
			
			//Parametro pCAD_MTMD_QTDE_FINAL
			param.Add(Connection.CreateParameter("pCAD_MTMD_QTDE_FINAL", dto.QtdeFinal.DBValue, ParameterDirection.Input, dto.QtdeFinal.DbType));
						
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));

            //Parametro pMTMD_COD_LOTE
            param.Add(Connection.CreateParameter("pMTMD_COD_LOTE", dto.CodLote.DBValue, ParameterDirection.Input, dto.CodLote.DbType));

            //Parametro pMTMD_NUM_LOTE
            param.Add(Connection.CreateParameter("pMTMD_NUM_LOTE", dto.NumLoteFab.DBValue, ParameterDirection.Input, dto.NumLoteFab.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
            
            if (qtdeImport != null)
            {
                //Parametro pLOG_QTDE_IMPORT
                param.Add(Connection.CreateParameter("pLOG_QTDE_IMPORT", qtdeImport.Value, ParameterDirection.Input, dto.QtdeFinal.DbType));

                //Parametro pLOG_DATA_INI_IMPORT
                if (!dto.DtAtualizacao.Value.IsNull) param.Add(Connection.CreateParameter("pLOG_DATA_INI_IMPORT", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

                //Parametro pLOG_CD_BARRA_IMPORT
                if (!string.IsNullOrEmpty(codBarraImport)) param.Add(Connection.CreateParameter("pLOG_CD_BARRA_IMPORT", codBarraImport, ParameterDirection.Input, new CodigoBarraDTO().CdBarra.DbType));

                //Parametro pCAD_MTMD_FECHAMENTO
                param.Add(Connection.CreateParameter("pCAD_MTMD_FECHAMENTO", dto.Fechamento.DBValue, ParameterDirection.Input, dto.Fechamento.DbType));
            }
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);				
		}

        /// <summary>
        /// Ativar o inventário
        /// </summary>			
        public void AtivarInventario(InventarioMatMedDTO dto, bool apenasMateriaisEmGeral)
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            string query = "PRC_CAD_MTMD_INVENTARIO_ATIVAR";
            if (dto.IdtGrupo.Value.IsNull) dto.IdtGrupo.Value = 0;
            if ((decimal)dto.IdtGrupo.Value != 0)
            {
                query = "PRC_CAD_MTMD_INV_ATIVAR_GRUPO";
                param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
            }
            //else
            //    param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", 0, ParameterDirection.Input, dto.IdtGrupo.DbType));

            #region "Parametros"            

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdFilial.DBValue, ParameterDirection.Input, dto.IdFilial.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));

            //Parametro pCAD_MTMD_DT_INVENTARIO
            param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INVENTARIO", dto.DataInventario.DBValue, ParameterDirection.Input, dto.DataInventario.DbType));

            //Parametro pCAD_MTMD_ANDAMENTO
            param.Add(Connection.CreateParameter("pCAD_MTMD_ANDAMENTO", dto.FlAndamento.DBValue, ParameterDirection.Input, dto.FlAndamento.DbType));
                        
            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));

            if (apenasMateriaisEmGeral)
                param.Add(Connection.CreateParameter("pAPENAS_MATERIAIS", 1, ParameterDirection.Input, DbType.Decimal));

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Fechar o inventário
        /// </summary>			
        public void FecharInventario(InventarioMatMedDTO dto)
        {
            string query = "PRC_CAD_MTMD_INVENTARIO_FECHAR";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdFilial.DBValue, ParameterDirection.Input, dto.IdFilial.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdSetor.DBValue, ParameterDirection.Input, dto.IdSetor.DbType));

            //Parametro pCAD_MTMD_DT_INVENTARIO
            param.Add(Connection.CreateParameter("pCAD_MTMD_DT_INVENTARIO", dto.DataInventario.DBValue, ParameterDirection.Input, dto.DataInventario.DbType));
            
            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdUsuario.DBValue, ParameterDirection.Input, dto.IdUsuario.DbType));

            //Parametro pFL_MEDICAMENTO
            param.Add(Connection.CreateParameter("pFL_MEDICAMENTO", dto.FlMedicamento.DBValue, ParameterDirection.Input, dto.FlMedicamento.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        public void ExcluirItemLogImportacaoPalmTXT(InventarioMatMedDTO dto, string codBarraImport, int? qtdeImport)
        {
            string queryExec = "UPDATE TB_CAD_MTMD_INVENT_LOG_IMPORT SET " +
                                   "   FL_EXCLUIDO = 1, INV_LOG_DATA_EXCLUSAO = SYSDATE, LOG_ID_USUARIO_EXCLUSAO = " + dto.IdUsuario.Value +
                               "\nWHERE FL_EXCLUIDO = 0 AND\n" +
                                     " CAD_MTMD_FECHAMENTO = " + dto.Fechamento.Value.ToString() + " AND\n" +
                                     " CAD_MTMD_FILIAL_ID = " + dto.IdFilial.Value.ToString() + " AND\n" +
                                     " CAD_SET_ID = " + dto.IdSetor.Value.ToString() + " AND\n" +
                                     " CAD_MTMD_ID = " + dto.IdProduto.Value.ToString() + " AND\n" +
                                     " MTMD_COD_LOTE = " + dto.CodLote.Value.ToString() + " AND\n" +
                                     " INV_LOG_CD_BARRA = '" + codBarraImport + "' AND\n" +
                                     " CAD_MTMD_QTDE = " + qtdeImport.Value.ToString() + " AND\n" +
                                     " INV_LOG_DATA_REGISTRO = TO_DATE('" + DateTime.Parse(dto.DtAtualizacao.Value.ToString()).ToString("ddMMyyyy HHmmss") + "','ddMMyyyy HH24miss')";

            Connection.ExecuteCommand(queryExec);
        }

        public DataTable ListarItensLogImportacaoPalmTXT(InventarioMatMedDTO dto)
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT CAD_MTMD_FILIAL_ID,\n" +
                               "       CAD_SET_ID,\n" +
                               "       CAD_MTMD_ID,\n" +
                               "       CAD_MTMD_QTDE,\n" +
                               "       INV_LOG_CD_BARRA,\n" +
                               "       INV_LOG_DATA_INI_PROCESSO,\n" +
                               "       INV_LOG_DATA_REGISTRO,\n" +
                               "       INV_SEG_USU_ID_USUARIO,\n" +
                               "       FL_EXCLUIDO,\n" +
                               "       LOG_ID_USUARIO_EXCLUSAO,\n" +
                               "       MTMD_COD_LOTE,\n" +
                               "       CAD_MTMD_FECHAMENTO\n" +
                               "FROM TB_CAD_MTMD_INVENT_LOG_IMPORT\n" +
                               "WHERE FL_EXCLUIDO = 0 AND CAD_MTMD_FILIAL_ID = " + dto.IdFilial.Value.ToString() + " AND\n" +
                               "      CAD_SET_ID = " + dto.IdSetor.Value.ToString() + " AND\n" +
                               "      INV_LOG_DATA_INI_PROCESSO = TO_DATE('" + DateTime.Parse(dto.DtAtualizacao.Value.ToString()).ToString("ddMMyyyy HHmmss") + "','ddMMyyyy HH24miss')";

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public DataTable ListarArquivosSalvosImportacaoPalmTXT(InventarioMatMedDTO dto)
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT DISTINCT \n" +
                               "       CAD_SET_ID,\n" +
                               "       CAD_MTMD_FILIAL_ID,\n" +                               
                               "       INV_LOG_DATA_INI_PROCESSO,\n" +
                               "       CAD_MTMD_FECHAMENTO+1 CAD_MTMD_FECHAMENTO\n" +
                               "FROM TB_CAD_MTMD_INVENT_LOG_IMPORT\n" +
                               "WHERE FL_EXCLUIDO = 0 AND CAD_MTMD_FILIAL_ID = " + dto.IdFilial.Value.ToString() + " AND\n" +
                               "      CAD_SET_ID = " + dto.IdSetor.Value.ToString() + " AND\n" +
                               "      INV_LOG_DATA_INI_PROCESSO >= SYSDATE-60 ORDER BY INV_LOG_DATA_INI_PROCESSO DESC ";

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public DataTable ListarTXT(InventarioMatMedDTO dto)
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT CAD_MTMD_ID,\n" +
                               "       CAD_MTMD_QTDE_ANTERIOR\n" + 
                               "FROM TB_CAD_MTMD_INVENTARIO\n" +
                               "WHERE CAD_MTMD_FILIAL_ID = " + dto.IdFilial.Value.ToString() + " AND\n" +
                               "      CAD_SET_ID = " + dto.IdSetor.Value.ToString() + " AND\n" +
                               "      CAD_MTMD_DT_INVENTARIO = TO_DATE('" + DateTime.Parse(dto.DataInventario.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')";

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }        

        public DataTable SetoresSemContagem(DateTime dataDe, DateTime dataAte)
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT DISTINCT\n" +
                                "       DECODE(L.CAD_MTMD_FILIAL_ID,1,'HAC',2,'ACS','CE') ESTOQUE,\n" +
                                "       U.CAD_UNI_DS_UNIDADE UNIDADE,\n" +
                                "       S.CAD_SET_DS_SETOR SETOR\n" +
                                "FROM TB_MTMD_ESTOQUE_LOCAL L JOIN\n" +
                                "     TB_CAD_UNI_UNIDADE U ON U.CAD_UNI_ID_UNIDADE = L.CAD_UNI_ID_UNIDADE JOIN\n" +
                                "     TB_CAD_SET_SETOR S ON S.CAD_SET_ID = L.CAD_SET_ID JOIN\n" +
                                "     TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = L.CAD_MTMD_ID\n" +
                                "WHERE L.CAD_SET_ID NOT IN\n" +
                                "      (SELECT INV.CAD_SET_ID\n" +
                                "         FROM TB_CAD_MTMD_INVENTARIO INV\n" +
                                "        WHERE INV.CAD_MTMD_DT_INVENTARIO >= TO_DATE('" + dataDe.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "          AND INV.CAD_MTMD_DT_INVENTARIO <= TO_DATE('" + dataAte.ToString("ddMMyyyy") + "','ddMMyyyy')\n" +
                                "          AND INV.CAD_MTMD_FILIAL_ID = L.CAD_MTMD_FILIAL_ID )\n" +
                                "  AND L.CAD_SET_ID NOT IN (SELECT CAD_SET_ID\n" +
                                "                             FROM TB_MTMD_CFG_ESTOQUE_CONSUMO\n" +
                                "                            WHERE CAD_MTMD_FILIAL_ID = L.CAD_MTMD_FILIAL_ID\n" +
                                "                              AND CAD_SET_ID = L.CAD_SET_ID\n" +
                                "                            UNION SELECT 2252 FROM DUAL) --ATD. DOM.\n" +
                                "GROUP BY L.CAD_MTMD_FILIAL_ID, U.CAD_UNI_DS_UNIDADE, S.CAD_SET_DS_SETOR\n" +
                                "HAVING SUM(L.MTMD_ESTLOC_QTDE) > 0\n" +
                                "ORDER BY DECODE(L.CAD_MTMD_FILIAL_ID,1,'HAC',2,'ACS','CE'),\n" +
                                "         U.CAD_UNI_DS_UNIDADE,\n" +
                                "         S.CAD_SET_DS_SETOR";

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public bool InventarioImportando(InventarioMatMedDTO dto, DateTime _dataInicioInv)
        {
            DataTable result = new DataTable();
            string grupo = dto.FlMedicamento.Value == 1 ? "= 1" : "!= 1";
            if (!dto.IdtGrupo.Value.IsNull && (decimal)dto.IdtGrupo.Value != 0) grupo = "= " + dto.IdtGrupo.Value;
            string sqlString = "SELECT COUNT(M.MTMD_MOV_ID)\n" +
                                " FROM TB_MTMD_MOV_MOVIMENTACAO M\n" +
                                "WHERE M.CAD_MTMD_SUBTP_ID IN (43,44) AND\n" +
                                "      M.CAD_SET_ID = " + dto.IdSetor.Value + " AND\n" +
                                "      M.CAD_MTMD_FILIAL_ID = " + dto.IdFilial.Value + " AND\n" +
                                "      M.CAD_MTMD_GRUPO_ID " + grupo + " AND\n" +
                                "      (M.MTMD_MOV_DATA BETWEEN TO_DATE('" + _dataInicioInv.ToString("ddMMyyyy HHmm") + "', 'ddMMyyyy HH24mi') AND " +
                                                               "TO_DATE('" + _dataInicioInv.ToString("ddMMyyyy") + "', 'ddMMyyyy')+30/24)";

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return int.Parse(result.Rows[0][0].ToString()) > 0 ? true : false;
        }

        public void InserirHash(InventarioMatMedDTO dto, string hash)
        {
            DataTable result = new DataTable();
            string sqlString = "INSERT INTO TB_CAD_MTMD_INVENTARIO_ARQUIVO\n" +
                               "  ( CAD_MTMD_FILIAL_ID,\n" +
                               "    CAD_SET_ID,\n" +
                               "    CAD_MTMD_FECHAMENTO,\n" +
                               "    CAD_MTMD_INV_HASH,\n" +
                               "    MTMD_DT_REGISTRO,\n" +
                               "    INV_LOG_DATA_INI_PROCESSO\n" +
                               "  )\n" +
                               "  VALUES\n" +
                               "  ( " + dto.IdFilial.Value.ToString() + ",\n" +
                               "    " + dto.IdSetor.Value.ToString() + ",\n" +
                               "    " + dto.Fechamento.Value.ToString() + ",\n" +
                               "    '" + hash + "',\n" +
                               "    SYSDATE,\n" +
                               "    TO_DATE('" + DateTime.Parse(dto.DtAtualizacao.Value.ToString()).ToString("ddMMyyyy HHmmss") + "','ddMMyyyy HH24miss')\n" +
                               "  )";

            Connection.ExecuteCommand(sqlString);
        }

        public void ExcluirHashImportacaoPalmTXT(InventarioMatMedDTO dto)
        {
            string queryExec = "UPDATE TB_CAD_MTMD_INVENTARIO_ARQUIVO SET " +
                                   "   FL_EXCLUIDO = 1 \n" +
                               "\nWHERE FL_EXCLUIDO = 0 AND\n" +
                                      " CAD_MTMD_FECHAMENTO = " + dto.Fechamento.Value.ToString() + " AND\n" +
                                      " CAD_MTMD_FILIAL_ID = " + dto.IdFilial.Value.ToString() + " AND\n" +
                                      " CAD_SET_ID = " + dto.IdSetor.Value.ToString() + " AND\n" +
                                      " INV_LOG_DATA_INI_PROCESSO = TO_DATE('" + DateTime.Parse(dto.DtAtualizacao.Value.ToString()).ToString("ddMMyyyy HHmmss") + "','ddMMyyyy HH24miss')";

            Connection.ExecuteCommand(queryExec);
        }

        public DataTable ListarHashImportacaoPalmTXT(InventarioMatMedDTO dto, string hash)
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT CAD_MTMD_FILIAL_ID,\n" +
                               "       CAD_SET_ID,\n" +
                               "       CAD_MTMD_INV_HASH,\n" +
                               "       INV_LOG_DATA_INI_PROCESSO,\n" +
                               "       MTMD_DT_REGISTRO,\n" +
                               "       FL_EXCLUIDO,\n" +
                               "       CAD_MTMD_FECHAMENTO\n" +
                               "FROM TB_CAD_MTMD_INVENTARIO_ARQUIVO\n" +
                               "WHERE FL_EXCLUIDO = 0 AND MTMD_DT_REGISTRO >= SYSDATE-30 AND CAD_MTMD_INV_HASH = '" + hash.Trim() + "' AND\n" +
                               "      CAD_MTMD_FILIAL_ID = " + dto.IdFilial.Value.ToString() + " AND\n" +
                               "      CAD_SET_ID = " + dto.IdSetor.Value.ToString();

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }
	}
}