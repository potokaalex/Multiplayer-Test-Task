using CodeBase.Gameplay.Player.Object;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    public class BulletObject : MonoBehaviourPun
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        private BulletNetwork _network;
        private int _damageValue;

        public void Constructor(BulletNetwork network, int damageValue, int layerID)
        {
            _network = network;
            _damageValue = damageValue;

            SetLayer(layerID);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!photonView.IsMine)
                return;

            if (other.gameObject.TryGetComponent<PlayerObject>(out var playerObject))
                playerObject.RpcChangeHealth(_damageValue);

            _network.DestroyBullet(this);
        }

        public void AddForce(Vector2 direction, float force) =>
            _rigidbody.AddForce(direction * force);

        private void SetLayer(int layerID) => gameObject.layer = layerID;
    }
}