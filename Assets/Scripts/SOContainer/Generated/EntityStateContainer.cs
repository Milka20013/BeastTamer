
//This is a generated script. You should not touch it.

using UnityEngine;
using UnityEditor;
using System.Linq;
[CreateAssetMenu(menuName = "Container/EntityState",fileName = "EntityStateContainer")]
public partial class EntityStateContainer : GeneratedContainer
{
public EntityState attack;
public EntityState chase;
public EntityState idle;
public EntityState wander;
#if UNITY_EDITOR
public override void FindReferences()
{EntityState[] objects = Resources.LoadAll<EntityState>("ScriptableObjects/EntityStates");
attack = objects.Where(x=>x.name == "Attack").First();
chase = objects.Where(x=>x.name == "Chase").First();
idle = objects.Where(x=>x.name == "Idle").First();
wander = objects.Where(x=>x.name == "Wander").First();
EditorUtility.SetDirty(this);
}
#endif
}