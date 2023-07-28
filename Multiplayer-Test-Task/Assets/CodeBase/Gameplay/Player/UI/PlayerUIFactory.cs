namespace CodeBase.Gameplay.Player.UI
{
    public class PlayerUIFactory
    {
        private readonly PlayerStaticData _data;

        public PlayerUIFactory(PlayerStaticData data) => _data = data;

        public IPlayerUIMediator CreateUIMediator() => UnityEngine.Object.Instantiate(_data.UIMediatorPrefab);
    }
}