using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Lobby.UI
{
    public class JoinOrCreateRoomButton : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;
        private LobbyUIMediator _mediator;

        public void Initialize(LobbyUIMediator mediator)
        {
            _mediator = mediator;
            _selectableButton.onClick.AddListener(_mediator.JoinOrCreateRoom);
        }

        public void Dispose() => _selectableButton.onClick.RemoveListener(_mediator.JoinOrCreateRoom);
    }
}