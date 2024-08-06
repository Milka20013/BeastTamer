using UnityEngine;
using UnityEngine.Events;

public class SimpleFollowTarget : MonoBehaviour
{
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    public UnityEvent onStopped;
    [SerializeField] private float stoppingDistance;
    private float movementSpeed;
    private Transform target;
    private bool isStopped = false;

    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChanged);
    }

    private void Start()
    {
        OnStatChanged();
    }
    void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, target.position) <= stoppingDistance)
        {
            if (!isStopped)
            {
                isStopped = true;
                onStopped.Invoke();
            }
            return;
        }
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
