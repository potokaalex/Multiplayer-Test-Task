using CodeBase.Gameplay.Coin.Spawner;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.Game.States
{
    public class BattleState : IState
    {
        private readonly PlayerUIFactory _playerUIFactory;
        private readonly CoinSpawnerFactory _coinSpawnerFactory;
        private CoinSpawner _spawner;

        public BattleState(PlayerUIFactory playerUIFactory, CoinSpawnerFactory coinSpawnerFactory)
        {
            _playerUIFactory = playerUIFactory;
            _coinSpawnerFactory = coinSpawnerFactory;
        }

        public void Enter()
        {
            _playerUIFactory.GetUI().IsBattle = true;
            _spawner = _coinSpawnerFactory.CreateSpawner();
        }

        public void Exit()
        {
            _coinSpawnerFactory.DestroySpawner(_spawner);
        }
    }

    public class DeathState : IState
    {
        public void Enter()
        {
            
        }
    }
}