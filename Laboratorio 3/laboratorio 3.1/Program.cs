internal class Program
{
    private static void Main(string[] args)
    {
        int radio;
        double resultado;
        Console.Write("Ingresa el primero numero: ");
        radio = Convert.ToInt32(Console.ReadLine());
        const double pi = 3.14;

        resultado = pi * (radio * radio);

        Console.WriteLine(resultado);
    }
}