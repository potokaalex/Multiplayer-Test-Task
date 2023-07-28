using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Lobby.UI
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;
        private LobbyUIMediator _mediator;

        public void Initialize(LobbyUIMediator mediator)
        {
            _mediator = mediator;
            _selectableButton.onClick.AddListener(_mediator.ApplicationExit);
        }
        
        public void Dispose() => _selectableButton.onClick.RemoveListener(_mediator.ApplicationExit);
    }
}