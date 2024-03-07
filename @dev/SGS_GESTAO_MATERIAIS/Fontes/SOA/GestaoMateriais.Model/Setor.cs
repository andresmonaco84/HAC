using System.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Setor : Entity
    {
        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public SetorDataTable Sel(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_SET_CD_SETOR
            param.Add(Connection.CreateParameter("pCAD_SET_CD_SETOR", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));

            //Parametro pCAD_SET_DS_SETOR
            param.Add(Connection.CreateParameter("pCAD_SET_DS_SETOR", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));

            //Parametro pCAD_SET_NR_TELEFONE
            param.Add(Connection.CreateParameter("pCAD_SET_NR_TELEFONE", dto.NumeroTelefone.DBValue, ParameterDirection.Input, dto.NumeroTelefone.DbType));

            //Parametro pCAD_SET_FL_SUBSTALMOX_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_SUBSTALMOX_OK", dto.SubstituiAlmoxarifado.DBValue, ParameterDirection.Input, dto.SubstituiAlmoxarifado.DbType));

            //Parametro pCAD_SET_FL_ESTQPROPRIO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ESTQPROPRIO_OK", dto.PossuiEstoqueProprio.DBValue, ParameterDirection.Input, dto.PossuiEstoqueProprio.DbType));

            //Parametro pCAD_SET_FL_ATIVO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ATIVO_OK", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

            //Parametro pCAD_SET_FL_GRAVAATEND_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_GRAVAATEND_OK", dto.GravaAtendimento.DBValue, ParameterDirection.Input, dto.GravaAtendimento.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuarioUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioUltimaAtualizacao.DbType));

            //Parametro pCAD_SET_NR_ANDAR
            param.Add(Connection.CreateParameter("pCAD_SET_NR_ANDAR", dto.NumeroAndar.DBValue, ParameterDirection.Input, dto.NumeroAndar.DbType));

            //Parametro pCAD_SET_DT_ULTIMA_ATUALIZACAO
            param.Add(Connection.CreateParameter("pCAD_SET_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

            //Parametro pCAD_SET_NR_RAMAL
            param.Add(Connection.CreateParameter("pCAD_SET_NR_RAMAL", dto.IdtRamal.DBValue, ParameterDirection.Input, dto.IdtRamal.DbType));

            //Parametro pCAD_SET_DS_PROCEDENCIA
            param.Add(Connection.CreateParameter("pCAD_SET_DS_PROCEDENCIA", dto.DescricaoProcedencia.DBValue, ParameterDirection.Input, dto.DescricaoProcedencia.DbType));

            //Parametro pCAD_SET_FL_ATENDSERVMUL_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ATENDSERVMUL_OK", dto.AtendeServicoMulher.DBValue, ParameterDirection.Input, dto.AtendeServicoMulher.DbType));

            //Parametro pCAD_SET_ALMOX_CENTRAL
            param.Add(Connection.CreateParameter("pCAD_SET_ALMOX_CENTRAL", dto.FlAlmoxCentral.DBValue, ParameterDirection.Input, dto.FlAlmoxCentral.DbType));

            //Parametro pCAD_SET_SETOR_FARMACIA
            param.Add(Connection.CreateParameter("pCAD_SET_SETOR_FARMACIA", dto.SetorFarmacia.DBValue, ParameterDirection.Input, dto.SetorFarmacia.DbType));

            //Parametro pCAD_SET_CE_SETOR_PAI
            param.Add(Connection.CreateParameter("pCAD_SET_CE_SETOR_PAI", dto.CarrinhoEmergSetorPai.DBValue, ParameterDirection.Input, dto.CarrinhoEmergSetorPai.DbType));

            //Parametro pCAD_SET_FL_PERMITEINTERN_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_PERMITEINTERN_OK", dto.PermiteInternacao.DBValue, ParameterDirection.Input, dto.PermiteInternacao.DbType));

            //Parametro pCAD_SET_FL_PREFERENC_ACS_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_PREFERENC_ACS_OK", dto.PreferencialACS.DBValue, ParameterDirection.Input, dto.PreferencialACS.DbType));

            //Parametro pCAD_SET_FL_MOVIMENTAPACINT_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_MOVIMENTAPACINT_OK", dto.MovimentaPacienteInternado.DBValue, ParameterDirection.Input, dto.MovimentaPacienteInternado.DbType));

            //Parametro pCAD_SET_FL_PERMITELIBLEITO_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_PERMITELIBLEITO_OK", dto.PermiteLiberarLeito.DBValue, ParameterDirection.Input, dto.PermiteLiberarLeito.DbType));
            #endregion

            SetorDataTable result = new SetorDataTable();
            string query = "PRC_CAD_SETOR_RMT_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public SetorDTO SelChave(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));


            #endregion

            SetorDataTable result = new SetorDataTable();
            string query = "PRC_CAD_SETOR_RMT_SID";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result.TypedRow(0);
        }

        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public SetorDataTable SelSetoresCentroDispensacao(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_SET_UNIDADE_ALMOX
            param.Add(Connection.CreateParameter("pCAD_SET_UNIDADE_ALMOX", dto.UnidadeAlmoxarifado.DBValue, ParameterDirection.Input, dto.UnidadeAlmoxarifado.DbType));

            //Parametro pCAD_SET_LOCAL_ALMOX
            param.Add(Connection.CreateParameter("pCAD_SET_LOCAL_ALMOX", dto.LocalAlmoxarifado.DBValue, ParameterDirection.Input, dto.LocalAlmoxarifado.DbType));

            //Parametro pCAD_SET_SETOR_ALMOX
            param.Add(Connection.CreateParameter("pCAD_SET_SETOR_ALMOX", dto.SetorAlmoxarifado.DBValue, ParameterDirection.Input, dto.SetorAlmoxarifado.DbType));

            #endregion

            SetorDataTable result = new SetorDataTable();
            string query = "PRC_CAD_SET_SETOR_ALMOX_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Exclui o registro
        /// </summary>        
        public void Del(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            // Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));


            #endregion
            //Executa o procedimento

            string query = "PRC_CAD_SETOR_RMT_D";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Altera o registro
        /// </summary>			
        public void Upd(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_SET_CD_SETOR
            param.Add(Connection.CreateParameter("pCAD_SET_CD_SETOR", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));

            //Parametro pCAD_SET_DS_SETOR
            param.Add(Connection.CreateParameter("pCAD_SET_DS_SETOR", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));

            //Parametro pCAD_SET_NR_TELEFONE
            param.Add(Connection.CreateParameter("pCAD_SET_NR_TELEFONE", dto.NumeroTelefone.DBValue, ParameterDirection.Input, dto.NumeroTelefone.DbType));

            //Parametro pCAD_SET_FL_SUBSTALMOX_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_SUBSTALMOX_OK", dto.SubstituiAlmoxarifado.DBValue, ParameterDirection.Input, dto.SubstituiAlmoxarifado.DbType));

            //Parametro pCAD_SET_FL_ESTQPROPRIO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ESTQPROPRIO_OK", dto.PossuiEstoqueProprio.DBValue, ParameterDirection.Input, dto.PossuiEstoqueProprio.DbType));

            //Parametro pCAD_SET_FL_ATIVO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ATIVO_OK", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

            //Parametro pCAD_SET_FL_GRAVAATEND_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_GRAVAATEND_OK", dto.GravaAtendimento.DBValue, ParameterDirection.Input, dto.GravaAtendimento.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuarioUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioUltimaAtualizacao.DbType));

            //Parametro pCAD_SET_NR_ANDAR
            param.Add(Connection.CreateParameter("pCAD_SET_NR_ANDAR", dto.NumeroAndar.DBValue, ParameterDirection.Input, dto.NumeroAndar.DbType));

            //Parametro pCAD_SET_DT_ULTIMA_ATUALIZACAO
            param.Add(Connection.CreateParameter("pCAD_SET_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

            //Parametro pCAD_SET_NR_RAMAL
            param.Add(Connection.CreateParameter("pCAD_SET_NR_RAMAL", dto.IdtRamal.DBValue, ParameterDirection.Input, dto.IdtRamal.DbType));

            //Parametro pCAD_SET_DS_PROCEDENCIA
            param.Add(Connection.CreateParameter("pCAD_SET_DS_PROCEDENCIA", dto.DescricaoProcedencia.DBValue, ParameterDirection.Input, dto.DescricaoProcedencia.DbType));

            //Parametro pCAD_SET_FL_ATENDSERVMUL_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ATENDSERVMUL_OK", dto.AtendeServicoMulher.DBValue, ParameterDirection.Input, dto.AtendeServicoMulher.DbType));

            //Parametro pCAD_SET_FL_PERMITEINTERN_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_PERMITEINTERN_OK", dto.PermiteInternacao.DBValue, ParameterDirection.Input, dto.PermiteInternacao.DbType));

            //Parametro pCAD_SET_FL_PREFERENC_ACS_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_PREFERENC_ACS_OK", dto.PreferencialACS.DBValue, ParameterDirection.Input, dto.PreferencialACS.DbType));

            //Parametro pCAD_SET_FL_MOVIMENTAPACINT_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_MOVIMENTAPACINT_OK", dto.MovimentaPacienteInternado.DBValue, ParameterDirection.Input, dto.MovimentaPacienteInternado.DbType));

            //Parametro pCAD_SET_FL_PERMITELIBLEITO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_PERMITELIBLEITO_OK", dto.PermiteLiberarLeito.DBValue, ParameterDirection.Input, dto.PermiteLiberarLeito.DbType));

            #endregion

            string query = "PRC_CAD_SETOR_RMT_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Altera os campos referentes ao centro de dispensação do setor
        /// </summary>			
        public void UpdCentroDispensacao(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_SET_UNIDADE_ALMOX
            param.Add(Connection.CreateParameter("pCAD_SET_UNIDADE_ALMOX", dto.UnidadeAlmoxarifado.DBValue, ParameterDirection.Input, dto.UnidadeAlmoxarifado.DbType));

            //Parametro pCAD_SET_LOCAL_ALMOX
            param.Add(Connection.CreateParameter("pCAD_SET_LOCAL_ALMOX", dto.LocalAlmoxarifado.DBValue, ParameterDirection.Input, dto.LocalAlmoxarifado.DbType));

            //Parametro pCAD_SET_SETOR_ALMOX
            param.Add(Connection.CreateParameter("pCAD_SET_SETOR_ALMOX", dto.SetorAlmoxarifado.DBValue, ParameterDirection.Input, dto.SetorAlmoxarifado.DbType));

            //Parametro pCAD_SET_SETOR_FARMACIA
            param.Add(Connection.CreateParameter("pCAD_SET_SETOR_FARMACIA", dto.SetorFarmacia.DBValue, ParameterDirection.Input, dto.SetorFarmacia.DbType));

            //Parametro pCAD_SET_CE_SETOR_PAI
            param.Add(Connection.CreateParameter("pCAD_SET_CE_SETOR_PAI", dto.CarrinhoEmergSetorPai.DBValue, ParameterDirection.Input, dto.CarrinhoEmergSetorPai.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            //param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuarioUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioUltimaAtualizacao.DbType));

            #endregion

            string query = "PRC_CAD_SET_SETOR_ALMOX_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        ///<summary>
        /// Atualiza o campo SubstituiAlmoxarifado
        /// </summary>				
        public void UpdSubstAlmox(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_SET_FL_SUBSTALMOX_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_SUBSTALMOX_OK", dto.SubstituiAlmoxarifado.DBValue, ParameterDirection.Input, dto.SubstituiAlmoxarifado.DbType));

            //Parametro pCAD_SET_FL_ESTQPROPRIO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ESTQPROPRIO_OK", dto.PossuiEstoqueProprio.DBValue, ParameterDirection.Input, dto.PossuiEstoqueProprio.DbType));            

            //Parametro pSEG_USU_ID_USUARIO
            //param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuarioUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioUltimaAtualizacao.DbType));

            #endregion

            string query = "PRC_CAD_SETOR_SUBALMOX_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Atualiza o Flag de Almoxarifado Central
        /// </summary>			
        public void UpdAlmoxarifadoCentral(SetorDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_SET_ALMOX_CENTRAL
            param.Add(Connection.CreateParameter("pCAD_SET_ALMOX_CENTRAL", dto.FlAlmoxCentral.DBValue, ParameterDirection.Input, dto.FlAlmoxCentral.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            //param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuarioUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioUltimaAtualizacao.DbType));

            #endregion

            string query = "PRC_CAD_SETOR_ALMOX_CENTRAL_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Inclui o registro
        /// </summary>			
        public void Ins(SetorDTO dto)
        {
            string query = "PRC_CAD_SETOR_RMT_I";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();


            //Parametro pCAD_SET_ID
            param.Add(Connection.CreateParameter("pCAD_SET_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_SET_CD_SETOR
            param.Add(Connection.CreateParameter("pCAD_SET_CD_SETOR", dto.Codigo.DBValue, ParameterDirection.Input, dto.Codigo.DbType));

            //Parametro pCAD_SET_DS_SETOR
            param.Add(Connection.CreateParameter("pCAD_SET_DS_SETOR", dto.Descricao.DBValue, ParameterDirection.Input, dto.Descricao.DbType));

            //Parametro pCAD_SET_NR_TELEFONE
            param.Add(Connection.CreateParameter("pCAD_SET_NR_TELEFONE", dto.NumeroTelefone.DBValue, ParameterDirection.Input, dto.NumeroTelefone.DbType));

            //Parametro pCAD_SET_FL_SUBSTALMOX_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_SUBSTALMOX_OK", dto.SubstituiAlmoxarifado.DBValue, ParameterDirection.Input, dto.SubstituiAlmoxarifado.DbType));

            //Parametro pCAD_SET_FL_ESTQPROPRIO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ESTQPROPRIO_OK", dto.PossuiEstoqueProprio.DBValue, ParameterDirection.Input, dto.PossuiEstoqueProprio.DbType));

            //Parametro pCAD_SET_FL_ATIVO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ATIVO_OK", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

            //Parametro pCAD_SET_FL_GRAVAATEND_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_GRAVAATEND_OK", dto.GravaAtendimento.DBValue, ParameterDirection.Input, dto.GravaAtendimento.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuarioUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioUltimaAtualizacao.DbType));

            //Parametro pCAD_SET_NR_ANDAR
            param.Add(Connection.CreateParameter("pCAD_SET_NR_ANDAR", dto.NumeroAndar.DBValue, ParameterDirection.Input, dto.NumeroAndar.DbType));

            //Parametro pCAD_SET_DT_ULTIMA_ATUALIZACAO
            param.Add(Connection.CreateParameter("pCAD_SET_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.IdtUnidade.DBValue, ParameterDirection.Input, dto.IdtUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", dto.IdtLocalAtendimento.DBValue, ParameterDirection.Input, dto.IdtLocalAtendimento.DbType));

            //Parametro pCAD_SET_NR_RAMAL
            param.Add(Connection.CreateParameter("pCAD_SET_NR_RAMAL", dto.IdtRamal.DBValue, ParameterDirection.Input, dto.IdtRamal.DbType));

            //Parametro pCAD_SET_DS_PROCEDENCIA
            param.Add(Connection.CreateParameter("pCAD_SET_DS_PROCEDENCIA", dto.DescricaoProcedencia.DBValue, ParameterDirection.Input, dto.DescricaoProcedencia.DbType));

            //Parametro pCAD_SET_FL_ATENDSERVMUL_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_ATENDSERVMUL_OK", dto.AtendeServicoMulher.DBValue, ParameterDirection.Input, dto.AtendeServicoMulher.DbType));

            //Parametro pCAD_SET_FL_PERMITEINTERN_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_PERMITEINTERN_OK", dto.PermiteInternacao.DBValue, ParameterDirection.Input, dto.PermiteInternacao.DbType));

            //Parametro pCAD_SET_FL_PREFERENC_ACS_OK
            // param.Add(Connection.CreateParameter("pCAD_SET_FL_PREFERENC_ACS_OK", dto.PreferencialACS.DBValue, ParameterDirection.Input, dto.PreferencialACS.DbType));

            //Parametro pCAD_SET_FL_MOVIMENTAPACINT_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_MOVIMENTAPACINT_OK", dto.MovimentaPacienteInternado.DBValue, ParameterDirection.Input, dto.MovimentaPacienteInternado.DbType));

            //Parametro pCAD_SET_FL_PERMITELIBLEITO_OK
            param.Add(Connection.CreateParameter("pCAD_SET_FL_PERMITELIBLEITO_OK", dto.PermiteLiberarLeito.DBValue, ParameterDirection.Input, dto.PermiteLiberarLeito.DbType));
            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

        }

        public SetorDataTable SelSetoresCentroCusto(string centroCusto)
        {            
            SetorDataTable result = new SetorDataTable();
            string query = "SELECT DISTINCT\n" +
                            "       CC.CAD_CEC_ID_CCUSTO, CC.CAD_CEC_CD_CCUSTO, CC.CAD_CEC_DS_CCUSTO,\n" +
                            "       SETOR.CAD_SET_ID, SETOR.CAD_SET_DS_SETOR\n" +
                            "  FROM TB_CAD_CEC_CENTRO_CUSTO CC JOIN\n" +
                            "       TB_ASS_USC_UNI_SET_CCUS_CLA USC ON USC.CAD_CEC_ID_CCUSTO = CC.CAD_CEC_ID_CCUSTO JOIN\n" +
                            "       TB_CAD_SET_SETOR SETOR ON SETOR.CAD_SET_ID = USC.CAD_SET_ID\n" +
                            "WHERE CC.CAD_CEC_FL_CCUSTO = 'A' AND USC.ASS_USC_FL_STATUS = 'A' AND\n" +
                            "      SETOR.CAD_SET_FL_ATIVO_OK = 'S' AND\n" +
                            "      USC.CAD_TAP_TP_ATRIBUTO IN ('MAT','MED') AND\n" +
                            "      USC.ASS_USC_DT_FIM_VIGENCIA IS NULL AND\n" +
                            "      CC.CAD_CEC_CD_CCUSTO = '" + centroCusto +"'\n" +
                            "ORDER BY CC.CAD_CEC_DS_CCUSTO";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }      
    }
}