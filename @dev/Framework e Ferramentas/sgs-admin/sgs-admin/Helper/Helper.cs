using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.ServiceProcess;

namespace sgs_admin.Helper
{
    public class FileHelper
    {
        public static bool PathExists(string path)
        {
            var impersonation = new Impersonation();
            
            try
            {
                impersonation.Impersonate();
                return Directory.Exists(path);
            }
            catch
            {
                throw;
            }
            finally
            {
                impersonation.Revert();
            }
        }

        public static void CopyFiles(string sourcePath, string targetPath, bool allFiles = false)
        {
            var impersonation = new Impersonation();
            
            try
            {
                impersonation.Impersonate();

                if (!PathExists(targetPath))
                    Directory.CreateDirectory(targetPath);

                
                
                if (allFiles)
                {
                    //Now Create all of the directories
                    foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));    
                    }

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories).Where(newPath => !newPath.Contains(".config")))
                    {
                        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }
                }
                else
                {

                    string[] files;

                    files = Directory.GetFiles(sourcePath, "*.dll", SearchOption.TopDirectoryOnly)
                             .Concat(Directory.GetFiles(sourcePath, "*.exe", SearchOption.TopDirectoryOnly)).ToArray();
                    
                    foreach (string s in files)
                    {
                        if (s.Contains(".config")) continue;

                        // Use static Path methods to extract only the file name from the path.
                        var fileName = Path.GetFileName(s);
                        var destFile = Path.Combine(targetPath, fileName);
                        File.Copy(s, destFile, true);
                    }
                }
                

          
                
            }
            catch
            {
                throw;
            }
            finally
            {
                impersonation.Revert();
            }
        }

        
    }

    public class ServiceHelper
    {

        public static void StartStop(string serviceName, bool start, string server)
        {
            var impersonation = new Impersonation();

            try
            {
                impersonation.Impersonate();

                //var remoteMachine = server.Length > 0 ? server : ConfigurationManager.AppSettings["RemoteMachine"];

                var service = new ServiceController(serviceName, server);
                var timeout = TimeSpan.FromMilliseconds(20000);
                if (start)
                {
                    if (service.Status != ServiceControllerStatus.Running)
                    {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);    
                    }
                }
                else
                {
                    if (service.Status != ServiceControllerStatus.Stopped)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);    
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                impersonation.Revert();
            }
        }

    }
}