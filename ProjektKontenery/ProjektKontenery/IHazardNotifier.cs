namespace ProjektKontenery;

public interface IHazardNotifier
{
    public void Notify()
    {
        Console.WriteLine("Niebezpieczna sytuacja");
    }
}