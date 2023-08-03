namespace CodeBase.Infrastructure.Project.Services.StateMachine
{
    public interface IState : IStateBase
    {
        public void Enter();
    }
}