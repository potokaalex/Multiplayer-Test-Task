using CodeBase.Gameplay.Player.Interact;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectView : MonoBehaviour
    {
        [SerializeField] private PlayerCollisionHandler _collisionHandler;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private Rigidbody2D _rigidbody;

        public PlayerCollisionHandler CollisionHandler => _collisionHandler;
        
        public Transform BulletSpawnPoint => _bulletSpawnPoint;
       
        public Rigidbody2D Rigidbody => _rigidbody;
    }
}