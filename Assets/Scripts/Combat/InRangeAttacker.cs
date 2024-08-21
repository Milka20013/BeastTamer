using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InRangeAttacker : MonoBehaviour
{
    [SerializeField] private EntityStateContainer stateContainer;
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    [SerializeField] private LayerMask targetLayer;
    private float attackRange;
    [SerializeField] private int maxNumberOfTargets = 10;
    private float damage;
    private bool readyToAttack = false;
    private Collider2D target;
    [SerializeField] private float detectionPerSecond = 30f;
    private EntityStateMachine stateMachine;
    [SerializeField] private AnimationClip attackAnimation;
    public UnityEvent onAttack;


    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChanged);
        if (TryGetComponent(out IStateMachineHandler<EnemyStateMachine> stateHandler))
        {
            stateMachine = stateHandler.GetStateMachine();
        }
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
        if (stateMachine == null)
        {
            AttackTarget();
            return;
        }
        stateMachine.RequestStateChange(stateContainer.attack);
        if (!stateMachine.RequestAnimation(attackAnimation, stateContainer.attack))
        {
            AttackTarget();
            return;
        }
    }

    IEnumerator DetectTargetInRange()
    {
        for (; ; )
        {
            Collider2D[] colliders = new Collider2D[maxNumberOfTargets];
            int size = Physics2D.OverlapCircleNonAlloc(transform.position, attackRange, colliders, targetLayer);
            target = Utilitity.ClosestToPoint(transform.position, colliders);
            if (target == null)
            {
                stateMachine?.ReleaseState(stateContainer.attack);
            }
            TryAttack();
            yield return new WaitForSeconds(1 / detectionPerSecond);
        }
    }
    public void OnDoAttack()
    {
        AttackTarget();
    }
    public void AttackTarget()
    {
        if (target == null)
        {
            return;
        }
        onAttack.Invoke();
        if (target.TryGetComponent(out IDamageable damageable))
        {
            damageable.RegisterDamage(damage, gameObject);
        }
        readyToAttack = false;
        //to-do: implement for more targets
        /*for (int i = 0; i < size; i++)
        {
            if (colliders[i].TryGetComponent(out IDamageable damageable))
            {
                damageable.RegisterDamage(damage);
            }
        }*/
    }

    public void OnStatChanged()
    {
        stats.TryGetAttributeValue(attributeContainer.damage, out damage);
        stats.TryGetAttributeValue(attributeContainer.attackRange, out attackRange);
    }
}
