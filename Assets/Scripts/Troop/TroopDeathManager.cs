using UnityEngine;

public class TroopDeathManager : MonoBehaviour
{
    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
