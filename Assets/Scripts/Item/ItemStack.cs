using UnityEngine;
public class ItemStack
{
    public enum StackState { Alive, Full, Dead }
    public ItemBlueprint item;
    public int quantity;
    public StackState state = StackState.Alive;
    private ItemStack(ItemBlueprint item, int quantity)
    {
        this.item = item;
        ChangeQuantity(quantity);
        state = quantity < item.stackSize ? StackState.Alive : StackState.Full;

    }
    private void UpdateState()
    {
        if (quantity <= 0)
        {
            state = StackState.Dead;
        }
        else if (quantity >= item.stackSize)
        {
            state = StackState.Full;
        }
        else
        {
            state = StackState.Alive;
        }
    }
    public int FillStack(ItemBlueprint item, int quantity)
    {
        int oldQuantity = this.quantity;
        if (!SameItem(item))
        {
            return 0;
        }
        if (state == StackState.Alive)
        {
            if (quantity > 0)
            {
                this.quantity += quantity;
                this.quantity = Mathf.Clamp(this.quantity, 0, item.stackSize);
                UpdateState();
            }
        }
        ChangeQuantity(this.quantity);
        return this.quantity - oldQuantity;

    }
    public int RemoveItems(ItemBlueprint item, int quantity)
    {
        int oldQuantity = this.quantity;
        if (!SameItem(item))
        {
            return 0;
        }
        if (state != StackState.Dead)
        {
            if (quantity > 0)
            {
                this.quantity -= quantity;
                ChangeQuantity(Mathf.Clamp(this.quantity, 0, item.stackSize));
                UpdateState();
            }
        }
        return this.quantity - oldQuantity;
    }
    public int RemoveItems(int quantity)
    {
        return RemoveItems(item, quantity);
    }
    public static ItemStack[] CreateItemStacks(ItemBlueprint item, int quantity = 1)
    {
        float quantityF = quantity;
        float stackSizeF = item.stackSize;  //Mathf.CeilToInt() doesn't work with integer division
        int size = Mathf.CeilToInt(quantityF / stackSizeF);
        ItemStack[] itemStacks = new ItemStack[size];
        for (int i = 0; i < itemStacks.Length; i++)
        {
            itemStacks[i] = new ItemStack(item, 0);
            quantity -= itemStacks[i].FillStack(item, quantity);
        }
        return itemStacks;
    }
    public bool SameItem(ItemBlueprint item)
    {
        if (item.itemName == this.item.itemName)
        {
            return true;
        }
        return false;
    }
    public void ChangeQuantity(int quantity)
    {
        this.quantity = quantity;
    }
}
