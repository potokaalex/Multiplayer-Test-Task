using CodeBase.Infrastructure.Game.Data;
using CodeBase.Infrastructure.Game.Network;
using CodeBase.Infrastructure.Project.Services.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Game.UI
{
    public class GameUIFactory
    {
        private readonly IDataProvider _dataProvider;
        private readonly GameNetwork _gameNetwork;
        private GameSceneStaticData _gameSceneStaticData;

        public GameUIFactory(IDataProvider dataProvider, GameNetwork gameNetwork)
        {
            _dataProvider = dataProvider;
            _gameNetwork = gameNetwork;
        }

        public void Initialize() => _gameSceneStaticData = _dataProvider.Get<GameSceneStaticData>();

        public WaitingUI CreateWaitingUI()
        {
            var ui = Object.Instantiate(_gameSceneStaticData.WaitingUIPrefab);

            ui.Constructor(_gameNetwork);

            return ui;
        }

        public void DestroyWaitingUI(WaitingUI ui) => Object.Destroy(ui.gameObject);

        public GameOverUI CreateGameOverUI()
        {
            var ui = Object.Instantiate(_gameSceneStaticData.GameOverUIPrefab);

            ui.Constructor(_gameNetwork);

            return ui;
        }

        public void DestroyGameOverUI(GameOverUI ui) => Object.Destroy(ui.gameObject);
    }
}