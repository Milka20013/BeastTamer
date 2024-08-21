using UnityEngine;

public class EnemyStateManager : MonoBehaviour, IStateMachineHandler<EnemyStateMachine>
{
    [SerializeField] private EntityStateContainer stateContainer;
    [SerializeField] private AnimationClip idleAnimation;
    private Animator animator;
    private EnemyStateMachine enemyStateMachine;

    public EnemyStateMachine GetStateMachine()
    {
        return enemyStateMachine;
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        enemyStateMachine = new(stateContainer, animator, idleAnimation, stateContainer.idle);
    }
}
