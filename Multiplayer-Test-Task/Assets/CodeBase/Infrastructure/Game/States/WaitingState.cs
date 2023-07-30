using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Coin;
using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Coin.Object;
using CodeBase.Gameplay.Player;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Services.SceneData;
using CodeBase.Infrastructure.Services.StateMachine;
using ExitGames.Client.Photon;
using Photon.Pun;

namespace CodeBase.Infrastructure.Game.States
{
    public class WaitingState : IState
    {
        private readonly ISceneDataProvider _dataProvider;
        private readonly PlayerUIFactory _playerUIFactory;

        public WaitingState(ISceneDataProvider dataProvider, PlayerUIFactory playerUIFactory)
        {
            _dataProvider = dataProvider;
            _playerUIFactory = playerUIFactory;
        }

        public void Enter()
        {
            var data = _dataProvider.Get<GameSceneData>();
            RegisterPlayerColor();
            InitializeNetwork(data);

            var bulletNetwork = data.Network.BulletNetwork;
            var playerUI = _playerUIFactory.CreateUI();
            var playerObject = CreatePlayer(data, playerUI, bulletNetwork);

            playerUI.Initialize(playerObject);
        }

        private void RegisterPlayerColor() =>
            PhotonPeer.RegisterType(typeof(PlayerColor), CustomRegisteredNetworkTypes.PlayerColor,
                PlayerColor.Serialize, PlayerColor.Deserialize);

        private PlayerObject CreatePlayer(GameSceneData data, IPlayerUI ui, BulletNetwork bulletNetwork)
        {
            var factory = new PlayerObjectFactory(data.PlayerStaticData, data.PlayerSpawnPoints);
            var player = factory.CreatePlayer(ui, bulletNetwork, PhotonNetwork.CurrentRoom.PlayerCount - 1);

            return player;
        }

        private void InitializeNetwork(GameSceneData data)
        {
            var bulletFactory = new BulletFactory(data.BulletStaticData);
            data.Network.BulletNetwork.Initialize(bulletFactory);

            var coinFactory = new CoinObjectFactory(data.CoinStaticData, data.CoinSpawnPoints);
            var coins = new Coins(data.CoinSpawnPoints.Length);
            data.Network.CoinNetwork.Initialize(coinFactory, coins);
        }
    }
}