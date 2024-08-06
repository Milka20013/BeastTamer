using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Blueprint")]
public class EnemyBlueprint : ScriptableObject
{
    public string enemyName;
    public AttributeSelector<Attribute>[] attributes;
}
