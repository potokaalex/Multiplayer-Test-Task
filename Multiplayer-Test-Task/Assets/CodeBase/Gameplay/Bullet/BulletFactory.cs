using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    public class BulletFactory
    {
        private readonly BulletStaticData _staticData;

        public BulletFactory(BulletStaticData staticData)
        {
            _staticData = staticData;
        }

        public BulletObject CreateBullet(Vector3 position, int damageValue)
        {
            var gameObject = NetworkInstantiate(position);
            var bulletObject = gameObject.GetComponent<BulletObject>();

            bulletObject.Constructor(damageValue, _staticData.CreationLayerID);

            return bulletObject;
        }

        private GameObject NetworkInstantiate(Vector3 position) =>
            PhotonNetwork.Instantiate(_staticData.BulletObjectPrefab.name, position, Quaternion.identity);
    }
}