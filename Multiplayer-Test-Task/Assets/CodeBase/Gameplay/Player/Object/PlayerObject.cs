using CodeBase.Gameplay.Player.Coins;
using CodeBase.Gameplay.Player.Data;
using CodeBase.Gameplay.Player.Health;
using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Gameplay.Player.Weapon;
using CodeBase.Infrastructure.Game.Network;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private PhotonView _photonView;

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

        public Rigidbody2D Rigidbody => _rigidbody;

        public Transform BulletSpawnPoint => _bulletSpawnPoint;

        public PhotonView PhotonView => _photonView;

        public void Move(Vector2 inputVector) => _movement.MovePosition(inputVector);

        public void Rotate(Vector2 inputVector) => _movement.MoveRotation(inputVector);

        public void Shoot() => _weapon.Shoot();

        public void ChangeHealth(int value)
        {
            _health.Change(value);
            _ui.SetHealth(_health.Get());
        }

        public int GetHealth() => _health.Get();

        public void AddCoin()
        {
            _coins.Change(1);
            _ui.SetCoinsCount(_coins.Get());
        }

        public int GetCoinsCount() => _coins.Get();

        private void SetLayer(int layerID) => gameObject.layer = layerID;

        public void SetColor(Color color) => _spriteRenderer.color = color;

        public Color GetColor() => _spriteRenderer.color;
    }
}