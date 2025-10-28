using System;
using System.Linq;

namespace Laboratorio91
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE PAGO ===\n");

            double precio;
            do
            {
                Console.Write("Ingrese el precio del producto: $");
                precio = double.Parse(Console.ReadLine());

                if (precio <= 0)
                    Console.WriteLine("Error. El precio debe ser positivo.\n");

            } while (precio <= 0);

            Console.Write("Forma de pago (efectivo/tarjeta): ");
            string formaPago = Console.ReadLine().ToLower();

            if (formaPago == "tarjeta")
            {
                string numTarjeta;
                bool tarjetaValida;

                do
                {
                    Console.Write("Ingrese el número de tarjeta (16 dígitos): ");
                    numTarjeta = Console.ReadLine();

                    tarjetaValida = numTarjeta.Length == 16 && numTarjeta.All(char.IsDigit);

                    if (!tarjetaValida)
                        Console.WriteLine("Error. El número debe tener exactamente 16 dígitos.\n");

                } while (!tarjetaValida);

                Console.WriteLine($"\n✓ Pago procesado con tarjeta ****{numTarjeta.Substring(12)}");
                Console.WriteLine($"  Monto: ${precio:F2}");
            }
            else if (formaPago == "efectivo")
            {
                Console.WriteLine($"\n✓ Pago en efectivo");
                Console.WriteLine($"  Monto: ${precio:F2}");
            }
            else
            {
                Console.WriteLine("Forma de pago no reconocida.");
            }

            Console.ReadKey();
        }
    }
}