using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour, IStatsInitializer<Attribute>, IDropHandler
{
    public Player player;
    public TroopBlueprint troopBlueprint;
    private IDropHandler dropHandler;

    private void Start()
    {
        dropHandler = player.GetComponent<IDropHandler>();
    }
    public ICollection<AttributeSelector<Attribute>> GetAttributeSelectors()
    {
        return troopBlueprint.GetAttributes();
    }

    public void RegisterDrop(Drop drop, float amount)
    {
        dropHandler.RegisterDrop(drop, amount);
    }
}
