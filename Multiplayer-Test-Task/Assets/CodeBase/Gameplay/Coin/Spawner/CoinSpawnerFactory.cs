using CodeBase.Gameplay.Coin.Data;

namespace CodeBase.Gameplay.Coin.Spawner
{
    public class CoinSpawnerFactory
    {
        private readonly CoinStaticData _staticData;

        public CoinSpawnerFactory(CoinStaticData staticData) => _staticData = staticData;

        public CoinSpawner CreateSpawner() => UnityEngine.Object.Instantiate(_staticData.CoinSpawnerPrefab);

        public void DestroySpawner(CoinSpawner spawner) => UnityEngine.Object.Destroy(spawner);
    }
}