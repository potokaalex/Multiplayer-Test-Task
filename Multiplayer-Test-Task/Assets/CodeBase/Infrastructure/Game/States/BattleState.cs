using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Coin.Object;
using CodeBase.Gameplay.Coin.Spawner;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.Game.States
{
    public class BattleState : IState
    {
        private readonly PlayerUIFactory _playerUIFactory;
        private readonly CoinSpawnerFactory _coinSpawnerFactory;
        private readonly BulletFactory _bulletFactory;
        private readonly CoinObjectFactory _coinObjectFactory;
        private CoinSpawner _spawner;

        public BattleState(PlayerUIFactory playerUIFactory, CoinSpawnerFactory coinSpawnerFactory,
            BulletFactory bulletFactory, CoinObjectFactory coinObjectFactory)
        {
            _playerUIFactory = playerUIFactory;
            _coinSpawnerFactory = coinSpawnerFactory;
            _bulletFactory = bulletFactory;
            _coinObjectFactory = coinObjectFactory;
        }

        public void Enter()
        {
            _coinSpawnerFactory.Initialize();
            _coinObjectFactory.Initialize();
            _bulletFactory.Initialize();

            _spawner = _coinSpawnerFactory.CreateSpawner();
            _playerUIFactory.GetUI().IsBattle = true;
        }

        public void Exit()
        {
            _coinSpawnerFactory.DestroySpawner(_spawner);
            _playerUIFactory.DestroyUI();
        }
    }
}