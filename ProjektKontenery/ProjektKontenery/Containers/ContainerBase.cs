

namespace ProjektKontenery;

public abstract class ContainerBase
{
    protected double LoadMass { get; }
    protected double Hight { get; }
    protected double OwnWeight { get; }
    protected double Depth { get;  }
    protected static int LiczbaNumeruSeryjnego;
    
    protected double MaxLoad { get; set; }

    protected ContainerBase(double loadMass, double hight, double ownWeight, double depth)
    {
        this.LoadMass = loadMass;
        this.Hight = hight;
        this.OwnWeight = ownWeight;
        this.Depth = depth;
        this.MaxLoad = MaxLoad;
        
    }

    public void Load()
    {

    }
    
}