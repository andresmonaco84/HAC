
using System;
using System.Text;
using System.Data.Common;
using System.Data.Common;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using System.Data;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class Usuario : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public UsuarioDataTable Sel(UsuarioDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_USU_DS_NOME
			param.Add(Connection.CreateParameter("pSEG_USU_DS_NOME", dto.NmUsuario.DBValue, ParameterDirection.Input, dto.NmUsuario.DbType));

			//Parametro pSEG_USU_DS_LOGIN
			param.Add(Connection.CreateParameter("pSEG_USU_DS_LOGIN", dto.Login.DBValue, ParameterDirection.Input, dto.Login.DbType));

			//Parametro pSEG_USU_DS_EMAIL
			param.Add(Connection.CreateParameter("pSEG_USU_DS_EMAIL", dto.Email.DBValue, ParameterDirection.Input, dto.Email.DbType));

			//Parametro pSEG_USU_CD_PASSWORD
			param.Add(Connection.CreateParameter("pSEG_USU_CD_PASSWORD", dto.Senha.DBValue, ParameterDirection.Input, dto.Senha.DbType));

			//Parametro pSEG_USU_CD_MATRICULA
			param.Add(Connection.CreateParameter("pSEG_USU_CD_MATRICULA", dto.Matricula.DBValue, ParameterDirection.Input, dto.Matricula.DbType));

			//Parametro pSEG_USU_DS_TELEFONE
			param.Add(Connection.CreateParameter("pSEG_USU_DS_TELEFONE", dto.Telefone.DBValue, ParameterDirection.Input, dto.Telefone.DbType));

			//Parametro pSEG_USU_DS_RAMAL
			param.Add(Connection.CreateParameter("pSEG_USU_DS_RAMAL", dto.Ramal.DBValue, ParameterDirection.Input, dto.Ramal.DbType));

			//Parametro pSEG_USU_FL_TROCAR_SENHA_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_TROCAR_SENHA_OK", dto.FlTrocarSenha.DBValue, ParameterDirection.Input, dto.FlTrocarSenha.DbType));

			//Parametro pSEG_USU_FL_SENHA_NAO_EXPIRA
			// param.Add(Connection.CreateParameter("pSEG_USU_FL_SENHA_NAO_EXPIRA", dto.FlSenhaNaoExpira.DBValue, ParameterDirection.Input, dto.FlSenhaNaoExpira.DbType));

			//Parametro pSEG_USU_DT_EXPIRACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_EXPIRACAO", dto.DtExpiraSenha.DBValue, ParameterDirection.Input, dto.DtExpiraSenha.DbType));

			//Parametro pSEG_USU_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_USU_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));

			//Parametro pSEG_USU_FL_RESPONS_PERFIL_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_RESPONS_PERFIL_OK", dto.FlResponsavelPerfilOk.DBValue, ParameterDirection.Input, dto.FlResponsavelPerfilOk.DbType));

			//Parametro pSEG_USU_QT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_QT_LOGIN_INVALIDO", dto.QtdLoginInvalido.DBValue, ParameterDirection.Input, dto.QtdLoginInvalido.DbType));

			//Parametro pSEG_USU_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));

			//Parametro pSEG_USU_DT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_LOGIN_INVALIDO", dto.DtLoginInvalido.DBValue, ParameterDirection.Input, dto.DtLoginInvalido.DbType));

			//Parametro pSEG_USU_ID_ATUALIZADO_POR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_ATUALIZADO_POR", dto.IdtUsuAtualizado.DBValue, ParameterDirection.Input, dto.IdtUsuAtualizado.DbType));

			//Parametro pSEG_USU_TP_INTER_EXTER
			param.Add(Connection.CreateParameter("pSEG_USU_TP_INTER_EXTER", dto.TpInterExter.DBValue, ParameterDirection.Input, dto.TpInterExter.DbType));

			//Parametro pSEG_USU_DS_CARGO
			param.Add(Connection.CreateParameter("pSEG_USU_DS_CARGO", dto.DsCargo.DBValue, ParameterDirection.Input, dto.DsCargo.DbType));

			//Parametro pSEG_USU_ID_USU_RESP_SUPERIOR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USU_RESP_SUPERIOR", dto.IdtUsuarioSuperior.DBValue, ParameterDirection.Input, dto.IdtUsuarioSuperior.DbType));

            //Parametro pSEG_USU_NR_CPF
            param.Add(Connection.CreateParameter("pSEG_USU_NR_CPF", dto.CPF.DBValue, ParameterDirection.Input, dto.CPF.DbType));

            //Parametro pSEG_USU_DT_NASCIMENTO
            param.Add(Connection.CreateParameter("pSEG_USU_DT_NASCIMENTO", dto.DataNascimento.DBValue, ParameterDirection.Input, dto.DataNascimento.DbType));
			#endregion	
			
			UsuarioDataTable result = new UsuarioDataTable();
			string query = "PRC_SEG_USUARIO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public UsuarioDTO SelChave(UsuarioDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			UsuarioDataTable result = new UsuarioDataTable();
			string query = "PRC_SEG_USUARIO_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

        public DataTable buscaPorNome(UsuarioDTO dto)
        {
            DataTable result = new DataTable();
            string sqlString = " SELECT SEG_USU_ID_USUARIO,    SEG_USU_DS_NOME,      SEG_USU_DS_LOGIN, SEG_USU_DS_EMAIL, " +
                               "        SEG_USU_CD_MATRICULA,  SEG_USU_DS_TELEFONE,  SEG_USU_DS_RAMAL, SEG_USU_FL_STATUS " +
                               " FROM TB_SEG_USU_USUARIO " +
                 string.Format(" WHERE SEG_USU_DS_NOME LIKE '%{0}%'", dto.NmUsuario.Value) +
                               " ORDER BY SEG_USU_DS_NOME ";

            Connection.RecordSet(sqlString, result, CommandType.Text);
            return result;
        }
		
		/// <summary>
        /// Exclui o registro
        /// </summary>        

		public void Del(UsuarioDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_SEG_USUARIO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(UsuarioDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_USU_DS_NOME
			param.Add(Connection.CreateParameter("pSEG_USU_DS_NOME", dto.NmUsuario.DBValue, ParameterDirection.Input, dto.NmUsuario.DbType));
			
			//Parametro pSEG_USU_DS_LOGIN
			param.Add(Connection.CreateParameter("pSEG_USU_DS_LOGIN", dto.Login.DBValue, ParameterDirection.Input, dto.Login.DbType));
			
			//Parametro pSEG_USU_DS_EMAIL
			param.Add(Connection.CreateParameter("pSEG_USU_DS_EMAIL", dto.Email.DBValue, ParameterDirection.Input, dto.Email.DbType));
			
			//Parametro pSEG_USU_CD_PASSWORD
			param.Add(Connection.CreateParameter("pSEG_USU_CD_PASSWORD", dto.Senha.DBValue, ParameterDirection.Input, dto.Senha.DbType));
			
			//Parametro pSEG_USU_CD_MATRICULA
			param.Add(Connection.CreateParameter("pSEG_USU_CD_MATRICULA", dto.Matricula.DBValue, ParameterDirection.Input, dto.Matricula.DbType));
			
			//Parametro pSEG_USU_DS_TELEFONE
			param.Add(Connection.CreateParameter("pSEG_USU_DS_TELEFONE", dto.Telefone.DBValue, ParameterDirection.Input, dto.Telefone.DbType));
			
			//Parametro pSEG_USU_DS_RAMAL
			param.Add(Connection.CreateParameter("pSEG_USU_DS_RAMAL", dto.Ramal.DBValue, ParameterDirection.Input, dto.Ramal.DbType));
			
			//Parametro pSEG_USU_FL_TROCAR_SENHA_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_TROCAR_SENHA_OK", dto.FlTrocarSenha.DBValue, ParameterDirection.Input, dto.FlTrocarSenha.DbType));

            //Parametro pSEG_USU_FL_SENHA_NAO_EXPIRA
            param.Add(Connection.CreateParameter("pSEG_USU_FL_SENHA_NAO_EXPIRA", dto.FlSenhaNaoExpira.DBValue, ParameterDirection.Input, dto.FlSenhaNaoExpira.DbType));
			
			//Parametro pSEG_USU_DT_EXPIRACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_EXPIRACAO", dto.DtExpiraSenha.DBValue, ParameterDirection.Input, dto.DtExpiraSenha.DbType));
			
			//Parametro pSEG_USU_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_USU_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));
			
			//Parametro pSEG_USU_FL_RESPONS_PERFIL_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_RESPONS_PERFIL_OK", dto.FlResponsavelPerfilOk.DBValue, ParameterDirection.Input, dto.FlResponsavelPerfilOk.DbType));
			
			//Parametro pSEG_USU_QT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_QT_LOGIN_INVALIDO", dto.QtdLoginInvalido.DBValue, ParameterDirection.Input, dto.QtdLoginInvalido.DbType));
			
			//Parametro pSEG_USU_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_ULTIMA_ATUALIZACAO", dto.DtAtualizacao.DBValue, ParameterDirection.Input, dto.DtAtualizacao.DbType));
			
			//Parametro pSEG_USU_DT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_LOGIN_INVALIDO", dto.DtLoginInvalido.DBValue, ParameterDirection.Input, dto.DtLoginInvalido.DbType));
			
			//Parametro pSEG_USU_ID_ATUALIZADO_POR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_ATUALIZADO_POR", dto.IdtUsuAtualizado.DBValue, ParameterDirection.Input, dto.IdtUsuAtualizado.DbType));
			
			//Parametro pSEG_USU_TP_INTER_EXTER
			param.Add(Connection.CreateParameter("pSEG_USU_TP_INTER_EXTER", dto.TpInterExter.DBValue, ParameterDirection.Input, dto.TpInterExter.DbType));
			
			//Parametro pSEG_USU_DS_CARGO
			param.Add(Connection.CreateParameter("pSEG_USU_DS_CARGO", dto.DsCargo.DBValue, ParameterDirection.Input, dto.DsCargo.DbType));
			
			//Parametro pSEG_USU_ID_USU_RESP_SUPERIOR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USU_RESP_SUPERIOR", dto.IdtUsuarioSuperior.DBValue, ParameterDirection.Input, dto.IdtUsuarioSuperior.DbType));

            //Parametro pSEG_USU_NR_CPF
            param.Add(Connection.CreateParameter("pSEG_USU_NR_CPF", dto.CPF.DBValue, ParameterDirection.Input, dto.CPF.DbType));

            //Parametro pSEG_USU_DT_NASCIMENTO
            param.Add(Connection.CreateParameter("pSEG_USU_DT_NASCIMENTO", dto.DataNascimento.DBValue, ParameterDirection.Input, dto.DataNascimento.DbType));
			
			#endregion	

			string query = "PRC_SEG_USUARIO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}

        /// <summary>
        /// Coloca senha padrão para o usuário
        /// </summary>			
        public void AtribuirSenhaPadrao(UsuarioDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro pSEG_USU_ID_USUARIO
            param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));            

            #endregion

            string query = "PRC_SEG_USU_SENHA_PADRAO_U";

            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
        }
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(UsuarioDTO dto)
		{			
			string query = "PRC_SEG_USUARIO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();						
			
			//Parametro pSEG_USU_DS_NOME
			param.Add(Connection.CreateParameter("pSEG_USU_DS_NOME", dto.NmUsuario.DBValue, ParameterDirection.Input, dto.NmUsuario.DbType));
			
			//Parametro pSEG_USU_DS_LOGIN
			param.Add(Connection.CreateParameter("pSEG_USU_DS_LOGIN", dto.Login.DBValue, ParameterDirection.Input, dto.Login.DbType));
			
			//Parametro pSEG_USU_DS_EMAIL
			param.Add(Connection.CreateParameter("pSEG_USU_DS_EMAIL", dto.Email.DBValue, ParameterDirection.Input, dto.Email.DbType));
			
			//Parametro pSEG_USU_CD_PASSWORD
			param.Add(Connection.CreateParameter("pSEG_USU_CD_PASSWORD", dto.Senha.DBValue, ParameterDirection.Input, dto.Senha.DbType));
			
			//Parametro pSEG_USU_CD_MATRICULA
			param.Add(Connection.CreateParameter("pSEG_USU_CD_MATRICULA", dto.Matricula.DBValue, ParameterDirection.Input, dto.Matricula.DbType));
			
			//Parametro pSEG_USU_DS_TELEFONE
			param.Add(Connection.CreateParameter("pSEG_USU_DS_TELEFONE", dto.Telefone.DBValue, ParameterDirection.Input, dto.Telefone.DbType));
			
			//Parametro pSEG_USU_DS_RAMAL
			param.Add(Connection.CreateParameter("pSEG_USU_DS_RAMAL", dto.Ramal.DBValue, ParameterDirection.Input, dto.Ramal.DbType));

            //Parametro pSEG_USU_FL_TROCAR_SENHA_OK
            param.Add(Connection.CreateParameter("pSEG_USU_FL_TROCAR_SENHA_OK", dto.FlTrocarSenha.DBValue, ParameterDirection.Input, dto.FlTrocarSenha.DbType));

			//Parametro pSEG_USU_FL_SENHA_NAO_EXPIRA
			param.Add(Connection.CreateParameter("pSEG_USU_FL_SENHA_NAO_EXPIRA", dto.FlSenhaNaoExpira.DBValue, ParameterDirection.Input, dto.FlSenhaNaoExpira.DbType));
			
			//Parametro pSEG_USU_DT_EXPIRACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_EXPIRACAO", dto.DtExpiraSenha.DBValue, ParameterDirection.Input, dto.DtExpiraSenha.DbType));
			
			//Parametro pSEG_USU_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_USU_FL_STATUS", dto.Status.DBValue, ParameterDirection.Input, dto.Status.DbType));
			
			//Parametro pSEG_USU_FL_RESPONS_PERFIL_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_RESPONS_PERFIL_OK", dto.FlResponsavelPerfilOk.DBValue, ParameterDirection.Input, dto.FlResponsavelPerfilOk.DbType));
			
			//Parametro pSEG_USU_QT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_QT_LOGIN_INVALIDO", dto.QtdLoginInvalido.DBValue, ParameterDirection.Input, dto.QtdLoginInvalido.DbType));
						
			//Parametro pSEG_USU_DT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_LOGIN_INVALIDO", dto.DtLoginInvalido.DBValue, ParameterDirection.Input, dto.DtLoginInvalido.DbType));
			
			//Parametro pSEG_USU_ID_ATUALIZADO_POR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_ATUALIZADO_POR", dto.IdtUsuAtualizado.DBValue, ParameterDirection.Input, dto.IdtUsuAtualizado.DbType));
			
			//Parametro pSEG_USU_TP_INTER_EXTER
			param.Add(Connection.CreateParameter("pSEG_USU_TP_INTER_EXTER", dto.TpInterExter.DBValue, ParameterDirection.Input, dto.TpInterExter.DbType));
			
			//Parametro pSEG_USU_DS_CARGO
			param.Add(Connection.CreateParameter("pSEG_USU_DS_CARGO", dto.DsCargo.DBValue, ParameterDirection.Input, dto.DsCargo.DbType));
			
			//Parametro pSEG_USU_ID_USU_RESP_SUPERIOR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USU_RESP_SUPERIOR", dto.IdtUsuarioSuperior.DBValue, ParameterDirection.Input, dto.IdtUsuarioSuperior.DbType));

            //Parametro pSEG_USU_NR_CPF
            param.Add(Connection.CreateParameter("pSEG_USU_NR_CPF", dto.CPF.DBValue, ParameterDirection.Input, dto.CPF.DbType));

            //Parametro pSEG_USU_DT_NASCIMENTO
            param.Add(Connection.CreateParameter("pSEG_USU_DT_NASCIMENTO", dto.DataNascimento.DBValue, ParameterDirection.Input, dto.DataNascimento.DbType));

            param.Add(Connection.CreateParameterSequence());
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);            
            dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());		

		}

        public string GeraToken(string usuario, string acao)
        {
            string query = "PRC_SEGURANCA_TOKEN";
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            param.Add(Connection.CreateParameter("P_IDENTIFICACAO", usuario, ParameterDirection.Input, DbType.String));
            Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);

            DataTable result = new DataTable();
            string sql = string.Format("SELECT SGS.FNC_SEGURANCA_TOKEN('{0}','{1}') FROM DUAL", usuario, acao);
            Connection.RecordSet(sql, result, CommandType.Text);

            if (result.Rows.Count > 0)
                return result.Rows[0][0].ToString();
            else
                return string.Empty;
        }
	}
}