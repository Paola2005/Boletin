using Boletin.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Boletin
{
    public class MisFunciones
    {

        public static byte MenuEstudiantes()
        {
            Console.WriteLine("1. Registrar Estudinte");
            Console.WriteLine("2. Buscar Estudiante");
            Console.WriteLine("3. Editar Estudiante");
            Console.WriteLine("4. Eliminar Estudiante");
            Console.WriteLine("5. Regresar al menu principal");
            return Convert.ToByte(Console.ReadLine());

        }
        public static byte MenuNotasPrin()
        {
            Console.WriteLine("1. Registrar nota");
            Console.WriteLine("2. Buscar nota");
            Console.WriteLine("3. Editar nota");
            Console.WriteLine("4. Eliminar nota");
            Console.WriteLine("5. Regresar al menu principal");
            return Convert.ToByte(Console.ReadLine());
        }
        public static byte MenuNotasA()
        {
            Console.WriteLine("1. Quices");
            Console.WriteLine("2. Trabajos");
            Console.WriteLine("3. Parciales");
            Console.WriteLine("4. Salir al menu principal");
            return Convert.ToByte(Console.ReadLine());
        }

        public static byte Reportes()
        {
            Console.WriteLine("1. Notas de grupo");
            Console.WriteLine("2. Notas Finales");
            Console.WriteLine("3. salir");
            return Convert.ToByte(Console.ReadLine());
        }

        public static void GuardarDatos(List<Estudiante> lstListado)
        {

            string json = JsonConvert.SerializeObject(lstListado, Formatting.Indented);

            File.WriteAllText("boletin.json", json);
        }

        public static List<Estudiante> LoadData()
        {
            List<Estudiante> lstListado = new List<Estudiante>();

            if (File.Exists("boletin.json"))
            {

                using (StreamReader reader = new StreamReader("boletin.json"))

                {
                    string json = reader.ReadToEnd();
                    lstListado = JsonConvert.DeserializeObject<List<Estudiante>>(json);
                }
            }

            return lstListado;
        }

    }


}