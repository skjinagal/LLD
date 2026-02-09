namespace VendingMachine;
public class IdleState : VendingMachineState
{
    public IdleState(VendingMachine vendingMachine) : base(vendingMachine)
    {
    }

    public override void InsertCoin(Coin coin)
    {
        vendingMachine.AddToBalance((int)coin);
        vendingMachine.SetState(vendingMachine.hasMoneyState);
    }

    public override void SelectItem(string itemCode)
    {
        Console.WriteLine("Please insert coins before selecting an item.");
    }

    public override void DispenseItem()
    {
        Console.WriteLine("No item selected. Please insert coins and select an item.");
    }

    public override void ReturnCoins()
    {
        Console.WriteLine("No coins to return.");
    }
}