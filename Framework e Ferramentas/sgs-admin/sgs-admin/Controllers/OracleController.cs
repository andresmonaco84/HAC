using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace sgs_admin.Controllers
{
    public class OracleController : Controller
    {
        //
        // GET: /Oracle/

        public ActionResult Index(string error)
        {
            try
            {
                if (error != null) {ViewBag.ErrorMessage = error;}

                const string query = "select gv.inst_id,\n" +
                                     "       gv.sid,\n" +
                                     "       gv.serial#,\n" +
                                     "       gv.username,\n" +
                                     "       gv.program,\n" +
                                     "       gv.machine,\n" +
                                     "       gv.status,\n" +
                                     "       a.blocking_others,\n" +
                                     "       o.object_name\n" +
                                     "  from dba_locks a, gv$session gv, gv$locked_object lo, dba_objects o\n" +
                                     " where a.session_id = gv.sid\n" +
                                     "   and gv.machine not in ('orahac01', 'orahac02')\n" +
                                     "   and a.blocking_others = 'Blocking'\n" +
                                     "   and lo.inst_id = gv.inst_id\n" +
                                     "   and lo.session_id = gv.sid\n" +
                                     "   and o.object_id = lo.object_id";

                var resultSGS = Helper.DataAccessHelper.GetData(query, "SGS");
                var resultRM = Helper.DataAccessHelper.GetData(query, "RM");

                var result = new Dictionary<string, dynamic> { { "SGS", resultSGS }, { "RM", resultRM } };

                return View(result);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();

        }

        public ActionResult Kill(string database, string sid, string serial)
        {
            var cmd = string.Format("alter system kill session '{0},{1}'", sid, serial);

            try
            {
                Helper.DataAccessHelper.ExecuteCommand(cmd, database);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }


            return RedirectToAction("Index", new { error = ViewBag.ErrorMessage});
        }

    }
}
