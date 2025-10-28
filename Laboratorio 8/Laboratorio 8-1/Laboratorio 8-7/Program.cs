using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicacion");

        ClaseBase obj = new ClaseBase();
        obj.test();
        obj.moreTesting();
    }
}

// Clase sellada (no puede heredarse)
sealed class ClaseBase
{
    public void test()
    {
        Console.WriteLine("Ejecutando test()");
    }

    public void moreTesting()
    {
        Console.WriteLine("Ejecutando moreTesting()");
    }
}

// ❌ Esto daría error, porque ClaseBase es sealed
// class ClaseHijo : ClaseBase { }
