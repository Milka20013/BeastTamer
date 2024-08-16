using System.Collections;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float checkPerSecond = 30;
    [SerializeField] private float checkRadius = 2;
    [SerializeField] private LayerMask interactableLayer;
    private IInteractable currentInteractable;

    private void Start()
    {
        StartCoroutine(FindInteractables());
    }

    IEnumerator FindInteractables()
    {
        for (; ; )
        {
            Collider2D[] colliders = new Collider2D[5];
            Physics2D.OverlapCircleNonAlloc(transform.position, checkRadius, colliders, interactableLayer);
            Collider2D closestCollider = Utilitity.ClosestToPoint(transform.position, colliders);
            if (closestCollider == null)
            {
                //None found
                ReleaseCurrentInteractable();
                yield return new WaitForSeconds(1 / checkPerSecond);
                continue;
            }
            if (closestCollider.TryGetComponent(out IInteractable interactable))
            {
                //One found
                if (currentInteractable != interactable)
                {
                    //It's a new one
                    ReleaseCurrentInteractable();
                    currentInteractable = interactable;
                    interactable.OnProximityEnter(this);
                }
                //If it is not new, do nothing
                yield return new WaitForSeconds(1 / checkPerSecond);
                continue;
            }
            //The found object is false positive
            ReleaseCurrentInteractable();
            yield return new WaitForSeconds(1 / checkPerSecond);
        }
    }

    private void ReleaseCurrentInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable.OnProximityExit(this);
        }
        currentInteractable = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
