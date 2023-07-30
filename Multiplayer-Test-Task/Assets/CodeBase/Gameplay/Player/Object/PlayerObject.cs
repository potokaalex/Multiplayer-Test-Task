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

        private IPlayerUI _ui;
        private PlayerMovement _movement;
        private IPlayerWeapon _weapon;
        private PlayerHealth _health;
        private PlayerCoins _coins;

        public void Constructor(IPlayerUI ui, PlayerMovement movement, IPlayerWeapon weapon,
            PlayerHealth health, PlayerCoins coins, int layerID)
        {
            _ui = ui;
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
            _ui.SetCoinsCount(_coins.Get());
        }

        [PunRPC]
        private void ChangeHealth(int value)
        {
            if (!photonView.IsMine)
                return;

            _health.Change(value);
            _ui.SetHealth(_health.Get());
            
            //if(_health.Get() <= 0)
                //+state
        }

        private void SetLayer(int layerID) => gameObject.layer = layerID;
    }
}