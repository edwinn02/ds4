// Seeusing System;

public class Empleado
{
    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
}

// Propiedades con validación
public class CuentaBancaria
{
    private decimal saldo;

    public decimal Saldo
    {
        get { return saldo; }
        set
        {
            if (value >= 0)   // validación
                saldo = value;
            else
                throw new ArgumentException("El saldo no puede ser negativo.");
        }
    }
}

// Propiedades de solo lectura
public class Cobertura
{
    private double radio;

    public Cobertura(double radio)
    {
        this.radio = radio;
    }

    public double Radio
    {
        get { return radio; }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // Clase Empleado
        Empleado empleado = new Empleado();
        empleado.Nombre = "John Doe";
        Console.WriteLine($"Nombre del empleado: {empleado.Nombre}");

        // Clase CuentaBancaria
        CuentaBancaria cta = new CuentaBancaria();
        cta.Saldo = 100;
        Console.WriteLine($"El saldo del empleado: {cta.Saldo}");

        // Descomenta esta línea para probar la excepción
        // cta.Saldo = -50; 

        // Clase Cobertura
        Cobertura c = new Cobertura(5);
        Console.WriteLine($"Con una cobertura de radio: {c.Radio}");
    }
}
