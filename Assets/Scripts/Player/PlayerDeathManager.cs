using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    public void OnDeath(GameObject attacker)
    {
        Destroy(gameObject);
    }
}
