using Boletin.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Boletin
{
    public class MisFunciones
    {
        public static byte MenuNotas()
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
            // Serializa la lista de estudiantes a formato JSON con formato indentado.
            string json = JsonConvert.SerializeObject(lstListado, Formatting.Indented);
            //Se escribe todo lo que ingrese el usuario en el json
            File.WriteAllText("boletin.json", json);
        }

        public static List<Estudiante> LoadData()
        {
            List<Estudiante> lstListado = new List<Estudiante>();

            if (File.Exists("boletin.json"))
            {
                //abre el archivo para la lectura
                using (StreamReader reader = new StreamReader("boletin.json"))
                //el streamreader  para abrir y leer el archivo "boletin.json"
                {
                    string json = reader.ReadToEnd();
                    lstListado = JsonConvert.DeserializeObject<List<Estudiante>>(json);
                }
            }

            return lstListado;
        }
    }

}