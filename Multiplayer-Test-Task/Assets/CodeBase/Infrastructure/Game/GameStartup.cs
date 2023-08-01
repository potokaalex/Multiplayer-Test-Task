using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Player.Data;
using CodeBase.Infrastructure.Game.States;
using CodeBase.Infrastructure.Services.Data;
using CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Game
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _playerStaticData;
        [SerializeField] private BulletStaticData _bulletStaticData;
        [SerializeField] private CoinStaticData _coinStaticData;
        [SerializeField] private GameSceneData _sceneData;

        private IStateMachine _stateMachine;
        private IStateFactory _stateFactory;
        private IDataProvider _dataProvider;

        [Inject]
        private void Constructor(IStateMachine stateMachine, IStateFactory stateFactory,
            IDataProvider dataProvider)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _dataProvider = dataProvider;
        }

        private void Start()
        {
            SetData();
            InitializeStateMachine();

            _stateMachine.SwitchTo<GameLoadingState>();
        }

        private void SetData()
        {
            _dataProvider.Set(_playerStaticData);
            _dataProvider.Set(_bulletStaticData);
            _dataProvider.Set(_coinStaticData);
            _dataProvider.Set(_sceneData);
        }

        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(
                _stateFactory.Create<GameLoadingState>(),
                _stateFactory.Create<SetupPlayerState>(),
                _stateFactory.Create<BattleState>(),
                _stateFactory.Create<DeathState>());
        }
    }
}