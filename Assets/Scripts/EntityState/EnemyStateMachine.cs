using UnityEngine;

public class EnemyStateMachine : EntityStateMachine
{
    public EnemyStateMachine(EntityStateContainer stateContainer, Animator animator, AnimationClip idleAnimation, EntityState currentState)
        : base(stateContainer, animator, idleAnimation, currentState)
    {
    }

    public override bool RequestStateChange(EntityState state)
    {
        if (currentState == stateContainer.attack)
        {
            return false;
        }
        return base.RequestStateChange(state);
    }
}
