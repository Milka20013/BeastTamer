using UnityEngine;
using UnityEngine.Events;

public class SimpleFollowTarget : MonoBehaviour
{
    public UnityEvent onStopped;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float speed;
    private Transform target;
    private bool isStopped = false;
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
        transform.Translate(speed * Time.deltaTime * direction.normalized);
    }

    public void OnTargetDetected(Transform target)
    {
        this.target = target;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
