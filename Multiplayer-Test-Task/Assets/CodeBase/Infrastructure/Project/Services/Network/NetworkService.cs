using System;
using Photon.Pun;
using Photon.Realtime;

namespace CodeBase.Infrastructure.Project.Services.Network
{
    public class NetworkService : MonoBehaviourPunCallbacks, INetworkService
    {
        private Action _afterConnectionAction;
        private Action _afterJoinRoomAction;
        private string _lobbySceneName;
        private string _roomName;
        private int _maxPlayersInRoom;

        public void Initialize(string lobbySceneName, int maxPlayersInRoom)
        {
            _lobbySceneName = lobbySceneName;
            _maxPlayersInRoom = maxPlayersInRoom;
        }

        public void Connect(Action afterConnection)
        {
            PhotonNetwork.ConnectUsingSettings();
            _afterConnectionAction = afterConnection;
        }

        public void SetRoomName(string roomName) => _roomName = roomName;

        public bool IsRoomNameValid() => !string.IsNullOrEmpty(_roomName);

        public bool JoinOrCreateRoom() =>
            PhotonNetwork.JoinOrCreateRoom(_roomName, new RoomOptions { MaxPlayers = _maxPlayersInRoom },
                new TypedLobby(_lobbySceneName, LobbyType.Default));

        public void LoadGameScene(string gameSceneName)
        {
            if (PhotonNetwork.InRoom)
                PhotonNetwork.LoadLevel(gameSceneName);
            else
                _afterJoinRoomAction = () => LoadGameScene(gameSceneName);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            _afterConnectionAction?.Invoke();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            _afterJoinRoomAction?.Invoke();
        }
    }
}