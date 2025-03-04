using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppBuenasPracticas1.Entities;
using ConsoleAppBuenasPracticas1.Models;

namespace ConsoleAppBuenasPracticas1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LOGDBEntities db = new LOGDBEntities();
            try
            {
                Log.Escribir("1","INFO","instancié el articulo");
                Articulo articuloAAgregarALaBaseDeDatos = new Articulo();
                articuloAAgregarALaBaseDeDatos.Nombre = "Curacocos de bolsillo";
                articuloAAgregarALaBaseDeDatos.Descripcion = "Frasco optimizado para curar flores de cannabis";
                articuloAAgregarALaBaseDeDatos.Precio = 45000;
                //agrego el articulo
                Log.Escribir("1", "INFO", "Cargué el articulo en la bd");

                db.Articulos.Add(articuloAAgregarALaBaseDeDatos);
                //guardo en la base de datos
                Log.Escribir("1", "INFO", "guardé los cambios");
                db.SaveChanges();
                throw new Exception("excepcion personalizada");
            }
            catch (Exception ex)
            {
                Log.Escribir("1","EXCEPCION","Error guardando el articulo en la base de datos: "+ex.Message.ToString());
                Console.WriteLine("No se encontró la ruta en la que quieres crear el archivo: " + ex.Message.ToString());

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
