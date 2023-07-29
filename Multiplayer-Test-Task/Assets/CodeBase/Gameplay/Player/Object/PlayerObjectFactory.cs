using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.UI;
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

        public PlayerObject CreatePlayer(IPlayerUIMediator uiMediator, int index)
        {
            var gameObject = NetworkInstantiate(index);
            var playerObject = CreatePlayerObject(gameObject, uiMediator);

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

        private PlayerObject CreatePlayerObject(GameObject gameObject, IPlayerUIMediator uiMediator)
        {
            var objectData = gameObject.GetComponent<PlayerObjectData>();
            var playerObject = gameObject.GetComponent<PlayerObject>();
            var movement = new PlayerMovement(objectData.Rigidbody, _data.PositionVelocity);

            playerObject.Constructor(uiMediator, movement);

            return playerObject;
        }
    }
}