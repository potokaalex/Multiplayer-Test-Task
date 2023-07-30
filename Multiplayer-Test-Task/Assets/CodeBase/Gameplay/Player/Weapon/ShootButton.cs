using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Gameplay.Player.Weapon
{
    public class ShootButton : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;
        
        private PlayerObject _playerObject;
        private PlayerUI _ui;

        public void Initialize(PlayerUI ui)
        {
            _ui = ui;
            _selectableButton.onClick.AddListener(Shoot);
        }

        public void Dispose() => _selectableButton.onClick.RemoveListener(Shoot);

        private void Shoot() => _ui.Shoot();
    }
}