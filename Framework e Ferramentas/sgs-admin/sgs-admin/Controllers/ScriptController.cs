using sgs_admin.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;

namespace sgs_admin.Controllers
{
    public class ScriptController : Controller
    {
        //
        // GET: /Script/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult TransferirProntuario(int atendimentoNovo, int atendimentoAntigo)
        public ActionResult Index(int atendimentoNovo, int atendimentoAntigo)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            try
            {
                //delete atendimento where codateamb = &atendimento_novo;
                string queryDeleteAtendimento = string.Format("delete atendimento where codateamb = {0}", atendimentoNovo);
                Helper.DataAccessHelper.ExecuteCommand(queryDeleteAtendimento, "SGS");

                string queryInserAtendimento = string.Format("insert into atendimento(codateamb, codpac, pulso, alergias, pressao_dis, pressao_sis, \n"+
                                                             "                        medic_habit, freq_cardiaca, estado_geral, nivel_consc, freq_respira, \n" +
                                                             "                        temperatura, cid, status_consulta, encaminha, ds_receita, atendimento, \n" +
                                                             "                        resultado, ds_conduta, horate, datate, horafim, justifica, codmed, \n" +
                                                             "                        primeira_vez, peso, altura, imc, per_cefalico, sc, in_repouso, \n" +
                                                             "                        in_curativo, ds_enfermagem, dt_enfermagem, cd_matricula_enfermagem, \n" +
                                                             "                        in_enfermagem) \n" +
                                                             " select {0}, codpac, pulso, alergias, pressao_dis, pressao_sis, medic_habit, freq_cardiaca, \n" +
                                                             "        estado_geral, nivel_consc, freq_respira, temperatura, cid, status_consulta, encaminha, \n" +
                                                             "        ds_receita, atendimento, resultado, ds_conduta, horate, datate, horafim, justifica, \n" +
                                                             "        codmed, primeira_vez, peso, altura, imc, per_cefalico, sc, in_repouso, in_curativo, \n" +
                                                             "        ds_enfermagem, dt_enfermagem, cd_matricula_enfermagem, in_enfermagem \n" +
                                                             "   from atendimento where codateamb = {1}", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryInserAtendimento, "SGS");

                //update aten_cirurgia set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenCirurgia= string.Format("update aten_cirurgia set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenCirurgia, "SGS");

                //update aten_conduta set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenConduta = string.Format("update aten_conduta set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenConduta, "SGS");

                //update aten_gravidade set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenGravidade = string.Format("update aten_gravidade set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenConduta, "SGS");

                //update aten_guia_interna set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenGuiaInterna = string.Format("update aten_guia_interna set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenGuiaInterna, "SGS");

                //update aten_justifica set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenJustifica = string.Format("update aten_justifica set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenJustifica, "SGS");

                //update aten_observa set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenObserva = string.Format("update aten_observa set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenObserva, "SGS");

                //update aten_protese_sintese set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenProteseSintese = string.Format("update aten_protese_sintese set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenProteseSintese, "SGS");

                //update aten_receita set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenReceita = string.Format("update aten_receita set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenReceita, "SGS");

                //update atestado set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtestado = string.Format("update atestado set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtestado, "SGS");

                //update aten_queixa set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenQueixa = string.Format("update aten_queixa set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenQueixa, "SGS");

                //update aten_sinal set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenSinal = string.Format("update aten_sinal set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenSinal, "SGS");

                //update aten_sintoma set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenSintoma = string.Format("update aten_sintoma set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenSintoma, "SGS");

                //update auditagem set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAuditagem = string.Format("update auditagem set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAuditagem, "SGS");

                //update diag_secundario set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryDiagSecundario = string.Format("update diag_secundario set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryDiagSecundario, "SGS");

                //update tb_faturar_sadt set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryTBFaturarSADT = string.Format("update tb_faturar_sadt set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryTBFaturarSADT, "SGS");

                //update aten_curativo set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenCurativo = string.Format("update aten_curativo set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenCurativo, "SGS");

                //update aten_especialidade_enc set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtenEspecialidadeEnc = string.Format("update aten_especialidade_enc set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtenEspecialidadeEnc, "SGS");

                //update rel_medico set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryRelMedico = string.Format("update rel_medico set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryRelMedico, "SGS");

                //update tp_atendimento set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryTpAtendimento = string.Format("update tp_atendimento set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryTpAtendimento, "SGS");

                //update atestado_novo set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryAtestadoNovo = string.Format("update atestado_novo set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtestadoNovo, "SGS");

                //update pep.tb_queixa_ps set codateamb = &atendimento_novo where codateamb in (&atendimento_antigo);
                string queryTbQueixaPs = string.Format("update pep.tb_queixa_ps set codateamb = {0} where codateamb in {1};", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryTbQueixaPs, "SGS");

                //delete atendimento where codateamb = &atendimento_antigo;
                string queryAtendimento = string.Format("delete atendimento where codateamb in {0};", atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryAtendimento, "SGS");

                string queryUpdateAtendimento = string.Format(" BEGIN\n " +
                                                              "     DECLARE\n " +
                                                              "     CONT NUMBER;\n " +
                                                              "     CURSOR ATENDIMENTO IS\n " +
                                                              "         SELECT ATE.CAD_CID_CD_CID10, ATE.CAD_PRO_ID_PROF_EXEC\n " +
                                                              "             FROM TB_ATD_ATE_ATENDIMENTO ATE\n " +
                                                              "             WHERE ATE.ATD_ATE_ID = &ATENDIMENTO_ANTIGO;\n " +
                                                              "     BEGIN\n " +
                                                              "         FOR ATE IN ATENDIMENTO LOOP\n " +
                                                              "             UPDATE TB_ATD_ATE_ATENDIMENTO\n " +
                                                              "                 SET CAD_CID_CD_CID10 = ATE.CAD_CID_CD_CID10,\n " +
                                                              "                     CAD_PRO_ID_PROF_EXEC = ATE.CAD_PRO_ID_PROF_EXEC,\n " +
                                                              "                     ATD_ATE_FL_PRONT_ELETR_ATIVO = 'S'\n " +
                                                              "                 WHERE ATD_ATE_ID = {0};\n " +
                                                              "             UPDATE TB_ATD_ATE_ATENDIMENTO\n " +
                                                              "                 SET ATD_ATE_FL_PRONT_ELETR_ATIVO = 'N'\n " +
                                                              "                 WHERE ATD_ATE_ID = {1};\n " +
                                                              "         END LOOP;\n " +
                                                              "         COMMIT;\n " +
                                                              "     END;\n " +
                                                              "     COMMIT;\n " +
                                                              " END; ", atendimentoNovo, atendimentoAntigo);
                Helper.DataAccessHelper.ExecuteCommand(queryUpdateAtendimento, "SGS");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);

                return RedirectToAction("Index");
            }
        }
    }
}
