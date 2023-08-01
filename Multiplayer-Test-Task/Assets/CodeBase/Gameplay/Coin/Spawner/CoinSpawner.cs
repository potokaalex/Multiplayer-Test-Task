using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Coin.Object;
using UnityEngine;

namespace CodeBase.Gameplay.Coin.Spawner
{
    public class CoinSpawner : MonoBehaviour
    {
        private CoinObjectFactory _coinObjectFactory;
        private CoinStaticData _staticData;
        private float _timeToSpawn;

        public void Constructor(CoinObjectFactory coinObjectFactory, CoinStaticData staticData)
        {
            _coinObjectFactory = coinObjectFactory;
            _staticData = staticData;
        }

        private void FixedUpdate()
        {
            if (_timeToSpawn >= 0)
            {
                _timeToSpawn -= Time.fixedDeltaTime;
                return;
            }

            _timeToSpawn = _staticData.SpawnRateSeconds;

            _coinObjectFactory.CreateCoin();
        }
    }
}