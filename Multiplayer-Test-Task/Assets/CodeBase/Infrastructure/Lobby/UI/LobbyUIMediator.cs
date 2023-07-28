using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Lobby.UI
{
    public class LobbyUIMediator : MonoBehaviour
    {
        [SerializeField] private RoomNameInputField _roomNameInputField;
        [SerializeField] private JoinOrCreateRoomButton _joinOrCreateRoomButton;
        [SerializeField] private ExitButton _exitButton;

        //TODO: create models & states

        private string _roomName;

        [Inject]
        private void Constructor()
        {
        }

        public void InitializeUI()
        {
            _roomNameInputField.Initialize(this);
            _joinOrCreateRoomButton.Initialize(this);
            _exitButton.Initialize(this);
        }

        public void DisposeUI()
        {
            _roomNameInputField.Dispose();
            _joinOrCreateRoomButton.Dispose();
            _exitButton.Dispose();
        }

        public void SetRoomName(string name)
        {
            _roomName = name;
        }

        public void JoinOrCreateRoom()
        {
            if (string.IsNullOrEmpty(_roomName))
                return;
            
            PhotonNetwork.JoinOrCreateRoom(_roomName, new RoomOptions { MaxPlayers = 2 },
                new TypedLobby("Lobby", LobbyType.Default));
        }

        public void ApplicationExit()
#if UNITY_EDITOR
            => UnityEditor.EditorApplication.isPlaying = false;
#else
            => UnityEngine.Application.Quit();
#endif
    }
}