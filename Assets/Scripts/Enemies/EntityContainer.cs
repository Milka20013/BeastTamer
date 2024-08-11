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
}
