
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum ItemType
    {
        Supplies,
        InventoryItem
    }

    public ItemType type;
    public int amount = 5;
    public string itemName = "Key";

    public void Collect(GameState state)
    {
        if (type == ItemType.Supplies)
        {
            state.AddSupplies(amount);
        }
        else if (type == ItemType.InventoryItem)
        {
            state.AddItem(itemName);
        }

        Destroy(gameObject);
    }
}
