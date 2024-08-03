using UnityEngine;
using UnityEngine.Events;

public class InRangeAttacker : MonoBehaviour
{
    public UnityEvent onAttack;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private int maxNumberOfTargets;
    [SerializeField] private float damage;
    private bool readyToAttack = false;

    public void OnReloaded()
    {
        readyToAttack = true;
        TryAttack();
    }

    public void TryAttack()
    {
        if (!readyToAttack)
        {
            return;
        }
        Collider2D[] colliders = new Collider2D[maxNumberOfTargets];
        int size = Physics2D.OverlapCircleNonAlloc(transform.position, attackRange, colliders, targetLayer);
        if (size == 0)
        {
            return;
        }
        for (int i = 0; i < size; i++)
        {
            if (TryGetComponent(out IDamageable damageable))
            {
                damageable.RegisterDamage(damage);
            }
        }
        readyToAttack = false;
        onAttack.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
