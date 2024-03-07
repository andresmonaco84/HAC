using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Data.OracleClient;
using System.Web.UI;

namespace WebCamCaptureWebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    //[WebService(Namespace = "http://sgs.anacosta.com.br/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // public class WebCamCaptureWebService : System.Web.Services.WebService
    public class WebCamCaptureWebService : Page
    {
        private const string eventSource = "Application";
        private bool? _isTrace = null;
        private bool isTrace
        {
            get { return _isTrace == null ? Convert.ToBoolean(ConfigurationManager.AppSettings["trace"]) : _isTrace.Value; }
        }

        private void Logar(string message, EventLogEntryType type)
        {
            if (isTrace)
            {
                try
                {
                    EventLog.WriteEntry(eventSource, message, type);
                }
                catch
                {                    
                }
            }
        }

        [WebMethod]
        public string SavePicture(int idPessoa, string strImage)
        {           
            try
            {
                byte[] arrImage = Convert.FromBase64String(strImage);
                Logar("Criando Conexão com o banco de dados", EventLogEntryType.Warning);
                Logar(string.Format("String de conexão, {0}", ConfigurationManager.ConnectionStrings["SGS"].ConnectionString), EventLogEntryType.Warning);

                using (OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["SGS"].ConnectionString))
                {

                    Logar("Conexão criada com sucesso.", EventLogEntryType.Information);
                    Logar("Criando command", EventLogEntryType.Warning);

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        Logar("Command criado com sucesso", EventLogEntryType.Information);

                        cmd.Connection = cn;
                        string sqlCommand;
                        if (GetPicture(idPessoa).Contains("msg:1"))
                        {
                             sqlCommand = "INSERT INTO TB_CAD_PAC_IMAGEM (IDPESSOA, IMAGEM, DATA) VALUES (:pidPessoa, :pimagem, sysdate)";
                        }
                        else
                        {
                            sqlCommand = "UPDATE TB_CAD_PAC_IMAGEM SET IMAGEM = :pimagem, DATA = sysdate where IDPESSOA = :pidPessoa";
                        }
                        cmd.CommandText = sqlCommand;
                        //cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(AddIdPessoaParameter(idPessoa));
                        cmd.Parameters.Add(AddPicParameter(arrImage));                        

                        try
                        {
                            Logar("Abrindo conexão com o banco de dados", EventLogEntryType.Warning);
                            cn.Open();
                            Logar("Conexão aberta com sucesso", EventLogEntryType.Information);
                            Logar("Executando query no banco de dados", EventLogEntryType.Warning);
                            cmd.ExecuteNonQuery();
                            Logar("Comando executado com sucesso", EventLogEntryType.Information);
                        }
                        finally
                        {
                            if (cn.State == ConnectionState.Open)
                            {
                                cn.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logar(ex.Message, EventLogEntryType.Error);
                return ex.Message;
            }

            return "ok";
        }

        [WebMethod]      
        public string GetPicture(int idPessoa)
        {            
            DataTable dtbResult;
            Logar("Criando Conexão com o banco de dados", EventLogEntryType.Error);
            Logar(string.Format("String de conexão, {0}", ConfigurationManager.ConnectionStrings["SGS"].ConnectionString), EventLogEntryType.Warning);
            using (OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["SGS"].ConnectionString))
            {
                Logar("Conexão criada com sucesso.", EventLogEntryType.Information);
                Logar("Criando command", EventLogEntryType.Warning);

                using (OracleCommand cmd = new OracleCommand())
                {
                    Logar("Command criado com sucesso", EventLogEntryType.Information);

                    cmd.Connection = cn;
                    StringBuilder sql = new StringBuilder();
                    sql.Append("select IMAGEM from TB_CAD_PAC_IMAGEM ");
                    sql.AppendFormat("where idpessoa = {0}", idPessoa);

                    cmd.CommandText = sql.ToString();

                    using (OracleDataAdapter adp = new OracleDataAdapter(cmd))
                    {
                        try
                        {
                            Logar("Executando query no banco de dados", EventLogEntryType.Warning);
                            dtbResult = new DataTable();
                            adp.Fill(dtbResult);
                            Logar("Comando executado com sucesso", EventLogEntryType.Information);

                            if (dtbResult.Rows.Count != 0) // tem imagem
                            {
                                Logar("Convertendo imagem do banco de dados para memorystream", EventLogEntryType.Warning);
                                MemoryStream stream = new MemoryStream((byte[])dtbResult.Rows[0]["IMAGEM"]);
                                Logar("Conversão realizada com sucesso", EventLogEntryType.Information);
                                return Convert.ToBase64String(stream.ToArray());
                            }
                            else // não tem imagem
                            {
                                Logar(string.Format("Não existe imagem para a pessoa: {0}", idPessoa), EventLogEntryType.Information);
                                return "msg:1";
                            }
                        }
                        catch (Exception ex)
                        {
                            Logar(ex.Message, EventLogEntryType.Error);
                            return string.Format("msg:erro, {0}", ex.Message);
                        }
                        finally
                        {
                            if (cn.State == ConnectionState.Open)
                            {
                                cn.Close();
                            }
                        }
                    }
                }
            }
        }

        private OracleParameter AddPicParameter(byte[] arrImage)
        {
            OracleParameter param = new OracleParameter();
            param.OracleType = OracleType.Blob;            
            param.ParameterName = ":pimagem";
            param.Direction = ParameterDirection.Input;
            param.Value = arrImage;

            return param;
        }

        private OracleParameter AddIdPessoaParameter(int idPessoa)
        {
            OracleParameter param = new OracleParameter();
            param.OracleType = OracleType.Number;
            param.Direction = ParameterDirection.Input;
            param.ParameterName = ":pidPessoa";
            param.Value = idPessoa;

            return param;
        }
    }
}
