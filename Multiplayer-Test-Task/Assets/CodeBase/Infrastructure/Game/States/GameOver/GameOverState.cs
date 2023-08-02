using CodeBase.Infrastructure.Game.UI;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.Game.States.GameOver
{
    public class GameOverState : IStateWithParameter<GameOverStateParameter>
    {
        private readonly GameUIFactory _gameUIFactory;
        private GameOverUI _gameOverUI;

        public GameOverState(GameUIFactory gameUIFactory)
        {
            _gameUIFactory = gameUIFactory;
        }

        public void Enter(GameOverStateParameter parameter)
        {
            _gameOverUI = _gameUIFactory.CreateGameOverUI();
            _gameOverUI.InitializeUI(parameter.WinnerColor, parameter.WinnerCoinsCount);
        }

        public void Exit()
        {
            _gameOverUI.DisposeUI();
            _gameUIFactory.DestroyGameOverUI(_gameOverUI);
        }
    }
}