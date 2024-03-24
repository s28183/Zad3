using System.Transactions;

namespace ProjektKontenery;

public class OverfillException : Exception
{
    public OverfillException()
    {
    Console.WriteLine("Masa podanego ladunku jest wieksza niz ładowność kontenera");    
    }
}