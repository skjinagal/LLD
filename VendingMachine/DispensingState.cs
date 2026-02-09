namespace VendingMachine;
public class DispensingState : VendingMachineState
{
    public DispensingState(VendingMachine vendingMachine) : base(vendingMachine)
    {
    }

    public override void InsertCoin(Coin coin)
    {
        Console.WriteLine("Please wait, dispensing your item.");
    }

    public override void SelectItem(string itemCode)
    {
        Console.WriteLine("Please wait, dispensing your item.");
    }

    public override void DispenseItem()
    {
        var selectedItem = vendingMachine.GetSelectedItem();
        if (selectedItem != null)
        {
            if (vendingMachine.ReduceItemStock(selectedItem.Name))
            {
                Console.WriteLine($"Dispensing {selectedItem.Name}");
                vendingMachine.DeductBalance(selectedItem.Price);
                vendingMachine.SetState(vendingMachine.idleState);
            }
            else
            {
                Console.WriteLine("Item out of stock. Returning to Idle State.");
                vendingMachine.SetState(vendingMachine.idleState);
            }
        }
        else
        {
            Console.WriteLine("No item selected. Returning to Idle State.");
            vendingMachine.SetState(vendingMachine.idleState);
        }
    }

    public override void ReturnCoins()
    {
        Console.WriteLine("Cannot return coins while dispensing. Please wait.");
    }
}