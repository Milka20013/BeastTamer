using UnityEngine;

public class EnemyDeathManager : MonoBehaviour
{
    [SerializeField] private EntityContainer entityContainer;
    [SerializeField] private GameObject tameableIndicator;
    private DropTable dropTable;
    private EnemyBlueprint blueprint;
    private bool tameable = false;
    private void Awake()
    {
        dropTable = GetComponent<IDropper>().GetDropTable();
        blueprint = GetComponent<Enemy>().blueprint;
    }
    public void MarkAsTameable()
    {
        tameable = true;
        tameableIndicator.SetActive(true);
    }
    public void OnDeath(GameObject attacker)
    {
        if (dropTable != null)
        {
            if (attacker.TryGetComponent(out IDropHandler dropHandler))
            {
                foreach (var drop in dropTable.drops)
                {
                    dropHandler.RegisterDrop(drop.drop, drop.GetDropQuantity());
                }
            }
        }
        if (tameable)
        {
            if (attacker.TryGetComponent(out TroopManager troopManager))
            {
                troopManager.SpawnTroop(entityContainer.GetTroopFromEnemyBlueprint(blueprint));
            }
        }
        Destroy(gameObject);
    }
}
