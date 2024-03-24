using System.Transactions;

namespace ProjektKontenery;

public class GasContainer : ContainerBase, IHazardNotifier
{
    
    protected double pressure;
    private string numer;
    public GasContainer()
    {
        this.pressure = 0;
        this.numer = GenerateNumber();
    }

    public override void Load(double newMass)
    {
        if (newMass+LoadedMass < MaxLoad)
        {
            LoadedMass = newMass + LoadedMass;
            pressure = LoadedMass / MaxLoad;
            Console.WriteLine("Zaladowano nowy towar, mamy teraz" + LoadedMass);

        }
        else
        {
            Notify();
            throw new OverfillException();
        }
    }

    public override void UnLoad(double minusMass)
    {
        double newMass = LoadedMass - minusMass;
        if (newMass >= MaxLoad * 0.05)
        {
            LoadedMass = newMass;
            Console.WriteLine("Rozladowano towar, mamy teraz:" + LoadedMass);
        }
        else
        {
            Console.WriteLine("Odejmij mniej towaru musi zostac 5%");
        }
    }

    public override string GenerateNumber()
    {
        return $"KON-G-{ idKonteneraIlosc }";
        
    }

    public override string getNumer()
    {
        return numer;
    }

    public void Notify()
    {
        Console.WriteLine("Niebezpieczna sytuacja, kontener nr " + numer);
    }

    public void info()
    {
        Console.WriteLine(numer + " | Cisnienie: "+ pressure + " | " + toString());

    }
}