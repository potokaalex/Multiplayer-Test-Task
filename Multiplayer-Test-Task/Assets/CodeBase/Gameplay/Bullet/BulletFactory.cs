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

        public BulletObject NetworkCreateBullet(BulletNetwork network, Vector3 position, int damageValue)
        {
            var gameObject = NetworkInstantiate(position);
            var bulletObject = gameObject.GetComponent<BulletObject>();

            bulletObject.Constructor(network, damageValue, _staticData.CreationLayerID);

            return bulletObject;
        }

        public void NetworkDestroyBullet(BulletObject bullet) => PhotonNetwork.Destroy(bullet.gameObject);

        private GameObject NetworkInstantiate(Vector3 position) =>
            PhotonNetwork.Instantiate(_staticData.BulletObjectPrefab.name, position, Quaternion.identity);
    }
}