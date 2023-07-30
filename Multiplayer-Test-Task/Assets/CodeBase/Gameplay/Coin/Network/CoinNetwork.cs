using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Coin.Object;
using Photon.Pun;

namespace CodeBase.Gameplay.Coin.Network
{
    public class CoinNetwork : MonoBehaviourPun
    {
        private CoinObjectFactory _objectFactory;
        private Coins _coins;

        public void Initialize(CoinObjectFactory objectFactory, Coins coins)
        {
            _objectFactory = objectFactory;
            _coins = coins;
        }

        public void CreateCoin()
        {
            var coin = _objectFactory.NetworkCreateCoin(this, _coins.GetCoinId());
            _coins.RegisterCoin(coin);
        }

        public void DestroyCoin(CoinObject coinObject)
        {
            _coins.UnregisterCoin(coinObject.Id);
            _objectFactory.NetworkDestroyCoin(coinObject);
        }
    }
}