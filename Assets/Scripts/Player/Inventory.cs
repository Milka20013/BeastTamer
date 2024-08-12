using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameEventContainer eventContainer;
    private Dictionary<Drop, float> ownedDrops = new();

    public void AddDrop(Drop drop, float amount)
    {
        if (!ownedDrops.TryAdd(drop, amount))
        {
            ownedDrops[drop] += amount;
        }
        eventContainer.onDropGained.RaiseEvent(drop);
    }

    public void RegisterDrop(Drop drop, float amount)
    {
        AddDrop(drop, amount);
    }

    public bool TryGetDropValue(Drop drop, out float value)
    {
        return ownedDrops.TryGetValue(drop, out value);
    }
}
