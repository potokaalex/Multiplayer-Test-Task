using CodeBase.Gameplay.Player.Data;
using CodeBase.Infrastructure.Project.Services.Data;

namespace CodeBase.Gameplay.Player.UI
{
    public class PlayerUIFactory
    {
        private readonly IDataProvider _dataProvider;
        private PlayerStaticData _playerStaticData;
        private PlayerUI _ui;

        public PlayerUIFactory(IDataProvider dataProvider) => _dataProvider = dataProvider;

        public void Initialize() => _playerStaticData = _dataProvider.Get<PlayerStaticData>();

        public void CreateUI() => _ui = UnityEngine.Object.Instantiate(_playerStaticData.UIPrefab);

        public void DestroyUI() => UnityEngine.Object.Destroy(_ui.gameObject);

        public PlayerUI GetUI() => _ui;
    }
}