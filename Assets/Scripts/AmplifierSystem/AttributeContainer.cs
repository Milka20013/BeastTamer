using UnityEngine;

[CreateAssetMenu(menuName = "Attribute/Container")]
public class AttributeContainer : ScriptableObject
{
    [Header("Basic")]
    public Attribute health;
    public Attribute movementSpeed;
    public Attribute attackSpeed;
    public Attribute damage;
    public Attribute attackRange;
    public Attribute range;


    [Header("Detection")]
    public Attribute detectionRadius;
    public Attribute stoppingDistance;

}
