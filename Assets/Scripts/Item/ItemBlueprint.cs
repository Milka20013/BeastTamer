using UnityEngine;

[CreateAssetMenu(menuName = "Item/Basic")]
public class ItemBlueprint : ScriptableObject
{
    public string id;
    public string itemName;
    public int stackSize;
    public string description;
}
