using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Project.Services.StateMachine.Implementations
{
    public class StateMachine : IStateMachine
    {
        private Dictionary<Type, IStateBase> _states;
        private IStateBase _currentState;

        public void Initialize(params IStateBase[] states)
        {
            _states = new(states.Length);

            foreach (var state in states)
                _states.Add(state.GetType(), state);
        }

        public void SwitchTo<StateType>()
            where StateType : IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(StateType)];
            (_currentState as IState)?.Enter();
        }

        public void SwitchTo<StateType, ParameterType>(ParameterType parameter)
            where StateType : IStateWithParameter<ParameterType>
            where ParameterType : IStateParameter
        {
            _currentState?.Exit();
            _currentState = _states[typeof(StateType)];
            (_currentState as IStateWithParameter<ParameterType>)?.Enter(parameter);
        }
    }
}