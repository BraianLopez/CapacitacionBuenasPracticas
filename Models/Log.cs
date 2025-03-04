using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppBuenasPracticas1.Entities;

namespace ConsoleAppBuenasPracticas1.Models
{
    public class Log
    {
        public static void Escribir(string usuario, string tipo, string descripcion)
        {
            try
            {
                LOGDBEntities db = new LOGDBEntities();
                AppLog appLog = new AppLog();
                appLog.Usuario = usuario;
                appLog.Tipo = tipo;
                appLog.Descripcion = descripcion;
                db.AppLogs.Add(appLog);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                try
                {
                    using (StreamWriter sw = new StreamWriter("c:\\LogApp.txt"))
                    {
                        sw.WriteLine(ex.Message);
                        sw.WriteLine(ex.InnerException);

                        sw.WriteLine(ex.StackTrace);
                        sw.WriteLine(ex.Source);
                    }
                }
                catch
                {

                }
            }
        }
    }
}
