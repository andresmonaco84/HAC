using System;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnCriar_Click(object sender, EventArgs e)
    {
        Exec(true);
    }

    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        Exec(false);
    }

    private void Exec(bool inclusaoUsuario)
    {
        try
        {
            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
            string procedureName = inclusaoUsuario ? "pandora.pkg_pandora.cria_usuario_prontel" : "pandora.pkg_pandora.altera_senha_usuario";
            OracleConnection conn = new OracleConnection(strConexao); conn.Open();            
            OracleCommand dbCommand = conn.CreateCommand();

            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = procedureName;

            dbCommand.Parameters.Add("p_username", txtUsuario.Text.ToUpper());
            dbCommand.Parameters.Add("p_senha", txtSenha.Text);

            dbCommand.ExecuteNonQuery();
            conn.Close();

            if (inclusaoUsuario)
            {
                lblMensagem.Text = "Usuário criado com sucesso";
            }
            else
            {
                lblMensagem.Text = "Senha alterada com sucesso";
            }
            lblMensagem.ForeColor = System.Drawing.Color.Green;
            txtUsuario.Text = string.Empty;
        }
        catch (Exception ex)
        {
            if (ex.Message.IndexOf("1920") > -1)
            {
                lblMensagem.Text = "Usuário já cadastrado";
            }
            else if (ex.Message.IndexOf("1918") > -1)
            {
                lblMensagem.Text = "Usuário inválido";
            }
            else
            {
                lblMensagem.Text = "Ocorreu o seguinte erro: " + ex.Message;
            }
            lblMensagem.ForeColor = System.Drawing.Color.Red;
        }        
    }
    protected void btnSGSAlterarSenha_Click(object sender, EventArgs e)
    {
        try{
            if (txtSGSUsuario.Text.Length == 0 || txtSGSSenha.Text.Length == 0) {
                lblSGSMensagem.Text = "Preencher usuário e senha SGS.";
                lblSGSMensagem.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DataTable a = ObterUsuario(txtSGSUsuario.Text.ToUpper());
            if (a.Rows.Count == 0)
            {
                lblSGSMensagem.Text = "Usuário não encontrado.";
                lblSGSMensagem.ForeColor = System.Drawing.Color.Red;
                return;
            }
            

            string strConexao = ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
            string novaSenhaCriptografada = CriptografarMd5Hash( txtSGSSenha.Text.ToUpper());
            string query = string.Format("UPDATE tb_seg_usu_usuario usu SET USU.SEG_USU_CD_PASSWORD = '{1}', SEG_USU_FL_TROCAR_SENHA_OK = 'S' WHERE USU.seg_usu_ds_login = '{0}'", txtSGSUsuario.Text.ToUpper(), novaSenhaCriptografada);

            OracleConnection conn = new OracleConnection(strConexao); conn.Open();   
            OracleCommand dbCommand = conn.CreateCommand();

            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = query;

            dbCommand.ExecuteNonQuery();
            conn.Close();
          
                lblSGSMensagem.Text = "Senha alterada com sucesso";
                

            lblSGSMensagem.ForeColor = System.Drawing.Color.Green;
            txtSGSUsuario.Text = string.Empty;
        }
        catch (Exception ex)
        {
           lblSGSMensagem.Text = "Ocorreu o seguinte erro: " + ex.Message;
           
            lblSGSMensagem.ForeColor = System.Drawing.Color.Red;
        }        
    }

    /// <summary>
    /// Criptografa string informada utilizando MD5 Hash
    /// </summary>
    /// <param name="value">Valor Informado a ser criptografado</param>
    /// <returns>String Criptografada</returns>
    public static string CriptografarMd5Hash(string value)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    public DataTable ObterUsuario(string strLogin)
    {
        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString;
        using (OracleConnection db = new OracleConnection(connectionString))
        {

            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.Append("SELECT USU.seg_usu_ds_login FROM tb_seg_usu_usuario usu WHERE USU.SEG_USU_DS_LOGIN = :pSEG_USU_DS_LOGIN\n");
            
            OracleCommand dbCommand = db.CreateCommand();
            dbCommand.CommandText = sqlCommand.ToString();
            dbCommand.CommandType = CommandType.Text;

            #region "Parametros"
            dbCommand.Parameters.AddWithValue(":pSEG_USU_DS_LOGIN", strLogin);
            #endregion

            OracleDataAdapter adp = new OracleDataAdapter(dbCommand);
            DataTable dt = new DataTable();
            try
            {
                adp.Fill(dt);
                adp.Dispose();
            }
            finally
            {
                if (dbCommand.Connection != null)
                {
                    dbCommand.Connection.Close();
                }
                dbCommand.Dispose();
            }
            return dt;
        }
    }

   
}