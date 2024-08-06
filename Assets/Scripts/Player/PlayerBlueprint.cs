using UnityEngine;

[CreateAssetMenu(menuName = "Player/Blueprint")]
public class PlayerBlueprint : ScriptableObject
{
    public AttributeSelector<Attribute>[] attributes;
}
