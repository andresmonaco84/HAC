
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace SGS.AgenteService
{
    class Mailer
    {
        public static string RemoveFitas(string bozo)
        {
            return bozo.Replace("'", " ").Replace("\"", " ").Replace(System.Environment.NewLine, " ").Replace("\n", "");

        }

        public static void Processar()
        {
            //Envio de comunicado para emails externos / Foi dado a carga na TB_SGS_EML como status Y.
            //C:\tfshac\hac\Framework e Ferramentas\CargaEmail\
            //new GenericModel().ExecuteCommand(@"UPDATE TB_SGS_EML_ENVIA_EMAIL EML SET EML.SGS_EML_STATUS = 'N' WHERE EML.SGS_EML_STATUS ='Y' and rownum =< 10");

            //Se der erro tenta de novo.
            var dtb = new GenericModel().GetData(@"select *  from tb_sgs_eml_envia_email where sgs_eml_status IN ('E', 'N') and rownum < 15 order by sgs_eml_id desc");

            /*
            SGS_EML_ID,
            SGS_EML_TEXTO,
            SGS_EML_DESTINO,
            SGS_EML_STATUS,
            SGS_EML_ASSUNTO,
            SGS_EML_DT_ULTIMA_ATUALIZACAO
            */

            foreach (DataRow row in dtb.Rows)
            {

                using (SmtpClient smtp = new SmtpClient("smtp.office365.com", 587))
                {
                    smtp.EnableSsl = true;

                    smtp.Credentials = new System.Net.NetworkCredential("tisistemas@anacosta.com.br", "Mj78$vb09");
                    MailAddress remetente = new MailAddress("tisistemas@anacosta.com.br", "HAC");



                    var id = Convert.ToInt32(row["SGS_EML_ID"]);

                    try
                    {
                        var destinos = row["SGS_EML_DESTINO"].ToString().Replace(";", ",").Split(',');
                        //var destinos = new string[] { "marcusrelva@gmail.com" };

                        var texto = row["SGS_EML_TEXTO"].ToString();
                        if (string.IsNullOrWhiteSpace(texto))
                        {
                            texto = row["SGS_EML_CURTO_TEXTO"].ToString();
                        }

                        var replyto = row["SGS_EML_REPLYTO"].ToString().Replace(";", ",").Split(',');
                        var assunto = row["SGS_EML_ASSUNTO"].ToString();

                        //smtp.Credentials = new System.Net.NetworkCredential("user1.365@uhgbrasil.com.br", "amil*2021");

                        //SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
                        //smtp.Credentials = new System.Net.NetworkCredential("tisistemas@anacosta.com.br", "Mj78$vb09");
                        //smtp.EnableSsl = true;
                        //MailAddress remetente = new MailAddress("tisistemas@anacosta.com.br", "HAC");


                        //SmtpClient smtp = new SmtpClient("172.16.1.18", 587);
                        //smtp.Credentials = new System.Net.NetworkCredential("marcus.relva", "masdof$4", "ANACOSTA");
                        //smtp.EnableSsl = false;
                        //smtp.UseDefaultCredentials = true;
                        //MailAddress remetente = new MailAddress("marcus.relva@anacosta.com.br", "HAC");


                        MailMessage mail = new MailMessage();


                        StringBuilder sb = new StringBuilder();
                        sb.Append(@"<html><head></head><body style=""font-size: medium; font-family: 'Helvetica Neue',
                        'Lucida Grande', 'Segoe UI', 'Arial', 'Helvetica', 'Verdana', 'sans-serif'; color: #666;"">");
                        sb.Append(string.Format("{0}", texto));

                        sb.Append(@"<br/><br/></body></html>");
                        
                        mail.Subject = RemoveFitas(assunto);
                        mail.Body = sb.ToString();

                        foreach (var item in replyto)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                mail.ReplyToList.Add(item);
                            }

                        }

                        foreach (var item in destinos)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                mail.To.Add(item);
                            }
                        }

                        mail.IsBodyHtml = true;

                        mail.From = remetente;                                           
                        smtp.Send(mail);

                        new GenericModel().ExecuteCommand(@"update tb_sgs_eml_envia_email set sgs_eml_status = 'P', SGS_EML_DT_ULTIMA_ATUALIZACAO = SYSDATE where sgs_eml_id = " + id);

                        Thread.Sleep(110);
                    }
                    catch (Exception ex)
                    {
                        new GenericModel().ExecuteCommand(@"update tb_sgs_eml_envia_email set sgs_eml_status = 'E'  where sgs_eml_id =  " + id);

                        try
                        {
                            var msg = RemoveFitas(DateTime.Now.ToString() + " " + ex.ToString()).PadRight(501, Convert.ToChar(" ")).Substring(0, 499);
                            //new GenericModel().ExecuteCommand(string.Format(@"update tb_sgs_eml_envia_email set sgs_eml_status = 'E',SGS_EML_MSG_ERRO='{1}' where sgs_eml_id = {0}",id,msg));
                            new GenericModel().ExecuteCommand(string.Format(@"update tb_sgs_eml_envia_email set sgs_eml_status = 'E', SGS_EML_MSG_ERRO='{0}'  where sgs_eml_id = {1}", msg, id));
                        }
                        catch (Exception)
                        {
                            var msg2 = RemoveFitas(DateTime.Now.ToString() + " " + ex.Message);
                            //new GenericModel().ExecuteCommand(string.Format(@"update tb_sgs_eml_envia_email set sgs_eml_status = 'E',SGS_EML_MSG_ERRO='{1}' where sgs_eml_id = {0}",id,msg));
                            new GenericModel().ExecuteCommand(string.Format(@"update tb_sgs_eml_envia_email set sgs_eml_status = 'E', SGS_EML_MSG_ERRO='{0}'  where sgs_eml_id = {1}", msg2, id));
                        }
                    }
                }
            }//using
        }
    }
}
