using System;
using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Coin;
using CodeBase.Gameplay.Coin.Network;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Infrastructure.Game.States;
using CodeBase.Infrastructure.Services.StateMachine;
using Photon.Pun;
using Photon.Realtime;
using Zenject;

namespace CodeBase._dev
{
    public class GameNetwork : MonoBehaviourPunCallbacks
    {
        public BulletNetwork BulletNetwork;
        public CoinNetwork CoinNetwork;
        public int MinPlayerCountToBattle;
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);

            if (PhotonNetwork.PlayerList.Length >= MinPlayerCountToBattle)
                photonView.RPC(nameof(StartBattle), RpcTarget.All);
        }

        [PunRPC]
        private void StartBattle()
        {
            _stateMachine.SwitchTo<BattleState>();
        }
    }
}