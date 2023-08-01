using CodeBase.Gameplay.Bullet;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Weapon
{
    public class PlayerWeapon : IPlayerWeapon
    {
        private readonly BulletFactory _bulletFactory;
        private readonly float _forceValue;
        private readonly int _damageValue;

        private Transform _bulletSpawnPoint;
        private Rigidbody2D _player;

        public PlayerWeapon(BulletFactory bulletFactory, float forceValue, int damageValue)
        {
            _bulletFactory = bulletFactory;
            _forceValue = forceValue;
            _damageValue = damageValue;
        }

        public void Initialize(Transform bulletSpawnPoint, Rigidbody2D player)
        {
            _bulletSpawnPoint = bulletSpawnPoint;
            _player = player;
        }

        public void Shoot()
        {
            var bullet = _bulletFactory.CreateBullet(_bulletSpawnPoint.position);

            bullet.Initialize(_player.transform.right, _forceValue, _damageValue);
        }
    }
}