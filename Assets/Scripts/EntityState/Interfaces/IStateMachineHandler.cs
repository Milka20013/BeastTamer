public interface IStateMachineHandler<T> where T : EntityStateMachine
{
    public T GetStateMachine();
}
