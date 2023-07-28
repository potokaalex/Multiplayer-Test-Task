using Photon.Pun;
using UnityEngine;

namespace CodeBase.Infrastructure.Game.UI
{
    public class GameUIMediator : MonoBehaviour
    {
        [SerializeField] private LeaveRoomButton _leaveRoomButton;
        
        public void InitializeUI()
        {
            _leaveRoomButton.Initialize(this);
        }

        public void DisposeUI()
        {
            _leaveRoomButton.Dispose();
        }
        
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}