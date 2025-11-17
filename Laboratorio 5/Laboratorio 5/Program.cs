
using System;

class Program
{
    private int[] sueldos; // Arreglo de sueldos

    public void Cargar()
    {
        sueldos = new int[6]; // inicializamos el valor en 5
        for (int f = 1; f <= 5; f++)
        {
            Console.Write("Ingrese sueldo del operario " + f + ": ");
            string linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea); // Asignamos los 5 sueldos al vector 
        }
    }

    // muestra los sueldos de los operarios en el vector sueldos[f]
    public void Imprimir()
    {
        Console.WriteLine("Los 5 sueldos de los operarios: ");
        for (int f = 1; f <= 5; f++)
        {
            Console.WriteLine("[" + sueldos[f] + "]");
        }
        Console.ReadKey();
    }

    // Main principal
    static void Main(string[] args)
    {
        Program pv = new Program();
        pv.Cargar();
        pv.Imprimir();
    }
}