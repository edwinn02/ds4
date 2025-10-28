using System;

namespace Laboratorio94
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CLASE ALEATORIOS ===\n");

            Aleatorios generador = new Aleatorios();

            Console.Write("Ingrese el número mínimo: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el número máximo: ");
            int max = int.Parse(Console.ReadLine());

            int numeroAleatorio = generador.GenerarNumero(min, max);
            Console.WriteLine($"\nNúmero aleatorio generado: {numeroAleatorio}");

            Console.Write("\n¿Cuántos números desea generar en el arreglo?: ");
            int cantidad = int.Parse(Console.ReadLine());

            int[] arreglo = generador.GenerarArreglo(min, max, cantidad);
            Console.WriteLine("\nArreglo generado:");
            Console.WriteLine(string.Join(", ", arreglo));

            Console.ReadKey();
        }
    }
}