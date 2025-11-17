Dictionary<string, string> paisesYCapitales = new Dictionary<string, string>
{
   { "Chile", "Santiago" },
    { "Argentina", "Buenos Aires" },
    { "Peru", "Lima" }
};

foreach (KeyValuePair<string, string> par in paisesYCapitales)
{
    Console.WriteLine("La capital de " + par.Key + " es " + par.Value + ".");
}