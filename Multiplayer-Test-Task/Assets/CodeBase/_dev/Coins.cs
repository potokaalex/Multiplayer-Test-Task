using System.Collections.Generic;
using CodeBase.Gameplay.Coin.Object;
using UnityEngine;

namespace CodeBase.Gameplay.Coin.Data
{
    public class Coins
    {
        private readonly Dictionary<CoinObject, int> _coins = new();
        private readonly int _maxCount;

        public Coins(int maxCount) => _maxCount = maxCount;

        public bool IsCanCreateCoin => _coins.Count < _maxCount;

        public void RegisterCoin(CoinObject coinObject, int coinId) => _coins.Add(coinObject, coinId);

        public void UnregisterCoin(CoinObject coinObject) => _coins.Remove(coinObject);

        public int GetNewCoinId()
        {
            var id = Random.Range(0, _maxCount);

            if (!_coins.ContainsValue(id))
                return id;

            for (var i = 0; i < _maxCount; i++)
                if (!_coins.ContainsValue(i))
                    return i;

            return -1;
        }
    }
}