namespace VendingMachine;
public abstract class VendingMachineState
{
    protected VendingMachine vendingMachine;

    public VendingMachineState(VendingMachine vendingMachine)
    {
        this.vendingMachine = vendingMachine;
    }

    public abstract void InsertCoin(Coin coin);
    public abstract void SelectItem(string itemCode);
    public abstract void DispenseItem();
    public abstract void ReturnCoins();
}