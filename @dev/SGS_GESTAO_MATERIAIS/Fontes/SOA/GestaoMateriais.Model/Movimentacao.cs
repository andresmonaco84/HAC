using System;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Movimentacao : Entity
    {
        private OracleError trataErro = new OracleError();

        /// <summary>
        /// Nova versão do RM (2018)
        /// </summary>
        /// <param name="dto"></param>        
        public DataTable SelMovArquivoContHeader(MovimentacaoMensalDTO dto)
        {
            string sqlString = "SELECT DISTINCT A.MESANO DATA,\n" +
                                "       0 VALOR,\n" +
                                "       'M' || RPAD('10',10) || RPAD('IMPORTACAO ESTOQUE HAC',100) || RPAD(TO_CHAR(A.MESANO,'DDMMYYYY' ) ,10) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB  A\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA  IN ( 'B' ,  'V',  'Q',  'A' )\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT A.MESANO DATA,\n" +
                                "       SUM(NVL(A.VALOR,0)) VALOR,\n" +
                                "       '*P' ||\n" +
                                "       LPAD(TO_CHAR(A.MESANO,'DDMMYY' ) ,6)||\n" +
                                "       RPAD(' ',14)||\n" +
                                "       RPAD(CODCONTA_DEB,40)  ||\n" +
                                "       RPAD(CODCONTA_CRED,40) ||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       TO_CHAR(SUM(NVL(A.VALOR,0)), '00000000000,00') ||\n" +
                                "       RPAD('173',10) ||\n" +
                                "       RPAD(' ',250) ||\n" +
                                "       RPAD(CODFILIAL,3) ||\n" +
                                "       RPAD(A.CD_CCUSTO,25) ||\n" +
                                "       RPAD(' ',64) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB  A\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA  IN ( 'B' ,  'V',  'Q',  'A' )\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT DISTINCT A.MESANO DATA,\n" +
                                "       0 VALOR,\n" +
                                "       'M' || RPAD('10',10) || RPAD('IMPORTACAO ESTOQUE HAC',100) || RPAD(TO_CHAR(A.MESANO,'DDMMYYYY' ) ,10) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB A,\n" +
                                "     TB_CAD_UNI_UNIDADE U\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA = 'T'\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "  AND A.CODCLADESAMB <> 6\n" +
                                "  AND A.CODCLADESAMB = U.CAD_UNI_CD_UNID_HOSPITALAR\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT A.MESANO DATA,\n" +
                                "       SUM(NVL(A.VALOR,0)) VALOR,\n" +
                                "       '*P' ||\n" +
                                "       LPAD(TO_CHAR(A.MESANO,'DDMMYY' ) ,6)||\n" +
                                "       RPAD(' ',14)||\n" +
                                "       RPAD(CODCONTA_DEB,40)  ||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       TO_CHAR(SUM(NVL(A.VALOR,0)), '00000000000,00') ||\n" +
                                "       RPAD('110',10) ||\n" +
                                "       RPAD(' ',250) ||\n" +
                                "       (SELECT SUBSTR(PSU.CAD_PES_NR_CNPJ_CPF, 11, 2) || ' '\n" +
                                "         FROM TB_CAD_UNI_UNIDADE     UNI,\n" +
                                "              TB_CAD_PES_PESSOA      PSU\n" +
                                "        WHERE UNI.CAD_UNI_ID_UNIDADE = U.CAD_UNI_ID_UNIDADE\n" +
                                "          AND UNI.CAD_PES_ID_PESSOA = PSU.CAD_PES_ID_PESSOA) ||\n" +
                                "       RPAD(A.CD_CCUSTO,25) ||\n" +
                                "       RPAD(' ',64) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB  A,\n" +
                                "     TB_CAD_UNI_UNIDADE U\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA = 'T'\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "  AND A.CODCLADESAMB <> 6\n" +
                                "  AND A.CODCLADESAMB = U.CAD_UNI_CD_UNID_HOSPITALAR\n" +
                                "GROUP BY U.CAD_UNI_ID_UNIDADE, A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT DISTINCT A.MESANO DATA,\n" +
                                "       0 VALOR,\n" +
                                "       'M' || RPAD('10',10) || RPAD('IMPORTACAO ESTOQUE HAC',100) || RPAD(TO_CHAR(A.MESANO,'DDMMYYYY' ) ,10) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB A\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA = 'T'\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "  AND A.CODCLADESAMB <> 6\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT A.MESANO DATA,\n" +
                                "       SUM(NVL(A.VALOR,0)) VALOR,\n" +
                                "       '*P' ||\n" +
                                "       LPAD(TO_CHAR(A.MESANO,'DDMMYY' ) ,6)||\n" +
                                "       RPAD(' ',14)||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       RPAD(CODCONTA_CRED,40) ||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       TO_CHAR(SUM(NVL(A.VALOR,0)), '00000000000,00') ||\n" +
                                "       RPAD('110',10) ||\n" +
                                "       RPAD(' ',250) ||\n" +
                                "       RPAD(CODFILIAL,3) ||\n" +
                                "       RPAD(A.CD_CCUSTO,25) ||\n" +
                                "       RPAD(' ',64) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB A\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA = 'T'\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "  AND A.CODCLADESAMB <> 6\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT DISTINCT A.MESANO DATA,\n" +
                                "       0 VALOR,\n" +
                                "       'M' || RPAD('10',10) || RPAD('IMPORTACAO ESTOQUE HAC',100) || RPAD(TO_CHAR(A.MESANO,'DDMMYYYY' ) ,10) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB  A\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA = 'D'\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT A.MESANO DATA,\n" +
                                "       SUM(NVL(A.VALOR,0)) VALOR,\n" +
                                "       '*P' ||\n" +
                                "       LPAD(TO_CHAR(A.MESANO,'DDMMYY' ) ,6)||\n" +
                                "       RPAD(' ',14)||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       RPAD(CODCONTA_CRED,40) ||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       TO_CHAR(SUM(NVL(A.VALOR,0)), '00000000000,00') ||\n" +
                                "       RPAD('083',10) ||\n" +
                                "       RPAD(' ',250) ||\n" +
                                "       RPAD(CODFILIAL,3) ||\n" +
                                "       RPAD(A.CD_CCUSTO,25) ||\n" +
                                "       RPAD(' ',64) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB  A\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA = 'D'\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "UNION\n" +
                                "SELECT A.MESANO DATA,\n" +
                                "       SUM(NVL(A.VALOR,0)) VALOR,\n" +
                                "       '*P' ||\n" +
                                "       LPAD(TO_CHAR(A.MESANO,'DDMMYY' ) ,6)||\n" +
                                "       RPAD(' ',14)||\n" +
                                "       RPAD(CODCONTA_DEB,40)  ||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       RPAD(' ',40) ||\n" +
                                "       TO_CHAR(SUM(NVL(A.VALOR,0)), '00000000000,00') ||\n" +
                                "       RPAD('083',10) ||\n" +
                                "       RPAD(' ',250) ||\n" +
                                "       '001' ||\n" +
                                "       RPAD(A.CD_CCUSTO,25) ||\n" +
                                "       RPAD(' ',64) TXT_GERAR\n" +
                                "FROM ALM_RESUMO_MOVIMENTO_CTB  A\n" +
                                "WHERE TO_NUMBER(TO_CHAR(MESANO,'MM' )) = @MES\n" +
                                "  AND TO_NUMBER(TO_CHAR(MESANO,'YYYY')) = @ANO\n" +
                                "  AND A.TIPO_BAIXA = 'D'\n" +
                                "  AND A.IND_TIPO_BAIXA = 'N'\n" +
                                "  AND A.CODHOS = 1\n" +
                                "  AND NVL(A.VALOR,0) != 0\n" +
                                "GROUP BY A.CODFILIAL, MESANO, TIPO_BAIXA, A.CD_CCUSTO,\n" +
                                "         A.CODUNIHOS,RPAD(CODCONTA_DEB,40), RPAD(CODCONTA_CRED,40)\n" +
                                "ORDER BY 1,3 DESC";

            sqlString = sqlString.Replace("@MES", dto.Mes.Value);
            sqlString = sqlString.Replace("@ANO", dto.Ano.Value);

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public DataTable SelMovArquivoCont(MovimentacaoMensalDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pMTMD_MOV_ANO
            param.Add(Connection.CreateParameter("pMTMD_MOV_ANO", dto.Ano.DBValue, ParameterDirection.Input, dto.Ano.DbType));

            // Parametro pMTMD_MOV_MES
            param.Add(Connection.CreateParameter("pMTMD_MOV_MES", dto.Mes.DBValue, ParameterDirection.Input, dto.Mes.DbType));

            // Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            #endregion

            DataTable result = new DataTable();
            string query = "PRC_MTMD_ESTOQUE_GERA_TXT_CONT";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

		/// <summary>
        /// Listar todos os registros
        /// Caso consumoPaciente = true, filtra os registros que sejam apenas referente a consumo de paciente
        /// </summary>
        public MovimentacaoDataTable Sel(MovimentacaoDTO dto, bool consumoPaciente)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

			//Parametro pMTMD_LOTEST_ID
			param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

			//Parametro pCAD_MTMD_TPMOV_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));

			//Parametro pCAD_MTMD_SUBTP_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

			//Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

			//Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

			//Parametro pMTMD_MOV_FL_FINALIZADO
			param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dto.FlFinalizado.DBValue, ParameterDirection.Input, dto.FlFinalizado.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.IdtRequisicao.DBValue, ParameterDirection.Input, dto.IdtRequisicao.DbType));

            //Parametro
            param.Add(Connection.CreateParameter("pMTMD_MOV_FL_ESTORNO", dto.FlEstornado.DBValue, ParameterDirection.Input, dto.FlEstornado.DbType));

            //Parametro
            param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FATURADO", dto.FlFaturado.DBValue, ParameterDirection.Input, dto.FlFaturado.DbType));

            

            if (consumoPaciente)
            {
                //Parametro pCONSUMO_PACIENTE (traz apenas registros referentes ao consumo do paciente)
                param.Add(Connection.CreateParameter("pCONSUMO_PACIENTE", "S"));
            }

			#endregion	
			
			MovimentacaoDataTable result = new MovimentacaoDataTable();
			string query = "PRC_MTMD_MOV_MOVIMENTACAO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MovimentacaoDTO SelChave(MovimentacaoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			MovimentacaoDataTable result = new MovimentacaoDataTable();
			// string query = "PRC_MTMD_MOV_MOVIMENTACAO_S";
            string query = "PRC_MTMD_MOV_MOVIMENTACAO_SID";            
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}
		
		/// <summary>
        /// Exclui o registro
        /// </summary>
		public void Del(MovimentacaoDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_MOV_MOVIMENTACAO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(MovimentacaoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pMTMD_MOV_ID
			param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			//Parametro pMTMD_LOTEST_ID
			param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_MTMD_TPMOV_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));
			
			//Parametro pCAD_MTMD_SUBTP_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));
			
			//Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));
			
			//Parametro pMTMD_MOV_QTDE
			param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
			
			//Parametro pMTMD_MOV_FL_FINALIZADO
			param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dto.FlFinalizado.DBValue, ParameterDirection.Input, dto.FlFinalizado.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			#endregion	

			string query = "PRC_MTMD_MOV_MOVIMENTACAO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
        public void Ins(MovimentacaoDTO dto)
		{			
			string query = "PRC_MTMD_MOV_MOVIMENTACAO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();

            param.Add(Connection.CreateParameterSequence());

			//Parametro pMTMD_MOV_ID
			// param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			//Parametro pMTMD_LOTEST_ID
			param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_MTMD_TPMOV_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));
			
			//Parametro pCAD_MTMD_SUBTP_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));
			
			//Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));
			
			//Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
			
			//Parametro pMTMD_MOV_FL_FINALIZADO
			param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dto.FlFinalizado.DBValue, ParameterDirection.Input, dto.FlFinalizado.DbType));

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.IdtRequisicao.DBValue, ParameterDirection.Input, dto.IdtRequisicao.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pMTMD_TP_FRACAO_ID
            param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.TpFracao.DBValue, ParameterDirection.Input, dto.TpFracao.DbType));

            //Parametro pMTMD_QTD_CONVERTIDA
            param.Add(Connection.CreateParameter("pMTMD_QTD_CONVERTIDA", dto.QtdConvertida.DBValue, ParameterDirection.Input, dto.QtdConvertida.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());

		}

        public MovimentacaoDTO EntradaProduto(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            param.Add(Connection.CreateParameterSequence());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));            

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.IdtRequisicao.DBValue, ParameterDirection.Input, dto.IdtRequisicao.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_TPMOV_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
            
            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pMTMD_MOV_FL_FINALIZADO
            param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dto.FlFinalizado.DBValue, ParameterDirection.Input, dto.FlFinalizado.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            #endregion
            string query = "PRC_MTMD_MOV_ENTRADA_UNIDADE";
            try
            {

                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
                dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
            return dto;

        }

        /// <summary>
        /// Faz Movimentação entre estoques - entrada e saida
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDTO TransfereEstoqueProduto(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            param.Add(Connection.CreateParameterSequence());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.IdtRequisicao.DBValue, ParameterDirection.Input, dto.IdtRequisicao.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
            
            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_TPMOV_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

            // INFORMAÇÕES PARA ESTOQUE DE SAIDA

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE_S", dto.IdtUnidadeBaixa.DBValue, ParameterDirection.Input, dto.IdtUnidadeBaixa.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_S", dto.IdtLocalBaixa.DBValue, ParameterDirection.Input, dto.IdtLocalBaixa.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID_S", dto.IdtSetorBaixa.DBValue, ParameterDirection.Input, dto.IdtSetorBaixa.DbType));

            //Parametro pCAD_MTMD_TPMOV_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_S", dto.IdtTipoBaixa.DBValue, ParameterDirection.Input, dto.IdtTipoBaixa.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_S", dto.IdtSubTipoBaixa.DBValue, ParameterDirection.Input, dto.IdtSubTipoBaixa.DbType));

            //Parametro pMTMD_MOV_DATA
            //param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            //Parametro pMTMD_MOV_FL_FINALIZADO
            param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dto.FlFinalizado.DBValue, ParameterDirection.Input, dto.FlFinalizado.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            #endregion
            string query = "PRC_MTMD_MOV_ESTOQUE_TRANSF";
            try
            {

                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
                dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
            return dto;

        }

        /// <summary>
        /// Baixa estoque local
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDTO MovimentaEstoqueProduto(MovimentacaoDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            param.Add(Connection.CreateParameterSequence());


            //Parametro pMTMD_MOV_ID
            //param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.IdtRequisicao.DBValue, ParameterDirection.Input, dto.IdtRequisicao.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_TPMOV_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

            //Parametro pMTMD_MOV_DATA
            //param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            //Parametro pMTMD_MOV_FL_FINALIZADO
            //param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dto.FlFinalizado.DBValue, ParameterDirection.Input, dto.FlFinalizado.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //pCAD_MTMD_FL_FRACIONA
            param.Add(Connection.CreateParameter("pCAD_MTMD_FL_FRACIONA", dto.FlFracionado.DBValue, ParameterDirection.Input, dto.FlFracionado.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_FATURAMENTO", dto.DtFaturamento.DBValue, ParameterDirection.Input, dto.DtFaturamento.DbType));

            //pCAD_MTMD_FL_FRACIONA
            param.Add(Connection.CreateParameter("pMTMD_MOV_HORA_FATURAMENTO", dto.HrFaturamento.DBValue, ParameterDirection.Input, dto.HrFaturamento.DbType));



            #endregion
            
            string query = "PRC_MTMD_MOV_ESTOQUE_BAIXA";
            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
                dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
                // BUSCA INFORMAÇÃO SOBRE MOVIMENTO SE É PRODUTO FRACIONADO COM TABELA DE CONVERSÃO
                if ( !dto.TpFracao.Value.IsNull  )
                {
                    dto = this.SelChave(dto);
                    // dto = this.SelChave(dto);
                    // SE PRODUTO É FRACIONADO MAS FOI CONSUMIDO COMO INTEIRO NÃO MOSTRA (/UNIDADE DE VENDA) NA TELA
                    if (dto.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM && dto.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA)
                    {
                        dto.DsQtdeConsumo.Value = string.Format("{0}/{1}", Convert.ToString(dto.Qtde.Value), dto.UnidadeVenda.Value.ToString());
                    }
                    else
                    {
                        dto.DsQtdeConsumo.Value = string.Format("{0}", Convert.ToString(dto.Qtde.Value));
                    }

                }
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }

            return dto;
        }

        /// <summary>
        /// Estorna estoque local
        /// </summary>
        /// <param name="dto"></param>
        public void EstornarMovimentoConsumoPaciente(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            
            //Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));            

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_LOTEST_ID
            //param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));            

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pMTMD_ID_USUARIO_ESTORNO
            param.Add(Connection.CreateParameter("pMTMD_ID_USUARIO_ESTORNO", dto.IdtUsuarioEstorno.DBValue, ParameterDirection.Input, dto.IdtUsuarioEstorno.DbType));

            #endregion

            string query = "PRC_MTMD_MOV_ESTOQUE_EST_CONS";
            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
        }

        public void GerarDadosRelatorioInfMatMed(byte mes, int ano, bool processarFechaEstoque, bool processarReceita, int idUsuario)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pREL_RFM_ANO_FECHAMENTO
            param.Add(Connection.CreateParameter("pREL_RFM_ANO_FECHAMENTO", ano, ParameterDirection.Input, DbType.Int16));

            //Parametro pREL_RFM_MES_FECHAMENTO
            param.Add(Connection.CreateParameter("pREL_RFM_MES_FECHAMENTO", mes, ParameterDirection.Input, DbType.Int16));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", idUsuario, ParameterDirection.Input, DbType.Int32));

            //Parametro pPROCESSAR_FECHA_ESTOQUE
            param.Add(Connection.CreateParameter("pPROCESSAR_FECHA_ESTOQUE", processarFechaEstoque ? 1 : 0, ParameterDirection.Input, DbType.Int16));

            //Parametro pPROCESSAR_RECEITA
            param.Add(Connection.CreateParameter("pPROCESSAR_RECEITA", processarReceita ? 1 : 0, ParameterDirection.Input, DbType.Int16));
                        
            #endregion

            string query = "PRC_REL_RFM_RESU_FAT_MTMD_G";
            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(ora.Message);
            }
        }

        #region DESUSO
        /*
        /// <summary>
        /// Estorna estoque local
        /// </summary>
        /// <param name="dto"></param>
        public void EstornarMovimentoCentroCirurgico(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pMTMD_ID_USUARIO_ESTORNO
            param.Add(Connection.CreateParameter("pMTMD_ID_USUARIO_ESTORNO", dto.IdtUsuarioEstorno.DBValue, ParameterDirection.Input, dto.IdtUsuarioEstorno.DbType));

            #endregion

            string query = "PRC_MTMD_ESTORNO_CCIRURGICO";

            //Executa o procedimento
            MovimentacaoDataTable result = new MovimentacaoDataTable();
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
        }
        */
        #endregion

        public MovimentacaoDataTable SelDivergencias(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pMTMD_MOV_FL_FINALIZADO
            param.Add(Connection.CreateParameter("pMTMD_MOV_FL_FINALIZADO", dto.FlFinalizado.DBValue, ParameterDirection.Input, dto.FlFinalizado.DbType));

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            #endregion

            string query = "PRC_MTMD_MOV_DIVERGENCIA_S";

            //Executa o procedimento
            MovimentacaoDataTable result = new MovimentacaoDataTable();
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public void DistribuiDespesaCentroCusto(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_TPMOV_ID
            // param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            // param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

            //Parametro pMTMD_MOV_DATA
            //param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pMTMD_ID_TP_CCUSTO
            param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));

            //Parametro pMTMD_REQ_ID
            param.Add(Connection.CreateParameter("pMTMD_REQ_ID", dto.IdtRequisicao.DBValue, ParameterDirection.Input, dto.IdtRequisicao.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));
            
            #endregion
            string query = "PRC_MTMD_MOV_CONSUMO_CCUSTO";
            try
            {

                // Executa o Procedimento
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }

        }

        public MovimentacaoDataTable HistoricoDespesaCentroCusto(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

			//Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pMTMD_MOV_DATA_ATE
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_ATE", dto.DataAte.DBValue, ParameterDirection.Input, dto.DataAte.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pTIS_MED_CD_TABELAMEDICA
            param.Add(Connection.CreateParameter("pTIS_MED_CD_TABELAMEDICA", dto.Tabelamedica.DBValue, ParameterDirection.Input, dto.Tabelamedica.DbType));

            //Parametro pMTMD_ID_TP_CCUSTO
            param.Add(Connection.CreateParameter("pMTMD_ID_TP_CCUSTO", dto.IdtLocalEstoque.DBValue, ParameterDirection.Input, dto.IdtLocalEstoque.DbType));

            //Parametro pBNF_MUN_CD_IBGE
            param.Add(Connection.CreateParameter("pBNF_MUN_CD_IBGE", dto.CodigoIBGEMunicipioHomeCare.DBValue, ParameterDirection.Input, dto.CodigoIBGEMunicipioHomeCare.DbType));

			 #endregion	
			
			MovimentacaoDataTable result = new MovimentacaoDataTable();
			string query = "PRC_MTMD_MOV_CONSUMO_HIST_CCUS";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
        }

        public MovimentacaoDataTable HistoricoDespesaCentroCustoSintetico(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pMTMD_MOV_DATA_ATE
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_ATE", dto.DataAte.DBValue, ParameterDirection.Input, dto.DataAte.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pTIS_MED_CD_TABELAMEDICA
            param.Add(Connection.CreateParameter("pTIS_MED_CD_TABELAMEDICA", dto.Tabelamedica.DBValue, ParameterDirection.Input, dto.Tabelamedica.DbType));

            //Parametro pBNF_MUN_CD_IBGE
            param.Add(Connection.CreateParameter("pBNF_MUN_CD_IBGE", dto.CodigoIBGEMunicipioHomeCare.DBValue, ParameterDirection.Input, dto.CodigoIBGEMunicipioHomeCare.DbType));

            #endregion

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_CONS_HIST_CCUS_R";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public MovimentacaoDataTable HistoricoDespesaCentroCustoPacientes(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
                        
            //Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pMTMD_MOV_DATA_ATE
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_ATE", dto.DataAte.DBValue, ParameterDirection.Input, dto.DataAte.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));
                        
            //Parametro pBNF_MUN_CD_IBGE
            param.Add(Connection.CreateParameter("pBNF_MUN_CD_IBGE", dto.CodigoIBGEMunicipioHomeCare.DBValue, ParameterDirection.Input, dto.CodigoIBGEMunicipioHomeCare.DbType));

            #endregion

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_CONS_PACIENTES_R";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public void EstornaDespesaCCusto(MovimentacaoDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();


            // Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pMTMD_ID_USUARIO_ESTORNO
            param.Add(Connection.CreateParameter("pMTMD_ID_USUARIO_ESTORNO", dto.IdtUsuarioEstorno.DBValue, ParameterDirection.Input, dto.IdtUsuarioEstorno.DbType));


            #endregion
            string query = "PRC_MTMD_MOV_CONSUMO_EST_CCUST";
            try
            {
                //Executa o procedimento
                // Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
        }

        #region DESUSO

        /*
        /// <summary>
        /// Verifica se um mat/med pode ser incluído na conta do paciente         
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se o mat/med não pode ser incluído. Caso contrário, retorna false.</returns>
        public bool VerificarFaturamentoInc(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));


            //Parametro pRetorno
            param.Add(Connection.CreateParameter("pRetorno", null, ParameterDirection.Output, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_REQUISICAO_FECHADA_I";

            //Executa o procedimento
            MovimentacaoDataTable result = new MovimentacaoDataTable();
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            return decimal.Parse(param["pRetorno"].Value.ToString()) == 0 ? false : true;
        }

        /// <summary>
        /// Verifica se um mat/med pode ser excluído da conta do paciente         
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se o mat/med não pode ser excluído. Caso contrário, retorna false.</returns>
        public bool VerificarFaturamentoExc(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));


            //Parametro pRetorno
            param.Add(Connection.CreateParameter("pRetorno", null, ParameterDirection.Output, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_REQUISICAO_FECHADA_E";

            //Executa o procedimento
            MovimentacaoDataTable result = new MovimentacaoDataTable();
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            return decimal.Parse(param["pRetorno"].Value.ToString()) == 0 ? false : true;
        }
        */

        #endregion

        /// <summary>
        /// Verifica se conta ainda esta aberta para consumo, não faturada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool PermiteConsumo(MovimentacaoDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));


            //Parametro pRetorno
            param.Add(Connection.CreateParameter("pRetorno", null, ParameterDirection.Output, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_PERMITE_CONSUMO";

            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch(OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
            return decimal.Parse(param["pRetorno"].Value.ToString()) == 1 ? true : false;
        }
                
        public MovimentacaoDataTable ListaMovimentacaoCCirurgicoFaturar(MovimentacaoDTO dto)
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
            
            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_CCIRURGICO_FAT";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

        /// <summary>
        /// Lista Movimento do Produto passado como parametro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDataTable ListaMovimentacao(MovimentacaoDTO dto)
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());


            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));


            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_MOVIMENTACAO_R";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }                
        
        public void SalvaMovimentoCentroCirurgico(MovimentacaoDTO dto)
        {
            string query = "PRC_MTMD_MOV_BAIXA_CCIRURGICO";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // param.Add(Connection.CreateParameterSequence());

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            #endregion

            try
            {
                // Executa o Procedimento
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
                // dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
        }

        /// <summary>
        /// Processa operações padrões (atualizações de campos e status) 
        /// após a realização do processo de faturamento do SGS  
        /// </summary>
        public void ProcessarRotinaPosFaturamento(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro pACAO = 0 (Inclusão)
            //param.Add(Connection.CreateParameter("pACAO", 0, ParameterDirection.Input, DbType.Decimal));

            // Parametro pCAD_MTMD_ID
            //param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            // Parametro pSEQ_PACIENTE
            param.Add(Connection.CreateParameter("pSEQ_PACIENTE", dto.SequenciaConsumoFaturamento.DBValue, ParameterDirection.Input, dto.SequenciaConsumoFaturamento.DbType));
                        
            // Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pMTMD_MOV_DATA_FATURAMENTO
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_FATURAMENTO", dto.DtFaturamento.DBValue, ParameterDirection.Input, dto.DtFaturamento.DbType));

            //Parametro pMTMD_MOV_HORA_FATURAMENTO
            param.Add(Connection.CreateParameter("pMTMD_MOV_HORA_FATURAMENTO", dto.HrFaturamento.DBValue, ParameterDirection.Input, dto.HrFaturamento.DbType));

            // Parametro pATD_ATE_ID
            //param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            #endregion
            string query = "PRC_MTMD_MOV_POS_FATURA";
            try
            {
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
        }

        /// <summary>
        /// Processa operações padrões (atualizações de campos e status) 
        /// após a realização do processo de faturamento do SGS p/ o Centro Cirurgico 
        /// </summary>
        public void ProcessarRotinaPosFaturamentoCCirurgico(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            
            // Parametro pSEQ_PACIENTE
            param.Add(Connection.CreateParameter("pSEQ_PACIENTE", dto.SequenciaConsumoFaturamento.DBValue, ParameterDirection.Input, dto.SequenciaConsumoFaturamento.DbType));

            // Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
            
            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
                        
            //Parametro pCAD_MTMD_SUBTP_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
                        
            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pMTMD_TP_FRACAO_ID
            param.Add(Connection.CreateParameter("pMTMD_TP_FRACAO_ID", dto.TpFracao.DBValue, ParameterDirection.Input, dto.TpFracao.DbType));

            //Parametro pMTMD_QTD_CONVERTIDA
            param.Add(Connection.CreateParameter("pMTMD_QTD_CONVERTIDA", dto.QtdConvertida.DBValue, ParameterDirection.Input, dto.QtdConvertida.DbType));

            //Parametro pMTMD_MOV_DATA_FATURAMENTO
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_FATURAMENTO", dto.DtFaturamento.DBValue, ParameterDirection.Input, dto.DtFaturamento.DbType));

            //Parametro pMTMD_MOV_HORA_FATURAMENTO
            param.Add(Connection.CreateParameter("pMTMD_MOV_HORA_FATURAMENTO", dto.HrFaturamento.DBValue, ParameterDirection.Input, dto.HrFaturamento.DbType));

            #endregion
            string query = "PRC_MTMD_MOV_POS_FATURA_CCIR";
            try
            {
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
        }

        /// <summary>
        /// Processa operações padrões (atualizações de campos e status) 
        /// após a realização do processo de estorno de faturamento do SGS  
        /// </summary>
        /// <param name="dto"></param>
        public void ProcessarRotinaPosFaturamentoEstorno(MovimentacaoDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro pACAO = 0 (Exclusão)
            param.Add(Connection.CreateParameter("pACAO", 1, ParameterDirection.Input, DbType.Decimal));

            // Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            #endregion
            string query = "PRC_MTMD_MOV_POS_FATURA";
            try
            {
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
        }

        public MovimentacaoDTO ObterSequenciaConsumoFaturamento(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pMTMD_MOV_ID
            param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            #endregion

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_SEQ_CONS_FAT";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count > 0)
            {
                if (!result.TypedRow(0).SequenciaConsumoFaturamento.Value.IsNull) dto.SequenciaConsumoFaturamento.Value = result.TypedRow(0).SequenciaConsumoFaturamento.Value;
            }                

            return dto;
        }

        /// <summary>
        /// Lista Atendimento com Itens não enviados ao faturamento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDataTable PendenciaCCirurgico(MovimentacaoDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_TPMOV_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

            //Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));


            #endregion

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_CCIRURGICO_R";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Verifica Consumo de Materiais e Medicamentos para o paciente.
        /// Nr. Atendimento ( Obrigatório )
        /// Unidade/Local?Setor ( Opcional )
        /// </summary>
        /// <param name="dto">MovimentacaoDTO</param>
        /// <returns>Boolean</returns>
        public bool VerificaConsumo(MovimentacaoDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));


            //Parametro pRetorno
            param.Add(Connection.CreateParameter("pRetorno", null, ParameterDirection.Output, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_MOV_VERIFICA_CONSUMO";

            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }
            return decimal.Parse(param["pRetorno"].Value.ToString()) == 1 ? true : false;
        }

        ///// <summary>
        ///// Verifica Consumo de Materiais e Medicamentos para o paciente.
        ///// Nr. Atendimento ( Obrigatório )
        ///// </summary>
        ///// <param name="dto">MovimentacaoDTO</param>
        ///// <returns>Boolean</returns>
        //public bool VerificaConsumoCentroCirurgico(MovimentacaoDTO dto)
        //{

        //    #region "Parametros"
        //    DbParameterCollection param = Connection.CreateDataParameterCollection();

        //    //Parametro pATD_ATE_ID
        //    param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));
            
        //    //Parametro pRetorno
        //    param.Add(Connection.CreateParameter("pRetorno", null, ParameterDirection.Output, DbType.Decimal));

        //    #endregion

        //    string query = "PRC_MTMD_MOV_VERIF_CONS_CECI";

        //    try
        //    {
        //        //Executa o procedimento
        //        MovimentacaoDataTable result = new MovimentacaoDataTable();
        //        Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        //    }
        //    catch (OracleException ora)
        //    {
        //        throw new Exception(trataErro.RetornaMsg(ora, dto, query));
        //    }
        //    return decimal.Parse(param["pRetorno"].Value.ToString()) == 1 ? true : false;
        //}

        public MovimentacaoDataTable HistoricoEnvioFaturamentoPaciente(MovimentacaoDTO dto)
        {
            string query = "SELECT MOVIMENTACAO.MTMD_MOV_ID,\n" +
                            "       MOVIMENTACAO.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                            "       MOVIMENTACAO.CAD_UNI_ID_UNIDADE,\n" +
                            "       MOVIMENTACAO.CAD_SET_ID,\n" +
                            "       MOVIMENTACAO.MTMD_REQ_ID,\n" +
                            "       MOVIMENTACAO.MTMD_LOTEST_ID,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_ID,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_TPMOV_ID,\n" +
                            "       DECODE(MOVIMENTACAO.CAD_MTMD_SUBTP_ID, 36, 14, MOVIMENTACAO.CAD_MTMD_SUBTP_ID) CAD_MTMD_SUBTP_ID,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_DATA,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_QTDE,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_FL_FINALIZADO,\n" +
                            "       MOVIMENTACAO.ATD_ATE_ID,\n" +
                            "       MOVIMENTACAO.ATD_ATE_TP_PACIENTE,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_FL_FATURADO,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_FILIAL_ID,\n" +
                            "       MOVIMENTACAO.MTMD_TP_FRACAO_ID,\n" +
                            "       MOVIMENTACAO.MTMD_QTD_CONVERTIDA,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_DATA_FATURAMENTO,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_HORA_FATURAMENTO,\n" +
                            "       MOVIMENTACAO.SEQ_PACIENTE,\n" +
                            "       PRODUTO.CAD_MTMD_CODMNE,\n" +
                            "       CASE\n" +
                            "          WHEN  MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN(14,35)\n" +
                            "          AND   PRODUTO.CAD_MTMD_FL_FRACIONA = 0  THEN FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID)||' (FRACIONADO) '\n" +
                            "          ELSE FNC_MTMD_SOUNDALIKE(PRODUTO.CAD_MTMD_NOMEFANTASIA,PRODUTO.CAD_MTMD_GRUPO_ID)\n" +
                            "       END CAD_MTMD_NOMEFANTASIA,\n" +
                            "       PRODUTO.CAD_MTMD_UNIDADE_VENDA,\n" +
                            "       CASE\n" +
                            "             WHEN  MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN(11, 18)\n" +
                            "             AND   PRODUTO.CAD_MTMD_FL_FRACIONA = 1 THEN\n" +
                            "                0\n" +
                            "             ELSE\n" +
                            "                PRODUTO.CAD_MTMD_FL_FRACIONA\n" +
                            "       END CAD_MTMD_FL_FRACIONA,\n" +
                            "       CASE\n" +
                            "         WHEN MOVIMENTACAO.MTMD_TP_FRACAO_ID IS NOT NULL\n" +
                            "         AND  MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (14, 35, 66)  THEN\n" +
                            "            TO_CHAR(MOVIMENTACAO.MTMD_QTD_CONVERTIDA)||' '||(SELECT MTMD_DS_TP_FRACAO FROM TB_MTMD_TIPO_FRACAO WHERE MTMD_TP_FRACAO_ID = MOVIMENTACAO.MTMD_TP_FRACAO_ID)\n" +
                            "         WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (14, 35)\n" +
                            "         AND  PRODUTO.CAD_MTMD_FL_FRACIONA = 0 THEN\n" +
                            "            'FRACIONADO'\n" +
                            "         WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 18)\n" +
                            "         AND  PRODUTO.CAD_MTMD_FL_FRACIONA = 1  THEN\n" +
                            "            'INTEIRO'\n" +
                            "         ELSE NULL\n" +
                            "       END  DS_QTDE_CONVERTIDA,\n" +
                            "       NULL MTMD_DT_RESSUPRIMENTO,\n" +
                            "       SETOR.CAD_SET_DS_SETOR,\n" +
                            "       UNIDADE.CAD_UNI_DS_UNIDADE,\n" +
                            "       SUBTP.CAD_MTMD_SUBTP_DESCRICAO,\n" +
                            "       SUBTP.CAD_MTMD_FL_FATURA,\n" +
                            "       USU_MOV.SEG_USU_DS_NOME DS_USUARIO,\n" +
                            "       (CASE\n" +
                            "           WHEN PRODUTO.CAD_MTMD_FL_FRACIONA = 1 AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (14, 26, 35, 66) THEN\n" +
                            "              TO_CHAR( MOVIMENTACAO.MTMD_MOV_QTDE )||'/'||TO_CHAR( PRODUTO.CAD_MTMD_UNIDADE_VENDA)\n" +
                            "           ELSE\n" +
                            "              TO_CHAR( MOVIMENTACAO.MTMD_MOV_QTDE )\n" +
                            "        END)  DS_QTDE_CONSUMO,\n" +
                            "        PRODUTO.CAD_MTMD_FL_MAV,\n" +
                            "        MOVIMENTACAO.MTMD_COD_LOTE,\n" +
                            "        (SELECT NVL(LL.MTMD_NUM_LOTE_ALT, LL.MTMD_NUM_LOTE)\n" +
                            "           FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                            "          WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND\n" +
                            "                LL.CAD_MTMD_ID   = MOVIMENTACAO.CAD_MTMD_ID AND\n" +
                            "                LL.MTMD_COD_LOTE = MOVIMENTACAO.MTMD_COD_LOTE AND ROWNUM = 1) MTMD_NUM_LOTE\n" +
                            "    FROM TB_MTMD_MOV_MOVIMENTACAO       MOVIMENTACAO,\n" +
                            "         TB_CAD_MTMD_MAT_MED            PRODUTO,\n" +
                            "         TB_CAD_SET_SETOR               SETOR,\n" +
                            "         TB_CAD_UNI_UNIDADE             UNIDADE,\n" +
                            "         TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP,\n" +
                            "         TB_SEG_USU_USUARIO             USU_MOV\n" +
                            "    WHERE MOVIMENTACAO.ATD_ATE_ID        = @ATD_ATE_ID\n @FILTRO-CAD_SET_ID @FILTRO-PERIODO" +
                            "    AND   MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (66)\n" +
                            "    AND   MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" +
                            "    AND   MOVIMENTACAO.CAD_MTMD_ID       = PRODUTO.CAD_MTMD_ID\n" +
                            "    AND   SETOR.CAD_SET_ID               = MOVIMENTACAO.CAD_SET_ID\n" +
                            "    AND   UNIDADE.CAD_UNI_ID_UNIDADE     = MOVIMENTACAO.CAD_UNI_ID_UNIDADE\n" +
                            "    AND   SUBTP.CAD_MTMD_SUBTP_ID        = MOVIMENTACAO.CAD_MTMD_SUBTP_ID\n" +
                            "    AND   USU_MOV.SEG_USU_ID_USUARIO(+)  = MOVIMENTACAO.SEG_USU_ID_USUARIO\n" +
                            "ORDER BY MOVIMENTACAO.MTMD_MOV_DATA DESC, PRODUTO.CAD_MTMD_NOMEFANTASIA ASC";

            query = query.Replace("@ATD_ATE_ID", dto.IdtAtendimento.Value);
            if (!dto.IdtSetor.Value.IsNull)
                query = query.Replace("@FILTRO-CAD_SET_ID", "AND MOVIMENTACAO.CAD_SET_ID = " + dto.IdtSetor.Value + "\n");
            else
                query = query.Replace("@FILTRO-CAD_SET_ID", string.Empty);

            if (!dto.DataMovimento.Value.IsNull && !dto.DataAte.Value.IsNull)
                query = query.Replace("@FILTRO-PERIODO", "AND MOVIMENTACAO.MTMD_MOV_DATA BETWEEN TO_DATE('" + DateTime.Parse(dto.DataMovimento.Value.ToString()).ToString("ddMMyyyy HHmmss") + "','ddMMyyyy HH24MISS') AND " +
                                                                                                "TO_DATE('" + DateTime.Parse(dto.DataAte.Value.ToString()).ToString("ddMMyyyy HHmmss") + "','ddMMyyyy HH24MISS')");
            else
                query = query.Replace("@FILTRO-PERIODO", string.Empty);

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            Connection.RecordSet(query, result, CommandType.Text);
            return result;
        }

        /// <summary>
        /// Retorna Itens consumidos para o paciente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>DataTable</returns>
        public MovimentacaoDataTable HistoricoConsumoPaciente(MovimentacaoDTO dto)
        {

            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pDATAINI
            param.Add(Connection.CreateParameter("pDATAINI", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pDATAFIM
            param.Add(Connection.CreateParameter("pDATAFIM", dto.DataAte.DBValue, ParameterDirection.Input, dto.DataAte.DbType));

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_HIST_PACIENTE";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;            
        }

        /// <summary>
        /// RETORNA ATENDIMENTOS COM MOVIMENTAÇÕES DE BAIXA NO PERÍODO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDataTable HistoricoConsumoAtendimentosPeriodo(MovimentacaoDTO dto, decimal? idtConvenio)
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();
           
            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pDATAINI
            param.Add(Connection.CreateParameter("pDATAINI", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pDATAFIM
            param.Add(Connection.CreateParameter("pDATAFIM", dto.DataAte.DBValue, ParameterDirection.Input, dto.DataAte.DbType));

            //Parametro pCAD_CNV_ID_CONVENIO
            if (idtConvenio != null)
                param.Add(Connection.CreateParameter("pCAD_CNV_ID_CONVENIO", idtConvenio.Value, ParameterDirection.Input,DbType.Decimal));

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_HIST_ATENDIMENTOS";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Retorna toda movimentação do produto no setor, parametros Obrigatórios:
        /// IdtProduto, IdtUnidade, IdtLocal, IdtSetor, IdtFilial, DtMovimetnacao
        /// DtMovimentacao é a data de inicio da pesquisa.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDataTable HistoricoProdutoSetor(MovimentacaoDTO dto)
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_MOV_DATA
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DataMovimento.DBValue, ParameterDirection.Input, dto.DataMovimento.DbType));

            //Parametro pMTMD_MOV_DATA_ATE
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_ATE", dto.DataAte.DBValue, ParameterDirection.Input, dto.DataAte.DbType));

            //Parametro pMTMD_COD_LOTE
            if (!dto.CodLote.Value.IsNull)
                param.Add(Connection.CreateParameter("pMTMD_COD_LOTE", dto.CodLote.DBValue, ParameterDirection.Input, dto.CodLote.DbType));

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_MOV_HIST_PRD_SETOR";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Realiza a Dispensação, Baixa e consumo para o paciente de Produtos para o Centro Cirurgico
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoDTO DispensacaoKitCCirurgico(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            param.Add(Connection.CreateParameterSequence());


            //Parametro pMTMD_MOV_ID
            //param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_LOTEST_ID
            param.Add(Connection.CreateParameter("pMTMD_LOTEST_ID", dto.IdtLote.DBValue, ParameterDirection.Input, dto.IdtLote.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_TPMOV_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_TPMOV_ID", dto.IdtTipo.DBValue, ParameterDirection.Input, dto.IdtTipo.DbType));

            //Parametro pCAD_MTMD_SUBTP_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.IdtSubTipo.DBValue, ParameterDirection.Input, dto.IdtSubTipo.DbType));

            //Parametro pMTMD_MOV_QTDE
            param.Add(Connection.CreateParameter("pMTMD_ESTLOC_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            //Parametro pATD_ATE_ID
            param.Add(Connection.CreateParameter("pATD_ATE_ID", dto.IdtAtendimento.DBValue, ParameterDirection.Input, dto.IdtAtendimento.DbType));

            //Parametro pATD_ATE_TP_PACIENTE
            param.Add(Connection.CreateParameter("pATD_ATE_TP_PACIENTE", dto.TpAtendimento.DBValue, ParameterDirection.Input, dto.TpAtendimento.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_FATURAMENTO", dto.DtFaturamento.DBValue, ParameterDirection.Input, dto.DtFaturamento.DbType));

            //pCAD_MTMD_FL_FRACIONA
            param.Add(Connection.CreateParameter("pMTMD_MOV_HORA_FATURAMENTO", dto.HrFaturamento.DBValue, ParameterDirection.Input, dto.HrFaturamento.DbType));



            #endregion

            string query = "PRC_MTMD_MOV_DISP_CCIRURGICO";
            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
                dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
                dto = this.SelChave(dto);
                // BUSCA INFORMAÇÃO SOBRE MOVIMENTO SE É PRODUTO FRACIONADO COM TABELA DE CONVERSÃO
                
                //if (!dto.TpFracao.Value.IsNull)
                //{
                //    dto = this.SelChave(dto);
                //    // dto = this.SelChave(dto);
                //    // SE PRODUTO É FRACIONADO MAS FOI CONSUMIDO COMO INTEIRO NÃO MOSTRA (/UNIDADE DE VENDA) NA TELA
                //    if (dto.FlFracionado.Value == (byte)MaterialMedicamentoDTO.Fracionado.SIM && dto.IdtSubTipo.Value == (byte)MovimentacaoDTO.SubTipoMovimento.MOVIMENTACAO_FRACIONADA)
                //    {
                //        dto.DsQtdeConsumo.Value = string.Format("{0}/{1}", Convert.ToString(dto.Qtde.Value), dto.UnidadeVenda.Value.ToString());
                //    }
                //    else
                //    {
                //        dto.DsQtdeConsumo.Value = string.Format("{0}", Convert.ToString(dto.Qtde.Value));
                //    }

                //}

            }
            catch (OracleException ora)
            {
                throw new Exception(trataErro.RetornaMsg(ora, dto, query));
            }

            return dto;
            
        }

        public void ImportaInventario(MovimentacaoDTO dto, int? idGrupo)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_MOV_ID
            //param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA_FATURAMENTO", dto.DtFaturamento.DBValue, ParameterDirection.Input, dto.DtFaturamento.DbType));

            if (idGrupo != null && idGrupo.Value > 0) //Parametro pCAD_MTMD_GRUPO_ID
                param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", idGrupo, ParameterDirection.Input, dto.IdtProduto.DbType));
            #endregion

            string query = "PRC_MTMD_IMPORTA_INVENTARIO";
            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            }
            catch (OracleException ora)
            {
                throw new Exception(ora.Message);
            }
        }

        public void ImportaInventarioMed(MovimentacaoDTO dto, int? idGrupo)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_MOV_ID
            //param.Add(Connection.CreateParameter("pMTMD_MOV_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pMTMD_MOV_DATA", dto.DtFaturamento.DBValue, ParameterDirection.Input, dto.DtFaturamento.DbType));

            if (idGrupo != null && idGrupo.Value > 0) //Parametro pCAD_MTMD_GRUPO_ID
                param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", idGrupo, ParameterDirection.Input, dto.IdtProduto.DbType));
            #endregion

            string query = "PRC_MTMD_IMPORTA_INVENT_MED";
            try
            {
                //Executa o procedimento
                MovimentacaoDataTable result = new MovimentacaoDataTable();
                Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            }
            catch (OracleException ora)
            {
                throw new Exception(ora.Message);
            }
        }

        public void TransferirAtendimento(decimal idAtd_De, decimal idAtd_Para)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_MTMD_MOV_MOVIMENTACAO SET ATD_ATE_ID = " + idAtd_Para + " WHERE ATD_ATE_ID = " + idAtd_De;

            Connection.ExecuteCommand(query);
        }

        public void LiberarAtendimento(decimal atendimento, decimal status, decimal idUsuario)
        {
            DataTable result = new DataTable();
            string query = "INSERT INTO TB_CAD_MTMD_ATD_ABERTURA VALUES (" + atendimento + ", " + status + ", " + idUsuario + ", SYSDATE)";

            Connection.ExecuteCommand(query);
        }

        public void AtualizarAtendimentoLiberado(decimal atendimento, decimal status)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_CAD_MTMD_ATD_ABERTURA SET ATD_FL_ABERTO = " + status + " WHERE ATD_ATE_ID = " + atendimento;

            Connection.ExecuteCommand(query);
        }

        public DataTable AtendimentosLiberados()
        {
            DataTable result = new DataTable();
            string query =  "SELECT ATD_ATE_ID,\n" +
                            "       ATD_FL_ABERTO,\n" +
                            "       DECODE(ATD_FL_ABERTO, 1, 'SIM', 'NAO') FL_ABERTO,\n" +
                            "       SEG_USU_ID_USUARIO,\n" +
                            "       ATD_DATA\n" +
                            "FROM TB_CAD_MTMD_ATD_ABERTURA ORDER BY ATD_DATA DESC";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterQtdProdutoBaixaPacSetor(MovimentacaoDTO dto, int idPrincipioAtivo)
        {
            if (dto.IdtSetor.Value.IsNull) dto.IdtSetor.Value = 0;
            DataTable result = new DataTable();
            string query =  "SELECT DECODE(MOVIMENTACAO.CAD_MTMD_SUBTP_ID, 14, 'F', 'I') MOV_TIPO,\n" +
                            "       SUM(MOVIMENTACAO.MTMD_MOV_QTDE) QTD_CONSUMO\n" +
                            "  FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO JOIN\n" +
                            "       TB_CAD_MTMD_MAT_MED PRODUTO ON PRODUTO.CAD_MTMD_ID = MOVIMENTACAO.CAD_MTMD_ID LEFT JOIN\n" +
                            "       TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = MOVIMENTACAO.MTMD_REQ_ID\n" +
                            "  WHERE MOVIMENTACAO.MTMD_MOV_DATA >= TO_DATE('10062015 1430','DDMMYYYY HH24MI') AND MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2\n" + //10/06/2015 foi a data da implantação da nova tela de Consumo das UTIs, e ficou provisoriamente hardcode para levar em conta apenas as baixas de produtos após esta data, para a verificação Qtd. Pedida x Baixas dar certo (= ao ObterQtdSolicitadaProdutoPaciente)
                            "    AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35, 36, 60)\n" +
                            "    AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" +
                            "    AND REQ.CAD_MTMD_KIT_ID IS NULL\n" +
                            //"    AND (MOVIMENTACAO.MTMD_REQ_ID IS NULL OR PRODUTO.CAD_MTMD_SUBGRUPO_ID = 981)\n" + //Antimicrobianos Restritos
                            "    AND (MOVIMENTACAO.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + " OR (PRODUTO.CAD_MTMD_PRIATI_ID <> 0 AND PRODUTO.CAD_MTMD_PRIATI_ID = " + idPrincipioAtivo.ToString() + "))\n" +
                            "    AND MOVIMENTACAO.ATD_ATE_ID = " + dto.IdtAtendimento.Value.ToString() + "\n" +
                            //"    AND MOVIMENTACAO.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n" +
                            "      AND   ((" + dto.IdtSetor.Value + " != 0 AND MOVIMENTACAO.CAD_SET_ID = " + dto.IdtSetor.Value + ") OR (" + dto.IdtSetor.Value + " = 0 AND MOVIMENTACAO.CAD_SET_ID = MOVIMENTACAO.CAD_SET_ID))\n" +
                            "GROUP BY DECODE(MOVIMENTACAO.CAD_MTMD_SUBTP_ID, 14, 'F', 'I') ORDER BY DECODE(MOVIMENTACAO.CAD_MTMD_SUBTP_ID, 14, 'F', 'I')";            

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterItensPendentesProtocolo(MovimentacaoDTO dto)
        {            
            DataTable result = new DataTable();
            string query =  "SELECT MOVIMENTACAO.MTMD_MOV_DATA,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_ID,\n" +
                            "       DECODE(MOVIMENTACAO.CAD_MTMD_SUBTP_ID, 14,\n" +
                            "              PRODUTO.CAD_MTMD_NOMEFANTASIA || ' *',\n" +
                            "              PRODUTO.CAD_MTMD_NOMEFANTASIA) CAD_MTMD_NOMEFANTASIA,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_QTDE,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_ID\n" +
                            "FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO,\n" +
                            "     TB_CAD_MTMD_MAT_MED      PRODUTO\n" +
                            "WHERE MOVIMENTACAO.ATD_ATE_ID IS NOT NULL\n" +
                            "  AND MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2\n" +
                            "  AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35, 36, 60)\n" +
                            "  AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" +
                            "  AND MOVIMENTACAO.CAD_MTMD_ID = PRODUTO.CAD_MTMD_ID\n" +
                            "  AND MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID IS NULL" +
                            "  AND MOVIMENTACAO.ATD_ATE_ID = @ATD_ATE_ID\n" +
                            "  AND MOVIMENTACAO.CAD_SET_ID = @CAD_SET_ID\n" +
                            "  AND MOVIMENTACAO.MTMD_MOV_DATA >= @DATA_DE AND TRUNC(MOVIMENTACAO.MTMD_MOV_DATA) <= @DATA_ATE\n" +
                            "ORDER BY MOVIMENTACAO.MTMD_MOV_DATA DESC, PRODUTO.CAD_MTMD_NOMEFANTASIA";

            query = query.Replace("@ATD_ATE_ID", dto.IdtAtendimento.Value);
            query = query.Replace("@CAD_SET_ID", dto.IdtSetor.Value);
            query = query.Replace("@DATA_DE", "TO_DATE('" + DateTime.Parse(dto.DataMovimento.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')");
            query = query.Replace("@DATA_ATE", "TO_DATE('" + DateTime.Parse(dto.DataAte.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')");

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterProtocolosPaciente(MovimentacaoDTO dto, decimal? idProtocolo)
        {
            DataTable result = new DataTable();
            string query = "SELECT TRUNC(MOVIMENTACAO.MTMD_MOV_PROTOCOLO_DATA) MTMD_MOV_PROTOCOLO_DATA,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID,\n" +
                            "       SUM(MOVIMENTACAO.MTMD_MOV_QTDE) MTMD_MOV_QTDE\n" +
                            "FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO,\n" +
                            "     TB_CAD_MTMD_MAT_MED      PRODUTO\n" +
                            "WHERE MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID IS NOT NULL AND MOVIMENTACAO.ATD_ATE_ID IS NOT NULL\n" +
                            "  AND MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2\n" +
                            "  AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35, 36, 60)\n" +
                            "  AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0\n" +
                            "  AND MOVIMENTACAO.CAD_MTMD_ID = PRODUTO.CAD_MTMD_ID\n" +
                            "  AND MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID = @PROTOCOLO_ID\n" +
                            "  AND MOVIMENTACAO.ATD_ATE_ID = @ATD_ATE_ID\n" +
                            "  AND MOVIMENTACAO.CAD_SET_ID = @CAD_SET_ID\n" +
                            "  AND MOVIMENTACAO.MTMD_MOV_PROTOCOLO_DATA >= @DATA_DE AND TRUNC(MOVIMENTACAO.MTMD_MOV_PROTOCOLO_DATA) <= @DATA_ATE\n" +
                            "GROUP BY TRUNC(MOVIMENTACAO.MTMD_MOV_PROTOCOLO_DATA),\n" +
                            "         MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID\n" +
                            "ORDER BY MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID DESC";

            query = query.Replace("@ATD_ATE_ID", dto.IdtAtendimento.Value);
            query = query.Replace("@CAD_SET_ID", dto.IdtSetor.Value);

            if (idProtocolo != null)
                query = query.Replace("@PROTOCOLO_ID", idProtocolo.ToString());
            else
                query = query.Replace("AND MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID = @PROTOCOLO_ID\n", string.Empty);

            if (!dto.DataMovimento.Value.IsNull && !dto.DataAte.Value.IsNull)
            {
                query = query.Replace("@DATA_DE", "TO_DATE('" + DateTime.Parse(dto.DataMovimento.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')");
                query = query.Replace("@DATA_ATE", "TO_DATE('" + DateTime.Parse(dto.DataAte.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')");
            }
            else
                query = query.Replace("AND MOVIMENTACAO.MTMD_MOV_PROTOCOLO_DATA >= @DATA_DE AND TRUNC(MOVIMENTACAO.MTMD_MOV_PROTOCOLO_DATA) <= @DATA_ATE\n", string.Empty);

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterUltimoProtocolo()
        {
            DataTable result = new DataTable();
            string query = "SELECT NVL(MAX(MOVIMENTACAO.MTMD_MOV_PROTOCOLO_ID),0)\n" +
                            "FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO";            

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public void AtualizarProtocolo(decimal idProtocolo, decimal idMovimento)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_MTMD_MOV_MOVIMENTACAO SET MTMD_MOV_PROTOCOLO_ID = " + idProtocolo 
                         + ", MTMD_MOV_PROTOCOLO_DATA = SYSDATE WHERE MTMD_MOV_ID = " + idMovimento;

            Connection.ExecuteCommand(query);
        }

        public void AtualizarEmpresaEmprestimo(decimal idEmpresa, decimal idMovimento)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_MTMD_MOV_MOVIMENTACAO SET CAD_MTMD_ID_EMP_EMPRESTIMO = " + idEmpresa
                         + " WHERE MTMD_MOV_ID = " + idMovimento;

            Connection.ExecuteCommand(query);
        }

        public void AtualizarKit(decimal idKit, decimal idMovimento)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_MTMD_MOV_MOVIMENTACAO SET CAD_MTMD_KIT_ID = " + idKit
                         + " WHERE MTMD_MOV_ID = " + idMovimento;

            Connection.ExecuteCommand(query);
        }

        public void MarcarEstornoMovimento(decimal idMovimento)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_MTMD_MOV_MOVIMENTACAO SET MTMD_MOV_FL_ESTORNO = 1 " +
                            "WHERE MTMD_MOV_ID = " + idMovimento + " OR MTMD_MOV_ID_REF = " + idMovimento;

            Connection.ExecuteCommand(query);
        }

        public decimal ObterSaidasMensalSetor(MovimentacaoDTO dto)
        {
            DataTable result = new DataTable();
            string query = "SELECT NVL(SUM(MOV.MTMD_MOV_QTDE),0)\n" +
                    "           FROM TB_MTMD_MOV_MOVIMENTACAO       MOV,\n" +
                    "                TB_CAD_MTMD_SUBTP_MOVIMENTACAO TIP\n" +
                    "          WHERE MOV.MTMD_MOV_DATA >= @DATA_DE\n" +
                    "          AND   MOV.MTMD_MOV_DATA <= @DATA_ATE\n" +
                    "          AND   MOV.CAD_MTMD_ID         = @CAD_MTMD_ID\n" +
                    "          AND   MOV.CAD_MTMD_FILIAL_ID  = @CAD_MTMD_FILIAL_ID\n" +
                    "          AND   MOV.CAD_UNI_ID_UNIDADE  = @CAD_UNI_ID_UNIDADE\n" +
                    "          AND   MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO = @CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                    "          AND   MOV.CAD_SET_ID          = @CAD_SET_ID\n" +
                    "          AND   TIP.CAD_MTMD_TPMOV_ID   = MOV.CAD_MTMD_TPMOV_ID\n" +
                    "          AND   TIP.CAD_MTMD_SUBTP_ID   = MOV.CAD_MTMD_SUBTP_ID\n" +                    
                    "          AND   MOV.CAD_MTMD_TPMOV_ID = 2\n" +
                    "          AND   MOV.CAD_MTMD_SUBTP_ID NOT IN (14,17,20,26,27,28,34,35,36,37,38)\n" +
                    "          AND   MOV.MTMD_MOV_FL_ESTORNO = 0";

            query = query.Replace("@CAD_MTMD_ID", dto.IdtProduto.Value);
            query = query.Replace("@CAD_UNI_ID_UNIDADE", dto.IdtUnidade.Value);
            query = query.Replace("@CAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.Value);
            query = query.Replace("@CAD_SET_ID", dto.IdtSetor.Value);
            query = query.Replace("@CAD_MTMD_FILIAL_ID", dto.IdtFilial.Value);
            query = query.Replace("@DATA_DE", "TO_DATE('" + DateTime.Parse(dto.DataMovimento.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy')");
            query = query.Replace("@DATA_ATE", "TO_DATE('" + DateTime.Parse(dto.DataAte.Value.ToString()).ToString("ddMMyyyy HHmmss") + "','ddMMyyyy HH24MISS')");

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return decimal.Parse(result.Rows[0][0].ToString()) / int.Parse(DateTime.Parse(dto.DataAte.Value.ToString()).ToString("dd"));
        }

        public decimal ObterQtdLoteDispensado(MovimentacaoDTO dto)
        {
            DataTable result = new DataTable();
            string query = "SELECT NVL(SUM(MOV.MTMD_MOV_QTDE),0)\n" +
                           "  FROM TB_MTMD_MOV_MOVIMENTACAO MOV\n" +
                           " WHERE MOV.CAD_MTMD_ID = @CAD_MTMD_ID AND\n" +
                           "       MOV.MTMD_COD_LOTE = @MTMD_COD_LOTE AND\n" +
                           "       MOV.CAD_MTMD_FILIAL_ID = @CAD_MTMD_FILIAL_ID AND\n" +
                           "       MOV.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                           "       MOV.CAD_MTMD_SUBTP_ID IN (5,8,10,22,68) AND\n" +
                           "       MOV.MTMD_MOV_FL_ESTORNO = 0";

            query = query.Replace("@CAD_MTMD_ID", dto.IdtProduto.Value);
            query = query.Replace("@MTMD_COD_LOTE", dto.CodLote.Value);
            query = query.Replace("@CAD_MTMD_FILIAL_ID", dto.IdtFilial.Value);            

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);
            return decimal.Parse(result.Rows[0][0].ToString());
        }

        public decimal ObterIdMovimentoBaixaAutoDispensaPaciente(MovimentacaoDTO dto)
        {
            DataTable result = new DataTable();
            string query = "SELECT M.MTMD_MOV_ID\n" +
                                " FROM TB_MTMD_MOV_MOVIMENTACAO M\n" +
                                " WHERE M.CAD_MTMD_FILIAL_ID = 1 AND\n" +
                                "       M.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                                "       M.CAD_MTMD_SUBTP_ID = 60 AND\n" +
                                "       M.MTMD_REQ_ID = @MTMD_REQ_ID AND\n" +
                                "       M.CAD_MTMD_ID = @CAD_MTMD_ID AND\n" +
                                "       NVL(M.MTMD_LOTEST_ID,0) = NVL(@MTMD_LOTEST_ID,0) AND\n" +
                                "       M.MTMD_MOV_QTDE = @MTMD_MOV_QTDE AND\n" +
                                "       M.MTMD_MOV_FL_ESTORNO = 0 AND ROWNUM = 1";

            query = query.Replace("@MTMD_REQ_ID", dto.IdtRequisicao.Value);
            query = query.Replace("@CAD_MTMD_ID", dto.IdtProduto.Value);
            if (dto.IdtLote.Value.IsNull) dto.IdtLote.Value = 0;
            query = query.Replace("@MTMD_LOTEST_ID", dto.IdtLote.Value);
            query = query.Replace("@MTMD_MOV_QTDE", dto.Qtde.Value);

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);
            if (result.Rows.Count > 0)
                return decimal.Parse(result.Rows[0][0].ToString());
            else
                return 0;
        }

        public decimal ObterIdMovimentoEnvioFaturamento(MovimentacaoDTO dto)
        {
            DataTable result = new DataTable();
            string query = "SELECT M.MTMD_MOV_ID\n" +
                                " FROM TB_MTMD_MOV_MOVIMENTACAO M\n" +
                                " WHERE M.CAD_MTMD_FILIAL_ID = 1 AND\n" +
                                "       M.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                                "       M.CAD_MTMD_SUBTP_ID = 66 AND\n" +
                                "       M.MTMD_REQ_ID = @MTMD_REQ_ID AND\n" +
                                "       M.CAD_MTMD_ID = @CAD_MTMD_ID AND\n" +
                                "       M.MTMD_MOV_QTDE = @MTMD_MOV_QTDE AND\n" +
                                "       M.MTMD_MOV_FL_ESTORNO = 0 AND ROWNUM = 1";

            query = query.Replace("@MTMD_REQ_ID", dto.IdtRequisicao.Value);
            query = query.Replace("@CAD_MTMD_ID", dto.IdtProduto.Value);
            query = query.Replace("@MTMD_MOV_QTDE", dto.Qtde.Value);

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);
            if (result.Rows.Count > 0)
                return decimal.Parse(result.Rows[0][0].ToString());
            else
                return 0;
        }

        public MovimentacaoDataTable ObterCentroDispMovimentoPedido(MovimentacaoDTO dto)
        {
            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string strSubTpsMovs = "5,8,10,22,68";
            string query = "SELECT M.CAD_UNI_ID_UNIDADE,M.CAD_LAT_ID_LOCAL_ATENDIMENTO,M.CAD_SET_ID\n" +
                                " FROM TB_MTMD_MOV_MOVIMENTACAO M\n" +
                                " WHERE M.CAD_MTMD_FILIAL_ID = 1 AND\n" +
                                "       M.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                                "       M.CAD_MTMD_SUBTP_ID IN (" + strSubTpsMovs + ") AND\n" +
                                "       M.MTMD_REQ_ID = @MTMD_REQ_ID AND\n" +
                                "       M.CAD_MTMD_ID = @CAD_MTMD_ID AND\n" +                                
                                "       M.MTMD_MOV_QTDE > 0 AND\n" +
                                "       M.MTMD_MOV_FL_ESTORNO = 0 AND ROWNUM = 1";

            query = query.Replace("@MTMD_REQ_ID", dto.IdtRequisicao.Value);
            query = query.Replace("@CAD_MTMD_ID", dto.IdtProduto.Value);

            if (!dto.IdtLote.Value.IsNull)
            {
                query += " AND M.MTMD_LOTEST_ID = @MTMD_LOTEST_ID ";
                query = query.Replace("@MTMD_LOTEST_ID", dto.IdtLote.Value);
            }

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);
            return result;
        }

        public KitDataTable ObterKitsConsumidosPaciente(MovimentacaoDTO dto)
        {
            KitDataTable result = new KitDataTable();
            string query = "SELECT DISTINCT M.CAD_MTMD_KIT_ID, K.CAD_MTMD_KIT_DSC\n" +
                            "  FROM TB_MTMD_MOV_MOVIMENTACAO M JOIN\n" +
                            "       TB_CAD_MTMD_KIT K ON K.CAD_MTMD_KIT_ID = M.CAD_MTMD_KIT_ID\n" +
                            "WHERE M.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                            "      M.MTMD_MOV_FL_ESTORNO = 0 AND\n" +
                            "      M.CAD_SET_ID = @CAD_SET_ID AND\n" +
                            "      M.ATD_ATE_ID = @ATD_ATE_ID\n" +
                            "ORDER BY K.CAD_MTMD_KIT_DSC";

            query = query.Replace("@CAD_SET_ID", dto.IdtSetor.Value);
            query = query.Replace("@ATD_ATE_ID", dto.IdtAtendimento.Value);

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterEntradasCentroDispPedido(MovimentacaoDTO dto)
        {
            DataTable result = new DataTable();
            //PERCORRER MOVIMENTACOES DE ENTRADA DO CENTRO DE DISPENSACAO PARA ENCONTRAR LOTES E DAR ENTRADA
            string query = "SELECT DECODE(MOV.MTMD_COD_LOTE,NULL,NULL,MOV.MTMD_LOTEST_ID) MTMD_LOTEST_ID,\n" +
                           "       NVL(MOV.MTMD_COD_LOTE,'SEM_LOTE') MTMD_COD_LOTE, NVL(SUM(MOV.MTMD_MOV_QTDE),0) MTMD_MOV_QTDE,\n" +                           
                           //"       (SUM(MOV.MTMD_MOV_QTDE) -\n" +
                           //"       (SELECT NVL(SUM(MOV_EST.MTMD_MOV_QTDE),0)\n" +
                           //"          FROM TB_MTMD_MOV_MOVIMENTACAO MOV_EST\n" +
                           //"          WHERE MOV_EST.CAD_MTMD_ID = MOV.CAD_MTMD_ID AND\n" +
                           //"                MOV_EST.CAD_MTMD_FILIAL_ID = MOV.CAD_MTMD_FILIAL_ID AND\n" +
                           //"                MOV_EST.MTMD_REQ_ID = MOV.MTMD_REQ_ID AND\n" +
                           //"                MOV_EST.CAD_MTMD_TPMOV_ID = 1 AND\n" +
                           //"                MOV_EST.CAD_MTMD_SUBTP_ID = 23 AND --Estorno dispensacao\n" +
                           //"                MOV_EST.MTMD_MOV_FL_ESTORNO = 1 AND\n" +
                           //"                NVL(MOV_EST.MTMD_LOTEST_ID,0) = NVL(MOV.MTMD_LOTEST_ID,0))) MTMD_MOV_QTDE\n" +                           
                           "          (SELECT NVL(SUM(MOV_EST.MTMD_MOV_QTDE),0)\n" +
                           "             FROM TB_MTMD_MOV_MOVIMENTACAO MOV_EST\n" +
                           "            WHERE MOV_EST.CAD_MTMD_ID = MOV.CAD_MTMD_ID AND\n" +
                           "                  MOV_EST.CAD_MTMD_FILIAL_ID = MOV.CAD_MTMD_FILIAL_ID AND\n" +
                           "                  MOV_EST.MTMD_REQ_ID = MOV.MTMD_REQ_ID AND\n" +
                           "                  MOV_EST.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                           "                  MOV_EST.CAD_MTMD_SUBTP_ID = 3 AND --Transferido/Devolvido\n" +
                           "                  NVL(MOV_EST.MTMD_LOTEST_ID,0) = NVL(MOV.MTMD_LOTEST_ID,0)) MTMD_MOV_QTDE_DEV\n" +                            
                           "  FROM TB_MTMD_MOV_MOVIMENTACAO MOV\n" +
                           " WHERE MOV.CAD_MTMD_ID = @CAD_MTMD_ID AND\n" +
                           "       MOV.CAD_MTMD_FILIAL_ID = @CAD_MTMD_FILIAL_ID AND\n" +
                           "       MOV.MTMD_REQ_ID = @MTMD_REQ_ID AND\n" +
                           "       MOV.CAD_MTMD_TPMOV_ID = 1 AND\n" +
                           "       MOV.CAD_MTMD_SUBTP_ID IN (58,4,7,9) AND --Entradas de dispensacao/transf. pac.\n" +
                           "       MOV.MTMD_MOV_FL_ESTORNO = 0\n" +
                           "GROUP BY MOV.CAD_MTMD_ID, MOV.CAD_MTMD_FILIAL_ID, MOV.MTMD_REQ_ID, MOV.MTMD_LOTEST_ID, MOV.MTMD_COD_LOTE";

            query = query.Replace("@CAD_MTMD_ID", dto.IdtProduto.Value);
            query = query.Replace("@CAD_MTMD_FILIAL_ID", dto.IdtFilial.Value);
            query = query.Replace("@MTMD_REQ_ID", dto.IdtRequisicao.Value);            

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterSaidasCentroDispPedidoAnalitico(MovimentacaoDTO dto, bool blnUtiCompartilhada, bool blnFarmCentroCirurgico)
        {
            string filtros = string.Empty;
            string strSubTpsMovs = "5,8,10,22,68";
            DataTable result = new DataTable();

            if (!dto.IdtSetor.Value.IsNull)
                filtros += " AND REQ.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";

            if (!dto.IdtRequisicao.Value.IsNull)
                filtros += " AND MOV.MTMD_REQ_ID = " + dto.IdtRequisicao.Value.ToString() + "\n";
            else
                filtros += " AND REQ.MTMD_REQ_FL_STATUS IN (3,4,0,6)\n"; //Trazer apenas registro de pedidos já dispensados ou cancelados

            if (!dto.IdtAtendimento.Value.IsNull)
                filtros += " AND MOV.ATD_ATE_ID = " + dto.IdtAtendimento.Value.ToString() + "\n";

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND MOV.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + "\n";

            if (!dto.IdtLote.Value.IsNull)
                filtros += " AND MOV.MTMD_LOTEST_ID = " + dto.IdtLote.Value.ToString() + "\n";

            if (!dto.DataMovimento.Value.IsNull)
                filtros += " AND (MOV.MTMD_MOV_DATA >= TO_DATE('" + DateTime.Parse(dto.DataMovimento.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI')) " + "\n";

            if (blnUtiCompartilhada || blnFarmCentroCirurgico)
                strSubTpsMovs = ((byte)MovimentacaoDTO.SubTipoMovimento.BAIXA_CONS_DISP_AUTO_PACIENTE).ToString();
            
            string query = "SELECT MOV.*,\n" +
                            "       PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                            "       PROD.CAD_MTMD_FL_FRACIONA,\n" +
                            "       PROD.CAD_MTMD_FL_REUTILIZAVEL,\n" +
                            "       (SELECT NVL(LL.MTMD_NUM_LOTE_ALT, LL.MTMD_NUM_LOTE)\n" +
                            "          FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                            "         WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = MOV.MTMD_COD_LOTE AND\n" +
                            "               LL.CAD_MTMD_ID = MOV.CAD_MTMD_ID AND ROWNUM = 1) MTMD_NUM_LOTE,\n" +
                            "       REQ.CAD_MTMD_FILIAL_ID CAD_MTMD_FILIAL_ID_REQ,\n" +
                            "       DECODE(REQ.CAD_MTMD_FILIAL_ID,4,'CE','HAC') ESTOQUE_REQ,\n" +
                            "       REQ.CAD_UNI_ID_UNIDADE CAD_UNI_ID_UNIDADE_REQ,\n" +
                            "       REQ.CAD_LAT_ID_LOCAL_ATENDIMENTO CAD_LAT_ID_LOCAL_REQ,\n" +
                            "       REQ.CAD_SET_ID CAD_SET_ID_REQ,\n" +                            
                            "       UNI.CAD_UNI_DS_RESUMIDA UNIDADE_REQ,\n" +
                            "       SETOR.CAD_SET_DS_SETOR SETOR_REQ,\n" +
                            "       SETOR_DISP.CAD_SET_DS_SETOR CENTRO_DISP,\n" +
                            "       REQ.CAD_SET_SETOR_FARMACIA,\n" +
                            "       REQ.MTM_TIPO_REQUISICAO,\n" +
                            "       REQ.MTMD_REQ_FL_STATUS\n" +
                            "  FROM TB_MTMD_MOV_MOVIMENTACAO MOV JOIN\n" +
                            "       TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = MOV.MTMD_REQ_ID JOIN\n" +
                            "       TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = REQ.CAD_UNI_ID_UNIDADE JOIN\n" +
                            "       TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = REQ.CAD_SET_ID JOIN\n" +
                            "       TB_CAD_SET_SETOR SETOR_DISP ON SETOR_DISP.CAD_SET_ID = MOV.CAD_SET_ID JOIN\n" +
                            "       TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = MOV.CAD_MTMD_ID\n" +
                            " WHERE MOV.CAD_MTMD_FILIAL_ID = 1 AND\n" +                            
                            "       MOV.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                            "       MOV.CAD_MTMD_SUBTP_ID IN (" + strSubTpsMovs + ") AND --Baixas de dispensacao\n" +
                            "       MOV.MTMD_MOV_FL_ESTORNO = 0\n" + filtros +
                            "ORDER BY MOV.MTMD_REQ_ID DESC, MOV.CAD_MTMD_GRUPO_ID, PROD.CAD_MTMD_NOMEFANTASIA, MOV.MTMD_MOV_DATA DESC";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterEntradasPedidoProduto(MovimentacaoDTO dto)
        {
            string filtros = string.Empty;            
            DataTable result = new DataTable();

            if (!dto.IdtSetor.Value.IsNull)
                filtros += " AND MOV.CAD_SET_ID = " + dto.IdtSetor.Value.ToString() + "\n";

            if (!dto.IdtRequisicao.Value.IsNull)
                filtros += " AND MOV.MTMD_REQ_ID = " + dto.IdtRequisicao.Value.ToString() + "\n";            

            if (!dto.IdtProduto.Value.IsNull)
                filtros += " AND MOV.CAD_MTMD_ID = " + dto.IdtProduto.Value.ToString() + "\n";

            string query = "SELECT MOV.CAD_MTMD_GRUPO_ID, MOV.CAD_MTMD_ID, MOV.MTMD_LOTEST_ID,\n" +
                            "       PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                            "      (SELECT NVL(LL.MTMD_NUM_LOTE_ALT, LL.MTMD_NUM_LOTE)\n" +
                            "          FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                            "         WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = MOV.MTMD_COD_LOTE AND\n" +
                            "               LL.CAD_MTMD_ID = MOV.CAD_MTMD_ID AND ROWNUM = 1) MTMD_NUM_LOTE,\n" +
                            "       SUM(MOV.MTMD_MOV_QTDE) MTMD_MOV_QTDE\n" +
                            "FROM TB_MTMD_MOV_MOVIMENTACAO MOV JOIN\n" +
                            "     TB_MTMD_REQ_REQUISICAO REQ ON REQ.MTMD_REQ_ID = MOV.MTMD_REQ_ID JOIN\n" +
                            "     TB_CAD_MTMD_MAT_MED PROD ON PROD.CAD_MTMD_ID = MOV.CAD_MTMD_ID\n" +
                            "WHERE MOV.CAD_MTMD_FILIAL_ID = 1 AND\n" +
                            " MOV.CAD_MTMD_TPMOV_ID = 1 AND\n" +
                            " MOV.MTMD_MOV_FL_ESTORNO = 0\n" + filtros +
                            "GROUP BY MOV.CAD_MTMD_ID, MOV.MTMD_LOTEST_ID,\n" +
                            "         PROD.CAD_MTMD_NOMEFANTASIA,\n" +
                            "         MOV.MTMD_COD_LOTE,\n" +
                            "         MOV.CAD_MTMD_GRUPO_ID\n" +
                            "ORDER BY MOV.CAD_MTMD_GRUPO_ID, PROD.CAD_MTMD_NOMEFANTASIA";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public MovimentacaoDataTable RastrearLoteProduto(MovimentacaoDTO dto)
        {
            string filtros = string.Empty;            

            if (!dto.CodLote.Value.IsNull)
                filtros += " AND MOVIMENTACAO.MTMD_COD_LOTE = '" + dto.CodLote.Value.ToString() + "'\n";

            if (!dto.IdtAtendimento.Value.IsNull)
                filtros += " AND MOVIMENTACAO.ATD_ATE_ID = " + dto.IdtAtendimento.Value.ToString() + "\n";

            if (!dto.DataMovimento.Value.IsNull && !dto.DataAte.Value.IsNull)
            {
                filtros += " AND (MOVIMENTACAO.MTMD_MOV_DATA >= TO_DATE('" + DateTime.Parse(dto.DataMovimento.Value.ToString()).Date.ToString("ddMMyyyy") + "','ddMMyyyy') " +
                           " AND  MOVIMENTACAO.MTMD_MOV_DATA <= TO_DATE('" + DateTime.Parse(dto.DataAte.Value.ToString()).ToString("ddMMyyyy") + " 235959','ddMMyyyy HH24MISS'))\n";
            }

            string query =  "SELECT MOVIMENTACAO.MTMD_MOV_ID,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_FILIAL_ID,\n" +
                            "       DECODE(MOVIMENTACAO.CAD_MTMD_FILIAL_ID,4,'CE','HAC') ESTOQUE_FILIAL,\n" +
                            "       UNI.CAD_UNI_DS_RESUMIDA || ' - ' || SETOR.CAD_SET_CD_SETOR SETOR,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_ID,\n" +
                            "       MOVIMENTACAO.MTMD_LOTEST_ID,\n" +
                            "       MOVIMENTACAO.MTMD_REQ_ID,\n" +
                            "       MOVIMENTACAO.ATD_ATE_ID,\n" +
                            "       MOVIMENTACAO.ATD_ATE_TP_PACIENTE,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_TPMOV_ID,\n" +
                            "       MOVIMENTACAO.CAD_MTMD_SUBTP_ID,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_DATA,\n" +
                            "       DECODE(MOVIMENTACAO.CAD_MTMD_TPMOV_ID,1,'ENTRADA','SAIDA') TPMOV,\n" +
                            "       CASE\n" +
                            "             WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 1 THEN -- ENTRADA\n" +
                            "                CASE\n" +
                            "                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 2 THEN -- TRANSFERENCIA\n" +
                            "                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO||' '||\n" +
                            "                      ( SELECT SETOR.CAD_SET_DS_SETOR\n" +
                            "                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,\n" +
                            "                             TB_CAD_SET_SETOR       SETOR\n" +
                            "                        WHERE MTMD_MOV_ID                        = MOVIMENTACAO.MTMD_MOV_ID_REF\n" +
                            "                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID\n" +
                            "                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                            "                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE )\n" +
                            "                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 29 THEN\n" +
                            "                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO||': '||\n" +
                            "                      (SELECT SETOR_HORA FROM\n" +
                            "                       (SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR || ' ' || TO_CHAR(MOV.MTMD_MOV_DATA,'(DD/MM/YY HH24:MI:SS)') SETOR_HORA\n" +
                            "                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,\n" +
                            "                             TB_CAD_SET_SETOR       SETOR,\n" +
                            "                             TB_CAD_UNI_UNIDADE     UNI\n" +
                            "                        WHERE MOV.MTMD_MOV_ID_REF                    = MOVIMENTACAO.MTMD_MOV_ID_REF\n" +
                            "                        AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE\n" +
                            "                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID\n" +
                            "                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                            "                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE\n" +
                            "                        ORDER BY MOV.CAD_MTMD_TPMOV_ID DESC)\n" +
                            "                        WHERE ROWNUM = 1)\n" +
                            "                   ELSE\n" +
                            "                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO\n" +
                            "                 END\n" +
                            "             WHEN MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2 THEN -- SAIDA\n" +
                            "                CASE\n" +
                            "                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (5, 8, 10) THEN\n" +
                            "                      'DISPENSADO P/ '||\n" +
                            "                      ( SELECT SETOR.CAD_SET_DS_SETOR||' '||\n" +
                            "                               CASE\n" +
                            "                                  WHEN REQ.CAD_UNI_ID_UNIDADE != MOVIMENTACAO.CAD_UNI_ID_UNIDADE THEN\n" +
                            "                                     (SELECT UNI.CAD_UNI_DS_UNIDADE\n" +
                            "                                      FROM TB_CAD_UNI_UNIDADE UNI\n" +
                            "                                      WHERE UNI.CAD_UNI_ID_UNIDADE = REQ.CAD_UNI_ID_UNIDADE )\n" +
                            "                                  ELSE NULL\n" +
                            "                               END ||\n" +
                            "                               CASE\n" +
                            "                                  WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 5  THEN ' (AVULSO)'\n" +
                            "                                  WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 8  THEN ' (PADRAO)'\n" +
                            "                                  WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 10 THEN ' (PERSONALIZADO)'\n" +
                            "                               END\n" +
                            "                        FROM TB_MTMD_REQ_REQUISICAO REQ,\n" +
                            "                             TB_CAD_SET_SETOR       SETOR\n" +
                            "                        WHERE REQ.MTMD_REQ_ID                    = MOVIMENTACAO.MTMD_REQ_ID\n" +
                            "                        AND   SETOR.CAD_SET_ID                   = REQ.CAD_SET_ID\n" +
                            "                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = REQ.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                            "                        AND   SETOR.CAD_UNI_ID_UNIDADE           = REQ.CAD_UNI_ID_UNIDADE )\n" +
                            "                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 3 THEN -- TRANSFERENCIA\n" +
                            "                      SUBTP.CAD_MTMD_SUBTP_DESCRICAO||', DESTINO: '||\n" +
                            "                      ( SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR\n" +
                            "                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,\n" +
                            "                             TB_CAD_SET_SETOR       SETOR,\n" +
                            "                             TB_CAD_UNI_UNIDADE     UNI\n" +
                            "                        WHERE MTMD_MOV_ID                        = MOVIMENTACAO.MTMD_MOV_ID_REF\n" +
                            "                        AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE\n" +
                            "                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID\n" +
                            "                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                            "                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE )\n" +
                            "                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 19 THEN -- CONSUMO CENTRO CUSTO\n" +
                            "                      'BAIXA CENT. CUSTO, DESTINO: '||\n" +
                            "                      (SELECT SETOR FROM\n" +
                            "                       (SELECT UNI.CAD_UNI_DS_RESUMIDA || '/' || SETOR.CAD_SET_CD_SETOR ||' '||\n" +
                            "                               (DECODE(MOV.CAD_MTMD_SUBTP_ID,28,' (HOME CARE)','')) SETOR\n" +
                            "                        FROM TB_MTMD_MOV_MOVIMENTACAO MOV,\n" +
                            "                             TB_CAD_SET_SETOR       SETOR,\n" +
                            "                             TB_CAD_UNI_UNIDADE     UNI\n" +
                            "                        WHERE ((MOV.MTMD_MOV_FL_ESTORNO = 1 AND MOV.MTMD_MOV_ID_REF = MOVIMENTACAO.MTMD_MOV_ID) OR\n" +
                            "                               (MOV.MTMD_MOV_FL_ESTORNO = 0 AND MOV.MTMD_MOV_ID = MOVIMENTACAO.MTMD_MOV_ID_REF))\n" +
                            "                        AND   UNI.CAD_UNI_ID_UNIDADE             = MOV.CAD_UNI_ID_UNIDADE\n" +
                            "                        AND   SETOR.CAD_SET_ID                   = MOV.CAD_SET_ID\n" +
                            "                        AND   SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO = MOV.CAD_LAT_ID_LOCAL_ATENDIMENTO\n" +
                            "                        AND   SETOR.CAD_UNI_ID_UNIDADE           = MOV.CAD_UNI_ID_UNIDADE\n" +
                            "                        ORDER BY MOV.CAD_MTMD_TPMOV_ID DESC)\n" +
                            "                        WHERE ROWNUM = 1)\n" +
                            "                   WHEN MOVIMENTACAO.CAD_MTMD_SUBTP_ID = 27 THEN\n" +
                            "                      'DESPESA CENT. CUSTO '\n" +
                            "                   ELSE\n" +
                            "                     SUBTP.CAD_MTMD_SUBTP_DESCRICAO\n" +
                            "                END\n" +
                            "       END CAD_MTMD_SUBTP_DESCRICAO,\n" +
                            "       PRODUTO.CAD_MTMD_UNIDADE_VENDA,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_QTDE,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_ESTOQUE_ATUAL,\n" +
                            "       MOVIMENTACAO.MTMD_COD_LOTE,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_TOTAL,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_SALDO_LOTE_SETOR,\n" +
                            "       MOVIMENTACAO.MTMD_MOV_FL_ESTORNO,\n" +
                            "       USU_MOV.SEG_USU_DS_NOME DS_USUARIO\n" +
                            "FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO JOIN\n" +
                            "     TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = MOVIMENTACAO.CAD_SET_ID JOIN\n" +
                            "     TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = SETOR.CAD_UNI_ID_UNIDADE JOIN\n" +
                            "     TB_CAD_MTMD_MAT_MED PRODUTO ON MOVIMENTACAO.CAD_MTMD_ID = PRODUTO.CAD_MTMD_ID JOIN\n" +
                            "     TB_CAD_MTMD_SUBTP_MOVIMENTACAO SUBTP ON SUBTP.CAD_MTMD_SUBTP_ID = MOVIMENTACAO.CAD_MTMD_SUBTP_ID LEFT JOIN\n" +
                            "     TB_SEG_USU_USUARIO USU_MOV ON MOVIMENTACAO.SEG_USU_ID_USUARIO = USU_MOV.SEG_USU_ID_USUARIO\n" +
                            "WHERE MOVIMENTACAO.CAD_MTMD_ID   = @CAD_MTMD_ID\n" +
                            //"AND   MOVIMENTACAO.MTMD_COD_LOTE = '@MTMD_COD_LOTE'\n" +
                            "AND   SUBTP.CAD_MTMD_FL_INFORMATIVO = 0\n" + filtros +
                            "ORDER BY MOVIMENTACAO.MTMD_MOV_ID";

            query = query.Replace("@CAD_MTMD_ID", dto.IdtProduto.Value);
            //query = query.Replace("@MTMD_COD_LOTE", dto.CodLote.Value);

            MovimentacaoDataTable result = new MovimentacaoDataTable();            
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public bool TemParcelaFaturamento(decimal atendimento, DateTime? dtParcela)
        {
            string filtros = string.Empty;
            
            if (dtParcela != null)
            {
                filtros += " AND CCP.FAT_CCP_DT_PARCELA >= TO_DATE('" + dtParcela.Value.ToString("ddMMyyyy") + "','ddMMyyyy') ";
            }

            string query = "SELECT CCP.FAT_CCP_DT_PARCELA\n" +
                           "FROM TB_FAT_CCP_CONTA_CONS_PARC CCP\n" +
                           "WHERE CCP.ATD_ATE_ID IN (@ATD_ATE_ID)" + filtros;

            query = query.Replace("@ATD_ATE_ID", atendimento.ToString());

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            Connection.RecordSet(query, result, CommandType.Text);

            return result.Rows.Count > 0 ? true : false;
        }

        /// <summary>
        /// RotinaExclusaoFaturamento (SCRIPT)
        /// </summary>
        /// <param name="seqPaciente">ID da CCI</param>
        public void RotinaExclusaoFaturamento(int seqPaciente)
        {
            string sqlString =  "DECLARE\n" +
                                "IDCOM NUMBER;\n" +
                                "BEGIN\n" +
                                "  SELECT FAT_MCC_ID\n" +
                                "    INTO IDCOM\n" +
                                "    FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI\n" +
                                "   WHERE CCI.FAT_CCI_ID = " + seqPaciente + ";\n" +
                                "\n" +
                                "  UPDATE TB_MTMD_MOV_MOVIMENTACAO SET SEQ_PACIENTE = NULL WHERE SEQ_PACIENTE = " + seqPaciente + ";\n" +
                                "  DELETE TB_FAT_CCI_CONTA_CONSU_ITEM CCI WHERE CCI.FAT_CCI_ID = " + seqPaciente + ";\n" +
                                "\n" +
                                "  PRC_FAT_MCC_ATUALIZAR_VL_TOTAL(IDCOM);\n" +
                                "EXCEPTION WHEN NO_DATA_FOUND THEN\n" +
                                "  NULL;\n" +
                                "END;";

            Connection.ExecuteCommand(sqlString);
        }

        public void ExcluirAssFatMov(MovimentacaoDTO dto)
        {
            string filtros = string.Empty;

            if (!dto.DataMovimento.Value.IsNull && !dto.DataAte.Value.IsNull)
            {
                filtros += " AND (M.MTMD_MOV_DATA >= TO_DATE('" + DateTime.Parse(dto.DataMovimento.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MI') " +
                           " AND  M.MTMD_MOV_DATA <= TO_DATE('" + DateTime.Parse(dto.DataAte.Value.ToString()).ToString("ddMMyyyy HHmm") + "','ddMMyyyy HH24MISS'))\n";
            }

            string query = "UPDATE TB_MTMD_MOV_MOVIMENTACAO M\n" +
                           "   SET M.SEQ_PACIENTE = NULL\n" +
                           "WHERE ATD_ATE_ID IN (@ATD_ATE_ID) AND\n" +
                           "      M.MTMD_MOV_FL_ESTORNO = 0 AND\n" +
                           "      M.SEQ_PACIENTE IS NOT NULL AND\n" +
                           "      M.CAD_MTMD_TPMOV_ID = 2 AND\n" +
                           "      M.CAD_MTMD_SUBTP_ID IN (11,14,25,26,60)" + filtros;

            query = query.Replace("@ATD_ATE_ID", dto.IdtAtendimento.Value);

            Connection.ExecuteCommand(query);
        }

        public DataTable RelatorioConsumoGrupoMercado(string periodo)
        {
            string sqlString = "";

            if (periodo == "1")
            {
                sqlString = "SELECT TO_CHAR(MOV.MTMD_MOV_DATA,'YYYY/MM') ANO_MES,\n" +
               "       DECODE(CGC.CAD_CGC_DS_DESCRICAO,'EXTRA GRUPO','MERCADO',CGC.CAD_CGC_DS_DESCRICAO) TP ,\n" +
               "       SUM(MOV.MTMD_MOV_QTDE*MOV.MTMD_CUSTO_MEDIO) VALOR\n" +
               "   FROM TB_MTMD_MOV_MOVIMENTACAO MOV JOIN\n" +
               "        TB_CAD_MTMD_SUBTP_MOVIMENTACAO TIP ON TIP.CAD_MTMD_TPMOV_ID = MOV.CAD_MTMD_TPMOV_ID AND TIP.CAD_MTMD_SUBTP_ID = MOV.CAD_MTMD_SUBTP_ID JOIN\n" +
               "        TB_CAD_MTMD_MAT_MED MM ON MM.CAD_MTMD_ID = MOV.CAD_MTMD_ID JOIN\n" +
               "        TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = MOV.ATD_ATE_ID JOIN\n" +
               "        TB_CAD_CNV_CONVENIO CNV ON PAT.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO JOIN\n" +
               "        TB_CAD_CGC_CLASSIF_GRUPO_CONV CGC ON CGC.CAD_CGC_ID = CNV.CAD_CGC_ID\n" +
               "  WHERE MOV.MTMD_MOV_DATA >= TO_DATE('01' || TO_CHAR(SYSDATE,'/MM/YYYY'),'DD/MM/YYYY')\n" +
               "  AND   MOV.CAD_MTMD_FILIAL_ID  IN (1,4)\n" +
               "  AND   MOV.CAD_MTMD_TPMOV_ID = 2\n" +
               "  AND   MOV.CAD_MTMD_SUBTP_ID NOT IN (1,15)\n" +
               "  AND   TIP.CAD_MTMD_FL_CONSUMO = 1\n" +
               "  AND   MOV.MTMD_MOV_FL_ESTORNO = 0\n" +
               "  AND   MM.CAD_MTMD_GRUPO_ID = 1\n" +
               "  AND   MOV.ATD_ATE_ID IS NOT NULL\n" +
               "GROUP BY CGC.CAD_CGC_DS_DESCRICAO,\n" +
               "         TO_CHAR(MOV.MTMD_MOV_DATA,'YYYY/MM')\n" +
               "ORDER BY 1,2";
            }
            else if (periodo == "3")
            {
                sqlString = "SELECT TO_CHAR(MOV.MTMD_MOV_DATA,'YYYY/MM') ANO_MES,\n" +
               "       DECODE(CGC.CAD_CGC_DS_DESCRICAO,'EXTRA GRUPO','MERCADO',CGC.CAD_CGC_DS_DESCRICAO) TP ,\n" +
               "       SUM(MOV.MTMD_MOV_QTDE *\n" +
               "           (SELECT nvl(sum(e.MTMD_CUSTO_MEDIO_ATUAL),0)\n" +
               "             FROM TB_MTMD_MOV_ESTOQUE_DIA e\n" +
               "             WHERE MTMD_MOV_DATA = TO_DATE('01' || TO_CHAR(MOV.MTMD_MOV_DATA,'/MM/YYYY'),'DD/MM/YYYY')\n" +
               "             AND   CAD_MTMD_FILIAL_ID = 1\n" +
               "             AND   CAD_MTMD_ID = MOV.CAD_MTMD_ID\n" +
               "             AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33\n" +
               "             AND   CAD_UNI_ID_UNIDADE           = 244\n" +
               "             AND   CAD_SET_ID                   = 29\n" +
               "             AND   CAD_MTMD_TPMOV_ID            = 0\n" +
               "             AND   CAD_MTMD_SUBTP_ID            = 0)\n" +
               "       ) VALOR\n" +
               "   FROM TB_MTMD_MOV_MOVIMENTACAO MOV JOIN\n" +
               "        TB_CAD_MTMD_SUBTP_MOVIMENTACAO TIP ON TIP.CAD_MTMD_TPMOV_ID = MOV.CAD_MTMD_TPMOV_ID AND TIP.CAD_MTMD_SUBTP_ID = MOV.CAD_MTMD_SUBTP_ID JOIN\n" +
               "        TB_CAD_MTMD_MAT_MED MM ON MM.CAD_MTMD_ID = MOV.CAD_MTMD_ID JOIN\n" +
               "        TB_ASS_PAT_PACIEATEND PAT ON PAT.ATD_ATE_ID = MOV.ATD_ATE_ID JOIN\n" +
               "        TB_CAD_CNV_CONVENIO CNV ON PAT.CAD_CNV_ID_CONVENIO = CNV.CAD_CNV_ID_CONVENIO JOIN\n" +
               "        TB_CAD_CGC_CLASSIF_GRUPO_CONV CGC ON CGC.CAD_CGC_ID = CNV.CAD_CGC_ID\n" +
               "  WHERE MOV.MTMD_MOV_DATA >= TO_DATE('01' || TO_CHAR(ADD_MONTHS(SYSDATE, -3),'/MM/YYYY'),'DD/MM/YYYY')\n" +
               "  AND   MOV.MTMD_MOV_DATA <= TO_DATE(TO_CHAR(LAST_DAY(ADD_MONTHS(SYSDATE, -1)),'DD') || TO_CHAR(ADD_MONTHS(SYSDATE, -1),'/MM/YYYY') || ' 23:59:59','DD/MM/YYYY HH24:MI:SS')\n" +
               "  AND   MOV.CAD_MTMD_FILIAL_ID  IN (1,4)\n" +
               "  AND   MOV.CAD_MTMD_TPMOV_ID = 2\n" +
               "  AND   MOV.CAD_MTMD_SUBTP_ID NOT IN (1,15)\n" +
               "  AND   TIP.CAD_MTMD_FL_CONSUMO = 1\n" +
               "  AND   MOV.MTMD_MOV_FL_ESTORNO = 0\n" +
               "  AND   MM.CAD_MTMD_GRUPO_ID = 1\n" +
               "  AND   MOV.ATD_ATE_ID IS NOT NULL\n" +
               "GROUP BY CGC.CAD_CGC_DS_DESCRICAO,\n" +
               "         TO_CHAR(MOV.MTMD_MOV_DATA,'YYYY/MM')\n" +
               "ORDER BY 1,2";
            }
            
            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }

        public int ConverterQtdFracaoGotas(MovimentacaoDTO dto)
        {
            DataTable result = new DataTable();
            string sqlString = "select NVL(fnc_mtmd_converte_fracao(" + dto.TpFracao.Value + ",\n" +
                               "                                    " + dto.Qtde.Value + "),1)\n" +
                               "from dual";

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return int.Parse(result.Rows[0][0].ToString());
        }

        public void TransferirEstoqueMedicamentos(MovimentacaoDTO dto)
        {
            string queryExec = "DECLARE\n" +
                                "pNewIdt integer;\n" +
                                "nIdEntrada integer;\n" +
                                "io_cursor PKG_CURSOR.t_cursor;\n" +
                                "BEGIN\n" +
                                "   FOR X IN\n" +
                                "   (SELECT ESTLOCAL.CAD_MTMD_ID,\n" +
                                "            SETOR.CAD_UNI_ID_UNIDADE,\n" +
                                "            SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "            SETOR.CAD_SET_ID,\n" +
                                "            PRODUTO.CAD_MTMD_NOMEFANTASIA,\n" +
                                "            ESTLOCAL.MTMD_EST_QTDE,\n" +
                                "            ESTLOCAL.MTMD_COD_LOTE,\n" +
                                "            (SELECT LL.MTMD_LOTEST_ID\n" +
                                "               FROM TB_MTMD_LOTEST_LOTE_ESTOQUE LL\n" +
                                "              WHERE LL.CAD_MTMD_FILIAL_ID = 1 AND LL.MTMD_COD_LOTE = ESTLOCAL.MTMD_COD_LOTE AND\n" +
                                "                    LL.CAD_MTMD_ID        = ESTLOCAL.CAD_MTMD_ID AND ROWNUM = 1) MTMD_LOTEST_ID\n" +
                                "     FROM TB_MTMD_ESTOQUE_LOTE       ESTLOCAL,\n" +
                                "          TB_CAD_MTMD_MAT_MED        PRODUTO,\n" +
                                "          TB_CAD_UNI_UNIDADE         UNIDADE,\n" +
                                "          TB_CAD_SET_SETOR           SETOR,\n" +
                                "          TB_CAD_MTMD_FILIAL         FILIAL\n" +
                                "     WHERE SETOR.CAD_SET_ID            = @CAD_SET_ID_BAIXA\n" +
                                "     AND   ESTLOCAL.CAD_MTMD_FILIAL_ID = @CAD_MTMD_FILIAL_ID\n" +
                                "     AND   ESTLOCAL.CAD_MTMD_ID        = PRODUTO.CAD_MTMD_ID\n" +
                                "     AND   UNIDADE.CAD_UNI_ID_UNIDADE  = SETOR.CAD_UNI_ID_UNIDADE\n" +
                                "     AND   SETOR.CAD_SET_ID            = ESTLOCAL.CAD_SET_ID\n" +
                                "     AND   ESTLOCAL.CAD_MTMD_FILIAL_ID = FILIAL.CAD_MTMD_FILIAL_ID\n" +
                                "     AND   ESTLOCAL.MTMD_EST_QTDE > 0)\n" +
                                "   LOOP\n" +
                                "\n" +
                                "   BEGIN\n" +
                                "       PRC_MTMD_MOV_ENTRADA_UNIDADE( X.CAD_MTMD_ID,\n" +
                                "                                     X.MTMD_LOTEST_ID,\n" +
                                "                                     @CAD_MTMD_FILIAL_ID,\n" +
                                "                                     NULL,\n" +
                                "                                     @CAD_UNI_ID_UNIDADE,\n" +
                                "                                     @CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "                                     @CAD_SET_ID,\n" +
                                "                                     1,\n" +
                                "                                     2,\n" +
                                "                                     X.MTMD_EST_QTDE,\n" +
                                "                                     NULL,\n" +
                                "                                     NULL,\n" +
                                "                                     1,\n" +
                                "                                     @SEG_USU_ID_USUARIO,\n" +
                                "                                     NULL,\n" +
                                "                                     nIdEntrada);\n" +
                                "\n" +
                                "        PRC_MTMD_MOV_ESTOQUE_BAIXA(X.CAD_MTMD_ID,\n" +
                                "                                   NULL,\n" +
                                "                                   X.MTMD_LOTEST_ID,\n" +
                                "                                   @CAD_MTMD_FILIAL_ID,\n" +
                                "                                   X.CAD_UNI_ID_UNIDADE,\n" +
                                "                                   X.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "                                   X.CAD_SET_ID,\n" +
                                "                                   X.MTMD_EST_QTDE,\n" +
                                "                                   NULL,\n" +
                                "                                   NULL,\n" +
                                "                                   2,\n" +
                                "                                   3,\n" +
                                "                                   0,\n" +
                                "                                   @SEG_USU_ID_USUARIO,\n" +
                                "                                   NULL,\n" +
                                "                                   NULL,\n" +
                                "                                   pNewIdt);\n" +
                                "      EXCEPTION WHEN OTHERS THEN\n" +
                                "         RAISE_APPLICATION_ERROR(-20000,' ERRO '||SQLERRM);\n" +
                                "      END;\n" +
                                "\n" +
                                "      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET\n" +
                                "      MTMD_MOV_ID_REF = pNewIdt\n" +
                                "      WHERE MTMD_MOV_ID = nIdEntrada;\n" +
                                "\n" +
                                "      UPDATE TB_MTMD_MOV_MOVIMENTACAO s SET\n" +
                                "      MTMD_MOV_ID_REF = nIdEntrada\n" +
                                "      WHERE MTMD_MOV_ID = pNewIdt;\n" +
                                "\n" +
                                "   END LOOP;\n" +
                                "\n" +
                                "END;";
            
            queryExec = queryExec.Replace("@CAD_SET_ID_BAIXA", dto.IdtSetorBaixa.Value);
            queryExec = queryExec.Replace("@CAD_UNI_ID_UNIDADE", dto.IdtUnidade.Value);
            queryExec = queryExec.Replace("@CAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.Value);
            queryExec = queryExec.Replace("@CAD_SET_ID", dto.IdtSetor.Value);
            queryExec = queryExec.Replace("@CAD_MTMD_FILIAL_ID", dto.IdtFilial.Value);
            queryExec = queryExec.Replace("@SEG_USU_ID_USUARIO", dto.IdtUsuario.Value);

            Connection.ExecuteCommand(queryExec);
        }

        public void TransferirEstoqueMateriais(MovimentacaoDTO dto)
        {
            string queryExec = "DECLARE\n" +
                                "pNewIdt integer;\n" +
                                "nIdEntrada integer;\n" +
                                "io_cursor PKG_CURSOR.t_cursor;\n" +
                                "BEGIN\n" +
                                "   FOR X IN\n" +
                                "   (SELECT ESTLOCAL.CAD_MTMD_ID,\n" +
                                "            ESTLOCAL.CAD_UNI_ID_UNIDADE,\n" +
                                "            ESTLOCAL.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "            ESTLOCAL.CAD_SET_ID,\n" +
                                "            PRODUTO.CAD_MTMD_NOMEFANTASIA,\n" +
                                "            ESTLOCAL.MTMD_ESTLOC_QTDE,\n" +
                                "            MTMD_PEDPAD_QTDE\n" +
                                "     FROM TB_MTMD_ESTOQUE_LOCAL      ESTLOCAL,\n" +
                                "          TB_CAD_MTMD_MAT_MED        PRODUTO,\n" +
                                "          TB_CAD_UNI_UNIDADE         UNIDADE,\n" +
                                "          TB_CAD_SET_SETOR           SETOR,\n" +
                                "          TB_CAD_MTMD_FILIAL         FILIAL\n" +
                                "     WHERE SETOR.CAD_SET_ID            = @CAD_SET_ID_BAIXA\n" +
                                "     AND   ESTLOCAL.CAD_MTMD_FILIAL_ID = @CAD_MTMD_FILIAL_ID\n" +
                                "     AND   ESTLOCAL.CAD_MTMD_ID        = PRODUTO.CAD_MTMD_ID\n" +
                                "     AND   UNIDADE.CAD_UNI_ID_UNIDADE  = ESTLOCAL.CAD_UNI_ID_UNIDADE\n" +
                                "     AND   SETOR.CAD_SET_ID            = ESTLOCAL.CAD_SET_ID\n" +
                                "     AND   ESTLOCAL.CAD_MTMD_FILIAL_ID = FILIAL.CAD_MTMD_FILIAL_ID\n" +
                                "     AND   PRODUTO.CAD_MTMD_GRUPO_ID != 1\n" +
                                "     AND   ESTLOCAL.MTMD_ESTLOC_QTDE > 0\n" +
                                "   )\n" +
                                "   LOOP\n" +
                                "\n" +
                                "   BEGIN\n" +
                                "       PRC_MTMD_MOV_ENTRADA_UNIDADE( X.CAD_MTMD_ID,\n" +
                                "                                     NULL,\n" +
                                "                                     @CAD_MTMD_FILIAL_ID,\n" +
                                "                                     NULL,\n" +
                                "                                     @CAD_UNI_ID_UNIDADE,\n" +
                                "                                     @CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "                                     @CAD_SET_ID,\n" +
                                "                                     1,\n" +
                                "                                     2,\n" +
                                "                                     X.MTMD_ESTLOC_QTDE,\n" +
                                "                                     NULL,\n" +
                                "                                     NULL,\n" +
                                "                                     1,\n" +
                                "                                     @SEG_USU_ID_USUARIO,\n" +
                                "                                     NULL,\n" +
                                "                                     nIdEntrada);\n" +
                                "\n" +
                                "        PRC_MTMD_MOV_ESTOQUE_BAIXA(X.CAD_MTMD_ID,\n" +
                                "                                   NULL,\n" +
                                "                                   NULL,\n" +
                                "                                   @CAD_MTMD_FILIAL_ID,\n" +
                                "                                   X.CAD_UNI_ID_UNIDADE,\n" +
                                "                                   X.CAD_LAT_ID_LOCAL_ATENDIMENTO,\n" +
                                "                                   X.CAD_SET_ID,\n" +
                                "                                   X.MTMD_ESTLOC_QTDE,\n" +
                                "                                   NULL,\n" +
                                "                                   NULL,\n" +
                                "                                   2,\n" +
                                "                                   3,\n" +
                                "                                   0,\n" +
                                "                                   @SEG_USU_ID_USUARIO,\n" +
                                "                                   NULL,\n" +
                                "                                   NULL,\n" +
                                "                                   pNewIdt);\n" +
                                "      EXCEPTION WHEN OTHERS THEN\n" +
                                "         RAISE_APPLICATION_ERROR(-20000,' ERRO '||SQLERRM);\n" +
                                "      END;\n" +
                                "\n" +
                                "      UPDATE TB_MTMD_MOV_MOVIMENTACAO SET\n" +
                                "      MTMD_MOV_ID_REF = pNewIdt\n" +
                                "      WHERE MTMD_MOV_ID = nIdEntrada;\n" +
                                "\n" +
                                "      UPDATE TB_MTMD_MOV_MOVIMENTACAO s SET\n" +
                                "      MTMD_MOV_ID_REF = nIdEntrada\n" +
                                "      WHERE MTMD_MOV_ID = pNewIdt;\n" +
                                "\n" +
                                "   END LOOP;\n" +
                                "\n" +
                                "END;";

            queryExec = queryExec.Replace("@CAD_SET_ID_BAIXA", dto.IdtSetorBaixa.Value);
            queryExec = queryExec.Replace("@CAD_UNI_ID_UNIDADE", dto.IdtUnidade.Value);
            queryExec = queryExec.Replace("@CAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.Value);
            queryExec = queryExec.Replace("@CAD_SET_ID", dto.IdtSetor.Value);
            queryExec = queryExec.Replace("@CAD_MTMD_FILIAL_ID", dto.IdtFilial.Value);
            queryExec = queryExec.Replace("@SEG_USU_ID_USUARIO", dto.IdtUsuario.Value);

            Connection.ExecuteCommand(queryExec);
        }

        public bool ContaSalvaFaturamento(decimal atendimento)
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT COUNT(*) FROM SGS.TB_MTMD_MOV_MOVIMENTACAO M\n" +
                               " WHERE M.CAD_SET_ID = 61\n" +
                               "   AND M.CAD_MTMD_TPMOV_ID = 2\n" +
                               "   AND M.CAD_MTMD_SUBTP_ID IN (34)\n" +
                               "   AND M.ATD_ATE_ID = " + atendimento;

            //Executa o procedimento
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return int.Parse(result.Rows[0][0].ToString()) > 0 ? true : false;
        }
	}
}