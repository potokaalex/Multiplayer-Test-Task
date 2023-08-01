using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    public class BulletNetwork : MonoBehaviourPun
    {
        public GameObject CreateBullet(BulletObject bulletObjectPrefab, Vector3 position) =>
            PhotonNetwork.Instantiate(bulletObjectPrefab.name, position, Quaternion.identity);

        public void DestroyBullet(BulletObject bullet) => PhotonNetwork.Destroy(bullet.gameObject);
    }
}