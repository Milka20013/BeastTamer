using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    private HealthSystem healthSystem;
    public UnityEvent onDeath;
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

    public void RegisterDamage(float amount)
    {
        float remainingHealth = healthSystem.TakeDamage(amount);
        if (remainingHealth <= 0f && !isDead)
        {
            onDeath.Invoke();
            isDead = true;
        }
    }
}
