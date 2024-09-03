using UnityEngine;

public class TroopDetector : Detector
{
    private PlayerMovement playerMovement;

    protected override void Init()
    {
        playerMovement = GetComponent<Troop>().player.GetComponent<PlayerMovement>();
        base.Init();
    }
    public override void OnTargetDetected(Collider2D target)
    {
        if (playerMovement.isMoving)
        {
            onTargetDetected.Invoke(playerMovement.GetComponent<Collider2D>());
        }
        else
        {
            onTargetDetected.Invoke(target);
        }
    }
}
