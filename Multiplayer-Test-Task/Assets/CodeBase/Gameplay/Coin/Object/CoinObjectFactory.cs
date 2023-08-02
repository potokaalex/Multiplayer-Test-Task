using System.Collections.Generic;
using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Coin.Network;
using CodeBase.Gameplay.Player.Network;
using CodeBase.Infrastructure.Game;
using CodeBase.Infrastructure.Game.Data;
using CodeBase.Infrastructure.Services.Data;
using UnityEngine;

namespace CodeBase.Gameplay.Coin.Object
{
    public class CoinObjectFactory
    {
        private readonly Dictionary<CoinObject, int> _coins = new();
        private readonly IDataProvider _dataProvider;
        private readonly CoinNetwork _coinNetwork;
        private readonly PlayerNetwork _playerNetwork;

        private CoinStaticData _coinStaticData;
        private GameSceneData _sceneData;

        public CoinObjectFactory(IDataProvider dataProvider, CoinNetwork coinNetwork, PlayerNetwork playerNetwork)
        {
            _dataProvider = dataProvider;
            _coinNetwork = coinNetwork;
            _playerNetwork = playerNetwork;
        }

        public void Initialize()
        {
            _coinStaticData = _dataProvider.Get<CoinStaticData>();
            _sceneData = _dataProvider.Get<GameSceneData>();
        }

        public void CreateCoin()
        {
            if (!IsCanCreateCoin(_sceneData.CoinSpawnPoints.Length))
                return;

            var id = GetNewCoinId(_sceneData.CoinSpawnPoints.Length);
            var position = _sceneData.CoinSpawnPoints[id].position;
            var coin = _coinNetwork.CreateCoin(_coinStaticData.CoinObjectPrefab, position);

            _coins.Add(coin, id);
            coin.Constructor(this, _playerNetwork);
        }

        public void DestroyCoin(CoinObject coinObject)
        {
            _coinNetwork.DestroyCoin(coinObject);
            _coins.Remove(coinObject);
        }

        private bool IsCanCreateCoin(int maxCount) => _coinNetwork.IsMasterClient() && _coins.Count < maxCount;

        private int GetNewCoinId(int maxCount)
        {
            var id = Random.Range(0, maxCount);

            if (!_coins.ContainsValue(id))
                return id;

            for (var i = 0; i < maxCount; i++)
                if (!_coins.ContainsValue(i))
                    return i;

            return -1;
        }
    }
}