using CodeBase.Gameplay.Coin.Object;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Coin.Network
{
    public class CoinNetwork : MonoBehaviourPun
    {
        public bool IsMasterClient() => PhotonNetwork.IsMasterClient;

        public CoinObject CreateCoin(CoinObject coinObjectPrefab, Vector3 position)
        {
            var coinGameObject = PhotonNetwork.Instantiate(coinObjectPrefab.name, position, Quaternion.identity);
            var coin = coinGameObject.GetComponent<CoinObject>();

            return coin;
        }

        public void DestroyCoin(CoinObject coinObject) => PhotonNetwork.Destroy(coinObject.gameObject);
    }
}