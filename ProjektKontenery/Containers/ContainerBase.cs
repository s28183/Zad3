

namespace ProjektKontenery;

public abstract class ContainerBase
{
    protected double LoadedMass { get; set; }
    protected double Hight { get; }
    protected double OwnWeight { get; set; }
    protected double Depth { get;  }
    public static int idKonteneraIlosc = 0;
    public int idKontenera;
    protected static int LiczbaNumeruSeryjnego;
    
    protected double MaxLoad { get; set; }

    protected ContainerBase()
    {
        this.LoadedMass = 0;
        this.OwnWeight = 3000;
        this.Hight = 2500;
        this.Depth = 5000;
        this.MaxLoad = 10000;
        this.idKontenera = ++idKonteneraIlosc;
    }

    public abstract void Load(double newMass);

    public abstract void UnLoad(double minusMass);

    public abstract string GenerateNumber();

    public double GetLoadedMass()
    {
        return LoadedMass;
    }

    public double getOwnWeight()
    {
        return OwnWeight;
    }
    public int GetIdContainer()
    {
        return idKontenera;
    }

    public abstract string getNumer();

    public string toString()
    {
        return "Ilosc zaladunku: " + LoadedMass + "| Masa wlasna: " + OwnWeight + " |";
        
    }
}