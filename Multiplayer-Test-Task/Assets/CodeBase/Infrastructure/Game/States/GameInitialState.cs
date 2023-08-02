using CodeBase.Infrastructure.Game.Network;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.Game.States
{
    public class GameInitialState : IState
    {
        private readonly GameNetwork _gameNetwork;
        private readonly IStateMachine _stateMachine;

        public GameInitialState(GameNetwork gameNetwork, IStateMachine stateMachine)
        {
            _gameNetwork = gameNetwork;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _gameNetwork.Initialize();
            _gameNetwork.RegisterCustomTypes();

            _stateMachine.SwitchTo<SetupPlayerState>();
        }
    }
}