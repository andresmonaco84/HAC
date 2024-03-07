
using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.Seguranca.DTO;

namespace HospitalAnaCosta.Services.Seguranca.Model
{
	public partial class Usuario : Entity
	{			
		/// <summary>
		/// Listar todos os registros
		/// </summary>
		public UsuarioDataTable Listar(UsuarioDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());

			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));

			//Parametro pSEG_USU_DS_NOME
			param.Add(Connection.CreateParameter("pSEG_USU_DS_NOME", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));

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
			param.Add(Connection.CreateParameter("pSEG_USU_FL_TROCAR_SENHA_OK", dto.FlagTrocarSenha.DBValue, ParameterDirection.Input, dto.FlagTrocarSenha.DbType));

			//Parametro pSEG_USU_FL_SENHA_NAO_EXPIRA_OK
            param.Add(Connection.CreateParameter("pSEG_USU_FL_SENHA_NAO_EXPIR_OK", dto.FlagSenhaNaoExpira.DBValue, ParameterDirection.Input, dto.FlagSenhaNaoExpira.DbType));

			//Parametro pSEG_USU_DT_EXPIRACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_EXPIRACAO", dto.DataExpiracaoSenha.DBValue, ParameterDirection.Input, dto.DataExpiracaoSenha.DbType));

			//Parametro pSEG_USU_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_USU_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));

			//Parametro pSEG_USU_FL_RESPONS_PERFIL_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_RESPONS_PERFIL_OK", dto.FlagResponsavelPerfil.DBValue, ParameterDirection.Input, dto.FlagResponsavelPerfil.DbType));

			//Parametro pSEG_USU_QT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_QT_LOGIN_INVALIDO", dto.QuantidadeLoginInvalido.DBValue, ParameterDirection.Input, dto.QuantidadeLoginInvalido.DbType));

			//Parametro pSEG_USU_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));

			//Parametro pSEG_USU_DT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_LOGIN_INVALIDO", dto.DataLoginInvalido.DBValue, ParameterDirection.Input, dto.DataLoginInvalido.DbType));

			//Parametro pSEG_USU_ID_ATUALIZADO_POR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_ATUALIZADO_POR", dto.IdtUsuarioAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizacao.DbType));

			//Parametro pSEG_USU_TP_INTER_EXTER
			param.Add(Connection.CreateParameter("pSEG_USU_TP_INTER_EXTER", dto.Tipo.DBValue, ParameterDirection.Input, dto.Tipo.DbType));

			//Parametro pSEG_USU_DS_CARGO
			param.Add(Connection.CreateParameter("pSEG_USU_DS_CARGO", dto.Cargo.DBValue, ParameterDirection.Input, dto.Cargo.DbType));

			//Parametro pSEG_USU_ID_USU_RESP_SUPERIOR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USU_RESP_SUPERIOR", dto.IdtUsuarioSuperior.DBValue, ParameterDirection.Input, dto.IdtUsuarioSuperior.DbType));
			#endregion	
			
			UsuarioDataTable result = new UsuarioDataTable();
			string query = "PRC_SEG_USU_USUARIO_R_L";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
		/// Listar o registro utilizando PK
		/// </summary>
		public UsuarioDTO Pesquisar(UsuarioDTO dto)
		{            
			#region "Parametros"
			DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
			param.Add(Connection.CreateParameterCursor());
			
			// Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			
			#endregion	
			
			UsuarioDataTable result = new UsuarioDataTable();
			string query = "PRC_SEG_USU_USUARIO_R_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			if (result.Rows.Count > 0)
				return result.TypedRow(0);
			else
				return null;
		}

		
		/// <summary>
		/// Exclui o registro
		/// </summary>        

		public void Excluir(UsuarioDTO dto)
		{
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
		
		   #endregion				
			//Executa o procedimento
			
			string query = "PRC_SEG_USU_USUARIO_R_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Altera o registro
		/// </summary>			
		public void Alterar(UsuarioDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_USU_DS_NOME
			param.Add(Connection.CreateParameter("pSEG_USU_DS_NOME", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
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
			param.Add(Connection.CreateParameter("pSEG_USU_FL_TROCAR_SENHA_OK", dto.FlagTrocarSenha.DBValue, ParameterDirection.Input, dto.FlagTrocarSenha.DbType));
			
			//Parametro pSEG_USU_FL_SENHA_NAO_EXPIRA_OK
            param.Add(Connection.CreateParameter("pSEG_USU_FL_SENHA_NAO_EXPIR_OK", dto.FlagSenhaNaoExpira.DBValue, ParameterDirection.Input, dto.FlagSenhaNaoExpira.DbType));
			
			//Parametro pSEG_USU_DT_EXPIRACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_EXPIRACAO", dto.DataExpiracaoSenha.DBValue, ParameterDirection.Input, dto.DataExpiracaoSenha.DbType));
			
			//Parametro pSEG_USU_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_USU_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));
			
			//Parametro pSEG_USU_FL_RESPONS_PERFIL_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_RESPONS_PERFIL_OK", dto.FlagResponsavelPerfil.DBValue, ParameterDirection.Input, dto.FlagResponsavelPerfil.DbType));
			
			//Parametro pSEG_USU_QT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_QT_LOGIN_INVALIDO", dto.QuantidadeLoginInvalido.DBValue, ParameterDirection.Input, dto.QuantidadeLoginInvalido.DbType));
			
			//Parametro pSEG_USU_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));
			
			//Parametro pSEG_USU_DT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_LOGIN_INVALIDO", dto.DataLoginInvalido.DBValue, ParameterDirection.Input, dto.DataLoginInvalido.DbType));
			
			//Parametro pSEG_USU_ID_ATUALIZADO_POR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_ATUALIZADO_POR", dto.IdtUsuarioAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizacao.DbType));
			
			//Parametro pSEG_USU_TP_INTER_EXTER
			param.Add(Connection.CreateParameter("pSEG_USU_TP_INTER_EXTER", dto.Tipo.DBValue, ParameterDirection.Input, dto.Tipo.DbType));
			
			//Parametro pSEG_USU_DS_CARGO
			param.Add(Connection.CreateParameter("pSEG_USU_DS_CARGO", dto.Cargo.DBValue, ParameterDirection.Input, dto.Cargo.DbType));
			
			//Parametro pSEG_USU_ID_USU_RESP_SUPERIOR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USU_RESP_SUPERIOR", dto.IdtUsuarioSuperior.DBValue, ParameterDirection.Input, dto.IdtUsuarioSuperior.DbType));
			
			#endregion	

			string query = "PRC_SEG_USU_USUARIO_R_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
		/// Inclui o registro
		/// </summary>			
		public void Incluir(UsuarioDTO dto)
		{			
			string query = "PRC_SEG_USU_USUARIO_R_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro Sequence			
			param.Add(Connection.CreateParameterSequence());
			
			
			//Parametro pSEG_USU_ID_USUARIO
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USUARIO", dto.Idt.DBValue, ParameterDirection.Input, dto.Idt.DbType));
			
			//Parametro pSEG_USU_DS_NOME
			param.Add(Connection.CreateParameter("pSEG_USU_DS_NOME", dto.Nome.DBValue, ParameterDirection.Input, dto.Nome.DbType));
			
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
			param.Add(Connection.CreateParameter("pSEG_USU_FL_TROCAR_SENHA_OK", dto.FlagTrocarSenha.DBValue, ParameterDirection.Input, dto.FlagTrocarSenha.DbType));
			
			//Parametro pSEG_USU_FL_SENHA_NAO_EXPIRA_OK
            param.Add(Connection.CreateParameter("pSEG_USU_FL_SENHA_NAO_EXPIR_OK", dto.FlagSenhaNaoExpira.DBValue, ParameterDirection.Input, dto.FlagSenhaNaoExpira.DbType));
			
			//Parametro pSEG_USU_DT_EXPIRACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_EXPIRACAO", dto.DataExpiracaoSenha.DBValue, ParameterDirection.Input, dto.DataExpiracaoSenha.DbType));
			
			//Parametro pSEG_USU_FL_STATUS
			param.Add(Connection.CreateParameter("pSEG_USU_FL_STATUS", dto.FlagStatus.DBValue, ParameterDirection.Input, dto.FlagStatus.DbType));
			
			//Parametro pSEG_USU_FL_RESPONS_PERFIL_OK
			param.Add(Connection.CreateParameter("pSEG_USU_FL_RESPONS_PERFIL_OK", dto.FlagResponsavelPerfil.DBValue, ParameterDirection.Input, dto.FlagResponsavelPerfil.DbType));
			
			//Parametro pSEG_USU_QT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_QT_LOGIN_INVALIDO", dto.QuantidadeLoginInvalido.DBValue, ParameterDirection.Input, dto.QuantidadeLoginInvalido.DbType));
			
			//Parametro pSEG_USU_DT_ULTIMA_ATUALIZACAO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_ULTIMA_ATUALIZACAO", dto.DataUltimaAtualizacao.DBValue, ParameterDirection.Input, dto.DataUltimaAtualizacao.DbType));
			
			//Parametro pSEG_USU_DT_LOGIN_INVALIDO
			param.Add(Connection.CreateParameter("pSEG_USU_DT_LOGIN_INVALIDO", dto.DataLoginInvalido.DBValue, ParameterDirection.Input, dto.DataLoginInvalido.DbType));
			
			//Parametro pSEG_USU_ID_ATUALIZADO_POR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_ATUALIZADO_POR", dto.IdtUsuarioAtualizacao.DBValue, ParameterDirection.Input, dto.IdtUsuarioAtualizacao.DbType));
			
			//Parametro pSEG_USU_TP_INTER_EXTER
			param.Add(Connection.CreateParameter("pSEG_USU_TP_INTER_EXTER", dto.Tipo.DBValue, ParameterDirection.Input, dto.Tipo.DbType));
			
			//Parametro pSEG_USU_DS_CARGO
			param.Add(Connection.CreateParameter("pSEG_USU_DS_CARGO", dto.Cargo.DBValue, ParameterDirection.Input, dto.Cargo.DbType));
			
			//Parametro pSEG_USU_ID_USU_RESP_SUPERIOR
			param.Add(Connection.CreateParameter("pSEG_USU_ID_USU_RESP_SUPERIOR", dto.IdtUsuarioSuperior.DBValue, ParameterDirection.Input, dto.IdtUsuarioSuperior.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						
				
			//Recupera o valor da Sequence utilizado na procedure     
			
						
			   dto.Idt.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
			

		}
	}
}
