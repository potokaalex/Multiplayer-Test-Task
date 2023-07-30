using CodeBase.Gameplay.Player.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Input
{
    public abstract class InputDevice : MonoBehaviour
    {
        private protected Vector2 InputVectorDefaultValue;
        private protected Vector2 InputVector;
        private PlayerUI _ui;

        public void Initialize(PlayerUI ui)
        {
            _ui = ui;
            InputVectorDefaultValue = default;
        }

        private void FixedUpdate()
        {
            if (InputVector == InputVectorDefaultValue)
                return;

            _ui.Move(InputVector);
            _ui.Rotate(InputVector);
        }
    }
}