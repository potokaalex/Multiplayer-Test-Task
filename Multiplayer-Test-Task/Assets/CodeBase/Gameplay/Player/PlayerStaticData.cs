using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    [CreateAssetMenu(menuName = "Configuration/Player", fileName = "PlayerConfiguration")]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private PlayerObjectView _objectViewPrefab;
        [SerializeField] private PlayerUIMediator _uiMediatorPrefab;
        [SerializeField] private float _positionVelocity;

        public PlayerObjectView ObjectViewPrefab => _objectViewPrefab;

        public PlayerUIMediator UIMediatorPrefab => _uiMediatorPrefab;

        public float PositionVelocity => _positionVelocity;
    }
}