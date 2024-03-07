using PagedList;
using sgs_admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sgs_admin.Controllers
{
    public class ClinicaAtendimentoController : Controller
    {
        //
        // GET: /ClinicaAtendimento/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarClinica(int codigo)
        {
            string query = string.Format("select clc.cad_clc_id,\n" +
                                    "            clc.cad_clc_dt_ini_vigencia,\n" +
                                    "            clc.cad_clc_dt_fim_vigencia,\n" +
                                    "            clc.cad_clc_cd_clinica,\n" +
                                    "            clc.cad_clc_fl_status,\n" +
                                    "            clc.cad_clc_ds_descricao\n" +
                                    "       from tb_cad_clc_clinica_credenciada clc\n" +
                                    "      where clc.cad_clc_cd_clinica = {0}\n", codigo,
                                    "   order by 6 desc");

            var resultSGS = Helper.DataAccessHelper.GetData(query, "SGS");

            List<ClinicaAtendimento> Lista = new List<ClinicaAtendimento>();

            foreach (var item in resultSGS)
            {
                Lista.Add(new ClinicaAtendimento
                {
                    Idt = Convert.ToInt32(item["CAD_CLC_ID"]),
                    Codigo = Convert.ToInt32(item["CAD_CLC_CD_CLINICA"]),
                    Clinica = Convert.ToString(item["CAD_CLC_DS_DESCRICAO"]),
                    Inicio = Convert.ToDateTime(item["CAD_CLC_DT_INI_VIGENCIA"]),
                    Fim = item["CAD_CLC_DT_FIM_VIGENCIA"] == DBNull.Value ? null : Convert.ToDateTime(item["CAD_CLC_DT_FIM_VIGENCIA"]),
                    Status = Convert.ToString(item["CAD_CLC_FL_STATUS"]),
                });
            }

            return View(Lista);
        }
    }
}
