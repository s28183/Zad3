namespace ProjektKontenery;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    protected Boolean isDangerous = false;
    private string numer;
    public LiquidContainer(Boolean isDangerous)
    {
        this.isDangerous = isDangerous;
        this.OwnWeight = 4000;
        this.numer = GenerateNumber();
    }

    public override void Load(double newMass)
    {
        if (isDangerous == false)
        {
            if (newMass+LoadedMass < MaxLoad*0.9)
            {
                LoadedMass = newMass + LoadedMass;
                Console.WriteLine("Zaladowano nowy towar, mamy teraz" + LoadedMass);
            }
            else
            {
                Notify();
                throw new OverfillException();

            }
        
        }
        else
        {
            if (newMass + LoadedMass < MaxLoad * 0.5)
            {
                LoadedMass = newMass + LoadedMass;
                Console.WriteLine("Zaladowano nowy towar, mamy teraz" + LoadedMass);
            }
            else
            {
                Notify();
                throw new OverfillException();
            }
        }
    }

    public override void UnLoad(double minusMass)
    {
        if (minusMass > LoadedMass)
        {
            Console.WriteLine("Nie ma tyle towqaru ile chcesz odjac");
        }
        else
        {
            LoadedMass =  LoadedMass - minusMass;
            Console.WriteLine("Rozladowano towar, mamy teraz:" + LoadedMass);
        }
    }
    

    public override string GenerateNumber()
    {
        return $"KON-L-{ idKonteneraIlosc }";
    }
    public void Notify()
    {
        Console.WriteLine("Niebezpieczna sytuacja, kontener nr " + numer);
    }
    public override string getNumer()
    {
        return numer;
    }
    public void info()
    {
        Console.WriteLine(numer + " | CzyNiebezpieczny: "+ isDangerous + " | " + toString());

    }

}   