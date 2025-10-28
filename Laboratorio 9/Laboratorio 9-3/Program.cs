using System;

namespace Laboratorio93
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CLASIFICADOR DE TRIÁNGULOS ===\n");

            Console.Write("Ingrese el lado 1: ");
            double lado1 = double.Parse(Console.ReadLine());

            Console.Write("Ingrese el lado 2: ");
            double lado2 = double.Parse(Console.ReadLine());

            Console.Write("Ingrese el lado 3: ");
            double lado3 = double.Parse(Console.ReadLine());

            if (lado1 + lado2 > lado3 && lado1 + lado3 > lado2 && lado2 + lado3 > lado1)
            {
                Console.WriteLine("\n✓ Los lados SÍ forman un triángulo");

                if (lado1 == lado2 && lado2 == lado3)
                {
                    Console.WriteLine("Tipo: EQUILÁTERO (todos los lados iguales)");
                }
                else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
                {
                    Console.WriteLine("Tipo: ISÓSCELES (dos lados iguales)");
                }
                else
                {
                    Console.WriteLine("Tipo: ESCALENO (todos los lados diferentes)");
                }
            }
            else
            {
                Console.WriteLine("\n✗ Los lados NO forman un triángulo válido");
                Console.WriteLine("(La suma de dos lados debe ser mayor al tercer lado)");
            }

            Console.ReadKey();
        }
    }
}
