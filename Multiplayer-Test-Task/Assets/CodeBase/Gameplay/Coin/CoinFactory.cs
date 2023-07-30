using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Coin
{
    public class CoinFactory
    {
        private readonly CoinStaticData _staticData;
        private readonly Transform[] _spawnPoints;

        public CoinFactory(CoinStaticData staticData, Transform[] spawnPoints)
        {
            _staticData = staticData;
            _spawnPoints = spawnPoints;
        }

        public CoinObject NetworkCreateCoin(CoinNetwork network, int id)
        {
            var gameObject = NetworkInstantiate(id);
            var coin = gameObject.GetComponent<CoinObject>();

            coin.Constructor(network, id);

            return coin;
        }

        public void NetworkDestroyCoin(CoinObject coinObject) => PhotonNetwork.Destroy(coinObject.gameObject);

        private GameObject NetworkInstantiate(int id)
        {
            var name = _staticData.CoinObjectPrefab.name;
            var position = _spawnPoints[id].position;
            var gameObject = PhotonNetwork.Instantiate(name, position, Quaternion.identity);

            return gameObject;
        }
    }
}