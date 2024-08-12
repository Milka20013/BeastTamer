using UnityEngine;

public class EnemyDeathManager : MonoBehaviour
{
    private DropTable dropTable;
    private void Awake()
    {
        dropTable = GetComponent<IDropper>().GetDropTable();
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
        Destroy(gameObject);
    }
}
