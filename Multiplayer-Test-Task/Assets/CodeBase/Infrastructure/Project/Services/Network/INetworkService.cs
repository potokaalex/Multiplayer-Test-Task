using System;

namespace CodeBase.Infrastructure.Project.Services.Network
{
    public interface INetworkService
    {
        public void Initialize(string lobbySceneName, int maxPlayersInRoom);
        
        public void Connect(Action afterConnection);

        public void SetRoomName(string newRoomName);
        
        public bool IsRoomNameValid();

        public bool JoinOrCreateRoom();

        public void LoadGameScene(string gameSceneName);
    }
}