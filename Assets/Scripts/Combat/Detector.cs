using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] private AttributeContainer attributeContainer;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float detectionRatePerSecond;
    private float _detectionDelay;
    private BasicStats stats;
    private float detectionRadius;
    public UnityEvent<Transform> onTargetDetected;

    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChanged);
    }

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        OnStatChanged();
        _detectionDelay = 1 / detectionRatePerSecond;
        StartCoroutine(DetectTarget());
    }
    IEnumerator DetectTarget()
    {
        for (; ; )
        {
            //hardcoded 100
            Collider2D[] colliders = new Collider2D[100];

            int size = Physics2D.OverlapCircleNonAlloc(transform.position, detectionRadius, colliders, targetLayer);
            if (size == 0)
            {
                OnTargetDetected(null);
            }
            else
            {
                OnTargetDetected(Utilitity.ClosestToPoint(transform.position, colliders).transform);
            }
            yield return new WaitForSeconds(_detectionDelay);
        }
    }

    public virtual void OnTargetDetected(Transform target)
    {
        onTargetDetected.Invoke(target);
    }

    public void OnStatChanged()
    {
        stats.TryGetAttributeValue(attributeContainer.detectionRadius, out detectionRadius);
    }
}
