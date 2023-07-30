using System;
using CodeBase._dev;
using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Coin;
using CodeBase.Gameplay.Coin.Data;
using CodeBase.Gameplay.Player;
using CodeBase.Infrastructure.Services.SceneData;
using UnityEngine;

namespace CodeBase.Infrastructure.Game
{
    [Serializable]
    public class GameSceneData : ISceneData
    {
        public GameNetwork Network;
        
        public PlayerStaticData PlayerStaticData;
        public Transform[] PlayerSpawnPoints;

        public CoinStaticData CoinStaticData;
        public Transform[] CoinSpawnPoints;

        public BulletStaticData BulletStaticData;
    }
}