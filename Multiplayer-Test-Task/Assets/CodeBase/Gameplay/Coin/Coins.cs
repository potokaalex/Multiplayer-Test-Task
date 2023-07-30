using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Coin
{
    public class Coins
    {
        private readonly Dictionary<int, CoinObject> _coins = new();
        private readonly int _maxCount;

        public Coins(int maxCount)
        {
            _maxCount = maxCount;
        }

        public int MaxCount => _maxCount;

        public int CurrentCount => _coins.Count;

        public void RegisterCoin(CoinObject coin) => _coins.Add(coin.Id, coin);

        public void UnregisterCoin(int coinId) => _coins.Remove(coinId);

        public int GetCoinId()
        {
            var id = Random.Range(0, _maxCount);

            if (!_coins.ContainsKey(id))
                return id;

            for (var i = 0; i < _maxCount; i++)
                if (!_coins.ContainsKey(i))
                    return i;

            return -1;
        }
    }
}