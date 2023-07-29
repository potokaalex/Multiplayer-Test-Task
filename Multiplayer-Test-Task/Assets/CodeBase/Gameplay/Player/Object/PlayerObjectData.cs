using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectData : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _bulletSpawnPoint;

        public Rigidbody2D Rigidbody => _rigidbody;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Transform BulletSpawnPoint => _bulletSpawnPoint;
    }
}