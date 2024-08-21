using UnityEngine;

public class EntityStateMachine
{
    protected EntityStateContainer stateContainer;
    protected Animator animator;
    protected AnimationClip idleAnimation;
    public EntityState currentState;

    public EntityStateMachine(EntityStateContainer stateContainer, Animator animator, AnimationClip idleAnimation, EntityState currentState)
    {
        this.stateContainer = stateContainer;
        this.animator = animator;
        this.idleAnimation = idleAnimation;
        this.currentState = currentState;
        Init();
    }
    private void Init()
    {
        RequestStateChange(stateContainer.idle);
        RequestAnimation(idleAnimation, stateContainer.idle);
    }
    public virtual bool RequestStateChange(EntityState state)
    {
        currentState = state;
        return true;
    }

    protected void ChangeState(EntityState state)
    {
        currentState = state;
    }

    public void ReleaseState(EntityState state)
    {
        if (currentState == state)
        {
            ChangeState(stateContainer.idle);
            RequestAnimation(idleAnimation, stateContainer.idle);
        }
    }
    public bool RequestAnimation(AnimationClip animationClip, EntityState state)
    {
        if (animationClip == null)
        {
            return false;
        }
        return RequestAnimation(animationClip.name, state);
    }
    public bool RequestAnimation(string animationName, EntityState state)
    {
        if (animator == null)
        {
            return false;
        }
        if (state != currentState)
        {
            return false;
        }
        animator.Play(animationName);
        return true;
    }
}
