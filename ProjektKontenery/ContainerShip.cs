namespace ProjektKontenery;

public class ContainerShip
{
    private List<ContainerBase> containersList = new List<ContainerBase>();
    private double maxKnots = 20;
    private int maxShipContainers = 50;
    private double maxContainersWeight = 20000;
    private double currentLoadWeight = 0;
    private static int idShip = -1;

    public ContainerShip(double maxKnots, int maxShipContainers, double maxContainersWeight)
    {
        this.maxKnots = maxKnots;
        this.maxShipContainers = maxShipContainers;
        this.maxContainersWeight = maxContainersWeight;
        idShip++;
    }

    
    public void LoadContainerToShip(ContainerBase container)
    {
        if (containersList.Count >= maxShipContainers)
        {
            throw new InvalidOperationException("Maksymalana liczba kontenerow na statku");
        }
        container.getOwnWeight();
        
        if (currentLoadWeight + container.getOwnWeight() > maxContainersWeight)
        {
            throw new InvalidOperationException("Przekracza maksymalna ilosc wagi");
        }
        containersList.Add(container);
        currentLoadWeight = currentLoadWeight + container.getOwnWeight();;

    }

    public ContainerBase FindContainerById(int containerId)
    {
        return containersList.FirstOrDefault(container  => container.GetIdContainer() == containerId);
    }
    
    public void LoadListContainersToShip(List<ContainerBase> containers)
    {
        foreach (ContainerBase container in containers)
        {
            try
            {
                LoadContainerToShip(container);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Nie udalo sie zaladowac kontenera");
            }
        }
    }
    public void RemoveContainerFromShip(ContainerBase containerRemove)
    {
        if (containersList.Contains(containerRemove))
        {
            containersList.Remove(containerRemove);
            currentLoadWeight = currentLoadWeight - containerRemove.GetLoadedMass();
            Console.WriteLine("Usunieto kontener");
        }
        else
        {
            Console.WriteLine("Taki kontener nie znajduje sie na statku");
        }
    }
    
    
    public void ReplaceContainerWithNew(int containerReplace, ContainerBase newContainer)
    {
        ContainerBase containerToReplace = FindContainerById(containerReplace);
        if (containerToReplace == null)
        {
            throw new ArgumentException("Nie znaleziono kontenera o podanym id");
        }
        containersList.Remove(containerToReplace);
        currentLoadWeight = currentLoadWeight - containerToReplace.GetLoadedMass();
        LoadContainerToShip(newContainer);
        Console.WriteLine("Zastapiono kontener o ID "+containerReplace+" nowym kontenerem o id "+newContainer.GetIdContainer());
    }
    
    
    public void ContainerToAnotherShip(int containerId, ContainerShip different)
    {
        ContainerBase containerToTransfer = FindContainerById(containerId);
        if (containerToTransfer == null)
        {
            throw new ArgumentException("Nie znaleziono kontenera o podanym id");
        }
        RemoveContainerFromShip(containerToTransfer);
        different.LoadContainerToShip(containerToTransfer);
        Console.WriteLine("Przeniesiono kontener na inny statek");
    }

    public void info()
    {
        Console.WriteLine("Statek informacje:");
        Console.WriteLine("Statek id: " + idShip +" | Maksymalna ilosc kontenerow: " + maxShipContainers + " | Max waga kontenerow: " + maxContainersWeight);
        Console.WriteLine("Calkowita waga wszystkich kontenerow: " + currentLoadWeight);
        Console.WriteLine("Liczba kontenerow: " + containersList.Count);
        Console.WriteLine("Kontnery załadowane na statek:");

        if (containersList.Any())
        {
            foreach (ContainerBase container in containersList)
            {
                Console.WriteLine("Zaladowany kontner o numerze: " + container.getNumer() +" typu "+ container.GetType().Name);
            }
        }
        else
        {
            Console.WriteLine("Brak kontenerow na statku");
        }
    }
}