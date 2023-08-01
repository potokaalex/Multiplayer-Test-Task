using CodeBase.Gameplay.Player.Data;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Infrastructure.Game.States;
using CodeBase.Infrastructure.Services.StateMachine;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Player.Network
{
    public class PlayerNetwork : MonoBehaviourPun
    {
        private IStateMachine _stateMachine;
        private PlayerObject _playerObject;

        [Inject]
        private void Constructor(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public void Initialize(PlayerObject playerObject) => _playerObject = playerObject;

        public int GetPlayerIndex() => PhotonNetwork.CurrentRoom.PlayerCount - 1;

        public GameObject CreatePlayer(PlayerObject playerObjectPrefab, Vector3 position, PlayerColor color)
        {
            var player = PhotonNetwork.Instantiate(playerObjectPrefab.name, position, default);
            var playerViewId = player.GetPhotonView().ViewID;

            photonView.RPC(nameof(RpcConstructPlayer), RpcTarget.AllBuffered, playerViewId, color);

            return player;
        }

        public void ChangeHealth(Photon.Realtime.Player player, int value) =>
            photonView.RPC(nameof(RpcChangeHealth), player, value);

        public void AddCoin(Photon.Realtime.Player player) => photonView.RPC(nameof(RpcAddCoin), player);

        [PunRPC]
        private void RpcConstructPlayer(int playerViewId, PlayerColor color)
        {
            var playerPhoton = PhotonNetwork.GetPhotonView(playerViewId);
            var playerObject = playerPhoton.GetComponent<PlayerObject>();

            playerObject.SetColor(color);
        }

        [PunRPC]
        private void RpcChangeHealth(int value)
        {
            _playerObject.ChangeHealth(value);

            if (_playerObject.GetHealth() <= 0)
                _stateMachine.SwitchTo<DeathState>();
        }

        [PunRPC]
        private void RpcAddCoin() => _playerObject.AddCoin();
    }
}