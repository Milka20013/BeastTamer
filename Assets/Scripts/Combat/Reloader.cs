using UnityEngine;
using UnityEngine.Events;

public class Reloader : MonoBehaviour
{
    [SerializeField] private AttributeContainer attributeContainer;
    public UnityEvent onReady;
    private BasicStats stats;
    private float attackSpeed;
    private float _attackDelay;
    private bool isReady = false;

    private void Awake()
    {
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(OnStatChange);

    }
    private void Start()
    {
        OnStatChange();
        _attackDelay = 1 / attackSpeed;
    }
    private void Update()
    {
        if (isReady)
        {
            return;
        }
        _attackDelay -= Time.deltaTime;
        if (_attackDelay <= 0f)
        {
            isReady = true;
            onReady.Invoke();
        }
    }

    public void Reload()
    {
        _attackDelay = 1 / attackSpeed;
        isReady = false;
    }

    public void OnStatChange()
    {
        stats.TryGetAttributeValue(attributeContainer.attackSpeed, out attackSpeed);
    }
}
