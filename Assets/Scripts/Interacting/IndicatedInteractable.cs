using UnityEngine;

public abstract class IndicatedInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject indicatorPrefab;
    [SerializeField] protected Transform indicatorPosition;
    protected GameObject indicator;
    public abstract void Interact(Interactor interactor);

    public void OnProximityEnter(Interactor interactor)
    {
        indicator = Instantiate(indicatorPrefab, indicatorPosition.position, Quaternion.identity);
        indicator.GetComponent<Indicator>().Initialize(this, interactor);
    }

    public void OnProximityExit(Interactor interactor)
    {
        if (indicator != null)
        {
            Destroy(indicator);
            indicator = null;
        }
    }
}
