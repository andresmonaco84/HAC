using System.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class Unidade : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        // public UnidadeDataTable Sel(UnidadeDTO dto)
        public DataTable Sel(UnidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_UNI_DS_IMAGEM_ASSOCIADA
			param.Add(Connection.CreateParameter("pCAD_UNI_DS_IMAGEM_ASSOCIADA", dto.Imagem.DBValue, ParameterDirection.Input, dto.Imagem.DbType));

			//Parametro pCAD_UNI_FL_STATUS
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

			//Parametro pCAD_UNI_DT_ULTIMO_STATUS
			param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMO_STATUS", dto.DtStatus.DBValue, ParameterDirection.Input, dto.DtStatus.DbType));

			//Parametro pCAD_UNI_FL_GRAVA_ATEND_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_ATEND_OK", dto.GravaAtendimentoFL.DBValue, ParameterDirection.Input, dto.GravaAtendimentoFL.DbType));

			//Parametro pCAD_UNI_FL_LIBERA_AGENDA_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_LIBERA_AGENDA_OK", dto.LiberaAgendaFL.DBValue, ParameterDirection.Input, dto.LiberaAgendaFL.DbType));

			//Parametro pCAD_UNI_FL_GRAVA_CD_PAC_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_CD_PAC_OK", dto.GravaCodPacFL.DBValue, ParameterDirection.Input, dto.GravaCodPacFL.DbType));

			//Parametro pCAD_UNI_ID_UNIDADE_MASTER
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE_MASTER", dto.UnidadeMasterFL.DBValue, ParameterDirection.Input, dto.UnidadeMasterFL.DbType));

			//Parametro pCAD_PES_ID_PESSOA
			param.Add(Connection.CreateParameter("pCAD_PES_ID_PESSOA", dto.IdtPessoa.DBValue, ParameterDirection.Input, dto.IdtPessoa.DbType));

			//Parametro pCAD_UNI_NR_CNES
			param.Add(Connection.CreateParameter("pCAD_UNI_NR_CNES", dto.NrCnes.DBValue, ParameterDirection.Input, dto.NrCnes.DbType));

			//Parametro pCAD_UNI_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

			//Parametro pCAD_UNI_CD_HOSPITALAR
			param.Add(Connection.CreateParameter("pCAD_UNI_CD_HOSPITALAR", dto.CdHospitalar.DBValue, ParameterDirection.Input, dto.CdHospitalar.DbType));

			//Parametro pCAD_UNI_CD_UNID_HOSPITALAR
			param.Add(Connection.CreateParameter("pCAD_UNI_CD_UNID_HOSPITALAR", dto.UnidHospitalar.DBValue, ParameterDirection.Input, dto.UnidHospitalar.DbType));

			//Parametro pCAD_UNI_FL_CRONICO_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_CRONICO_OK", dto.CronicoOK.DBValue, ParameterDirection.Input, dto.CronicoOK.DbType));

			//Parametro pCAD_UNI_FL_PRIORIDADE_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_PRIORIDADE_OK", dto.PrioridadeOK.DBValue, ParameterDirection.Input, dto.PrioridadeOK.DbType));

			//Parametro pCAD_UNI_DS_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_DS_UNIDADE", dto.DsUnidade.DBValue, ParameterDirection.Input, dto.DsUnidade.DbType));
			#endregion	
			
			// UnidadeDataTable result = new UnidadeDataTable();
            DataTable result = new DataTable();
			string query = "PRC_CAD_UNIDADE_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public UnidadeDTO SelChave(UnidadeDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			UnidadeDataTable result = new UnidadeDataTable();
			string query = "PRC_CAD_UNIDADE_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(UnidadeDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_CAD_UNIDADE_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(UnidadeDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_UNI_DS_IMAGEM_ASSOCIADA
			param.Add(Connection.CreateParameter("pCAD_UNI_DS_IMAGEM_ASSOCIADA", dto.Imagem.DBValue, ParameterDirection.Input, dto.Imagem.DbType));
			
			//Parametro pCAD_UNI_FL_STATUS
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));
			
			//Parametro pCAD_UNI_DT_ULTIMO_STATUS
			param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMO_STATUS", dto.DtStatus.DBValue, ParameterDirection.Input, dto.DtStatus.DbType));
			
			//Parametro pCAD_UNI_FL_GRAVA_ATEND_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_ATEND_OK", dto.GravaAtendimentoFL.DBValue, ParameterDirection.Input, dto.GravaAtendimentoFL.DbType));
			
			//Parametro pCAD_UNI_FL_LIBERA_AGENDA_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_LIBERA_AGENDA_OK", dto.LiberaAgendaFL.DBValue, ParameterDirection.Input, dto.LiberaAgendaFL.DbType));
			
			//Parametro pCAD_UNI_FL_GRAVA_CD_PAC_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_CD_PAC_OK", dto.GravaCodPacFL.DBValue, ParameterDirection.Input, dto.GravaCodPacFL.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE_MASTER
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE_MASTER", dto.UnidadeMasterFL.DBValue, ParameterDirection.Input, dto.UnidadeMasterFL.DbType));
			
			//Parametro pCAD_PES_ID_PESSOA
			param.Add(Connection.CreateParameter("pCAD_PES_ID_PESSOA", dto.IdtPessoa.DBValue, ParameterDirection.Input, dto.IdtPessoa.DbType));
			
			//Parametro pCAD_UNI_NR_CNES
			param.Add(Connection.CreateParameter("pCAD_UNI_NR_CNES", dto.NrCnes.DBValue, ParameterDirection.Input, dto.NrCnes.DbType));
			
			//Parametro pCAD_UNI_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pCAD_UNI_CD_HOSPITALAR
			param.Add(Connection.CreateParameter("pCAD_UNI_CD_HOSPITALAR", dto.CdHospitalar.DBValue, ParameterDirection.Input, dto.CdHospitalar.DbType));
			
			//Parametro pCAD_UNI_CD_UNID_HOSPITALAR
			param.Add(Connection.CreateParameter("pCAD_UNI_CD_UNID_HOSPITALAR", dto.UnidHospitalar.DBValue, ParameterDirection.Input, dto.UnidHospitalar.DbType));
			
			//Parametro pCAD_UNI_FL_CRONICO_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_CRONICO_OK", dto.CronicoOK.DBValue, ParameterDirection.Input, dto.CronicoOK.DbType));
			
			//Parametro pCAD_UNI_FL_PRIORIDADE_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_PRIORIDADE_OK", dto.PrioridadeOK.DBValue, ParameterDirection.Input, dto.PrioridadeOK.DbType));
			
			//Parametro pCAD_UNI_DS_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_DS_UNIDADE", dto.DsUnidade.DBValue, ParameterDirection.Input, dto.DsUnidade.DbType));
			
			#endregion	

			string query = "PRC_CAD_UNIDADE_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(UnidadeDTO dto)
		{			
			string query = "PRC_CAD_UNIDADE_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_UNI_ID_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_UNI_DS_IMAGEM_ASSOCIADA
			param.Add(Connection.CreateParameter("pCAD_UNI_DS_IMAGEM_ASSOCIADA", dto.Imagem.DBValue, ParameterDirection.Input, dto.Imagem.DbType));
			
			//Parametro pCAD_UNI_FL_STATUS
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));
			
			//Parametro pCAD_UNI_DT_ULTIMO_STATUS
			param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMO_STATUS", dto.DtStatus.DBValue, ParameterDirection.Input, dto.DtStatus.DbType));
			
			//Parametro pCAD_UNI_FL_GRAVA_ATEND_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_ATEND_OK", dto.GravaAtendimentoFL.DBValue, ParameterDirection.Input, dto.GravaAtendimentoFL.DbType));
			
			//Parametro pCAD_UNI_FL_LIBERA_AGENDA_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_LIBERA_AGENDA_OK", dto.LiberaAgendaFL.DBValue, ParameterDirection.Input, dto.LiberaAgendaFL.DbType));
			
			//Parametro pCAD_UNI_FL_GRAVA_CD_PAC_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_CD_PAC_OK", dto.GravaCodPacFL.DBValue, ParameterDirection.Input, dto.GravaCodPacFL.DbType));
			
			//Parametro pCAD_UNI_ID_UNIDADE_MASTER
			param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE_MASTER", dto.UnidadeMasterFL.DBValue, ParameterDirection.Input, dto.UnidadeMasterFL.DbType));
			
			//Parametro pCAD_PES_ID_PESSOA
			param.Add(Connection.CreateParameter("pCAD_PES_ID_PESSOA", dto.IdtPessoa.DBValue, ParameterDirection.Input, dto.IdtPessoa.DbType));
			
			//Parametro pCAD_UNI_NR_CNES
			param.Add(Connection.CreateParameter("pCAD_UNI_NR_CNES", dto.NrCnes.DBValue, ParameterDirection.Input, dto.NrCnes.DbType));
			
			//Parametro pCAD_UNI_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			//Parametro pCAD_UNI_CD_HOSPITALAR
			param.Add(Connection.CreateParameter("pCAD_UNI_CD_HOSPITALAR", dto.CdHospitalar.DBValue, ParameterDirection.Input, dto.CdHospitalar.DbType));
			
			//Parametro pCAD_UNI_CD_UNID_HOSPITALAR
			param.Add(Connection.CreateParameter("pCAD_UNI_CD_UNID_HOSPITALAR", dto.UnidHospitalar.DBValue, ParameterDirection.Input, dto.UnidHospitalar.DbType));
			
			//Parametro pCAD_UNI_FL_CRONICO_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_CRONICO_OK", dto.CronicoOK.DBValue, ParameterDirection.Input, dto.CronicoOK.DbType));
			
			//Parametro pCAD_UNI_FL_PRIORIDADE_OK
			param.Add(Connection.CreateParameter("pCAD_UNI_FL_PRIORIDADE_OK", dto.PrioridadeOK.DBValue, ParameterDirection.Input, dto.PrioridadeOK.DbType));
			
			//Parametro pCAD_UNI_DS_UNIDADE
			param.Add(Connection.CreateParameter("pCAD_UNI_DS_UNIDADE", dto.DsUnidade.DBValue, ParameterDirection.Input, dto.DsUnidade.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}


        public UnidadeDataTable ListarUnidadeDoLocal(UnidadeDTO dto, int? idtLocal)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_UNI_ID_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_UNI_DS_IMAGEM_ASSOCIADA
            param.Add(Connection.CreateParameter("pCAD_UNI_DS_IMAGEM_ASSOCIADA", dto.Imagem.DBValue, ParameterDirection.Input, dto.Imagem.DbType));

            //Parametro pCAD_UNI_FL_STATUS
            param.Add(Connection.CreateParameter("pCAD_UNI_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

            //Parametro pCAD_UNI_DT_ULTIMO_STATUS
            param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMO_STATUS", dto.DtStatus.DBValue, ParameterDirection.Input, dto.DtStatus.DbType));

            //Parametro pCAD_UNI_FL_GRAVA_ATEND_OK
            param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_ATEND_OK", dto.GravaAtendimentoFL.DBValue, ParameterDirection.Input, dto.GravaAtendimentoFL.DbType));

            //Parametro pCAD_UNI_FL_LIBERA_AGENDA_OK
            param.Add(Connection.CreateParameter("pCAD_UNI_FL_LIBERA_AGENDA_OK", dto.LiberaAgendaFL.DBValue, ParameterDirection.Input, dto.LiberaAgendaFL.DbType));

            //Parametro pCAD_UNI_FL_GRAVA_CD_PAC_OK
            param.Add(Connection.CreateParameter("pCAD_UNI_FL_GRAVA_CD_PAC_OK", dto.GravaCodPacFL.DBValue, ParameterDirection.Input, dto.GravaCodPacFL.DbType));

            //Parametro pCAD_UNI_ID_UNIDADE_MASTER
            param.Add(Connection.CreateParameter("pCAD_UNI_ID_UNIDADE_MASTER", dto.UnidadeMasterFL.DBValue, ParameterDirection.Input, dto.UnidadeMasterFL.DbType));

            //Parametro pCAD_PES_ID_PESSOA
            param.Add(Connection.CreateParameter("pCAD_PES_ID_PESSOA", dto.IdtPessoa.DBValue, ParameterDirection.Input, dto.IdtPessoa.DbType));

            //Parametro pCAD_UNI_NR_CNES
            param.Add(Connection.CreateParameter("pCAD_UNI_NR_CNES", dto.NrCnes.DBValue, ParameterDirection.Input, dto.NrCnes.DbType));

            //Parametro pCAD_UNI_DT_ULTIMA_ATUALIZACAO
            param.Add(Connection.CreateParameter("pCAD_UNI_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            //Parametro pCAD_UNI_CD_HOSPITALAR
            param.Add(Connection.CreateParameter("pCAD_UNI_CD_HOSPITALAR", dto.CdHospitalar.DBValue, ParameterDirection.Input, dto.CdHospitalar.DbType));

            //Parametro pCAD_UNI_CD_UNID_HOSPITALAR
            param.Add(Connection.CreateParameter("pCAD_UNI_CD_UNID_HOSPITALAR", dto.UnidHospitalar.DBValue, ParameterDirection.Input, dto.UnidHospitalar.DbType));

            //Parametro pCAD_UNI_FL_CRONICO_OK
            param.Add(Connection.CreateParameter("pCAD_UNI_FL_CRONICO_OK", dto.CronicoOK.DBValue, ParameterDirection.Input, dto.CronicoOK.DbType));

            //Parametro pCAD_UNI_FL_PRIORIDADE_OK
            param.Add(Connection.CreateParameter("pCAD_UNI_FL_PRIORIDADE_OK", dto.PrioridadeOK.DBValue, ParameterDirection.Input, dto.PrioridadeOK.DbType));

            //Parametro pCAD_UNI_DS_UNIDADE
            param.Add(Connection.CreateParameter("pCAD_UNI_DS_UNIDADE", dto.DsUnidade.DBValue, ParameterDirection.Input, dto.DsUnidade.DbType));

            //Parametro pCAD_LAT_ID_LOCAL_ATENDIMENTO
            param.Add(Connection.CreateParameter("pCAD_LAT_ID_LOCAL_ATENDIMENTO", idtLocal, ParameterDirection.Input, DbType.Int32));

            #endregion

            UnidadeDataTable result = new UnidadeDataTable();
            string query = "PRC_ASS_ULO_RMT_S";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;
        }

        public UnidadeDataTable ListarUnidadesMaster()
        {
            string sqlString = "SELECT DISTINCT U.CAD_UNI_ID_UNIDADE_MASTER_AMIL CAD_UNI_ID_UNIDADE,\n" +
                            "                UM.CAD_UNI_DS_UNIDADE\n" +
                            "  FROM TB_CAD_UNI_UNIDADE U JOIN\n" +
                            "       TB_CAD_UNI_UNIDADE UM ON UM.CAD_UNI_ID_UNIDADE = U.CAD_UNI_ID_UNIDADE_MASTER_AMIL\n" +
                            " WHERE U.CAD_UNI_FL_STATUS = 'A'\n" +
                            " ORDER BY UM.CAD_UNI_DS_UNIDADE";

            UnidadeDataTable result = new UnidadeDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result;
        }
	}
}
