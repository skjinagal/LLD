namespace VendingMachine;
public class HasMoneyState: VendingMachineState
{
    public HasMoneyState(VendingMachine vendingMachine) : base(vendingMachine)
    {
    }

    public override void InsertCoin(Coin coin)
    {
        vendingMachine.AddToBalance((int)coin);
        Console.WriteLine($"Inserted {coin}. Current balance: {vendingMachine.GetCurrentBalance()} cents.");
    }

    public override void SelectItem(string itemCode)
    {
        if (vendingMachine.GetInventory().Items.ContainsKey(itemCode))
        {
            Item selectedItem = vendingMachine.GetInventory().Items[itemCode];
            if (selectedItem.Quantity <= 0)
            {
                Console.WriteLine("Selected item is out of stock. Please select another item.");
                return;
            }

            if (vendingMachine.GetCurrentBalance() >= (int)(selectedItem.Price * 100))
            {
                vendingMachine.SelectItem(selectedItem.Name);
                vendingMachine.SetState(vendingMachine.dispensingState);
                vendingMachine.DispenseItem();
            }
            else
            {
                Console.WriteLine($"Insufficient balance. Please insert more coins to purchase {selectedItem.Name}.");
            }
        }
        else
        {
            Console.WriteLine("Invalid item code. Please select a valid item.");
        }
    }

    public override void DispenseItem()
    {
        Console.WriteLine("Please select an item before dispensing.");
    }

    public override void ReturnCoins()
    {
        Console.WriteLine($"Returning {vendingMachine.GetCurrentBalance()} cents.");
        vendingMachine.ResetCurrentBalance();
        vendingMachine.SetState(vendingMachine.idleState);
    }
}