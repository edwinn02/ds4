using System;

namespace Laboratorio92
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== NÚMEROS DEL 1 AL 100 ===");
            Console.WriteLine("(Pares o divisibles entre 3)\n");

            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0 || i % 3 == 0)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}