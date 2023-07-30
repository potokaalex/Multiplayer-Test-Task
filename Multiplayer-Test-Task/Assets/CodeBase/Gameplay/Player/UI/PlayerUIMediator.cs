using CodeBase.Gameplay.Player.Coins;
using CodeBase.Gameplay.Player.Health;
using CodeBase.Gameplay.Player.Input;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.Weapon;
using UnityEngine;

namespace CodeBase.Gameplay.Player.UI
{
    public class PlayerUIMediator : MonoBehaviour, IPlayerUIMediator
    {
        [SerializeField] private InputDevice _inputDevice;
        [SerializeField] private ShootButton _shootButton;
        [SerializeField] private HealthSlider _healthSlider;
        [SerializeField] private CoinsCountText _coinsCountText;
        private PlayerObject _playerObject;

        public void InitializeUI(PlayerObject playerObject)
        {
            _playerObject = playerObject;

            _inputDevice.Initialize(this);
            _shootButton.Initialize(this);
        }

        public void DisposeUI()
        {
            _shootButton.Dispose();
        }

        public void SetHealth(int value) => _healthSlider.SetHealth(value);

        public void SetCoinsCount(int value) => _coinsCountText.SetCoinsCount(value);

        public void Move(Vector2 inputVector) => _playerObject.Move(inputVector);

        public void Rotate(Vector2 inputVector) => _playerObject.Rotate(inputVector);

        public void Shoot() => _playerObject.Shoot();
    }
}