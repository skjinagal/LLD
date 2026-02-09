namespace VendingMachine;
public class VendingMachineDemo
{
    public static void Main(string[] args)
    {
        VendingMachine vendingMachine = VendingMachine.GetInstance();

        // Adding items to the vending machine
        vendingMachine.AddItemToInventory("A1", new Item("Soda", 1.25m, 10), 10);
        vendingMachine.AddItemToInventory("B1", new Item("Chips", 0.75m, 15), 15);
        vendingMachine.AddItemToInventory("C1", new Item("Candy", 0.65m, 20), 20);

        // Simulating user interactions
        vendingMachine.InsertCoin(Coin.Quarter);
        vendingMachine.InsertCoin(Coin.Quarter);
        vendingMachine.InsertCoin(Coin.Dime);
        vendingMachine.InsertCoin(Coin.Nickel);

        vendingMachine.SelectItem("A1");
        vendingMachine.DispenseItem();

        vendingMachine.ReturnCoins();
    }
}