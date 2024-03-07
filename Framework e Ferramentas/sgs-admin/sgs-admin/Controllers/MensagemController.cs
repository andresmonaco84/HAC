using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using sgs_admin.Models;
using PagedList;
using System.Linq;

namespace sgs_admin.Controllers
{
    public class MensagemController : Controller
    {

        //
        // GET: /Mensagem/
        public ActionResult Index(int? page)
        {
            const string query = "   select asi.aux_asi_id,\n" +
                                    "       asi.aux_asi_data_ini,\n" + 
                                    "       asi.aux_asi_data_fim,\n" + 
                                    "       asi.aux_asi_ds_sistema,\n" + 
                                    "       asi.aux_asi_ds_mensagem,\n" + 
                                    "       asi.aux_asi_fl_status,\n" + 
                                    "       asi.seg_mod_id_modulo,\n" +
                                    "       asi.aux_asi_imagem\n" + 
                                    "  from tb_aux_asi_aviso_sistema asi\n" + 
                                    "  order by 1 desc";

            var resultSGS = Helper.DataAccessHelper.GetData(query, "SGS");

            List<Mensagem> Lista = new List<Mensagem>();
            foreach (var item in resultSGS)
            {
                Lista.Add(new Mensagem
                {
                    Id = Convert.ToInt32(item["AUX_ASI_ID"]),
                    Inicio = Convert.ToDateTime(item["AUX_ASI_DATA_INI"]),
                    Fim = Convert.ToDateTime(item["AUX_ASI_DATA_FIM"]),
                    Sistema = Convert.ToString(item["AUX_ASI_DS_SISTEMA"]),
                    Texto = Convert.ToString(item["AUX_ASI_DS_MENSAGEM"]),
                    Status = Convert.ToBoolean(item["AUX_ASI_FL_STATUS"]),
                    Modulo = Convert.ToString(item["SEG_MOD_ID_MODULO"]),
                    LogoImagem = Convert.ToString(item["AUX_ASI_IMAGEM"])
                    
                });
            }


            int pageSize = 4;
            int pageNumber = (page ?? 1);


            //ViewBag.Fabiola = "Sim";

            //return View(Lista);
            return View(Lista.ToPagedList(pageNumber, pageSize));
        }


        public Boolean ValidarPeriodoAtivo(Mensagem mensagem)
        {
            string query = string.Format(" select count(*) as count\n" +
                                         "   from tb_aux_asi_aviso_sistema asi\n" +
                                         "  where (fnc_validar_vigencia_datahora(asi.aux_asi_data_ini, asi.aux_asi_data_fim, {0}) = 1\n" +
                                         "      or fnc_validar_vigencia_datahora(asi.aux_asi_data_ini, asi.aux_asi_data_fim, {1}) = 1)\n" +
                                         "     and asi.aux_asi_id <> {2} ",
                                         " to_date( '" + mensagem.Inicio.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI')",
                                         " to_date( '" + mensagem.Fim.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI')",
                                         mensagem.Id);

            var resultSGS = Helper.DataAccessHelper.GetData(query, "SGS");

            foreach (var item in resultSGS)
            {
                if (Convert.ToInt32(item["COUNT"]) > 0)
                    return false;
            }
            return true;
        }


        public Boolean ValidarEditarDataHora(Mensagem mensagem)
        {
            string query = string.Format(" select count(*) as count\n" +
                                         "  from tb_aux_asi_aviso_sistema asi\n" +
                                         " where (to_date(to_char(asi.aux_asi_data_ini, 'dd/MM/yyyy HH24MI'), 'dd/MM/yyyy HH24mi') = {0}\n" +
                                         "    or  to_date(to_char(asi.aux_asi_data_fim, 'dd/MM/yyyy HH24MI'), 'dd/MM/yyyy HH24mi') = {1}\n" +
                                         "   and  asi.aux_asi_id = {2}",
                                         " to_date( '" + mensagem.Inicio.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI')",
                                         " to_date( '" + mensagem.Fim.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI'))",
                                         mensagem.Id);

            var resultSGS = Helper.DataAccessHelper.GetData(query, "SGS");

            foreach (var item in resultSGS)
            {
                if (Convert.ToInt32(item["COUNT"]) > 0)
                    return false;
            }
            
            return true;
        }


        //public Boolean ValidarTeste(Mensagem mensagem)
        //{
        //    string query = string.Format(" select to_date(to_char(asi.aux_asi_data_ini, 'dd/MM/yyyy HH24MI'), 'dd/MM/yyyy HH24mi') as datainibase,\n" +
        //                                 "        to_date(to_char(asi.aux_asi_data_fim, 'dd/MM/yyyy HH24MI'), 'dd/MM/yyyy HH24mi') as datafimbase,\n" +
        //                                 "        to_date( '" + mensagem.Inicio.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI') as datainiparam,\n" +
        //                                 "        to_date( '" + mensagem.Fim.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI') as datafimparam\n" +
        //                                 "  from tb_aux_asi_aviso_sistema asi\n" +
        //                                 " where (to_date(to_char(asi.aux_asi_data_ini, 'dd/MM/yyyy HH24MI'), 'dd/MM/yyyy HH24mi') = {0}\n" +
        //                                 "    or  to_date(to_char(asi.aux_asi_data_fim, 'dd/MM/yyyy HH24MI'), 'dd/MM/yyyy HH24mi') = {1}\n" +
        //                                 "   and  asi.aux_asi_id = {2}",
        //                                 " to_date( '" + mensagem.Inicio.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI')",
        //                                 " to_date( '" + mensagem.Fim.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture) + "', 'DD/MM/YYYY HH24MI'))",
        //                                 mensagem.Id);

