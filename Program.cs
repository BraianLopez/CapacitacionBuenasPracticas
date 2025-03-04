using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppBuenasPracticas1.Entities;

namespace ConsoleAppBuenasPracticas1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LOGDBEntities db = new LOGDBEntities();
            try
            {
                Articulo articuloAAgregarALaBaseDeDatos = new Articulo();
                articuloAAgregarALaBaseDeDatos.Nombre = "Curacocos";
                articuloAAgregarALaBaseDeDatos.Descripcion = "Frasco optimizado para curar flores de cannabis";
                articuloAAgregarALaBaseDeDatos.Precio = 45000;
                //agrego el articulo
                db.Articulos.Add(articuloAAgregarALaBaseDeDatos);
                //guardo en la base de datos
                db.SaveChanges();
                throw new Exception("excepcion personalizada");
            }
            catch (Exception ex)
            {
                AppLog appLog = new AppLog();
                appLog.Usuario = "1";
                appLog.Tipo = "EXCEPCION";
                appLog.Descripcion = "Error creando la conexion a la base de datos: " + ex.Message.ToString();
                db.AppLogs.Add(appLog);
                db.SaveChanges();
                //Console.WriteLine("Error creando la conexion a la base de datos: " + ex.Message.ToString());
            }
            Console.Read();
            //try
            //{
            //    FileInfo file = new FileInfo("c:\\users\\Prueba.TXT");
            //    file.Create();
            //}
            //catch (DirectoryNotFoundException ex)
            //{
            //    Console.WriteLine("No se encontró la ruta en la que quieres crear el archivo");
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message.ToString());
            //}
        }
    }
}
