using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boletin.Entities
{
    public class Estudiante : Boletin
    {
        private string id;
        private string nombre;
        private string direccion;
        private int edad;

        public Estudiante() : base()
        {
        }
        public Estudiante(List<float> quices, List<float> trabajos, List<float> parciales, string id, string nombre, string direccion, int edad) : base(quices, trabajos, parciales)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.edad = edad;
        }
        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Edad { get => edad; set => edad = value; }

        public void AñadirEstudiante(List<Estudiante> estudiantes)

        {
            Estudiante estudiante = new Estudiante();
            Console.WriteLine("Ingrese el Id del estudiante:");
            estudiante.Id = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del estudiante:");
            estudiante.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del estudiante:");
            estudiante.Direccion = Console.ReadLine();
            Console.WriteLine("Ingrese la edad del estudiante");
            estudiante.Edad = Convert.ToInt32(Console.ReadLine());
            estudiante.Quices = new List<float>();
            estudiante.Trabajos = new List<float>();
            estudiante.Parciales = new List<float>();
            estudiantes.Add(estudiante);
        }
        public void AñadirNotas(List<Estudiante> ListaStudi, byte opcion)
        {
            Console.WriteLine("Ingrese el id del estudiante:");
            string codigostudiante = Console.ReadLine();
            Estudiante alumno = ListaStudi.FirstOrDefault(x => x.Id.Equals(codigostudiante));
            Console.WriteLine("Porfavor ingrese la nota del: ");
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Quiz Nro: {0}", (alumno.Quices.Count + 1));
                    alumno.Quices.Add(float.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Trabajo Nro: {0}", (alumno.Trabajos.Count + 1));
                    alumno.Trabajos.Add(float.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Parcial Nro: {0}", (alumno.Parciales.Count + 1));
                    alumno.Parciales.Add(float.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.Clear();

                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opcion invalida");
                    Console.WriteLine("Seleecione una opcion valida");
                    Console.ReadKey();
                    break;
            }
        }

        public void EliminarItem(List<Estudiante> ListaStudi)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el id del estudiante a eliminar");
            string codigostudiante = Console.ReadLine();
            Estudiante studentToRemove = ListaStudi.FirstOrDefault(x => x.Id.Equals(codigostudiante)) ?? new Estudiante();
            if (studentToRemove.id != null)
            {
                ListaStudi.Remove(studentToRemove);
                MisFunciones.GuardarDatos(ListaStudi);
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }

        public void EliminarNota(List<Estudiante> ListaStudi, byte opcN)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el id el estudiante:");
            string codigostudiante = Console.ReadLine();
            Estudiante searchstudent = ListaStudi.FirstOrDefault(x => x.Id.Equals(codigostudiante)) ?? new Estudiante();
            if (searchstudent.id != null)
            {
                Console.WriteLine("Ingrese la posicion de la nota que quiere eliminar:");
                string notaE=Console.ReadLine();
                
                


            }
        }

    }
}