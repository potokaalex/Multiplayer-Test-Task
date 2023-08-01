using CodeBase.Gameplay.Player.Data;
using CodeBase.Infrastructure.Game.States;
using CodeBase.Infrastructure.Services.StateMachine;
using CodeBase.Utilities.Network;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Game.Network
{
    public class GameNetwork : MonoBehaviourPunCallbacks
    {
        [SerializeField] private int MinPlayerCountToBattle;

        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);

            if (PhotonNetwork.PlayerList.Length >= MinPlayerCountToBattle)
                photonView.RPC(nameof(StartBattle), RpcTarget.All);
        }

        public void RegisterCustomTypes()
        {
            PhotonPeer.RegisterType(typeof(PlayerColor), CustomRegisteredNetworkTypes.PlayerColor,
                PlayerColor.Serialize, PlayerColor.Deserialize);
        }

        [PunRPC]
        private void StartBattle() => _stateMachine.SwitchTo<BattleState>();
    }
}