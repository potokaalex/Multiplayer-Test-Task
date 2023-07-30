using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    public class BulletNetwork : MonoBehaviourPun
    {
        private BulletFactory _factory;

        public void Initialize(BulletFactory factory) => _factory = factory;

        public BulletObject CreateBullet(Vector3 position, int damageValue) =>
            _factory.NetworkCreateBullet(this, position, damageValue);

        public void DestroyBullet(BulletObject bullet) => _factory.NetworkDestroyBullet(bullet);
    }
}