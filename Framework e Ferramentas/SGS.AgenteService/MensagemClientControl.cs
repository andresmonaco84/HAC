using HospitalAnaCosta.Framework.Common;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalAnaCosta.Framework.Data;
using System.IO;
using System.Configuration;

namespace SGS.AgenteService
{
    public static class MensagemClientControl
    {
        public static void Executa()
        {
            //executar query e verificar se existe mensagem para aquele período
            var dtb = new GenericModel().GetData("select asi.aux_asi_ds_mensagem, asi.aux_asi_ds_sistema,asi.aux_asi_imagem\n" +
                                                    "from tb_aux_asi_aviso_sistema asi\n" +
                                                    "where asi.aux_asi_fl_status = '1'\n" +
                                                    "and sgs.fnc_validar_vigencia_datahora(asi.aux_asi_data_ini, asi.aux_asi_data_fim, sysdate) = 1");

            //abrir arquivo e ler a mensagem da base
            string mensagemArquivo = File.ReadAllText(@ConfigurationManager.AppSettings["ARQUIVOMENSAGEM"]);
            //string mensagemLogoArquivo = File.ReadAllText(@ConfigurationManager.AppSettings["LOGOMENSAGEM"]);

            //se houver mensagem
            if (dtb.Rows.Count > 0)
            {
                var mensagemBase = dtb.Rows[0][0].ToString();
                var mensagemLogoBase = dtb.Rows[0][2].ToString();

                //comparar com mensagem da base e se diferente, gravar no arquivo a mensagem da base          
                if (mensagemArquivo != mensagemBase)
                {
                    File.WriteAllText(@ConfigurationManager.AppSettings["LOGOMENSAGEM"], mensagemLogoBase, Encoding.UTF8);
                    File.WriteAllText(@ConfigurationManager.AppSettings["ARQUIVOMENSAGEM"], mensagemBase, Encoding.UTF8);
                }

            }
            //se não houver mensagem 
            else
            {
                if(mensagemArquivo.Replace(Environment.NewLine, " ").Trim() != "")
                {
                    File.WriteAllText(@ConfigurationManager.AppSettings["LOGOMENSAGEM"], "ti");
                    File.WriteAllText(@ConfigurationManager.AppSettings["ARQUIVOMENSAGEM"], "");
                }               
                
            }

        }        
    }

}
