namespace CodeBase.Gameplay.Player.UI
{
    public class PlayerUIFactory
    {
        private readonly PlayerStaticData _data;
        private PlayerUI _ui;

        public PlayerUIFactory(PlayerStaticData data) => _data = data;

        public PlayerUI CreateUI()
        {
            _ui = UnityEngine.Object.Instantiate(_data.UIPrefab);

            return _ui;
        }

        public PlayerUI GetUI() => _ui;
    }
}