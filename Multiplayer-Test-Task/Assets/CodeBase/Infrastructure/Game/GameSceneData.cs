using System;
using CodeBase.Infrastructure.Game.UI;
using CodeBase.Infrastructure.Services.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Game
{
    [Serializable]
    public class GameSceneData : IDataToProvide
    {
        public Transform[] PlayerSpawnPoints;
        public Transform[] CoinSpawnPoints;
        public GameUIMediator GameUI;
    }
}