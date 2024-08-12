using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Blueprint")]
public class EnemyBlueprint : ScriptableObject
{
    public string enemyName;
    public GameObject prefab;
    public AttributeSelector<Attribute>[] attributes;
    public DropTable dropTable;
}
