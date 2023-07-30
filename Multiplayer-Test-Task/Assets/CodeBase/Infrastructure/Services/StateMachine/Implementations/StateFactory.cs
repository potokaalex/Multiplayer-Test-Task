using Zenject;

namespace CodeBase.Infrastructure.Services.StateMachine.Implementations
{
    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator)
            => _instantiator = instantiator;

        public StateType Create<StateType>() where StateType : IStateBase
            => _instantiator.Instantiate<StateType>();
    }
}