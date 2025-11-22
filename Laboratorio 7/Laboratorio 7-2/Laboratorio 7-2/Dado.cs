using System;

class Dado
{
    private int valor;
    private static Random aleatorio = new Random();

    public Dado()
    {
        // No es necesario crear un nuevo Random aquí si ya es static
    }

    public void Tirar()
    {
        valor = aleatorio.Next(1, 7);   // Número entre 1 y 6
    }

    public void Imprimir()
    {
        Console.WriteLine("El valor del dado es: " + valor);
    }

    public int RetornarValor()
    {
        return valor;
    }
}