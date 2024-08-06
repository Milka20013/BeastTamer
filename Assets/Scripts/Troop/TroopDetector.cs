using UnityEngine;

public class TroopDetector : Detector
{
    private PlayerMovement playerMovement;

    protected override void Init()
    {
        playerMovement = GetComponent<Troop>().player.GetComponent<PlayerMovement>();
        base.Init();
    }
    public override void OnTargetDetected(Transform target)
    {
        if (playerMovement.isMoving)
        {
            onTargetDetected.Invoke(playerMovement.transform);
        }
        else
        {
            onTargetDetected.Invoke(target);
        }
    }
}
