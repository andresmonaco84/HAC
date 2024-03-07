using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceProcess;
using sgs_admin.Helper;
using System.IO;

namespace sgs_admin.Controllers
{
    public class HomeController : Controller
    {
        private string GetServicePath(string serviceName)
        {
            var servicePath = "";

            var data = DataAccessHelper.GetData(string.Format("select caminho from sgs.tb_sgs_admin a\n" +
                                                           "where tipo = 'S'\n" +
                                                           "and nome = '{0}'\n" +
                                                           "order by nome", serviceName), "SGS");


            foreach (var row in data)
            {
                foreach (var col in row)
                {
                    if (col.Key == "CAMINHO")
                    {
                        servicePath = col.Value;
                    }
                }
            }

            return servicePath;
        }

        private string GetServiceHostName()
        {
            string host = "";

            var data = DataAccessHelper.GetData(string.Format("select host from sgs.tb_sgs_admin a\n" +
                                                           "where tipo = 'S' and rownum = 1"), "SGS");

            foreach (var row in data)
            {
                foreach (var col in row)
                {

                    if (col.Key == "HOST")
                    {
                        host = col.Value;
                    }
                }
            }

            return host;

        }

        [HttpGet]
        public ActionResult Index(string error)
        {
            var impersonation = new Impersonation();

            impersonation.Impersonate();

            var remoteMachine = GetServiceHostName();

            var services = ServiceController.GetServices(remoteMachine).Where(s => s.ServiceName.Contains("SGS"));


            ViewBag.Message = "Services of " + remoteMachine;

            ViewBag.ErrorMessage = error;

            impersonation.Revert();

            return View(services);
        }

        public ActionResult StartStop(string serviceName, bool start)
        {
            try
            {
                var host = GetServiceHostName();

                ServiceHelper.StartStop(serviceName, start, host);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index", new { error = ViewBag.ErrorMessage });
        }

        public ActionResult Update(string serviceName, string error)
        {

            string servicePath = "";
            string host = "";

            var data = DataAccessHelper.GetData(string.Format("select caminho, host from sgs.tb_sgs_admin a\n" +
                                                           "where tipo = 'S'\n" +
                                                           "and nome = '{0}'\n" +
                                                           "order by nome", serviceName), "SGS");


            foreach (var row in data)
            {
                foreach (var col in row)
                {
                    if (col.Key == "CAMINHO")
                    {
                        servicePath = col.Value;
                    }

                    if (col.Key == "HOST")
                    {
                        host = col.Value;
                    }
                }
            }


            //string remoteMachine = ConfigurationManager.AppSettings["RemoteMachine"];

            ViewBag.ServicePath = servicePath;
            ViewBag.ServiceName = serviceName;
            ViewBag.Message = string.Format("Update service {1} on {0}", host, serviceName);
            ViewBag.ErrorMessage = error;

            var impersonation = new Impersonation();
            impersonation.Impersonate();

            //return list of backups
            var backupPath = string.Format("{0}backup\\", servicePath);
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
        public ActionResult Update(string serviceName, string updatePath, string error)
        {
            string servicePath = GetServicePath(serviceName);
            string host = GetServiceHostName();

            try
            {
                //check path
                if (!Helper.FileHelper.PathExists(updatePath))
                    throw new Exception("Path not found: " + updatePath);

                //stop service
                Helper.ServiceHelper.StartStop(serviceName, false, host);

                //backup files (datetimePath target)
                if (!updatePath.Contains("backup"))
                    Helper.FileHelper.CopyFiles(servicePath, string.Format("{0}\\backup\\{1}", servicePath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")));

                //copy only dll and exe
                Helper.FileHelper.CopyFiles(updatePath, servicePath);

                //start service and wait until started
                Helper.ServiceHelper.StartStop(serviceName, true, host);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Update", new { serviceName = serviceName, error = ViewBag.ErrorMessage });
            }

            return RedirectToAction("Update", new { serviceName = serviceName, error = string.Format("Service {0} was successfully updated on {1}.", serviceName, host) });

        }


    }
}
