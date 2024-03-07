using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class MatMedSetorConfig : Entity
    {
        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public MatMedSetorConfigDataTable Sel(MatMedSetorConfigDTO dto)
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
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idtsetor.DBValue, ParameterDirection.Input, dto.Idtsetor.DbType));

            //Parametro pCAD_MTMD_SUBGRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));
            #endregion

            MatMedSetorConfigDataTable result = new MatMedSetorConfigDataTable();
            string query = "PRC_MTMD_MATMED_CONFIG_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public MatMedSetorConfigDTO SelChave(MatMedSetorConfigDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            // Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idtsetor.DBValue, ParameterDirection.Input, dto.Idtsetor.DbType));

            // Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_MTMD_SUBGRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));

            #endregion

            MatMedSetorConfigDataTable result = new MatMedSetorConfigDataTable();
            string query = "PRC_MTMD_MATMED_CONFIG_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result.TypedRow(0);
        }


        /// <summary>
        /// Exclui o registro
        /// </summary>        

        public void Del(MatMedSetorConfigDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            // Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idtsetor.DBValue, ParameterDirection.Input, dto.Idtsetor.DbType));

            // Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_MTMD_SUBGRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));

            #endregion
            //Executa o procedimento

            string query = "PRC_MTMD_MATMED_CONFIG_D";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Inclui o registro
        /// </summary>			
        public void Ins(MatMedSetorConfigDTO dto)
        {
            string query = "PRC_MTMD_MATMED_CONFIG_I";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idtsetor.DBValue, ParameterDirection.Input, dto.Idtsetor.DbType));

            //Parametro pCAD_MTMD_SUBGRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_SUBGRUPO_ID", dto.IdtSubGrupo.DBValue, ParameterDirection.Input, dto.IdtSubGrupo.DbType));

            //Parametro pCAD_MTMD_GRUPO_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_GRUPO_ID", dto.IdtGrupo.DBValue, ParameterDirection.Input, dto.IdtGrupo.DbType));

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

        }


        public MatMedSetorConfigDTO SetorCfg(MatMedSetorConfigDTO dto)
        {

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idtsetor.DBValue, ParameterDirection.Input, dto.Idtsetor.DbType));

            #endregion
            MatMedSetorConfigDataTable result = new MatMedSetorConfigDataTable();
            string query = "PRC_MTMD_MATMED_SETOR_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            if (result.Rows.Count > 0)
            {
                dtoCfg = result.TypedRow(0);
            }
            else
            {
                dtoCfg.AtendeTodosSetores.Value = 0;
                dtoCfg.IgnoraAlta.Value = 0;
            }

            return dtoCfg;

        }

        /// <summary>
        /// Salva configurações de acesso referentes ao setor
        /// </summary>
        /// <param name="dto"></param>
        public void SetorCfgSalvar(MatMedSetorConfigDTO dto)
        {
            string query = "PRC_MTMD_MATMED_SETOR_I";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idtsetor.DBValue, ParameterDirection.Input, dto.Idtsetor.DbType));

            //Parametro pMTMD_ATENDE_PAC_TODOS_SETORES
            param.Add(Connection.CreateParameter("pMTMD_ATENDE_PAC_TODOS_SETORES", dto.AtendeTodosSetores.DBValue, ParameterDirection.Input, dto.AtendeTodosSetores.DbType));

            //Parametro pMTMD_IGNORA_ALTA
            param.Add(Connection.CreateParameter("pMTMD_IGNORA_ALTA", dto.IgnoraAlta.DBValue, ParameterDirection.Input, dto.IgnoraAlta.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pMTMD_CONSOME_CENTRO_CUSTO", dto.ConsomeParaOutroCentroCusto.DBValue, ParameterDirection.Input, dto.ConsomeParaOutroCentroCusto.DbType));
            
            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pMTMD_ATENDE_PAC_TODAS_UNIDADE", dto.AtendeTodasUnidades.DBValue, ParameterDirection.Input, dto.AtendeTodasUnidades.DbType));

            //Parametro pMTMD_CONSOME_DIRETO_PACIENTE = Flag GerandoPedidoAutomatico
            param.Add(Connection.CreateParameter("pMTMD_CONSOME_DIRETO_PACIENTE", dto.GerandoPedidoAutomatico.DBValue, ParameterDirection.Input, dto.GerandoPedidoAutomatico.DbType));

            //Parametro pMTMD_IGNORA_ALTA_HORAS_ATE
            param.Add(Connection.CreateParameter("pMTMD_IGNORA_ALTA_HORAS_ATE", dto.IgnoraAltaHorasAte.DBValue, ParameterDirection.Input, dto.IgnoraAltaHorasAte.DbType));

            //Parametro pMTMD_ESTOQUE_UNIFICADO_HAC
            param.Add(Connection.CreateParameter("pMTMD_ESTOQUE_UNIFICADO_HAC", dto.EstoqueUnificadoHAC.DBValue, ParameterDirection.Input, dto.EstoqueUnificadoHAC.DbType));

            //Parametro pMTMD_SOLICITA_KIT
            param.Add(Connection.CreateParameter("pMTMD_SOLICITA_KIT", dto.SolicitaKit.DBValue, ParameterDirection.Input, dto.SolicitaKit.DbType));

            //Parametro pMTMD_CONTROLA_CONSUMO_PAC
            param.Add(Connection.CreateParameter("pMTMD_CONTROLA_CONSUMO_PAC", dto.ControlaConsumoPaciente.DBValue, ParameterDirection.Input, dto.ControlaConsumoPaciente.DbType));

            //Parametro pMTMD_CONTROLA_CONS_PAC_DATA
            param.Add(Connection.CreateParameter("pMTMD_CONTROLA_CONS_PAC_DATA", dto.DataControlaConsumoPaciente.DBValue, ParameterDirection.Input, dto.DataControlaConsumoPaciente.DbType));

            //Parametro pMTMD_FUN_ID_FUNCIONALIDADE
            param.Add(Connection.CreateParameter("pMTMD_FUN_ID_FUNCIONALIDADE", dto.IdFuncionalidade.DBValue, ParameterDirection.Input, dto.IdFuncionalidade.DbType));

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

        }

        public void GerarPedidosAutomaticosFarmacia(bool gerando, bool atualizarData)
        {
            //Flag MTMD_CONSOME_DIRETO_PACIENTE não estava sendo utilizado, e para não criar outro campo foi utilizado para esta finalidade
            DataTable result = new DataTable();
            int gerandoPedidoAutomatico = gerando ? 1 : 0;
            string data = atualizarData ? "SYSDATE" : "MTMD_CONTROLA_CONS_PAC_DATA";
            string query = "UPDATE TB_MTMD_MATMED_SETOR SET " +
                            " MTMD_CONSOME_DIRETO_PACIENTE = " + gerandoPedidoAutomatico +
                            " , MTMD_CONTROLA_CONS_PAC_DATA = " + data +
                            " WHERE CAD_SET_ID = 2592"; //Farmacia
            Connection.ExecuteCommand(query);
        }

        public bool GerandoPedidosAutomaticosFarmacia()
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT NVL(MTMD_CONSOME_DIRETO_PACIENTE, 0)\n" +
                               "  FROM TB_MTMD_MATMED_SETOR\n" +
                               "  WHERE CAD_SET_ID = 2592"; //Farmacia

            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (int.Parse(result.Rows[0][0].ToString()) == 1)
                return true;
            else
                return false;
        }

        public void GerarPedidosAutomaticosImediatoTransfPac(bool gerando)
        {
            //Flag MTMD_CONSOME_DIRETO_PACIENTE não estava sendo utilizado, e para não criar outro campo foi utilizado para esta finalidade
            DataTable result = new DataTable();
            int gerandoPedidoAutomatico = gerando ? 1 : 0;
            string query = "UPDATE TB_MTMD_MATMED_SETOR SET " +
                            " MTMD_CONSOME_DIRETO_PACIENTE = " + gerandoPedidoAutomatico +
                            " , MTMD_CONTROLA_CONS_PAC_DATA = SYSDATE " +
                            " WHERE CAD_SET_ID = 2092"; //ALMOXARIFADO UTI
            Connection.ExecuteCommand(query);
        }

        public bool GerandoPedidosAutomaticosImediatoTransfPac()
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT NVL(MTMD_CONSOME_DIRETO_PACIENTE, 0)\n" +
                               "  FROM TB_MTMD_MATMED_SETOR\n" +
                               "  WHERE CAD_SET_ID = 2092"; //ALMOXARIFADO UTI

            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (int.Parse(result.Rows[0][0].ToString()) == 1)
                return true;
            else
                return false;
        }

        public DateTime? DataUltimaGeracaoPedidosAutomaticosImediatoTransfPac()
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT MTMD_CONTROLA_CONS_PAC_DATA\n" +
                               "  FROM TB_MTMD_MATMED_SETOR\n" +
                               "  WHERE CAD_SET_ID = 2092"; //ALMOXARIFADO UTI

            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (string.IsNullOrEmpty(result.Rows[0][0].ToString()))
                return null;
            else
                return DateTime.Parse(result.Rows[0][0].ToString());
        }

        public DateTime? DataUltimaGeracaoPedidosAutomaticosFarmacia()
        {
            DataTable result = new DataTable();
            string sqlString = "SELECT MTMD_CONTROLA_CONS_PAC_DATA\n" +
                               "  FROM TB_MTMD_MATMED_SETOR\n" +
                               "  WHERE CAD_SET_ID = 2592"; //Farmacia

            Connection.RecordSet(sqlString, result, CommandType.Text);

            if (string.IsNullOrEmpty(result.Rows[0][0].ToString()))
                return null;
            else
                return DateTime.Parse(result.Rows[0][0].ToString());
        }

        /// <summary>
        /// Obtem estoques de consumo da unidade
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public SetorEstoqueConsumoDataTable SetorEstoqueConsumoObter(SetorEstoqueConsumoDTO dto)
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

            SetorEstoqueConsumoDataTable result = new SetorEstoqueConsumoDataTable();
            string query = "PRC_MTMD_CFG_ESTOQUE_CONSUMO_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

        /// <summary>
        /// Salva estoque de consumo da unidade
        /// </summary>
        /// <param name="dto"></param>
        public void SetorEstoqueConsumoSalvar(SetorEstoqueConsumoDTO dto)
        {
            string query = "PRC_MTMD_CFG_ESTOQUE_CONSUMO_I";

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

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pMTMD_LOCAL_ESTOQUE_CONSUMO", dto.IdtLocalConsumo.DBValue, ParameterDirection.Input, dto.IdtLocalConsumo.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pMTMD_UNIDADE_ESTOQUE_CONSUMO", dto.IdtUnidadeConsumo.DBValue, ParameterDirection.Input, dto.IdtUnidadeConsumo.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pMTMD_SETOR_ESTOQUE_CONSUMO", dto.IdtSetorConsumo.DBValue, ParameterDirection.Input, dto.IdtSetorConsumo.DbType));

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Exclui estoque de consumo da unidade
        /// </summary>
        /// <param name="dto"></param>
        public void SetorEstoqueConsumoExcluir(SetorEstoqueConsumoDTO dto)
        {
            string query = "PRC_MTMD_CFG_ESTOQUE_CONSUMO_D";

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

            ////Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            //param.Add(Connection.CreateParameter("pMTMD_LOCAL_ESTOQUE_CONSUMO", dto.IdtLocalConsumo.DBValue, ParameterDirection.Input, dto.IdtLocalConsumo.DbType));

            ////Parametro pCAD_UNI_ID_UNIDADE
            //param.Add(Connection.CreateParameter("pMTMD_UNIDADE_ESTOQUE_CONSUMO", dto.IdtUnidadeConsumo.DBValue, ParameterDirection.Input, dto.IdtUnidadeConsumo.DbType));

            ////Parametro pCAD_SET_ID
            //param.Add(Connection.CreateParameter("pMTMD_SETOR_ESTOQUE_CONSUMO", dto.IdtSetorConsumo.DBValue, ParameterDirection.Input, dto.IdtSetorConsumo.DbType));

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtem unidades que consomem do estoque passado como parâmetro
        /// </summary>
        /// <param name="dto">Unidade para consulta</param>
        /// <returns></returns>
        public SetorEstoqueConsumoDataTable SetorEstoqueUnidadesQueConsomemObter(SetorEstoqueConsumoDTO dto)
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

            SetorEstoqueConsumoDataTable result = new SetorEstoqueConsumoDataTable();
            string query = "PRC_MTMD_CFG_UNIDADE_CONSUMO_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }


        /// <summary>
        /// Verifica se Setor tem Acesso ao Produto sendo movimentado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Verdadeiro/Falso</returns>
        public bool SetorAcessoProduto(MovimentacaoDTO dto)
        {
            string query = "PRC_MTMD_SETOR_ACESSO";
            Int32 Retorno;
            bool Ret;

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            param.Add(Connection.CreateParameterSequence());

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocal.DBValue, ParameterDirection.Input, dto.IdtLocal.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.IdtSetor.DBValue, ParameterDirection.Input, dto.IdtSetor.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.IdtProduto.DBValue, ParameterDirection.Input, dto.IdtProduto.DbType));
            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            Retorno = Int32.Parse(param["pNewIdt"].Value.ToString());

            Ret = (Retorno == 0 ? false : true);
            return Ret;
        }
    }
}