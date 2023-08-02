using CodeBase.Gameplay.Player.Coins;
using CodeBase.Gameplay.Player.Data;
using CodeBase.Gameplay.Player.Health;
using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.Network;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Gameplay.Player.Weapon;
using CodeBase.Infrastructure.Game;
using CodeBase.Infrastructure.Game.Data;
using CodeBase.Infrastructure.Game.Network;
using CodeBase.Infrastructure.Services.Data;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly PlayerNetwork _playerNetwork;

        private Transform[] _spawnPoints;
        private PlayerStaticData _staticData;

        public PlayerObjectFactory(IDataProvider dataProvider, PlayerNetwork playerNetwork)
        {
            _dataProvider = dataProvider;
            _playerNetwork = playerNetwork;
        }

        public void Initialize()
        {
            _spawnPoints = _dataProvider.Get<GameSceneData>().PlayerSpawnPoints;
            _staticData = _dataProvider.Get<PlayerStaticData>();
        }

        public PlayerObject CreatePlayer(IPlayerUI ui, IPlayerWeapon weapon)
        {
            var index = _playerNetwork.GetPlayerIndex();
            var position = _spawnPoints[index].position;
            var color = new NetworkColor(_staticData.PlayerColors[index]);
            var gameObject = _playerNetwork.CreatePlayer(_staticData.PlayerObjectPrefab, position, color);
            var playerObject = gameObject.GetComponent<PlayerObject>();

            ConstructPlayer(playerObject, ui, weapon);

            return playerObject;
        }

        private void ConstructPlayer(PlayerObject playerObject, IPlayerUI ui, IPlayerWeapon weapon)
        {
            var movement = new PlayerMovement(playerObject.Rigidbody, _staticData.PositionVelocity);
            var health = new PlayerHealth(_staticData.MaxHealth, _staticData.MaxHealth);
            var coins = new PlayerCoins();

            playerObject.Constructor(ui, movement, weapon, health, coins, _staticData.CreationLayerID);
        }

        public void DestroyPlayer() => _playerNetwork.DestroyPlayer();
    }
}