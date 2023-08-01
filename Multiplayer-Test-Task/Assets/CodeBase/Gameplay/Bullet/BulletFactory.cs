using CodeBase.Gameplay.Player.Network;
using CodeBase.Infrastructure.Services.Data;
using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    public class BulletFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly BulletNetwork _bulletNetwork;
        private readonly PlayerNetwork _playerNetwork;
        private BulletStaticData _staticData;

        public BulletFactory(IDataProvider dataProvider, BulletNetwork bulletNetwork, PlayerNetwork playerNetwork)
        {
            _dataProvider = dataProvider;
            _bulletNetwork = bulletNetwork;
            _playerNetwork = playerNetwork;
        }

        public void Initialize() => _staticData = _dataProvider.Get<BulletStaticData>();

        public BulletObject CreateBullet(Vector3 position)
        {
            var gameObject = _bulletNetwork.CreateBullet(_staticData.BulletObjectPrefab, position);
            var bulletObject = gameObject.GetComponent<BulletObject>();

            bulletObject.Constructor(this, _playerNetwork, _staticData.CreationLayerID);

            return bulletObject;
        }

        public void DestroyBullet(BulletObject bullet) => _bulletNetwork.DestroyBullet(bullet);
    }
}