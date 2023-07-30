using CodeBase.Gameplay.Bullet;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Weapon
{
    public class PlayerWeapon : IPlayerWeapon
    {
        private readonly BulletNetwork _network;
        private readonly Transform _bulletSpawnPoint;
        private readonly Rigidbody2D _player;
        private readonly float _forceValue;
        private readonly int _damageValue;

        public PlayerWeapon(BulletNetwork network, Transform bulletSpawnPoint,
            Rigidbody2D playerBody, float forceValue, int damageValue)
        {
            _network = network;
            _bulletSpawnPoint = bulletSpawnPoint;
            _player = playerBody;
            _forceValue = forceValue;
            _damageValue = damageValue;
        }

        public void Shoot()
        {
            var bullet = _network.CreateBullet(_bulletSpawnPoint.position, _damageValue);

            bullet.AddForce(_player.transform.right, _forceValue);
        }
    }
}