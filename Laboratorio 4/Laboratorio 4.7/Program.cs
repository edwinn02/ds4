class Program
{
    static void Main(string[] args)
    {
        int numerouno = 70;
        double numerodos = 67.89;
        double numerotres = 67.89;

        Console.WriteLine(Suma(numerouno, numerodos));

        Console.WriteLine(Suma(numerouno, numerodos, numerotres));
    }
    static double Suma(int x, double y, double z = 0)
    {
        return x + y + z;
    }
}