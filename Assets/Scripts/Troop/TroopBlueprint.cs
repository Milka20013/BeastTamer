using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Troop/Blueprint")]
public class TroopBlueprint : ScriptableObject
{
    public EnemyBlueprint enemyBlueprint;
    public GameObject troopPrefab;
    public AttributeSelector<Attribute>[] overrides;


    public List<AttributeSelector<Attribute>> GetAttributes()
    {
        List<AttributeSelector<Attribute>> attributes = new();
        for (int i = 0; i < enemyBlueprint.attributes.Length; i++)
        {
            attributes.Add(new(enemyBlueprint.attributes[i]));
        }
        for (int i = 0; i < overrides.Length; i++)
        {
            for (int j = 0; j < attributes.Count; j++)
            {
                if (overrides[i].attribute == attributes[j].attribute)
                {
                    attributes[j] = new(overrides[i]);
                }
            }
        }
        return attributes;
    }
}
