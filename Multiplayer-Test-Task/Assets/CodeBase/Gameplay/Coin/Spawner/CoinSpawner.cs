using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Coin.Network;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Coin.Spawner
{
    public class CoinSpawner : MonoBehaviour
    {
        private CoinStaticData _staticData;
        private CoinNetwork _network;
        private Coins _coins;
        private float _timeToSpawn;

        public void Constructor(CoinStaticData staticData, CoinNetwork network, Coins coins)
        {
            _staticData = staticData;
            _network = network;
            _coins = coins;
        }

        private void FixedUpdate()
        {
            if (_timeToSpawn >= 0)
            {
                _timeToSpawn -= Time.fixedDeltaTime;
                return;
            }

            _timeToSpawn = _staticData.SpawnRateSeconds;

            if (!PhotonNetwork.IsMasterClient)
                return;

            //TODO: sync on all clients
            
            if (_coins.CurrentCount >= _coins.MaxCount)
                return;

            _network.CreateCoin();
        }
    }
}