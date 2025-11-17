internal class Program
{
    private static void Main(string[] args)
    {
        int fac = 1, n;
        string linea;
        Console.WriteLine("ingrese numero entero");
        linea = Console.ReadLine();
        n = int.Parse(linea);
        for (int i = 1; i < n; i++) {
            fac = fac * i;

        }
        Console.WriteLine("la factorial es:" + fac);
        Console.ReadKey();
    }
}