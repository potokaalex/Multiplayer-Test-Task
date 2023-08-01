using CodeBase.Infrastructure.Game.Network;
using CodeBase.Infrastructure.Services.Data;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.Game.States
{
    public class GameLoadingState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly GameNetwork _gameNetwork;
        private readonly IStateMachine _stateMachine;

        public GameLoadingState(IDataProvider dataProvider, GameNetwork gameNetwork,IStateMachine stateMachine)
        {
            _dataProvider = dataProvider;
            _gameNetwork = gameNetwork;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _dataProvider.Get<GameSceneData>().GameUI.InitializeUI();
            
            _gameNetwork.RegisterCustomTypes();
            
            _stateMachine.SwitchTo<SetupPlayerState>();
        }
    }
}