using Photon.Pun;

namespace CodeBase.Gameplay.Coin
{
    public class CoinNetwork : MonoBehaviourPun
    {
        private CoinFactory _factory;
        private Coins _coins;

        public void Constructor(CoinFactory factory, Coins coins)
        {
            _factory = factory;
            _coins = coins;
        }

        public void CreateCoin()
        {
            var coin = _factory.NetworkCreateCoin(this, _coins.GetCoinId());
            _coins.RegisterCoin(coin);
        }

        public void DestroyCoin(CoinObject coinObject)
        {
            _coins.UnregisterCoin(coinObject.Id);
            _factory.NetworkDestroyCoin(coinObject);
        }
    }
}