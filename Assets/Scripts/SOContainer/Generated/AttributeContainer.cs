
//This is a generated script. You should not touch it.

using UnityEngine;
using UnityEditor;
using System.Linq;
[CreateAssetMenu(menuName = "Container/Attribute",fileName = "AttributeContainer")]
public partial class AttributeContainer : GeneratedContainer
{
public Attribute attackRange;
public Attribute attackSpeed;
public Attribute damage;
public Attribute detectionRadius;
public Attribute health;
public Attribute movementSpeed;
public Attribute range;
public Attribute stoppingDistance;
#if UNITY_EDITOR
public override void FindReferences()
{Attribute[] objects = Resources.LoadAll<Attribute>("ScriptableObjects/Attribute");
attackRange = objects.Where(x=>x.name == "AttackRange").First();
attackSpeed = objects.Where(x=>x.name == "AttackSpeed").First();
damage = objects.Where(x=>x.name == "Damage").First();
detectionRadius = objects.Where(x=>x.name == "DetectionRadius").First();
health = objects.Where(x=>x.name == "Health").First();
movementSpeed = objects.Where(x=>x.name == "MovementSpeed").First();
range = objects.Where(x=>x.name == "Range").First();
stoppingDistance = objects.Where(x=>x.name == "StoppingDistance").First();
EditorUtility.SetDirty(this);
}
#endif
}