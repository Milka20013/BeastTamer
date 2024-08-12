using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IStatsInitializer<Attribute>, IDropper
{
    public EnemyBlueprint blueprint;

    public ICollection<AttributeSelector<Attribute>> GetAttributeSelectors()
    {
        return blueprint.attributes;
    }

    public DropTable GetDropTable()
    {
        return blueprint.dropTable;
    }
}
