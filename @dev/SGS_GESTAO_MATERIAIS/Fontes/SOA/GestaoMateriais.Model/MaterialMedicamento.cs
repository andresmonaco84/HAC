
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class MaterialMedicamento : Entity
    {

        /// <summary>
        /// Busca consumo de 3 meses anteriores da data passada como parâmetro, o parâmetro qtdMesesAnteriores está sendo ignorada na procedure
        /// </summary>
        /// <param name="dtoMatMed"></param>
        /// <param name="qtdMesesAnteriores"></param>
        /// <returns></returns>
        public MovimentacaoDataTable ObterConsumoUltimosMeses(MaterialMedicamentoDTO dtoMatMed, byte qtdMesesAnteriores)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dtoMatMed.Idt.DBValue, ParameterDirection.Input, dtoMatMed.Idt.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID            
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dtoMatMed.IdtFilial.DBValue, ParameterDirection.Input, dtoMatMed.IdtFilial.DbType));

            //Parametro pQtdMesesAnteriores
            param.Add(Connection.CreateParameter("pQtdMesesAnteriores", qtdMesesAnteriores, ParameterDirection.Input));

            #endregion

            MovimentacaoDataTable result = new MovimentacaoDataTable();
            string query = "PRC_MTMD_CONSUMOS_MENSAIS";
            
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            return result;
        }

        public decimal ObterRotatividade(MaterialMedicamentoDTO dtoMatMed, DateTime dataInicio, DateTime dataTermino)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dtoMatMed.Idt.DBValue, ParameterDirection.Input, dtoMatMed.Idt.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID            
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dtoMatMed.IdtFilial.DBValue, ParameterDirection.Input, dtoMatMed.IdtFilial.DbType));

            //Parametro pDATA_INI
            param.Add(Connection.CreateParameter("pDATA_INI", dataInicio, ParameterDirection.Input, DbType.Date));

            //Parametro pDATA_FIM
            param.Add(Connection.CreateParameter("pDATA_FIM", dataTermino, ParameterDirection.Input, DbType.Date));

            #endregion

            DataTable result = new DataTable();
            string query = "PRC_MTMD_STATUS_CONSUMOS";

            result.Columns.Add("ROTATIVIDADE", typeof(Decimal));

            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count > 0)
            {
                object obj = result.Rows[0]["ROTATIVIDADE"];
                if (!string.IsNullOrEmpty(obj.ToString())) return decimal.Parse(obj.ToString());
            }
            return 0;
        }

        public void ObterStatusConsumo(MaterialMedicamentoDTO dtoMatMed, DateTime dataInicio, DateTime dataTermino, out decimal consumoMedio, out decimal iRotatividade, out decimal Entrada )
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dtoMatMed.Idt.DBValue, ParameterDirection.Input, dtoMatMed.Idt.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID            
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dtoMatMed.IdtFilial.DBValue, ParameterDirection.Input, dtoMatMed.IdtFilial.DbType));

            //Parametro pDATA_INI
            param.Add(Connection.CreateParameter("pDATA_INI", dataInicio, ParameterDirection.Input, DbType.Date));

            //Parametro pDATA_FIM
            param.Add(Connection.CreateParameter("pDATA_FIM", dataTermino, ParameterDirection.Input, DbType.Date));

            #endregion            

            DataTable result = new DataTable();
            string query = "PRC_MTMD_STATUS_CONSUMOS";

            result.Columns.Add("CONSUMO_MEDIO", typeof(Decimal));
            result.Columns.Add("ROTATIVIDADE", typeof(Decimal));
            result.Columns.Add("ENTRADA", typeof(Decimal));

            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            consumoMedio = 0;
            iRotatividade = 0;
            Entrada = 0;
            
            if (result.Rows.Count > 0)
            {
                object obj;

                obj = result.Rows[0]["CONSUMO_MEDIO"];
                if (!string.IsNullOrEmpty(obj.ToString())) consumoMedio = decimal.Parse(obj.ToString());

                obj = result.Rows[0]["ROTATIVIDADE"];
                if (!string.IsNullOrEmpty(obj.ToString())) iRotatividade = decimal.Parse(obj.ToString());

                obj = result.Rows[0]["ENTRADA"];
                if (!string.IsNullOrEmpty(obj.ToString())) Entrada = decimal.Parse(obj.ToString());               

            }                 
        }

        public void ObterStatusConsumo(MaterialMedicamentoDTO dtoMatMed, out decimal qtdEstoqueContabil, out DateTime? ultimoConsumo)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dtoMatMed.Idt.DBValue, ParameterDirection.Input, dtoMatMed.Idt.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID            
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dtoMatMed.IdtFilial.DBValue, ParameterDirection.Input, dtoMatMed.IdtFilial.DbType));            

            #endregion

            DataTable result = new DataTable();
            string query = "PRC_MTMD_STATUS_CONSUMOS";

            result.Columns.Add("QTD_ESTOQUE_CONTABIL", typeof(Decimal));
            result.Columns.Add("DATA_ULT_CONSUMO", typeof(DateTime));

            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            
            qtdEstoqueContabil = 0;
            ultimoConsumo = null;

            if (result.Rows.Count > 0)
            {
                object obj;                

                obj = result.Rows[0]["QTD_ESTOQUE_CONTABIL"];
                if (!string.IsNullOrEmpty(obj.ToString())) qtdEstoqueContabil = decimal.Parse(obj.ToString());

                obj = result.Rows[0]["DATA_ULT_CONSUMO"];
                if (!string.IsNullOrEmpty(obj.ToString())) ultimoConsumo = DateTime.Parse(obj.ToString());
            }      
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public decimal ObterCustoMedio(MovimentacaoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID            
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));            

            //Parametro pRetorno
            param.Add(Connection.CreateParameter("pRetorno", null, ParameterDirection.Output, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_CUSTO_MEDIO";

            //Executa o procedimento            
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            return decimal.Parse(param["pRetorno"].Value.ToString());
        }

		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public MaterialMedicamentoDataTable Sel(MaterialMedicamentoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));

			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));

			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));

			//Parametro pTIS_MED_CD_TABELAMEDICA
			param.Add(Connection.CreateParameter("pTIS_MED_CD_TABELAMEDICA", dto.Tabelamedica.DBValue, ParameterDirection.Input, dto.Tabelamedica.DbType));

			//Parametro pCAD_MTMD_NOMEFANTASIA
			param.Add(Connection.CreateParameter("pCAD_MTMD_NOMEFANTASIA", dto.NomeFantasia.DBValue, ParameterDirection.Input, dto.NomeFantasia.DbType));

			//Parametro pCAD_MTMD_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DESCRICAO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));

			//Parametro pCAD_MTMD_UNIDADE_VENDA
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_VENDA", dto.UnidadeVenda.DBValue, ParameterDirection.Input, dto.UnidadeVenda.DbType));

			//Parametro pCAD_MTMD_UNIDADE_COMPRA
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_COMPRA", dto.UnidadeCompra.DBValue, ParameterDirection.Input, dto.UnidadeCompra.DbType));

			//Parametro pCAD_MTMD_UNIDADE_CONTROLE
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_CONTROLE", dto.UnidadeControle.DBValue, ParameterDirection.Input, dto.UnidadeControle.DbType));

			//Parametro pCAD_MTMD_CODMNE
			param.Add(Connection.CreateParameter("pCAD_MTMD_CODMNE", dto.CodMne.DBValue, ParameterDirection.Input, dto.CodMne.DbType));

			//Parametro pCAD_MTMD_CURVA_ABC
			param.Add(Connection.CreateParameter("pCAD_MTMD_CURVA_ABC", dto.CurvaAbc.DBValue, ParameterDirection.Input, dto.CurvaAbc.DbType));

			//Parametro pCAD_MTMD_CD_FABRICANTE
			param.Add(Connection.CreateParameter("pCAD_MTMD_CD_FABRICANTE", dto.CdFabricante.DBValue, ParameterDirection.Input, dto.CdFabricante.DbType));

			//Parametro pCAD_MTMD_FL_FRACIONA
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_FRACIONA", dto.FlFracionado.DBValue, ParameterDirection.Input, dto.FlFracionado.DbType));

			//Parametro pCAD_MTMD_FL_ATIVO
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

			//Parametro pCAD_MTMD_FL_MANTER_ESTOQUE
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_MANTER_ESTOQUE", dto.FlManterEstoque.DBValue, ParameterDirection.Input, dto.FlManterEstoque.DbType));

			//Parametro pCAD_MTMD_FL_REUTILIZAVEL
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_REUTILIZAVEL", dto.FlReutilizavel.DBValue, ParameterDirection.Input, dto.FlReutilizavel.DbType));

			//Parametro pCAD_MTMD_DT_ULTIMA_ATUALIZA
            param.Add(Connection.CreateParameter("pCAD_MTMD_DT_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

			//Parametro pCAD_MTMD_CD_RM
			param.Add(Connection.CreateParameter("pCAD_MTMD_CD_RM", dto.CdRm.DBValue, ParameterDirection.Input, dto.CdRm.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pTP_PESQUISA", dto.TpPesquisa.DBValue, ParameterDirection.Input, dto.TpPesquisa.DbType));

			#endregion	
			
			MaterialMedicamentoDataTable result = new MaterialMedicamentoDataTable();
			string query = "PRC_CAD_MTMD_MAT_MED_S";
            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MaterialMedicamentoDTO SelChave(MaterialMedicamentoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			MaterialMedicamentoDataTable result = new MaterialMedicamentoDataTable();
			string query = "PRC_CAD_MTMD_MAT_MED_SID";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count > 0)
            {
                return result.TypedRow(0);
            }
            else
            {
                return null;
            }
		}
		
		/// <summary>
        /// Exclui o registro
        /// </summary>
		public void Del(MaterialMedicamentoDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_CAD_MTMD_MAT_MED_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(MaterialMedicamentoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
					
			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));
			
			//Parametro pTIS_MED_CD_TABELAMEDICA
			param.Add(Connection.CreateParameter("pTIS_MED_CD_TABELAMEDICA", dto.Tabelamedica.DBValue, ParameterDirection.Input, dto.Tabelamedica.DbType));
			
			//Parametro pCAD_MTMD_NOMEFANTASIA
			param.Add(Connection.CreateParameter("pCAD_MTMD_NOMEFANTASIA", dto.NomeFantasia.DBValue, ParameterDirection.Input, dto.NomeFantasia.DbType));
			
			//Parametro pCAD_MTMD_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DESCRICAO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pCAD_MTMD_UNIDADE_VENDA
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_VENDA", dto.UnidadeVenda.DBValue, ParameterDirection.Input, dto.UnidadeVenda.DbType));
			
			//Parametro pCAD_MTMD_UNIDADE_COMPRA
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_COMPRA", dto.UnidadeCompra.DBValue, ParameterDirection.Input, dto.UnidadeCompra.DbType));
			
			//Parametro pCAD_MTMD_UNIDADE_CONTROLE
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_CONTROLE", dto.UnidadeControle.DBValue, ParameterDirection.Input, dto.UnidadeControle.DbType));
			
			//Parametro pCAD_MTMD_CODMNE
			param.Add(Connection.CreateParameter("pCAD_MTMD_CODMNE", dto.CodMne.DBValue, ParameterDirection.Input, dto.CodMne.DbType));
			
			//Parametro pCAD_MTMD_CURVA_ABC
			param.Add(Connection.CreateParameter("pCAD_MTMD_CURVA_ABC", dto.CurvaAbc.DBValue, ParameterDirection.Input, dto.CurvaAbc.DbType));
			
			//Parametro pCAD_MTMD_CD_FABRICANTE
			param.Add(Connection.CreateParameter("pCAD_MTMD_CD_FABRICANTE", dto.CdFabricante.DBValue, ParameterDirection.Input, dto.CdFabricante.DbType));
			
			//Parametro pCAD_MTMD_FL_FRACIONA
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_FRACIONA", dto.FlFracionado.DBValue, ParameterDirection.Input, dto.FlFracionado.DbType));
			
			//Parametro pCAD_MTMD_FL_ATIVO
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));
			
			//Parametro pCAD_MTMD_FL_MANTER_ESTOQUE
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_MANTER_ESTOQUE", dto.FlManterEstoque.DBValue, ParameterDirection.Input, dto.FlManterEstoque.DbType));
			
			//Parametro pCAD_MTMD_FL_REUTILIZAVEL
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_REUTILIZAVEL", dto.FlReutilizavel.DBValue, ParameterDirection.Input, dto.FlReutilizavel.DbType));
			
			//Parametro pCAD_MTMD_DT_ULTIMA_ATUALIZA
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_ATUALIZA", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pCAD_MTMD_CD_RM
			param.Add(Connection.CreateParameter("pCAD_MTMD_CD_RM", dto.CdRm.DBValue, ParameterDirection.Input, dto.CdRm.DbType));

            //Parametro pCAD_MTMD_UNIDADE_CONSUMO
            param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_CONSUMO", dto.UnidadeConsumo.DBValue, ParameterDirection.Input, dto.CdRm.DbType));
			
			#endregion	

			string query = "PRC_CAD_MTMD_MAT_MED_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(MaterialMedicamentoDTO dto)
		{			
			string query = "PRC_CAD_MTMD_MAT_MED_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
					
			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));
			
			//Parametro pCAD_MTMD_GRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
			
			//Parametro pCAD_MTMD_SUBGRUPO_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));
			
			//Parametro pTIS_MED_CD_TABELAMEDICA
			param.Add(Connection.CreateParameter("pTIS_MED_CD_TABELAMEDICA", dto.Tabelamedica.DBValue, ParameterDirection.Input, dto.Tabelamedica.DbType));
			
			//Parametro pCAD_MTMD_NOMEFANTASIA
			param.Add(Connection.CreateParameter("pCAD_MTMD_NOMEFANTASIA", dto.NomeFantasia.DBValue, ParameterDirection.Input, dto.NomeFantasia.DbType));
			
			//Parametro pCAD_MTMD_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_DESCRICAO", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));
			
			//Parametro pCAD_MTMD_UNIDADE_VENDA
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_VENDA", dto.UnidadeVenda.DBValue, ParameterDirection.Input, dto.UnidadeVenda.DbType));
			
			//Parametro pCAD_MTMD_UNIDADE_COMPRA
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_COMPRA", dto.UnidadeCompra.DBValue, ParameterDirection.Input, dto.UnidadeCompra.DbType));
			
			//Parametro pCAD_MTMD_UNIDADE_CONTROLE
			param.Add(Connection.CreateParameter("pCAD_MTMD_UNIDADE_CONTROLE", dto.UnidadeControle.DBValue, ParameterDirection.Input, dto.UnidadeControle.DbType));
			
			//Parametro pCAD_MTMD_CODMNE
			param.Add(Connection.CreateParameter("pCAD_MTMD_CODMNE", dto.CodMne.DBValue, ParameterDirection.Input, dto.CodMne.DbType));
			
			//Parametro pCAD_MTMD_CURVA_ABC
			param.Add(Connection.CreateParameter("pCAD_MTMD_CURVA_ABC", dto.CurvaAbc.DBValue, ParameterDirection.Input, dto.CurvaAbc.DbType));
			
			//Parametro pCAD_MTMD_CD_FABRICANTE
			param.Add(Connection.CreateParameter("pCAD_MTMD_CD_FABRICANTE", dto.CdFabricante.DBValue, ParameterDirection.Input, dto.CdFabricante.DbType));
			
			//Parametro pCAD_MTMD_FL_FRACIONA
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_FRACIONA", dto.FlFracionado.DBValue, ParameterDirection.Input, dto.FlFracionado.DbType));
			
			//Parametro pCAD_MTMD_FL_ATIVO
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));
			
			//Parametro pCAD_MTMD_FL_MANTER_ESTOQUE
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_MANTER_ESTOQUE", dto.FlManterEstoque.DBValue, ParameterDirection.Input, dto.FlManterEstoque.DbType));
			
			//Parametro pCAD_MTMD_FL_REUTILIZAVEL
			param.Add(Connection.CreateParameter("pCAD_MTMD_FL_REUTILIZAVEL", dto.FlReutilizavel.DBValue, ParameterDirection.Input, dto.FlReutilizavel.DbType));
			
			//Parametro pCAD_MTMD_DT_ULTIMA_ATUALIZA
			param.Add(Connection.CreateParameter("pCAD_MTMD_DT_ATUALIZA", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pCAD_MTMD_CD_RM
			param.Add(Connection.CreateParameter("pCAD_MTMD_CD_RM", dto.CdRm.DBValue, ParameterDirection.Input, dto.CdRm.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}

        public MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dto)
        {
            return SelSubGrupoSetorPermissao(dto, false);
        }

        /// <summary>
        /// SelSubGrupoSetorPermissao
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="comEstoqueAlmox">Apenas com Saldo no Almoxarifado Central</param>
        /// <returns></returns>
        public MaterialMedicamentoDataTable SelSubGrupoSetorPermissao(MaterialMedicamentoDTO dto, bool comEstoqueAlmox)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            // param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_NOMEFANTASIA
            param.Add(Connection.CreateParameter("pCAD_MTMD_NOMEFANTASIA", dto.NomeFantasia.DBValue, ParameterDirection.Input, dto.NomeFantasia.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            if (!dto.IdtFilial.Value.IsNull)            
                param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            if (comEstoqueAlmox)
                param.Add(Connection.CreateParameter("pCOM_ESTOQUE", 1, ParameterDirection.Input));
            #endregion

            MaterialMedicamentoDataTable result = new MaterialMedicamentoDataTable();
            string query = "PRC_MTMD_MATMED_PERMIS_SETOR";
            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            return result;
        }

        public MaterialMedicamentoDTO InfoContabil(MaterialMedicamentoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            #endregion

            MaterialMedicamentoDataTable result = new MaterialMedicamentoDataTable();
            string query = "PRC_MTMD_MAT_MED_INFO_CONTABIL";
            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            if (result.Rows.Count > 0)
            {
                return result.TypedRow(0);
            }
            else
            {
                return null;
            }
        }

        public void InserirMarca(decimal idProduto, decimal numMarca, string descricaoMarca, decimal idUsuario)
        {
            DataTable result = new DataTable();
            string query = "INSERT INTO TB_CAD_MTMD_MARCAS(CAD_MTMD_ID, CAD_MTMD_DSC_MARCA, SEG_USU_ID_USUARIO, CAD_MTMD_DT_ATUALIZACAO, CAD_MTMD_MARCA_NUM) " +
                           " VALUES (" + idProduto + ", '" + descricaoMarca + "', " + idUsuario + ", SYSDATE, " + numMarca + ")";

            Connection.ExecuteCommand(query);
        }

        public void AtualizarMarca(decimal idProduto, decimal numMarca, string descricaoMarca, decimal idUsuario)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_CAD_MTMD_MARCAS SET " +
                            " CAD_MTMD_DSC_MARCA = '" + descricaoMarca + "'" +
                            " , SEG_USU_ID_USUARIO = " + idUsuario +
                            " , CAD_MTMD_DT_ATUALIZACAO = SYSDATE" + 
                            " WHERE CAD_MTMD_ID = " + idProduto + " AND CAD_MTMD_MARCA_NUM = " + numMarca;

            Connection.ExecuteCommand(query);
        }

        public void ExcluirMarca(decimal idProduto, decimal numMarca)
        {
            DataTable result = new DataTable();
            string query = "DELETE TB_CAD_MTMD_MARCAS " +
                            " WHERE CAD_MTMD_ID = " + idProduto + " AND CAD_MTMD_MARCA_NUM = " + numMarca;

            Connection.ExecuteCommand(query);
        }

        public DataTable SelMarcas(decimal idProduto)
        {
            DataTable result = new DataTable();
            string query = "SELECT CAD_MTMD_ID,\n" +
                            "       CAD_MTMD_DSC_MARCA,\n" +
                            "       CAD_MTMD_DT_ATUALIZACAO,\n" +
                            "       SEG_USU_ID_USUARIO,\n" +
                            "       CAD_MTMD_MARCA_NUM\n" +
                            "FROM TB_CAD_MTMD_MARCAS " +
                            "WHERE CAD_MTMD_ID = " + idProduto + 
                            " ORDER BY CAD_MTMD_DSC_MARCA";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable SelEnderecos(decimal idProduto)
        {
            DataTable result = new DataTable();
            string query = "SELECT CAD_MTMD_ENDERECO_ALMOX_HAC,\n" +
                            "      CAD_MTMD_ENDERECO_ALMOX_ACS\n" +
                            "FROM TB_CAD_MTMD_MAT_MED " +
                            "WHERE CAD_MTMD_ID = " + idProduto;

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public void AtualizarEnderecos(decimal idProduto, decimal? numEndHAC, decimal? numEndACS)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_CAD_MTMD_MAT_MED SET " +
                            "  CAD_MTMD_ENDERECO_ALMOX_HAC = " + (numEndHAC == null ? "null" : numEndHAC.Value.ToString()) +
                            " ,CAD_MTMD_ENDERECO_ALMOX_ACS = " + (numEndACS == null ? "null" : numEndACS.Value.ToString()) +
                            " WHERE CAD_MTMD_ID = " + idProduto;

            Connection.ExecuteCommand(query);
        }

        public void AtualizarDiluente(MaterialMedicamentoDTO dto)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_CAD_MTMD_MAT_MED SET " +
                            "  CAD_MTMD_FL_DILUENTE = " + dto.FlDiluente.Value +
                            " WHERE CAD_MTMD_ID = " + dto.Idt.Value;

            Connection.ExecuteCommand(query);
        }

        public void AtualizarPrincipioAtivo(MaterialMedicamentoDTO dto)
        {
            DataTable result = new DataTable();
            string query = "UPDATE TB_CAD_MTMD_MAT_MED SET " +
                            "  CAD_MTMD_PRIATI_ID = " + dto.IdtPrincipioAtivo.Value +
                            " WHERE CAD_MTMD_ID = " + dto.Idt.Value;

            Connection.ExecuteCommand(query);
        }

        /// <summary>
        /// QtdMinima
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Se retornar 0 é porque não há cadastro de CAD_PRD_QT_MINIMA</returns>
        public int QtdMinima(MaterialMedicamentoDTO dto)
        {
            DataTable result = new DataTable();
            string query = "SELECT NVL(MAX(P.CAD_PRD_QT_MINIMA),0)\n" +
                           "  FROM TB_CAD_PRD_PRODUTO P\n" +
                           " WHERE TRIM(P.CAD_PRD_CD_CODIGO) = TRIM('" + dto.CodMne.Value + "')";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return int.Parse(result.Rows[0][0].ToString());
        }
	}
}