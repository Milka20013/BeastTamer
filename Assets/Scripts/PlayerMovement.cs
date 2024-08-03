using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float speed;
    void Update()
    {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();

        transform.Translate(speed * Time.deltaTime * direction);
    }
}
