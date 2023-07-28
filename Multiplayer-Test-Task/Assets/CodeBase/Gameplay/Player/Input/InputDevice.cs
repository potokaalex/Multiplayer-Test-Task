using CodeBase.Gameplay.Player.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Input
{
    public abstract class InputDevice : MonoBehaviour
    {
        private protected Vector2 InputVectorDefaultValue;
        private protected Vector2 InputVector;
        private PlayerUIMediator _uiMediator;

        public void Initialize(PlayerUIMediator uiMediator)
        {
            _uiMediator = uiMediator;
            InputVectorDefaultValue = default;
        }

        private void FixedUpdate()
        {
            if (InputVector == InputVectorDefaultValue)
                return;

            _uiMediator.Move(InputVector);
            _uiMediator.Rotate(InputVector);
        }
    }
}