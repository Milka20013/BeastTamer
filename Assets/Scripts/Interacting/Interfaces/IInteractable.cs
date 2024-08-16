public interface IInteractable
{
    public void Interact(Interactor interactor);
    public void OnProximityEnter(Interactor interactor);
    public void OnProximityExit(Interactor interactor);

}
