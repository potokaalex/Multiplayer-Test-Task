using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    [CreateAssetMenu(menuName = "Configuration/Player", fileName = "PlayerConfiguration")]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private PlayerObject _playerObjectPrefab;
        [SerializeField] private PlayerUIMediator _uiMediatorPrefab;
        [SerializeField] private int _creationLayerID;
        [SerializeField] private Color[] _playerColors;
        [SerializeField] private float _positionVelocity;

        public PlayerObject PlayerObjectPrefab => _playerObjectPrefab;

        public PlayerUIMediator UIMediatorPrefab => _uiMediatorPrefab;

        public int CreationLayerID => _creationLayerID;

        public Color[] PlayerColors => _playerColors;

        public float PositionVelocity => _positionVelocity;
    }
}