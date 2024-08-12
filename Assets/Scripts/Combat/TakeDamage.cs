using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    private HealthSystem healthSystem;
    public UnityEvent<GameObject> onDeath;
    public UnityEvent<GameObject> onHit;
    private bool isDead;

    private void Awake()
    {
        stats = GetComponent<BasicStats>();
    }

    private void Start()
    {
        healthSystem = new(stats, attributeContainer.health);
    }
    public bool IsDead()
    {
        return healthSystem.CurrentHealth <= 0f;
    }

    public void RegisterDamage(float amount, GameObject attacker)
    {
        float remainingHealth = healthSystem.TakeDamage(amount);
        onHit.Invoke(attacker);
        if (remainingHealth <= 0f && !isDead)
        {
            onDeath.Invoke(attacker);
            isDead = true;
        }
    }
}
