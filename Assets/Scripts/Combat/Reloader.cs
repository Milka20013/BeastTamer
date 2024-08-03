using UnityEngine;
using UnityEngine.Events;

public class Reloader : MonoBehaviour
{
    public UnityEvent onReady;
    [SerializeField] private float attackSpeed;
    private float _attackDelay;
    private bool isReady = false;

    private void Awake()
    {
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
}
