using UnityEngine;
using UnityEngine.Events;

public class SimpleFollowTarget : MonoBehaviour
{
    [SerializeField] private EntityStateContainer stateContainer;
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    public UnityEvent onStopped;
    [SerializeField] private float stoppingDistance;
    private float movementSpeed;
    private Transform target;
    private bool isStopped = false;
    private EntityStateMachine stateMachine = null;
    [SerializeField] private AnimationClip walkAnimation;

    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChanged);
        if (TryGetComponent(out IStateMachineHandler<EnemyStateMachine> machineHandler))
        {
            stateMachine = machineHandler.GetStateMachine();
        }
    }

    private void Start()
    {
        OnStatChanged();
    }
    void Update()
    {
        if (target == null)
        {
            stateMachine?.ReleaseState(stateContainer.chase);
            return;
        }
        if (Vector3.Distance(transform.position, target.position) <= stoppingDistance)
        {
            if (!isStopped)
            {
                isStopped = true;
                onStopped.Invoke();
            }
            stateMachine?.ReleaseState(stateContainer.chase);
            return;
        }
        stateMachine?.RequestStateChange(stateContainer.chase);
        stateMachine?.RequestAnimation(walkAnimation, stateContainer.chase);
        Vector3 direction = target.position - transform.position;
        transform.Translate(movementSpeed * Time.deltaTime * direction.normalized);
    }

    public void OnTargetDetected(Transform target)
    {
        this.target = target;
    }

    public void OnStatChanged()
    {
        stats.TryGetAttributeValue(attributeContainer.movementSpeed, out movementSpeed);
        //stats.TryGetAttributeValue(attributeContainer.stoppingDistance, out stoppingDistance);
    }
}
