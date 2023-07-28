using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObject
    {
        private readonly IPlayerUIMediator _uiMediator;
        private readonly PlayerMovement _movement;

        public PlayerObject(IPlayerUIMediator uiMediator, PlayerMovement movement)
        {
            _uiMediator = uiMediator;
            _movement = movement;
        }

        public void Move(Vector2 inputVector) => _movement.MovePosition(inputVector);

        public void Rotate(Vector2 inputVector) => _movement.MoveRotation(inputVector);
    }
}