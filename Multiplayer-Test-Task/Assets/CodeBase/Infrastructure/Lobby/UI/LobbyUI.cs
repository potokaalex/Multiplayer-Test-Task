using CodeBase.Infrastructure.Project.Services.Network;
using CodeBase.Infrastructure.Project.Services.StateMachine;
using CodeBase.Infrastructure.Project.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Lobby.UI
{
    public class LobbyUI : MonoBehaviour
    {
        [SerializeField] private RoomNameInputField _roomNameInputField;
        [SerializeField] private JoinOrCreateRoomButton _joinOrCreateRoomButton;
        [SerializeField] private ExitButton _exitButton;
        private IStateMachine _stateMachine;
        private INetworkService _networkService;

        [Inject]
        private void Constructor(INetworkService networkService, IStateMachine stateMachine)
        {
            _networkService = networkService;
            _stateMachine = stateMachine;
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

        public void SetRoomName(string roomName) => _networkService.SetRoomName(roomName);

        public void JoinOrCreateRoom()
        {
            if (_networkService.IsRoomNameValid())
                if (_networkService.JoinOrCreateRoom())
                    _stateMachine.SwitchTo<LoadGameState>();
        }

        public void ApplicationExit() => _stateMachine.SwitchTo<ApplicationExitState>();
    }
}