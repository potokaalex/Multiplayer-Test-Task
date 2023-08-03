using CodeBase.Infrastructure.Game.Data;
using CodeBase.Infrastructure.Game.States;
using CodeBase.Infrastructure.Game.States.GameOver;
using CodeBase.Infrastructure.Project.Services.Data;
using CodeBase.Infrastructure.Project.Services.Network;
using CodeBase.Infrastructure.Project.Services.StateMachine;
using CodeBase.Infrastructure.Project.States;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Game.Network
{
    public class GameNetwork : MonoBehaviourPunCallbacks
    {
        private GameSceneStaticData _gameSceneStaticData;
        private IStateMachine _stateMachine;
        private IDataProvider _dataProvider;
        [Inject]
        private void Constructor(IStateMachine stateMachine, IDataProvider dataProvider)
        {
            _stateMachine = stateMachine;
            _dataProvider = dataProvider;
        }

        public void Initialize() => _gameSceneStaticData = _dataProvider.Get<GameSceneStaticData>();

        public override void OnPlayerEnteredRoom(Player otherPlayer)
        {
            base.OnPlayerEnteredRoom(otherPlayer);

            if (PhotonNetwork.PlayerList.Length >= _gameSceneStaticData.MinPlayerCountToBattle)
                photonView.RPC(nameof(RpcStartBattle), RpcTarget.All);
        }

        public void RegisterCustomTypes()
        {
            PhotonPeer.RegisterType(typeof(NetworkColor), CustomRegisteredNetworkTypes.NetworkColor,
                NetworkColor.Serialize, NetworkColor.Deserialize);
        }

        public void StartGameOver(Color winnerColor, int winnerCoinsCount)
        {
            var color = new NetworkColor(winnerColor);

            photonView.RPC(nameof(RpcStartGameOver), RpcTarget.All, color, winnerCoinsCount);
        }

        [PunRPC]
        private void RpcStartBattle() => _stateMachine.SwitchTo<BattleState>();

        [PunRPC]
        private void RpcStartGameOver(NetworkColor winnerColor, int winnerCoinsCount)
        {
            _stateMachine.SwitchTo<GameOverState, GameOverStateParameter>(new GameOverStateParameter
            {
                WinnerColor = winnerColor.GetValue(),
                WinnerCoinsCount = winnerCoinsCount
            });
        }
        
        public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    }
}