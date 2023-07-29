using CodeBase.Gameplay.Player.Health;
using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Gameplay.Player.Weapon;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObject : MonoBehaviourPun
    {
        [SerializeField] private PlayerObjectData _objectData;

        private IPlayerUIMediator _uiMediator;
        private PlayerMovement _movement;
        private IPlayerWeapon _weapon;
        private PlayerHealth _health;

        public void Constructor(IPlayerUIMediator uiMediator, PlayerMovement movement, IPlayerWeapon weapon,
            PlayerHealth health, int layerID)
        {
            _uiMediator = uiMediator;
            _movement = movement;
            _weapon = weapon;
            _health = health;

            SetLayer(layerID);
        }

        public void Initialize(PlayerColor color) => _objectData.SpriteRenderer.color = color.GetValue();

        public void Move(Vector2 inputVector) => _movement.MovePosition(inputVector);

        public void Rotate(Vector2 inputVector) => _movement.MoveRotation(inputVector);

        private void SetLayer(int layerID) => gameObject.layer = layerID;

        public void Shoot() => _weapon.Shoot();

        public void RpcChangeHealth(int value) =>
            photonView.RPC(nameof(ChangeHealth), RpcTarget.All, value);

        [PunRPC]
        private void ChangeHealth(int value)
        {
            if (!photonView.IsMine)
                return;

            _health.Change(value);
            _uiMediator.SetHealth(_health.Get());
        }
    }
}