
//This is a generated script. You should not touch it.

using UnityEngine;
using UnityEditor;
using System.Linq;
[CreateAssetMenu(menuName = "Container/GameEvent",fileName = "GameEventContainer")]
public partial class GameEventContainer : GeneratedContainer
{
public GameEvent onDropGained;
#if UNITY_EDITOR
public override void FindReferences()
{GameEvent[] objects = Resources.LoadAll<GameEvent>("ScriptableObjects/Event");
onDropGained = objects.Where(x=>x.name == "OnDropGained").First();
EditorUtility.SetDirty(this);
}
#endif
}