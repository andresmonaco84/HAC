using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;
class AknaSMSSender
{

    static string xmlEnvio = 
@"<?xml version=""1.0"" encoding=""UTF-8""?>
                <main>
                    <emkt trans=""40.01"">
                        <sms>
                            <telefone>{0}</telefone>
                            <mensagem>{1}</mensagem>
                            <remetente>ANA COSTA</remetente>
                        </sms>
                    </emkt>
                </main>";

    public static AknaRetorno Enviar(string telefone, string mensagem)
    {

        var xml = string.Format(xmlEnvio, telefone, mensagem);
        var client = "26949";
        var user = "tisgs@anacosta.com.br";
        var pass = "c96db768aa9baad5ab5e3e868b2241bd";

        var dump = xml;

        var encoding = new UTF8Encoding();
        var postData = "Client=" + client;
        postData += "&User=" + user;
        postData += "&Pass=" + pass;
        postData += "&XML=" + xml;
        byte[] data = encoding.GetBytes(postData);
        
        var myRequest = (HttpWebRequest)WebRequest.Create("https://app.akna.com.br/emkt/int/integracao.php");
        myRequest.Method = "POST";
        myRequest.ContentType = "application/x-www-form-urlencoded";
        myRequest.ContentLength = data.Length;

#if DEBUG
        WebProxy proxy = new WebProxy("proxy.uhgbrasil.com.br:8082");
        proxy.Credentials = new NetworkCredential("PS12068619", "masdof$5", "grupoamil.com.br");
        proxy.UseDefaultCredentials = true;
        WebRequest.DefaultWebProxy = proxy;
        myRequest.Proxy = proxy;
#endif

        var newStream = myRequest.GetRequestStream();
        newStream.Write(data, 0, data.Length);
        newStream.Close();
        AknaRetorno retorno = new AknaRetorno();
        var response = myRequest.GetResponse();
        var responseStream = response.GetResponseStream();
        var responseReader = new StreamReader(responseStream);
        var result = responseReader.ReadToEnd();
        try
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(MAIN));
            using (StringReader reader = new StringReader(result))
            {
                var obj = (MAIN)serializer.Deserialize(reader);
                retorno.Status = obj.EMKT.RETURN.ID;
                retorno.RetornoId = obj.EMKT.RETURN.Text;
            }

            responseReader.Close();
            response.Close();

            dump += Environment.NewLine + result;
            retorno.Dump = dump;

            

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            //throw;
        }

        return retorno;

    }

    static string xmlResposta = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <main>
                   <emkt trans=""40.03""> 
                    <sms>     
                     <codigo>{0}</codigo>  
                    </sms>  
                  </emkt> 
                </main>";

    public static AknaRetorno ObterResposta(string id)
    {

        var xml = string.Format(xmlResposta,id);
        var client = "26949";
        var user = "tisgs@anacosta.com.br";
        var pass = "c96db768aa9baad5ab5e3e868b2241bd";

        var dump = xml;

        var encoding = new UTF8Encoding();
        var postData = "Client=" + client;
        postData += "&User=" + user;
        postData += "&Pass=" + pass;
        postData += "&XML=" + xml;
        byte[] data = encoding.GetBytes(postData);

        var myRequest = (HttpWebRequest)WebRequest.Create("https://app.akna.com.br/emkt/int/integracao.php");
        myRequest.Method = "POST";
        myRequest.ContentType = "application/x-www-form-urlencoded";
        myRequest.ContentLength = data.Length;

#if DEBUG
        WebProxy proxy = new WebProxy("proxy.uhgbrasil.com.br:8082");
        proxy.Credentials = new NetworkCredential("PS12068619", "masdof$5", "grupoamil.com.br");
        proxy.UseDefaultCredentials = true;
        WebRequest.DefaultWebProxy = proxy;
        myRequest.Proxy = proxy;
#endif
        var newStream = myRequest.GetRequestStream();
        newStream.Write(data, 0, data.Length);
        newStream.Close();

        var response = myRequest.GetResponse();
        var responseStream = response.GetResponseStream();
        var responseReader = new StreamReader(responseStream);
        var result = responseReader.ReadToEnd();
        
        AknaRetorno retorno = new AknaRetorno();
        XmlSerializer serializer = new XmlSerializer(typeof(MAIN));
        using (StringReader reader = new StringReader(result))
        {
            var obj = (MAIN)serializer.Deserialize(reader);
            foreach (var item in obj.EMKT.SMS)
            {
                retorno.Respostas.Add(item.MENSAGEM);

            }

        }

        responseReader.Close();
        response.Close();

        dump += Environment.NewLine + result;

        retorno.Dump = dump;

        return retorno;
    }

}

public class AknaRetorno
{
    public AknaRetorno()
    {
        Respostas = new List<string>();
    }

    public string RetornoId { get; set; }
    public string Status { get; set; }
    public List<string> Respostas { get; set; }
    public string Dump { get; set; }
}

[XmlRoot(ElementName = "RETURN")]
public class RETURN
{

    [XmlAttribute(AttributeName = "ID")]
    public string ID;

    [XmlText]
    public string Text;
}

[XmlRoot(ElementName = "SMS")]
public class SMS
{

    [XmlElement(ElementName = "TELEFONE")]
    public string TELEFONE;

    [XmlElement(ElementName = "MENSAGEM")]
    public string MENSAGEM;

    [XmlElement(ElementName = "DATA_RECEBIMENTO")]
    public string DATARECEBIMENTO;
}

[XmlRoot(ElementName = "EMKT")]
public class EMKT
{

    [XmlElement(ElementName = "RETURN")]
    public RETURN RETURN;

    [XmlElement(ElementName = "SMS")]
    public List<SMS> SMS;

    [XmlAttribute(AttributeName = "TRANS")]
    public double TRANS;

    [XmlAttribute(AttributeName = "KEY")]
    public string KEY;

    [XmlText]
    public string Text;
}

[XmlRoot(ElementName = "MAIN")]
public class MAIN
{

    [XmlElement(ElementName = "EMKT")]
    public EMKT EMKT;
}