using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float detectionRatePerSecond;
    private float _detectionDelay;
    [SerializeField] private float detectionRadius;
    public UnityEvent<Transform> onTargetDetected;

    private void Awake()
    {
        _detectionDelay = 1 / detectionRatePerSecond;
    }

    private void Start()
    {
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
                onTargetDetected.Invoke(null);
            }
            else
            {
                onTargetDetected.Invoke(Utilitity.ClosestToPoint(transform.position, colliders).transform);
            }
            yield return new WaitForSeconds(_detectionDelay);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
