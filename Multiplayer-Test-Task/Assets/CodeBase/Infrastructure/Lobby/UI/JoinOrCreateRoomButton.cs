using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Lobby.UI
{
    public class JoinOrCreateRoomButton : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;
        private LobbyUI _mediator;

        public void Initialize(LobbyUI mediator)
        {
            _mediator = mediator;
            _selectableButton.onClick.AddListener(_mediator.JoinOrCreateRoom);
        }

        public void Dispose() => _selectableButton.onClick.RemoveListener(_mediator.JoinOrCreateRoom);
    }
}