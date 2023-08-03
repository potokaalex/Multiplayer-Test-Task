using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Project.Services.Data;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Data
{
    [CreateAssetMenu(menuName = "Configuration/Player", fileName = "PlayerConfiguration")]
    public class PlayerStaticData : ScriptableObject, IDataToProvide
    {
        [SerializeField] private PlayerObject _playerObjectPrefab;
        [SerializeField] private PlayerUI _uiPrefab;
        [SerializeField] private int _creationLayerID;
        [SerializeField] private Color[] _playerColors;
        [SerializeField] private float _positionVelocity;
        [SerializeField] private float _bulletForceValue;
        [SerializeField] private int _bulletDamageValue;
        [SerializeField] private int _maxHealth;

        public PlayerObject PlayerObjectPrefab => _playerObjectPrefab;

        public PlayerUI UIPrefab => _uiPrefab;

        public int CreationLayerID => _creationLayerID;

        public Color[] PlayerColors => _playerColors;

        public float PositionVelocity => _positionVelocity;

        public float BulletForceValue => _bulletForceValue;

        public int BulletDamageValue => _bulletDamageValue;

        public int MaxHealth => _maxHealth;
    }
}