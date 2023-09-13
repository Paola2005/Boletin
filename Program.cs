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
    Console.WriteLine("1. Registro de estudiantes");
    Console.WriteLine("2. Ingresar notas");
    Console.WriteLine("3. Reportes e informes");
    Console.WriteLine("4. Eliminar estudiantes");
    Console.WriteLine("5. Eliminar notas");
    Console.WriteLine("6. Salir");
    byte opcion = Convert.ToByte(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            student.AñadirEstudiante(ListaStudi);
            MisFunciones.GuardarDatos(ListaStudi);
            Console.ReadKey();
            break;

        case 2:
            bool MenuN = true;
            while (MenuN)
            {
                Console.Clear();
                byte OpcN = MisFunciones.MenuNotas();
                //si OpcN no es igual a cero o si OpcN es mayor que 3, entonces la condición es verdadera
                if (OpcN != 0 || OpcN > 3)
                {
                    Console.Clear();
                    student.AñadirNotas(ListaStudi, OpcN);
                    MisFunciones.GuardarDatos(ListaStudi);
                }
                else
                {
                    MenuN = false;
                }
            }
            break;

        case 3:
            bool MenuR = true;
            while (MenuR)
            {
                Console.Clear();
                byte OpcR = MisFunciones.Reportes();
                switch (OpcR)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
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
            student.EliminarItem(ListaStudi);
            Console.ReadKey();
            break;

        case 5:
            bool MenuEN = true;
            while (MenuEN)
            {
                Console.Clear();
                byte OpcN = MisFunciones.MenuNotas();
                //si OpcN no es igual a cero o si OpcN es mayor que 3, entonces la condición es verdadera
                if (OpcN != 0 || OpcN > 3)
                {
                    Console.Clear();
                    student.EliminarNota(ListaStudi, OpcN);
                    MisFunciones.GuardarDatos(ListaStudi);
                }
                else
                {
                    MenuEN = false;
                }
            }
            break;

        case 6:
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
