
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class MovimentacaoMensal : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public MovimentacaoMensalDataTable Sel(MovimentacaoMensalDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

			//Parametro pMTMD_MOV_MES
			param.Add(Connection.CreateParameter("pMTMD_MOV_MES", dto.Mes.DBValue, ParameterDirection.Input, dto.Mes.DbType));

			//Parametro pMTMD_MOV_ANO
			param.Add(Connection.CreateParameter("pMTMD_MOV_ANO", dto.Ano.DBValue, ParameterDirection.Input, dto.Ano.DbType));

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

			#endregion	
			
			MovimentacaoMensalDataTable result = new MovimentacaoMensalDataTable();
			//string query = "PRC_MTMD_MOV_ESTOQUE_MES_S";
            string query = "PRC_MTMD_MOV_MES_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MovimentacaoMensalDTO SelChave(MovimentacaoMensalDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			// Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			// Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));
			
			// Parametro pCAD_MTMD_SUBTP_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.SubTipoMovimento.DBValue, ParameterDirection.Input, dto.SubTipoMovimento.DbType));
			
			// Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			// Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			// Parametro pMTMD_MOV_ANO
			param.Add(Connection.CreateParameter("pMTMD_MOV_ANO", dto.Ano.DBValue, ParameterDirection.Input, dto.Ano.DbType));
			
			// Parametro pMTMD_MOV_MES
			param.Add(Connection.CreateParameter("pMTMD_MOV_MES", dto.Mes.DBValue, ParameterDirection.Input, dto.Mes.DbType));
			
			// Parametro pMTMD_MOV_TIPO
			param.Add(Connection.CreateParameter("pMTMD_MOV_TIPO", dto.TipoMovimento.DBValue, ParameterDirection.Input, dto.TipoMovimento.DbType));
			
			
			#endregion	
			
			MovimentacaoMensalDataTable result = new MovimentacaoMensalDataTable();
			string query = "PRC_MTMD_MOV_ESTOQUE_MES_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(MovimentacaoMensalDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			// Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			// Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			// Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));
			
			// Parametro pCAD_MTMD_SUBTP_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.SubTipoMovimento.DBValue, ParameterDirection.Input, dto.SubTipoMovimento.DbType));
			
			// Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			// Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			// Parametro pMTMD_MOV_ANO
			param.Add(Connection.CreateParameter("pMTMD_MOV_ANO", dto.Ano.DBValue, ParameterDirection.Input, dto.Ano.DbType));
			
			// Parametro pMTMD_MOV_MES
			param.Add(Connection.CreateParameter("pMTMD_MOV_MES", dto.Mes.DBValue, ParameterDirection.Input, dto.Mes.DbType));
			
			// Parametro pMTMD_MOV_TIPO
			param.Add(Connection.CreateParameter("pMTMD_MOV_TIPO", dto.TipoMovimento.DBValue, ParameterDirection.Input, dto.TipoMovimento.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_MTMD_MOV_ESTOQUE_MES_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(MovimentacaoMensalDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			// param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			// param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_SET_ID
			// param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			//Parametro pMTMD_MOV_MES
			// param.Add(Connection.CreateParameter("pMTMD_MOV_MES", dto.Mes.DBValue, ParameterDirection.Input, dto.Mes.DbType));
			
			//Parametro pMTMD_MOV_ANO
			// param.Add(Connection.CreateParameter("pMTMD_MOV_ANO", dto.Ano.DBValue, ParameterDirection.Input, dto.Ano.DbType));
			
			//Parametro pMTMD_MOV_QTDE
			// param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
			
			//Parametro pMTMD_MOV_TIPO
			// param.Add(Connection.CreateParameter("pMTMD_MOV_TIPO", dto.TipoMovimento.DBValue, ParameterDirection.Input, dto.TipoMovimento.DbType));
			
			//Parametro pMTMD_CUSTO_MEDIO
			// param.Add(Connection.CreateParameter("pMTMD_CUSTO_MEDIO", dto.CustoMedio.DBValue, ParameterDirection.Input, dto.CustoMedio.DbType));
			
			//Parametro pMTMD_MOV_ESTOQUE_ATUAL
            // param.Add(Connection.CreateParameter("pMTMD_MOV_ESTOQUE_ATUAL", dto.SaldoAtual.DBValue, ParameterDirection.Input, dto.SaldoAtual.DbType));
			
			//Parametro pMTMD_MOV_ESTOQUE_ANTERIOR
            param.Add(Connection.CreateParameter("pMTMD_MOV_ESTOQUE_ANTERIOR", dto.SaldoAnterior.DBValue, ParameterDirection.Input, dto.SaldoAnterior.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pSEG_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_DT_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));
			
			//Parametro pMTMD_CUSTO_MEDIO_ANTERIOR
			param.Add(Connection.CreateParameter("pMTMD_CUSTO_MEDIO_ANTERIOR", dto.CustoMedioAnterior.DBValue, ParameterDirection.Input, dto.CustoMedioAnterior.DbType));
			
			//Parametro pMTMD_VALOR_TOTAL_MES
			param.Add(Connection.CreateParameter("pMTMD_VALOR_TOTAL_MES", dto.VlrTotalMes.DBValue, ParameterDirection.Input, dto.VlrTotalMes.DbType));
			
			//Parametro pCAD_MTMD_SUBTP_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.SubTipoMovimento.DBValue, ParameterDirection.Input, dto.SubTipoMovimento.DbType));
			
			//Parametro pMTMD_VALOR_TOTAL_ANTERIOR
			param.Add(Connection.CreateParameter("pMTMD_VALOR_TOTAL_ANTERIOR", dto.VlrTotalAnterior.DBValue, ParameterDirection.Input, dto.VlrTotalAnterior.DbType));
			
			#endregion	

			string query = "PRC_MTMD_MOV_ESTOQUE_MES_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(MovimentacaoMensalDTO dto)
		{			
			string query = "PRC_MTMD_MOV_ESTOQUE_MES_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			//Parametro pMTMD_MOV_MES
			param.Add(Connection.CreateParameter("pMTMD_MOV_MES", dto.Mes.DBValue, ParameterDirection.Input, dto.Mes.DbType));
			
			//Parametro pMTMD_MOV_ANO
			param.Add(Connection.CreateParameter("pMTMD_MOV_ANO", dto.Ano.DBValue, ParameterDirection.Input, dto.Ano.DbType));
			
			//Parametro pMTMD_MOV_QTDE
			// param.Add(Connection.CreateParameter("pMTMD_MOV_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));
			
			//Parametro pMTMD_MOV_TIPO
			param.Add(Connection.CreateParameter("pMTMD_MOV_TIPO", dto.TipoMovimento.DBValue, ParameterDirection.Input, dto.TipoMovimento.DbType));
			
			//Parametro pMTMD_CUSTO_MEDIO
			param.Add(Connection.CreateParameter("pMTMD_CUSTO_MEDIO", dto.CustoMedio.DBValue, ParameterDirection.Input, dto.CustoMedio.DbType));
			
			//Parametro pMTMD_MOV_ESTOQUE_ATUAL
            param.Add(Connection.CreateParameter("pMTMD_MOV_ESTOQUE_ATUAL", dto.SaldoAtual.DBValue, ParameterDirection.Input, dto.SaldoAtual.DbType));
			
			//Parametro pMTMD_MOV_ESTOQUE_ANTERIOR
            param.Add(Connection.CreateParameter("pMTMD_MOV_ESTOQUE_ANTERIOR", dto.SaldoAnterior.DBValue, ParameterDirection.Input, dto.SaldoAnterior.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pSEG_DT_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_DT_ATUALIZACAO", dto.DataAtualizacao.DBValue, ParameterDirection.Input, dto.DataAtualizacao.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));
			
			//Parametro pMTMD_CUSTO_MEDIO_ANTERIOR
			param.Add(Connection.CreateParameter("pMTMD_CUSTO_MEDIO_ANTERIOR", dto.CustoMedioAnterior.DBValue, ParameterDirection.Input, dto.CustoMedioAnterior.DbType));
			
			//Parametro pMTMD_VALOR_TOTAL_MES
			param.Add(Connection.CreateParameter("pMTMD_VALOR_TOTAL_MES", dto.VlrTotalMes.DBValue, ParameterDirection.Input, dto.VlrTotalMes.DbType));
			
			//Parametro pCAD_MTMD_SUBTP_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBTP_ID", dto.SubTipoMovimento.DBValue, ParameterDirection.Input, dto.SubTipoMovimento.DbType));
			
			//Parametro pMTMD_VALOR_TOTAL_ANTERIOR
			param.Add(Connection.CreateParameter("pMTMD_VALOR_TOTAL_ANTERIOR", dto.VlrTotalAnterior.DBValue, ParameterDirection.Input, dto.VlrTotalAnterior.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	

        /// <summary>
        /// Calcula Indice de rotatividade do produto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public MovimentacaoMensalDTO ObtemIndiceRotatividade(MovimentacaoMensalDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            // param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            // param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            // param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            // param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pMTMD_MOV_MES
            param.Add(Connection.CreateParameter("pMTMD_MOV_MES", dto.Mes.DBValue, ParameterDirection.Input, dto.Mes.DbType));

            //Parametro pMTMD_MOV_ANO
            param.Add(Connection.CreateParameter("pMTMD_MOV_ANO", dto.Ano.DBValue, ParameterDirection.Input, dto.Ano.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            // param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));

            //Parametro pCAD_MTMD_SUBGRUPO_ID
            // param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));

            //Parametro de retorno
            param.Add(Connection.CreateParameter("pNewIdt", dto.IndiceRotatividade.DBValue, ParameterDirection.Output, dto.IndiceRotatividade.DbType));

            // param.Add(Connection.CreateParameterSequence());
            #endregion	

            MovimentacaoMensalDataTable result = new MovimentacaoMensalDataTable();
            string query = "PRC_MTMD_MOV_ESTOQUE_MES_IR";
            

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.IndiceRotatividade.Value = Decimal.Parse(param["pNewIdt"].Value.ToString());

            return dto;
        }

        public DataTable ObterValoresMovProdutos(int ano, byte mes, byte filial)
        {
            DataTable result = new DataTable();
            string data1 = "01/" + mes.ToString().PadLeft(2, '0') + "/" + ano.ToString();
            string data2 = DateTime.Parse(data1).Date.AddMonths(1).AddDays(-1).ToString("ddMMyyyy");
            data1 = data1.Replace("/","");
            string query = string.Format(
            "SELECT MTMD.CAD_MTMD_ID PRODUTO_ID,\n" +
            "       MTMD.CAD_MTMD_NOMEFANTASIA PRODUTO_DESCRICAO,\n" +
            "       DIAP.CAD_MTMD_GRUPO_ID GRUPO_ID,\n" +
            "       DIAP.CAD_MTMD_SUBGRUPO_ID SUBGRUPO_ID,\n" +
            "       LINHA_ZERO.MTMD_SALDO_ANTERIOR             SALDO_ANTERIOR,\n" +
            "       LINHA_ZERO.MTMD_VALOR_ANTERIOR             VALOR_ANTERIOR,\n" +
            "       SUM(NVL(NOTAS.MTMD_QTDE_ENTRADA,0))        QTDE_ENTRADA_NF,\n" +
            "       SUM(NVL(NOTAS.MTMD_VALOR_ENTRADA,0))       VALOR_ENTRADA_NF,\n" +
            "       SUM( (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1) THEN DIAP.MTMD_QTDE_ENTRADA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "           ) QTDE_DEVOLUCAO,\n" +
            "       SUM( (CASE\n" +
            "             WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (1)) THEN DIAP.MTMD_VALOR_ENTRADA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "          ) VALOR_DEVOLUCAO,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "        )   QTDE_CONSUMO,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "          ) VALOR_CONSUMO,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "        )   QTDE_PERDA,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "          ) VALOR_PERDA,\n" +
            "       LINHA_ZERO.MTMD_SALDO_ATUAL                SALDO_ATUAL,\n" +
            "       LINHA_ZERO.MTMD_VALOR_ATUAL                VALOR_ATUAL\n" +
            "FROM TB_CAD_MTMD_MAT_MED MTMD,\n" +
            "     TB_MTMD_MOV_ESTOQUE_DIA DIAP,\n" +
            "     (\n" +
            "       SELECT *\n" +
            "       FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
            "       WHERE MTMD_MOV_DATA                = TO_DATE('{0}','ddMMyyyy')\n" +
            "       AND   CAD_MTMD_FILIAL_ID           = {2}\n" +
            "       AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33\n" +
            "       AND   CAD_UNI_ID_UNIDADE           = 244\n" +
            "       AND   CAD_SET_ID                   = 29\n" +
            "       AND   CAD_MTMD_TPMOV_ID            = 0\n" +
            "       AND   CAD_MTMD_SUBTP_ID            = 0\n" +
            "     ) LINHA_ZERO,\n" +
            "     (\n" +
            "       SELECT *\n" +
            "       FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
            "       WHERE CAD_MTMD_TPMOV_ID            = 1\n" +
            "       AND   CAD_MTMD_SUBTP_ID            = 1\n" +
            "       AND   MTMD_MOV_DATA >= TO_DATE('{0}','ddMMyyyy')\n" +
            "       AND   MTMD_MOV_DATA <= TO_DATE('{1}','ddMMyyyy')\n" +
            "       AND   CAD_MTMD_FILIAL_ID = {2}\n" +
            "     ) NOTAS\n" +
            "WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('{0}','ddMMyyyy')\n" +
            "AND   DIAP.MTMD_MOV_DATA <= TO_DATE('{1}','ddMMyyyy')\n" +
            "AND   DIAP.CAD_MTMD_FILIAL_ID             = {2}\n" +
            "AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)   = DIAP.CAD_MTMD_SUBGRUPO_ID\n" +
            "AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA\n" +
            "AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID\n" +
            "AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID\n" +
            "AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID\n" +
            "AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID\n" +
            "AND  NOTAS.CAD_MTMD_TPMOV_ID(+)   = DIAP.CAD_MTMD_TPMOV_ID\n" +
            "AND  NOTAS.CAD_MTMD_SUBTP_ID(+)   = DIAP.CAD_MTMD_SUBTP_ID\n" +
            "AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)\n" +
            "GROUP BY MTMD.CAD_MTMD_ID,\n" +
            "         DIAP.CAD_MTMD_FILIAL_ID,\n" +
            "         MTMD.CAD_MTMD_NOMEFANTASIA,\n" +
            "         LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,\n" +
            "         LINHA_ZERO.MTMD_SALDO_ATUAL,\n" +
            "         LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,\n" +
            "         LINHA_ZERO.MTMD_VALOR_ATUAL,\n" +
            "         LINHA_ZERO.MTMD_SALDO_ANTERIOR,\n" +
            "         LINHA_ZERO.MTMD_VALOR_ANTERIOR,\n" +
            "         DIAP.CAD_MTMD_GRUPO_ID,\n" +
            "         DIAP.CAD_MTMD_SUBGRUPO_ID\n" +
            "HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0)+ NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0\n" +
            "ORDER BY MTMD.CAD_MTMD_NOMEFANTASIA"
            , data1, data2, filial);
            
            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterValoresMovGrupo(int ano, byte mes, byte filial)
        {
            DataTable result = new DataTable();
            string data1 = "01/" + mes.ToString().PadLeft(2, '0') + "/" + ano.ToString();
            string data2 = DateTime.Parse(data1).Date.AddMonths(1).AddDays(-1).ToString("ddMMyyyy");
            data1 = data1.Replace("/", "");
            string query = string.Format(
            "SELECT EST_DIA.CAD_MTMD_GRUPO_ID GRUPO,\n" +
            "       GRUPO.CAD_MTMD_GRUPO_DESCRICAO GRUPO_DSC,\n" +
            "       SUBG.CAD_MTMD_SUBGRUPO_ID||' '||SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO SUBGRUPO_DESCRICAO,\n" +
            "       SUM(EST_DIA.MTMD_SALDO_ANTERIOR) QTD_ANTERIOR,\n" +
            "       SUM(EST_DIA.MTMD_VALOR_ANTERIOR) VLR_ANTERIOR,\n" +
            "       SUM(EST_DIA.MTMD_QTDE_ENTRADA )  QTD_ENTRADAS,\n" +
            "       SUM(EST_DIA.MTMD_VALOR_ENTRADA)  VLR_ENTRADA,\n" +
            "       SUM(EST_DIA.MTMD_QTDE_DEVOLUCAO) QTD_DEVOLUCAO,\n" +
            "       SUM(EST_DIA.MTMD_VLR_DEVOLUCAO)  VLR_DEVOLUCAO,\n" +
            "       SUM(EST_DIA.MTMD_QTDE_CONSUMO)   QTD_CONSUMOS,\n" +
            "       SUM(EST_DIA.MTMD_VALOR_CONSUMO)  VLR_CONSUMO,\n" +
            "       SUM(EST_DIA.MTMD_QTDE_PERDA)     QTD_PERDAS,\n" +
            "       SUM(EST_DIA.MTMD_VALOR_PERDA)    VLR_PERDA,\n" +
            "       SUM(EST_DIA.MTMD_SALDO_ATUAL)    SALDO_ATUAL,\n" +
            "       SUM(EST_DIA.MTMD_VALOR_ATUAL)    VLR_ATUAL\n" +
            "FROM\n" +
            "  (SELECT MTMD.CAD_MTMD_ID,\n" +
            "          DIAP.CAD_MTMD_GRUPO_ID,\n" +
            "          DIAP.CAD_MTMD_SUBGRUPO_ID,\n" +
            "       MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,\n" +
            "       (\n" +
            "          CASE\n" +
            "             WHEN LINHA_ZERO.MTMD_SALDO_ANTERIOR = 0 THEN 0\n" +
            "             ELSE LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR\n" +
            "          END\n" +
            "       )                                          MTMD_CUSTO_MEDIO_ANTERIOR,\n" +
            "       LINHA_ZERO.MTMD_SALDO_ANTERIOR             MTMD_SALDO_ANTERIOR,\n" +
            "       LINHA_ZERO.MTMD_VALOR_ANTERIOR             MTMD_VALOR_ANTERIOR,\n" +
            "       LINHA_ZERO.MTMD_SALDO_ATUAL                MTMD_SALDO_ATUAL,\n" +
            "       LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL          MTMD_CUSTO_MEDIO_ATUAL,\n" +
            "       LINHA_ZERO.MTMD_VALOR_ATUAL                MTMD_VALOR_ATUAL,\n" +
            "       SUM(NVL(NOTAS.MTMD_QTDE_ENTRADA,0))        MTMD_QTDE_ENTRADA,\n" +
            "       SUM(NVL(NOTAS.MTMD_VALOR_ENTRADA,0))       MTMD_VALOR_ENTRADA,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "        )   MTMD_QTDE_SAIDA,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15) THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "          ) MTMD_VALOR_SAIDA,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "        )   MTMD_QTDE_CONSUMO,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6) THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "          ) MTMD_VALOR_CONSUMO,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "        )   MTMD_QTDE_PERDA,\n" +
            "       SUM(\n" +
            "           (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID IN (6) THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "          ) MTMD_VALOR_PERDA,\n" +
            "       SUM( (CASE\n" +
            "             WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1) THEN DIAP.MTMD_QTDE_ENTRADA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "           ) MTMD_QTDE_DEVOLUCAO,\n" +
            "       SUM( (CASE\n" +
            "             WHEN (DIAP.CAD_MTMD_SUBTP_ID NOT IN (1)) THEN DIAP.MTMD_VALOR_ENTRADA\n" +
            "             ELSE 0\n" +
            "             END )\n" +
            "          ) MTMD_VLR_DEVOLUCAO\n" +
            "FROM TB_CAD_MTMD_MAT_MED MTMD,\n" +
            "     TB_MTMD_MOV_ESTOQUE_DIA DIAP,\n" +
            "     (\n" +
            "       SELECT *\n" +
            "       FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
            "       WHERE MTMD_MOV_DATA                = TO_DATE('{0}','DDMMYYYY')\n" +
            "       AND   CAD_MTMD_FILIAL_ID = {2}\n" +
            "       AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33\n" +
            "       AND   CAD_UNI_ID_UNIDADE           = 244\n" +
            "       AND   CAD_SET_ID                   = 29\n" +
            "       AND   CAD_MTMD_TPMOV_ID            = 0\n" +
            "       AND   CAD_MTMD_SUBTP_ID            = 0\n" +
            "     ) LINHA_ZERO,\n" +
            "     (\n" +
            "       SELECT *\n" +
            "       FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
            "       WHERE CAD_MTMD_TPMOV_ID            = 1\n" +
            "       AND   CAD_MTMD_SUBTP_ID            = 1\n" +
            "       AND   MTMD_MOV_DATA >= TO_DATE('{0}','DDMMYYYY')\n" +
            "       AND   MTMD_MOV_DATA <= TO_DATE('{1}','DDMMYYYY')\n" +
            "       AND   CAD_MTMD_FILIAL_ID = {2}\n" +
            "     ) NOTAS\n" +
            "WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('{0}','DDMMYYYY')\n" +
            "AND   DIAP.MTMD_MOV_DATA <= TO_DATE('{1}','DDMMYYYY')\n" +
            "AND   DIAP.CAD_MTMD_FILIAL_ID             = {2}\n" +
            "AND   MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_ID(+)               = DIAP.CAD_MTMD_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)        = DIAP.CAD_MTMD_FILIAL_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)         = DIAP.CAD_MTMD_GRUPO_ID\n" +
            "AND  LINHA_ZERO.CAD_MTMD_SUBGRUPO_ID(+)      = DIAP.CAD_MTMD_SUBGRUPO_ID\n" +
            "AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA\n" +
            "AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID\n" +
            "AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID\n" +
            "AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID\n" +
            "AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID\n" +
            "AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID\n" +
            "AND  NOTAS.CAD_MTMD_SUBTP_ID(+)       = DIAP.CAD_MTMD_SUBTP_ID\n" +
            "AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)\n" +
            "GROUP BY MTMD.CAD_MTMD_ID,\n" +
            "         DIAP.CAD_MTMD_FILIAL_ID,\n" +
            "         MTMD.CAD_MTMD_NOMEFANTASIA,\n" +
            "         LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,\n" +
            "         LINHA_ZERO.MTMD_SALDO_ATUAL,\n" +
            "         LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,\n" +
            "         LINHA_ZERO.MTMD_VALOR_ATUAL,\n" +
            "         LINHA_ZERO.MTMD_SALDO_ANTERIOR,\n" +
            "         LINHA_ZERO.MTMD_VALOR_ANTERIOR,\n" +
            "         DIAP.CAD_MTMD_GRUPO_ID,\n" +
            "         DIAP.CAD_MTMD_SUBGRUPO_ID\n" +
            "HAVING SUM(NVL(DIAP.MTMD_SALDO_ANTERIOR,0)+NVL(DIAP.MTMD_SALDO_ATUAL,0)+ NVL(DIAP.MTMD_QTDE_ENTRADA,0)+ NVL(DIAP.MTMD_QTDE_SAIDA,0) + NVL(LINHA_ZERO.MTMD_VALOR_ANTERIOR,0) ) > 0) EST_DIA,\n" +
            " TB_CAD_MTMD_GRUPO            GRUPO,\n" +
            " TB_CAD_MTMD_SUBGRUPO         SUBG\n" +
            "WHERE GRUPO.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID AND\n" +
            "      SUBG.CAD_MTMD_SUBGRUPO_ID (+)= EST_DIA.CAD_MTMD_SUBGRUPO_ID AND\n" +
            "      SUBG.CAD_MTMD_GRUPO_ID (+)= EST_DIA.CAD_MTMD_GRUPO_ID\n" +
            "GROUP BY EST_DIA.CAD_MTMD_GRUPO_ID,\n" +
            "         GRUPO.CAD_MTMD_GRUPO_DESCRICAO,\n" +
            "         EST_DIA.CAD_MTMD_SUBGRUPO_ID,\n" +
            "         SUBG.CAD_MTMD_SUBGRUPO_ID,\n" +
            "         SUBG.CAD_MTMD_SUBGRUPO_DESCRICAO\n" +
            "ORDER BY EST_DIA.CAD_MTMD_GRUPO_ID, EST_DIA.CAD_MTMD_SUBGRUPO_ID"
            , data1, data2, filial);

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterQtdsConsumoCCusto(int ano, byte mes, byte filial)
        {
            DataTable result = new DataTable();
            string data1 = "01/" + mes.ToString().PadLeft(2, '0') + "/" + ano.ToString();
            string data2 = DateTime.Parse(data1).Date.AddMonths(1).AddDays(-1).ToString("ddMMyyyy");
            data1 = data1.Replace("/", "");
            string query = string.Format(
            "SELECT UNI.CAD_UNI_DS_UNIDADE UNIDADE,\n" +
            "       CCUSTO.CAD_CEC_CD_CCUSTO CENTRO_CUSTO,\n" +
            "       CCUSTO.CAD_CEC_DS_CCUSTO CCUSTO_DESCRICAO,\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.MTMD_QTDE_SAIDA,0))   DROG_MED_QTD,    --1\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.MTMD_VALOR_SAIDA,0))   DROG_MED_VL,    --1\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.MTMD_QTDE_SAIDA,0))  PROTESE_QTD,     --61\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.MTMD_VALOR_SAIDA,0))  PROTESE_VL,     --61\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.MTMD_QTDE_SAIDA,0))   GEN_ALIMENT_QTD,    --4\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.MTMD_VALOR_SAIDA,0))   GEN_ALIMENT_VL,    --4\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.MTMD_QTDE_SAIDA,0))  COPA_QTD,        --11\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.MTMD_VALOR_SAIDA,0))  COPA_VL,        --11\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.MTMD_QTDE_SAIDA,0))   IMPRESSOS_QTD,      --5\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.MTMD_VALOR_SAIDA,0))   IMPRESSOS_VL,      --5\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.MTMD_QTDE_SAIDA,0))   MAT_MED_HOSP_QTD,--6\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.MTMD_VALOR_SAIDA,0))   MAT_MED_HOSP_VL,--6\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.MTMD_QTDE_SAIDA,0))  HIGIEN_QTD,      -- 12\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.MTMD_VALOR_SAIDA,0))  HIGIEN_VL,      -- 12\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.MTMD_QTDE_SAIDA,0))   MANUTEN_QTD,    -- 8\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.MTMD_VALOR_SAIDA,0))   MANUTEN_VL,    -- 8\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.MTMD_QTDE_SAIDA,0))   OLEO_QTD,       -- 9\n" +
            "       SUM(DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.MTMD_VALOR_SAIDA,0))   OLEO_VL,       -- 9\n" +
            "       SUM(\n" +
            "            CASE\n" +
            "               WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN\n" +
            "                  EST_DIA.MTMD_QTDE_SAIDA\n" +
            "               ELSE\n" +
            "                  0\n" +
            "            END\n" +
            "          ) OUTROS_QTD,\n" +
            "       SUM(\n" +
            "            CASE\n" +
            "               WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN\n" +
            "                  EST_DIA.MTMD_VALOR_SAIDA\n" +
            "               ELSE\n" +
            "                  0\n" +
            "            END\n" +
            "          ) OUTROS_VL,\n" +
            "       SUM(\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.MTMD_QTDE_SAIDA,0))+\n" +
            "          (\n" +
            "               CASE\n" +
            "                  WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN\n" +
            "                     EST_DIA.MTMD_QTDE_SAIDA\n" +
            "                  ELSE\n" +
            "                     0\n" +
            "               END\n" +
            "          )\n" +
            "       ) QTD_TOTAL,\n" +
            "       SUM(\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,1,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,61,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,4,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,11,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,5,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,6,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,12,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,8,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (DECODE(EST_DIA.CAD_MTMD_GRUPO_ID,9,EST_DIA.MTMD_VALOR_SAIDA,0))+\n" +
            "          (\n" +
            "               CASE\n" +
            "                  WHEN EST_DIA.CAD_MTMD_GRUPO_ID NOT IN (1,61,4,11,5,6,12,8,9) THEN\n" +
            "                     EST_DIA.MTMD_VALOR_SAIDA\n" +
            "                  ELSE\n" +
            "                     0\n" +
            "               END\n" +
            "          )\n" +
            "       ) VL_TOTAL\n" +
            "  FROM\n" +
            "  (\n" +
            "  SELECT EST_DIA.MTMD_MOV_DATA,\n" +
            "         EST_DIA.CAD_UNI_ID_UNIDADE,\n" +
            "         EST_DIA.CAD_SET_ID,\n" +
            "         EST_DIA.CAD_MTMD_GRUPO_ID,\n" +
            "         SUM(EST_DIA.MTMD_QTDE_SAIDA) MTMD_QTDE_SAIDA,\n" +
            "         SUM(EST_DIA.MTMD_VALOR_SAIDA) MTMD_VALOR_SAIDA\n" +
            "  FROM\n" +
            "  (SELECT DIAP.MTMD_MOV_DATA,\n" +
            "          DIAP.CAD_UNI_ID_UNIDADE,\n" +
            "          DIAP.CAD_SET_ID,\n" +
            "          DIAP.CAD_MTMD_GRUPO_ID,\n" +
            "          MTMD.CAD_MTMD_ID,\n" +
            "          MTMD.CAD_MTMD_NOMEFANTASIA DESCRICAO,\n" +
            "          SUM(\n" +
            "              (CASE\n" +
            "               WHEN (NVL(0,0) = 0 AND DIAP.CAD_MTMD_SUBTP_ID NOT IN (15))    THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "               WHEN (NVL(0,0) = 1 AND DIAP.CAD_MTMD_SUBTP_ID = 6)            THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "               WHEN (NVL(0,0) = 2 AND DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6)) THEN DIAP.MTMD_QTDE_SAIDA\n" +
            "               ELSE 0\n" +
            "               END )\n" +
            "             )-\n" +
            "          SUM((CASE\n" +
            "               WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1) THEN DIAP.MTMD_QTDE_ENTRADA\n" +
            "               ELSE 0\n" +
            "               END )\n" +
            "             )\n" +
            "          MTMD_QTDE_SAIDA,\n" +
            "          SUM(\n" +
            "              (CASE\n" +
            "               WHEN (NVL(0,0) = 0 AND DIAP.CAD_MTMD_SUBTP_ID NOT IN (15))    THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "               WHEN (NVL(0,0) = 1 AND DIAP.CAD_MTMD_SUBTP_ID = 6)            THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "               WHEN (NVL(0,0) = 2 AND DIAP.CAD_MTMD_SUBTP_ID NOT IN (15, 6)) THEN DIAP.MTMD_VALOR_SAIDA\n" +
            "               ELSE 0\n" +
            "               END )\n" +
            "             )-\n" +
            "          SUM((CASE\n" +
            "               WHEN DIAP.CAD_MTMD_SUBTP_ID NOT IN (1) THEN DIAP.MTMD_VALOR_ENTRADA\n" +
            "               ELSE 0\n" +
            "               END )\n" +
            "             )\n" +
            "          MTMD_VALOR_SAIDA\n" +
            "  FROM TB_CAD_MTMD_MAT_MED MTMD,\n" +
            "       TB_MTMD_MOV_ESTOQUE_DIA DIAP,\n" +
            "       (\n" +
            "         SELECT *\n" +
            "         FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
            "         WHERE MTMD_MOV_DATA                = TO_DATE('{0}','ddMMyyyy')\n" +
            "         AND   CAD_MTMD_FILIAL_ID = {2}\n" +
            "         AND   CAD_LAT_ID_LOCAL_ATENDIMENTO = 33\n" +
            "         AND   CAD_UNI_ID_UNIDADE           = 244\n" +
            "         AND   CAD_SET_ID                   = 29\n" +
            "         AND   CAD_MTMD_TPMOV_ID            = 0\n" +
            "         AND   CAD_MTMD_SUBTP_ID            = 0\n" +
            "       ) LINHA_ZERO,\n" +
            "       (\n" +
            "         SELECT *\n" +
            "         FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
            "         WHERE CAD_MTMD_TPMOV_ID            = 1\n" +
            "         AND   CAD_MTMD_SUBTP_ID            = 1\n" +
            "         AND   MTMD_MOV_DATA >= TO_DATE('{0}','ddMMyyyy')\n" +
            "         AND   MTMD_MOV_DATA <= TO_DATE('{1}','ddMMyyyy')\n" +
            "         AND   CAD_MTMD_FILIAL_ID = {2}\n" +
            "         AND   MTMD_VALOR_ENTRADA != 0\n" +
            "         AND   MTMD_QTDE_ENTRADA > 0\n" +
            "       ) NOTAS\n" +
            "  WHERE DIAP.MTMD_MOV_DATA >= TO_DATE('{0}','ddMMyyyy')\n" +
            "  AND   DIAP.MTMD_MOV_DATA <= TO_DATE('{1}','ddMMyyyy')\n" +
            "  AND   DIAP.CAD_MTMD_FILIAL_ID             = {2}\n" +
            "  AND  MTMD.CAD_MTMD_ID                    = DIAP.CAD_MTMD_ID\n" +
            "  AND  LINHA_ZERO.CAD_MTMD_ID(+)            = DIAP.CAD_MTMD_ID\n" +
            "  AND  LINHA_ZERO.CAD_MTMD_FILIAL_ID(+)     = DIAP.CAD_MTMD_FILIAL_ID\n" +
            "  AND  LINHA_ZERO.CAD_MTMD_GRUPO_ID(+)      = DIAP.CAD_MTMD_GRUPO_ID\n" +
            "  AND  NOTAS.MTMD_MOV_DATA(+)       = DIAP.MTMD_MOV_DATA\n" +
            "  AND  NOTAS.CAD_MTMD_ID(+)         = DIAP.CAD_MTMD_ID\n" +
            "  AND  NOTAS.CAD_MTMD_FILIAL_ID(+)  = DIAP.CAD_MTMD_FILIAL_ID\n" +
            "  AND  NOTAS.CAD_MTMD_GRUPO_ID(+)   = DIAP.CAD_MTMD_GRUPO_ID\n" +
            "  AND  NOTAS.CAD_MTMD_SUBGRUPO_ID(+) = DIAP.CAD_MTMD_SUBGRUPO_ID\n" +
            "  AND  NOTAS.CAD_MTMD_TPMOV_ID(+)       = DIAP.CAD_MTMD_TPMOV_ID\n" +
            "  AND  DIAP.CAD_MTMD_GRUPO_ID NOT IN (40,42)\n" +
            "  GROUP BY DIAP.MTMD_MOV_DATA,\n" +
            "           DIAP.CAD_UNI_ID_UNIDADE,\n" +
            "           DIAP.CAD_SET_ID,\n" +
            "           DIAP.CAD_MTMD_GRUPO_ID,\n" +
            "           MTMD.CAD_MTMD_ID,\n" +
            "           DIAP.CAD_MTMD_FILIAL_ID,\n" +
            "           MTMD.CAD_MTMD_NOMEFANTASIA,\n" +
            "           LINHA_ZERO.MTMD_CUSTO_MEDIO_ANTERIOR,\n" +
            "           LINHA_ZERO.MTMD_SALDO_ATUAL,\n" +
            "           LINHA_ZERO.MTMD_CUSTO_MEDIO_ATUAL,\n" +
            "           LINHA_ZERO.MTMD_VALOR_ATUAL,\n" +
            "           LINHA_ZERO.MTMD_SALDO_ANTERIOR,\n" +
            "           LINHA_ZERO.MTMD_VALOR_ANTERIOR\n" +
            "  ) EST_DIA\n" +
            "  GROUP BY EST_DIA.MTMD_MOV_DATA,\n" +
            "           EST_DIA.CAD_UNI_ID_UNIDADE,\n" +
            "           EST_DIA.CAD_SET_ID,\n" +
            "           EST_DIA.CAD_MTMD_GRUPO_ID\n" +
            "  ) EST_DIA,\n" +
            "  TB_CAD_UNI_UNIDADE UNI,\n" +
            "  TB_CAD_SET_SETOR   SETOR,\n" +
            "  TB_CAD_CEC_CENTRO_CUSTO CCUSTO\n" +
            "  WHERE UNI.CAD_UNI_ID_UNIDADE = EST_DIA.CAD_UNI_ID_UNIDADE AND\n" +
            "        SETOR.CAD_SET_ID       = EST_DIA.CAD_SET_ID AND\n" +
            "        CCUSTO.CAD_CEC_ID_CCUSTO = FNC_OBTER_CCUSTO(EST_DIA.CAD_SET_ID,\n" +
            "                                                    DECODE(EST_DIA.CAD_MTMD_GRUPO_ID, 1, 'MED', 'MAT'),\n" +
            "                                                    NULL,\n" +
            "                                                    NULL,\n" +
            "                                                    NULL,\n" +
            "                                                    NULL,\n" +
            "                                                    EST_DIA.MTMD_MOV_DATA)\n" +
            "  GROUP BY UNI.CAD_UNI_DS_UNIDADE,\n" +
            "           CCUSTO.CAD_CEC_CD_CCUSTO,\n" +
            "           CCUSTO.CAD_CEC_DS_CCUSTO\n" +
            "  ORDER BY 1,3,2"
            , data1, data2, filial);

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DateTime? ObterUltimaDataExecucaoFechamento()
        {
            string sqlString = "SELECT MAX(SEG_DT_ATUALIZACAO)\n" +
                             "  FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
                             " WHERE MTMD_MOV_DATA >= SYSDATE-60\n" +
                             "   AND MTMD_MOV_DATA <= SYSDATE+31";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (string.IsNullOrEmpty(result.Rows[0][0].ToString()))
                return null;
            else
                return DateTime.Parse(result.Rows[0][0].ToString());
        }

        public DateTime? ObterUltimaDataFechamento()
        {
            string sqlString = "SELECT MAX(MTMD_MOV_DATA)\n" +
                             "  FROM TB_MTMD_MOV_ESTOQUE_DIA\n" +
                             " WHERE MTMD_MOV_DATA >= SYSDATE-60\n" +
                             "   AND MTMD_MOV_DATA <= SYSDATE+31";

            DataTable result = new DataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (string.IsNullOrEmpty(result.Rows[0][0].ToString()))
                return null;
            else
                return DateTime.Parse(result.Rows[0][0].ToString());
        }

        public void GerarPreviaMes()
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            Connection.ExecuteCommand("PRC_MTMD_MOV_ESTOQUE_MES", ref param, CommandType.StoredProcedure);
        }
	}
}