using TMPro;
using UnityEngine;

namespace CodeBase.Infrastructure.Lobby.UI
{
    public class RoomNameInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _field;
        private LobbyUIMediator _mediator;

        public void Initialize(LobbyUIMediator mediator)
        {
            _mediator = mediator;
            _field.onDeselect.AddListener(_mediator.SetRoomName);
        }

        public void Dispose() => _field.onDeselect.RemoveListener(_mediator.SetRoomName);
    }
}