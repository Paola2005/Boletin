using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        public List<float> Notas { get; set; } = new List<float>();

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
        public static Estudiante BuscarEstudiantePorId(List<Estudiante> ListaStudi, string id)
        {
            return ListaStudi.FirstOrDefault(estudiante => estudiante.Id.Equals(id));
        }
        public void EditarEstudiante()
        {
            Console.WriteLine("Editar información del estudiante (deje en blanco para mantener los valores actuales):");

            Console.WriteLine($"ID actual: {this.Id}");
            Console.Write("Nuevo ID: ");
            string nuevoId = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoId))
            {
                this.Id = nuevoId;
            }

            Console.WriteLine($"Nombre actual: {this.Nombre}");
            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                this.Nombre = nuevoNombre;
            }

            Console.WriteLine($"Dirección actual: {this.Direccion}");
            Console.Write("Nueva dirección: ");
            string nuevaDireccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaDireccion))
            {
                this.Direccion = nuevaDireccion;
            }

            Console.WriteLine($"Edad actual: {this.Edad}");
            Console.Write("Nueva edad: ");
            string nuevaEdadStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaEdadStr))
            {
                if (int.TryParse(nuevaEdadStr, out int nuevaEdad))
                {
                    this.Edad = nuevaEdad;
                }
                else
                {
                    Console.WriteLine("Edad no válida. No se realizaron cambios en la edad.");
                }
            }

            Console.WriteLine("Información actualizada.");
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

        public static void EliminarNota(List<Estudiante> ListaStudi)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del estudiante para eliminar una nota:");
            string codigoEstudiante = Console.ReadLine();
            Estudiante estudiante = ListaStudi.FirstOrDefault(x => x.Id.Equals(codigoEstudiante));

            if (estudiante != null)
            {
                Console.WriteLine($"Notas disponibles para el estudiante {estudiante.Id}:");
                Console.WriteLine("1. Quices");
                Console.WriteLine("2. Trabajos");
                Console.WriteLine("3. Parciales");
                int opcionEliminar = Convert.ToInt32(Console.ReadLine());

                List<float> notas = null;
                string tipoNota = "";

                switch (opcionEliminar)
                {
                    case 1:
                        notas = estudiante.Quices;
                        tipoNota = "Quices";
                        break;
                    case 2:
                        notas = estudiante.Trabajos;
                        tipoNota = "Trabajos";
                        break;
                    case 3:
                        notas = estudiante.Parciales;
                        tipoNota = "Parciales";
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (notas != null)
                {
                    Console.WriteLine($"Notas disponibles para el estudiante {estudiante.Id} ({tipoNota}):");

                    for (int i = 0; i < notas.Count; i++)
                    {
                        Console.WriteLine($"Posición {i + 1}: {notas[i]}");
                    }

                    Console.WriteLine($"Ingrese la posición de la {tipoNota.ToLower()} que quiere eliminar:");
                    if (int.TryParse(Console.ReadLine(), out int posicionNota) && posicionNota >= 1 && posicionNota <= notas.Count)
                    {
                        notas.RemoveAt(posicionNota - 1);

                        Console.WriteLine($"La {tipoNota.ToLower()} se ha eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Ingrese una posición válida.");
                    }
                }
                else
                {
                    Console.WriteLine($"El estudiante {estudiante.Id} no tiene notas de {tipoNota}.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró al estudiante con el ID especificado.");
            }
        }
        public void BuscarNotasPorId(List<Estudiante> ListaStudi, string id)
        {
            Estudiante estudiante = ListaStudi.FirstOrDefault(e => e.Id.Equals(id));

            if (estudiante != null)
            {
                Console.WriteLine($"Notas del estudiante {estudiante.Nombre} (ID: {estudiante.Id}):");
                Console.WriteLine("Quices:");
                MostrarNotas("Quices", estudiante.Quices);
                Console.WriteLine("Trabajos:");
                MostrarNotas("Trabajos", estudiante.Trabajos);
                Console.WriteLine("Parciales:");
                MostrarNotas("Parciales", estudiante.Parciales);
            }
            else
            {
                Console.WriteLine($"Estudiante con ID {id} no encontrado.");
            }
        }

        private void MostrarNotas(string tipoNota, List<float> notas)
        {
            if (notas.Count > 0)
            {
                for (int i = 0; i < notas.Count; i++)
                {
                    Console.WriteLine($"Nota {i + 1}: {notas[i]}");
                }
            }
            else
            {
                Console.WriteLine($"El estudiante no tiene {tipoNota.ToLower()} registrados.");
            }
        }

        public void EditarNotas(List<Estudiante> ListaStudi)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del estudiante para editar notas:");
            string codigoEstudiante = Console.ReadLine();


            Estudiante estudiante = ListaStudi.FirstOrDefault(x => x.Id.Equals(codigoEstudiante));

            if (estudiante != null)
            {
                Console.WriteLine($"Notas disponibles para el estudiante {estudiante.Id}:");
                Console.WriteLine("1. Quices");
                Console.WriteLine("2. Trabajos");
                Console.WriteLine("3. Parciales");
                int opcionEditar = Convert.ToInt32(Console.ReadLine());

                List<float> notas = null;
                string tipoNota = "";

                switch (opcionEditar)
                {
                    case 1:
                        notas = estudiante.Quices;
                        tipoNota = "Quices";
                        break;
                    case 2:
                        notas = estudiante.Trabajos;
                        tipoNota = "Trabajos";
                        break;
                    case 3:
                        notas = estudiante.Parciales;
                        tipoNota = "Parciales";
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (notas != null)
                {
                    Console.WriteLine($"Notas disponibles para el estudiante {estudiante.Id} ({tipoNota}):");

                    for (int i = 0; i < notas.Count; i++)
                    {
                        Console.WriteLine($"Posición {i + 1}: {notas[i]}");
                    }

                    Console.WriteLine($"Ingrese la posición de la {tipoNota.ToLower()} que quiere editar:");
                    if (int.TryParse(Console.ReadLine(), out int posicionNota) && posicionNota >= 1 && posicionNota <= notas.Count)
                    {
                        Console.WriteLine($"Ingrese la nueva nota:");
                        if (float.TryParse(Console.ReadLine(), out float nuevaNota))
                        {

                            notas[posicionNota - 1] = nuevaNota;

                            Console.WriteLine($"La {tipoNota.ToLower()} se ha editado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Ingrese una nota válida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Ingrese una posición válida.");
                    }
                }
                else
                {
                    Console.WriteLine($"El estudiante {estudiante.Id} no tiene notas de {tipoNota}.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró al estudiante con el ID especificado.");
            }
        }


public static void MostrarTablaEstudiantes()
{
    string jsonPath = "boletin.json";
    string jsonContent = File.ReadAllText(jsonPath);
    List<Estudiante> estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(jsonContent);

    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("| Código           | Nombre                                     |              Quices             |    Trabajos   |       Parciales        |");
    Console.WriteLine("|                  |                                            |  Q1   |   Q2   |   Q3   |  Q4   |   T1  |   T2  |   P1  |   P2   |   P3  |");
    Console.WriteLine("|----------------- |--------------------------------------------|-------|------- |--------|-------|-------|-------|-------|--------|-------|");

    foreach (var estudiante in estudiantes)
    {
        string id = estudiante.Id.PadRight(18);
        string nombre = estudiante.Nombre.PadRight(41);
        string quices = ObtenerNotas(estudiante.Quices, 4);
        string trabajos = ObtenerNotas(estudiante.Trabajos, 2);
        string parciales = ObtenerNotas(estudiante.Parciales, 3);
        double promedioQuices = estudiante.Quices.Count > 0 ? estudiante.Quices.Average() : 0;
        double promedioTrabajos = estudiante.Trabajos.Count > 0 ? estudiante.Trabajos.Average() : 0;
        double promedioParciales = estudiante.Parciales.Count > 0 ? estudiante.Parciales.Average() : 0;
        double notaFinal = (promedioQuices * 0.25) + (promedioTrabajos * 0.15) + (promedioParciales * 0.6);

        Console.WriteLine($"|{id}|{nombre}   |{quices}|{trabajos}|{parciales}|");
    }

    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
}

        public static string ObtenerNotas(List<float> notas, int cantidad)
        {
            string notasStr = "";

            for (int i = 0; i < cantidad; i++)
            {
                string nota = i < notas.Count ? notas[i].ToString("N2") : "   ";
                notasStr += nota.PadRight(6);

                if (i < cantidad - 1)
                {
                    notasStr += " | ";
                }
            }

            return notasStr;
        }


        static void Main()
        {
            string jsonPath = "boletin.json";
            List<Estudiante> ListaStudi = JsonConvert.DeserializeObject<List<Estudiante>>(File.ReadAllText(jsonPath));

            ListarDefinitivasYNotaFinal(ListaStudi);
        }

        public static void ListarDefinitivasYNotaFinal(List<Estudiante> ListaStudi)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Código        | Nombre                   | Def Quices  | Def Trabajos  | Def Parciales  | Nota Final  |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Estudiante estudiante in ListaStudi)
            {
                double promedioQuices = estudiante.Quices.Count > 0 ? estudiante.Quices.Average() : 0;
                double promedioTrabajos = estudiante.Trabajos.Count > 0 ? estudiante.Trabajos.Average() : 0;
                double promedioParciales = estudiante.Parciales.Count > 0 ? estudiante.Parciales.Average() : 0;
                double notaFinal = (promedioQuices * 0.25) + (promedioTrabajos * 0.15) + (promedioParciales * 0.6);

                Console.WriteLine($"| {estudiante.Id.PadRight(14)}| {estudiante.Nombre.PadRight(25)}| " +
                    $"{promedioQuices.ToString("N2").PadRight(12)}| " +
                    $"{promedioTrabajos.ToString("N2").PadRight(14)}| " +
                    $"{promedioParciales.ToString("N2").PadRight(15)}| " +
                    $"{notaFinal.ToString("N2").PadRight(12)}|");

                Console.WriteLine();
            }
        }

    }
}