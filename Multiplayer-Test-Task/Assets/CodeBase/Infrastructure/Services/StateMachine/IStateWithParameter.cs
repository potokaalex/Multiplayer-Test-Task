namespace CodeBase.Infrastructure.Services.StateMachine
{
    public interface IStateWithParameter<in ParameterType> : IStateBase
        where ParameterType : IStateParameter
    {
        public void Enter(ParameterType parameter);
    }
}