using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Framework.Data;
using System.Data.Common;
using System.Data;
using HospitalAnaCosta.SGS.Seguranca.DTO;

namespace HospitalAnaCosta.SGS.Seguranca.Model
{
    public partial class Autentica : Entity
    {
        public SegurancaDTO Login(SegurancaDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            SegurancaDTO DTOSeguranca;
            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro
            param.Add(Connection.CreateParameter("pSEG_USU_DS_LOGIN", dto.Login.DBValue, ParameterDirection.Input, dto.Login.DbType));

            //Parametro
            param.Add(Connection.CreateParameter("pSEG_USU_CD_PASSWORD", dto.Senha.DBValue, ParameterDirection.Input, dto.Senha.DbType));

            #endregion

            SegurancaDataTable result = new SegurancaDataTable();
            string query = "PRC_SEG_LOGIN";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            try
            {
                DTOSeguranca = result.TypedRow(0);
            }
            catch (HacException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                // throw new HacException(ex.Message);
                return null;
            }
            return DTOSeguranca;
        }

        public Boolean TrocaSenha(SegurancaDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();
            SegurancaDTO DTOSeguranca;
            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            //Parametro
            param.Add(Connection.CreateParameter("pSEG_USU_DS_LOGIN", dto.Login.DBValue, ParameterDirection.Input, dto.Login.DbType));

            //Parametro
            param.Add(Connection.CreateParameter("pSEG_USU_CD_PASSWORD", dto.Senha.DBValue, ParameterDirection.Input, dto.Senha.DbType));

            //Parametro
            param.Add(Connection.CreateParameter("pNOVA_SENHA", dto.NovaSenha.DBValue, ParameterDirection.Input, dto.NovaSenha.DbType));


            #endregion

            SegurancaDataTable result = new SegurancaDataTable();
            string query = "PRC_SEG_TROCA_SENHA";

            //Executa o procedimento
            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
            try
            {
                DTOSeguranca = result.TypedRow(0);
            }
            catch (HacException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }

    
}
