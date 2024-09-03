using System.Collections.Generic;

public class ItemInventory
{

    public int capacity;
    public List<ItemStack> itemStacks;

    public ItemInventory(int capacity)
    {
        this.capacity = capacity;
    }
    public void RegisterItems(ICollection<ItemStack> itemStacks)
    {
        this.itemStacks.AddRange(itemStacks);
    }
}
