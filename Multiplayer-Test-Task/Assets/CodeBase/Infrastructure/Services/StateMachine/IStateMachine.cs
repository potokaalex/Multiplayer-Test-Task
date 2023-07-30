namespace CodeBase.Infrastructure.Services.StateMachine
{
    public interface IStateMachine
    {
        public void Initialize(params IStateBase[] states);

        public void SwitchTo<StateType>()
            where StateType : IState;

        public void SwitchTo<StateType, ParameterType>(ParameterType parameter)
            where StateType : IStateWithParameter<ParameterType>
            where ParameterType : IStateParameter;
    }
}