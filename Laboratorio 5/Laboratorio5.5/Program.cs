using System;
using System.Collections.Generic;

class Estudiante
{
    public string Nombre { get; set; } = "";
    public int Edad { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante>
        {
            new Estudiante { Nombre = "Juan", Edad = 18 },
            new Estudiante { Nombre = "Maria", Edad = 20 },
            new Estudiante { Nombre = "Pedro", Edad = 19 }
        };

        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine("Nombre: " + estudiante.Nombre + " Edad: " + estudiante.Edad);
        }
    }
}