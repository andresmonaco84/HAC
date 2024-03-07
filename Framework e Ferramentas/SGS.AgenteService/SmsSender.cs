using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SGS.AgenteService
{
    class SmsSender
    {
        public static void ProcessarRespostas()
        {
            var model = new GenericModel();

            var dtb = model.GetData(@"select * from tb_sgs_eml_envia_email 
                                                   where sgs_eml_status = '1' 
                                                   and (sgs_eml_controle_id is not null and sgs_eml_controle_id > 0)                                                   
                                                   and sgs_eml_dt_ultima_atualizacao >= trunc(sysdate) -3
                                                   and upper(sgs_eml_curto_texto) like '%CONFIRMA%'                                                  
                                                   and sms_eml_retorno_tipo in ('A')");

            foreach (DataRow row in dtb.Rows)
            {
                var agendaId = row["sgs_eml_controle_id"];
                var envioId = Convert.ToInt32(row["sgs_eml_id"]);
                var retornoId = row["sgs_eml_retorno_id"].ToString();
                //a = agenda, s = sadt
                var tipoControle = row["sms_eml_retorno_tipo"].ToString();

                try
                {


                    var obj = AknaSMSSender.ObterResposta(retornoId);

                    var retorno = "";
                    if (obj.Respostas.Any())
                    {
                        if (obj.Respostas.Where(t => t.Contains("2")).Any())
                        {
                            retorno = "9"; // cancelar;
                        }
                        else if (obj.Respostas.Where(t => t.Contains("1")
                                || t.ToLower().Contains("ok")
                                || t.ToLower().Contains("confirma")
                                || t.ToLower().Contains("sim")).Any())
                        {
                            retorno = "8"; // confirmar;    
                        }

                        if (retorno == "9" || retorno == "8")
                        {
                            if (tipoControle == "A")
                            {
                                model.ExecuteCommand(@"update tb_age_agd_agenda 
                                                        set age_agd_fl_confirma_status = 'S',                                                        
                                                        age_agd_fl_confirma_tipo = :retorno
                                                        where age_agd_id = :agendaId",
                                                        model.CreateParameterCollecion(new Parameter[] {
                                                                                    new Parameter("retorno", retorno),
                                                                                    new Parameter("agendaId", agendaId)}));
                            }
                            else if (tipoControle == "S")
                            {
                                model.ExecuteCommand(@"update tb_age_agd_agenda 
                                                        set age_agd_fl_confirma_status = 'S',                                                        
                                                        age_agd_fl_confirma_tipo = :retorno
                                                        where age_agd_id = :agendaId",
                                                        model.CreateParameterCollecion(new Parameter[] {
                                                                                    new Parameter("retorno", retorno),
                                                                                    new Parameter("agendaId", agendaId)}));
                            }

                        }

                        model.ExecuteCommand(@"update tb_sgs_eml_envia_email set sgs_eml_status = '3', sgs_eml_texto = :dump where sgs_eml_id = :envioId",
                       model.CreateParameterCollecion(new Parameter[] {
                                            new Parameter("dump", obj.Dump),
                                            new Parameter("envioId", envioId)
                                   }));

                    }

                }
                catch (Exception ex)
                {
                    var msg2 = DateTime.Now.ToString() + " " + ex.Message;
                    model.ExecuteCommand(@"update tb_sgs_eml_envia_email set sgs_eml_status = '4', SGS_EML_MSG_ERRO = :mensagemErro where sgs_eml_id = :envioId",
                         model.CreateParameterCollecion(new Parameter[] {
                                                                    new Parameter("envioId", envioId),
                                                                    new Parameter("mensagemErro", msg2)}));


                }




            }
        }



        public static void SendTest()
        {
            var retorno = AknaSMSSender.Enviar("13981292299", "TESTE HAC SERVER").Dump;

            Console.WriteLine(retorno);

            retorno = AknaSMSSender.Enviar("13997024193", "TESTE HAC MENSAGEM").Dump;

            Console.WriteLine(retorno);

        }


        public static void Processar()
        {
            var model = new GenericModel();

            var dtb = model.GetData(@"select *  from tb_sgs_eml_envia_email where sgs_eml_status = '0' and rownum < 30");


            foreach (DataRow row in dtb.Rows)
            {

                var id = Convert.ToInt32(row["SGS_EML_ID"]);

                try
                {

                    var destino = row["SGS_EML_DESTINO"].ToString();
                    var texto = row["SGS_EML_CURTO_TEXTO"].ToString();

                    var retorno = AknaSMSSender.Enviar(destino, texto);

                    model.ExecuteCommand(@"update tb_sgs_eml_envia_email set sgs_eml_status = '1', 
                                                                sgs_eml_texto = :retorno, sgs_eml_retorno_id = :retornoId where sgs_eml_id = :envioId",
                                                                model.CreateParameterCollecion(new Parameter[]
                                                                {
                                                                    new Parameter("retorno", retorno.Dump),
                                                                    new Parameter("retornoId", retorno.RetornoId),
                                                                    new Parameter("envioId", id)
                                                                }));

                }
                catch (Exception ex)
                {


                    var msg2 = DateTime.Now.ToString() + " " + ex.Message;
                    model.ExecuteCommand(@"update tb_sgs_eml_envia_email set sgs_eml_status = '2', SGS_EML_MSG_ERRO = :mensagemErro where sgs_eml_id = :envioId",
                         model.CreateParameterCollecion(new Parameter[] {
                                                                    new Parameter("envioId", id),
                                                                    new Parameter("mensagemErro", msg2)
                                                                }));

                }

            }

        }

        public static void EnviarLembretesLinksTeleconsulta()
        {
            var dtb = ObterLinksDia();

            var mensagem = "{0}, TELEATENDIMENTO {1} AS {2}. NESTE HORARIO ACESSE O LINK A SEGUIR PARA REALIZAR A CONSULTA EM VIDEO {3}";


            foreach (DataRow row in dtb.Rows)
            {
                try
                {
                    var nome = row["nome"].ToString().Split(' ')[0];
                    var horario = Convert.ToInt32(row["hora"]).ToString("00:00");
                    var data = Convert.ToDateTime(row["data"]).ToString("dd/MM/yyyy");
                    var link = row["link"].ToString();
                    var idtPessoa = Convert.ToInt32(row["cad_pes_id_pessoa"]);
                    var idtAgenda = 0;
                    var msg = string.Format(mensagem, nome, data, horario, link);


                    var dtbTelefone = ObterTelefone(idtPessoa);

                    if (dtbTelefone.Rows.Count > 0)
                    {
                        var telefone = dtbTelefone.Rows[0][0].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("*", "").Replace("_", "").Replace("/", "");

                        GravarMensagemOracle(telefone, msg, idtAgenda, "T");

                    }
                }
                catch (Exception)
                {

                    continue;
                }
            }


        }

        private static DataTable ObterLinksDia()
        {
            //agendamentos do dia seguinte
            var dtb = new GenericModel().GetData(@"select
                pes.cad_pes_nm_pessoa nome, 
                min(t.age_lnk_horario_ini) hora,
                trunc(a.age_agd_dt_atendimento) data,
                t.age_lnk_url link,
                pes.cad_pes_id_pessoa
                from tb_age_lnk_telemedicina t
                join tb_age_esm_escala_medica e 
                on t.tis_cbo_cd_cbos = e.tis_cbo_cd_cbos
                --and t.cad_pro_id_profissional = e.cad_pro_id_profissional --todos os profissionais que tem escala para especialidade
                and t.age_lnk_dia_semana = e.age_esm_nr_dia_semana
                join tb_age_agd_agenda a on a.age_esm_id = e.age_esm_id
                join tb_cad_pac_paciente p on a.cad_pac_id_paciente = p.cad_pac_id_paciente
                join tb_cad_pes_pessoa pes on p.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
                and  trunc(a.age_agd_dt_atendimento) = trunc(sysdate) +1  
                and  a.age_agd_hr_atendimento >= t.age_lnk_horario_ini 
                and  a.age_agd_hr_atendimento < t.age_lnk_horario_fim 
                group by pes.cad_pes_nm_pessoa, t.age_lnk_url, pes.cad_pes_id_pessoa, trunc(a.age_agd_dt_atendimento)");


            return dtb;

        }

        private static DataTable ObterTelefone(int idtPessoa)
        {
            var dtb = new GenericModel().GetData(string.Format(@"select tel.cad_tel_nr_num_tel from tb_cad_tel_telefone tel
            where tel.cad_pes_id_pessoa = {0}
            and tel.aux_tte_cd_tp_tel_end in (8,16)
            order by tel.aux_tte_cd_tp_tel_end desc", idtPessoa));

            return dtb;

        }

        private static void GravarMensagemOracle(string destino, string mensagem, int idtAgenda = 0, string tipoControle = "")
        {
            try
            {
                //0 pendente, 1 enviada, 2 erro
                string query = @"insert into tb_sgs_eml_envia_email 
                            (SGS_EML_ID, SGS_EML_STATUS, SGS_EML_CURTO_TEXTO, SGS_EML_DESTINO, SGS_EML_DT_ULTIMA_ATUALIZACAO, SGS_EML_ASSUNTO, SGS_EML_CONTROLE_ID, SMS_EML_RETORNO_TIPO)
                            values
                            (sgs.seq_sgs_eml_01.nextval, '0', :mensagem, :destino, sysdate, 'SMS', :idtAgenda, :tipoControle)";

                var param = new GenericModel().CreateParameterCollecion();
                param.Add(new GenericModel().CreateParameter("mensagem", mensagem));
                param.Add(new GenericModel().CreateParameter("destino", destino));
                param.Add(new GenericModel().CreateParameter("idtAgenda", idtAgenda));
                param.Add(new GenericModel().CreateParameter("tipoControle", tipoControle));
                new GenericModel().ExecuteCommand(query, param);
            }
            catch (Exception ex)
            {


                throw ex;
            }


        }

    }
}
