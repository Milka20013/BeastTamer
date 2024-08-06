using UnityEngine;

public class TroopSpawner : MonoBehaviour
{
    [SerializeField] private TroopBlueprint[] troops;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        for (int i = 0; i < troops.Length; i++)
        {
            SpawnTroop(troops[i]);
        }
    }
    public void SpawnTroop(TroopBlueprint troopBp)
    {
        var troopObj = Instantiate(troopBp.troopPrefab, transform.position, Quaternion.identity);
        troopObj.GetComponent<Troop>().player = player;
    }
}
