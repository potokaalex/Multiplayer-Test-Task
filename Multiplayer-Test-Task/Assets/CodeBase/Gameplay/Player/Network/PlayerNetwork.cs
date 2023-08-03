using System.Collections.Generic;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Infrastructure.Game.Network;
using CodeBase.Infrastructure.Game.States;
using CodeBase.Infrastructure.Project.Services.StateMachine;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Player.Network
{
    public class PlayerNetwork : MonoBehaviourPunCallbacks
    {
        private readonly List<int> _activePlayers = new();
        private PlayerObject _playerObject;
        private GameNetwork _gameNetwork;
        private IStateMachine _stateMachine;
        private bool _isWin;

        [Inject]
        private void Constructor(IStateMachine stateMachine, GameNetwork gameNetwork)
        {
            _stateMachine = stateMachine;
            _gameNetwork = gameNetwork;
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);

            if (!_isWin)
                photonView.RPC(nameof(RpcDestroyPlayer), RpcTarget.All, otherPlayer.ActorNumber);
        }

        public void Initialize(PlayerObject playerObject) => _playerObject = playerObject;

        public int GetPlayerIndex() => PhotonNetwork.CurrentRoom.PlayerCount - 1;

        public GameObject CreatePlayer(PlayerObject playerObjectPrefab, Vector3 position, NetworkColor color)
        {
            var player = PhotonNetwork.Instantiate(playerObjectPrefab.name, position, default);
            var playerViewId = player.GetPhotonView().ViewID;

            photonView.RPC(nameof(RpcConstructPlayer), RpcTarget.AllBuffered, playerViewId, color);

            return player;
        }

        public void DestroyPlayer()
        {
            var actorNumber = _playerObject.PhotonView.Controller.ActorNumber;

            PhotonNetwork.Destroy(_playerObject.gameObject);
            photonView.RPC(nameof(RpcDestroyPlayer), RpcTarget.All, actorNumber);
        }

        public void ChangeHealth(Photon.Realtime.Player player, int value) =>
            photonView.RPC(nameof(RpcChangeHealth), player, value);

        public void AddCoin(Photon.Realtime.Player player) => photonView.RPC(nameof(RpcAddCoin), player);

        [PunRPC]
        private void RpcConstructPlayer(int playerViewId, NetworkColor color)
        {
            var playerPhoton = PhotonNetwork.GetPhotonView(playerViewId);
            var playerObject = playerPhoton.GetComponent<PlayerObject>();

            playerObject.SetColor(color.GetValue());
            _activePlayers.Add(playerPhoton.Controller.ActorNumber);
        }

        [PunRPC]
        private void RpcDestroyPlayer(int actorNumber)
        {
            _activePlayers.Remove(actorNumber);

            if (!PhotonNetwork.IsMasterClient || _activePlayers.Count > 1)
                return;

            foreach (var player in PhotonNetwork.PlayerList)
            {
                if (player.ActorNumber == _activePlayers[0])
                {
                    photonView.RPC(nameof(RpcPlayerWin), player);
                    _isWin = true;
                }
            }
        }

        [PunRPC]
        private void RpcPlayerWin() =>
            _gameNetwork.StartGameOver(_playerObject.GetColor(), _playerObject.GetCoinsCount());

        [PunRPC]
        private void RpcChangeHealth(int value)
        {
            //bullets handle not only on the master client, so, because the ping, you can kill the player several times
            if (_playerObject.GetHealth() <= 0)
                return;

            _playerObject.ChangeHealth(value);

            if (_playerObject.GetHealth() <= 0)
                _stateMachine.SwitchTo<DeathState>();
        }

        [PunRPC]
        private void RpcAddCoin() => _playerObject.AddCoin();
    }
}