using CodeBase.Gameplay.Player.Coins;
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
        private PlayerCoins _coins;

        public void Constructor(IPlayerUIMediator uiMediator, PlayerMovement movement, IPlayerWeapon weapon,
            PlayerHealth health,PlayerCoins coins, int layerID)
        {
            _uiMediator = uiMediator;
            _movement = movement;
            _weapon = weapon;
            _health = health;
            _coins = coins;
            
            SetLayer(layerID);
        }

        public void Initialize(PlayerColor color) => _objectData.SpriteRenderer.color = color.GetValue();

        public void Move(Vector2 inputVector) => _movement.MovePosition(inputVector);

        public void Rotate(Vector2 inputVector) => _movement.MoveRotation(inputVector);

        public void Shoot() => _weapon.Shoot();

        public void RpcAddCoin() =>
            photonView.RPC(nameof(AddCoin), RpcTarget.All);

        public void RpcChangeHealth(int value) =>
            photonView.RPC(nameof(ChangeHealth), RpcTarget.All, value);

        [PunRPC]
        private void AddCoin()
        {
            if (!photonView.IsMine)
                return;

            _coins.Change(1);
            _uiMediator.SetCoinsCount(_coins.Get());
        }

        [PunRPC]
        private void ChangeHealth(int value)
        {
            if (!photonView.IsMine)
                return;

            _health.Change(value);
            _uiMediator.SetHealth(_health.Get());
        }

        private void SetLayer(int layerID) => gameObject.layer = layerID;
    }
}