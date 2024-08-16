using UnityEngine;
using UnityEngine.EventSystems;

public class Indicator : MonoBehaviour, IPointerClickHandler
{
    private IInteractable interactable;
    private Interactor interactor;
    public void Initialize(IInteractable interactable, Interactor interactor)
    {
        this.interactable = interactable;
        this.interactor = interactor;
    }

    public void Interact()
    {
        interactable.Interact(interactor);
        //Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }
}
