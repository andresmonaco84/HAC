using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Web;
using System.Web.Mvc;
using sgs_admin.Helper;

namespace sgs_admin.Controllers
{
    public class WebController : Controller
    {

        [HttpGet]
        public ActionResult Index(string error)
        {
            ViewBag.ErrorMessage = error;

            const string query = "select * from sgs.tb_sgs_admin a\n" +
                                "where tipo = 'W'\n" +
                                "order by nome";

            ViewBag.Message = "Web Servers";

            var result = Helper.DataAccessHelper.GetData(query, "SGS");

            return View(result);
        }

        public ActionResult Restart(string host)
        {
            try
            {
                //stop
                ServiceHelper.StartStop("W3SVC", false, host);

                //start
                ServiceHelper.StartStop("W3SVC", true, host);

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index", new { error = ViewBag.ErrorMessage });
        }

        public ActionResult Publish(string host, string path, string error)
        {
            ViewBag.WebServerName = host;
            ViewBag.Message = string.Format("Publish on {0}", host);
            ViewBag.ErrorMessage = error;
            ViewBag.ServicePath = path;

            var impersonation = new Impersonation();
            impersonation.Impersonate();

            //return list of backups
            var backupPath = string.Format("{0}backup\\", path);
            var dictionary = new Dictionary<string, string>();
            if (Directory.Exists(backupPath))
            {
                foreach (var item in Directory.GetDirectories(backupPath).ToList())
                {
                    dictionary.Add(item.Split('\\').Last(), item.Replace("\\", "\\\\"));
                }
            }

            impersonation.Revert();

            return View(dictionary);
        }

        [HttpPost]
        public ActionResult Publish(string host, string sourcePath, string targetPath, string error)
        {
            try
            {
                //check path
                if (!Helper.FileHelper.PathExists(targetPath))
                    throw new Exception("Path not found: " + targetPath);


                //copy all files
                Helper.FileHelper.CopyFiles(sourcePath, targetPath, true);

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Publish", new { host, path = targetPath, error = ViewBag.ErrorMessage });
            }

            return RedirectToAction("Publish", new { host, path = targetPath, error = string.Format("WebApplication on {0} was successfully updated.",host) });

        }

    }
}
