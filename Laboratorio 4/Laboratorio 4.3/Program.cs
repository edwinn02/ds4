internal class Program
{
    private static void Main(string[] args)
    {
        int suma, cant, valor, promedio;
        string linea;
        suma = 0;   
        cant = 0;
        do
        {
            Console.WriteLine("Ingrese un numero(0 para finalizar):");
            linea = Console.ReadLine();
            valor = int.Parse(linea);
            if (valor != 0) { 
            suma = suma + valor;
                cant++;
            }
        }while(valor != 0);
        if (cant != 0)
        {
            promedio = suma / cant;
            Console.WriteLine("el promedio ingresado es");
            Console.WriteLine(promedio);
        }
        else { 
        Console.WriteLine("no se ingresaron valores");
                }
    }
}