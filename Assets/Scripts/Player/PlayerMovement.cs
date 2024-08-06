using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    [SerializeField] private InputActionReference moveAction;
    private float movementSpeed;
    [HideInInspector] public bool isMoving = false;
    public UnityEvent onStoppedMoving;
    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChange);
        OnStatChange();
    }
    void Update()
    {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();
        if (direction.magnitude == 0)
        {
            if (isMoving)
            {
                onStoppedMoving.Invoke();
            }
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        transform.Translate(movementSpeed * Time.deltaTime * direction);
    }

    public void OnStatChange()
    {
        stats.TryGetAttributeValue(attributeContainer.movementSpeed, out movementSpeed);
    }
}
