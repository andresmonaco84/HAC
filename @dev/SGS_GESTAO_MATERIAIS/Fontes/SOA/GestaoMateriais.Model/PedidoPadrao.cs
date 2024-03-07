
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class PedidoPadrao : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public PedidoPadraoDataTable Sel(PedidoPadraoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pMTMD_PEDPAD_ID
			param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            //Parametro pMTMD_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pMTMD_DT_ULT_REQUISICAO
            param.Add(Connection.CreateParameter("pMTMD_DT_ULT_REQUISICAO", dto.DataDispensado.DBValue, ParameterDirection.Input, dto.DataDispensado.DbType));
			#endregion	
			
			PedidoPadraoDataTable result = new PedidoPadraoDataTable();
			string query = "PRC_MTMD_PEDIDO_PADRAO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}


        /// <summary>
        /// Listar Pedido para tela de geração de pedidos padrões
        /// </summary>
        public PedidoPadraoDataTable GeraImpressaoPedidoPadrao(PedidoPadraoDTO dto)
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

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));

            #endregion

            PedidoPadraoDataTable result = new PedidoPadraoDataTable();
            string query = "PRC_MTMD_PEDIDO_PADRAO_IMP_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }



		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public PedidoPadraoDTO SelChave(PedidoPadraoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			// Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
			// Parametro pMTMD_PEDPAD_ID
			param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			// Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			// Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));						

            //Parametro pMTMD_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));
			
			#endregion	
			
			PedidoPadraoDataTable result = new PedidoPadraoDataTable();
			string query = "PRC_MTMD_PEDIDO_PADRAO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}
		
		/// <summary>
        /// Exclui o registro
        /// </summary>        
		public void Del(PedidoPadraoDTO dto)
		{
  		   #region "Parametros"            
		   DbParameterCollection param = Connection.CreateDataParameterCollection();

           // Parametro pMTMD_PEDPAD_ID
           param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
		
    	   #endregion				
			            
		   string query = "PRC_MTMD_PEDIDO_PADRAO_D";
			
		   Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(PedidoPadraoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pMTMD_PEDPAD_ID
			param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));		

            //Parametro pMTMD_PERIODO_DIAS
            param.Add(Connection.CreateParameter("pMTMD_PERIODO_DIAS", dto.Periodo.DBValue, ParameterDirection.Input, dto.Periodo.DbType));
			
            //Parametro pMTMD_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			#endregion	

			string query = "PRC_MTMD_PEDIDO_PADRAO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}

        /// <summary>
        /// Gera Requisição/Pedido do estoque fixo da Unidade
        /// </summary>
        /// <param name="dto"></param>
        public void GeraRequisicao(PedidoPadraoDTO dto, string tabelaMedica, int? idSetorFarmacia)
        {
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
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

            if (idSetorFarmacia != null)
                param.Add(Connection.CreateParameter("pCAD_SET_SETOR_FARMACIA", idSetorFarmacia.Value, ParameterDirection.Input, new RequisicaoDTO().SetorFarmacia.DbType));

            if (!string.IsNullOrEmpty(tabelaMedica))
                param.Add(Connection.CreateParameter("pMED_CD_TABELAMEDICA", tabelaMedica, ParameterDirection.Input, new MaterialMedicamentoDTO().Tabelamedica.DbType));            
            
            PedidoPadraoDataTable result = new PedidoPadraoDataTable();
            string query = "PRC_MTMD_GERA_REQ_PADRAO";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Altera a data da última dispensação
        /// </summary>
        public void UpdDataDispensacao(PedidoPadraoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_PEDPAD_ID
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pFL_ATUALIZAR_DT_DISPENSACAO
            param.Add(Connection.CreateParameter("pFL_ATUALIZAR_DT_DISPENSACAO", 1, ParameterDirection.Input, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_PEDIDO_PADRAO_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Altera a data da última requisição referente a este pedido padrão
        /// </summary>			
        public void UpdDataUltRequisicao(PedidoPadraoDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pMTMD_PEDPAD_ID
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pFL_ATUALIZAR_DT_ULT_REQ
            param.Add(Connection.CreateParameter("pFL_ATUALIZAR_DT_ULT_REQ", 1, ParameterDirection.Input, DbType.Decimal));

            #endregion

            string query = "PRC_MTMD_PEDIDO_PADRAO_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(PedidoPadraoDTO dto)
		{			
			string query = "PRC_MTMD_PEDIDO_PADRAO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();						
			
			//Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
			param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));
			
			//Parametro pCAD_SET_ID
			param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
			
            //Parametro pMTMD_PERIODO_DIAS
            param.Add(Connection.CreateParameter("pMTMD_PERIODO_DIAS", dto.Periodo.DBValue, ParameterDirection.Input, dto.Periodo.DbType));			

            //Parametro pMTMD_FL_STATUS
            param.Add(Connection.CreateParameter("pMTMD_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            param.Add(Connection.CreateParameterSequence());
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
		}

        /// <summary>
        /// Retorna Itens cadastrado no Pedido Padrão
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PedidoPadraoItensDataTable SelItens(PedidoPadraoDTO dto)
        {
            string query = "PRC_MTMD_PEDIDO_PADRAO_ITENS_S";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_PEDPAD_ID
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
            #endregion
            PedidoPadraoItensDataTable result = new PedidoPadraoItensDataTable();

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

        /// <summary>
        /// Retorna Itens cadastrado no Pedido Padrão
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PedidoPadraoItensDataTable SelItens(PedidoPadraoItensDTO dto)
        {
            string query = "PRC_MTMD_PEDIDO_PADRAO_ITENS_S";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pMTMD_PEDPAD_ID
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pCAD_MTMD_PRIATI_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));
            #endregion
            PedidoPadraoItensDataTable result = new PedidoPadraoItensDataTable();

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Exclui o item
        /// </summary>       
        public void DelItem(PedidoPadraoItensDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            // Parametro pMTMD_PEDPAD_ID
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));


            #endregion
            //Executa o procedimento

            string query = "PRC_MTMD_PEDIDO_PADRAO_ITENS_D";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Altera o item
        /// </summary>			
        public void UpdItem(PedidoPadraoItensDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_PEDPAD_ID
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pMTMD_PEDPAD_QTDE
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            //Parametro pMTMD_PEDPAD_PERCENT_RESSUP
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_PERCENT_RESSUP", dto.PontoRessuprimento.DBValue, ParameterDirection.Input, dto.PontoRessuprimento.DbType));

            #endregion

            string query = "PRC_MTMD_PEDIDO_PADRAO_ITENS_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Inclui o item
        /// </summary>			
        public void InsItem(PedidoPadraoItensDTO dto)
        {
            string query = "PRC_MTMD_PEDIDO_PADRAO_ITENS_I";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();


            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));

            //Parametro pMTMD_PEDPAD_ID
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pMTMD_PEDPAD_QTDE
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_QTDE", dto.Qtde.DBValue, ParameterDirection.Input, dto.Qtde.DbType));

            //Parametro pMTMD_PEDPAD_PERCENT_RESSUP
            param.Add(Connection.CreateParameter("pMTMD_PEDPAD_PERCENT_RESSUP", dto.PontoRessuprimento.DBValue, ParameterDirection.Input, dto.PontoRessuprimento.DbType));

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

        }

        public PedidoPadraoItensDataTable ListarItemRessuprir(PedidoPadraoDTO dto)
        {
            string query = "PRC_MTMD_PEDIDO_PADRAO_DISPENS";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_FILIAL_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.IdtFilial.DBValue, ParameterDirection.Input, dto.IdtFilial.DbType));
            #endregion
            PedidoPadraoItensDataTable result = new PedidoPadraoItensDataTable();

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }
	}
}
