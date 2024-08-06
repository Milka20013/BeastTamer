using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour, IStatsInitializer<Attribute>
{
    public Player player;
    public TroopBlueprint troopBlueprint;

    public ICollection<AttributeSelector<Attribute>> GetAttributeSelectors()
    {
        return troopBlueprint.GetAttributes();
    }
}
