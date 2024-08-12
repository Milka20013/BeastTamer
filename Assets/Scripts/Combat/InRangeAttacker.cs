using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InRangeAttacker : MonoBehaviour
{
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    [SerializeField] private LayerMask targetLayer;
    private float attackRange;
    [SerializeField] private int maxNumberOfTargets = 10;
    private float damage;
    private bool readyToAttack = false;
    private Collider2D target;
    [SerializeField] private float detectionPerSecond = 30f;
    public UnityEvent onAttack;


    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChanged);
    }

    private void Start()
    {
        OnStatChanged();
        StartCoroutine(DetectTargetInRange());
    }
    public void OnReloaded()
    {
        readyToAttack = true;
        TryAttack();
    }

    public void TryAttack()
    {
        if (!readyToAttack || target == null)
        {
            return;
        }
        Attack();
    }

    IEnumerator DetectTargetInRange()
    {
        for (; ; )
        {
            Collider2D[] colliders = new Collider2D[maxNumberOfTargets];
            int size = Physics2D.OverlapCircleNonAlloc(transform.position, attackRange, colliders, targetLayer);
            if (size != 0)
            {
                target = Utilitity.ClosestToPoint(transform.position, colliders);
                TryAttack();
            }
            yield return new WaitForSeconds(1 / detectionPerSecond);
        }
    }
    public void Attack()
    {
        if (target.TryGetComponent(out IDamageable damageable))
        {
            damageable.RegisterDamage(damage, gameObject);
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
