using UnityEngine;

namespace CodeBase.Gameplay.Coin
{
    [CreateAssetMenu(menuName = "Configuration/Coin", fileName = "CoinConfiguration")]
    public class CoinStaticData : ScriptableObject
    {
        public CoinObject CoinObjectPrefab;
        public float SpawnRateSeconds;
    }
}