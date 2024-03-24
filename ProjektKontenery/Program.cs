
using System.Linq.Expressions;
using ProjektKontenery;

// ContainerBase cb = new LiquidContainer();
//
// ContainerBase cb1 = new LiquidContainer();
// LiquidContainer liquidContainer = new LiquidContainer();
// CoolingContainer coolingContainer = new CoolingContainer("Bananas");
// coolingContainer.Load(1111, "Bananas"); 
// coolingContainer.SetTemperature(15);

// CoolingContainer coolingContainer1 = new CoolingContainer("Bananas");
// Console.WriteLine(coolingContainer1);
// ContainerShip containerShip1 = new ContainerShip();
// Console.WriteLine(coolingContainer1.getNumer());

// containerShip1.LoadContainerToShip(coolingContainer1);
// CoolingContainer coolingContainer2 = new CoolingContainer("Bananas");
// Console.WriteLine(coolingContainer2.getNumer());
// CoolingContainer coolingContainer3 = new CoolingContainer("Bananas");
// List<ContainerBase> lista = new List<ContainerBase>();
// lista.Add(coolingContainer3);
// lista.Add(coolingContainer2);
// lista.Add(coolingContainer1);
// ContainerShip containerShip2 = new ContainerShip();
// containerShip1.LoadListContainersToShip(lista);
// containerShip1.RemoveContainerFromShip(coolingContainer3);
//  GasContainer gasContainer1 = new GasContainer();
//  Console.WriteLine(gasContainer1.getNumer());
// CoolingContainer coolingContainer4 = new CoolingContainer("Bananas");
// lista.Add(coolingContainer4);
// containerShip1.ReplaceContainerWithNew(2,gasContainer1);
// containerShip1.ContainerToAnotherShip(1,containerShip2);
// foreach (ContainerBase cb in lista)
// {
//     Console.WriteLine(cb.getNumer());
// }
ContainerShip containerShip1 = new ContainerShip(15,50,20000);
CoolingContainer coolingContainer = new CoolingContainer("Bananas");
// containerShip1.LoadContainerToShip(coolingContainer);
List<ContainerBase> lista = new List<ContainerBase>();
CoolingContainer coolingContainer1 = new CoolingContainer("Bananas");
CoolingContainer coolingContainer2 = new CoolingContainer("Bananas");
GasContainer gasContainer1 = new GasContainer();
lista.Add(gasContainer1);
lista.Add(coolingContainer2);
lista.Add(coolingContainer1);
containerShip1.LoadListContainersToShip(lista);
containerShip1.info();
gasContainer1.Load(122);
gasContainer1.UnLoad(120);
gasContainer1.info();
LiquidContainer lc = new LiquidContainer(true);
lc.Load(120);
lc.info();