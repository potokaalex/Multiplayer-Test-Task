using CodeBase.Infrastructure.Game.UI;
using CodeBase.Infrastructure.Services.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Game.Data
{
    [CreateAssetMenu(menuName = "Configuration/Game", fileName = "GameConfiguration")]
    public class GameSceneStaticData : ScriptableObject, IDataToProvide
    {
        [SerializeField] private WaitingUI _waitingUIPrefab;
        [SerializeField] private GameOverUI _gameOverUIPrefab;
        [SerializeField] private int _minPlayerCountToBattle;

        public WaitingUI WaitingUIPrefab => _waitingUIPrefab;
        
        public GameOverUI GameOverUIPrefab => _gameOverUIPrefab;
        
        public int MinPlayerCountToBattle => _minPlayerCountToBattle;
    }
}