
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class PrincipioAtivo : Entity
    {        
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public PrincipioAtivoDataTable Sel(PrincipioAtivoDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_MTMD_PRIATI_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_DESCRICAO", dto.DsPrincipioAtivo.DBValue, ParameterDirection.Input, dto.DsPrincipioAtivo.DbType));
			#endregion	
			
			PrincipioAtivoDataTable result = new PrincipioAtivoDataTable();
            string query = "PRC_CAD_MTMD_PRINCIPIO_ATIVO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        //public PrincipioAtivoDTO SelChave(PrincipioAtivoDTO dto)
        //{            
        //    #region "Parametros"
        //    DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
        //    //Parametro Cursor
        //    param.Add(Connection.CreateParameterCursor());
			
        //    // Parametro pCAD_MTMD_PRIATI_ID
        //    param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
        //    #endregion	
			
        //    PrincipioAtivoDataTable result = new PrincipioAtivoDataTable();
        //    string query = "PRC_CAD_MTMD_PRINCIPIO_ATIVO_SID";
			
        //    //Executa o procedimento
        //    Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
        //    return result.TypedRow(0);
        //}

        public PrincipioAtivoDTO SelChave(PrincipioAtivoDTO dto)
        {
            string sqlString = "select * from tb_cad_mtmd_priati_princ_ativo p where p.cad_mtmd_priati_id = " + dto.Idt.Value;

            PrincipioAtivoDataTable result = new PrincipioAtivoDataTable();
            Connection.RecordSet(sqlString, result, CommandType.Text);

            return result.TypedRow(0);
        }

        /// <summary>
        /// Lista Materiais e Medicamentos relacionado ao principio ativo
        /// </summary>
        /// <param name="dto">PrincipioAtivoDTO</param>
        /// <returns>MaterialMedicamentoDataTable</returns>
        public MaterialMedicamentoDataTable SelMatMed(PrincipioAtivoDTO dto, MaterialMedicamentoDTO dtoMatMed)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pCAD_MTMD_PRIATI_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            //Parametro pCAD_MTMD_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dtoMatMed.Idt.DBValue, ParameterDirection.Input, dtoMatMed.Idt.DbType));
            #endregion

            MaterialMedicamentoDataTable result = new MaterialMedicamentoDataTable();
            string query = "PRC_CAD_MTMD_PATIVO_SIMILARES";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            return result;

        }

		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(PrincipioAtivoDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento

            string query = "PRC_CAD_MTMD_PRINCIPIO_ATIVO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(PrincipioAtivoDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_PRIATI_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_DESCRICAO", dto.DsPrincipioAtivo.DBValue, ParameterDirection.Input, dto.DsPrincipioAtivo.DbType));

            //Parametro pCAD_MTMD_FL_IRRITANTE
            param.Add(Connection.CreateParameter("pCAD_MTMD_FL_IRRITANTE", dto.FlIrritante.DBValue, ParameterDirection.Input, dto.FlIrritante.DbType));

            //Parametro pCAD_MTMD_FL_VESICANTE
            param.Add(Connection.CreateParameter("pCAD_MTMD_FL_VESICANTE", dto.FlVesicante.DBValue, ParameterDirection.Input, dto.FlVesicante.DbType));

            //Parametro pCAD_MTMD_FL_FLEBITANTE
            param.Add(Connection.CreateParameter("pCAD_MTMD_FL_FLEBITANTE", dto.FlFlebitante.DBValue, ParameterDirection.Input, dto.FlFlebitante.DbType));

            //Parametro pCAD_MTMD_ORIENTACAO
            param.Add(Connection.CreateParameter("pCAD_MTMD_ORIENTACAO", dto.DsOrientacao.DBValue, ParameterDirection.Input, dto.DsOrientacao.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));
			
			#endregion	

            string query = "PRC_CAD_MTMD_PRINCIPIO_ATIVO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
        public PrincipioAtivoDTO Ins(PrincipioAtivoDTO dto)
		{
            string query = "PRC_CAD_MTMD_PRINCIPIO_ATIVO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_PRIATI_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_PRIATI_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_DESCRICAO", dto.DsPrincipioAtivo.DBValue, ParameterDirection.Input, dto.DsPrincipioAtivo.DbType));

            //Parametro pCAD_MTMD_FL_IRRITANTE
            param.Add(Connection.CreateParameter("pCAD_MTMD_FL_IRRITANTE", dto.FlIrritante.DBValue, ParameterDirection.Input, dto.FlIrritante.DbType));

            //Parametro pCAD_MTMD_FL_VESICANTE
            param.Add(Connection.CreateParameter("pCAD_MTMD_FL_VESICANTE", dto.FlVesicante.DBValue, ParameterDirection.Input, dto.FlVesicante.DbType));

            //Parametro pCAD_MTMD_FL_FLEBITANTE
            param.Add(Connection.CreateParameter("pCAD_MTMD_FL_FLEBITANTE", dto.FlFlebitante.DBValue, ParameterDirection.Input, dto.FlFlebitante.DbType));

            //Parametro pCAD_MTMD_ORIENTACAO
            param.Add(Connection.CreateParameter("pCAD_MTMD_ORIENTACAO", dto.DsOrientacao.DBValue, ParameterDirection.Input, dto.DsOrientacao.DbType));

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.IdtUsuario.DBValue, ParameterDirection.Input, dto.IdtUsuario.DbType));

            param.Add(Connection.CreateParameterSequence());
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
            return dto;
		}

        /// <summary>
        /// Inclui matmed na relação de similares do principio ativo
        /// </summary>
        /// <param name="dto"></param>
        public void InsMatMed(MaterialMedicamentoDTO dto)
        {

            string query = "PRC_CAD_MTMD_PATIVO_SIMILAR_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_PRIATI_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));
			
			//Parametro pCAD_MTMD_PRIATI_DESCRICAO
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						


        }
        /// <summary>
        /// Exclui matmed da relação de similares do principio ativo
        /// </summary>
        /// <param name="dto"></param>
        public void DelMatMed(MaterialMedicamentoDTO dto)
        {
            string query = "PRC_CAD_MTMD_PATIVO_SIMILAR_D";

            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();


            //Parametro pCAD_MTMD_PRIATI_ID
            param.Add(Connection.CreateParameter("pCAD_MTMD_PRIATI_ID", dto.IdtPrincipioAtivo.DBValue, ParameterDirection.Input, dto.IdtPrincipioAtivo.DbType));

            //Parametro pCAD_MTMD_PRIATI_DESCRICAO
            param.Add(Connection.CreateParameter("pCAD_MTMD_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

            #endregion

            // Executa o Procedimento
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

        }
	}
}
