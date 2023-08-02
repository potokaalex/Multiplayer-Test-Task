using CodeBase.Infrastructure.Services.StateMachine.Implementations;
using CodeBase.Infrastructure.Services.StateMachine;
using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Coin.Network;
using CodeBase.Gameplay.Coin.Object;
using CodeBase.Gameplay.Coin.Spawner;
using CodeBase.Gameplay.Player.Network;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Gameplay.Player.Weapon;
using CodeBase.Infrastructure.Game.Network;
using CodeBase.Infrastructure.Game.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameNetwork _gameNetwork;
        [SerializeField] private PlayerNetwork _playerNetwork;
        [SerializeField] private BulletNetwork _bulletNetwork;
        [SerializeField] private CoinNetwork _coinNetwork;

        public override void InstallBindings()
        {
            BindStateMachine();
            BindGame();
            BindPlayer();
            BindBullet();
            BidCoin();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }

        private void BindGame()
        {
            Container.Bind<GameNetwork>().FromInstance(_gameNetwork).AsSingle();
            Container.Bind<GameUIFactory>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerNetwork>().FromInstance(_playerNetwork).AsSingle();
            Container.Bind<PlayerObjectFactory>().AsSingle();
            Container.Bind<PlayerWeaponFactory>().AsSingle();
            Container.Bind<PlayerUIFactory>().AsSingle();
        }

        private void BindBullet()
        {
            Container.Bind<BulletNetwork>().FromInstance(_bulletNetwork).AsSingle();
            Container.Bind<BulletFactory>().AsSingle();
        }

        private void BidCoin()
        {
            Container.Bind<CoinSpawnerFactory>().AsSingle();
            Container.Bind<CoinObjectFactory>().AsSingle();
            Container.Bind<CoinNetwork>().FromInstance(_coinNetwork).AsSingle();
        }
    }
}