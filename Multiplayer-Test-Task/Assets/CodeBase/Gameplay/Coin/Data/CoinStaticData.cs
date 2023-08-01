using CodeBase.Gameplay.Coin.Object;
using CodeBase.Gameplay.Coin.Spawner;
using CodeBase.Infrastructure.Services.Data;
using UnityEngine;

namespace CodeBase.Gameplay.Coin.Data
{
    [CreateAssetMenu(menuName = "Configuration/Coin", fileName = "CoinConfiguration")]
    public class CoinStaticData : ScriptableObject, IDataToProvide
    {
        public CoinSpawner CoinSpawnerPrefab;
        public CoinObject CoinObjectPrefab;
        public float SpawnRateSeconds;
    }
}