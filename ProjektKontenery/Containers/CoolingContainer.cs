namespace ProjektKontenery;

public class CoolingContainer : ContainerBase, IHazardNotifier
{
    private string numer;
    private string product;
    private double temperature;
    private Boolean isLoaded;
    private Dictionary<string, double> productsTemperature;
    public CoolingContainer(string product)
    {
        this.temperature = 0;
        this.numer = GenerateNumber();
        this.productsTemperature = new Dictionary<string, double>
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };
        if (!productsTemperature.ContainsKey(product))
        {
            throw new ArgumentException("Ten Produkt nie jest obslugiwany");
        }
        this.product = product;
        SetTemperature(productsTemperature[product]);
    }

 
    public void SetTemperature(double newTemperature)
    {
        if (newTemperature < productsTemperature[product])
        {
            Notify();
            throw new Exception("Temperatura " +newTemperature + "C jest za niska dla tego produktu:" + product);
        }
        else
        {
            temperature = newTemperature;
            Console.WriteLine("Ustawiono nową temeprature: " + newTemperature);
        }
    }
     
    public void Load(double newMass, string newProduct)
    {
        if (newMass + LoadedMass > MaxLoad)
        {
            Notify();
            throw new OverfillException();
        }

        if (isLoaded && product != newProduct)
        {
            Notify();
            throw new Exception("Kontener jest już załadowany produktem " + product);
        }
        else
        {
            product = newProduct;
            LoadedMass = newMass + LoadedMass;
            isLoaded = true;
            Console.WriteLine("Zaladowano nowy towar, mamy teraz" + LoadedMass);
        }
    }

    public override void Load(double newNass)
    {
        Console.WriteLine("Jest to klasa do ktorej musisz włożyc jakis produkt, wybierz metode z dwoma arugmentami ");
    }

    public override void UnLoad(double minusMass)
    {
        if (minusMass > LoadedMass)
        {
            Notify();
            throw new Exception("nie m,a tyle ladunku ile chcesz rozladowac");
        }
        LoadedMass = LoadedMass - minusMass;
        Console.WriteLine("Rozladowano towar, mamy teraz" + LoadedMass);
    }

    public override string GenerateNumber()
    {
        return $"KON-C-{ idKonteneraIlosc }";
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
        Console.WriteLine(numer + " | Produkt: "+ product + " | Temperatura: "+ temperature + " | " + toString());

    }

}