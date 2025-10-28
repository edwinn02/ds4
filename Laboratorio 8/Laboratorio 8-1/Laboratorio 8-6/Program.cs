using System;

class ClaseBase
{
    public virtual void masTests()
    {
        Console.WriteLine("Método en ClaseBase");
    }
}

class ClaseHijo : ClaseBase
{
    public sealed override void masTests()
    {
        Console.WriteLine("Método sobrescrito en ClaseHijo (sellado, no más overrides)");
    }
}

// Si intentas hacer esto, dará error:
// class ClaseNieto : ClaseHijo
// {
//     public override void masTests() { } // ❌ ERROR: método está sealed
// }

internal class Program
{
    private static void Main(string[] args)
    {
        ClaseBase obj1 = new ClaseBase();
        obj1.masTests();

        ClaseHijo obj2 = new ClaseHijo();
        obj2.masTests();

        Console.WriteLine("Corrio la aplicacion");
    }
}
