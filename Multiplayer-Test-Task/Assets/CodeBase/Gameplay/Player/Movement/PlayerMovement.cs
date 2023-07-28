using UnityEngine;

namespace CodeBase.Gameplay.Player.Movement
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _player;
        private readonly float _positionVelocity;

        public PlayerMovement(Rigidbody2D playerBody, float positionVelocity)
        {
            _player = playerBody;
            _positionVelocity = positionVelocity;
        }

        public void MovePosition(Vector2 inputVector)
        {
            var offset = inputVector * (Time.fixedDeltaTime * _positionVelocity);

            _player.transform.position += new Vector3(offset.x, offset.y);
        }

        public void MoveRotation(Vector2 inputVector)
        {
            var angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;

            _player.transform.rotation = new Quaternion { eulerAngles = new Vector3(0, 0, angle) };
        }
    }
}