namespace VendingMachine;
public class Inventory
{
    public Dictionary<string, Item> Items;
    private Dictionary<string, int> itemStock;
    public Inventory()
    {
        Items = new Dictionary<string, Item>();
        itemStock = new Dictionary<string, int>();
    }

    public void AddItem(string code,Item item, int stock)
    {
        Items[code] = item;
        itemStock[code] = stock;
    }

    public bool ReduceStock(string itemName)
    {
        if (itemStock.ContainsKey(itemName) && itemStock[itemName] > 0)
        {
            itemStock[itemName]--;
            return true;
        }
        return false;
    }

    public Item GetItem(string itemName)
    {
        if (Items.ContainsKey(itemName))
        {
            return Items[itemName];
        }
        return null;
    }
    public Boolean IsAvailable(string itemName)
    {
        return itemStock.ContainsKey(itemName) && itemStock[itemName] > 0;
    }
}