using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObject : MonoBehaviour
    {
        [SerializeField] private PlayerObjectData _objectData;

        private IPlayerUIMediator _uiMediator;
        private PlayerMovement _movement;

        public void Constructor(IPlayerUIMediator uiMediator, PlayerMovement movement)
        {
            _uiMediator = uiMediator;
            _movement = movement;
        }

        public void Initialize(PlayerColor color) => _objectData.SpriteRenderer.color = color.GetValue();

        public void Move(Vector2 inputVector) => _movement.MovePosition(inputVector);

        public void Rotate(Vector2 inputVector) => _movement.MoveRotation(inputVector);
    }
}