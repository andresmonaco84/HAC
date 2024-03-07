using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.ServiceProcess;
using System.Web.Mvc;
using System.Reflection;
using System.EnterpriseServices;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

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

    //public static class MyExtensions
    //{
    //    public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
    //        where TEnum : struct, IComparable, IFormattable, IConvertible
    //    {
    //        var values = from TEnum e in Enum.GetValues(typeof(TEnum))
    //                     select new { Id = e, Name = e.ToString() };
    //        return new SelectList(values, "Id", "Name", enumObj);
    //    }

    //    private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
    //    {
    //        Type realModelType = modelMetadata.ModelType;

    //        Type underlyingType = Nullable.GetUnderlyingType(realModelType);
    //        if (underlyingType != null)
    //        {
    //            realModelType = underlyingType;
    //        }
    //        return realModelType;
    //    }

    //    private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

    //    public static string GetEnumDescription<TEnum>(TEnum value)
    //    {
    //        FieldInfo fi = value.GetType().GetField(value.ToString());

    //        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

    //        if ((attributes != null) && (attributes.Length > 0))
    //            return attributes[0].Description;
    //        else
    //            return value.ToString();
    //    }

    //    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
    //    {
    //        return EnumDropDownListFor(htmlHelper, expression, null);
    //    }

    //    public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
    //    {
    //        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
    //        Type enumType = GetNonNullableModelType(metadata);
    //        IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

    //        IEnumerable<SelectListItem> items = from value in values
    //                                            select new SelectListItem
    //                                            {
    //                                                Text = GetEnumDescription(value),
    //                                                Value = value.ToString(),
    //                                                Selected = value.Equals(metadata.Model)
    //                                            };

    //        // If the enum is nullable, add an 'empty' item to the collection
    //        if (metadata.IsNullableValueType)
    //            items = SingleEmptyItem.Concat(items);

    //        return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
    //    }
    //}

}