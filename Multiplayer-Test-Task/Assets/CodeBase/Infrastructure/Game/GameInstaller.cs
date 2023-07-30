using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Coin.Spawner;
using CodeBase.Gameplay.Player;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Services.SceneData;
using CodeBase.Infrastructure.Services.StateMachine.Implementations;
using CodeBase.Infrastructure.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Game
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStaticData _playerStaticData;
        [SerializeField] private CoinStaticData _coinStaticData;

        public override void InstallBindings()
        {
            Container.Bind<ISceneDataProvider>().To<SceneDataProvider>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            BindPlayerUIFactory();
            BindCoinSpawnerFactory();
        }

        private void BindPlayerUIFactory()
        {
            var factory = new PlayerUIFactory(_playerStaticData);

            Container.Bind<PlayerUIFactory>().FromInstance(factory).AsSingle();
        }

        private void BindCoinSpawnerFactory()
        {
            var factory = new CoinSpawnerFactory(_coinStaticData);

            Container.Bind<CoinSpawnerFactory>().FromInstance(factory).AsSingle();
        }
    }
}