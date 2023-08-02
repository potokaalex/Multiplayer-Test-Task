using CodeBase.Infrastructure.Game.Network;
using UnityEngine;

namespace CodeBase.Infrastructure.Game.UI
{
    public class WaitingUI : MonoBehaviour, IGameUI
    {
        [SerializeField] private LeaveRoomButton _leaveRoomButton;
        private GameNetwork _gameNetwork;

        public void Constructor(GameNetwork gameNetwork) => _gameNetwork = gameNetwork;

        public void InitializeUI() => _leaveRoomButton.Initialize(this);

        public void DisposeUI() => _leaveRoomButton.Dispose();

        public void LeaveRoom() => _gameNetwork.LeaveRoom();
    }
}