using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Game.UI
{
    public class LeaveRoomButton : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;
        private IGameUI _ui;

        public void Initialize(IGameUI ui)
        {
            _ui = ui;
            _selectableButton.onClick.AddListener(_ui.LeaveRoom);
        }

        public void Dispose() => _selectableButton.onClick.RemoveListener(_ui.LeaveRoom);
    }
}