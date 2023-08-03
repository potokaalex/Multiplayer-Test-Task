namespace CodeBase.Infrastructure.Project.Services.StateMachine
{
    public interface IStateFactory
    {
        public StateType Create<StateType>() where StateType : IStateBase;
    }
}
