internal class Calculo
{
    public int Variables(int n1, int n2)
    {
        int resultado = (n1 + n2) * (n1 + n2);
        return resultado;
    }
}


    internal class Program
    {
        private static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("introdusca el primer numero");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("introdusca el segundo numero");
            b = Convert.ToInt32(Console.ReadLine());
            Calculo calculo = new();
          int  operacion = calculo.Variables(a, b);
            Console.WriteLine(operacion);

        }
    }
