using CodeBase.Gameplay.Player.Input;
using CodeBase.Gameplay.Player.Object;
using UnityEngine;

namespace CodeBase.Gameplay.Player.UI
{
    public class PlayerUIMediator : MonoBehaviour, IPlayerUIMediator
    {
        [SerializeField] private InputDevice _inputDevice;
        private PlayerObject _playerObject;

        public void InitializeUI(PlayerObject playerObject)
        {
            _playerObject = playerObject;

            _inputDevice.Initialize(this);
        }

        public void Move(Vector2 inputVector) => _playerObject.Move(inputVector);

        public void Rotate(Vector2 inputVector) => _playerObject.Rotate(inputVector);
    }
}