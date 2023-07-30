using CodeBase.Infrastructure.Game.States;
using CodeBase.Infrastructure.Game.UI;
using CodeBase.Infrastructure.Services.SceneData;
using CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;
using Zenject;

//TODO: Refactoring player network

namespace CodeBase.Infrastructure.Game
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private GameSceneData _sceneData;
        [SerializeField] private GameUIMediator _gameUIMediator;
        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private ISceneDataProvider _sceneDataProvider;

        [Inject]
        private void Constructor(IStateMachine stateMachine, IStateFactory stateFactory,
            ISceneDataProvider sceneDataProvider)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _sceneDataProvider = sceneDataProvider;
        }

        private void Start()
        {
            /*
            var coins = new Coins(_coinSpawnPoints.Length);
            var coinFactory = new CoinFactory(_coinStaticData, _coinSpawnPoints);
            _coinNetwork.Constructor(coinFactory, coins);
            _coinSpawner.Constructor(_coinStaticData, _coinNetwork, coins);
            */
            _gameUIMediator.InitializeUI();
            InitializeSceneDataProvider();
            InitializeStateMachine();

            _stateMachine.SwitchTo<WaitingState>();
        }

        private void OnDestroy() => _gameUIMediator.DisposeUI();

        private void InitializeSceneDataProvider() => _sceneDataProvider.Initialize(_sceneData);

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<WaitingState>(),
                _stateFactory.Create<BattleState>());
        }
    }
}