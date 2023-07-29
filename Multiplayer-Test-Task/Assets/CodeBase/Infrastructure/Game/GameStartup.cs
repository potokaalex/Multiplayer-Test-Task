using _dev;
using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Player;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Game.UI;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: Refactoring network communications

namespace CodeBase.Infrastructure.Game
{
    public class GameStartup : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameUIMediator _gameUIMediator;
        [SerializeField] private PlayerStaticData _playerStaticData;
        [SerializeField] private BulletStaticData _bulletStaticData;
        [SerializeField] private Transform[] _spawnPoints;
        private IPlayerUIMediator _uiMediator;

        private void Start()
        {
            PhotonPeer.RegisterType(typeof(PlayerColor), (byte)CustomRegisteredNetworkTypes.PlayerColor,
                PlayerColor.Serialize, PlayerColor.Deserialize);

            var bulletFactory = new BulletFactory(_bulletStaticData);

            _uiMediator = new PlayerUIFactory(_playerStaticData).CreateUIMediator();
            var playerObject =
                new PlayerObjectFactory(_playerStaticData, _spawnPoints).CreatePlayer(_uiMediator, bulletFactory,
                    PhotonNetwork.CurrentRoom.PlayerCount - 1);

            _uiMediator.InitializeUI(playerObject);
            _gameUIMediator.InitializeUI();
        }

        private void OnDestroy()
        {
            _gameUIMediator.DisposeUI();
            _uiMediator.DisposeUI();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            UnityEngine.Debug.Log($"Player {newPlayer.NickName} entered room!");
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            UnityEngine.Debug.Log($"Player {otherPlayer.NickName} left room!");
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            SceneManager.LoadScene("Lobby");
        }
    }
}