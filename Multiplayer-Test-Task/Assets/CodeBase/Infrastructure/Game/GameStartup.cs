using _dev;
using CodeBase.Gameplay.Player;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Game.UI;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Game
{
    public class GameStartup : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameUIMediator _gameUIMediator;
        [SerializeField] private PlayerStaticData _playerStaticData;
        [SerializeField] private Transform[] _spawnPoints;

        private void Start()
        {
            PhotonPeer.RegisterType(typeof(PlayerColor), (byte)CustomRegisteredNetworkTypes.PlayerColor,
                PlayerColor.Serialize, PlayerColor.Deserialize);

            var uiMediator = new PlayerUIFactory(_playerStaticData).CreateUIMediator();
            var playerObject =
                new PlayerObjectFactory(_playerStaticData, _spawnPoints).CreatePlayer(uiMediator,
                    PhotonNetwork.CurrentRoom.PlayerCount - 1);

            uiMediator.InitializeUI(playerObject);
            _gameUIMediator.InitializeUI();
        }

        private void OnDestroy()
        {
            _gameUIMediator.DisposeUI();
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