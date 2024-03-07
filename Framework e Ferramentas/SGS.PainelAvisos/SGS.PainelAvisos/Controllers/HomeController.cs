using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGS.PainelAvisos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("PainelCirurgias");
        }

        public ActionResult PainelCirurgias()
        {
            var oracleData = new OracleData();


            string sqlString = @"
   SELECT fnc_juntar_data_hora(CIR.ATD_CIR_DT_INICIO_REALIZ, cir.atd_cir_hr_inicio_realiz) inicio, SAU.AGE_SAU_DS_SALA SALA, 
                      sgs.FNC_INT_OBTER_INICIAIS(PES.CAD_PES_NM_PESSOA) PACIENTE, 
                      PES.CAD_PES_NM_PESSOA PESSOA, 
                      DECODE(HSC.ATD_HSC_FL_STATUS, 1, '', 2, 'EM ANDAMENTO', 3, 'POS ANESTESICO', 4, 'ALTA DE RECUPERACAO', 5, 'ENCAMINHADO AO LEITO', 6, 'ALTA HOSPITALAR') SITUACAO, 
                      PES.CAD_PES_DT_NASCIMENTO NASCIMENTO, 
                      PRO.CAD_PRO_NM_NOME CIRURGIAO ,
                      HSC.ATD_HSC_FL_STATUS,
                      HSC.ATD_CIR_ID
                 FROM SGS.TB_ATD_CIR_CIRURGIA_REALIZADA CIR, 
                      SGS.TB_ATD_PCI_PROCED_CIRURGIA    PCI, 
                      SGS.TB_ATD_HSC_HIST_STA_CIRURGIA  HSC, 
                      SGS.TB_AGE_SAU_SALA_UNID_AND      SAU, 
                      SGS.TB_CAD_PRO_PROFISSIONAL       PRO, 
                      SGS.TB_ATD_ATE_ATENDIMENTO        ATD, 
                      SGS.TB_CAD_PAC_PACIENTE           PAC, 
                      SGS.TB_CAD_PES_PESSOA             PES, 
                      SGS.TB_ASS_PAT_PACIEATEND         PAT , 
                    (SELECT MAX(HSC.ATD_HSC_DT_INICIO) as DTH, HSC.ATD_CIR_ID IDCIR 
                        FROM SGS.TB_ATD_HSC_HIST_STA_CIRURGIA  HSC 
                       GROUP BY HSC.ATD_CIR_ID) SQ
                WHERE PCI.ATD_CIR_ID = CIR.ATD_CIR_ID 
                  AND CIR.ATD_CIR_FL_SITUACAO = 'A' 
                  AND PCI.ATD_PCI_FL_SITUACAO = 'A' 
                  AND HSC.ATD_CIR_ID = CIR.ATD_CIR_ID 
                  AND SAU.AGE_SAU_ID = CIR.AGE_SAU_ID 
                  AND PRO.CAD_PRO_ID_PROFISSIONAL = CIR.CAD_PRO_ID_CIRURGIAO 
                  AND CIR.ATD_CIR_DT_INICIO_REALIZ >= TRUNC(SYSDATE)
                  AND CIR.ATD_CIR_DT_FIM_REALIZ IS NULL 
                  AND HSC.ATD_HSC_FL_STATUS NOT IN (5,6) 
                  AND ATD.ATD_ATE_ID = CIR.ATD_ATE_ID 
                  AND ATD.ATD_ATE_DT_ATENDIMENTO = PAT.ASS_PAT_DT_ENTRADA 
                  AND ATD.ATD_ATE_HR_ATENDIMENTO = PAT.ASS_PAT_HR_ENTRADA 
                  AND ATD.ATD_ATE_ID = PAT.ATD_ATE_ID 
                  AND PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE 
                  AND PAC.CAD_PES_ID_PESSOA = PES.CAD_PES_ID_PESSOA 
                  AND SQ.IDCIR = CIR.ATD_CIR_ID 
             --     AND SQ.IDHSC = HSC.ATD_HSC_ID 
                  AND SQ.DTH = HSC.ATD_HSC_DT_INICIO
                  ORDER BY 1 desc ";            

            var result = oracleData.ExecuteQuery(sqlString);

            var list = new List<AvisoCirurgiaViewModel>();

            foreach (DataRow row in result.Rows)
            {
                list.Add(new AvisoCirurgiaViewModel
                {
                    Cirurgiao = row["CIRURGIAO"].ToString(),
                    Nascimento = Convert.ToDateTime(row["NASCIMENTO"].ToString()).ToString("dd/MM/yyyy"),
                    Paciente = row["PACIENTE"].ToString(),
                    Situacao = row["SITUACAO"].ToString(),
                    Pessoa = row["PESSOA"].ToString(),
                    Sala = row["SALA"].ToString(),
                    Inicio = row["INICIO"].ToString()
                });
            }

            return View(list);
        }




        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}


public class AvisoCirurgiaViewModel
{
    public string Sala { get; set; }
    public string Paciente { get; set; }
    public string Pessoa { get; set; }
    public string Situacao { get; set; }
    public string Nascimento { get; set; }
    public string Cirurgiao { get; set; }
    public string Inicio { get; set; }

}