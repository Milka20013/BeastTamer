using System.Linq;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyStats : Stats<Attribute>
{
    private void Awake()
    {
        var blueprint = GetComponent<Enemy>().blueprint;

        attributes.AddRange(blueprint.attributes);

        amplifierSystem = new(attributes.Select(x => x.attribute), attributes.Select(x => x.value));
    }
}
