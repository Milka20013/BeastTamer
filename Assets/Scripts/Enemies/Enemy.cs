using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IStatsInitializer<Attribute>
{
    public EnemyBlueprint blueprint;

    public ICollection<AttributeSelector<Attribute>> GetAttributeSelectors()
    {
        return blueprint.attributes;
    }
}
