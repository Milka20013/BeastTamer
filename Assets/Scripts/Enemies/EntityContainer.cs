using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Entity/Container")]
public class EntityContainer : ScriptableObject
{
    public EnemyBlueprint[] enemies;
    public string enemyBpsPath;
    public TroopBlueprint[] troops;
    public string troopBpsPath;

    public void LoadEntites()
    {
        enemies = Resources.LoadAll<EnemyBlueprint>(enemyBpsPath);
        troops = Resources.LoadAll<TroopBlueprint>(troopBpsPath);
    }

    public TroopBlueprint GetTroopFromEnemyBlueprint(EnemyBlueprint enemyBlueprint)
    {
        var troop = troops.Where(x => x.enemyBlueprint == enemyBlueprint).FirstOrDefault();
        if (troop != null)
        {
            return troop;
        }
        Debug.LogWarning($"Enemyblueprint {enemyBlueprint.name} was not found. Trying a resource loading.");
        LoadEntites();
        troop = troops.Where(x => x.enemyBlueprint == enemyBlueprint).FirstOrDefault();
        if (troop == null)
        {
            Debug.LogError($"Enemyblueprint {enemyBlueprint.name} was not found after loading.");
        }
        return troop;

    }
}
