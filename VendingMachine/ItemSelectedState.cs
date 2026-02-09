namespace VendingMachine;
public class ItemSelectedState : VendingMachineState
{
    public ItemSelectedState(VendingMachine vendingMachine) : base(vendingMachine)
    {
    }

    public override void InsertCoin(Coin coin)
    {
        vendingMachine.AddToBalance((int)coin);
        Console.WriteLine($"Inserted {coin}. Current balance: {vendingMachine.GetCurrentBalance()} cents.");
    }

    public override void SelectItem(string itemCode)
    {
        Console.WriteLine("Item already selected. Please dispense the item or return coins.");
    }

    public override void DispenseItem()
    {
        var selectedItem = vendingMachine.GetSelectedItem();
        if (selectedItem == null)
        {
            Console.WriteLine("No item selected.");
            return;
        }

        if (vendingMachine.GetCurrentBalance() >= (int)(selectedItem.Price * 100))
        {
            if (vendingMachine.ReduceItemStock(selectedItem.Name))
            {
                vendingMachine.DeductBalance((int)(selectedItem.Price * 100));
                Console.WriteLine($"Dispensed {selectedItem.Name}. Remaining balance: {vendingMachine.GetCurrentBalance()} cents.");
                vendingMachine.SetState(new IdleState(vendingMachine));
            }
            else
            {
                Console.WriteLine($"{selectedItem.Name} is out of stock. Returning coins.");
                vendingMachine.ReturnCoins();
                vendingMachine.SetState(new IdleState(vendingMachine));
            }
        }
        else
        {
            Console.WriteLine($"Insufficient balance. Please insert more coins to purchase {selectedItem.Name}.");
        }
    }

    public override void ReturnCoins()
    {
        Console.WriteLine($"Returning {vendingMachine.GetCurrentBalance()} cents.");
        vendingMachine.ResetCurrentBalance();
        vendingMachine.SetState(new IdleState(vendingMachine));
    }
}