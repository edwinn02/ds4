using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Suma(1.0, 2.2));   // Llama al método con double
        Console.WriteLine(Suma(1, 2));       // Llama al método con int
        Console.WriteLine(Suma(100L, 200L)); // Llama al método con long
    }

    static int Suma(int x, int y)
    {
        return x + y;
    }

    static double Suma(double x, double y)
    {
        return x + y;
    }

    static long Suma(long x, long y)
    {
        return x + y;
    }
}
