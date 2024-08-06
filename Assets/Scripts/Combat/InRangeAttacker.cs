using UnityEngine;
using UnityEngine.Events;

public class InRangeAttacker : MonoBehaviour
{
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    [SerializeField] private LayerMask targetLayer;
    private float attackRange;
    [SerializeField] private int maxNumberOfTargets;
    private float damage;
    private bool readyToAttack = false;
    public UnityEvent onAttack;


    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChanged);
    }

    private void Start()
    {
        OnStatChanged();
    }
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

        var target = Utilitity.ClosestToPoint(transform.position, colliders);
        if (target.TryGetComponent(out IDamageable damageable))
        {
            damageable.RegisterDamage(damage);
        }
        //to-do: implement for more targets
        /*for (int i = 0; i < size; i++)
        {
            if (colliders[i].TryGetComponent(out IDamageable damageable))
            {
                damageable.RegisterDamage(damage);
            }
        }*/
        readyToAttack = false;
        onAttack.Invoke();
    }

    public void OnStatChanged()
    {
        stats.TryGetAttributeValue(attributeContainer.damage, out damage);
        stats.TryGetAttributeValue(attributeContainer.attackRange, out attackRange);
    }
}
