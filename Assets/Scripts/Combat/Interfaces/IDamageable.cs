using UnityEngine;

public interface IDamageable
{
    public void RegisterDamage(float amount, GameObject attacker);
    public bool IsDead();
}
