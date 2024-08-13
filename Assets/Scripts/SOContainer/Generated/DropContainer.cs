
//This is a generated script. You should not touch it.

using UnityEngine;
using System.Linq;
[CreateAssetMenu(menuName = "Container/Drop",fileName = "DropContainer")]
public partial class DropContainer : GeneratedContainer
{
public Drop diamondDrop;
public Drop moneyDrop;
public override void FindReferences()
{Drop[] objects = Resources.LoadAll<Drop>("ScriptableObjects/Drop");
diamondDrop = objects.Where(x=>x.name == "DiamondDrop").First();
moneyDrop = objects.Where(x=>x.name == "MoneyDrop").First();
}}