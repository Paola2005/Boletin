﻿using System.Runtime.Intrinsics.Arm;
using Boletin;
using Boletin.Entities;


List<Estudiante> ListaStudi = new List<Estudiante>();
Estudiante student = new Estudiante();
bool bandera = true;
ListaStudi = MisFunciones.LoadData();

while (bandera)
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("|||Menu Principal|||");
    Console.WriteLine("1. Estudiantes");
    Console.WriteLine("2. Notas");
    Console.WriteLine("3. Reportes e informes");
    Console.WriteLine("4. Salir");
    byte opcion = Convert.ToByte(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            bool MenuEst = true;
            while (MenuEst)
            {
                Console.Clear();
                byte OpcEs = MisFunciones.MenuEstudiantes();
                switch (OpcEs)
                {
                    case 1:
                        student.AñadirEstudiante(ListaStudi);
                        MisFunciones.GuardarDatos(ListaStudi);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Buscar estudiante por ID:");
                        Console.WriteLine("Ingrese el ID del estudiante a buscar:");
                        string idEstudianteBuscar = Console.ReadLine();

                        Estudiante estudianteEncontrado = Estudiante.BuscarEstudiantePorId(ListaStudi, idEstudianteBuscar);

                        if (estudianteEncontrado != null)
                        {
                            Console.WriteLine("Estudiante encontrado:");
                            Console.WriteLine($"ID: {estudianteEncontrado.Id}");
                            Console.WriteLine($"Nombre: {estudianteEncontrado.Nombre}");
                            Console.WriteLine($"Dirección: {estudianteEncontrado.Direccion}");
                            Console.WriteLine($"Edad: {estudianteEncontrado.Edad}");
                            Console.WriteLine("Notas:");
                            Console.WriteLine("Quices:");
                            foreach (var nota in estudianteEncontrado.Quices)
                            {
                                Console.WriteLine($"- {nota}");
                            }

                            Console.WriteLine("Trabajos:");
                            foreach (var nota in estudianteEncontrado.Trabajos)
                            {
                                Console.WriteLine($"- {nota}");
                            }

                            Console.WriteLine("Parciales:");
                            foreach (var nota in estudianteEncontrado.Parciales)
                            {
                                Console.WriteLine($"- {nota}");
                            }

                            Console.WriteLine("Presione Enter para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Estudiante no encontrado.");
                        }

                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ingrese el ID del estudiante a editar:");
                        string idEstudianteEditar = Console.ReadLine();
                        Estudiante estudianteEditar = Estudiante.BuscarEstudiantePorId(ListaStudi, idEstudianteEditar);

                        if (estudianteEditar != null)
                        {
                            Console.WriteLine("Información actual del estudiante:");
                            Console.WriteLine($"ID: {estudianteEditar.Id}");
                            Console.WriteLine($"Nombre: {estudianteEditar.Nombre}");
                            Console.WriteLine($"Dirección: {estudianteEditar.Direccion}");
                            Console.WriteLine($"Edad: {estudianteEditar.Edad}");

                            Console.WriteLine("¿Desea editar la información? (S/N)");
                            string respuesta = Console.ReadLine();
                            if (respuesta.Equals("S", StringComparison.OrdinalIgnoreCase))
                            {
                                estudianteEditar.EditarEstudiante();
                                MisFunciones.GuardarDatos(ListaStudi);
                                Console.WriteLine("Estudiante editado correctamente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Estudiante no encontrado.");
                        }
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        student.EliminarItem(ListaStudi);
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        MenuEst = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida");
                        Console.WriteLine("Seleecione una opcion valida");
                        Console.ReadKey();
                        break;
                }
            }
            break;

        case 2:
            bool MenuPrinN = true;
            while (MenuPrinN)
            {
                Console.Clear();
                byte OpcNPrin = MisFunciones.MenuNotasPrin();
                switch (OpcNPrin)
                {
                    case 1:
                        bool MenuN = true;
                        while (MenuN)
                        {
                            Console.Clear();
                            byte OpcN = MisFunciones.MenuNotasA();
                            if (OpcN != 0 || OpcN > 3)
                            {
                                Console.Clear();
                                student.AñadirNotas(ListaStudi, OpcN);
                                MisFunciones.GuardarDatos(ListaStudi);
                            }
                            if (OpcN == 4)
                            {
                                Console.Clear();
                                MenuN = false;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Buscar notas de un estudiante por ID");
                        Console.Write("Ingrese el ID del estudiante: ");
                        string idEstudiante = Console.ReadLine();
                        student.BuscarNotasPorId(ListaStudi, idEstudiante);
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();

                        student.EditarNotas(ListaStudi);
                        MisFunciones.GuardarDatos(ListaStudi);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Estudiante.EliminarNota(ListaStudi);
                        MisFunciones.GuardarDatos(ListaStudi);
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        MenuPrinN = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida");
                        Console.WriteLine("Seleecione una opcion valida");
                        Console.ReadKey();
                        break;
                }
            }
            break;


        case 3:
            bool MenuR = true;
            Console.Clear();
            while (MenuR)
            {
                byte OpcR = MisFunciones.Reportes();
                switch (OpcR)
                {
                    case 1:
                        Console.Clear();
                        Estudiante.MostrarTablaEstudiantes();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("####-Listado de definitivas y nota final-####");
                        Console.ForegroundColor = ConsoleColor.White;
                        Boletin.Entities.Estudiante.ListarDefinitivasYNotaFinal(ListaStudi);
                        break;
                    case 3:
                        Console.Clear();
                        MenuR = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida");
                        Console.WriteLine("Seleecione una opcion valida");
                        Console.ReadKey();
                        break;
                }
            }
            break;

        case 4:
            Console.Clear();
            bandera = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opcion invalida");
            Console.WriteLine("Seleecione una opcion valida");
            Console.ReadKey();
            break;
    }

}
