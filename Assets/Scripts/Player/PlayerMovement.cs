using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AttributeContainer attributeContainer;
    private BasicStats stats;
    [SerializeField] private InputActionReference moveAction;
    private float movementSpeed;

    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChange);
        OnStatChange();
    }
    void Update()
    {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();

        transform.Translate(movementSpeed * Time.deltaTime * direction);
    }

    public void OnStatChange()
    {
        stats.TryGetAttributeValue(attributeContainer.movementSpeed, out movementSpeed);
    }
}
