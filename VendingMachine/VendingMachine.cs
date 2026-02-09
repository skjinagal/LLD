namespace VendingMachine;
public class VendingMachine
{
    public static VendingMachine Instance  { get; } = new VendingMachine();
    private VendingMachineState currentState;
    private Inventory inventory;
    private decimal currentBalance;
    private string selectedItemCode;
    public VendingMachineState idleState;
    public VendingMachineState hasMoneyState;
    public VendingMachineState itemSelectedState;
    public VendingMachineState dispensingState;


    private VendingMachine()
    {
        inventory = new Inventory();
        currentBalance = 0;
        currentState = new IdleState(this);
        idleState = new IdleState(this);
        hasMoneyState = new HasMoneyState(this);
        itemSelectedState = new ItemSelectedState(this);
        dispensingState = new DispensingState(this);
    }
    public static VendingMachine GetInstance()
    {
        return Instance;
    }

    public void SetState(VendingMachineState state)
    {
        currentState = state;
    }

    public void InsertCoin(Coin coin)
    {
        currentState.InsertCoin(coin);
    }

    public void SelectItem(string itemCode)
    {
        currentState.SelectItem(itemCode);
    }

    public void DispenseItem()
    {
        currentState.DispenseItem();
    }

    public void ReturnCoins()
    {
        currentState.ReturnCoins();
    }

    public void AddItemToInventory(string code, Item item, int stock)
    {
        inventory.AddItem(code, item, stock);
    }

    public bool IsItemAvailable(string itemCode)
    {
        return inventory.IsAvailable(itemCode);
    }

    public Item GetItem(string itemCode)
    {
        return inventory.GetItem(itemCode);
    }

    public bool ReduceItemStock(string itemCode)
    {
        return inventory.ReduceStock(itemCode);
    }

    public void AddToBalance(decimal amount)
    {
        currentBalance += amount;
    }

    public decimal GetCurrentBalance()
    {
        return currentBalance;
    }

    public void ResetBalance()
    {
        currentBalance = 0;
    }
    public void DeductBalance(decimal amount)
    {
        currentBalance -= amount;
    }

    public void ResetCurrentBalance()
    {
        currentBalance = 0;
    }

    public Item GetSelectedItem()
    {
        if (selectedItemCode != null)
        {
            return inventory.GetItem(selectedItemCode);
        }
        return null;
    }

    public Inventory GetInventory() { return inventory; }
}