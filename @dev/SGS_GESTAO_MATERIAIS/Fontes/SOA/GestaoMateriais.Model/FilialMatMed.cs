
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Model
{
    public partial class FilialMatMed : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public FilialMatMedDataTable Sel(FilialMatMedDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pCAD_MTMD_FILIAL_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_DESCRICAO", dto.DsFilial.DBValue, ParameterDirection.Input, dto.DsFilial.DbType));
			#endregion	
			
			FilialMatMedDataTable result = new FilialMatMedDataTable();
			string query = "PRC_CAD_MTMD_FILIAL_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public FilialMatMedDTO SelChave(FilialMatMedDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			FilialMatMedDataTable result = new FilialMatMedDataTable();
			string query = "PRC_CAD_MTMD_FILIAL_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(FilialMatMedDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_CAD_MTMD_FILIAL_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(FilialMatMedDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_DESCRICAO", dto.DsFilial.DBValue, ParameterDirection.Input, dto.DsFilial.DbType));
			
			#endregion	

			string query = "PRC_CAD_MTMD_FILIAL_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(FilialMatMedDTO dto)
		{			
			string query = "PRC_CAD_MTMD_FILIAL_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCAD_MTMD_FILIAL_ID
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_ID", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pCAD_MTMD_FILIAL_DESCRICAO
			param.Add(Connection.CreateParameter("pCAD_MTMD_FILIAL_DESCRICAO", dto.DsFilial.DBValue, ParameterDirection.Input, dto.DsFilial.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}

        public DataTable ObterDadosFilialRM(decimal idFilial)
        {
            DataTable result = new DataTable();
            string query = "SELECT NOME,\n" +
                                  "CGC CNPJ,\n" +
                                  "DTIPORUA.DESCRICAO || ' ' || RUA || ' ' || NUMERO || ' - ' || BAIRRO ENDERECO,\n" +
                                  "CIDADE,\n" +
                                  "ESTADO,\n" +
                                  "INSCRICAOESTADUAL INSC_ESTADUAL,\n" +
                                  "INSCMUN INSC_MUNICIPAL,\n" +
                                  "NUMREGJUNTA INSC_JUNTA_COM\n" +
                           "FROM GFILIAL@RMDB  GFILIAL,\n" +
                                "DTIPORUA@RMDB DTIPORUA\n" +
                           "WHERE DTIPORUA.CODIGO = TIPORUA AND\n" +
                                 "CODFILIAL = 1 AND\n" +
                                 "CODCOLIGADA = " + idFilial.ToString();

            //Se não for produção, não usar dblink RM
            if (Connection.ConnectionString.ToUpper().IndexOf("DESENV") > -1 ||
                Connection.ConnectionString.ToUpper().IndexOf("SGSDEV") > -1 ||
                Connection.ConnectionString.ToUpper().IndexOf("SGS2") > -1)
            {
                query = query.Replace("GFILIAL@RMDB", "RM.GFILIAL");
                query = query.Replace("DTIPORUA@RMDB", "RM.DTIPORUA");
            }                

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable ObterEmpresaEmprestimo(decimal? idEmpresa)
        {
            DataTable result = new DataTable();
            string query = "SELECT CAD_MTMD_ID_EMP_EMPRESTIMO,\n" +
                           "       CAD_MTMD_EMP_DESCRICAO,\n" +
                           "       CAD_MTMD_EMP_CNPJ\n" +
                           "FROM TB_CAD_MTMD_EMPRESA_EMPRESTIMO";

            if (idEmpresa != null)
                query += " WHERE CAD_MTMD_ID_EMP_EMPRESTIMO = " + idEmpresa.Value.ToString() + "\n";

            query += " ORDER BY CAD_MTMD_EMP_DESCRICAO";

            //Executa o procedimento
            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public DataTable InserirEmpresaEmprestimo(string descricaoEmpresa, string cnpjEmpresa)
        {
            DataTable result = new DataTable();
            string query = "SELECT max(CAD_MTMD_ID_EMP_EMPRESTIMO) a FROM TB_CAD_MTMD_EMPRESA_EMPRESTIMO";
            Connection.RecordSet(query, result, CommandType.Text);

            int seq = Convert.ToInt32(result.Rows[0][0])+1;
            
             query = string.Format("INSERT INTO TB_CAD_MTMD_EMPRESA_EMPRESTIMO (CAD_MTMD_ID_EMP_EMPRESTIMO, CAD_MTMD_EMP_DESCRICAO, CAD_MTMD_EMP_CNPJ) VALUES ({0},'{1}','{2}') ",
                 seq, descricaoEmpresa, cnpjEmpresa);                        
            
            Connection.RecordSet(query);

            query = "SELECT CAD_MTMD_ID_EMP_EMPRESTIMO, CAD_MTMD_EMP_DESCRICAO, CAD_MTMD_EMP_CNPJ FROM TB_CAD_MTMD_EMPRESA_EMPRESTIMO ORDER BY CAD_MTMD_EMP_DESCRICAO";

            Connection.RecordSet(query, result, CommandType.Text);

            return result;
        }

        public void EnviarSMS(string destino, string texto)
        {
            string sqlString = "INSERT INTO TB_SGS_EML_ENVIA_EMAIL EE\n" +
                            "          (SGS_EML_ID,\n" +
                            "          SGS_EML_CURTO_TEXTO,\n" +
                            "          SGS_EML_DESTINO,\n" +
                            "          SGS_EML_STATUS,\n" +
                            "          SGS_EML_ASSUNTO,\n" +
                            "          SGS_EML_DT_ULTIMA_ATUALIZACAO)\n" +
                            "        values\n" +
                            "          (seq_sgs_eml_01.nextval,\n" +
                            "          '" + texto.Trim() + "',\n" +
                            "          '" + destino.Trim() + "',\n" +
                            "          0,\n" +
                            "          'SMS',\n" +
                            "          sysdate)";

            Connection.ExecuteCommand(sqlString);
        }

        public void EnviarEmail(string destino, string texto, string assunto)
        {
            string sqlString = "INSERT INTO TB_SGS_EML_ENVIA_EMAIL EE\n" +
                            "          (SGS_EML_ID,\n" +
                            "          SGS_EML_TEXTO,\n" +
                            "          SGS_EML_DESTINO,\n" +
                            "          SGS_EML_STATUS,\n" +
                            "          SGS_EML_ASSUNTO,\n" +
                            "          SGS_EML_DT_ULTIMA_ATUALIZACAO)\n" +
                            "        values\n" +
                            "          (seq_sgs_eml_01.nextval,\n" +
                            "          '" + texto.Trim() + "',\n" +
                            "          '" + destino.Trim() + "',\n" +
                            "          'N',\n" +
                            "          '" + assunto.Trim() + "',\n" +
                            "          sysdate)";

            Connection.ExecuteCommand(sqlString);
        }
	}
}