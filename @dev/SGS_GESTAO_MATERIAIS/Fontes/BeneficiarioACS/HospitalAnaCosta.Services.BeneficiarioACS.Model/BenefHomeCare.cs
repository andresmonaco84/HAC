using System;
using System.Text;
using System.Data;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Model
{
    public partial class BenefHomeCare : Entity
    {			
		/// <summary>
        /// Listar todos os registros
        /// </summary>
        public BenefHomeCareDataTable Sel(BenefHomeCareDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pBNF_HOMECARE_ID
			param.Add(Connection.CreateParameter("pBNF_HOMECARE_ID", dto.CodigoHomeCare.DBValue, ParameterDirection.Input, dto.CodigoHomeCare.DbType));

			//Parametro pBNF_COD_PLANO
			param.Add(Connection.CreateParameter("pBNF_COD_PLANO", dto.CodigoPlano.DBValue, ParameterDirection.Input, dto.CodigoPlano.DbType));

			//Parametro pBNF_LOJA_ID
			param.Add(Connection.CreateParameter("pBNF_LOJA_ID", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));

			//Parametro pBNF_BEN_ID
			param.Add(Connection.CreateParameter("pBNF_BEN_ID", dto.CodigoMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoMatriculaBenef.DbType));

			//Parametro pBNF_COD_SEQ
			param.Add(Connection.CreateParameter("pBNF_COD_SEQ", dto.CodigoSeqMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoSeqMatriculaBenef.DbType));

			//Parametro pBNF_COD_NUM_PLANO
			param.Add(Connection.CreateParameter("pBNF_COD_NUM_PLANO", dto.CodigoNumericoPlano.DBValue, ParameterDirection.Input, dto.CodigoNumericoPlano.DbType));

			//Parametro pBNF_PLA_ID_PLANO
			param.Add(Connection.CreateParameter("pBNF_PLA_ID_PLANO", dto.IdtPlanoSGS.DBValue, ParameterDirection.Input, dto.IdtPlanoSGS.DbType));

			//Parametro pBNF_FL_ATIVO
			param.Add(Connection.CreateParameter("pBNF_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));

			//Parametro pBNF_ENDERECO
			param.Add(Connection.CreateParameter("pBNF_ENDERECO", dto.Endereco.DBValue, ParameterDirection.Input, dto.Endereco.DbType));

			//Parametro pBNF_BAIRRO
			param.Add(Connection.CreateParameter("pBNF_BAIRRO", dto.Bairro.DBValue, ParameterDirection.Input, dto.Bairro.DbType));

			//Parametro pBNF_UF
			param.Add(Connection.CreateParameter("pBNF_UF", dto.UF.DBValue, ParameterDirection.Input, dto.UF.DbType));

			//Parametro pBNF_NUMERO
			param.Add(Connection.CreateParameter("pBNF_NUMERO", dto.NumeroEndereco.DBValue, ParameterDirection.Input, dto.NumeroEndereco.DbType));

			//Parametro pBNF_CEP
			param.Add(Connection.CreateParameter("pBNF_CEP", dto.CEP.DBValue, ParameterDirection.Input, dto.CEP.DbType));

			//Parametro pBNF_DDD
			param.Add(Connection.CreateParameter("pBNF_DDD", dto.DDD.DBValue, ParameterDirection.Input, dto.DDD.DbType));

			//Parametro pBNF_TELEFONE
			param.Add(Connection.CreateParameter("pBNF_TELEFONE", dto.Telefone.DBValue, ParameterDirection.Input, dto.Telefone.DbType));

			//Parametro pBNF_DDD2
			param.Add(Connection.CreateParameter("pBNF_DDD2", dto.DDD2.DBValue, ParameterDirection.Input, dto.DDD2.DbType));

			//Parametro pBNF_TELEFONE2
			param.Add(Connection.CreateParameter("pBNF_TELEFONE2", dto.Telefone2.DBValue, ParameterDirection.Input, dto.Telefone2.DbType));

			//Parametro pBNF_DDD3
			param.Add(Connection.CreateParameter("pBNF_DDD3", dto.DDD3.DBValue, ParameterDirection.Input, dto.DDD3.DbType));

			//Parametro pBNF_TELEFONE3
			param.Add(Connection.CreateParameter("pBNF_TELEFONE3", dto.Telefone3.DBValue, ParameterDirection.Input, dto.Telefone3.DbType));

			//Parametro pBNF_COMP
            param.Add(Connection.CreateParameter("pBNF_COMP", dto.ComplementoEndereco.DBValue, ParameterDirection.Input, dto.ComplementoEndereco.DbType));

			//Parametro pBNF_TIPO_LOGRADOURO
			param.Add(Connection.CreateParameter("pBNF_TIPO_LOGRADOURO", dto.TipoLogradouro.DBValue, ParameterDirection.Input, dto.TipoLogradouro.DbType));

			//Parametro pBNF_OBS
			param.Add(Connection.CreateParameter("pBNF_OBS", dto.Observacao.DBValue, ParameterDirection.Input, dto.Observacao.DbType));

			//Parametro pBNF_EMAIL
			param.Add(Connection.CreateParameter("pBNF_EMAIL", dto.Email.DBValue, ParameterDirection.Input, dto.Email.DbType));

            //Parametro pBNF_MUN_CD_IBGE
            param.Add(Connection.CreateParameter("pBNF_MUN_CD_IBGE", dto.CodigoIBGEMunicipio.DBValue, ParameterDirection.Input, dto.CodigoIBGEMunicipio.DbType));

            //Parametro 
            param.Add(Connection.CreateParameter("pNOMBEN", dto.NomeBeneficiario.DBValue, ParameterDirection.Input, dto.NomeBeneficiario.DbType));


			#endregion	
			
			BenefHomeCareDataTable result = new BenefHomeCareDataTable();
			string query = "PRC_BNF_HOMECARE_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public BenefHomeCareDTO SelChave(BenefHomeCareDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());
			
			// Parametro pBNF_HOMECARE_ID
			param.Add(Connection.CreateParameter("pBNF_HOMECARE_ID", dto.CodigoHomeCare.DBValue, ParameterDirection.Input, dto.CodigoHomeCare.DbType));
			
			
			#endregion	
			
			BenefHomeCareDataTable result = new BenefHomeCareDataTable();
			string query = "PRC_BNF_HOMECARE_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
   		    return result.TypedRow(0);
		}

        /// <summary>
        /// Listar o registro de endereço do sgs a ser incluido no homecare
        /// </summary>
        public BenefHomeCareDTO SelEnderecoIncluir(BenefHomeCareDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro pBNF_COD_PLANO
            param.Add(Connection.CreateParameter("pBNF_COD_PLANO", dto.CodigoPlano.DBValue, ParameterDirection.Input, dto.CodigoPlano.DbType));

            //Parametro pBNF_LOJA_ID
            param.Add(Connection.CreateParameter("pBNF_LOJA_ID", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));

            //Parametro pBNF_BEN_ID
            param.Add(Connection.CreateParameter("pBNF_BEN_ID", dto.CodigoMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoMatriculaBenef.DbType));

            //Parametro pBNF_COD_SEQ
            param.Add(Connection.CreateParameter("pBNF_COD_SEQ", dto.CodigoSeqMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoSeqMatriculaBenef.DbType));

            #endregion

            BenefHomeCareDataTable result = new BenefHomeCareDataTable();
            string query = "PRC_BNF_HOMECARE_END_INC_S";

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
		public void Del(BenefHomeCareDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pBNF_HOMECARE_ID
			param.Add(Connection.CreateParameter("pBNF_HOMECARE_ID", dto.CodigoHomeCare.DBValue, ParameterDirection.Input, dto.CodigoHomeCare.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC_BNF_HOMECARE_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Upd(BenefHomeCareDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pBNF_HOMECARE_ID
			param.Add(Connection.CreateParameter("pBNF_HOMECARE_ID", dto.CodigoHomeCare.DBValue, ParameterDirection.Input, dto.CodigoHomeCare.DbType));
			
            ////Parametro pBNF_COD_PLANO
            //param.Add(Connection.CreateParameter("pBNF_COD_PLANO", dto.CodigoPlano.DBValue, ParameterDirection.Input, dto.CodigoPlano.DbType));
			
            ////Parametro pBNF_LOJA_ID
            //param.Add(Connection.CreateParameter("pBNF_LOJA_ID", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));
			
            ////Parametro pBNF_BEN_ID
            //param.Add(Connection.CreateParameter("pBNF_BEN_ID", dto.CodigoMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoMatriculaBenef.DbType));
			
            ////Parametro pBNF_COD_SEQ
            //param.Add(Connection.CreateParameter("pBNF_COD_SEQ", dto.CodigoSeqMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoSeqMatriculaBenef.DbType));
			
            ////Parametro pBNF_COD_NUM_PLANO
            //param.Add(Connection.CreateParameter("pBNF_COD_NUM_PLANO", dto.CodigoNumericoPlano.DBValue, ParameterDirection.Input, dto.CodigoNumericoPlano.DbType));
			
			//Parametro pBNF_PLA_ID_PLANO
			param.Add(Connection.CreateParameter("pBNF_PLA_ID_PLANO", dto.IdtPlanoSGS.DBValue, ParameterDirection.Input, dto.IdtPlanoSGS.DbType));
			
			//Parametro pBNF_FL_ATIVO
			param.Add(Connection.CreateParameter("pBNF_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));
			
			//Parametro pBNF_ENDERECO
			param.Add(Connection.CreateParameter("pBNF_ENDERECO", dto.Endereco.DBValue, ParameterDirection.Input, dto.Endereco.DbType));
			
			//Parametro pBNF_BAIRRO
			param.Add(Connection.CreateParameter("pBNF_BAIRRO", dto.Bairro.DBValue, ParameterDirection.Input, dto.Bairro.DbType));
			
			//Parametro pBNF_UF
			param.Add(Connection.CreateParameter("pBNF_UF", dto.UF.DBValue, ParameterDirection.Input, dto.UF.DbType));
			
			//Parametro pBNF_NUMERO
			param.Add(Connection.CreateParameter("pBNF_NUMERO", dto.NumeroEndereco.DBValue, ParameterDirection.Input, dto.NumeroEndereco.DbType));
			
			//Parametro pBNF_CEP
			param.Add(Connection.CreateParameter("pBNF_CEP", dto.CEP.DBValue, ParameterDirection.Input, dto.CEP.DbType));
			
			//Parametro pBNF_DDD
			param.Add(Connection.CreateParameter("pBNF_DDD", dto.DDD.DBValue, ParameterDirection.Input, dto.DDD.DbType));
			
			//Parametro pBNF_TELEFONE
			param.Add(Connection.CreateParameter("pBNF_TELEFONE", dto.Telefone.DBValue, ParameterDirection.Input, dto.Telefone.DbType));
			
			//Parametro pBNF_DDD2
			param.Add(Connection.CreateParameter("pBNF_DDD2", dto.DDD2.DBValue, ParameterDirection.Input, dto.DDD2.DbType));
			
			//Parametro pBNF_TELEFONE2
			param.Add(Connection.CreateParameter("pBNF_TELEFONE2", dto.Telefone2.DBValue, ParameterDirection.Input, dto.Telefone2.DbType));
			
			//Parametro pBNF_DDD3
			param.Add(Connection.CreateParameter("pBNF_DDD3", dto.DDD3.DBValue, ParameterDirection.Input, dto.DDD3.DbType));
			
			//Parametro pBNF_TELEFONE3
			param.Add(Connection.CreateParameter("pBNF_TELEFONE3", dto.Telefone3.DBValue, ParameterDirection.Input, dto.Telefone3.DbType));
			
			//Parametro pBNF_COMP
            param.Add(Connection.CreateParameter("pBNF_COMP", dto.ComplementoEndereco.DBValue, ParameterDirection.Input, dto.ComplementoEndereco.DbType));
			
			//Parametro pBNF_TIPO_LOGRADOURO
			param.Add(Connection.CreateParameter("pBNF_TIPO_LOGRADOURO", dto.TipoLogradouro.DBValue, ParameterDirection.Input, dto.TipoLogradouro.DbType));
			
			//Parametro pBNF_OBS
			param.Add(Connection.CreateParameter("pBNF_OBS", dto.Observacao.DBValue, ParameterDirection.Input, dto.Observacao.DbType));
			
			//Parametro pBNF_EMAIL
			param.Add(Connection.CreateParameter("pBNF_EMAIL", dto.Email.DBValue, ParameterDirection.Input, dto.Email.DbType));

            //Parametro pBNF_MUN_CD_IBGE
            param.Add(Connection.CreateParameter("pBNF_MUN_CD_IBGE", dto.CodigoIBGEMunicipio.DBValue, ParameterDirection.Input, dto.CodigoIBGEMunicipio.DbType));			
			#endregion	

			string query = "PRC_BNF_HOMECARE_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Ins(BenefHomeCareDTO dto)
		{			
			string query = "PRC_BNF_HOMECARE_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();						
			
			//Parametro pBNF_HOMECARE_ID
			param.Add(Connection.CreateParameter("pBNF_HOMECARE_ID", dto.CodigoHomeCare.DBValue, ParameterDirection.Input, dto.CodigoHomeCare.DbType));
			
			//Parametro pBNF_COD_PLANO
			param.Add(Connection.CreateParameter("pBNF_COD_PLANO", dto.CodigoPlano.DBValue, ParameterDirection.Input, dto.CodigoPlano.DbType));
			
			//Parametro pBNF_LOJA_ID
			param.Add(Connection.CreateParameter("pBNF_LOJA_ID", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));
			
			//Parametro pBNF_BEN_ID
			param.Add(Connection.CreateParameter("pBNF_BEN_ID", dto.CodigoMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoMatriculaBenef.DbType));
			
			//Parametro pBNF_COD_SEQ
			param.Add(Connection.CreateParameter("pBNF_COD_SEQ", dto.CodigoSeqMatriculaBenef.DBValue, ParameterDirection.Input, dto.CodigoSeqMatriculaBenef.DbType));
			
			//Parametro pBNF_COD_NUM_PLANO
			param.Add(Connection.CreateParameter("pBNF_COD_NUM_PLANO", dto.CodigoNumericoPlano.DBValue, ParameterDirection.Input, dto.CodigoNumericoPlano.DbType));
			
			//Parametro pBNF_PLA_ID_PLANO
			param.Add(Connection.CreateParameter("pBNF_PLA_ID_PLANO", dto.IdtPlanoSGS.DBValue, ParameterDirection.Input, dto.IdtPlanoSGS.DbType));
			
			//Parametro pBNF_FL_ATIVO
			param.Add(Connection.CreateParameter("pBNF_FL_ATIVO", dto.FlAtivo.DBValue, ParameterDirection.Input, dto.FlAtivo.DbType));
			
			//Parametro pBNF_ENDERECO
			param.Add(Connection.CreateParameter("pBNF_ENDERECO", dto.Endereco.DBValue, ParameterDirection.Input, dto.Endereco.DbType));
			
			//Parametro pBNF_BAIRRO
			param.Add(Connection.CreateParameter("pBNF_BAIRRO", dto.Bairro.DBValue, ParameterDirection.Input, dto.Bairro.DbType));
			
			//Parametro pBNF_UF
			param.Add(Connection.CreateParameter("pBNF_UF", dto.UF.DBValue, ParameterDirection.Input, dto.UF.DbType));
			
			//Parametro pBNF_NUMERO
			param.Add(Connection.CreateParameter("pBNF_NUMERO", dto.NumeroEndereco.DBValue, ParameterDirection.Input, dto.NumeroEndereco.DbType));
			
			//Parametro pBNF_CEP
			param.Add(Connection.CreateParameter("pBNF_CEP", dto.CEP.DBValue, ParameterDirection.Input, dto.CEP.DbType));
			
			//Parametro pBNF_DDD
			param.Add(Connection.CreateParameter("pBNF_DDD", dto.DDD.DBValue, ParameterDirection.Input, dto.DDD.DbType));
			
			//Parametro pBNF_TELEFONE
			param.Add(Connection.CreateParameter("pBNF_TELEFONE", dto.Telefone.DBValue, ParameterDirection.Input, dto.Telefone.DbType));
			
			//Parametro pBNF_DDD2
			param.Add(Connection.CreateParameter("pBNF_DDD2", dto.DDD2.DBValue, ParameterDirection.Input, dto.DDD2.DbType));
			
			//Parametro pBNF_TELEFONE2
			param.Add(Connection.CreateParameter("pBNF_TELEFONE2", dto.Telefone2.DBValue, ParameterDirection.Input, dto.Telefone2.DbType));
			
			//Parametro pBNF_DDD3
			param.Add(Connection.CreateParameter("pBNF_DDD3", dto.DDD3.DBValue, ParameterDirection.Input, dto.DDD3.DbType));
			
			//Parametro pBNF_TELEFONE3
			param.Add(Connection.CreateParameter("pBNF_TELEFONE3", dto.Telefone3.DBValue, ParameterDirection.Input, dto.Telefone3.DbType));
			
			//Parametro pBNF_COMP
            param.Add(Connection.CreateParameter("pBNF_COMP", dto.ComplementoEndereco.DBValue, ParameterDirection.Input, dto.ComplementoEndereco.DbType));
			
			//Parametro pBNF_TIPO_LOGRADOURO
			param.Add(Connection.CreateParameter("pBNF_TIPO_LOGRADOURO", dto.TipoLogradouro.DBValue, ParameterDirection.Input, dto.TipoLogradouro.DbType));
			
			//Parametro pBNF_OBS
			param.Add(Connection.CreateParameter("pBNF_OBS", dto.Observacao.DBValue, ParameterDirection.Input, dto.Observacao.DbType));
			
			//Parametro pBNF_EMAIL
			param.Add(Connection.CreateParameter("pBNF_EMAIL", dto.Email.DBValue, ParameterDirection.Input, dto.Email.DbType));

            //Parametro pBNF_MUN_CD_IBGE
            param.Add(Connection.CreateParameter("pBNF_MUN_CD_IBGE", dto.CodigoIBGEMunicipio.DBValue, ParameterDirection.Input, dto.CodigoIBGEMunicipio.DbType));

            param.Add(Connection.CreateParameterSequence());
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
            dto.CodigoHomeCare.Value = Int32.Parse(param["pNewIdt"].Value.ToString());
		}	
	}
}