        //    var resultSGS = Helper.DataAccessHelper.GetData(query, "SGS");

        //    foreach (var item in resultSGS)
        //    {
        //        if (Convert.ToString(item["DATAINIBASE"]) == Convert.ToString(item["DATAINIPARAM"]) && Convert.ToString(item["DATAFIMBASE"]) == Convert.ToString(item["DATAFIMPARAM"])) //não alterando nada
        //            return false;
        //        if (Convert.ToString(item["DATAINIBASE"]) == Convert.ToString(item["DATAINIPARAM"]) && Convert.ToString(item["DATAINIBASE"]) != Convert.ToString(item["DATAINIPARAM"])) //alterando inicio
        //            return false; //não valida
        //        if (Convert.ToString(item["DATAFIMBASE"]) != Convert.ToString(item["DATAFIMPARAM"]) && Convert.ToString(item["DATAINIBASE"]) == Convert.ToString(item["DATAINIPARAM"])) //alterando fim
        //            return false;
        //    }

        //    return true;
        //}


        //
        // GET: /Mensagem/Create
        public ActionResult Create()
        {
            var list = new[]
            {
                new SelectListItem { Value = "ti", Text = "ti" },
                new SelectListItem { Value = "acs", Text = "acs" },
                new SelectListItem { Value = "uhg", Text = "uhg" },
            };
            ViewBag.Lista = new SelectList(list, "Value", "Text"); ViewBag.Lista = new SelectList(list, "Value", "Text");
            return View();
        }

        
        //
        // POST: /Mensagem/Create
        [HttpPost]
        //public ActionResult Create(Mensagem mensagem, FormCollection form)
        public ActionResult Create(Mensagem mensagem)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            try
            {
                if (ModelState.IsValid)
                {
                    if (mensagem.Inicio < DateTime.Now)
                    {
                        throw new Exception("A Data/Hora de Início deve ser maior ou igual a Data/Hora atual");
                    }

                    if (mensagem.Fim < mensagem.Inicio)
                    {
                        throw new Exception("A Data/Hora Fim deve ser maior ou igual a Data/Hora Início");
                    }

                    if (!ValidarPeriodoAtivo(mensagem))
                    {
                        throw new Exception("A Data/Hora de Início deve ser maior que a Data/Hora de Início da última mensagem cadastrada");
                    }


                    // TODO: Add insert logic here
                    string query = string.Format("insert into tb_aux_asi_aviso_sistema asi\n" +
                                                 "      (asi.aux_asi_id,\n" +
                                                 "       asi.aux_asi_data_ini,\n" +
                                                 "       asi.aux_asi_data_fim,\n" +
                                                 "       asi.aux_asi_ds_sistema,\n" +
                                                 "       asi.aux_asi_ds_mensagem,\n" +
                                                 "       asi.aux_asi_fl_status,\n" +
                                                 "       asi.seg_mod_id_modulo,\n" +
                                                 "       asi.aux_asi_imagem)\n" +
                                                 "       values (seq_aux_asi_01.nextval, to_date('{0}', 'dd/MM/yyyy HH24MI'), to_date('{1}', 'dd/MM/yyyy HH24MI'), '{2}', :pmensagem, '{4}', {5},'{6}')",
                                                 mensagem.Inicio.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture),
                                                 mensagem.Fim.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture),
                                                 mensagem.Sistema,
                                                 mensagem.Texto,
                                                 1,
                                                 mensagem.Modulo == null ? "null" : Convert.ToString(mensagem.Modulo),
                                                 mensagem.LogoImagem);

                    OracleParameter par = new OracleParameter(":pmensagem", mensagem.Texto);

                    Helper.DataAccessHelper.ExecuteCommand(query, "SGS", new List<OracleParameter>{par});

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(mensagem);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);

