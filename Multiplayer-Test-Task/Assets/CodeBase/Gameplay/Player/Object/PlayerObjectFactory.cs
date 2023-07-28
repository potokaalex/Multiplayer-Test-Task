using CodeBase.Gameplay.Player.Movement;
using CodeBase.Gameplay.Player.UI;

namespace CodeBase.Gameplay.Player.Object
{
    public class PlayerObjectFactory
    {
        private readonly PlayerStaticData _data;

        public PlayerObjectFactory(PlayerStaticData data) => _data = data;

        public PlayerObject CreatePlayer(IPlayerUIMediator uiMediator)
        {
            var objectView = UnityEngine.Object.Instantiate(_data.ObjectViewPrefab);
            var movement = new PlayerMovement(objectView.Rigidbody, _data.PositionVelocity);

            return new PlayerObject(uiMediator, movement);
        }
    }
}