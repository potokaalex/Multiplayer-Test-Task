using System;
using CodeBase.Infrastructure.Project.Services.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Game.Data
{
    [Serializable]
    public class GameSceneData : IDataToProvide
    {
        public Transform[] PlayerSpawnPoints;
        public Transform[] CoinSpawnPoints;
    }
}