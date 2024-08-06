using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IStatsInitializer<Attribute>
{
    public PlayerBlueprint blueprint;

    public ICollection<AttributeSelector<Attribute>> GetAttributeSelectors()
    {
        return blueprint.attributes;
    }
}
