

public class HealthSystem
{
    private BasicStats stats;
    private Attribute healthAttr;
    public float InitialHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public HealthSystem(BasicStats basicStats, Attribute healthAttr)
    {
        stats = basicStats;
        this.healthAttr = healthAttr;
        stats.onValueChanged.AddListener(OnInitialHealthChanged);
        OnInitialHealthChanged();
        CurrentHealth = InitialHealth;
    }

    private void OnInitialHealthChanged()
    {
        stats.TryGetAttributeValue(healthAttr, out float value);
        InitialHealth = value;
    }
    public float TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        return CurrentHealth;
    }

}