                return View(mensagem);
            }
        }


        //
        // GET: /Mensagem/Edit/5
        public ActionResult Edit(int id)
        {
            string query = " select asi.aux_asi_id,\n" +
                           "        asi.aux_asi_data_ini,\n" +
                           "        asi.aux_asi_data_fim,\n" +
                           "        asi.aux_asi_ds_sistema,\n" +
                           "        asi.aux_asi_ds_mensagem,\n" +
                           "        asi.aux_asi_fl_status,\n" +
                           "        asi.seg_mod_id_modulo,\n" +
                           "        asi.aux_asi_imagem\n" +
                           "   from tb_aux_asi_aviso_sistema asi\n" +
                           "  where asi.aux_asi_id = " + id;

            var result = Helper.DataAccessHelper.GetData(query, "SGS");

            var mensagem = new Mensagem
                {
                    Inicio = Convert.ToDateTime(result[0]["AUX_ASI_DATA_INI"].ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)),
                    Fim = Convert.ToDateTime(result[0]["AUX_ASI_DATA_FIM"].ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)),
                    Sistema = Convert.ToString(result[0]["AUX_ASI_DS_SISTEMA"]),
                    Texto = Convert.ToString(result[0]["AUX_ASI_DS_MENSAGEM"]),
                    Status = Convert.ToBoolean(result[0]["AUX_ASI_FL_STATUS"]),
                    Modulo = Convert.ToString(result[0]["SEG_MOD_ID_MODULO"]),
                    LogoImagem = Convert.ToString(result[0]["AUX_ASI_IMAGEM"])
                };

            return View(mensagem);
        }


        //
        // POST: /Mensagem/Edit/5
        [HttpPost]
        public ActionResult Edit(Mensagem mensagem)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            try
            {
                if (ModelState.IsValid)
                {
                    if (ValidarEditarDataHora(mensagem))
                    //if (ValidarEditarDataHora(mensagem) || ValidarTeste(mensagem))
                    {
                        if (mensagem.Inicio < DateTime.Now)
                        {
                            throw new Exception("A Data/Hora de Início deve ser maior ou igual a Data/Hora atual");
                        }
                        if (mensagem.Fim < mensagem.Inicio)
                        {
                            throw new Exception("A Data/Hora Fim deve ser maior ou igual a Data/Hora Início");
                        }
                        if (!ValidarPeriodoAtivo(mensagem))
                        {
                            throw new Exception("A Data/Hora de Início deve ser maior que a Data/Hora de Início da última mensagem cadastrada");
                        }
                    }

                    // TODO: Add update logic here
                    //string query = string.Format(" update tb_aux_asi_aviso_sistema asi\n" +
                    //                             "    set asi.aux_asi_data_ini = to_date('{0}', 'dd/MM/yyyy HH24MI'),\n" +
                    //                             "        asi.aux_asi_data_fim = to_date('{1}', 'dd/MM/yyyy HH24MI'),\n" +
                    //                             "        asi.aux_asi_ds_sistema= '{2}',\n" +
                    //                             "        asi.aux_asi_ds_mensagem = '{3}',\n" +
                    //                             "        asi.aux_asi_fl_status = {4},\n" +
                    //                             "        asi.seg_mod_id_modulo = '{5}'\n" +
                    //                             "  where asi.aux_asi_id = {6}",
                    //                             mensagem.Inicio.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture),
                    //                             mensagem.Fim.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture),
                    //                             mensagem.Sistema,
                    //                             mensagem.Texto,
                    //                             1,
                    //                             //mensagem.Status ? '1' : '0',
                    //                             mensagem.Modulo == null ? null : Convert.ToString(mensagem.Modulo),
                    //                             mensagem.Id);


                    //Helper.DataAccessHelper.ExecuteCommand(query, "SGS");

                    string query = string.Format(" update tb_aux_asi_aviso_sistema asi\n" +
                                                 "    set asi.aux_asi_data_ini = to_date('{0}', 'dd/MM/yyyy HH24MI'),\n" +
                                                 "        asi.aux_asi_data_fim = to_date('{1}', 'dd/MM/yyyy HH24MI'),\n" +
                                                 "        asi.aux_asi_ds_sistema= '{2}',\n" +
                                                 "        asi.aux_asi_ds_mensagem = :pmensagem,\n" +
                                                 "        asi.aux_asi_fl_status = {4},\n" +
                                                 "        asi.seg_mod_id_modulo = '{5}',\n" +
                                                 "        asi.aux_asi_imagem = '{7}'\n" +
                                                 "  where asi.aux_asi_id = {6}",
                                                 mensagem.Inicio.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture),
                                                 mensagem.Fim.ToString("dd/MM/yyyy HHmm", CultureInfo.InvariantCulture),
                                                 mensagem.Sistema,
                                                 mensagem.Texto,
                                                 1,
                                                 //mensagem.Status ? '1' : '0',
                                                 mensagem.Modulo == null ? null : Convert.ToString(mensagem.Modulo),
                                                 mensagem.Id,
                                                 mensagem.LogoImagem);


                    OracleParameter par = new OracleParameter(":pmensagem", mensagem.Texto);

                    Helper.DataAccessHelper.ExecuteCommand(query, "SGS", new List<OracleParameter> { par });

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(mensagem);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);

                return View(mensagem);
            }
        }


        //
        // GET: /Mensagem/Delete/5
        public ActionResult Delete(int id)
        {
            var query = "delete tb_aux_asi_aviso_sistema where aux_asi_id = " + id;

            Helper.DataAccessHelper.ExecuteCommand(query, "SGS");

            return RedirectToAction("Index");
        }
    }
}
