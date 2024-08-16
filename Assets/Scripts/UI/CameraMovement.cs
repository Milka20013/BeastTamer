using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    private void Update()
    {
        var target = followTarget.transform.position;
        transform.position = new(target.x, target.y, transform.position.z);
    }
}
