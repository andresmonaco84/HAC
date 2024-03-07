using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMSConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder strRetorno = new StringBuilder();
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://sms.contele.com.br/bulksms/submitsms.go");            

            var telefone = args[0];

            var message = "";
            for (int i = 1; i < args.Length; i++)
            {
                message += args[i] + " ";
            }


            string getDetails = string.Format("username=maria.santos@anacosta.com.br&password=Contele123&phone=55{0}&msgtext={1}&id=99999999", telefone, message);

            ASCIIEncoding sendEncoding = new ASCIIEncoding();
            byte[] byte1 = sendEncoding.GetBytes(getDetails);

            myHttpWebRequest.Method = "POST";
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.ContentLength = getDetails.Length;

            Stream sendStream = myHttpWebRequest.GetRequestStream();
            sendStream.Write(byte1, 0, byte1.Length);
            sendStream.Close();

            WebResponse myWebResponse = myHttpWebRequest.GetResponse();
            Stream receiveStream = myWebResponse.GetResponseStream();
            Encoding readEncoding = System.Text.Encoding.GetEncoding("utf-8");

            StreamReader readStream = new StreamReader(receiveStream, readEncoding);
            Char[] read = new Char[256];

            int count = readStream.Read(read, 0, 256);

            while (count > 0)
            {
                String str = new String(read, 0, count);
                strRetorno.AppendFormat("{0} {1}", str, Environment.NewLine);
                count = readStream.Read(read, 0, 256);
            }

            sendStream.Close();
            sendStream.Dispose();

            readStream.Close();
            readStream.Dispose();

            receiveStream.Close();
            receiveStream.Dispose();

            myWebResponse.Close();

            Console.WriteLine(message);
            Console.WriteLine("Mensagem enviada!");
            Console.WriteLine(strRetorno.ToString());
        }
    }
}
