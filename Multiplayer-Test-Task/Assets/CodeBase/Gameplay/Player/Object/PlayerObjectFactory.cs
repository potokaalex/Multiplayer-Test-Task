using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Player.Coins;
using CodeBase.Gameplay.Player.Health;
using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Gameplay.Player.Weapon;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectFactory
    {
        private readonly PlayerStaticData _data;
        private readonly Transform[] _spawnPoints;

        public PlayerObjectFactory(PlayerStaticData data, Transform[] spawnPoints)
        {
            _data = data;
            _spawnPoints = spawnPoints;
        }

        public PlayerObject CreatePlayer(IPlayerUIMediator uiMediator, BulletNetwork bulletNetwork, int index)
        {
            var gameObject = NetworkInstantiate(index);
            var playerObject = CreatePlayerObject(gameObject, uiMediator, bulletNetwork);

            return playerObject;
        }

        private GameObject NetworkInstantiate(int index)
        {
            var prefabName = _data.PlayerObjectPrefab.name;
            var position = _spawnPoints[index].position;
            var color = new PlayerColor(_data.PlayerColors[index]);
            var instantiateData = new object[] { color };

            return PhotonNetwork.Instantiate(prefabName, position, Quaternion.identity, 0, instantiateData);
        }

        private PlayerObject CreatePlayerObject(GameObject gameObject, IPlayerUIMediator uiMediator,
            BulletNetwork bulletNetwork)
        {
            var objectData = gameObject.GetComponent<PlayerObjectData>();
            var playerObject = gameObject.GetComponent<PlayerObject>();
            var movement = new PlayerMovement(objectData.Rigidbody, _data.PositionVelocity);
            var weapon = new PlayerWeapon(bulletNetwork, objectData.BulletSpawnPoint, objectData.Rigidbody, 300, -1);
            var health = new PlayerHealth(5, 5);
            var coins = new PlayerCoins(100, 0);

            playerObject.Constructor(uiMediator, movement, weapon, health, coins, _data.CreationLayerID);

            return playerObject;
        }
    }
}