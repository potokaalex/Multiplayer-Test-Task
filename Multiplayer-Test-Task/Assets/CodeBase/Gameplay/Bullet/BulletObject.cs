using CodeBase.Gameplay.Player.Network;
using CodeBase.Gameplay.Player.Object;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    public class BulletObject : MonoBehaviourPun
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        private BulletFactory _bulletFactory;
        private PlayerNetwork _playerNetwork;
        private int _damageValue;

        public void Constructor(BulletFactory bulletFactory, PlayerNetwork playerNetwork, int layerID)
        {
            _bulletFactory = bulletFactory;
            _playerNetwork = playerNetwork;

            SetLayer(layerID);
        }

        public void Initialize(Vector2 direction, float force, int damageValue)
        {
            _rigidbody.AddForce(direction * force);
            _damageValue = damageValue;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!photonView.IsMine)
                return;

            if (other.gameObject.TryGetComponent<PlayerObject>(out var playerObject))
                _playerNetwork.ChangeHealth(playerObject.PhotonView.Controller, _damageValue);

            _bulletFactory.DestroyBullet(this);
        }

        private void SetLayer(int layerID) => gameObject.layer = layerID;
    }
}