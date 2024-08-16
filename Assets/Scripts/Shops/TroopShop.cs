using UnityEngine;

public class TroopShop : IndicatedInteractable
{
    public override void Interact(Interactor interactor)
    {
        Debug.Log("Interacted with troop shop");
    }
}
