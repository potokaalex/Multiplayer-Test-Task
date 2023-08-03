using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Coin.Object;
using CodeBase.Infrastructure.Project.Services.Data;

namespace CodeBase.Gameplay.Coin.Spawner
{
    public class CoinSpawnerFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly CoinObjectFactory _coinObjectFactory;
        private CoinStaticData _coinStaticData;

        public CoinSpawnerFactory(IDataProvider dataProvider, CoinObjectFactory coinObjectFactory)
        {
            _dataProvider = dataProvider;
            _coinObjectFactory = coinObjectFactory;
        }

        public void Initialize() => _coinStaticData = _dataProvider.Get<CoinStaticData>();

        public CoinSpawner CreateSpawner()
        {
            var spawner = UnityEngine.Object.Instantiate(_coinStaticData.CoinSpawnerPrefab);

            spawner.Constructor(_coinObjectFactory, _coinStaticData);

            return spawner;
        }

        public void DestroySpawner(CoinSpawner spawner) => UnityEngine.Object.Destroy(spawner);
    }
}