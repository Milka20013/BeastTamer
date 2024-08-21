
//This is a generated script. You should not touch it.

using UnityEngine;
using UnityEditor;
using System.Linq;
[CreateAssetMenu(menuName = "Container/Drop",fileName = "DropContainer")]
public partial class DropContainer : GeneratedContainer
{
public Drop diamondDrop;
public Drop moneyDrop;
#if UNITY_EDITOR
public override void FindReferences()
{Drop[] objects = Resources.LoadAll<Drop>("ScriptableObjects/Drop");
diamondDrop = objects.Where(x=>x.name == "DiamondDrop").First();
moneyDrop = objects.Where(x=>x.name == "MoneyDrop").First();
EditorUtility.SetDirty(this);
}
#endif
}