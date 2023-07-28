using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Game.UI
{
    public class LeaveRoomButton : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;
        private GameUIMediator _mediator;

        public void Initialize(GameUIMediator mediator)
        {
            _mediator = mediator;
            _selectableButton.onClick.AddListener(_mediator.LeaveRoom);
        }

        public void Dispose() => _selectableButton.onClick.RemoveListener(_mediator.LeaveRoom);
    }
}